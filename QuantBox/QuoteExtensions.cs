using System;
using QuantBox.XApi;
using SmartQuant;

namespace QuantBox
{
    public static class QuoteExtensions
    {
        public static DepthMarketDataField GetMarketData(this Instrument inst)
        {
            return (DepthMarketDataField)inst.Fields[QuantBoxConst.ExtensionsOffset];
        }

        public static void SetMarketData(this Instrument inst, DepthMarketDataField field)
        {
            inst.Fields[QuantBoxConst.ExtensionsOffset] = field;
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

        public static double GetOpenInterest(this Instrument inst)
        {
            return GetMarketData(inst)?.OpenInterest ?? double.NaN;
        }

        public static double GetPreOpenInterest(this Instrument inst)
        {
            return GetMarketData(inst)?.PreOpenInterest ?? double.NaN;
        }

        public static double GetTurnover(this Instrument inst)
        {
            return GetMarketData(inst)?.Turnover ?? double.NaN;
        }

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