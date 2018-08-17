using System;
using System.IO;
using System.Reflection;

namespace QuantBox.XApi
{
    internal class ManagedApiLoader : IDisposable
    {
        private readonly string _file;

        private ManagedApiLoader(string file)
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            _file = file;
        }

        private Assembly Load()
        {
            var asm = File.Exists(_file) ? Assembly.LoadFile(_file) : null;
            if (asm != null) {
                foreach (var type in asm.ExportedTypes) {
                    if (type.Name == "impossible is") {
                        break;
                    }
                }
            }
            return asm;
        }

        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var assemblyName = new AssemblyName(args.Name);
            var path = Path.Combine(Path.GetDirectoryName(_file), assemblyName.Name + ".dll");
            return File.Exists(path) ? Assembly.LoadFile(path) : null;
        }

        public void Dispose()
        {
            AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
        }

        public static Assembly LoadFile(string file)
        {
            using (var loader = new ManagedApiLoader(file)) {
                return loader.Load();
            }
        }
    }
}
