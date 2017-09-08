using System.Runtime.Serialization;
using QuantBox.XApi;

namespace QuantBox
{
    [DataContract]
    public class QuantBoxOrderInfo
    {
        public OpenCloseType OpenClose = OpenCloseType.Open;
        public HedgeFlagType HedgeFlag = HedgeFlagType.Undefined;
        public QuantBox.XApi.OrderSide Side = QuantBox.XApi.OrderSide.Undefined;    
    }
}
