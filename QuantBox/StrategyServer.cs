using System.IO;
using System.Threading;
using System.Threading.Tasks;
using LiteDB;
using SmartQuant;

namespace QuantBox
{
    public static class TaskExtensions
    {
        public static void WaitAndCancel(this Task task, int ms)
        {
            if (!(task.AsyncState is CancellationTokenSource cts)) {
                return;
            }

            if (task.Wait(ms)) {
                return;
            }

            cts.Cancel();
            task.Wait();
        }
    }

    public class StrategyServer
    {
        private const string ConnectionString = "Filename={0};Upgrade=true";

        private volatile int _initialized;
        private readonly Framework _framework;
        private readonly string _instanceName;
        private string _databasePath;
        private ObjectTableWriter _fieldsWriter;
        private ObjectTableReader _fieldsReader;

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
            _instanceName = instanceName ?? (string.IsNullOrEmpty(strategy.Name) ? strategy.GetType().Name : strategy.Name);
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

        public StrategyServer Init()
        {
            if (Interlocked.CompareExchange(ref _initialized, 1, 0) > 0) {
                return this;
            }
            InstTradingRules.Init(_framework);
            ClosePortfolioServer();
            CloseOrderServer();
            var db = CreateDatabase();
            _framework.PortfolioServer = new DatabasePortfolioServer(_framework, db);
            _framework.OrderServer = new DatabaseOrderServer(_framework, db, _instanceName);
            _framework.StrategyManager.Persistence = StrategyPersistence.Full;
            return this;

            void ClosePortfolioServer()
            {
                if (_framework.PortfolioServer is DatabasePortfolioServer server) {
                    server.Close();
                }
            }

            void CloseOrderServer()
            {
                if (_framework.OrderServer is DatabaseOrderServer server) {
                    server.Close();
                }
            }
        }

        public static void SaveStop(Stop stop)
        {
            var framework = stop.Strategy.GetFramework();
            if (framework != null && framework.OrderServer is DatabaseOrderServer server) {
                server.SaveStop(stop);
            }
        }

        public static void RemoveStop(Stop stop)
        {
            var framework = stop.Strategy.GetFramework();
            if (framework != null && framework.OrderServer is DatabaseOrderServer server) {
                server.RemoveStop(stop);
            }
        }
    }
}