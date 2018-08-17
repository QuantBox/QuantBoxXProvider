namespace QuantBox.XApi
{
    public enum InstrumentStatusType : byte
    {
        BeforeTrading,
        NoTrading,
        Continous,
        AuctionOrdering,
        AuctionBalance,
        AuctionMatch,
        Closed
    }
}