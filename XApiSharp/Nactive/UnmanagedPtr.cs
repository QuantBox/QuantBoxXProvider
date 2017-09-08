using System;
using System.Runtime.InteropServices;

namespace QuantBox.XApi.Nactive
{
    internal struct UnmanagedPtr<T> : IDisposable
    {
        public UnmanagedPtr(T obj)
        {
            Ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(T)));
            Marshal.StructureToPtr(obj, Ptr, false);
        }

        public UnmanagedPtr(string s)
        {
            Ptr = Marshal.StringToHGlobalAnsi(s);
        }

        public static implicit operator IntPtr(UnmanagedPtr<T> data)
        {
            return data.Ptr;
        }

        public void Dispose()
        {
            if (Ptr != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(Ptr);
                Ptr = IntPtr.Zero;
            }
        }

        public IntPtr Ptr { get; private set; }
    }
}