
namespace QuantBox
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using LiteDB;
    using SmartQuant;

    internal enum ProviderSettingsType
    {
        TradingDay = 1,
        MaxLocalId = 2
    }

    internal class DatabaseOrderServer : OrderServer
    {
        #region Settings
        public class SettingsManager
        {
            private readonly LiteCollection<BsonDocument> _collection;

            public SettingsManager(LiteCollection<BsonDocument> collection)
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
                return data != null ? data["value"].AsBinary : default(byte[]);
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
                return data != null ? data["value"].AsDateTime : default(DateTime);
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
                return data != null ? data["value"].AsDecimal : default(decimal);
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
                return data != null ? data["value"].AsDouble : default(double);
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
                return data != null ? data["value"].AsGuid : default(Guid);
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
                return data != null ? data["value"].AsInt32 : default(int);
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
                return data != null ? data["value"].AsInt64 : default(long);
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
                return data != null ? data["value"].AsString : default(string);
            }

        }
        #endregion

        private readonly Framework _framework;
        private readonly LiteDatabase _database;
        private readonly LiteCollection<ExecutionCommand> _orders;
        private readonly LiteCollection<ExecutionReport> _reports;
        private readonly LiteCollection<Stop> _stops;

        public Action<ExecutionCommand> SetOrderId = _ => { };

        private readonly Skyline.IdArray<StopStrategy> _stopStrategys = new Skyline.IdArray<StopStrategy>(100);

        private void SetSubSide(ExecutionCommand cmd, SubSide subSide)
        {
            ExecutionCommandSerializer.subSide.Setter(cmd, subSide);
        }

        private void SetStopStrategy(Stop stop)
        {
            if (!(stop.Strategy is StopStrategy)) {
                var ss = _stopStrategys[stop.Strategy.Id];
                if (ss == null) {
                    ss = new StopStrategy(_framework, stop.Strategy, string.Empty);
                    _stopStrategys[stop.Strategy.Id] = ss;
                }
                stop.SetStrategy(ss);
            }
        }

        public DatabaseOrderServer(Framework framework, LiteDatabase database) : base(framework)
        {
            _framework = framework;
            _database = database;
            _orders = _database.GetCollection<ExecutionCommand>("orders");
            _reports = _database.GetCollection<ExecutionReport>("reports");
            _stops = _database.GetCollection<Stop>("stops");
            Settings = new SettingsManager(_database.GetCollection<BsonDocument>("settings"));
        }

        public SettingsManager Settings { get; }

        public override void Save(ExecutionMessage message, int id = -1)
        {
            try {
                switch (message.TypeId) {
                    case DataObjectType.ExecutionCommand:
                        SetOrderId((ExecutionCommand)message);
                        _orders.Insert((ExecutionCommand)message);
                        break;
                    case DataObjectType.ExecutionReport:
                        _reports.Insert((ExecutionReport)message);
                        break;
                }
            }
            catch (Exception exception) {
                Console.WriteLine(exception);
            }
        }

        public override List<ExecutionMessage> Load(string series = null)
        {
            var idMap = new IdArray<string>();
            var subSideMap = new IdArray<SubSide>();

            var reports = _reports.FindAll().ToList();
            foreach (var report in reports) {
                idMap[report.OrderId] = report.ProviderOrderId;
                subSideMap[report.OrderId] = report.SubSide;
            }
            var orders = _orders.FindAll().ToList();
            var maxLocalId = string.Empty;
            foreach (var order in orders) {
                order.ProviderOrderId = idMap[order.OrderId];
                SetSubSide(order, subSideMap[order.OrderId]);
                maxLocalId = DealProcessor.GetOrderId(order);
            }
            Settings.Set(ProviderSettingsType.MaxLocalId, maxLocalId);
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