using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using NLog;
using QuantBox.XApi;
using SmartQuant;
using InstrumentType = SmartQuant.InstrumentType;

namespace QuantBox
{
    public partial class XProvider : Provider
    {
        private const string MsgProviderNotConnected = @"Provider is not connected.";

        internal bool QryInstrumentCompleted;
        private readonly List<Instrument> _instruments = new List<Instrument>();
        private int _tradingDataQueryInterval = 60;
        private int _connectTimeout = 2;

        private string _currentUserId;
        private string _currentUserPassword;
        private string _currentServer;

        private ApiType _providerCapacity;
        private EventQueue _accountQueue;

        private readonly DealProcessor _processor;
        private readonly Convertor _convertor;
        private readonly TimedTask _timer;
        private readonly SubscribeManager _subscribeManager;
        private readonly ConnectManager _connectManager;
        private readonly IEventEmitter _emitter;

        internal Logger Logger;
        internal TraderClient Trader;
        internal MarketDataClient Market;

        protected internal bool VolumeIsAccumulated = true;

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
            QryInstrumentCompleted = false;
            _instruments.Clear();
        }

        private void ProviderInit()
        {
            GetCapacity();
            Settings = LoadSettings();
            LoadSessionTimes();
            Logger = LogManager.GetLogger(Settings.Name);
            id = Settings.Id;
            name = Settings.Name;
            description = Settings.Description;
            url = Settings.Url;
            Logger.Info("Provider Initialized.");
        }

        private void LoadSessionTimes()
        {
            SessionTimes = new BindingList<TimeRange>();
            SessionTimes.RaiseListChangedEvents = false;
            foreach (var range in Settings.SessionTimes) {
                SessionTimes.Add(range);
            }
            SessionTimes.RaiseListChangedEvents = true;
            SessionTimes.ListChanged += SessionTimesOnListChanged;
        }

        private void SessionTimesOnListChanged(object sender, ListChangedEventArgs args)
        {
            Settings.SessionTimes.Clear();
            foreach (var range in SessionTimes) {
                Settings.SessionTimes.Add(range);
            }
            SaveSettings();
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

        internal InstrumentManager InstrumentManager => framework.InstrumentManager;
        internal bool IsDataProvider => ConnectMarketData && (_providerCapacity & ApiType.MarketData) == ApiType.MarketData;
        internal bool IsExecutionProvider => ConnectTrader && (_providerCapacity & ApiType.Trade) == ApiType.Trade;
        internal bool IsInstrumentProvider => ConnectTrader && (_providerCapacity & ApiType.Instrument) == ApiType.Instrument;

        protected internal bool InTradingSession()
        {
            if (SessionTimes.Count == 0) {
                return true;
            }
            var time = DateTime.Now.TimeOfDay;
            time = new TimeSpan(time.Hours, time.Minutes, time.Seconds);
            foreach (var range in SessionTimes) {
                if (time >= range.Begin && time <= range.End) {
                    return true;
                }
            }
            return false;
        }

        #region Derived Override Methods

        protected internal virtual string GetApiPath(string path)
        {
            var dllPath = QBHelper.MakeAbsolutePath(path, Installation.ConfigDir.FullName);
            if (!File.Exists(dllPath)) {
                dllPath = QBHelper.MakeAbsolutePath(path);
            }
            return dllPath;
        }

        protected internal virtual XTradingApi CreateXApi(string path)
        {
            return new XTradingApi(GetApiPath(path));
        }

        protected internal virtual ServerInfoField GetServerInfo(int index, ApiType type)
        {
            if (!string.IsNullOrEmpty(_currentServer)) {
                return GetServerInfo(_currentServer, type);
            }
            return Settings.Servers[index].Get();
        }

        protected virtual ServerInfoField GetServerInfo(string key, ApiType type)
        {
            foreach (var server in Settings.Servers) {
                if (server.Name == key && (server.Type | type) == type) {
                    return server.Get();
                }
            }
            return null;
        }

        protected internal virtual UserInfoField GetUserInfo(int index)
        {
            var info = Settings.Users[index].Get();
            if (!string.IsNullOrEmpty(_currentUserId)) {
                info.UserID = _currentUserId;
                info.Password = _currentUserPassword;
            }
            return info;
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

        protected virtual string GetSettingsFileName()
        {
            return GetType().Name;
        }

        protected internal virtual void SaveSettings()
        {
            Settings?.Save(QBHelper.GetConfigPath(GetSettingsFileName()));
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

        #region Override Methods

        protected override void OnConnect()
        {
            Status = ProviderStatus.Connecting;
            InitAccoutQueue();
            _convertor.Init();
            _emitter.Open();
            _processor.Open();
            _timer.Start();
            _connectManager.Post(new OnConnect());
        }

        protected override void OnDisconnect()
        {
            Status = ProviderStatus.Disconnecting;
            _connectManager.Post(new OnDisconnect());
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

        #region Message Handlers

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
            if (_accountQueue != null) {
                _accountQueue.Enqueue(new OnQueueClosed(_accountQueue));
                _accountQueue = null;
            }
        }

        internal void StartTimerTask()
        {
            _timer.Start();
        }

        internal void ConnectDone()
        {
            InitQuery();
            if (IsInstrumentProvider) {
                Trader.QueryInstrument();
                Logger.Info("开始查询合约......");
            }
            else {
                StartTimerTask();
            }
        }

        internal void DisconnectDone()
        {
            _subscribeManager.Clear();
            _timer.Close();
            _processor.Close();
            _emitter.Close();
            ClearAccoutQueue();
            Market = null;
            Trader = null;
        }

        internal void OnProviderError(int errorId, string errorMsg)
        {
            Logger.Warn("id: {0}, msg: {1}", errorId, errorMsg);
            EmitError(errorId, errorId, errorMsg);
        }

        internal void OnClientConnected(XApiClient client)
        {
            if (client == Market) {
                _subscribeManager.Resubscribe();
            }
            _connectManager.Post(new OnClientConnected());
        }

        internal void OnClientDisconnected()
        {
            _connectManager.Post(new OnClientDisconnected());
        }

        internal void OnMessage(ExecutionReport report)
        {
            _emitter.EmitExecutionReport(report);
        }

        internal void OnMessage(InstrumentField field, bool completed)
        {
            if (QryInstrumentCompleted) {
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
                QryInstrumentCompleted = true;
                Logger.Info($"合约查询完毕，收到{_instruments.Count}个合约");
                StartTimerTask();
            }
        }

        internal void OnMessage(PositionField data, bool completed)
        {
            if (data != null) {
                _convertor.ProcessPosition(data);
                Logger.Info(data.DebugInfo());
            }
            if (completed) {
                _timer.EnableQueryAccount = true;
            }
        }

        internal void OnMessage(AccountField data)
        {
            if (data != null) {
                _convertor.ProcessAccount(data);
                Logger.Info(data.DebugInfo());
            }
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

        #region Internal Methods 

        internal void ProcessMarketData(DataObject data)
        {
            _emitter.EmitData(data);
        }

        internal void ProcessAccount(AccountData data)
        {
            _emitter.EmitAccountData(data);
        }

        internal void AutoConnect()
        {
            _connectManager.Post(new OnAutoConnect());
        }

        internal void AutoDisconnect()
        {
            _connectManager.Post(new OnAutoDisconnect());
        }

        internal byte GetAltId()
        {
            return InstrumentAltId > 0 ? (byte)InstrumentAltId : Id;
        }

        internal (string, string) GetSymbolInfo(Instrument inst)
        {
            var altid = GetAltId();
            return (inst.GetSymbol(altid), inst.GetExchange(altid));
        }

        internal void SetStatus(ProviderStatus status)
        {
            Status = status;
        }
        #endregion

        #region Static Member
        static XProvider()
        {
            QBHelper.InitNLog();
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
            _connectManager = new ConnectManager(this);
            _subscribeManager = new SubscribeManager(this);
            _processor = new DealProcessor(this);
            _convertor = new Convertor(this);
            _timer = new TimedTask(this);
#if DEBUG
            //_emitter = new EventDebugEmitter(this);
            _emitter = new EventEmitter(this);
#else
            _emitter = new EventEmitter(this);
#endif
            ProviderInit();
        }

        ~XProvider()
        {
            SaveSettings();
        }

        public void SetConnectInfo(string server, string userId, string password)
        {
            _currentServer = server;
            _currentUserId = userId;
            _currentUserPassword = password;
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
            if (IsDataProvider) {
                instrument.SetTimeFilter(MarketDataFilter.Instance.GetFilter(instrument));
                _subscribeManager.Subscribe(instrument);
            }
        }

        public override void Unsubscribe(Instrument instrument)
        {
            if (IsDataProvider) {
                _subscribeManager.Unsubscribe(instrument);
            }
        }

        public override void Send(InstrumentDefinitionRequest request)
        {
            if (!IsConnected) {
                CancelInstrumentRequest(request, MsgProviderNotConnected);
                return;
            }
            if (!IsInstrumentProvider) {
                CancelInstrumentRequest(request, "没有查询合约的功能");
                return;
            }
            Task.Run(() => {
                SendInstrumentDefinition(request, QryInstrumentCompleted ? _instruments.ToArray() : new Instrument[0]);
            });
        }

        [Browsable(false)]
        public XProviderSettings Settings { get; set; }

        #region UI
        private const string InfoSettings = "Information";
        [Category(InfoSettings)]
        [Description("版本")]
        [ReadOnly(true)]
        public string Version => QBHelper.GetVersionString(GetType());

        private const string CategorySettings = "Settings";
        [Category(CategorySettings)]
        [Description("综合设置")]
        [ReadOnly(true)]
        [Editor(typeof(Design.XApiSettingsTypeEditor), typeof(UITypeEditor))]
        public string Configuration { get; set; }

        [Category(CategorySettings)]
        [Description("交易时段列表，当前时间在这些列表中将启用重连机制，不在此列表中将主动断开，列表为空将不处理")]
        public BindingList<TimeRange> SessionTimes { get; set; }

        [Category(CategorySettings)]
        [Description("自动重连时的连接超时设置(分钟)")]
        public int ConnectTimeout {
            get => _connectTimeout;
            set {
                if (value < 2) {
                    value = 2;
                }
                _connectTimeout = value;
            }
        }

        private const string CategoryTrade = "Settings - Trade";
        [Category(CategoryTrade)]
        [Description("默认的投机保值设置")]
        public HedgeFlagType DefaultHedgeFlag { get; set; }

        [Category(CategoryTrade)]
        [Description("资金持仓查询间隔(秒)")]
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

        [Category(CategoryTrade)]
        [Description("连接行情服务")]
        public bool ConnectMarketData { get; set; } = true;

        [Category(CategoryTrade)]
        [Description("连接交易服务")]
        public bool ConnectTrader { get; set; } = true;

        [Category(CategoryTrade)]
        [Description("启用夜盘行情时间修正")]
        public bool NightTradingTimeCorrection { get; set; } = false;

        [Category(CategoryTrade)]
        [Description("过滤非交易时间的行情")]
        public bool DiscardNoTrading { get; set; } = true;

        [Category(CategoryTrade)]
        [Description("过滤成交量为零的行情")]
        public bool DiscardEmptyTrade { get; set; } = true;

        #endregion
    }
}