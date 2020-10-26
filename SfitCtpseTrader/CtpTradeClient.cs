using System.IO;
using System;
using System.Threading;
using System.Threading.Tasks;
#if CTP || CTPSE
using QuantBox.Sfit.Api;
#elif CTPMINI
using QuantBox.SfitMini.Api;
#else
using QuantBox.Rohon.Api;
#endif

namespace QuantBox.XApi
{
    public class CtpTradeClient
    {
        private const string ThanfAuthCode = "QL9TP36WN1FJGZ4T";
        private const string OpenQuantAppId = "tfqh_openquant_v1.0";

        private static readonly Random Rand = new Random((int)DateTime.Now.Ticks);
        private int _requestId;
        private int _orderRef;

        private CtpQueryManager _queryManager;
        private CtpDealProcessor _processor;
        private StatusPublisher _publisher;

        internal IXSpi spi;
        internal CtpTraderApi api;
        internal CtpRspUserLogin ctpLoginInfo;

        internal int GetNextRequestId()
        {
            return Interlocked.Increment(ref _requestId);
        }

        private int GetNextOrderRef()
        {
            return Interlocked.Increment(ref _orderRef);
        }

        private static string GetFlowPath(ServerInfoField server, UserInfoField user)
        {
            var path = Path.Combine(Path.GetTempPath(), "XAPI", "T", $"{server.BrokerID}_{user.UserID}_{Rand.Next()}");
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            return path + Path.DirectorySeparatorChar;
        }
        private void SendError(ErrorField error)
        {
            Task.Run(() => spi.ProcessError(error));
        }

        internal void SendError(CtpRspInfo info, string source)
        {
            SendError(new ErrorField(info.ErrorID, info.ErrorID, info.ErrorMsg, source));
        }
        internal void SendError(int reason, string source)
        {
            SendError(new ErrorField(reason, reason, CtpConvert.GetReasonMsg(reason), source));
        }
        private void SendError(string msg)
        {
            SendError(new ErrorField(-1, -1, msg, nameof(CtpTradeClient)));
        }

        private void InitHandler()
        {
            // Order
            api.RspHandlerList[CtpResponseType.OnRtnOrder] = ProcessDeal;
            api.RspHandlerList[CtpResponseType.OnRtnTrade] = ProcessDeal;
            api.RspHandlerList[CtpResponseType.OnErrRtnOrderAction] = ProcessDeal;
            api.RspHandlerList[CtpResponseType.OnErrRtnOrderInsert] = ProcessDeal;
            api.RspHandlerList[CtpResponseType.OnRspOrderAction] = ProcessDeal;
            api.RspHandlerList[CtpResponseType.OnRspOrderInsert] = ProcessDeal;
            // Query
            api.RspHandlerList[CtpResponseType.OnRspQryOrder] = ProcessQuery;
            api.RspHandlerList[CtpResponseType.OnRspQryTrade] = ProcessQuery;
            api.RspHandlerList[CtpResponseType.OnRspQryInstrument] = ProcessQuery;
            api.RspHandlerList[CtpResponseType.OnRspQryTradingAccount] = ProcessQuery;
            api.RspHandlerList[CtpResponseType.OnRspQryInvestorPosition] = ProcessQuery;
            api.RspHandlerList[CtpResponseType.OnRtnInstrumentStatus] = OnRtnInstrumentStatus;
            api.RspHandlerList[CtpResponseType.OnRspQryDepthMarketData] = OnRspQryDepthMarketData;
            // Connection
            api.RspHandlerList[CtpResponseType.OnFrontConnected] = OnFrontConnected;
            api.RspHandlerList[CtpResponseType.OnFrontDisconnected] = OnFrontDisconnected;
            api.RspHandlerList[CtpResponseType.OnRspUserLogin] = OnRspUserLogin;
            api.RspHandlerList[CtpResponseType.OnRspAuthenticate] = OnRspAuthenticate;
            api.RspHandlerList[CtpResponseType.OnRspSettlementInfoConfirm] = OnRspSettlementInfoConfirm;
            api.RspHandlerList[CtpResponseType.OnRspError] = OnRspError;
        }


        #region Connect Response Handler

        private void DoSettlementInfoConfirm()
        {
            var confirm = new CtpSettlementInfoConfirm();
            confirm.BrokerID = Server.BrokerID;
            confirm.InvestorID = User.UserID;
            confirm.ConfirmDate = DateTime.Now.ToString("yyyyMMdd");
            confirm.ConfirmTime = DateTime.Now.ToString("hhmmss");
            _publisher.Post(ConnectionStatus.Confirming);
            api.ReqSettlementInfoConfirm(confirm, GetNextRequestId());
        }

        private void DoLogin()
        {
            var info = new CtpReqUserLogin();
            info.BrokerID = Server.BrokerID;
            info.UserProductInfo = Server.UserProductInfo;
            info.UserID = User.UserID;
            info.Password = User.Password;
            if (!Connected) {
                _publisher.Post(ConnectionStatus.Logining);
            }
            else {
                spi.ProcessLog(new LogField(LogLevel.Debug, $"Ctpse trader({User.UserID}) login"));
            }

            api.ReqUserLogin(info, GetNextRequestId());
        }

        private void DoAuthenticate()
        {
            var info = new CtpReqAuthenticate();
            info.BrokerID = Server.BrokerID;
            info.UserID = User.UserID;
            info.UserProductInfo = Server.UserProductInfo;
            info.AuthCode = Server.AuthCode;
#if CTPSE || CTPMINI
            info.AppID = Server.ExtInfoChar128;
#endif
            if (!Connected) {
                _publisher.Post(ConnectionStatus.Authorizing);
            }
            else {
                spi.ProcessLog(new LogField(LogLevel.Debug, $"Ctpse trader({User.UserID}) authorizing"));
            }

            api.ReqAuthenticate(info, GetNextRequestId());
        }

        private void OnRspError(ref CtpResponse rsp)
        {
            _queryManager.Post(QueryType.ReqError, rsp);
            SendError(rsp.Item1.AsRspInfo, nameof(OnRspError));
        }

        private void OnRspUserLogin(ref CtpResponse rsp)
        {
            ctpLoginInfo = rsp.Item1.AsRspUserLogin;
            if (ctpLoginInfo != null && CtpConvert.CheckRspInfo(rsp.Item2)) {
                if (!Connected) {
                    UserLogin = new RspUserLoginField();
                    UserLogin.TradingDay = CtpConvert.GetDate(ctpLoginInfo.TradingDay);
                    UserLogin.LoginTime = CtpConvert.GetTime(ctpLoginInfo.LoginTime);
                    UserLogin.UserID = ctpLoginInfo.UserID;
                    UserLogin.SessionID = $"{ctpLoginInfo.FrontID}:{ctpLoginInfo.SessionID}";
                    UserLogin.Text = string.IsNullOrEmpty(ctpLoginInfo.MaxOrderRef) ? "1" : ctpLoginInfo.MaxOrderRef;
                    _orderRef = int.Parse(UserLogin.Text);
                    _publisher.Post(ConnectionStatus.Logined, UserLogin);
#if CTPMINI
                    Connected = true;
                    _publisher.Post(ConnectionStatus.Confirmed);
                    _publisher.Post(ConnectionStatus.Done, UserLogin);
#else
                    DoSettlementInfoConfirm();
#endif
                }
                else {
                    spi.ProcessLog(new LogField(LogLevel.Debug, $"Ctpse trader({User.UserID}) login success"));
                }
            }
            else {
                SendError(rsp.Item2, nameof(OnRspUserLogin));
                _publisher.Post(ConnectionStatus.Disconnected);
            }
        }

        private void OnFrontConnected(ref CtpResponse rsp)
        {
            spi.ProcessLog(new LogField(LogLevel.Debug, $"Ctpse trader({User.UserID}) connected"));

            if (!Connected) {
                _publisher.Post(ConnectionStatus.Connected);
            }
#if CTPSE || CTPMINI
            DoAuthenticate();
#else
            DoLogin();
#endif
        }

        private void OnFrontDisconnected(ref CtpResponse rsp)
        {
            if (rsp.Item1.AsInt == null) {
                return;
            }

            var reason = rsp.Item1.AsInt.Value;
            SendError(reason, $"{User.UserID}");
        }

        private void OnRspAuthenticate(ref CtpResponse rsp)
        {
            var data = rsp.Item1.AsRspAuthenticate;
            if (data != null && CtpConvert.CheckRspInfo(rsp.Item2)) {
                if (!Connected) {
                    _publisher.Post(ConnectionStatus.Authorized);
                }
                else {
                    spi.ProcessLog(new LogField(LogLevel.Debug, $"Ctp trader({User.UserID}) authorized"));
                }

                DoLogin();
            }
            else {
                SendError(rsp.Item2, nameof(OnRspAuthenticate));
                _publisher.Post(ConnectionStatus.Disconnected);
            }
        }

        private void OnRspSettlementInfoConfirm(ref CtpResponse rsp)
        {
            var data = rsp.Item1.AsSettlementInfoConfirm;
            if (data != null && CtpConvert.CheckRspInfo(rsp.Item2)) {
                Connected = true;
                _publisher.Post(ConnectionStatus.Confirmed);
                _publisher.Post(ConnectionStatus.Done, UserLogin);
            }
            else {
                SendError(rsp.Item2, nameof(OnRspSettlementInfoConfirm));
                _publisher.Post(ConnectionStatus.Disconnected);
            }
        }
        #endregion

        #region Query Response Handler

        private void ProcessQuery(ref CtpResponse rsp)
        {
            switch (rsp.TypeId) {
                case CtpResponseType.OnRspQryOrder:
                    _queryManager?.Post(QueryType.ReqQryOrder, rsp);
                    break;
                case CtpResponseType.OnRspQryTrade:
                    _queryManager?.Post(QueryType.ReqQryTrade, rsp);
                    break;
                case CtpResponseType.OnRspQryTradingAccount:
                    _queryManager?.Post(QueryType.ReqQryTradingAccount, rsp);
                    break;
                case CtpResponseType.OnRspQryInvestorPosition:
                    _queryManager?.Post(QueryType.ReqQryInvestorPosition, rsp);
                    break;
                case CtpResponseType.OnRspQryInstrument:
                    _queryManager?.Post(QueryType.ReqQryInstrument, rsp);
                    break;
            }
        }

        private void OnRtnInstrumentStatus(ref CtpResponse rsp)
        {
            var status = rsp.Item1.AsInstrumentStatus;
            var field = CtpConvert.GetInstrumentStatus(status);
            spi.ProcessRtnInstrumentStatus(field);
        }

        private void OnRspQryDepthMarketData(ref CtpResponse rsp)
        {

        }

        #endregion

        #region Order Response Handler

        private void ProcessDeal(ref CtpResponse rsp)
        {
            _processor.Post(rsp);
        }

        #endregion

        public CtpTradeClient(IXSpi spi)
        {
            this.spi = spi;
            _publisher = new StatusPublisher(spi);
        }

        public void RegisterSpi(IXSpi spi)
        {
            this.spi = spi;
            _publisher = new StatusPublisher(spi);
        }

        public bool Connected { get; private set; }
        public ServerInfoField Server { get; private set; }
        public UserInfoField User { get; private set; }
        public RspUserLoginField UserLogin { get; private set; }

        private bool CheckSettings(ServerInfoField server, UserInfoField user)
        {
            if (string.IsNullOrEmpty(server.Address)) {
                SendError("没有设置 Address");
                _publisher.Post(ConnectionStatus.Disconnected);
                return false;
            }
            if (string.IsNullOrEmpty(server.BrokerID)) {
                SendError("没有设置 BrokerID");
                _publisher.Post(ConnectionStatus.Disconnected);
                return false;
            }
            if (string.IsNullOrEmpty(user.UserID) || string.IsNullOrEmpty(user.Password)) {
                SendError("没有设置用户名和密码");
                _publisher.Post(ConnectionStatus.Disconnected);
                return false;
            }
            #region 设置天风认证码
            //连接实盘系统
            if (string.IsNullOrEmpty(server.ExtInfoChar128)) {
                server.AuthCode = ThanfAuthCode;
                server.ExtInfoChar128 = OpenQuantAppId;
            }
            #endregion
            return true;
        }

        public void Init(ServerInfoField server, UserInfoField user)
        {
            if (api != null) {
                return;
            }
            if (!CheckSettings(server, user)) {
                return;
            }
            _queryManager = new CtpQueryManager(this);
            _processor = new CtpDealProcessor(this);
            User = user;
            Server = server;
            api = new CtpTraderApi(GetFlowPath(server, user));
            InitHandler();
            var items = server.Address.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in items) {
                api.RegisterFront(item);
            }
            api.SubscribePrivateTopic(CtpConvert.GetCtpResumeType(server.PrivateTopicResumeType));
            api.SubscribePublicTopic(CtpConvert.GetCtpResumeType(server.PublicTopicResumeType));
            _publisher.Post(ConnectionStatus.Connecting);
            api.Init();
        }

        public void Release()
        {
            if (api != null) {
                _publisher.Post(ConnectionStatus.Releasing);
                _queryManager.Close();
                _queryManager = null;
                Connected = false;
                api.Release();
                api = null;
                _processor.Close();
                _processor = null;
                _publisher.Post(ConnectionStatus.Disconnected);
            }
        }

        public void Query(QueryType type, ReqQueryField field)
        {
            if (Connected) {
                _queryManager.Post(type, field);
            }
        }

        public string SendOrder(OrderField order)
        {
            if (!Connected) {
                return string.Empty;
            }

            if (string.IsNullOrEmpty(order.LocalID)) {
                order.LocalID = GetNextOrderRef().ToString();
            }
            _processor.Post(order);
            return order.ID;
        }

        public void CancelOrder(string id)
        {
            if (Connected) {
                _processor.Post(id);
            }
        }
    }
}