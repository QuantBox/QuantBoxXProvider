using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace QuantBox.XApi
{
    public class CtpTrader : IXApi
    {
        private CtpTradeClient _client;

        static CtpTrader()
        {
            AssemblyResolver.AddPath(Path.GetDirectoryName(typeof(CtpTrader).Assembly.Location));
        }

        public void RegisterSpi(IXSpi spi)
        {
            if (_client != null) {
                _client.RegisterSpi(spi);
                return;
            }
            _client = new CtpTradeClient(spi);
        }

        public void Release()
        {
            Disconnect();
            _client = null;
        }

        public void Connect(ServerInfoField server, UserInfoField user)
        {
            _client?.Init(server, user);
        }

        public void Disconnect()
        {
            _client?.Release();
        }

        public void Query(QueryType type, ReqQueryField query)
        {
            _client?.Query(type, query);
        }

        public void Subscribe(string instrument, string exchange, InstrumentType type)
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe(string instrument, string exchange, InstrumentType type)
        {
            throw new NotImplementedException();
        }

        public string SendOrder(params OrderField[] orders)
        {
            if (!Connected) {
                return string.Empty;
            }
            if (orders.Length == 1) {
                return _client.SendOrder(orders[0]);
            }
            var result = new StringBuilder();
            foreach (var order in orders) {
                if (result.Length > 0) {
                    result.Append(",");
                }
                result.Append(_client.SendOrder(order));
            }
            return result.ToString();
        }

        public string CancelOrder(params string[] list)
        {
            if (!Connected) {
                return string.Empty;
            }
            foreach (var id in list) {
                _client.CancelOrder(id);
            }
            return string.Empty;
        }

        public string ApiVersion => XApiHelper.GetVersionString(typeof(CtpTrader));
        public ApiType ApiTypes => ApiType.Trade | ApiType.Instrument | ApiType.Query;
#if CTP || CTPSE
        public string ApiName => "CTP";
#else
        public string ApiName => "Rohon";
#endif
        public bool Connected => _client?.Connected ?? false;
        public ServerInfoField Server => _client?.Server;
        public UserInfoField User => _client?.User;
        public RspUserLoginField UserLogin => _client?.UserLogin;
    }
}
