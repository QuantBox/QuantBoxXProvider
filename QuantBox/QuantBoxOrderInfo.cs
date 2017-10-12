using System.Runtime.Serialization;
using QuantBox.XApi;

namespace QuantBox
{
    [DataContract]
    public class QuantBoxOrderInfo
    {
        public OpenCloseType OpenClose = OpenCloseType.Open;
        public HedgeFlagType HedgeFlag = HedgeFlagType.Speculation;
        public OrderSide Side = OrderSide.Undefined;    
    }
}
