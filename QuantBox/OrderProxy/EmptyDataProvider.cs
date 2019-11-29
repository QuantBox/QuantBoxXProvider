using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartQuant;

namespace QuantBox.OrderProxy
{
    internal class EmptyDataProvider : IDataProvider
    {
        public static readonly EmptyDataProvider Instance;
        static EmptyDataProvider() 
        {
            Instance = new EmptyDataProvider(null);
        }

        private ProviderStatus _status;
        private readonly Framework _framework;

        public EmptyDataProvider(Framework framework) 
        {
            _framework = framework;
        }

        public ProviderStatus Status {
            get => _status;
            set {
                if (_status != value) {
                    _status = value;
                    _framework?.EventServer.OnProviderStatusChanged(this);
                }
            } 
        }

        public bool IsConnecting => _status == ProviderStatus.Connecting;

        public bool IsConnected => _status == ProviderStatus.Connected;

        public bool IsDisconnecting => _status == ProviderStatus.Disconnecting;

        public bool IsDisconnected => _status == ProviderStatus.Disconnected;

        public bool Enabled { get; set; }
        public byte Id { get; set; }
        public string Name { get; set; }

        public void Connect()
        {
            Status = ProviderStatus.Connected;
        }

        public bool Connect(int timeout)
        {
            Connect();
            return true;
        }

        public void Disconnect()
        {
            Status = ProviderStatus.Connected;
        }

        public void Subscribe(Instrument instrument)
        {
        }

        public void Subscribe(InstrumentList instrument)
        {
        }

        public void Unsubscribe(Instrument instrument)
        {
        }

        public void Unsubscribe(InstrumentList instrument)
        {
        }
    }
}
