using System;
using SmartQuant;

namespace QuantBox.Data.Compression
{
    internal class CompressedBarEventArgs : EventArgs
    {
        public Bar Bar
        {
            get;
            private set;
        }

        public CompressedBarEventArgs(Bar bar)
        {
            Bar = bar;
        }
    }
}

namespace QuantBox.Data.Compression
{
    internal abstract class BarCompressor
    {
        protected readonly Instrument inst;
        protected readonly int instrumentId;
        protected long oldBarSize;
        protected long newBarSize;
        protected Bar bar;
        private readonly TimeRangeSelector _timeRangeSelector;

        protected BarCompressor(Instrument inst)
        {
            bar = null;
            this.inst = inst;
            instrumentId = inst.Id;
            _timeRangeSelector = new TimeRangeSelector(inst);
        }

        public event EventHandler<CompressedBarEventArgs> NewCompressedBar;

        public static BarCompressor GetCompressor(Instrument inst, long oldBarSize, long newBarSize)
        {
            var compressor = new TimeBarCompressor(inst);
            compressor.oldBarSize = oldBarSize;
            compressor.newBarSize = newBarSize;
            return compressor;
        }

        public abstract void Add(DataEntry entry);

        protected void AddItemsToBar(PriceSizeItem[] items)
        {
            foreach (PriceSizeItem item in items) {
                AddItemToBar(item);
            }
        }

        protected void CreateNewBar(BarType barType, DateTime beginTime, DateTime endTime, double price)
        {
            bar = new Bar(beginTime, endTime, instrumentId, barType, newBarSize, price, price, price, price, 0L, 0L);
        }

        protected void EmitNewCompressedBar()
        {
            NewCompressedBar?.Invoke(this, new CompressedBarEventArgs(bar));
            bar = null;
        }

        public BarSeries Compress(DataEntryEnumerator enumerator)
        {
            enumerator.TimeRangeSelector = _timeRangeSelector;
            BarSeries series = new BarSeries(DataSeriesNameHelper.GetName(inst, DataObjectType.Bar, BarType.Time, newBarSize));
            NewCompressedBar += delegate (object sender, CompressedBarEventArgs args) {
                series.Add(args.Bar);
            };
            while (enumerator.MoveNext()) {
                Add(enumerator.Current);
            }
            Flush();
            return series;
        }

        private void AddItemToBar(PriceSizeItem item)
        {
            bar.Low = Math.Min(bar.Low, item.Price);
            bar.High = Math.Max(bar.High, item.Price);
            bar.Close = item.Price;
            bar.Volume += item.Size;
            bar.IncTurnover(item.Amount);
            bar.OpenInt = item.OpenInt;
        }

        private void Flush()
        {
            if (bar != null) {
                EmitNewCompressedBar();
            }
        }
    }
}