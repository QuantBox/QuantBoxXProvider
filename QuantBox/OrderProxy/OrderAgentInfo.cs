using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using QuantBox.XApi;

namespace QuantBox
{
    public class OrderAgentInfo
    {
        private static string GetSettingsFile()
        {
            return QBHelper.GetConfigPath("orderagent");
        }

        public OrderAgentInfo()
        {
            Market2Limit.PriceAdjustMethod = OrderPriceAdjustMethod.UpperLowerLimit;
        }

        /// <summary>
        /// 优先平金的交易所列表
        /// </summary>
        public readonly HashSet<string> CloseTodayFirstExchanges = new HashSet<string> { ExchangeNames.CFFEX };

        /// <summary>
        /// 支持市价的交易所列表
        /// </summary>
        public readonly HashSet<string> SupportMarketOrderExchanges = new HashSet<string> {
            ExchangeNames.SSE, 
            ExchangeNames.SZSE, 
            ExchangeNames.DCE, 
            ExchangeNames.CZCE
        };

        /// <summary>
        /// 支持市价的交易所列表
        /// </summary>
        public readonly HashSet<string> StrictCloseTodayExchanges = new HashSet<string> {
            ExchangeNames.SHFE, 
            ExchangeNames.INE
        };

        /// <summary>
        /// 下反手单时，平仓单和开仓单同时发出还是先平后开顺序发出。
        /// </summary>
        public bool CloseFirstOnReversing = false;

        /// <summary>
        /// 市价转现价
        /// </summary>
        public DeviationInfo Market2Limit;

        public static OrderAgentInfo Load()
        {
            var settingsFile = GetSettingsFile();
            if (File.Exists(settingsFile)) {
                return JsonConvert.DeserializeObject<OrderAgentInfo>(QBHelper.ReadOnlyAllText(settingsFile));
            }
            return new OrderAgentInfo();
        }

        public void Save()
        {
            File.WriteAllText(GetSettingsFile(), JsonConvert.SerializeObject(this, Formatting.Indented));
        }
    }
}
