namespace QuantBox.XApi
{
    public enum HedgeFlagType : byte
    {
        /// <summary>
        /// 投机
        /// </summary>
        Speculation,
        /// <summary>
        /// 套利
        /// </summary>
        Arbitrage,
        /// <summary>
        /// 套保
        /// </summary>
        Hedge,
        Covered,
        MarketMaker,
        Undefined
    };
}
