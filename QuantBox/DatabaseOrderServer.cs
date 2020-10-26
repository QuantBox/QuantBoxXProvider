using System.Runtime.CompilerServices;

namespace QuantBox
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using LiteDB;
    using SmartQuant;

    internal enum ProviderSettingsType
    {
        TradingDay = 1
    }

    public class PositionStore
    {
        private readonly Framework _framework;
        private readonly IdArray<PositionManager> _positionManagers = new IdArray<PositionManager>(200);

        public PositionStore(Framework framework)
        {
            _framework = framework;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DualPosition GetPosition(int strategyId, int instrumentId, bool createNew = true)
        {
            return GetPositionManager(strategyId, createNew)?.GetPosition(
                _framework.InstrumentManager.GetById(instrumentId), createNew);
        }

        public PositionManager GetPositionManager(int strategyId, bool createNew = true)
        {
            var manager = _positionManagers[strategyId];
            if (manager != null) {
                return manager;
            }

            if (createNew) {
                var strategy = _framework.StrategyManager.FindStrategy(strategyId);
                if (strategy == null) {
                    //OrderAgent Strategy
                    manager = new PositionManager(GetLastMarketCloseTime());
                    _positionManagers[strategyId] = manager;
                    return manager;
                }
                return GetPositionManager(strategy);
            }

            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DualPosition GetPosition(Order order)
        {
            return GetPositionManager(order.strategyId).GetPosition(order.Instrument);
        }

        public PositionManager GetPositionManager(Strategy strategy)
        {
            var manager = _positionManagers[strategy.Id];
            if (manager != null) {
                return manager;
            }

            if (strategy is InstrumentStrategy iss && iss.IsInstance) {
                manager = GetPositionManager(iss.Parent.Id);
            }
            else {
                manager = new PositionManager(GetLastMarketCloseTime());
            }
            _positionManagers[strategy.Id] = manager;
            return manager;
        }

        public void Load(IList<ExecutionCommand> cmdList, IdArray<List<ExecutionReport>> recordMap)
        {
            var marketCloseTime = GetLastMarketCloseTime();
            var tradingDay = DateTime.MinValue;

            foreach (var cmd in cmdList) {
                if (cmd.Type != ExecutionCommandType.Send) {
                    continue;
                }
                var order = new Order(cmd) {
                    Instrument = _framework.InstrumentManager.GetById(cmd.InstrumentId)
                };
                if (tradingDay == DateTime.MinValue) {
                    tradingDay = order.TransactTime.Date;
                }
                var manager = GetPositionManager(order.strategyId);
                var position = GetPosition(order);
                if (tradingDay < order.TransactTime.Date) {
                    manager.ChangeTradingDay();
                }

                position.FrozenPosition(order);
                var reports = recordMap[order.Id];
                if (reports != null) {
                    foreach (var report in reports) {
                        report.Order = order;
                        position.ProcessExecutionReport(report);
                    }
                }
            }

            if (cmdList.Last().TransactTime < marketCloseTime) {
                for (int i = 0; i < _positionManagers.Size; i++) {
                    _positionManagers[i]?.ChangeTradingDay();
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void UpdatePosition(ExecutionCommand cmd)
        {
            GetPosition(cmd.StrategyId, cmd.InstrumentId).FrozenPosition(cmd.Order);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void UpdatePosition(ExecutionReport report)
        {
            GetPosition(report.StrategyId, report.InstrumentId, false)?.ProcessExecutionReport(report);
        }

        public static TimeSpan MarketCloseTime { get; set; } = new TimeSpan(15, 30, 0);
        private static DateTime GetLastMarketCloseTime()
        {
            if (DateTime.Now.TimeOfDay > MarketCloseTime) {
                return DateTime.Today.Add(MarketCloseTime);
            }

            var date = DateTime.Today.AddDays(-1);
            while (date.DayOfWeek != DayOfWeek.Saturday) {
                date = date.AddDays(-1);
            }

            return date.Add(MarketCloseTime);
        }

        public void ChangeTradingDay()
        {
            for (int i = 0; i < _positionManagers.Size; i++) {
                _positionManagers[i]?.ChangeTradingDay();
            }
        }
    }

    internal class DatabaseOrderServer : OrderServer
    {
        #region Settings
        public class SettingsManager
        {
            private readonly ILiteCollection<BsonDocument> _collection;

            public SettingsManager(ILiteCollection<BsonDocument> collection)
            {
                _collection = collection;
            }

            public void Set(ProviderSettingsType type, bool value)
            {
                var doc = new BsonDocument {
                    ["_id"] = (int)type,
                    ["value"] = value
                };
                _collection.Upsert(doc);
            }
            public bool GetAsBoolean(ProviderSettingsType type)
            {
                var data = _collection.FindById((int)type);
                return data != null && data["value"].AsBoolean;
            }
            public void Set(ProviderSettingsType type, byte[] value)
            {
                var doc = new BsonDocument {
                    ["_id"] = (int)type,
                    ["value"] = value
                };
                _collection.Upsert(doc);
            }
            public byte[] GetAsBinary(ProviderSettingsType type)
            {
                var data = _collection.FindById((int)type);
                return data != null ? data["value"].AsBinary : default;
            }
            public void Set(ProviderSettingsType type, DateTime value)
            {
                var doc = new BsonDocument {
                    ["_id"] = (int)type,
                    ["value"] = value
                };
                _collection.Upsert(doc);
            }
            public DateTime GetAsDateTime(ProviderSettingsType type)
            {
                var data = _collection.FindById((int)type);
                return data != null ? data["value"].AsDateTime : default;
            }
            public void Set(ProviderSettingsType type, decimal value)
            {
                var doc = new BsonDocument {
                    ["_id"] = (int)type,
                    ["value"] = value
                };
                _collection.Upsert(doc);
            }
            public decimal GetAsDecimal(ProviderSettingsType type)
            {
                var data = _collection.FindById((int)type);
                return data != null ? data["value"].AsDecimal : default;
            }
            public void Set(ProviderSettingsType type, double value)
            {
                var doc = new BsonDocument {
                    ["_id"] = (int)type,
                    ["value"] = value
                };
                _collection.Upsert(doc);
            }
            public double GetAsDouble(ProviderSettingsType type)
            {
                var data = _collection.FindById((int)type);
                return data != null ? data["value"].AsDouble : default;
            }
            public void Set(ProviderSettingsType type, Guid value)
            {
                var doc = new BsonDocument {
                    ["_id"] = (int)type,
                    ["value"] = value
                };
                _collection.Upsert(doc);
            }
            public Guid GetAsGuid(ProviderSettingsType type)
            {
                var data = _collection.FindById((int)type);
                return data != null ? data["value"].AsGuid : default;
            }
            public void Set(ProviderSettingsType type, int value)
            {
                var doc = new BsonDocument {
                    ["_id"] = (int)type,
                    ["value"] = value
                };
                _collection.Upsert(doc);
            }
            public int GetAsInt32(ProviderSettingsType type)
            {
                var data = _collection.FindById((int)type);
                return data != null ? data["value"].AsInt32 : default;
            }
            public void Set(ProviderSettingsType type, long value)
            {
                var doc = new BsonDocument {
                    ["_id"] = (int)type,
                    ["value"] = value
                };
                _collection.Upsert(doc);
            }

            public long GetAsInt64(ProviderSettingsType type)
            {
                var data = _collection.FindById((int)type);
                return data != null ? data["value"].AsInt64 : 0L;
            }

            public void Set(ProviderSettingsType type, string value)
            {
                var doc = new BsonDocument {
                    ["_id"] = (int)type,
                    ["value"] = value
                };
                _collection.Upsert(doc);
            }

            public string GetAsString(ProviderSettingsType type)
            {
                var data = _collection.FindById((int)type);
                return data?["value"].AsString;
            }

        }
        #endregion

        private readonly Framework _framework;
        private readonly LiteDatabase _database;
        private readonly string _instanceName;
        private readonly TickIdGen _idGen = new TickIdGen();
        private readonly ILiteCollection<ExecutionCommand> _orders;
        private readonly ILiteCollection<ExecutionReport> _reports;
        private readonly ILiteCollection<Stop> _stops;
        private readonly PositionStore _store;

        public Action<ExecutionCommand> SetOrderId = _ => { };
        public string LastProviderId { get; private set; } = "0";

        private readonly Skyline.IdArray<StopStrategy> _stopStrategist = new Skyline.IdArray<StopStrategy>(100);

        private void SetStopStrategy(Stop stop)
        {
            if (stop.Strategy is StopStrategy) {
                return;
            }

            var ss = _stopStrategist[stop.Strategy.Id];
            if (ss == null) {
                ss = new StopStrategy(_framework, stop.Strategy, string.Empty);
                _stopStrategist[stop.Strategy.Id] = ss;
            }
            stop.SetStrategy(ss);
        }

        public DatabaseOrderServer(
            Framework framework,
            LiteDatabase database,
            string instanceName) : base(framework)
        {
            _framework = framework;
            _database = database;
            _instanceName = instanceName;
            _orders = _database.GetCollection<ExecutionCommand>("orders");
            _reports = _database.GetCollection<ExecutionReport>("reports");
            _stops = _database.GetCollection<Stop>("stops");
            Settings = new SettingsManager(_database.GetCollection<BsonDocument>("settings"));
            _store = new PositionStore(_framework);
        }

        public SettingsManager Settings { get; }

        public PositionStore PositionStore => _store;

        public override void Save(ExecutionMessage message, int id = -1)
        {
            try {
                switch (message.TypeId) {
                    case DataObjectType.ExecutionCommand:
                        var nextId = _idGen.Next().ToString();
                        message.Order.ClOrderId = nextId;
                        message.ClOrderId = nextId;
                        message.ProviderOrderId = nextId;
                        var cmd = (ExecutionCommand)message;
                        SetOrderId(cmd);
                        _orders.Insert(cmd);
                        PositionStore.UpdatePosition(cmd);
                        break;
                    case DataObjectType.ExecutionReport:
                        var report = (ExecutionReport)message;
                        _reports.Insert(report);
                        PositionStore.UpdatePosition(report);
                        break;
                }
            }
            catch (Exception exception) {
                Console.WriteLine(exception);
            }
        }

        public override List<ExecutionMessage> Load(string series = null)
        {
            //var subSideMap = new IdArray<SubSide>();
            var recordMap = new IdArray<List<ExecutionReport>>();
            var reports = _reports.FindAll().ToList();
            foreach (var report in reports) {
                var temp = recordMap[report.OrderId];
                if (temp == null) {
                    temp = new List<ExecutionReport>();
                    recordMap[report.OrderId] = temp;
                }
                temp.Add(report);
                //subSideMap[report.OrderId] = report.SubSide;
            }
            var orders = _orders.FindAll().ToList();
            foreach (var order in orders) {
                LastProviderId = order.ProviderOrderId;
                if (recordMap[order.OrderId] != null) {
                    order.ProviderOrderId = recordMap[order.OrderId][0].ProviderOrderId;
                }
                //SetSubSide(order, subSideMap[order.OrderId]);
            }

            PositionStore.Load(orders, recordMap);
            var list = new List<ExecutionMessage>();
            list.AddRange(orders);
            list.AddRange(reports);
            return list;
        }

        public HashSet<string> GetTrades(DateTime tradingDay)
        {
            var trades = new HashSet<string>();
            var result = _reports.Find(Query.GT("transactTime", tradingDay));
            foreach (var report in result) {
                trades.Add($"{report.ExecId}_{report.Side}");
            }
            return trades;
        }

        internal void SaveStop(Stop stop)
        {
            SetStopStrategy(stop);
            _stops.Upsert(stop);
        }

        internal void RemoveStop(Stop stop)
        {
            _stops.Delete(new ObjectId(stop.GetObjectId()));
        }

        internal void LoadStop(Strategy s)
        {
            ((DataEventMapper)_database.Mapper).StopSerializer.Strategy = s;
            foreach (var stop in _stops.Find(Query.EQ("strategyId", s.Id))) {
                s.AddStop(stop);
                SetStopStrategy(stop);
            }
        }

        public override void Close()
        {
            _database.Dispose();
        }
    }
}