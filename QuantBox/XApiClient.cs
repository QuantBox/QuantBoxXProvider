using System;
using NLog;
using QuantBox.XApi;

namespace QuantBox
{
    internal abstract class XApiClient
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
            Provider.OnMessage(position, isLast);
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
                    TradingDay = field.TradingDay();
                    OnConnected();
                    break;
                case ConnectionStatus.Disconnected:
                    OnDisconnected();
                    break;
            }
        }

        protected virtual void OnRtnTrade(object sender, TradeField trade)
        {
        }

        protected virtual void OnRtnOrder(object sender, OrderField order)
        {
        }

        protected virtual void OnConnected()
        {
            Provider.OnClientConnected(this);
        }

        protected virtual void OnDisconnected()
        {
            Provider.OnClientDisconnected();
        }

        protected XApiClient(XProvider provider, ConnectionInfo info)
        {
            Info = info;
            Provider = provider;
            User = provider.GetUserInfo(info.User);
            Server = provider.GetServerInfo(info.Server, info.UseType);
            Logger = LogManager.GetLogger($"{provider.Name}.{info.LogPrefix}.{User.UserID}");
            Api = provider.CreateXApi(provider.GetApiPath(Info.ApiPath));
            Api.ErrorHappened += OnErrorHappened;
            Api.StatusChanged += OnStatusChanged;
            Api.InvestorReceived += OnInvestorReceived;
            Api.AccountReceived += OnRspQryAccount;
            Api.PositionReceived += OnRspQryPositions;
            Api.OrderReturn += OnRtnOrder;
            Api.TradeReturn += OnRtnTrade;
            Api.InstrumentReceived += OnInstrumentReceived;
            Api.MarketDataReceived += OnMarketDataReceived;
        }

        private void OnErrorHappened(object sender, ErrorField error)
        {
            Provider.OnProviderError(error);
        }

        public void Connect()
        {
            Api.Connect(Server, User);
        }

        public void Disconnect()
        {
            Api.Disconnect();
        }

        public bool Connected => Api.Connected;

        public DateTime TradingDay { get; set; }

        public XProvider Provider { get; }
    }
}