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

        private DateTime _closeDateTime;
        private readonly ClockType _clockType;
        private readonly bool _enableLog;
        private readonly Logger _logger;
        private TradingTimeRange _timeRange;
        private Framework _framework;
        private bool _delayedBarOpen;
        private TimeSpan _nightOpenTime;
        private TimeSpan _openTime;

        public override BarFactoryItem Clone()
        {
            return new QBTimeBarFactoryItem(instrument, barSize, _enableLog);
        }

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
                _logger = LogManager.GetLogger("tbf." + instrument.Symbol);
            }
            _clockType = ClockType.Exchange;
            LoadTradingTimeRange();
        }

        public bool IncludeFirstTick { get; set; } = true;

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
            if (_framework.Mode == FrameworkMode.Realtime) {
            }
        }

        protected override void OnReminder(DateTime datetime)
        {
            RaiseBar();
        }

        private DateTime GetBarOpenDateTime(DataObject obj)
        {
            var tick = (Tick)obj;
            if (IncludeFirstTick) {
                var time = _clockType == ClockType.Exchange ? tick.ExchangeDateTime : tick.DateTime;
                var timeChanged = false;
                if (time.Hour == _openTime.Hours && time.Minute == _openTime.Minutes) {
                    time = time.Date.Add(_timeRange.OpenTime.Add(TradingTimeManager.OffsetMinutes));
                    timeChanged = true;
                }
                else if (time.Hour == _nightOpenTime.Hours && time.Minute == _nightOpenTime.Minutes) {
                    time = time.Date.Add(_timeRange.NightOpenTime.Add(TradingTimeManager.OffsetMinutes));
                    timeChanged = true;
                }
                if (timeChanged) {
                    if (_framework.Mode == FrameworkMode.Realtime) {
                        _delayedBarOpen = true;
                    }

                    if (_clockType == ClockType.Exchange) {
                        tick.ExchangeDateTime = time;
                    }
                    else {
                        tick.DateTime = time;
                    }
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
            if (bar == null) {
                return;
            }

            bar.DateTime = FixCloseDateTime(_closeDateTime, false);
            //if (_framework.Mode == FrameworkMode.Realtime) {
                
            //}
            //else {
            //    bar.DateTime = _closeDateTime;
            //}
            EmitBar();
        }

        private void CreateBar(Tick tick)
        {
            GetOpenCloseDateTime(tick, out var time, out _closeDateTime);
            if (_enableLog && _framework.Mode == FrameworkMode.Realtime) {
                _logger.Debug($"new_bar,{time: dd_HH:mm:ss},{_closeDateTime: dd_HH:mm:ss}");
            }
            bar = OpenQuant.Helper.NewBar(
                time,
                tick.DateTime,
                ProviderId,
                tick.InstrumentId,
                barType,
                barSize,
                tick.Price, tick.Price, tick.Price, tick.Price, OpenQuant.Helper.GetDoubleSize(tick));

            if (!_delayedBarOpen) {
                EmitBarOpen();
            }

            if (_framework.Mode == FrameworkMode.Simulation) {
                AddReminder(_closeDateTime, _clockType);
            }
        }

        private void LoadTradingTimeRange()
        {
            _timeRange = TradingCalendar.Instance.GetTimeRange(instrument, DateTime.Today);
            _nightOpenTime = _timeRange.NightOpenTime;
            _openTime = _timeRange.OpenTime;
        }

        protected override void OnData(DataObject obj)
        {
            if (_framework == null) {
                _framework = GetFramework();
            }
            var tick = (Tick)obj;
            if (_enableLog && _framework.Mode == FrameworkMode.Realtime) {
                _logger.Debug($"{tick.Price}, {OpenQuant.Helper.GetIntSize(tick)},{tick.DateTime: HH:mm:ss},{tick.ExchangeDateTime: HH:mm:ss}");
            }

            if (bar != null) {
                if (_delayedBarOpen && bar.OpenDateTime <= tick.ExchangeDateTime) {
                    _delayedBarOpen = false;
                    EmitBarOpen();
                }

                if (_closeDateTime < tick.ExchangeDateTime) {
                    RaiseBar();
                    if (OpenQuant.Helper.GetIntSize(tick) == 0) {
                        return;
                    }
                    CreateBar(tick);
                }
                base.OnData(tick);

                if (_framework.Mode == FrameworkMode.Simulation) {
                    return;
                }

                if (_closeDateTime == tick.ExchangeDateTime) {
                    RaiseBar();
                }
                else {
                    if (obj is Trade trade && trade.GetClosePrice() > 0) {
                        RaiseBar();
                    }
                }
            }
            else {
                if (OpenQuant.Helper.GetIntSize(tick) == 0) {
                    return;
                }
                CreateBar(tick);
            }
        }
    }
}