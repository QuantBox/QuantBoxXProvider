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
                    _connectStart = DateTime.Now;
                    if (!_provider.EnableAutoConnect || _provider.InTradingSession()) {
                        ConnectClient();
                    }
                    else {
                        TradingCalendar.Instance.Init(DateTime.Today, host: _provider.DataHost);
                        _provider.logger.Info("等待交易时段......");
                        _provider.StartTimerTask();
                        _manualDisconnecting = false;
                    }
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
                        _provider.logger.Info("交易时段内自动重连.");
                        DisconnectClient();
                        _connectStart = DateTime.Now;
                        ConnectClient();
                    }
                    break;
                case XEventType.OnAutoDisconnect:
                    if (!_manualDisconnecting) {
                        _provider.logger.Info("非交易时段内自动断开.");
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
                if (_provider.trader?.Connected == true && _provider.market?.Connected == true) {
                    ConnectDone();
                }
            }
            else if (_provider.IsDataProvider) {
                if (_provider.market.Connected) {
                    ConnectDone();
                }
            }
            else if (_provider.IsExecutionProvider) {
                if (_provider.trader.Connected) {
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
            _provider.SetStatus(ProviderStatus.Disconnected);
        }

        private void DisconnectClient()
        {
            _provider.market?.Disconnect();
            _provider.trader?.Disconnect();
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
                _provider.logger.Error(ex);
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
                _provider.logger.Error("行情连接信息未设定.");
                _provider.Disconnect();
                return;
            }
            if (!CheckConnection(connection)) {
                _provider.Disconnect();
                return;
            }
            _provider.market?.Disconnect();
            _provider.market = new MarketDataClient(_provider, connection);
            _provider.market.Connect();
        }

        private bool CheckConnection(ConnectionInfo conn)
        {
            if (_provider.GetUserInfo(conn.User) == null) {
                _provider.logger.Error("连接用户信息未设定.");
                return false;
            }
            if (_provider.GetServerInfo(conn.Server, conn.UseType) == null) {
                _provider.logger.Error("连接服务器信息未设定.");
                return false;
            }
            return true;
        }

        private void ConnectTrader()
        {
            var connection = GetConnectionInfo(TraderClient.ApiType);
            if (connection == null) {
                _provider.logger.Error("交易连接信息未设定.");
                _provider.Disconnect();
                return;
            }
            if (!CheckConnection(connection)) {
                _provider.Disconnect();
                return;
            }
            _provider.trader?.Disconnect();
            _provider.trader = new TraderClient(_provider, connection);
            _provider.OnTraderCreated();
            _provider.trader.Connect();
        }

        public ConnectManager(XProvider provider)
        {
            _provider = provider;
            _block = new ActionBlock<Event>(Process, DataflowHelper.SpscBlockOptions);
        }

        public void Post(Event e)
        {
            _block.Post(e);
        }

        public TraderClient CreateTrader(IXSpi spi)
        {
            var connection = GetConnectionInfo(TraderClient.ApiType);
            if (connection == null) {
                return null;
            }
            if (!CheckConnection(connection)) {
                return null;
            }

            return new TraderClient(_provider, connection, spi);
        }
    }
}