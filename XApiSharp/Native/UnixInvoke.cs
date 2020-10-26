using System;
using System.Runtime.InteropServices;

namespace QuantBox.XApi.Native
{
    internal class UnixInvoke : XApiInvoke
    {
        [DllImport("libdl.so")]
        private static extern IntPtr dlopen(string path, int mode);
        [DllImport("libdl.so")]
        private static extern IntPtr dlsym(IntPtr handle, string symbol);
        [DllImport("libdl.so")]
        private static extern IntPtr dlerror();
        [DllImport("libdl.so")]
        private static extern int dlclose(IntPtr handle);

        public UnixInvoke(string path)
        {
            DllLib = dlopen(path, 1);
            if (DllLib == IntPtr.Zero) {
                var errptr = dlerror();
                var error = Marshal.PtrToStringAnsi(errptr);
                throw new Exception(error);
            }
        }

        public override XRequest GetXRequest()
        {
            if (DllLib == IntPtr.Zero)
                return null;

            var api = dlsym(DllLib, XRequestFunction);
            return (XRequest)Marshal.GetDelegateForFunctionPointer(api, typeof(XRequest));
        }

        public override void Dispose()
        {
            if (DllLib != IntPtr.Zero)
                dlclose(DllLib);
            DllLib = IntPtr.Zero;
        }
    }
}