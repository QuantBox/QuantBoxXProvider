namespace QuantBox.XApi
{
    public enum QueryType : byte
    {
        ReqQryInstrument = 32,
        ReqQryTradingAccount,
        ReqQryInvestorPosition,

        ReqQryOrder,
        ReqQryTrade,
        ReqQryQuote,

        ReqQryInstrumentCommissionRate,
        ReqQryInstrumentMarginRate,
        ReqQrySettlementInfo,
        ReqQryInvestor,

        ReqQryHistoricalTicks,
        ReqQryHistoricalBars,
    }
}