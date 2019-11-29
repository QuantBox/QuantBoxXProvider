using SmartQuant;

namespace QuantBox.Data.Compression
{
    internal class TickDataEnumerator : DataEntryEnumerator
    {
        private readonly TickSeries _series;
        private readonly byte _type;

        private PriceSizeItem GetItem(Tick tick)
        {
            if (tick.TypeId == DataObjectType.Trade) {
                var trade = (Trade)tick;
                return new PriceSizeItem(tick.Price, tick.Size, (int)trade.GetOpenInterest(), trade.GetTurnover());
            }
            else {
                return new PriceSizeItem(tick.Price, tick.Size);
            }
        }

        public override DataEntry Current
        {
            get {
                Tick tick = _series[index];
                if (_type == tick.TypeId) {
                    var range = TimeRangeSelector.Get(tick.DateTime);
                    if (tick.Size > 0 && range.InRange(tick.DateTime.TimeOfDay)) {
                        return new DataEntry(tick.DateTime, range, new PriceSizeItem[] { GetItem(tick) });
                    }
                }
                return null;
            }
        }

        public TickDataEnumerator(TickSeries series, byte type = DataObjectType.Trade)
            : base(series.Count)
        {
            _series = series;
            _type = type;
        }
    }
}
