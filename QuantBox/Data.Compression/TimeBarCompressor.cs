using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skyline;
using SmartQuant;

namespace QuantBox.Data.Compression
{
    internal class TimeBarCompressor : BarCompressor
    {
        public TimeBarCompressor(Instrument inst) : base(inst)
        {
        }

        public override void Add(DataEntry entry)
        {
            if (entry == null) {
                return;
            }
            var timeRanges = entry.TimeRanges;
            if (bar == null || (bar.CloseDateTime <= entry.DateTime && !timeRanges.IsEndPoint(entry.DateTime.TimeOfDay))) {
                if (bar != null) {
                    EmitNewCompressedBar();
                }
                if (timeRanges.InRange(entry.DateTime.TimeOfDay)) {
                    DateTime barBeginTime = GetBarBeginTime(entry.DateTime, timeRanges);
                    DateTime barEndTime = GetBarEndTime(barBeginTime, timeRanges);
                    CreateNewBar(BarType.Time, barBeginTime, barEndTime, entry.Items[0].Price);
                }
            }
            if (bar != null) {
                AddItemsToBar(entry.Items);
            }
        }

        private DateTime GetBarBeginTime(DateTime datetime, TradingTimeRange timeRanges)
        {
            if (timeRanges.InFristMd(datetime.TimeOfDay)) {
                if (datetime.TimeOfDay > timeRanges.CloseTime) {
                    datetime = datetime.Date.Add(timeRanges.NightOpenTime);
                }
                else {
                    datetime = datetime.Date.Add(timeRanges.OpenTime);
                }
            }
            if (newBarSize > QuantBoxConst.DayBarSize) {
                var tradingDay = datetime.Date;
                if (datetime.TimeOfDay > timeRanges.CloseTime) {
                    tradingDay = TradingCalendar.Instance.GetNextTradingDay(tradingDay);
                }
                if (newBarSize == QuantBoxConst.DayBarSize) {
                    return tradingDay;
                }
                if (newBarSize == QuantBoxConst.WeekBarSize) {
                    int num = (int)((tradingDay.DayOfWeek == DayOfWeek.Sunday) ? DayOfWeek.Saturday : (tradingDay.DayOfWeek - 1));
                    return tradingDay.AddDays(-num);
                }
                if (newBarSize == QuantBoxConst.MonthBarSize) {
                    return tradingDay.AddDays(-tradingDay.Day + 1);
                }
            }
            long seconds = (long)datetime.TimeOfDay.TotalSeconds / newBarSize * newBarSize;
            return datetime.Date.AddSeconds(seconds);
        }

        private DateTime GetBarEndTime(DateTime begintime, TradingTimeRange timeRanges)
        {
            if (newBarSize > QuantBoxConst.DayBarSize) {
                if (newBarSize == QuantBoxConst.DayBarSize) {
                    return begintime.Add(timeRanges.CloseTime);
                }
                if (newBarSize == QuantBoxConst.WeekBarSize) {
                    var date = begintime.Date.AddDays(5);
                    if (!TradingCalendar.Instance.IsTradingDay(date)) {
                        date = TradingCalendar.Instance.GetPrevTradingDay(date);
                    }
                    return date.Add(timeRanges.CloseTime);
                }
                if (newBarSize == QuantBoxConst.MonthBarSize) {
                    var date = begintime.Date.AddMonths(1).AddDays(-1);
                    if (!TradingCalendar.Instance.IsTradingDay(date)) {
                        date = TradingCalendar.Instance.GetPrevTradingDay(date);
                    }
                    return date.Add(timeRanges.CloseTime);
                }
            }

            var datetime = begintime.AddSeconds(newBarSize);
            if (datetime.TimeOfDay > timeRanges.CloseTime && (timeRanges.NightOpenTime == TimeSpan.Zero || datetime.TimeOfDay < timeRanges.NightOpenTime)) {
                datetime = datetime.Date.Add(timeRanges.CloseTime);
            }
            return datetime;
        }
    }
}
