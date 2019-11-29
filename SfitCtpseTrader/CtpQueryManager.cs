using System;
using System.Threading.Tasks;
#if CTP || CTPSE
using QuantBox.Sfit.Api;
#else
using QuantBox.Rohon.Api;
#endif

namespace QuantBox.XApi
{
    internal class CtpQueryManager : QueryManager<CtpResponse?>
    {
        private readonly CtpTradeClient _client;

        protected override int QryTradingAccount(ReqQueryField field)
        {
            var account = new CtpQryTradingAccount();
            account.BrokerID = _client.CtpLoginInfo.BrokerID;
            account.InvestorID = _client.CtpLoginInfo.UserID;
            return _client.Api.ReqQryTradingAccount(account, _client.GetNextRequestId());
        }

        protected override int QryOrder(ReqQueryField field)
        {
            return _client.Api.ReqQryOrder(new CtpQryOrder {
                BrokerID = _client.CtpLoginInfo.BrokerID,
                InvestorID = _client.CtpLoginInfo.UserID
            }, _client.GetNextRequestId());
        }

        protected override int QryTrade(ReqQueryField field)
        {
            return _client.Api.ReqQryTrade(new CtpQryTrade {
                BrokerID = _client.CtpLoginInfo.BrokerID,
                InvestorID = _client.CtpLoginInfo.UserID
            }, _client.GetNextRequestId());
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
            var req = new CtpQryDepthMarketData();
            req.InstrumentID = field.InstrumentID;
            return _client.Api.ReqQryDepthMarketData(req, _client.GetNextRequestId());
        }

        protected override bool ProcessInstrument(CtpResponse? rsp)
        {
            if (!rsp.HasValue) {
                return true;
            }
            try {
                var data = rsp.Value.Item1.AsInstrument;
                if (data == null)
                    return true;

                if (CtpConvert.CheckRspInfo(rsp.Value.Item2)) {
                    _client.Spi.ProcessQryInstrument(CtpConvert.GetInstrumentField(data), rsp.Value.IsLast);
                    return rsp.Value.IsLast;
                }
                else {
                    _client.SendError(rsp.Value.Item2, nameof(ProcessInstrument));
                    _client.Spi.ProcessQryInstrument(null, true);
                }
            }
            catch (Exception e) {
                _client.SendError(-1, e.Message);
                _client.Spi.ProcessQryInstrument(null, true);
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
                _client.Spi.ProcessQryPosition(position, rsp.Value.IsLast);
                return rsp.Value.IsLast;
            }
            else {
                _client.SendError(rsp.Value.Item2, nameof(ProcessInvestorPosition));
                _client.Spi.ProcessQryPosition(null, true);
            }
            return true;
        }

        protected override bool ProcessTradingAccount(CtpResponse? rsp)
        {
            var data = rsp?.Item1.AsTradingAccount;
            if (data == null)
                return true;
            if (CtpConvert.CheckRspInfo(rsp.Value.Item2)) {
                _client.Spi.ProcessQryAccount(CtpConvert.GetAccountField(data), rsp.Value.IsLast);
                return rsp.Value.IsLast;
            }
            else {
                _client.SendError(rsp.Value.Item2, nameof(ProcessTradingAccount));
                _client.Spi.ProcessQryAccount(null, true);
            }
            return true;
        }

        protected override bool ProcessOrder(CtpResponse? rsp)
        {
            if (rsp == null) {
                return true;
            }

            if (CtpConvert.CheckRspInfo(rsp.Value.Item2)) {
                _client.Spi.ProcessQryOrder(CtpConvert.GetOrder(rsp.Value.Item1.AsOrder), rsp.Value.IsLast);
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
                _client.Spi.ProcessQryTrade(CtpConvert.GetTrade(rsp.Value.Item1.AsTrade), rsp.Value.IsLast);
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
            return _client.Api.ReqQryInstrument(new CtpQryInstrument(), _client.GetNextRequestId());
        }

        protected override int QryInvestorPosition(ReqQueryField field)
        {
            var position = new CtpQryInvestorPosition();
            position.BrokerID = _client.CtpLoginInfo.BrokerID;
            position.InvestorID = _client.CtpLoginInfo.UserID;
            return _client.Api.ReqQryInvestorPosition(position, _client.GetNextRequestId());
        }

        public CtpQueryManager(CtpTradeClient client)
        {
            _client = client;
        }
    }
}