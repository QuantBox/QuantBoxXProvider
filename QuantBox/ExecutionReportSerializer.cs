using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using LiteDB;
using Skyline;
using SmartQuant;

namespace QuantBox
{
    internal class ExecutionReportSerializer
    {
        #region FieldInfos
        private static readonly Dictionary<string, FieldInfo> Fields = new Dictionary<string, FieldInfo>();
        private static readonly FastFieldInfo<ExecutionReport, string> account;
        private static readonly FastFieldInfo<ExecutionReport, int> algoId;
        private static readonly FastFieldInfo<ExecutionReport, double> avgPx;
        private static readonly FastFieldInfo<ExecutionReport, int> clId;
        private static readonly FastFieldInfo<ExecutionReport, int> clientId;
        private static readonly FastFieldInfo<ExecutionReport, string> clientID;
        private static readonly FastFieldInfo<ExecutionReport, string> clOrderId;
        private static readonly FastFieldInfo<ExecutionReport, double> commission;
        private static readonly FastFieldInfo<ExecutionReport, double> cumQty;
        private static readonly FastFieldInfo<ExecutionReport, byte> currencyId;
        private static readonly FastFieldInfo<ExecutionReport, DateTime> dateTime;
        private static readonly FastFieldInfo<ExecutionReport, string> execId;
        private static readonly FastFieldInfo<ExecutionReport, string> execInst;
        private static readonly FastFieldInfo<ExecutionReport, ExecType> execType;
        private static readonly FastFieldInfo<ExecutionReport, DateTime> expireTime;
        private static readonly FastFieldInfo<ExecutionReport, int> id;
        private static readonly FastFieldInfo<ExecutionReport, int> instrumentId;
        private static readonly FastFieldInfo<ExecutionReport, bool> isLoaded;
        private static readonly FastFieldInfo<ExecutionReport, double> lastPx;
        private static readonly FastFieldInfo<ExecutionReport, double> lastQty;
        private static readonly FastFieldInfo<ExecutionReport, double> leavesQty;
        private static readonly FastFieldInfo<ExecutionReport, double> minQty;
        private static readonly FastFieldInfo<ExecutionReport, string> oCA;
        private static readonly FastFieldInfo<ExecutionReport, int> orderId;
        private static readonly FastFieldInfo<ExecutionReport, double> ordQty;
        private static readonly FastFieldInfo<ExecutionReport, OrderStatus> ordStatus;
        private static readonly FastFieldInfo<ExecutionReport, OrderType> ordType;
        private static readonly FastFieldInfo<ExecutionReport, double> pegDifference;
        private static readonly FastFieldInfo<ExecutionReport, int> portfolioId;
        private static readonly FastFieldInfo<ExecutionReport, double> price;
        private static readonly FastFieldInfo<ExecutionReport, byte> providerId;
        private static readonly FastFieldInfo<ExecutionReport, string> providerOrderId;
        private static readonly FastFieldInfo<ExecutionReport, byte> routeId;
        private static readonly FastFieldInfo<ExecutionReport, OrderSide> side;
        private static readonly FastFieldInfo<ExecutionReport, double> stopPx;
        private static readonly FastFieldInfo<ExecutionReport, int> strategyId;
        private static readonly FastFieldInfo<ExecutionReport, SubSide> subSide;
        private static readonly FastFieldInfo<ExecutionReport, string> text;
        private static readonly FastFieldInfo<ExecutionReport, TimeInForce> timeInForce;
        private static readonly FastFieldInfo<ExecutionReport, DateTime> transactTime;
        private static readonly FastFieldInfo<ExecutionReport, byte> typeId;
        #endregion

        static ExecutionReportSerializer()
        {
            foreach (var field in typeof(ExecutionReport).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)) {
                var attr = field.GetCustomAttribute<DataMemberAttribute>();
                if (attr != null && attr.Name != "order") {
                    Fields[attr.Name] = field;
                }
            }
            account = new FastFieldInfo<ExecutionReport, string>(Fields["account"]);
            algoId = new FastFieldInfo<ExecutionReport, int>(Fields["algoId"]);
            avgPx = new FastFieldInfo<ExecutionReport, double>(Fields["avgPx"]);
            clId = new FastFieldInfo<ExecutionReport, int>(Fields["clId"]);
            clientId = new FastFieldInfo<ExecutionReport, int>(Fields["clientId"]);
            clientID = new FastFieldInfo<ExecutionReport, string>(Fields["clientID"]);
            clOrderId = new FastFieldInfo<ExecutionReport, string>(Fields["clOrderId"]);
            commission = new FastFieldInfo<ExecutionReport, double>(Fields["commission"]);
            cumQty = new FastFieldInfo<ExecutionReport, double>(Fields["cumQty"]);
            currencyId = new FastFieldInfo<ExecutionReport, byte>(Fields["currencyId"]);
            dateTime = new FastFieldInfo<ExecutionReport, DateTime>(Fields["dateTime"]);
            execId = new FastFieldInfo<ExecutionReport, string>(Fields["execId"]);
            execInst = new FastFieldInfo<ExecutionReport, string>(Fields["execInst"]);
            execType = new FastFieldInfo<ExecutionReport, ExecType>(Fields["execType"]);
            expireTime = new FastFieldInfo<ExecutionReport, DateTime>(Fields["expireTime"]);
            id = new FastFieldInfo<ExecutionReport, int>(Fields["id"]);
            instrumentId = new FastFieldInfo<ExecutionReport, int>(Fields["instrumentId"]);
            isLoaded = new FastFieldInfo<ExecutionReport, bool>(Fields["isLoaded"]);
            lastPx = new FastFieldInfo<ExecutionReport, double>(Fields["lastPx"]);
            lastQty = new FastFieldInfo<ExecutionReport, double>(Fields["lastQty"]);
            leavesQty = new FastFieldInfo<ExecutionReport, double>(Fields["leavesQty"]);
            minQty = new FastFieldInfo<ExecutionReport, double>(Fields["minQty"]);
            oCA = new FastFieldInfo<ExecutionReport, string>(Fields["oCA"]);
            orderId = new FastFieldInfo<ExecutionReport, int>(Fields["orderId"]);
            ordQty = new FastFieldInfo<ExecutionReport, double>(Fields["ordQty"]);
            ordStatus = new FastFieldInfo<ExecutionReport, OrderStatus>(Fields["ordStatus"]);
            ordType = new FastFieldInfo<ExecutionReport, OrderType>(Fields["ordType"]);
            pegDifference = new FastFieldInfo<ExecutionReport, double>(Fields["pegDifference"]);
            portfolioId = new FastFieldInfo<ExecutionReport, int>(Fields["portfolioId"]);
            price = new FastFieldInfo<ExecutionReport, double>(Fields["price"]);
            providerId = new FastFieldInfo<ExecutionReport, byte>(Fields["providerId"]);
            providerOrderId = new FastFieldInfo<ExecutionReport, string>(Fields["providerOrderId"]);
            routeId = new FastFieldInfo<ExecutionReport, byte>(Fields["routeId"]);
            side = new FastFieldInfo<ExecutionReport, OrderSide>(Fields["side"]);
            stopPx = new FastFieldInfo<ExecutionReport, double>(Fields["stopPx"]);
            strategyId = new FastFieldInfo<ExecutionReport, int>(Fields["strategyId"]);
            subSide = new FastFieldInfo<ExecutionReport, SubSide>(Fields["subSide"]);
            text = new FastFieldInfo<ExecutionReport, string>(Fields["text"]);
            timeInForce = new FastFieldInfo<ExecutionReport, TimeInForce>(Fields["timeInForce"]);
            transactTime = new FastFieldInfo<ExecutionReport, DateTime>(Fields["transactTime"]);
            typeId = new FastFieldInfo<ExecutionReport, byte>(Fields["typeId"]);
        }

        public BsonValue ToBson(ExecutionReport cmd)
        {
            var doc = new BsonDocument();
            doc["account"] = account.Getter(cmd);
            doc["algoId"] = algoId.Getter(cmd);
            doc["avgPx"] = avgPx.Getter(cmd);
            doc["clId"] = clId.Getter(cmd);
            doc["clientId"] = clientId.Getter(cmd);
            doc["clientID"] = clientID.Getter(cmd);
            doc["clOrderId"] = clOrderId.Getter(cmd);
            doc["commission"] = commission.Getter(cmd);
            doc["cumQty"] = cumQty.Getter(cmd);
            doc["currencyId"] = (int)currencyId.Getter(cmd);
            doc["dateTime"] = dateTime.Getter(cmd);
            doc["execId"] = execId.Getter(cmd);
            doc["execInst"] = execInst.Getter(cmd);
            doc["execType"] = (int)execType.Getter(cmd);
            doc["expireTime"] = expireTime.Getter(cmd);
            doc["id"] = id.Getter(cmd);
            doc["instrumentId"] = instrumentId.Getter(cmd);
            doc["isLoaded"] = isLoaded.Getter(cmd);
            doc["lastPx"] = lastPx.Getter(cmd);
            doc["lastQty"] = lastQty.Getter(cmd);
            doc["leavesQty"] = leavesQty.Getter(cmd);
            doc["minQty"] = minQty.Getter(cmd);
            doc["oCA"] = oCA.Getter(cmd);
            doc["orderId"] = orderId.Getter(cmd);
            doc["ordQty"] = ordQty.Getter(cmd);
            doc["ordStatus"] = (int)ordStatus.Getter(cmd);
            doc["ordType"] = (int)ordType.Getter(cmd);
            doc["pegDifference"] = pegDifference.Getter(cmd);
            doc["portfolioId"] = portfolioId.Getter(cmd);
            doc["price"] = price.Getter(cmd);
            doc["providerId"] = (int)providerId.Getter(cmd);
            doc["providerOrderId"] = providerOrderId.Getter(cmd);
            doc["routeId"] = (int)routeId.Getter(cmd);
            doc["side"] = (int)side.Getter(cmd);
            doc["stopPx"] = stopPx.Getter(cmd);
            doc["strategyId"] = strategyId.Getter(cmd);
            doc["subSide"] = (int)subSide.Getter(cmd);
            doc["text"] = text.Getter(cmd);
            doc["timeInForce"] = (int)timeInForce.Getter(cmd);
            doc["transactTime"] = transactTime.Getter(cmd);
            doc["typeId"] = (int)typeId.Getter(cmd);
            return doc;
        }

        public ExecutionReport ToReport(BsonValue v)
        {
            var doc = (BsonDocument)v;
            var cmd = new ExecutionReport();
            account.Setter(cmd, doc["account"].AsString);
            algoId.Setter(cmd, doc["algoId"].AsInt32);
            avgPx.Setter(cmd, doc["avgPx"].AsDouble);
            clId.Setter(cmd, doc["clId"].AsInt32);
            clientId.Setter(cmd, doc["clientId"].AsInt32);
            clientID.Setter(cmd, doc["clientID"].AsString);
            clOrderId.Setter(cmd, doc["clOrderId"].AsString);
            commission.Setter(cmd, doc["commission"].AsDouble);
            cumQty.Setter(cmd, doc["cumQty"].AsDouble);
            currencyId.Setter(cmd, (byte)doc["currencyId"].AsInt32);
            dateTime.Setter(cmd, doc["dateTime"].AsDateTime);
            execId.Setter(cmd, doc["execId"].AsString);
            execInst.Setter(cmd, doc["execInst"].AsString);
            execType.Setter(cmd, (ExecType)doc["execType"].AsInt32);
            expireTime.Setter(cmd, doc["expireTime"].AsDateTime);
            id.Setter(cmd, doc["id"].AsInt32);
            instrumentId.Setter(cmd, doc["instrumentId"].AsInt32);
            isLoaded.Setter(cmd, doc["isLoaded"].AsBoolean);
            lastPx.Setter(cmd, doc["lastPx"].AsDouble);
            lastQty.Setter(cmd, doc["lastQty"].AsDouble);
            leavesQty.Setter(cmd, doc["leavesQty"].AsDouble);
            minQty.Setter(cmd, doc["minQty"].AsDouble);
            oCA.Setter(cmd, doc["oCA"].AsString);
            orderId.Setter(cmd, doc["orderId"].AsInt32);
            ordQty.Setter(cmd, doc["ordQty"].AsDouble);
            ordStatus.Setter(cmd, (OrderStatus)doc["ordStatus"].AsInt32);
            ordType.Setter(cmd, (OrderType)doc["ordType"].AsInt32);
            pegDifference.Setter(cmd, doc["pegDifference"].AsDouble);
            portfolioId.Setter(cmd, doc["portfolioId"].AsInt32);
            price.Setter(cmd, doc["price"].AsDouble);
            providerId.Setter(cmd, (byte)doc["providerId"].AsInt32);
            providerOrderId.Setter(cmd, doc["providerOrderId"].AsString);
            routeId.Setter(cmd, (byte)doc["routeId"].AsInt32);
            side.Setter(cmd, (OrderSide)doc["side"].AsInt32);
            stopPx.Setter(cmd, doc["stopPx"].AsDouble);
            strategyId.Setter(cmd, doc["strategyId"].AsInt32);
            subSide.Setter(cmd, (SubSide)doc["subSide"].AsInt32);
            text.Setter(cmd, doc["text"].AsString);
            timeInForce.Setter(cmd, (TimeInForce)doc["timeInForce"].AsInt32);
            transactTime.Setter(cmd, doc["transactTime"].AsDateTime);
            typeId.Setter(cmd, (byte)doc["typeId"].AsInt32);
            return cmd;
        }
    }
}