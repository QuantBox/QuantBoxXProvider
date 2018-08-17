using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace QuantBox.XApi.Nactive
{
    internal class XApi : IXApi, IDisposable
    {
        private delegate void RspHandler(ref ResponseData data);

        private XApiInvokeProxy _proxy;
        private readonly XApiInvoke.XRequest _callback;
        private readonly RspHandler[] _handlers = new RspHandler[byte.MaxValue];
        private IntPtr _api;
        private IXSpi _spi;
        private readonly SubscribedList _subscribedList = new SubscribedList();

        #region Response Handler
        private void InitHandler()
        {
            void DefaultHandler(ref ResponseData data) { }
            for (var i = 0; i < _handlers.Length; i++) {
                _handlers[i] = DefaultHandler;
            }
            _handlers[(byte)ResponseType.OnConnectionStatus] = ProcessConnectionStatus;
            _handlers[(byte)ResponseType.OnRtnError] = ProcessError;
            _handlers[(byte)ResponseType.OnRspQryInstrument] = ProcessQryInstrument;
            _handlers[(byte)ResponseType.OnRspQryInvestorPosition] = ProcessQryPosition;
            _handlers[(byte)ResponseType.OnRspQryInvestor] = ProcessQryInvestor;
            _handlers[(byte)ResponseType.OnRspQryTradingAccount] = ProcessQryAccount;
            _handlers[(byte)ResponseType.OnRspQrySettlementInfo] = ProcessQrySettlementInfo;
            _handlers[(byte)ResponseType.OnRspQryOrder] = ProcessQryOrder;
            _handlers[(byte)ResponseType.OnRspQryTrade] = ProcessQryTrade;
            _handlers[(byte)ResponseType.OnRtnDepthMarketData] = ProcessDepthMarketData;
            _handlers[(byte)ResponseType.OnRtnOrder] = ProcessRtnOrder;
            _handlers[(byte)ResponseType.OnRtnTrade] = ProcessRtnTrade;
            _handlers[(byte)ResponseType.OnLog] = ProcessLog;
        }
        private IntPtr ProcessResponse(byte type, IntPtr api1, IntPtr api2, double double1, double double2, IntPtr ptr1,
            int size1, IntPtr ptr2, int size2, IntPtr ptr3, int size3)
        {
            var data = new ResponseData(type, api1, api2, double1, double2, ptr1, size1, ptr2, size2, ptr3, size3);
            _handlers[data.RspType](ref data);
            return IntPtr.Zero;
        }

        private void ProcessConnectionStatus(ref ResponseData data)
        {
            var status = (ConnectionStatus)data.Double1;
            switch (status) {
                case ConnectionStatus.Disconnected:
                case ConnectionStatus.Uninitialized:
                    Connected = false;
                    break;
                case ConnectionStatus.Done:
                    Connected = true;
                    Resubscribe();
                    break;
            }

            if (data.Size1 > 0) {
                var field = PInvokeUtility.PtrToStruct<InternalRspUserLoginField>(data.Ptr1);
                UserLogin = new RspUserLoginField(field);
            }
            _spi.ProcessConnectionStatus(status, UserLogin);
        }
        private void ProcessError(ref ResponseData data)
        {
            var field = PInvokeUtility.PtrToStruct<InternalErrorField>(data.Ptr1);
            _spi.ProcessError(new ErrorField(field));
        }
        private void ProcessLog(ref ResponseData data)
        {
            var field = PInvokeUtility.PtrToStruct<InternalLogField>(data.Ptr1);
            _spi.ProcessLog(new LogField(field));
        }
        private void ProcessQryInstrument(ref ResponseData data)
        {
            var field = PInvokeUtility.PtrToStruct<InstrumentField>(data.Ptr1);
            _spi.ProcessQryInstrument(field, Math.Abs(data.Double1) > double.Epsilon);
        }
        private void ProcessQryPosition(ref ResponseData data)
        {
            var field = PInvokeUtility.PtrToStruct<PositionField>(data.Ptr1);
            _spi.ProcessQryPosition(field, Math.Abs(data.Double1) > double.Epsilon);
        }
        private void ProcessQryInvestor(ref ResponseData data)
        {
            var field = PInvokeUtility.PtrToStruct<InvestorField>(data.Ptr1);
            _spi.ProcessQryInvestor(field, Math.Abs(data.Double1) > double.Epsilon);
        }
        private void ProcessQryAccount(ref ResponseData data)
        {
            var field = PInvokeUtility.PtrToStruct<AccountField>(data.Ptr1);
            _spi.ProcessQryAccount(field, Math.Abs(data.Double1) > double.Epsilon);
        }
        private void ProcessQrySettlementInfo(ref ResponseData data)
        {
            var field = PInvokeUtility.GetSettlementInfo(data.Ptr1);
            _spi.ProcessQrySettlementInfo(field, Math.Abs(data.Double1) > double.Epsilon);
        }
        private void ProcessQryOrder(ref ResponseData data)
        {
            var field = PInvokeUtility.PtrToStruct<OrderField>(data.Ptr1);
            _spi.ProcessQryOrder(field, Math.Abs(data.Double1) > double.Epsilon);
        }
        private void ProcessQryTrade(ref ResponseData data)
        {
            var field = PInvokeUtility.PtrToStruct<TradeField>(data.Ptr1);
            _spi.ProcessQryTrade(field, Math.Abs(data.Double1) > double.Epsilon);
        }
        private void ProcessDepthMarketData(ref ResponseData data)
        {
            var field = PInvokeUtility.GetDepthMarketData(data.Ptr1);
            _spi.ProcessDepthMarketData(field);
        }
        private void ProcessRtnOrder(ref ResponseData data)
        {
            var field = PInvokeUtility.PtrToStruct<OrderField>(data.Ptr1);
            _spi.ProcessRtnOrder(field);
        }
        private void ProcessRtnTrade(ref ResponseData data)
        {
            var field = PInvokeUtility.PtrToStruct<TradeField>(data.Ptr1);
            _spi.ProcessRtnTrade(field);
        }
        #endregion

        public XApi(string path)
        {
            InitHandler();
            _proxy = new XApiInvokeProxy(path);
            _callback = ProcessResponse;
        }

        public void RegisterSpi(IXSpi spi)
        {
            _spi = spi;
        }

        public void Release()
        {
            Dispose();
        }

        ~XApi()
        {
            Dispose();
        }

        public void Dispose()
        {
            _proxy?.Dispose();
            _proxy = null;
        }

        public string ApiVersion => Marshal.PtrToStringAnsi(_proxy.XRequest(RequestType.GetApiVersion));
        public ApiType ApiTypes => (ApiType)_proxy.XRequest(RequestType.GetApiTypes);
        public string ApiName => Marshal.PtrToStringAnsi(_proxy.XRequest(RequestType.GetApiName));
        public ServerInfoField Server { get; private set; }
        public UserInfoField User { get; private set; }
        public bool Connected { get; private set; }
        public RspUserLoginField UserLogin { get; private set; }

        #region Connection & Query
        public void Connect(ServerInfoField server, UserInfoField user)
        {
            if (_api == IntPtr.Zero) {
                _api = _proxy.XRequest(RequestType.Create);
                _proxy.XRequest(RequestType.Register, _api, IntPtr.Zero, 0, 0, Marshal.GetFunctionPointerForDelegate(_callback), 0, IntPtr.Zero, 0, IntPtr.Zero, 0);

                Server = server;
                User = user;
                UserLogin = null;
                _proxy.XRequest(RequestType.Connect, _api, IntPtr.Zero, 0, 0,
                    new UnmanagedPtr<ServerInfoField>(server), 0,
                    new UnmanagedPtr<UserInfoField>(User), 0,
                    Marshal.StringToHGlobalAnsi(Path.GetTempPath()), 0);
            }
        }
        public void Disconnect()
        {
            if (_api != IntPtr.Zero) {
                _proxy.XRequest(RequestType.Disconnect, _api);
                _proxy.XRequest(RequestType.Release, _api);
                _api = IntPtr.Zero;
            }
        }
        public void Query(QueryType type, ReqQueryField query)
        {
            if (query == null) {
                query = new ReqQueryField {
                    AccountID = UserLogin?.AccountID,
                    ClientID = User.UserID
                };
            }
            _proxy.XRequest(type, _api, new UnmanagedPtr<ReqQueryField>(query), Marshal.SizeOf(typeof(ReqQueryField)));
        }
        #endregion

        #region Subscribe
        private void Resubscribe()
        {
            foreach (var item in _subscribedList) {
                InternalSubscribe(item.Item1, item.Item2, false);
            }
        }
        private void InternalSubscribe(string instrument, string exchange, bool record = true)
        {
            _proxy.XRequest(RequestType.Subscribe, _api, new UnmanagedPtr<string>(instrument), new UnmanagedPtr<string>(exchange));
            if (record) {
                _subscribedList.Subscribe(instrument, exchange);
            }
        }
        private void InternalUnsubscribe(string instrument, string exchange)
        {
            _proxy.XRequest(RequestType.Unsubscribe, _api, new UnmanagedPtr<string>(instrument), new UnmanagedPtr<string>(exchange));
            _subscribedList.Unsubscribe(instrument, exchange);
        }

        public void Subscribe(string instrument, string exchange, InstrumentType type)
        {
            instrument.Split(';', ',', ' ').ToList().ForEach(x => {
                InternalSubscribe(instrument, exchange);
            });
        }

        public void Unsubscribe(string instrument, string exchange, InstrumentType type)
        {
            instrument.Split(';', ',', ' ').ToList().ForEach(x => {
                InternalUnsubscribe(instrument, exchange);
            });
        }
        #endregion

        #region Trading
        public string SendOrder(params OrderField[] orders)
        {
            var unmanaged = new UnmanagedOrders(orders);
            _proxy.XRequest(RequestType.ReqOrderInsert, _api, IntPtr.Zero, 0, 0,
                unmanaged.OrderPtr, orders.Length, unmanaged.OutOrderIdPtr, orders.Length, IntPtr.Zero, 0);
            return Marshal.PtrToStringAnsi(unmanaged.OutOrderIdPtr);
        }
        public string CancelOrder(params string[] list)
        {
            var unmanaged = new UnmanagedOrders(list);
            _proxy.XRequest(RequestType.ReqOrderAction, _api, IntPtr.Zero, 0, 0,
                unmanaged.InOrderIdPtr, list.Length, unmanaged.OutOrderIdPtr, list.Length, IntPtr.Zero, 0);
            return Marshal.PtrToStringAnsi(unmanaged.OutOrderIdPtr);
        }
        #endregion
    }
}