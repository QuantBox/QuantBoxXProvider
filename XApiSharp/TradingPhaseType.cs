namespace QuantBox.XApi
{
    ///交易阶段类型
    public enum TradingPhaseType : byte
    {
        BeforeTrading,		///开盘前
        NoTrading,			///非交易
        Continuous,		///连续交易
        AuctionOrdering,	///集合竞价报单
        AuctionBalance,	///集合竞价价格平衡
        AuctionMatch,		///集合竞价撮合
        Closed,			///收盘
        Suspension,		///停牌时段,参考于LTS
        Fuse,				///熔断时段,参考于LTS
    };
}
