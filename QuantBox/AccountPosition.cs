using QuantBox.XApi;

namespace QuantBox
{
    internal class AccountPosition
    {
        public string ExchangeId { get; private set; }

        public string InstrumentId { get; private set; }

        public double Qty => LongQty + ShortQty;

        public PositionField Long { get; private set; }

        public double LongQty {
            get {
                if (Long != null) {
                    return Long.Position;
                }
                return 0;
            }
        }

        public PositionField Short { get; private set; }

        public double ShortQty {
            get {
                if (Short != null) {
                    return Short.Position;
                }
                return 0;
            }
        }

        public void AddPosition(PositionField position)
        {
            if (string.IsNullOrEmpty(InstrumentId)) {
                ExchangeId = position.ExchangeID;
                InstrumentId = position.InstrumentID;
            }

            if (position.Side == QuantBox.XApi.PositionSide.Long) {
                Long = position;
            }
            else {
                Short = position;
            }
        }
    }
}
