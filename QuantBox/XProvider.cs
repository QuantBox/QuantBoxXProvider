using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using NLog;
using QuantBox.XApi;
using Skyline;

namespace QuantBox
{
    using SmartQuant;
    //using InstrumentType = SmartQuant.InstrumentType;

    public partial class XProvider : Provider, IExecutionProvider, IDataProvider
    {
        private const string MsgProviderNotConnected = @"Provider is not connected.";
        private const int DefaultInstrumentProvider = 60;

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
        private ICommissionProvider _commissionProvider;
        private int _orderId;
        private string _orderPrefix;
        private Action<ExecutionCommand> _providerSetOrderId;

        internal Logger Logger;
        internal TraderClient Trader;
        internal MarketDataClient Market;

        protected internal bool VolumeIsAccumulated = true;

        private void SetOrderId(ExecutionCommand msg)
        {
            var nextId = Interlocked.Increment(ref _orderId).ToString("D8");
            if (!string.IsNullOrEmpty(_orderPrefix))
            {
                nextId = _orderPrefix + nextId;
            }
            msg.Order.ClOrderId = nextId;
            msg.ClOrderId = nextId;
            var dateTime = DateTime.Now;
            if (DateTime.Today != Trader.TradingDay)
            {
                dateTime = Trader.TradingDay.Add(dateTime.TimeOfDay);
            }
            msg.Order.TransactTime = dateTime;
            msg.TransactTime = dateTime;
        }

        private void CancelInstrumentRequest(InstrumentDefinitionRequest request, string text)
        {
            EmitInstrumentDefinitionEnd(request.Id, RequestResult.Error, text);
        }

        private void SendInstrumentDefinition(InstrumentDefinitionRequest request, Instrument[] insts)
        {
            try
            {
                var data = QBHelper.FilterInstrument(request, insts);
                var definition = new InstrumentDefinition();
                definition.Instruments = data;
                definition.ProviderId = Id;
                definition.RequestId = request.Id;
                definition.TotalNum = data.Length;
                EmitInstrumentDefinition(definition);
                EmitInstrumentDefinitionEnd(request.Id, RequestResult.Completed, string.Empty);
            }
            catch (Exception ex)
            {
                CancelInstrumentRequest(request, ex.Message);
            }
        }

        private void InitQuery()
        {
            QryInstrumentCompleted = false;
            _instruments.Clear();
        }

        private void InstallProvider()
        {
            if (framework.ProviderManager.GetProvider(QuantBoxConst.PIdSimExec) == null)
            {
                framework.ProviderManager.AddProvider(new QBExecutionSimulator(framework));
            }
        }

        private void ProviderInit()
        {
            InstallProvider();
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
            if (Settings.SessionTimes != null)
            {
                foreach (var range in Settings.SessionTimes)
                {
                    SessionTimes.Add(range);
                }
            }
            SessionTimes.RaiseListChangedEvents = true;
            SessionTimes.ListChanged += SessionTimesOnListChanged;
        }

        private void SessionTimesOnListChanged(object sender, ListChangedEventArgs args)
        {
            Settings.SessionTimes.Clear();
            foreach (var range in SessionTimes)
            {
                Settings.SessionTimes.Add(range);
            }
            SaveSettings();
        }

        private void GetCapacity()
        {
            if (this is IInstrumentProvider)
            {
                _providerCapacity |= ApiType.Instrument;
            }
            if (this is IExecutionProvider)
            {
                _providerCapacity |= ApiType.Trade;
            }
            if (this is IDataProvider)
            {
                _providerCapacity |= ApiType.MarketData;
            }
        }

        internal InstrumentManager InstrumentManager => framework.InstrumentManager;
        internal bool IsDataProvider => ConnectMarketData && (_providerCapacity & ApiType.MarketData) == ApiType.MarketData;
        internal bool IsExecutionProvider => ConnectTrader && (_providerCapacity & ApiType.Trade) == ApiType.Trade;
        internal bool IsInstrumentProvider => ConnectTrader && (_providerCapacity & ApiType.Instrument) == ApiType.Instrument;

        protected internal bool InTradingSession()
        {
            if (SessionTimes.Count == 0)
            {
                return true;
            }
            var time = DateTime.Now.TimeOfDay;
            time = new TimeSpan(time.Hours, time.Minutes, time.Seconds);
            foreach (var range in SessionTimes)
            {
                if (time >= range.Begin && time <= range.End)
                {
                    return true;
                }
            }
            return false;
        }

        #region Derived Override Methods

        protected internal virtual string GetApiPath(string path)
        {
            var dllPath = QBHelper.MakeAbsolutePath(path, Installation.ConfigDir.FullName);
            if (!File.Exists(dllPath))
            {
                dllPath = QBHelper.MakeAbsolutePath(path);
            }
            return dllPath;
        }

        protected internal virtual XTradingApi CreateXApi(string path)
        {
            return new XTradingApi(GetApiPath(path));
        }

        protected virtual ServerInfoField GetServerInfo(ServerInfo info)
        {
            return info.Get();
        }

        protected internal virtual ServerInfoField GetServerInfo(int index, ApiType type)
        {
            if (!string.IsNullOrEmpty(_currentServer))
            {
                return GetServerInfo(_currentServer, type);
            }
            if (index < 0 || index >= Settings.Servers.Count)
            {
                return null;
            }
            return GetServerInfo(Settings.Servers[index]);
        }

        protected virtual ServerInfoField GetServerInfo(string key, ApiType type)
        {
            foreach (var server in Settings.Servers)
            {
                if (server.Name == key && (server.Type | type) == type)
                {
                    return GetServerInfo(server);
                }
            }
            return null;
        }

        protected virtual UserInfoField GetUserInfo(UserInfo user)
        {
            var info = user.Get();
            if (!string.IsNullOrEmpty(_currentUserId))
            {
                info.UserID = _currentUserId;
                info.Password = _currentUserPassword;
            }
            return info;
        }

        protected internal virtual UserInfoField GetUserInfo(int index)
        {
            if (index < 0 || index >= Settings.Users.Count)
            {
                return null;
            }
            return GetUserInfo(Settings.Users[index]);
        }

        protected virtual XProviderSettings LoadSettings()
        {
            return new XProviderSettings
            {
                Id = 60,
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
            if (_accountQueue == null)
            {
                framework.EventManager.OnEvent(data);
                return;
            }
            _accountQueue.Enqueue(data);
        }

        private new void EmitAccountReport(AccountReport report, bool queued = true)
        {
            if (queued && _accountQueue != null)
            {
                _accountQueue.Enqueue(report);
                return;
            }
            framework.EventManager.OnEvent(report);
        }

        #endregion

        #region Message Handlers

        private void InitAccoutQueue()
        {
            if (IsExecutionProvider)
            {
                _accountQueue = new EventQueue(2, 0, 2, 100, framework.EventBus);
                _accountQueue.Enqueue(new OnQueueOpened(_accountQueue));
                framework.EventBus.ExecutionPipe.Add(_accountQueue);
            }
        }

        private void ClearAccoutQueue()
        {
            if (_accountQueue != null)
            {
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
            EventHappened?.Invoke(this, XProviderEventType.ConnectDone);
            InitQuery();
            if (IsInstrumentProvider)
            {
                Logger.Info("开始查询合约......");
                Trader.QueryInstrument();
            }
            else
            {
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
            EventHappened?.Invoke(this, XProviderEventType.DisconnectDone);
        }

        internal void OnProviderError(ErrorField error)
        {
            if (error.XErrorId == 90)
            {

            }
            else
            {
                Logger.Warn("id: {0}, msg: {1}, source: {2}", error.XErrorId, error.Text, error.Source);
                EmitError(error.XErrorId, error.RawErrorId, $"{error.Source}:{error.Text}");
            }
        }

        internal void OnProviderError(int errorId, string errorMsg)
        {
            Logger.Warn("id: {0}, msg: {1}", errorId, errorMsg);
            EmitError(errorId, errorId, errorMsg);
        }

        internal void OnClientConnected(XApiClient client)
        {
            if (client == Market)
            {
                if (!ConnectTrader)
                {
                    TradingCalendar.Instance.Init(DateTime.Today);
                }
                _subscribeManager.Resubscribe();
            }

            if (client == Trader)
            {
                TradingInit();
            }

            _connectManager.Post(new OnClientConnected());
        }

        internal void OnClientDisconnected(XApiClient client)
        {
            if (client == Market)
            {
                _convertor.Reset();
            }
            _connectManager.Post(new OnClientDisconnected());
        }

        private DatabaseOrderServer GetPersistentServer()
        {
            if (framework.OrderServer is DatabaseOrderServer server
                && framework.OrderManager.IsPersistent)
            {
                return server;
            }
            return null;
        }

        private void TradingInit()
        {
            TradingCalendar.Instance.Init(Trader.TradingDay);
            var server = GetPersistentServer();
            _orderId = Trader.OrderIdBase + 1;
            _orderPrefix = Trader.OrderPrefix;
            if (server != null)
            {
                if (server.Settings.GetAsDateTime(ProviderSettingsType.TradingDay) == Trader.TradingDay
                    && int.TryParse(server.Settings.GetAsString(ProviderSettingsType.MaxLocalId), out var maxLocalId)
                    && _orderId < maxLocalId)
                {
                    _orderId = maxLocalId + 1;
                }
                _providerSetOrderId = _ => { };
                server.SetOrderId = SetOrderId;
                server.Settings.Set(ProviderSettingsType.TradingDay, Trader.TradingDay);
                _processor.ProcessNoSendOrders();
            }
            else
            {
                _providerSetOrderId = SetOrderId;
            }
        }

        internal void SetOrderIdBase(int orderId)
        {
            if (_orderId < orderId)
            {
                _orderId = orderId;
            }
        }

        public InstrumentStatusType TradingStatus { get; private set; } = InstrumentStatusType.NoTrading;

        internal void OnMessage(InstrumentStatusField field)
        {
            if (field.Status != TradingStatus)
            {
                TradingStatus = field.Status;
                if (TradingStatus == InstrumentStatusType.Closed)
                {
                    CancelUndoneOrder();
                }
                EventHappened?.Invoke(this, (XProviderEventType)field.Status);
            }
        }

        internal void OnMessage(ExecutionReport report)
        {
            _emitter.EmitExecutionReport(report);
        }

        internal void OnMessage(InstrumentField field, bool completed)
        {
            if (QryInstrumentCompleted)
            {
                return;
            }
            if (field != null)
            {
                var inst = _convertor.GetInstument(field);
                switch (inst.Type)
                {
                    case InstrumentType.Stock:
                    case InstrumentType.Future:
                    case InstrumentType.Option:
                    case InstrumentType.FutureOption:
                    case InstrumentType.MultiLeg:
                        _instruments.Add(inst);
                        break;
                }
            }
            if (completed)
            {
                _instruments.Sort((x, y) => string.Compare(x.Symbol, y.Symbol, StringComparison.Ordinal));
                QryInstrumentCompleted = true;
                Logger.Info($"合约查询完毕，收到{_instruments.Count}个合约");
                Logger.Info("开始查询资金和持仓......");
                Trader.QueryAccount();
                Trader.QueryPositions();
                StartTimerTask();
            }
        }

        internal void OnMessage(PositionField data)
        {
            if (data != null)
            {
                _convertor.ProcessPosition(data);
                Logger.Info(data.DebugInfo());
            }
        }

        internal void OnMessage(AccountField data)
        {
            if (data != null)
            {
                _convertor.ProcessAccount(data);
                Logger.Info(data.DebugInfo());
            }
        }

        internal void OnMessage(DepthMarketDataField data)
        {
            try
            {
                _convertor.ProcessMarketData(data);
            }
            catch (Exception e)
            {
                Logger.Error(e);
                throw;
            }
        }

        internal void OnMessage(TradeField field)
        {
            _processor.PostTrade(field);
            if (QueryTradingDataAfterTrade)
            {
                Trader.QueryAccount();
                Trader.QueryPositions();
            }
        }

        internal void OnMessage(OrderField field)
        {
            _processor.PostReturnOrder(field);
        }

        internal void OnTraderCreated()
        {
            var server = GetPersistentServer();
            if (server != null)
            {
                EventHappened?.Invoke(this, XProviderEventType.TraderCreated);
                var tradingDay = server.Settings.GetAsDateTime(ProviderSettingsType.TradingDay);
                if (tradingDay == DateTime.Today && DateTime.Now.TimeOfDay > MarketSettlementTime)
                {
                    //CancelUndoneOrder();
                }
                else
                {
                    _processor.LoadUndoneOrders(framework, tradingDay, server.GetTrades(tradingDay));
                }
            }
        }

        private void CancelUndoneOrder()
        {
            foreach (var order in framework.OrderManager.Orders)
            {
                if (order.ProviderId == id && !order.IsDone)
                {
                    ProcessExpired(order);
                }
            }

            void ProcessExpired(Order order)
            {
                var report = new ExecutionReport(order);
                report.ExecType = SmartQuant.ExecType.ExecExpired;
                report.OrdStatus = SmartQuant.OrderStatus.Expired;
                OnMessage(report);
            }
        }
        #endregion

        #region Internal Methods 

        internal void SubscribeDone(Instrument inst)
        {
            if (IsExecutionProvider && SubscribeAndQueryQuote)
            {
                Trader.QueryQuote(inst);
            }
        }

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
            EventHappened?.Invoke(this, XProviderEventType.AutoDisconnect);
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
            AssemblyResolver.AddPath(QBHelper.BasePath);
        }

        public static void BacktestInit(bool updateCalendar = false, string host = "data.quantbox.cn")
        {
            TradingCalendar.Instance.Init(DateTime.Today, updateCalendar, host);
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

        [Browsable(false)]
        public Framework Framework => framework;

        [Browsable(false)]
        public event Action<XProvider, XProviderEventType> EventHappened;

        public TraderClient CreateTrader(IXSpi spi)
        {
            return _connectManager.CreateTrader(spi);
        }

        public void SetConnectInfo(string server, string userId, string password)
        {
            _currentServer = server;
            _currentUserId = userId;
            _currentUserPassword = password;
        }

        public (string server, string user, string password) GetConnectInfo()
        {
            return (_currentServer, _currentUserId, _currentUserPassword);
        }

        public void SetCommissionProvider(ICommissionProvider commissionProvider)
        {
            _commissionProvider = commissionProvider;
        }

        public double GetCommission(ExecutionReport report)
        {
            return _commissionProvider?.GetCommission(report) ?? 0;
        }

        public override void Send(ExecutionCommand command)
        {
            if (!IsExecutionProvider || !IsConnected)
            {
                EmitError(-1, -1, MsgProviderNotConnected);
                return;
            }
            switch (command.Type)
            {
                case ExecutionCommandType.Send:
                    _providerSetOrderId(command);
                    _processor.PostNewOrder(command.Order);
                    break;
                case ExecutionCommandType.Cancel:
                    _processor.PostCancelOrder(command.Order);
                    break;
            }
        }

        public override void Subscribe(Instrument instrument)
        {
            if (IsDataProvider)
            {
                instrument.SetTimeRange(TradingCalendar.Instance.GetTimeRange(instrument, DateTime.Today));
                _convertor.InitInstrument(instrument);
                _subscribeManager.Subscribe(instrument);
            }
        }

        public override void Unsubscribe(Instrument instrument)
        {
            if (IsDataProvider)
            {
                _convertor.RemoveInstrument(instrument);
                _subscribeManager.Unsubscribe(instrument);
            }
        }

        public override void Send(InstrumentDefinitionRequest request)
        {
            if (!IsConnected)
            {
                CancelInstrumentRequest(request, MsgProviderNotConnected);
                return;
            }
            if (!IsInstrumentProvider)
            {
                CancelInstrumentRequest(request, "没有查询合约的功能");
                return;
            }
            Task.Run(() =>
            {
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
        public string Version => QBHelper.GetVersionString();

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
        public int ConnectTimeout
        {
            get => _connectTimeout;
            set {
                if (value < 2)
                {
                    value = 2;
                }
                _connectTimeout = value;
            }
        }

        private const string CategoryTrade = "Settings - Trade";

        [Category(CategoryTrade)]
        [Description("交易市场的关闭结算时间")]
        public TimeSpan MarketSettlementTime { get; set; } = new TimeSpan(17, 0, 0);

        [Category(CategoryTrade)]
        [Description("启动行情调试日志")]
        public bool EnableMarketLog { get; set; } = false;

        [Category(CategoryTrade)]
        [Description("默认的投机保值设置")]
        public HedgeFlagType DefaultHedgeFlag { get; set; }

        [Category(CategoryTrade)]
        [Description("成交后查询资金持仓")]
        public bool QueryTradingDataAfterTrade { get; set; } = true;

        [Category(CategoryTrade)]
        [Description("资金持仓查询间隔(秒)")]
        public int TradingDataQueryInterval
        {
            get => _tradingDataQueryInterval;
            set {
                if (value < 0)
                {
                    value = 1;
                }
                _tradingDataQueryInterval = value;
            }
        }

        [Category(CategoryTrade)]
        [Description("指定使用的合约附加信息")]
        [TypeConverter(typeof(Design.InstrumentProviderConverter))]
        public int InstrumentAltId { get; set; } = DefaultInstrumentProvider;

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
        [Description("过滤成交量为零的行情")]
        public bool DiscardEmptyTrade { get; set; } = true;

        [Category(CategoryTrade)]
        [Description("过滤非交易时间的行情")]
        public bool DiscardOutOfTimeRange { get; set; } = true;

        [Category(CategoryTrade)]
        [Description("交易所和本地之间的最大时差,超过这个设定的行情将被过滤(单位: 分钟)")]
        public int MaxTimeDiffExchangeLocal { get; set; } = 60;

        [Category(CategoryTrade)]
        [Description("在订阅行情的同时通过交易接口查询行情,解决融航柜台无法报单的问题")]
        public bool SubscribeAndQueryQuote { get; set; } = false;

        #endregion
    }
}