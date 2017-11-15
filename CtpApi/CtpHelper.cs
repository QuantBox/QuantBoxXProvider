using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantBox.Sfit.Api
{
    public static class CtpHelper
    {
        readonly static Dictionary<string, TimeSpan> _strTimeMap;
        readonly static Dictionary<string, DateTime> _strDateMap;
        readonly static string[] _timeStrMap;
        readonly static string[] _dateStrMap;
        readonly static int CatchYear = DateTime.Today.Year;

        public static DateTime StrToDate(string str)
        {
            try
            {
                return DateTime.ParseExact(str, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
            }
            catch (Exception ex)
            {
                return DateTime.Today;
            }
        }

        static CtpHelper()
        {
            var beginTime = new TimeSpan(0, 0, 0);
            var endTime = new TimeSpan(23, 59, 59);
            var countTime = (int)((endTime - beginTime).TotalSeconds) + 1;

            _strTimeMap = new Dictionary<string, TimeSpan>(countTime);
            _timeStrMap = new string[countTime];

            for (var i = 0; i < countTime; i++) {
                var time = beginTime.Add(TimeSpan.FromSeconds(i));
                var str = time.ToString();
                _strTimeMap.Add(str, time);
                _timeStrMap[i] = str;
            }

            var beginDate = new DateTime(DateTime.Today.Year, 1, 1);
            var endDate = beginDate.AddYears(1);
            var countDate = (int)((endDate - beginDate).TotalDays);

            _strDateMap = new Dictionary<string, DateTime>(countDate);
            _dateStrMap = new string[countDate];

            for (var i = 0; i < countDate; i++) {
                var date = beginDate.AddDays(i);
                var str = date.ToString("yyyyMMdd");
                _strDateMap.Add(str, date);
                _dateStrMap[i] = str;
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
            TimeSpan span;
            _strTimeMap.TryGetValue(time, out span);
            return span;
        }

        public static DateTime GetTime(string date, string time)
        {
            if (date.Length == 8 && time.Length == 8) {
                var span = _strTimeMap[time];
                return GetDate(date).Add(span);
            }
            return DateTime.MinValue;
        }

        public static DateTime GetDate(string date)
        {
            if (date.Length == 8) {
                DateTime d;
                if (_strDateMap.TryGetValue(date, out d)) {
                    return d;
                }
                var yyyy = int.Parse(date.Substring(0, 4));
                var MM = int.Parse(date.Substring(4, 2));
                var dd = int.Parse(date.Substring(6, 2));
                return new DateTime(yyyy, MM, dd);
            }
            return DateTime.Today;
        }

        public static string DateToStr(DateTime date)
        {
            if (date.Year == CatchYear) {
                return _dateStrMap[date.DayOfYear -1];
            }
            return date.ToString("yyyyMMdd");
        }

        public static string TimeToStr(DateTime date)
        {
            return _timeStrMap[date.Hour * 60 * 60 + date.Minute * 60 + date.Second];
        }
    }
}
