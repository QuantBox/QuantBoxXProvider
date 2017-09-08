using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using SmartQuant;

namespace QuantBox
{
    public static class QBHelper
    {
        public static readonly string BasePath;

        static QBHelper()
        {
            BasePath = Path.GetDirectoryName(typeof(XProvider).Assembly.Location) + Path.DirectorySeparatorChar;
        }

        public const string UserDataName = "UserData";

        public static Instrument[] FilterInstrument(InstrumentDefinitionRequest request, IEnumerable<Instrument> insts)
        {
            var list = new List<Instrument>();
            foreach (var inst in insts) {
                if (request.FilterType.HasValue && request.FilterType != inst.Type) {
                    continue;
                }
                if (!string.IsNullOrEmpty(request.FilterExchange) && inst.Exchange.ToLower() != request.FilterExchange.ToLower()) {
                    continue;
                }
                if (!string.IsNullOrEmpty(request.FilterSymbol) && !inst.Symbol.ToLower().Contains(request.FilterSymbol.ToLower())) {
                    continue;
                }
                list.Add(inst);
            }
            return list.ToArray();
        }

        public static string GetConfigPath(string name)
        {
            var dir = Path.Combine(Installation.ConfigDir.FullName, "thanf");
            if (!Directory.Exists(dir)) {
                Directory.CreateDirectory(dir);
            }
            return Path.Combine(dir, $"{name}.json");
        }

        public static string GetVersionString()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public static string MakeAbsolutePath(string path, string basePath = null)
        {
            basePath = basePath ?? BasePath;
            if (basePath != null && Uri.TryCreate(new Uri(basePath), path, out var uri)) {
                return uri.LocalPath.Replace('/', Path.DirectorySeparatorChar);
            }
            return path;
        }

        public static int GetPrecision(double value)
        {
            var precision = 0;
            while (Math.Abs(value * Math.Pow(10, precision) - Math.Round(value * Math.Pow(10, precision))) > double.Epsilon)
                precision++;
            return precision;
        }
    }
}