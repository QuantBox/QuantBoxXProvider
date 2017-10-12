using System;
using System.Threading.Tasks.Dataflow;
using QuantBox.XApi;
using SmartQuant;

namespace QuantBox
{
    public partial class XProvider
    {
        private class ConnectManager
        {
            private readonly XProvider _provider;
            private readonly ActionBlock<Event> _block;
            private bool _manualDisconnecting;

            private void Process(Event @event)
            {
                switch (@event.TypeId) {
                    case EventType.OnConnect:
                        _provider.Status = ProviderStatus.Connecting;
                        ConnectClient();
                        break;
                    case EventType.OnDisconnect:
                        if (_provider.Status == ProviderStatus.Disconnecting
                            || _provider.Status == ProviderStatus.Disconnected) {
                            return;
                        }
                        _provider.Status = ProviderStatus.Disconnecting;
                        _manualDisconnecting = true;
                        DisconnectClient();
                        break;
                    case XEventType.OnClientConnected:
                        CheckConnected();
                        break;
                    case XEventType.OnClientDisconnected:
                        if (!_manualDisconnecting) {
                            if (_provider.Status == ProviderStatus.Connected) {
                                _provider.Status = ProviderStatus.Connecting;
                            }
                        }
                        break;
                    case XEventType.OnAutoReconnect:
                        if (!_manualDisconnecting && !_provider.IsConnected) {
                            DisconnectClient();
                            ConnectClient();
                        }
                        break;
                }
            }

            private void CheckConnected()
            {
                if (_provider.IsDataProvider && _provider.IsExecutionProvider) {
                    if (_provider._trader?.Connected == true && _provider._md?.Connected == true) {
                        ConnectDone();
                    }
                }
                else if (_provider.IsDataProvider) {
                    if (_provider._md.Connected) {
                        ConnectDone();
                    }
                }
                else if (_provider.IsExecutionProvider) {
                    if (_provider._trader.Connected) {
                        ConnectDone();
                    }
                }
            }

            private void ConnectDone()
            {
                _provider.Status = ProviderStatus.Connected;
                _manualDisconnecting = false;
                _provider.ConnectDone();
            }

            private void DisconnectDone()
            {
                _provider.DisconnectDone();
                _manualDisconnecting = false;
                _provider.Status = ProviderStatus.Disconnected;
            }

            private void DisconnectClient()
            {
                _provider._md?.Disconnect();
                _provider._trader?.Disconnect();
                if (_manualDisconnecting) {
                    DisconnectDone();
                }
            }

            private void ConnectClient()
            {
                try {
                    if (_provider.IsExecutionProvider) {
                        ConnectTrader();
                    }
                    if (_provider.IsDataProvider) {
                        ConnectMarketData();
                    }
                }
                catch (Exception ex) {
                    _provider.OnProviderError(-1, ex.Message);
                    _provider._logger.Error(ex);
                    _provider.Disconnect();
                }
            }

            private ConnectionInfo GetConnectionInfo(ApiType type)
            {
                foreach (var conn in _provider.Settings.Connections) {
                    if (conn.Active && (conn.Type & type) == type) {
                        return conn;
                    }
                }
                return null;
            }

            private void ConnectMarketData()
            {
                var connection = GetConnectionInfo(MarketDataClient.ApiType);
                if (connection == null) {
                    _provider._logger.Error("行情连接信息未设定.");
                    _provider.Disconnect();
                    return;
                }

                if (_provider._md == null) {
                    _provider._md = new MarketDataClient(_provider, connection);
                    _provider._md.Connect();
                }
            }

            private void ConnectTrader()
            {
                var connection = GetConnectionInfo(TraderClient.ApiType);
                if (connection == null) {
                    _provider._logger.Error("交易连接信息未设定.");
                    _provider.Disconnect();
                    return;
                }

                if (_provider._trader == null) {
                    _provider._trader = new TraderClient(_provider, connection);
                    _provider._trader.Connect();
                }
            }

            public ConnectManager(XProvider provider)
            {
                _provider = provider;
                _block = new ActionBlock<Event>((Action<Event>)Process);
            }

            public void Post(Event e)
            {
                _block.Post(e);
            }
        }
    }
}