using System;

namespace QuantBox.Sfit.Api
{       
    public class CtpTraderSpi : CtpSpi
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
            RspHandlerList[CtpResponseType.OnRspAuthenticate] = DoRspAuthenticate;
            RspHandlerList[CtpResponseType.OnRspUserLogin] = DoRspUserLogin;
            RspHandlerList[CtpResponseType.OnRspUserLogout] = DoRspUserLogout;
            RspHandlerList[CtpResponseType.OnRspUserPasswordUpdate] = DoRspUserPasswordUpdate;
            RspHandlerList[CtpResponseType.OnRspTradingAccountPasswordUpdate] = DoRspTradingAccountPasswordUpdate;
            RspHandlerList[CtpResponseType.OnRspOrderInsert] = DoRspOrderInsert;
            RspHandlerList[CtpResponseType.OnRspParkedOrderInsert] = DoRspParkedOrderInsert;
            RspHandlerList[CtpResponseType.OnRspParkedOrderAction] = DoRspParkedOrderAction;
            RspHandlerList[CtpResponseType.OnRspOrderAction] = DoRspOrderAction;
            RspHandlerList[CtpResponseType.OnRspQueryMaxOrderVolume] = DoRspQueryMaxOrderVolume;
            RspHandlerList[CtpResponseType.OnRspSettlementInfoConfirm] = DoRspSettlementInfoConfirm;
            RspHandlerList[CtpResponseType.OnRspRemoveParkedOrder] = DoRspRemoveParkedOrder;
            RspHandlerList[CtpResponseType.OnRspRemoveParkedOrderAction] = DoRspRemoveParkedOrderAction;
            RspHandlerList[CtpResponseType.OnRspExecOrderInsert] = DoRspExecOrderInsert;
            RspHandlerList[CtpResponseType.OnRspExecOrderAction] = DoRspExecOrderAction;
            RspHandlerList[CtpResponseType.OnRspForQuoteInsert] = DoRspForQuoteInsert;
            RspHandlerList[CtpResponseType.OnRspQuoteInsert] = DoRspQuoteInsert;
            RspHandlerList[CtpResponseType.OnRspQuoteAction] = DoRspQuoteAction;
            RspHandlerList[CtpResponseType.OnRspBatchOrderAction] = DoRspBatchOrderAction;
            RspHandlerList[CtpResponseType.OnRspCombActionInsert] = DoRspCombActionInsert;
            RspHandlerList[CtpResponseType.OnRspQryOrder] = DoRspQryOrder;
            RspHandlerList[CtpResponseType.OnRspQryTrade] = DoRspQryTrade;
            RspHandlerList[CtpResponseType.OnRspQryInvestorPosition] = DoRspQryInvestorPosition;
            RspHandlerList[CtpResponseType.OnRspQryTradingAccount] = DoRspQryTradingAccount;
            RspHandlerList[CtpResponseType.OnRspQryInvestor] = DoRspQryInvestor;
            RspHandlerList[CtpResponseType.OnRspQryTradingCode] = DoRspQryTradingCode;
            RspHandlerList[CtpResponseType.OnRspQryInstrumentMarginRate] = DoRspQryInstrumentMarginRate;
            RspHandlerList[CtpResponseType.OnRspQryInstrumentCommissionRate] = DoRspQryInstrumentCommissionRate;
            RspHandlerList[CtpResponseType.OnRspQryExchange] = DoRspQryExchange;
            RspHandlerList[CtpResponseType.OnRspQryProduct] = DoRspQryProduct;
            RspHandlerList[CtpResponseType.OnRspQryInstrument] = DoRspQryInstrument;
            RspHandlerList[CtpResponseType.OnRspQryDepthMarketData] = DoRspQryDepthMarketData;
            RspHandlerList[CtpResponseType.OnRspQrySettlementInfo] = DoRspQrySettlementInfo;
            RspHandlerList[CtpResponseType.OnRspQryTransferBank] = DoRspQryTransferBank;
            RspHandlerList[CtpResponseType.OnRspQryInvestorPositionDetail] = DoRspQryInvestorPositionDetail;
            RspHandlerList[CtpResponseType.OnRspQryNotice] = DoRspQryNotice;
            RspHandlerList[CtpResponseType.OnRspQrySettlementInfoConfirm] = DoRspQrySettlementInfoConfirm;
            RspHandlerList[CtpResponseType.OnRspQryInvestorPositionCombineDetail] = DoRspQryInvestorPositionCombineDetail;
            RspHandlerList[CtpResponseType.OnRspQryCFMMCTradingAccountKey] = DoRspQryCFMMCTradingAccountKey;
            RspHandlerList[CtpResponseType.OnRspQryEWarrantOffset] = DoRspQryEWarrantOffset;
            RspHandlerList[CtpResponseType.OnRspQryInvestorProductGroupMargin] = DoRspQryInvestorProductGroupMargin;
            RspHandlerList[CtpResponseType.OnRspQryExchangeMarginRate] = DoRspQryExchangeMarginRate;
            RspHandlerList[CtpResponseType.OnRspQryExchangeMarginRateAdjust] = DoRspQryExchangeMarginRateAdjust;
            RspHandlerList[CtpResponseType.OnRspQryExchangeRate] = DoRspQryExchangeRate;
            RspHandlerList[CtpResponseType.OnRspQrySecAgentACIDMap] = DoRspQrySecAgentACIDMap;
            RspHandlerList[CtpResponseType.OnRspQryProductExchRate] = DoRspQryProductExchRate;
            RspHandlerList[CtpResponseType.OnRspQryProductGroup] = DoRspQryProductGroup;
            RspHandlerList[CtpResponseType.OnRspQryOptionInstrTradeCost] = DoRspQryOptionInstrTradeCost;
            RspHandlerList[CtpResponseType.OnRspQryOptionInstrCommRate] = DoRspQryOptionInstrCommRate;
            RspHandlerList[CtpResponseType.OnRspQryExecOrder] = DoRspQryExecOrder;
            RspHandlerList[CtpResponseType.OnRspQryForQuote] = DoRspQryForQuote;
            RspHandlerList[CtpResponseType.OnRspQryQuote] = DoRspQryQuote;
            RspHandlerList[CtpResponseType.OnRspQryCombInstrumentGuard] = DoRspQryCombInstrumentGuard;
            RspHandlerList[CtpResponseType.OnRspQryCombAction] = DoRspQryCombAction;
            RspHandlerList[CtpResponseType.OnRspQryTransferSerial] = DoRspQryTransferSerial;
            RspHandlerList[CtpResponseType.OnRspQryAccountregister] = DoRspQryAccountregister;
            RspHandlerList[CtpResponseType.OnRspError] = DoRspError;
            RspHandlerList[CtpResponseType.OnRtnOrder] = DoRtnOrder;
            RspHandlerList[CtpResponseType.OnRtnTrade] = DoRtnTrade;
            RspHandlerList[CtpResponseType.OnErrRtnOrderInsert] = DoErrRtnOrderInsert;
            RspHandlerList[CtpResponseType.OnErrRtnOrderAction] = DoErrRtnOrderAction;
            RspHandlerList[CtpResponseType.OnRtnInstrumentStatus] = DoRtnInstrumentStatus;
            RspHandlerList[CtpResponseType.OnRtnTradingNotice] = DoRtnTradingNotice;
            RspHandlerList[CtpResponseType.OnRtnErrorConditionalOrder] = DoRtnErrorConditionalOrder;
            RspHandlerList[CtpResponseType.OnRtnExecOrder] = DoRtnExecOrder;
            RspHandlerList[CtpResponseType.OnErrRtnExecOrderInsert] = DoErrRtnExecOrderInsert;
            RspHandlerList[CtpResponseType.OnErrRtnExecOrderAction] = DoErrRtnExecOrderAction;
            RspHandlerList[CtpResponseType.OnErrRtnForQuoteInsert] = DoErrRtnForQuoteInsert;
            RspHandlerList[CtpResponseType.OnRtnQuote] = DoRtnQuote;
            RspHandlerList[CtpResponseType.OnErrRtnQuoteInsert] = DoErrRtnQuoteInsert;
            RspHandlerList[CtpResponseType.OnErrRtnQuoteAction] = DoErrRtnQuoteAction;
            RspHandlerList[CtpResponseType.OnRtnForQuoteRsp] = DoRtnForQuoteRsp;
            RspHandlerList[CtpResponseType.OnRtnCFMMCTradingAccountToken] = DoRtnCFMMCTradingAccountToken;
            RspHandlerList[CtpResponseType.OnErrRtnBatchOrderAction] = DoErrRtnBatchOrderAction;
            RspHandlerList[CtpResponseType.OnRtnCombAction] = DoRtnCombAction;
            RspHandlerList[CtpResponseType.OnErrRtnCombActionInsert] = DoErrRtnCombActionInsert;
            RspHandlerList[CtpResponseType.OnRspQryContractBank] = DoRspQryContractBank;
            RspHandlerList[CtpResponseType.OnRspQryParkedOrder] = DoRspQryParkedOrder;
            RspHandlerList[CtpResponseType.OnRspQryParkedOrderAction] = DoRspQryParkedOrderAction;
            RspHandlerList[CtpResponseType.OnRspQryTradingNotice] = DoRspQryTradingNotice;
            RspHandlerList[CtpResponseType.OnRspQryBrokerTradingParams] = DoRspQryBrokerTradingParams;
            RspHandlerList[CtpResponseType.OnRspQryBrokerTradingAlgos] = DoRspQryBrokerTradingAlgos;
            RspHandlerList[CtpResponseType.OnRspQueryCFMMCTradingAccountToken] = DoRspQueryCFMMCTradingAccountToken;
            RspHandlerList[CtpResponseType.OnRtnFromBankToFutureByBank] = DoRtnFromBankToFutureByBank;
            RspHandlerList[CtpResponseType.OnRtnFromFutureToBankByBank] = DoRtnFromFutureToBankByBank;
            RspHandlerList[CtpResponseType.OnRtnRepealFromBankToFutureByBank] = DoRtnRepealFromBankToFutureByBank;
            RspHandlerList[CtpResponseType.OnRtnRepealFromFutureToBankByBank] = DoRtnRepealFromFutureToBankByBank;
            RspHandlerList[CtpResponseType.OnRtnFromBankToFutureByFuture] = DoRtnFromBankToFutureByFuture;
            RspHandlerList[CtpResponseType.OnRtnFromFutureToBankByFuture] = DoRtnFromFutureToBankByFuture;
            RspHandlerList[CtpResponseType.OnRtnRepealFromBankToFutureByFutureManual] = DoRtnRepealFromBankToFutureByFutureManual;
            RspHandlerList[CtpResponseType.OnRtnRepealFromFutureToBankByFutureManual] = DoRtnRepealFromFutureToBankByFutureManual;
            RspHandlerList[CtpResponseType.OnRtnQueryBankBalanceByFuture] = DoRtnQueryBankBalanceByFuture;
            RspHandlerList[CtpResponseType.OnErrRtnBankToFutureByFuture] = DoErrRtnBankToFutureByFuture;
            RspHandlerList[CtpResponseType.OnErrRtnFutureToBankByFuture] = DoErrRtnFutureToBankByFuture;
            RspHandlerList[CtpResponseType.OnErrRtnRepealBankToFutureByFutureManual] = DoErrRtnRepealBankToFutureByFutureManual;
            RspHandlerList[CtpResponseType.OnErrRtnRepealFutureToBankByFutureManual] = DoErrRtnRepealFutureToBankByFutureManual;
            RspHandlerList[CtpResponseType.OnErrRtnQueryBankBalanceByFuture] = DoErrRtnQueryBankBalanceByFuture;
            RspHandlerList[CtpResponseType.OnRtnRepealFromBankToFutureByFuture] = DoRtnRepealFromBankToFutureByFuture;
            RspHandlerList[CtpResponseType.OnRtnRepealFromFutureToBankByFuture] = DoRtnRepealFromFutureToBankByFuture;
            RspHandlerList[CtpResponseType.OnRspFromBankToFutureByFuture] = DoRspFromBankToFutureByFuture;
            RspHandlerList[CtpResponseType.OnRspFromFutureToBankByFuture] = DoRspFromFutureToBankByFuture;
            RspHandlerList[CtpResponseType.OnRspQueryBankAccountMoneyByFuture] = DoRspQueryBankAccountMoneyByFuture;
            RspHandlerList[CtpResponseType.OnRtnOpenAccountByBank] = DoRtnOpenAccountByBank;
            RspHandlerList[CtpResponseType.OnRtnCancelAccountByBank] = DoRtnCancelAccountByBank;
            RspHandlerList[CtpResponseType.OnRtnChangeAccountByBank] = DoRtnChangeAccountByBank;
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
         
        private void DoRspAuthenticate(ref CtpResponse rsp)
        {
            var handler = OnRspAuthenticate;
            if (handler != null){
                handler(this, rsp.Item1.AsRspAuthenticate, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpRspAuthenticate> OnRspAuthenticate;
         
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
         
        private void DoRspUserPasswordUpdate(ref CtpResponse rsp)
        {
            var handler = OnRspUserPasswordUpdate;
            if (handler != null){
                handler(this, rsp.Item1.AsUserPasswordUpdate, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpUserPasswordUpdate> OnRspUserPasswordUpdate;
         
        private void DoRspTradingAccountPasswordUpdate(ref CtpResponse rsp)
        {
            var handler = OnRspTradingAccountPasswordUpdate;
            if (handler != null){
                handler(this, rsp.Item1.AsTradingAccountPasswordUpdate, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpTradingAccountPasswordUpdate> OnRspTradingAccountPasswordUpdate;
         
        private void DoRspOrderInsert(ref CtpResponse rsp)
        {
            var handler = OnRspOrderInsert;
            if (handler != null){
                handler(this, rsp.Item1.AsInputOrder, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpInputOrder> OnRspOrderInsert;
         
        private void DoRspParkedOrderInsert(ref CtpResponse rsp)
        {
            var handler = OnRspParkedOrderInsert;
            if (handler != null){
                handler(this, rsp.Item1.AsParkedOrder, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpParkedOrder> OnRspParkedOrderInsert;
         
        private void DoRspParkedOrderAction(ref CtpResponse rsp)
        {
            var handler = OnRspParkedOrderAction;
            if (handler != null){
                handler(this, rsp.Item1.AsParkedOrderAction, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpParkedOrderAction> OnRspParkedOrderAction;
         
        private void DoRspOrderAction(ref CtpResponse rsp)
        {
            var handler = OnRspOrderAction;
            if (handler != null){
                handler(this, rsp.Item1.AsInputOrderAction, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpInputOrderAction> OnRspOrderAction;
         
        private void DoRspQueryMaxOrderVolume(ref CtpResponse rsp)
        {
            var handler = OnRspQueryMaxOrderVolume;
            if (handler != null){
                handler(this, rsp.Item1.AsQueryMaxOrderVolume, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpQueryMaxOrderVolume> OnRspQueryMaxOrderVolume;
         
        private void DoRspSettlementInfoConfirm(ref CtpResponse rsp)
        {
            var handler = OnRspSettlementInfoConfirm;
            if (handler != null){
                handler(this, rsp.Item1.AsSettlementInfoConfirm, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpSettlementInfoConfirm> OnRspSettlementInfoConfirm;
         
        private void DoRspRemoveParkedOrder(ref CtpResponse rsp)
        {
            var handler = OnRspRemoveParkedOrder;
            if (handler != null){
                handler(this, rsp.Item1.AsRemoveParkedOrder, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpRemoveParkedOrder> OnRspRemoveParkedOrder;
         
        private void DoRspRemoveParkedOrderAction(ref CtpResponse rsp)
        {
            var handler = OnRspRemoveParkedOrderAction;
            if (handler != null){
                handler(this, rsp.Item1.AsRemoveParkedOrderAction, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpRemoveParkedOrderAction> OnRspRemoveParkedOrderAction;
         
        private void DoRspExecOrderInsert(ref CtpResponse rsp)
        {
            var handler = OnRspExecOrderInsert;
            if (handler != null){
                handler(this, rsp.Item1.AsInputExecOrder, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpInputExecOrder> OnRspExecOrderInsert;
         
        private void DoRspExecOrderAction(ref CtpResponse rsp)
        {
            var handler = OnRspExecOrderAction;
            if (handler != null){
                handler(this, rsp.Item1.AsInputExecOrderAction, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpInputExecOrderAction> OnRspExecOrderAction;
         
        private void DoRspForQuoteInsert(ref CtpResponse rsp)
        {
            var handler = OnRspForQuoteInsert;
            if (handler != null){
                handler(this, rsp.Item1.AsInputForQuote, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpInputForQuote> OnRspForQuoteInsert;
         
        private void DoRspQuoteInsert(ref CtpResponse rsp)
        {
            var handler = OnRspQuoteInsert;
            if (handler != null){
                handler(this, rsp.Item1.AsInputQuote, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpInputQuote> OnRspQuoteInsert;
         
        private void DoRspQuoteAction(ref CtpResponse rsp)
        {
            var handler = OnRspQuoteAction;
            if (handler != null){
                handler(this, rsp.Item1.AsInputQuoteAction, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpInputQuoteAction> OnRspQuoteAction;
         
        private void DoRspBatchOrderAction(ref CtpResponse rsp)
        {
            var handler = OnRspBatchOrderAction;
            if (handler != null){
                handler(this, rsp.Item1.AsInputBatchOrderAction, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpInputBatchOrderAction> OnRspBatchOrderAction;
         
        private void DoRspCombActionInsert(ref CtpResponse rsp)
        {
            var handler = OnRspCombActionInsert;
            if (handler != null){
                handler(this, rsp.Item1.AsInputCombAction, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpInputCombAction> OnRspCombActionInsert;
         
        private void DoRspQryOrder(ref CtpResponse rsp)
        {
            var handler = OnRspQryOrder;
            if (handler != null){
                handler(this, rsp.Item1.AsOrder, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpOrder> OnRspQryOrder;
         
        private void DoRspQryTrade(ref CtpResponse rsp)
        {
            var handler = OnRspQryTrade;
            if (handler != null){
                handler(this, rsp.Item1.AsTrade, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpTrade> OnRspQryTrade;
         
        private void DoRspQryInvestorPosition(ref CtpResponse rsp)
        {
            var handler = OnRspQryInvestorPosition;
            if (handler != null){
                handler(this, rsp.Item1.AsInvestorPosition, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpInvestorPosition> OnRspQryInvestorPosition;
         
        private void DoRspQryTradingAccount(ref CtpResponse rsp)
        {
            var handler = OnRspQryTradingAccount;
            if (handler != null){
                handler(this, rsp.Item1.AsTradingAccount, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpTradingAccount> OnRspQryTradingAccount;
         
        private void DoRspQryInvestor(ref CtpResponse rsp)
        {
            var handler = OnRspQryInvestor;
            if (handler != null){
                handler(this, rsp.Item1.AsInvestor, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpInvestor> OnRspQryInvestor;
         
        private void DoRspQryTradingCode(ref CtpResponse rsp)
        {
            var handler = OnRspQryTradingCode;
            if (handler != null){
                handler(this, rsp.Item1.AsTradingCode, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpTradingCode> OnRspQryTradingCode;
         
        private void DoRspQryInstrumentMarginRate(ref CtpResponse rsp)
        {
            var handler = OnRspQryInstrumentMarginRate;
            if (handler != null){
                handler(this, rsp.Item1.AsInstrumentMarginRate, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpInstrumentMarginRate> OnRspQryInstrumentMarginRate;
         
        private void DoRspQryInstrumentCommissionRate(ref CtpResponse rsp)
        {
            var handler = OnRspQryInstrumentCommissionRate;
            if (handler != null){
                handler(this, rsp.Item1.AsInstrumentCommissionRate, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpInstrumentCommissionRate> OnRspQryInstrumentCommissionRate;
         
        private void DoRspQryExchange(ref CtpResponse rsp)
        {
            var handler = OnRspQryExchange;
            if (handler != null){
                handler(this, rsp.Item1.AsExchange, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpExchange> OnRspQryExchange;
         
        private void DoRspQryProduct(ref CtpResponse rsp)
        {
            var handler = OnRspQryProduct;
            if (handler != null){
                handler(this, rsp.Item1.AsProduct, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpProduct> OnRspQryProduct;
         
        private void DoRspQryInstrument(ref CtpResponse rsp)
        {
            var handler = OnRspQryInstrument;
            if (handler != null){
                handler(this, rsp.Item1.AsInstrument, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpInstrument> OnRspQryInstrument;
         
        private void DoRspQryDepthMarketData(ref CtpResponse rsp)
        {
            var handler = OnRspQryDepthMarketData;
            if (handler != null){
                handler(this, rsp.Item1.AsDepthMarketData, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpDepthMarketData> OnRspQryDepthMarketData;
         
        private void DoRspQrySettlementInfo(ref CtpResponse rsp)
        {
            var handler = OnRspQrySettlementInfo;
            if (handler != null){
                handler(this, rsp.Item1.AsSettlementInfo, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpSettlementInfo> OnRspQrySettlementInfo;
         
        private void DoRspQryTransferBank(ref CtpResponse rsp)
        {
            var handler = OnRspQryTransferBank;
            if (handler != null){
                handler(this, rsp.Item1.AsTransferBank, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpTransferBank> OnRspQryTransferBank;
         
        private void DoRspQryInvestorPositionDetail(ref CtpResponse rsp)
        {
            var handler = OnRspQryInvestorPositionDetail;
            if (handler != null){
                handler(this, rsp.Item1.AsInvestorPositionDetail, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpInvestorPositionDetail> OnRspQryInvestorPositionDetail;
         
        private void DoRspQryNotice(ref CtpResponse rsp)
        {
            var handler = OnRspQryNotice;
            if (handler != null){
                handler(this, rsp.Item1.AsNotice, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpNotice> OnRspQryNotice;
         
        private void DoRspQrySettlementInfoConfirm(ref CtpResponse rsp)
        {
            var handler = OnRspQrySettlementInfoConfirm;
            if (handler != null){
                handler(this, rsp.Item1.AsSettlementInfoConfirm, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpSettlementInfoConfirm> OnRspQrySettlementInfoConfirm;
         
        private void DoRspQryInvestorPositionCombineDetail(ref CtpResponse rsp)
        {
            var handler = OnRspQryInvestorPositionCombineDetail;
            if (handler != null){
                handler(this, rsp.Item1.AsInvestorPositionCombineDetail, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpInvestorPositionCombineDetail> OnRspQryInvestorPositionCombineDetail;
         
        private void DoRspQryCFMMCTradingAccountKey(ref CtpResponse rsp)
        {
            var handler = OnRspQryCFMMCTradingAccountKey;
            if (handler != null){
                handler(this, rsp.Item1.AsCFMMCTradingAccountKey, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpCFMMCTradingAccountKey> OnRspQryCFMMCTradingAccountKey;
         
        private void DoRspQryEWarrantOffset(ref CtpResponse rsp)
        {
            var handler = OnRspQryEWarrantOffset;
            if (handler != null){
                handler(this, rsp.Item1.AsEWarrantOffset, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpEWarrantOffset> OnRspQryEWarrantOffset;
         
        private void DoRspQryInvestorProductGroupMargin(ref CtpResponse rsp)
        {
            var handler = OnRspQryInvestorProductGroupMargin;
            if (handler != null){
                handler(this, rsp.Item1.AsInvestorProductGroupMargin, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpInvestorProductGroupMargin> OnRspQryInvestorProductGroupMargin;
         
        private void DoRspQryExchangeMarginRate(ref CtpResponse rsp)
        {
            var handler = OnRspQryExchangeMarginRate;
            if (handler != null){
                handler(this, rsp.Item1.AsExchangeMarginRate, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpExchangeMarginRate> OnRspQryExchangeMarginRate;
         
        private void DoRspQryExchangeMarginRateAdjust(ref CtpResponse rsp)
        {
            var handler = OnRspQryExchangeMarginRateAdjust;
            if (handler != null){
                handler(this, rsp.Item1.AsExchangeMarginRateAdjust, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpExchangeMarginRateAdjust> OnRspQryExchangeMarginRateAdjust;
         
        private void DoRspQryExchangeRate(ref CtpResponse rsp)
        {
            var handler = OnRspQryExchangeRate;
            if (handler != null){
                handler(this, rsp.Item1.AsExchangeRate, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpExchangeRate> OnRspQryExchangeRate;
         
        private void DoRspQrySecAgentACIDMap(ref CtpResponse rsp)
        {
            var handler = OnRspQrySecAgentACIDMap;
            if (handler != null){
                handler(this, rsp.Item1.AsSecAgentACIDMap, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpSecAgentACIDMap> OnRspQrySecAgentACIDMap;
         
        private void DoRspQryProductExchRate(ref CtpResponse rsp)
        {
            var handler = OnRspQryProductExchRate;
            if (handler != null){
                handler(this, rsp.Item1.AsProductExchRate, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpProductExchRate> OnRspQryProductExchRate;
         
        private void DoRspQryProductGroup(ref CtpResponse rsp)
        {
            var handler = OnRspQryProductGroup;
            if (handler != null){
                handler(this, rsp.Item1.AsProductGroup, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpProductGroup> OnRspQryProductGroup;
         
        private void DoRspQryOptionInstrTradeCost(ref CtpResponse rsp)
        {
            var handler = OnRspQryOptionInstrTradeCost;
            if (handler != null){
                handler(this, rsp.Item1.AsOptionInstrTradeCost, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpOptionInstrTradeCost> OnRspQryOptionInstrTradeCost;
         
        private void DoRspQryOptionInstrCommRate(ref CtpResponse rsp)
        {
            var handler = OnRspQryOptionInstrCommRate;
            if (handler != null){
                handler(this, rsp.Item1.AsOptionInstrCommRate, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpOptionInstrCommRate> OnRspQryOptionInstrCommRate;
         
        private void DoRspQryExecOrder(ref CtpResponse rsp)
        {
            var handler = OnRspQryExecOrder;
            if (handler != null){
                handler(this, rsp.Item1.AsExecOrder, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpExecOrder> OnRspQryExecOrder;
         
        private void DoRspQryForQuote(ref CtpResponse rsp)
        {
            var handler = OnRspQryForQuote;
            if (handler != null){
                handler(this, rsp.Item1.AsForQuote, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpForQuote> OnRspQryForQuote;
         
        private void DoRspQryQuote(ref CtpResponse rsp)
        {
            var handler = OnRspQryQuote;
            if (handler != null){
                handler(this, rsp.Item1.AsQuote, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpQuote> OnRspQryQuote;
         
        private void DoRspQryCombInstrumentGuard(ref CtpResponse rsp)
        {
            var handler = OnRspQryCombInstrumentGuard;
            if (handler != null){
                handler(this, rsp.Item1.AsCombInstrumentGuard, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpCombInstrumentGuard> OnRspQryCombInstrumentGuard;
         
        private void DoRspQryCombAction(ref CtpResponse rsp)
        {
            var handler = OnRspQryCombAction;
            if (handler != null){
                handler(this, rsp.Item1.AsCombAction, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpCombAction> OnRspQryCombAction;
         
        private void DoRspQryTransferSerial(ref CtpResponse rsp)
        {
            var handler = OnRspQryTransferSerial;
            if (handler != null){
                handler(this, rsp.Item1.AsTransferSerial, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpTransferSerial> OnRspQryTransferSerial;
         
        private void DoRspQryAccountregister(ref CtpResponse rsp)
        {
            var handler = OnRspQryAccountregister;
            if (handler != null){
                handler(this, rsp.Item1.AsAccountregister, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpAccountregister> OnRspQryAccountregister;
         
        private void DoRspError(ref CtpResponse rsp)
        {
            var handler = OnRspError;
            if (handler != null){
                handler(this, rsp.Item1.AsRspInfo, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler3 OnRspError;
         
        private void DoRtnOrder(ref CtpResponse rsp)
        {
            var handler = OnRtnOrder;
            if (handler != null){
                handler(this, rsp.Item1.AsOrder);
            }
        }
        
        public event CtpEventHandler<CtpOrder> OnRtnOrder;
         
        private void DoRtnTrade(ref CtpResponse rsp)
        {
            var handler = OnRtnTrade;
            if (handler != null){
                handler(this, rsp.Item1.AsTrade);
            }
        }
        
        public event CtpEventHandler<CtpTrade> OnRtnTrade;
         
        private void DoErrRtnOrderInsert(ref CtpResponse rsp)
        {
            var handler = OnErrRtnOrderInsert;
            if (handler != null){
                handler(this, rsp.Item1.AsInputOrder, rsp.Item2);
            }
        }
        
        public event CtpEventHandler2<CtpInputOrder> OnErrRtnOrderInsert;
         
        private void DoErrRtnOrderAction(ref CtpResponse rsp)
        {
            var handler = OnErrRtnOrderAction;
            if (handler != null){
                handler(this, rsp.Item1.AsOrderAction, rsp.Item2);
            }
        }
        
        public event CtpEventHandler2<CtpOrderAction> OnErrRtnOrderAction;
         
        private void DoRtnInstrumentStatus(ref CtpResponse rsp)
        {
            var handler = OnRtnInstrumentStatus;
            if (handler != null){
                handler(this, rsp.Item1.AsInstrumentStatus);
            }
        }
        
        public event CtpEventHandler<CtpInstrumentStatus> OnRtnInstrumentStatus;
         
        private void DoRtnTradingNotice(ref CtpResponse rsp)
        {
            var handler = OnRtnTradingNotice;
            if (handler != null){
                handler(this, rsp.Item1.AsTradingNoticeInfo);
            }
        }
        
        public event CtpEventHandler<CtpTradingNoticeInfo> OnRtnTradingNotice;
         
        private void DoRtnErrorConditionalOrder(ref CtpResponse rsp)
        {
            var handler = OnRtnErrorConditionalOrder;
            if (handler != null){
                handler(this, rsp.Item1.AsErrorConditionalOrder);
            }
        }
        
        public event CtpEventHandler<CtpErrorConditionalOrder> OnRtnErrorConditionalOrder;
         
        private void DoRtnExecOrder(ref CtpResponse rsp)
        {
            var handler = OnRtnExecOrder;
            if (handler != null){
                handler(this, rsp.Item1.AsExecOrder);
            }
        }
        
        public event CtpEventHandler<CtpExecOrder> OnRtnExecOrder;
         
        private void DoErrRtnExecOrderInsert(ref CtpResponse rsp)
        {
            var handler = OnErrRtnExecOrderInsert;
            if (handler != null){
                handler(this, rsp.Item1.AsInputExecOrder, rsp.Item2);
            }
        }
        
        public event CtpEventHandler2<CtpInputExecOrder> OnErrRtnExecOrderInsert;
         
        private void DoErrRtnExecOrderAction(ref CtpResponse rsp)
        {
            var handler = OnErrRtnExecOrderAction;
            if (handler != null){
                handler(this, rsp.Item1.AsExecOrderAction, rsp.Item2);
            }
        }
        
        public event CtpEventHandler2<CtpExecOrderAction> OnErrRtnExecOrderAction;
         
        private void DoErrRtnForQuoteInsert(ref CtpResponse rsp)
        {
            var handler = OnErrRtnForQuoteInsert;
            if (handler != null){
                handler(this, rsp.Item1.AsInputForQuote, rsp.Item2);
            }
        }
        
        public event CtpEventHandler2<CtpInputForQuote> OnErrRtnForQuoteInsert;
         
        private void DoRtnQuote(ref CtpResponse rsp)
        {
            var handler = OnRtnQuote;
            if (handler != null){
                handler(this, rsp.Item1.AsQuote);
            }
        }
        
        public event CtpEventHandler<CtpQuote> OnRtnQuote;
         
        private void DoErrRtnQuoteInsert(ref CtpResponse rsp)
        {
            var handler = OnErrRtnQuoteInsert;
            if (handler != null){
                handler(this, rsp.Item1.AsInputQuote, rsp.Item2);
            }
        }
        
        public event CtpEventHandler2<CtpInputQuote> OnErrRtnQuoteInsert;
         
        private void DoErrRtnQuoteAction(ref CtpResponse rsp)
        {
            var handler = OnErrRtnQuoteAction;
            if (handler != null){
                handler(this, rsp.Item1.AsQuoteAction, rsp.Item2);
            }
        }
        
        public event CtpEventHandler2<CtpQuoteAction> OnErrRtnQuoteAction;
         
        private void DoRtnForQuoteRsp(ref CtpResponse rsp)
        {
            var handler = OnRtnForQuoteRsp;
            if (handler != null){
                handler(this, rsp.Item1.AsForQuoteRsp);
            }
        }
        
        public event CtpEventHandler<CtpForQuoteRsp> OnRtnForQuoteRsp;
         
        private void DoRtnCFMMCTradingAccountToken(ref CtpResponse rsp)
        {
            var handler = OnRtnCFMMCTradingAccountToken;
            if (handler != null){
                handler(this, rsp.Item1.AsCFMMCTradingAccountToken);
            }
        }
        
        public event CtpEventHandler<CtpCFMMCTradingAccountToken> OnRtnCFMMCTradingAccountToken;
         
        private void DoErrRtnBatchOrderAction(ref CtpResponse rsp)
        {
            var handler = OnErrRtnBatchOrderAction;
            if (handler != null){
                handler(this, rsp.Item1.AsBatchOrderAction, rsp.Item2);
            }
        }
        
        public event CtpEventHandler2<CtpBatchOrderAction> OnErrRtnBatchOrderAction;
         
        private void DoRtnCombAction(ref CtpResponse rsp)
        {
            var handler = OnRtnCombAction;
            if (handler != null){
                handler(this, rsp.Item1.AsCombAction);
            }
        }
        
        public event CtpEventHandler<CtpCombAction> OnRtnCombAction;
         
        private void DoErrRtnCombActionInsert(ref CtpResponse rsp)
        {
            var handler = OnErrRtnCombActionInsert;
            if (handler != null){
                handler(this, rsp.Item1.AsInputCombAction, rsp.Item2);
            }
        }
        
        public event CtpEventHandler2<CtpInputCombAction> OnErrRtnCombActionInsert;
         
        private void DoRspQryContractBank(ref CtpResponse rsp)
        {
            var handler = OnRspQryContractBank;
            if (handler != null){
                handler(this, rsp.Item1.AsContractBank, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpContractBank> OnRspQryContractBank;
         
        private void DoRspQryParkedOrder(ref CtpResponse rsp)
        {
            var handler = OnRspQryParkedOrder;
            if (handler != null){
                handler(this, rsp.Item1.AsParkedOrder, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpParkedOrder> OnRspQryParkedOrder;
         
        private void DoRspQryParkedOrderAction(ref CtpResponse rsp)
        {
            var handler = OnRspQryParkedOrderAction;
            if (handler != null){
                handler(this, rsp.Item1.AsParkedOrderAction, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpParkedOrderAction> OnRspQryParkedOrderAction;
         
        private void DoRspQryTradingNotice(ref CtpResponse rsp)
        {
            var handler = OnRspQryTradingNotice;
            if (handler != null){
                handler(this, rsp.Item1.AsTradingNotice, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpTradingNotice> OnRspQryTradingNotice;
         
        private void DoRspQryBrokerTradingParams(ref CtpResponse rsp)
        {
            var handler = OnRspQryBrokerTradingParams;
            if (handler != null){
                handler(this, rsp.Item1.AsBrokerTradingParams, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpBrokerTradingParams> OnRspQryBrokerTradingParams;
         
        private void DoRspQryBrokerTradingAlgos(ref CtpResponse rsp)
        {
            var handler = OnRspQryBrokerTradingAlgos;
            if (handler != null){
                handler(this, rsp.Item1.AsBrokerTradingAlgos, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpBrokerTradingAlgos> OnRspQryBrokerTradingAlgos;
         
        private void DoRspQueryCFMMCTradingAccountToken(ref CtpResponse rsp)
        {
            var handler = OnRspQueryCFMMCTradingAccountToken;
            if (handler != null){
                handler(this, rsp.Item1.AsQueryCFMMCTradingAccountToken, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpQueryCFMMCTradingAccountToken> OnRspQueryCFMMCTradingAccountToken;
         
        private void DoRtnFromBankToFutureByBank(ref CtpResponse rsp)
        {
            var handler = OnRtnFromBankToFutureByBank;
            if (handler != null){
                handler(this, rsp.Item1.AsRspTransfer);
            }
        }
        
        public event CtpEventHandler<CtpRspTransfer> OnRtnFromBankToFutureByBank;
         
        private void DoRtnFromFutureToBankByBank(ref CtpResponse rsp)
        {
            var handler = OnRtnFromFutureToBankByBank;
            if (handler != null){
                handler(this, rsp.Item1.AsRspTransfer);
            }
        }
        
        public event CtpEventHandler<CtpRspTransfer> OnRtnFromFutureToBankByBank;
         
        private void DoRtnRepealFromBankToFutureByBank(ref CtpResponse rsp)
        {
            var handler = OnRtnRepealFromBankToFutureByBank;
            if (handler != null){
                handler(this, rsp.Item1.AsRspRepeal);
            }
        }
        
        public event CtpEventHandler<CtpRspRepeal> OnRtnRepealFromBankToFutureByBank;
         
        private void DoRtnRepealFromFutureToBankByBank(ref CtpResponse rsp)
        {
            var handler = OnRtnRepealFromFutureToBankByBank;
            if (handler != null){
                handler(this, rsp.Item1.AsRspRepeal);
            }
        }
        
        public event CtpEventHandler<CtpRspRepeal> OnRtnRepealFromFutureToBankByBank;
         
        private void DoRtnFromBankToFutureByFuture(ref CtpResponse rsp)
        {
            var handler = OnRtnFromBankToFutureByFuture;
            if (handler != null){
                handler(this, rsp.Item1.AsRspTransfer);
            }
        }
        
        public event CtpEventHandler<CtpRspTransfer> OnRtnFromBankToFutureByFuture;
         
        private void DoRtnFromFutureToBankByFuture(ref CtpResponse rsp)
        {
            var handler = OnRtnFromFutureToBankByFuture;
            if (handler != null){
                handler(this, rsp.Item1.AsRspTransfer);
            }
        }
        
        public event CtpEventHandler<CtpRspTransfer> OnRtnFromFutureToBankByFuture;
         
        private void DoRtnRepealFromBankToFutureByFutureManual(ref CtpResponse rsp)
        {
            var handler = OnRtnRepealFromBankToFutureByFutureManual;
            if (handler != null){
                handler(this, rsp.Item1.AsRspRepeal);
            }
        }
        
        public event CtpEventHandler<CtpRspRepeal> OnRtnRepealFromBankToFutureByFutureManual;
         
        private void DoRtnRepealFromFutureToBankByFutureManual(ref CtpResponse rsp)
        {
            var handler = OnRtnRepealFromFutureToBankByFutureManual;
            if (handler != null){
                handler(this, rsp.Item1.AsRspRepeal);
            }
        }
        
        public event CtpEventHandler<CtpRspRepeal> OnRtnRepealFromFutureToBankByFutureManual;
         
        private void DoRtnQueryBankBalanceByFuture(ref CtpResponse rsp)
        {
            var handler = OnRtnQueryBankBalanceByFuture;
            if (handler != null){
                handler(this, rsp.Item1.AsNotifyQueryAccount);
            }
        }
        
        public event CtpEventHandler<CtpNotifyQueryAccount> OnRtnQueryBankBalanceByFuture;
         
        private void DoErrRtnBankToFutureByFuture(ref CtpResponse rsp)
        {
            var handler = OnErrRtnBankToFutureByFuture;
            if (handler != null){
                handler(this, rsp.Item1.AsReqTransfer, rsp.Item2);
            }
        }
        
        public event CtpEventHandler2<CtpReqTransfer> OnErrRtnBankToFutureByFuture;
         
        private void DoErrRtnFutureToBankByFuture(ref CtpResponse rsp)
        {
            var handler = OnErrRtnFutureToBankByFuture;
            if (handler != null){
                handler(this, rsp.Item1.AsReqTransfer, rsp.Item2);
            }
        }
        
        public event CtpEventHandler2<CtpReqTransfer> OnErrRtnFutureToBankByFuture;
         
        private void DoErrRtnRepealBankToFutureByFutureManual(ref CtpResponse rsp)
        {
            var handler = OnErrRtnRepealBankToFutureByFutureManual;
            if (handler != null){
                handler(this, rsp.Item1.AsReqRepeal, rsp.Item2);
            }
        }
        
        public event CtpEventHandler2<CtpReqRepeal> OnErrRtnRepealBankToFutureByFutureManual;
         
        private void DoErrRtnRepealFutureToBankByFutureManual(ref CtpResponse rsp)
        {
            var handler = OnErrRtnRepealFutureToBankByFutureManual;
            if (handler != null){
                handler(this, rsp.Item1.AsReqRepeal, rsp.Item2);
            }
        }
        
        public event CtpEventHandler2<CtpReqRepeal> OnErrRtnRepealFutureToBankByFutureManual;
         
        private void DoErrRtnQueryBankBalanceByFuture(ref CtpResponse rsp)
        {
            var handler = OnErrRtnQueryBankBalanceByFuture;
            if (handler != null){
                handler(this, rsp.Item1.AsReqQueryAccount, rsp.Item2);
            }
        }
        
        public event CtpEventHandler2<CtpReqQueryAccount> OnErrRtnQueryBankBalanceByFuture;
         
        private void DoRtnRepealFromBankToFutureByFuture(ref CtpResponse rsp)
        {
            var handler = OnRtnRepealFromBankToFutureByFuture;
            if (handler != null){
                handler(this, rsp.Item1.AsRspRepeal);
            }
        }
        
        public event CtpEventHandler<CtpRspRepeal> OnRtnRepealFromBankToFutureByFuture;
         
        private void DoRtnRepealFromFutureToBankByFuture(ref CtpResponse rsp)
        {
            var handler = OnRtnRepealFromFutureToBankByFuture;
            if (handler != null){
                handler(this, rsp.Item1.AsRspRepeal);
            }
        }
        
        public event CtpEventHandler<CtpRspRepeal> OnRtnRepealFromFutureToBankByFuture;
         
        private void DoRspFromBankToFutureByFuture(ref CtpResponse rsp)
        {
            var handler = OnRspFromBankToFutureByFuture;
            if (handler != null){
                handler(this, rsp.Item1.AsReqTransfer, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpReqTransfer> OnRspFromBankToFutureByFuture;
         
        private void DoRspFromFutureToBankByFuture(ref CtpResponse rsp)
        {
            var handler = OnRspFromFutureToBankByFuture;
            if (handler != null){
                handler(this, rsp.Item1.AsReqTransfer, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpReqTransfer> OnRspFromFutureToBankByFuture;
         
        private void DoRspQueryBankAccountMoneyByFuture(ref CtpResponse rsp)
        {
            var handler = OnRspQueryBankAccountMoneyByFuture;
            if (handler != null){
                handler(this, rsp.Item1.AsReqQueryAccount, rsp.Item2, rsp.RequestID, rsp.IsLast);
            }
        }
        
        public event CtpEventHandler4<CtpReqQueryAccount> OnRspQueryBankAccountMoneyByFuture;
         
        private void DoRtnOpenAccountByBank(ref CtpResponse rsp)
        {
            var handler = OnRtnOpenAccountByBank;
            if (handler != null){
                handler(this, rsp.Item1.AsOpenAccount);
            }
        }
        
        public event CtpEventHandler<CtpOpenAccount> OnRtnOpenAccountByBank;
         
        private void DoRtnCancelAccountByBank(ref CtpResponse rsp)
        {
            var handler = OnRtnCancelAccountByBank;
            if (handler != null){
                handler(this, rsp.Item1.AsCancelAccount);
            }
        }
        
        public event CtpEventHandler<CtpCancelAccount> OnRtnCancelAccountByBank;
         
        private void DoRtnChangeAccountByBank(ref CtpResponse rsp)
        {
            var handler = OnRtnChangeAccountByBank;
            if (handler != null){
                handler(this, rsp.Item1.AsChangeAccount);
            }
        }
        
        public event CtpEventHandler<CtpChangeAccount> OnRtnChangeAccountByBank;
         
        #endregion
        
        public CtpTraderSpi()
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