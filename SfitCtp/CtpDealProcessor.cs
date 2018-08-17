using System;
using System.Collections.Generic;
using System.Threading.Tasks.Dataflow;
#if CTP
using QuantBox.Sfit.Api;
#else
using QuantBox.Rohon.Api;
#endif

namespace QuantBox.XApi
{
    internal class CtpDealProcessor
    {
        #region Order Event Class
        private static class OrderEventType
        {
            public const byte NewOrder = 0;
            public const byte OrderCancel = 1;
            public const byte OrderRsp = 2;
        }
        private abstract class OrderEvent
        {
            public abstract byte TypeId { get; }
        }
        private class NewOrderEvent : OrderEvent
        {
            public readonly OrderField Order;
            public NewOrderEvent(OrderField order)
            {
                Order = order;
            }
            public override byte TypeId => OrderEventType.NewOrder;
        }
        private class CancelOrderEvent : OrderEvent
        {
            public readonly string OrderId;

            public CancelOrderEvent(string orderId)
            {
                OrderId = orderId;
            }

            public override byte TypeId => OrderEventType.OrderCancel;
        }
        private class OrderRspEvent : OrderEvent
        {
            public readonly CtpResponse Response;

            public OrderRspEvent(CtpResponse response)
            {
                Response = response;
            }

            public override byte TypeId => OrderEventType.OrderRsp;
        }
        #endregion

        private readonly CtpTradeClient _client;
        private readonly ActionBlock<OrderEvent> _action;
        private readonly OrderMap _orders;
        private readonly HashSet<string> _cancelPendings = new HashSet<string>();

        private void ReportOrder(OrderField order, ExecType execType, OrderStatus newStatus, CtpRspInfo rspInfo)
        {
            ReportOrder(order, execType, newStatus, rspInfo.ErrorID, rspInfo.ErrorID, rspInfo.ErrorMsg);
        }

        private void ReportOrder(OrderField order, ExecType execType, OrderStatus newStatus, int errorId = 0, int rawErrorId = 0, string text = "")
        {
            order.Status = newStatus;
            var report = order.Clone();
            report.ExecType = execType;
            if (!string.IsNullOrEmpty(text)) {
                report.XErrorID = errorId;
                report.RawErrorID = rawErrorId;
                report.SetText(text);
            }
            _client.Spi.ProcessRtnOrder(report);
        }

        private void OrderAction(OrderEvent e)
        {
            switch (e.TypeId) {
                case OrderEventType.NewOrder:
                    ProcessNewOrder((NewOrderEvent)e);
                    return;
                case OrderEventType.OrderCancel:
                    ProcessCancelOrder((CancelOrderEvent)e);
                    return;
            }
            var rsp = ((OrderRspEvent)e).Response;
            switch (rsp.TypeId) {
                case CtpResponseType.OnErrRtnOrderAction:
                    ProcessCancelReject(rsp.Item1.AsOrderAction, rsp.Item2);
                    break;
                case CtpResponseType.OnErrRtnOrderInsert:
                    ProcessOrderReject(rsp.Item1.AsInputOrder, rsp.Item2);
                    break;
                case CtpResponseType.OnRspOrderAction:
                    ProcessCancelReject(rsp.Item1.AsInputOrderAction, rsp.Item2);
                    break;
                case CtpResponseType.OnRspOrderInsert:
                    ProcessOrderReject(rsp.Item1.AsInputOrder, rsp.Item2);
                    break;
                case CtpResponseType.OnRtnOrder:
                    ProcessRtnOrder(rsp.Item1.AsOrder);
                    break;
                case CtpResponseType.OnRtnTrade:
                    ProcessRtnTrade(rsp.Item1.AsTrade);
                    break;
            }
        }

        private void ProcessRtnTrade(CtpTrade data)
        {
            var sysId = $"{data.ExchangeID}:{data.InstrumentID}:{data.OrderSysID}";
            if (_orders.TryGetBySysId(sysId, out var order)) {
                var trade = CtpConvert.GetTrade(data);
                trade.ID = order.ID;
                _client.Spi.ProcessRtnTrade(trade);
            }
        }

        private void ProcessRtnOrder(CtpOrder data)
        {
            var localId = $"{data.FrontID}:{data.SessionID}:{data.OrderRef}";
            if (!_orders.TryGetByLocalId(localId, out var order)) {
                return;
            }

            if (!string.IsNullOrEmpty(data.OrderSysID) && string.IsNullOrEmpty(order.OrderID)) {
                order.OrderID = $"{data.ExchangeID}:{data.InstrumentID}:{data.OrderSysID}";
                _orders.SetOrderSysId(order.OrderID, localId);
            }
            ReportOrder(order, CtpConvert.GetExecType(data), CtpConvert.GetOrderStatus(data), 0, 0, data.StatusMsg);
            if (_cancelPendings.Contains(localId)) {
                _cancelPendings.Remove(localId);
                ProcessCancelOrder(localId);
            }
        }

        #region Cancel Reject
        private void ProcessCancelReject(string localId, CtpRspInfo rspInfo)
        {
            _orders.TryGetByLocalId(localId, out var order);
            if (order != null) {
                ReportOrder(order, ExecType.CancelReject, order.Status, rspInfo);
            }
        }
        private void ProcessCancelReject(CtpOrderAction action, CtpRspInfo rspInfo)
        {
            var localId = $"{action.FrontID}:{action.SessionID}:{action.OrderRef}";
            ProcessCancelReject(localId, rspInfo);
        }
        private void ProcessCancelReject(CtpInputOrderAction action, CtpRspInfo rspInfo)
        {
            var localId = $"{action.FrontID}:{action.SessionID}:{action.OrderRef}";
            ProcessCancelReject(localId, rspInfo);
        }
        #endregion

        #region Order Reject
        private void ProcessOrderReject(string localId, CtpRspInfo rspInfo)
        {
            _orders.TryGetByLocalId(localId, out var order);
            if (order != null) {
                ReportOrder(order, ExecType.Rejected, OrderStatus.Rejected, rspInfo);
            }
        }
        private void ProcessOrderReject(CtpInputOrder input, CtpRspInfo rspInfo)
        {
            var login = _client.CtpLoginInfo;
            var localId = $"{login.FrontID}:{login.SessionID}:{input.OrderRef}";
            ProcessOrderReject(localId, rspInfo);
        }
        #endregion

        private void ProcessCancelOrder(string localId)
        {
            if (_cancelPendings.Contains(localId)) {
                return;
            }

            if (!_orders.TryGetByLocalId(localId, out var order)) {
                return;
            }

            if (string.IsNullOrEmpty(order.OrderID)) {
                _cancelPendings.Add(localId);
                return;
            }

            var action = new CtpInputOrderAction();
            (action.FrontID, action.SessionID, action.OrderRef) = GetFrontSessionItems(order.ID);
            (action.ExchangeID, action.InstrumentID, action.OrderSysID) = GetOrderSysItems(order.OrderID);
            action.ActionFlag = CtpActionFlagType.Delete;
            action.OrderActionRef = _client.GetNextRequestId();
            action.InvestorID = _client.CtpLoginInfo.UserID;
            action.BrokerID = _client.CtpLoginInfo.BrokerID;
            _client.Api.ReqOrderAction(action, _client.GetNextRequestId());
        }

        private static (string, string, string) GetOrderSysItems(string orderId)
        {
            var items = orderId.Split(':');
            return (items[0], items[1], items[2]);
        }

        private static (int, int, string) GetFrontSessionItems(string localId)
        {
            var items = localId.Split(':');
            return (int.Parse(items[0]), int.Parse(items[1]), items[2]);
        }

        private void ProcessCancelOrder(CancelOrderEvent e)
        {
            ProcessCancelOrder(e.OrderId);
        }

        private void ProcessNewOrder(NewOrderEvent e)
        {
            var data = CtpConvert.GetCtpOrder(e.Order);
            data.InvestorID = _client.CtpLoginInfo.UserID;
            data.BrokerID = _client.CtpLoginInfo.BrokerID;
            _orders.AddOrder(e.Order);
            _client.Api.ReqOrderInsert(data, _client.GetNextRequestId());
        }

        public CtpDealProcessor(CtpTradeClient client)
        {
            _client = client;
            _action = new ActionBlock<OrderEvent>((Action<OrderEvent>)OrderAction);
            _orders = new OrderMap();
        }

        public void Post(OrderField order)
        {
            _action.Post(new NewOrderEvent(order));
        }

        public void Post(string orderId)
        {
            _action.Post(new CancelOrderEvent(orderId));
        }

        public void Post(CtpResponse rsp)
        {
            _action.Post(new OrderRspEvent(rsp));
        }

        public void Close()
        {
            _action.Complete();
            _action.Completion.Wait();
        }
    }
}
