using System;
using System.Threading;

namespace QuantBox.XApi
{
    public delegate void XApiEventHandler2<in T1, in T2>(object sender, T1 t1, T2 t2);
    public delegate void XApiEventHandler3<in T>(object sender, T t, bool isLast);

    public enum XApiFileType
    {
        Unknown,
        Native,
        Managed
    }

    public class XTradingApi : IXSpi, IDisposable
    {
        private IXApi _api;
        private readonly object _instance;

        #region Response Handler
        void IXSpi.ProcessConnectionStatus(ConnectionStatus status, RspUserLoginField login)
        {
            StatusChanged?.Invoke(this, status, login);
        }

        void IXSpi.ProcessError(ErrorField error)
        {
            ErrorHappened?.Invoke(this, error);
        }

        void IXSpi.ProcessQryInstrument(InstrumentField inst, bool last)
        {
            InstrumentReceived?.Invoke(this, inst, last);
        }

        void IXSpi.ProcessQryPosition(PositionField position, bool last)
        {
            PositionReceived?.Invoke(this, position, last);
        }

        void IXSpi.ProcessQryInvestor(InvestorField investor, bool last)
        {
            InvestorReceived?.Invoke(this, investor, last);
        }

        void IXSpi.ProcessQryAccount(AccountField account, bool last)
        {
            AccountReceived?.Invoke(this, account, last);
        }

        void IXSpi.ProcessQrySettlementInfo(SettlementInfoField info, bool last)
        {
            SettlementInfoReceived?.Invoke(this, info, last);
        }

        void IXSpi.ProcessQryOrder(OrderField order, bool last)
        {
            OrderReceived?.Invoke(this, order, last);
        }

        void IXSpi.ProcessQryTrade(TradeField trade, bool last)
        {
            TradeReceived?.Invoke(this, trade, last);
        }

        void IXSpi.ProcessDepthMarketData(DepthMarketDataField data)
        {
            MarketDataReceived?.Invoke(this, data);
        }

        void IXSpi.ProcessRtnOrder(OrderField order)
        {
            OrderReturn?.Invoke(this, order);
        }

        void IXSpi.ProcessRtnTrade(TradeField trade)
        {
            TradeReturn?.Invoke(this, trade);
        }

        public void ProcessLog(LogField log)
        {
            LogHappened?.Invoke(this, log);
        }

        #endregion

        public XTradingApi(string path)
        {
            if (XApiHelper.IsManagedAssembly(path)) {
                FileType = XApiFileType.Managed;
                _instance = ManagedManager.GetInstance(path);
            }
            else {
                FileType = XApiFileType.Managed;
                _instance = new Nactive.XApi(path);
            }
            _api = (IXApi)_instance;
            _api.RegisterSpi(this);
        }

        public XTradingApi(IXApi api)
        {
            _api = api;
            _api.RegisterSpi(this);
        }

        ~XTradingApi()
        {
            Dispose();
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

        #region Response Events
        public event XApiEventHandler2<ConnectionStatus, RspUserLoginField> StatusChanged;
        public event EventHandler<ErrorField> ErrorHappened;
        public event EventHandler<LogField> LogHappened;
        public event XApiEventHandler3<InstrumentField> InstrumentReceived;
        public event XApiEventHandler3<PositionField> PositionReceived;
        public event XApiEventHandler3<InvestorField> InvestorReceived;
        public event XApiEventHandler3<AccountField> AccountReceived;
        public event XApiEventHandler3<SettlementInfoField> SettlementInfoReceived;
        public event XApiEventHandler3<OrderField> OrderReceived;
        public event XApiEventHandler3<TradeField> TradeReceived;
        public event EventHandler<DepthMarketDataField> MarketDataReceived;
        public event EventHandler<OrderField> OrderReturn;
        public event EventHandler<TradeField> TradeReturn;        
        #endregion
    }
}