using System;
using System.Collections.Generic;

namespace QuantBox.XApi
{
    internal class OrderMap
    {
        private readonly Dictionary<string, OrderField> _orders = new Dictionary<string, OrderField>();
        private readonly Dictionary<string, OrderField> _ordersBySysId = new Dictionary<string, OrderField>();

        public void AddOrder(OrderField order)
        {
            _orders[order.ID] = order;
        }

        public bool OrderExist(string id)
        {
            return TryGetById(id, out _);
        }

        public bool TryGetById(string id, out OrderField order)
        {
            return _orders.TryGetValue(id, out order);
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