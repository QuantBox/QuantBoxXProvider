using Newtonsoft.Json;
using SmartQuant;

namespace QuantBox.OrderProxy
{
    public class DualPosition
    {
        [JsonIgnore]
        public Instrument Instrument { get; set; }
        [JsonIgnore]
        public string Text { get; set; }
        [JsonIgnore]
        public double LongQty => Long.Qty;

        [JsonIgnore]
        public double ShortQty => Short.Qty;

        [JsonIgnore]
        public double NetQty => Long.Qty - Short.Qty;

        public PositionRecord Long { get; set; }
        public PositionRecord Short { get; set; }

        public DualPosition()
        {
            Long = new PositionRecord("Long");
            Short = new PositionRecord("Short");
        }

        public void ChangeTradingDay()
        {
            Long.ChangeTradingDay();
            Short.ChangeTradingDay();
        }

        public PositionRecord GetPositionRecord(OrderSide side, OrderFlags flags)
        {
            if (flags.IsOpen) {
                return side == OrderSide.Buy ? Long : Short;
            }
            return side == OrderSide.Buy ? Short : Long;
        }

        #region Process Report
        public void ProcessSend(Order order, OrderFlags flags)
        {
            OnPendingNewOrder(order, flags);
        }

        public void ProcessExecutionReport(ExecutionReport report, OrderFlags flags)
        {
            switch (report.ExecType) {
                case ExecType.ExecRejected:
                    OnOrderRejected(report.Order, flags);
                    break;
                case ExecType.ExecCancelled:
                    OnOrderCancelled(report.Order, flags);
                    break;
                //case ExecType.ExecNew:
                //    OnPendingNewOrder(report.Order, flags);
                //    break;
                case ExecType.ExecTrade:
                    OnOrderFilled(report.Order, flags);
                    break;
            }
        }

        private void OnOrderRejected(Order order, OrderFlags flags)
        {
            var record = GetPositionRecord(order.Side, flags);
            var leavesQty = order.LeavesQty;
            if (flags.IsOpen) {
                record.OrderRejectedOpen(leavesQty);
            }
            else if (flags.IsCloseToday) {
                record.OrderRejectedCloseToday(leavesQty);
            }
            else {
                record.OrderRejectedClose(leavesQty);
            }
        }

        private void OnOrderCancelled(Order order, OrderFlags flags)
        {
            var record = GetPositionRecord(order.Side, flags);
            record.CumCancelCount++;
            OnOrderRejected(order, flags);
        }

        private void OnPendingNewOrder(Order order, OrderFlags flags)
        {
            var qty = order.Qty;
            var record = GetPositionRecord(order.Side, flags);

            if (flags.IsOpen) {
                record.NewOrderOpen(qty);
            }
            else if (flags.IsCloseToday) {
                record.NewOrderCloseToday(qty);
            }
            else {
                record.NewOrderClose(qty);
            }
        }

        private void OnOrderFilled(Order order, OrderFlags flags)
        {
            var index = order.Reports.Count - 1;
            var lastQty = order.Reports[index].LastQty;
            var lastPrice = order.Reports[index].LastPx;

            var record = GetPositionRecord(order.Side, flags);

            if (flags.IsOpen) {
                record.FilledOpen(lastQty, lastPrice);
            }
            else if (flags.IsCloseToday) {
                record.FilledCloseToday(lastQty, lastPrice);
            }
            else {
                record.FilledClose(lastQty, lastPrice);
            }
        }
        #endregion
    }
}
