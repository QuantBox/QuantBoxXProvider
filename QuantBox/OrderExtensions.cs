using QuantBox.XApi;
using SmartQuant;

namespace QuantBox
{
    public static class OrderExtensions
    {
        private static QuantBoxOrderInfo GetOrderInfo(Order order)
        {
            var data = (QuantBoxOrderInfo)order.Fields[QuantBoxConst.ExtensionsOffset];
            if (data == null) {
                data = new QuantBoxOrderInfo();
                order.Fields[QuantBoxConst.ExtensionsOffset] = data;
            }
            return data;
        }

        public static HedgeFlagType GetHedgeFlag(this Order order)
        {
            return GetOrderInfo(order).HedgeFlag;
        }

        public static void SetHedgeFlag(this Order order, HedgeFlagType flag = HedgeFlagType.Arbitrage)
        {
            GetOrderInfo(order).HedgeFlag = flag;
        }

        public static OpenCloseType GetOpenClose(this Order order)
        {
            return GetOrderInfo(order).OpenClose;
        }

        public static void SetSide(this Order order, QuantBox.XApi.OrderSide side)
        {
            GetOrderInfo(order).Side = side;
        }

        public static QuantBox.XApi.OrderSide GetSide(this Order order)
        {
            return GetOrderInfo(order).Side;
        }

        public static void Open(this Order order)
        {
            order.SubSide = order.Side == SmartQuant.OrderSide.Buy ? SubSide.Undefined : SubSide.SellShort;
            GetOrderInfo(order).OpenClose = OpenCloseType.Open;
        }

        public static void Close(this Order order)
        {
            order.SubSide = order.Side == SmartQuant.OrderSide.Sell ? SubSide.Undefined : SubSide.BuyCover;
            GetOrderInfo(order).OpenClose = OpenCloseType.Close;
        }

        public static void CloseToday(this Order order)
        {
            order.SubSide = order.Side == SmartQuant.OrderSide.Sell ? SubSide.Undefined : SubSide.BuyCover;
            GetOrderInfo(order).OpenClose = OpenCloseType.CloseToday;
        }        
    }
}
