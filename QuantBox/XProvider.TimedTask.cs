using System;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace QuantBox
{
    public partial class XProvider
    {
        private class TimedTask
        {
            private readonly XProvider _provider;
            private readonly Timer _timer;
            private DateTime _lastTime;
            private int _validQutryCount;
            private int _inTimer;

            public TimedTask(XProvider provider)
            {
                _provider = provider;
                _timer = new Timer(100);
                _timer.Elapsed += TimerOnElapsed;
            }

            private void TimerOnElapsed(object sender, ElapsedEventArgs e)
            {
                if (Interlocked.Exchange(ref _inTimer, 1) != 0) {
                    return;
                }
                try {
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
                        _provider._trader.QueryPositions();
                        _validQutryCount -= 1;
                        EnableQueryPosition = false;
                    }
                    if (EnableQueryAccount) {
                        _provider._trader.QueryAccount();
                        _validQutryCount -= 1;
                        EnableQueryAccount = false;
                    }
                }
                finally {
                    Interlocked.Exchange(ref _inTimer, 0);
                }
            }

            public bool EnableQueryAccount { get; set; }
            public bool EnableQueryPosition { get; set; }

            public void Start()
            {
                if (!_timer.Enabled) {
                    _lastTime = DateTime.Now;
                    EnableQueryAccount = true;
                    EnableQueryPosition = false;
                    _validQutryCount = 2;
                    _timer.Start();
                }
            }

            public void Stop()
            {
                _timer.Stop();
            }
        }
    }
}
