using System;
using System.Linq;
using Skyline;

namespace QuantBox
{
    using SmartQuant;

    public class TickFilter : EventFilter
    {
        private readonly IdArray<TimeRangeSelector> _selectorList = new IdArray<TimeRangeSelector>();

        private Func<TradingTimeRange, TimeSpan, bool> _inTrading;
        private bool _discardEmpty;

        /// <summary>
        /// 丢弃集合竞价
        /// </summary>
        /// <param name="enabled"></param>
        /// <returns></returns>
        public TickFilter DiscardAuction(bool enabled = true)
        {
            if (enabled) {
                _inTrading = (range, span) => range.InTrading(span);
            }
            else {
                _inTrading = (range, span) => range.InRange(span);
            }
            return this;
        }

        /// <summary>
        /// 丢弃没有成交量的行情
        /// </summary>
        /// <param name="enabled"></param>
        /// <returns></returns>
        public TickFilter DiscardEmpty(bool enabled = true)
        {
            _discardEmpty = enabled;
            return this;
        }

        public TickFilter(Framework framework, params string[] symbols) : base(framework)
        {
            Init(symbols.Select(n => framework.InstrumentManager[n]).ToArray());
        }

        public TickFilter(Framework framework, params Instrument[] insts) : base(framework)
        {
            Init(insts);
        }

        public TickFilter(Framework framework, InstrumentList insts)
            : base(framework)
        {
            Init(insts.ToArray());
        }

        private void Init(Instrument[] insts)
        {
            DiscardEmpty().DiscardAuction(false);
            foreach (var inst in insts) {
                if (inst != null) {
                    _selectorList[inst.Id] = new TimeRangeSelector(inst);
                }
            }
        }

        public override Event Filter(Event e)
        {
            switch (e.TypeId) {
                case DataObjectType.Ask:
                case DataObjectType.Bid:
                case DataObjectType.Trade:
                    var tick = (Tick)e;
                    if (_discardEmpty && tick.Size == 0) {
                        return null;
                    }
                    var range = GetRanges(tick.InstrumentId, e.DateTime);
                    var span = e.DateTime.TimeOfDay;
                    if (range != null) {
                        if (!_inTrading(range, span)) {
                            return null;
                        }

                        if (range.IsEndPoint(span) || range.IsOpen(span)) {
                            tick.DateTime = e.DateTime.AddMilliseconds(-span.Milliseconds);
                            tick.ExchangeDateTime = tick.DateTime;
                        }
                    }
                    break;
            }
            return e;
        }

        private TradingTimeRange GetRanges(int instrumentId, DateTime dateTime)
        {
            return _selectorList[instrumentId].Get(dateTime);
        }
    }
}