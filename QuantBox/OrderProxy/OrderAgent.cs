using System;
using System.Threading;
using SmartQuant;

namespace QuantBox
{
    using System.Collections.Generic;
    using NLog;
    using QuantBox.OrderProxy;
    using ProcessorList = System.Collections.Generic.LinkedList<OrderProxy.OrderProcessor>;
    using ProcessorListNode = System.Collections.Generic.LinkedListNode<OrderProxy.OrderProcessor>;

    public class OrderAgent : SellSideStrategy, IProvider
    {
        private static volatile int _nextId;
        internal static int GetNextId()
        {
            return Interlocked.Increment(ref _nextId);
        }

        internal struct InstTradeInfo
        {
            public bool MarketOrder;
            public bool CloseToday;
            public bool CloseTodayFirst;
        }
        internal IdArray<InstTradeInfo> InstTradeInfoList = new IdArray<InstTradeInfo>();

        private readonly IdArray<PositionManager> _managers = new IdArray<PositionManager>();
        private readonly ProcessorList _processors = new ProcessorList();
        private readonly OrderAgentInfo _info;
        private readonly Clock _eventClock;
        private readonly EventQueue _eventQueue;
        private Logger _logger = LogManager.CreateNullLogger();

        private void InitSubscription()
        {
            foreach (var s in framework.StrategyManager.GetStrategies()) {
                foreach (var (inst, p) in s.GetExecutionProviderList()) {
                    if (p == null) {
                        continue;
                    }
                    if (p.Id == AgentId && p is OrderAgent agent) {
                        if (inst == null) {
                            foreach (var item in s.Instruments) {
                                AddInstrument(item, s.GetDataProvider(item));
                            }
                            break;
                        }
                        else {
                            AddInstrument(inst, s.GetDataProvider(inst));
                        }
                    }
                }
            }
        }

        private void InitInstTradingInfo()
        {
            foreach (var inst in framework.InstrumentManager.Instruments) {
                var info = new InstTradeInfo {
                    MarketOrder = _info.SupportMarketOrderExchanges.Contains(inst.Exchange),
                    CloseToday = _info.SupportCloseTodayExchanges.Contains(inst.Exchange),
                    CloseTodayFirst = _info.UseCloseTodayExchanges.Contains(inst.Exchange)
                };
                InstTradeInfoList[inst.Id] = info;
            }
        }

        private void OnMarketStatusEvent(DateTime dateTime, object data)
        {
            var type = (XProviderEventType)data;
            switch (type) {
                case XProviderEventType.MarketBeforeTrading:
                    break;
                case XProviderEventType.MarketNoTrading:
                    break;
                case XProviderEventType.MarketContinous:
                    OnMarketContinous();
                    break;
                case XProviderEventType.MarketAuctionOrdering:
                    OnMarketAuctionOrdering();
                    break;
                case XProviderEventType.MarketAuctionBalance:
                    break;
                case XProviderEventType.MarketAuctionMatch:
                    break;
                case XProviderEventType.MarketClosed:
                    OnMarketClosed();
                    break;
                default:
                    break;
            }
        }

        private void ProviderEventHappened(XProvider s, XProviderEventType type)
        {
            switch (type) {
                case XProviderEventType.TraderCreated:
                    LoadPositions();
                    break;
                case XProviderEventType.ConnectDone:
                    break;
                case XProviderEventType.DisconnectDone:
                    break;
                case XProviderEventType.AutoDisconnect:
                    break;
                default:
                    _logger.Debug($"{AgentId}, status={type}");
                    TradingStatus = type;
                    var reminder = new Reminder(OnMarketStatusEvent, DateTime.Now, type);
                    reminder.SetClock(_eventClock);
                    _eventQueue.Enqueue(reminder);
                    break;
            }
        }

        private void OnMarketAuctionOrdering()
        {
            foreach (var item in _processors) {
                item.OnMarketAuctionOrdering();
            }
        }

        private void OnMarketClosed()
        {
            foreach (var item in _processors) {
                item.OnMarketClosed();
            }
        }

        private void OnMarketContinous()
        {
            foreach (var item in _processors) {
                item.OnMarketContinous();
            }
        }

        internal ProcessorListNode AddProcessor(OrderProcessor p)
        {
            return _processors.AddLast(p);
        }

        internal void RemoveProcessor(OrderProcessor p)
        {
            _processors.Remove(p.ListNode);
        }

        internal PositionManager GetPositionManager(int strategyId)
        {
            var strategy = framework.StrategyManager.FindStrategy(strategyId);
            return GetPositionManager(strategy);
        }

        private PositionManager GetPositionManager(Strategy strategy)
        {
            var manager = _managers[strategy.Id];
            if (manager == null) {
                if (strategy is InstrumentStrategy iss && iss.IsInstance) {
                    manager = GetPositionManager(iss.Parent.Id);
                    _managers[strategy.Id] = manager;
                }
                else {
                    manager = new PositionManager(strategy.Portfolio);
                }
            }
            return manager;
        }

        private void ProcessCommand(ExecutionCommand command)
        {
            switch (command.Type) {
                case ExecutionCommandType.Send:
                    ProcessSend(command);
                    break;
                case ExecutionCommandType.Cancel:
                    ProcessCancel(command);
                    break;
                case ExecutionCommandType.Replace:
                    break;
            }
        }

        internal Order CreateOrder(Order order, double qty)
        {
            return Order(order.Instrument, order.Type, order.Side, qty, order.StopPx, order.Price, order.Text);
        }

        private void ProcessCancel(ExecutionCommand cmd)
        {
            var order = cmd.Order;
            var info = OrderExtensions.GetOrderInfo(order);
            if (info.Processor is OrderProcessor processor) {
                processor.Cancel();
            }
        }

        private void ProcessSend(ExecutionCommand cmd)
        {
            var order = cmd.Order;
            var info = OrderExtensions.GetOrderInfo(order);
            info.Processor = new OrderProcessor(this, order, _logger);
            ((OrderProcessor)info.Processor).Do();
        }

        public const string DefaultName = "QBAgent";
        public OrderAgent(Framework framework, string name = DefaultName)
            : base(framework, name)
        {
            Status = ProviderStatus.Disconnected;
            DataProvider = EmptyDataProvider.Instance;
            _info = OrderAgentInfo.Load();
            _eventClock = new Clock(framework);
            _eventClock.SetMode(ClockMode.Realtime);
            _eventQueue = new EventQueue(size: 10, bus: framework.EventBus);            
            framework.EventBus.ExecutionPipe.Add(_eventQueue);
        }
        byte IProvider.Id { get; set; }
        public byte AgentId => ((IProvider)this).Id;
        public OrderAgentInfo Info => _info;
        public XProviderEventType TradingStatus { get; private set; } = XProviderEventType.MarketNoTrading;

        #region Setting Functions
        public OrderAgent EnableLog(bool enable = true)
        {
            _logger = enable ? LogManager.GetLogger("order_agent") : LogManager.CreateNullLogger();
            return this;
        }
        public OrderAgent DefaultMarket2Limit(OrderPriceAdjustMethod method, byte slippage = 0)
        {
            Info.Market2Limit.PriceAdjustMethod = method;
            Info.Market2Limit.Slippage = slippage;
            return this;
        }

        public OrderAgent UseCloseTodayExchanges(params string[] exchanges)
        {
            if (exchanges.Length > 0) {
                Info.UseCloseTodayExchanges.Clear();
                foreach (var item in exchanges) {
                    if (!Info.UseCloseTodayExchanges.Contains(item)) {
                        Info.UseCloseTodayExchanges.Add(item);
                    }
                }
            }
            return this;
        }

        public OrderAgent SupportCloseTodayExchanges(params string[] exchanges)
        {
            if (exchanges.Length > 0) {
                Info.SupportCloseTodayExchanges.Clear();
                foreach (var item in exchanges) {
                    if (!Info.SupportCloseTodayExchanges.Contains(item)) {
                        Info.SupportCloseTodayExchanges.Add(item);
                    }
                }
            }
            return this;
        }

        public OrderAgent SupportMarketOrderExchanges(params string[] exchanges)
        {
            if (exchanges.Length > 0) {
                Info.SupportMarketOrderExchanges.Clear();
                foreach (var item in exchanges) {
                    if (!Info.SupportMarketOrderExchanges.Contains(item)) {
                        Info.SupportMarketOrderExchanges.Add(item);
                    }
                }
            }
            return this;
        }

        public OrderAgent CloseFirstOnReversing(bool enable)
        {
            Info.CloseFirstOnReversing = enable;
            return this;
        }

        public OrderAgent CloseTodayFirst(bool enable)
        {
            Info.CloseTodayFirst = enable;
            return this;
        }

        #endregion

        public override void Connect()
        {
            if (Status == ProviderStatus.Disconnected) {
                Status = ProviderStatus.Connecting;
                if (ExecutionProvider is XProvider x) {
                    x.EventHappened += ProviderEventHappened;
                }
                InitInstTradingInfo();
                InitSubscription();
                framework.StrategyManager.Strategy.AddStrategy(this);
            }
        }

        public void LoadPositions()
        {
            foreach (var s in framework.StrategyManager.GetStrategies()) {
                GetPositionManager(s);
            }

            var processorList = new Dictionary<int, OrderProcessor>();
            foreach (var order in OrderManager.Orders) {
                if (!order.IsDone && order.ProviderId == AgentId) {
                    var info = OrderExtensions.GetOrderInfo(order);
                    info.Processor = new OrderProcessor(this, order, _logger);
                    processorList[order.Id] = (OrderProcessor)info.Processor;
                }
            }

            foreach (var order in OrderManager.Orders) {
                if (order.strategyId == Id) {
                    var info = OrderExtensions.GetOrderInfo(order);
                    if (info.ParentOrderId != 0) {
                        if (!processorList.TryGetValue(info.ParentOrderId, out var processor)) {
                            continue;
                        }
                        switch (order.GetOpenClose()) {
                            case XApi.OpenCloseType.Undefined:
                            case XApi.OpenCloseType.Open:
                                processor.OpenOrder = order;
                                break;
                            case XApi.OpenCloseType.Close:
                                processor.CloseOrder = order;
                                break;
                            case XApi.OpenCloseType.CloseToday:
                                processor.CloseTodayOrder = order;
                                break;
                        }
                        if (!order.IsDone) {
                            info.Processor = processor;
                        }
                    }
                }
            }

            foreach (var item in processorList) {
                item.Value.Do();
            }
        }

        protected override void OnProviderConnected(Provider provider)
        {
            if (provider.Id == ExecutionProvider.Id) {
                if (Status != ProviderStatus.Connected) {
                    Status = ProviderStatus.Connected;
                }
            }
        }

        protected override void OnProviderDisconnected(Provider provider)
        {
            if (provider.Id == ExecutionProvider.Id) {
                Status = ProviderStatus.Disconnected;
            }
        }

        protected override void OnExecutionReport(ExecutionReport report)
        {
            var info = OrderExtensions.GetOrderInfo(report.Order);
            if (info.Processor is OrderProcessor processor) {
                processor.OnExecutionReport(report);
            }
        }

        protected override void OnTrade(Instrument instrument, Trade trade)
        {
            foreach (var item in _processors) {
                item.OnTrade(instrument, trade);
            }
        }

        protected override void OnReminder(DateTime dateTime, object data)
        {
            var order = (Order)data;
            if (order.IsDone) {
                return;
            }
            var info = OrderExtensions.GetOrderInfo(order);
            if (info.Processor is OrderProcessor processor) {
                processor.OnReminder(dateTime, order);
            }
        }

        public override void Send(ExecutionCommand command)
        {
            ProcessCommand(command);
        }

        protected override void OnStrategyStart()
        {
            Portfolio.Parent = null;
        }

        internal void AddReminder(int threshold, Order order)
        {
            AddReminder(Clock.DateTime.AddMilliseconds(threshold), order);
        }
    }
}
