using System;
using System.Threading.Tasks.Dataflow;

namespace QuantBox.XApi
{
    internal class StatusPublisher
    {
        private readonly IXSpi _spi;
        private readonly ActionBlock<(ConnectionStatus, RspUserLoginField)> _statusAction;

        private void StatusAction(ValueTuple<ConnectionStatus, RspUserLoginField> data)
        {
            _spi.ProcessConnectionStatus(data.Item1, data.Item2);
        }

        public StatusPublisher(IXSpi spi)
        {
            _spi = spi;
            _statusAction = new ActionBlock<(ConnectionStatus, RspUserLoginField)>((Action<(ConnectionStatus, RspUserLoginField)>)StatusAction);
        }

        public void Post(ConnectionStatus status, RspUserLoginField field = null)
        {
            _statusAction.Post((status, field));
        }
    }
}
