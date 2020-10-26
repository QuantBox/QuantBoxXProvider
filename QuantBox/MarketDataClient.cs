using QuantBox.XApi;
using SmartQuant;

namespace QuantBox
{
    internal class MarketDataClient : XApiClient
    {
        public MarketDataClient(XProvider provider, ConnectionInfo info)
            : base(provider, info)
        {
        }

        public void Subscribe(Instrument inst)
        {
            var altId = Provider.GetAltId();
            api.Subscribe(inst.GetSymbol(altId), inst.GetExchange(altId), (XApi.InstrumentType)inst.Type);
        }

        public void Unsubscribe(Instrument inst)
        {
            var (symbol, exchange) = Provider.GetSymbolInfo(inst);
            api.Unsubscribe(symbol, exchange, (XApi.InstrumentType)inst.Type);
        }

        public static ApiType ApiType => ApiType.MarketData;
    }
}
