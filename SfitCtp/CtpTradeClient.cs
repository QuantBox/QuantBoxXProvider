using System.IO;
using System;
using System.Threading;
using System.Threading.Tasks;
#if CTP
using QuantBox.Sfit.Api;
#else
using QuantBox.Rohon.Api;
#endif

namespace QuantBox.XApi
{
    public class CtpTradeClient
    {
        private const int NetworkReadError = 0x1001;

        private static readonly Random Rand = new Random((int)DateTime.Now.Ticks);
        private int _lastDisconnectReason;
        private int _requestId;
        private int _orderRefId;
        private CtpQueryManager _queryManager;
        private CtpDealProcessor _processor;
        private readonly StatusPublisher _publisher;

        internal readonly IXSpi Spi;
        internal CtpTraderApi Api;
        internal CtpRspUserLogin CtpLoginInfo;

        internal int GetNextRequestId()
        {
            return Interlocked.Increment(ref _requestId);
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
            Task.Run(() => Spi.ProcessError(error));
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
            Api.RspHandlerList[CtpResponseType.OnRtnOrder] = ProcessDeal;
            Api.RspHandlerList[CtpResponseType.OnRtnTrade] = ProcessDeal;
            Api.RspHandlerList[CtpResponseType.OnErrRtnOrderAction] = ProcessDeal;
            Api.RspHandlerList[CtpResponseType.OnErrRtnOrderInsert] = ProcessDeal;
            Api.RspHandlerList[CtpResponseType.OnRspOrderAction] = ProcessDeal;
            Api.RspHandlerList[CtpResponseType.OnRspOrderInsert] = ProcessDeal;
            // Query
            Api.RspHandlerList[CtpResponseType.OnRspQryOrder] = ProcessQuery;
            Api.RspHandlerList[CtpResponseType.OnRspQryTrade] = ProcessQuery;
            Api.RspHandlerList[CtpResponseType.OnRspQryInstrument] = ProcessQuery;
            Api.RspHandlerList[CtpResponseType.OnRspQryTradingAccount] = ProcessQuery;
            Api.RspHandlerList[CtpResponseType.OnRspQryInvestorPosition] = ProcessQuery;
            Api.RspHandlerList[CtpResponseType.OnRtnInstrumentStatus] = OnRtnInstrumentStatus;
            Api.RspHandlerList[CtpResponseType.OnRspQryDepthMarketData] = OnRspQryDepthMarketData;
            // Connection
            Api.RspHandlerList[CtpResponseType.OnFrontConnected] = OnFrontConnected;
            Api.RspHandlerList[CtpResponseType.OnFrontDisconnected] = OnFrontDisconnected;
            Api.RspHandlerList[CtpResponseType.OnRspUserLogin] = OnRspUserLogin;
            Api.RspHandlerList[CtpResponseType.OnRspAuthenticate] = OnRspAuthenticate;
            Api.RspHandlerList[CtpResponseType.OnRspSettlementInfoConfirm] = OnRspSettlementInfoConfirm;
            Api.RspHandlerList[CtpResponseType.OnRspError] = OnRspError;
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
            Api.ReqSettlementInfoConfirm(confirm, GetNextRequestId());
        }

        private void DoLogin()
        {
            var info = new CtpReqUserLogin();
            info.BrokerID = Server.BrokerID;
            info.UserProductInfo = Server.UserProductInfo;
            info.UserID = User.UserID;
            info.Password = User.Password;
            _publisher.Post(ConnectionStatus.Logining);
            Api.ReqUserLogin(info, GetNextRequestId());
        }

        private void DoAuthenticate()
        {
            var info = new CtpReqAuthenticate();
            info.AuthCode = Server.AuthCode;
            info.BrokerID = Server.BrokerID;
            info.UserProductInfo = Server.UserProductInfo;
            info.UserID = User.UserID;
            _publisher.Post(ConnectionStatus.Authorizing);
            Api.ReqAuthenticate(info, GetNextRequestId());
        }

        private void OnRspError(ref CtpResponse rsp)
        {
            SendError(rsp.Item1.AsRspInfo, nameof(OnRspError));
        }

        private void OnRspUserLogin(ref CtpResponse rsp)
        {
            CtpLoginInfo = rsp.Item1.AsRspUserLogin;
            if (CtpLoginInfo != null && CtpConvert.CheckRspInfo(rsp.Item2)) {
                UserLogin = new RspUserLoginField();
                UserLogin.TradingDay = CtpConvert.GetDate(CtpLoginInfo.TradingDay);
                UserLogin.LoginTime = CtpConvert.GetTime(CtpLoginInfo.LoginTime);
                UserLogin.UserID = CtpLoginInfo.UserID;
                UserLogin.SessionID = $"{CtpLoginInfo.FrontID}:{CtpLoginInfo.SessionID}";
                _publisher.Post(ConnectionStatus.Logined, UserLogin);
                if (string.IsNullOrEmpty(CtpLoginInfo.MaxOrderRef)) {
                    _orderRefId = 1;
                }
                else {
                    _orderRefId = int.Parse(CtpLoginInfo.MaxOrderRef) + 1;
                }
                DoSettlementInfoConfirm();
            }
            else {
                SendError(rsp.Item2, nameof(OnRspUserLogin));
                _publisher.Post(ConnectionStatus.Disconnected);
            }
        }

        private void OnFrontConnected(ref CtpResponse rsp)
        {
            if (_lastDisconnectReason != NetworkReadError) {
                _publisher.Post(ConnectionStatus.Connected);
            }
            if (!string.IsNullOrEmpty(Server.AuthCode) && !string.IsNullOrEmpty(Server.UserProductInfo)) {
                DoAuthenticate();
            }
            else {
                DoLogin();
            }
        }

        private void OnFrontDisconnected(ref CtpResponse rsp)
        {
            Connected = false;
            if (rsp.Item1.AsInt != null) {
                var reason = rsp.Item1.AsInt.Value;
                if (reason != _lastDisconnectReason) {
                    SendError(reason, nameof(OnFrontDisconnected));
                }
                _lastDisconnectReason = reason;
                if (_lastDisconnectReason == NetworkReadError) {
                    return;
                }
            }
            _publisher.Post(ConnectionStatus.Disconnected);
        }

        private void OnRspAuthenticate(ref CtpResponse rsp)
        {
            var data = rsp.Item1.AsRspAuthenticate;
            if (data != null && CtpConvert.CheckRspInfo(rsp.Item2)) {
                _publisher.Post(ConnectionStatus.Authorized);
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
                _lastDisconnectReason = 0;
                _publisher.Post(ConnectionStatus.Confirmed);
                _publisher.Post(ConnectionStatus.Done);
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
            Spi.ProcessRtnInstrumentStatus(field);
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
            Spi = spi;
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
            return true;
        }

        public void Init(ServerInfoField server, UserInfoField user)
        {
            if (Api != null) {
                return;
            }
            if (!CheckSettings(server, user)) {
                return;
            }
            _queryManager = new CtpQueryManager(this);
            _processor = new CtpDealProcessor(this);
            User = user;
            Server = server;
            Api = new CtpTraderApi(GetFlowPath(server, user));
            InitHandler();
            var items = server.Address.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in items) {
                Api.RegisterFront(item);
            }
            Api.SubscribePrivateTopic(CtpConvert.GetCtpResumeType(server.PrivateTopicResumeType));
            Api.SubscribePublicTopic(CtpConvert.GetCtpResumeType(server.PublicTopicResumeType));
            _publisher.Post(ConnectionStatus.Connecting);
            Api.Init();
        }

        public void Release()
        {
            if (Api != null) {
                Connected = false;
                Api.Release();
                _queryManager.Close();
                _queryManager = null;
                _processor.Close();
                _processor = null;
                Api = null;
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
            if (!Connected)
                return string.Empty;
            order.ReserveInt32 = ++_orderRefId;
            order.ID = $"{CtpLoginInfo.FrontID}:{CtpLoginInfo.SessionID}:{order.ReserveInt32}";
            order.LocalID = order.ID;
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