using System;
using Newtonsoft.Json;

namespace QuantBox.OrderProxy
{
    public class PositionRecord
    {
        /// <summary>
        /// 实际持仓
        /// </summary>
        public double Qty { get; set; }
        /// <summary>
        /// 实际持今仓量
        /// </summary>
        public double QtyToday { get; set; }
        /// <summary>
        /// 挂开仓量
        /// </summary>
        public double FrozenOpen { get; private set; }
        /// <summary>
        /// 挂平仓量
        /// </summary>
        public double FrozenClose { get; private set; }
        /// <summary>
        /// 挂平今量
        /// </summary>
        public double FrozenCloseToday { get; private set; }
        /// <summary>
        /// 开仓手数累计
        /// </summary>
        [JsonIgnore]
        public double CumOpenQty { get; private set; }
        /// <summary>
        /// 撤单次数累计
        /// </summary>
        [JsonIgnore]
        public double CumCancelCount { get; set; }
        /// <summary>
        /// 持仓成本
        /// </summary>
        [JsonIgnore]
        public double HoldingCost { get; private set; }

        [JsonIgnore]
        public string Name { get; private set; }

        public PositionRecord(string name)
        {
            Name = name;
        }

        public void Reset()
        {
            Qty = 0;
            HoldingCost = 0;
            ChangeTradingDay();
        }

        public void ChangeTradingDay()
        {
            QtyToday = 0;
            FrozenOpen = 0;
            FrozenClose = 0;
            FrozenCloseToday = 0;
            CumOpenQty = 0;
            CumCancelCount = 0;
        }

        /// <summary>
        /// 持仓平均成本
        /// </summary>
        [JsonIgnore]
        public double AvgPrice
        {
            get {
                if (Math.Abs(Qty) < double.Epsilon)
                    return 0;
                return HoldingCost / Qty;
            }
        }

        /// <summary>
        /// 持仓平均成本
        /// </summary>
        [JsonIgnore]
        public double QtyYesterday => Qty - QtyToday;

        public override string ToString()
        {
            return $"Name:{Name}, 持仓量:{Qty}, 昨仓量:{QtyYesterday}, 今仓量:{QtyToday}, 挂开仓量:{FrozenOpen}, 挂平仓量:{FrozenClose}, 开仓手数累计:{CumOpenQty}";
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
            if (FrozenOpen >= lastQty) {
                FrozenOpen -= lastQty;
            }
            CumOpenQty += lastQty;
            HoldingCost += lastPrice * lastQty;
        }

        public void FilledClose(double lastQty, double lastPrice)
        {
            Qty -= lastQty;
            if (FrozenClose >= lastQty) {
                FrozenClose -= lastQty;
            }
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
            if (FrozenClose >= lastQty && FrozenCloseToday >= lastQty) {
                FrozenClose -= lastQty;
                FrozenCloseToday -= lastQty;
            }
            if (Math.Abs(Qty) < double.Epsilon) {
                HoldingCost = 0;
            }
            else {
                HoldingCost -= lastPrice * lastQty;
            }
        }

        public void OrderRejectedOpen(double leavesQty)
        {
            if (FrozenOpen >= leavesQty) {
                FrozenOpen -= leavesQty;
            }
        }

        public void OrderRejectedClose(double leavesQty)
        {
            if (FrozenClose >= leavesQty) {
                FrozenClose -= leavesQty;
            }
        }

        public void OrderRejectedCloseToday(double leavesQty)
        {
            if (FrozenClose >= leavesQty && FrozenCloseToday >= leavesQty) {
                FrozenCloseToday -= leavesQty;
                FrozenClose -= leavesQty;
            }
        }

        public (double closeTd, double closeYd) GetCanCloseQty()
        {
            // 得到可平的今仓
            var qtyToday = QtyToday - FrozenCloseToday;
            // 得到可平的昨仓
            var qtyYesterday = Qty - FrozenClose - qtyToday;
            // 对于非上海的，应当QtyYesterday就是所想要的值
            return (qtyToday, qtyYesterday);
        }
    }
}
