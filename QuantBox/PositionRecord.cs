using System;
using System.Runtime.CompilerServices;

namespace QuantBox
{
    public class PositionRecord
    {
        /// <summary>
        /// 实际持仓
        /// </summary>
        public double Qty;

        /// <summary>
        /// 实际持今仓量
        /// </summary>
        public double QtyToday;

        /// <summary>
        /// 登记开仓量
        /// </summary>
        public double FrozenOpen;

        /// <summary>
        /// 注销开仓量
        /// </summary>
        public double UnfrozenOpen;

        /// <summary>
        /// 登记平仓量
        /// </summary>
        public double FrozenClose;

        /// <summary>
        /// 注销平仓量
        /// </summary>
        public double UnfrozenClose;

        /// <summary>
        /// 登记平今量
        /// </summary>
        public double FrozenCloseToday;

        /// <summary>
        /// 注销平今量
        /// </summary>
        public double UnfrozenCloseToday;

        /// <summary>
        /// 撤单次数累计
        /// </summary>
        public double CumCancelCount;

        /// <summary>
        /// 持仓成本
        /// </summary>
        public double HoldingCost;

        public string Name;

        public PositionRecord(string name)
        {
            Name = name;
        }

        public void Reset()
        {
            ChangeTradingDay();
            Qty = 0;
        }

        public void ChangeTradingDay()
        {
            QtyToday = 0;
            FrozenOpen = 0;
            UnfrozenOpen = 0;
            FrozenClose = 0;
            UnfrozenClose = 0;
            FrozenCloseToday = 0;
            UnfrozenCloseToday = 0;
            CumCancelCount = 0;
        }

        public override string ToString()
        {
            return $"Name:{Name}, 持仓量:{Qty}, 今仓量:{QtyToday}, 挂开仓量:{FrozenOpen - UnfrozenOpen}, 挂平仓量:{FrozenClose - UnfrozenClose}";
        }

        public void NewOrderOpen(double qty)
        {
            FrozenOpen += qty;
        }

        public void NewOrderClose(double qty)
        {
            FrozenClose += qty;
        }

        public void NewOrderCloseToday(double qty)
        {
            FrozenCloseToday += qty;
            FrozenClose += qty;
        }

        public void FilledOpen(double lastQty, double lastPrice)
        {
            Qty += lastQty;
            QtyToday += lastQty;
            UnfrozenOpen += lastQty;
            HoldingCost += lastPrice * lastQty;
        }

        public void FilledClose(double lastQty, double lastPrice)
        {
            Qty -= lastQty;
            UnfrozenClose += lastQty;
            if (Math.Abs(Qty) < double.Epsilon) {
                HoldingCost = 0;
            }
            else {
                HoldingCost -= lastPrice * lastQty;
            }
        }

        public void FilledCloseToday(double lastQty, double lastPrice)
        {
            Qty -= lastQty;
            QtyToday -= lastQty;
            UnfrozenClose += lastQty;
            UnfrozenCloseToday += lastQty;
            if (Math.Abs(Qty) < double.Epsilon) {
                HoldingCost = 0;
            }
            else {
                HoldingCost -= lastPrice * lastQty;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void OrderRejectedOpen(double leavesQty)
        {
            UnfrozenOpen += leavesQty;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void OrderRejectedClose(double leavesQty)
        {
            UnfrozenClose += leavesQty;
        }

        public void OrderRejectedCloseToday(double leavesQty)
        {
            UnfrozenClose += leavesQty;
            UnfrozenCloseToday += leavesQty;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public (double closeToday, double close) GetCanCloseQty()
        {
            return (QtyToday - (FrozenCloseToday - UnfrozenCloseToday), Qty - (FrozenClose - UnfrozenClose));
        }
    }
}
