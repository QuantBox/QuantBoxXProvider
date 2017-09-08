using System.Runtime.InteropServices;

namespace QuantBox.XApi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public class OrderField
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
        
        public OrderSide Side;
        public double Qty;
        public double Price;
        public OpenCloseType OpenClose;
        public HedgeFlagType HedgeFlag;
        public int Date;
        public int Time;
        
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string ID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string OrderID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string LocalID;
        
        public OrderType Type;
        public double StopPx;
        public TimeInForce TimeInForce;

        public OrderStatus Status;
        public ExecType ExecType;
        public double LeavesQty;
        public double CumQty;
        public double AvgPx;

        public int XErrorID;
        public int RawErrorID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] Text;

        public int ReserveInt32;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string ReserveChar64;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string PortfolioID1;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string PortfolioID2;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string PortfolioID3;

        public BusinessType Business;
    }
}