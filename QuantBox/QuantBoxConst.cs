namespace QuantBox
{
    public static class QuantBoxConst
    {
        /// <summary>
        /// 历史数据插件
        /// </summary>
        public const byte PIdHisData = 60;
        /// <summary>
        /// CtpSimnow插件
        /// </summary>
        public const byte PIdSimnow = 61;
        /// <summary>
        /// O32插件
        /// </summary>
        public const byte PIdO32 = 62;
        /// <summary>
        /// O32插件
        /// </summary>
        public const byte PIdUfx = 62;
        /// <summary>
        /// 天风行情
        /// </summary>
        public const byte PIdThanfSubscribe = 63;
        /// <summary>
        /// 数据模拟
        /// </summary>
        public const byte PIdSimData = 64;
        /// <summary>
        /// 文件数据模拟
        /// </summary>
        public const byte PIdFileSimData = 65;
        /// <summary>
        /// 融航插件
        /// </summary>
        public const byte PIdRohon = 66;
        /// <summary>
        /// 迅投PB
        /// </summary>
        public const byte PIdRaiseTechPb = 67;
        /// <summary>
        /// 天风STP
        /// </summary>
        public const byte PIdStp = 68;
        /// <summary>
        /// QuantBox Oms
        /// </summary>
        public const byte PIdOms = 71;
        /// <summary>
        /// Ctp插件
        /// </summary>
        public const byte PIdCtp = 72;
        /// <summary>
        /// Ctp仿真插件
        /// </summary>
        public const byte PIdCtpSim = 73;
        /// <summary>
        /// 交易撮合模拟
        /// </summary>
        public const byte PIdSimExec = 74;
        /// <summary>
        /// 期权数据模拟
        /// </summary>
        public const byte PIdOptionSimData = 75;

        public const int ReportErrorOffset = 0;
        public const int OrderInfoOffset = 0;
        public const int StopIdOffset = 0;
        public const int InstrumentMarketDataOffset = 0;
        public const int InstrumentTimeManagerOffset = 1;
        public const int TradeMarketDataOffset = 0;
        public const int TradeOpenInterestOffset = 1;
        public const int TradeTurnoverOffset = 2;
        public const int TradeClosePriceOffset = 3;
        public const int BarTurnoverOffset = 0;
        internal const string GlobalExOrders = "@qb_exchange_orders@";
        internal const string GlobalExTrades = "@qb_exchange_trades@";
        internal const string GlobalExTradingDay = "@qb_exchange_tradingday@";
        internal const string GlobalMarketCloseReminder = "@qb_market_close_reminder@";

        public const int MinBarSize = 60;
        public const int HourBarSize = 60 * MinBarSize;
        public const int DayBarSize = 24 * HourBarSize;
        public const int WeekBarSize = DayBarSize * 7;
        public const int MonthBarSize = DayBarSize * 30;
    }
}