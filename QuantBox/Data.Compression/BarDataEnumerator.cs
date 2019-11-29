using SmartQuant;

namespace QuantBox.Data.Compression
{
    internal class BarDataEnumerator : DataEntryEnumerator
    {
        private readonly BarSeries _series;

        public override DataEntry Current
        {
            get {
                var bar = _series[index];

                return new DataEntry(bar.OpenDateTime, TimeRangeSelector.Get(bar.DateTime), new PriceSizeItem[4] {
                    new PriceSizeItem(bar.Open, 0),
                    new PriceSizeItem(bar.High, 0),
                    new PriceSizeItem(bar.Low, 0),
                    new PriceSizeItem(bar.Close, (int)bar.Volume, (int)bar.OpenInt, bar.GetTurnover())
                });
            }
        }

        public BarDataEnumerator(BarSeries series)
            : base(series.Count)
        {
            _series = series;
        }
    }
}
