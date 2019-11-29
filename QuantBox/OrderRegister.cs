using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks.Dataflow;
using System.Timers;
using NLog;
using SmartQuant;

namespace QuantBox
{
    using Timer = System.Timers.Timer;

    public enum SelfTradePreventMethod : byte
    {
        Reject,
        WaitUntilDone
    }

    public class OrderRegister
    {
        private class ReminderData : DataObject
        {
            public override byte TypeId => DataObjectType.Reminder;
        }

        private class PriceBook
        {
            public readonly List<long> SellPriceList;
            public readonly List<long> BuyPriceList;

            public PriceBook()
            {
                SellPriceList = new List<long>();
                BuyPriceList = new List<long>();
            }

            public void AddOrder(Order order)
            {
                long value = GetOrderValue(order);
                if (order.Side == OrderSide.Buy) {
                    BuyPriceList.Add(value);
                    BuyPriceList.Sort();
                }
                else {
                    SellPriceList.Add(value);
                    SellPriceList.Sort();
                }
            }

            private static long GetOrderValue(Order order)
            {
                var price = (int)(order.Price / order.Instrument.TickSize);
                if (order.Type == OrderType.Market) {
                    price = order.Side == OrderSide.Buy ? int.MaxValue : int.MinValue;
                }
                var value = new Skyline.MakeLong(price, (int)order.Qty).Value;
                return value;
            }

            public void RemoveOrder(Order order)
            {
                long value = GetOrderValue(order);
                if (order.Side == OrderSide.Buy) {
                    BuyPriceList.Remove(value);
                }
                else {
                    SellPriceList.Remove(value);
                }
            }

            public bool TradeTest(Order order)
            {
                if (order.Type == OrderType.Market) {
                    return order.Side == OrderSide.Buy ? SellPriceList.Count > 0 : BuyPriceList.Count > 0;
                }
                var price = (int)(order.Price / order.Instrument.TickSize);
                if (order.Side == OrderSide.Buy) {
                    return SellPriceList.Count > 0 && price >= new Skyline.MakeLong(SellPriceList.First()).High;
                }
                else {
                    return BuyPriceList.Count > 0 && price <= new Skyline.MakeLong(BuyPriceList.Last()).High;
                }
            }
        }

        public static readonly OrderRegister Instance;
        private readonly ActionBlock<DataObject> _actionBlock;
        private readonly Dictionary<Framework, EventQueue> _queues;
        private readonly Dictionary<string, PriceBook> _priceBookList;
        private readonly ReminderData _reminder;
        private readonly Timer _timer;
        private readonly List<Framework> _frameworks;
        private List<Order> _pendingList;
        private Logger _logger;

        public SelfTradePreventMethod PreventMethod { get; set; } = SelfTradePreventMethod.WaitUntilDone;
        public TimeSpan WaitTimeout { get; set; } = TimeSpan.Zero;

        static OrderRegister()
        {
            Instance = new OrderRegister();
        }

        private EventQueue GetEventQueue(Framework framework)
        {
            if (!_queues.TryGetValue(framework, out var queue)) {
                queue = new EventQueue(size: 10, bus: framework.EventBus);
                queue.Enqueue(new OnQueueOpened(queue));
                framework.EventBus.ExecutionPipe.Add(queue);
            }
            return queue;
        }

        private void SendOrderCancel(Order order)
        {
            var framework = order.Portfolio.GetFramework();
            GetEventQueue(framework).Enqueue(CreateCancelReport(order));
        }

        private void SendOrderReject(Order order)
        {
            var framework = order.Portfolio.GetFramework();
            GetEventQueue(framework).Enqueue(CreateRejectReport(order));
        }
        
        private ExecutionReport CreateCancelReport(Order order)
        {
            var report = new ExecutionReport(order);
            report.OrdStatus = OrderStatus.Cancelled;
            report.Text = "等待超时";
            report.ExecType = ExecType.ExecCancelled;
            return report;
        }

        private ExecutionReport CreateRejectReport(Order order)
        {
            var report = new ExecutionReport(order);
            report.OrdStatus = OrderStatus.Rejected;
            report.Text = "防止自成交";
            report.ExecType = ExecType.ExecRejected;
            return report;
        }

        private void CheckSelfTrade(Order order)
        {
            if (!_priceBookList.TryGetValue(order.Instrument.Symbol, out var book)) {
                book = new PriceBook();
                _priceBookList.Add(order.Instrument.Symbol, book);
            }

            if (book.TradeTest(order)) {
                if (PreventMethod == SelfTradePreventMethod.Reject) {
                    SendOrderReject(order);
                }
                else {
                    _logger.Debug($"{order.Text}: 检测到自成交可能，进入等待队列.");
                    _pendingList.Add(order);
                }
            }
            else {
                book.AddOrder(order);
                order.Send();
            }
        }

        private void Process(DataObject data)
        {
            switch (data.TypeId) {
                case DataObjectType.Order:
                    CheckSelfTrade((Order)data);
                    break;
                case DataObjectType.ExecutionReport:
                    ProcessReport((ExecutionReport)data);
                    break;
                case DataObjectType.Reminder:
                    if (PreventMethod == SelfTradePreventMethod.WaitUntilDone) {
                        ProcessTimeout();
                    }
                    break;
                default:
                    break;
            }
        }

        private void ProcessTimeout()
        {
            if (_pendingList.Count == 0 || WaitTimeout == TimeSpan.Zero) { return; }
            var temp = new List<Order>();
            foreach (var item in _pendingList) {
                if (DateTime.Now - item.DateTime > WaitTimeout) {
                    SendOrderCancel(item);
                    continue;
                }
                temp.Add(item);
            }
            _pendingList = temp;
        }

        private void ProcessReport(ExecutionReport report)
        {
            var order = report.Order;
            if (order.IsDone) {
                if (_priceBookList.TryGetValue(order.Instrument.Symbol, out var book)) {
                    book.RemoveOrder(order);
                    _logger.Debug($"{order.Text}, 成交");
                    if (_pendingList.Count == 0) { return; }
                    var temp = new List<Order>();
                    foreach (var item in _pendingList) {
                        if (order.Side != item.Side) {
                            if (!book.TradeTest(item)) {
                                book.AddOrder(item);
                                item.Send();
                                continue;
                            }
                        }
                        temp.Add(item);
                    }
                    _pendingList = temp;
                }
            }
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            Post(_reminder);
        }
        public OrderRegister()
        {
            _reminder = new ReminderData();
            _queues = new Dictionary<Framework, EventQueue>();
            _actionBlock = new ActionBlock<DataObject>(Process);
            _priceBookList = new Dictionary<string, PriceBook>();
            _pendingList = new List<Order>();
            _frameworks = new List<Framework>();
            _timer = new Timer(1000);
            _timer.Elapsed += TimerOnElapsed;
            _timer.Enabled = true;
        }

        public void Init(params Framework[] frameworks)
        {
            if (_logger == null) {
                _logger = LogManager.GetLogger("order_register");
            }
            _frameworks.AddRange(frameworks);
            foreach (var item in frameworks) {
                item.EventManager.Dispatcher.ExecutionReport += OnExecutionReport;
            }
        }

        private void OnExecutionReport(object sender, ExecutionReport report)
        {
            Post(report);
        }

        public void Post(DataObject data)
        {
            _actionBlock.Post(data);
        }

        public void Close()
        {
            foreach (var framework in _frameworks) {
                framework.EventManager.Dispatcher.ExecutionReport -= OnExecutionReport;
            }
            _timer.Enabled = false;
            _actionBlock.Complete();
            _actionBlock.Completion.Wait();
            _priceBookList.Clear();
            _pendingList.Clear();
        }
    }
}
