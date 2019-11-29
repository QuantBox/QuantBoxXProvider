using System;

namespace QuantBox.Sfit.Api
{
    public class CtpMdApi : CtpMdSpi, ICtpRequestHandler
    {
        private CtpRequestFunc[] _handerList;
        private IntPtr _instance = IntPtr.Zero;

        private void InitHandlerList()
        {
            int NullRequestHandler(ref CtpRequest req)
            {
                return -1;
            }
            _handerList = new CtpRequestFunc[CtpRequestType.Max];
            for (var i = 0; i < CtpRequestType.Max; i++) {
                _handerList[i] = NullRequestHandler;
            }
            _handerList[CtpRequestType.SubscribeMarketData] = DoSubscribeMarketData;
            _handerList[CtpRequestType.UnSubscribeMarketData] = DoUnSubscribeMarketData;
            _handerList[CtpRequestType.SubscribeForQuoteRsp] = DoSubscribeForQuoteRsp;
            _handerList[CtpRequestType.UnSubscribeForQuoteRsp] = DoUnSubscribeForQuoteRsp;
            _handerList[CtpRequestType.ReqUserLogin] = DoReqUserLogin;
            _handerList[CtpRequestType.ReqUserLogout] = DoReqUserLogout;
        }
        
        #region Native Response Handler
        private CtpMdNative.OnFrontConnected _cbOnFrontConnected;
        private CtpMdNative.OnFrontDisconnected _cbOnFrontDisconnected;
        private CtpMdNative.OnHeartBeatWarning _cbOnHeartBeatWarning;
        private CtpMdNative.OnRspUserLogin _cbOnRspUserLogin;
        private CtpMdNative.OnRspUserLogout _cbOnRspUserLogout;
        private CtpMdNative.OnRspError _cbOnRspError;
        private CtpMdNative.OnRspSubMarketData _cbOnRspSubMarketData;
        private CtpMdNative.OnRspUnSubMarketData _cbOnRspUnSubMarketData;
        private CtpMdNative.OnRspSubForQuoteRsp _cbOnRspSubForQuoteRsp;
        private CtpMdNative.OnRspUnSubForQuoteRsp _cbOnRspUnSubForQuoteRsp;
        private CtpMdNative.OnRtnDepthMarketData _cbOnRtnDepthMarketData;
        private CtpMdNative.OnRtnForQuoteRsp _cbOnRtnForQuoteRsp;

        private void InitNativeCallback()
        {
            _cbOnFrontConnected = NativeOnFrontConnected; 
            CtpMdNative.SetOnFrontConnected(_instance, _cbOnFrontConnected);
            _cbOnFrontDisconnected = NativeOnFrontDisconnected; 
            CtpMdNative.SetOnFrontDisconnected(_instance, _cbOnFrontDisconnected);
            _cbOnHeartBeatWarning = NativeOnHeartBeatWarning; 
            CtpMdNative.SetOnHeartBeatWarning(_instance, _cbOnHeartBeatWarning);
            _cbOnRspUserLogin = NativeOnRspUserLogin; 
            CtpMdNative.SetOnRspUserLogin(_instance, _cbOnRspUserLogin);
            _cbOnRspUserLogout = NativeOnRspUserLogout; 
            CtpMdNative.SetOnRspUserLogout(_instance, _cbOnRspUserLogout);
            _cbOnRspError = NativeOnRspError; 
            CtpMdNative.SetOnRspError(_instance, _cbOnRspError);
            _cbOnRspSubMarketData = NativeOnRspSubMarketData; 
            CtpMdNative.SetOnRspSubMarketData(_instance, _cbOnRspSubMarketData);
            _cbOnRspUnSubMarketData = NativeOnRspUnSubMarketData; 
            CtpMdNative.SetOnRspUnSubMarketData(_instance, _cbOnRspUnSubMarketData);
            _cbOnRspSubForQuoteRsp = NativeOnRspSubForQuoteRsp; 
            CtpMdNative.SetOnRspSubForQuoteRsp(_instance, _cbOnRspSubForQuoteRsp);
            _cbOnRspUnSubForQuoteRsp = NativeOnRspUnSubForQuoteRsp; 
            CtpMdNative.SetOnRspUnSubForQuoteRsp(_instance, _cbOnRspUnSubForQuoteRsp);
            _cbOnRtnDepthMarketData = NativeOnRtnDepthMarketData; 
            CtpMdNative.SetOnRtnDepthMarketData(_instance, _cbOnRtnDepthMarketData);
            _cbOnRtnForQuoteRsp = NativeOnRtnForQuoteRsp; 
            CtpMdNative.SetOnRtnForQuoteRsp(_instance, _cbOnRtnForQuoteRsp);
        }

        ///当客户端与交易后台建立起通信连接时（还未登录前），该方法被调用。
 private void NativeOnFrontConnected()
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnFrontConnected;
ProcessResponse(ref rsp);
        }
        
        ///当客户端与交易后台通信连接断开时，该方法被调用。当发生这个情况后，API会自动重新连接，客户端可不做处理。
///@param nReason 错误原因
///        0x1001 网络读失败
///        0x1002 网络写失败
///        0x2001 接收心跳超时
///        0x2002 发送心跳失败
///        0x2003 收到错误报文
 private void NativeOnFrontDisconnected(int reason)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnFrontDisconnected;
rsp.Item1 = new CtpAny(reason);
ProcessResponse(ref rsp);
        }
        
        ///心跳超时警告。当长时间未收到报文时，该方法被调用。
///@param nTimeLapse 距离上次接收报文的时间
 private void NativeOnHeartBeatWarning(int timeLapse)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnHeartBeatWarning;
rsp.Item1 = new CtpAny(timeLapse);
ProcessResponse(ref rsp);
        }
        
        ///登录请求响应
 private void NativeOnRspUserLogin(CtpRspUserLogin rspUserLogin,CtpRspInfo rspInfo,int requestId,bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspUserLogin;
rsp.Item1 = new CtpAny(rspUserLogin);
rsp.Item2 = rspInfo;
rsp.RequestID = requestId;
rsp.IsLast = isLast;
ProcessResponse(ref rsp);
        }
        
        ///登出请求响应
 private void NativeOnRspUserLogout(CtpUserLogout userLogout,CtpRspInfo rspInfo,int requestId,bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspUserLogout;
rsp.Item1 = new CtpAny(userLogout);
rsp.Item2 = rspInfo;
rsp.RequestID = requestId;
rsp.IsLast = isLast;
ProcessResponse(ref rsp);
        }
        
        ///错误应答
 private void NativeOnRspError(CtpRspInfo rspInfo,int requestId,bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspError;
rsp.Item1 = new CtpAny(rspInfo);
rsp.RequestID = requestId;
rsp.IsLast = isLast;
ProcessResponse(ref rsp);
        }
        
        ///订阅行情应答
 private void NativeOnRspSubMarketData(CtpSpecificInstrument specificInstrument,CtpRspInfo rspInfo,int requestId,bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspSubMarketData;
rsp.Item1 = new CtpAny(specificInstrument);
rsp.Item2 = rspInfo;
rsp.RequestID = requestId;
rsp.IsLast = isLast;
ProcessResponse(ref rsp);
        }
        
        ///取消订阅行情应答
 private void NativeOnRspUnSubMarketData(CtpSpecificInstrument specificInstrument,CtpRspInfo rspInfo,int requestId,bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspUnSubMarketData;
rsp.Item1 = new CtpAny(specificInstrument);
rsp.Item2 = rspInfo;
rsp.RequestID = requestId;
rsp.IsLast = isLast;
ProcessResponse(ref rsp);
        }
        
        ///订阅询价应答
 private void NativeOnRspSubForQuoteRsp(CtpSpecificInstrument specificInstrument,CtpRspInfo rspInfo,int requestId,bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspSubForQuoteRsp;
rsp.Item1 = new CtpAny(specificInstrument);
rsp.Item2 = rspInfo;
rsp.RequestID = requestId;
rsp.IsLast = isLast;
ProcessResponse(ref rsp);
        }
        
        ///取消订阅询价应答
 private void NativeOnRspUnSubForQuoteRsp(CtpSpecificInstrument specificInstrument,CtpRspInfo rspInfo,int requestId,bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspUnSubForQuoteRsp;
rsp.Item1 = new CtpAny(specificInstrument);
rsp.Item2 = rspInfo;
rsp.RequestID = requestId;
rsp.IsLast = isLast;
ProcessResponse(ref rsp);
        }
        
        ///深度行情通知
 private void NativeOnRtnDepthMarketData(CtpDepthMarketData depthMarketData)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRtnDepthMarketData;
rsp.Item1 = new CtpAny(depthMarketData);
ProcessResponse(ref rsp);
        }
        
        ///询价通知
 private void NativeOnRtnForQuoteRsp(CtpForQuoteRsp forQuoteRsp)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRtnForQuoteRsp;
rsp.Item1 = new CtpAny(forQuoteRsp);
ProcessResponse(ref rsp);
        }
        
        #endregion
        
        #region Request Handler
        private int DoSubscribeMarketData(ref CtpRequest req)
        {
            var data = req.Args.AsStringArray;
return CtpMdNative.SubscribeMarketData(_instance, data, data.Length);
        }
        
        private int DoUnSubscribeMarketData(ref CtpRequest req)
        {
            var data = req.Args.AsStringArray;
return CtpMdNative.UnSubscribeMarketData(_instance, data, data.Length);
        }
        
        private int DoSubscribeForQuoteRsp(ref CtpRequest req)
        {
            var data = req.Args.AsStringArray;
return CtpMdNative.SubscribeForQuoteRsp(_instance, data, data.Length);
        }
        
        private int DoUnSubscribeForQuoteRsp(ref CtpRequest req)
        {
            var data = req.Args.AsStringArray;
return CtpMdNative.UnSubscribeForQuoteRsp(_instance, data, data.Length);
        }
        
        private int DoReqUserLogin(ref CtpRequest req)
        {
            var data = req.Args.AsReqUserLogin;
return CtpMdNative.ReqUserLogin(_instance, data, req.RequestID);
        }
        
        private int DoReqUserLogout(ref CtpRequest req)
        {
            var data = req.Args.AsUserLogout;
return CtpMdNative.ReqUserLogout(_instance, data, req.RequestID);
        }
        
        #endregion

        private void InitApi(string flowPath)
        {
            _instance = CtpMdNative.Create(flowPath);
        }

        public CtpMdApi(string flowPath)
        {
            InitHandlerList();
            InitApi(flowPath);
            InitNativeCallback();
        }

        ~CtpMdApi()
        {
            Release();
        }

        public virtual int ProcessRequest(ref CtpRequest req)
        {
            return _handerList[req.TypeId](ref req);
        }

        public void Init()
        {
            CtpMdNative.Init(_instance);
        }

        public void Release()
        {
            if (_instance == IntPtr.Zero)
                return;
            CtpMdNative.Release(_instance);
            _instance = IntPtr.Zero;
        }
        
        public int Join()
        {
            return CtpMdNative.Join(_instance);
        }
        
        ///获取当前交易日
        ///@retrun 获取到的交易日
        ///@remark 只有登录成功后,才能得到正确的交易日
        public string GetTradingDay()
        {
            return CtpMdNative.GetTradingDay(_instance);
        }

        ///注册前置机网络地址
        ///@param pszFrontAddress：前置机网络地址。
        ///@remark 网络地址的格式为：“protocol://ipaddress:port”，如：”tcp://127.0.0.1:17001”。 
        ///@remark “tcp”代表传输协议，“127.0.0.1”代表服务器地址。”17001”代表服务器端口号。
        public void RegisterFront(string frontAddress)
        {
            CtpMdNative.RegisterFront(_instance, frontAddress);
        }
        ///注册名字服务器网络地址
        ///@param pszNsAddress：名字服务器网络地址。
        ///@remark 网络地址的格式为：“protocol://ipaddress:port”，如：”tcp://127.0.0.1:12001”。 
        ///@remark “tcp”代表传输协议，“127.0.0.1”代表服务器地址。”12001”代表服务器端口号。
        ///@remark RegisterNameServer优先于RegisterFront
        public void RegisterNameServer(string nsAddress)
        {
            CtpMdNative.RegisterNameServer(_instance, nsAddress);
        }
        
        ///注册名字服务器用户信息
        ///@param fensUserInfo：用户信息。
        public void RegisterFensUserInfo(CtpFensUserInfo fensUserInfo)
        {
            CtpMdNative.RegisterFensUserInfo(_instance, fensUserInfo);
        }

        public CtpRequestFunc[] ReqHandlerList => _handerList;

        ///订阅行情。
///@param ppInstrumentID 合约ID  
///@param nCount 要订阅/退订行情的合约个数
///@remark 
public int SubscribeMarketData(string[] instrumentID,int count)
        {
            return CtpMdNative.SubscribeMarketData(_instance, instrumentID, count);
        }

        ///退订行情。
///@param ppInstrumentID 合约ID  
///@param nCount 要订阅/退订行情的合约个数
///@remark 
public int UnSubscribeMarketData(string[] instrumentID,int count)
        {
            return CtpMdNative.UnSubscribeMarketData(_instance, instrumentID, count);
        }

        ///订阅询价。
///@param ppInstrumentID 合约ID  
///@param nCount 要订阅/退订行情的合约个数
///@remark 
public int SubscribeForQuoteRsp(string[] instrumentID,int count)
        {
            return CtpMdNative.SubscribeForQuoteRsp(_instance, instrumentID, count);
        }

        ///退订询价。
///@param ppInstrumentID 合约ID  
///@param nCount 要订阅/退订行情的合约个数
///@remark 
public int UnSubscribeForQuoteRsp(string[] instrumentID,int count)
        {
            return CtpMdNative.UnSubscribeForQuoteRsp(_instance, instrumentID, count);
        }

        ///用户登录请求
public int ReqUserLogin(CtpReqUserLogin reqUserLoginField,int requestId)
        {
            return CtpMdNative.ReqUserLogin(_instance, reqUserLoginField, requestId);
        }

        ///登出请求
public int ReqUserLogout(CtpUserLogout userLogout,int requestId)
        {
            return CtpMdNative.ReqUserLogout(_instance, userLogout, requestId);
        }
    }
}