﻿using System;
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
        private const int LockPort = 15346;

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
                if (TradingDay == tradingDay) {
                    return;
                }

                TradingDay = tradingDay;
                Load();
                if (!updateCalendar && DayList.HolidayLoaded && DayList.BeginDate.Year == CalendarBegin.Year) {
                    return;
                }

                UpdateDataFromRemote(host);
                Load();
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

                    if (File.Exists(tempFile)) {
                        try {
                            new TradingCalendar().LoadTimeRange(tempFile);
                            GlobalWait.Run(LockPort, () => File.Copy(tempFile, GetTimeRangeDataFile(), true), 1000);
                        }
                        catch (Exception) {
                            // ignored
                        }

                        File.Delete(tempFile);
                    }
                }
                catch (Exception e) {
                    Logger.Warn($@"Update time range from remote:{remoteTimeRangeFile}[{e}]");
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

                    if (File.Exists(tempFile)) {
                        try {
                            new TradingCalendar().LoadCalendar(tempFile);
                            GlobalWait.Run(LockPort, () => File.Copy(tempFile, GetCalendarDataFile(), true), 1000);
                        }
                        catch (Exception) {
                            // ignored
                        }

                        File.Delete(tempFile);
                    }
                }
                catch (Exception e) {
                    Logger.Warn($"Update calendar from remote:{remoteCalendarUrl}[{e}]");
                }
            }
        }

        private TradingCalendar()
        {
            DayList = new TradingDayList(CalendarBegin, CalendarEnd);
        }

        private void LoadTimeRange(string file = null)
        {
            file = file ?? GetTimeRangeDataFile();
            if (!File.Exists(file)) {
                return;
            }
            var content = QBHelper.ReadOnlyAllText(file);
            try {
                var manager = new TradingTimeManager();
                manager.Load(JsonConvert.DeserializeObject<string[][]>(content));
                TimeManager = manager;
            }
            catch (Exception e) {
                Logger.Warn($"LoadTimeRange [{e.Message}]");
            }
        }

        private void LoadCalendar(string file = null)
        {
            file = file ?? GetCalendarDataFile();
            if (!File.Exists(file)) {
                return;
            }

            var content = QBHelper.ReadOnlyAllText(file);

            try {
                var list = JToken.Parse(content);
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
            catch (Exception e) {
                Logger.Warn($"LoadCalendar content:[{content}] error:[{e.Message}]");
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