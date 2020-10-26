using System;

namespace QuantBox.XApi.Native
{
    internal class XApiInvokeProxy : IDisposable
    {
        private readonly XApiInvoke _invoke;
        private readonly XApiInvoke.XRequest _request;

        public XApiInvokeProxy(string path)
        {
            if (Environment.OSVersion.Platform == PlatformID.Unix) {
                _invoke = new UnixInvoke(path);
            }
            else {
                _invoke = new WindowsInvoke(path);
            }
            if (_invoke != null) {
                _request = _invoke.GetXRequest();
            }
        }

        ~XApiInvokeProxy()
        {
            Dispose();
        }

        public void Dispose()
        {
            _invoke?.Dispose();
        }

        public IntPtr XRequest(QueryType type, IntPtr api, IntPtr ptr1, int size1)
        {
            return _request((byte)type, api, IntPtr.Zero, 0, 0, ptr1, size1, IntPtr.Zero, 0, IntPtr.Zero, 0);
        }

        public IntPtr XRequest(RequestType type, IntPtr api, IntPtr ptr1, IntPtr ptr2)
        {
            return _request((byte)type, api, IntPtr.Zero, 0, 0, ptr1, 0, ptr2, 0, IntPtr.Zero, 0);
        }

        public IntPtr XRequest(RequestType type, IntPtr api1, IntPtr api2, double double1, double double2,
            IntPtr ptr1, int size1, IntPtr ptr2, int size2, IntPtr ptr3, int size3)
        {
            return _request((byte)type, api1, api2, double1, double2, ptr1, size1, ptr2, size2, ptr3, size3);
        }

        public IntPtr XRequest(RequestType type)
        {
            return XRequest(type, IntPtr.Zero);
        }

        public IntPtr XRequest(RequestType type, IntPtr api)
        {
            return XRequest(type, api, IntPtr.Zero, 0, 0, IntPtr.Zero, 0, IntPtr.Zero, 0, IntPtr.Zero, 0);
        }
    }
}
