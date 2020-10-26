using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using QuantBox.XApi;
using Skyline;
using SmartQuant;
using SmartQuant.Strategy_;
using ExecType = SmartQuant.ExecType;
using OrderSide = SmartQuant.OrderSide;
using OrderStatus = SmartQuant.OrderStatus;
using OrderType = SmartQuant.OrderType;
using PositionSide = SmartQuant.PositionSide;

namespace QuantBox
{
    public class OrderList
    {
        public Strategy Strategy { get; }
        public readonly List<Order> Orders;

        public OrderList(Strategy strategy)
        {
            Strategy = strategy;
            Orders = new List<Order>();
        }

        public void Add(Order order)
        {
            Orders.Add(order);
        }

        public void Send()
        {
            foreach (var order in Orders) {
                if (order.IsNotSent) {
                    continue;
                }
                Strategy.Send(order);
            }
        }

        public void Cancel()
        {
            foreach (var order in Orders) {
                Strategy.Cancel(order);
            }
        }

        public bool IsDone => Orders.TrueForAll(n => n.IsDone);
        public bool IsFilled => Orders.TrueForAll(n => n.IsFilled);
        public bool IsCancelled => Orders.TrueForAll(n => n.IsCancelled);
        public bool IsNotSent => Orders.TrueForAll(n => n.IsNotSent);
    }

    public static class StrategyExtensions
    {
        private static readonly MethodInfo StrategyOnStopStatusChangedMethod;
        private static readonly Action<Strategy, Stop> OnStopStatusChangedAction;
        private static readonly FastFieldInfo<Strategy, SmartQuant.IdArray<Strategy>> StrategyByIdField;
        private static readonly FastFieldInfo<Strategy, IExecutionProvider> ExecutionProviderField;
        private static readonly FastFieldInfo<Strategy, IDataProvider> DataProviderField;
        private static readonly FastFieldInfo<StrategyManager_, SmartQuant.IdArray<Strategy_>> StrategiesField1;
        private static readonly FastFieldInfo<StrategyManager_, SmartQuant.IdArray<Strategy_>> StrategiesField2;

        static StrategyExtensions()
        {
            foreach (var field in typeof(StrategyManager_).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)) {
                if (field.FieldType == typeof(SmartQuant.IdArray<Strategy_>)) {
                    if (StrategiesField1 == null) {
                        StrategiesField1 = new FastFieldInfo<StrategyManager_, SmartQuant.IdArray<Strategy_>>(field);
                    }
                    else {
                        StrategiesField2 = new FastFieldInfo<StrategyManager_, SmartQuant.IdArray<Strategy_>>(field);
                    }
                }
            }

            foreach (var field in typeof(Strategy).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)) {
                if (field.FieldType == typeof(SmartQuant.IdArray<Strategy>)) {
                    StrategyByIdField = new FastFieldInfo<Strategy, SmartQuant.IdArray<Strategy>>(field);
                }
                else if (field.FieldType == typeof(IExecutionProvider)) {
                    ExecutionProviderField = new FastFieldInfo<Strategy, IExecutionProvider>(field);
                }
                else if (field.FieldType == typeof(IDataProvider)) {
                    DataProviderField = new FastFieldInfo<Strategy, IDataProvider>(field);
                }
            }

            StrategyOnStopStatusChangedMethod = typeof(Strategy).GetMethod("OnStopStatusChanged_", BindingFlags.Instance | BindingFlags.NonPublic);
            OnStopStatusChangedAction = (Action<Strategy, Stop>)StrategyOnStopStatusChangedMethod.CreateDelegate(typeof(Action<Strategy, Stop>));
        }

        /// <summary>
        /// 对手价卖出
        /// </summary>
        /// <returns></returns>
        public static Order SellMatchOrder(this Strategy s, Instrument inst, int qty, string text = "")
        {
            return s.SellLimitOrder(inst, qty, inst.Bid.Price, text);
        }

        /// <summary>
        /// 对手价买入
        /// </summary>
        /// <returns></returns>
        public static Order BuyMatchOrder(this Strategy s, Instrument inst, int qty, string text = "")
        {
            return s.BuyLimitOrder(inst, qty, inst.Ask.Price, text);
        }

        public static Stop AddStop(this Strategy s,
            Position position, double qty, DateTime dateTime)
        {
            return AddStop(s, position, position.Side, qty, dateTime);
        }

        public static Stop AddStop(this Strategy s,
            Position position, PositionSide side, double qty, DateTime dateTime)
        {
            var stop = new QBStop(s, position, side, qty, dateTime);
            AddStop2(s, stop);
            return stop;
        }

        public static Stop AddStop(this Strategy s, Position position, double qty = 0,
            double level = 0.05, StopType type = StopType.Trailing, StopMode mode = StopMode.Percent)
        {
            return AddStop(s, position, position.Side, qty, level, type, mode);
        }

        public static Stop AddStop(this Strategy s, Position position, PositionSide side, double qty = 0,
            double level = 0.05, StopType type = StopType.Trailing, StopMode mode = StopMode.Percent)
        {
            var stop = new QBStop(s, position, side, qty, level, type, mode);
            AddStop2(s, stop);
            return stop;
        }

        private static void AddStop2(Strategy s, Stop stop)
        {
            s.AddStop(stop);
            StrategyServer.SaveStop(stop);
        }

        public static void AddStop2(this Strategy s, Stop stop, double qty)
        {
            if (qty > 0) {
                stop.SetQty(qty);
            }
            AddStop2(s, stop);
        }

        public static void LoadStop(this Strategy s)
        {
            var f = s.GetFramework();
            if (f == null) {
                return;
            }
            if (f.OrderServer is DatabaseOrderServer server) {
                server.LoadStop(s);
            }
        }

        public static void CallStopStatusChanged(this Strategy s, Stop stop)
        {
            //StrategyOnStopStatusChangedMethod?.Invoke(s, new[] { stop });
            OnStopStatusChangedAction(s, stop);
        }

        public static SmartQuant.IdArray<Strategy> GetStrategies(this Strategy s)
        {
            return StrategyByIdField?.Getter(s);
        }

        public static Strategy FindStrategy(this StrategyManager manager, int id)
        {
            if (manager.Strategy != null && manager.Strategy.Id == id) {
                return manager.Strategy;
            }
            var list = StrategyByIdField?.Getter(manager.Strategy);
            return list?[id] != null ? list[id] : manager.Strategy.GetStrategyById(id);
        }

        public static IEnumerable<Strategy> GetStrategies(this StrategyManager manager)
        {
            if (manager.Strategy != null) {
                yield return manager.Strategy;
                foreach (var item in All(manager.Strategy)) {
                    yield return item;
                }
            }

            IEnumerable<Strategy> All(Strategy parent)
            {
                foreach (var item in parent.Strategies) {
                    foreach (var child in All(item)) {
                        yield return child;
                    }
                    yield return item;
                }
            }
        }

        public static DualPosition GetPosition(this Strategy strategy, Instrument instrument)
        {
            if (strategy.OrderManager.Server is DatabaseOrderServer server) {
                return server.PositionStore.GetPosition(strategy.Id, instrument.Id);
            }
            return null;
        }

        public static DualPosition GetPosition(this InstrumentStrategy strategy)
        {
            if (strategy.OrderManager.Server is DatabaseOrderServer server) {
                return server.PositionStore.GetPosition(strategy.Id, strategy.Instrument.Id);
            }
            return null;
        }

        public static Strategy_ FindStrategy(this StrategyManager_ manager, int id)
        {
            var s = StrategiesField1.Getter(manager)[id];
            if (s != null && s.Id == id) {
                return s;
            }
            s = StrategiesField2.Getter(manager)[id];
            if (s != null && s.Id == id) {
                return s;
            }
            return null;
        }

        public static IExecutionProvider GetExecutionProvider(this Strategy strategy, Instrument inst = null)
        {
            if (inst?.ExecutionProvider != null) {
                return inst.ExecutionProvider;
            }

            IExecutionProvider p = null;
            if (ExecutionProviderField != null) {
                p = ExecutionProviderField.Getter(strategy);
            }
            return p;
        }

        public static IDataProvider GetDataProvider(this Strategy strategy, Instrument inst = null)
        {
            if (inst?.DataProvider != null) {
                return inst.DataProvider;
            }

            IDataProvider p = null;
            if (DataProviderField != null) {
                p = DataProviderField.Getter(strategy);
            }
            return p;
        }

        public static IEnumerable<(Instrument, IExecutionProvider)> GetExecutionProviderList(this Strategy s)
        {
            if (s.Instruments.Count > 0) {
                foreach (var inst in s.Instruments) {
                    yield return (inst, GetExecutionProvider(s, inst));
                }
            }
            else {
                yield return (null, GetExecutionProvider(s));
            }
        }

        public static bool AddMarketCloseReminder(this Strategy strategy, object state = null)
        {
            return AddMarketCloseReminder(strategy, TimeSpan.Zero, state);
        }

        public static bool AddMarketCloseReminder(this Strategy strategy, TimeSpan offset, object state = null)
        {
            var date = GetNextMarketCloseTime(strategy);
            if (date != DateTime.MaxValue) {
                strategy.AddReminder(date.Add(offset), state);
                return true;
            }
            return false;
        }

        public static bool AddMarketOpenReminder(this Strategy strategy, object state = null)
        {
            return AddMarketOpenReminder(strategy, TimeSpan.Zero, state);
        }

        public static bool AddMarketOpenReminder(this Strategy strategy, TimeSpan offset, object state = null)
        {
            var date = GetNextMarketOpenTime(strategy, strategy.Instruments.First());
            if (date != DateTime.MaxValue) {
                strategy.AddReminder(date.Add(offset), state);
                return true;
            }
            return false;
        }

        private static void UpdateTradingRange(DateTime datetime, object data)
        {
            if (data is InstrumentStrategy si) {
                SetTradingRange(si);
            }
            else if (data is Strategy s) {
                SetTradingRange(s);
            }
        }

        private static void SetRangeUpdateReminder(TradingTimeRange range, Strategy strategy)
        {
            if (range.DateTime2 < DateTime.MaxValue) {
                strategy.Clock.AddReminder(new Reminder(UpdateTradingRange, range.DateTime2.AddDays(1), strategy));
            }
        }

        public static void SetTradingRange(this InstrumentStrategy strategy)
        {
            if (strategy.IsInstance) {
                var range = TradingCalendar.Instance.GetTimeRange(strategy.Instrument, strategy.Clock.DateTime);
                strategy.Instrument.SetTimeRange(range);
                SetRangeUpdateReminder(range, strategy);
            }
            else {
                SetTradingRange((Strategy)strategy);
            }
        }

        public static void SetTradingRange(this Strategy strategy)
        {
            var min = TradingTimeRange.Fulltime;
            foreach (var inst in strategy.Instruments) {
                var range = TradingCalendar.Instance.GetTimeRange(inst, strategy.Clock.DateTime);
                if (range.DateTime2 < min.DateTime2) {
                    min = range;
                }
                inst.SetTimeRange(range);
            }
            SetRangeUpdateReminder(min, strategy);
        }

        public static DateTime GetNextMarketOpenTime(this Strategy strategy, Instrument inst = null)
        {
            return TradingCalendar.Instance.GetNextMarketOpenTime(
                inst ?? strategy.Instruments.First(),
                strategy.Clock.DateTime,
                strategy.StrategyManager.Mode == StrategyMode.Backtest,
                strategy.DataSimulator.DateTime1);
        }

        public static DateTime GetNextMarketOpenTime(this InstrumentStrategy strategy)
        {
            return GetNextMarketOpenTime(strategy, strategy.Instrument);
        }

        public static DateTime GetNextMarketCloseTime(this InstrumentStrategy strategy)
        {
            return GetNextMarketCloseTime(strategy, strategy.Instrument);
        }

        public static DateTime GetNextMarketCloseTime(this Strategy strategy, Instrument inst = null)
        {
            if (inst == null) {
                inst = strategy.Instruments.First();
            }
            return TradingCalendar.Instance.GetNextCloseTime(inst, strategy.Clock.DateTime);
        }

        public static void SendFill(this Strategy strategy, Order order)
        {
            var report = new ExecutionReport(order);
            report.ExecType = ExecType.ExecTrade;
            report.DateTime = DateTime.Now;
            report.OrdStatus = OrderStatus.Filled;
            report.CumQty = order.Qty;
            report.LeavesQty = 0;
            report.LastPx = order.Type == OrderType.Limit ? order.Price : order.Instrument.Trade?.Price ?? 0;
            report.LastQty = order.Qty;
            var queue = new EventQueue(size: 10);
            queue.Enqueue(report);
            queue.Enqueue(new OnQueueClosed(queue));
            strategy.GetFramework().EventBus.ExecutionPipe.Add(queue);
        }

        public static OrderList GetOpenOrders(this Strategy strategy)
        {
            var list = new OrderList(strategy);
            foreach (var order in strategy.OrderManager.Orders)
            {
                if (order.strategyId != strategy.Id || order.IsDone) {
                    continue;
                }
                list.Add(order);
            }

            return list;
        }

        private static double GetOrderPrice(Instrument instrument, OrderSide side, OrderPriceAdjustMethod method)
        {
            var rules = instrument.GetTradingRules();
            double price;
            if (rules.HasMarketOrder) {
                price = Double.NaN;
            }
            else {
                if (side == OrderSide.Buy) {
                    price = method == OrderPriceAdjustMethod.MatchPrice ? instrument.Ask.Price : instrument.GetUpperLimitPrice();
                }
                else {
                    price = method == OrderPriceAdjustMethod.MatchPrice ? instrument.Bid.Price : instrument.GetLowerLimitPrice();
                }
            }

            return price;
        }

        public static Order OpenLong(this Strategy strategy, Instrument instrument, double qty, double price)
        {
            var order = Double.IsNaN(price)
                ? strategy.BuyOrder(instrument, qty).Open()
                : strategy.BuyLimitOrder(instrument, qty, price).Open();
            strategy.Send(order);
            return order;
        }

        public static Order OpenLong(this InstrumentStrategy strategy, double qty, double price)
        {
            return OpenLong(strategy, strategy.Instrument, qty, price);
        }

        public static Order OpenLong(this Strategy strategy, Instrument instrument, double qty,
            OrderPriceAdjustMethod method = OrderPriceAdjustMethod.MatchPrice)
        {
            double price = GetOrderPrice(instrument, OrderSide.Buy, method);
            return OpenLong(strategy, instrument, qty, price);
        }

        public static Order OpenLong(this InstrumentStrategy strategy, double qty, OrderPriceAdjustMethod method = OrderPriceAdjustMethod.MatchPrice)
        {
            return OpenLong(strategy, strategy.Instrument, qty, method);
        }

        public static Order OpenShort(this Strategy strategy, Instrument instrument, double qty, double price)
        {
            var order = Double.IsNaN(price)
                ? strategy.SellOrder(instrument, qty).Open()
                : strategy.SellLimitOrder(instrument, qty, price).Open();
            //strategy.Send(order);
            return order;
        }

        public static Order OpenShort(this InstrumentStrategy strategy, double qty, double price)
        {
            return OpenShort(strategy, strategy.Instrument, qty, price);
        }

        public static Order OpenShort(this Strategy strategy, Instrument instrument, double qty,
            OrderPriceAdjustMethod method = OrderPriceAdjustMethod.MatchPrice)
        {
            double price = GetOrderPrice(instrument, OrderSide.Sell, method);
            return OpenShort(strategy, instrument, qty, price);
        }

        public static Order OpenShort(this InstrumentStrategy strategy, double qty, OrderPriceAdjustMethod method = OrderPriceAdjustMethod.MatchPrice)
        {
            return OpenShort(strategy, strategy.Instrument, qty, method);
        }

        private static (double close, double closeToday) GetCloseInfo(Strategy strategy, Instrument instrument, OrderSide side, double qty = Double.MaxValue)
        {
            var position = strategy.GetPosition(instrument);
            var rules = instrument.GetTradingRules();
            (double closeQty, double closeTodayQty) = GetCloseQty();
            double closeToday;
            double close;
            if (rules.StrictCloseToday) {
                closeQty -= closeTodayQty;
                closeToday = Math.Min(qty, closeTodayQty);
                qty -= closeToday;
                if (Math.Abs(qty) < Double.Epsilon) {
                    return (close, closeToday);
                }
            }

            close = Math.Min(qty, closeQty);
            return (close, closeToday);
            #region local
            (double close, double closeToday) GetCloseQty()
            {
                (closeToday, close) = side == OrderSide.Buy
                    ? position.Short.GetCanCloseQty()
                    : position.Long.GetCanCloseQty();

                if (!rules.DisableCloseToday) {
                    return (close, closeToday);
                }

                close -= closeToday;
                closeToday = 0;
                return (close, closeToday);
            }
            #endregion
        }

        public static OrderList CloseLong(this InstrumentStrategy strategy, double qty,
            OrderPriceAdjustMethod method = OrderPriceAdjustMethod.MatchPrice)
        {
            return CloseLong(strategy, strategy.Instrument, qty, method);
        }

        public static OrderList CloseLong(this Strategy strategy, Instrument instrument, double qty,
            OrderPriceAdjustMethod method = OrderPriceAdjustMethod.MatchPrice)
        {
            return CloseLong(strategy, instrument, qty, GetOrderPrice(instrument, OrderSide.Sell, method));
        }

        public static OrderList CloseLong(this InstrumentStrategy strategy, double qty, double price)
        {
            return CloseLong(strategy, strategy.Instrument, qty, price);
        }

        public static OrderList CloseLong(this Strategy strategy, Instrument instrument, double qty, double price)
        {
            var list = new OrderList(strategy);
            (double close, double closeToday) = GetCloseInfo(strategy, instrument, OrderSide.Sell, qty);
            if (closeToday > 0) {
                list.Add(CreateOrder(closeToday).CloseToday());
            }

            if (close > 0) {
                list.Add(CreateOrder(close).Close());
            }

            return list;

            Order CreateOrder(double size)
            {
                return Double.IsNaN(price)
                    ? strategy.SellOrder(instrument, size)
                    : strategy.SellLimitOrder(instrument, size, price);

            }
        }

        public static OrderList CloseShort(this InstrumentStrategy strategy, double qty,
            OrderPriceAdjustMethod method = OrderPriceAdjustMethod.MatchPrice)
        {
            return CloseShort(strategy, strategy.Instrument, qty, method);
        }

        public static OrderList CloseShort(this Strategy strategy, Instrument instrument, double qty,
            OrderPriceAdjustMethod method = OrderPriceAdjustMethod.MatchPrice)
        {
            return CloseShort(strategy, instrument, qty, GetOrderPrice(instrument, OrderSide.Buy, method));
        }

        public static OrderList CloseShort(this InstrumentStrategy strategy, double qty, double price)
        {
            return CloseShort(strategy, strategy.Instrument, qty, price);
        }

        public static OrderList CloseShort(this Strategy strategy, Instrument instrument, double qty, double price)
        {
            var list = new OrderList(strategy);
            (double close, double closeToday) = GetCloseInfo(strategy, instrument, OrderSide.Buy, qty);
            if (closeToday > 0) {
                list.Add(CreateOrder(closeToday).CloseToday());
            }

            if (close > 0) {
                list.Add(CreateOrder(close).Close());
            }

            return list;

            Order CreateOrder(double size)
            {
                return Double.IsNaN(price)
                    ? strategy.BuyOrder(instrument, size)
                    : strategy.BuyLimitOrder(instrument, size, price);

            }
        }
    }
}