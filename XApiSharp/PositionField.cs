using System.Runtime.InteropServices;

namespace QuantBox.XApi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public class PositionField
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] InstrumentName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string Symbol;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string ClientID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string AccountID;

        public PositionSide Side;
        public HedgeFlagType HedgeFlag;
        public int Date;
        public double PositionCost;

        public double Position;
        public double TodayPosition;
        public double HistoryPosition;
        public double HistoryFrozen;

        ///今日买卖持仓
        public double TodayBSPosition;
        ///今日买卖持仓冻结
        public double TodayBSFrozen;
        ///今日申赎持仓
        public double TodayPRPosition;
        ///今日申赎持仓冻结
        public double TodayPRFrozen;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string ID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string PortfolioID1;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string PortfolioID2;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string PortfolioID3;

        public BusinessType Business;
    }
}