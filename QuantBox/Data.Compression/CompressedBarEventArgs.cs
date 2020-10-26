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