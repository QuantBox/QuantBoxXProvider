using System;
using Skyline;

namespace QuantBox.Data.Compression
{
    internal class DataEntry
    {
        public readonly TradingTimeRange TimeRanges;
        public readonly DateTime DateTime;
        public readonly PriceSizeItem[] Items;

        public DataEntry(DateTime datetime, TradingTimeRange timeRanges, PriceSizeItem[] items)
        {
            DateTime = datetime;
            TimeRanges = timeRanges;
            Items = items;
        }
    }
}
