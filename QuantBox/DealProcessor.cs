using System;
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

        private OrderField CreateOrderField(Order order)
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
            field.ClientID = order.ClientID;
            field.AccountID = order.Account;
            field.StopPx = order.StopPx;
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
            report.Text = text;
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
            _provider.Logger.Info(field.DebugInfo);
            _orderHandlers[(byte)field.ExecType](field);
        }

        private void ProcessExecCancelled(OrderField field)
        {
            if (_map.TryPickCancelled(field.ID, out var record)) {
                _provider.OnMessage(CreateReport(record, (OrderStatus)field.Status, ExecType.ExecCancelled));
            }
            else if (_map.TryPickLocal(field.LocalID, out var order)) {
                _provider.OnMessage(CreateReport(new OrderRecord(order), (OrderStatus)field.Status,
                    ExecType.ExecCancelled, field.Text()));
            }
        }

        private void ProcessExecNew(OrderField field)
        {
            var record = _map.PendingToWorking(field.LocalID, field.ID);
            if (record != null) {
                _provider.OnMessage(CreateReport(record, (OrderStatus)field.Status, ExecType.ExecNew));
            }
        }

        private void ProcessExecRejected(OrderField field)
        {
            if (_map.TryPickLocal(field.LocalID, out var order)) {
                _provider.OnMessage(CreateReport(new OrderRecord(order), (OrderStatus)field.Status,
                    ExecType.ExecRejected, field.Text()));
            }
            else if (_map.TryPickRejected(field.ID, out var record)) {
                //出现超出涨跌停时，会先收到 ProcessExecNew
                _provider.OnMessage(CreateReport(record, (OrderStatus)field.Status, ExecType.ExecRejected,
                    field.Text()));
            }
        }

        private void ProcessExecPendingCancel(OrderField field)
        {
            if (_map.TryPickCancelling(field.ID, out var record)) {
                _provider.OnMessage(CreateReport(record, (OrderStatus)field.Status, ExecType.ExecPendingCancel));
            }
        }

        private void ProcessExecCancelReject(OrderField field)
        {
            if (_map.TryPickPendingCancel(field.LocalID, out var record)) {
                _provider.OnMessage(CreateReport(record, (OrderStatus)field.Status, ExecType.ExecCancelReject,
                    field.Text()));
            }
        }

        private void ProcessTrade(TradeField trade)
        {
            _map.TryPeek(trade.ID, out var record);
            if (record != null) {
                record.AddFill(trade.Price, trade.Qty);
                var status = (record.LeavesQty > 0) ? OrderStatus.PartiallyFilled : OrderStatus.Filled;
                var report = CreateReport(record, status, ExecType.ExecTrade);
                report.DateTime = trade.UpdateTime();
                report.LastPx = trade.Price;
                report.LastQty = trade.Qty;

                if (Math.Abs(trade.Commission) < double.Epsilon)
                {
                    report.Commission = _provider.GetCommission(report);
                }
                else
                {
                    report.Commission = trade.Commission;
                }

                _provider.OnMessage(report);
                if (status == OrderStatus.Filled) {
                    _map.RemoveFilled(trade.ID);
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
            if (_map.TryGetOrderId(order, out var id)) {
                error = _provider.Trader.CancelOrder(id);
                if (string.IsNullOrEmpty(error) || error == "0") {
                    _map.AddCancelPending(order);
                }
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
            _provider.Logger.Info(string.Join(",", order.Id, order.Side, order.Instrument.Symbol, order.Qty, order.Price));
            var localId = _provider.Trader.SendOrder(CreateOrderField(order));
            if (string.IsNullOrEmpty(localId)) {
                var report = CreateReport(new OrderRecord(order), OrderStatus.Rejected, ExecType.ExecRejected,
                    @"Internal Error");
                _provider.OnMessage(report);
            }
            else {
                _map.SetLocalId(localId, order);
            }
        }

        #endregion

        public DealProcessor(XProvider provider)
        {
            _provider = provider;
            InitHandler();
        }

        public void Open()
        {
            if (_orderBlock == null) {
                _orderBlock = new ActionBlock<TradingEvent>((Action<TradingEvent>)OrderEventAction);
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

        public void PostRetrunOrder(OrderField order)
        {
            _orderBlock.Post(new TradingEvent(ExecType.ExecOrderStatus, order));
        }
    }
}
