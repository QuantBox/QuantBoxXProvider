namespace QuantBox.XApi
{
    public enum OrderSide : byte
    {
        Buy,
        Sell,
        LOFCreation,		///LOF申购
        LOFRedemption,		///LOF赎回
        ETFCreation,	///ETF申购
        ETFRedemption,	///ETF赎回
        Merge,		    ///合并
        Split,		    ///拆分
        CBConvert,		///可转债转股，参考于https://en.wikipedia.org/wiki/Convertible_bond
        CBRedemption,
        Undefined,
    };
}