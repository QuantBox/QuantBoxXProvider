using System;

namespace QuantBox.Sfit.Api
{
    public class CtpTraderApi : CtpTraderSpi, ICtpRequestHandler
    {
        private CtpRequestFunc[] _handerList;
        private IntPtr _instance = IntPtr.Zero;

        private void InitApi(string flowPath)
        {
            _instance = CtpTraderNative.Create(flowPath);
        }

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
            _handerList[CtpRequestType.ReqAuthenticate] = DoReqAuthenticate;
            _handerList[CtpRequestType.ReqUserLogin] = DoReqUserLogin;
            _handerList[CtpRequestType.ReqUserLogout] = DoReqUserLogout;
            _handerList[CtpRequestType.ReqUserPasswordUpdate] = DoReqUserPasswordUpdate;
            _handerList[CtpRequestType.ReqTradingAccountPasswordUpdate] = DoReqTradingAccountPasswordUpdate;
            _handerList[CtpRequestType.ReqOrderInsert] = DoReqOrderInsert;
            _handerList[CtpRequestType.ReqParkedOrderInsert] = DoReqParkedOrderInsert;
            _handerList[CtpRequestType.ReqParkedOrderAction] = DoReqParkedOrderAction;
            _handerList[CtpRequestType.ReqOrderAction] = DoReqOrderAction;
            _handerList[CtpRequestType.ReqQueryMaxOrderVolume] = DoReqQueryMaxOrderVolume;
            _handerList[CtpRequestType.ReqSettlementInfoConfirm] = DoReqSettlementInfoConfirm;
            _handerList[CtpRequestType.ReqRemoveParkedOrder] = DoReqRemoveParkedOrder;
            _handerList[CtpRequestType.ReqRemoveParkedOrderAction] = DoReqRemoveParkedOrderAction;
            _handerList[CtpRequestType.ReqExecOrderInsert] = DoReqExecOrderInsert;
            _handerList[CtpRequestType.ReqExecOrderAction] = DoReqExecOrderAction;
            _handerList[CtpRequestType.ReqForQuoteInsert] = DoReqForQuoteInsert;
            _handerList[CtpRequestType.ReqQuoteInsert] = DoReqQuoteInsert;
            _handerList[CtpRequestType.ReqQuoteAction] = DoReqQuoteAction;
            _handerList[CtpRequestType.ReqBatchOrderAction] = DoReqBatchOrderAction;
            _handerList[CtpRequestType.ReqCombActionInsert] = DoReqCombActionInsert;
            _handerList[CtpRequestType.ReqQryOrder] = DoReqQryOrder;
            _handerList[CtpRequestType.ReqQryTrade] = DoReqQryTrade;
            _handerList[CtpRequestType.ReqQryInvestorPosition] = DoReqQryInvestorPosition;
            _handerList[CtpRequestType.ReqQryTradingAccount] = DoReqQryTradingAccount;
            _handerList[CtpRequestType.ReqQryInvestor] = DoReqQryInvestor;
            _handerList[CtpRequestType.ReqQryTradingCode] = DoReqQryTradingCode;
            _handerList[CtpRequestType.ReqQryInstrumentMarginRate] = DoReqQryInstrumentMarginRate;
            _handerList[CtpRequestType.ReqQryInstrumentCommissionRate] = DoReqQryInstrumentCommissionRate;
            _handerList[CtpRequestType.ReqQryExchange] = DoReqQryExchange;
            _handerList[CtpRequestType.ReqQryProduct] = DoReqQryProduct;
            _handerList[CtpRequestType.ReqQryInstrument] = DoReqQryInstrument;
            _handerList[CtpRequestType.ReqQryDepthMarketData] = DoReqQryDepthMarketData;
            _handerList[CtpRequestType.ReqQrySettlementInfo] = DoReqQrySettlementInfo;
            _handerList[CtpRequestType.ReqQryTransferBank] = DoReqQryTransferBank;
            _handerList[CtpRequestType.ReqQryInvestorPositionDetail] = DoReqQryInvestorPositionDetail;
            _handerList[CtpRequestType.ReqQryNotice] = DoReqQryNotice;
            _handerList[CtpRequestType.ReqQrySettlementInfoConfirm] = DoReqQrySettlementInfoConfirm;
            _handerList[CtpRequestType.ReqQryInvestorPositionCombineDetail] = DoReqQryInvestorPositionCombineDetail;
            _handerList[CtpRequestType.ReqQryCFMMCTradingAccountKey] = DoReqQryCFMMCTradingAccountKey;
            _handerList[CtpRequestType.ReqQryEWarrantOffset] = DoReqQryEWarrantOffset;
            _handerList[CtpRequestType.ReqQryInvestorProductGroupMargin] = DoReqQryInvestorProductGroupMargin;
            _handerList[CtpRequestType.ReqQryExchangeMarginRate] = DoReqQryExchangeMarginRate;
            _handerList[CtpRequestType.ReqQryExchangeMarginRateAdjust] = DoReqQryExchangeMarginRateAdjust;
            _handerList[CtpRequestType.ReqQryExchangeRate] = DoReqQryExchangeRate;
            _handerList[CtpRequestType.ReqQrySecAgentACIDMap] = DoReqQrySecAgentACIDMap;
            _handerList[CtpRequestType.ReqQryProductExchRate] = DoReqQryProductExchRate;
            _handerList[CtpRequestType.ReqQryProductGroup] = DoReqQryProductGroup;
            _handerList[CtpRequestType.ReqQryOptionInstrTradeCost] = DoReqQryOptionInstrTradeCost;
            _handerList[CtpRequestType.ReqQryOptionInstrCommRate] = DoReqQryOptionInstrCommRate;
            _handerList[CtpRequestType.ReqQryExecOrder] = DoReqQryExecOrder;
            _handerList[CtpRequestType.ReqQryForQuote] = DoReqQryForQuote;
            _handerList[CtpRequestType.ReqQryQuote] = DoReqQryQuote;
            _handerList[CtpRequestType.ReqQryCombInstrumentGuard] = DoReqQryCombInstrumentGuard;
            _handerList[CtpRequestType.ReqQryCombAction] = DoReqQryCombAction;
            _handerList[CtpRequestType.ReqQryTransferSerial] = DoReqQryTransferSerial;
            _handerList[CtpRequestType.ReqQryAccountregister] = DoReqQryAccountregister;
            _handerList[CtpRequestType.ReqQryContractBank] = DoReqQryContractBank;
            _handerList[CtpRequestType.ReqQryParkedOrder] = DoReqQryParkedOrder;
            _handerList[CtpRequestType.ReqQryParkedOrderAction] = DoReqQryParkedOrderAction;
            _handerList[CtpRequestType.ReqQryTradingNotice] = DoReqQryTradingNotice;
            _handerList[CtpRequestType.ReqQryBrokerTradingParams] = DoReqQryBrokerTradingParams;
            _handerList[CtpRequestType.ReqQryBrokerTradingAlgos] = DoReqQryBrokerTradingAlgos;
            _handerList[CtpRequestType.ReqQueryCFMMCTradingAccountToken] = DoReqQueryCFMMCTradingAccountToken;
            _handerList[CtpRequestType.ReqFromBankToFutureByFuture] = DoReqFromBankToFutureByFuture;
            _handerList[CtpRequestType.ReqFromFutureToBankByFuture] = DoReqFromFutureToBankByFuture;
            _handerList[CtpRequestType.ReqQueryBankAccountMoneyByFuture] = DoReqQueryBankAccountMoneyByFuture;
        }

        #region Native Response Handler
        private CtpTraderNative.OnFrontConnected _cbOnFrontConnected;
        private CtpTraderNative.OnFrontDisconnected _cbOnFrontDisconnected;
        private CtpTraderNative.OnHeartBeatWarning _cbOnHeartBeatWarning;
        private CtpTraderNative.OnRspAuthenticate _cbOnRspAuthenticate;
        private CtpTraderNative.OnRspUserLogin _cbOnRspUserLogin;
        private CtpTraderNative.OnRspUserLogout _cbOnRspUserLogout;
        private CtpTraderNative.OnRspUserPasswordUpdate _cbOnRspUserPasswordUpdate;
        private CtpTraderNative.OnRspTradingAccountPasswordUpdate _cbOnRspTradingAccountPasswordUpdate;
        private CtpTraderNative.OnRspOrderInsert _cbOnRspOrderInsert;
        private CtpTraderNative.OnRspParkedOrderInsert _cbOnRspParkedOrderInsert;
        private CtpTraderNative.OnRspParkedOrderAction _cbOnRspParkedOrderAction;
        private CtpTraderNative.OnRspOrderAction _cbOnRspOrderAction;
        private CtpTraderNative.OnRspQueryMaxOrderVolume _cbOnRspQueryMaxOrderVolume;
        private CtpTraderNative.OnRspSettlementInfoConfirm _cbOnRspSettlementInfoConfirm;
        private CtpTraderNative.OnRspRemoveParkedOrder _cbOnRspRemoveParkedOrder;
        private CtpTraderNative.OnRspRemoveParkedOrderAction _cbOnRspRemoveParkedOrderAction;
        private CtpTraderNative.OnRspExecOrderInsert _cbOnRspExecOrderInsert;
        private CtpTraderNative.OnRspExecOrderAction _cbOnRspExecOrderAction;
        private CtpTraderNative.OnRspForQuoteInsert _cbOnRspForQuoteInsert;
        private CtpTraderNative.OnRspQuoteInsert _cbOnRspQuoteInsert;
        private CtpTraderNative.OnRspQuoteAction _cbOnRspQuoteAction;
        private CtpTraderNative.OnRspBatchOrderAction _cbOnRspBatchOrderAction;
        private CtpTraderNative.OnRspCombActionInsert _cbOnRspCombActionInsert;
        private CtpTraderNative.OnRspQryOrder _cbOnRspQryOrder;
        private CtpTraderNative.OnRspQryTrade _cbOnRspQryTrade;
        private CtpTraderNative.OnRspQryInvestorPosition _cbOnRspQryInvestorPosition;
        private CtpTraderNative.OnRspQryTradingAccount _cbOnRspQryTradingAccount;
        private CtpTraderNative.OnRspQryInvestor _cbOnRspQryInvestor;
        private CtpTraderNative.OnRspQryTradingCode _cbOnRspQryTradingCode;
        private CtpTraderNative.OnRspQryInstrumentMarginRate _cbOnRspQryInstrumentMarginRate;
        private CtpTraderNative.OnRspQryInstrumentCommissionRate _cbOnRspQryInstrumentCommissionRate;
        private CtpTraderNative.OnRspQryExchange _cbOnRspQryExchange;
        private CtpTraderNative.OnRspQryProduct _cbOnRspQryProduct;
        private CtpTraderNative.OnRspQryInstrument _cbOnRspQryInstrument;
        private CtpTraderNative.OnRspQryDepthMarketData _cbOnRspQryDepthMarketData;
        private CtpTraderNative.OnRspQrySettlementInfo _cbOnRspQrySettlementInfo;
        private CtpTraderNative.OnRspQryTransferBank _cbOnRspQryTransferBank;
        private CtpTraderNative.OnRspQryInvestorPositionDetail _cbOnRspQryInvestorPositionDetail;
        private CtpTraderNative.OnRspQryNotice _cbOnRspQryNotice;
        private CtpTraderNative.OnRspQrySettlementInfoConfirm _cbOnRspQrySettlementInfoConfirm;
        private CtpTraderNative.OnRspQryInvestorPositionCombineDetail _cbOnRspQryInvestorPositionCombineDetail;
        private CtpTraderNative.OnRspQryCFMMCTradingAccountKey _cbOnRspQryCFMMCTradingAccountKey;
        private CtpTraderNative.OnRspQryEWarrantOffset _cbOnRspQryEWarrantOffset;
        private CtpTraderNative.OnRspQryInvestorProductGroupMargin _cbOnRspQryInvestorProductGroupMargin;
        private CtpTraderNative.OnRspQryExchangeMarginRate _cbOnRspQryExchangeMarginRate;
        private CtpTraderNative.OnRspQryExchangeMarginRateAdjust _cbOnRspQryExchangeMarginRateAdjust;
        private CtpTraderNative.OnRspQryExchangeRate _cbOnRspQryExchangeRate;
        private CtpTraderNative.OnRspQrySecAgentACIDMap _cbOnRspQrySecAgentACIDMap;
        private CtpTraderNative.OnRspQryProductExchRate _cbOnRspQryProductExchRate;
        private CtpTraderNative.OnRspQryProductGroup _cbOnRspQryProductGroup;
        private CtpTraderNative.OnRspQryOptionInstrTradeCost _cbOnRspQryOptionInstrTradeCost;
        private CtpTraderNative.OnRspQryOptionInstrCommRate _cbOnRspQryOptionInstrCommRate;
        private CtpTraderNative.OnRspQryExecOrder _cbOnRspQryExecOrder;
        private CtpTraderNative.OnRspQryForQuote _cbOnRspQryForQuote;
        private CtpTraderNative.OnRspQryQuote _cbOnRspQryQuote;
        private CtpTraderNative.OnRspQryCombInstrumentGuard _cbOnRspQryCombInstrumentGuard;
        private CtpTraderNative.OnRspQryCombAction _cbOnRspQryCombAction;
        private CtpTraderNative.OnRspQryTransferSerial _cbOnRspQryTransferSerial;
        private CtpTraderNative.OnRspQryAccountregister _cbOnRspQryAccountregister;
        private CtpTraderNative.OnRspError _cbOnRspError;
        private CtpTraderNative.OnRtnOrder _cbOnRtnOrder;
        private CtpTraderNative.OnRtnTrade _cbOnRtnTrade;
        private CtpTraderNative.OnErrRtnOrderInsert _cbOnErrRtnOrderInsert;
        private CtpTraderNative.OnErrRtnOrderAction _cbOnErrRtnOrderAction;
        private CtpTraderNative.OnRtnInstrumentStatus _cbOnRtnInstrumentStatus;
        private CtpTraderNative.OnRtnTradingNotice _cbOnRtnTradingNotice;
        private CtpTraderNative.OnRtnErrorConditionalOrder _cbOnRtnErrorConditionalOrder;
        private CtpTraderNative.OnRtnExecOrder _cbOnRtnExecOrder;
        private CtpTraderNative.OnErrRtnExecOrderInsert _cbOnErrRtnExecOrderInsert;
        private CtpTraderNative.OnErrRtnExecOrderAction _cbOnErrRtnExecOrderAction;
        private CtpTraderNative.OnErrRtnForQuoteInsert _cbOnErrRtnForQuoteInsert;
        private CtpTraderNative.OnRtnQuote _cbOnRtnQuote;
        private CtpTraderNative.OnErrRtnQuoteInsert _cbOnErrRtnQuoteInsert;
        private CtpTraderNative.OnErrRtnQuoteAction _cbOnErrRtnQuoteAction;
        private CtpTraderNative.OnRtnForQuoteRsp _cbOnRtnForQuoteRsp;
        private CtpTraderNative.OnRtnCFMMCTradingAccountToken _cbOnRtnCFMMCTradingAccountToken;
        private CtpTraderNative.OnErrRtnBatchOrderAction _cbOnErrRtnBatchOrderAction;
        private CtpTraderNative.OnRtnCombAction _cbOnRtnCombAction;
        private CtpTraderNative.OnErrRtnCombActionInsert _cbOnErrRtnCombActionInsert;
        private CtpTraderNative.OnRspQryContractBank _cbOnRspQryContractBank;
        private CtpTraderNative.OnRspQryParkedOrder _cbOnRspQryParkedOrder;
        private CtpTraderNative.OnRspQryParkedOrderAction _cbOnRspQryParkedOrderAction;
        private CtpTraderNative.OnRspQryTradingNotice _cbOnRspQryTradingNotice;
        private CtpTraderNative.OnRspQryBrokerTradingParams _cbOnRspQryBrokerTradingParams;
        private CtpTraderNative.OnRspQryBrokerTradingAlgos _cbOnRspQryBrokerTradingAlgos;
        private CtpTraderNative.OnRspQueryCFMMCTradingAccountToken _cbOnRspQueryCFMMCTradingAccountToken;
        private CtpTraderNative.OnRtnFromBankToFutureByBank _cbOnRtnFromBankToFutureByBank;
        private CtpTraderNative.OnRtnFromFutureToBankByBank _cbOnRtnFromFutureToBankByBank;
        private CtpTraderNative.OnRtnRepealFromBankToFutureByBank _cbOnRtnRepealFromBankToFutureByBank;
        private CtpTraderNative.OnRtnRepealFromFutureToBankByBank _cbOnRtnRepealFromFutureToBankByBank;
        private CtpTraderNative.OnRtnFromBankToFutureByFuture _cbOnRtnFromBankToFutureByFuture;
        private CtpTraderNative.OnRtnFromFutureToBankByFuture _cbOnRtnFromFutureToBankByFuture;
        private CtpTraderNative.OnRtnRepealFromBankToFutureByFutureManual _cbOnRtnRepealFromBankToFutureByFutureManual;
        private CtpTraderNative.OnRtnRepealFromFutureToBankByFutureManual _cbOnRtnRepealFromFutureToBankByFutureManual;
        private CtpTraderNative.OnRtnQueryBankBalanceByFuture _cbOnRtnQueryBankBalanceByFuture;
        private CtpTraderNative.OnErrRtnBankToFutureByFuture _cbOnErrRtnBankToFutureByFuture;
        private CtpTraderNative.OnErrRtnFutureToBankByFuture _cbOnErrRtnFutureToBankByFuture;
        private CtpTraderNative.OnErrRtnRepealBankToFutureByFutureManual _cbOnErrRtnRepealBankToFutureByFutureManual;
        private CtpTraderNative.OnErrRtnRepealFutureToBankByFutureManual _cbOnErrRtnRepealFutureToBankByFutureManual;
        private CtpTraderNative.OnErrRtnQueryBankBalanceByFuture _cbOnErrRtnQueryBankBalanceByFuture;
        private CtpTraderNative.OnRtnRepealFromBankToFutureByFuture _cbOnRtnRepealFromBankToFutureByFuture;
        private CtpTraderNative.OnRtnRepealFromFutureToBankByFuture _cbOnRtnRepealFromFutureToBankByFuture;
        private CtpTraderNative.OnRspFromBankToFutureByFuture _cbOnRspFromBankToFutureByFuture;
        private CtpTraderNative.OnRspFromFutureToBankByFuture _cbOnRspFromFutureToBankByFuture;
        private CtpTraderNative.OnRspQueryBankAccountMoneyByFuture _cbOnRspQueryBankAccountMoneyByFuture;
        private CtpTraderNative.OnRtnOpenAccountByBank _cbOnRtnOpenAccountByBank;
        private CtpTraderNative.OnRtnCancelAccountByBank _cbOnRtnCancelAccountByBank;
        private CtpTraderNative.OnRtnChangeAccountByBank _cbOnRtnChangeAccountByBank;

        private void InitNativeCallback()
        {
            _cbOnFrontConnected = NativeOnFrontConnected;
            CtpTraderNative.SetOnFrontConnected(_instance, _cbOnFrontConnected);
            _cbOnFrontDisconnected = NativeOnFrontDisconnected;
            CtpTraderNative.SetOnFrontDisconnected(_instance, _cbOnFrontDisconnected);
            _cbOnHeartBeatWarning = NativeOnHeartBeatWarning;
            CtpTraderNative.SetOnHeartBeatWarning(_instance, _cbOnHeartBeatWarning);
            _cbOnRspAuthenticate = NativeOnRspAuthenticate;
            CtpTraderNative.SetOnRspAuthenticate(_instance, _cbOnRspAuthenticate);
            _cbOnRspUserLogin = NativeOnRspUserLogin;
            CtpTraderNative.SetOnRspUserLogin(_instance, _cbOnRspUserLogin);
            _cbOnRspUserLogout = NativeOnRspUserLogout;
            CtpTraderNative.SetOnRspUserLogout(_instance, _cbOnRspUserLogout);
            _cbOnRspUserPasswordUpdate = NativeOnRspUserPasswordUpdate;
            CtpTraderNative.SetOnRspUserPasswordUpdate(_instance, _cbOnRspUserPasswordUpdate);
            _cbOnRspTradingAccountPasswordUpdate = NativeOnRspTradingAccountPasswordUpdate;
            CtpTraderNative.SetOnRspTradingAccountPasswordUpdate(_instance, _cbOnRspTradingAccountPasswordUpdate);
            _cbOnRspOrderInsert = NativeOnRspOrderInsert;
            CtpTraderNative.SetOnRspOrderInsert(_instance, _cbOnRspOrderInsert);
            _cbOnRspParkedOrderInsert = NativeOnRspParkedOrderInsert;
            CtpTraderNative.SetOnRspParkedOrderInsert(_instance, _cbOnRspParkedOrderInsert);
            _cbOnRspParkedOrderAction = NativeOnRspParkedOrderAction;
            CtpTraderNative.SetOnRspParkedOrderAction(_instance, _cbOnRspParkedOrderAction);
            _cbOnRspOrderAction = NativeOnRspOrderAction;
            CtpTraderNative.SetOnRspOrderAction(_instance, _cbOnRspOrderAction);
            _cbOnRspQueryMaxOrderVolume = NativeOnRspQueryMaxOrderVolume;
            CtpTraderNative.SetOnRspQueryMaxOrderVolume(_instance, _cbOnRspQueryMaxOrderVolume);
            _cbOnRspSettlementInfoConfirm = NativeOnRspSettlementInfoConfirm;
            CtpTraderNative.SetOnRspSettlementInfoConfirm(_instance, _cbOnRspSettlementInfoConfirm);
            _cbOnRspRemoveParkedOrder = NativeOnRspRemoveParkedOrder;
            CtpTraderNative.SetOnRspRemoveParkedOrder(_instance, _cbOnRspRemoveParkedOrder);
            _cbOnRspRemoveParkedOrderAction = NativeOnRspRemoveParkedOrderAction;
            CtpTraderNative.SetOnRspRemoveParkedOrderAction(_instance, _cbOnRspRemoveParkedOrderAction);
            _cbOnRspExecOrderInsert = NativeOnRspExecOrderInsert;
            CtpTraderNative.SetOnRspExecOrderInsert(_instance, _cbOnRspExecOrderInsert);
            _cbOnRspExecOrderAction = NativeOnRspExecOrderAction;
            CtpTraderNative.SetOnRspExecOrderAction(_instance, _cbOnRspExecOrderAction);
            _cbOnRspForQuoteInsert = NativeOnRspForQuoteInsert;
            CtpTraderNative.SetOnRspForQuoteInsert(_instance, _cbOnRspForQuoteInsert);
            _cbOnRspQuoteInsert = NativeOnRspQuoteInsert;
            CtpTraderNative.SetOnRspQuoteInsert(_instance, _cbOnRspQuoteInsert);
            _cbOnRspQuoteAction = NativeOnRspQuoteAction;
            CtpTraderNative.SetOnRspQuoteAction(_instance, _cbOnRspQuoteAction);
            _cbOnRspBatchOrderAction = NativeOnRspBatchOrderAction;
            CtpTraderNative.SetOnRspBatchOrderAction(_instance, _cbOnRspBatchOrderAction);
            _cbOnRspCombActionInsert = NativeOnRspCombActionInsert;
            CtpTraderNative.SetOnRspCombActionInsert(_instance, _cbOnRspCombActionInsert);
            _cbOnRspQryOrder = NativeOnRspQryOrder;
            CtpTraderNative.SetOnRspQryOrder(_instance, _cbOnRspQryOrder);
            _cbOnRspQryTrade = NativeOnRspQryTrade;
            CtpTraderNative.SetOnRspQryTrade(_instance, _cbOnRspQryTrade);
            _cbOnRspQryInvestorPosition = NativeOnRspQryInvestorPosition;
            CtpTraderNative.SetOnRspQryInvestorPosition(_instance, _cbOnRspQryInvestorPosition);
            _cbOnRspQryTradingAccount = NativeOnRspQryTradingAccount;
            CtpTraderNative.SetOnRspQryTradingAccount(_instance, _cbOnRspQryTradingAccount);
            _cbOnRspQryInvestor = NativeOnRspQryInvestor;
            CtpTraderNative.SetOnRspQryInvestor(_instance, _cbOnRspQryInvestor);
            _cbOnRspQryTradingCode = NativeOnRspQryTradingCode;
            CtpTraderNative.SetOnRspQryTradingCode(_instance, _cbOnRspQryTradingCode);
            _cbOnRspQryInstrumentMarginRate = NativeOnRspQryInstrumentMarginRate;
            CtpTraderNative.SetOnRspQryInstrumentMarginRate(_instance, _cbOnRspQryInstrumentMarginRate);
            _cbOnRspQryInstrumentCommissionRate = NativeOnRspQryInstrumentCommissionRate;
            CtpTraderNative.SetOnRspQryInstrumentCommissionRate(_instance, _cbOnRspQryInstrumentCommissionRate);
            _cbOnRspQryExchange = NativeOnRspQryExchange;
            CtpTraderNative.SetOnRspQryExchange(_instance, _cbOnRspQryExchange);
            _cbOnRspQryProduct = NativeOnRspQryProduct;
            CtpTraderNative.SetOnRspQryProduct(_instance, _cbOnRspQryProduct);
            _cbOnRspQryInstrument = NativeOnRspQryInstrument;
            CtpTraderNative.SetOnRspQryInstrument(_instance, _cbOnRspQryInstrument);
            _cbOnRspQryDepthMarketData = NativeOnRspQryDepthMarketData;
            CtpTraderNative.SetOnRspQryDepthMarketData(_instance, _cbOnRspQryDepthMarketData);
            _cbOnRspQrySettlementInfo = NativeOnRspQrySettlementInfo;
            CtpTraderNative.SetOnRspQrySettlementInfo(_instance, _cbOnRspQrySettlementInfo);
            _cbOnRspQryTransferBank = NativeOnRspQryTransferBank;
            CtpTraderNative.SetOnRspQryTransferBank(_instance, _cbOnRspQryTransferBank);
            _cbOnRspQryInvestorPositionDetail = NativeOnRspQryInvestorPositionDetail;
            CtpTraderNative.SetOnRspQryInvestorPositionDetail(_instance, _cbOnRspQryInvestorPositionDetail);
            _cbOnRspQryNotice = NativeOnRspQryNotice;
            CtpTraderNative.SetOnRspQryNotice(_instance, _cbOnRspQryNotice);
            _cbOnRspQrySettlementInfoConfirm = NativeOnRspQrySettlementInfoConfirm;
            CtpTraderNative.SetOnRspQrySettlementInfoConfirm(_instance, _cbOnRspQrySettlementInfoConfirm);
            _cbOnRspQryInvestorPositionCombineDetail = NativeOnRspQryInvestorPositionCombineDetail;
            CtpTraderNative.SetOnRspQryInvestorPositionCombineDetail(_instance, _cbOnRspQryInvestorPositionCombineDetail);
            _cbOnRspQryCFMMCTradingAccountKey = NativeOnRspQryCFMMCTradingAccountKey;
            CtpTraderNative.SetOnRspQryCFMMCTradingAccountKey(_instance, _cbOnRspQryCFMMCTradingAccountKey);
            _cbOnRspQryEWarrantOffset = NativeOnRspQryEWarrantOffset;
            CtpTraderNative.SetOnRspQryEWarrantOffset(_instance, _cbOnRspQryEWarrantOffset);
            _cbOnRspQryInvestorProductGroupMargin = NativeOnRspQryInvestorProductGroupMargin;
            CtpTraderNative.SetOnRspQryInvestorProductGroupMargin(_instance, _cbOnRspQryInvestorProductGroupMargin);
            _cbOnRspQryExchangeMarginRate = NativeOnRspQryExchangeMarginRate;
            CtpTraderNative.SetOnRspQryExchangeMarginRate(_instance, _cbOnRspQryExchangeMarginRate);
            _cbOnRspQryExchangeMarginRateAdjust = NativeOnRspQryExchangeMarginRateAdjust;
            CtpTraderNative.SetOnRspQryExchangeMarginRateAdjust(_instance, _cbOnRspQryExchangeMarginRateAdjust);
            _cbOnRspQryExchangeRate = NativeOnRspQryExchangeRate;
            CtpTraderNative.SetOnRspQryExchangeRate(_instance, _cbOnRspQryExchangeRate);
            _cbOnRspQrySecAgentACIDMap = NativeOnRspQrySecAgentACIDMap;
            CtpTraderNative.SetOnRspQrySecAgentACIDMap(_instance, _cbOnRspQrySecAgentACIDMap);
            _cbOnRspQryProductExchRate = NativeOnRspQryProductExchRate;
            CtpTraderNative.SetOnRspQryProductExchRate(_instance, _cbOnRspQryProductExchRate);
            _cbOnRspQryProductGroup = NativeOnRspQryProductGroup;
            CtpTraderNative.SetOnRspQryProductGroup(_instance, _cbOnRspQryProductGroup);
            _cbOnRspQryOptionInstrTradeCost = NativeOnRspQryOptionInstrTradeCost;
            CtpTraderNative.SetOnRspQryOptionInstrTradeCost(_instance, _cbOnRspQryOptionInstrTradeCost);
            _cbOnRspQryOptionInstrCommRate = NativeOnRspQryOptionInstrCommRate;
            CtpTraderNative.SetOnRspQryOptionInstrCommRate(_instance, _cbOnRspQryOptionInstrCommRate);
            _cbOnRspQryExecOrder = NativeOnRspQryExecOrder;
            CtpTraderNative.SetOnRspQryExecOrder(_instance, _cbOnRspQryExecOrder);
            _cbOnRspQryForQuote = NativeOnRspQryForQuote;
            CtpTraderNative.SetOnRspQryForQuote(_instance, _cbOnRspQryForQuote);
            _cbOnRspQryQuote = NativeOnRspQryQuote;
            CtpTraderNative.SetOnRspQryQuote(_instance, _cbOnRspQryQuote);
            _cbOnRspQryCombInstrumentGuard = NativeOnRspQryCombInstrumentGuard;
            CtpTraderNative.SetOnRspQryCombInstrumentGuard(_instance, _cbOnRspQryCombInstrumentGuard);
            _cbOnRspQryCombAction = NativeOnRspQryCombAction;
            CtpTraderNative.SetOnRspQryCombAction(_instance, _cbOnRspQryCombAction);
            _cbOnRspQryTransferSerial = NativeOnRspQryTransferSerial;
            CtpTraderNative.SetOnRspQryTransferSerial(_instance, _cbOnRspQryTransferSerial);
            _cbOnRspQryAccountregister = NativeOnRspQryAccountregister;
            CtpTraderNative.SetOnRspQryAccountregister(_instance, _cbOnRspQryAccountregister);
            _cbOnRspError = NativeOnRspError;
            CtpTraderNative.SetOnRspError(_instance, _cbOnRspError);
            _cbOnRtnOrder = NativeOnRtnOrder;
            CtpTraderNative.SetOnRtnOrder(_instance, _cbOnRtnOrder);
            _cbOnRtnTrade = NativeOnRtnTrade;
            CtpTraderNative.SetOnRtnTrade(_instance, _cbOnRtnTrade);
            _cbOnErrRtnOrderInsert = NativeOnErrRtnOrderInsert;
            CtpTraderNative.SetOnErrRtnOrderInsert(_instance, _cbOnErrRtnOrderInsert);
            _cbOnErrRtnOrderAction = NativeOnErrRtnOrderAction;
            CtpTraderNative.SetOnErrRtnOrderAction(_instance, _cbOnErrRtnOrderAction);
            _cbOnRtnInstrumentStatus = NativeOnRtnInstrumentStatus;
            CtpTraderNative.SetOnRtnInstrumentStatus(_instance, _cbOnRtnInstrumentStatus);
            _cbOnRtnTradingNotice = NativeOnRtnTradingNotice;
            CtpTraderNative.SetOnRtnTradingNotice(_instance, _cbOnRtnTradingNotice);
            _cbOnRtnErrorConditionalOrder = NativeOnRtnErrorConditionalOrder;
            CtpTraderNative.SetOnRtnErrorConditionalOrder(_instance, _cbOnRtnErrorConditionalOrder);
            _cbOnRtnExecOrder = NativeOnRtnExecOrder;
            CtpTraderNative.SetOnRtnExecOrder(_instance, _cbOnRtnExecOrder);
            _cbOnErrRtnExecOrderInsert = NativeOnErrRtnExecOrderInsert;
            CtpTraderNative.SetOnErrRtnExecOrderInsert(_instance, _cbOnErrRtnExecOrderInsert);
            _cbOnErrRtnExecOrderAction = NativeOnErrRtnExecOrderAction;
            CtpTraderNative.SetOnErrRtnExecOrderAction(_instance, _cbOnErrRtnExecOrderAction);
            _cbOnErrRtnForQuoteInsert = NativeOnErrRtnForQuoteInsert;
            CtpTraderNative.SetOnErrRtnForQuoteInsert(_instance, _cbOnErrRtnForQuoteInsert);
            _cbOnRtnQuote = NativeOnRtnQuote;
            CtpTraderNative.SetOnRtnQuote(_instance, _cbOnRtnQuote);
            _cbOnErrRtnQuoteInsert = NativeOnErrRtnQuoteInsert;
            CtpTraderNative.SetOnErrRtnQuoteInsert(_instance, _cbOnErrRtnQuoteInsert);
            _cbOnErrRtnQuoteAction = NativeOnErrRtnQuoteAction;
            CtpTraderNative.SetOnErrRtnQuoteAction(_instance, _cbOnErrRtnQuoteAction);
            _cbOnRtnForQuoteRsp = NativeOnRtnForQuoteRsp;
            CtpTraderNative.SetOnRtnForQuoteRsp(_instance, _cbOnRtnForQuoteRsp);
            _cbOnRtnCFMMCTradingAccountToken = NativeOnRtnCFMMCTradingAccountToken;
            CtpTraderNative.SetOnRtnCFMMCTradingAccountToken(_instance, _cbOnRtnCFMMCTradingAccountToken);
            _cbOnErrRtnBatchOrderAction = NativeOnErrRtnBatchOrderAction;
            CtpTraderNative.SetOnErrRtnBatchOrderAction(_instance, _cbOnErrRtnBatchOrderAction);
            _cbOnRtnCombAction = NativeOnRtnCombAction;
            CtpTraderNative.SetOnRtnCombAction(_instance, _cbOnRtnCombAction);
            _cbOnErrRtnCombActionInsert = NativeOnErrRtnCombActionInsert;
            CtpTraderNative.SetOnErrRtnCombActionInsert(_instance, _cbOnErrRtnCombActionInsert);
            _cbOnRspQryContractBank = NativeOnRspQryContractBank;
            CtpTraderNative.SetOnRspQryContractBank(_instance, _cbOnRspQryContractBank);
            _cbOnRspQryParkedOrder = NativeOnRspQryParkedOrder;
            CtpTraderNative.SetOnRspQryParkedOrder(_instance, _cbOnRspQryParkedOrder);
            _cbOnRspQryParkedOrderAction = NativeOnRspQryParkedOrderAction;
            CtpTraderNative.SetOnRspQryParkedOrderAction(_instance, _cbOnRspQryParkedOrderAction);
            _cbOnRspQryTradingNotice = NativeOnRspQryTradingNotice;
            CtpTraderNative.SetOnRspQryTradingNotice(_instance, _cbOnRspQryTradingNotice);
            _cbOnRspQryBrokerTradingParams = NativeOnRspQryBrokerTradingParams;
            CtpTraderNative.SetOnRspQryBrokerTradingParams(_instance, _cbOnRspQryBrokerTradingParams);
            _cbOnRspQryBrokerTradingAlgos = NativeOnRspQryBrokerTradingAlgos;
            CtpTraderNative.SetOnRspQryBrokerTradingAlgos(_instance, _cbOnRspQryBrokerTradingAlgos);
            _cbOnRspQueryCFMMCTradingAccountToken = NativeOnRspQueryCFMMCTradingAccountToken;
            CtpTraderNative.SetOnRspQueryCFMMCTradingAccountToken(_instance, _cbOnRspQueryCFMMCTradingAccountToken);
            _cbOnRtnFromBankToFutureByBank = NativeOnRtnFromBankToFutureByBank;
            CtpTraderNative.SetOnRtnFromBankToFutureByBank(_instance, _cbOnRtnFromBankToFutureByBank);
            _cbOnRtnFromFutureToBankByBank = NativeOnRtnFromFutureToBankByBank;
            CtpTraderNative.SetOnRtnFromFutureToBankByBank(_instance, _cbOnRtnFromFutureToBankByBank);
            _cbOnRtnRepealFromBankToFutureByBank = NativeOnRtnRepealFromBankToFutureByBank;
            CtpTraderNative.SetOnRtnRepealFromBankToFutureByBank(_instance, _cbOnRtnRepealFromBankToFutureByBank);
            _cbOnRtnRepealFromFutureToBankByBank = NativeOnRtnRepealFromFutureToBankByBank;
            CtpTraderNative.SetOnRtnRepealFromFutureToBankByBank(_instance, _cbOnRtnRepealFromFutureToBankByBank);
            _cbOnRtnFromBankToFutureByFuture = NativeOnRtnFromBankToFutureByFuture;
            CtpTraderNative.SetOnRtnFromBankToFutureByFuture(_instance, _cbOnRtnFromBankToFutureByFuture);
            _cbOnRtnFromFutureToBankByFuture = NativeOnRtnFromFutureToBankByFuture;
            CtpTraderNative.SetOnRtnFromFutureToBankByFuture(_instance, _cbOnRtnFromFutureToBankByFuture);
            _cbOnRtnRepealFromBankToFutureByFutureManual = NativeOnRtnRepealFromBankToFutureByFutureManual;
            CtpTraderNative.SetOnRtnRepealFromBankToFutureByFutureManual(_instance, _cbOnRtnRepealFromBankToFutureByFutureManual);
            _cbOnRtnRepealFromFutureToBankByFutureManual = NativeOnRtnRepealFromFutureToBankByFutureManual;
            CtpTraderNative.SetOnRtnRepealFromFutureToBankByFutureManual(_instance, _cbOnRtnRepealFromFutureToBankByFutureManual);
            _cbOnRtnQueryBankBalanceByFuture = NativeOnRtnQueryBankBalanceByFuture;
            CtpTraderNative.SetOnRtnQueryBankBalanceByFuture(_instance, _cbOnRtnQueryBankBalanceByFuture);
            _cbOnErrRtnBankToFutureByFuture = NativeOnErrRtnBankToFutureByFuture;
            CtpTraderNative.SetOnErrRtnBankToFutureByFuture(_instance, _cbOnErrRtnBankToFutureByFuture);
            _cbOnErrRtnFutureToBankByFuture = NativeOnErrRtnFutureToBankByFuture;
            CtpTraderNative.SetOnErrRtnFutureToBankByFuture(_instance, _cbOnErrRtnFutureToBankByFuture);
            _cbOnErrRtnRepealBankToFutureByFutureManual = NativeOnErrRtnRepealBankToFutureByFutureManual;
            CtpTraderNative.SetOnErrRtnRepealBankToFutureByFutureManual(_instance, _cbOnErrRtnRepealBankToFutureByFutureManual);
            _cbOnErrRtnRepealFutureToBankByFutureManual = NativeOnErrRtnRepealFutureToBankByFutureManual;
            CtpTraderNative.SetOnErrRtnRepealFutureToBankByFutureManual(_instance, _cbOnErrRtnRepealFutureToBankByFutureManual);
            _cbOnErrRtnQueryBankBalanceByFuture = NativeOnErrRtnQueryBankBalanceByFuture;
            CtpTraderNative.SetOnErrRtnQueryBankBalanceByFuture(_instance, _cbOnErrRtnQueryBankBalanceByFuture);
            _cbOnRtnRepealFromBankToFutureByFuture = NativeOnRtnRepealFromBankToFutureByFuture;
            CtpTraderNative.SetOnRtnRepealFromBankToFutureByFuture(_instance, _cbOnRtnRepealFromBankToFutureByFuture);
            _cbOnRtnRepealFromFutureToBankByFuture = NativeOnRtnRepealFromFutureToBankByFuture;
            CtpTraderNative.SetOnRtnRepealFromFutureToBankByFuture(_instance, _cbOnRtnRepealFromFutureToBankByFuture);
            _cbOnRspFromBankToFutureByFuture = NativeOnRspFromBankToFutureByFuture;
            CtpTraderNative.SetOnRspFromBankToFutureByFuture(_instance, _cbOnRspFromBankToFutureByFuture);
            _cbOnRspFromFutureToBankByFuture = NativeOnRspFromFutureToBankByFuture;
            CtpTraderNative.SetOnRspFromFutureToBankByFuture(_instance, _cbOnRspFromFutureToBankByFuture);
            _cbOnRspQueryBankAccountMoneyByFuture = NativeOnRspQueryBankAccountMoneyByFuture;
            CtpTraderNative.SetOnRspQueryBankAccountMoneyByFuture(_instance, _cbOnRspQueryBankAccountMoneyByFuture);
            _cbOnRtnOpenAccountByBank = NativeOnRtnOpenAccountByBank;
            CtpTraderNative.SetOnRtnOpenAccountByBank(_instance, _cbOnRtnOpenAccountByBank);
            _cbOnRtnCancelAccountByBank = NativeOnRtnCancelAccountByBank;
            CtpTraderNative.SetOnRtnCancelAccountByBank(_instance, _cbOnRtnCancelAccountByBank);
            _cbOnRtnChangeAccountByBank = NativeOnRtnChangeAccountByBank;
            CtpTraderNative.SetOnRtnChangeAccountByBank(_instance, _cbOnRtnChangeAccountByBank);
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

        ///客户端认证响应
        private void NativeOnRspAuthenticate(CtpRspAuthenticate rspAuthenticateField, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspAuthenticate;
            rsp.Item1 = new CtpAny(rspAuthenticateField);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///登录请求响应
        private void NativeOnRspUserLogin(CtpRspUserLogin rspUserLogin, CtpRspInfo rspInfo, int requestId, bool isLast)
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
        private void NativeOnRspUserLogout(CtpUserLogout userLogout, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspUserLogout;
            rsp.Item1 = new CtpAny(userLogout);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///用户口令更新请求响应
        private void NativeOnRspUserPasswordUpdate(CtpUserPasswordUpdate userPasswordUpdate, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspUserPasswordUpdate;
            rsp.Item1 = new CtpAny(userPasswordUpdate);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///资金账户口令更新请求响应
        private void NativeOnRspTradingAccountPasswordUpdate(CtpTradingAccountPasswordUpdate tradingAccountPasswordUpdate, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspTradingAccountPasswordUpdate;
            rsp.Item1 = new CtpAny(tradingAccountPasswordUpdate);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///报单录入请求响应
        private void NativeOnRspOrderInsert(CtpInputOrder inputOrder, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspOrderInsert;
            rsp.Item1 = new CtpAny(inputOrder);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///预埋单录入请求响应
        private void NativeOnRspParkedOrderInsert(CtpParkedOrder parkedOrder, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspParkedOrderInsert;
            rsp.Item1 = new CtpAny(parkedOrder);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///预埋撤单录入请求响应
        private void NativeOnRspParkedOrderAction(CtpParkedOrderAction parkedOrderAction, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspParkedOrderAction;
            rsp.Item1 = new CtpAny(parkedOrderAction);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///报单操作请求响应
        private void NativeOnRspOrderAction(CtpInputOrderAction inputOrderAction, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspOrderAction;
            rsp.Item1 = new CtpAny(inputOrderAction);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///查询最大报单数量响应
        private void NativeOnRspQueryMaxOrderVolume(CtpQueryMaxOrderVolume queryMaxOrderVolume, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQueryMaxOrderVolume;
            rsp.Item1 = new CtpAny(queryMaxOrderVolume);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///投资者结算结果确认响应
        private void NativeOnRspSettlementInfoConfirm(CtpSettlementInfoConfirm settlementInfoConfirm, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspSettlementInfoConfirm;
            rsp.Item1 = new CtpAny(settlementInfoConfirm);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///删除预埋单响应
        private void NativeOnRspRemoveParkedOrder(CtpRemoveParkedOrder removeParkedOrder, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspRemoveParkedOrder;
            rsp.Item1 = new CtpAny(removeParkedOrder);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///删除预埋撤单响应
        private void NativeOnRspRemoveParkedOrderAction(CtpRemoveParkedOrderAction removeParkedOrderAction, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspRemoveParkedOrderAction;
            rsp.Item1 = new CtpAny(removeParkedOrderAction);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///执行宣告录入请求响应
        private void NativeOnRspExecOrderInsert(CtpInputExecOrder inputExecOrder, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspExecOrderInsert;
            rsp.Item1 = new CtpAny(inputExecOrder);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///执行宣告操作请求响应
        private void NativeOnRspExecOrderAction(CtpInputExecOrderAction inputExecOrderAction, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspExecOrderAction;
            rsp.Item1 = new CtpAny(inputExecOrderAction);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///询价录入请求响应
        private void NativeOnRspForQuoteInsert(CtpInputForQuote inputForQuote, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspForQuoteInsert;
            rsp.Item1 = new CtpAny(inputForQuote);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///报价录入请求响应
        private void NativeOnRspQuoteInsert(CtpInputQuote inputQuote, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQuoteInsert;
            rsp.Item1 = new CtpAny(inputQuote);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///报价操作请求响应
        private void NativeOnRspQuoteAction(CtpInputQuoteAction inputQuoteAction, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQuoteAction;
            rsp.Item1 = new CtpAny(inputQuoteAction);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///批量报单操作请求响应
        private void NativeOnRspBatchOrderAction(CtpInputBatchOrderAction inputBatchOrderAction, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspBatchOrderAction;
            rsp.Item1 = new CtpAny(inputBatchOrderAction);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///申请组合录入请求响应
        private void NativeOnRspCombActionInsert(CtpInputCombAction inputCombAction, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspCombActionInsert;
            rsp.Item1 = new CtpAny(inputCombAction);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询报单响应
        private void NativeOnRspQryOrder(CtpOrder order, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryOrder;
            rsp.Item1 = new CtpAny(order);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询成交响应
        private void NativeOnRspQryTrade(CtpTrade trade, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryTrade;
            rsp.Item1 = new CtpAny(trade);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询投资者持仓响应
        private void NativeOnRspQryInvestorPosition(CtpInvestorPosition investorPosition, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryInvestorPosition;
            rsp.Item1 = new CtpAny(investorPosition);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询资金账户响应
        private void NativeOnRspQryTradingAccount(CtpTradingAccount tradingAccount, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryTradingAccount;
            rsp.Item1 = new CtpAny(tradingAccount);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询投资者响应
        private void NativeOnRspQryInvestor(CtpInvestor investor, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryInvestor;
            rsp.Item1 = new CtpAny(investor);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询交易编码响应
        private void NativeOnRspQryTradingCode(CtpTradingCode tradingCode, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryTradingCode;
            rsp.Item1 = new CtpAny(tradingCode);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询合约保证金率响应
        private void NativeOnRspQryInstrumentMarginRate(CtpInstrumentMarginRate instrumentMarginRate, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryInstrumentMarginRate;
            rsp.Item1 = new CtpAny(instrumentMarginRate);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询合约手续费率响应
        private void NativeOnRspQryInstrumentCommissionRate(CtpInstrumentCommissionRate instrumentCommissionRate, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryInstrumentCommissionRate;
            rsp.Item1 = new CtpAny(instrumentCommissionRate);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询交易所响应
        private void NativeOnRspQryExchange(CtpExchange exchange, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryExchange;
            rsp.Item1 = new CtpAny(exchange);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询产品响应
        private void NativeOnRspQryProduct(CtpProduct product, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryProduct;
            rsp.Item1 = new CtpAny(product);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询合约响应
        private void NativeOnRspQryInstrument(CtpInstrument instrument, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryInstrument;
            rsp.Item1 = new CtpAny(instrument);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询行情响应
        private void NativeOnRspQryDepthMarketData(CtpDepthMarketData depthMarketData, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryDepthMarketData;
            rsp.Item1 = new CtpAny(depthMarketData);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询投资者结算结果响应
        private void NativeOnRspQrySettlementInfo(CtpSettlementInfo settlementInfo, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQrySettlementInfo;
            rsp.Item1 = new CtpAny(settlementInfo);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询转帐银行响应
        private void NativeOnRspQryTransferBank(CtpTransferBank transferBank, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryTransferBank;
            rsp.Item1 = new CtpAny(transferBank);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询投资者持仓明细响应
        private void NativeOnRspQryInvestorPositionDetail(CtpInvestorPositionDetail investorPositionDetail, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryInvestorPositionDetail;
            rsp.Item1 = new CtpAny(investorPositionDetail);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询客户通知响应
        private void NativeOnRspQryNotice(CtpNotice notice, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryNotice;
            rsp.Item1 = new CtpAny(notice);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询结算信息确认响应
        private void NativeOnRspQrySettlementInfoConfirm(CtpSettlementInfoConfirm settlementInfoConfirm, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQrySettlementInfoConfirm;
            rsp.Item1 = new CtpAny(settlementInfoConfirm);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询投资者持仓明细响应
        private void NativeOnRspQryInvestorPositionCombineDetail(CtpInvestorPositionCombineDetail investorPositionCombineDetail, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryInvestorPositionCombineDetail;
            rsp.Item1 = new CtpAny(investorPositionCombineDetail);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///查询保证金监管系统经纪公司资金账户密钥响应
        private void NativeOnRspQryCFMMCTradingAccountKey(CtpCFMMCTradingAccountKey cFMMCTradingAccountKey, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryCFMMCTradingAccountKey;
            rsp.Item1 = new CtpAny(cFMMCTradingAccountKey);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询仓单折抵信息响应
        private void NativeOnRspQryEWarrantOffset(CtpEWarrantOffset eWarrantOffset, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryEWarrantOffset;
            rsp.Item1 = new CtpAny(eWarrantOffset);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询投资者品种/跨品种保证金响应
        private void NativeOnRspQryInvestorProductGroupMargin(CtpInvestorProductGroupMargin investorProductGroupMargin, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryInvestorProductGroupMargin;
            rsp.Item1 = new CtpAny(investorProductGroupMargin);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询交易所保证金率响应
        private void NativeOnRspQryExchangeMarginRate(CtpExchangeMarginRate exchangeMarginRate, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryExchangeMarginRate;
            rsp.Item1 = new CtpAny(exchangeMarginRate);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询交易所调整保证金率响应
        private void NativeOnRspQryExchangeMarginRateAdjust(CtpExchangeMarginRateAdjust exchangeMarginRateAdjust, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryExchangeMarginRateAdjust;
            rsp.Item1 = new CtpAny(exchangeMarginRateAdjust);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询汇率响应
        private void NativeOnRspQryExchangeRate(CtpExchangeRate exchangeRate, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryExchangeRate;
            rsp.Item1 = new CtpAny(exchangeRate);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询二级代理操作员银期权限响应
        private void NativeOnRspQrySecAgentACIDMap(CtpSecAgentACIDMap secAgentACIDMap, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQrySecAgentACIDMap;
            rsp.Item1 = new CtpAny(secAgentACIDMap);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询产品报价汇率
        private void NativeOnRspQryProductExchRate(CtpProductExchRate productExchRate, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryProductExchRate;
            rsp.Item1 = new CtpAny(productExchRate);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询产品组
        private void NativeOnRspQryProductGroup(CtpProductGroup productGroup, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryProductGroup;
            rsp.Item1 = new CtpAny(productGroup);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询期权交易成本响应
        private void NativeOnRspQryOptionInstrTradeCost(CtpOptionInstrTradeCost optionInstrTradeCost, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryOptionInstrTradeCost;
            rsp.Item1 = new CtpAny(optionInstrTradeCost);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询期权合约手续费响应
        private void NativeOnRspQryOptionInstrCommRate(CtpOptionInstrCommRate optionInstrCommRate, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryOptionInstrCommRate;
            rsp.Item1 = new CtpAny(optionInstrCommRate);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询执行宣告响应
        private void NativeOnRspQryExecOrder(CtpExecOrder execOrder, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryExecOrder;
            rsp.Item1 = new CtpAny(execOrder);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询询价响应
        private void NativeOnRspQryForQuote(CtpForQuote forQuote, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryForQuote;
            rsp.Item1 = new CtpAny(forQuote);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询报价响应
        private void NativeOnRspQryQuote(CtpQuote quote, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryQuote;
            rsp.Item1 = new CtpAny(quote);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询组合合约安全系数响应
        private void NativeOnRspQryCombInstrumentGuard(CtpCombInstrumentGuard combInstrumentGuard, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryCombInstrumentGuard;
            rsp.Item1 = new CtpAny(combInstrumentGuard);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询申请组合响应
        private void NativeOnRspQryCombAction(CtpCombAction combAction, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryCombAction;
            rsp.Item1 = new CtpAny(combAction);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询转帐流水响应
        private void NativeOnRspQryTransferSerial(CtpTransferSerial transferSerial, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryTransferSerial;
            rsp.Item1 = new CtpAny(transferSerial);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询银期签约关系响应
        private void NativeOnRspQryAccountregister(CtpAccountregister accountregister, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryAccountregister;
            rsp.Item1 = new CtpAny(accountregister);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///错误应答
        private void NativeOnRspError(CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspError;
            rsp.Item1 = new CtpAny(rspInfo);
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///报单通知
        private void NativeOnRtnOrder(CtpOrder order)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRtnOrder;
            rsp.Item1 = new CtpAny(order);
            ProcessResponse(ref rsp);
        }

        ///成交通知
        private void NativeOnRtnTrade(CtpTrade trade)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRtnTrade;
            rsp.Item1 = new CtpAny(trade);
            ProcessResponse(ref rsp);
        }

        ///报单录入错误回报
        private void NativeOnErrRtnOrderInsert(CtpInputOrder inputOrder, CtpRspInfo rspInfo)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnErrRtnOrderInsert;
            rsp.Item1 = new CtpAny(inputOrder);
            rsp.Item2 = rspInfo;
            ProcessResponse(ref rsp);
        }

        ///报单操作错误回报
        private void NativeOnErrRtnOrderAction(CtpOrderAction orderAction, CtpRspInfo rspInfo)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnErrRtnOrderAction;
            rsp.Item1 = new CtpAny(orderAction);
            rsp.Item2 = rspInfo;
            ProcessResponse(ref rsp);
        }

        ///合约交易状态通知
        private void NativeOnRtnInstrumentStatus(CtpInstrumentStatus instrumentStatus)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRtnInstrumentStatus;
            rsp.Item1 = new CtpAny(instrumentStatus);
            ProcessResponse(ref rsp);
        }

        ///交易通知
        private void NativeOnRtnTradingNotice(CtpTradingNoticeInfo tradingNoticeInfo)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRtnTradingNotice;
            rsp.Item1 = new CtpAny(tradingNoticeInfo);
            ProcessResponse(ref rsp);
        }

        ///提示条件单校验错误
        private void NativeOnRtnErrorConditionalOrder(CtpErrorConditionalOrder errorConditionalOrder)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRtnErrorConditionalOrder;
            rsp.Item1 = new CtpAny(errorConditionalOrder);
            ProcessResponse(ref rsp);
        }

        ///执行宣告通知
        private void NativeOnRtnExecOrder(CtpExecOrder execOrder)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRtnExecOrder;
            rsp.Item1 = new CtpAny(execOrder);
            ProcessResponse(ref rsp);
        }

        ///执行宣告录入错误回报
        private void NativeOnErrRtnExecOrderInsert(CtpInputExecOrder inputExecOrder, CtpRspInfo rspInfo)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnErrRtnExecOrderInsert;
            rsp.Item1 = new CtpAny(inputExecOrder);
            rsp.Item2 = rspInfo;
            ProcessResponse(ref rsp);
        }

        ///执行宣告操作错误回报
        private void NativeOnErrRtnExecOrderAction(CtpExecOrderAction execOrderAction, CtpRspInfo rspInfo)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnErrRtnExecOrderAction;
            rsp.Item1 = new CtpAny(execOrderAction);
            rsp.Item2 = rspInfo;
            ProcessResponse(ref rsp);
        }

        ///询价录入错误回报
        private void NativeOnErrRtnForQuoteInsert(CtpInputForQuote inputForQuote, CtpRspInfo rspInfo)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnErrRtnForQuoteInsert;
            rsp.Item1 = new CtpAny(inputForQuote);
            rsp.Item2 = rspInfo;
            ProcessResponse(ref rsp);
        }

        ///报价通知
        private void NativeOnRtnQuote(CtpQuote quote)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRtnQuote;
            rsp.Item1 = new CtpAny(quote);
            ProcessResponse(ref rsp);
        }

        ///报价录入错误回报
        private void NativeOnErrRtnQuoteInsert(CtpInputQuote inputQuote, CtpRspInfo rspInfo)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnErrRtnQuoteInsert;
            rsp.Item1 = new CtpAny(inputQuote);
            rsp.Item2 = rspInfo;
            ProcessResponse(ref rsp);
        }

        ///报价操作错误回报
        private void NativeOnErrRtnQuoteAction(CtpQuoteAction quoteAction, CtpRspInfo rspInfo)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnErrRtnQuoteAction;
            rsp.Item1 = new CtpAny(quoteAction);
            rsp.Item2 = rspInfo;
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

        ///保证金监控中心用户令牌
        private void NativeOnRtnCFMMCTradingAccountToken(CtpCFMMCTradingAccountToken cFMMCTradingAccountToken)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRtnCFMMCTradingAccountToken;
            rsp.Item1 = new CtpAny(cFMMCTradingAccountToken);
            ProcessResponse(ref rsp);
        }

        ///批量报单操作错误回报
        private void NativeOnErrRtnBatchOrderAction(CtpBatchOrderAction batchOrderAction, CtpRspInfo rspInfo)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnErrRtnBatchOrderAction;
            rsp.Item1 = new CtpAny(batchOrderAction);
            rsp.Item2 = rspInfo;
            ProcessResponse(ref rsp);
        }

        ///申请组合通知
        private void NativeOnRtnCombAction(CtpCombAction combAction)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRtnCombAction;
            rsp.Item1 = new CtpAny(combAction);
            ProcessResponse(ref rsp);
        }

        ///申请组合录入错误回报
        private void NativeOnErrRtnCombActionInsert(CtpInputCombAction inputCombAction, CtpRspInfo rspInfo)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnErrRtnCombActionInsert;
            rsp.Item1 = new CtpAny(inputCombAction);
            rsp.Item2 = rspInfo;
            ProcessResponse(ref rsp);
        }

        ///请求查询签约银行响应
        private void NativeOnRspQryContractBank(CtpContractBank contractBank, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryContractBank;
            rsp.Item1 = new CtpAny(contractBank);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询预埋单响应
        private void NativeOnRspQryParkedOrder(CtpParkedOrder parkedOrder, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryParkedOrder;
            rsp.Item1 = new CtpAny(parkedOrder);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询预埋撤单响应
        private void NativeOnRspQryParkedOrderAction(CtpParkedOrderAction parkedOrderAction, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryParkedOrderAction;
            rsp.Item1 = new CtpAny(parkedOrderAction);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询交易通知响应
        private void NativeOnRspQryTradingNotice(CtpTradingNotice tradingNotice, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryTradingNotice;
            rsp.Item1 = new CtpAny(tradingNotice);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询经纪公司交易参数响应
        private void NativeOnRspQryBrokerTradingParams(CtpBrokerTradingParams brokerTradingParams, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryBrokerTradingParams;
            rsp.Item1 = new CtpAny(brokerTradingParams);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询经纪公司交易算法响应
        private void NativeOnRspQryBrokerTradingAlgos(CtpBrokerTradingAlgos brokerTradingAlgos, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQryBrokerTradingAlgos;
            rsp.Item1 = new CtpAny(brokerTradingAlgos);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///请求查询监控中心用户令牌
        private void NativeOnRspQueryCFMMCTradingAccountToken(CtpQueryCFMMCTradingAccountToken queryCFMMCTradingAccountToken, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQueryCFMMCTradingAccountToken;
            rsp.Item1 = new CtpAny(queryCFMMCTradingAccountToken);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///银行发起银行资金转期货通知
        private void NativeOnRtnFromBankToFutureByBank(CtpRspTransfer rspTransfer)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRtnFromBankToFutureByBank;
            rsp.Item1 = new CtpAny(rspTransfer);
            ProcessResponse(ref rsp);
        }

        ///银行发起期货资金转银行通知
        private void NativeOnRtnFromFutureToBankByBank(CtpRspTransfer rspTransfer)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRtnFromFutureToBankByBank;
            rsp.Item1 = new CtpAny(rspTransfer);
            ProcessResponse(ref rsp);
        }

        ///银行发起冲正银行转期货通知
        private void NativeOnRtnRepealFromBankToFutureByBank(CtpRspRepeal rspRepeal)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRtnRepealFromBankToFutureByBank;
            rsp.Item1 = new CtpAny(rspRepeal);
            ProcessResponse(ref rsp);
        }

        ///银行发起冲正期货转银行通知
        private void NativeOnRtnRepealFromFutureToBankByBank(CtpRspRepeal rspRepeal)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRtnRepealFromFutureToBankByBank;
            rsp.Item1 = new CtpAny(rspRepeal);
            ProcessResponse(ref rsp);
        }

        ///期货发起银行资金转期货通知
        private void NativeOnRtnFromBankToFutureByFuture(CtpRspTransfer rspTransfer)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRtnFromBankToFutureByFuture;
            rsp.Item1 = new CtpAny(rspTransfer);
            ProcessResponse(ref rsp);
        }

        ///期货发起期货资金转银行通知
        private void NativeOnRtnFromFutureToBankByFuture(CtpRspTransfer rspTransfer)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRtnFromFutureToBankByFuture;
            rsp.Item1 = new CtpAny(rspTransfer);
            ProcessResponse(ref rsp);
        }

        ///系统运行时期货端手工发起冲正银行转期货请求，银行处理完毕后报盘发回的通知
        private void NativeOnRtnRepealFromBankToFutureByFutureManual(CtpRspRepeal rspRepeal)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRtnRepealFromBankToFutureByFutureManual;
            rsp.Item1 = new CtpAny(rspRepeal);
            ProcessResponse(ref rsp);
        }

        ///系统运行时期货端手工发起冲正期货转银行请求，银行处理完毕后报盘发回的通知
        private void NativeOnRtnRepealFromFutureToBankByFutureManual(CtpRspRepeal rspRepeal)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRtnRepealFromFutureToBankByFutureManual;
            rsp.Item1 = new CtpAny(rspRepeal);
            ProcessResponse(ref rsp);
        }

        ///期货发起查询银行余额通知
        private void NativeOnRtnQueryBankBalanceByFuture(CtpNotifyQueryAccount notifyQueryAccount)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRtnQueryBankBalanceByFuture;
            rsp.Item1 = new CtpAny(notifyQueryAccount);
            ProcessResponse(ref rsp);
        }

        ///期货发起银行资金转期货错误回报
        private void NativeOnErrRtnBankToFutureByFuture(CtpReqTransfer reqTransfer, CtpRspInfo rspInfo)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnErrRtnBankToFutureByFuture;
            rsp.Item1 = new CtpAny(reqTransfer);
            rsp.Item2 = rspInfo;
            ProcessResponse(ref rsp);
        }

        ///期货发起期货资金转银行错误回报
        private void NativeOnErrRtnFutureToBankByFuture(CtpReqTransfer reqTransfer, CtpRspInfo rspInfo)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnErrRtnFutureToBankByFuture;
            rsp.Item1 = new CtpAny(reqTransfer);
            rsp.Item2 = rspInfo;
            ProcessResponse(ref rsp);
        }

        ///系统运行时期货端手工发起冲正银行转期货错误回报
        private void NativeOnErrRtnRepealBankToFutureByFutureManual(CtpReqRepeal reqRepeal, CtpRspInfo rspInfo)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnErrRtnRepealBankToFutureByFutureManual;
            rsp.Item1 = new CtpAny(reqRepeal);
            rsp.Item2 = rspInfo;
            ProcessResponse(ref rsp);
        }

        ///系统运行时期货端手工发起冲正期货转银行错误回报
        private void NativeOnErrRtnRepealFutureToBankByFutureManual(CtpReqRepeal reqRepeal, CtpRspInfo rspInfo)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnErrRtnRepealFutureToBankByFutureManual;
            rsp.Item1 = new CtpAny(reqRepeal);
            rsp.Item2 = rspInfo;
            ProcessResponse(ref rsp);
        }

        ///期货发起查询银行余额错误回报
        private void NativeOnErrRtnQueryBankBalanceByFuture(CtpReqQueryAccount reqQueryAccount, CtpRspInfo rspInfo)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnErrRtnQueryBankBalanceByFuture;
            rsp.Item1 = new CtpAny(reqQueryAccount);
            rsp.Item2 = rspInfo;
            ProcessResponse(ref rsp);
        }

        ///期货发起冲正银行转期货请求，银行处理完毕后报盘发回的通知
        private void NativeOnRtnRepealFromBankToFutureByFuture(CtpRspRepeal rspRepeal)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRtnRepealFromBankToFutureByFuture;
            rsp.Item1 = new CtpAny(rspRepeal);
            ProcessResponse(ref rsp);
        }

        ///期货发起冲正期货转银行请求，银行处理完毕后报盘发回的通知
        private void NativeOnRtnRepealFromFutureToBankByFuture(CtpRspRepeal rspRepeal)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRtnRepealFromFutureToBankByFuture;
            rsp.Item1 = new CtpAny(rspRepeal);
            ProcessResponse(ref rsp);
        }

        ///期货发起银行资金转期货应答
        private void NativeOnRspFromBankToFutureByFuture(CtpReqTransfer reqTransfer, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspFromBankToFutureByFuture;
            rsp.Item1 = new CtpAny(reqTransfer);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///期货发起期货资金转银行应答
        private void NativeOnRspFromFutureToBankByFuture(CtpReqTransfer reqTransfer, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspFromFutureToBankByFuture;
            rsp.Item1 = new CtpAny(reqTransfer);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///期货发起查询银行余额应答
        private void NativeOnRspQueryBankAccountMoneyByFuture(CtpReqQueryAccount reqQueryAccount, CtpRspInfo rspInfo, int requestId, bool isLast)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRspQueryBankAccountMoneyByFuture;
            rsp.Item1 = new CtpAny(reqQueryAccount);
            rsp.Item2 = rspInfo;
            rsp.RequestID = requestId;
            rsp.IsLast = isLast;
            ProcessResponse(ref rsp);
        }

        ///银行发起银期开户通知
        private void NativeOnRtnOpenAccountByBank(CtpOpenAccount openAccount)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRtnOpenAccountByBank;
            rsp.Item1 = new CtpAny(openAccount);
            ProcessResponse(ref rsp);
        }

        ///银行发起银期销户通知
        private void NativeOnRtnCancelAccountByBank(CtpCancelAccount cancelAccount)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRtnCancelAccountByBank;
            rsp.Item1 = new CtpAny(cancelAccount);
            ProcessResponse(ref rsp);
        }

        ///银行发起变更银行账号通知
        private void NativeOnRtnChangeAccountByBank(CtpChangeAccount changeAccount)
        {
            var rsp = new CtpResponse();
            rsp.TypeId = CtpResponseType.OnRtnChangeAccountByBank;
            rsp.Item1 = new CtpAny(changeAccount);
            ProcessResponse(ref rsp);
        }

        #endregion

        #region Request Handler
        private int DoReqAuthenticate(ref CtpRequest req)
        {
            var data = req.Args.AsReqAuthenticate;
            return CtpTraderNative.ReqAuthenticate(_instance, data, req.RequestID);
        }

        private int DoReqUserLogin(ref CtpRequest req)
        {
            var data = req.Args.AsReqUserLogin;
            return CtpTraderNative.ReqUserLogin(_instance, data, req.RequestID);
        }

        private int DoReqUserLogout(ref CtpRequest req)
        {
            var data = req.Args.AsUserLogout;
            return CtpTraderNative.ReqUserLogout(_instance, data, req.RequestID);
        }

        private int DoReqUserPasswordUpdate(ref CtpRequest req)
        {
            var data = req.Args.AsUserPasswordUpdate;
            return CtpTraderNative.ReqUserPasswordUpdate(_instance, data, req.RequestID);
        }

        private int DoReqTradingAccountPasswordUpdate(ref CtpRequest req)
        {
            var data = req.Args.AsTradingAccountPasswordUpdate;
            return CtpTraderNative.ReqTradingAccountPasswordUpdate(_instance, data, req.RequestID);
        }

        private int DoReqOrderInsert(ref CtpRequest req)
        {
            var data = req.Args.AsInputOrder;
            return CtpTraderNative.ReqOrderInsert(_instance, data, req.RequestID);
        }

        private int DoReqParkedOrderInsert(ref CtpRequest req)
        {
            var data = req.Args.AsParkedOrder;
            return CtpTraderNative.ReqParkedOrderInsert(_instance, data, req.RequestID);
        }

        private int DoReqParkedOrderAction(ref CtpRequest req)
        {
            var data = req.Args.AsParkedOrderAction;
            return CtpTraderNative.ReqParkedOrderAction(_instance, data, req.RequestID);
        }

        private int DoReqOrderAction(ref CtpRequest req)
        {
            var data = req.Args.AsInputOrderAction;
            return CtpTraderNative.ReqOrderAction(_instance, data, req.RequestID);
        }

        private int DoReqQueryMaxOrderVolume(ref CtpRequest req)
        {
            var data = req.Args.AsQueryMaxOrderVolume;
            return CtpTraderNative.ReqQueryMaxOrderVolume(_instance, data, req.RequestID);
        }

        private int DoReqSettlementInfoConfirm(ref CtpRequest req)
        {
            var data = req.Args.AsSettlementInfoConfirm;
            return CtpTraderNative.ReqSettlementInfoConfirm(_instance, data, req.RequestID);
        }

        private int DoReqRemoveParkedOrder(ref CtpRequest req)
        {
            var data = req.Args.AsRemoveParkedOrder;
            return CtpTraderNative.ReqRemoveParkedOrder(_instance, data, req.RequestID);
        }

        private int DoReqRemoveParkedOrderAction(ref CtpRequest req)
        {
            var data = req.Args.AsRemoveParkedOrderAction;
            return CtpTraderNative.ReqRemoveParkedOrderAction(_instance, data, req.RequestID);
        }

        private int DoReqExecOrderInsert(ref CtpRequest req)
        {
            var data = req.Args.AsInputExecOrder;
            return CtpTraderNative.ReqExecOrderInsert(_instance, data, req.RequestID);
        }

        private int DoReqExecOrderAction(ref CtpRequest req)
        {
            var data = req.Args.AsInputExecOrderAction;
            return CtpTraderNative.ReqExecOrderAction(_instance, data, req.RequestID);
        }

        private int DoReqForQuoteInsert(ref CtpRequest req)
        {
            var data = req.Args.AsInputForQuote;
            return CtpTraderNative.ReqForQuoteInsert(_instance, data, req.RequestID);
        }

        private int DoReqQuoteInsert(ref CtpRequest req)
        {
            var data = req.Args.AsInputQuote;
            return CtpTraderNative.ReqQuoteInsert(_instance, data, req.RequestID);
        }

        private int DoReqQuoteAction(ref CtpRequest req)
        {
            var data = req.Args.AsInputQuoteAction;
            return CtpTraderNative.ReqQuoteAction(_instance, data, req.RequestID);
        }

        private int DoReqBatchOrderAction(ref CtpRequest req)
        {
            var data = req.Args.AsInputBatchOrderAction;
            return CtpTraderNative.ReqBatchOrderAction(_instance, data, req.RequestID);
        }

        private int DoReqCombActionInsert(ref CtpRequest req)
        {
            var data = req.Args.AsInputCombAction;
            return CtpTraderNative.ReqCombActionInsert(_instance, data, req.RequestID);
        }

        private int DoReqQryOrder(ref CtpRequest req)
        {
            var data = req.Args.AsQryOrder;
            return CtpTraderNative.ReqQryOrder(_instance, data, req.RequestID);
        }

        private int DoReqQryTrade(ref CtpRequest req)
        {
            var data = req.Args.AsQryTrade;
            return CtpTraderNative.ReqQryTrade(_instance, data, req.RequestID);
        }

        private int DoReqQryInvestorPosition(ref CtpRequest req)
        {
            var data = req.Args.AsQryInvestorPosition;
            return CtpTraderNative.ReqQryInvestorPosition(_instance, data, req.RequestID);
        }

        private int DoReqQryTradingAccount(ref CtpRequest req)
        {
            var data = req.Args.AsQryTradingAccount;
            return CtpTraderNative.ReqQryTradingAccount(_instance, data, req.RequestID);
        }

        private int DoReqQryInvestor(ref CtpRequest req)
        {
            var data = req.Args.AsQryInvestor;
            return CtpTraderNative.ReqQryInvestor(_instance, data, req.RequestID);
        }

        private int DoReqQryTradingCode(ref CtpRequest req)
        {
            var data = req.Args.AsQryTradingCode;
            return CtpTraderNative.ReqQryTradingCode(_instance, data, req.RequestID);
        }

        private int DoReqQryInstrumentMarginRate(ref CtpRequest req)
        {
            var data = req.Args.AsQryInstrumentMarginRate;
            return CtpTraderNative.ReqQryInstrumentMarginRate(_instance, data, req.RequestID);
        }

        private int DoReqQryInstrumentCommissionRate(ref CtpRequest req)
        {
            var data = req.Args.AsQryInstrumentCommissionRate;
            return CtpTraderNative.ReqQryInstrumentCommissionRate(_instance, data, req.RequestID);
        }

        private int DoReqQryExchange(ref CtpRequest req)
        {
            var data = req.Args.AsQryExchange;
            return CtpTraderNative.ReqQryExchange(_instance, data, req.RequestID);
        }

        private int DoReqQryProduct(ref CtpRequest req)
        {
            var data = req.Args.AsQryProduct;
            return CtpTraderNative.ReqQryProduct(_instance, data, req.RequestID);
        }

        private int DoReqQryInstrument(ref CtpRequest req)
        {
            var data = req.Args.AsQryInstrument;
            return CtpTraderNative.ReqQryInstrument(_instance, data, req.RequestID);
        }

        private int DoReqQryDepthMarketData(ref CtpRequest req)
        {
            var data = req.Args.AsQryDepthMarketData;
            return CtpTraderNative.ReqQryDepthMarketData(_instance, data, req.RequestID);
        }

        private int DoReqQrySettlementInfo(ref CtpRequest req)
        {
            var data = req.Args.AsQrySettlementInfo;
            return CtpTraderNative.ReqQrySettlementInfo(_instance, data, req.RequestID);
        }

        private int DoReqQryTransferBank(ref CtpRequest req)
        {
            var data = req.Args.AsQryTransferBank;
            return CtpTraderNative.ReqQryTransferBank(_instance, data, req.RequestID);
        }

        private int DoReqQryInvestorPositionDetail(ref CtpRequest req)
        {
            var data = req.Args.AsQryInvestorPositionDetail;
            return CtpTraderNative.ReqQryInvestorPositionDetail(_instance, data, req.RequestID);
        }

        private int DoReqQryNotice(ref CtpRequest req)
        {
            var data = req.Args.AsQryNotice;
            return CtpTraderNative.ReqQryNotice(_instance, data, req.RequestID);
        }

        private int DoReqQrySettlementInfoConfirm(ref CtpRequest req)
        {
            var data = req.Args.AsQrySettlementInfoConfirm;
            return CtpTraderNative.ReqQrySettlementInfoConfirm(_instance, data, req.RequestID);
        }

        private int DoReqQryInvestorPositionCombineDetail(ref CtpRequest req)
        {
            var data = req.Args.AsQryInvestorPositionCombineDetail;
            return CtpTraderNative.ReqQryInvestorPositionCombineDetail(_instance, data, req.RequestID);
        }

        private int DoReqQryCFMMCTradingAccountKey(ref CtpRequest req)
        {
            var data = req.Args.AsQryCFMMCTradingAccountKey;
            return CtpTraderNative.ReqQryCFMMCTradingAccountKey(_instance, data, req.RequestID);
        }

        private int DoReqQryEWarrantOffset(ref CtpRequest req)
        {
            var data = req.Args.AsQryEWarrantOffset;
            return CtpTraderNative.ReqQryEWarrantOffset(_instance, data, req.RequestID);
        }

        private int DoReqQryInvestorProductGroupMargin(ref CtpRequest req)
        {
            var data = req.Args.AsQryInvestorProductGroupMargin;
            return CtpTraderNative.ReqQryInvestorProductGroupMargin(_instance, data, req.RequestID);
        }

        private int DoReqQryExchangeMarginRate(ref CtpRequest req)
        {
            var data = req.Args.AsQryExchangeMarginRate;
            return CtpTraderNative.ReqQryExchangeMarginRate(_instance, data, req.RequestID);
        }

        private int DoReqQryExchangeMarginRateAdjust(ref CtpRequest req)
        {
            var data = req.Args.AsQryExchangeMarginRateAdjust;
            return CtpTraderNative.ReqQryExchangeMarginRateAdjust(_instance, data, req.RequestID);
        }

        private int DoReqQryExchangeRate(ref CtpRequest req)
        {
            var data = req.Args.AsQryExchangeRate;
            return CtpTraderNative.ReqQryExchangeRate(_instance, data, req.RequestID);
        }

        private int DoReqQrySecAgentACIDMap(ref CtpRequest req)
        {
            var data = req.Args.AsQrySecAgentACIDMap;
            return CtpTraderNative.ReqQrySecAgentACIDMap(_instance, data, req.RequestID);
        }

        private int DoReqQryProductExchRate(ref CtpRequest req)
        {
            var data = req.Args.AsQryProductExchRate;
            return CtpTraderNative.ReqQryProductExchRate(_instance, data, req.RequestID);
        }

        private int DoReqQryProductGroup(ref CtpRequest req)
        {
            var data = req.Args.AsQryProductGroup;
            return CtpTraderNative.ReqQryProductGroup(_instance, data, req.RequestID);
        }

        private int DoReqQryOptionInstrTradeCost(ref CtpRequest req)
        {
            var data = req.Args.AsQryOptionInstrTradeCost;
            return CtpTraderNative.ReqQryOptionInstrTradeCost(_instance, data, req.RequestID);
        }

        private int DoReqQryOptionInstrCommRate(ref CtpRequest req)
        {
            var data = req.Args.AsQryOptionInstrCommRate;
            return CtpTraderNative.ReqQryOptionInstrCommRate(_instance, data, req.RequestID);
        }

        private int DoReqQryExecOrder(ref CtpRequest req)
        {
            var data = req.Args.AsQryExecOrder;
            return CtpTraderNative.ReqQryExecOrder(_instance, data, req.RequestID);
        }

        private int DoReqQryForQuote(ref CtpRequest req)
        {
            var data = req.Args.AsQryForQuote;
            return CtpTraderNative.ReqQryForQuote(_instance, data, req.RequestID);
        }

        private int DoReqQryQuote(ref CtpRequest req)
        {
            var data = req.Args.AsQryQuote;
            return CtpTraderNative.ReqQryQuote(_instance, data, req.RequestID);
        }

        private int DoReqQryCombInstrumentGuard(ref CtpRequest req)
        {
            var data = req.Args.AsQryCombInstrumentGuard;
            return CtpTraderNative.ReqQryCombInstrumentGuard(_instance, data, req.RequestID);
        }

        private int DoReqQryCombAction(ref CtpRequest req)
        {
            var data = req.Args.AsQryCombAction;
            return CtpTraderNative.ReqQryCombAction(_instance, data, req.RequestID);
        }

        private int DoReqQryTransferSerial(ref CtpRequest req)
        {
            var data = req.Args.AsQryTransferSerial;
            return CtpTraderNative.ReqQryTransferSerial(_instance, data, req.RequestID);
        }

        private int DoReqQryAccountregister(ref CtpRequest req)
        {
            var data = req.Args.AsQryAccountregister;
            return CtpTraderNative.ReqQryAccountregister(_instance, data, req.RequestID);
        }

        private int DoReqQryContractBank(ref CtpRequest req)
        {
            var data = req.Args.AsQryContractBank;
            return CtpTraderNative.ReqQryContractBank(_instance, data, req.RequestID);
        }

        private int DoReqQryParkedOrder(ref CtpRequest req)
        {
            var data = req.Args.AsQryParkedOrder;
            return CtpTraderNative.ReqQryParkedOrder(_instance, data, req.RequestID);
        }

        private int DoReqQryParkedOrderAction(ref CtpRequest req)
        {
            var data = req.Args.AsQryParkedOrderAction;
            return CtpTraderNative.ReqQryParkedOrderAction(_instance, data, req.RequestID);
        }

        private int DoReqQryTradingNotice(ref CtpRequest req)
        {
            var data = req.Args.AsQryTradingNotice;
            return CtpTraderNative.ReqQryTradingNotice(_instance, data, req.RequestID);
        }

        private int DoReqQryBrokerTradingParams(ref CtpRequest req)
        {
            var data = req.Args.AsQryBrokerTradingParams;
            return CtpTraderNative.ReqQryBrokerTradingParams(_instance, data, req.RequestID);
        }

        private int DoReqQryBrokerTradingAlgos(ref CtpRequest req)
        {
            var data = req.Args.AsQryBrokerTradingAlgos;
            return CtpTraderNative.ReqQryBrokerTradingAlgos(_instance, data, req.RequestID);
        }

        private int DoReqQueryCFMMCTradingAccountToken(ref CtpRequest req)
        {
            var data = req.Args.AsQueryCFMMCTradingAccountToken;
            return CtpTraderNative.ReqQueryCFMMCTradingAccountToken(_instance, data, req.RequestID);
        }

        private int DoReqFromBankToFutureByFuture(ref CtpRequest req)
        {
            var data = req.Args.AsReqTransfer;
            return CtpTraderNative.ReqFromBankToFutureByFuture(_instance, data, req.RequestID);
        }

        private int DoReqFromFutureToBankByFuture(ref CtpRequest req)
        {
            var data = req.Args.AsReqTransfer;
            return CtpTraderNative.ReqFromFutureToBankByFuture(_instance, data, req.RequestID);
        }

        private int DoReqQueryBankAccountMoneyByFuture(ref CtpRequest req)
        {
            var data = req.Args.AsReqQueryAccount;
            return CtpTraderNative.ReqQueryBankAccountMoneyByFuture(_instance, data, req.RequestID);
        }

        #endregion

        public CtpTraderApi(string flowPath)
        {
            InitHandlerList();
            InitApi(flowPath);
            InitNativeCallback();
        }

        ~CtpTraderApi()
        {
            Release();
        }

        public CtpRequestFunc[] ReqHandlerList { get { return _handerList; } }

        public virtual int ProcessRequest(ref CtpRequest req)
        {
            return _handerList[req.TypeId](ref req);
        }

        public void Init()
        {
            CtpTraderNative.Init(_instance);
        }

        public void Release()
        {
            if (_instance == IntPtr.Zero)
                return;
            CtpTraderNative.Release(_instance);
            _instance = IntPtr.Zero;
        }

        public int Join()
        {
            return CtpTraderNative.Join(_instance);
        }

        ///获取当前交易日
        ///@retrun 获取到的交易日
        ///@remark 只有登录成功后,才能得到正确的交易日
        public string GetTradingDay()
        {
            return CtpTraderNative.GetTradingDay(_instance);
        }

        ///注册前置机网络地址
        ///@param pszFrontAddress：前置机网络地址。
        ///@remark 网络地址的格式为：“protocol://ipaddress:port”，如：”tcp://127.0.0.1:17001”。 
        ///@remark “tcp”代表传输协议，“127.0.0.1”代表服务器地址。”17001”代表服务器端口号。
        public void RegisterFront(string frontAddress)
        {
            CtpTraderNative.RegisterFront(_instance, frontAddress);
        }

        ///注册名字服务器网络地址
        ///@param pszNsAddress：名字服务器网络地址。
        ///@remark 网络地址的格式为：“protocol://ipaddress:port”，如：”tcp://127.0.0.1:12001”。 
        ///@remark “tcp”代表传输协议，“127.0.0.1”代表服务器地址。”12001”代表服务器端口号。
        ///@remark RegisterNameServer优先于RegisterFront
        public void RegisterNameServer(string nsAddress)
        {
            CtpTraderNative.RegisterNameServer(_instance, nsAddress);
        }
        ///订阅私有流。
        ///@param nResumeType 私有流重传方式  
        ///        THOST_TERT_RESTART:从本交易日开始重传
        ///        THOST_TERT_RESUME:从上次收到的续传
        ///        THOST_TERT_QUICK:只传送登录后私有流的内容
        ///@remark 该方法要在Init方法前调用。若不调用则不会收到私有流的数据。
        public void SubscribePrivateTopic(CtpResumeType resumeType)
        {
            CtpTraderNative.SubscribePrivateTopic(_instance, (int)resumeType);
        }

        ///订阅公共流。
        ///@param nResumeType 公共流重传方式  
        ///        THOST_TERT_RESTART:从本交易日开始重传
        ///        THOST_TERT_RESUME:从上次收到的续传
        ///        THOST_TERT_QUICK:只传送登录后公共流的内容
        ///@remark 该方法要在Init方法前调用。若不调用则不会收到公共流的数据。
        public void SubscribePublicTopic(CtpResumeType resumeType)
        {
            CtpTraderNative.SubscribePublicTopic(_instance, (int)resumeType);
        }

        ///客户端认证请求
        public int ReqAuthenticate(CtpReqAuthenticate reqAuthenticateField, int requestId)
        {
            return CtpTraderNative.ReqAuthenticate(_instance, reqAuthenticateField, requestId);
        }

        ///用户登录请求
        public int ReqUserLogin(CtpReqUserLogin reqUserLoginField, int requestId)
        {
            return CtpTraderNative.ReqUserLogin(_instance, reqUserLoginField, requestId);
        }

        ///登出请求
        public int ReqUserLogout(CtpUserLogout userLogout, int requestId)
        {
            return CtpTraderNative.ReqUserLogout(_instance, userLogout, requestId);
        }

        ///用户口令更新请求
        public int ReqUserPasswordUpdate(CtpUserPasswordUpdate userPasswordUpdate, int requestId)
        {
            return CtpTraderNative.ReqUserPasswordUpdate(_instance, userPasswordUpdate, requestId);
        }

        ///资金账户口令更新请求
        public int ReqTradingAccountPasswordUpdate(CtpTradingAccountPasswordUpdate tradingAccountPasswordUpdate, int requestId)
        {
            return CtpTraderNative.ReqTradingAccountPasswordUpdate(_instance, tradingAccountPasswordUpdate, requestId);
        }

        ///报单录入请求
        public int ReqOrderInsert(CtpInputOrder inputOrder, int requestId)
        {
            return CtpTraderNative.ReqOrderInsert(_instance, inputOrder, requestId);
        }

        ///预埋单录入请求
        public int ReqParkedOrderInsert(CtpParkedOrder parkedOrder, int requestId)
        {
            return CtpTraderNative.ReqParkedOrderInsert(_instance, parkedOrder, requestId);
        }

        ///预埋撤单录入请求
        public int ReqParkedOrderAction(CtpParkedOrderAction parkedOrderAction, int requestId)
        {
            return CtpTraderNative.ReqParkedOrderAction(_instance, parkedOrderAction, requestId);
        }

        ///报单操作请求
        public int ReqOrderAction(CtpInputOrderAction inputOrderAction, int requestId)
        {
            return CtpTraderNative.ReqOrderAction(_instance, inputOrderAction, requestId);
        }

        ///查询最大报单数量请求
        public int ReqQueryMaxOrderVolume(CtpQueryMaxOrderVolume queryMaxOrderVolume, int requestId)
        {
            return CtpTraderNative.ReqQueryMaxOrderVolume(_instance, queryMaxOrderVolume, requestId);
        }

        ///投资者结算结果确认
        public int ReqSettlementInfoConfirm(CtpSettlementInfoConfirm settlementInfoConfirm, int requestId)
        {
            return CtpTraderNative.ReqSettlementInfoConfirm(_instance, settlementInfoConfirm, requestId);
        }

        ///请求删除预埋单
        public int ReqRemoveParkedOrder(CtpRemoveParkedOrder removeParkedOrder, int requestId)
        {
            return CtpTraderNative.ReqRemoveParkedOrder(_instance, removeParkedOrder, requestId);
        }

        ///请求删除预埋撤单
        public int ReqRemoveParkedOrderAction(CtpRemoveParkedOrderAction removeParkedOrderAction, int requestId)
        {
            return CtpTraderNative.ReqRemoveParkedOrderAction(_instance, removeParkedOrderAction, requestId);
        }

        ///执行宣告录入请求
        public int ReqExecOrderInsert(CtpInputExecOrder inputExecOrder, int requestId)
        {
            return CtpTraderNative.ReqExecOrderInsert(_instance, inputExecOrder, requestId);
        }

        ///执行宣告操作请求
        public int ReqExecOrderAction(CtpInputExecOrderAction inputExecOrderAction, int requestId)
        {
            return CtpTraderNative.ReqExecOrderAction(_instance, inputExecOrderAction, requestId);
        }

        ///询价录入请求
        public int ReqForQuoteInsert(CtpInputForQuote inputForQuote, int requestId)
        {
            return CtpTraderNative.ReqForQuoteInsert(_instance, inputForQuote, requestId);
        }

        ///报价录入请求
        public int ReqQuoteInsert(CtpInputQuote inputQuote, int requestId)
        {
            return CtpTraderNative.ReqQuoteInsert(_instance, inputQuote, requestId);
        }

        ///报价操作请求
        public int ReqQuoteAction(CtpInputQuoteAction inputQuoteAction, int requestId)
        {
            return CtpTraderNative.ReqQuoteAction(_instance, inputQuoteAction, requestId);
        }

        ///批量报单操作请求
        public int ReqBatchOrderAction(CtpInputBatchOrderAction inputBatchOrderAction, int requestId)
        {
            return CtpTraderNative.ReqBatchOrderAction(_instance, inputBatchOrderAction, requestId);
        }

        ///申请组合录入请求
        public int ReqCombActionInsert(CtpInputCombAction inputCombAction, int requestId)
        {
            return CtpTraderNative.ReqCombActionInsert(_instance, inputCombAction, requestId);
        }

        ///请求查询报单
        public int ReqQryOrder(CtpQryOrder qryOrder, int requestId)
        {
            return CtpTraderNative.ReqQryOrder(_instance, qryOrder, requestId);
        }

        ///请求查询成交
        public int ReqQryTrade(CtpQryTrade qryTrade, int requestId)
        {
            return CtpTraderNative.ReqQryTrade(_instance, qryTrade, requestId);
        }

        ///请求查询投资者持仓
        public int ReqQryInvestorPosition(CtpQryInvestorPosition qryInvestorPosition, int requestId)
        {
            return CtpTraderNative.ReqQryInvestorPosition(_instance, qryInvestorPosition, requestId);
        }

        ///请求查询资金账户
        public int ReqQryTradingAccount(CtpQryTradingAccount qryTradingAccount, int requestId)
        {
            return CtpTraderNative.ReqQryTradingAccount(_instance, qryTradingAccount, requestId);
        }

        ///请求查询投资者
        public int ReqQryInvestor(CtpQryInvestor qryInvestor, int requestId)
        {
            return CtpTraderNative.ReqQryInvestor(_instance, qryInvestor, requestId);
        }

        ///请求查询交易编码
        public int ReqQryTradingCode(CtpQryTradingCode qryTradingCode, int requestId)
        {
            return CtpTraderNative.ReqQryTradingCode(_instance, qryTradingCode, requestId);
        }

        ///请求查询合约保证金率
        public int ReqQryInstrumentMarginRate(CtpQryInstrumentMarginRate qryInstrumentMarginRate, int requestId)
        {
            return CtpTraderNative.ReqQryInstrumentMarginRate(_instance, qryInstrumentMarginRate, requestId);
        }

        ///请求查询合约手续费率
        public int ReqQryInstrumentCommissionRate(CtpQryInstrumentCommissionRate qryInstrumentCommissionRate, int requestId)
        {
            return CtpTraderNative.ReqQryInstrumentCommissionRate(_instance, qryInstrumentCommissionRate, requestId);
        }

        ///请求查询交易所
        public int ReqQryExchange(CtpQryExchange qryExchange, int requestId)
        {
            return CtpTraderNative.ReqQryExchange(_instance, qryExchange, requestId);
        }

        ///请求查询产品
        public int ReqQryProduct(CtpQryProduct qryProduct, int requestId)
        {
            return CtpTraderNative.ReqQryProduct(_instance, qryProduct, requestId);
        }

        ///请求查询合约
        public int ReqQryInstrument(CtpQryInstrument qryInstrument, int requestId)
        {
            return CtpTraderNative.ReqQryInstrument(_instance, qryInstrument, requestId);
        }

        ///请求查询行情
        public int ReqQryDepthMarketData(CtpQryDepthMarketData qryDepthMarketData, int requestId)
        {
            return CtpTraderNative.ReqQryDepthMarketData(_instance, qryDepthMarketData, requestId);
        }

        ///请求查询投资者结算结果
        public int ReqQrySettlementInfo(CtpQrySettlementInfo qrySettlementInfo, int requestId)
        {
            return CtpTraderNative.ReqQrySettlementInfo(_instance, qrySettlementInfo, requestId);
        }

        ///请求查询转帐银行
        public int ReqQryTransferBank(CtpQryTransferBank qryTransferBank, int requestId)
        {
            return CtpTraderNative.ReqQryTransferBank(_instance, qryTransferBank, requestId);
        }

        ///请求查询投资者持仓明细
        public int ReqQryInvestorPositionDetail(CtpQryInvestorPositionDetail qryInvestorPositionDetail, int requestId)
        {
            return CtpTraderNative.ReqQryInvestorPositionDetail(_instance, qryInvestorPositionDetail, requestId);
        }

        ///请求查询客户通知
        public int ReqQryNotice(CtpQryNotice qryNotice, int requestId)
        {
            return CtpTraderNative.ReqQryNotice(_instance, qryNotice, requestId);
        }

        ///请求查询结算信息确认
        public int ReqQrySettlementInfoConfirm(CtpQrySettlementInfoConfirm qrySettlementInfoConfirm, int requestId)
        {
            return CtpTraderNative.ReqQrySettlementInfoConfirm(_instance, qrySettlementInfoConfirm, requestId);
        }

        ///请求查询投资者持仓明细
        public int ReqQryInvestorPositionCombineDetail(CtpQryInvestorPositionCombineDetail qryInvestorPositionCombineDetail, int requestId)
        {
            return CtpTraderNative.ReqQryInvestorPositionCombineDetail(_instance, qryInvestorPositionCombineDetail, requestId);
        }

        ///请求查询保证金监管系统经纪公司资金账户密钥
        public int ReqQryCFMMCTradingAccountKey(CtpQryCFMMCTradingAccountKey qryCFMMCTradingAccountKey, int requestId)
        {
            return CtpTraderNative.ReqQryCFMMCTradingAccountKey(_instance, qryCFMMCTradingAccountKey, requestId);
        }

        ///请求查询仓单折抵信息
        public int ReqQryEWarrantOffset(CtpQryEWarrantOffset qryEWarrantOffset, int requestId)
        {
            return CtpTraderNative.ReqQryEWarrantOffset(_instance, qryEWarrantOffset, requestId);
        }

        ///请求查询投资者品种/跨品种保证金
        public int ReqQryInvestorProductGroupMargin(CtpQryInvestorProductGroupMargin qryInvestorProductGroupMargin, int requestId)
        {
            return CtpTraderNative.ReqQryInvestorProductGroupMargin(_instance, qryInvestorProductGroupMargin, requestId);
        }

        ///请求查询交易所保证金率
        public int ReqQryExchangeMarginRate(CtpQryExchangeMarginRate qryExchangeMarginRate, int requestId)
        {
            return CtpTraderNative.ReqQryExchangeMarginRate(_instance, qryExchangeMarginRate, requestId);
        }

        ///请求查询交易所调整保证金率
        public int ReqQryExchangeMarginRateAdjust(CtpQryExchangeMarginRateAdjust qryExchangeMarginRateAdjust, int requestId)
        {
            return CtpTraderNative.ReqQryExchangeMarginRateAdjust(_instance, qryExchangeMarginRateAdjust, requestId);
        }

        ///请求查询汇率
        public int ReqQryExchangeRate(CtpQryExchangeRate qryExchangeRate, int requestId)
        {
            return CtpTraderNative.ReqQryExchangeRate(_instance, qryExchangeRate, requestId);
        }

        ///请求查询二级代理操作员银期权限
        public int ReqQrySecAgentACIDMap(CtpQrySecAgentACIDMap qrySecAgentACIDMap, int requestId)
        {
            return CtpTraderNative.ReqQrySecAgentACIDMap(_instance, qrySecAgentACIDMap, requestId);
        }

        ///请求查询产品报价汇率
        public int ReqQryProductExchRate(CtpQryProductExchRate qryProductExchRate, int requestId)
        {
            return CtpTraderNative.ReqQryProductExchRate(_instance, qryProductExchRate, requestId);
        }

        ///请求查询产品组
        public int ReqQryProductGroup(CtpQryProductGroup qryProductGroup, int requestId)
        {
            return CtpTraderNative.ReqQryProductGroup(_instance, qryProductGroup, requestId);
        }

        ///请求查询期权交易成本
        public int ReqQryOptionInstrTradeCost(CtpQryOptionInstrTradeCost qryOptionInstrTradeCost, int requestId)
        {
            return CtpTraderNative.ReqQryOptionInstrTradeCost(_instance, qryOptionInstrTradeCost, requestId);
        }

        ///请求查询期权合约手续费
        public int ReqQryOptionInstrCommRate(CtpQryOptionInstrCommRate qryOptionInstrCommRate, int requestId)
        {
            return CtpTraderNative.ReqQryOptionInstrCommRate(_instance, qryOptionInstrCommRate, requestId);
        }

        ///请求查询执行宣告
        public int ReqQryExecOrder(CtpQryExecOrder qryExecOrder, int requestId)
        {
            return CtpTraderNative.ReqQryExecOrder(_instance, qryExecOrder, requestId);
        }

        ///请求查询询价
        public int ReqQryForQuote(CtpQryForQuote qryForQuote, int requestId)
        {
            return CtpTraderNative.ReqQryForQuote(_instance, qryForQuote, requestId);
        }

        ///请求查询报价
        public int ReqQryQuote(CtpQryQuote qryQuote, int requestId)
        {
            return CtpTraderNative.ReqQryQuote(_instance, qryQuote, requestId);
        }

        ///请求查询组合合约安全系数
        public int ReqQryCombInstrumentGuard(CtpQryCombInstrumentGuard qryCombInstrumentGuard, int requestId)
        {
            return CtpTraderNative.ReqQryCombInstrumentGuard(_instance, qryCombInstrumentGuard, requestId);
        }

        ///请求查询申请组合
        public int ReqQryCombAction(CtpQryCombAction qryCombAction, int requestId)
        {
            return CtpTraderNative.ReqQryCombAction(_instance, qryCombAction, requestId);
        }

        ///请求查询转帐流水
        public int ReqQryTransferSerial(CtpQryTransferSerial qryTransferSerial, int requestId)
        {
            return CtpTraderNative.ReqQryTransferSerial(_instance, qryTransferSerial, requestId);
        }

        ///请求查询银期签约关系
        public int ReqQryAccountregister(CtpQryAccountregister qryAccountregister, int requestId)
        {
            return CtpTraderNative.ReqQryAccountregister(_instance, qryAccountregister, requestId);
        }

        ///请求查询签约银行
        public int ReqQryContractBank(CtpQryContractBank qryContractBank, int requestId)
        {
            return CtpTraderNative.ReqQryContractBank(_instance, qryContractBank, requestId);
        }

        ///请求查询预埋单
        public int ReqQryParkedOrder(CtpQryParkedOrder qryParkedOrder, int requestId)
        {
            return CtpTraderNative.ReqQryParkedOrder(_instance, qryParkedOrder, requestId);
        }

        ///请求查询预埋撤单
        public int ReqQryParkedOrderAction(CtpQryParkedOrderAction qryParkedOrderAction, int requestId)
        {
            return CtpTraderNative.ReqQryParkedOrderAction(_instance, qryParkedOrderAction, requestId);
        }

        ///请求查询交易通知
        public int ReqQryTradingNotice(CtpQryTradingNotice qryTradingNotice, int requestId)
        {
            return CtpTraderNative.ReqQryTradingNotice(_instance, qryTradingNotice, requestId);
        }

        ///请求查询经纪公司交易参数
        public int ReqQryBrokerTradingParams(CtpQryBrokerTradingParams qryBrokerTradingParams, int requestId)
        {
            return CtpTraderNative.ReqQryBrokerTradingParams(_instance, qryBrokerTradingParams, requestId);
        }

        ///请求查询经纪公司交易算法
        public int ReqQryBrokerTradingAlgos(CtpQryBrokerTradingAlgos qryBrokerTradingAlgos, int requestId)
        {
            return CtpTraderNative.ReqQryBrokerTradingAlgos(_instance, qryBrokerTradingAlgos, requestId);
        }

        ///请求查询监控中心用户令牌
        public int ReqQueryCFMMCTradingAccountToken(CtpQueryCFMMCTradingAccountToken queryCFMMCTradingAccountToken, int requestId)
        {
            return CtpTraderNative.ReqQueryCFMMCTradingAccountToken(_instance, queryCFMMCTradingAccountToken, requestId);
        }

        ///期货发起银行资金转期货请求
        public int ReqFromBankToFutureByFuture(CtpReqTransfer reqTransfer, int requestId)
        {
            return CtpTraderNative.ReqFromBankToFutureByFuture(_instance, reqTransfer, requestId);
        }

        ///期货发起期货资金转银行请求
        public int ReqFromFutureToBankByFuture(CtpReqTransfer reqTransfer, int requestId)
        {
            return CtpTraderNative.ReqFromFutureToBankByFuture(_instance, reqTransfer, requestId);
        }

        ///期货发起查询银行余额请求
        public int ReqQueryBankAccountMoneyByFuture(CtpReqQueryAccount reqQueryAccount, int requestId)
        {
            return CtpTraderNative.ReqQueryBankAccountMoneyByFuture(_instance, reqQueryAccount, requestId);
        }
    }
}