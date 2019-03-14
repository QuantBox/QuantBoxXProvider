using System;
using System.Collections.Generic;

namespace QuantBox
{
    public class TradingTimeRange
    {
        private const byte NoTrading = 0;
        private const byte Trading = 1;
        private const byte Open = 2;
        private const byte Close = 4;
        private const byte Night = 8;
        private const byte EndPoint = 16;
        private readonly List<TimeRange> _ranges = new List<TimeRange>();
        private readonly byte[,,] _points = new byte[24, 60, 60];

        private void AddRange(TimeSpan time1, TimeSpan time2)
        {
            for (var time = time1; time <= time2; time = time.Add(TimeSpan.FromSeconds(1))) {
                _points[time.Hours, time.Minutes, time.Seconds] = Trading;
            }
        }

        public TradingTimeRange(DateTime dateTime1, DateTime dateTime2)
        {
            DateTime1 = dateTime1;
            DateTime2 = dateTime2;
        }

        public readonly DateTime DateTime1;
        public readonly DateTime DateTime2;
        public TimeSpan NightOpenTime = TimeSpan.Zero;
        public TimeSpan OpenTime = TimeSpan.Zero;
        public TimeSpan NightCloseTime = TimeSpan.Zero;
        public TimeSpan CloseTime = TimeSpan.Zero;

        public List<TimeRange> Ranges => _ranges;

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

        //判断是否是集合竞价时间集合竞价时间规则为：
        //有夜盘的，夜盘开盘前5分钟的前4分钟；
        //无夜盘的，日盘开盘前5分钟的前4分钟；
        public bool IsAggregateAuctionTime(TimeSpan time)
        {
            var openTime = NightOpenTime != TimeSpan.Zero ? NightOpenTime : OpenTime;
            var startAuction = openTime - new TimeSpan(0, 4, -30);
            var endAuction = openTime - new TimeSpan(0, 0, 30);

            return time > startAuction && time < endAuction;
        }

        public void AddRange(TimeRange range)
        {
            _ranges.Add(range);
            AddRange(range.Begin, range.End);
            if (range.IsOpen) {
                _points[range.Begin.Hours, range.Begin.Minutes, range.Begin.Seconds] = (byte)(range.IsNight ? Open | Night : Open);
                if (range.IsNight) {
                    NightOpenTime = range.Begin;
                    NightCloseTime = range.End;
                }
                else {
                    OpenTime = range.Begin;
                }
            }
            else if (range.IsClose) {
                CloseTime = range.End;
            }
            else if (range.Begin == TimeSpan.Zero) {
                NightCloseTime = range.End;
            }

            _points[range.End.Hours, range.End.Minutes, range.End.Seconds] = (byte)(range.IsClose ? Close | EndPoint : EndPoint);
        }

        public static readonly TradingTimeRange Fulltime;
        static TradingTimeRange()
        {
            Fulltime = new TradingTimeRange(DateTime.MinValue, DateTime.MaxValue);
            Fulltime.AddRange(TimeSpan.Zero, new TimeSpan(23, 59, 59));
        }
    }
}