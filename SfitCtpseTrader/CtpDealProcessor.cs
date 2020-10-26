using System;
using System.Collections.Generic;
using System.Threading.Tasks.Dataflow;
#if CTP || CTPSE
using QuantBox.Sfit.Api;
#elif CTPMINI
using QuantBox.SfitMini.Api;
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
        private readonly HashSet<string> _cancelPending = new HashSet<string>();
        private readonly List<CtpTrade> _tradePending = new List<CtpTrade>();

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
            _client.spi.ProcessRtnOrder(report);
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
            if (_tradePending.Count == 0) {
                return;
            }
            var list = new List<CtpTrade>(_tradePending);
            _tradePending.Clear();
            foreach (var trade in list) {
                ProcessRtnTrade(trade);
            }
        }

        private void ProcessRtnTrade(CtpTrade data)
        {
            _client.spi.ProcessLog(new LogField(LogLevel.Trace, "RtnTrade"));
            if (_orders.TryGetBySysId(data.OrderSysID, out var order)) {
                var trade = CtpConvert.GetTrade(data);
                trade.ID = order.ID;
                _client.spi.ProcessRtnTrade(trade);
            }
            else {
                _tradePending.Add(data);
            }
        }

        private void ProcessRtnOrder(CtpOrder data)
        {
            if (!_orders.TryGetByOrderRef(data.OrderRef, out var order)) {
                return;
            }

            var id = order.ID;
            if (!string.IsNullOrEmpty(data.OrderSysID) && string.IsNullOrEmpty(order.OrderID)) {
                order.OrderID = data.OrderSysID;
                order.ExchangeID = data.ExchangeID;
                _orders.SetMap(order);
                ProcessTradePending();
            }
            ReportOrder(order, CtpConvert.GetExecType(data), CtpConvert.GetOrderStatus(data), 0, 0, data.StatusMsg);
            if (_cancelPending.Contains(id)) {
                _cancelPending.Remove(id);
                ProcessCancelOrder(id);
            }
        }

        #region Cancel Reject
        private void ProcessCancelReject(string orderSysId, CtpRspInfo rspInfo)
        {
            _orders.TryGetBySysId(orderSysId, out var order);
            if (order != null) {
                ReportOrder(order, ExecType.CancelReject, order.Status, rspInfo);
            }
        }
        private void ProcessCancelReject(CtpOrderAction action, CtpRspInfo rspInfo)
        {
            ProcessCancelReject(action.OrderSysID, rspInfo);
        }
        private void ProcessCancelReject(CtpInputOrderAction action, CtpRspInfo rspInfo)
        {
            ProcessCancelReject(action.OrderSysID, rspInfo);
        }
        #endregion

        #region Order Reject
        private void ProcessOrderReject(string orderRef, CtpRspInfo rspInfo)
        {
            _orders.TryGetByOrderRef(orderRef, out var order);
            if (order != null) {
                ReportOrder(order, ExecType.Rejected, OrderStatus.Rejected, rspInfo);
            }
        }
        private void ProcessOrderReject(CtpInputOrder input, CtpRspInfo rspInfo)
        {
            ProcessOrderReject(input.OrderRef, rspInfo);
        }
        #endregion

        private void ProcessCancelOrder(string id)
        {
            if (_cancelPending.Contains(id)) {
                return;
            }

            if (!_orders.TryGetById(id, out var order)) {
                return;
            }

            if (string.IsNullOrEmpty(order.OrderID)) {
                _cancelPending.Add(id);
                return;
            }

            var action = new CtpInputOrderAction();
            action.OrderSysID = order.OrderID;
            action.ExchangeID = order.ExchangeID.ToUpper();
            action.InstrumentID = order.InstrumentID;
            action.ActionFlag = CtpActionFlagType.Delete;
            action.OrderActionRef = _client.GetNextRequestId();
            action.InvestorID = _client.ctpLoginInfo.UserID;
            action.BrokerID = _client.ctpLoginInfo.BrokerID;
            _client.api.ReqOrderAction(action, _client.GetNextRequestId());
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
                data.InvestorID = _client.ctpLoginInfo.UserID;
                data.BrokerID = _client.ctpLoginInfo.BrokerID;
                data.OrderRef = e.Order.LocalID;
                var ret = _client.api.ReqOrderInsert(data, _client.GetNextRequestId());
                if (ret == 0) {
                    return;
                }
                ProcessOrderReject(data, new CtpRspInfo {
                    ErrorID = -1, ErrorMsg = "连接中断发送失败"
                });
            }
        }

        public CtpDealProcessor(CtpTradeClient client)
        {
            _client = client;
            _action = new ActionBlock<OrderEvent>(OrderAction, DataflowHelper.SpscBlockOptions);
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
