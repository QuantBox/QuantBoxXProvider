using SmartQuant;

namespace QuantBox
{
    internal class OrderRecord
    {
        public OrderRecord(Order order)
        {
            Order = order;
            LeavesQty = (int)order.Qty;
            CumQty = 0;
            AvgPx = 0;
        }

        public Order Order { get; }

        public double LeavesQty { get; set; }

        public double CumQty { get; private set; }

        public double AvgPx { get; private set; }

        public void AddFill(double lastPx, double lastQty)
        {
            AvgPx = (AvgPx * CumQty + lastPx * lastQty) / (CumQty + lastQty);
            LeavesQty -= lastQty;
            CumQty += lastQty;
        }
    }
}