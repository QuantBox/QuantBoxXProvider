namespace QuantBox.Data.Compression
{
    internal class PriceSizeItem
    {
        public double Price { get; private set; }

        public int Size { get; private set; }

        public int OpenInt { get; private set; }

        public double Amount { get; private set; }

        public PriceSizeItem(double price, int size, int openInt = 0, double amount = 0)
        {
            Price = price;
            Size = size;
            OpenInt = openInt;
            Amount = amount;
        }
    }
}
