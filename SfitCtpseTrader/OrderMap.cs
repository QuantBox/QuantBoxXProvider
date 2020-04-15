using System;
using System.Collections.Generic;

namespace QuantBox.XApi
{
    internal class OrderMap
    {
        private readonly Dictionary<string, OrderField> _orders = new Dictionary<string, OrderField>();
        private readonly Dictionary<string, OrderField> _ordersBySysId = new Dictionary<string, OrderField>();
        private readonly Dictionary<string, string> _orderRefMap = new Dictionary<string, string>();

        public void AddOrder(OrderField order)
        {
            _orders[order.ID] = order;
            _orderRefMap[order.LocalID] = order.ID;
        }

        public bool TryGetById(string id, out OrderField order)
        {
            return _orders.TryGetValue(id, out order);
        }

        public bool TryGetByOrderRef(string orderRef, out OrderField order)
        {
            order = null;
            return _orderRefMap.TryGetValue(orderRef, out var id) && TryGetById(id, out order);
        }

        public bool TryGetBySysId(string orderSysId, out OrderField order)
        {
            return _ordersBySysId.TryGetValue(orderSysId, out order);
        }

        public void SetMap(OrderField order)
        {
            _ordersBySysId[order.OrderID] = order;
        }
    }
}