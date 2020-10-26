using System;
using System.Collections;
using System.Collections.Generic;

namespace QuantBox.XApi.Native
{
    internal class SubscribedList : IEnumerable<Tuple<string, string>>
    {
        private readonly Dictionary<string, HashSet<string>> _list = new Dictionary<string, HashSet<string>>();

        public void Subscribe(string instrument, string exchange)
        {
            _list.TryGetValue(exchange, out HashSet<string> insts);
            if (insts == null) {
                insts = new HashSet<string>();
                _list.Add(exchange, insts);
            }
            if (!insts.Contains(instrument)) {
                insts.Add(instrument);
            }
        }

        public void Unsubscribe(string instrument, string exchange)
        {
            _list.TryGetValue(exchange, out HashSet<string> insts);
            if (insts == null) {
                return;
            }
            if (insts.Contains(instrument)) {
                insts.Remove(instrument);
            }
        }

        public IEnumerator<Tuple<string, string>> GetEnumerator()
        {
            foreach (var item in _list) {
                foreach (var inst in item.Value) {
                    yield return Tuple.Create(inst, item.Key);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}