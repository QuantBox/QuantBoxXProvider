namespace QuantBox.XApi
{
    ///交易阶段类型
    public enum TradingPhaseType : byte
    {
        /// <summary>
        /// 开盘前
        /// </summary>
        BeforeTrading,
        /// <summary>
        /// 非交易
        /// </summary>
        NoTrading,
        /// <summary>
        /// 连续交易
        /// </summary>
        Continuous,
        /// <summary>
        /// 集合竞价报单
        /// </summary>
        AuctionOrdering,
        /// <summary>
        /// 集合竞价价格平衡
        /// </summary>
        AuctionBalance,
        /// <summary>
        /// 集合竞价撮合
        /// </summary>
        AuctionMatch,
        /// <summary>
        /// 收盘
        /// </summary>
        Closed,
        /// <summary>
        /// 停牌时段,参考于LTS
        /// </summary>
        Suspension,
        /// <summary>
        /// 熔断时段,参考于LTS
        /// </summary>
        Fuse,
        /// <summary>
        /// 存量数据，TFData
        /// </summary>
        Repository
    };
}
