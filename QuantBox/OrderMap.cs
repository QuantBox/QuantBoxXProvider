using System.Collections.Generic;
using SmartQuant;

namespace QuantBox
{
    internal class OrderMap
    {
        private readonly Dictionary<string, OrderRecord> _working = new Dictionary<string, OrderRecord>();
        private readonly Dictionary<string, Order> _pendingNew = new Dictionary<string, Order>();
        private readonly Dictionary<string, OrderRecord> _pendingCancel = new Dictionary<string, OrderRecord>();
        private readonly Dictionary<int, string> _orderIds = new Dictionary<int, string>();

        public void SetLocalId(string localId, Order order)
        {
            _pendingNew.Add(localId, order);
            _orderIds[order.Id] = localId;
        }

        public OrderRecord PendingToWorking(string localId, string orderId)
        {
            if (_pendingNew.TryGetValue(localId, out Order order)) {
                _pendingNew.Remove(localId);
                var record = new OrderRecord(order);
                _working.Add(orderId, record);
                _orderIds[order.Id] = orderId;
                return record;
            }
            return null;
        }

        private bool TryPickWorking(string orderId, out OrderRecord record, bool remove = true)
        {
            if (_working.TryGetValue(orderId, out record)) {
                if (remove) {
                    _working.Remove(orderId);
                    _orderIds.Remove(record.Order.Id);
                }
                return true;
            }
            return false;
        }

        public bool TryPickLocal(string localId, out Order order)
        {
            if (_pendingNew.TryGetValue(localId, out order)) {
                _pendingNew.Remove(localId);
                _orderIds.Remove(order.Id);
                return true;
            }
            return false;
        }

        public void AddCancelPending(Order order)
        {
            var key = _orderIds[order.Id];
            if (!_working.TryGetValue(key, out OrderRecord record)) {
                record = new OrderRecord(order);
            }
            _pendingCancel[key] = record;
        }

        public void RemoveFilled(string id)
        {
            _working.Remove(id);
        }

        public bool TryPickCancelled(string id, out OrderRecord record)
        {
            return TryPickWorking(id, out record);
        }

        public bool TryPickCancelling(string id, out OrderRecord record)
        {
            return TryPickWorking(id, out record, false);
        }

        public bool TryPeek(string id, out OrderRecord record)
        {
            return TryPickWorking(id, out record, false);
        }

        public bool TryPickRejected(string id, out OrderRecord record)
        {
            return TryPickWorking(id, out record);
        }

        public bool TryPickPendingCancel(string id, out OrderRecord record)
        {
            if (_pendingCancel.TryGetValue(id, out record)) {
                _pendingCancel.Remove(id);
                return true;
            }
            return false;
        }

        public bool TryGetOrderId(Order order, out string id)
        {
            return _orderIds.TryGetValue(order.Id, out id);
        }
    }
}