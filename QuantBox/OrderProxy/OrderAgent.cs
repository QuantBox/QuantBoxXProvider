using System;
using System.Threading;
using SmartQuant;

namespace QuantBox
{
    using System.Collections.Generic;
    using NLog;
    using OrderProxy;
    using ProcessorList = System.Collections.Generic.LinkedList<OrderProxy.OrderProcessor>;
    using ProcessorListNode = System.Collections.Generic.LinkedListNode<OrderProxy.OrderProcessor>;

    public struct InstTradingRules
    {
        /// <summary>
        /// 支持做空
        /// </summary>
        public bool HasShort;
        /// <summary>
        /// 支持市价
        /// </summary>
        public bool HasMarketOrder;
        /// <summary>
        /// T+1 平仓
        /// </summary>
        public bool DisableCloseToday;
        /// <summary>
        /// 平今优先
        /// </summary>
        public bool CloseTodayFirst;
        /// <summary>
        /// 严格的平今
        /// </summary>
        public bool StrictCloseToday;
    }

    public sealed class OrderAgent : SellSideStrategy, IProvider
    {
        internal readonly IdArray<InstTradingRules> instTradeInfoList = new IdArray<InstTradingRules>();
        private readonly IdArray<PositionManager> _managers = new IdArray<PositionManager>();
        private readonly ProcessorList _processors = new ProcessorList();
        private readonly OrderAgentInfo _info;
        private readonly Clock _eventClock;
        private readonly EventQueue _eventQueue;
        private Logger _logger = LogManager.CreateNullLogger();

        private void InitSubscription()
        {
            foreach (var s in framework.StrategyManager.GetStrategies()) {
                foreach ((Instrument inst, IExecutionProvider p) in s.GetExecutionProviderList()) {
                    if (p == null) {
                        continue;
                    }

                    if (p.Id != AgentId || !(p is OrderAgent)) {
                        continue;
                    }

                    if (inst == null) {
                        foreach (var item in s.Instruments) {
                            AddInstrument(item, s.GetDataProvider(item));
                        }
                        break;
                    }

                    AddInstrument(inst, s.GetDataProvider(inst));
                }
            }
        }

        private InstTradingRules DefaultTradingRules(Instrument inst)
        {
            return new InstTradingRules {
                HasShort = inst.Type == InstrumentType.Future || inst.Type == InstrumentType.FutureOption || inst.Type == InstrumentType.Option,
                DisableCloseToday = !(inst.Type == InstrumentType.Future || inst.Type == InstrumentType.FutureOption || inst.Type == InstrumentType.Option),
                HasMarketOrder = _info.SupportMarketOrderExchanges.Contains(inst.Exchange),
                CloseTodayFirst = _info.CloseTodayFirstExchanges.Contains(inst.Exchange),
                StrictCloseToday = _info.StrictCloseTodayExchanges.Contains(inst.Exchange),
            };
        }

        private void InitInstTradingRules()
        {
            foreach (var inst in framework.InstrumentManager.Instruments) {
                instTradeInfoList[inst.Id] = RulesGetter(inst);
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
                    OnMarketContinuous();
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

        private void OnMarketContinuous()
        {
            foreach (var item in _processors) {
                item.OnMarketContentious();
            }
        }

        internal ProcessorListNode AddProcessor(OrderProcessor p)
        {
            return _processors.AddLast(p);
        }

        internal void RemoveProcessor(OrderProcessor p)
        {
            _processors.Remove(p.listNode);
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

        internal Order CreateOrder(Order order, double qty)
        {
            return Order(order.Instrument, order.Type, order.Side, qty, order.StopPx, order.Price, order.Text);
        }

        internal void SendOrder(Order order)
        {
            order.Provider = ExecutionProvider;
            Send(order);
        }

        public const string DefaultName = "QBAgent";
        public OrderAgent(Framework framework, string name = DefaultName)
            : base(framework, name)
        {
            RulesGetter = DefaultTradingRules;
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
        public Func<Instrument, InstTradingRules> RulesGetter;

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

        public OrderAgent TradingRules(Func<Instrument, InstTradingRules> getter)
        {
            if (getter != null) {
                RulesGetter = getter;
            }
            return this;
        }

        /// <summary>
        /// 设置优先平金的交易所
        /// </summary>
        /// <param name="exchanges"></param>
        /// <returns></returns>
        public OrderAgent CloseTodayFirstExchanges(params string[] exchanges)
        {
            if (exchanges.Length > 0) {
                Info.CloseTodayFirstExchanges.Clear();
                foreach (var item in exchanges) {
                    if (!Info.CloseTodayFirstExchanges.Contains(item)) {
                        Info.CloseTodayFirstExchanges.Add(item);
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

        /// <summary>
        /// 反向开仓时先平后开
        /// </summary>
        /// <param name="enable"></param>
        /// <returns></returns>
        public OrderAgent CloseFirstOnReversing(bool enable)
        {
            Info.CloseFirstOnReversing = enable;
            return this;
        }

        #endregion

        public override void Connect()
        {
            if (Status != ProviderStatus.Disconnected) {
                return;
            }

            Status = ProviderStatus.Connecting;
            if (ExecutionProvider is XProvider x) {
                x.EventHappened += ProviderEventHappened;
            }
            InitInstTradingRules();
            InitSubscription();
            framework.StrategyManager.Strategy.AddStrategy(this);
        }

        public void LoadPositions()
        {
            foreach (var s in framework.StrategyManager.GetStrategies()) {
                GetPositionManager(s);
            }

            var processorList = new Dictionary<int, OrderProcessor>();
            foreach (var order in OrderManager.Orders) {
                if (order.IsDone || order.ProviderId != AgentId) {
                    continue;
                }

                var info = OrderExtensions.GetOrderInfo(order);
                info.processor = new OrderProcessor(this, order, _logger);
                processorList[order.Id] = (OrderProcessor)info.processor;
            }

            foreach (var order in OrderManager.Orders) {
                if (order.strategyId != Id) {
                    continue;
                }

                var info = OrderExtensions.GetOrderInfo(order);
                if (info.ParentOrderId == 0) {
                    continue;
                }

                if (!processorList.TryGetValue(info.ParentOrderId, out var processor)) {
                    continue;
                }
                switch (order.GetOpenClose()) {
                    case XApi.OpenCloseType.Undefined:
                    case XApi.OpenCloseType.Open:
                        processor.openOrder = order;
                        break;
                    case XApi.OpenCloseType.Close:
                        processor.closeOrder = order;
                        break;
                    case XApi.OpenCloseType.CloseToday:
                        processor.closeTodayOrder = order;
                        break;
                }
                if (!order.IsDone) {
                    info.processor = processor;
                }
            }

            foreach (var item in processorList) {
                item.Value.Do();
            }
        }

        protected override void OnProviderConnected(Provider provider)
        {
            if (provider.Id != ExecutionProvider.Id) {
                return;
            }

            if (Status != ProviderStatus.Connected) {
                Status = ProviderStatus.Connected;
            }
        }

        protected override void OnProviderDisconnected(Provider provider)
        {
            if (provider.Id == ExecutionProvider.Id) {
                Status = ProviderStatus.Disconnected;
            }
        }

        public override void OnSendCommand(ExecutionCommand cmd)
        {
            var order = cmd.Order;
            var info = OrderExtensions.GetOrderInfo(order);
            info.processor = new OrderProcessor(this, order, _logger);
            ((OrderProcessor)info.processor).Do();
        }

        public override void OnCancelCommand(ExecutionCommand cmd)
        {
            var order = cmd.Order;
            var info = OrderExtensions.GetOrderInfo(order);
            if (info.processor is OrderProcessor processor) {
                processor.Cancel();
            }
        }

        protected override void OnSendOrder(Order order)
        {
            var info = OrderExtensions.GetOrderInfo(order);
            if (info.processor is OrderProcessor processor) {
                processor.OnSendOrder(order);
            }
        }

        protected override void OnExecutionReport(ExecutionReport report)
        {
            var info = OrderExtensions.GetOrderInfo(report.Order);
            if (info.processor is OrderProcessor processor) {
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
            if (info.processor is OrderProcessor processor) {
                processor.OnReminder(dateTime, order);
            }
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
