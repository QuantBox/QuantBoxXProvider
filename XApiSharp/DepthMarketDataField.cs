using System;
using System.Text;

namespace QuantBox.XApi
{
    public class DepthMarketDataField
    {
        public int TradingDay;
        public int ActionDay;
        public int UpdateTime;
        public int UpdateMillisec;

        /// <summary>
        /// 合约代码
        /// </summary>
        public string Symbol;

        /// <summary>
        /// 合约代码
        /// </summary>
        public string InstrumentID;

        /// <summary>
        /// 交易所代码
        /// </summary>
        public string ExchangeID;

        /// <summary>
        /// 交易所代码
        /// </summary>
        public ExchangeType Exchange;

        /// <summary>
        /// 最新价
        /// </summary>
        public double LastPrice;
        /// <summary>
        /// 数量
        /// </summary>
        public double Volume;
        /// <summary>
        /// 成交金额
        /// </summary>
        public double Turnover;
        /// <summary>
        /// 持仓量
        /// </summary>
        public double OpenInterest;
        /// <summary>
        /// 当日均价
        /// </summary>
        public double AveragePrice;
        /// <summary>
        /// 今开盘
        /// </summary>
        public double OpenPrice;
        /// <summary>
        /// 最高价
        /// </summary>
        public double HighestPrice;
        /// <summary>
        /// 最低价
        /// </summary>
        public double LowestPrice;
        /// <summary>
        /// 今收盘
        /// </summary>
        public double ClosePrice;
        /// <summary>
        /// 本次结算价
        /// </summary>
        public double SettlementPrice;

        /// <summary>
        /// 涨停板价
        /// </summary>
        public double UpperLimitPrice;
        /// <summary>
        /// 跌停板价
        /// </summary>
        public double LowerLimitPrice;
        /// <summary>
        /// 昨收盘
        /// </summary>
        public double PreClosePrice;
        /// <summary>
        /// 上次结算价
        /// </summary>
        public double PreSettlementPrice;
        /// <summary>
        /// 昨持仓量
        /// </summary>
        public double PreOpenInterest;

        ///交易阶段类型
        public TradingPhaseType TradingPhase;

        /// <summary>
        /// 买档
        /// </summary>
        public DepthField[] Bids;
        /// <summary>
        /// 卖挡
        /// </summary>
        public DepthField[] Asks;

        public DepthMarketDataField Copy()
        {
            var field = (DepthMarketDataField)MemberwiseClone();
            CopyDepthField(Bids, ref field.Bids);
            CopyDepthField(Asks, ref field.Asks);
            return field;

            void CopyDepthField(DepthField[] src, ref DepthField[] dest)
            {
                if (src != null && src.Length > 0) {
                    dest = new DepthField[src.Length];
                    Array.Copy(src, 0, dest, 0, src.Length);
                }
                else {
                    dest = new DepthField[0];
                }
            }
        }

        public override string ToString()
        {
            return new StringBuilder()
                .Append($"{ActionDay} {UpdateTime}.{UpdateMillisec}").Append(", ")
                .Append(InstrumentID).Append(", ")
                .Append(LastPrice).Append(", ")
                .Append(Volume).Append(", ")
                .Append("bid:").Append(GetDepthField(Bids)).Append(", ")
                .Append("ask:").Append(GetDepthField(Asks)).Append(", ")
                .Append("turnover:").Append(Turnover).Append(", ")
                .Append("open_interest:").Append(OpenInterest).Append(", ")
                .ToString();

            string GetDepthField(DepthField[] fields)
            {
                if (fields != null && fields.Length > 0) {
                    return $"{fields[0].Price}, {fields[0].Size}";
                }
                return "0, 0";
            }
        }

        public readonly static DepthMarketDataField Empty;
        static DepthMarketDataField()
        {
            Empty = new DepthMarketDataField() {
                OpenPrice = double.NaN,
                ClosePrice = double.NaN,
                UpperLimitPrice = double.NaN,
                LowerLimitPrice = double.NaN,
                SettlementPrice = double.NaN,
                OpenInterest = double.NaN,
                PreClosePrice = double.NaN,
                PreSettlementPrice = double.NaN,
                PreOpenInterest = double.NaN,
                TradingPhase = TradingPhaseType.NoTrading,
                LastPrice = double.NaN,
                Volume = double.NaN,
                Exchange = ExchangeType.Undefined,
                Symbol = string.Empty,
                ExchangeID = string.Empty,
                InstrumentID = string.Empty,
                Bids = new DepthField[0],
                Asks = new DepthField[0]
            };
        }
    }
}