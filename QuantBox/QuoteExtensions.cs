using System;
using QuantBox.XApi;
using SmartQuant;

namespace QuantBox
{
    public static class QuoteExtensions
    {
        private static DepthMarketDataField GetMarketData(this Instrument inst)
        {
            return (DepthMarketDataField)inst.Fields[QuantBoxConst.InstrumentMarketDataOffset];
        }

        public static TradingTimeRange GetTimeRange(this Instrument inst)
        {
            return (TradingTimeRange)inst.Fields[QuantBoxConst.InstrumentTimeManagerOffset];
        }

        public static void SetTimeRange(this Instrument inst, TradingTimeRange manager)
        {
            inst.Fields[QuantBoxConst.InstrumentTimeManagerOffset] = manager;
        }

        public static void SetMarketData(this Instrument inst, DepthMarketDataField field)
        {
            inst.Fields[QuantBoxConst.InstrumentMarketDataOffset] = field;
        }

        public static double GetUpperLimitPrice(this Instrument inst)
        {
            return GetMarketData(inst)?.UpperLimitPrice ?? double.NaN;
        }

        public static double GetLowerLimitPrice(this Instrument inst)
        {
            return GetMarketData(inst)?.LowerLimitPrice ?? double.NaN;
        }

        public static double GetOpenPrice(this Instrument inst)
        {
            return GetMarketData(inst)?.OpenPrice ?? double.NaN;
        }

        public static double GetPreClosePrice(this Instrument inst)
        {
            return GetMarketData(inst)?.PreClosePrice ?? double.NaN;
        }

        public static DateTime GetTradingDay(this Instrument inst)
        {
            return GetMarketData(inst)?.TradingDay() ?? DateTime.Today;
        }

        public static double GetPreOpenInterest(this Instrument inst)
        {
            return GetMarketData(inst)?.PreOpenInterest ?? double.NaN;
        }

        public static DepthMarketDataField GetMarketData(this Trade trade)
        {
            return (DepthMarketDataField)trade.Fields[QuantBoxConst.TradeMarketDataOffset];
        }

        public static double GetOpenInterest(this Trade trade)
        {
            return trade.Fields[QuantBoxConst.TradeOpenInterestOffset] == null
                ? double.NaN
                : trade.Fields.GetDouble(QuantBoxConst.TradeOpenInterestOffset);
        }

        public static double GetTurnover(this Trade trade)
        {
            return trade.Fields[QuantBoxConst.TradeTurnoverOffset] == null
                ? double.NaN
                : trade.Fields.GetDouble(QuantBoxConst.TradeTurnoverOffset);
        }

        public static double GetClosePrice(this Trade trade)
        {
            return trade.Fields[QuantBoxConst.TradeClosePriceOffset] == null
                ? double.NaN
                : trade.Fields.GetDouble(QuantBoxConst.TradeClosePriceOffset);
        }

        public static void SetMarketData(this Trade trade, DepthMarketDataField field)
        {
            trade.Fields[QuantBoxConst.TradeMarketDataOffset] = field;
            trade.Fields[QuantBoxConst.TradeClosePriceOffset] = field.ClosePrice;
        }

        public static void SetMarketData(this Trade trade, double turnover, double openInterest)
        {
            trade.Fields[QuantBoxConst.TradeOpenInterestOffset] = openInterest;
            trade.Fields[QuantBoxConst.TradeTurnoverOffset] = turnover;
        }
    }
}