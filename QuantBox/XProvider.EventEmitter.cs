using System.Threading;
using SmartQuant;

namespace QuantBox
{
    public partial class XProvider
    {
        #region Unimportance
        internal interface IEventEmitter
        {
            void EmitData(DataObject data, bool queued = true);
            void EmitExecutionReport(ExecutionReport report, bool queued = true);
            void EmitAccountData(AccountData data);
            void EmitAccountReport(AccountReport report, bool queued = true);
            void Open();
            void Close();
        }

        private class EventEmitter : IEventEmitter
        {
            private readonly XProvider _provider;

            public EventEmitter(XProvider provider)
            {
                _provider = provider;
            }

            public void EmitData(DataObject data, bool queued = true)
            {
                _provider.EmitData(data, queued);
            }

            public void EmitExecutionReport(ExecutionReport report, bool queued = true)
            {
                _provider.EmitExecutionReport(report, queued);
            }

            public void EmitAccountData(AccountData data)
            {
                _provider.EmitAccountData(data);
            }

            public void EmitAccountReport(AccountReport report, bool queued = true)
            {
                _provider.EmitAccountReport(report, queued);
            }

            public void Open()
            {
            }

            public void Close()
            {
            }
        }
        #endregion

        private class EventDebugEmitter : IEventEmitter
        {
            private readonly XProvider _provider;
            private readonly EventPipe _dataPipe;
            private readonly EventQueue _dataQueue;
            private readonly EventPipe _executionPipe;
            private readonly EventQueue _executionQueue;
            private readonly EventQueue _accountQueue;
            private Thread _thread;
            private bool _exit;

            private void ThreadRun()
            {
                while (true) {
                    if (_exit) {
                        return;
                    }

                    Event e = null;
                    if (!_executionPipe.IsEmpty()) {
                        e = _executionPipe.Read();
                    }
                    if (!_dataPipe.IsEmpty() && e == null) {
                        e = _dataPipe.Read();
                    }
                    if (e != null) {
                        switch (e.TypeId) {
                            case EventType.AccountData:
                                _provider.EmitAccountData((AccountData)e);
                                break;
                            case EventType.AccountReport:
                                _provider.EmitAccountReport((AccountReport)e);
                                break;
                            case EventType.ExecutionReport:
                                _provider.EmitExecutionReport((ExecutionReport)e);
                                break;
                            default:
                                _provider.EmitData((DataObject)e);
                                break;
                        }
                    }
                    if (e == null) {
                        Thread.Sleep(1);
                    }
                }
            }

            public EventDebugEmitter(XProvider provider)
            {
                _provider = provider;
                _dataPipe = new EventPipe(provider.framework);
                _dataQueue = new EventQueue(1, 0, 2, 25000, provider.framework.EventBus);
                _dataPipe.Add(_dataQueue);
                _executionPipe = new EventPipe(provider.framework);
                _executionQueue = new EventQueue(2, 0, 2, 25000, provider.framework.EventBus);
                _executionPipe.Add(_executionQueue);
                _accountQueue = new EventQueue(2, 0, 2, 100, provider.framework.EventBus);
                _executionPipe.Add(_accountQueue);
            }

            public void EmitData(DataObject data, bool queued = true)
            {
                _dataQueue.Enqueue(data);
            }

            public void EmitExecutionReport(ExecutionReport report, bool queued = true)
            {
                _executionQueue.Enqueue(report);
            }

            public void EmitAccountData(AccountData data)
            {
                _accountQueue.Enqueue(data);
            }

            public void EmitAccountReport(AccountReport report, bool queued = true)
            {
                _accountQueue.Enqueue(report);
            }

            public void Open()
            {
                if (_thread == null) {
                    _exit = false;
                    _dataQueue.Clear();
                    _executionQueue.Clear();
                    _thread = new Thread(ThreadRun);
                    _thread.IsBackground = true;
                    _thread.Start();
                }
            }

            public void Close()
            {
                _exit = true;
                _thread?.Join();
                _thread = null;
            }
        }
    }
}