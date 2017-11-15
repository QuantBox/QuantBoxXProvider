using System;
using System.Threading;
using System.Threading.Tasks.Dataflow;
using QuantBox.Sfit.Api;

namespace QuantBox.XApi
{
    internal class CtpQueryManager
    {
        private struct QueryEvent
        {
            public QueryType? Type { get; }
            public CtpResponse? Response { get; }

            public QueryEvent(QueryType type)
            {
                Type = type;
                Response = null;
            }

            public QueryEvent(CtpResponse rsp)
            {
                Response = rsp;
                Type = null;
            }
        }

        private readonly CtpTradeClient _client;
        private readonly ActionBlock<QueryEvent> _action;
        private int _sleeps;

        private void ProcessQuery(QueryEvent e)
        {
            var ret = 0;
            switch (e.Type) {
                case QueryType.ReqQryInstrument:
                    ret = _client.Api.ReqQryInstrument(new CtpQryInstrument(), _client.GetNextRequestId());
                    break;
                case QueryType.ReqQryInvestorPosition:
                    ret = QryInvestorPosition();
                    break;
                case QueryType.ReqQryTradingAccount:
                    ret = QryTradingAccount();
                    break;

            }
            if (ret == 0) {
                _sleeps = 1;
            }
            else {
                _sleeps *= 4;
                _sleeps %= 1023;
                _action.Post(e);
            }
            Thread.Sleep(_sleeps);
        }
        private void ProcessAccount(CtpResponse rsp)
        {
            var data = rsp.Item1.AsTradingAccount;
            if (data == null)
                return;
            if (CtpConvert.CheckRspInfo(rsp.Item2)) {
                _client.Spi.ProcessQryAccount(CtpConvert.GetAccountField(data), rsp.IsLast == CtpResponse.True);
            }
            else {
                _client.SendError(rsp.Item2, nameof(ProcessAccount));
                _client.Spi.ProcessQryAccount(null, true);
            }
        }
        private void ProcessPosition(CtpResponse rsp)
        {
            var data = rsp.Item1.AsInvestorPosition;
            if (data == null)
                return;
            if (CtpConvert.CheckRspInfo(rsp.Item2)) {
                _client.Spi.ProcessQryPosition(CtpConvert.GetPositionField(data), rsp.IsLast == CtpResponse.True);
            }
            else {
                _client.SendError(rsp.Item2, nameof(ProcessPosition));
                _client.Spi.ProcessQryPosition(null, true);
            }
        }
        private void ProcessInstrument(CtpResponse rsp)
        {
            try {
                var data = rsp.Item1.AsInstrument;
                if (data == null)
                    return;
                if (CtpConvert.CheckRspInfo(rsp.Item2)) {
                    _client.Spi.ProcessQryInstrument(CtpConvert.GetInstrumentField(data), rsp.IsLast == CtpResponse.True);
                }
                else {
                    _client.SendError(rsp.Item2, nameof(ProcessInstrument));
                    _client.Spi.ProcessQryInstrument(null, true);
                }
            }
            catch (Exception e) {
                _client.SendError(-1, e.Message);
                _client.Spi.ProcessQryInstrument(null, true);
            }
        }

        private void ProcessResponse(QueryEvent e)
        {
            if (e.Response == null)
                return;
            var rsp = e.Response.Value;
            switch (rsp.TypeId) {
                case CtpResponseType.OnRspQryTradingAccount:
                    ProcessAccount(rsp);
                    break;
                case CtpResponseType.OnRspQryInvestorPosition:
                    ProcessPosition(rsp);
                    break;
                case CtpResponseType.OnRspQryInstrument:
                    ProcessInstrument(rsp);
                    break;
            }
        }
        private void QueryAction(QueryEvent e)
        {
            if (!_client.Connected) {
                return;
            }
            if (e.Type.HasValue) {
                ProcessQuery(e);
            }
            else {
                ProcessResponse(e);
            }
        }

        private int QryTradingAccount()
        {
            var field = new CtpQryTradingAccount();
            field.BrokerID = _client.CtpLoginInfo.BrokerID;
            field.InvestorID = _client.CtpLoginInfo.UserID;
            return _client.Api.ReqQryTradingAccount(field, _client.GetNextRequestId());
        }

        private int QryInvestorPosition()
        {
            var field = new CtpQryInvestorPosition();
            field.BrokerID = _client.CtpLoginInfo.BrokerID;
            field.InvestorID = _client.CtpLoginInfo.UserID;
            return _client.Api.ReqQryInvestorPosition(field, _client.GetNextRequestId());
        }

        public CtpQueryManager(CtpTradeClient client)
        {
            _client = client;
            _action = new ActionBlock<QueryEvent>((Action<QueryEvent>)QueryAction);
        }

        public void Post(QueryType type)
        {
            _action.Post(new QueryEvent(type));
        }

        public void Post(CtpResponse rsp)
        {
            _action.Post(new QueryEvent(rsp));
        }

        public void Close()
        {
            _action.Complete();
            _action.Completion.Wait();
        }
    }
}