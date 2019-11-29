using System;
using System.Collections.Generic;

namespace QuantBox.Sfit.Api
{
    public static class CtpHelper
    {
        private static readonly Dictionary<string, TimeSpan> StrTimeMap;
        private static readonly Dictionary<string, DateTime> StrDateMap;
        private static readonly string[] TimeStrMap;
        private static readonly string[] DateStrMap;
        private static readonly int CatchYear = DateTime.Today.Year;

        public static DateTime StrToDate(string str)
        {
            try
            {
                return DateTime.ParseExact(str, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
            }
            catch (Exception)
            {
                return DateTime.Today;
            }
        }

        static CtpHelper()
        {
            var beginTime = new TimeSpan(0, 0, 0);
            var endTime = new TimeSpan(23, 59, 59);
            var countTime = (int)((endTime - beginTime).TotalSeconds) + 1;

            StrTimeMap = new Dictionary<string, TimeSpan>(countTime);
            TimeStrMap = new string[countTime];

            for (var i = 0; i < countTime; i++) {
                var time = beginTime.Add(TimeSpan.FromSeconds(i));
                var str = time.ToString();
                StrTimeMap.Add(str, time);
                TimeStrMap[i] = str;
            }

            var beginDate = new DateTime(DateTime.Today.Year, 1, 1);
            var endDate = beginDate.AddYears(1);
            var countDate = (int)((endDate - beginDate).TotalDays);

            StrDateMap = new Dictionary<string, DateTime>(countDate);
            DateStrMap = new string[countDate];

            for (var i = 0; i < countDate; i++) {
                var date = beginDate.AddDays(i);
                var str = date.ToString("yyyyMMdd");
                StrDateMap.Add(str, date);
                DateStrMap[i] = str;
            }
        }

        public static DateTime GetExchangeTime(CtpDepthMarketData data)
        {
            //直接按HH:mm:ss来解析，测试过这种方法目前是效率比较高的方法
            try {
                // 模拟时TradingDay周五晚上收的日期是周一,ActionDay为空

                // 20140310 想来想去，时间的确定还是使用TradingDay，使用实际日期
                // 20140315 TradingDay在夜盘时是第二天的时间，在行情去重Block会出错，使0点后的行情全无法传出
                var span = GetSpan(data.UpdateTime);

                // 夜盘时间，从TradingDay中取的交易时间与日历不对，特别是周五晚到周六早上
                // 本想取ActionDay，但模拟中目前为空
                DateTime date;
                var dayText = data.ActionDay;
                // 除了有取出为“”的情况，还有取去为“$4”的情况，好吧，只能这样了
                if (dayText.Length != 8) {
                    // 如何证明慢了一天或快了一天呢？
                    date = DateTime.Today;
                    if (span.Hours >= 23) {
                        if (date.Hour <= 1) {
                            // 表示行情时间慢了，系统日期减一天即可
                            date = date.AddDays(-1);
                        }
                    }
                    else if (span.Hours <= 1) {
                        if (date.Hour >= 23) {
                            // 表示本地时间慢了，本地时间加一天即可
                            date = date.AddDays(1);
                        }
                    }

                    // !!!! 这种处理方法的后果是，如果你周日登录了
                    // 行情本是周六凌晨的最后一笔，变成了周日凌晨有一笔了
                    // 无所谓，这个错误数据由用户自己来过滤
                }
                else {
                    // 取的是ActionDay，这是最简单的结果
                    date = GetDate(dayText);
                }

                return date.Add(span).AddMilliseconds(data.UpdateMillisec);
            }
            catch (Exception) {
                // 这个地方到底是用哪个时间比较好，
                //return framework.Clock.DateTime;
                return DateTime.Now;
            }
        }

        public static TimeSpan GetSpan(string time)
        {
            StrTimeMap.TryGetValue(time, out var span);
            return span;
        }

        public static DateTime GetTime(string date, string time)
        {
            if (date.Length == 8 && time.Length == 8) {
                var span = StrTimeMap[time];
                return GetDate(date).Add(span);
            }
            return DateTime.MinValue;
        }

        public static DateTime GetDate(string date)
        {
            if (date.Length == 8) {
                if (StrDateMap.TryGetValue(date, out var d)) {
                    return d;
                }
                var yyyy = int.Parse(date.Substring(0, 4));
                var mm = int.Parse(date.Substring(4, 2));
                var dd = int.Parse(date.Substring(6, 2));
                return new DateTime(yyyy, mm, dd);
            }
            return DateTime.Today;
        }

        public static string DateToStr(DateTime date)
        {
            if (date.Year == CatchYear) {
                return DateStrMap[date.DayOfYear -1];
            }
            return date.ToString("yyyyMMdd");
        }

        public static string TimeToStr(DateTime date)
        {
            return TimeStrMap[date.Hour * 60 * 60 + date.Minute * 60 + date.Second];
        }
    }
}
