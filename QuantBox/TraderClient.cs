using QuantBox.XApi;
using SmartQuant;

namespace QuantBox
{
    public class TraderClient : XApiClient
    {
        public static ApiType ApiType => ApiType.Trade;

        public TraderClient(XProvider provider, ConnectionInfo info, IXSpi spi = null)
            : base(provider, info, spi)
        {
        }

        public string CancelOrder(string orderId)
        {
            return Api.CancelOrder(orderId);
        }

        public string SendOrder(OrderField order)
        {
            return Api.SendOrder(order);
        }

        public void QueryAccount()
        {
            if (Connected) {
                Api.Query(QueryType.ReqQryTradingAccount, null);
            }
        }

        public void QueryPositions()
        {
            if (Connected) {
                Api.Query(QueryType.ReqQryInvestorPosition, null);
            }
        }

        public void QueryOrders()
        {
            if (Connected) {
                Api.Query(QueryType.ReqQryOrder, null);
            }
        }

        public void QueryTrades()
        {
            if (Connected) {
                Api.Query(QueryType.ReqQryTrade, null);
            }
        }

        public void QueryQuote(Instrument inst)
        {
            if (Connected) {
                var (symbol, exchange) = Provider.GetSymbolInfo(inst);
                Api.Query(QueryType.ReqQryQuote, new ReqQueryField {
                    ExchangeID = exchange,
                    InstrumentID = symbol,
                    Symbol = symbol
                });
            }
        }
    }
}
