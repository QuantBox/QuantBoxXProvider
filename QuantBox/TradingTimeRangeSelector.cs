using System;
using System.Collections.Generic;
using System.Linq;
using Skyline;
using SmartQuant;

namespace QuantBox
{
    public class TimeRangeSelector
    {
        private readonly IList<TradingTimeRange> _list;
        private TradingTimeRange _last;

        public TimeRangeSelector(Instrument inst)
        {
            _list = TradingCalendar.Instance.GetTimeRanges(inst);
        }

        public TradingTimeRange Get(DateTime dateTime)
        {
            _last = TradingCalendar.Instance.GetTimeRange(_list, _last, dateTime);
            return _last;
        }
    }
}
