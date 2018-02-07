using System;

namespace QuantBox
{
    public class TimeRangeManager
    {
        private const byte NoTrading = 0;
        private const byte Trading = 1;
        private const byte Open = 2;
        private const byte Close = 4;
        private const byte Night = 8;
        private const byte EndPoint = 16;

        private readonly byte[,,] _points = new byte[24, 60, 60];

        public TimeSpan NightOpenTime = TimeSpan.Zero;
        public TimeSpan OpenTime = TimeSpan.Zero;

        public bool InRange(TimeSpan time)
        {
            return _points[time.Hours, time.Minutes, time.Seconds] > NoTrading;
        }

        public bool IsOpen(int hours, int minutes, int seconds = 0)
        {
            return (_points[hours, minutes, seconds] & Open) == Open;
        }

        public bool IsOpen(TimeSpan time)
        {
            return IsOpen(time.Hours, time.Minutes, time.Seconds);
        }

        public bool IsClose(TimeSpan time)
        {
            return (_points[time.Hours, time.Minutes, time.Seconds] & Close) == Close;
        }

        public bool IsEndPoint(int hours, int minutes, int seconds = 0)
        {
            return (_points[hours, minutes, seconds] & EndPoint) == EndPoint;
        }

        public bool IsEndPoint(TimeSpan time)
        {
            return IsEndPoint(time.Hours, time.Minutes, time.Seconds);
        }

        public void AddRange(TimeRange range)
        {
            AddRange(range.Begin, range.End);
            if (range.IsOpen) {
                _points[range.Begin.Hours, range.Begin.Minutes, range.Begin.Seconds] = (byte)(range.IsNight ? Open | Night : Open);
                if (range.IsNight) {
                    NightOpenTime = range.Begin;
                }
                else {
                    OpenTime = range.Begin;
                }
            }
            _points[range.End.Hours, range.End.Minutes, range.End.Seconds] = (byte)(range.IsClose ? Close | EndPoint : EndPoint);
        }

        private void AddRange(TimeSpan time1, TimeSpan time2)
        {
            for (var time = time1; time <= time2; time = time.Add(TimeSpan.FromSeconds(1))) {
                _points[time.Hours, time.Minutes, time.Seconds] = Trading;
            }
        }
    }
}