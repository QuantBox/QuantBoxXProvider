using System.Runtime.InteropServices;

namespace QuantBox.XApi
{
    [ComVisible(false)]
    public enum OrderType : byte
    {
        Market,
        Stop,
        Limit,
        StopLimit,
        MarketOnClose,
        Pegged,
        TrailingStop,
        TrailingStopLimit,
    };
}