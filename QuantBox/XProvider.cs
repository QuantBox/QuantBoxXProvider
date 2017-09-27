using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Win32;
using NLog;
using QuantBox.XApi;
using SmartQuant;
using InstrumentType = SmartQuant.InstrumentType;

namespace QuantBox
{
    public partial class XProvider : Provider
    {
        private const string MsgProviderNotConnected = @"Provider is not connected.";

        private bool _qryInstrumentCompleted;
        private readonly List<Instrument> _instruments = new List<Instrument>();
        private int _tradingDataQueryInterval = 60;
        private TraderClient _trader;
        private MarketDataClient _md;
        private ApiType _providerCapacity;
        private EventQueue _accountQueue;

        private Logger _logger;
        private readonly ConnectManager _manager;
        private readonly TradingProcessor _processor;
        private readonly Convertor _convertor;
        private readonly TimedTask _timer;
        private readonly IEventEmitter _emitter;

        private void CancelInstrumentRequest(InstrumentDefinitionRequest request, string text)
        {
            EmitInstrumentDefinitionEnd(request.Id, RequestResult.Error, text);
        }

        private void SendInstrumentDefinition(InstrumentDefinitionRequest request, Instrument[] insts)
        {
            try {
                var data = QBHelper.FilterInstrument(request, insts);
                var definition = new InstrumentDefinition();
                definition.Instruments = data;
                definition.ProviderId = Id;
                definition.RequestId = request.Id;
                definition.TotalNum = data.Length;
                EmitInstrumentDefinition(definition);
                EmitInstrumentDefinitionEnd(request.Id, RequestResult.Completed, string.Empty);
            }
            catch (Exception ex) {
                CancelInstrumentRequest(request, ex.Message);
            }
        }

        private void InitQuery()
        {
            _qryInstrumentCompleted = false;
            _instruments.Clear();
        }

        private void ProviderInit()
        {
            GetCapacity();
            Settings = LoadSettings();
            _logger = LogManager.GetLogger(Settings.Name);
            id = Settings.Id;
            name = Settings.Name;
            description = Settings.Description;
            url = Settings.Url;
            _logger.Info("Provider Initialized.");
        }

        private void GetCapacity()
        {
            if (this is IInstrumentProvider) {
                _providerCapacity |= ApiType.Instrument;
            }
            if (this is IExecutionProvider) {
                _providerCapacity |= ApiType.Trade;
            }
            if (this is IDataProvider) {
                _providerCapacity |= ApiType.MarketData;
            }
        }

        private bool IsDataProvider => (_providerCapacity & ApiType.MarketData) == ApiType.MarketData;
        private bool IsExecutionProvider => (_providerCapacity & ApiType.Trade) == ApiType.Trade;
        private bool IsInstrumentProvider => (_providerCapacity & ApiType.Instrument) == ApiType.Instrument;

        #region Derived Override Method

        protected internal virtual string GetApiPath(string path)
        {
            var dllPath = QBHelper.MakeAbsolutePath(path);
            if (!File.Exists(dllPath)) {
                dllPath = QBHelper.MakeAbsolutePath(path, GetSmartQuantPath());
            }
            return dllPath;
        }

        protected internal virtual XTradingApi CreateXApi(string path)
        {
            return new XTradingApi(path);
        }

        protected internal virtual ServerInfoField GetServerInfo(int index)
        {
            return Settings.Servers[index].Get();
        }

        protected internal virtual UserInfoField GetUserInfo(int index)
        {
            return Settings.Users[index].Get();
        }

        protected virtual XProviderSettings LoadSettings()
        {
            return new XProviderSettings {
                Id = 50,
                Name = "xapi",
                Description = "XApi Provider",
                Url = "www.thanf.com",
                UserProductInfo = "OpenQuant"
            };
        }

        protected internal virtual void SaveSettings()
        {
            Settings.Save(QBHelper.GetConfigPath(Settings.Name));
        }

        protected internal virtual IDictionary<string, string> GetUserPropertyMap()
        {
            return null;
        }
        protected internal virtual IDictionary<string, string> GetServerPropertyMap()
        {
            return null;
        }
        #endregion

        #region Override Method

        protected override void OnConnect()
        {
            InitAccoutQueue();
            _emitter.Open();
            _processor.Open();
            _manager.Post(new OnConnect());
        }

        protected override void OnDisconnect()
        {
            _manager.Post(new OnDisconnect());
        }

        private new void EmitAccountData(AccountData data)
        {
            if (_accountQueue == null) {
                framework.EventManager.OnEvent(data);
                return;
            }
            _accountQueue.Enqueue(data);
        }

        private new void EmitAccountReport(AccountReport report, bool queued = true)
        {
            if (queued && _accountQueue != null) {
                _accountQueue.Enqueue(report);
                return;
            }
            framework.EventManager.OnEvent(report);
        }

        #endregion

        #region Message Handler

        private void InitAccoutQueue()
        {
            if (IsExecutionProvider) {
                _accountQueue = new EventQueue(2, 0, 2, 100, framework.EventBus);
                _accountQueue.Enqueue(new OnQueueOpened(_accountQueue));
                framework.EventBus.ExecutionPipe.Add(_accountQueue);
            }
        }

        private void ClearAccoutQueue()
        {
            if (IsExecutionProvider) {
                _accountQueue.Enqueue(new OnQueueClosed(_accountQueue));
                _accountQueue = null;
            }
        }

        private void StartTimerTask()
        {
            if (IsExecutionProvider) {
                _timer.Start();
            }
        }

        private void ConnectDone()
        {
            InitQuery();
            if (IsInstrumentProvider) {
                _trader.QueryInstrument();
                _logger.Info("开始查询合约......");
            }
            else {
                StartTimerTask();
            }
        }

        private void DisconnectDone()
        {
            _processor.Close();
            _emitter.Close();
            ClearAccoutQueue();
            _md = null;
            _trader = null;
            Status = ProviderStatus.Disconnected;
        }

        internal void OnProviderError(int errorId, string errorMsg)
        {
            _logger.Warn("id: {0}, msg: {1}", errorId, errorMsg);
            EmitError(errorId, errorId, errorMsg);
        }

        internal void OnClientConnected()
        {
            _manager.Post(new OnClientConnected());
        }

        internal void OnClientDisconnected()
        {
            _timer.Stop();
            _manager.Post(new OnClientDisconnected());
        }

        internal void OnMessage(ExecutionReport report)
        {
            _emitter.EmitExecutionReport(report);
        }

        internal void OnMessage(InstrumentField field, bool completed)
        {
            if (_qryInstrumentCompleted) {
                return;
            }
            if (field != null) {
                var inst = _convertor.GetInstument(field);
                switch (inst.Type) {
                    case InstrumentType.Stock:
                    case InstrumentType.Future:
                    case InstrumentType.Option:
                    case InstrumentType.FutureOption:
                        _instruments.Add(inst);
                        break;
                }
            }
            if (completed) {
                _instruments.Sort((x, y) => string.Compare(x.Symbol, y.Symbol, StringComparison.Ordinal));
                _qryInstrumentCompleted = true;
                _logger.Info($"合约查询完毕，收到{_instruments.Count}个合约");
                StartTimerTask();
            }
        }

        internal void OnMessage(PositionField data, bool completed)
        {
            if (data != null) {
                _convertor.ProcessPosition(data);
                _logger.Info(data.DebugInfo());
            }
            if (completed) {
                _timer.EnableQueryAccount = true;
            }
        }

        internal void OnMessage(AccountField data)
        {
            _convertor.ProcessAccount(data);
            _logger.Info(data.DebugInfo());
            _timer.EnableQueryPosition = true;
        }

        internal void OnMessage(DepthMarketDataField data)
        {
            _convertor.ProcessMarketData(data);
        }

        internal void OnMessage(TradeField field)
        {
            _processor.PostTrade(field);
        }

        internal void OnMessage(OrderField field)
        {
            _processor.PostRetrunOrder(field);
        }
        #endregion

        #region Custom Instrument Symbol       
        internal byte GetAltId()
        {
            return InstrumentAltId > 0 ? Id : (byte)InstrumentAltId;
        }

        internal (string, string) GetSymbolInfo(Instrument inst)
        {
            var altid = GetAltId();
            return (inst.GetSymbol(altid), inst.GetExchange(altid));
        }
        #endregion

        #region Static Member
        private static string GetSmartQuantPath()
        {
            var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{C224DA18-4901-433D-BD94-82D28B640B2C}");
            if (key != null) {
                var names = new List<string>(key.GetSubKeyNames());
                names.Sort();
                return key.GetValue("InstallLocation").ToString();
            }
            return Directory.GetParent(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)).FullName;
        }

        static XProvider()
        {
            const string nlogConfig = "NLog.config";
            var configFile = Path.Combine(QBHelper.BasePath, nlogConfig);
            if (!File.Exists(configFile)) {
                configFile = Path.Combine(GetSmartQuantPath(), nlogConfig);
            }
            if (File.Exists(configFile)) {
                LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(configFile, true);
            }
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomainOnAssemblyResolve;
        }

        private static Assembly CurrentDomainOnAssemblyResolve(object sender, ResolveEventArgs args)
        {
            var assemblyName = new AssemblyName(args.Name);
            var path = Path.Combine(QBHelper.BasePath, assemblyName.Name + ".dll");
            if (File.Exists(path)) {
                return Assembly.LoadFile(path);
            }
            return null;
        }
        #endregion

        public XProvider(Framework framework)
            : base(framework)
        {
            _manager = new ConnectManager(this);
            _processor = new TradingProcessor(this);
            _convertor = new Convertor(this);
            _timer = new TimedTask(this);
#if DEBUG
            _emitter = new EventDebugEmitter(this);
#else
            _emitter = new EventEmitter(this);
#endif
            ProviderInit();
        }

        public override void Send(ExecutionCommand command)
        {
            if (!IsExecutionProvider || !IsConnected) {
                EmitError(-1, -1, MsgProviderNotConnected);
                return;
            }
            switch (command.Type) {
                case ExecutionCommandType.Send:
                    _processor.PostNewOrder(command.Order);
                    break;
                case ExecutionCommandType.Cancel:
                    _processor.PostCancelOrder(command.Order);
                    break;
            }
        }

        public override void Subscribe(Instrument instrument)
        {
            if (!IsDataProvider || !IsConnected) {
                EmitError(-1, -1, MsgProviderNotConnected);
                return;
            }
            _md.Subscribe(instrument);
        }

        public override void Unsubscribe(Instrument instrument)
        {
            if (!IsDataProvider || !IsConnected) {
                EmitError(-1, -1, MsgProviderNotConnected);
                return;
            }
            _md.Unsubscribe(instrument);
        }

        public override void Send(InstrumentDefinitionRequest request)
        {
            if (!IsInstrumentProvider || !IsConnected) {
                CancelInstrumentRequest(request, MsgProviderNotConnected);
                return;
            }
            Task.Run(() => {
                SendInstrumentDefinition(request, _qryInstrumentCompleted ? _instruments.ToArray() : new Instrument[0]);
            });
        }

        [Browsable(false)]
        public XProviderSettings Settings { get; set; }

        #region UI
        private const string InfoSettings = "Information";
        [Category(InfoSettings)]
        [Description("版本")]
        [ReadOnly(true)]
        public string Version => QBHelper.GetVersionString();

        private const string CategorySettings = "Settings";
        [Category(CategorySettings)]
        [Description("综合设置")]
        [ReadOnly(true)]
        [Editor(typeof(Design.XApiSettingsTypeEditor), typeof(UITypeEditor))]
        public string Configuration { get; set; }

        private const string CategoryTrade = "Settings - Trade";
        [Category(CategoryTrade)]
        [Description("默认的投机保值设置")]
        public HedgeFlagType DefaultHedgeFlag { get; set; }

        [Category(CategoryTrade)]
        [Description("交易数据(资金持仓)查询间隔")]
        public int TradingDataQueryInterval {
            get => _tradingDataQueryInterval;
            set {
                if (value < 0) {
                    value = 1;
                }
                _tradingDataQueryInterval = value;
            }
        }

        [Category(CategoryTrade)]
        [Description("指定使用的合约附加信息")]
        [TypeConverter(typeof(Design.InstrumentProviderConverter))]
        public int InstrumentAltId { get; set; } = -1;

        #endregion
    }
}