namespace QuantBox.XApi
{
    internal enum ResponseType : byte
    {
        OnConnectionStatus = 64,
        OnRtnError,
        OnLog,

        OnRtnDepthMarketData,
        OnRspQryInstrument,
        OnRspQryTradingAccount,
        OnRspQryInvestorPosition,
        OnRspQrySettlementInfo,

        OnRspQryOrder,
        OnRspQryTrade,
        OnRspQryQuote,

        OnRtnOrder,
        OnRtnTrade,
        OnRtnQuote,

        OnRtnQuoteRequest,

        OnRspQryHistoricalTicks,
        OnRspQryHistoricalBars,
        OnRspQryInvestor,

        OnFilterSubscribe,
    }
}