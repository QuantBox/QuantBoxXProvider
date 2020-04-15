using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using QuantBox.XApi;
using Skyline;
using SmartQuant;
using OrderSide = SmartQuant.OrderSide;
using PositionSide = SmartQuant.PositionSide;

namespace QuantBox
{
    public static class OrderExtensions
    {
        private static readonly FastFieldInfo<Order, SubSide> SubSideField;
        private static readonly FastFieldInfo<Order, SmartQuant.OrderType> TypeField;
        private static readonly FastFieldInfo<Order, SmartQuant.OrderStatus> StatusField;

        static OrderExtensions()
        {
            foreach (var field in typeof(Order).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)) {
                if (field.FieldType == typeof(SubSide)) {
                    SubSideField = new FastFieldInfo<Order, SubSide>(field);
                    continue;
                }
                if (field.FieldType == typeof(SmartQuant.OrderType)) {
                    TypeField = new FastFieldInfo<Order, SmartQuant.OrderType>(field);
                    continue;
                }
                if (field.FieldType == typeof(SmartQuant.OrderStatus)) {
                    StatusField = new FastFieldInfo<Order, SmartQuant.OrderStatus>(field);
                    continue;
                }
            }
        }

        public static bool IsLong(this Order order)
        {
            return (order.Side == OrderSide.Buy && order.SubSide == SubSide.Undefined)
                || (order.Side == OrderSide.Sell && order.SubSide == SubSide.Undefined);
        }

        public static bool IsShort(this Order order)
        {
            return (order.Side == OrderSide.Sell && order.SubSide == SubSide.SellShort)
                || (order.Side == OrderSide.Buy && order.SubSide == SubSide.BuyCover);
        }

        public static void SetErrorId(this ExecutionReport report, int errorId, int rawErrorId)
        {
            report.Fields[QuantBoxConst.ReportErrorOffset] = new MakeLong(errorId, rawErrorId);
        }

        public static (int, int) GetErrorId(this ExecutionReport report)
        {
            if (report.Fields[QuantBoxConst.ReportErrorOffset] != null) {
                var m = (MakeLong)report.Fields[QuantBoxConst.ReportErrorOffset];
                return (m.High, m.Low);
            }
            return (0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static QuantBoxOrderInfo GetOrderInfo(Order order)
        {
            var data = (QuantBoxOrderInfo)order.Fields[QuantBoxConst.OrderInfoOffset];
            if (data != null) {
                return data;
            }

            data = new QuantBoxOrderInfo();
            order.Fields[QuantBoxConst.OrderInfoOffset] = data;
            return data;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static HedgeFlagType GetHedgeFlag(this Order order)
        {
            return GetOrderInfo(order).HedgeFlag;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PositionSide ToPositionSide(this OrderSide side)
        {
            switch (side) {
                case OrderSide.Buy:
                    return PositionSide.Long;
                default:
                    return PositionSide.Short;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PositionSide ToPositionSide(this Fill fill)
        {
            return ToPositionSide(fill.Order.Side);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsOpen(this Fill fill)
        {
            return fill.Order.IsOpen();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsOpen(this Order order)
        {
            return (order.Side == OrderSide.Buy && order.SubSide == SubSide.Undefined)
                   || (order.Side == OrderSide.Sell && order.SubSide == SubSide.SellShort);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Order SetHedgeFlag(this Order order, HedgeFlagType flag = HedgeFlagType.Arbitrage)
        {
            GetOrderInfo(order).HedgeFlag = flag;
            return order;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static OpenCloseType GetOpenClose(this Order order, bool enabledUndefined = false)
        {
            var f = GetOrderInfo(order).OpenClose;
            if (enabledUndefined) {
                return f;
            }

            return f == OpenCloseType.Undefined ? OpenCloseType.Open : f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetSide(this Order order, XApi.OrderSide side)
        {
            GetOrderInfo(order).Side = side;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XApi.OrderSide GetSide(this Order order)
        {
            return GetOrderInfo(order).Side;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetSubSide(this Order order, SubSide side)
        {
            SubSideField.Setter(order, side);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetOrderType(this Order order, SmartQuant.OrderType type)
        {
            TypeField.Setter(order, type);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetOrderStatus(this Order order, SmartQuant.OrderStatus status)
        {
            StatusField.Setter(order, status);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Order SetOpenClose(this Order order, OpenCloseType openClose)
        {
            switch (openClose) {
                case OpenCloseType.Undefined:
                    break;
                case OpenCloseType.Open:
                    Open(order);
                    break;
                case OpenCloseType.Close:
                    Close(order);
                    break;
                case OpenCloseType.CloseToday:
                    CloseToday(order);
                    break;
                case OpenCloseType.LockToday:
                    LockToday(order);
                    break;
            }
            return order;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Order Open(this Order order)
        {
            var subside = order.Side == OrderSide.Buy ? SubSide.Undefined : SubSide.SellShort;
            if (order.IsNotSent) {
                order.SubSide = subside;
            }
            else {
                SetSubSide(order, subside);
            }
            GetOrderInfo(order).OpenClose = OpenCloseType.Open;
            return order;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Order Close(this Order order)
        {
            var subside = order.Side == OrderSide.Sell ? SubSide.Undefined : SubSide.BuyCover;
            if (order.IsNotSent) {
                order.SubSide = subside;
            }
            else {
                SetSubSide(order, subside);
            }
            GetOrderInfo(order).OpenClose = OpenCloseType.Close;
            return order;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Order CloseToday(this Order order)
        {
            var subside = order.Side == OrderSide.Sell ? SubSide.Undefined : SubSide.BuyCover;
            if (order.IsNotSent) {
                order.SubSide = subside;
            }
            else {
                SetSubSide(order, subside);
            }
            GetOrderInfo(order).OpenClose = OpenCloseType.CloseToday;
            return order;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Order LockToday(this Order order)
        {
            GetOrderInfo(order).OpenClose = OpenCloseType.LockToday;
            return order;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Order Send(this Order order)
        {
            order.Portfolio.GetFramework().OrderManager.Send(order);
            return order;
        }

        public static Order SendWithSelfTradeCheck(this Order order)
        {
            if (order.Portfolio.GetFramework().Mode == FrameworkMode.Realtime) {
                OrderRegister.Instance.Post(order);
            }
            else {
                Send(order);
            }
            return order;
        }

        /// <summary>
        /// 立即全部成交否則取消(Fill Or Kill)订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Order FOK(this Order order)
        {
            order.TimeInForce = SmartQuant.TimeInForce.FOK;
            return order;
        }

        /// <summary>
        /// 立即成交否則取消(Immediate Or Cancel)订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Order IOC(this Order order)
        {
            order.TimeInForce = SmartQuant.TimeInForce.IOC;
            return order;
        }

        /// <summary>
        /// 取消前有效(Good Till Cancel)定单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Order GTC(this Order order)
        {
            //order.Type = SmartQuant.OrderType.
            order.TimeInForce = SmartQuant.TimeInForce.GTC;
            return order;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Order Deviation(Order order,
            OrderDeviationMode mode, int threshold,
            OrderDeviationMethod method,
            OrderPriceAdjustMethod adjustMethod,
            byte slippage, byte maxTry)
        {
            var info = GetOrderInfo(order);
            if (mode == OrderDeviationMode.Disabled) {
                info.DeviationMode = mode;
            }
            else {
                switch (info.DeviationMode) {
                    case OrderDeviationMode.QuoteAndTrade:
                    case OrderDeviationMode.Trade:
                    case OrderDeviationMode.Time:
                        info.DeviationMode |= mode;
                        break;
                    default:
                        info.DeviationMode = mode;
                        break;
                }
            }
            info.DeviationInfo.Threshold = threshold;
            info.DeviationInfo.Method = method;
            info.DeviationInfo.PriceAdjustMethod = adjustMethod;
            info.DeviationInfo.Slippage = slippage;
            info.DeviationInfo.MaxTry = maxTry;
            return order;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Order PriceDeviation(Order order, byte priceOffset, OrderDeviationMode mode,
            OrderPriceAdjustMethod adjustMethod = OrderPriceAdjustMethod.MatchPrice, byte slippage = 1, byte maxTry = 3)
        {
            return Deviation(order, mode, priceOffset, OrderDeviationMethod.PriceAdjust, adjustMethod, slippage, maxTry);
        }

        /// <summary>
        /// 在指定的时间内未成交自动追单
        /// </summary>
        /// <param name="order"></param>
        /// <param name="timeout">超时时间(毫秒)</param>
        /// <param name="adjustMethod">价格调整的方式</param>
        /// <param name="slippage">追价的滑点</param>
        /// <param name="maxTry">最大尝试次数(0表示无限次，默认3次)</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Order TimeDeviation(this Order order, int timeout,
            OrderPriceAdjustMethod adjustMethod = OrderPriceAdjustMethod.MatchPrice, byte slippage = 1, byte maxTry = 3)
        {
            return Deviation(order, OrderDeviationMode.Time, timeout, OrderDeviationMethod.PriceAdjust, adjustMethod, slippage, maxTry);
        }

        /// <summary>
        /// 在指定的时间内未成交时用市价追单
        /// </summary>
        /// <param name="order"></param>
        /// <param name="timeout">超时时间(毫秒)</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Order TimeDeviationUseMarket(this Order order, int timeout)
        {
            return Deviation(order, OrderDeviationMode.Time, timeout, OrderDeviationMethod.PriceAdjust, OrderPriceAdjustMethod.UpperLowerLimit, 0, 0);
        }

        /// <summary>
        /// 在指定的时间内未成交时用对手价追单
        /// </summary>
        /// <param name="order"></param>
        /// <param name="timeout">超时时间(毫秒)</param>
        /// <param name="maxTry">尝试的次数</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Order TimeDeviationUseMatch(this Order order, int timeout, byte maxTry = 3)
        {
            return Deviation(order, OrderDeviationMode.Time, timeout, OrderDeviationMethod.PriceAdjust, OrderPriceAdjustMethod.MatchPrice, 0, maxTry);
        }

        /// <summary>
        /// 在指定的时间内未成交时用对手价加滑点追单
        /// </summary>
        /// <param name="order"></param>
        /// <param name="timeout">超时时间(毫秒)</param>
        /// <param name="slippage">追价的滑点</param>
        /// <param name="maxTry"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Order TimeDeviationUseSlippage(this Order order, int timeout, byte slippage = 1, byte maxTry = 3)
        {
            return Deviation(order, OrderDeviationMode.Time, timeout, OrderDeviationMethod.PriceAdjust, OrderPriceAdjustMethod.MatchPrice, slippage, maxTry);
        }

        /// <summary>
        /// 盘口或最新价偏移太远时自动追单
        /// </summary>
        /// <param name="order"></param>
        /// <param name="priceOffset">价格偏移的跳数</param>
        /// <param name="adjustMethod">价格调整的方式</param>
        /// <param name="slippage">每次追价的跳数</param>
        /// <param name="maxTry">最大尝试次数(0表示无限次，默认3此)</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Order PriceDeviation(this Order order, byte priceOffset,
            OrderPriceAdjustMethod adjustMethod = OrderPriceAdjustMethod.MatchPrice, byte slippage = 1, byte maxTry = 3)
        {
            return PriceDeviation(order, priceOffset, OrderDeviationMode.QuoteAndTrade, adjustMethod, slippage, maxTry);
        }

        /// <summary>
        /// 盘口或最新价偏移太远时用市价追单
        /// </summary>
        /// <param name="order"></param>
        /// <param name="priceOffset"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Order PriceDeviationUseMarket(this Order order, byte priceOffset)
        {
            return PriceDeviation(order, priceOffset, OrderDeviationMode.QuoteAndTrade, OrderPriceAdjustMethod.UpperLowerLimit, 0, 0);
        }

        /// <summary>
        /// 盘口或最新价偏移太远时用对手价追单
        /// </summary>
        /// <param name="order"></param>
        /// <param name="priceOffset">价格偏移的跳数</param>
        /// <param name="maxTry">最大尝试次数(0表示无限次，默认3此)</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Order PriceDeviationUseMatch(this Order order, byte priceOffset, byte maxTry = 3)
        {
            return PriceDeviation(order, priceOffset, OrderDeviationMode.QuoteAndTrade, OrderPriceAdjustMethod.MatchPrice, 0, maxTry);
        }

        /// <summary>
        /// 盘口或最新价偏移太远时用对手价加滑点追单
        /// </summary>
        /// <param name="order"></param>
        /// <param name="priceOffset">价格偏移的跳数</param>
        /// <param name="slippage">滑点</param>
        /// <param name="maxTry">最大尝试次数(0表示无限次，默认3此)</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Order PriceDeviationUseSlippage(this Order order, byte priceOffset, byte slippage = 1, byte maxTry = 3)
        {
            return PriceDeviation(order, priceOffset, OrderDeviationMode.QuoteAndTrade, OrderPriceAdjustMethod.MatchPrice, slippage, maxTry);
        }

        /// <summary>
        /// 最新价偏移太远时自动追单
        /// </summary>
        /// <param name="order"></param>
        /// <param name="priceOffset">价格偏移的跳数</param>
        /// <param name="adjustMethod">价格调整的方式</param>
        /// <param name="slippage">每次追价的跳数</param>
        /// <param name="maxTry">最大尝试次数(0表示无限次，默认3此)</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Order TradeDeviation(this Order order, byte priceOffset,
            OrderPriceAdjustMethod adjustMethod = OrderPriceAdjustMethod.MatchPrice, byte slippage = 1, byte maxTry = 3)
        {
            return PriceDeviation(order, priceOffset, OrderDeviationMode.Trade, adjustMethod, slippage, maxTry);
        }

        /// <summary>
        /// 禁止订单的价格偏移和等待成交时间超时检测
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Order DeviationDisable(this Order order)
        {
            var info = GetOrderInfo(order);
            info.DeviationMode = OrderDeviationMode.Disabled;
            return order;
        }

        /// <summary>
        /// 订单在指定时间未成交时自动撤销
        /// </summary>
        /// <param name="order"></param>
        /// <param name="timeout">等待成交的时间(毫秒)</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Order TimeDeviationCancel(this Order order, int timeout)
        {
            return Deviation(order, OrderDeviationMode.Time, timeout, OrderDeviationMethod.Cancel, OrderPriceAdjustMethod.Default, 0, 0);
        }

        /// <summary>
        /// 最新价或盘口价格偏移报单价格指定量时撤销订单
        /// </summary>
        /// <param name="order"></param>
        /// <param name="priceOffset">价格偏移的跳数</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Order PriceDeviationCancel(this Order order, byte priceOffset = 1)
        {
            return Deviation(order, OrderDeviationMode.QuoteAndTrade, priceOffset, OrderDeviationMethod.Cancel, OrderPriceAdjustMethod.Default, 0, 0);
        }

        /// <summary>
        /// 最新价偏移报单价格指定量时撤销订单
        /// </summary>
        /// <param name="order"></param>
        /// <param name="priceOffset">价格偏移的跳数</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Order TradeDeviationCancel(this Order order, byte priceOffset = 1)
        {
            return Deviation(order, OrderDeviationMode.Trade, priceOffset, OrderDeviationMethod.Cancel, OrderPriceAdjustMethod.Default, 0, 0);
        }

        /// <summary>
        /// 在价格偏移或超时后进行价格调整还是无法按时成交的订单做撤单处理
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Order FailedAfterCancel(this Order order)
        {
            GetOrderInfo(order).FailedMethod = OrderAdjustFailedMethod.Cancel;
            return order;
        }

        /// <summary>
        /// 在价格偏移或超时后进行价格调整还是无法按时成交的订单不做处理
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Order FailedAfterKeep(this Order order)
        {
            GetOrderInfo(order).FailedMethod = OrderAdjustFailedMethod.Keep;
            return order;
        }

        /// <summary>
        /// 交易所不支持市价单时，市价单如何转换成限价单
        /// </summary>
        /// <param name="order"></param>
        /// <param name="method"></param>
        /// <param name="slippage">预设的滑点</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Order Market2Limit(this Order order, OrderPriceAdjustMethod method, byte slippage = 1)
        {
            var info = GetOrderInfo(order);
            info.Market2Limit.PriceAdjustMethod = method;
            info.Market2Limit.Slippage = slippage;
            return order;
        }
    }
}
