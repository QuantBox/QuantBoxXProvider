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

        public static TimeRangeManager GetTimeFilter(this Instrument inst)
        {
            return (TimeRangeManager)inst.Fields[QuantBoxConst.InstrumentTimeManagerOffset];
        }

        public static void SetTimeFilter(this Instrument inst, TimeRangeManager manager)
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

        [Obsolete("持仓量不再储存在合约中，请从QBTrade中获取", true)]
        public static double GetOpenInterest(this Instrument inst)
        {
            return GetMarketData(inst)?.OpenInterest ?? double.NaN;
        }

        public static double GetPreOpenInterest(this Instrument inst)
        {
            return GetMarketData(inst)?.PreOpenInterest ?? double.NaN;
        }

        [Obsolete("成交金额不再储存在合约中，请从QBTrade中获取", true)]
        public static double GetTurnover(this Instrument inst)
        {
            return GetMarketData(inst)?.Turnover ?? double.NaN;
        }

        [Obsolete("成交均价不再储存在合约中，请从QBTrade中获取", true)]
        public static double GetAveragePrice(this Instrument inst)
        {
            return GetMarketData(inst)?.AveragePrice ?? double.NaN;
        }

        public static DateTime GetTradingDay(this Instrument inst)
        {
            return GetMarketData(inst)?.TradingDay() ?? DateTime.Today;
        }
    }
}