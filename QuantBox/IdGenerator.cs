using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Skyline;

namespace QuantBox
{
    public interface IIdGenerator
    {
        long Next();
    }

    public class SyncTickIdGen : IIdGenerator
    {
        private const int Used = 1;
        private const int Unused = 0;

        private int _flag;
        private long _last;

        public SyncTickIdGen()
        {
            _last = DateTime.Now.Ticks;
        }
        public long Next()
        {
            while (Interlocked.CompareExchange(ref _flag, Used, Unused) != Used) {
                Thread.Sleep(0);
            }
            var ticks = DateTime.Now.Ticks;
            while (_last == ticks) {
                ticks = DateTime.Now.Ticks;
            }
            _last = ticks;
            Interlocked.Exchange(ref _flag, Unused);
            return ticks;
        }
    }

    public class TickIdGen : IIdGenerator
    {
        private long _last;

        public TickIdGen()
        {
            _last = DateTime.Now.Ticks;
        }
        public long Next()
        {
            var ticks = DateTime.Now.Ticks;
            while (_last == ticks) {
                ticks = DateTime.Now.Ticks;
            }
            _last = ticks;
            return ticks;
        }
    }

    public class IdGenerator : IIdGenerator
    {
        private long _value;

        public IdGenerator(int baseValue, int seriesValue)
        {
            _value = new MakeLong(baseValue, seriesValue).Value;
        }

        public long Next() => Interlocked.Increment(ref _value);
    }
}
