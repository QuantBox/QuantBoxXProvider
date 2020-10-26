using System.Runtime.CompilerServices;
using QuantBox.XApi;
using SmartQuant;
using ExecType = SmartQuant.ExecType;
using OrderSide = SmartQuant.OrderSide;

namespace QuantBox
{
    public class DualPosition
    {
        public Instrument Instrument;
        public string Text;
        public readonly PositionRecord Long;
        public readonly PositionRecord Short;
        public DualPosition()
        {
            Long = new PositionRecord("Long");
            Short = new PositionRecord("Short");
        }
        public double LongQty => Long.Qty;
        public double ShortQty => Short.Qty;
        public double NetQty => Long.Qty - Short.Qty;

        public double ShortAvailable => Short.Qty - Short.FrozenClose + Short.UnfrozenClose;
        public double LongAvailable => Long.Qty - Long.FrozenClose + Long.UnfrozenClose;

        public void ChangeTradingDay()
        {
            Long.ChangeTradingDay();
            Short.ChangeTradingDay();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public PositionRecord GetPositionRecord(OrderSide side, OrderOffsetFlag offsetFlag)
        {
            return offsetFlag.IsOpen
                ? side == OrderSide.Buy ? Long : Short
                : side == OrderSide.Buy ? Short : Long;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static OrderOffsetFlag GetOrderFlags(Order order)
        {
            var openCloseType = order.GetOpenClose();
            return new OrderOffsetFlag(openCloseType == OpenCloseType.Open, openCloseType == OpenCloseType.CloseToday);
        }

        #region Process Report

        public void ProcessExecutionReport(ExecutionReport report)
        {
            switch (report.ExecType) {
                case ExecType.ExecRejected:
                case ExecType.ExecCancelled:
                    OnOrderRejected(report.Order);
                    break;
                case ExecType.ExecTrade:
                    OnOrderFilled(report);
                    break;
            }
        }

        public void OnOrderRejected(Order order)
        {
            var offsetFlag = GetOrderFlags(order);
            var record = GetPositionRecord(order.Side, offsetFlag);
            if (order.IsCancelled) {
                record.CumCancelCount++;
            }
            var leavesQty = order.LeavesQty;
            if (offsetFlag.IsOpen) {
                record.OrderRejectedOpen(leavesQty);
            }
            else if (offsetFlag.IsCloseToday) {
                record.OrderRejectedCloseToday(leavesQty);
            }
            else {
                record.OrderRejectedClose(leavesQty);
            }
        }

        public void FrozenPosition(Order order)
        {
            var offsetFlag = GetOrderFlags(order);
            var record = GetPositionRecord(order.Side, offsetFlag);
            if (offsetFlag.IsOpen) {
                record.NewOrderOpen(order.LeavesQty);
            }
            else if (offsetFlag.IsCloseToday) {
                record.NewOrderCloseToday(order.LeavesQty);
            }
            else {
                record.NewOrderClose(order.LeavesQty);
            }
        }

        public void OnOrderFilled(ExecutionReport report)
        {
            var offsetFlag = GetOrderFlags(report.Order);
            var record = GetPositionRecord(report.Side, offsetFlag);

            var lastQty = report.LastQty;
            var lastPrice = report.LastPx;

            if (offsetFlag.IsOpen) {
                record.FilledOpen(lastQty, lastPrice);
            }
            else if (offsetFlag.IsCloseToday) {
                record.FilledCloseToday(lastQty, lastPrice);
            }
            else {
                record.FilledClose(lastQty, lastPrice);
            }
        }
        #endregion
    }
}
