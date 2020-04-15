using System;
using System.Threading.Tasks.Dataflow;

namespace QuantBox.XApi
{
    internal class StatusPublisher
    {
        private readonly IXSpi _spi;
        private readonly ActionBlock<(ConnectionStatus, RspUserLoginField)> _statusAction;

        private void StatusAction((ConnectionStatus status, RspUserLoginField login) data)
        {
            _spi.ProcessConnectionStatus(data.status, data.login);
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
