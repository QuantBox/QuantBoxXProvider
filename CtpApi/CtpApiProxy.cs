using System;

namespace QuantBox.Sfit.Api
{
    public class CtpApiProxy
    {
        private void InitHandlerList()
        {
            DefaultHandler = (req) => { };
            ReqHandlerList = new Action<CtpRequest>[CtpRequestType.Max];
            for (var i = 0; i < CtpRequestType.Max; i++) {
                ReqHandlerList[i] = DefaultHandler;
            }

            #region Request Handler
            ReqHandlerList[CtpRequestType.SubscribeMarketData] = req => SubscribeMarketData(req, req.Args.AsStringArray);
            ReqHandlerList[CtpRequestType.UnSubscribeMarketData] = req => SubscribeMarketData(req, req.Args.AsStringArray);
            ReqHandlerList[CtpRequestType.SubscribeForQuoteRsp] = req => SubscribeMarketData(req, req.Args.AsStringArray);
            ReqHandlerList[CtpRequestType.UnSubscribeForQuoteRsp] = req => SubscribeMarketData(req, req.Args.AsStringArray);
            ReqHandlerList[CtpRequestType.ReqAuthenticate] = req => ReqAuthenticate(req, req.Args.AsReqAuthenticate);
            ReqHandlerList[CtpRequestType.ReqUserLogin] = req => ReqUserLogin(req, req.Args.AsReqUserLogin);
            ReqHandlerList[CtpRequestType.ReqUserLogout] = req => ReqUserLogout(req, req.Args.AsUserLogout);
            ReqHandlerList[CtpRequestType.ReqUserPasswordUpdate] = req => ReqUserPasswordUpdate(req, req.Args.AsUserPasswordUpdate);
            ReqHandlerList[CtpRequestType.ReqTradingAccountPasswordUpdate] = req => ReqTradingAccountPasswordUpdate(req, req.Args.AsTradingAccountPasswordUpdate);
            ReqHandlerList[CtpRequestType.ReqOrderInsert] = req => ReqOrderInsert(req, req.Args.AsInputOrder);
            ReqHandlerList[CtpRequestType.ReqParkedOrderInsert] = req => ReqParkedOrderInsert(req, req.Args.AsParkedOrder);
            ReqHandlerList[CtpRequestType.ReqParkedOrderAction] = req => ReqParkedOrderAction(req, req.Args.AsParkedOrderAction);
            ReqHandlerList[CtpRequestType.ReqOrderAction] = req => ReqOrderAction(req, req.Args.AsInputOrderAction);
            ReqHandlerList[CtpRequestType.ReqQueryMaxOrderVolume] = req => ReqQueryMaxOrderVolume(req, req.Args.AsQueryMaxOrderVolume);
            ReqHandlerList[CtpRequestType.ReqSettlementInfoConfirm] = req => ReqSettlementInfoConfirm(req, req.Args.AsSettlementInfoConfirm);
            ReqHandlerList[CtpRequestType.ReqRemoveParkedOrder] = req => ReqRemoveParkedOrder(req, req.Args.AsRemoveParkedOrder);
            ReqHandlerList[CtpRequestType.ReqRemoveParkedOrderAction] = req => ReqRemoveParkedOrderAction(req, req.Args.AsRemoveParkedOrderAction);
            ReqHandlerList[CtpRequestType.ReqExecOrderInsert] = req => ReqExecOrderInsert(req, req.Args.AsInputExecOrder);
            ReqHandlerList[CtpRequestType.ReqExecOrderAction] = req => ReqExecOrderAction(req, req.Args.AsInputExecOrderAction);
            ReqHandlerList[CtpRequestType.ReqForQuoteInsert] = req => ReqForQuoteInsert(req, req.Args.AsInputForQuote);
            ReqHandlerList[CtpRequestType.ReqQuoteInsert] = req => ReqQuoteInsert(req, req.Args.AsInputQuote);
            ReqHandlerList[CtpRequestType.ReqQuoteAction] = req => ReqQuoteAction(req, req.Args.AsInputQuoteAction);
            ReqHandlerList[CtpRequestType.ReqBatchOrderAction] = req => ReqBatchOrderAction(req, req.Args.AsInputBatchOrderAction);
            ReqHandlerList[CtpRequestType.ReqCombActionInsert] = req => ReqCombActionInsert(req, req.Args.AsInputCombAction);
            ReqHandlerList[CtpRequestType.ReqQryOrder] = req => ReqQryOrder(req, req.Args.AsQryOrder);
            ReqHandlerList[CtpRequestType.ReqQryTrade] = req => ReqQryTrade(req, req.Args.AsQryTrade);
            ReqHandlerList[CtpRequestType.ReqQryInvestorPosition] = req => ReqQryInvestorPosition(req, req.Args.AsQryInvestorPosition);
            ReqHandlerList[CtpRequestType.ReqQryTradingAccount] = req => ReqQryTradingAccount(req, req.Args.AsQryTradingAccount);
            ReqHandlerList[CtpRequestType.ReqQryInvestor] = req => ReqQryInvestor(req, req.Args.AsQryInvestor);
            ReqHandlerList[CtpRequestType.ReqQryTradingCode] = req => ReqQryTradingCode(req, req.Args.AsQryTradingCode);
            ReqHandlerList[CtpRequestType.ReqQryInstrumentMarginRate] = req => ReqQryInstrumentMarginRate(req, req.Args.AsQryInstrumentMarginRate);
            ReqHandlerList[CtpRequestType.ReqQryInstrumentCommissionRate] = req => ReqQryInstrumentCommissionRate(req, req.Args.AsQryInstrumentCommissionRate);
            ReqHandlerList[CtpRequestType.ReqQryExchange] = req => ReqQryExchange(req, req.Args.AsQryExchange);
            ReqHandlerList[CtpRequestType.ReqQryProduct] = req => ReqQryProduct(req, req.Args.AsQryProduct);
            ReqHandlerList[CtpRequestType.ReqQryInstrument] = req => ReqQryInstrument(req, req.Args.AsQryInstrument);
            ReqHandlerList[CtpRequestType.ReqQryDepthMarketData] = req => ReqQryDepthMarketData(req, req.Args.AsQryDepthMarketData);
            ReqHandlerList[CtpRequestType.ReqQrySettlementInfo] = req => ReqQrySettlementInfo(req, req.Args.AsQrySettlementInfo);
            ReqHandlerList[CtpRequestType.ReqQryTransferBank] = req => ReqQryTransferBank(req, req.Args.AsQryTransferBank);
            ReqHandlerList[CtpRequestType.ReqQryInvestorPositionDetail] = req => ReqQryInvestorPositionDetail(req, req.Args.AsQryInvestorPositionDetail);
            ReqHandlerList[CtpRequestType.ReqQryNotice] = req => ReqQryNotice(req, req.Args.AsQryNotice);
            ReqHandlerList[CtpRequestType.ReqQrySettlementInfoConfirm] = req => ReqQrySettlementInfoConfirm(req, req.Args.AsQrySettlementInfoConfirm);
            ReqHandlerList[CtpRequestType.ReqQryInvestorPositionCombineDetail] = req => ReqQryInvestorPositionCombineDetail(req, req.Args.AsQryInvestorPositionCombineDetail);
            ReqHandlerList[CtpRequestType.ReqQryCFMMCTradingAccountKey] = req => ReqQryCFMMCTradingAccountKey(req, req.Args.AsQryCFMMCTradingAccountKey);
            ReqHandlerList[CtpRequestType.ReqQryEWarrantOffset] = req => ReqQryEWarrantOffset(req, req.Args.AsQryEWarrantOffset);
            ReqHandlerList[CtpRequestType.ReqQryInvestorProductGroupMargin] = req => ReqQryInvestorProductGroupMargin(req, req.Args.AsQryInvestorProductGroupMargin);
            ReqHandlerList[CtpRequestType.ReqQryExchangeMarginRate] = req => ReqQryExchangeMarginRate(req, req.Args.AsQryExchangeMarginRate);
            ReqHandlerList[CtpRequestType.ReqQryExchangeMarginRateAdjust] = req => ReqQryExchangeMarginRateAdjust(req, req.Args.AsQryExchangeMarginRateAdjust);
            ReqHandlerList[CtpRequestType.ReqQryExchangeRate] = req => ReqQryExchangeRate(req, req.Args.AsQryExchangeRate);
            ReqHandlerList[CtpRequestType.ReqQrySecAgentACIDMap] = req => ReqQrySecAgentACIDMap(req, req.Args.AsQrySecAgentACIDMap);
            ReqHandlerList[CtpRequestType.ReqQryProductExchRate] = req => ReqQryProductExchRate(req, req.Args.AsQryProductExchRate);
            ReqHandlerList[CtpRequestType.ReqQryProductGroup] = req => ReqQryProductGroup(req, req.Args.AsQryProductGroup);
            ReqHandlerList[CtpRequestType.ReqQryOptionInstrTradeCost] = req => ReqQryOptionInstrTradeCost(req, req.Args.AsQryOptionInstrTradeCost);
            ReqHandlerList[CtpRequestType.ReqQryOptionInstrCommRate] = req => ReqQryOptionInstrCommRate(req, req.Args.AsQryOptionInstrCommRate);
            ReqHandlerList[CtpRequestType.ReqQryExecOrder] = req => ReqQryExecOrder(req, req.Args.AsQryExecOrder);
            ReqHandlerList[CtpRequestType.ReqQryForQuote] = req => ReqQryForQuote(req, req.Args.AsQryForQuote);
            ReqHandlerList[CtpRequestType.ReqQryQuote] = req => ReqQryQuote(req, req.Args.AsQryQuote);
            ReqHandlerList[CtpRequestType.ReqQryCombInstrumentGuard] = req => ReqQryCombInstrumentGuard(req, req.Args.AsQryCombInstrumentGuard);
            ReqHandlerList[CtpRequestType.ReqQryCombAction] = req => ReqQryCombAction(req, req.Args.AsQryCombAction);
            ReqHandlerList[CtpRequestType.ReqQryTransferSerial] = req => ReqQryTransferSerial(req, req.Args.AsQryTransferSerial);
            ReqHandlerList[CtpRequestType.ReqQryAccountregister] = req => ReqQryAccountregister(req, req.Args.AsQryAccountregister);
            ReqHandlerList[CtpRequestType.ReqQryContractBank] = req => ReqQryContractBank(req, req.Args.AsQryContractBank);
            ReqHandlerList[CtpRequestType.ReqQryParkedOrder] = req => ReqQryParkedOrder(req, req.Args.AsQryParkedOrder);
            ReqHandlerList[CtpRequestType.ReqQryParkedOrderAction] = req => ReqQryParkedOrderAction(req, req.Args.AsQryParkedOrderAction);
            ReqHandlerList[CtpRequestType.ReqQryTradingNotice] = req => ReqQryTradingNotice(req, req.Args.AsQryTradingNotice);
            ReqHandlerList[CtpRequestType.ReqQryBrokerTradingParams] = req => ReqQryBrokerTradingParams(req, req.Args.AsQryBrokerTradingParams);
            ReqHandlerList[CtpRequestType.ReqQryBrokerTradingAlgos] = req => ReqQryBrokerTradingAlgos(req, req.Args.AsQryBrokerTradingAlgos);
            ReqHandlerList[CtpRequestType.ReqQueryCFMMCTradingAccountToken] = req => ReqQueryCFMMCTradingAccountToken(req, req.Args.AsQueryCFMMCTradingAccountToken);
            ReqHandlerList[CtpRequestType.ReqFromBankToFutureByFuture] = req => ReqFromBankToFutureByFuture(req, req.Args.AsReqTransfer);
            ReqHandlerList[CtpRequestType.ReqFromFutureToBankByFuture] = req => ReqFromFutureToBankByFuture(req, req.Args.AsReqTransfer);
            ReqHandlerList[CtpRequestType.ReqQueryBankAccountMoneyByFuture] = req => ReqQueryBankAccountMoneyByFuture(req, req.Args.AsReqQueryAccount);
            #endregion
        }

        public CtpApiProxy()
        {
            InitHandlerList();
        }

        public void ProcessRequest(CtpRequest req)
        {
            switch (req.TypeId) {
                case CtpRequestType.Request:
                case CtpRequestType.Max:
                    break;
                default:
                    ReqHandlerList[req.TypeId](req);
                    break;
            }
        }

        #region Handler Definition

        public virtual void SubscribeMarketData(CtpRequest req, string[] data)
        {
            DefaultHandler(req);
        }

        public virtual void UnSubscribeMarketData(CtpRequest req, string[] data)
        {
            DefaultHandler(req);
        }

        public virtual void SubscribeForQuoteRsp(CtpRequest req, string[] data)
        {
            DefaultHandler(req);
        }

        public virtual void UnSubscribeForQuoteRsp(CtpRequest req, string[] data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqAuthenticate(CtpRequest req, CtpReqAuthenticate data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqUserLogin(CtpRequest req, CtpReqUserLogin data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqUserLogout(CtpRequest req, CtpUserLogout data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqUserPasswordUpdate(CtpRequest req, CtpUserPasswordUpdate data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqTradingAccountPasswordUpdate(CtpRequest req, CtpTradingAccountPasswordUpdate data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqOrderInsert(CtpRequest req, CtpInputOrder data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqParkedOrderInsert(CtpRequest req, CtpParkedOrder data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqParkedOrderAction(CtpRequest req, CtpParkedOrderAction data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqOrderAction(CtpRequest req, CtpInputOrderAction data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQueryMaxOrderVolume(CtpRequest req, CtpQueryMaxOrderVolume data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqSettlementInfoConfirm(CtpRequest req, CtpSettlementInfoConfirm data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqRemoveParkedOrder(CtpRequest req, CtpRemoveParkedOrder data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqRemoveParkedOrderAction(CtpRequest req, CtpRemoveParkedOrderAction data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqExecOrderInsert(CtpRequest req, CtpInputExecOrder data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqExecOrderAction(CtpRequest req, CtpInputExecOrderAction data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqForQuoteInsert(CtpRequest req, CtpInputForQuote data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQuoteInsert(CtpRequest req, CtpInputQuote data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQuoteAction(CtpRequest req, CtpInputQuoteAction data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqBatchOrderAction(CtpRequest req, CtpInputBatchOrderAction data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqCombActionInsert(CtpRequest req, CtpInputCombAction data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryOrder(CtpRequest req, CtpQryOrder data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryTrade(CtpRequest req, CtpQryTrade data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryInvestorPosition(CtpRequest req, CtpQryInvestorPosition data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryTradingAccount(CtpRequest req, CtpQryTradingAccount data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryInvestor(CtpRequest req, CtpQryInvestor data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryTradingCode(CtpRequest req, CtpQryTradingCode data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryInstrumentMarginRate(CtpRequest req, CtpQryInstrumentMarginRate data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryInstrumentCommissionRate(CtpRequest req, CtpQryInstrumentCommissionRate data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryExchange(CtpRequest req, CtpQryExchange data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryProduct(CtpRequest req, CtpQryProduct data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryInstrument(CtpRequest req, CtpQryInstrument data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryDepthMarketData(CtpRequest req, CtpQryDepthMarketData data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQrySettlementInfo(CtpRequest req, CtpQrySettlementInfo data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryTransferBank(CtpRequest req, CtpQryTransferBank data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryInvestorPositionDetail(CtpRequest req, CtpQryInvestorPositionDetail data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryNotice(CtpRequest req, CtpQryNotice data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQrySettlementInfoConfirm(CtpRequest req, CtpQrySettlementInfoConfirm data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryInvestorPositionCombineDetail(CtpRequest req, CtpQryInvestorPositionCombineDetail data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryCFMMCTradingAccountKey(CtpRequest req, CtpQryCFMMCTradingAccountKey data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryEWarrantOffset(CtpRequest req, CtpQryEWarrantOffset data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryInvestorProductGroupMargin(CtpRequest req, CtpQryInvestorProductGroupMargin data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryExchangeMarginRate(CtpRequest req, CtpQryExchangeMarginRate data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryExchangeMarginRateAdjust(CtpRequest req, CtpQryExchangeMarginRateAdjust data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryExchangeRate(CtpRequest req, CtpQryExchangeRate data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQrySecAgentACIDMap(CtpRequest req, CtpQrySecAgentACIDMap data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryProductExchRate(CtpRequest req, CtpQryProductExchRate data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryProductGroup(CtpRequest req, CtpQryProductGroup data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryOptionInstrTradeCost(CtpRequest req, CtpQryOptionInstrTradeCost data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryOptionInstrCommRate(CtpRequest req, CtpQryOptionInstrCommRate data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryExecOrder(CtpRequest req, CtpQryExecOrder data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryForQuote(CtpRequest req, CtpQryForQuote data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryQuote(CtpRequest req, CtpQryQuote data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryCombInstrumentGuard(CtpRequest req, CtpQryCombInstrumentGuard data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryCombAction(CtpRequest req, CtpQryCombAction data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryTransferSerial(CtpRequest req, CtpQryTransferSerial data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryAccountregister(CtpRequest req, CtpQryAccountregister data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryContractBank(CtpRequest req, CtpQryContractBank data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryParkedOrder(CtpRequest req, CtpQryParkedOrder data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryParkedOrderAction(CtpRequest req, CtpQryParkedOrderAction data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryTradingNotice(CtpRequest req, CtpQryTradingNotice data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryBrokerTradingParams(CtpRequest req, CtpQryBrokerTradingParams data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQryBrokerTradingAlgos(CtpRequest req, CtpQryBrokerTradingAlgos data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQueryCFMMCTradingAccountToken(CtpRequest req, CtpQueryCFMMCTradingAccountToken data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqFromBankToFutureByFuture(CtpRequest req, CtpReqTransfer data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqFromFutureToBankByFuture(CtpRequest req, CtpReqTransfer data)
        {
            DefaultHandler(req);
        }

        public virtual void ReqQueryBankAccountMoneyByFuture(CtpRequest req, CtpReqQueryAccount data)
        {
            DefaultHandler(req);
        }

        #endregion

        public Action<CtpRequest> DefaultHandler { get; set; }
        public Action<CtpRequest>[] ReqHandlerList { get; private set; }
    }
}