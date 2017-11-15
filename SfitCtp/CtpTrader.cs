using System;
using System.IO;
using System.Reflection;
using System.Text;
using Skyline;

namespace QuantBox.XApi
{
    public class CtpTrader : IXApi
    {
        private CtpTradeClient _client;

        static CtpTrader()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomainOnAssemblyResolve;
        }

        private static Assembly CurrentDomainOnAssemblyResolve(object sender, ResolveEventArgs args)
        {
            var assemblyName = new AssemblyName(args.Name);
            var path = Utility.GetCurrentPath(typeof(CtpTrader));
            path = Path.Combine(path, assemblyName.Name + ".dll");
            return File.Exists(path) ? Assembly.LoadFile(path) : null;
        }

        public void RegisterSpi(IXSpi spi)
        {
            if (_client != null) {
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
            _client?.Query(type);
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

        public string ApiVersion => GetType().Assembly.GetName().Version.ToString();
        public ApiType ApiTypes => ApiType.Trade | ApiType.Instrument | ApiType.Query;
        public string ApiName => "CTP";
        public bool Connected => _client?.Connected ?? false;
        public ServerInfoField Server => _client?.Server;
        public UserInfoField User => _client?.User;
        public RspUserLoginField UserLogin => _client?.UserLogin;
    }
}
