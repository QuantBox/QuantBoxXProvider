using System;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace QuantBox
{
    internal class TimedTask
    {
        private readonly XProvider _provider;
        private readonly Timer _timer;
        private DateTime _lastTime;
        private int _inTimer;

        public TimedTask(XProvider provider)
        {
            _provider = provider;
            _timer = new Timer(1000);
            _timer.Elapsed += TimerOnElapsed;
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            if (Interlocked.Exchange(ref _inTimer, 1) != 0) {
                return;
            }
            try {
                AutoConnect();
                if (!TradingCalendar.Instance.IsTradingDay(DateTime.Today)) {
                    return;
                }
                DataQuery();
            }
            finally {
                Interlocked.Exchange(ref _inTimer, 0);
            }
        }

        private void AutoConnect()
        {
            if (!_provider.EnableAutoConnect) {
                return;
            }

            if (_provider.InTradingSession()) {
                if (!_provider.IsConnected) {
                    _provider.AutoConnect();
                }
            }
            else {
                if (_provider.IsConnected) {
                    _provider.AutoDisconnect();
                }
            }
        }

        private void DataQuery()
        {
            if (!_provider.IsConnected
                || !_provider.IsExecutionProvider
                || (_provider.IsInstrumentProvider && !_provider.qryInstrumentCompleted)
                || _provider.QueryTradingDataAfterTrade) {
                return;
            }

            if ((DateTime.Now - _lastTime).TotalSeconds > _provider.TradingDataQueryInterval) {
                _lastTime = DateTime.Now;
                _provider.trader.QueryPositions();
                _provider.trader.QueryAccount();
            }
        }

        public void Start()
        {
            if (!_timer.Enabled) {
                _lastTime = DateTime.Now;
                _timer.Start();
            }
        }

        public void Close()
        {
            _timer.Stop();
        }
    }
}
