using System;
using System.Reflection;
using NLog;
using SmartQuant;

namespace QuantBox
{
    public class QBTimeBarFactoryItem : TimeBarFactoryItem
    {
        private const int OffsetSeconds = 1;
        private const long MonthsBarSize = 2592000L;
        private static readonly TimeSpan OffsetMinutes = TimeSpan.FromMinutes(1);

        private DateTime _closeDateTime;
        private readonly ClockType _clockType;
        private readonly TimeRangeManager _timeRange;
        private readonly bool _enableLog;
        private readonly Logger _logger;
        private Framework _framework;

        private Framework GetFramework()
        {
            var fields = factory.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var field in fields) {
                if (field.FieldType == typeof(Framework)) {
                    return (Framework)field.GetValue(factory);
                }
            }
            return null;
        }

        public QBTimeBarFactoryItem(Instrument instrument, long barSize, bool enableLog = false)
            : base(instrument, barSize, BarInput.Trade, ClockType.Exchange)
        {
            _enableLog = enableLog;
            if (_enableLog) {
                _logger = LogManager.GetLogger("tbg." + instrument.Symbol);
            }
            IncludeFirstTick = true;
            _timeRange = MarketDataFilter.Instance.GetFilter(instrument);
            _clockType = ClockType.Exchange;
        }

        public bool IncludeFirstTick { get; set; }

        private void GetOpenCloseDateTime(DataObject tick, out DateTime openDateTime, out DateTime closeDateTime)
        {
            openDateTime = GetBarOpenDateTime(tick);
            if (barSize == MonthsBarSize) {
                closeDateTime = openDateTime.Date.AddMonths(1);
            }
            else {
                closeDateTime = openDateTime.AddSeconds(barSize);
            }
            closeDateTime = FixCloseDateTime(closeDateTime);
        }

        protected override void OnReminder(DateTime datetime)
        {
        }

        private DateTime GetBarOpenDateTime(DataObject obj)
        {
            var tick = (Tick)obj;
            if (IncludeFirstTick) {
                var time = _clockType == ClockType.Exchange ? tick.ExchangeDateTime : tick.DateTime;
                var timeChanged = false;
                if (time.Hour == _timeRange.OpenTime.Hours && time.Minute == _timeRange.OpenTime.Minutes) {
                    time = time.Date.Add(_timeRange.OpenTime.Add(OffsetMinutes));
                    timeChanged = true;
                }
                else if (time.Hour == _timeRange.NightOpenTime.Hours && time.Minute == _timeRange.NightOpenTime.Minutes) {
                    time = time.Date.Add(_timeRange.NightOpenTime.Add(OffsetMinutes));
                    timeChanged = true;
                }
                if (timeChanged) {
                    tick = new Tick(time, time, tick.ProviderId, tick.InstrumentId, tick.Price, tick.Size);
                }
            }
            return base.GetBarOpenDateTime(tick, _clockType);
        }

        private DateTime FixCloseDateTime(DateTime dateTime, bool backwards = true)
        {
            var time = dateTime.TimeOfDay;
            if (_timeRange.IsEndPoint(time.Hours, time.Minutes)) {
                return dateTime.AddSeconds(backwards ? OffsetSeconds : -OffsetSeconds);
            }
            return dateTime;
        }

        private void RaiseBar()
        {
            bar.DateTime = FixCloseDateTime(_closeDateTime, false);
            EmitBar();
        }

        private void CreateBar(Tick tick)
        {
            GetOpenCloseDateTime(tick, out var time, out _closeDateTime);
            if (_enableLog && _framework.Mode == FrameworkMode.Realtime) {
                _logger.Debug($"new_bar,{time: dd_HH:mm:ss},{_closeDateTime: dd_HH:mm:ss}");
            }            
            bar = new Bar(time, time, tick.InstrumentId, barType, barSize, tick.Price, tick.Price, tick.Price, tick.Price, tick.Size);
            EmitBarOpen();
        }

        protected override void OnData(DataObject obj)
        {
            var tick = (Tick)obj;
            if (_framework == null) {
                _framework = GetFramework();
            }
            if (_enableLog && _framework.Mode == FrameworkMode.Realtime) {
                _logger.Debug($"{tick.Size},{tick.DateTime: HH:mm:ss},{tick.ExchangeDateTime: HH:mm:ss}");
            }
            if (tick.Size == 0) {
                return;
            }

            if (bar != null) {
                if (_closeDateTime < tick.ExchangeDateTime) {
                    RaiseBar();
                    CreateBar(tick);
                }
                base.OnData(tick);
            }
            else {
                CreateBar(tick);
            }

            if (_closeDateTime == tick.ExchangeDateTime) {
                RaiseBar();
            }
            else {
                if (obj is QBTrade trade && trade.Field.ClosePrice > 0) {
                    RaiseBar();
                }
            }
        }
    }
}