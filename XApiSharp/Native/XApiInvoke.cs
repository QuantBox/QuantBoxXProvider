using System;

namespace QuantBox.XApi.Native
{
    internal abstract class XApiInvoke : IDisposable
    {
        public delegate IntPtr XRequest(byte type, IntPtr pApi1, IntPtr pApi2, double double1, double double2, IntPtr ptr1, int size1, IntPtr ptr2, int size2, IntPtr ptr3, int size3);

        protected const string XRequestFunction = "XRequest";

        protected IntPtr DllLib = IntPtr.Zero;

        public abstract XRequest GetXRequest();

        public virtual void Dispose()
        {
        }
    }
}
