using System;

namespace QuantBox
{
    public enum OrderDeviationMode : byte
    {
        Disabled = 0,
        Time,
        Trade,
        QuoteAndTrade
    }

    public enum OrderDeviationMethod : byte
    {
        Cancel = 0,
        PriceAdjust
    }

    public enum OrderAdjustFailedMethod : byte
    {
        Cancel = 0,
        Keep
    }

    public enum OrderPriceAdjustMethod : byte
    {
        /// <summary>
        /// 默认设置
        /// </summary>
        Default = 0,
        /// <summary>
        /// 涨跌停价 
        /// </summary>
        UpperLowerLimit,
        /// <summary>
        /// 对手价
        /// </summary>
        MatchPrice
    }
}
