using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SmartQuant;

namespace QuantBox
{
    internal class OrderMap : IEnumerable<OrderRecord>
    {
        private readonly Dictionary<string, OrderRecord> _working = new Dictionary<string, OrderRecord>();
        private readonly Dictionary<string, OrderRecord> _noSends = new Dictionary<string, OrderRecord>();

        public void AddNewOrder(string id, Order order)
        {
            var record = new OrderRecord(order);
            _working.Add(id, record);
            if (string.IsNullOrEmpty(order.ProviderOrderId)) {
                _noSends.Add(id, record);
            }
        }

        public void RemoveNoSend(string id)
        {
            _noSends.Remove(id);
        }

        public void RemoveDone(string id)
        {
            _working.Remove(id);
        }

        public bool OrderExist(string id)
        {
            return TryGetOrder(id, out _);
        }

        public bool TryGetOrder(string id, out OrderRecord record)
        {
            return _working.TryGetValue(id, out record);
        }

        public List<OrderRecord> GetNoSend()
        {
            return _noSends.Values.ToList();
        }

        public IEnumerator<OrderRecord> GetEnumerator()
        {
            return _working.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}