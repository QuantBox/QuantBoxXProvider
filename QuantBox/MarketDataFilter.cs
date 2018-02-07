using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using SmartQuant;

namespace QuantBox
{
    public class MarketDataFilter
    {
        private const string Futures = "futures";
        private const string Stock = "stock";

        private readonly TimeRangeManager _default = new TimeRangeManager();
        private readonly Dictionary<string, TimeRangeManager> _items = new Dictionary<string, TimeRangeManager>();

        public static readonly MarketDataFilter Instance;

        static MarketDataFilter()
        {
            lock (typeof(MarketDataFilter)) {
                Instance = new MarketDataFilter();
                Instance.Load();
            }
        }

        public MarketDataFilter()
        {
            _default.AddRange(new TimeRange(new TimeSpan(8, 59, 0), new TimeSpan(11, 30, 0), true, false, false));
            _default.AddRange(new TimeRange(new TimeSpan(13, 0, 0), new TimeSpan(15, 0, 0), false, true, false));
        }

        public void Load()
        {
            try {
                var file = Path.Combine(Installation.ConfigDir.FullName, "thanf", "trading_range.json");
                if (File.Exists(file)) {
                    var list = JToken.Parse(File.ReadAllText(file));
                    var current = list.First;
                    while (current != null) {
                        var manager = new TimeRangeManager();
                        var ranges = current["TimeRanges"].ToObject<TimeRange[]>();
                        foreach (var range in ranges) {
                            manager.AddRange(range);
                        }
                        var products = current["Products"].ToObject<string>();
                        var keys = products.Split(',');
                        foreach (var key in keys) {
                            _items[key] = manager;
                        }
                        current = current.Next;
                    }
                }
            }
            catch (Exception) {
                // ignored
            }
        }

        public TimeRangeManager GetFilter(Instrument inst)
        {
            if (inst.Type == InstrumentType.Stock) {
                if (_items.TryGetValue(Stock, out var manager)) {
                    return manager;
                }
            }
            if (inst.Type == InstrumentType.Future) {
                var match = Regex.Match(inst.Symbol, @"([a-zA-Z]+)\d+");
                if (match.Success) {
                    if (_items.TryGetValue(match.Groups[1].Value, out var manager)) {
                        return manager;
                    }
                    if (_items.TryGetValue(Futures, out manager)) {
                        return manager;
                    }
                }
            }
            return _default;
        }
    }
}