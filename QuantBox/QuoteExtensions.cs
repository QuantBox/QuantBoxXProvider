using System;
using System.Runtime.CompilerServices;
using QuantBox.XApi;
using Skyline;
using SmartQuant;

namespace QuantBox
{
    public static class QuoteExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DepthMarketDataField GetMarketData(this Instrument inst)
        {
            return (DepthMarketDataField)inst.Fields[QuantBoxConst.InstrumentMarketDataOffset];
        }

        #region Instrument
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TradingTimeRange GetTimeRange(this Instrument inst)
        {
            return (TradingTimeRange)inst.Fields[QuantBoxConst.InstrumentTimeManagerOffset];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetTimeRange(this Instrument inst, TradingTimeRange manager)
        {
            inst.Fields[QuantBoxConst.InstrumentTimeManagerOffset] = manager;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetMarketData(this Instrument inst, DepthMarketDataField field)
        {
            inst.Fields[QuantBoxConst.InstrumentMarketDataOffset] = field;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetUpperLimitPrice(this Instrument inst)
        {
            return GetMarketData(inst)?.UpperLimitPrice ?? double.NaN;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetLowerLimitPrice(this Instrument inst)
        {
            return GetMarketData(inst)?.LowerLimitPrice ?? double.NaN;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetOpenPrice(this Instrument inst)
        {
            return GetMarketData(inst)?.OpenPrice ?? double.NaN;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetPreClosePrice(this Instrument inst)
        {
            return GetMarketData(inst)?.PreClosePrice ?? double.NaN;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DateTime GetTradingDay(this Instrument inst)
        {
            return GetMarketData(inst)?.TradingDay() ?? DateTime.Today;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetPreOpenInterest(this Instrument inst)
        {
            return GetMarketData(inst)?.PreOpenInterest ?? double.NaN;
        }
        #endregion

        #region Trade
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DepthMarketDataField GetMarketData(this Trade trade)
        {
            return (DepthMarketDataField)trade.Fields[QuantBoxConst.TradeMarketDataOffset];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetOpenInterest(this Trade trade)
        {
            return trade.Fields[QuantBoxConst.TradeOpenInterestOffset] == null
                ? 0
                : trade.Fields.GetDouble(QuantBoxConst.TradeOpenInterestOffset);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetTurnover(this Trade trade)
        {
            return trade.Fields[QuantBoxConst.TradeTurnoverOffset] == null
                ? 0
                : trade.Fields.GetDouble(QuantBoxConst.TradeTurnoverOffset);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetClosePrice(this Trade trade)
        {
            return trade.Fields[QuantBoxConst.TradeClosePriceOffset] == null
                ? double.NaN
                : trade.Fields.GetDouble(QuantBoxConst.TradeClosePriceOffset);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetMarketData(this Trade trade, DepthMarketDataField field)
        {
            trade.Fields[QuantBoxConst.TradeMarketDataOffset] = field;
            trade.Fields[QuantBoxConst.TradeClosePriceOffset] = field.ClosePrice;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetMarketData(this Trade trade, double turnover, double openInterest)
        {
            trade.Fields[QuantBoxConst.TradeOpenInterestOffset] = openInterest;
            trade.Fields[QuantBoxConst.TradeTurnoverOffset] = turnover;
        }

        [Obsolete("使用VWap()", true)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetVWap(this Trade trade)
        {
            return VWap(trade);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double VWap(this Trade trade)
        {
            if (trade.Size == 0) {
                return trade.Price;
            }
            var turnover = GetTurnover(trade);
            return turnover / trade.Size;
        }
        #endregion

        #region Bar

        public static void AddQBTimeBar(this BarFactory factory, Instrument inst, long barSize)
        {
            var barItem = new QBTimeBarFactoryItem(inst, barSize);
            factory.Add(barItem);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetTurnover(this Bar bar, double turnover)
        {
            bar.Fields[QuantBoxConst.BarTurnoverOffset] = turnover;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetTurnover(this Bar bar)
        {
            return bar.Fields[QuantBoxConst.BarTurnoverOffset] == null
                ? 0
                : bar.Fields.GetDouble(QuantBoxConst.BarTurnoverOffset);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IncTurnover(this Bar bar, double turnover)
        {
            if (turnover != 0) {
                var v = bar.Fields[QuantBoxConst.BarTurnoverOffset] == null
                    ? 0
                    : bar.Fields.GetDouble(QuantBoxConst.BarTurnoverOffset);
                bar.Fields[QuantBoxConst.BarTurnoverOffset] = v + turnover;
            }
        }

        [Obsolete("用VWap()替换", true)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetVWap(this Bar bar)
        {
            return VWap(bar);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double VWap(this Bar bar)
        {
            if (bar.Volume == 0) {
                return bar.Close;
            }
            var turnover = GetTurnover(bar);
            return turnover / bar.Volume;
        }
        #endregion

        #region TickSeries
        private static Instrument GetInstrument(TickSeries series)
        {
            return Framework.Current.InstrumentManager.GetById(series[0].InstrumentId);
        }

        /// <summary>
        /// 生成日线
        /// </summary>
        /// <param name="series"></param>
        /// <returns></returns>
        public static BarSeries DayCompress(this TickSeries series)
        {
            return TimeCompress(series, QuantBoxConst.DayBarSize);
        }

        /// <summary>
        /// 生成1分钟Bar
        /// </summary>
        /// <param name="series"></param>
        /// <returns></returns>
        public static BarSeries MinuteCompress(this TickSeries series, byte type = DataObjectType.Trade)
        {
            return TimeCompress(series, 60, type);
        }

        public static BarSeries TimeCompress(this TickSeries series, long barSize, byte type = DataObjectType.Trade)
        {
            if (series.Count == 0) {
                return new BarSeries();
            }
            return TimeCompress(series, GetInstrument(series), barSize, type);
        }

        public static BarSeries TimeCompress(this TickSeries series, Instrument inst, long barSize, byte type = DataObjectType.Trade)
        {
            if (series.Count == 0) {
                return new BarSeries();
            }
            return Data.Compression.BarCompressor
                .GetCompressor(inst, 0, barSize)
                .Compress(new Data.Compression.TickDataEnumerator(series, type));
        }

        #endregion

        #region BarSeries
        private static Instrument GetInstrument(BarSeries series)
        {
            return Framework.Current.InstrumentManager.GetById(series[0].InstrumentId);
        }

        /// <summary>
        /// 按指定的 BarSize 生成新的 Bar，新的 BarSize 应该是原始 BarSize 的整数倍，这个函数可以正确的处理夜盘数据。
        /// </summary>
        /// <param name="series"></param>
        /// <param name="inst"></param>
        /// <param name="barSize"></param>
        /// <returns></returns>
        public static BarSeries TimeCompress(this BarSeries series, Instrument inst, long barSize)
        {
            if (series.Count == 0) {
                return new BarSeries();
            }
            var bar = series[0];
            if (barSize > bar.Size && barSize % bar.Size == 0) {
                return Data.Compression.BarCompressor.GetCompressor(inst, bar.Size, barSize).Compress(new Data.Compression.BarDataEnumerator(series));
            }
            return series.Compress(barSize);
        }

        /// <summary>
        /// 按指定的 BarSize 生成新的 Bar，新的 BarSize 应该是原始 BarSize 的整数倍，这个函数可以正确的处理夜盘数据。
        /// </summary>
        /// <param name="series"></param>
        /// <param name="barSize"></param>
        /// <returns></returns>
        public static BarSeries TimeCompress(this BarSeries series, long barSize)
        {
            if (series.Count == 0) {
                return new BarSeries();
            }
            return TimeCompress(series, GetInstrument(series), barSize);
        }

        /// <summary>
        /// 把 count 个 Bar 合并成一个新的 Bar
        /// </summary>
        /// <param name="series"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static BarSeries MergeCompress(this BarSeries series, long count)
        {
            if (series.Count == 0) {
                return new BarSeries();
            }
            return MergeCompress(series, Framework.Current.InstrumentManager.GetById(series[0].InstrumentId), count);
        }

        /// <summary>
        /// 把 count 个 Bar 合并成一个新的 Bar
        /// </summary>
        /// <param name="series"></param>
        /// <param name="inst"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static BarSeries MergeCompress(this BarSeries series, Instrument inst, long count)
        {
            if (series.Count == 0 || count < 2) {
                return new BarSeries();
            }
            var selector = new TimeRangeSelector(inst);
            var emitOnClose = true;
            var bar = series[0];
            if (bar.Size >= QuantBoxConst.DayBarSize) {
                emitOnClose = false;
            }

            var bars = new BarSeries();
            Bar last = null;
            var index = 0;
            for (int i = 0; i < series.Count; i++) {
                var range = selector.Get(series[i].DateTime.Date);
                if (index == 0) {
                    last = series[i];
                }
                else {
                    QBHelper.MergeBar(last, series[i]);
                }
                ++index;
                if (index == count || (emitOnClose && series[i].CloseDateTime.TimeOfDay == range.CloseTime)) {
                    bars.Add(last);
                    last = null;
                    index = 0;
                    continue;
                }
            }
            return bars;
        }
        #endregion
    }
}