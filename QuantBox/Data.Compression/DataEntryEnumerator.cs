using System;
using System.Collections;
using System.Collections.Generic;

namespace QuantBox.Data.Compression
{
    internal abstract class DataEntryEnumerator : IEnumerator<DataEntry>, IDisposable, IEnumerator
    {
        protected int index;
        internal TimeRangeSelector TimeRangeSelector;
        private readonly int _count;

        public abstract DataEntry Current { get; }

        object IEnumerator.Current { get { throw new NotImplementedException(); } }

        protected DataEntryEnumerator(int count)
        {
            _count = count;
            Reset();
        }

        public void Dispose()
        {
        }

        public virtual bool MoveNext()
        {
            return ++index < _count;
        }

        public virtual void Reset()
        {
            index = -1;
        }
    }
}
