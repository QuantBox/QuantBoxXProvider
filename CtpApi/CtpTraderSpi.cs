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
            RspHandlerList[CtpResponseType.OnRspUserAuthMethod] = DoRspUserAuthMethod;
            RspHandlerList[CtpResponseType.OnRspGenUserCaptcha] = DoRspGenUserCaptcha;
            RspHandlerList[CtpResponseType.OnRspGenUserText] = DoRspGenUserText;
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
            RspHandlerList[CtpResponseType.OnRspOptionSelfCloseInsert] = DoRspOptionSelfCloseInsert;
            RspHandlerList[CtpResponseType.OnRspOptionSelfCloseAction] = DoRspOptionSelfCloseAction;
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
            RspHandlerList[CtpResponseType.OnRspQryMMInstrumentCommissionRate] = DoRspQryMMInstrumentCommissionRate;
            RspHandlerList[CtpResponseType.OnRspQryMMOptionInstrCommRate] = DoRspQryMMOptionInstrCommRate;
            RspHandlerList[CtpResponseType.OnRspQryInstrumentOrderCommRate] = DoRspQryInstrumentOrderCommRate;
            RspHandlerList[CtpResponseType.OnRspQrySecAgentTradingAccount] = DoRspQrySecAgentTradingAccount;
            RspHandlerList[CtpResponseType.OnRspQrySecAgentCheckMode] = DoRspQrySecAgentCheckMode;
            RspHandlerList[CtpResponseType.OnRspQrySecAgentTradeInfo] = DoRspQrySecAgentTradeInfo;
            RspHandlerList[CtpResponseType.OnRspQryOptionInstrTradeCost] = DoRspQryOptionInstrTradeCost;
            RspHandlerList[CtpResponseType.OnRspQryOptionInstrCommRate] = DoRspQryOptionInstrCommRate;
            RspHandlerList[CtpResponseType.OnRspQryExecOrder] = DoRspQryExecOrder;
            RspHandlerList[CtpResponseType.OnRspQryForQuote] = DoRspQryForQuote;
            RspHandlerList[CtpResponseType.OnRspQryQuote] = DoRspQryQuote;
            RspHandlerList[CtpResponseType.OnRspQryOptionSelfClose] = DoRspQryOptionSelfClose;
            RspHandlerList[CtpResponseType.OnRspQryInvestUnit] = DoRspQryInvestUnit;
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
            RspHandlerList[CtpResponseType.OnRtnBulletin] = DoRtnBulletin;
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
            RspHandlerList[CtpResponseType.OnRtnOptionSelfClose] = DoRtnOptionSelfClose;
            RspHandlerList[CtpResponseType.OnErrRtnOptionSelfCloseInsert] = DoErrRtnOptionSelfCloseInsert;
            RspHandlerList[CtpResponseType.OnErrRtnOptionSelfCloseAction] = DoErrRtnOptionSelfCloseAction;
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
            handler?.Invoke(this);
        }
        
        public event CtpEventHandler OnFrontConnected;
         
        private void DoFrontDisconnected(ref CtpResponse rsp)
        {
            var handler = OnFrontDisconnected;
            handler?.Invoke(this, rsp.Item1.AsInt.Value);
        }
        
        public event CtpEventHandler<int> OnFrontDisconnected;
         
        private void DoHeartBeatWarning(ref CtpResponse rsp)
        {
            var handler = OnHeartBeatWarning;
            handler?.Invoke(this, rsp.Item1.AsInt.Value);
        }
        
        public event CtpEventHandler<int> OnHeartBeatWarning;
         
        private void DoRspAuthenticate(ref CtpResponse rsp)
        {
            var handler = OnRspAuthenticate;
            handler?.Invoke(this, rsp.Item1.AsRspAuthenticate, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpRspAuthenticate> OnRspAuthenticate;
         
        private void DoRspUserLogin(ref CtpResponse rsp)
        {
            var handler = OnRspUserLogin;
            handler?.Invoke(this, rsp.Item1.AsRspUserLogin, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpRspUserLogin> OnRspUserLogin;
         
        private void DoRspUserLogout(ref CtpResponse rsp)
        {
            var handler = OnRspUserLogout;
            handler?.Invoke(this, rsp.Item1.AsUserLogout, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpUserLogout> OnRspUserLogout;
         
        private void DoRspUserPasswordUpdate(ref CtpResponse rsp)
        {
            var handler = OnRspUserPasswordUpdate;
            handler?.Invoke(this, rsp.Item1.AsUserPasswordUpdate, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpUserPasswordUpdate> OnRspUserPasswordUpdate;
         
        private void DoRspTradingAccountPasswordUpdate(ref CtpResponse rsp)
        {
            var handler = OnRspTradingAccountPasswordUpdate;
            handler?.Invoke(this, rsp.Item1.AsTradingAccountPasswordUpdate, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpTradingAccountPasswordUpdate> OnRspTradingAccountPasswordUpdate;
         
        private void DoRspUserAuthMethod(ref CtpResponse rsp)
        {
            var handler = OnRspUserAuthMethod;
            handler?.Invoke(this, rsp.Item1.AsRspUserAuthMethod, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpRspUserAuthMethod> OnRspUserAuthMethod;
         
        private void DoRspGenUserCaptcha(ref CtpResponse rsp)
        {
            var handler = OnRspGenUserCaptcha;
            handler?.Invoke(this, rsp.Item1.AsRspGenUserCaptcha, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpRspGenUserCaptcha> OnRspGenUserCaptcha;
         
        private void DoRspGenUserText(ref CtpResponse rsp)
        {
            var handler = OnRspGenUserText;
            handler?.Invoke(this, rsp.Item1.AsRspGenUserText, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpRspGenUserText> OnRspGenUserText;
         
        private void DoRspOrderInsert(ref CtpResponse rsp)
        {
            var handler = OnRspOrderInsert;
            handler?.Invoke(this, rsp.Item1.AsInputOrder, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpInputOrder> OnRspOrderInsert;
         
        private void DoRspParkedOrderInsert(ref CtpResponse rsp)
        {
            var handler = OnRspParkedOrderInsert;
            handler?.Invoke(this, rsp.Item1.AsParkedOrder, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpParkedOrder> OnRspParkedOrderInsert;
         
        private void DoRspParkedOrderAction(ref CtpResponse rsp)
        {
            var handler = OnRspParkedOrderAction;
            handler?.Invoke(this, rsp.Item1.AsParkedOrderAction, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpParkedOrderAction> OnRspParkedOrderAction;
         
        private void DoRspOrderAction(ref CtpResponse rsp)
        {
            var handler = OnRspOrderAction;
            handler?.Invoke(this, rsp.Item1.AsInputOrderAction, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpInputOrderAction> OnRspOrderAction;
         
        private void DoRspQueryMaxOrderVolume(ref CtpResponse rsp)
        {
            var handler = OnRspQueryMaxOrderVolume;
            handler?.Invoke(this, rsp.Item1.AsQueryMaxOrderVolume, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpQueryMaxOrderVolume> OnRspQueryMaxOrderVolume;
         
        private void DoRspSettlementInfoConfirm(ref CtpResponse rsp)
        {
            var handler = OnRspSettlementInfoConfirm;
            handler?.Invoke(this, rsp.Item1.AsSettlementInfoConfirm, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpSettlementInfoConfirm> OnRspSettlementInfoConfirm;
         
        private void DoRspRemoveParkedOrder(ref CtpResponse rsp)
        {
            var handler = OnRspRemoveParkedOrder;
            handler?.Invoke(this, rsp.Item1.AsRemoveParkedOrder, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpRemoveParkedOrder> OnRspRemoveParkedOrder;
         
        private void DoRspRemoveParkedOrderAction(ref CtpResponse rsp)
        {
            var handler = OnRspRemoveParkedOrderAction;
            handler?.Invoke(this, rsp.Item1.AsRemoveParkedOrderAction, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpRemoveParkedOrderAction> OnRspRemoveParkedOrderAction;
         
        private void DoRspExecOrderInsert(ref CtpResponse rsp)
        {
            var handler = OnRspExecOrderInsert;
            handler?.Invoke(this, rsp.Item1.AsInputExecOrder, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpInputExecOrder> OnRspExecOrderInsert;
         
        private void DoRspExecOrderAction(ref CtpResponse rsp)
        {
            var handler = OnRspExecOrderAction;
            handler?.Invoke(this, rsp.Item1.AsInputExecOrderAction, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpInputExecOrderAction> OnRspExecOrderAction;
         
        private void DoRspForQuoteInsert(ref CtpResponse rsp)
        {
            var handler = OnRspForQuoteInsert;
            handler?.Invoke(this, rsp.Item1.AsInputForQuote, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpInputForQuote> OnRspForQuoteInsert;
         
        private void DoRspQuoteInsert(ref CtpResponse rsp)
        {
            var handler = OnRspQuoteInsert;
            handler?.Invoke(this, rsp.Item1.AsInputQuote, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpInputQuote> OnRspQuoteInsert;
         
        private void DoRspQuoteAction(ref CtpResponse rsp)
        {
            var handler = OnRspQuoteAction;
            handler?.Invoke(this, rsp.Item1.AsInputQuoteAction, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpInputQuoteAction> OnRspQuoteAction;
         
        private void DoRspBatchOrderAction(ref CtpResponse rsp)
        {
            var handler = OnRspBatchOrderAction;
            handler?.Invoke(this, rsp.Item1.AsInputBatchOrderAction, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpInputBatchOrderAction> OnRspBatchOrderAction;
         
        private void DoRspOptionSelfCloseInsert(ref CtpResponse rsp)
        {
            var handler = OnRspOptionSelfCloseInsert;
            handler?.Invoke(this, rsp.Item1.AsInputOptionSelfClose, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpInputOptionSelfClose> OnRspOptionSelfCloseInsert;
         
        private void DoRspOptionSelfCloseAction(ref CtpResponse rsp)
        {
            var handler = OnRspOptionSelfCloseAction;
            handler?.Invoke(this, rsp.Item1.AsInputOptionSelfCloseAction, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpInputOptionSelfCloseAction> OnRspOptionSelfCloseAction;
         
        private void DoRspCombActionInsert(ref CtpResponse rsp)
        {
            var handler = OnRspCombActionInsert;
            handler?.Invoke(this, rsp.Item1.AsInputCombAction, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpInputCombAction> OnRspCombActionInsert;
         
        private void DoRspQryOrder(ref CtpResponse rsp)
        {
            var handler = OnRspQryOrder;
            handler?.Invoke(this, rsp.Item1.AsOrder, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpOrder> OnRspQryOrder;
         
        private void DoRspQryTrade(ref CtpResponse rsp)
        {
            var handler = OnRspQryTrade;
            handler?.Invoke(this, rsp.Item1.AsTrade, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpTrade> OnRspQryTrade;
         
        private void DoRspQryInvestorPosition(ref CtpResponse rsp)
        {
            var handler = OnRspQryInvestorPosition;
            handler?.Invoke(this, rsp.Item1.AsInvestorPosition, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpInvestorPosition> OnRspQryInvestorPosition;
         
        private void DoRspQryTradingAccount(ref CtpResponse rsp)
        {
            var handler = OnRspQryTradingAccount;
            handler?.Invoke(this, rsp.Item1.AsTradingAccount, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpTradingAccount> OnRspQryTradingAccount;
         
        private void DoRspQryInvestor(ref CtpResponse rsp)
        {
            var handler = OnRspQryInvestor;
            handler?.Invoke(this, rsp.Item1.AsInvestor, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpInvestor> OnRspQryInvestor;
         
        private void DoRspQryTradingCode(ref CtpResponse rsp)
        {
            var handler = OnRspQryTradingCode;
            handler?.Invoke(this, rsp.Item1.AsTradingCode, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpTradingCode> OnRspQryTradingCode;
         
        private void DoRspQryInstrumentMarginRate(ref CtpResponse rsp)
        {
            var handler = OnRspQryInstrumentMarginRate;
            handler?.Invoke(this, rsp.Item1.AsInstrumentMarginRate, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpInstrumentMarginRate> OnRspQryInstrumentMarginRate;
         
        private void DoRspQryInstrumentCommissionRate(ref CtpResponse rsp)
        {
            var handler = OnRspQryInstrumentCommissionRate;
            handler?.Invoke(this, rsp.Item1.AsInstrumentCommissionRate, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpInstrumentCommissionRate> OnRspQryInstrumentCommissionRate;
         
        private void DoRspQryExchange(ref CtpResponse rsp)
        {
            var handler = OnRspQryExchange;
            handler?.Invoke(this, rsp.Item1.AsExchange, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpExchange> OnRspQryExchange;
         
        private void DoRspQryProduct(ref CtpResponse rsp)
        {
            var handler = OnRspQryProduct;
            handler?.Invoke(this, rsp.Item1.AsProduct, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpProduct> OnRspQryProduct;
         
        private void DoRspQryInstrument(ref CtpResponse rsp)
        {
            var handler = OnRspQryInstrument;
            handler?.Invoke(this, rsp.Item1.AsInstrument, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpInstrument> OnRspQryInstrument;
         
        private void DoRspQryDepthMarketData(ref CtpResponse rsp)
        {
            var handler = OnRspQryDepthMarketData;
            handler?.Invoke(this, rsp.Item1.AsDepthMarketData, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpDepthMarketData> OnRspQryDepthMarketData;
         
        private void DoRspQrySettlementInfo(ref CtpResponse rsp)
        {
            var handler = OnRspQrySettlementInfo;
            handler?.Invoke(this, rsp.Item1.AsSettlementInfo, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpSettlementInfo> OnRspQrySettlementInfo;
         
        private void DoRspQryTransferBank(ref CtpResponse rsp)
        {
            var handler = OnRspQryTransferBank;
            handler?.Invoke(this, rsp.Item1.AsTransferBank, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpTransferBank> OnRspQryTransferBank;
         
        private void DoRspQryInvestorPositionDetail(ref CtpResponse rsp)
        {
            var handler = OnRspQryInvestorPositionDetail;
            handler?.Invoke(this, rsp.Item1.AsInvestorPositionDetail, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpInvestorPositionDetail> OnRspQryInvestorPositionDetail;
         
        private void DoRspQryNotice(ref CtpResponse rsp)
        {
            var handler = OnRspQryNotice;
            handler?.Invoke(this, rsp.Item1.AsNotice, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpNotice> OnRspQryNotice;
         
        private void DoRspQrySettlementInfoConfirm(ref CtpResponse rsp)
        {
            var handler = OnRspQrySettlementInfoConfirm;
            handler?.Invoke(this, rsp.Item1.AsSettlementInfoConfirm, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpSettlementInfoConfirm> OnRspQrySettlementInfoConfirm;
         
        private void DoRspQryInvestorPositionCombineDetail(ref CtpResponse rsp)
        {
            var handler = OnRspQryInvestorPositionCombineDetail;
            handler?.Invoke(this, rsp.Item1.AsInvestorPositionCombineDetail, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpInvestorPositionCombineDetail> OnRspQryInvestorPositionCombineDetail;
         
        private void DoRspQryCFMMCTradingAccountKey(ref CtpResponse rsp)
        {
            var handler = OnRspQryCFMMCTradingAccountKey;
            handler?.Invoke(this, rsp.Item1.AsCFMMCTradingAccountKey, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpCFMMCTradingAccountKey> OnRspQryCFMMCTradingAccountKey;
         
        private void DoRspQryEWarrantOffset(ref CtpResponse rsp)
        {
            var handler = OnRspQryEWarrantOffset;
            handler?.Invoke(this, rsp.Item1.AsEWarrantOffset, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpEWarrantOffset> OnRspQryEWarrantOffset;
         
        private void DoRspQryInvestorProductGroupMargin(ref CtpResponse rsp)
        {
            var handler = OnRspQryInvestorProductGroupMargin;
            handler?.Invoke(this, rsp.Item1.AsInvestorProductGroupMargin, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpInvestorProductGroupMargin> OnRspQryInvestorProductGroupMargin;
         
        private void DoRspQryExchangeMarginRate(ref CtpResponse rsp)
        {
            var handler = OnRspQryExchangeMarginRate;
            handler?.Invoke(this, rsp.Item1.AsExchangeMarginRate, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpExchangeMarginRate> OnRspQryExchangeMarginRate;
         
        private void DoRspQryExchangeMarginRateAdjust(ref CtpResponse rsp)
        {
            var handler = OnRspQryExchangeMarginRateAdjust;
            handler?.Invoke(this, rsp.Item1.AsExchangeMarginRateAdjust, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpExchangeMarginRateAdjust> OnRspQryExchangeMarginRateAdjust;
         
        private void DoRspQryExchangeRate(ref CtpResponse rsp)
        {
            var handler = OnRspQryExchangeRate;
            handler?.Invoke(this, rsp.Item1.AsExchangeRate, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpExchangeRate> OnRspQryExchangeRate;
         
        private void DoRspQrySecAgentACIDMap(ref CtpResponse rsp)
        {
            var handler = OnRspQrySecAgentACIDMap;
            handler?.Invoke(this, rsp.Item1.AsSecAgentACIDMap, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpSecAgentACIDMap> OnRspQrySecAgentACIDMap;
         
        private void DoRspQryProductExchRate(ref CtpResponse rsp)
        {
            var handler = OnRspQryProductExchRate;
            handler?.Invoke(this, rsp.Item1.AsProductExchRate, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpProductExchRate> OnRspQryProductExchRate;
         
        private void DoRspQryProductGroup(ref CtpResponse rsp)
        {
            var handler = OnRspQryProductGroup;
            handler?.Invoke(this, rsp.Item1.AsProductGroup, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpProductGroup> OnRspQryProductGroup;
         
        private void DoRspQryMMInstrumentCommissionRate(ref CtpResponse rsp)
        {
            var handler = OnRspQryMMInstrumentCommissionRate;
            handler?.Invoke(this, rsp.Item1.AsMMInstrumentCommissionRate, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpMMInstrumentCommissionRate> OnRspQryMMInstrumentCommissionRate;
         
        private void DoRspQryMMOptionInstrCommRate(ref CtpResponse rsp)
        {
            var handler = OnRspQryMMOptionInstrCommRate;
            handler?.Invoke(this, rsp.Item1.AsMMOptionInstrCommRate, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpMMOptionInstrCommRate> OnRspQryMMOptionInstrCommRate;
         
        private void DoRspQryInstrumentOrderCommRate(ref CtpResponse rsp)
        {
            var handler = OnRspQryInstrumentOrderCommRate;
            handler?.Invoke(this, rsp.Item1.AsInstrumentOrderCommRate, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpInstrumentOrderCommRate> OnRspQryInstrumentOrderCommRate;
         
        private void DoRspQrySecAgentTradingAccount(ref CtpResponse rsp)
        {
            var handler = OnRspQrySecAgentTradingAccount;
            handler?.Invoke(this, rsp.Item1.AsTradingAccount, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpTradingAccount> OnRspQrySecAgentTradingAccount;
         
        private void DoRspQrySecAgentCheckMode(ref CtpResponse rsp)
        {
            var handler = OnRspQrySecAgentCheckMode;
            handler?.Invoke(this, rsp.Item1.AsSecAgentCheckMode, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpSecAgentCheckMode> OnRspQrySecAgentCheckMode;
         
        private void DoRspQrySecAgentTradeInfo(ref CtpResponse rsp)
        {
            var handler = OnRspQrySecAgentTradeInfo;
            handler?.Invoke(this, rsp.Item1.AsSecAgentTradeInfo, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpSecAgentTradeInfo> OnRspQrySecAgentTradeInfo;
         
        private void DoRspQryOptionInstrTradeCost(ref CtpResponse rsp)
        {
            var handler = OnRspQryOptionInstrTradeCost;
            handler?.Invoke(this, rsp.Item1.AsOptionInstrTradeCost, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpOptionInstrTradeCost> OnRspQryOptionInstrTradeCost;
         
        private void DoRspQryOptionInstrCommRate(ref CtpResponse rsp)
        {
            var handler = OnRspQryOptionInstrCommRate;
            handler?.Invoke(this, rsp.Item1.AsOptionInstrCommRate, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpOptionInstrCommRate> OnRspQryOptionInstrCommRate;
         
        private void DoRspQryExecOrder(ref CtpResponse rsp)
        {
            var handler = OnRspQryExecOrder;
            handler?.Invoke(this, rsp.Item1.AsExecOrder, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpExecOrder> OnRspQryExecOrder;
         
        private void DoRspQryForQuote(ref CtpResponse rsp)
        {
            var handler = OnRspQryForQuote;
            handler?.Invoke(this, rsp.Item1.AsForQuote, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpForQuote> OnRspQryForQuote;
         
        private void DoRspQryQuote(ref CtpResponse rsp)
        {
            var handler = OnRspQryQuote;
            handler?.Invoke(this, rsp.Item1.AsQuote, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpQuote> OnRspQryQuote;
         
        private void DoRspQryOptionSelfClose(ref CtpResponse rsp)
        {
            var handler = OnRspQryOptionSelfClose;
            handler?.Invoke(this, rsp.Item1.AsOptionSelfClose, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpOptionSelfClose> OnRspQryOptionSelfClose;
         
        private void DoRspQryInvestUnit(ref CtpResponse rsp)
        {
            var handler = OnRspQryInvestUnit;
            handler?.Invoke(this, rsp.Item1.AsInvestUnit, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpInvestUnit> OnRspQryInvestUnit;
         
        private void DoRspQryCombInstrumentGuard(ref CtpResponse rsp)
        {
            var handler = OnRspQryCombInstrumentGuard;
            handler?.Invoke(this, rsp.Item1.AsCombInstrumentGuard, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpCombInstrumentGuard> OnRspQryCombInstrumentGuard;
         
        private void DoRspQryCombAction(ref CtpResponse rsp)
        {
            var handler = OnRspQryCombAction;
            handler?.Invoke(this, rsp.Item1.AsCombAction, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpCombAction> OnRspQryCombAction;
         
        private void DoRspQryTransferSerial(ref CtpResponse rsp)
        {
            var handler = OnRspQryTransferSerial;
            handler?.Invoke(this, rsp.Item1.AsTransferSerial, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpTransferSerial> OnRspQryTransferSerial;
         
        private void DoRspQryAccountregister(ref CtpResponse rsp)
        {
            var handler = OnRspQryAccountregister;
            handler?.Invoke(this, rsp.Item1.AsAccountregister, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpAccountregister> OnRspQryAccountregister;
         
        private void DoRspError(ref CtpResponse rsp)
        {
            var handler = OnRspError;
            handler?.Invoke(this, rsp.Item1.AsRspInfo, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler3 OnRspError;
         
        private void DoRtnOrder(ref CtpResponse rsp)
        {
            var handler = OnRtnOrder;
            handler?.Invoke(this, rsp.Item1.AsOrder);
        }
        
        public event CtpEventHandler<CtpOrder> OnRtnOrder;
         
        private void DoRtnTrade(ref CtpResponse rsp)
        {
            var handler = OnRtnTrade;
            handler?.Invoke(this, rsp.Item1.AsTrade);
        }
        
        public event CtpEventHandler<CtpTrade> OnRtnTrade;
         
        private void DoErrRtnOrderInsert(ref CtpResponse rsp)
        {
            var handler = OnErrRtnOrderInsert;
            handler?.Invoke(this, rsp.Item1.AsInputOrder, rsp.Item2);
        }
        
        public event CtpEventHandler2<CtpInputOrder> OnErrRtnOrderInsert;
         
        private void DoErrRtnOrderAction(ref CtpResponse rsp)
        {
            var handler = OnErrRtnOrderAction;
            handler?.Invoke(this, rsp.Item1.AsOrderAction, rsp.Item2);
        }
        
        public event CtpEventHandler2<CtpOrderAction> OnErrRtnOrderAction;
         
        private void DoRtnInstrumentStatus(ref CtpResponse rsp)
        {
            var handler = OnRtnInstrumentStatus;
            handler?.Invoke(this, rsp.Item1.AsInstrumentStatus);
        }
        
        public event CtpEventHandler<CtpInstrumentStatus> OnRtnInstrumentStatus;
         
        private void DoRtnBulletin(ref CtpResponse rsp)
        {
            var handler = OnRtnBulletin;
            handler?.Invoke(this, rsp.Item1.AsBulletin);
        }
        
        public event CtpEventHandler<CtpBulletin> OnRtnBulletin;
         
        private void DoRtnTradingNotice(ref CtpResponse rsp)
        {
            var handler = OnRtnTradingNotice;
            handler?.Invoke(this, rsp.Item1.AsTradingNoticeInfo);
        }
        
        public event CtpEventHandler<CtpTradingNoticeInfo> OnRtnTradingNotice;
         
        private void DoRtnErrorConditionalOrder(ref CtpResponse rsp)
        {
            var handler = OnRtnErrorConditionalOrder;
            handler?.Invoke(this, rsp.Item1.AsErrorConditionalOrder);
        }
        
        public event CtpEventHandler<CtpErrorConditionalOrder> OnRtnErrorConditionalOrder;
         
        private void DoRtnExecOrder(ref CtpResponse rsp)
        {
            var handler = OnRtnExecOrder;
            handler?.Invoke(this, rsp.Item1.AsExecOrder);
        }
        
        public event CtpEventHandler<CtpExecOrder> OnRtnExecOrder;
         
        private void DoErrRtnExecOrderInsert(ref CtpResponse rsp)
        {
            var handler = OnErrRtnExecOrderInsert;
            handler?.Invoke(this, rsp.Item1.AsInputExecOrder, rsp.Item2);
        }
        
        public event CtpEventHandler2<CtpInputExecOrder> OnErrRtnExecOrderInsert;
         
        private void DoErrRtnExecOrderAction(ref CtpResponse rsp)
        {
            var handler = OnErrRtnExecOrderAction;
            handler?.Invoke(this, rsp.Item1.AsExecOrderAction, rsp.Item2);
        }
        
        public event CtpEventHandler2<CtpExecOrderAction> OnErrRtnExecOrderAction;
         
        private void DoErrRtnForQuoteInsert(ref CtpResponse rsp)
        {
            var handler = OnErrRtnForQuoteInsert;
            handler?.Invoke(this, rsp.Item1.AsInputForQuote, rsp.Item2);
        }
        
        public event CtpEventHandler2<CtpInputForQuote> OnErrRtnForQuoteInsert;
         
        private void DoRtnQuote(ref CtpResponse rsp)
        {
            var handler = OnRtnQuote;
            handler?.Invoke(this, rsp.Item1.AsQuote);
        }
        
        public event CtpEventHandler<CtpQuote> OnRtnQuote;
         
        private void DoErrRtnQuoteInsert(ref CtpResponse rsp)
        {
            var handler = OnErrRtnQuoteInsert;
            handler?.Invoke(this, rsp.Item1.AsInputQuote, rsp.Item2);
        }
        
        public event CtpEventHandler2<CtpInputQuote> OnErrRtnQuoteInsert;
         
        private void DoErrRtnQuoteAction(ref CtpResponse rsp)
        {
            var handler = OnErrRtnQuoteAction;
            handler?.Invoke(this, rsp.Item1.AsQuoteAction, rsp.Item2);
        }
        
        public event CtpEventHandler2<CtpQuoteAction> OnErrRtnQuoteAction;
         
        private void DoRtnForQuoteRsp(ref CtpResponse rsp)
        {
            var handler = OnRtnForQuoteRsp;
            handler?.Invoke(this, rsp.Item1.AsForQuoteRsp);
        }
        
        public event CtpEventHandler<CtpForQuoteRsp> OnRtnForQuoteRsp;
         
        private void DoRtnCFMMCTradingAccountToken(ref CtpResponse rsp)
        {
            var handler = OnRtnCFMMCTradingAccountToken;
            handler?.Invoke(this, rsp.Item1.AsCFMMCTradingAccountToken);
        }
        
        public event CtpEventHandler<CtpCFMMCTradingAccountToken> OnRtnCFMMCTradingAccountToken;
         
        private void DoErrRtnBatchOrderAction(ref CtpResponse rsp)
        {
            var handler = OnErrRtnBatchOrderAction;
            handler?.Invoke(this, rsp.Item1.AsBatchOrderAction, rsp.Item2);
        }
        
        public event CtpEventHandler2<CtpBatchOrderAction> OnErrRtnBatchOrderAction;
         
        private void DoRtnOptionSelfClose(ref CtpResponse rsp)
        {
            var handler = OnRtnOptionSelfClose;
            handler?.Invoke(this, rsp.Item1.AsOptionSelfClose);
        }
        
        public event CtpEventHandler<CtpOptionSelfClose> OnRtnOptionSelfClose;
         
        private void DoErrRtnOptionSelfCloseInsert(ref CtpResponse rsp)
        {
            var handler = OnErrRtnOptionSelfCloseInsert;
            handler?.Invoke(this, rsp.Item1.AsInputOptionSelfClose, rsp.Item2);
        }
        
        public event CtpEventHandler2<CtpInputOptionSelfClose> OnErrRtnOptionSelfCloseInsert;
         
        private void DoErrRtnOptionSelfCloseAction(ref CtpResponse rsp)
        {
            var handler = OnErrRtnOptionSelfCloseAction;
            handler?.Invoke(this, rsp.Item1.AsOptionSelfCloseAction, rsp.Item2);
        }
        
        public event CtpEventHandler2<CtpOptionSelfCloseAction> OnErrRtnOptionSelfCloseAction;
         
        private void DoRtnCombAction(ref CtpResponse rsp)
        {
            var handler = OnRtnCombAction;
            handler?.Invoke(this, rsp.Item1.AsCombAction);
        }
        
        public event CtpEventHandler<CtpCombAction> OnRtnCombAction;
         
        private void DoErrRtnCombActionInsert(ref CtpResponse rsp)
        {
            var handler = OnErrRtnCombActionInsert;
            handler?.Invoke(this, rsp.Item1.AsInputCombAction, rsp.Item2);
        }
        
        public event CtpEventHandler2<CtpInputCombAction> OnErrRtnCombActionInsert;
         
        private void DoRspQryContractBank(ref CtpResponse rsp)
        {
            var handler = OnRspQryContractBank;
            handler?.Invoke(this, rsp.Item1.AsContractBank, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpContractBank> OnRspQryContractBank;
         
        private void DoRspQryParkedOrder(ref CtpResponse rsp)
        {
            var handler = OnRspQryParkedOrder;
            handler?.Invoke(this, rsp.Item1.AsParkedOrder, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpParkedOrder> OnRspQryParkedOrder;
         
        private void DoRspQryParkedOrderAction(ref CtpResponse rsp)
        {
            var handler = OnRspQryParkedOrderAction;
            handler?.Invoke(this, rsp.Item1.AsParkedOrderAction, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpParkedOrderAction> OnRspQryParkedOrderAction;
         
        private void DoRspQryTradingNotice(ref CtpResponse rsp)
        {
            var handler = OnRspQryTradingNotice;
            handler?.Invoke(this, rsp.Item1.AsTradingNotice, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpTradingNotice> OnRspQryTradingNotice;
         
        private void DoRspQryBrokerTradingParams(ref CtpResponse rsp)
        {
            var handler = OnRspQryBrokerTradingParams;
            handler?.Invoke(this, rsp.Item1.AsBrokerTradingParams, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpBrokerTradingParams> OnRspQryBrokerTradingParams;
         
        private void DoRspQryBrokerTradingAlgos(ref CtpResponse rsp)
        {
            var handler = OnRspQryBrokerTradingAlgos;
            handler?.Invoke(this, rsp.Item1.AsBrokerTradingAlgos, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpBrokerTradingAlgos> OnRspQryBrokerTradingAlgos;
         
        private void DoRspQueryCFMMCTradingAccountToken(ref CtpResponse rsp)
        {
            var handler = OnRspQueryCFMMCTradingAccountToken;
            handler?.Invoke(this, rsp.Item1.AsQueryCFMMCTradingAccountToken, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpQueryCFMMCTradingAccountToken> OnRspQueryCFMMCTradingAccountToken;
         
        private void DoRtnFromBankToFutureByBank(ref CtpResponse rsp)
        {
            var handler = OnRtnFromBankToFutureByBank;
            handler?.Invoke(this, rsp.Item1.AsRspTransfer);
        }
        
        public event CtpEventHandler<CtpRspTransfer> OnRtnFromBankToFutureByBank;
         
        private void DoRtnFromFutureToBankByBank(ref CtpResponse rsp)
        {
            var handler = OnRtnFromFutureToBankByBank;
            handler?.Invoke(this, rsp.Item1.AsRspTransfer);
        }
        
        public event CtpEventHandler<CtpRspTransfer> OnRtnFromFutureToBankByBank;
         
        private void DoRtnRepealFromBankToFutureByBank(ref CtpResponse rsp)
        {
            var handler = OnRtnRepealFromBankToFutureByBank;
            handler?.Invoke(this, rsp.Item1.AsRspRepeal);
        }
        
        public event CtpEventHandler<CtpRspRepeal> OnRtnRepealFromBankToFutureByBank;
         
        private void DoRtnRepealFromFutureToBankByBank(ref CtpResponse rsp)
        {
            var handler = OnRtnRepealFromFutureToBankByBank;
            handler?.Invoke(this, rsp.Item1.AsRspRepeal);
        }
        
        public event CtpEventHandler<CtpRspRepeal> OnRtnRepealFromFutureToBankByBank;
         
        private void DoRtnFromBankToFutureByFuture(ref CtpResponse rsp)
        {
            var handler = OnRtnFromBankToFutureByFuture;
            handler?.Invoke(this, rsp.Item1.AsRspTransfer);
        }
        
        public event CtpEventHandler<CtpRspTransfer> OnRtnFromBankToFutureByFuture;
         
        private void DoRtnFromFutureToBankByFuture(ref CtpResponse rsp)
        {
            var handler = OnRtnFromFutureToBankByFuture;
            handler?.Invoke(this, rsp.Item1.AsRspTransfer);
        }
        
        public event CtpEventHandler<CtpRspTransfer> OnRtnFromFutureToBankByFuture;
         
        private void DoRtnRepealFromBankToFutureByFutureManual(ref CtpResponse rsp)
        {
            var handler = OnRtnRepealFromBankToFutureByFutureManual;
            handler?.Invoke(this, rsp.Item1.AsRspRepeal);
        }
        
        public event CtpEventHandler<CtpRspRepeal> OnRtnRepealFromBankToFutureByFutureManual;
         
        private void DoRtnRepealFromFutureToBankByFutureManual(ref CtpResponse rsp)
        {
            var handler = OnRtnRepealFromFutureToBankByFutureManual;
            handler?.Invoke(this, rsp.Item1.AsRspRepeal);
        }
        
        public event CtpEventHandler<CtpRspRepeal> OnRtnRepealFromFutureToBankByFutureManual;
         
        private void DoRtnQueryBankBalanceByFuture(ref CtpResponse rsp)
        {
            var handler = OnRtnQueryBankBalanceByFuture;
            handler?.Invoke(this, rsp.Item1.AsNotifyQueryAccount);
        }
        
        public event CtpEventHandler<CtpNotifyQueryAccount> OnRtnQueryBankBalanceByFuture;
         
        private void DoErrRtnBankToFutureByFuture(ref CtpResponse rsp)
        {
            var handler = OnErrRtnBankToFutureByFuture;
            handler?.Invoke(this, rsp.Item1.AsReqTransfer, rsp.Item2);
        }
        
        public event CtpEventHandler2<CtpReqTransfer> OnErrRtnBankToFutureByFuture;
         
        private void DoErrRtnFutureToBankByFuture(ref CtpResponse rsp)
        {
            var handler = OnErrRtnFutureToBankByFuture;
            handler?.Invoke(this, rsp.Item1.AsReqTransfer, rsp.Item2);
        }
        
        public event CtpEventHandler2<CtpReqTransfer> OnErrRtnFutureToBankByFuture;
         
        private void DoErrRtnRepealBankToFutureByFutureManual(ref CtpResponse rsp)
        {
            var handler = OnErrRtnRepealBankToFutureByFutureManual;
            handler?.Invoke(this, rsp.Item1.AsReqRepeal, rsp.Item2);
        }
        
        public event CtpEventHandler2<CtpReqRepeal> OnErrRtnRepealBankToFutureByFutureManual;
         
        private void DoErrRtnRepealFutureToBankByFutureManual(ref CtpResponse rsp)
        {
            var handler = OnErrRtnRepealFutureToBankByFutureManual;
            handler?.Invoke(this, rsp.Item1.AsReqRepeal, rsp.Item2);
        }
        
        public event CtpEventHandler2<CtpReqRepeal> OnErrRtnRepealFutureToBankByFutureManual;
         
        private void DoErrRtnQueryBankBalanceByFuture(ref CtpResponse rsp)
        {
            var handler = OnErrRtnQueryBankBalanceByFuture;
            handler?.Invoke(this, rsp.Item1.AsReqQueryAccount, rsp.Item2);
        }
        
        public event CtpEventHandler2<CtpReqQueryAccount> OnErrRtnQueryBankBalanceByFuture;
         
        private void DoRtnRepealFromBankToFutureByFuture(ref CtpResponse rsp)
        {
            var handler = OnRtnRepealFromBankToFutureByFuture;
            handler?.Invoke(this, rsp.Item1.AsRspRepeal);
        }
        
        public event CtpEventHandler<CtpRspRepeal> OnRtnRepealFromBankToFutureByFuture;
         
        private void DoRtnRepealFromFutureToBankByFuture(ref CtpResponse rsp)
        {
            var handler = OnRtnRepealFromFutureToBankByFuture;
            handler?.Invoke(this, rsp.Item1.AsRspRepeal);
        }
        
        public event CtpEventHandler<CtpRspRepeal> OnRtnRepealFromFutureToBankByFuture;
         
        private void DoRspFromBankToFutureByFuture(ref CtpResponse rsp)
        {
            var handler = OnRspFromBankToFutureByFuture;
            handler?.Invoke(this, rsp.Item1.AsReqTransfer, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpReqTransfer> OnRspFromBankToFutureByFuture;
         
        private void DoRspFromFutureToBankByFuture(ref CtpResponse rsp)
        {
            var handler = OnRspFromFutureToBankByFuture;
            handler?.Invoke(this, rsp.Item1.AsReqTransfer, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpReqTransfer> OnRspFromFutureToBankByFuture;
         
        private void DoRspQueryBankAccountMoneyByFuture(ref CtpResponse rsp)
        {
            var handler = OnRspQueryBankAccountMoneyByFuture;
            handler?.Invoke(this, rsp.Item1.AsReqQueryAccount, rsp.Item2, rsp.RequestID, rsp.IsLast);
        }
        
        public event CtpEventHandler4<CtpReqQueryAccount> OnRspQueryBankAccountMoneyByFuture;
         
        private void DoRtnOpenAccountByBank(ref CtpResponse rsp)
        {
            var handler = OnRtnOpenAccountByBank;
            handler?.Invoke(this, rsp.Item1.AsOpenAccount);
        }
        
        public event CtpEventHandler<CtpOpenAccount> OnRtnOpenAccountByBank;
         
        private void DoRtnCancelAccountByBank(ref CtpResponse rsp)
        {
            var handler = OnRtnCancelAccountByBank;
            handler?.Invoke(this, rsp.Item1.AsCancelAccount);
        }
        
        public event CtpEventHandler<CtpCancelAccount> OnRtnCancelAccountByBank;
         
        private void DoRtnChangeAccountByBank(ref CtpResponse rsp)
        {
            var handler = OnRtnChangeAccountByBank;
            handler?.Invoke(this, rsp.Item1.AsChangeAccount);
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