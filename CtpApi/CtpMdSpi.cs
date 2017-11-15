using System;

namespace QuantBox.Sfit.Api
{       
    public class CtpMdSpi : CtpSpi
    {    
        void InitHandlerList()
        {
            RspHandlerList = new Action<CtpResponse>[CtpResponseType.Max];
            for (var i = 0; i < CtpResponseType.Max; i++)
            {
                RspHandlerList[i] = (rsp) => {};
            }        
            
            #region Response Handler
            RspHandlerList[CtpResponseType.OnFrontConnected] = DoFrontConnected;
            RspHandlerList[CtpResponseType.OnFrontDisconnected] = DoFrontDisconnected;
            RspHandlerList[CtpResponseType.OnHeartBeatWarning] = DoHeartBeatWarning;
            RspHandlerList[CtpResponseType.OnRspUserLogin] = DoRspUserLogin;
            RspHandlerList[CtpResponseType.OnRspUserLogout] = DoRspUserLogout;
            RspHandlerList[CtpResponseType.OnRspError] = DoRspError;
            RspHandlerList[CtpResponseType.OnRspSubMarketData] = DoRspSubMarketData;
            RspHandlerList[CtpResponseType.OnRspUnSubMarketData] = DoRspUnSubMarketData;
            RspHandlerList[CtpResponseType.OnRspSubForQuoteRsp] = DoRspSubForQuoteRsp;
            RspHandlerList[CtpResponseType.OnRspUnSubForQuoteRsp] = DoRspUnSubForQuoteRsp;
            RspHandlerList[CtpResponseType.OnRtnDepthMarketData] = DoRtnDepthMarketData;
            RspHandlerList[CtpResponseType.OnRtnForQuoteRsp] = DoRtnForQuoteRsp;
            #endregion
        }        
        
        #region Event Definition
        void DoFrontConnected(CtpResponse rsp)
        {
            var handler = OnFrontConnected;
            if (handler != null){
                handler(this);
            }
        }
        
        public event CtpEventHandler OnFrontConnected;
         
        void DoFrontDisconnected(CtpResponse rsp)
        {
            var handler = OnFrontDisconnected;
            if (handler != null){
                handler(this, rsp.Item1.AsInt.Value);
            }
        }
        
        public event CtpEventHandler<int> OnFrontDisconnected;
         
        void DoHeartBeatWarning(CtpResponse rsp)
        {
            var handler = OnHeartBeatWarning;
            if (handler != null){
                handler(this, rsp.Item1.AsInt.Value);
            }
        }
        
        public event CtpEventHandler<int> OnHeartBeatWarning;
         
        void DoRspUserLogin(CtpResponse rsp)
        {
            var handler = OnRspUserLogin;
            if (handler != null){
                handler(this, rsp.Item1.AsRspUserLogin, rsp.Item2, rsp.RequestID, rsp.IsLast == CtpResponse.True);
            }
        }
        
        public event CtpEventHandler4<CtpRspUserLogin> OnRspUserLogin;
         
        void DoRspUserLogout(CtpResponse rsp)
        {
            var handler = OnRspUserLogout;
            if (handler != null){
                handler(this, rsp.Item1.AsUserLogout, rsp.Item2, rsp.RequestID, rsp.IsLast == CtpResponse.True);
            }
        }
        
        public event CtpEventHandler4<CtpUserLogout> OnRspUserLogout;
         
        void DoRspError(CtpResponse rsp)
        {
            var handler = OnRspError;
            if (handler != null){
                handler(this, rsp.Item1.AsRspInfo, rsp.RequestID, rsp.IsLast == CtpResponse.True);
            }
        }
        
        public event CtpEventHandler3 OnRspError;
         
        void DoRspSubMarketData(CtpResponse rsp)
        {
            var handler = OnRspSubMarketData;
            if (handler != null){
                handler(this, rsp.Item1.AsSpecificInstrument, rsp.Item2, rsp.RequestID, rsp.IsLast == CtpResponse.True);
            }
        }
        
        public event CtpEventHandler4<CtpSpecificInstrument> OnRspSubMarketData;
         
        void DoRspUnSubMarketData(CtpResponse rsp)
        {
            var handler = OnRspUnSubMarketData;
            if (handler != null){
                handler(this, rsp.Item1.AsSpecificInstrument, rsp.Item2, rsp.RequestID, rsp.IsLast == CtpResponse.True);
            }
        }
        
        public event CtpEventHandler4<CtpSpecificInstrument> OnRspUnSubMarketData;
         
        void DoRspSubForQuoteRsp(CtpResponse rsp)
        {
            var handler = OnRspSubForQuoteRsp;
            if (handler != null){
                handler(this, rsp.Item1.AsSpecificInstrument, rsp.Item2, rsp.RequestID, rsp.IsLast == CtpResponse.True);
            }
        }
        
        public event CtpEventHandler4<CtpSpecificInstrument> OnRspSubForQuoteRsp;
         
        void DoRspUnSubForQuoteRsp(CtpResponse rsp)
        {
            var handler = OnRspUnSubForQuoteRsp;
            if (handler != null){
                handler(this, rsp.Item1.AsSpecificInstrument, rsp.Item2, rsp.RequestID, rsp.IsLast == CtpResponse.True);
            }
        }
        
        public event CtpEventHandler4<CtpSpecificInstrument> OnRspUnSubForQuoteRsp;
         
        void DoRtnDepthMarketData(CtpResponse rsp)
        {
            var handler = OnRtnDepthMarketData;
            if (handler != null){
                handler(this, rsp.Item1.AsDepthMarketData);
            }
        }
        
        public event CtpEventHandler<CtpDepthMarketData> OnRtnDepthMarketData;
         
        void DoRtnForQuoteRsp(CtpResponse rsp)
        {
            var handler = OnRtnForQuoteRsp;
            if (handler != null){
                handler(this, rsp.Item1.AsForQuoteRsp);
            }
        }
        
        public event CtpEventHandler<CtpForQuoteRsp> OnRtnForQuoteRsp;
         
        #endregion
        
        public CtpMdSpi()
        {
            InitHandlerList();
        }
        
        public override void ProcessResponse(CtpResponse rsp)
        {
            switch (rsp.TypeId) {
                case CtpResponseType.Response:
                case CtpResponseType.Max:
                    break;
                default:
                    RspHandlerList[rsp.TypeId](rsp);
                    break;
            }
        }
        
        public override void SetResponseHandler(byte type, Action<CtpResponse> handler)
        {
            if (type < CtpResponseType.Max)
                RspHandlerList[type] = handler;
        }
        
        public Action<CtpResponse>[] RspHandlerList { get; private set; }
    }
}