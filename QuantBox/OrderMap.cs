using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SmartQuant;

namespace QuantBox
{
    internal class OrderMap : IEnumerable<OrderRecord>
    {
        private readonly Dictionary<string, OrderRecord> _working = new Dictionary<string, OrderRecord>();
        private readonly Dictionary<string, OrderRecord> _noSent = new Dictionary<string, OrderRecord>();

        public void AddNewOrder(string id, string orderId, Order order)
        {
            var record = new OrderRecord(order);
            _working.Add(id, record);
            if (string.IsNullOrEmpty(orderId)) {
                _noSent.Add(id, record);
            }
        }

        public void RemoveNoSent(string id)
        {
            _noSent.Remove(id);
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

        public List<OrderRecord> GetNoSent()
        {
            return _noSent.Values.ToList();
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