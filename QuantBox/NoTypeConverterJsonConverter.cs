using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace QuantBox
{
    /// <summary>
    /// 解决使用了 TypeConverter 以后类型无法用 Json.Net 进行系列化的问题
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class NoTypeConverterJsonConverter<T> : JsonConverter
    {
        private static readonly IContractResolver Resolver = new NoTypeConverterContractResolver();

        private class NoTypeConverterContractResolver : DefaultContractResolver
        {
            protected override JsonContract CreateContract(Type objectType)
            {
                if (typeof(T).IsAssignableFrom(objectType)) {
                    var contract = CreateObjectContract(objectType);
                    // Also null out the converter to prevent infinite recursion.
                    contract.Converter = null;
                    return contract;
                }
                return base.CreateContract(objectType);
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return JsonSerializer.CreateDefault(new JsonSerializerSettings { ContractResolver = Resolver }).Deserialize(reader, objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JsonSerializer.CreateDefault(new JsonSerializerSettings { ContractResolver = Resolver }).Serialize(writer, value);
        }
    }
}