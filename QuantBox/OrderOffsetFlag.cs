namespace QuantBox
{
    public readonly struct OrderOffsetFlag
    {
        public readonly bool IsOpen;
        public readonly bool IsCloseToday;

        public OrderOffsetFlag(bool isOpen, bool isToday)
        {
            IsOpen = isOpen;
            IsCloseToday = isToday;
        }
    }
}
