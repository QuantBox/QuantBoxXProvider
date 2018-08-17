using System;
using System.IO;

namespace QuantBox.XApi
{
    public class CtpQuote : IXApi
    {
        private CtpMdClient _client;

        static CtpQuote()
        {
            AssemblyResolver.AddPath(Path.GetDirectoryName(typeof(CtpQuote).Assembly.Location));
        }

        public void RegisterSpi(IXSpi spi)
        {
            if (_client != null) {
                return;
            }
            _client = new CtpMdClient(spi);
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
            throw new NotImplementedException();
        }

        public void Subscribe(string instrument, string exchange, InstrumentType type)
        {
            _client?.Subscribe(instrument);
        }

        public void Unsubscribe(string instrument, string exchange, InstrumentType type)
        {
            _client?.Unsubscribe(instrument);
        }

        public string SendOrder(params OrderField[] orders)
        {
            throw new NotImplementedException();
        }

        public string CancelOrder(params string[] list)
        {
            throw new NotImplementedException();
        }

        public string ApiVersion => GetType().Assembly.GetName().Version.ToString();
        public ApiType ApiTypes => ApiType.MarketData;
#if CTP
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
