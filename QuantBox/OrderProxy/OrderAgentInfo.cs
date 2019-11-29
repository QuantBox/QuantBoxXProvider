using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

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
            Market2Limit.PriceAdjustMethod = OrderPriceAdjustMethod.LowerUpperLimit;
        }

        /// <summary>
        /// 如果可能(交易所支持)优先平今
        /// </summary>
        public bool CloseTodayFirst = true;

        /// <summary>
        /// 优先平金的交易所列表
        /// </summary>
        public readonly HashSet<string> UseCloseTodayExchanges = new HashSet<string> { QuantBoxConst.SHFE, QuantBoxConst.INE };

        /// <summary>
        /// 支持平金的交易所列表
        /// </summary>
        public readonly HashSet<string> SupportCloseTodayExchanges = new HashSet<string> { QuantBoxConst.SHFE, QuantBoxConst.INE, QuantBoxConst.CFFEX };
        
        /// <summary>
        /// 支持市价的交易所列表
        /// </summary>
        public readonly HashSet<string> SupportMarketOrderExchanges = new HashSet<string> { QuantBoxConst.DCE, QuantBoxConst.CFFEX, QuantBoxConst.CZCE };

        /// <summary>
        /// 下反手单时，平仓单和开仓单同时发出还是先平后开顺序发出。
        /// </summary>
        public bool CloseFirstOnReversing = false;

        /// <summary>
        /// 是否对接OMS，如果对接OMS，则所有交易都区分平今平昨.
        /// </summary>
        public bool ConnectOms = true;

        /// <summary>
        /// 市价转现价
        /// </summary>
        public DeviationInfo Market2Limit = new DeviationInfo();
            
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
