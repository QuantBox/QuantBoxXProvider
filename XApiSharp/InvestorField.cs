using System.Runtime.InteropServices;

namespace QuantBox.XApi
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public struct InvestorField
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string InvestorID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        public IdCardType IdentifiedCardType;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string IdentifiedCardNo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 81)]
        public byte[] InvestorName;
    }
}