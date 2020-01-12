using System;
using System.Net.Sockets;
using System.Threading;

namespace QuantBox
{
    class GlobalWait
    {
        public static T Run<T>(int service, Func<T> action)
        {
            TcpListener listener = null;
            while (true) {
                try {
                    listener = TcpListener.Create(service);
                    listener.Start();
                    var ret = action();
                    return ret;
                }
                catch (SocketException ex) {
                    //Console.WriteLine(ex.Message);
                    Thread.Sleep(1000);
                }
                finally {
                    try {
                        listener?.Stop();
                    }
                    catch (SocketException ex) {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        public static void Run(int service, Action action)
        {
            Run(service, () => { action(); return 0; });
        }
    }
}