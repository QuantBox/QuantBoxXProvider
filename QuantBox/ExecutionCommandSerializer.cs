using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using LiteDB;
using QuantBox.XApi;
using Skyline;
using SmartQuant;
using OrderSide = SmartQuant.OrderSide;
using OrderType = SmartQuant.OrderType;
using TimeInForce = SmartQuant.TimeInForce;

namespace QuantBox
{
    internal class ExecutionCommandSerializer
    {
        #region FieldInfos
        private static readonly Dictionary<string, FieldInfo> Fields = new Dictionary<string, FieldInfo>();
        private static readonly FastFieldInfo<ExecutionCommand, string> account;
        private static readonly FastFieldInfo<ExecutionCommand, int> algoId;
        private static readonly FastFieldInfo<ExecutionCommand, int> clId;
        private static readonly FastFieldInfo<ExecutionCommand, int> clientId;
        private static readonly FastFieldInfo<ExecutionCommand, string> clientID;
        private static readonly FastFieldInfo<ExecutionCommand, string> clOrderId;
        private static readonly FastFieldInfo<ExecutionCommand, byte> currencyId;
        private static readonly FastFieldInfo<ExecutionCommand, DateTime> dateTime;
        private static readonly FastFieldInfo<ExecutionCommand, string> execInst;
        private static readonly FastFieldInfo<ExecutionCommand, ExecutionCommandType> executionCommandType;
        private static readonly FastFieldInfo<ExecutionCommand, DateTime> expireTime;
        private static readonly FastFieldInfo<ExecutionCommand, int> id;
        private static readonly FastFieldInfo<ExecutionCommand, int> instrumentId;
        private static readonly FastFieldInfo<ExecutionCommand, bool> isLoaded;
        private static readonly FastFieldInfo<ExecutionCommand, double> minQty;
        private static readonly FastFieldInfo<ExecutionCommand, string> oCA;
        private static readonly FastFieldInfo<ExecutionCommand, int> orderId;
        private static readonly FastFieldInfo<ExecutionCommand, OrderType> ordType;
        private static readonly FastFieldInfo<ExecutionCommand, double> pegDifference;
        private static readonly FastFieldInfo<ExecutionCommand, int> portfolioId;
        private static readonly FastFieldInfo<ExecutionCommand, double> price;
        private static readonly FastFieldInfo<ExecutionCommand, byte> providerId;
        private static readonly FastFieldInfo<ExecutionCommand, string> providerOrderId;
        private static readonly FastFieldInfo<ExecutionCommand, double> qty;
        private static readonly FastFieldInfo<ExecutionCommand, byte> routeId;
        private static readonly FastFieldInfo<ExecutionCommand, OrderSide> side;
        private static readonly FastFieldInfo<ExecutionCommand, double> stopPx;
        private static readonly FastFieldInfo<ExecutionCommand, int> strategyId;
        internal static readonly FastFieldInfo<ExecutionCommand, SubSide> subSide;
        private static readonly FastFieldInfo<ExecutionCommand, string> symbol;
        private static readonly FastFieldInfo<ExecutionCommand, string> text;
        private static readonly FastFieldInfo<ExecutionCommand, TimeInForce> timeInForce;
        private static readonly FastFieldInfo<ExecutionCommand, DateTime> transactTime;
        private static readonly FastFieldInfo<ExecutionCommand, byte> typeId;
        #endregion

        static ExecutionCommandSerializer()
        {
            foreach (var field in typeof(ExecutionCommand).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)) {
                var attr = field.GetCustomAttribute<DataMemberAttribute>();
                if (attr != null && attr.Name != "order") {
                    Fields[attr.Name] = field;
                }
            }

            account = new FastFieldInfo<ExecutionCommand, string>(Fields["account"]);
            algoId = new FastFieldInfo<ExecutionCommand, int>(Fields["algoId"]);
            clId = new FastFieldInfo<ExecutionCommand, int>(Fields["clId"]);
            clientId = new FastFieldInfo<ExecutionCommand, int>(Fields["clientId"]);
            clientID = new FastFieldInfo<ExecutionCommand, string>(Fields["clientID"]);
            clOrderId = new FastFieldInfo<ExecutionCommand, string>(Fields["clOrderId"]);
            currencyId = new FastFieldInfo<ExecutionCommand, byte>(Fields["currencyId"]);
            dateTime = new FastFieldInfo<ExecutionCommand, DateTime>(Fields["dateTime"]);
            execInst = new FastFieldInfo<ExecutionCommand, string>(Fields["execInst"]);
            executionCommandType = new FastFieldInfo<ExecutionCommand, ExecutionCommandType>(Fields["executionCommandType"]);
            expireTime = new FastFieldInfo<ExecutionCommand, DateTime>(Fields["expireTime"]);
            id = new FastFieldInfo<ExecutionCommand, int>(Fields["id"]);
            instrumentId = new FastFieldInfo<ExecutionCommand, int>(Fields["instrumentId"]);
            isLoaded = new FastFieldInfo<ExecutionCommand, bool>(Fields["isLoaded"]);
            minQty = new FastFieldInfo<ExecutionCommand, double>(Fields["minQty"]);
            oCA = new FastFieldInfo<ExecutionCommand, string>(Fields["oCA"]);
            orderId = new FastFieldInfo<ExecutionCommand, int>(Fields["orderId"]);
            ordType = new FastFieldInfo<ExecutionCommand, OrderType>(Fields["ordType"]);
            pegDifference = new FastFieldInfo<ExecutionCommand, double>(Fields["pegDifference"]);
            portfolioId = new FastFieldInfo<ExecutionCommand, int>(Fields["portfolioId"]);
            price = new FastFieldInfo<ExecutionCommand, double>(Fields["price"]);
            providerId = new FastFieldInfo<ExecutionCommand, byte>(Fields["providerId"]);
            providerOrderId = new FastFieldInfo<ExecutionCommand, string>(Fields["providerOrderId"]);
            qty = new FastFieldInfo<ExecutionCommand, double>(Fields["qty"]);
            routeId = new FastFieldInfo<ExecutionCommand, byte>(Fields["routeId"]);
            side = new FastFieldInfo<ExecutionCommand, OrderSide>(Fields["side"]);
            stopPx = new FastFieldInfo<ExecutionCommand, double>(Fields["stopPx"]);
            strategyId = new FastFieldInfo<ExecutionCommand, int>(Fields["strategyId"]);
            subSide = new FastFieldInfo<ExecutionCommand, SubSide>(Fields["subSide"]);
            symbol = new FastFieldInfo<ExecutionCommand, string>(Fields["symbol"]);
            text = new FastFieldInfo<ExecutionCommand, string>(Fields["text"]);
            timeInForce = new FastFieldInfo<ExecutionCommand, TimeInForce>(Fields["timeInForce"]);
            transactTime = new FastFieldInfo<ExecutionCommand, DateTime>(Fields["transactTime"]);
            typeId = new FastFieldInfo<ExecutionCommand, byte>(Fields["typeId"]);
        }

        private readonly ObjectTableWriter _fieldsWriter = (a, b, c) => { };
        private readonly ObjectTableReader _fieldsReader = (a, b, c) => { };

        public ExecutionCommandSerializer(ObjectTableWriter writer, ObjectTableReader reader)
        {
            if (writer != null) {
                _fieldsWriter = writer;
            }

            if (reader != null) {
                _fieldsReader = reader;
            }
        }

        private void WriteTable(BsonDocument doc, ExecutionMessage msg)
        {
            var info = (QuantBoxOrderInfo)msg.Fields[QuantBoxConst.OrderInfoOffset];
            if (info != null) {
                doc["orderInfo"] = info.Save();
            }
            using (var stream = new MemoryStream(1024))
            using (var writer = new BinaryWriter(stream)) {
                _fieldsWriter(ObjectTableOwner.Order, msg.Fields, writer);
                if (stream.Length > 0) {
                    doc["fields"] = stream.GetBuffer();
                }
            }
        }

        private void ReadTable(BsonDocument doc, ExecutionMessage msg)
        {
            if (doc.TryGetValue("orderInfo", out var v)) {
                var data = v.AsBinary;
                var info = new QuantBoxOrderInfo();
                info.Load(data);
                msg.Fields[QuantBoxConst.OrderInfoOffset] = info;
            }

            if (doc.TryGetValue("fields", out var f) && !f.IsNull) {
                var buffer = f.AsBinary;
                using (var stream = new MemoryStream(buffer))
                using (var reader = new BinaryReader(stream)) {
                    _fieldsReader(ObjectTableOwner.Order, msg.Fields, reader);
                }
            }
        }

        public BsonValue ToBson(ExecutionCommand cmd)
        {
            var doc = new BsonDocument();
            doc["account"] = account.Getter(cmd);
            doc["algoId"] = algoId.Getter(cmd);
            doc["clId"] = clId.Getter(cmd);
            doc["clientId"] = clientId.Getter(cmd);
            doc["clientID"] = clientID.Getter(cmd);
            doc["clOrderId"] = clOrderId.Getter(cmd);
            doc["currencyId"] = (int)currencyId.Getter(cmd);
            doc["dateTime"] = dateTime.Getter(cmd);
            doc["execInst"] = execInst.Getter(cmd);
            doc["executionCommandType"] = (int)executionCommandType.Getter(cmd);
            doc["expireTime"] = expireTime.Getter(cmd);
            doc["id"] = id.Getter(cmd);
            doc["instrumentId"] = instrumentId.Getter(cmd);
            doc["isLoaded"] = isLoaded.Getter(cmd);
            doc["minQty"] = minQty.Getter(cmd);
            doc["oCA"] = oCA.Getter(cmd);
            doc["orderId"] = orderId.Getter(cmd);
            doc["ordType"] = (int)ordType.Getter(cmd);
            doc["pegDifference"] = pegDifference.Getter(cmd);
            doc["portfolioId"] = portfolioId.Getter(cmd);
            doc["price"] = price.Getter(cmd);
            doc["providerId"] = (int)providerId.Getter(cmd);
            doc["providerOrderId"] = providerOrderId.Getter(cmd);
            doc["qty"] = qty.Getter(cmd);
            doc["routeId"] = (int)routeId.Getter(cmd);
            doc["side"] = (int)side.Getter(cmd);
            doc["stopPx"] = stopPx.Getter(cmd);
            doc["strategyId"] = strategyId.Getter(cmd);
            doc["subSide"] = (int)subSide.Getter(cmd);
            doc["symbol"] = symbol.Getter(cmd);
            doc["text"] = text.Getter(cmd);
            doc["timeInForce"] = (int)timeInForce.Getter(cmd);
            doc["transactTime"] = transactTime.Getter(cmd);
            doc["typeId"] = (int)typeId.Getter(cmd);
            WriteTable(doc, cmd);
            return doc;
        }

        public ExecutionCommand ToCommand(BsonValue v)
        {
            var doc = (BsonDocument)v;
            var cmd = new ExecutionCommand();
            account.Setter(cmd, doc["account"].AsString);
            algoId.Setter(cmd, doc["algoId"].AsInt32);
            clId.Setter(cmd, doc["clId"].AsInt32);
            clientId.Setter(cmd, doc["clientId"].AsInt32);
            clientID.Setter(cmd, doc["clientID"].AsString);
            clOrderId.Setter(cmd, doc["clOrderId"].AsString);
            currencyId.Setter(cmd, (byte)doc["currencyId"].AsInt32);
            dateTime.Setter(cmd, doc["dateTime"].AsDateTime);
            execInst.Setter(cmd, doc["execInst"].AsString);
            executionCommandType.Setter(cmd, (ExecutionCommandType)doc["executionCommandType"].AsInt32);
            expireTime.Setter(cmd, doc["expireTime"].AsDateTime);
            id.Setter(cmd, doc["id"].AsInt32);
            instrumentId.Setter(cmd, doc["instrumentId"].AsInt32);
            isLoaded.Setter(cmd, doc["isLoaded"].AsBoolean);
            minQty.Setter(cmd, doc["minQty"].AsDouble);
            oCA.Setter(cmd, doc["oCA"].AsString);
            orderId.Setter(cmd, doc["orderId"].AsInt32);
            ordType.Setter(cmd, (OrderType)doc["ordType"].AsInt32);
            pegDifference.Setter(cmd, doc["pegDifference"].AsDouble);
            portfolioId.Setter(cmd, doc["portfolioId"].AsInt32);
            price.Setter(cmd, doc["price"].AsDouble);
            providerId.Setter(cmd, (byte)doc["providerId"].AsInt32);
            providerOrderId.Setter(cmd, doc["providerOrderId"].AsString);
            qty.Setter(cmd, doc["qty"].AsDouble);
            routeId.Setter(cmd, (byte)doc["routeId"].AsInt32);
            side.Setter(cmd, (OrderSide)doc["side"].AsInt32);
            stopPx.Setter(cmd, doc["stopPx"].AsDouble);
            strategyId.Setter(cmd, doc["strategyId"].AsInt32);
            subSide.Setter(cmd, (SubSide)doc["subSide"].AsInt32);
            symbol.Setter(cmd, doc["symbol"].AsString);
            text.Setter(cmd, doc["text"].AsString);
            timeInForce.Setter(cmd, (TimeInForce)doc["timeInForce"].AsInt32);
            transactTime.Setter(cmd, doc["transactTime"].AsDateTime);
            typeId.Setter(cmd, (byte)doc["typeId"].AsInt32);
            ReadTable(doc, cmd);
            return cmd;
        }
    }
}