using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using Skyline;
using SmartQuant;

namespace QuantBox
{
    public class TradingCalendar : TradingCalendarBase
    {
        public static readonly DateTime CalendarBegin;
        public static readonly DateTime CalendarEnd;
        public static readonly TradingCalendar Instance;
        public static readonly Logger Logger;

        static TradingCalendar()
        {
            CalendarBegin = new DateTime(DateTime.Today.Year - 10, 1, 1);
            CalendarEnd = new DateTime(DateTime.Today.Year + 1, 12, 31);
            Instance = new TradingCalendar();
            Logger = LogManager.GetLogger("TradingCalendar");
        }

        public DateTime TradingDay { get; private set; } = DateTime.MinValue;

        public void Init(DateTime tradingDay, bool updateCalendar = true, string host = "data.quantbox.cn")
        {
            lock (this) {
                if (TradingDay != tradingDay) {
                    TradingDay = tradingDay;
                    Load();
                    if (updateCalendar || (!DayList.HolidayLoaded || DayList.BeginDate.Year != CalendarBegin.Year)) {
                        UpdateDataFromRemote(host);
                        Load();
                    }
                }
            }
        }

        private static string GetTimeRangeDataFile()
        {
            return Path.Combine(Installation.ConfigDir.FullName, "quantbox", "trading_range.json");
        }

        private static string GetCalendarDataFile()
        {
            return Path.Combine(Installation.ConfigDir.FullName, "quantbox", "trading_calendar.json");
        }

        private static void UpdateDataFromRemote(string host)
        {
            const string remoteTimeRangeFile = "http://{0}/get_exchange_trading_time_data";
            using (var wc = new WebClient()) {
                try {
                    var tempFile = Path.GetTempFileName();
                    var task = wc.DownloadFileTaskAsync(string.Format(remoteTimeRangeFile, host), tempFile);
                    task.Wait(5000);
                    if (wc.IsBusy || task.Status == TaskStatus.WaitingForActivation) {
                        wc.CancelAsync();
                        wc.Dispose();
                    }

                    if (File.Exists(tempFile) && new FileInfo(tempFile).Length > 0) {
                        File.Copy(tempFile, GetTimeRangeDataFile(), true);
                        File.Delete(tempFile);
                    }
                }
                catch (Exception e) {
                    Logger.Warn($@"Update time range from remote: [{e}]");
                }
            }
            const string remoteCalendarUrl = "http://{2}/trading_dates?start_date={0}0101&end_date={1}1231";
            using (var wc = new WebClient()) {
                try {
                    var uri = new Uri(string.Format(remoteCalendarUrl, CalendarBegin.Year, CalendarEnd.Year, host));
                    var tempFile = Path.GetTempFileName();
                    var task = wc.DownloadFileTaskAsync(uri, tempFile);
                    task.Wait(5000);
                    if (wc.IsBusy || task.Status == TaskStatus.WaitingForActivation) {
                        wc.CancelAsync();
                        wc.Dispose();
                    }

                    if (File.Exists(tempFile) && new FileInfo(tempFile).Length > 0) {
                        File.Copy(tempFile, GetCalendarDataFile(), true);
                        File.Delete(tempFile);
                    }
                }
                catch (Exception e) {
                    Logger.Warn($@"Update calendar from remote: [{e}]");
                }
            }
        }

        private TradingCalendar()
        {
            DayList = new TradingDayList(CalendarBegin, CalendarEnd);
        }

        private void LoadTimeRange()
        {
            try {
                var file = GetTimeRangeDataFile();
                if (File.Exists(file)) {
                    var manager = new TradingTimeManager();
                    manager.Load(JsonConvert.DeserializeObject<string[][]>(QBHelper.ReadOnlyAllText(file)));
                    TimeManager = manager;
                }
            }
            catch (Exception e) {
                Logger.Warn($@"LoadTimeRange [{e}]");
            }
        }

        private void LoadCalendar()
        {
            try {
                var file = GetCalendarDataFile();
                if (File.Exists(file)) {
                    var list = JToken.Parse(QBHelper.ReadOnlyAllText(file));
                    var firstDate = ParseDateTime(list.First);
                    var days = new TradingDayList(firstDate.AddDays(-firstDate.DayOfYear + 1), CalendarEnd);
                    var current = list.First;
                    while (current != null) {
                        var date = ParseDateTime(current);
                        days[date] = true;
                        current = current.Next;
                    }
                    days.SetHoliday();
                    DayList = days;
                }
            }
            catch (Exception e) {
                Logger.Warn($@"LoadCalendar [{e}]");
            }

            DateTime ParseDateTime(JToken current)
            {
                return DateTime.ParseExact((string)current, "yyyyMMdd", null);
            }
        }

        private void Load()
        {
            LoadCalendar();
            LoadTimeRange();
        }

        public TradingTimeRange GetTimeRange(Instrument inst, DateTime date)
        {
            return GetTimeRange(inst.Symbol, date);
        }

        public IList<TradingTimeRange> GetTimeRanges(Instrument inst)
        {
            return GetTimeRanges(inst.Symbol);
        }

        public DateTime GetNextMarketOpenTime(Instrument inst, DateTime dateTime, bool backtestMode = false, DateTime? dateTime1 = null)
        {
            return GetNextMarketOpenTime(inst.Symbol, dateTime, backtestMode, dateTime1);
        }

        public DateTime GetNextCloseTime(Instrument inst, DateTime dateTime)
        {
            return GetNextCloseTime(inst.Symbol, dateTime);
        }
    }
}