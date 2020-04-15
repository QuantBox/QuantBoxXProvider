using System;
using NLog;
using QuantBox.XApi;

namespace QuantBox
{
    public abstract class XApiClient
    {
        protected readonly ConnectionInfo Info;
        protected readonly XTradingApi Api;
        protected readonly UserInfoField User;
        protected readonly ServerInfoField Server;
        protected readonly Logger Logger;

        private void OnInvestorReceived(object sender, InvestorField investor, bool isLast)
        {
            Logger.Info(investor.Name() + " " + investor.IdentifiedCardNo);
        }

        protected virtual void OnMarketDataReceived(object sender, DepthMarketDataField field)
        {
            Provider.OnMessage(field);
        }

        protected virtual void OnRspQryPositions(object sender, PositionField position, bool isLast)
        {
            Provider.OnMessage(position);
        }

        protected virtual void OnRspQryAccount(object sender, AccountField account, bool isLast)
        {
            Provider.OnMessage(account);
        }

        protected virtual void OnInstrumentReceived(object sender, InstrumentField instrument, bool isLast)
        {
            Provider.OnMessage(instrument, isLast);
        }

        protected virtual void OnStatusChanged(object sender, ConnectionStatus status, RspUserLoginField field)
        {
            Logger.Info(status);
            if (field != null && status == ConnectionStatus.Logined) {
                Logger.Info(field.RawErrorID != 0 ? field.RawErrorMsg() : field.DebugInfo());
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
            Info = info;
            Provider = provider;
            User = provider.GetUserInfo(info.User);
            Server = provider.GetServerInfo(info.Server, info.UseType);
            Logger = LogManager.GetLogger($"{provider.Name}.{info.LogPrefix}.{User.UserID}");
            Api = provider.CreateXApi(info);
            if (spi != null) {
                Api.RegisterSpi(spi);
            }

            Api.LogHappened += OnLogHappened; 
            Api.ErrorHappened += OnErrorHappened;
            Api.StatusChanged += OnStatusChanged;
            Api.InvestorReceived += OnInvestorReceived;
            Api.AccountReceived += OnRspQryAccount;
            Api.PositionReceived += OnRspQryPositions;
            Api.OrderReturn += OnRtnOrder;
            Api.TradeReturn += OnRtnTrade;
            Api.InstrumentReceived += OnInstrumentReceived;
            Api.MarketDataReceived += OnMarketDataReceived;
            Api.OrderReceived += OnOrderReceived;
            Api.TradeReceived += OnTradeReceived;
            Api.InstrumentStatusChanged += OnInstrumentStatusChanged;
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
            Api.Connect(Server, User);
        }

        public void Disconnect()
        {
            Api.Disconnect();
        }

        public void QueryInstrument()
        {
            if (Connected) {
                Api.Query(QueryType.ReqQryInstrument, null);
            }
        }

        public bool Connected => Api.Connected;

        public DateTime TradingDay { get; internal set; }
        public int OrderIdBase { get; private set; }
        public XProvider Provider { get; }
    }
}