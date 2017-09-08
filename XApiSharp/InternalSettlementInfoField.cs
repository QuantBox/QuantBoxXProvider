using System.Runtime.InteropServices;

namespace QuantBox.XApi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal class InternalSettlementInfoField
    {
        public int Size;
        /// <summary>
        /// 交易日
        /// </summary>
        public int TradingDay;
    }
}