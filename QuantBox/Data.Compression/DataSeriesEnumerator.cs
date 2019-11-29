using SmartQuant;

namespace QuantBox.Data.Compression
{
    internal class DataSeriesEnumerator : DataEntryEnumerator
    {
        private readonly DataSeries _series;
        private readonly int _index1;
        private readonly int _index2;

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

        public DataSeriesEnumerator(DataSeries series, int index1, int index2) : base(index2 - index1 + 1)
        {
            _series = series;
            _index1 = index1;
            _index2 = index2;
        }

        public override bool MoveNext()
        {
            return ++index <= _index2;
        }

        public override void Reset()
        {
            index = _index1 - 1;
        }

        public override DataEntry Current
        {
            get {
                var tick = (Tick)_series[index];
                var timeRanges = TimeRangeSelector.Get(tick.DateTime);
                if (tick.Size > 0 && timeRanges.InRange(tick.DateTime.TimeOfDay)) {
                    return new DataEntry(tick.DateTime, timeRanges, new PriceSizeItem[] { GetItem(tick) });
                }
                return null;
            }
        }
    }
}
