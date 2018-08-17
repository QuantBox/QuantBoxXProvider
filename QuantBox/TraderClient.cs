using QuantBox.XApi;
using SmartQuant;

namespace QuantBox
{
    internal class TraderClient : XApiClient
    {
        protected override void OnRtnTrade(object sender, TradeField trade)
        {
            Provider.OnMessage(trade);
        }

        protected override void OnRtnOrder(object sender, OrderField order)
        {
            Provider.OnMessage(order);
        }

        public static ApiType ApiType => ApiType.Trade;

        public TraderClient(XProvider provider, ConnectionInfo info)
            : base(provider, info)
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

        public void QueryInstrument()
        {
            if (Connected) {
                Api.Query(QueryType.ReqQryInstrument, null);
            }
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
