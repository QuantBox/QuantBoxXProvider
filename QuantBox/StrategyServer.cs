using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LiteDB;
using QuantBox.XApi;
using SmartQuant;

namespace QuantBox
{
    public static class TaskExtensions
    {
        public static void WaitAndCancell(this Task task, int ms)
        {
            if (task.AsyncState is CancellationTokenSource cts)
            {
                if (!task.Wait(ms))
                {
                    cts.Cancel();
                    task.Wait();
                }
            }
        }
    }

    public class StrategyServer
    {
        private const string ConnectionString = "Filename={0};Upgrade=true";

        private volatile int _initialized;
        private readonly Framework _framework;
        private readonly Strategy _strategy;
        private readonly string _instanceName;
        private string _databasePath;
        private ObjectTableWriter _fieldsWriter = null;
        private ObjectTableReader _fieldsReader = null;

        private string GetDatabaseName()
        {
            return _instanceName;
        }

        private string GetDefaultDatabasePath()
        {
            return Path.Combine(Installation.DataDir.FullName, GetDatabaseName());
        }

        public StrategyServer(Strategy strategy, string instanceName = null)
            : this(strategy.GetFramework(), strategy, instanceName)
        {
        }

        public StrategyServer(Scenario scenario, string instanceName = null)
            : this(scenario.Framework, scenario.Strategy, instanceName)
        {
        }

        private StrategyServer(Framework framework, Strategy strategy, string instanceName)
        {
            _framework = framework;
            _strategy = strategy;
            _instanceName = instanceName ?? (string.IsNullOrEmpty(_strategy.Name) ? _strategy.GetType().Name : _strategy.Name);
            _databasePath = GetDefaultDatabasePath();
        }

        LiteDatabase CreateDatabase()
        {
            var mapper = new DataEventMapper(_fieldsWriter, _fieldsReader);
            return new LiteDatabase(string.Format(ConnectionString, _databasePath), mapper);
        }

        /// <summary>
        /// 设置交易数据库存储文件路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public StrategyServer SetDatabasePath(string path)
        {
            _databasePath = path;
            return this;
        }

        /// <summary>
        /// 设置订单或STOP的自定义数据的读取方法
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public StrategyServer SetFieldsReader(ObjectTableReader reader)
        {
            _fieldsReader = reader;
            return this;
        }

        /// <summary>
        /// 设置订单或STOP的自定义数据的存储方法
        /// </summary>
        /// <param name="writer"></param>
        /// <returns></returns>
        public StrategyServer SetFieldsWriter(ObjectTableWriter writer)
        {
            _fieldsWriter = writer;
            return this;
        }

        public Task Init()
        {
            if (Interlocked.CompareExchange(ref _initialized, 1, 0) > 0)
            {
                return Task.CompletedTask;
            }
            ClosePortfolioServer();
            CloseOrderServer();
            var db = CreateDatabase();
            _framework.PortfolioServer = new DatabasePortfolioServer(_framework, db);
            _framework.OrderServer = new DatabaseOrderServer(_framework, db, _instanceName);
            _framework.StrategyManager.Persistence = StrategyPersistence.Full;
            return LoadOrderTrade(_strategy, SetTradingDay);

            void ClosePortfolioServer()
            {
                if (_framework.PortfolioServer is DatabasePortfolioServer server)
                {
                    server.Close();
                }
            }

            void CloseOrderServer()
            {
                if (_framework.OrderServer is DatabaseOrderServer server)
                {
                    server.Close();
                }
            }
        }

        private void SetTradingDay()
        {
            var server = (DatabaseOrderServer)_framework.OrderServer;
            var date = _framework.StrategyManager.GetExTradingDay();
            if (date != default && server.Settings.GetAsDateTime(ProviderSettingsType.TradingDay) == default)
            {
                server.Settings.Set(ProviderSettingsType.TradingDay, date);
            }
        }

        private static IEnumerable<XProvider> GetXProviders(Strategy strategy)
        {
            var list = new HashSet<XProvider>();
            ScanStrategy(strategy);
            return list;

            void ScanProvider(Strategy s)
            {
                foreach (var (_, ep) in s.GetExecutionProviderList())
                {
                    switch (ep)
                    {
                        case XProvider p:
                            if (!list.Contains(p))
                            {
                                list.Add(p);
                            }
                            break;
                        case SellSideStrategy sss:
                            ScanProvider(sss);
                            break;
                    }
                }
                return;
            }

            void ScanStrategy(Strategy s)
            {
                ScanProvider(s);
                foreach (var child in s.Strategies)
                {
                    ScanStrategy(child);
                }
            }
        }

        private static Task LoadOrderTrade(XProvider provider, CancellationTokenSource cts)
        {
            return new Task(state => {
                var ct = ((CancellationTokenSource)state).Token;
                var spi = new XSpi();
                {
                    var client = provider.CreateTrader(spi);
                    var complete = new AutoResetEvent(false);
                    var orders = new List<OrderField>();
                    var trades = new List<TradeField>();

                    spi.ErrorHappened += (s, error) => {
                        Console.WriteLine(error.Text);
                        complete.Set();
                    };
                    spi.StatusChanged += (s, status, field) => {
                        Console.WriteLine(status);
                        if (field != null && status == ConnectionStatus.Logined)
                        {
                            Console.WriteLine(field.RawErrorID != 0 ? field.RawErrorMsg() : field.DebugInfo());
                        }

                        if (status == ConnectionStatus.Done)
                        {
                            client.TradingDay = field.TradingDay();
                            client.QueryOrders();
                        }
                    };
                    spi.OrderReceived += (s, order, isLast) => {
                        if (order != null)
                        {
                            orders.Add(order);
                        }
                        if (isLast)
                        {
                            client.QueryTrades();
                        }
                    };
                    spi.TradeReceived += (s, trade, isLast) => {
                        if (trade != null)
                        {
                            trades.Add(trade);
                        }
                        if (isLast)
                        {
                            complete.Set();
                        }
                    };

                    client.Connect();
                    while (!ct.IsCancellationRequested)
                    {
                        if (complete.WaitOne(0))
                        {
                            break;
                        }
                        Skyline.Utility.Sleep(100, ct);
                    }
                    client.Disconnect();
                    var global = provider.Framework.StrategyManager;
                    orders.Sort((x, y) => x.UpdateTime().CompareTo(y.UpdateTime()));
                    trades.Sort((x, y) => x.UpdateTime().CompareTo(y.UpdateTime()));
                    global.SetExOrders(orders, provider.Id);
                    global.SetExTrades(trades, provider.Id);
                    global.SetExTradingDay(client.TradingDay);
                }
            }, cts, cts.Token, TaskCreationOptions.LongRunning);
        }

        private static Task LoadOrderTrade(Strategy strategy, Action continueWith)
        {
            var cts = new CancellationTokenSource();
            var task = new Task(state => {
                var tasks = GetXProviders(strategy)
                    .Select(n => LoadOrderTrade(n, (CancellationTokenSource)state))
                    .ToArray();
                foreach (var item in tasks)
                {
                    item.Start();
                }
                Task.WaitAll(tasks);
                continueWith();
            }, cts, cts.Token, TaskCreationOptions.LongRunning);
            task.Start();
            return task;
        }

        public static void SaveStop(Stop stop)
        {
            var framework = stop.Strategy.GetFramework();
            if (framework != null && framework.OrderServer is DatabaseOrderServer server)
            {
                server.SaveStop(stop);
            }
        }

        public static void RemoveStop(Stop stop)
        {
            var framework = stop.Strategy.GetFramework();
            if (framework != null && framework.OrderServer is DatabaseOrderServer server)
            {
                server.RemoveStop(stop);
            }
        }
    }
}