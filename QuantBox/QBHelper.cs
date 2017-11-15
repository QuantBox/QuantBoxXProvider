using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.Win32;
using NLog;
using NLog.Config;
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

        public static string GetSmartQuantPath()
        {
            var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{C224DA18-4901-433D-BD94-82D28B640B2C}");
            if (key != null) {
                var names = new List<string>(key.GetSubKeyNames());
                names.Sort();
                return key.GetValue("InstallLocation").ToString();
            }
            return Directory.GetParent(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)).FullName;
        }

        public static void InitNLog()
        {
            const string nlogConfig = "NLog.config";
            var configFile = Path.Combine(BasePath, nlogConfig);
            if (!File.Exists(configFile)) {
                configFile = Path.Combine(GetSmartQuantPath(), nlogConfig);
            }
            if (File.Exists(configFile)) {
                LogManager.Configuration = new XmlLoggingConfiguration(configFile, true);
            }
        }

        public const string UserDataName = "UserData";

        public static Instrument[] FilterInstrument(InstrumentDefinitionRequest request, IEnumerable<Instrument> insts)
        {
            var list = new List<Instrument>();
            foreach (var inst in insts) {
                if (request.FilterType.HasValue && request.FilterType != inst.Type) {
                    continue;
                }
                if (!String.IsNullOrEmpty(request.FilterExchange) && inst.Exchange.ToLower() != request.FilterExchange.ToLower()) {
                    continue;
                }
                if (!String.IsNullOrEmpty(request.FilterSymbol) && !inst.Symbol.ToLower().Contains(request.FilterSymbol.ToLower())) {
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

        public static string GetVersionString(Type type)
        {
            return type.Assembly.GetName().Version.ToString();
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
            while (Math.Abs(value * Math.Pow(10, precision) - Math.Round(value * Math.Pow(10, precision))) > Double.Epsilon)
                precision++;
            return precision;
        }
    }
}