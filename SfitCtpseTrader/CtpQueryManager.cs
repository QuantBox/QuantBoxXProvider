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
    internal class CtpQueryManager : QueryManager<CtpResponse?>
    {
        private readonly CtpTradeClient _client;

        private int SendRequest(byte id, object arg)
        {
            return SendRequest(new CtpRequest(id, arg, _client.GetNextRequestId()));
        }

        private int SendRequest(CtpRequest req)
        {
            try {
                while (true) {
                    if (_client.api == null)
                        return -1;
                    var ret = _client.api.ProcessRequest(ref req);
                    var awaitingTimes = 0;
                    switch (ret) {
                        case -1:
                            return -1;
                        case -2:
                        case -3:
                            awaitingTimes++;
                            Thread.Sleep(awaitingTimes * 100);
                            break;
                        default:
                            return 0;
                    }
                }
            }
            catch (Exception) {
                return -1;
            }
        }

        protected override int QryTradingAccount(ReqQueryField field)
        {
            var query = new CtpQryTradingAccount {
                BrokerID = _client.ctpLoginInfo.BrokerID,
                InvestorID = _client.ctpLoginInfo.UserID
            };
            return SendRequest(CtpRequestType.ReqQryTradingAccount, query);
        }

        protected override int QryOrder(ReqQueryField field)
        {
            var query = new CtpQryOrder {
                BrokerID = _client.ctpLoginInfo.BrokerID,
                InvestorID = _client.ctpLoginInfo.UserID
            };
            return SendRequest(CtpRequestType.ReqQryOrder, query);
        }

        protected override int QryTrade(ReqQueryField field)
        {
            var query = new CtpQryTrade {
                BrokerID = _client.ctpLoginInfo.BrokerID,
                InvestorID = _client.ctpLoginInfo.UserID
            };
            return SendRequest(CtpRequestType.ReqQryTrade, query);
        }

        protected override int QryInstrumentCommissionRate(ReqQueryField field)
        {
            throw new NotImplementedException();
        }

        protected override int QryInstrumentMarginRate(ReqQueryField field)
        {
            throw new NotImplementedException();
        }

        protected override int QrySettlementInfo(ReqQueryField field)
        {
            throw new NotImplementedException();
        }

        protected override int QryInvestor(ReqQueryField field)
        {
            throw new NotImplementedException();
        }

        protected override int QryQuote(ReqQueryField field)
        {
            var query = new CtpQryDepthMarketData { InstrumentID = field.InstrumentID };
            return SendRequest(CtpRequestType.ReqQryDepthMarketData, query);
        }

        protected override bool ProcessInstrument(CtpResponse? rsp)
        {
            if (!rsp.HasValue) {
                return true;
            }
            try {
                var data = rsp.Value.Item1.AsInstrument;
                if (data == null) {
                    if (rsp.Value.IsLast) {
                        _client.spi.ProcessQryInstrument(null, true);
                    }
                    return true;
                }

                if (CtpConvert.CheckRspInfo(rsp.Value.Item2)) {
                    _client.spi.ProcessQryInstrument(CtpConvert.GetInstrumentField(data), rsp.Value.IsLast);
                    return rsp.Value.IsLast;
                }
                else {
                    _client.SendError(rsp.Value.Item2, nameof(ProcessInstrument));
                    _client.spi.ProcessQryInstrument(null, true);
                }
            }
            catch (Exception e) {
                _client.SendError(-1, e.Message);
                _client.spi.ProcessQryInstrument(null, true);
            }
            return true;
        }

        protected override bool ProcessInvestorPosition(CtpResponse? rsp)
        {
            if (!rsp.HasValue) {
                return true;
            }
            if (CtpConvert.CheckRspInfo(rsp.Value.Item2)) {
                var data = rsp.Value.Item1.AsInvestorPosition;
                PositionField position = null;
                if (data != null) {
                    position = CtpConvert.GetPositionField(data);
                }
                _client.spi.ProcessQryPosition(position, rsp.Value.IsLast);
                return rsp.Value.IsLast;
            }
            else {
                _client.SendError(rsp.Value.Item2, nameof(ProcessInvestorPosition));
                _client.spi.ProcessQryPosition(null, true);
            }
            return true;
        }

        protected override bool ProcessTradingAccount(CtpResponse? rsp)
        {
            var data = rsp?.Item1.AsTradingAccount;
            if (data == null)
                return true;
            if (CtpConvert.CheckRspInfo(rsp.Value.Item2)) {
                _client.spi.ProcessQryAccount(CtpConvert.GetAccountField(data), rsp.Value.IsLast);
                return rsp.Value.IsLast;
            }
            else {
                _client.SendError(rsp.Value.Item2, nameof(ProcessTradingAccount));
                _client.spi.ProcessQryAccount(null, true);
            }
            return true;
        }

        protected override bool ProcessOrder(CtpResponse? rsp)
        {
            if (rsp == null) {
                return true;
            }

            if (CtpConvert.CheckRspInfo(rsp.Value.Item2)) {
                _client.spi.ProcessQryOrder(CtpConvert.GetOrder(rsp.Value.Item1.AsOrder), rsp.Value.IsLast);
                return rsp.Value.IsLast;
            }
            return true;
        }

        protected override bool ProcessTrade(CtpResponse? rsp)
        {
            if (rsp == null) {
                return true;
            }

            if (CtpConvert.CheckRspInfo(rsp.Value.Item2)) {
                _client.spi.ProcessQryTrade(CtpConvert.GetTrade(rsp.Value.Item1.AsTrade), rsp.Value.IsLast);
                return rsp.Value.IsLast;
            }

            return true;
        }

        protected override bool ProcessInstrumentCommissionRate(CtpResponse? rsp)
        {
            throw new NotImplementedException();
        }

        protected override bool ProcessInstrumentMarginRate(CtpResponse? rsp)
        {
            throw new NotImplementedException();
        }

        protected override bool ProcessSettlementInfo(CtpResponse? rsp)
        {
            throw new NotImplementedException();
        }

        protected override bool ProcessInvestor(CtpResponse? rsp)
        {
            throw new NotImplementedException();
        }

        protected override bool ProcessError(CtpResponse? rsp)
        {
            if (rsp == null) {
                return true;
            }
            var info = rsp?.Item1.AsRspInfo;
            if (info.ErrorID == CtpErrorType.NEED_RETRY) {
                DelayQuery(2000);
                return false;
            }
            return true;
        }

        protected override int QueryInstrument(ReqQueryField field)
        {
            var query = new CtpQryInstrument();
            return SendRequest(CtpRequestType.ReqQryInstrument, query);
        }

        protected override int QryInvestorPosition(ReqQueryField field)
        {
            var query = new CtpQryInvestorPosition {
                BrokerID = _client.ctpLoginInfo.BrokerID,
                InvestorID = _client.ctpLoginInfo.UserID
            };
            return SendRequest(CtpRequestType.ReqQryInvestorPosition, query);
        }

        public CtpQueryManager(CtpTradeClient client)
        {
            _client = client;
        }
    }
}