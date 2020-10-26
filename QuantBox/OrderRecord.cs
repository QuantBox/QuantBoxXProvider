using SmartQuant;

namespace QuantBox
{
    internal class OrderRecord
    {        
        public OrderRecord(Order order)
        {
            Order = order;
            LeavesQty = (int)order.Qty;
            CumQty = order.CumQty;
            AvgPx = order.AvgPx;
        }

        public readonly Order Order;

        public double LeavesQty;

        public bool Cancelling;

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