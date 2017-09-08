using System;

namespace QuantBox.XApi
{
    [Flags]
    public enum ApiType : byte
    {
        None = 0,
        Trade = 1,
        MarketData = 2,
        Level2 = 4,
        QuoteRequest = 8,
        HistoricalData = 16,
        Instrument = 32,
        Query = 64,
    };
}