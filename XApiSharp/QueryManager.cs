using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace QuantBox.XApi
{
    public abstract class QueryManager<T>
    {
        private struct QueryEvent<TResponse>
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

        private readonly BlockingCollection<QueryEvent<T>> _queue;
        private readonly Task _task;
        private readonly CancellationTokenSource _cts;

        private DateTime _lastQueryTime = DateTime.Now;

        private void ProcessResponse(QueryEvent<T> e)
        {
            switch (e.Type) {
                case QueryType.ReqQryInstrument:
                    ProcessInstrument(e.Response);
                    break;
                case QueryType.ReqQryInvestorPosition:
                    ProcessInvestorPosition(e.Response);
                    break;
                case QueryType.ReqQryTradingAccount:
                    ProcessTradingAccount(e.Response);
                    break;
                case QueryType.ReqQryOrder:
                    ProcessOrder(e.Response);
                    break;
                case QueryType.ReqQryInstrumentCommissionRate:
                    ProcessInstrumentCommissionRate(e.Response);
                    break;
                case QueryType.ReqQryInstrumentMarginRate:
                    ProcessInstrumentMarginRate(e.Response);
                    break;
                case QueryType.ReqQrySettlementInfo:
                    ProcessSettlementInfo(e.Response);
                    break;
                case QueryType.ReqQryInvestor:
                    ProcessInvestor(e.Response);
                    break;
                default:
                    return;
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
                var wait = 1000 - (DateTime.Now - _lastQueryTime).Milliseconds;
                if (wait > 0) {
                    Thread.Sleep(wait);
                }
                _queue.Add(e);
            }
            _lastQueryTime = DateTime.Now;
        }

        private void TaskRun(CancellationToken ct)
        {
            try {
                while (!ct.IsCancellationRequested) {
                    if (!_queue.TryTake(out var e, -1, ct)) {
                        continue;
                    }
                    if (e.Response == null) {
                        ProcessQuery(e);
                    }
                    else {
                        ProcessResponse(e);
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
        protected abstract int QryInstrumentCommissionRate(ReqQueryField field);
        protected abstract int QryInstrumentMarginRate(ReqQueryField field);
        protected abstract int QrySettlementInfo(ReqQueryField field);
        protected abstract int QryInvestor(ReqQueryField field);
        protected abstract int QryQuote(ReqQueryField field);
        protected abstract void ProcessInstrument(T rsp);
        protected abstract void ProcessInvestorPosition(T rsp);
        protected abstract void ProcessTradingAccount(T rsp);
        protected abstract void ProcessOrder(T rsp);
        protected abstract void ProcessInstrumentCommissionRate(T rsp);
        protected abstract void ProcessInstrumentMarginRate(T rsp);
        protected abstract void ProcessSettlementInfo(T rsp);
        protected abstract void ProcessInvestor(T rsp);

        protected QueryManager()
        {
            _queue = new BlockingCollection<QueryEvent<T>>();
            _cts = new CancellationTokenSource();
            _task = Task.Run(() => TaskRun(_cts.Token), _cts.Token);
        }

        public void Post(QueryType type, ReqQueryField field = null)
        {
            _queue.Add(new QueryEvent<T>(type, field));
        }

        public void Post(QueryType type, T rsp)
        {
            _queue.Add(new QueryEvent<T>(type, rsp));
        }

        public void Close()
        {
            _cts.Cancel();
            _task.Wait();
        }
    }
}