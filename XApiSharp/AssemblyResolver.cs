using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security;

namespace QuantBox.XApi
{
    public static class AssemblyResolver
    {
        private static readonly ConcurrentDictionary<string, int> ScanPaths = new ConcurrentDictionary<string, int>();
        private static string[] _paths = new string[0];

        private static void AddPathStringToEnvironment(string path)
        {
            try {
                var environmentVariable = Environment.GetEnvironmentVariable("PATH");
                if (environmentVariable != null && !environmentVariable.Contains(path)) {
                    Environment.SetEnvironmentVariable("PATH", path + ";" + environmentVariable);
                    Trace.WriteLine($"{path} added to Path.");
                }
            }
            catch (SecurityException) {
                Trace.WriteLine("Changing PATH not allowed");
            }
        }

        static AssemblyResolver()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomainAssemblyResolve;
        }

        public static void AddPath(string path)
        {
            if (ScanPaths.TryAdd(path, 1)) {
                AddPathStringToEnvironment(path);
                _paths = ScanPaths.Keys.ToArray();
            }
        }

        private static Assembly CurrentDomainAssemblyResolve(object sender, ResolveEventArgs args)
        {
            var assemblyName = new AssemblyName(args.Name);
            foreach (var path in _paths) {
                var file = Path.Combine(path, assemblyName.Name + ".dll");
                if (File.Exists(file))
                    return Assembly.LoadFile(file);
            }
            return null;
        }
    }
}