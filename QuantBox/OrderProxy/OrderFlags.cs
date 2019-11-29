namespace QuantBox.OrderProxy
{
    public struct OrderFlags
    {
        public readonly bool IsOpen;
        public readonly bool IsCloseToday;

        public OrderFlags(bool isOpen, bool isToday)
        {
            IsOpen = isOpen;
            IsCloseToday = isToday;
        }
    }
}
