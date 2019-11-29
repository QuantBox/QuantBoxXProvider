using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace QuantBox.XApi
{
    public abstract class QueryManager<T>
    {
        protected struct QueryEvent<TResponse>
        {
            public QueryType? Type { get; }
            public TResponse Response { get; }
            public ReqQueryField Field { get; }

            public QueryEvent(QueryType type, ReqQueryField field = null)
            {
                Type = type;
                Response = default(TResponse);
                Field = field;
            }

            public QueryEvent(QueryType type, TResponse rsp)
            {
                Response = rsp;
                Type = type;
                Field = null;
            }
        }

        private readonly BlockingCollection<QueryEvent<T>> _requests;
        private readonly BlockingCollection<QueryEvent<T>> _responses;

        private readonly Task _task;
        private readonly CancellationTokenSource _cts;
        private QueryEvent<T>? _lastQuery;
        private int _tryCount;
        private int _qryCount;
        private Task _delayedTask;

        private void ResetQuery()
        {
            _lastQuery = null;
            _tryCount = 0;
        }

        private bool ProcessResponse(QueryEvent<T> e)
        {
            switch (e.Type) {
                case QueryType.ReqError:
                    return ProcessError(e.Response);
                case QueryType.ReqQryInstrument:
                    return ProcessInstrument(e.Response);
                case QueryType.ReqQryInvestorPosition:
                    return ProcessInvestorPosition(e.Response);
                case QueryType.ReqQryTradingAccount:
                    return ProcessTradingAccount(e.Response);
                case QueryType.ReqQryOrder:
                    return ProcessOrder(e.Response);
                case QueryType.ReqQryTrade:
                    return ProcessTrade(e.Response);
                case QueryType.ReqQryInstrumentCommissionRate:
                    return ProcessInstrumentCommissionRate(e.Response);
                case QueryType.ReqQryInstrumentMarginRate:
                    return ProcessInstrumentMarginRate(e.Response);
                case QueryType.ReqQrySettlementInfo:
                    return ProcessSettlementInfo(e.Response);
                case QueryType.ReqQryInvestor:
                    return ProcessInvestor(e.Response);
                default:
                    return true;
            }
        }

        private void ProcessQuery(QueryEvent<T> e)
        {
            int ret;
            if (e.Type == null) {
                return;
            }

            switch (e.Type) {
                case QueryType.ReqQryInstrument:
                    ret = QueryInstrument(e.Field);
                    break;
                case QueryType.ReqQryInvestorPosition:
                    ret = QryInvestorPosition(e.Field);
                    break;
                case QueryType.ReqQryTradingAccount:
                    ret = QryTradingAccount(e.Field);
                    break;
                case QueryType.ReqQryOrder:
                    ret = QryOrder(e.Field);
                    break;
                case QueryType.ReqQryTrade:
                    ret = QryTrade(e.Field);
                    break;
                case QueryType.ReqQryInstrumentCommissionRate:
                    ret = QryInstrumentCommissionRate(e.Field);
                    break;
                case QueryType.ReqQryInstrumentMarginRate:
                    ret = QryInstrumentMarginRate(e.Field);
                    break;
                case QueryType.ReqQrySettlementInfo:
                    ret = QrySettlementInfo(e.Field);
                    break;
                case QueryType.ReqQryInvestor:
                    ret = QryInvestor(e.Field);
                    break;
                case QueryType.ReqQryQuote:
                    ret = QryQuote(e.Field);
                    break;
                default:
                    return;
            }
            if (ret != 0) {
                DelayQuery(1000);
            }
        }

        private void TaskRun(CancellationToken ct)
        {
            try {
                while (!ct.IsCancellationRequested) {
                    if (_lastQuery == null) {
                        if (_requests.TryTake(out var e, 10, ct)) {
                            ++_qryCount;
                            _lastQuery = e;
                            ProcessQuery(e);
                        }
                    }
                    else if (_responses.TryTake(out var e, 10, ct)) {
                        if (ProcessResponse(e)) {
                            ResetQuery();
                        }
                    }
                }
            }
            catch (OperationCanceledException) {
            }
        }

        protected abstract int QueryInstrument(ReqQueryField field);
        protected abstract int QryInvestorPosition(ReqQueryField field);
        protected abstract int QryTradingAccount(ReqQueryField field);
        protected abstract int QryOrder(ReqQueryField field);
        protected abstract int QryTrade(ReqQueryField field);
        protected abstract int QryInstrumentCommissionRate(ReqQueryField field);
        protected abstract int QryInstrumentMarginRate(ReqQueryField field);
        protected abstract int QrySettlementInfo(ReqQueryField field);
        protected abstract int QryInvestor(ReqQueryField field);
        protected abstract int QryQuote(ReqQueryField field);
        protected abstract bool ProcessInstrument(T rsp);
        protected abstract bool ProcessInvestorPosition(T rsp);
        protected abstract bool ProcessTradingAccount(T rsp);
        protected abstract bool ProcessOrder(T rsp);
        protected abstract bool ProcessTrade(T rsp);
        protected abstract bool ProcessInstrumentCommissionRate(T rsp);
        protected abstract bool ProcessInstrumentMarginRate(T rsp);
        protected abstract bool ProcessSettlementInfo(T rsp);
        protected abstract bool ProcessInvestor(T rsp);
        protected abstract bool ProcessError(T rsp);

        protected void QueryAgain()
        {
            ++_tryCount;
            if (_tryCount > TryCountMax) {
                ResetQuery();
                return;
            }
            if (_lastQuery != null) {
                ProcessQuery(_lastQuery.Value);
            }
        }

        protected void DelayQuery(int millisecond)
        {
            _delayedTask = Task.Delay(millisecond, _cts.Token).ContinueWith((t) => {
                if (t.IsCompleted) {
                    QueryAgain();
                }
            });
        }

        protected QueryManager()
        {
            _requests = new BlockingCollection<QueryEvent<T>>();
            _responses = new BlockingCollection<QueryEvent<T>>();

            _cts = new CancellationTokenSource();
            _task = Task.Run(() => TaskRun(_cts.Token), _cts.Token);
        }

        public int TryCountMax { get; set; } = 3;
        public int MaxQueryQueue { get; private set; } = 1000;

        public void Post(QueryType type, ReqQueryField field = null)
        {
            if (_requests.Count < MaxQueryQueue) {
                _requests.Add(new QueryEvent<T>(type, field));
            }
        }

        public void Post(QueryType type, T rsp)
        {
            _responses.Add(new QueryEvent<T>(type, rsp));
        }

        public void Close()
        {
            _cts.Cancel();
            _task.Wait();
            _delayedTask?.Wait();
        }
    }
}