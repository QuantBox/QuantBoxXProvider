using System;
using SmartQuant;

namespace QuantBox
{
    public class TickFilter : EventFilter
    {
        private readonly IdArray<TradingTimeRange> _ranges = new IdArray<TradingTimeRange>();

        public TickFilter(Framework framework, InstrumentList insts)
            : base(framework)
        {
            foreach (var inst in insts) {
                _ranges[inst.Id] = TradingCalendar.Instance.GetTimeRange(inst, DateTime.Today);
            }
        }

        public override Event Filter(Event e)
        {
            switch (e.TypeId) {
                case DataObjectType.Ask:
                case DataObjectType.Bid:
                case DataObjectType.Trade:
                    var tick = (Tick)e;
                    var range = _ranges[tick.InstrumentId];
                    var span = e.DateTime.TimeOfDay;
                    if (range != null) {
                        if (!range.InRange(span)) {
                            return null;
                        }

                        if (range.IsEndPoint(span) || range.IsOpen(span)) {
                            var modifyTime = e.DateTime.AddMilliseconds(-span.Milliseconds);
                            switch (e.TypeId) {
                                case DataObjectType.Ask:
                                    return new Ask(modifyTime, tick.ProviderId, tick.InstrumentId, tick.Price, tick.Size);
                                case DataObjectType.Bid:
                                    return new Bid(modifyTime, tick.ProviderId, tick.InstrumentId, tick.Price, tick.Size);
                                case DataObjectType.Trade:
                                    return new Trade(modifyTime, tick.ProviderId, tick.InstrumentId, tick.Price, tick.Size);
                            }
                        }
                    }
                    break;
            }
            return e;
        }
    }
}