namespace QuantBox.XApi
{
    public enum OrderSide : byte
    {
        Buy,
        Sell,
        /// <summary>
        /// LOF申购
        /// </summary>
        LOFCreation,
        /// <summary>
        /// LOF赎回
        /// </summary>
        LOFRedemption,
        ///ETF申购
        ETFCreation,
        /// <summary>
        /// ETF赎回
        /// </summary>
        ETFRedemption,
        /// <summary>
        /// 合并
        /// </summary>
        Merge,
        /// <summary>
        /// 拆分
        /// </summary>
        Split,
        /// <summary>
        /// 可转债转股，参考于https://en.wikipedia.org/wiki/Convertible_bond
        /// </summary>
        CBConvert,
        CBRedemption,
        Undefined,
    };
}