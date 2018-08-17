using System;
using System.Collections;

namespace QuantBox
{
    internal class TradingDayList
    {
        private readonly BitArray _days;
        private readonly BitArray _holidays;

        public TradingDayList(DateTime begin, DateTime end)
        {
            BeginDate = begin;
            EndDate = end;
            _days = new BitArray(Convert.ToInt32((EndDate - BeginDate).TotalDays) + 1);
            _holidays = new BitArray(_days.Length);
        }

        public int GetPos(DateTime date)
        {
            return (date - BeginDate).Days;
        }

        public bool this[int index]
        {
            get => _days[index];
            set => _days.Set(index, value);
        }

        public bool this[DateTime date]
        {
            get => _days[GetPos(date)];
            set => _days.Set(GetPos(date), value);
        }

        public bool IsHoliday(DateTime date)
        {
            return _holidays[GetPos(date)];
        }
        
        public void SetHoliday(DateTime date)
        {
            _holidays[GetPos(date)] = true;
        }

        public int Count => _days.Length;
        public DateTime BeginDate { get; private set; }
        public DateTime EndDate { get; private set; }
    }
}