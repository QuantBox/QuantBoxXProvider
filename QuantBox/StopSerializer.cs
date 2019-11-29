using System;
using System.IO;
using LiteDB;
using SmartQuant;

namespace QuantBox
{
    public class QBStop : Stop
    {
        public QBStop(Strategy strategy, Position position, double level, StopType type, StopMode mode)
            : base(strategy, position, level, type, mode)
        {
        }

        public QBStop(Strategy strategy, Position position,
            PositionSide side, double qty,
            double level, StopType type, StopMode mode)
            : base(strategy, position, level, type, mode)
        {
            if (qty > 0) {
                this.qty = qty;
            }
            this.side = side;
        }

        public QBStop(Strategy strategy, Position position, DateTime time)
            : base(strategy, position, time)
        {
        }

        public QBStop(Strategy strategy, Position position, PositionSide side, double qty, DateTime time)
            : base(strategy, position, time)
        {
            if (qty > 0) {
                this.qty = qty;
            }
            this.side = side;
        }

        protected override double GetInstrumentPrice()
        {
            var dataManager = strategy.GetFramework()?.DataManager;
            if (dataManager == null) {
                return base.GetInstrumentPrice();
            }
            if (position.Side == PositionSide.Long) {
                var bid = dataManager.GetBid(instrument);
                if (bid != null) {
                    return GetPrice(bid.Price);
                }
            }
            if (position.Side == PositionSide.Short) {
                var ask = dataManager.GetAsk(instrument);
                if (ask != null) {
                    return GetPrice(ask.Price);
                }
            }
            var trade = dataManager.GetTrade(instrument);
            if (trade != null) {
                return GetPrice(trade.Price);
            }
            var bar = dataManager.GetBar(instrument);
            return bar != null ? GetPrice(bar.Close) : 0.0;
        }

        protected override double GetStopPrice()
        {
            initPrice = trailPrice;
            switch (mode) {
                case StopMode.Absolute:
                    switch (side) {
                        case PositionSide.Long:
                            return trailPrice - Math.Abs(level);
                        case PositionSide.Short:
                            return trailPrice + Math.Abs(level);
                        default:
                            throw new ArgumentException("Unknown position side : " + position.Side);
                    }
                case StopMode.Percent:
                    switch (side) {
                        case PositionSide.Long:
                            return trailPrice - Math.Abs(trailPrice * level);
                        case PositionSide.Short:
                            return trailPrice + Math.Abs(trailPrice * level);
                        default:
                            throw new ArgumentException("Unknown position side : " + position.Side);
                    }
                default:
                    throw new ArgumentException("Unknown stop mode : " + mode);
            }
        }
    }

    internal class StopSerializer
    {
        private readonly ObjectTableWriter _fieldsWriter = (a, b, c) => { };
        private readonly ObjectTableReader _fieldsReader = (a, b, c) => { };

        public StopSerializer(ObjectTableWriter writer, ObjectTableReader reader)
        {
            if (writer != null) {
                _fieldsWriter = writer;
            }

            if (reader != null) {
                _fieldsReader = reader;
            }
        }

        public Strategy Strategy;

        public BsonDocument ToBson(Stop s)
        {
            var doc = new BsonDocument();
            ObjectId id;
            if (s.GetObjectId() != null) {
                id = new ObjectId(s.GetObjectId());
            }
            else {
                id = ObjectId.NewObjectId();
                s.SetObjectId(id.ToByteArray());
            }
            doc["_id"] = id;
            var strategy = s.Strategy;
            if (strategy is StopStrategy ss) {
                strategy = ss.RealStrategy;
            }
            doc["strategyId"] = strategy.Id;
            doc["strategyName"] = strategy.Name;
            doc["instrument"] = s.Instrument.Symbol;

            doc["completionTime"] = s.CompletionTime;
            doc["creationTime"] = s.CreationTime;
            doc["fillMode"] = (int)s.FillMode;
            doc["filterBarSize"] = s.FilterBarSize;
            doc["filterBarType"] = (int)s.FilterBarType;
            doc["level"] = s.Level;
            doc["mode"] = (int)s.Mode;
            doc["qty"] = s.Qty;
            doc["side"] = (int)s.Side;
            doc["traceOnBar"] = s.TraceOnBar;
            doc["traceOnBarOpen"] = s.TraceOnBarOpen;
            doc["traceOnQuote"] = s.TraceOnQuote;
            doc["traceOnTrade"] = s.TraceOnTrade;
            doc["trailOnHighLow"] = s.TrailOnHighLow;
            doc["trailOnOpen"] = s.TrailOnOpen;
            doc["type"] = (int)s.Type;

            using (var stream = new MemoryStream(1024))
            using (var writer = new BinaryWriter(stream)) {
                _fieldsWriter(ObjectTableOwner.Stop, s.Fields, writer);
                if (stream.Length > 0) {
                    doc.Add("fields", stream.GetBuffer());
                }
            }
            return doc;
        }

        public Stop ToStop(BsonValue v)
        {
            var doc = (BsonDocument)v;
            var symbol = doc["instrument"].AsString;
            var inst = Strategy.GetFramework().InstrumentManager.GetBySymbol(symbol);
            if (inst == null) {
                return null;
            }

            var type = (StopType)doc["type"].AsInt32;
            var side = (PositionSide)doc["side"].AsInt32;
            var qty = doc["qty"].AsDouble;
            var position = Strategy.Portfolio.GetPosition(inst);
            QBStop stop;
            if (type != StopType.Time) {
                stop = new QBStop(
                    Strategy, position, side, qty,
                    doc["level"].AsDouble, type, (StopMode)doc["mode"].AsInt32);
            }
            else {
                stop = new QBStop(Strategy, position, side, qty, doc["completionTime"].AsDateTime);
            }
            stop.SetObjectId(doc["_id"].AsObjectId.ToByteArray());
            stop.FillMode = (StopFillMode)doc["fillMode"].AsInt32;
            stop.FilterBarSize = doc["filterBarSize"].AsInt64;
            stop.FilterBarType = (BarType)doc["filterBarType"].AsInt32;
            stop.TraceOnBar = doc["traceOnBar"].AsBoolean;
            stop.TraceOnBarOpen = doc["traceOnBarOpen"].AsBoolean;
            stop.TraceOnQuote = doc["traceOnQuote"].AsBoolean;
            stop.TraceOnTrade = doc["traceOnTrade"].AsBoolean;
            stop.TrailOnHighLow = doc["trailOnHighLow"].AsBoolean;
            stop.TrailOnOpen = doc["trailOnOpen"].AsBoolean;

            if (doc.TryGetValue("fields", out var f)) {
                var buffer = f.AsBinary;
                using (var stream = new MemoryStream(buffer))
                using (var reader = new BinaryReader(stream)) {
                    _fieldsReader(ObjectTableOwner.Stop, stop.Fields, reader);
                }
            }
            return stop;
        }
    }
}