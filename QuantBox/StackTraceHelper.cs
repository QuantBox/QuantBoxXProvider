using System;
using NLog;
using System.Diagnostics;

namespace QuantBox
{
    public static class StackTraceHelper
    {
        public static void PrintStackTrace(Logger logger = null)
        {
            var st = new StackTrace(true);
            for (int i = 0; i < st.FrameCount; i++) {
                // Note that at this level, there are four
                // stack frames, one for each method invocation.
                var sf = st.GetFrame(i);
                var stackIndent = $"Method: {sf.GetMethod()} File: {sf.GetFileName()} Line Number: {sf.GetFileLineNumber()}";
                if (logger != null) {
                    logger.Debug(stackIndent);
                }
                else {
                    Console.WriteLine(stackIndent);
                }
            }

        }
    }
}
