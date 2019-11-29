using System;
using System.Reflection;
using NLog;
using Skyline;
using SmartQuant;

namespace QuantBox
{
    public class QBTimeBarFactoryItem : TimeBarFactoryItem
    {
        private const int OffsetSeconds = 1;

        private DateTime _closeDateTime;
        private readonly ClockType _clockType;
        private readonly bool _enableLog;
        private readonly Logger _logger;
        private TradingTimeRange _timeRanges;
        private Framework _framework;
        private bool _delayedBarOpen;
        private double _turnover;

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
            if (barSize == QuantBoxConst.MonthBarSize) {
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
                if (_timeRanges.InFristMd(time.TimeOfDay)) {
                    if (time.TimeOfDay > _timeRanges.CloseTime) {
                        time = time.Date.Add(_timeRanges.NightOpenTime);
                    }
                    else {
                        time = time.Date.Add(_timeRanges.OpenTime);
                    }
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
            if (_timeRanges.IsEndPoint(time.Hours, time.Minutes)) {
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
            bar.SetTurnover(_turnover);
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
            _turnover = 0;
            if (!_delayedBarOpen) {
                EmitBarOpen();
            }

            if (_framework.Mode == FrameworkMode.Simulation) {
                AddReminder(_closeDateTime, _clockType);
            }
        }

        private void LoadTradingTimeRange()
        {
            _timeRanges = TradingCalendar.Instance.GetTimeRange(instrument, DateTime.Today);
        }

        protected override void OnData(DataObject obj)
        {
            if (_framework == null) {
                _framework = GetFramework();
            }
            var trade = (Trade)obj;
            if (_enableLog && _framework.Mode == FrameworkMode.Realtime) {
                _logger.Debug($"{trade.Price}, {OpenQuant.Helper.GetIntSize(trade)},{trade.DateTime: HH:mm:ss},{trade.ExchangeDateTime: HH:mm:ss}");
            }

            if (bar != null) {
                if (_delayedBarOpen && bar.OpenDateTime <= trade.ExchangeDateTime) {
                    _delayedBarOpen = false;
                    EmitBarOpen();
                }

                if (_closeDateTime < trade.ExchangeDateTime) {
                    RaiseBar();
                    if (OpenQuant.Helper.GetIntSize(trade) == 0) {
                        return;
                    }
                    CreateBar(trade);
                }
                base.OnData(trade);
                _turnover += trade.GetTurnover();

                if (_framework.Mode == FrameworkMode.Simulation) {
                    return;
                }

                if (_closeDateTime == trade.ExchangeDateTime) {
                    RaiseBar();
                }
                else {
                    if (trade.GetClosePrice() > 0) {
                        RaiseBar();
                    }
                }
            }
            else {
                if (OpenQuant.Helper.GetIntSize(trade) == 0) {
                    return;
                }
                CreateBar(trade);
            }
        }
    }
}