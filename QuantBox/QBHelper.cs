using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using NLog;
using NLog.Config;
using NLog.LayoutRenderers;
using QuantBox.XApi;
using SmartQuant;

namespace QuantBox
{
    public static class QBHelper
    {
        private static readonly object locker = new object();
        public static readonly string BasePath;
        
        static QBHelper()
        {
            BasePath = Path.GetDirectoryName(typeof(XProvider).Assembly.Location) + Path.DirectorySeparatorChar;
        }

        public static string ReadOnlyAllText(string path)
        {
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                return new StreamReader(stream).ReadToEnd();
            }
        }

        public static string[] ReadOnlyAllLine(string path)
        {
            var lines = new List<string>();
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                var reader = new StreamReader(stream);
                while (!reader.EndOfStream)
                {
                    lines.Add(reader.ReadLine());
                }
            }
            return lines.ToArray();
        }

        public static string GetSmartQuantPath()
        {
#if NETFRAMEWORK
            var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{C224DA18-4901-433D-BD94-82D28B640B2C}");
            if (key != null)
            {
                var names = new List<string>(key.GetSubKeyNames());
                names.Sort();
                return key.GetValue("InstallLocation").ToString();
            }
#endif            
            return Directory.GetParent(Path.GetDirectoryName(typeof(Framework).Assembly.Location)).FullName;
        }

        public static void InitNLog()
        {
            lock (locker) {
                if (LogManager.Configuration != null) {
                    return;
                }

                LayoutRenderer.Register("op_logsdir", (logEvent) => Installation.LogsDir.FullName);
                const string nlogConfig = "NLog.config";
                var configFile = Path.Combine(BasePath, nlogConfig);
                if (!File.Exists(configFile)) {
                    configFile = Path.Combine(Installation.ConfigDir.FullName, nlogConfig);
                }

                if (File.Exists(configFile)) {
                    LogManager.Configuration = new XmlLoggingConfiguration(configFile);
                }
            }
        }

        public const string UserDataName = "UserData";

        public static Instrument[] FilterInstrument(InstrumentDefinitionRequest request, IEnumerable<Instrument> insts)
        {
            var list = new List<Instrument>();
            foreach (var inst in insts)
            {
                if (request.FilterType.HasValue && request.FilterType != inst.Type)
                {
                    continue;
                }
                if (!string.IsNullOrEmpty(request.FilterExchange)
                    && !string.Equals(inst.Exchange, request.FilterExchange, StringComparison.CurrentCultureIgnoreCase))
                {
                    continue;
                }
                if (!string.IsNullOrEmpty(request.FilterSymbol)
                    && !inst.Symbol.ToLower().Contains(request.FilterSymbol.ToLower()))
                {
                    continue;
                }
                list.Add(inst);
            }
            return list.ToArray();
        }

        public static string GetConfigPath()
        {
            return Path.Combine(Installation.ConfigDir.FullName, "quantbox");
        }

        public static string GetConfigPath(string name)
        {
            var dir = Path.Combine(Installation.ConfigDir.FullName, "quantbox");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            return Path.Combine(dir, $"{name}.json");
        }

        public static string GetVersionString()
        {
            return XApiHelper.GetVersionString(typeof(XProvider));
        }

        public static string GetVersionString(Type type)
        {
            return XApiHelper.GetVersionString(type);
        }

        public static string MakeAbsolutePath(string path, string basePath = null)
        {
            basePath = basePath ?? BasePath;
            //if (!basePath.EndsWith(Path.DirectorySeparatorChar.ToString()))
            //{
            //    basePath += Path.DirectorySeparatorChar;
            //}
            if (basePath != null && Uri.TryCreate(new Uri(basePath), path, out var uri))
            {
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

        public static DateTime CorrectionActionDay(DateTime local, DateTime exchange)
        {
            switch (exchange.Hour)
            {
                case 0:
                    if (local.Hour == 23)
                    {
                        return local.Date.AddDays(1).Add(exchange.TimeOfDay);
                    }
                    break;
                case 23:
                    if (local.Hour == 0)
                    {
                        return local.Date.AddDays(-1).Add(exchange.TimeOfDay);
                    }
                    break;
            }
            return local.Date.Add(exchange.TimeOfDay);
        }

        public static void LoadFromJson(object instance, Type type, JToken token)
        {
            var list = type.GetProperties();
            foreach (var prop in list)
            {
                if (!prop.CanWrite)
                {
                    continue;
                }
                var item = token[prop.Name];
                if (item == null)
                {
                    continue;
                }
                prop.SetValue(instance, item.ToObject(prop.PropertyType));
            }
        }

        public static void SaveInt(byte[] bytes, int index, int value)
        {
            bytes[index] = (byte)(value >> 24);
            bytes[index + 1] = (byte)(value >> 16);
            bytes[index + 2] = (byte)(value >> 8);
            bytes[index + 3] = (byte)value;
        }

        public static int LoadInt(byte[] bytes, int index)
        {
            return (bytes[index] << 24) | (bytes[index + 1] << 16) | (bytes[index + 2] << 8) | (bytes[index + 3] & 0xFF);
        }

        public static Bar MergeBar(Bar bar, Bar bar2)
        {
            bar.High = Math.Max(bar.High, bar2.High);
            bar.Low = Math.Min(bar.Low, bar2.Low);
            bar.Close = bar2.Close;
            bar.Volume += bar2.Volume;
            bar.OpenInt = bar2.OpenInt;
            bar.IncTurnover(bar2.GetTurnover());
            bar.DateTime = bar2.CloseDateTime;
            return bar;
        }
    }
}