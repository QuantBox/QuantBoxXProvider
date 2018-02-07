using System;

namespace QuantBox
{
    public class TimeRange
    {
        public TimeSpan Begin { get; set; }
        public TimeSpan End { get; set; }
        public bool IsOpen { get; set; }
        public bool IsClose { get; set; }
        public bool IsNight { get; set; }

        public TimeRange(TimeSpan begin, TimeSpan end, bool open, bool close, bool night)
        {
            Begin = begin;
            End = end;
            IsOpen = open;
            IsClose = close;
            IsNight = night;
        }

        public TimeRange()
        {
        }

        public override string ToString()
        {
            return $"Start={Begin};End={End}";
        }
    }
}