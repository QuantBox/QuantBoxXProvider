using System;
using System.Runtime.InteropServices;
using System.Text;

namespace QuantBox.XApi.Native
{
    internal class WindowsInvoke : XApiInvoke
    {
        private enum LoadLibraryFlags : uint
        {
            DontResolveDllReferences = 0x00000001,
            LoadIgnoreCodeAuthzLevel = 0x00000010,
            LoadLibraryAsDatafile = 0x00000002,
            LoadLibraryAsDatafileExclusive = 0x00000040,
            LoadLibraryAsImageResource = 0x00000020,
            LoadWithAlteredSearchPath = 0x00000008
        }

        [Flags]
        private enum FormatMessageFlags : uint
        {
            FormatMessageAllocateBuffer = 0x00000100,
            FormatMessageIgnoreInserts = 0x00000200,
            FormatMessageFromSystem = 0x00001000,
            FormatMessageArgumentArray = 0x00002000,
            FormatMessageFromHmodule = 0x00000800,
            FormatMessageFromString = 0x00000400
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr LoadLibrary(string lpFileName);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);
        [DllImport("kernel32.dll")]
        private static extern bool FreeLibrary(IntPtr hModule);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern int GetDllDirectory(int bufSize, StringBuilder buf);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetDllDirectory(string lpPathName);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr LoadLibraryEx(string lpFileName, IntPtr hReservedNull, LoadLibraryFlags dwFlags);
        [DllImport("kernel32.dll")]
        private static extern uint FormatMessage(FormatMessageFlags dwFlags, IntPtr lpSource, uint dwMessageId, uint dwLanguageId, ref IntPtr lpBuffer, uint nSize, IntPtr pArguments);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr LocalFree(IntPtr hMem);

        private static string GetSysErrMsg(uint errCode)
        {
            var lpMsgBuf = IntPtr.Zero;
            const FormatMessageFlags flags = FormatMessageFlags.FormatMessageAllocateBuffer
                                             | FormatMessageFlags.FormatMessageIgnoreInserts
                                             | FormatMessageFlags.FormatMessageFromSystem;
            var chars = FormatMessage(flags/*0x1300*/, IntPtr.Zero, errCode, 0, ref lpMsgBuf, 255, IntPtr.Zero);
            if (chars == 0) {
                return null;
            }
            var msg = Marshal.PtrToStringAnsi(lpMsgBuf);
            LocalFree(lpMsgBuf);
            return msg;
        }

        public WindowsInvoke(string path)
        {
            DllLib = LoadLibraryEx(path, IntPtr.Zero, LoadLibraryFlags.LoadWithAlteredSearchPath);
            if (DllLib == IntPtr.Zero) {
                var errCode = Marshal.GetLastWin32Error();
                var errMsg = GetSysErrMsg((uint)errCode);
                throw new Exception($"GetLastError:{errCode},FormatMessage:{errMsg} {path}");
            }
        }

        public override XRequest GetXRequest()
        {
            if (DllLib == IntPtr.Zero)
                return null;
            var function = GetProcAddress(DllLib, XRequestFunction);
            return (XRequest)Marshal.GetDelegateForFunctionPointer(function, typeof(XRequest));
        }

        public override void Dispose()
        {
            if (DllLib != IntPtr.Zero) {
                FreeLibrary(DllLib);
            }
            DllLib = IntPtr.Zero;
        }
    }
}
