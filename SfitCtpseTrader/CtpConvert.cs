using System;
using System.Runtime.CompilerServices;
#if CTP || CTPSE
using QuantBox.Sfit.Api;
#else
using QuantBox.Rohon.Api;
#endif

namespace QuantBox.XApi
{
    internal static class CtpConvert
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetId(CtpOrder data)
        {
            return $"{data.FrontID}:{data.SessionID}:{data.OrderRef}";
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetId(CtpInputOrder input, CtpRspUserLogin login)
        {
            return $"{login.FrontID}:{login.SessionID}:{input.OrderRef}";
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (int, int, string) ParseId(string localId)
        {
            var items = localId.Split(':');
            return (int.Parse(items[0]), int.Parse(items[1]), items[2]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInvalid(double value)
        {
            return double.IsNaN(value)
                   || Math.Abs(value) < double.Epsilon
                   || Math.Abs(double.MaxValue - value) < double.Epsilon
                   || Math.Abs(value - double.MinValue) < double.Epsilon;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool CheckRspInfo(CtpRspInfo info)
        {
            return info == null || info.ErrorID == 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static InstrumentStatusField GetInstrumentStatus(CtpInstrumentStatus status)
        {
            var field = new InstrumentStatusField();
            field.Status = GetInstrumentStatusType(status.InstrumentStatus);
            field.EnterReason = GetEnterReasonType(status.EnterReason);
            field.EnterTime = GetTime(status.EnterTime);
            field.InstrumentID = status.InstrumentID;
            field.ExchangeID = status.ExchangeID;
            return field;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static EnterReasonType GetEnterReasonType(byte type)
        {
            switch (type) {
                case CtpInstStatusEnterReasonType.Automatic:
                    return EnterReasonType.Automatic;
                case CtpInstStatusEnterReasonType.Manual:
                    return EnterReasonType.Manual;
                default:
                    return EnterReasonType.Fuse;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static InstrumentStatusType GetInstrumentStatusType(byte type)
        {
            switch (type) {
                case CtpInstrumentStatusType.AuctionBalance:
                    return InstrumentStatusType.AuctionBalance;
                case CtpInstrumentStatusType.AuctionMatch:
                    return InstrumentStatusType.AuctionMatch;
                case CtpInstrumentStatusType.AuctionOrdering:
                    return InstrumentStatusType.AuctionOrdering;
                case CtpInstrumentStatusType.BeforeTrading:
                    return InstrumentStatusType.BeforeTrading;
                case CtpInstrumentStatusType.Closed:
                    return InstrumentStatusType.Closed;
                case CtpInstrumentStatusType.Continous:
                    return InstrumentStatusType.Continous;
                default:
                    return InstrumentStatusType.NoTrading;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetReasonMsg(int reason)
        {
            switch (reason) {
                case 0x1001:
                    return "0x1001 4097 网络读失败";
                case 0x1002:
                    return "0x1002 4098 网络写失败";
                case 0x2001:
                    return "0x2001 8193 接收心跳超时";
                case 0x2002:
                    return "0x2002 8194 发送心跳失败";
                case 0x2003:
                    return "0x2003 8195 收到错误报文";
                case 0x2004:
                    return "0x2004 8196 服务器主动断开";
                default:
                    return $"0x{reason:X} {reason} 未知错误";
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CtpResumeType GetCtpResumeType(ResumeType type)
        {
            switch (type) {
                case ResumeType.Restart:
                    return CtpResumeType.Restart;
                case ResumeType.Resume:
                    return CtpResumeType.Resume;
                default:
                    return CtpResumeType.Quick;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetDate(string date)
        {
            return string.IsNullOrEmpty(date) ? 99991231 : int.Parse(date);
        }

        public static int GetTime(string time)
        {
            if (time.Length == 6) {
                if (time[1] != ':' && time[2] != ':') {
                    return int.Parse(time);
                }
            }
            if (time.Length == 8) {
                return int.Parse(time.Substring(0, 2)) * 10000
                    + int.Parse(time.Substring(3, 2)) * 100
                    + int.Parse(time.Substring(6, 2));
            }

            var item = time.Split(':');
            if (item.Length >= 3) {
                return int.Parse(item[0]) * 10000
                       + int.Parse(item[1]) * 100
                       + int.Parse(item[2]);
            }

            return 0;
        }

        public static AccountField GetAccountField(CtpTradingAccount info)
        {
            var account = new AccountField();
            account.AccountID = info.AccountID;
            account.ClientID = info.TradingDay;
            account.PreBalance = info.PreBalance;
            account.CurrMargin = info.CurrMargin;
            account.Commission = info.Commission;
            account.CloseProfit = info.CloseProfit;
            account.PositionProfit = info.PositionProfit;
            account.Balance = info.Balance;
            account.Available = info.Available;
            account.Deposit = info.Deposit;
            account.Withdraw = info.Withdraw;
            account.WithdrawQuota = info.WithdrawQuota;
            return account;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PositionSide GetPositionSide(byte dir)
        {
            if (dir == CtpPosiDirectionType.Long) {
                return PositionSide.Long;
            }
            return PositionSide.Short;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static HedgeFlagType GetHedgeFlag(byte flag)
        {
            switch (flag) {
                case CtpHedgeFlagType.Arbitrage:
                    return HedgeFlagType.Arbitrage;
                case CtpHedgeFlagType.Hedge:
                    return HedgeFlagType.Hedge;
                case CtpHedgeFlagType.Speculation:
                    return HedgeFlagType.Speculation;
            }
            return HedgeFlagType.Undefined;
        }

        public static PositionField GetPositionField(CtpInvestorPosition info)
        {
            var position = new PositionField();
            position.Date = int.Parse(info.TradingDay);
            position.InstrumentID = info.InstrumentID;
            position.Symbol = info.InstrumentID;
            position.AccountID = info.InvestorID;
            position.Position = info.Position;
            position.TodayPosition = info.TodayPosition;
            position.HistoryPosition = info.YdPosition;
            position.Side = GetPositionSide(info.PosiDirection);
            position.HedgeFlag = GetHedgeFlag(info.HedgeFlag);
            return position;
        }

        public static InstrumentField GetInstrumentField(CtpInstrument info)
        {
            var inst = new InstrumentField();
            inst.InstrumentID = info.InstrumentID;
            inst.ExchangeID = info.ExchangeID;
            inst.Symbol = info.InstrumentID;
            inst.ProductID = info.ProductID;
            inst.SetName(info.InstrumentName);
            inst.Type = GetInstrumentType(info.ProductClass);
            inst.VolumeMultiple = info.VolumeMultiple;
            inst.PriceTick = info.PriceTick;
            inst.ExpireDate = GetDate(info.ExpireDate);
            inst.OptionsType = GetPutCall(info.OptionsType);
            inst.StrikePrice = (info.StrikePrice < double.Epsilon || Math.Abs(info.StrikePrice - double.MaxValue) < double.Epsilon) ? 0 : info.StrikePrice;
            inst.UnderlyingInstrID = info.UnderlyingInstrID;
            return inst;
        }

        internal static OrderStatus GetOrderStatus(CtpOrder data)
        {
            switch (data.OrderStatus) {
                case CtpOrderStatusType.Canceled: {
                        if (data.OrderSubmitStatus == CtpOrderSubmitStatusType.InsertRejected)
                            return OrderStatus.Rejected;
                        return OrderStatus.Cancelled;
                    }
                case CtpOrderStatusType.Unknown:
                    // 如果是撤单，也有可能出现这一条，如何过滤？
                    if (data.OrderSubmitStatus == CtpOrderSubmitStatusType.InsertSubmitted)
                        return OrderStatus.New;
                    goto default;
                default:
                    if (data.VolumeTotal == 0)
                        return OrderStatus.Filled;
                    else if (data.VolumeTotal == data.VolumeTotalOriginal)
                        return OrderStatus.New;
                    else
                        return OrderStatus.PartiallyFilled;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PutCall GetPutCall(byte type)
        {
            if (type == CtpOptionsTypeType.CallOptions) {
                return PutCall.Call;
            }
            return PutCall.Put;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static InstrumentType GetInstrumentType(byte type)
        {
            switch (type) {
                case CtpProductClassType.Futures:
                case CtpProductClassType.EFP:
                    return InstrumentType.Future;
                case CtpProductClassType.Combination:
                    return InstrumentType.MultiLeg;
                case CtpProductClassType.Options:
                case CtpProductClassType.SpotOption:
                    return InstrumentType.FutureOption;
            }
            return InstrumentType.Stock;
        }

        public static CtpInputOrder GetInputOrder(OrderField order)
        {
            var data = new CtpInputOrder();
            data.OrderRef = order.LocalID;
            data.InstrumentID = order.InstrumentID;
            data.ExchangeID = order.ExchangeID.ToUpper();
            data.Direction = GetCtpOrderSide(order.Side);
            data.CombOffsetFlag = GetOffsetFlag(order.OpenClose);
            data.CombHedgeFlag = GetHedgeFlag(order.HedgeFlag);
            data.VolumeTotalOriginal = (int)order.Qty;
            data.LimitPrice = order.Price;
            data.StopPrice = order.StopPx;
            switch (order.Type) {
                case OrderType.Market:
                case OrderType.Stop:
                case OrderType.MarketOnClose:
                case OrderType.TrailingStop:
                    data.OrderPriceType = CtpOrderPriceTypeType.AnyPrice;
                    data.TimeCondition = CtpTimeConditionType.IOC;
                    data.LimitPrice = 0;
                    break;
                default:
                    data.OrderPriceType = CtpOrderPriceTypeType.LimitPrice;
                    data.TimeCondition = CtpTimeConditionType.GFD;
                    break;
            }
            switch (order.TimeInForce) {
                case TimeInForce.IOC:
                    data.TimeCondition = CtpTimeConditionType.IOC;
                    data.VolumeCondition = CtpVolumeConditionType.AV;
                    break;
                case TimeInForce.FOK:
                    data.TimeCondition = CtpTimeConditionType.IOC;
                    data.VolumeCondition = CtpVolumeConditionType.CV;
                    break;
                default:
                    data.VolumeCondition = CtpVolumeConditionType.AV;
                    break;
            }
            data.ContingentCondition = CtpContingentConditionType.Immediately;
            data.MinVolume = 1;
            data.ForceCloseReason = CtpForceCloseReasonType.NotForceClose;
            data.IsAutoSuspend = 0;
            data.UserForceClose = 0;
            data.IsSwapOrder = 0;
            return data;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string GetHedgeFlag(HedgeFlagType flag)
        {
            switch (flag) {
                case HedgeFlagType.Arbitrage:
                    return Convert.ToChar(CtpHedgeFlagType.Arbitrage).ToString();
                case HedgeFlagType.Hedge:
                    return Convert.ToChar(CtpHedgeFlagType.Hedge).ToString();
                default:
                    return Convert.ToChar(CtpHedgeFlagType.Speculation).ToString();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string GetOffsetFlag(OpenCloseType openClose)
        {
            switch (openClose) {
                case OpenCloseType.Close:
                    return Convert.ToChar(CtpOffsetFlagType.Close).ToString();
                case OpenCloseType.CloseToday:
                    return Convert.ToChar(CtpOffsetFlagType.CloseToday).ToString();
            }
            return Convert.ToChar(CtpOffsetFlagType.Open).ToString();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static byte GetCtpOrderSide(OrderSide side)
        {
            if (side == OrderSide.Buy) {
                return CtpDirectionType.Buy;
            }
            return CtpDirectionType.Sell;
        }

        public static ExecType GetExecType(CtpOrder data)
        {
            switch (data.OrderStatus) {
                case CtpOrderStatusType.Canceled:
                    if (data.OrderSubmitStatus == CtpOrderSubmitStatusType.InsertRejected)
                        return ExecType.Rejected;
                    return ExecType.Cancelled;
                case CtpOrderStatusType.Unknown:
                    // 如果是撤单，也有可能出现这一条，如何过滤？
                    if (data.OrderSubmitStatus == CtpOrderSubmitStatusType.InsertSubmitted)
                        return ExecType.New;
                    return ExecType.Trade;
                case CtpOrderStatusType.AllTraded:
                case CtpOrderStatusType.PartTradedQueueing:
                    return ExecType.Trade;
                default:
                    return ExecType.New;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ExchangeType GetExchangeType(string exchangeId)
        {
            if (string.IsNullOrEmpty(exchangeId)) {
                return ExchangeType.Undefined;
            }
            switch (exchangeId[1]) {
                case 'H':
                    return ExchangeType.SHFE;
                case 'C':
                    return ExchangeType.DCE;
                case 'Z':
                    return ExchangeType.CZCE;
                case 'F':
                    return ExchangeType.CFFEX;
                case 'N':
                    return ExchangeType.INE;
                default:
                    return ExchangeType.Undefined;
            }
        }

        private static int GetActionDay(int updateTime)
        {
            var now = DateTime.Now;
            var offset = 0;
            if (updateTime > 230000 && now.Hour < 1) {
                offset = -1;
            }
            else if (updateTime < 10000 && now.Hour == 23) {
                offset = 1;
            }
            now = now.AddDays(offset);
            return now.Year * 10000 + now.Month * 100 + now.Day;
        }

        public static void SetExchangeTime(CtpDepthMarketData data, DepthMarketDataField market)
        {
            market.TradingDay = GetDate(data.TradingDay);
            market.UpdateTime = GetTime(data.UpdateTime);
            market.UpdateMillisec = data.UpdateMillisec;
            if (!string.IsNullOrEmpty(data.ActionDay)
                && data.ActionDay.Length == 8) {
                market.ActionDay = GetDate(data.ActionDay);
            }
            else {
                market.ActionDay = GetActionDay(market.UpdateTime);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetCzceExchangeTime(CtpDepthMarketData data, DepthMarketDataField market)
        {
            SetExchangeTime(data, market);
        }

        public static void SetDceExchangeTime(CtpDepthMarketData data, DepthMarketDataField market)
        {
            market.TradingDay = GetDate(data.TradingDay);
            market.UpdateTime = GetTime(data.UpdateTime);
            market.UpdateMillisec = data.UpdateMillisec;
            if (!string.IsNullOrEmpty(data.ActionDay)
                && data.ActionDay.Length == 8
                && market.UpdateTime > 60000
                && market.UpdateTime < 180000) {
                market.ActionDay = GetDate(data.ActionDay);
            }
            else {
                market.ActionDay = GetActionDay(market.UpdateTime);
            }
        }

        public static OrderField GetOrder(CtpOrder data)
        {
            if (data == null) {
                return null;
            }
            var order = new OrderField();
            order.ID = GetId(data);
            order.LocalID = data.OrderRef;
            order.OrderID = data.OrderSysID;
            order.InstrumentID = data.InstrumentID;
            order.Qty = data.VolumeTotal;
            order.Side = GetOrderSide(data.Direction);
            order.OpenClose = GetOpenClose((byte)data.CombOffsetFlag[0]);
            order.HedgeFlag = GetHedgeFlag((byte)data.CombHedgeFlag[0]);
            order.Price = data.LimitPrice;
            order.StopPx = data.StopPrice;
            order.TimeInForce = TimeInForce.IOC;
            order.Type = order.Price > 0 ? OrderType.Limit : OrderType.Market;
            order.Status = GetOrderStatus(data);
            order.ExecType = GetExecType(data);
            order.SetText(data.StatusMsg);
            order.Date = GetDate(data.InsertDate);
            order.Time = GetTime(data.InsertTime);
            return order;
        }

        public static TradeField GetTrade(CtpTrade data)
        {
            if (data == null) {
                return null;
            }
            var trade = new TradeField();
            trade.ID = data.OrderSysID;
            trade.InstrumentID = data.InstrumentID;
            trade.ExchangeID = data.ExchangeID;
            trade.AccountID = data.InvestorID;
            trade.TradeID = data.TradeID;
            trade.Side = GetOrderSide(data.Direction);
            trade.Qty = data.Volume;
            trade.Price = data.Price;
            trade.OpenClose = GetOpenClose(data.OffsetFlag);
            trade.HedgeFlag = GetHedgeFlag(data.HedgeFlag);
            trade.Commission = 0;//TODO收续费以后要计算出来
            trade.Time = GetTime(data.TradeTime);
            trade.Date = GetDate(data.TradeDate);
            return trade;
        }

        private static OpenCloseType GetOpenClose(byte flag)
        {
            switch (flag) {
                case CtpOffsetFlagType.Close:
                case CtpOffsetFlagType.CloseYesterday:
                    return OpenCloseType.Close;
                case CtpOffsetFlagType.CloseToday:
                    return OpenCloseType.CloseToday;
                default:
                    return OpenCloseType.Open;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static OrderSide GetOrderSide(byte direction)
        {
            if (direction == CtpDirectionType.Buy) {
                return OrderSide.Buy;
            }
            return OrderSide.Sell;
        }
    }
}