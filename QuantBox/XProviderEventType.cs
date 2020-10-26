namespace QuantBox
{
    public enum XProviderEventType : byte
    {
        AutoDisconnect,
        TraderCreated,
        ConnectDone,
        DisconnectDone,
        MarketBeforeTrading = 48,
        MarketNoTrading = 49,
        MarketContinuous = 50,
        MarketAuctionOrdering = 51,
        MarketAuctionBalance = 52,
        MarketAuctionMatch = 53,
        MarketClosed = 54
    }
}