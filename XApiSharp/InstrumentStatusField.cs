using System.Runtime.InteropServices;

namespace QuantBox.XApi
{
    public class InstrumentStatusField
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ExchangeID;
        public int EnterTime;
        public EnterReasonType EnterReason;
        public InstrumentStatusType Status;
    }
}