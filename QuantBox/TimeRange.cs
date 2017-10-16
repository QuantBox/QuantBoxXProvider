using System;

namespace QuantBox
{
    public class TimeRange
    {
        public TimeSpan Begin { get; set; }
        public TimeSpan End { get; set; }

        public override string ToString()
        {
            return $"Start={Begin};End={End}";
        }
    }
}