using System;
using System.Collections.Generic;
using QuantBox.XApi;
using SmartQuant;
using InstrumentType = SmartQuant.InstrumentType;

namespace QuantBox
{
    public class InstTradingRules
    {
        /// <summary>
        /// 优先平金的交易所列表
        /// </summary>
        public static readonly HashSet<string> CloseTodayFirstExchanges = new HashSet<string> { ExchangeNames.CFFEX };

        /// <summary>
        /// 支持市价的交易所列表
        /// </summary>
        public static readonly HashSet<string> SupportMarketOrderExchanges = new HashSet<string> {
            ExchangeNames.SSE, 
            ExchangeNames.SZSE, 
            ExchangeNames.DCE, 
            ExchangeNames.CZCE
        };

        /// <summary>
        /// 严格区分平今平昨的交易所列表
        /// </summary>
        public static readonly HashSet<string> StrictCloseTodayExchanges = new HashSet<string> {
            ExchangeNames.SHFE, 
            ExchangeNames.INE
        };

        public static InstTradingRules DefaultTradingRules(Instrument inst)
        {
            return new InstTradingRules {
                HasShort = inst.Type == InstrumentType.Future
                           || inst.Type == InstrumentType.FutureOption
                           || inst.Type == InstrumentType.Option,
                DisableCloseToday = !(inst.Type == InstrumentType.Future
                                      || inst.Type == InstrumentType.FutureOption
                                      || inst.Type == InstrumentType.Option),
                HasMarketOrder = SupportMarketOrderExchanges.Contains(inst.Exchange),
                CloseTodayFirst = CloseTodayFirstExchanges.Contains(inst.Exchange),
                StrictCloseToday = StrictCloseTodayExchanges.Contains(inst.Exchange),
            };
        }

        public static Func<Instrument, InstTradingRules> TradingRulesGetter = DefaultTradingRules;

        public static void Init(Framework framework)
        {
            foreach (var instrument in framework.InstrumentManager.Instruments) {
                instrument.SetTradingRules(TradingRulesGetter(instrument));
            }
        }

        /// <summary>
        /// 支持做空
        /// </summary>
        public bool HasShort;
        /// <summary>
        /// 支持市价
        /// </summary>
        public bool HasMarketOrder;
        /// <summary>
        /// T+1 平仓
        /// </summary>
        public bool DisableCloseToday;
        /// <summary>
        /// 平今优先
        /// </summary>
        public bool CloseTodayFirst;
        /// <summary>
        /// 严格的平今
        /// </summary>
        public bool StrictCloseToday;
    }
}