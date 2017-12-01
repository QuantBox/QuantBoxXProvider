using System;

namespace QuantBox.Sfit.Api
{       
    public class CtpMdSpi : CtpSpi
    {    
        private void InitHandlerList()
        {
            void DefaultResponseHandler(ref CtpResponse rsp)
            {
            }
            
            RspHandlerList = new CtpResponseAction[CtpResponseType.Max];
            for (var i = 0; i < CtpResponseType.Max; i++)
            {
                RspHandlerList[i] = DefaultResponseHandler;
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
        private void DoFrontConnected(ref CtpResponse rsp)
        {
            var handler = OnFrontConnected;
            if (handler != null){
                handler(this);
            }
        }
        
        public event CtpEventHandler OnFrontConnected;
         
        private void DoFrontDisconnected(ref CtpResponse rsp)
        {
            var handler = OnFrontDisconnected;
            if (handler != null){
                handler(this, rsp.Item1.AsInt.Value);
            }
        }
        
        public event CtpEventHandler<int> OnFrontDisconnected;
         
        private void DoHeartBeatWarning(ref CtpResponse rsp)
        {
            var handler = OnHeartBeatWarning;
            if (handler != null){
                handler(this, rsp.Item1.AsInt.Value);
            }
        }
        
        public event CtpEventHandler<int> OnHeartBeatWarning;
         
        private void DoRspUserLogin(ref CtpResponse rsp)
        {
            var handler = OnRspUserLogin;
            if (handler != null){
                handler(this, rsp.Item1.AsRspUserLogin, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpRspUserLogin> OnRspUserLogin;
         
        private void DoRspUserLogout(ref CtpResponse rsp)
        {
            var handler = OnRspUserLogout;
            if (handler != null){
                handler(this, rsp.Item1.AsUserLogout, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpUserLogout> OnRspUserLogout;
         
        private void DoRspError(ref CtpResponse rsp)
        {
            var handler = OnRspError;
            if (handler != null){
                handler(this, rsp.Item1.AsRspInfo, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler3 OnRspError;
         
        private void DoRspSubMarketData(ref CtpResponse rsp)
        {
            var handler = OnRspSubMarketData;
            if (handler != null){
                handler(this, rsp.Item1.AsSpecificInstrument, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpSpecificInstrument> OnRspSubMarketData;
         
        private void DoRspUnSubMarketData(ref CtpResponse rsp)
        {
            var handler = OnRspUnSubMarketData;
            if (handler != null){
                handler(this, rsp.Item1.AsSpecificInstrument, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpSpecificInstrument> OnRspUnSubMarketData;
         
        private void DoRspSubForQuoteRsp(ref CtpResponse rsp)
        {
            var handler = OnRspSubForQuoteRsp;
            if (handler != null){
                handler(this, rsp.Item1.AsSpecificInstrument, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpSpecificInstrument> OnRspSubForQuoteRsp;
         
        private void DoRspUnSubForQuoteRsp(ref CtpResponse rsp)
        {
            var handler = OnRspUnSubForQuoteRsp;
            if (handler != null){
                handler(this, rsp.Item1.AsSpecificInstrument, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpSpecificInstrument> OnRspUnSubForQuoteRsp;
         
        private void DoRtnDepthMarketData(ref CtpResponse rsp)
        {
            var handler = OnRtnDepthMarketData;
            if (handler != null){
                handler(this, rsp.Item1.AsDepthMarketData);
            }
        }
        
        public event CtpEventHandler<CtpDepthMarketData> OnRtnDepthMarketData;
         
        private void DoRtnForQuoteRsp(ref CtpResponse rsp)
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
        
        public override void ProcessResponse(ref CtpResponse rsp)
        {
            switch (rsp.TypeId) {
                case CtpResponseType.Response:
                case CtpResponseType.Max:
                    break;
                default:
                    RspHandlerList[rsp.TypeId](ref rsp);
                    break;
            }
        }
        
        public override void SetResponseHandler(byte type, CtpResponseAction handler)
        {
            if (type < CtpResponseType.Max)
                RspHandlerList[type] = handler;
        }
        
        public CtpResponseAction[] RspHandlerList { get; private set; }
    }
}