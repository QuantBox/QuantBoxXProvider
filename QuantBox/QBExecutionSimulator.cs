using System;
using System.Collections.Generic;
using System.Threading;
using NLog;
using SmartQuant;

namespace QuantBox
{
    public class QBExecutionSimulator : Provider, IExecutionSimulator
    {
        private class SimulatorExecutionReport
        {
            internal readonly OrderStatus ordStatus;

            internal readonly double avgPx;

            internal readonly double cumQty;

            internal readonly double leavesQty;

            internal double commission;

            public SimulatorExecutionReport(ExecutionReport report)
            {
                ordStatus = report.OrdStatus;
                avgPx = report.AvgPx;
                cumQty = report.CumQty;
                leavesQty = report.LeavesQty;
                commission = report.Commission;
            }
        }

        private readonly IdArray<IDataProvider> _strategyDataProviders = new IdArray<IDataProvider>();
        private readonly IdArray<List<Order>> _orders = new IdArray<List<Order>>();
        private readonly IdArray<int> _vwapFormats = new IdArray<int>();
        private readonly Dictionary<Order, double> _partiallyFilledOrders = new Dictionary<Order, double>();
        private readonly List<Order> _ordersToRemove = new List<Order>();
        private readonly Random _random = new Random();
        private readonly IdArray<SimulatorExecutionReport> _reports = new IdArray<SimulatorExecutionReport>();
        private readonly List<Order> _auctions = new List<Order>();
        private readonly Logger _logger = LogManager.GetLogger("qb_exec_sim");

        private IDataProvider GetDataProvider(Order order)
        {
            IDataProvider result = null;
            if (order.strategyId >= 0) {
                if (_strategyDataProviders[order.strategyId] == null) {
                    _strategyDataProviders[order.strategyId] = Get();
                }
                result = _strategyDataProviders[order.strategyId];
            }
            return result;

            IDataProvider Get()
            {
                var s_ = framework.StrategyManager_.FindStrategy(order.StrategyId);
                if (s_ != null) {
                    return s_.DataProvider;
                }
                var s = framework.StrategyManager.FindStrategy(order.StrategyId);
                return s?.DataProvider;
            }
        }

        private bool IsProviderPassed(Order order, int providerId)
        {
            IDataProvider dataProvider = GetDataProvider(order);
            if (dataProvider != null && dataProvider.Id != 1) {
                return dataProvider.Id == providerId;
            }
            return true;
        }

        private void RemoveDoneOrders()
        {
            if (_ordersToRemove.Count > 0) {
                foreach (Order item in _ordersToRemove) {
                    _orders[item.Instrument.Id].Remove(item);
                    _partiallyFilledOrders.Remove(item);
                }
                _ordersToRemove.Clear();
            }
        }

        private bool OnBuyLimit(Order order, Tick tick)
        {
            if (tick.Price <= order.Price) {
                if (UseProbability && tick.Price == order.Price && _random.NextDouble() < Probability) {
                    return false;
                }
                if (FillAtLimitPrice) {
                    Fill(order, order.Price, tick.Size);
                }
                else {
                    Fill(order, tick.Price, tick.Size);
                }
                return true;
            }
            return false;
        }
        private bool OnSellLimit(Order order, Tick tick)
        {
            if (tick.Price >= order.Price) {
                if (UseProbability && tick.Price == order.Price && _random.NextDouble() < Probability) {
                    return false;
                }
                if (FillAtLimitPrice) {
                    Fill(order, order.Price, tick.Size);
                }
                else {
                    Fill(order, tick.Price, tick.Size);
                }
                return true;
            }
            return false;
        }
        private bool OnBuyStop(Order order, Tick tick)
        {
            if (tick.Price >= order.StopPx) {
                if (FillAtStopPrice) {
                    Fill(order, order.StopPx, tick.Size);
                    return true;
                }
                order.SetOrderType(OrderType.Market);
            }
            return false;
        }
        private bool OnBuyStopLimit(Order order, Tick tick)
        {
            if (tick.Price >= order.StopPx) {
                order.SetOrderType(OrderType.Limit);
            }
            return false;
        }
        private bool OnSellStop(Order order, Tick tick)
        {
            if (tick.Price <= order.StopPx) {
                if (FillAtStopPrice) {
                    Fill(order, order.StopPx, tick.Size);
                    return true;
                }
                order.SetOrderType(OrderType.Market);
            }
            return false;
        }
        private bool OnSellStopLimit(Order order, Tick tick)
        {
            if (tick.Price <= order.StopPx) {
                order.SetOrderType(OrderType.Limit);
            }
            return false;
        }
        private bool OnLevel2(Order order, Level2Snapshot snapshot)
        {
            if (CheckDataProvider && !IsProviderPassed(order, snapshot.ProviderId)) {
                return false;
            }
            bool result = false;
            if (order.Side == OrderSide.Sell) {
                for (int i = 0; i < snapshot.Bids.Length; i++) {
                    bool flag = false;
                    if (order.LeavesQty > 0.0) {
                        flag = OnBid(order, snapshot.Bids[i]);
                    }
                    if (!flag) {
                        break;
                    }
                    result = true;
                }
            }
            else if (order.Side == OrderSide.Buy) {
                for (int i = 0; i < snapshot.Asks.Length; i++) {
                    bool flag2 = false;
                    if (order.LeavesQty > 0.0) {
                        flag2 = OnAsk(order, snapshot.Asks[i]);
                    }
                    if (!flag2) {
                        break;
                    }
                    result = true;
                }
            }
            return result;
        }
        private bool OnAsk(Order order, Ask ask)
        {
            if (CheckDataProvider && !IsProviderPassed(order, ask.ProviderId)) {
                return false;
            }
            if (order.Side == OrderSide.Buy) {
                while (true) {
                    switch (order.Type) {
                        case OrderType.Market:
                        case OrderType.Pegged:
                            Fill(order, ask.Price, ask.Size);
                            return true;
                        case OrderType.Limit:
                            if (OnBuyLimit(order, ask)) {
                                return true;
                            }
                            break;
                        case OrderType.Stop:
                            if (OnBuyStop(order, ask)) {
                                return true;
                            }
                            if (order.Type != OrderType.Stop) {
                                continue;
                            }
                            break;
                        case OrderType.StopLimit:
                            if (OnBuyStopLimit(order, ask)) {
                                return true;
                            }
                            if (order.Type != OrderType.Stop) {
                                continue;
                            }
                            break;
                    }
                    break;
                }
            }
            return false;
        }
        private bool OnBid(Order order, Bid bid)
        {
            if (CheckDataProvider && !IsProviderPassed(order, bid.ProviderId)) {
                return false;
            }
            if (order.Side == OrderSide.Sell) {
                while (true) {
                    switch (order.Type) {
                        case OrderType.Market:
                        case OrderType.Pegged:
                            Fill(order, bid.Price, bid.Size);
                            return true;
                        case OrderType.Limit:
                            if (OnSellLimit(order, bid)) {
                                return true;
                            }
                            break;
                        case OrderType.Stop:
                            if (OnSellStop(order, bid)) {
                                return true;
                            }
                            if (order.Type != OrderType.Stop) {
                                continue;
                            }
                            break;
                        case OrderType.StopLimit:
                            if (OnSellStopLimit(order, bid)) {
                                return true;
                            }
                            if (order.Type != OrderType.Stop) {
                                continue;
                            }
                            break;
                    }
                    break;
                }
            }
            return false;
        }
        private bool OnTrade(Order order, Trade trade)
        {
            if (CheckDataProvider && !IsProviderPassed(order, trade.ProviderId)) {
                return false;
            }
            while (true) {
                switch (order.Type) {
                    case OrderType.Market:
                    case OrderType.Pegged:
                        Fill(order, trade.Price, trade.Size);
                        return true;
                    case OrderType.Limit:
                        switch (order.Side) {
                            case OrderSide.Buy:
                                if (OnBuyLimit(order, trade)) {
                                    return true;
                                }
                                break;
                            case OrderSide.Sell:
                                if (OnSellLimit(order, trade)) {
                                    return true;
                                }
                                break;
                        }
                        break;
                    case OrderType.Stop:
                        switch (order.Side) {
                            case OrderSide.Buy:
                                if (OnBuyStop(order, trade)) {
                                    return true;
                                }
                                if (order.Type != OrderType.Stop) {
                                    continue;
                                }
                                break;
                            case OrderSide.Sell:
                                if (OnSellStop(order, trade)) {
                                    return true;
                                }
                                if (order.Type != OrderType.Stop) {
                                    continue;
                                }
                                break;
                        }
                        break;
                    case OrderType.StopLimit:
                        switch (order.Side) {
                            case OrderSide.Buy:
                                if (OnBuyStopLimit(order, trade)) {
                                    return true;
                                }
                                if (order.Type != OrderType.Stop) {
                                    continue;
                                }
                                break;
                            case OrderSide.Sell:
                                if (OnSellStopLimit(order, trade)) {
                                    return true;
                                }
                                if (order.Type != OrderType.Stop) {
                                    continue;
                                }
                                break;
                        }
                        break;
                }
                break;
            }
            return false;
        }
        private bool OnBar(Order order, Bar bar)
        {
            if (CheckDataProvider && !IsProviderPassed(order, bar.ProviderId)) {
                return false;
            }
            while (true) {
                switch (order.Type) {
                    case OrderType.Market:
                    case OrderType.Pegged:
                        Fill(order, GetBarPrice(order.Instrument, bar), (int)bar.Volume);
                        return true;
                    case OrderType.Limit:
                        switch (order.Side) {
                            case OrderSide.Buy:
                                if (bar.Low <= order.Price) {
                                    if (UseProbability && bar.Low == order.Price && _random.NextDouble() < Probability) {
                                        return false;
                                    }
                                    if (FillAtLimitPrice) {
                                        Fill(order, order.Price, (int)bar.Volume);
                                    }
                                    else {
                                        Fill(order, GetBarPrice(order.Instrument, bar), (int)bar.Volume);
                                    }
                                    return true;
                                }
                                break;
                            case OrderSide.Sell:
                                if (bar.High >= order.Price) {
                                    if (UseProbability && bar.High == order.Price && _random.NextDouble() < Probability) {
                                        return false;
                                    }
                                    if (FillAtLimitPrice) {
                                        Fill(order, order.Price, (int)bar.Volume);
                                    }
                                    else {
                                        Fill(order, GetBarPrice(order.Instrument, bar), (int)bar.Volume);
                                    }
                                    return true;
                                }
                                break;
                        }
                        break;
                    case OrderType.Stop:
                        switch (order.Side) {
                            case OrderSide.Buy:
                                if (bar.High >= order.StopPx) {
                                    if (FillAtStopPrice) {
                                        Fill(order, order.StopPx, (int)bar.Volume);
                                        return true;
                                    }
                                    order.SetOrderType(OrderType.Market);
                                    continue;
                                }
                                break;
                            case OrderSide.Sell:
                                if (bar.Low <= order.StopPx) {
                                    if (FillAtStopPrice) {
                                        Fill(order, order.StopPx, (int)bar.Volume);
                                        return true;
                                    }
                                    order.SetOrderType(OrderType.Market);
                                    continue;
                                }
                                break;
                        }
                        break;
                    case OrderType.StopLimit:
                        switch (order.Side) {
                            case OrderSide.Buy:
                                if (bar.High >= order.StopPx) {
                                    order.SetOrderType(OrderType.Limit);
                                    continue;
                                }
                                break;
                            case OrderSide.Sell:
                                if (bar.Low <= order.StopPx) {
                                    order.SetOrderType(OrderType.Limit);
                                    continue;
                                }
                                break;
                        }
                        break;
                }
                break;
            }
            return false;
        }

        private double GetBarPrice(Instrument inst, Bar bar)
        {
            var price = FillAtVWap ? bar.VWap() : 0;
            if (double.IsNaN(price)) {
                _logger.Debug($"{inst.Symbol},{bar.DateTime:yyyyMMdd HH:mm:ss},{bar.VWap()},{bar.Volume},{inst.Factor}");
            }
            if (double.IsNaN(price) || price == 0) {
                price = bar.Close;
            }
            else {
                if (_vwapFormats[bar.InstrumentId] > 0) {
                    price = Math.Round(price, _vwapFormats[bar.InstrumentId]);
                }
            }
            return price;
        }

        private void Reject(Order order, string rejectText)
        {
            var report = new ExecutionReport(order);
            report.DateTime = framework.Clock.DateTime;
            report.ExecType = ExecType.ExecRejected;
            report.OrdStatus = OrderStatus.Rejected;
            report.Text = rejectText;
            EmitExecutionReport(report, Queued);
        }

        private bool IsDone(OrderStatus status)
        {
            bool result = false;
            switch (status) {
                case OrderStatus.Rejected:
                case OrderStatus.Filled:
                case OrderStatus.Cancelled:
                case OrderStatus.Expired:
                    result = true;
                    break;
            }
            return result;
        }
        private void ReplaceReject(Order order, string rejectText)
        {
            SimulatorExecutionReport simReport = _reports[order.Id];
            ExecutionReport report = new ExecutionReport(order);
            report.DateTime = framework.Clock.DateTime;
            report.ExecType = ExecType.ExecReplaceReject;
            report.OrdStatus = simReport.ordStatus;
            report.CumQty = simReport.cumQty;
            report.LeavesQty = simReport.leavesQty;
            report.AvgPx = simReport.avgPx;
            report.Text = rejectText;
            EmitExecutionReport(report, Queued);
        }

        private void Replace(ExecutionCommand command)
        {
            Order order = command.Order;
            order.SetOrderStatus(OrderStatus.PendingReplace);
            if (_reports[order.Id] != null && IsDone(_reports[order.Id].ordStatus)) {
                ReplaceReject(order, "Order already done");
                return;
            }
            ExecutionReport report = new ExecutionReport(command);
            report.DateTime = framework.Clock.DateTime;
            report.ExecType = ExecType.ExecReplace;
            report.OrdStatus = OrderStatus.Replaced;
            report.CumQty = order.CumQty;
            report.LastQty = 0.0;
            report.LeavesQty = command.Qty - order.CumQty;
            report.LastPx = 0.0;
            report.AvgPx = 0.0;
            _reports[order.Id] = new SimulatorExecutionReport(report);
            EmitExecutionReport(report, Queued);
        }
        private void CancelReject(Order order, string rejectText)
        {
            SimulatorExecutionReport simReport = _reports[order.Id];
            ExecutionReport report = new ExecutionReport(order);
            report.DateTime = framework.Clock.DateTime;
            report.ExecType = ExecType.ExecCancelReject;
            report.OrdStatus = simReport.ordStatus;
            report.CumQty = simReport.cumQty;
            report.LeavesQty = simReport.leavesQty;
            report.AvgPx = simReport.avgPx;
            report.Text = rejectText;
            EmitExecutionReport(report, Queued);
        }
        private void Cancel(Order order)
        {
            order.SetOrderStatus(OrderStatus.PendingCancel);
            if (_reports[order.Id] != null && IsDone(_reports[order.Id].ordStatus)) {
                CancelReject(order, "Order already done");
                return;
            }
            _orders[order.Instrument.Id].Remove(order);
            ExecutionReport report = new ExecutionReport(order);
            report.DateTime = framework.Clock.DateTime;
            report.ExecType = ExecType.ExecCancelled;
            report.OrdStatus = OrderStatus.Cancelled;
            report.CumQty = order.CumQty;
            report.LastQty = 0.0;
            report.LeavesQty = order.LeavesQty;
            report.LastPx = 0.0;
            report.AvgPx = 0.0;
            _reports[order.Id] = new SimulatorExecutionReport(report);
            EmitExecutionReport(report, Queued);
        }

        private bool OnAucFill(Order order)
        {
            if (order.Type == OrderType.Limit) {
                int instrumentId = order.Instrument.Id;
                if (FillOnQuote) {
                    Ask ask = framework.DataManager.GetAsk(instrumentId);
                    if (ask != null && OnAsk(order, ask)) {
                        return true;
                    }
                    Bid bid = framework.DataManager.GetBid(instrumentId);
                    if (bid != null && OnBid(order, bid)) {
                        return true;
                    }
                }
                if (FillOnTrade) {
                    Trade trade = framework.DataManager.GetTrade(instrumentId);
                    if (trade != null && OnTrade(order, trade)) {
                        return true;
                    }
                }
                if (FillOnBar) {
                    Bar bar = framework.DataManager.GetBar(instrumentId);
                    if (BarFilter.Count != 0 && !BarFilter.Contains(bar.Type, bar.Size)) {
                        return false;
                    }
                    if (bar != null && OnBar(order, bar)) {
                        return true;
                    }
                }
                if (FillOnLevel2) {
                    Level2Snapshot snapshot = framework.DataManager.GetAggregatedSnapshot(instrumentId);
                    if (snapshot != null) {
                        return OnLevel2(order, snapshot);
                    }
                }
            }
            return false;
        }

        private void OnAuction1Reminder(DateTime dateTime, object data)
        {
            for (int num = _auctions.Count - 1; num >= 0; num--) {
                Order order = _auctions[num];
                if (_orders[order.Instrument.Id] == null) {
                    _orders[order.Instrument.Id] = new List<Order>();
                }
                _orders[order.Instrument.Id].Add(order);
                OnAucFill(order);
                _auctions.RemoveAt(num);
            }
        }

        private void OnAuction2Reminder(DateTime dateTime, object data)
        {
            for (int num = _auctions.Count - 1; num >= 0; num--) {
                Order order = _auctions[num];
                if (_orders[order.Instrument.Id] == null) {
                    _orders[order.Instrument.Id] = new List<Order>();
                }
                _orders[order.Instrument.Id].Add(order);
                if (!OnAucFill(order)) {
                    Cancel(order);
                }
                _auctions.RemoveAt(num);
            }
        }

        private void DoSend(ExecutionCommand command)
        {
            Order order = command.Order;
            if (order.Qty == 0.0) {
                Reject(order, "Order amount can not be zero");
                return;
            }
            if (CheckSubPositions) {
                Position position = order.Portfolio.GetPosition(order.Instrument);
                if (order.Side == OrderSide.Sell && order.SubSide != SubSide.SellShort && position.LongPositionQty < order.Qty) {
                    Reject(order, "Order amount greater than amount of long position");
                    return;
                }
                if (order.Side == OrderSide.Buy && order.SubSide == SubSide.BuyCover && position.ShortPositionQty < order.Qty) {
                    Reject(order, "Order amount greater than amount of short position");
                    return;
                }
            }
            SetVWapFormat(order.Instrument);
            ExecutionReport report = new ExecutionReport(command);
            report.DateTime = framework.Clock.DateTime;
            report.ExecType = ExecType.ExecNew;
            report.OrdStatus = OrderStatus.New;
            report.CumQty = 0.0;
            report.LastQty = 0.0;
            report.LeavesQty = order.Qty;
            report.LastPx = 0.0;
            report.AvgPx = 0.0;
            _reports[order.Id] = new SimulatorExecutionReport(report);
            EmitExecutionReport(report, Queued);
            if (order.TimeInForce == TimeInForce.AUC) {
                _auctions.Add(order);
                if (_auctions.Count == 1) {
                    framework.Clock.AddReminder(OnAuction1Reminder, framework.Clock.DateTime.Date.Add(Auction1));
                    framework.Clock.AddReminder(OnAuction2Reminder, framework.Clock.DateTime.Date.Add(Auction2));
                }
                return;
            }
            int instrumentId = order.Instrument.Id;
            if (_orders[instrumentId] == null) {
                _orders[instrumentId] = new List<Order>();
            }
            _orders[instrumentId].Add(order);
            if (((order.Type == OrderType.Market || order.Type == OrderType.Pegged) && FillMarketOnNext)
                || (order.Type == OrderType.Limit && FillLimitOnNext)
                || (order.Type == OrderType.Stop && FillStopOnNext)
                || (order.Type == OrderType.StopLimit && FillStopLimitOnNext)) {
                return;
            }

            if (FillOnQuote) {
                Ask ask = framework.DataManager.GetAsk(instrumentId);
                if (ask != null && OnAsk(order, ask)) {
                    RemoveDoneOrders();
                    return;
                }
                Bid bid = framework.DataManager.GetBid(instrumentId);
                if (bid != null && OnBid(order, bid)) {
                    RemoveDoneOrders();
                    return;
                }
            }
            if (FillOnTrade) {
                Trade trade = framework.DataManager.GetTrade(instrumentId);
                if (trade != null && OnTrade(order, trade)) {
                    RemoveDoneOrders();
                    return;
                }
            }
            if (FillOnBar) {
                Bar bar = framework.DataManager.GetBar(instrumentId);
                if (BarFilter.Count != 0 && !BarFilter.Contains(bar.Type, bar.Size)) {
                    return;
                }
                if (bar != null && OnBar(order, bar)) {
                    RemoveDoneOrders();
                    return;
                }
            }
            if (FillOnLevel2) {
                var snapshot = framework.DataManager.GetAggregatedSnapshot(instrumentId);
                if (snapshot != null && OnLevel2(order, snapshot)) {
                    RemoveDoneOrders();
                }
            }
        }

        private void SetVWapFormat(Instrument instrument)
        {
            if (_vwapFormats[instrument.Id] == 0 && !string.IsNullOrEmpty(instrument.PriceFormat)) {
                if (int.TryParse(instrument.PriceFormat.Substring(1), out var v)) {
                    _vwapFormats[instrument.Id] = v + 1;
                }
                else {
                    _vwapFormats[instrument.Id] = -1;
                }
            }
        }

        public QBExecutionSimulator(Framework framework)
            : base(framework)
        {
            Id = QuantBoxConst.PIdSimExec;
            Name = "QuantBoxExecutionSimulator";
            url = "www.quantbox.cn";
            this.framework = framework;
            BarFilter = new BarFilter();
            CheckSubPositions = this.framework.Configuration.UseSubPositions;
            SlippageProvider = new TickSizeSlippageProvider();
            CommissionProvider = new CommissionProvider();
        }

        public TimeSpan Auction1 { get; set; }
        public TimeSpan Auction2 { get; set; }
        public bool FillOnQuote { get; set; }
        public bool FillOnTrade { get; set; } = true;
        public bool FillOnBar { get; set; }
        public bool FillOnBarOpen { get; set; }
        public bool FillOnLevel2 { get; set; }
        public bool FillMarketOnNext { get; set; } = true;
        public bool FillLimitOnNext { get; set; } = true;
        public bool FillStopOnNext { get; set; } = true;
        public bool FillStopLimitOnNext { get; set; } = true;
        public bool FillAtLimitPrice { get; set; } = true;
        public bool FillAtStopPrice { get; set; }
        public bool PartialFills { get; set; }
        public bool UseProbability { get; set; }
        public double Probability { get; set; }
        public bool CheckDataProvider { get; set; }
        public bool CheckSubPositions { get; set; }
        public bool FillAtVWap { get; set; } = true;
        public bool Queued { get; set; } = true;

        public BarFilter BarFilter { get; private set; }

        public ICommissionProvider CommissionProvider { get; set; }
        public ISlippageProvider SlippageProvider { get; set; }

        public void Fill(Order order, double price, int size)
        {
            if (!PartialFills) {
                _ordersToRemove.Add(order);
                var report = new ExecutionReport(order);
                report.DateTime = framework.Clock.DateTime;
                report.ExecType = ExecType.ExecTrade;
                report.OrdStatus = OrderStatus.Filled;
                report.CumQty = order.LeavesQty;
                report.LastQty = order.LeavesQty;
                report.LeavesQty = 0.0;
                report.LastPx = price;
                if (CommissionProvider != null) {
                    report.Commission = CommissionProvider.GetCommission(report);
                }
                else {
                    //Console.WriteLine("ExecutionSimulator::Fill Warning - CommissionProvider is null");
                }
                if (SlippageProvider != null) {
                    report.LastPx = SlippageProvider.GetPrice(report);
                }
                else {
                    //Console.WriteLine("ExecutionSimulator::Fill Warning - SlippageProvider is null");
                }
                _reports[order.Id] = new SimulatorExecutionReport(report);
                EmitExecutionReport(report, Queued);
                return;
            }
            else {
                if (size <= 0) {
                    Console.WriteLine(@"ExecutionSimulator::Fill Error - using partial fills, size can not be zero");
                    return;
                }
                ExecutionReport report = new ExecutionReport(order);
                report.DateTime = framework.Clock.DateTime;
                report.ExecType = ExecType.ExecTrade;
                double leaves = order.LeavesQty;
                if (!_partiallyFilledOrders.ContainsKey(order)) {
                    _partiallyFilledOrders.Add(order, 0.0);
                }
                else {
                    leaves = order.Qty - _partiallyFilledOrders[order];
                }

                if (size >= leaves) {
                    Dictionary<Order, double> dictionary = _partiallyFilledOrders;
                    dictionary[order] += leaves;
                    _ordersToRemove.Add(order);
                    report.OrdStatus = OrderStatus.Filled;
                    report.CumQty = _partiallyFilledOrders[order];
                    report.LastQty = leaves;
                    report.LeavesQty = 0.0;
                    report.LastPx = price;
                }
                else if (size < leaves) {
                    Dictionary<Order, double> dictionary = _partiallyFilledOrders;
                    dictionary[order] += size;
                    report.OrdStatus = OrderStatus.PartiallyFilled;
                    report.CumQty = _partiallyFilledOrders[order];
                    report.LastQty = size;
                    report.LeavesQty = leaves - size;
                    report.LastPx = price;
                }
                if (CommissionProvider != null) {
                    report.Commission = CommissionProvider.GetCommission(report);
                }
                else {
                    //Console.WriteLine("ExecutionSimulator::Fill Warning - CommissionProvider is null");
                }
                if (SlippageProvider != null) {
                    report.LastPx = SlippageProvider.GetPrice(report);
                }
                else {
                    //Console.WriteLine("ExecutionSimulator::Fill Warning - SlippageProvider is null");
                }
                _reports[order.Id] = new SimulatorExecutionReport(report);
                EmitExecutionReport(report, Queued);
            }
        }

        public void OnAsk(Ask ask)
        {
            if (_orders[ask.InstrumentId] != null && FillOnQuote) {
                for (int i = 0; i < _orders[ask.InstrumentId].Count; i++) {
                    Order order = _orders[ask.InstrumentId][i];
                    OnAsk(order, ask);
                }
                RemoveDoneOrders();
            }
        }

        public void OnBar(Bar bar)
        {
            if (_orders[bar.InstrumentId] != null && FillOnBar && (BarFilter.Count == 0 || BarFilter.Contains(bar.Type, bar.Size))) {
                for (int i = 0; i < _orders[bar.InstrumentId].Count; i++) {
                    Order order = _orders[bar.InstrumentId][i];
                    OnBar(order, bar);
                }
                RemoveDoneOrders();
            }
        }

        public void OnBarOpen(Bar bar)
        {
            if (_orders[bar.InstrumentId] == null || !FillOnBarOpen || (BarFilter.Count != 0 && !BarFilter.Contains(bar.Type, bar.Size))) {
                return;
            }
            for (int i = 0; i < _orders[bar.InstrumentId].Count; i++) {
                Order order = _orders[bar.InstrumentId][i];
                if (CheckDataProvider && !IsProviderPassed(order, bar.ProviderId)) {
                    continue;
                }
                while (true) {
                    switch (order.Type) {
                        case OrderType.Market:
                        case OrderType.Pegged:
                            Fill(order, bar.Open, (int)bar.Volume);
                            break;
                        case OrderType.Limit:
                            switch (order.Side) {
                                case OrderSide.Buy:
                                    if (bar.Open <= order.Price) {
                                        if (UseProbability && bar.Open == order.Price && _random.NextDouble() < Probability) {
                                            return;
                                        }
                                        if (FillAtLimitPrice) {
                                            Fill(order, order.Price, (int)bar.Volume);
                                        }
                                        else {
                                            Fill(order, bar.Open, (int)bar.Volume);
                                        }
                                    }
                                    break;
                                case OrderSide.Sell:
                                    if (bar.Open >= order.Price) {
                                        if (UseProbability && bar.Open == order.Price && _random.NextDouble() < Probability) {
                                            return;
                                        }
                                        if (FillAtLimitPrice) {
                                            Fill(order, order.Price, (int)bar.Volume);
                                        }
                                        else {
                                            Fill(order, bar.Open, (int)bar.Volume);
                                        }
                                    }
                                    break;
                            }
                            break;
                        case OrderType.Stop:
                            switch (order.Side) {
                                case OrderSide.Buy:
                                    if (bar.Open >= order.StopPx) {
                                        if (!FillAtStopPrice) {
                                            order.SetOrderType(OrderType.Market);
                                            continue;
                                        }
                                        Fill(order, order.StopPx, (int)bar.Volume);
                                    }
                                    break;
                                case OrderSide.Sell:
                                    if (bar.Open <= order.StopPx) {
                                        if (!FillAtStopPrice) {
                                            order.SetOrderType(OrderType.Market);
                                            continue;
                                        }
                                        Fill(order, order.StopPx, (int)bar.Volume);
                                    }
                                    break;
                            }
                            break;
                        case OrderType.StopLimit:
                            switch (order.Side) {
                                case OrderSide.Buy:
                                    if (bar.Open >= order.StopPx) {
                                        order.SetOrderType(OrderType.Limit);
                                        continue;
                                    }
                                    break;
                                case OrderSide.Sell:
                                    if (bar.Open <= order.StopPx) {
                                        order.SetOrderType(OrderType.Limit);
                                        continue;
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
                }
            }
            RemoveDoneOrders();
        }

        public void OnBid(Bid bid)
        {
            if (_orders[bid.InstrumentId] != null && FillOnQuote) {
                for (int i = 0; i < _orders[bid.InstrumentId].Count; i++) {
                    Order order = _orders[bid.InstrumentId][i];
                    OnBid(order, bid);
                }
                RemoveDoneOrders();
            }
        }

        public void OnLevel2(Level2Snapshot snapshot)
        {
            var list = _orders[snapshot.InstrumentId];
            if (FillOnLevel2 && list != null) {
                for (int i = 0; i < list.Count; i++) {
                    var order = list[i];
                    OnLevel2(order, snapshot);
                }
                RemoveDoneOrders();
            }
        }

        public void OnLevel2(Level2Update update)
        {
            var list = _orders[update.InstrumentId];
            var snapshot = framework.DataManager.GetAggregatedSnapshot(update.InstrumentId);
            if (FillOnLevel2 && list != null && snapshot != null) {
                for (int i = 0; i < list.Count; i++) {
                    var order = list[i];
                    OnLevel2(order, snapshot);
                }
                RemoveDoneOrders();
            }
        }

        public void OnTrade(Trade trade)
        {
            if (_orders[trade.InstrumentId] != null && FillOnTrade) {
                for (int i = 0; i < _orders[trade.InstrumentId].Count; i++) {
                    Order order = _orders[trade.InstrumentId][i];
                    OnTrade(order, trade);
                }
                RemoveDoneOrders();
            }
        }

        public override void Send(ExecutionCommand command)
        {
            if (IsDisconnected) {
                Connect();
            }
            switch (command.Type) {
                case ExecutionCommandType.Send:
                    DoSend(command);
                    break;
                case ExecutionCommandType.Cancel:
                    Cancel(command.Order);
                    break;
                case ExecutionCommandType.Replace:
                    Replace(command);
                    break;
            }
        }

        private void EventThreadRun(object data)
        {
            Console.WriteLine(DateTime.Now + " Event manager thread started: Framework = " + framework.Name + " Clock = " + framework.Clock.GetModeAsString());
            var manager = framework.EventManager;
            var bus = framework.EventBus;
            while (!FrameworkExtensions.ThreadExitField.Getter(manager)) {
                if (manager.Status == EventManagerStatus.Running) {
                    var e = bus.Dequeue();
                    if (e.TypeId == DataObjectType.OnSimulatorStop) {

                    }
                    manager.OnEvent(e);
                }
                else {
                    Thread.Sleep(1);
                }
            }
            Console.WriteLine(DateTime.Now + " Event manager thread stopped: Framework = " + framework.Name + " Clock = " + framework.Clock.GetModeAsString());
        }

        protected override void OnConnect()
        {
            //if (framework.Name == "framework 4" && framework.IsExternalDataQueue) {
            //    framework.ChangeEventThread(new ParameterizedThreadStart(EventThreadRun));
            //}
            base.OnConnect();
        }
    }
}
