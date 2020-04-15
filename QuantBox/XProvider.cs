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
using LogLevel = QuantBox.XApi.LogLevel;

namespace QuantBox
{
    using SmartQuant;
    //using InstrumentType = SmartQuant.InstrumentType;

    public partial class XProvider : Provider, IExecutionProvider, IDataProvider
    {
        private const string MsgNotSupportTrading = @"此插件没有交易功能.";
        private const string MsgNotSupportInstrument = @"此插件没有合约查询功能";
        private const string MsgNotConnected = @"此插件还没有完成服务器连接.";
        private const int DefaultInstrumentProvider = 60;

        internal bool qryInstrumentCompleted;
        private readonly List<Instrument> _instruments = new List<Instrument>();
        private int _tradingDataQueryInterval = 60;
        private int _connectTimeout = 2;

        private string _currentUserId;
        private string _currentUserPassword;
        private string _currentServer;

        private ApiType _providerCapacity;
        private EventQueue _accountQueue;

        private readonly DealProcessor _dealProcessor;
        private readonly Convertor _convertor;
        private readonly TimedTask _timer;
        private readonly SubscribeManager _subscribeManager;
        private readonly ConnectManager _connectManager;
        private readonly IEventEmitter _emitter;
        private readonly TickIdGen _idGen = new TickIdGen();
        private readonly List<ExecutionCommand> _pendingCommands = new List<ExecutionCommand>();
        private ICommissionProvider _commissionProvider;
        private Action<ExecutionCommand> _providerSetOrderId;
        internal const int LocalIdLength = 8;
        internal int localId;
        internal Logger logger;
        internal TraderClient trader;
        internal MarketDataClient market;

        protected internal bool volumeIsAccumulated = true;
        protected internal bool qryInstrumentUseMarketApi = false;

        private void SetOrderId(ExecutionCommand cmd)
        {
            if (string.IsNullOrEmpty(cmd.ProviderOrderId)) {
                var nextId = _idGen.Next().ToString();
                cmd.Order.ClOrderId = nextId;
                cmd.ClOrderId = nextId;
            }

            cmd.ProviderOrderId = Interlocked.Increment(ref localId).ToString($"D{LocalIdLength}");
            cmd.Order.ProviderOrderId = cmd.ProviderOrderId;

            var dateTime = DateTime.Now;
            if (DateTime.Today != trader.TradingDay) {
                dateTime = trader.TradingDay.Add(dateTime.TimeOfDay);
            }
            cmd.Order.TransactTime = dateTime;
            cmd.TransactTime = dateTime;
        }

        private void CancelInstrumentRequest(InstrumentDefinitionRequest request, string text)
        {
            EmitInstrumentDefinitionEnd(request.Id, RequestResult.Error, text);
        }

        private void SendInstrumentDefinition(InstrumentDefinitionRequest request, Instrument[] instruments)
        {
            try {
                var data = QBHelper.FilterInstrument(request, instruments);
                var definition = new InstrumentDefinition {
                    Instruments = data,
                    ProviderId = Id,
                    RequestId = request.Id,
                    TotalNum = data.Length
                };
                EmitInstrumentDefinition(definition);
                EmitInstrumentDefinitionEnd(request.Id, RequestResult.Completed, string.Empty);
            }
            catch (Exception ex) {
                CancelInstrumentRequest(request, ex.Message);
            }
        }

        private void InitQuery()
        {
            qryInstrumentCompleted = false;
            _instruments.Clear();
        }

        private void InstallProvider()
        {
            if (framework.ProviderManager.GetProvider(QuantBoxConst.PIdSimExec) == null) {
                framework.ProviderManager.AddProvider(new QBExecutionSimulator(framework));
            }
        }

        private void ProviderInit()
        {
            InstallProvider();
            GetCapacity();
            Settings = LoadSettings();
            LoadSessionTimes();
            logger = LogManager.GetLogger(Settings.Name);
            id = Settings.Id;
            name = Settings.Name;
            description = Settings.Description;
            url = Settings.Url;
            logger.Info("Provider Initialized.");
        }

        private void LoadSessionTimes()
        {
            SessionTimes = new BindingList<TimeRange>();
            SessionTimes.RaiseListChangedEvents = false;
            if (Settings.SessionTimes != null) {
                foreach (var range in Settings.SessionTimes) {
                    SessionTimes.Add(range);
                }
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

        private void OnMarketClose(DateTime dateTime, object data)
        {
            foreach (var provider in framework.ProviderManager.Providers) {
                if (provider is XProvider) {
                    CancelUndoneOrder(provider.Id);
                }
            }
            framework.StrategyManager.Global.Remove(QuantBoxConst.GlobalMarketCloseReminder);
        }

        private static readonly object Locker = new object();
        private void InitMarketCloseReminder()
        {
            if (MarketCloseTime == TimeSpan.Zero) {
                return;
            }
            lock (Locker) {
                var global = framework.StrategyManager.Global;
                if (global.ContainsKey(QuantBoxConst.GlobalMarketCloseReminder)) {
                    return;
                }

                global.Add(QuantBoxConst.GlobalMarketCloseReminder, string.Empty);
                var closeDate = trader.TradingDay.Add(MarketCloseTime);
                if (trader.TradingDay == DateTime.Today && DateTime.Now.TimeOfDay > MarketCloseTime) {
                    closeDate = TradingCalendar.Instance.GetNextTradingDay(DateTime.Today).Add(MarketCloseTime);
                }

                framework.Clock.AddReminder(OnMarketClose, closeDate);
            }
        }

        internal InstrumentManager InstrumentManager => framework.InstrumentManager;
        internal bool IsDataProvider => ConnectMarketData && (_providerCapacity & ApiType.MarketData) == ApiType.MarketData;
        internal bool IsExecutionProvider => ConnectTrader && (_providerCapacity & ApiType.Trade) == ApiType.Trade;
        internal bool IsInstrumentProvider => ConnectTrader && (_providerCapacity & ApiType.Instrument) == ApiType.Instrument;

        protected internal bool InTradingSession()
        {
            var time = DateTime.Now.TimeOfDay;

            if (AutoConnectUseTradingCalendar) {
                var date = DateTime.Now.Date;
                var calendar = TradingCalendar.Instance;
                if (!calendar.IsTradingDay(date)) {
                    if (calendar.IsHoliday(date)) {
                        return false;
                    }

                    if (DateTime.Today.DayOfWeek != DayOfWeek.Saturday || time > MarketNightCloseTime) {
                        return false;
                    }
                }
            }

            if (SessionTimes.Count == 0) {
                return true;
            }

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

        protected internal virtual XTradingApi CreateXApi(ConnectionInfo info)
        {
            return CreateXApi(info.ApiPath);
        }

        protected virtual ServerInfoField GetServerInfo(ServerInfo info)
        {
            return info.Get();
        }

        protected internal virtual ServerInfoField GetServerInfo(int index, ApiType type)
        {
            if (!string.IsNullOrEmpty(_currentServer)) {
                return GetServerInfo(_currentServer, type);
            }
            if (index < 0 || index >= Settings.Servers.Count) {
                return null;
            }
            return GetServerInfo(Settings.Servers[index]);
        }

        protected virtual ServerInfoField GetServerInfo(string key, ApiType type)
        {
            foreach (var server in Settings.Servers) {
                if (server.Name == key && (server.Type | type) == type) {
                    return GetServerInfo(server);
                }
            }
            return null;
        }

        protected virtual UserInfoField GetUserInfo(UserInfo user)
        {
            var info = user.Get();
            if (!string.IsNullOrEmpty(_currentUserId)) {
                info.UserID = _currentUserId;
                info.Password = _currentUserPassword;
            }
            return info;
        }

        protected internal virtual UserInfoField GetUserInfo(int index)
        {
            if (index < 0 || index >= Settings.Users.Count) {
                return null;
            }
            return GetUserInfo(Settings.Users[index]);
        }

        protected virtual XProviderSettings LoadSettings()
        {
            return new XProviderSettings {
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
            InitAccountQueue();
            _convertor.Init();
            _emitter.Open();
            _dealProcessor.Open();
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

        private void InitAccountQueue()
        {
            if (IsExecutionProvider) {
                _accountQueue = new EventQueue(2, 0, 2, 100, framework.EventBus);
                _accountQueue.Enqueue(new OnQueueOpened(_accountQueue));
                framework.EventBus.ExecutionPipe.Add(_accountQueue);
            }
        }

        private void ClearAccountQueue()
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

        private void ProcessPendingCommand()
        {
            lock (_pendingCommands) {
                if (_pendingCommands.Count <= 0) {
                    return;
                }

                foreach (var command in _pendingCommands) {
                    Send(command);
                }
                _pendingCommands.Clear();
            }
        }

        internal void ConnectDone()
        {
            ProcessPendingCommand();

            EventHappened?.Invoke(this, XProviderEventType.ConnectDone);
            if (MarketContinuousAfterConnectDone) {
                TradingStatus = InstrumentStatusType.Continous;
                EventHappened?.Invoke(this, XProviderEventType.MarketContinous);
            }
            InitQuery();
            if (IsInstrumentProvider) {
                logger.Info("开始查询合约......");
                if (!qryInstrumentUseMarketApi) {
                    trader.QueryInstrument();    
                }
                else {
                    market.QueryInstrument();
                }
            }
            else {
                StartTimerTask();
            }
        }

        internal void DisconnectDone()
        {
            _subscribeManager.Clear();
            _timer.Close();
            _dealProcessor.Close();
            _emitter.Close();
            ClearAccountQueue();
            market = null;
            trader = null;
            EventHappened?.Invoke(this, XProviderEventType.DisconnectDone);
        }

        internal void OnProviderLog(LogField log)
        {
            switch (log.Level) {
                case LogLevel.Trace:
                    logger.Trace(log.Message);
                    break;
                case LogLevel.Debug:
                    logger.Debug(log.Message);
                    break;
                case LogLevel.Info:
                    logger.Info(log.Message);
                    break;
                case LogLevel.Warn:
                    logger.Warn(log.Message);
                    break;
                case LogLevel.Error:
                    logger.Error(log.Message);
                    break;
                case LogLevel.Fatal:
                    logger.Fatal(log.Message);
                    break;
            }
        }

        internal void OnProviderError(ErrorField error)
        {
            if (error.XErrorId == 90) {

            }
            else {
                logger.Warn("id: {0}, msg: {1}, source: {2}", error.XErrorId, error.Text, error.Source);
                EmitError(error.XErrorId, error.RawErrorId, $"{error.Source}:{error.Text}");
            }
        }

        internal void OnProviderError(int errorId, string errorMsg)
        {
            logger.Warn("id: {0}, msg: {1}", errorId, errorMsg);
            EmitError(errorId, errorId, errorMsg);
        }

        private void MarketDataInit()
        {
        }

        internal void OnClientConnected(XApiClient client)
        {
            if (client == market) {
                if (!ConnectTrader) {
                    TradingCalendar.Instance.Init(DateTime.Today, host: DataHost);
                }
                _subscribeManager.Resubscribe();
                MarketDataInit();
            }

            if (client == trader) {
                TradingInit();
            }

            _connectManager.Post(new OnClientConnected());
        }

        internal void OnClientDisconnected(XApiClient client)
        {
            if (client == market) {
                _convertor.Reset();
            }
            _connectManager.Post(new OnClientDisconnected());
        }

        private DatabaseOrderServer GetPersistentServer()
        {
            if (framework.OrderServer is DatabaseOrderServer server
                && framework.OrderManager.IsPersistent) {
                return server;
            }
            return null;
        }

        private void TradingInit()
        {
            TradingCalendar.Instance.Init(trader.TradingDay, host: DataHost);
            InitMarketCloseReminder();
            var server = GetPersistentServer();
            localId = trader.OrderIdBase + 1;
            if (server != null) {
                _providerSetOrderId = _ => { };
                server.SetOrderId = SetOrderId;
                server.Settings.Set(ProviderSettingsType.TradingDay, trader.TradingDay);
                _dealProcessor.ProcessNoSent();
            }
            else {
                _providerSetOrderId = SetOrderId;
            }
        }

        public InstrumentStatusType TradingStatus { get; private set; } = InstrumentStatusType.NoTrading;

        internal void OnMessage(InstrumentStatusField field)
        {
            if (field.Status != TradingStatus) {
                TradingStatus = field.Status;
                if (TradingStatus == InstrumentStatusType.Closed) {
                    //CancelUndoneOrder();
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
            if (qryInstrumentCompleted) {
                return;
            }
            if (field != null) {
                var inst = _convertor.GetInstument(field);
                switch (inst.Type) {
                    case InstrumentType.Stock:
                    case InstrumentType.Future:
                    case InstrumentType.Option:
                    case InstrumentType.FutureOption:
                    case InstrumentType.MultiLeg:
                        _instruments.Add(inst);
                        break;
                }
            }
            if (completed) {
                _instruments.Sort((x, y) => string.Compare(x.Symbol, y.Symbol, StringComparison.Ordinal));
                qryInstrumentCompleted = true;
                logger.Info($"合约查询完毕，收到{_instruments.Count}个合约");
                logger.Info("开始查询资金和持仓......");
                trader.QueryAccount();
                trader.QueryPositions();
                StartTimerTask();
            }
        }

        internal void OnMessage(PositionField data)
        {
            if (data != null) {
                _convertor.ProcessPosition(data);
                logger.Info(data.DebugInfo());
            }
        }

        internal void OnMessage(AccountField data)
        {
            if (data != null) {
                _convertor.ProcessAccount(data);
                logger.Info(data.DebugInfo());
            }
        }

        internal void OnMessage(DepthMarketDataField data)
        {
            try {
                _convertor.ProcessMarketData(data);
            }
            catch (Exception e) {
                logger.Error(e);
                throw;
            }
        }

        internal void OnMessage(TradeField field)
        {
            _dealProcessor.PostTrade(field);
            if (QueryTradingDataAfterTrade) {
                trader.QueryAccount();
                trader.QueryPositions();
            }
        }

        internal void OnMessage(OrderField field)
        {
            _dealProcessor.PostReturnOrder(field);
        }

        internal void OnTraderCreated()
        {
            var server = GetPersistentServer();
            if (server == null) {
                return;
            }

            EventHappened?.Invoke(this, XProviderEventType.TraderCreated);
            var tradingDay = server.Settings.GetAsDateTime(ProviderSettingsType.TradingDay);
            if (tradingDay == DateTime.Today && DateTime.Now.TimeOfDay > MarketCloseTime) {
                //CancelUndoneOrder();
            }
            else {
                _dealProcessor.ProcessUndone(framework, tradingDay, server.GetTrades(tradingDay));
            }
        }

        private void CancelUndoneOrder(byte providerId)
        {
            foreach (var order in framework.OrderManager.Orders) {
                if (order.ProviderId == providerId && !order.IsDone) {
                    ProcessExpired(order);
                }
            }

            void ProcessExpired(Order order)
            {
                var report = new ExecutionReport(order) {
                    ExecType = ExecType.ExecExpired,
                    OrdStatus = OrderStatus.Expired
                };
                OnMessage(report);
            }
        }
        #endregion

        #region Internal Methods 

        internal void SubscribeDone(Instrument inst)
        {
            logger.Debug($"Provider subscribe {inst.Symbol}");
            if (IsExecutionProvider && SubscribeAndQueryQuote) {
                trader.QueryQuote(inst);
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
            _dealProcessor = new DealProcessor(this);
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
            if (!IsExecutionProvider) {
                EmitError(-1, -1, MsgNotSupportTrading);
                return;
            }

            if (!IsConnected) {
                lock (_pendingCommands) {
                    if (!IsConnected) {
                        _pendingCommands.Add(command);
                        return;
                    }
                }
            }
            switch (command.Type) {
                case ExecutionCommandType.Send:
                    _providerSetOrderId(command);
                    _dealProcessor.PostNewOrder(command.Order);
                    break;
                case ExecutionCommandType.Cancel:
                    _dealProcessor.PostCancelOrder(command.Order);
                    break;
            }
        }

        public override void Subscribe(Instrument instrument)
        {
            if (IsDataProvider) {
                instrument.SetTimeRange(TradingCalendar.Instance.GetTimeRange(instrument, DateTime.Today));
                _convertor.InitInstrument(instrument);
                _subscribeManager.Subscribe(instrument);
            }
        }

        public override void Unsubscribe(Instrument instrument)
        {
            if (IsDataProvider) {
                _convertor.RemoveInstrument(instrument);
                _subscribeManager.Unsubscribe(instrument);
            }
        }

        public override void Send(InstrumentDefinitionRequest request)
        {
            if (!IsConnected) {
                CancelInstrumentRequest(request, MsgNotConnected);
                return;
            }
            if (!IsInstrumentProvider) {
                CancelInstrumentRequest(request, MsgNotSupportInstrument);
                return;
            }
            Task.Run(() => {
                SendInstrumentDefinition(request, qryInstrumentCompleted ? _instruments.ToArray() : new Instrument[0]);
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
#if NETFRAMEWORK
        [Editor(typeof(Design.XApiSettingsTypeEditor), typeof(UITypeEditor))]
#endif
        public string Configuration { get; set; }

        [Category(CategorySettings)]
        [Description("交易日历服务地址")]
        public string DataHost { get; set; } = "data.quantbox.cn";

        private const string ConnectSettings = "AutoConnect";
        [Category(ConnectSettings)]
        [Description("是否启用自动连接")]
        public bool EnableAutoConnect { get; set; } = true;

        [Category(ConnectSettings)]
        [Description("交易时段列表，当前时间在这些列表中将启用重连机制，不在此列表中将主动断开，列表为空将不处理")]
        public BindingList<TimeRange> SessionTimes { get; set; }

        [Category(ConnectSettings)]
        [Description("自动连接中是否使用交易日历")]
        public bool AutoConnectUseTradingCalendar { get; set; } = true;

        [Category(ConnectSettings)]
        [Description("交易市场夜盘的关闭时间")]
        public TimeSpan MarketNightCloseTime { get; set; } = new TimeSpan(2, 40, 0);

        [Category(ConnectSettings)]
        [Description("自动重连时的连接超时设置(分钟)")]
        public int ConnectTimeout
        {
            get => _connectTimeout;
            set { _connectTimeout = Math.Max(value, 2); }
        }

        private const string CategoryTrade = "Settings - Trade";

        [Category(CategoryTrade)]
        [Description("交易市场的关闭时间，插件在这个时间取消未完成的订单")]
        public TimeSpan MarketCloseTime { get; set; } = new TimeSpan(16, 0, 0);

        [Category(CategoryTrade)]
        [Description("默认的投机保值设置")]
        public HedgeFlagType DefaultHedgeFlag { get; set; } = HedgeFlagType.Speculation;

        [Category(CategoryTrade)]
        [Description("成交后查询资金持仓")]
        public bool QueryTradingDataAfterTrade { get; set; } = true;

        [Category(CategoryTrade)]
        [Description("资金持仓查询间隔(秒)")]
        public int TradingDataQueryInterval
        {
            get => _tradingDataQueryInterval;
            set {
                if (value < 0) {
                    value = 1;
                }
                _tradingDataQueryInterval = value;
            }
        }

        [Category(CategoryTrade)]
        [Description("连接行情服务")]
        public bool ConnectMarketData { get; set; } = true;

        [Category(CategoryTrade)]
        [Description("连接交易服务")]
        public bool ConnectTrader { get; set; } = true;

        [Category(CategoryTrade)]
        [Description("交易连接成功后就进入连续交易状态")]
        public bool MarketContinuousAfterConnectDone { get; set; } = false;

        private const string CategoryMarketData = "Settings - MarketData";
        [Category(CategoryMarketData)]
        [Description("启动行情调试日志")]
        public bool EnableMarketLog { get; set; } = false;

        [Category(CategoryMarketData)]
        [Description("获取交易所合约代码")]
#if NETFRAMEWORK
        [TypeConverter(typeof(Design.InstrumentProviderConverter))]
#endif
        public int InstrumentAltId { get; set; } = DefaultInstrumentProvider;

        [Category(CategoryMarketData)]
        [Description("启用夜盘行情时间修正")]
        public bool NightTradingTimeCorrection { get; set; } = false;

        [Category(CategoryMarketData)]
        [Description("过滤成交量为零的行情")]
        public bool DiscardEmptyTrade { get; set; } = true;

        [Category(CategoryMarketData)]
        [Description("过滤非交易时间的行情")]
        public bool DiscardOutOfTimeRange { get; set; } = true;

        [Category(CategoryMarketData)]
        [Description("交易所和本地之间的最大时差,超过这个设定的行情将被过滤(单位: 分钟)")]
        public int MaxTimeDiffExchangeLocal { get; set; } = 60;

        [Category(CategoryMarketData)]
        [Description("在订阅行情的同时通过交易接口查询行情,解决融航柜台无法报单的问题")]
        public bool SubscribeAndQueryQuote { get; set; } = false;

        #endregion
    }
}