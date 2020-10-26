using System;
using NLog;
using QuantBox.XApi;

namespace QuantBox
{
    public abstract class XApiClient
    {
        protected readonly ConnectionInfo info;
        protected readonly XTradingApi api;
        protected readonly UserInfoField user;
        protected readonly ServerInfoField server;
        protected readonly Logger logger;

        private void OnInvestorReceived(object sender, InvestorField investor, bool isLast)
        {
            logger.Info(investor.Name() + " " + investor.IdentifiedCardNo);
        }

        protected virtual void OnMarketDataReceived(object sender, DepthMarketDataField field)
        {
            Provider.OnMessage(field);
        }

        protected virtual void OnRspQryPositions(object sender, PositionField position, bool isLast)
        {
            Provider.OnMessage(position, isLast);
        }

        protected virtual void OnRspQryAccount(object sender, AccountField account, bool isLast)
        {
            Provider.OnMessage(account, isLast);
        }

        protected virtual void OnInstrumentReceived(object sender, InstrumentField instrument, bool isLast)
        {
            Provider.OnMessage(instrument, isLast);
        }

        protected virtual void OnStatusChanged(object sender, ConnectionStatus status, RspUserLoginField field)
        {
            logger.Info(status);
            if (field != null && status == ConnectionStatus.Logined) {
                logger.Info(field.RawErrorID != 0 ? field.RawErrorMsg() : field.DebugInfo());
            }

            switch (status) {
                case ConnectionStatus.Done:
                    if (field != null) {
                        TradingDay = field.TradingDay();
                        OrderIdBase = int.Parse(field.Text);
                    }
                    OnConnected();
                    break;
                case ConnectionStatus.Disconnected:
                    OnDisconnected();
                    break;
            }
        }

        protected virtual void OnRtnTrade(object sender, TradeField trade)
        {
            Provider.OnMessage(trade);
        }

        protected virtual void OnRtnOrder(object sender, OrderField order)
        {
            Provider.OnMessage(order);
        }

        protected virtual void OnConnected()
        {
            Provider.OnClientConnected(this);
        }

        protected virtual void OnDisconnected()
        {
            Provider.OnClientDisconnected(this);
        }
        
        protected XApiClient(XProvider provider, ConnectionInfo info, IXSpi spi = null)
        {
            this.info = info;
            Provider = provider;
            user = provider.GetUserInfo(info.User);
            server = provider.GetServerInfo(info.Server, info.UseType);
            logger = LogManager.GetLogger($"{provider.Name}.{info.LogPrefix}.{user.UserID}");
            api = provider.CreateXApi(info);
            if (spi != null) {
                api.RegisterSpi(spi);
            }

            api.LogHappened += OnLogHappened; 
            api.ErrorHappened += OnErrorHappened;
            api.StatusChanged += OnStatusChanged;
            api.InvestorReceived += OnInvestorReceived;
            api.AccountReceived += OnRspQryAccount;
            api.PositionReceived += OnRspQryPositions;
            api.OrderReturn += OnRtnOrder;
            api.TradeReturn += OnRtnTrade;
            api.InstrumentReceived += OnInstrumentReceived;
            api.MarketDataReceived += OnMarketDataReceived;
            api.OrderReceived += OnOrderReceived;
            api.TradeReceived += OnTradeReceived;
            api.InstrumentStatusChanged += OnInstrumentStatusChanged;
        }

        private void OnInstrumentStatusChanged(object sender, InstrumentStatusField status)
        {
            Provider.OnMessage(status);
        }

        private void OnTradeReceived(object sender, TradeField trade, bool isLast)
        {
            Provider.OnMessage(trade);
        }

        private void OnOrderReceived(object sender, OrderField order, bool isLast)
        {
            Provider.OnMessage(order);
        }

        private void OnErrorHappened(object sender, ErrorField error)
        {
            Provider.OnProviderError(error);
        }

        private void OnLogHappened(object sender, LogField log)
        {
            Provider.OnProviderLog(log);
        }

        public void Connect()
        {
            api.Connect(server, user);
        }

        public void Disconnect()
        {
            api.Disconnect();
        }

        public void QueryInstrument()
        {
            if (Connected) {
                api.Query(QueryType.ReqQryInstrument, null);
            }
        }

        public bool Connected => api.Connected;

        public DateTime TradingDay { get; internal set; }
        public int OrderIdBase { get; private set; }
        public XProvider Provider { get; }
    }
}