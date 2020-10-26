using System;
using System.Runtime.InteropServices;
using System.Text;

namespace QuantBox.XApi.Native
{
    internal static class PInvokeUtility
    {
        private static readonly int DepthFieldSize = Marshal.SizeOf(typeof(DepthField));
        private static readonly int MarketDataFieldSize = Marshal.SizeOf(typeof(InternalDepthMarketDataField));
        public static readonly Encoding Gb2312 = Encoding.GetEncoding(936);

        public static string ReadString(byte[] data)
        {
            if (data == null) {
                return string.Empty;
            }
            var byteCount = 0;
            foreach (var b in data) {
                if (0 == b)
                    break;
                ++byteCount;
            }
            return 0 == byteCount ? string.Empty : Gb2312.GetString(data, 0, byteCount);
        }

        public static T PtrToStruct<T>(IntPtr handler)
        {
            if (handler == IntPtr.Zero) {
                return default(T);
            }
            else {
                return (T)Marshal.PtrToStructure(handler, typeof(T));
            }
        }

        public static DepthMarketDataField GetDepthMarketData(IntPtr ptr)
        {
            var field = (InternalDepthMarketDataField)Marshal.PtrToStructure(ptr, typeof(InternalDepthMarketDataField));

            var data = new DepthMarketDataField();
            data.TradingDay = field.TradingDay;
            data.ActionDay = field.ActionDay;
            data.UpdateTime = field.UpdateTime;
            data.UpdateMillisec = field.UpdateMillisec;
            data.Exchange = field.Exchange;
            data.Symbol = field.Symbol;
            data.InstrumentID = field.InstrumentID;
            data.LastPrice = field.LastPrice;
            data.Volume = field.Volume;
            data.Turnover = field.Turnover;
            data.OpenInterest = field.OpenInterest;
            data.AveragePrice = field.AveragePrice;
            data.OpenPrice = field.OpenPrice;
            data.HighestPrice = field.HighestPrice;
            data.LowestPrice = field.LowestPrice;
            data.ClosePrice = field.ClosePrice;
            data.SettlementPrice = field.SettlementPrice;
            data.UpperLimitPrice = field.UpperLimitPrice;
            data.LowerLimitPrice = field.LowerLimitPrice;
            data.PreClosePrice = field.PreClosePrice;
            data.PreSettlementPrice = field.PreSettlementPrice;
            data.PreOpenInterest = field.PreOpenInterest;
            data.TradingPhase = field.TradingPhase;


            var bidOffset = ptr.ToInt64() + MarketDataFieldSize;
            var askCount = (field.Size - MarketDataFieldSize) / DepthFieldSize - field.BidCount;
            var askOffset = ptr.ToInt64() + MarketDataFieldSize + field.BidCount * DepthFieldSize;

            data.Bids = new DepthField[field.BidCount];
            data.Asks = new DepthField[askCount];

            for (var i = 0; i < field.BidCount; ++i) {
                data.Bids[i] = (DepthField)Marshal.PtrToStructure(new IntPtr(bidOffset + i * DepthFieldSize), typeof(DepthField));
            }

            for (var i = 0; i < askCount; ++i) {
                data.Asks[i] = (DepthField)Marshal.PtrToStructure(new IntPtr(askOffset + i * DepthFieldSize), typeof(DepthField));
            }

            return data;
        }

        public static SettlementInfoField GetSettlementInfo(IntPtr ptr)
        {
            var info = new SettlementInfoField();
            if (ptr == IntPtr.Zero)
                return info;

            var field = (InternalSettlementInfoField)Marshal.PtrToStructure(ptr, typeof(InternalSettlementInfoField));
            var size = Marshal.SizeOf(typeof(InternalSettlementInfoField));
            var content = new IntPtr(ptr.ToInt64() + size);
            info.TradingDay = field.TradingDay;
            unsafe {
                info.Content = new string((sbyte*)content, 0, field.Size, Gb2312);
            }
            return info;
        }
    }
}