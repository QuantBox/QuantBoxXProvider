namespace QuantBox.XApi
{
    public static class ExchangeNames
    {
        /// <summary>上期所</summary>
        public const string SHFE = "SHFE";
        /// <summary>郑商所</summary>
		public const string CZCE = "CZCE";
        /// <summary>中金所</summary>
        public const string CFFEX = "CFFEX";
        /// <summary>郑商所</summary>
        public const string DCE = "DCE";
        /// <summary>能源中心</summary>
        public const string INE = "INE";
        /// <summary>上交所</summary>
        public const string SSE = "SSE";
        /// <summary>深交所</summary>
        public const string SZSE = "SZSE";
        /// <summary>上海黄金交易所</summary>
        public const string SGE = "SGE";
        /// <summary>全国中小企业股份转让系统(三板)</summary>
        public const string NEEQ = "NEEQ";
        /// <summary>港交所</summary>
        public const string HKEx = "HKEx";
    }

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
