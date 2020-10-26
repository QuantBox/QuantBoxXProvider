using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Dataflow;
using QuantBox.XApi;
using SmartQuant;
using ExecType = SmartQuant.ExecType;
using OrderStatus = SmartQuant.OrderStatus;

namespace QuantBox
{
    internal class DealProcessor
    {
        private struct TradingEvent
        {
            public readonly ExecType Type;
            public readonly Order Order;
            public readonly TradeField Trade;
            public readonly OrderField OrderReturn;

            public TradingEvent(ExecType type)
            {
                Type = type;
                Order = null;
                Trade = null;
                OrderReturn = null;
            }

            public TradingEvent(ExecType type, Order order)
            {
                Type = type;
                Order = order;
                Trade = null;
                OrderReturn = null;
            }

            public TradingEvent(ExecType type, TradeField trade)
            {
                Type = type;
                Trade = trade;
                Order = null;
                OrderReturn = null;
            }

            public TradingEvent(ExecType type, OrderField order)
            {
                Type = type;
                OrderReturn = order;
                Trade = null;
                Order = null;
            }
        }

        private readonly XProvider _provider;
        private readonly OrderMap _map = new OrderMap();
        private ActionBlock<TradingEvent> _orderBlock;
        private delegate void OrderReturnHandler(OrderField field);
        private readonly IdArray<OrderReturnHandler> _orderHandlers = new IdArray<OrderReturnHandler>(byte.MaxValue);

        private OrderField CreateOrderField(Order order, string localId, string orderId = "")
        {
            var field = new OrderField();
            var (symbol, exchange) = _provider.GetSymbolInfo(order.Instrument);
            field.InstrumentID = symbol;
            field.ExchangeID = exchange;
            field.Price = order.Price;
            field.Qty = order.Qty;
            field.TimeInForce = (XApi.TimeInForce)order.TimeInForce;
            field.Type = (XApi.OrderType)order.Type;
            field.HedgeFlag = Convertor.GetHedgeFlag(order, _provider.DefaultHedgeFlag);
            field.Side = Convertor.GetSide(order);
            field.OpenClose = order.GetOpenClose();
            if (field.OpenClose == OpenCloseType.Open
                && field.Side == XApi.OrderSide.Sell
                && order.SubSide == SubSide.Undefined) {
                order.SetSubSide(SubSide.SellShort);
            }
            field.ClientID = order.Account;
            field.AccountID = order.Account;
            field.StopPx = order.StopPx;
            field.ID = GetOrderId(order);
            field.LocalID = localId;
            if (!string.IsNullOrEmpty(orderId)) {
                field.OrderID = orderId;
                field.ExchangeID = order.Instrument.Exchange;
                field.Status = XApi.OrderStatus.New;
            }
            else {
                field.Status = XApi.OrderStatus.NotSent;
            }
            return field;
        }

        private static ExecutionReport CreateReport(OrderRecord record, OrderStatus ordStatus, ExecType execType, string text = "")
        {
            var report = new ExecutionReport(record.Order);
            report.DateTime = DateTime.Now;
            report.AvgPx = record.AvgPx;
            report.CumQty = record.CumQty;
            report.LeavesQty = record.LeavesQty;
            report.OrdStatus = ordStatus;
            report.ExecType = execType;
            report.Text = text == "" ? record.Order.Text : text;
            return report;
        }

        #region ProcessOrderReturn

        private void InitHandler()
        {
            void DefaultHandler(OrderField field)
            {
            }

            for (var i = 0; i < byte.MaxValue; i++) {
                _orderHandlers[i] = DefaultHandler;
            }
            _orderHandlers[(byte)ExecType.ExecNew] = ProcessExecNew;
            _orderHandlers[(byte)ExecType.ExecCancelled] = ProcessExecCancelled;
            _orderHandlers[(byte)ExecType.ExecRejected] = ProcessExecRejected;
            _orderHandlers[(byte)ExecType.ExecPendingCancel] = ProcessExecPendingCancel;
            _orderHandlers[(byte)ExecType.ExecCancelReject] = ProcessExecCancelReject;
        }

        private void ProcessReturnOrder(OrderField field)
        {
            _provider.logger.Info(field.DebugInfo);
            _orderHandlers[(byte)field.ExecType](field);
        }

        private void ProcessExecCancelled(OrderField field)
        {
            if (_map.TryGetOrder(field.ID, out var record)) {
                _provider.OnMessage(CreateReport(record, (OrderStatus)field.Status, ExecType.ExecCancelled, field.Text()));
                _map.RemoveDone(field.ID);
            }
        }

        private void ProcessExecNew(OrderField field)
        {
            if (_map.TryGetOrder(field.ID, out var record)) {
                _map.RemoveNoSent(field.ID);
                (string localId, string orderId) = GetProviderOrderId(record.Order);
                if (string.IsNullOrEmpty(orderId)) {
                    record.Order.ProviderOrderId = $"{localId}_{field.OrderID}";
                    _provider.OnMessage(CreateReport(record, (OrderStatus)field.Status, ExecType.ExecNew));
                }
            }
        }

        private void ProcessExecRejected(OrderField field)
        {
            if (_map.TryGetOrder(field.ID, out var record)) {
                var report = CreateReport(record, (OrderStatus)field.Status, ExecType.ExecRejected, field.Text());
                report.SetErrorId(field.XErrorID, field.RawErrorID);
                _provider.OnMessage(report);
                _map.RemoveDone(field.ID);
            }
        }

        private void ProcessExecPendingCancel(OrderField field)
        {
            if (_map.TryGetOrder(field.ID, out var record)) {
                _provider.OnMessage(CreateReport(record, (OrderStatus)field.Status, ExecType.ExecPendingCancel));
            }
        }

        private void ProcessExecCancelReject(OrderField field)
        {
            if (_map.TryGetOrder(field.ID, out var record)) {
                _provider.OnMessage(CreateReport(record, (OrderStatus)field.Status, ExecType.ExecCancelReject,
                    field.Text()));
            }
        }

        private void ProcessTrade(TradeField trade)
        {
            _map.TryGetOrder(trade.ID, out var record);
            if (record != null) {
                record.AddFill(trade.Price, trade.Qty);
                var status = record.LeavesQty > 0 ? OrderStatus.PartiallyFilled : OrderStatus.Filled;
                var report = CreateReport(record, status, ExecType.ExecTrade);
                report.ExecId = trade.TradeID;
                report.DateTime = trade.UpdateTime();
                if (report.DateTime.Date != _provider.trader.TradingDay) {
                    report.TransactTime = _provider.trader.TradingDay.Add(report.DateTime.TimeOfDay);
                }
                else {
                    report.TransactTime = report.DateTime;
                }

                report.LastPx = trade.Price;
                report.LastQty = trade.Qty;

                if (Math.Abs(trade.Commission) < double.Epsilon) {
                    report.Commission = _provider.GetCommission(report);
                }
                else {
                    report.Commission = trade.Commission;
                }

                _provider.OnMessage(report);
                if (status == OrderStatus.Filled) {
                    _map.RemoveDone(trade.ID);
                }
            }
        }

        #endregion

        #region ProcessCommand

        private void OrderEventAction(TradingEvent e)
        {
            try {
                switch (e.Type) {
                    case ExecType.ExecNew:
                        ProcessSend(e.Order);
                        break;
                    case ExecType.ExecTrade:
                        ProcessTrade(e.Trade);
                        break;
                    case ExecType.ExecCancelled:
                        ProcessCancel(e.Order);
                        break;
                    case ExecType.ExecOrderStatus:
                        ProcessReturnOrder(e.OrderReturn);
                        break;
                }
            }
            catch (Exception ex) {
                _provider.OnProviderError(-1, ex.Message);
            }
        }

        private void ProcessCancel(Order order)
        {
            string error;
            if (_map.OrderExist(GetOrderId(order))) {
                error = _provider.trader.CancelOrder(GetOrderId(order));
            }
            else {
                error = @"Can't Found Order";
            }

            if (!string.IsNullOrEmpty(error)) {
                _provider.OnMessage(CreateReport(new OrderRecord(order), order.Status, ExecType.ExecCancelReject,
                    error));
            }
        }

        private void ProcessSend(Order order)
        {
            _provider.logger.Info(string.Join(",", order.Id, order.Side, order.Instrument.Symbol, order.Qty, order.Price));
            (string localId, string orderId) = GetProviderOrderId(order);
            _map.AddNewOrder(GetOrderId(order), orderId, order);
            _provider.trader.SendOrder(CreateOrderField(order, localId, orderId));
        }

        #endregion

        public DealProcessor(XProvider provider)
        {
            _provider = provider;
            InitHandler();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string GetOrderId(Order order)
        {
            return order.ClOrderId;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static (string localId, string orderId) GetProviderOrderId(Order order)
        {
            var id = order.ProviderOrderId;
            return id.Length == XProvider.LocalIdLength
                ? (id, string.Empty)
                : (id.Substring(0, XProvider.LocalIdLength), id.Substring(XProvider.LocalIdLength + 1));
        }
        
        public void Open()
        {
            if (_orderBlock == null) {
                _orderBlock = new ActionBlock<TradingEvent>(OrderEventAction, DataflowHelper.SpscBlockOptions);
            }
        }

        public void Close()
        {
            if (_orderBlock == null)
                return;
            _orderBlock.Complete();
            _orderBlock.Completion.Wait();
            _orderBlock = null;
        }

        public void PostNewOrder(Order order)
        {
            _orderBlock.Post(new TradingEvent(ExecType.ExecNew, order));
        }

        public void PostCancelOrder(Order order)
        {
            _orderBlock.Post(new TradingEvent(ExecType.ExecCancelled, order));
        }

        public void PostTrade(TradeField trade)
        {
            _orderBlock.Post(new TradingEvent(ExecType.ExecTrade, trade));
        }

        public void PostReturnOrder(OrderField order)
        {
            _orderBlock.Post(new TradingEvent(ExecType.ExecOrderStatus, order));
        }
    }
}
