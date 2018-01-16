using System;
using System.Threading;
using System.Threading.Tasks.Dataflow;
using QuantBox.XApi;
using SmartQuant;

namespace QuantBox
{
    internal class ConnectManager
    {
        private readonly XProvider _provider;
        private readonly ActionBlock<Event> _block;
        private bool _manualDisconnecting;
        private DateTime _connectStart = DateTime.MaxValue;

        private void Process(Event @event)
        {
            switch (@event.TypeId) {
                case EventType.OnConnect:
                    _provider.SetStatus(ProviderStatus.Connecting);
                    ConnectClient();
                    break;
                case EventType.OnDisconnect:
                    _provider.SetStatus(ProviderStatus.Disconnecting);
                    _manualDisconnecting = true;
                    DisconnectClient();
                    break;
                case XEventType.OnClientConnected:
                    CheckConnected();
                    break;
                case XEventType.OnClientDisconnected:
                    if (!_manualDisconnecting) {
                        if (_provider.Status == ProviderStatus.Connected) {
                            _provider.SetStatus(ProviderStatus.Connecting);
                        }
                    }
                    break;
                case XEventType.OnAutoReconnect:
                    if (!_manualDisconnecting
                        && !_provider.IsConnected
                        && _connectStart != DateTime.MaxValue
                        && (DateTime.Now - _connectStart).TotalMinutes > _provider.ConnectTimeout) {
                        _provider.Logger.Info("交易时段内自动重连");
                        DisconnectClient();
                        ConnectClient();
                    }
                    break;
                case XEventType.OnAutoDisconnect:
                    if (!_manualDisconnecting) {
                        _provider.Logger.Info("非交易时段内自动断开");
                        if (_provider.Status == ProviderStatus.Connected) {
                            _provider.SetStatus(ProviderStatus.Connecting);
                        }
                        DisconnectClient();
                    }
                    break;
            }
        }

        private void CheckConnected()
        {
            if (_provider.IsConnected) {
                return;
            }
            if (_provider.IsDataProvider && _provider.IsExecutionProvider) {
                if (_provider.Trader?.Connected == true && _provider.Market?.Connected == true) {
                    ConnectDone();
                }
            }
            else if (_provider.IsDataProvider) {
                if (_provider.Market.Connected) {
                    ConnectDone();
                }
            }
            else if (_provider.IsExecutionProvider) {
                if (_provider.Trader.Connected) {
                    ConnectDone();
                }
            }
        }

        private void ConnectDone()
        {
            _provider.SetStatus(ProviderStatus.Connected);
            _manualDisconnecting = false;
            _provider.ConnectDone();
        }

        private void DisconnectDone()
        {
            _provider.DisconnectDone();
            _manualDisconnecting = false;
            _provider.SetStatus(ProviderStatus.Disconnected);
        }

        private void DisconnectClient()
        {
            _provider.Market?.Disconnect();
            _provider.Trader?.Disconnect();
            if (_manualDisconnecting) {
                DisconnectDone();
            }
        }

        private void ConnectClient()
        {
            try {
                _connectStart = DateTime.Now;
                if (_provider.IsExecutionProvider) {
                    ConnectTrader();
                }
                if (_provider.IsDataProvider) {
                    ConnectMarketData();
                }
            }
            catch (Exception ex) {
                _provider.OnProviderError(-1, ex.Message);
                _provider.Logger.Error(ex);
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
                _provider.Logger.Error("行情连接信息未设定.");
                _provider.Disconnect();
                return;
            }

            _provider.Market?.Disconnect();
            _provider.Market = new MarketDataClient(_provider, connection);
            _provider.Market.Connect();
        }

        private void ConnectTrader()
        {
            var connection = GetConnectionInfo(TraderClient.ApiType);
            if (connection == null) {
                _provider.Logger.Error("交易连接信息未设定.");
                _provider.Disconnect();
                return;
            }

            _provider.Trader?.Disconnect();
            _provider.Trader = new TraderClient(_provider, connection);
            _provider.Trader.Connect();
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