using System;
using Newtonsoft.Json.Linq;

namespace QuantBox
{
    internal class Helper
    {
        public static DateTime CorrectionActionDay(DateTime local, DateTime exchange)
        {
            switch (exchange.Hour) {
                case 0:
                    if (local.Hour == 23) {
                        return local.Date.AddDays(1).Add(exchange.TimeOfDay);
                    }
                    break;
                case 23:
                    if (local.Hour == 0) {
                        return local.Date.AddDays(-1).Add(exchange.TimeOfDay);
                    }
                    break;
            }
            return local.Date.Add(exchange.TimeOfDay);
        }

        public static void LoadFromJson(object instance, Type type, JToken token)
        {
            var list = type.GetProperties();
            foreach (var prop in list) {
                if (!prop.CanWrite) {
                    continue;
                }
                var item = token[prop.Name];
                if (item == null) {
                    continue;
                }
                prop.SetValue(instance, item.ToObject(prop.PropertyType));
            }
        }
    }
}