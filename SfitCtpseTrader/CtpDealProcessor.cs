using System;
using System.Collections.Generic;
using System.Threading.Tasks.Dataflow;
#if CTP || CTPSE
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
            public readonly string Id;

            public CancelOrderEvent(string id)
            {
                Id = id;
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
        private readonly HashSet<string> _cancelPendings = new HashSet<string>(10);
        private readonly List<CtpTrade> _tradePendings = new List<CtpTrade>(10);

        private void ReportOrder(OrderField order, ExecType execType, OrderStatus newStatus, CtpRspInfo rspInfo)
        {
            ReportOrder(order, execType, newStatus, rspInfo.ErrorID, rspInfo.ErrorID, rspInfo.ErrorMsg);
        }

        private void ReportOrder(OrderField order, ExecType execType, OrderStatus newStatus,
            int errorId = 0, int rawErrorId = 0, string text = "")
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

        private void ProcessTradePending()
        {
            if (_tradePendings.Count == 0) {
                return;
            }
            var list = new List<CtpTrade>(_tradePendings);
            _tradePendings.Clear();
            foreach (var trade in list) {
                ProcessRtnTrade(trade);
            }
        }

        private void ProcessRtnTrade(CtpTrade data)
        {
            if (_orders.TryGetBySysId(data.OrderSysID, out var order)) {
                var trade = CtpConvert.GetTrade(data);
                trade.ID = order.ID;
                _client.Spi.ProcessRtnTrade(trade);
            }
            else {
                _tradePendings.Add(data);
            }
        }

        private void ProcessRtnOrder(CtpOrder data)
        {
            var id = CtpConvert.GetId(data);
            if (!_orders.TryGetById(id, out var order)) {
                return;
            }
            if (!string.IsNullOrEmpty(data.OrderSysID) && string.IsNullOrEmpty(order.OrderID)) {
                order.OrderID = data.OrderSysID;
                order.ExchangeID = data.ExchangeID;
                _orders.SetMap(order);
                ProcessTradePending();
            }
            ReportOrder(order, CtpConvert.GetExecType(data), CtpConvert.GetOrderStatus(data), 0, 0, data.StatusMsg);
            if (_cancelPendings.Contains(id)) {
                _cancelPendings.Remove(id);
                ProcessCancelOrder(id);
            }
        }

        #region Cancel Reject
        private void ProcessCancelReject(string localId, CtpRspInfo rspInfo)
        {
            _orders.TryGetById(localId, out var order);
            if (order != null) {
                ReportOrder(order, ExecType.CancelReject, order.Status, rspInfo);
            }
        }
        private void ProcessCancelReject(CtpOrderAction action, CtpRspInfo rspInfo)
        {
            ProcessCancelReject(action.OrderRef, rspInfo);
        }
        private void ProcessCancelReject(CtpInputOrderAction action, CtpRspInfo rspInfo)
        {
            ProcessCancelReject(action.OrderRef, rspInfo);
        }
        #endregion

        #region Order Reject
        private void ProcessOrderReject(string id, CtpRspInfo rspInfo)
        {
            _orders.TryGetById(id, out var order);
            if (order != null) {
                ReportOrder(order, ExecType.Rejected, OrderStatus.Rejected, rspInfo);
            }
        }
        private void ProcessOrderReject(CtpInputOrder input, CtpRspInfo rspInfo)
        {
            var login = _client.CtpLoginInfo;
            var id = CtpConvert.GetId(input, login);
            ProcessOrderReject(id, rspInfo);
        }
        #endregion

        private void ProcessCancelOrder(string id)
        {
            if (_cancelPendings.Contains(id)) {
                return;
            }

            if (!_orders.TryGetById(id, out var order)) {
                return;
            }

            if (string.IsNullOrEmpty(order.OrderID)) {
                _cancelPendings.Add(id);
                return;
            }

            var action = new CtpInputOrderAction();
            (action.FrontID, action.SessionID, action.OrderRef) = CtpConvert.ParseId(order.ID);
            action.OrderSysID = order.OrderID;
            action.ExchangeID = order.ExchangeID.ToUpper();
            action.InstrumentID = order.InstrumentID;
            action.ActionFlag = CtpActionFlagType.Delete;
            action.OrderActionRef = _client.GetNextRequestId();
            action.InvestorID = _client.CtpLoginInfo.UserID;
            action.BrokerID = _client.CtpLoginInfo.BrokerID;
            _client.Api.ReqOrderAction(action, _client.GetNextRequestId());
        }

        private void ProcessCancelOrder(CancelOrderEvent e)
        {
            ProcessCancelOrder(e.Id);
        }

        private void ProcessNewOrder(NewOrderEvent e)
        {
            _orders.AddOrder(e.Order);
            if (e.Order.Status == OrderStatus.NotSent) {
                var data = CtpConvert.GetInputOrder(e.Order);
                data.InvestorID = _client.CtpLoginInfo.UserID;
                data.BrokerID = _client.CtpLoginInfo.BrokerID;
                _client.Api.ReqOrderInsert(data, _client.GetNextRequestId());
            }
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

        public void Post(string id)
        {
            _action.Post(new CancelOrderEvent(id));
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
