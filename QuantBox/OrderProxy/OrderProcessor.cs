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

    internal sealed class OrderProcessor
    {
        private const int TimeOutOfBoundsError = 0;
        private const int PriceOutOfBoundsError = 0;

        private struct OpenCloseInfo
        {
            public double Open;
            public double Close;
            public double CloseToday;
        }

        private readonly OrderAgent _agent;
        private readonly Order _order;
        private readonly OrderRecord _record;
        private readonly DualPosition _position;
        private readonly QuantBoxOrderInfo _info;
        private InstTradingRules _rules;
        private readonly Logger _logger;
        private DepthMarketDataField _marketData = DepthMarketDataField.Empty;
        internal Order openOrder;
        internal Order closeOrder;
        internal Order closeTodayOrder;
        internal readonly ProcessorListNode listNode;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SetMarketData()
        {
            if (double.IsNaN(_marketData.OpenPrice)) {
                _marketData = _order.Instrument.GetMarketData();
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
            var order = _agent.CreateOrder(_order, qty);
            order.SetOpenClose(openClose);
            if (openClose == OpenCloseType.Open) {
                order.TimeInForce = _order.TimeInForce;
            }
            else {
                if (openOrder == null) {
                    order.TimeInForce = _order.TimeInForce;
                }
            }
            var info = OrderExtensions.GetOrderInfo(order);
            info.processor = this;
            info.ParentOrderId = _order.Id;
            info.DeviationInfo = _info.DeviationInfo;
            info.DeviationMode = _info.DeviationMode;
            return order;
        }

        private void RecreateOrder(Order order, bool copyDeviationInfo = false)
        {
            var newOrder = CreateOrder(order.LeavesQty, order.GetOpenClose(true));
            if (copyDeviationInfo) {
                var info = OrderExtensions.GetOrderInfo(newOrder);
                var old = OrderExtensions.GetOrderInfo(order);
                info.DeviationInfo = old.DeviationInfo;
            }
            if (openOrder == order) {
                ClearOrder(ref openOrder);
                openOrder = newOrder;
            }
            else if (closeOrder == order) {
                ClearOrder(ref closeOrder);
                closeOrder = newOrder;
            }
            else if (closeTodayOrder == order) {
                ClearOrder(ref closeTodayOrder);
                closeTodayOrder = newOrder;
            }
        }

        #region Auto OpenClose
        private OpenCloseInfo GetOpenCloseInfo()
        {
            var info = new OpenCloseInfo();

            (double closeQty, double closeTodayQty) = GetCloseQty();

            var openCloseType = _order.GetOpenClose(true);
            switch (openCloseType) {
                case OpenCloseType.Undefined:
                    AutoOpenClose(false);
                    break;
                case OpenCloseType.Open:
                    info.Open = _order.Qty;
                    break;
                case OpenCloseType.Close:
                    AutoOpenClose();
                    break;
                case OpenCloseType.CloseToday:
                    if (_rules.StrictCloseToday) {
                        info.CloseToday = Math.Min(_order.Qty, closeTodayQty);
                    }
                    else {
                        AutoOpenClose();
                    }
                    break;
                case OpenCloseType.LockToday:
                    if (closeTodayQty > 0) {
                        info.Open = _order.Qty;
                    }
                    else {
                        info.Close = Math.Min(_order.Qty, closeQty);
                        info.Open = Math.Max(0, _order.Qty - closeQty);
                    }
                    break;
            }
            return info;

            #region local
            (double close, double closeToday) GetCloseQty()
            {
                double closeToday, close;
                (closeToday, close) = _order.Side == OrderSide.Buy
                    ? _position.Short.GetCanCloseQty()
                    : _position.Long.GetCanCloseQty();

                if (!_rules.DisableCloseToday) {
                    return (close, closeToday);
                }

                close -= closeToday;
                closeToday = 0;
                return (close, closeToday);
            }
            void AutoOpenClose(bool closeOnly = true)
            {
                var qty = _order.Qty;
                if (_rules.StrictCloseToday) {
                    closeQty -= closeTodayQty;
                    info.CloseToday = Math.Min(qty, closeTodayQty);
                    qty -= info.CloseToday;
                    if (Math.Abs(qty) < double.Epsilon) {
                        return;
                    }
                }

                info.Close = Math.Min(qty, closeQty);
                qty -= info.Close;
                if (Math.Abs(qty) < double.Epsilon) {
                    return;
                }
                if (!closeOnly) {
                    info.Open = qty;
                }
            }
            #endregion
        }

        private bool SetOpenClose()
        {
            var info = GetOpenCloseInfo();
            if (info.Open > 0 && openOrder == null) {
                openOrder = CreateOrder(info.Open, OpenCloseType.Open);
            }
            if (info.Close > 0 && closeOrder == null) {
                closeOrder = CreateOrder(info.Close, OpenCloseType.Close);
            }
            if (info.CloseToday > 0 && closeTodayOrder == null) {
                closeTodayOrder = CreateOrder(info.CloseToday, OpenCloseType.CloseToday);
            }
            _logger.Debug($"o:{info.Open},c:{info.Close},ct:{info.CloseToday}");
            return !(info.Open + info.Close + info.CloseToday < _order.Qty);
        }
        #endregion

        private void SetOrderPrice(Order order, DeviationInfo info)
        {
            switch (info.PriceAdjustMethod) {
                case OrderPriceAdjustMethod.UpperLowerLimit:
                    order.Price = order.Side == OrderSide.Buy ? GetUpperLimitPrice() : GetLowerLimitPrice();
                    break;
                case OrderPriceAdjustMethod.MatchPrice:
                    order.Price = order.Side == OrderSide.Buy
                        ? order.Instrument.Ask.Price + info.Slippage
                        : order.Instrument.Bid.Price - info.Slippage;
                    break;
            }
        }

        private void SendOrder(Order order, bool checkUpperLowerLimit)
        {
            if (!IsNotSent(order)) {
                return;
            }

            if (_order.Type == OrderType.Market) {
                checkUpperLowerLimit = false;
                if (!_rules.HasMarketOrder) {
                    _order.SetOrderType(OrderType.Limit);
                    SetOrderPrice(order, _info.Market2Limit);
                }
            }
            else {
                if (_info.DeviationMode != OrderDeviationMode.Disabled && _info.DeviationInfo.TryCount > 0) {
                    checkUpperLowerLimit = false;
                    SetOrderPrice(order, _info.DeviationInfo);
                }
            }
            if (!checkUpperLowerLimit || (order.Price >= GetLowerLimitPrice() && order.Price <= GetUpperLimitPrice())) {
                _agent.SendOrder(order);
            }
            else {
                _logger.Debug($"{_order}, price_out_of_bounds");
            }
        }

        private void SendOrder()
        {
            if (_order.Type == OrderType.Stop || _order.Type == OrderType.StopLimit) {
                return;
            }
            var checkUpperLowerLimit = false;
            switch (_agent.TradingStatus) {
                case XProviderEventType.MarketContinuous:
                    checkUpperLowerLimit = true;
                    break;
                case XProviderEventType.MarketAuctionOrdering when _order.Type == OrderType.Limit:
                    break;
                case XProviderEventType.MarketAuctionOrdering:
                    return;
                default:
                    return;
            }

            SendOrder(closeOrder, checkUpperLowerLimit);
            SendOrder(closeTodayOrder, checkUpperLowerLimit);
            if (!_agent.Info.CloseFirstOnReversing || (IsFilled(closeOrder) && IsFilled(closeTodayOrder))) {
                SendOrder(openOrder, checkUpperLowerLimit);
            }
        }

        public OrderProcessor(OrderAgent agent, Order order, Logger logger)
        {
            _agent = agent;
            _order = order;
            _position = agent.GetPosition(order);
            _record = new OrderRecord(order);
            _info = OrderExtensions.GetOrderInfo(order);
            _logger = logger;
            listNode = agent.AddProcessor(this);
            InitRules();
        }

        private void InitRules()
        {
            SetMarketData();
            _rules = _agent.instTradeInfoList[_order.Instrument.Id];
            if ((_order.Type == OrderType.Market || _order.Type == OrderType.Stop) && _rules.HasMarketOrder) {
                _info.DeviationMode = OrderDeviationMode.Disabled;
                _info.Market2Limit.PriceAdjustMethod = OrderPriceAdjustMethod.Default;
            }
            else {
                if (_info.Market2Limit.PriceAdjustMethod == OrderPriceAdjustMethod.Default) {
                    _info.Market2Limit.PriceAdjustMethod = _agent.Info.Market2Limit.PriceAdjustMethod;
                }
            }
        }

        public void Init()
        {
            if (_order.Status == OrderStatus.PendingNew) {
                var report = new ExecutionReport(_order) {
                    ExecType = ExecType.ExecNew,
                    OrdStatus = OrderStatus.New
                };
                _agent.EmitExecutionReport(report);
            }
            if (!CheckMarketToLimit()) {
                var report = new ExecutionReport(_order) {
                    ExecType = ExecType.ExecRejected,
                    OrdStatus = OrderStatus.Rejected,
                    Text = "无法将市价转化为限价"
                };
                _agent.EmitExecutionReport(report);
                Clear();
                return;
            }

            if (SetOpenClose()) {
                FrozenPosition();
                SendOrder();
            }
            else {
                var report = new ExecutionReport(_order) {
                    ExecType = ExecType.ExecRejected,
                    OrdStatus = OrderStatus.Rejected,
                    Text = "平仓仓位不足"
                };
                _agent.EmitExecutionReport(report);
                Clear();
            }
        }

        private void UnfrozenPosition()
        {
            if (openOrder != null && !openOrder.IsFilled) {
                _position.OnOrderRejected(openOrder);
            }

            if (closeOrder != null && !closeOrder.IsFilled) {
                _position.OnOrderRejected(closeOrder);
            }

            if (closeTodayOrder != null && !closeTodayOrder.IsFilled) {
                _position.OnOrderRejected(closeTodayOrder);
            }
        }

        private void FrozenPosition()
        {
            if (openOrder != null && !openOrder.IsFilled) {
                _position.FrozenPosition(openOrder);
            }

            if (closeOrder != null && !closeOrder.IsFilled) {
                _position.FrozenPosition(closeOrder);
            }

            if (closeTodayOrder != null && !closeTodayOrder.IsFilled) {
                _position.FrozenPosition(closeTodayOrder);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool CheckMarketToLimit()
        {
            return _order.Type != OrderType.Market 
                   || _rules.HasMarketOrder 
                   || (_marketData != null && !double.IsNaN(_marketData.OpenPrice));
        }

        private void CancelOrder(ref Order order)
        {
            if (!IsDone(order) && !IsNotSent(order)) {
                _agent.Cancel(order);
            }
            else {
                if (IsNotSent(order)) {
                    //_manager.ProcessSend();
                    ClearOrder(ref order);
                }
            }
        }

        public void Cancel()
        {
            _record.Cancelling = true;
            CancelOrder(ref openOrder);
            CancelOrder(ref closeOrder);
            CancelOrder(ref closeTodayOrder);
        }

        #region Process ExecutionReport

        public void OnExecutionReport(ExecutionReport report)
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
                    SendOrder();
                    break;
                case ExecType.ExecCancelled:
                    OnExecCancelled(report);
                    break;
                default:
                    return;
            }

            Finish();
        }

        private void Finish()
        {
            if (!AllDone()) {
                return;
            }

            if (!AllFilled()) {
                UnfrozenPosition();
                ReportFailure();
            }

            Clear();
        }

        private static void ClearOrder(ref Order order)
        {
            if (order == null) {
                return;
            }
            OrderExtensions.GetOrderInfo(order).processor = null;
            order = null;
        }

        private void Clear()
        {
            OrderExtensions.GetOrderInfo(_order).processor = null;
            ClearOrder(ref openOrder);
            ClearOrder(ref closeOrder);
            ClearOrder(ref closeTodayOrder);
            _agent.RemoveProcessor(this);
        }

        private void OnExecCancelled(ExecutionMessage report)
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
            }
        }

        private void OnExecNew(ExecutionMessage report)
        {
            switch (_info.DeviationMode) {
                case OrderDeviationMode.Time:
                    _agent.AddReminder(_info.DeviationInfo.Threshold, report.Order);
                    break;
                case OrderDeviationMode.Trade:
                    break;
                case OrderDeviationMode.QuoteAndTrade:
                    break;
            }
        }

        private void OnExecTrade(ExecutionReport report)
        {
            if (!report.IsLoaded) {
                _position.OnOrderFilled(report);
            }
            _record.AddFill(report.LastPx, report.LastQty);
            _agent.EmitExecutionReport(new ExecutionReport(_order) {
                ExecType = ExecType.ExecTrade,
                LastQty = report.LastQty,
                LastPx = report.LastPx,
                AvgPx = _record.AvgPx,
                LeavesQty = _record.LeavesQty,
                CumQty = _record.CumQty,
                SubSide = report.SubSide,
                OrdStatus = GetOrderStatus(),
                Text = GetRejectedText()
            });
        }

        private void OnExecRejected(ExecutionReport report)
        {
            if (_record.Cancelling) {
                return;
            }
            (int errorId, _) = report.GetErrorId();
            if (errorId == TimeOutOfBoundsError) {
                if (_agent.TradingStatus == XProviderEventType.MarketClosed) {
                    if (_order.TimeInForce == TimeInForce.GTC) {
                        RecreateOrder(report.Order);
                    }
                    return;
                }
                RecreateOrder(report.Order);
            }
            else if (errorId == PriceOutOfBoundsError && _order.TimeInForce == TimeInForce.GTC) {
                RecreateOrder(report.Order);
            }
        }

        private void OnExecExpired(ExecutionReport report)
        {
            if (_record.Cancelling) {
                return;
            }
            if (_order.TimeInForce == TimeInForce.GTC) {
                RecreateOrder(report.Order);
            }
        }

        private string GetRejectedText()
        {
            if (IsRejected(openOrder)) {
                return openOrder.Text;
            }
            if (IsRejected(closeOrder)) {
                return closeOrder.Text;
            }
            if (IsRejected(closeTodayOrder)) {
                return closeTodayOrder.Text;
            }
            return string.Empty;
        }

        private OrderStatus GetOrderStatus()
        {
            if (AllDone()) {
                if (AllFilled()) {
                    return OrderStatus.Filled;
                }
                if (AnyCancelled()) {
                    if (_order.TimeInForce != TimeInForce.GTC || _record.Cancelling) {
                        return OrderStatus.Cancelled;
                    }
                }
                if (AnyRejected()) {
                    if (_order.TimeInForce != TimeInForce.GTC || _record.Cancelling) {
                        return OrderStatus.Rejected;
                    }
                }
                if (AnyExpired()) {
                    if (_order.TimeInForce != TimeInForce.GTC || _record.Cancelling) {
                        return OrderStatus.Expired;
                    }
                }
            }
            return OrderStatus.PartiallyFilled;
        }

        #endregion

        #region Order Status Check
        private static bool IsNotSent(Order order) => order?.IsNotSent == true;
        private static bool IsCancelled(Order order) => order?.IsCancelled == true;
        private static bool IsRejected(Order order) => order?.IsRejected == true;
        private static bool IsExpired(Order order) => order?.IsExpired == true;
        private static bool IsFilled(Order order) => order == null || order.IsFilled;
        private static bool IsDone(Order order) => order == null || order.IsDone;

        private bool AllDone() => IsDone(openOrder) && IsDone(closeOrder) && IsDone(closeTodayOrder);
        private bool AllFilled() => IsFilled(openOrder) && IsFilled(closeOrder) && IsFilled(closeTodayOrder);
        private bool AnyCancelled() => IsCancelled(openOrder) || IsCancelled(closeOrder) || IsCancelled(closeTodayOrder);
        private bool AnyRejected() => IsRejected(openOrder) || IsRejected(closeOrder) || IsRejected(closeTodayOrder);
        private bool AnyExpired() => IsExpired(openOrder) || IsExpired(closeOrder) || IsExpired(closeTodayOrder);
        #endregion

        #region Deviation
        public void OnTrade(Trade trade)
        {
            if (_order.Type == OrderType.Stop || _order.Type == OrderType.StopLimit) {
                if ((_order.Side == OrderSide.Buy && trade.Price >= _order.StopPx)
                    || (_order.Side == OrderSide.Sell && trade.Price <= _order.StopPx)) {
                    _logger.Debug($"{_order.Id} stop active");
                    _order.SetOrderType(_order.Type == OrderType.Stop ? OrderType.Market : OrderType.Limit);
                    SendOrder();
                }
            }
            else {
                if (_info.DeviationMode != OrderDeviationMode.QuoteAndTrade &&
                    _info.DeviationMode != OrderDeviationMode.Trade) {
                    return;
                }

                CheckPriceDeviation(openOrder);
                CheckPriceDeviation(closeOrder);
                CheckPriceDeviation(closeTodayOrder);
            }
        }

        private void CheckPriceDeviation(Order order)
        {
            var price = _order.Instrument.Trade.Price;
            var ask = _order.Instrument.Ask.Price;
            var bid = _order.Instrument.Bid.Price;

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
                    _logger.Debug($"{_order.Id}, price deviation {info.DeviationInfo.TryCount}.");
                    _agent.Cancel(order);
                }
                else {
                    DoFailed(order);
                }
            }
        }

        private static bool CheckTryCount(QuantBoxOrderInfo info)
        {
            ++info.DeviationInfo.TryCount;
            return info.DeviationInfo.MaxTry == 0 || info.DeviationInfo.TryCount <= info.DeviationInfo.MaxTry;
        }

        private void DoFailed(Order order)
        {
            _logger.Debug($"{_order.Id}, deviation adjust failed.");
            _info.DeviationMode = OrderDeviationMode.Disabled;
            if (_info.FailedMethod == OrderAdjustFailedMethod.Cancel) {
                _record.Cancelling = true;
                _agent.Cancel(order);
            }
        }

        public void OnReminder(DateTime dateTime, Order order)
        {
            var info = OrderExtensions.GetOrderInfo(order);
            if (CheckTryCount(info)) {
                _logger.Debug($"{_order.Id}, time deviation {info.DeviationInfo.TryCount}.");
                _agent.Cancel(order);
            }
            else {
                DoFailed(order);
            }
        }
        #endregion

        public void OnMarketContentious()
        {
            SendOrder();
        }

        public void OnMarketAuctionOrdering()
        {
            SendOrder();
        }

        internal void OnMarketClosed()
        {
        }

        public void Resume()
        {
            void LoadReport(Order order)
            {
                if (order == null) {
                    return;
                }

                foreach (var report in order.Reports) {
                    if (report.ExecType != ExecType.ExecTrade ||
                        _order.Reports.Exists(n => n.ExecId == report.ExecId)) {
                        continue;
                    }
                    OnExecTrade(report);
                }
            }

            if (openOrder == null && closeOrder == null && closeTodayOrder == null) {
                Clear();
                _agent.EmitExecutionReport(new ExecutionReport(_order) {
                    ExecType = ExecType.ExecCancelled,
                    Text = "系统意外退出"
                });
            }
            else {
                LoadReport(openOrder);
                LoadReport(closeOrder);
                LoadReport(closeTodayOrder);
                FrozenPosition();
                Finish();
            }
        }

        private void ReportFailure()
        {
            var status = GetOrderStatus();
            ExecType exec;
            switch (status) {
                case OrderStatus.Cancelled:
                    exec = ExecType.ExecCancelled;
                    break;
                case OrderStatus.Expired:
                    exec = ExecType.ExecExpired;
                    break;
                default:
                    exec = ExecType.ExecRejected;
                    break;
            }

            _agent.EmitExecutionReport(new ExecutionReport(_order) {
                ExecType = exec,
                OrdStatus = status,
                Text = GetRejectedText()
            });
        }
    }
}
