using System;
using System.IO;
using System.Reflection;

namespace QuantBox.XApi
{
    public class CtpQuote : IXApi
    {
        private CtpMdClient _client;

        static CtpQuote()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomainOnAssemblyResolve;
        }

        private static Assembly CurrentDomainOnAssemblyResolve(object sender, ResolveEventArgs args)
        {
            var assemblyName = new AssemblyName(args.Name);
            var path = Path.GetDirectoryName(typeof(CtpQuote).Assembly.Location);
            path = Path.Combine(path, assemblyName.Name + ".dll");
            return File.Exists(path) ? Assembly.LoadFile(path) : null;
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
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        public string CancelOrder(params string[] list)
        {
            throw new System.NotImplementedException();
        }

        public string ApiVersion => GetType().Assembly.GetName().Version.ToString();
        public ApiType ApiTypes => ApiType.MarketData;
        public string ApiName => "CTP";
        public bool Connected => _client?.Connected ?? false;
        public ServerInfoField Server => _client?.Server;
        public UserInfoField User => _client?.User;
        public RspUserLoginField UserLogin => _client?.UserLogin;
    }
}
