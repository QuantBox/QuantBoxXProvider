using System;
using System.Runtime.CompilerServices;
using NLog;
using QuantBox.XApi;
using SmartQuant;

namespace QuantBox.OrderProxy
{
    using ExecType = SmartQuant.ExecType;
    using OrderSide = SmartQuant.OrderSide;
    using OrderStatus = SmartQuant.OrderStatus;
    using OrderType = SmartQuant.OrderType;
    using TimeInForce = SmartQuant.TimeInForce;
    using ProcessorListNode = System.Collections.Generic.LinkedListNode<OrderProcessor>;

    internal class OrderProcessor
    {
        private const int TimeOutOfBoundsError = 0;
        private const int PriceOutOfBoundsError = 0;

        private struct OpenCloseInfo
        {
            public double Open;
            public double Close;
            public double CloseToday;
        }

        protected readonly OrderAgent Agent;
        protected readonly Order Order;
        protected readonly PositionManager Manager;
        private readonly OrderRecord _record;
        private readonly QuantBoxOrderInfo _info;
        private OrderAgent.InstTradeInfo _tradeInfo;
        private readonly Logger _logger;
        private DepthMarketDataField _marketData = DepthMarketDataField.Empty;
        internal Order OpenOrder;
        internal Order CloseOrder;
        internal Order CloseTodayOrder;
        internal readonly ProcessorListNode ListNode;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SetMarketData()
        {
            if (double.IsNaN(_marketData.OpenPrice)) {
                _marketData = Order.Instrument.GetMarketData();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private double GetUpperLimitPrice()
        {
            return _marketData.UpperLimitPrice;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private double GetLowerLimitPrice()
        {
            return _marketData.LowerLimitPrice;
        }

        private Order CreateOrder(double qty, OpenCloseType openClose)
        {
            var order = Agent.CreateOrder(Order, qty);
            order.SetOpenClose(openClose);
            if (openClose == OpenCloseType.Open) {
                order.TimeInForce = Order.TimeInForce;
            }
            else {
                if (OpenOrder == null) {
                    order.TimeInForce = Order.TimeInForce;
                }
            }
            var info = OrderExtensions.GetOrderInfo(order);
            info.Processor = this;
            info.ParentOrderId = Order.Id;
            info.DeviationInfo = _info.DeviationInfo;
            info.DeviationMode = _info.DeviationMode;
            return order;
        }

        private void RecreateOrder(Order order, bool copyDeviationInfo = false)
        {
            var newOrder = CreateOrder(order.LeavesQty, order.GetOpenClose());
            if (copyDeviationInfo) {
                var info = OrderExtensions.GetOrderInfo(newOrder);
                var old = OrderExtensions.GetOrderInfo(order);
                info.DeviationInfo = old.DeviationInfo;
            }
            if (OpenOrder == order) {
                ClearOrder(ref OpenOrder);
                OpenOrder = newOrder;
            }
            else if (CloseOrder == order) {
                ClearOrder(ref CloseOrder);
                CloseOrder = newOrder;
            }
            else if (CloseTodayOrder == order) {
                ClearOrder(ref CloseTodayOrder);
                CloseTodayOrder = newOrder;
            }
        }

        #region Auto OpenClose
        private OpenCloseInfo GetOpenCloseInfo()
        {
            var info = new OpenCloseInfo();
            var p = Manager.GetPosition(Order.Instrument);
            var (closeQty, closeTodayQty) = GetCloseItems();

            var oc = Order.GetOpenClose();
            switch (oc) {
                case OpenCloseType.Undefined:
                    AutoOpenClose(false);
                    break;
                case OpenCloseType.Open:
                    info.Open = Order.Qty;
                    break;
                case OpenCloseType.Close:
                    AutoOpenClose();
                    break;
                case OpenCloseType.CloseToday:
                    info.CloseToday = Math.Min(Order.Qty, closeTodayQty);
                    break;
                default:
                    break;
            }
            return info;

            #region local
            (double, double) GetCloseItems()
            {
                double close, closeToday;
                if (Order.Side == OrderSide.Buy) {
                    (close, closeToday) = p.Short.GetCanCloseQty();
                }
                else {
                    (close, closeToday) = p.Long.GetCanCloseQty();
                }
                if (!_tradeInfo.CloseToday) {
                    close += closeToday;
                    closeToday = 0;
                }
                return (close, closeToday);
            }
            void AutoOpenClose(bool closeOnly = true)
            {
                var qty = Order.Qty;
                if (_tradeInfo.CloseToday) {
                    if (_tradeInfo.CloseTodayFirst) {
                        info.CloseToday = Math.Min(qty, closeTodayQty);
                        qty -= closeTodayQty;
                        if (qty <= 0) {
                            return;
                        }
                    }
                    info.Close = Math.Min(qty, closeQty);
                    qty -= closeQty;
                    if (qty <= 0) {
                        return;
                    }
                    if (!_tradeInfo.CloseTodayFirst) {
                        info.CloseToday = Math.Min(qty, closeTodayQty);
                        qty -= closeTodayQty;
                        if (qty <= 0) {
                            return;
                        }
                    }
                }
                else {
                    info.Close = Math.Min(qty, closeQty);
                    qty -= closeQty;
                    if (qty <= 0) {
                        return;
                    }
                }
                if (!closeOnly) {
                    info.Open = qty;
                }
            }
            #endregion
        }

        private void AutoCloseOpen()
        {
            var info = GetOpenCloseInfo();
            if (info.Open > 0 && OpenOrder == null) {
                OpenOrder = CreateOrder(info.Open, OpenCloseType.Open);
            }
            if (info.Close > 0 && CloseOrder == null) {
                CloseOrder = CreateOrder(info.Close, OpenCloseType.Close);
            }
            if (info.CloseToday > 0 && CloseTodayOrder == null) {
                CloseTodayOrder = CreateOrder(info.CloseToday, OpenCloseType.CloseToday);
            }
            _logger.Debug($"o:{info.Open},c:{info.Close},ct{info.CloseToday}");
        }
        #endregion

        private void SetOrderPrice(Order order, DeviationInfo info, bool marketToLimit = true)
        {
            if (marketToLimit) {
                order.Type = OrderType.Limit;
            }
            switch (info.PriceAdjustMethod) {
                case OrderPriceAdjustMethod.LowerUpperLimit:
                    if (_tradeInfo.MarketOrder) {
                        _logger.Debug($"{Order.Id}, adjust to market");
                        order.Type = OrderType.Market;
                        order.Price = 0;
                    }
                    else {
                        _logger.Debug($"{Order.Id}, adjust to lower_upper_limit");
                        order.Price = GetLowerUpperPrice();
                    }
                    break;
                case OrderPriceAdjustMethod.MatchPrice:
                    _logger.Debug($"{Order.Id}, adjust to match");
                    order.Price = GetMatchPrice();
                    break;
            }

            double GetLowerUpperPrice()
            {
                return order.Side == OrderSide.Buy ? GetUpperLimitPrice() : GetLowerLimitPrice();
            }

            double GetMatchPrice()
            {
                if (order.Side == OrderSide.Buy) {
                    return order.Instrument.Ask.Price + info.Slippage;
                }
                return order.Instrument.Bid.Price - info.Slippage;
            }
        }

        private void SendOrder(Order order, bool checkUpperLowerLimit)
        {
            if (IsNotSent(order)) {
                if (Order.Type == OrderType.Market) {
                    checkUpperLowerLimit = false;
                    if (!_tradeInfo.MarketOrder) {
                        Order.SetOrderType(OrderType.Limit);
                        SetOrderPrice(order, _info.Market2Limit);
                    }
                }
                else {
                    if (_info.DeviationMode != OrderDeviationMode.Disabled && _info.DeviationInfo.TryCount > 0) {
                        checkUpperLowerLimit = false;
                        SetOrderPrice(order, _info.DeviationInfo, false);
                    }
                }
                if (!checkUpperLowerLimit || (order.Price >= GetLowerLimitPrice() && order.Price <= GetUpperLimitPrice())) {
                    order.Send();
                }
                else {
                    _logger.Debug($"{Order.Id}, price_out_of_bounds");
                }
            }
        }

        private void SendOrder()
        {
            if (Order.Type == OrderType.Stop || Order.Type == OrderType.StopLimit) {
                return;
            }
            var checkUpperLowerLimit = false;
            switch (Agent.TradingStatus) {
                case XProviderEventType.MarketContinous:
                    checkUpperLowerLimit = true;
                    break;
                case XProviderEventType.MarketAuctionOrdering:
                    if (Order.Type == OrderType.Limit) {
                        break;
                    }
                    return;
                default:
                    return;
            }

            SendOrder(CloseOrder, checkUpperLowerLimit);
            SendOrder(CloseTodayOrder, checkUpperLowerLimit);
            if (IsNotSent(OpenOrder)) {
                if (!Agent.Info.CloseFirstOnReversing
                    || (IsFilled(CloseOrder) && IsFilled(CloseTodayOrder)))
                    SendOrder(OpenOrder, checkUpperLowerLimit);
            }
        }

        public OrderProcessor(OrderAgent agent, Order order, Logger logger)
        {
            Agent = agent;
            Order = order;
            Manager = agent.GetPositionManager(order.strategyId);
            ListNode = agent.AddProcessor(this);
            _record = new OrderRecord(order);
            _info = OrderExtensions.GetOrderInfo(order);
            _logger = logger;
            ResetInfo();
        }

        private void ResetInfo()
        {
            _tradeInfo = Agent.InstTradeInfoList[Order.Instrument.Id];
            _info.DeviationMode = GetMode();
            if (_info.DeviationMode != OrderDeviationMode.Disabled) {
                _info.Market2Limit.PriceAdjustMethod = GetMarket2LimitMethod();
            }

            OrderPriceAdjustMethod GetMarket2LimitMethod()
            {
                if (_info.Market2Limit.PriceAdjustMethod == OrderPriceAdjustMethod.Default) {
                    return Agent.Info.Market2Limit.PriceAdjustMethod;
                }
                return _info.Market2Limit.PriceAdjustMethod;
            }

            OrderDeviationMode GetMode()
            {
                if ((Order.Type == OrderType.Market || Order.Type == OrderType.Stop) && _tradeInfo.MarketOrder) {
                    return OrderDeviationMode.Disabled;
                }
                return _info.DeviationMode;
            }
        }

        public virtual void Do()
        {
            if (Order.Status == OrderStatus.PendingNew) {
                var report = new ExecutionReport(Order);
                report.ExecType = ExecType.ExecNew;
                report.OrdStatus = OrderStatus.New;
                Agent.EmitExecutionReport(report);
            }
            AutoCloseOpen();
            SendOrder();
        }

        private void CancelOrder(ref Order order)
        {
            if (!IsDone(order) && !IsNotSent(order)) {
                Agent.Cancel(order);
            }
            else {
                if (IsNotSent(OpenOrder)) {
                    ClearOrder(ref order);
                }
            }
        }

        public void Cancel()
        {
            _record.Cancelling = true;
            CancelOrder(ref OpenOrder);
            CancelOrder(ref CloseOrder);
            CancelOrder(ref CloseTodayOrder);
        }

        #region Process ExecutionReport 
        public virtual void OnExecutionReport(ExecutionReport report)
        {
            switch (report.ExecType) {
                case ExecType.ExecNew:
                    OnExecNew(report);
                    break;
                case ExecType.ExecRejected:
                    OnExecRejected(report);
                    break;
                case ExecType.ExecExpired:
                    OnExecExpired(report);
                    break;
                case ExecType.ExecTrade:
                    OnExecTrade(report);
                    break;
                case ExecType.ExecCancelled:
                    OnExecCancelled(report);
                    break;
                default:
                    return;
            }

            if (AllDone()) {
                if (report.ExecType != ExecType.ExecTrade) {
                    Agent.EmitExecutionReport(new ExecutionReport(Order) {
                        ExecType = report.ExecType,
                        OrdStatus = GetOrderStatus(),
                        Text = GetRejectedText()
                    });
                }
                Clear();
            }
        }

        private void ClearOrder(ref Order order)
        {
            if (order != null) {
                OrderExtensions.GetOrderInfo(order).Processor = null;
                order = null;
            }
        }

        private void Clear()
        {
            ClearOrder(ref OpenOrder);
            ClearOrder(ref CloseOrder);
            ClearOrder(ref CloseTodayOrder);
            Agent.RemoveProcessor(this);
        }

        private void OnExecCancelled(ExecutionReport report)
        {
            if (_record.Cancelling) {
                return;
            }
            switch (_info.DeviationMode) {
                case OrderDeviationMode.Time:
                case OrderDeviationMode.Trade:
                case OrderDeviationMode.QuoteAndTrade:
                    RecreateOrder(report.Order, true);
                    break;
                default:
                    break;
            }
        }

        private void OnExecNew(ExecutionReport report)
        {
            switch (_info.DeviationMode) {
                case OrderDeviationMode.Time:
                    Agent.AddReminder(_info.DeviationInfo.Threshold, report.Order);
                    break;
                case OrderDeviationMode.Trade:
                    break;
                case OrderDeviationMode.QuoteAndTrade:
                    break;
            }
        }

        private void OnExecTrade(ExecutionReport report)
        {
            _record.AddFill(report.LastPx, report.LastQty);
            if (IsNotSent(OpenOrder)) {
                if ((CloseOrder == null || CloseOrder.IsFilled)
                    && (CloseTodayOrder == null || CloseTodayOrder.IsFilled)) {
                    OpenOrder.Send();
                }
            }

            Agent.EmitExecutionReport(new ExecutionReport(Order) {
                ExecType = ExecType.ExecTrade,
                LastQty = report.LastQty,
                LastPx = report.LastPx,
                AvgPx = _record.AvgPx,
                LeavesQty = _record.LeavesQty,
                CumQty = _record.CumQty,
                OrdStatus = GetOrderStatus(),
                Text = GetRejectedText()
            });
        }

        private void OnExecRejected(ExecutionReport report)
        {
            if (_record.Cancelling) {
                return;
            }
            var (errorId, _) = report.GetErrorId();
            if (errorId == TimeOutOfBoundsError) {
                if (Agent.TradingStatus == XProviderEventType.MarketClosed) {
                    if (Order.TimeInForce == TimeInForce.GTC) {
                        RecreateOrder(report.Order);
                    }
                    return;
                }
                RecreateOrder(report.Order);
                return;
            }
            else if (errorId == PriceOutOfBoundsError && Order.TimeInForce == TimeInForce.GTC) {
                RecreateOrder(report.Order);
            }
        }

        private void OnExecExpired(ExecutionReport report)
        {
            if (_record.Cancelling) {
                return;
            }
            if (Order.TimeInForce == TimeInForce.GTC) {
                RecreateOrder(report.Order);
            }
        }

        private string GetRejectedText()
        {
            if (IsRejected(OpenOrder)) {
                return OpenOrder.Text;
            }
            if (IsRejected(CloseOrder)) {
                return OpenOrder.Text;
            }
            if (IsRejected(CloseTodayOrder)) {
                return OpenOrder.Text;
            }
            return string.Empty;
        }

        private OrderStatus GetOrderStatus()
        {
            if (AllDone()) {
                if (AllFilled()) {
                    if (_record.LeavesQty == 0) {
                        return OrderStatus.Filled;
                    }
                    else {
                        return OrderStatus.Rejected;
                    }
                }
                if (AnyCancenlled()) {
                    if (Order.TimeInForce != TimeInForce.GTC || _record.Cancelling) {
                        return OrderStatus.Cancelled;
                    }
                }
                if (AnyRejected()) {
                    if (Order.TimeInForce != TimeInForce.GTC || _record.Cancelling) {
                        return OrderStatus.Rejected;
                    }
                }
                if (AnyExpired()) {
                    if (Order.TimeInForce != TimeInForce.GTC || _record.Cancelling) {
                        return OrderStatus.Expired;
                    }
                }
            }
            return OrderStatus.PartiallyFilled;
        }

        #endregion

        #region Order Status Check
        private static bool IsNotSent(Order order) => order?.IsNotSent == true;
        private static bool IsCancenlled(Order order) => order?.IsCancelled == true;
        private static bool IsRejected(Order order) => order?.IsRejected == true;
        private static bool IsExpired(Order order) => order?.IsExpired == true;
        private static bool IsFilled(Order order) => order == null || order.IsFilled;
        private static bool IsDone(Order order) => order == null || order.IsDone;

        private bool AllDone() => IsDone(OpenOrder) && IsDone(CloseOrder) && IsDone(CloseTodayOrder);
        private bool AllFilled() => IsFilled(OpenOrder) && IsFilled(CloseOrder) && IsFilled(CloseTodayOrder);
        private bool AnyCancenlled() => IsCancenlled(OpenOrder) || IsCancenlled(CloseOrder) || IsCancenlled(CloseTodayOrder);
        private bool AnyRejected() => IsRejected(OpenOrder) || IsRejected(CloseOrder) || IsRejected(CloseTodayOrder);
        private bool AnyExpired() => IsExpired(OpenOrder) || IsExpired(CloseOrder) || IsExpired(CloseTodayOrder);
        #endregion

        #region Deviation
        public virtual void OnTrade(Instrument inst, Trade trade)
        {
            if (Order.Type == OrderType.Stop || Order.Type == OrderType.StopLimit) {
                if ((Order.Side == OrderSide.Buy && trade.Price >= Order.StopPx)
                    || (Order.Side == OrderSide.Sell && trade.Price <= Order.StopPx)) {
                    _logger.Debug($"{Order.Id} stop active");
                    Order.SetOrderType(Order.Type == OrderType.Stop ? OrderType.Market : OrderType.Limit);
                    SendOrder();
                }
            }
            else {
                if (_info.DeviationMode == OrderDeviationMode.QuoteAndTrade || _info.DeviationMode == OrderDeviationMode.Trade) {
                    CheckPriceDeviation(OpenOrder);
                    CheckPriceDeviation(CloseOrder);
                    CheckPriceDeviation(CloseTodayOrder);
                }
            }
        }

        private void CheckPriceDeviation(Order order)
        {
            var price = Order.Instrument.Trade.Price;
            var ask = Order.Instrument.Ask.Price;
            var bid = Order.Instrument.Bid.Price;

            if (IsDone(order) || IsNotSent(order)) {
                return;
            }
            var info = OrderExtensions.GetOrderInfo(order);
            if (Math.Abs(order.Price - price) > _info.DeviationInfo.Threshold) {                
                Do();
            }

            if (_info.DeviationMode == OrderDeviationMode.QuoteAndTrade) {
                if ((order.Side == OrderSide.Buy && Math.Abs(order.Price - ask) > _info.DeviationInfo.Threshold)
                    || (order.Side == OrderSide.Sell && Math.Abs(order.Price - bid) > _info.DeviationInfo.Threshold)) {
                    Do();
                }
            }

            void Do()
            {                
                if (CheckTryCount(info)) {
                    _logger.Debug($"{Order.Id}, price deviation {info.DeviationInfo.TryCount}.");
                    Agent.Cancel(order);
                }
                else {
                    DoFailed(order);
                }
            }
        }

        private bool CheckTryCount(QuantBoxOrderInfo info)
        {
            ++info.DeviationInfo.TryCount;
            return info.DeviationInfo.MaxTry == 0 || info.DeviationInfo.TryCount <= info.DeviationInfo.MaxTry;
        }

        private void DoFailed(Order order)
        {
            _logger.Debug($"{Order.Id}, deviation adjust failed.");
            _info.DeviationMode = OrderDeviationMode.Disabled;
            if (_info.FailedMethod == OrderAdjustFailedMethod.Cancel) {
                _record.Cancelling = true;
                Agent.Cancel(order);
            }
        }

        public virtual void OnReminder(DateTime dateTime, Order order)
        {            
            var info = OrderExtensions.GetOrderInfo(order);
            if (CheckTryCount(info)) {
                _logger.Debug($"{Order.Id}, time deviation {info.DeviationInfo.TryCount}.");
                Agent.Cancel(order);
            }
            else {
                DoFailed(order);
            }
        }
        #endregion

        public void OnMarketContinous()
        {
            SetMarketData();
            SendOrder();
        }

        public void OnMarketAuctionOrdering()
        {
            SendOrder();
        }

        internal void OnMarketClosed()
        {
        }
    }
}
