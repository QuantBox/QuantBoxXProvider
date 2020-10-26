using System;

namespace QuantBox.XApi
{
    public delegate void XApiEventHandler2<in T1, in T2>(object sender, T1 t1, T2 t2);
    public delegate void XApiEventHandler3<in T>(object sender, T t, bool isLast);

    public enum XApiFileType
    {
        Native,
        Managed
    }

    public sealed class XTradingApi : XSpi, IDisposable
    {
        private IXApi _api;

        public XTradingApi(string path)
        {
            object instance;
            if (XApiHelper.IsManagedAssembly(path)) {
                FileType = XApiFileType.Managed;
                instance = ManagedManager.GetInstance(path);
            }
            else {
                FileType = XApiFileType.Native;
                instance = new Native.XApi(path);
            }
            _api = (IXApi)instance;
            _api.RegisterSpi(this);
        }

        public XTradingApi(IXApi api, XApiFileType type = XApiFileType.Managed)
        {
            FileType = type;
            _api = api;
            _api.RegisterSpi(this);
        }

        public void RegisterSpi(IXSpi spi)
        {
            _api?.RegisterSpi(spi);
        }

        public void Dispose()
        {
            _api?.Release();
            _api = null;
        }

        #region Connection & Query
        public void Connect(ServerInfoField server, UserInfoField user)
        {
            _api.Connect(server, user);
        }
        public void Disconnect()
        {
            _api.Disconnect();
        }
        public void Query(QueryType type, ReqQueryField query)
        {
            _api.Query(type, query);
        }
        public string ApiVersion => _api.ApiVersion;
        public ApiType ApiTypes => _api.ApiTypes;
        public string ApiName => _api.ApiName;
        #endregion

        #region Subscribe
        public void Subscribe(string instrument, string exchange, InstrumentType type)
        {
            _api.Subscribe(instrument, exchange, type);
        }
        public void Unsubscribe(string instrument, string exchange, InstrumentType type)
        {
            _api.Unsubscribe(instrument, exchange, type);
        }
        #endregion

        #region Trading
        public string SendOrder(params OrderField[] orders)
        {
            return _api.SendOrder(orders);
        }
        public string CancelOrder(params string[] list)
        {
            return _api.CancelOrder(list);
        }
        #endregion

        public bool Connected => _api.Connected;
        public ServerInfoField Server => _api.Server;
        public UserInfoField User => _api.User;
        public RspUserLoginField UserLogin => _api.UserLogin;
        public XApiFileType FileType { get; }
    }
}