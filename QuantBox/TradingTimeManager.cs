using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using SmartQuant;

namespace QuantBox
{
    public class TradingTimeManager
    {
        public static readonly TimeSpan OffsetMinutes = TimeSpan.FromMinutes(1);
        private readonly Dictionary<string, List<TradingTimeRange>> _items = new Dictionary<string, List<TradingTimeRange>>();
        private static readonly TradingTimeRange Stock;
        private static readonly TimeSpan LastForDay = new TimeSpan(23, 59, 59);

        static TradingTimeManager()
        {
            Stock = new TradingTimeRange(DateTime.MinValue, DateTime.MaxValue);
            Stock.AddRange(new TimeRange(new TimeSpan(9, 30, 0), new TimeSpan(11, 30, 0), true, false, false));
            Stock.AddRange(new TimeRange(new TimeSpan(13, 00, 0), new TimeSpan(15, 00, 0), false, true, false));
        }

        private static DateTime ParseDateTime(string date)
        {
            return DateTime.ParseExact(date, "yyyyMMdd", null);
        }

        private static TimeSpan ParseTimeSpan(string span)
        {
            return TimeSpan.ParseExact(span, "hhmmss", null);
        }

        private static IEnumerable<TimeRange> ParseTimeRange(string data)
        {
            var ranges = new List<TimeRange>();
            var items = data.Split(';');
            for (var i = 0; i < items.Length; i++) {
                var item = items[i];
                var pair = item.Split('-');
                var range = new TimeRange();
                range.Begin = ParseTimeSpan(pair[0]);
                range.End = ParseTimeSpan(pair[1]);
                range.IsOpen = i == 0 || i == 1 && ranges[0].IsNight;
                range.IsNight = range.Begin.Hours == 21;
                range.IsClose = i == items.Length - 1;
                if (range.IsOpen) {
                    range.Begin = range.Begin.Subtract(OffsetMinutes);
                }
                ranges.Add(range);
                if (range.Begin > range.End) {
                    var temp = new TimeRange(TimeSpan.Zero, range.End);
                    ranges.Add(temp);
                    range.End = LastForDay;
                }
            }
            return ranges;
        }

        public void Load(string file)
        {
            var list = JArray.Parse(File.ReadAllText(file));
            var current = list.First;
            while (current != null) {
                var items = (JArray)current;
                var product = items[1].Value<string>();
                if (!_items.TryGetValue(product, out var ranges)) {
                    ranges = new List<TradingTimeRange>();
                    _items.Add(product, ranges);
                }
                var date1 = ParseDateTime(items[4].Value<string>());
                var date2 = ParseDateTime(items[5].Value<string>());
                var range = new TradingTimeRange(date1, date2);
                foreach (var item in ParseTimeRange(items[2].Value<string>())) {
                    range.AddRange(item);
                }
                ranges.Add(range);
                current = current.Next;
            }
        }

        public TradingTimeRange GetTimeRange(Instrument inst, DateTime date)
        {
            if (inst.Type == InstrumentType.Stock) {
                return Stock;
            }
            if (inst.Type == InstrumentType.Future) {
                var match = Regex.Match(inst.Symbol, @"([a-zA-Z]+)\d+");
                if (match.Success) {
                    if (_items.TryGetValue(match.Groups[1].Value.ToUpper(), out var list)) {
                        foreach (var range in list) {
                            if (date >= range.DateTime1 && date <= range.DateTime2) {
                                return range;
                            }
                        }
                    }
                }
            }
            return Stock;
        }
    }
}