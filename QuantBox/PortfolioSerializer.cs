using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using LiteDB;
using Skyline;
using SmartQuant;

namespace QuantBox
{
    internal class PortfolioSerializer
    {
        private static readonly FastFieldInfo<Portfolio, int> id;
        private static readonly FastFieldInfo<Portfolio, bool> isLoaded;
        private static readonly FastFieldInfo<Portfolio, int> parentId;

        static PortfolioSerializer()
        {
            var fields = new Dictionary<string, FieldInfo>();
            foreach (var field in typeof(Portfolio).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)) {
                var attr = field.GetCustomAttribute<DataMemberAttribute>();
                if (attr != null) {
                    fields[attr.Name] = field;
                }
            }
            id = new FastFieldInfo<Portfolio, int>(fields["id"]);
            isLoaded = new FastFieldInfo<Portfolio, bool>(fields["isLoaded"]);
            parentId = new FastFieldInfo<Portfolio, int>(fields["parentId"]);
        }

        public static BsonValue ToBson(Portfolio p)
        {
            var doc = new BsonDocument();
            doc["_id"] = p.Id + 1;
            doc["name"] = p.Name;
            doc["description"] = p.Description;
            doc["parentId"] = p.ParentId;
            return doc;
        }

        public static Portfolio ToPortfolio(BsonValue value)
        {
            var doc = (BsonDocument)value;
            var p = new Portfolio(doc["name"].AsString);
            p.Description = doc["description"].AsString;
            id.Setter(p, doc["_id"].AsInt32 - 1);
            parentId.Setter(p, doc["parentId"].AsInt32);
            isLoaded.Setter(p, true);
            return p;
        }
    }
}