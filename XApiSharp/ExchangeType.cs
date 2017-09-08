namespace QuantBox.XApi
{

    public enum ExchangeType : byte
    {
        /// 未定义
        Undefined,
        /// 上期所
        SHFE,
        /// 大商所
        DCE,
        /// 郑商所
        CZCE,
        /// 中金所
        CFFEX,
        /// 能源中心
        INE,
        /// 上交所
        SSE,
        /// 深交所
        SZSE,
        /// 上海黄金交易所
        SGE,
        /// 全国中小企业股份转让系统,三板
        NEEQ,
        /// 港交所
        HKEx,
    };
}
