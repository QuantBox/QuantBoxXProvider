using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    public class CtpMdClient
    {
        private static readonly Random Rand = new Random((int)DateTime.Now.Ticks);
        private readonly IXSpi _spi;
        private CtpMdApi _api;
        private int _requestId;
        private readonly HashSet<string> _instruments = new HashSet<string>();
        private string[] _instrumentsView;
        private readonly StatusPublisher _publisher;

        private int GetNextRequestId()
        {
            return Interlocked.Increment(ref _requestId);
        }

        private static string GetFlowPath(ServerInfoField server, UserInfoField user)
        {
            var path = Path.Combine(Path.GetTempPath(), "XAPI", "M", $"{server.BrokerID}_{user.UserID}_{Rand.Next()}");
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            return path + Path.DirectorySeparatorChar;
        }

        private void SendError(ErrorField error)
        {
            Task.Run(() => _spi.ProcessError(error));
        }
        private void SendError(int reason, string source)
        {
            SendError(new ErrorField(reason, reason, CtpConvert.GetReasonMsg(reason), source));
        }
        private void SendError(CtpRspInfo info, string source)
        {
            SendError(new ErrorField(info.ErrorID, info.ErrorID, info.ErrorMsg, source));
        }

        private void InitHandler()
        {
            _api.OnFrontConnected += OnFrontConnected;
            _api.OnFrontDisconnected += OnFrontDisconnected;
            _api.OnRspError += OnRspError;
            _api.OnRspUserLogin += OnRspUserLogin;
            _api.OnRtnDepthMarketData += OnRtnDepthMarketData;
            _api.OnRspSubMarketData += OnRspSubMarketData;
        }

        private void OnRspSubMarketData(object sender, CtpSpecificInstrument response, CtpRspInfo info, int requestId, bool last)
        {
            if (response == null) {
                return;
            }
            _spi.ProcessLog(new LogField(LogLevel.Debug, $"Ctpse subscribe {response.InstrumentID}"));
        }

        private void OnRtnDepthMarketData(object sender, CtpDepthMarketData data)
        {
            //Thread.Sleep(5000);
            var market = new DepthMarketDataField();
            market.InstrumentID = data.InstrumentID;
            market.ExchangeID = data.ExchangeID;
            //market.Exchange = CtpConvert.GetExchangeType(data.ExchangeID);
            CtpConvert.SetExchangeTime(data, market);

            market.LastPrice = CtpConvert.IsInvalid(data.LastPrice) ? 0 : data.LastPrice;
            market.Volume = data.Volume;
            market.OpenInterest = data.OpenInterest;
            market.Turnover = data.Turnover;
            market.AveragePrice = data.AveragePrice;
            if (CtpConvert.IsInvalid(data.OpenPrice)) {
                market.OpenPrice = 0;
                market.HighestPrice = 0;
                market.LowestPrice = 0;
                //market.TradingPhase = TradingPhaseType.BeforeTrading;
            }
            else {
                market.OpenPrice = data.OpenPrice;
                market.HighestPrice = data.HighestPrice;
                market.LowestPrice = data.LowestPrice;
                //market.TradingPhase = TradingPhaseType.Continuous;
            }

            if (CtpConvert.IsInvalid(data.ClosePrice)) {
                market.ClosePrice = 0;
            }
            else {
                market.ClosePrice = data.ClosePrice;
                //market.TradingPhase = TradingPhaseType.Closed;
            }
            market.SettlementPrice = CtpConvert.IsInvalid(data.SettlementPrice) ? 0 : data.SettlementPrice;
            market.UpperLimitPrice = data.UpperLimitPrice;
            market.LowerLimitPrice = data.LowerLimitPrice;
            market.PreClosePrice = data.PreClosePrice;
            market.PreSettlementPrice = data.PreSettlementPrice;
            market.PreOpenInterest = data.PreOpenInterest;
            market.Asks = new DepthField[5];
            market.Bids = new DepthField[5];
            if (!CtpConvert.IsInvalid(data.AskPrice1)) {
                market.Asks[0].Price = data.AskPrice1;
                market.Asks[0].Size = data.AskVolume1;
                if (!CtpConvert.IsInvalid(data.AskPrice2)) {
                    market.Asks[1].Price = data.AskPrice2;
                    market.Asks[1].Size = data.AskVolume2;
                    if (!CtpConvert.IsInvalid(data.AskPrice3)) {
                        market.Asks[2].Price = data.AskPrice3;
                        market.Asks[2].Size = data.AskVolume3;
                        if (!CtpConvert.IsInvalid(data.AskPrice4)) {
                            market.Asks[3].Price = data.AskPrice4;
                            market.Asks[3].Size = data.AskVolume4;
                            if (!CtpConvert.IsInvalid(data.AskPrice5)) {
                                market.Asks[4].Price = data.AskPrice5;
                                market.Asks[4].Size = data.AskVolume5;
                            }
                        }
                    }
                }
            }

            if (!CtpConvert.IsInvalid(data.BidPrice1)) {
                market.Bids[0].Price = data.BidPrice1;
                market.Bids[0].Size = data.BidVolume1;
                if (!CtpConvert.IsInvalid(data.BidPrice2)) {
                    market.Bids[1].Price = data.BidPrice2;
                    market.Bids[1].Size = data.BidVolume2;
                    if (!CtpConvert.IsInvalid(data.BidPrice3)) {
                        market.Bids[2].Price = data.BidPrice3;
                        market.Bids[2].Size = data.BidVolume3;
                        if (!CtpConvert.IsInvalid(data.BidPrice4)) {
                            market.Bids[3].Price = data.BidPrice4;
                            market.Bids[3].Size = data.BidVolume4;
                            if (!CtpConvert.IsInvalid(data.BidPrice5)) {
                                market.Bids[4].Price = data.BidPrice5;
                                market.Bids[4].Size = data.BidVolume5;
                            }
                        }
                    }
                }
            }
            _spi.ProcessDepthMarketData(market);
        }

        private void OnRspError(object sender, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            SendError(rspInfo, nameof(OnRspError));
        }

        private void OnRspUserLogin(object sender, CtpRspUserLogin response, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            if (response != null && CtpConvert.CheckRspInfo(rspInfo)) {
                if (Connected) {
                    Resubscribe();
                    return;
                }
                Connected = true;
                UserLogin = new RspUserLoginField();
                var now = DateTime.Now;
                UserLogin.TradingDay = now.Year * 10000 + now.Month * 100 + now.Day;
                UserLogin.LoginTime = now.Hour * 10000 + now.Minute * 100 + now.Second;
                UserLogin.UserID = User.UserID;
                UserLogin.SessionID = string.Empty;
                _publisher.Post(ConnectionStatus.Logined, UserLogin);
                _publisher.Post(ConnectionStatus.Done);
            }
            else {
                SendError(rspInfo, nameof(OnRspUserLogin));
                _publisher.Post(ConnectionStatus.Disconnected);
            }
        }

        private void OnFrontDisconnected(object sender, int reason)
        {
            if (reason != 0) {
                SendError(reason, $"{Server.Address}");
            }
        }

        private void OnFrontConnected(object sender)
        {
            _spi.ProcessLog(new LogField(LogLevel.Debug, $"Ctpse market({Server.Address}) connected"));
            if (!Connected) {
                _publisher.Post(ConnectionStatus.Connected);
                _publisher.Post(ConnectionStatus.Logining);
            }

            var info = new CtpReqUserLogin();
            info.BrokerID = Server.BrokerID;
            info.UserProductInfo = Server.UserProductInfo;
            info.UserID = User.UserID;
            info.Password = User.Password;
            _api.ReqUserLogin(info, GetNextRequestId());
        }

        private void Resubscribe()
        {
            _spi.ProcessLog(new LogField(LogLevel.Debug, $"Ctpse market({Server.Address}) resubscribe count: {_instrumentsView.Length}"));
            _api.SubscribeMarketData(_instrumentsView, _instrumentsView.Length);
        }

        public CtpMdClient(IXSpi spi)
        {
            _spi = spi;
            _publisher = new StatusPublisher(spi);
            _instrumentsView = _instruments.ToArray();
        }

        public bool Connected { get; private set; }
        public ServerInfoField Server { get; private set; }
        public UserInfoField User { get; private set; }
        public RspUserLoginField UserLogin { get; private set; }

        public void Release()
        {
            if (_api != null) {
                _publisher.Post(ConnectionStatus.Releasing);
                Connected = false;
                _api.Release();
                _api = null;
                _instruments.Clear();
                _publisher.Post(ConnectionStatus.Disconnected);
            }
        }

        public void Init(ServerInfoField server, UserInfoField user)
        {
            if (_api != null) {
                return;
            }
            User = user;
            Server = server;
            UserLogin = null;
            _api = new CtpMdApi(GetFlowPath(server, user));
            InitHandler();
            var items = server.Address.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in items) {
                _api.RegisterFront(item);
            }
            _publisher.Post(ConnectionStatus.Connecting);
            _api.Init();
        }

        public void Subscribe(string instrument)
        {
            if (Connected && !_instruments.Contains(instrument)) {
                _instruments.Add(instrument);
                _instrumentsView = _instruments.ToArray();
                _api.SubscribeMarketData(new[] { instrument }, 1);
            }
        }

        public void Unsubscribe(string instrument)
        {
            if (Connected && _instruments.Contains(instrument)) {
                _instruments.Remove(instrument);
                _instrumentsView = _instruments.ToArray();
                _api.UnSubscribeMarketData(new[] { instrument }, 1);
            }
        }
    }
}