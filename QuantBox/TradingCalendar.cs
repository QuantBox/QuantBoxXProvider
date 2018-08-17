using System;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using SmartQuant;

namespace QuantBox
{
    public class TradingCalendar
    {
        private const string RemoteTimeRangeFile = "http://data.thanf.com/get_exchange_trading_time_data";
        private const string RemoteCalendarUrl = "http://data.thanf.com/trading_dates?start_date={0}0101&end_date={1}1231";

        private TradingTimeManager _manager = new TradingTimeManager();
        private TradingDayList _tradingDayList;
        public static readonly DateTime CalendarBegin;
        public static readonly DateTime CalendarEnd;
        public static readonly TradingCalendar Instance;

        static TradingCalendar()
        {
            CalendarBegin = new DateTime(DateTime.Today.Year - 1, 1, 1);
            CalendarEnd = new DateTime(DateTime.Today.Year, 12, 31);
            Instance = new TradingCalendar();
        }

        public DateTime TradingDay { get; private set; } = DateTime.MinValue;

        public void Init(DateTime tradingDay, bool updateCalendar = true)
        {
            if (TradingDay != tradingDay) {
                TradingDay = tradingDay;
                if (updateCalendar) {
                    UpdateDataFromRemote();
                }
                Load();
            }
        }

        private static string GetTimeRangeDataFile()
        {
            return Path.Combine(Installation.ConfigDir.FullName, "thanf", "trading_range.json");
        }

        private static string GetCalendarDataFile()
        {
            return Path.Combine(Installation.ConfigDir.FullName, "thanf", "trading_calendar.json");
        }

        private static void UpdateDataFromRemote()
        {
            try {
                var downloadTask = new WebClient().DownloadFileTaskAsync(RemoteTimeRangeFile, GetTimeRangeDataFile());
                downloadTask.Wait(2000);
                var uri = new Uri(string.Format(RemoteCalendarUrl, CalendarBegin.Year, CalendarEnd.Year));
                var stringTask = new WebClient().DownloadStringTaskAsync(uri);
                stringTask.Wait(2000);
                if (stringTask.IsCompleted) {
                    File.WriteAllText(GetCalendarDataFile(), stringTask.Result);
                }
            }
            catch (Exception) {
                // ignored
            }
        }

        private TradingCalendar()
        {
            _tradingDayList = new TradingDayList(CalendarBegin, CalendarEnd);
        }

        private void LoadTimeRange()
        {
            try {
                var file = GetTimeRangeDataFile();
                if (File.Exists(file)) {
                    var manager = new TradingTimeManager();
                    manager.Load(file);
                    _manager = manager;
                }
            }
            catch (Exception) {
                // ignored
            }
        }

        private void LoadCalendar()
        {
            try {
                var file = GetCalendarDataFile();
                if (File.Exists(file)) {
                    var list = JToken.Parse(File.ReadAllText(file));
                    var current = list.First;
                    var days = new TradingDayList(CalendarBegin, CalendarEnd);
                    while (current != null) {
                        var date = DateTime.ParseExact((string)current, "yyyyMMdd", null);
                        days[date] = true;
                        current = current.Next;
                    }
                    _tradingDayList = days;
                }
            }
            catch (Exception) {
                // ignored
            }
        }

        private void Load()
        {
            LoadCalendar();
            LoadTimeRange();
        }

        public TradingTimeRange GetTimeRange(Instrument inst, DateTime date)
        {
            return _manager.GetTimeRange(inst, date);
        }

        public bool IsTradingDay(DateTime date)
        {
            if (date >= _tradingDayList.BeginDate && date <= _tradingDayList.EndDate) {
                return _tradingDayList[date];
            }
            return date.DayOfWeek != DayOfWeek.Sunday && date.DayOfWeek != DayOfWeek.Saturday;
        }

        private DateTime SeekTradingDay(DateTime day, bool next = true)
        {
            var offset = 1;
            if (!next) {
                offset = -1;
            }

            var tmp = day.AddDays(offset);
            if (day > _tradingDayList.EndDate || day < _tradingDayList.BeginDate) {
                while (true) {
                    if (tmp.DayOfWeek != DayOfWeek.Saturday && tmp.DayOfWeek != DayOfWeek.Sunday)
                        return day;
                    tmp = tmp.AddDays(offset);
                }
            }
            while (true) {
                if (IsTradingDay(tmp))
                    return tmp;
                tmp = tmp.AddDays(offset);
            }
        }
        public DateTime GetNextTradingDay(DateTime date)
        {
            return SeekTradingDay(date);
        }

        public DateTime GetPrevTradingDay(DateTime day)
        {
            return SeekTradingDay(day, false);
        }
    }
}