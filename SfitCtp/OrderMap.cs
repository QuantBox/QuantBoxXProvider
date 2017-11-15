using System.Collections.Generic;

namespace QuantBox.XApi
{
    internal class OrderMap
    {
        private readonly Dictionary<string, OrderField> _orders = new Dictionary<string, OrderField>();
        private readonly Dictionary<string, string> _sys2Locals = new Dictionary<string, string>();

        public void SetOrderSysId(string sysId, string localId)
        {
            _sys2Locals[sysId] = localId;
        }

        public void AddOrder(OrderField order)
        {
            _orders[order.LocalID] = order;
        }

        public bool TryGetByLocalId(string localId, out OrderField order)
        {
            return _orders.TryGetValue(localId, out order);
        }

        public bool TryGetBySysId(string sysId, out OrderField order)
        {
            if (_sys2Locals.TryGetValue(sysId, out var localId)) {
                return _orders.TryGetValue(localId, out order);
            }
            order = null;
            return false;
        }
    }
}