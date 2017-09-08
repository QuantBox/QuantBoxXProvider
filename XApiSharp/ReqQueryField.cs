using System.Runtime.InteropServices;

namespace QuantBox.XApi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public class ReqQueryField
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
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;

        public int DateStart;
        public int DateEnd;
        public int TimeStart;
        public int TimeEnd;
        
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string Char64ID;
        public int Int32ID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string Char64PositionIndex;
        public int Int32PositionIndex;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string PortfolioID1;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string PortfolioID2;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string PortfolioID3;

        public BusinessType Business;
    }
}