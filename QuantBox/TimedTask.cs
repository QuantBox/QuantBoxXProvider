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
        private int _validQutryCount;
        private int _inTimer;

        public TimedTask(XProvider provider)
        {
            _provider = provider;
            _timer = new Timer(500);
            _timer.Elapsed += TimerOnElapsed;
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            if (!TradingCalendar.Instance.IsTradingDay(DateTime.Today)) {
                return;
            }
            if (Interlocked.Exchange(ref _inTimer, 1) != 0) {
                return;
            }
            try {
                DataQuery();
                AutoConnect();
            }
            finally {
                Interlocked.Exchange(ref _inTimer, 0);
            }
        }

        private void AutoConnect()
        {
            if (_provider.SessionTimes.Count == 0) {
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
            if (!_provider.IsConnected ||
                _provider.IsInstrumentProvider && !_provider.QryInstrumentCompleted) {
                return;
            }

            if (_validQutryCount == 0) {
                if ((DateTime.Now - _lastTime).TotalSeconds > _provider.TradingDataQueryInterval) {
                    _validQutryCount = 2;
                    _lastTime = DateTime.Now;
                }
            }

            if (_validQutryCount < 1) {
                return;
            }

            if (EnableQueryPosition) {
                _provider.Trader.QueryPositions();
                _validQutryCount -= 1;
                EnableQueryPosition = false;
            }
            if (EnableQueryAccount) {
                _provider.Trader.QueryAccount();
                _validQutryCount -= 1;
                EnableQueryAccount = false;
            }
        }

        public bool EnableQueryAccount { get; set; }
        public bool EnableQueryPosition { get; set; }

        public void Start()
        {
            if (!_timer.Enabled) {
                _lastTime = DateTime.Now;
                _validQutryCount = 2;
                if (_provider.IsExecutionProvider) {
                    EnableQueryAccount = true;
                    EnableQueryPosition = false;
                }
                else {
                    EnableQueryAccount = false;
                    EnableQueryPosition = false;
                }
                _timer.Start();
            }
        }

        public void Close()
        {
            _timer.Stop();
        }
    }
}
