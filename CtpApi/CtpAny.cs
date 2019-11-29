using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace QuantBox.Sfit.Api
{
    public struct CtpAny
    {
        private readonly int? _intValue;
        private readonly object _refValue;
        
        public CtpAny(int data)
        {
            _intValue = data;
            _refValue = null;
        }
        
        public CtpAny(object data)
        {
            _intValue = null;
            _refValue = data;
        }
        
        public int? AsInt { get { return _intValue; } }
        
        public string AsString { get { return _refValue as string; } }
        
        public string[] AsStringArray { get { return _refValue as string[]; } }
        
        public CtpReqUserLogin AsReqUserLogin { get { return _refValue as CtpReqUserLogin; } }
        
        public CtpRspUserLogin AsRspUserLogin { get { return _refValue as CtpRspUserLogin; } }
        
        public CtpUserLogout AsUserLogout { get { return _refValue as CtpUserLogout; } }
        
        public CtpForceUserLogout AsForceUserLogout { get { return _refValue as CtpForceUserLogout; } }
        
        public CtpReqAuthenticate AsReqAuthenticate { get { return _refValue as CtpReqAuthenticate; } }
        
        public CtpRspAuthenticate AsRspAuthenticate { get { return _refValue as CtpRspAuthenticate; } }
        
        public CtpAuthenticationInfo AsAuthenticationInfo { get { return _refValue as CtpAuthenticationInfo; } }
        
        public CtpRspUserLogin2 AsRspUserLogin2 { get { return _refValue as CtpRspUserLogin2; } }
        
        public CtpTransferHeader AsTransferHeader { get { return _refValue as CtpTransferHeader; } }
        
        public CtpTransferBankToFutureReq AsTransferBankToFutureReq { get { return _refValue as CtpTransferBankToFutureReq; } }
        
        public CtpTransferBankToFutureRsp AsTransferBankToFutureRsp { get { return _refValue as CtpTransferBankToFutureRsp; } }
        
        public CtpTransferFutureToBankReq AsTransferFutureToBankReq { get { return _refValue as CtpTransferFutureToBankReq; } }
        
        public CtpTransferFutureToBankRsp AsTransferFutureToBankRsp { get { return _refValue as CtpTransferFutureToBankRsp; } }
        
        public CtpTransferQryBankReq AsTransferQryBankReq { get { return _refValue as CtpTransferQryBankReq; } }
        
        public CtpTransferQryBankRsp AsTransferQryBankRsp { get { return _refValue as CtpTransferQryBankRsp; } }
        
        public CtpTransferQryDetailReq AsTransferQryDetailReq { get { return _refValue as CtpTransferQryDetailReq; } }
        
        public CtpTransferQryDetailRsp AsTransferQryDetailRsp { get { return _refValue as CtpTransferQryDetailRsp; } }
        
        public CtpRspInfo AsRspInfo { get { return _refValue as CtpRspInfo; } }
        
        public CtpExchange AsExchange { get { return _refValue as CtpExchange; } }
        
        public CtpProduct AsProduct { get { return _refValue as CtpProduct; } }
        
        public CtpInstrument AsInstrument { get { return _refValue as CtpInstrument; } }
        
        public CtpBroker AsBroker { get { return _refValue as CtpBroker; } }
        
        public CtpTrader AsTrader { get { return _refValue as CtpTrader; } }
        
        public CtpInvestor AsInvestor { get { return _refValue as CtpInvestor; } }
        
        public CtpTradingCode AsTradingCode { get { return _refValue as CtpTradingCode; } }
        
        public CtpPartBroker AsPartBroker { get { return _refValue as CtpPartBroker; } }
        
        public CtpSuperUser AsSuperUser { get { return _refValue as CtpSuperUser; } }
        
        public CtpSuperUserFunction AsSuperUserFunction { get { return _refValue as CtpSuperUserFunction; } }
        
        public CtpInvestorGroup AsInvestorGroup { get { return _refValue as CtpInvestorGroup; } }
        
        public CtpTradingAccount AsTradingAccount { get { return _refValue as CtpTradingAccount; } }
        
        public CtpInvestorPosition AsInvestorPosition { get { return _refValue as CtpInvestorPosition; } }
        
        public CtpInstrumentMarginRate AsInstrumentMarginRate { get { return _refValue as CtpInstrumentMarginRate; } }
        
        public CtpInstrumentCommissionRate AsInstrumentCommissionRate { get { return _refValue as CtpInstrumentCommissionRate; } }
        
        public CtpDepthMarketData AsDepthMarketData { get { return _refValue as CtpDepthMarketData; } }
        
        public CtpInstrumentTradingRight AsInstrumentTradingRight { get { return _refValue as CtpInstrumentTradingRight; } }
        
        public CtpBrokerUser AsBrokerUser { get { return _refValue as CtpBrokerUser; } }
        
        public CtpBrokerUserPassword AsBrokerUserPassword { get { return _refValue as CtpBrokerUserPassword; } }
        
        public CtpBrokerUserFunction AsBrokerUserFunction { get { return _refValue as CtpBrokerUserFunction; } }
        
        public CtpTraderOffer AsTraderOffer { get { return _refValue as CtpTraderOffer; } }
        
        public CtpSettlementInfo AsSettlementInfo { get { return _refValue as CtpSettlementInfo; } }
        
        public CtpInstrumentMarginRateAdjust AsInstrumentMarginRateAdjust { get { return _refValue as CtpInstrumentMarginRateAdjust; } }
        
        public CtpExchangeMarginRate AsExchangeMarginRate { get { return _refValue as CtpExchangeMarginRate; } }
        
        public CtpExchangeMarginRateAdjust AsExchangeMarginRateAdjust { get { return _refValue as CtpExchangeMarginRateAdjust; } }
        
        public CtpExchangeRate AsExchangeRate { get { return _refValue as CtpExchangeRate; } }
        
        public CtpSettlementRef AsSettlementRef { get { return _refValue as CtpSettlementRef; } }
        
        public CtpCurrentTime AsCurrentTime { get { return _refValue as CtpCurrentTime; } }
        
        public CtpCommPhase AsCommPhase { get { return _refValue as CtpCommPhase; } }
        
        public CtpLoginInfo AsLoginInfo { get { return _refValue as CtpLoginInfo; } }
        
        public CtpLogoutAll AsLogoutAll { get { return _refValue as CtpLogoutAll; } }
        
        public CtpFrontStatus AsFrontStatus { get { return _refValue as CtpFrontStatus; } }
        
        public CtpUserPasswordUpdate AsUserPasswordUpdate { get { return _refValue as CtpUserPasswordUpdate; } }
        
        public CtpInputOrder AsInputOrder { get { return _refValue as CtpInputOrder; } }
        
        public CtpOrder AsOrder { get { return _refValue as CtpOrder; } }
        
        public CtpExchangeOrder AsExchangeOrder { get { return _refValue as CtpExchangeOrder; } }
        
        public CtpExchangeOrderInsertError AsExchangeOrderInsertError { get { return _refValue as CtpExchangeOrderInsertError; } }
        
        public CtpInputOrderAction AsInputOrderAction { get { return _refValue as CtpInputOrderAction; } }
        
        public CtpOrderAction AsOrderAction { get { return _refValue as CtpOrderAction; } }
        
        public CtpExchangeOrderAction AsExchangeOrderAction { get { return _refValue as CtpExchangeOrderAction; } }
        
        public CtpExchangeOrderActionError AsExchangeOrderActionError { get { return _refValue as CtpExchangeOrderActionError; } }
        
        public CtpExchangeTrade AsExchangeTrade { get { return _refValue as CtpExchangeTrade; } }
        
        public CtpTrade AsTrade { get { return _refValue as CtpTrade; } }
        
        public CtpUserSession AsUserSession { get { return _refValue as CtpUserSession; } }
        
        public CtpQueryMaxOrderVolume AsQueryMaxOrderVolume { get { return _refValue as CtpQueryMaxOrderVolume; } }
        
        public CtpSettlementInfoConfirm AsSettlementInfoConfirm { get { return _refValue as CtpSettlementInfoConfirm; } }
        
        public CtpSyncDeposit AsSyncDeposit { get { return _refValue as CtpSyncDeposit; } }
        
        public CtpSyncFundMortgage AsSyncFundMortgage { get { return _refValue as CtpSyncFundMortgage; } }
        
        public CtpBrokerSync AsBrokerSync { get { return _refValue as CtpBrokerSync; } }
        
        public CtpSyncingInvestor AsSyncingInvestor { get { return _refValue as CtpSyncingInvestor; } }
        
        public CtpSyncingTradingCode AsSyncingTradingCode { get { return _refValue as CtpSyncingTradingCode; } }
        
        public CtpSyncingInvestorGroup AsSyncingInvestorGroup { get { return _refValue as CtpSyncingInvestorGroup; } }
        
        public CtpSyncingTradingAccount AsSyncingTradingAccount { get { return _refValue as CtpSyncingTradingAccount; } }
        
        public CtpSyncingInvestorPosition AsSyncingInvestorPosition { get { return _refValue as CtpSyncingInvestorPosition; } }
        
        public CtpSyncingInstrumentMarginRate AsSyncingInstrumentMarginRate { get { return _refValue as CtpSyncingInstrumentMarginRate; } }
        
        public CtpSyncingInstrumentCommissionRate AsSyncingInstrumentCommissionRate { get { return _refValue as CtpSyncingInstrumentCommissionRate; } }
        
        public CtpSyncingInstrumentTradingRight AsSyncingInstrumentTradingRight { get { return _refValue as CtpSyncingInstrumentTradingRight; } }
        
        public CtpQryOrder AsQryOrder { get { return _refValue as CtpQryOrder; } }
        
        public CtpQryTrade AsQryTrade { get { return _refValue as CtpQryTrade; } }
        
        public CtpQryInvestorPosition AsQryInvestorPosition { get { return _refValue as CtpQryInvestorPosition; } }
        
        public CtpQryTradingAccount AsQryTradingAccount { get { return _refValue as CtpQryTradingAccount; } }
        
        public CtpQryInvestor AsQryInvestor { get { return _refValue as CtpQryInvestor; } }
        
        public CtpQryTradingCode AsQryTradingCode { get { return _refValue as CtpQryTradingCode; } }
        
        public CtpQryInvestorGroup AsQryInvestorGroup { get { return _refValue as CtpQryInvestorGroup; } }
        
        public CtpQryInstrumentMarginRate AsQryInstrumentMarginRate { get { return _refValue as CtpQryInstrumentMarginRate; } }
        
        public CtpQryInstrumentCommissionRate AsQryInstrumentCommissionRate { get { return _refValue as CtpQryInstrumentCommissionRate; } }
        
        public CtpQryInstrumentTradingRight AsQryInstrumentTradingRight { get { return _refValue as CtpQryInstrumentTradingRight; } }
        
        public CtpQryBroker AsQryBroker { get { return _refValue as CtpQryBroker; } }
        
        public CtpQryTrader AsQryTrader { get { return _refValue as CtpQryTrader; } }
        
        public CtpQrySuperUserFunction AsQrySuperUserFunction { get { return _refValue as CtpQrySuperUserFunction; } }
        
        public CtpQryUserSession AsQryUserSession { get { return _refValue as CtpQryUserSession; } }
        
        public CtpQryPartBroker AsQryPartBroker { get { return _refValue as CtpQryPartBroker; } }
        
        public CtpQryFrontStatus AsQryFrontStatus { get { return _refValue as CtpQryFrontStatus; } }
        
        public CtpQryExchangeOrder AsQryExchangeOrder { get { return _refValue as CtpQryExchangeOrder; } }
        
        public CtpQryOrderAction AsQryOrderAction { get { return _refValue as CtpQryOrderAction; } }
        
        public CtpQryExchangeOrderAction AsQryExchangeOrderAction { get { return _refValue as CtpQryExchangeOrderAction; } }
        
        public CtpQrySuperUser AsQrySuperUser { get { return _refValue as CtpQrySuperUser; } }
        
        public CtpQryExchange AsQryExchange { get { return _refValue as CtpQryExchange; } }
        
        public CtpQryProduct AsQryProduct { get { return _refValue as CtpQryProduct; } }
        
        public CtpQryInstrument AsQryInstrument { get { return _refValue as CtpQryInstrument; } }
        
        public CtpQryDepthMarketData AsQryDepthMarketData { get { return _refValue as CtpQryDepthMarketData; } }
        
        public CtpQryBrokerUser AsQryBrokerUser { get { return _refValue as CtpQryBrokerUser; } }
        
        public CtpQryBrokerUserFunction AsQryBrokerUserFunction { get { return _refValue as CtpQryBrokerUserFunction; } }
        
        public CtpQryTraderOffer AsQryTraderOffer { get { return _refValue as CtpQryTraderOffer; } }
        
        public CtpQrySyncDeposit AsQrySyncDeposit { get { return _refValue as CtpQrySyncDeposit; } }
        
        public CtpQrySettlementInfo AsQrySettlementInfo { get { return _refValue as CtpQrySettlementInfo; } }
        
        public CtpQryExchangeMarginRate AsQryExchangeMarginRate { get { return _refValue as CtpQryExchangeMarginRate; } }
        
        public CtpQryExchangeMarginRateAdjust AsQryExchangeMarginRateAdjust { get { return _refValue as CtpQryExchangeMarginRateAdjust; } }
        
        public CtpQryExchangeRate AsQryExchangeRate { get { return _refValue as CtpQryExchangeRate; } }
        
        public CtpQrySyncFundMortgage AsQrySyncFundMortgage { get { return _refValue as CtpQrySyncFundMortgage; } }
        
        public CtpQryHisOrder AsQryHisOrder { get { return _refValue as CtpQryHisOrder; } }
        
        public CtpOptionInstrMiniMargin AsOptionInstrMiniMargin { get { return _refValue as CtpOptionInstrMiniMargin; } }
        
        public CtpOptionInstrMarginAdjust AsOptionInstrMarginAdjust { get { return _refValue as CtpOptionInstrMarginAdjust; } }
        
        public CtpOptionInstrCommRate AsOptionInstrCommRate { get { return _refValue as CtpOptionInstrCommRate; } }
        
        public CtpOptionInstrTradeCost AsOptionInstrTradeCost { get { return _refValue as CtpOptionInstrTradeCost; } }
        
        public CtpQryOptionInstrTradeCost AsQryOptionInstrTradeCost { get { return _refValue as CtpQryOptionInstrTradeCost; } }
        
        public CtpQryOptionInstrCommRate AsQryOptionInstrCommRate { get { return _refValue as CtpQryOptionInstrCommRate; } }
        
        public CtpIndexPrice AsIndexPrice { get { return _refValue as CtpIndexPrice; } }
        
        public CtpInputExecOrder AsInputExecOrder { get { return _refValue as CtpInputExecOrder; } }
        
        public CtpInputExecOrderAction AsInputExecOrderAction { get { return _refValue as CtpInputExecOrderAction; } }
        
        public CtpExecOrder AsExecOrder { get { return _refValue as CtpExecOrder; } }
        
        public CtpExecOrderAction AsExecOrderAction { get { return _refValue as CtpExecOrderAction; } }
        
        public CtpQryExecOrder AsQryExecOrder { get { return _refValue as CtpQryExecOrder; } }
        
        public CtpExchangeExecOrder AsExchangeExecOrder { get { return _refValue as CtpExchangeExecOrder; } }
        
        public CtpQryExchangeExecOrder AsQryExchangeExecOrder { get { return _refValue as CtpQryExchangeExecOrder; } }
        
        public CtpQryExecOrderAction AsQryExecOrderAction { get { return _refValue as CtpQryExecOrderAction; } }
        
        public CtpExchangeExecOrderAction AsExchangeExecOrderAction { get { return _refValue as CtpExchangeExecOrderAction; } }
        
        public CtpQryExchangeExecOrderAction AsQryExchangeExecOrderAction { get { return _refValue as CtpQryExchangeExecOrderAction; } }
        
        public CtpErrExecOrder AsErrExecOrder { get { return _refValue as CtpErrExecOrder; } }
        
        public CtpQryErrExecOrder AsQryErrExecOrder { get { return _refValue as CtpQryErrExecOrder; } }
        
        public CtpErrExecOrderAction AsErrExecOrderAction { get { return _refValue as CtpErrExecOrderAction; } }
        
        public CtpQryErrExecOrderAction AsQryErrExecOrderAction { get { return _refValue as CtpQryErrExecOrderAction; } }
        
        public CtpOptionInstrTradingRight AsOptionInstrTradingRight { get { return _refValue as CtpOptionInstrTradingRight; } }
        
        public CtpQryOptionInstrTradingRight AsQryOptionInstrTradingRight { get { return _refValue as CtpQryOptionInstrTradingRight; } }
        
        public CtpInputForQuote AsInputForQuote { get { return _refValue as CtpInputForQuote; } }
        
        public CtpForQuote AsForQuote { get { return _refValue as CtpForQuote; } }
        
        public CtpQryForQuote AsQryForQuote { get { return _refValue as CtpQryForQuote; } }
        
        public CtpExchangeForQuote AsExchangeForQuote { get { return _refValue as CtpExchangeForQuote; } }
        
        public CtpQryExchangeForQuote AsQryExchangeForQuote { get { return _refValue as CtpQryExchangeForQuote; } }
        
        public CtpInputQuote AsInputQuote { get { return _refValue as CtpInputQuote; } }
        
        public CtpInputQuoteAction AsInputQuoteAction { get { return _refValue as CtpInputQuoteAction; } }
        
        public CtpQuote AsQuote { get { return _refValue as CtpQuote; } }
        
        public CtpQuoteAction AsQuoteAction { get { return _refValue as CtpQuoteAction; } }
        
        public CtpQryQuote AsQryQuote { get { return _refValue as CtpQryQuote; } }
        
        public CtpExchangeQuote AsExchangeQuote { get { return _refValue as CtpExchangeQuote; } }
        
        public CtpQryExchangeQuote AsQryExchangeQuote { get { return _refValue as CtpQryExchangeQuote; } }
        
        public CtpQryQuoteAction AsQryQuoteAction { get { return _refValue as CtpQryQuoteAction; } }
        
        public CtpExchangeQuoteAction AsExchangeQuoteAction { get { return _refValue as CtpExchangeQuoteAction; } }
        
        public CtpQryExchangeQuoteAction AsQryExchangeQuoteAction { get { return _refValue as CtpQryExchangeQuoteAction; } }
        
        public CtpOptionInstrDelta AsOptionInstrDelta { get { return _refValue as CtpOptionInstrDelta; } }
        
        public CtpForQuoteRsp AsForQuoteRsp { get { return _refValue as CtpForQuoteRsp; } }
        
        public CtpStrikeOffset AsStrikeOffset { get { return _refValue as CtpStrikeOffset; } }
        
        public CtpQryStrikeOffset AsQryStrikeOffset { get { return _refValue as CtpQryStrikeOffset; } }
        
        public CtpInputBatchOrderAction AsInputBatchOrderAction { get { return _refValue as CtpInputBatchOrderAction; } }
        
        public CtpBatchOrderAction AsBatchOrderAction { get { return _refValue as CtpBatchOrderAction; } }
        
        public CtpExchangeBatchOrderAction AsExchangeBatchOrderAction { get { return _refValue as CtpExchangeBatchOrderAction; } }
        
        public CtpQryBatchOrderAction AsQryBatchOrderAction { get { return _refValue as CtpQryBatchOrderAction; } }
        
        public CtpCombInstrumentGuard AsCombInstrumentGuard { get { return _refValue as CtpCombInstrumentGuard; } }
        
        public CtpQryCombInstrumentGuard AsQryCombInstrumentGuard { get { return _refValue as CtpQryCombInstrumentGuard; } }
        
        public CtpInputCombAction AsInputCombAction { get { return _refValue as CtpInputCombAction; } }
        
        public CtpCombAction AsCombAction { get { return _refValue as CtpCombAction; } }
        
        public CtpQryCombAction AsQryCombAction { get { return _refValue as CtpQryCombAction; } }
        
        public CtpExchangeCombAction AsExchangeCombAction { get { return _refValue as CtpExchangeCombAction; } }
        
        public CtpQryExchangeCombAction AsQryExchangeCombAction { get { return _refValue as CtpQryExchangeCombAction; } }
        
        public CtpProductExchRate AsProductExchRate { get { return _refValue as CtpProductExchRate; } }
        
        public CtpQryProductExchRate AsQryProductExchRate { get { return _refValue as CtpQryProductExchRate; } }
        
        public CtpQryForQuoteParam AsQryForQuoteParam { get { return _refValue as CtpQryForQuoteParam; } }
        
        public CtpForQuoteParam AsForQuoteParam { get { return _refValue as CtpForQuoteParam; } }
        
        public CtpMMOptionInstrCommRate AsMMOptionInstrCommRate { get { return _refValue as CtpMMOptionInstrCommRate; } }
        
        public CtpQryMMOptionInstrCommRate AsQryMMOptionInstrCommRate { get { return _refValue as CtpQryMMOptionInstrCommRate; } }
        
        public CtpMMInstrumentCommissionRate AsMMInstrumentCommissionRate { get { return _refValue as CtpMMInstrumentCommissionRate; } }
        
        public CtpQryMMInstrumentCommissionRate AsQryMMInstrumentCommissionRate { get { return _refValue as CtpQryMMInstrumentCommissionRate; } }
        
        public CtpInstrumentOrderCommRate AsInstrumentOrderCommRate { get { return _refValue as CtpInstrumentOrderCommRate; } }
        
        public CtpQryInstrumentOrderCommRate AsQryInstrumentOrderCommRate { get { return _refValue as CtpQryInstrumentOrderCommRate; } }
        
        public CtpTradeParam AsTradeParam { get { return _refValue as CtpTradeParam; } }
        
        public CtpInstrumentMarginRateUL AsInstrumentMarginRateUL { get { return _refValue as CtpInstrumentMarginRateUL; } }
        
        public CtpFutureLimitPosiParam AsFutureLimitPosiParam { get { return _refValue as CtpFutureLimitPosiParam; } }
        
        public CtpLoginForbiddenIP AsLoginForbiddenIP { get { return _refValue as CtpLoginForbiddenIP; } }
        
        public CtpIPList AsIPList { get { return _refValue as CtpIPList; } }
        
        public CtpInputOptionSelfClose AsInputOptionSelfClose { get { return _refValue as CtpInputOptionSelfClose; } }
        
        public CtpInputOptionSelfCloseAction AsInputOptionSelfCloseAction { get { return _refValue as CtpInputOptionSelfCloseAction; } }
        
        public CtpOptionSelfClose AsOptionSelfClose { get { return _refValue as CtpOptionSelfClose; } }
        
        public CtpOptionSelfCloseAction AsOptionSelfCloseAction { get { return _refValue as CtpOptionSelfCloseAction; } }
        
        public CtpQryOptionSelfClose AsQryOptionSelfClose { get { return _refValue as CtpQryOptionSelfClose; } }
        
        public CtpExchangeOptionSelfClose AsExchangeOptionSelfClose { get { return _refValue as CtpExchangeOptionSelfClose; } }
        
        public CtpQryOptionSelfCloseAction AsQryOptionSelfCloseAction { get { return _refValue as CtpQryOptionSelfCloseAction; } }
        
        public CtpExchangeOptionSelfCloseAction AsExchangeOptionSelfCloseAction { get { return _refValue as CtpExchangeOptionSelfCloseAction; } }
        
        public CtpSyncDelaySwap AsSyncDelaySwap { get { return _refValue as CtpSyncDelaySwap; } }
        
        public CtpQrySyncDelaySwap AsQrySyncDelaySwap { get { return _refValue as CtpQrySyncDelaySwap; } }
        
        public CtpInvestUnit AsInvestUnit { get { return _refValue as CtpInvestUnit; } }
        
        public CtpQryInvestUnit AsQryInvestUnit { get { return _refValue as CtpQryInvestUnit; } }
        
        public CtpSecAgentCheckMode AsSecAgentCheckMode { get { return _refValue as CtpSecAgentCheckMode; } }
        
        public CtpSecAgentTradeInfo AsSecAgentTradeInfo { get { return _refValue as CtpSecAgentTradeInfo; } }
        
        public CtpMarketData AsMarketData { get { return _refValue as CtpMarketData; } }
        
        public CtpMarketDataBase AsMarketDataBase { get { return _refValue as CtpMarketDataBase; } }
        
        public CtpMarketDataStatic AsMarketDataStatic { get { return _refValue as CtpMarketDataStatic; } }
        
        public CtpMarketDataLastMatch AsMarketDataLastMatch { get { return _refValue as CtpMarketDataLastMatch; } }
        
        public CtpMarketDataBestPrice AsMarketDataBestPrice { get { return _refValue as CtpMarketDataBestPrice; } }
        
        public CtpMarketDataBid23 AsMarketDataBid23 { get { return _refValue as CtpMarketDataBid23; } }
        
        public CtpMarketDataAsk23 AsMarketDataAsk23 { get { return _refValue as CtpMarketDataAsk23; } }
        
        public CtpMarketDataBid45 AsMarketDataBid45 { get { return _refValue as CtpMarketDataBid45; } }
        
        public CtpMarketDataAsk45 AsMarketDataAsk45 { get { return _refValue as CtpMarketDataAsk45; } }
        
        public CtpMarketDataUpdateTime AsMarketDataUpdateTime { get { return _refValue as CtpMarketDataUpdateTime; } }
        
        public CtpMarketDataExchange AsMarketDataExchange { get { return _refValue as CtpMarketDataExchange; } }
        
        public CtpSpecificInstrument AsSpecificInstrument { get { return _refValue as CtpSpecificInstrument; } }
        
        public CtpInstrumentStatus AsInstrumentStatus { get { return _refValue as CtpInstrumentStatus; } }
        
        public CtpQryInstrumentStatus AsQryInstrumentStatus { get { return _refValue as CtpQryInstrumentStatus; } }
        
        public CtpInvestorAccount AsInvestorAccount { get { return _refValue as CtpInvestorAccount; } }
        
        public CtpPositionProfitAlgorithm AsPositionProfitAlgorithm { get { return _refValue as CtpPositionProfitAlgorithm; } }
        
        public CtpDiscount AsDiscount { get { return _refValue as CtpDiscount; } }
        
        public CtpQryTransferBank AsQryTransferBank { get { return _refValue as CtpQryTransferBank; } }
        
        public CtpTransferBank AsTransferBank { get { return _refValue as CtpTransferBank; } }
        
        public CtpQryInvestorPositionDetail AsQryInvestorPositionDetail { get { return _refValue as CtpQryInvestorPositionDetail; } }
        
        public CtpInvestorPositionDetail AsInvestorPositionDetail { get { return _refValue as CtpInvestorPositionDetail; } }
        
        public CtpTradingAccountPassword AsTradingAccountPassword { get { return _refValue as CtpTradingAccountPassword; } }
        
        public CtpMDTraderOffer AsMDTraderOffer { get { return _refValue as CtpMDTraderOffer; } }
        
        public CtpQryMDTraderOffer AsQryMDTraderOffer { get { return _refValue as CtpQryMDTraderOffer; } }
        
        public CtpQryNotice AsQryNotice { get { return _refValue as CtpQryNotice; } }
        
        public CtpNotice AsNotice { get { return _refValue as CtpNotice; } }
        
        public CtpUserRight AsUserRight { get { return _refValue as CtpUserRight; } }
        
        public CtpQrySettlementInfoConfirm AsQrySettlementInfoConfirm { get { return _refValue as CtpQrySettlementInfoConfirm; } }
        
        public CtpLoadSettlementInfo AsLoadSettlementInfo { get { return _refValue as CtpLoadSettlementInfo; } }
        
        public CtpBrokerWithdrawAlgorithm AsBrokerWithdrawAlgorithm { get { return _refValue as CtpBrokerWithdrawAlgorithm; } }
        
        public CtpTradingAccountPasswordUpdateV1 AsTradingAccountPasswordUpdateV1 { get { return _refValue as CtpTradingAccountPasswordUpdateV1; } }
        
        public CtpTradingAccountPasswordUpdate AsTradingAccountPasswordUpdate { get { return _refValue as CtpTradingAccountPasswordUpdate; } }
        
        public CtpQryCombinationLeg AsQryCombinationLeg { get { return _refValue as CtpQryCombinationLeg; } }
        
        public CtpQrySyncStatus AsQrySyncStatus { get { return _refValue as CtpQrySyncStatus; } }
        
        public CtpCombinationLeg AsCombinationLeg { get { return _refValue as CtpCombinationLeg; } }
        
        public CtpSyncStatus AsSyncStatus { get { return _refValue as CtpSyncStatus; } }
        
        public CtpQryLinkMan AsQryLinkMan { get { return _refValue as CtpQryLinkMan; } }
        
        public CtpLinkMan AsLinkMan { get { return _refValue as CtpLinkMan; } }
        
        public CtpQryBrokerUserEvent AsQryBrokerUserEvent { get { return _refValue as CtpQryBrokerUserEvent; } }
        
        public CtpBrokerUserEvent AsBrokerUserEvent { get { return _refValue as CtpBrokerUserEvent; } }
        
        public CtpQryContractBank AsQryContractBank { get { return _refValue as CtpQryContractBank; } }
        
        public CtpContractBank AsContractBank { get { return _refValue as CtpContractBank; } }
        
        public CtpInvestorPositionCombineDetail AsInvestorPositionCombineDetail { get { return _refValue as CtpInvestorPositionCombineDetail; } }
        
        public CtpParkedOrder AsParkedOrder { get { return _refValue as CtpParkedOrder; } }
        
        public CtpParkedOrderAction AsParkedOrderAction { get { return _refValue as CtpParkedOrderAction; } }
        
        public CtpQryParkedOrder AsQryParkedOrder { get { return _refValue as CtpQryParkedOrder; } }
        
        public CtpQryParkedOrderAction AsQryParkedOrderAction { get { return _refValue as CtpQryParkedOrderAction; } }
        
        public CtpRemoveParkedOrder AsRemoveParkedOrder { get { return _refValue as CtpRemoveParkedOrder; } }
        
        public CtpRemoveParkedOrderAction AsRemoveParkedOrderAction { get { return _refValue as CtpRemoveParkedOrderAction; } }
        
        public CtpInvestorWithdrawAlgorithm AsInvestorWithdrawAlgorithm { get { return _refValue as CtpInvestorWithdrawAlgorithm; } }
        
        public CtpQryInvestorPositionCombineDetail AsQryInvestorPositionCombineDetail { get { return _refValue as CtpQryInvestorPositionCombineDetail; } }
        
        public CtpMarketDataAveragePrice AsMarketDataAveragePrice { get { return _refValue as CtpMarketDataAveragePrice; } }
        
        public CtpVerifyInvestorPassword AsVerifyInvestorPassword { get { return _refValue as CtpVerifyInvestorPassword; } }
        
        public CtpUserIP AsUserIP { get { return _refValue as CtpUserIP; } }
        
        public CtpTradingNoticeInfo AsTradingNoticeInfo { get { return _refValue as CtpTradingNoticeInfo; } }
        
        public CtpTradingNotice AsTradingNotice { get { return _refValue as CtpTradingNotice; } }
        
        public CtpQryTradingNotice AsQryTradingNotice { get { return _refValue as CtpQryTradingNotice; } }
        
        public CtpQryErrOrder AsQryErrOrder { get { return _refValue as CtpQryErrOrder; } }
        
        public CtpErrOrder AsErrOrder { get { return _refValue as CtpErrOrder; } }
        
        public CtpErrorConditionalOrder AsErrorConditionalOrder { get { return _refValue as CtpErrorConditionalOrder; } }
        
        public CtpQryErrOrderAction AsQryErrOrderAction { get { return _refValue as CtpQryErrOrderAction; } }
        
        public CtpErrOrderAction AsErrOrderAction { get { return _refValue as CtpErrOrderAction; } }
        
        public CtpQryExchangeSequence AsQryExchangeSequence { get { return _refValue as CtpQryExchangeSequence; } }
        
        public CtpExchangeSequence AsExchangeSequence { get { return _refValue as CtpExchangeSequence; } }
        
        public CtpQueryMaxOrderVolumeWithPrice AsQueryMaxOrderVolumeWithPrice { get { return _refValue as CtpQueryMaxOrderVolumeWithPrice; } }
        
        public CtpQryBrokerTradingParams AsQryBrokerTradingParams { get { return _refValue as CtpQryBrokerTradingParams; } }
        
        public CtpBrokerTradingParams AsBrokerTradingParams { get { return _refValue as CtpBrokerTradingParams; } }
        
        public CtpQryBrokerTradingAlgos AsQryBrokerTradingAlgos { get { return _refValue as CtpQryBrokerTradingAlgos; } }
        
        public CtpBrokerTradingAlgos AsBrokerTradingAlgos { get { return _refValue as CtpBrokerTradingAlgos; } }
        
        public CtpQueryBrokerDeposit AsQueryBrokerDeposit { get { return _refValue as CtpQueryBrokerDeposit; } }
        
        public CtpBrokerDeposit AsBrokerDeposit { get { return _refValue as CtpBrokerDeposit; } }
        
        public CtpQryCFMMCBrokerKey AsQryCFMMCBrokerKey { get { return _refValue as CtpQryCFMMCBrokerKey; } }
        
        public CtpCFMMCBrokerKey AsCFMMCBrokerKey { get { return _refValue as CtpCFMMCBrokerKey; } }
        
        public CtpCFMMCTradingAccountKey AsCFMMCTradingAccountKey { get { return _refValue as CtpCFMMCTradingAccountKey; } }
        
        public CtpQryCFMMCTradingAccountKey AsQryCFMMCTradingAccountKey { get { return _refValue as CtpQryCFMMCTradingAccountKey; } }
        
        public CtpBrokerUserOTPParam AsBrokerUserOTPParam { get { return _refValue as CtpBrokerUserOTPParam; } }
        
        public CtpManualSyncBrokerUserOTP AsManualSyncBrokerUserOTP { get { return _refValue as CtpManualSyncBrokerUserOTP; } }
        
        public CtpCommRateModel AsCommRateModel { get { return _refValue as CtpCommRateModel; } }
        
        public CtpQryCommRateModel AsQryCommRateModel { get { return _refValue as CtpQryCommRateModel; } }
        
        public CtpMarginModel AsMarginModel { get { return _refValue as CtpMarginModel; } }
        
        public CtpQryMarginModel AsQryMarginModel { get { return _refValue as CtpQryMarginModel; } }
        
        public CtpEWarrantOffset AsEWarrantOffset { get { return _refValue as CtpEWarrantOffset; } }
        
        public CtpQryEWarrantOffset AsQryEWarrantOffset { get { return _refValue as CtpQryEWarrantOffset; } }
        
        public CtpQryInvestorProductGroupMargin AsQryInvestorProductGroupMargin { get { return _refValue as CtpQryInvestorProductGroupMargin; } }
        
        public CtpInvestorProductGroupMargin AsInvestorProductGroupMargin { get { return _refValue as CtpInvestorProductGroupMargin; } }
        
        public CtpQueryCFMMCTradingAccountToken AsQueryCFMMCTradingAccountToken { get { return _refValue as CtpQueryCFMMCTradingAccountToken; } }
        
        public CtpCFMMCTradingAccountToken AsCFMMCTradingAccountToken { get { return _refValue as CtpCFMMCTradingAccountToken; } }
        
        public CtpQryProductGroup AsQryProductGroup { get { return _refValue as CtpQryProductGroup; } }
        
        public CtpProductGroup AsProductGroup { get { return _refValue as CtpProductGroup; } }
        
        public CtpBulletin AsBulletin { get { return _refValue as CtpBulletin; } }
        
        public CtpQryBulletin AsQryBulletin { get { return _refValue as CtpQryBulletin; } }
        
        public CtpReqOpenAccount AsReqOpenAccount { get { return _refValue as CtpReqOpenAccount; } }
        
        public CtpReqCancelAccount AsReqCancelAccount { get { return _refValue as CtpReqCancelAccount; } }
        
        public CtpReqChangeAccount AsReqChangeAccount { get { return _refValue as CtpReqChangeAccount; } }
        
        public CtpReqTransfer AsReqTransfer { get { return _refValue as CtpReqTransfer; } }
        
        public CtpRspTransfer AsRspTransfer { get { return _refValue as CtpRspTransfer; } }
        
        public CtpReqRepeal AsReqRepeal { get { return _refValue as CtpReqRepeal; } }
        
        public CtpRspRepeal AsRspRepeal { get { return _refValue as CtpRspRepeal; } }
        
        public CtpReqQueryAccount AsReqQueryAccount { get { return _refValue as CtpReqQueryAccount; } }
        
        public CtpRspQueryAccount AsRspQueryAccount { get { return _refValue as CtpRspQueryAccount; } }
        
        public CtpFutureSignIO AsFutureSignIO { get { return _refValue as CtpFutureSignIO; } }
        
        public CtpRspFutureSignIn AsRspFutureSignIn { get { return _refValue as CtpRspFutureSignIn; } }
        
        public CtpReqFutureSignOut AsReqFutureSignOut { get { return _refValue as CtpReqFutureSignOut; } }
        
        public CtpRspFutureSignOut AsRspFutureSignOut { get { return _refValue as CtpRspFutureSignOut; } }
        
        public CtpReqQueryTradeResultBySerial AsReqQueryTradeResultBySerial { get { return _refValue as CtpReqQueryTradeResultBySerial; } }
        
        public CtpRspQueryTradeResultBySerial AsRspQueryTradeResultBySerial { get { return _refValue as CtpRspQueryTradeResultBySerial; } }
        
        public CtpReqDayEndFileReady AsReqDayEndFileReady { get { return _refValue as CtpReqDayEndFileReady; } }
        
        public CtpReturnResult AsReturnResult { get { return _refValue as CtpReturnResult; } }
        
        public CtpVerifyFuturePassword AsVerifyFuturePassword { get { return _refValue as CtpVerifyFuturePassword; } }
        
        public CtpVerifyCustInfo AsVerifyCustInfo { get { return _refValue as CtpVerifyCustInfo; } }
        
        public CtpVerifyFuturePasswordAndCustInfo AsVerifyFuturePasswordAndCustInfo { get { return _refValue as CtpVerifyFuturePasswordAndCustInfo; } }
        
        public CtpDepositResultInform AsDepositResultInform { get { return _refValue as CtpDepositResultInform; } }
        
        public CtpReqSyncKey AsReqSyncKey { get { return _refValue as CtpReqSyncKey; } }
        
        public CtpRspSyncKey AsRspSyncKey { get { return _refValue as CtpRspSyncKey; } }
        
        public CtpNotifyQueryAccount AsNotifyQueryAccount { get { return _refValue as CtpNotifyQueryAccount; } }
        
        public CtpTransferSerial AsTransferSerial { get { return _refValue as CtpTransferSerial; } }
        
        public CtpQryTransferSerial AsQryTransferSerial { get { return _refValue as CtpQryTransferSerial; } }
        
        public CtpNotifyFutureSignIn AsNotifyFutureSignIn { get { return _refValue as CtpNotifyFutureSignIn; } }
        
        public CtpNotifyFutureSignOut AsNotifyFutureSignOut { get { return _refValue as CtpNotifyFutureSignOut; } }
        
        public CtpNotifySyncKey AsNotifySyncKey { get { return _refValue as CtpNotifySyncKey; } }
        
        public CtpQryAccountregister AsQryAccountregister { get { return _refValue as CtpQryAccountregister; } }
        
        public CtpAccountregister AsAccountregister { get { return _refValue as CtpAccountregister; } }
        
        public CtpOpenAccount AsOpenAccount { get { return _refValue as CtpOpenAccount; } }
        
        public CtpCancelAccount AsCancelAccount { get { return _refValue as CtpCancelAccount; } }
        
        public CtpChangeAccount AsChangeAccount { get { return _refValue as CtpChangeAccount; } }
        
        public CtpSecAgentACIDMap AsSecAgentACIDMap { get { return _refValue as CtpSecAgentACIDMap; } }
        
        public CtpQrySecAgentACIDMap AsQrySecAgentACIDMap { get { return _refValue as CtpQrySecAgentACIDMap; } }
        
        public CtpUserRightsAssign AsUserRightsAssign { get { return _refValue as CtpUserRightsAssign; } }
        
        public CtpBrokerUserRightAssign AsBrokerUserRightAssign { get { return _refValue as CtpBrokerUserRightAssign; } }
        
        public CtpDRTransfer AsDRTransfer { get { return _refValue as CtpDRTransfer; } }
        
        public CtpFensUserInfo AsFensUserInfo { get { return _refValue as CtpFensUserInfo; } }
        
        public CtpCurrTransferIdentity AsCurrTransferIdentity { get { return _refValue as CtpCurrTransferIdentity; } }
        
        public CtpLoginForbiddenUser AsLoginForbiddenUser { get { return _refValue as CtpLoginForbiddenUser; } }
        
        public CtpQryLoginForbiddenUser AsQryLoginForbiddenUser { get { return _refValue as CtpQryLoginForbiddenUser; } }
        
        public CtpMulticastGroupInfo AsMulticastGroupInfo { get { return _refValue as CtpMulticastGroupInfo; } }
        
        public CtpTradingAccountReserve AsTradingAccountReserve { get { return _refValue as CtpTradingAccountReserve; } }
        
        public CtpQryLoginForbiddenIP AsQryLoginForbiddenIP { get { return _refValue as CtpQryLoginForbiddenIP; } }
        
        public CtpQryIPList AsQryIPList { get { return _refValue as CtpQryIPList; } }
        
        public CtpQryUserRightsAssign AsQryUserRightsAssign { get { return _refValue as CtpQryUserRightsAssign; } }
        
        public CtpReserveOpenAccountConfirm AsReserveOpenAccountConfirm { get { return _refValue as CtpReserveOpenAccountConfirm; } }
        
        public CtpReserveOpenAccount AsReserveOpenAccount { get { return _refValue as CtpReserveOpenAccount; } }
        
        public CtpAccountProperty AsAccountProperty { get { return _refValue as CtpAccountProperty; } }
        
        public CtpQryCurrDRIdentity AsQryCurrDRIdentity { get { return _refValue as CtpQryCurrDRIdentity; } }
        
        public CtpCurrDRIdentity AsCurrDRIdentity { get { return _refValue as CtpCurrDRIdentity; } }
        
        public CtpQrySecAgentCheckMode AsQrySecAgentCheckMode { get { return _refValue as CtpQrySecAgentCheckMode; } }
        
        public CtpQrySecAgentTradeInfo AsQrySecAgentTradeInfo { get { return _refValue as CtpQrySecAgentTradeInfo; } }
        
        public CtpUserSystemInfo AsUserSystemInfo { get { return _refValue as CtpUserSystemInfo; } }
        
        public CtpReqUserAuthMethod AsReqUserAuthMethod { get { return _refValue as CtpReqUserAuthMethod; } }
        
        public CtpRspUserAuthMethod AsRspUserAuthMethod { get { return _refValue as CtpRspUserAuthMethod; } }
        
        public CtpReqGenUserCaptcha AsReqGenUserCaptcha { get { return _refValue as CtpReqGenUserCaptcha; } }
        
        public CtpRspGenUserCaptcha AsRspGenUserCaptcha { get { return _refValue as CtpRspGenUserCaptcha; } }
        
        public CtpReqGenUserText AsReqGenUserText { get { return _refValue as CtpReqGenUserText; } }
        
        public CtpRspGenUserText AsRspGenUserText { get { return _refValue as CtpRspGenUserText; } }
        
        public CtpReqUserLoginWithCaptcha AsReqUserLoginWithCaptcha { get { return _refValue as CtpReqUserLoginWithCaptcha; } }
        
        public CtpReqUserLoginWithText AsReqUserLoginWithText { get { return _refValue as CtpReqUserLoginWithText; } }
        
        public CtpReqUserLoginWithOTP AsReqUserLoginWithOTP { get { return _refValue as CtpReqUserLoginWithOTP; } }
        
        public CtpReqApiHandshake AsReqApiHandshake { get { return _refValue as CtpReqApiHandshake; } }
        
        public CtpRspApiHandshake AsRspApiHandshake { get { return _refValue as CtpRspApiHandshake; } }
        
        public CtpReqVerifyApiKey AsReqVerifyApiKey { get { return _refValue as CtpReqVerifyApiKey; } }
        
        public CtpDepartmentUser AsDepartmentUser { get { return _refValue as CtpDepartmentUser; } }
        
        public CtpQueryFreq AsQueryFreq { get { return _refValue as CtpQueryFreq; } }
        

       
        public string ToXmlString()
        {            
      if(AsReqUserLogin!=null)
           return Serialize(AsReqUserLogin);
        
      if(AsRspUserLogin!=null)
           return Serialize(AsRspUserLogin);
        
      if(AsUserLogout!=null)
           return Serialize(AsUserLogout);
        
      if(AsForceUserLogout!=null)
           return Serialize(AsForceUserLogout);
        
      if(AsReqAuthenticate!=null)
           return Serialize(AsReqAuthenticate);
        
      if(AsRspAuthenticate!=null)
           return Serialize(AsRspAuthenticate);
        
      if(AsAuthenticationInfo!=null)
           return Serialize(AsAuthenticationInfo);
        
      if(AsRspUserLogin2!=null)
           return Serialize(AsRspUserLogin2);
        
      if(AsTransferHeader!=null)
           return Serialize(AsTransferHeader);
        
      if(AsTransferBankToFutureReq!=null)
           return Serialize(AsTransferBankToFutureReq);
        
      if(AsTransferBankToFutureRsp!=null)
           return Serialize(AsTransferBankToFutureRsp);
        
      if(AsTransferFutureToBankReq!=null)
           return Serialize(AsTransferFutureToBankReq);
        
      if(AsTransferFutureToBankRsp!=null)
           return Serialize(AsTransferFutureToBankRsp);
        
      if(AsTransferQryBankReq!=null)
           return Serialize(AsTransferQryBankReq);
        
      if(AsTransferQryBankRsp!=null)
           return Serialize(AsTransferQryBankRsp);
        
      if(AsTransferQryDetailReq!=null)
           return Serialize(AsTransferQryDetailReq);
        
      if(AsTransferQryDetailRsp!=null)
           return Serialize(AsTransferQryDetailRsp);
        
      if(AsRspInfo!=null)
           return Serialize(AsRspInfo);
        
      if(AsExchange!=null)
           return Serialize(AsExchange);
        
      if(AsProduct!=null)
           return Serialize(AsProduct);
        
      if(AsInstrument!=null)
           return Serialize(AsInstrument);
        
      if(AsBroker!=null)
           return Serialize(AsBroker);
        
      if(AsTrader!=null)
           return Serialize(AsTrader);
        
      if(AsInvestor!=null)
           return Serialize(AsInvestor);
        
      if(AsTradingCode!=null)
           return Serialize(AsTradingCode);
        
      if(AsPartBroker!=null)
           return Serialize(AsPartBroker);
        
      if(AsSuperUser!=null)
           return Serialize(AsSuperUser);
        
      if(AsSuperUserFunction!=null)
           return Serialize(AsSuperUserFunction);
        
      if(AsInvestorGroup!=null)
           return Serialize(AsInvestorGroup);
        
      if(AsTradingAccount!=null)
           return Serialize(AsTradingAccount);
        
      if(AsInvestorPosition!=null)
           return Serialize(AsInvestorPosition);
        
      if(AsInstrumentMarginRate!=null)
           return Serialize(AsInstrumentMarginRate);
        
      if(AsInstrumentCommissionRate!=null)
           return Serialize(AsInstrumentCommissionRate);
        
      if(AsDepthMarketData!=null)
           return Serialize(AsDepthMarketData);
        
      if(AsInstrumentTradingRight!=null)
           return Serialize(AsInstrumentTradingRight);
        
      if(AsBrokerUser!=null)
           return Serialize(AsBrokerUser);
        
      if(AsBrokerUserPassword!=null)
           return Serialize(AsBrokerUserPassword);
        
      if(AsBrokerUserFunction!=null)
           return Serialize(AsBrokerUserFunction);
        
      if(AsTraderOffer!=null)
           return Serialize(AsTraderOffer);
        
      if(AsSettlementInfo!=null)
           return Serialize(AsSettlementInfo);
        
      if(AsInstrumentMarginRateAdjust!=null)
           return Serialize(AsInstrumentMarginRateAdjust);
        
      if(AsExchangeMarginRate!=null)
           return Serialize(AsExchangeMarginRate);
        
      if(AsExchangeMarginRateAdjust!=null)
           return Serialize(AsExchangeMarginRateAdjust);
        
      if(AsExchangeRate!=null)
           return Serialize(AsExchangeRate);
        
      if(AsSettlementRef!=null)
           return Serialize(AsSettlementRef);
        
      if(AsCurrentTime!=null)
           return Serialize(AsCurrentTime);
        
      if(AsCommPhase!=null)
           return Serialize(AsCommPhase);
        
      if(AsLoginInfo!=null)
           return Serialize(AsLoginInfo);
        
      if(AsLogoutAll!=null)
           return Serialize(AsLogoutAll);
        
      if(AsFrontStatus!=null)
           return Serialize(AsFrontStatus);
        
      if(AsUserPasswordUpdate!=null)
           return Serialize(AsUserPasswordUpdate);
        
      if(AsInputOrder!=null)
           return Serialize(AsInputOrder);
        
      if(AsOrder!=null)
           return Serialize(AsOrder);
        
      if(AsExchangeOrder!=null)
           return Serialize(AsExchangeOrder);
        
      if(AsExchangeOrderInsertError!=null)
           return Serialize(AsExchangeOrderInsertError);
        
      if(AsInputOrderAction!=null)
           return Serialize(AsInputOrderAction);
        
      if(AsOrderAction!=null)
           return Serialize(AsOrderAction);
        
      if(AsExchangeOrderAction!=null)
           return Serialize(AsExchangeOrderAction);
        
      if(AsExchangeOrderActionError!=null)
           return Serialize(AsExchangeOrderActionError);
        
      if(AsExchangeTrade!=null)
           return Serialize(AsExchangeTrade);
        
      if(AsTrade!=null)
           return Serialize(AsTrade);
        
      if(AsUserSession!=null)
           return Serialize(AsUserSession);
        
      if(AsQueryMaxOrderVolume!=null)
           return Serialize(AsQueryMaxOrderVolume);
        
      if(AsSettlementInfoConfirm!=null)
           return Serialize(AsSettlementInfoConfirm);
        
      if(AsSyncDeposit!=null)
           return Serialize(AsSyncDeposit);
        
      if(AsSyncFundMortgage!=null)
           return Serialize(AsSyncFundMortgage);
        
      if(AsBrokerSync!=null)
           return Serialize(AsBrokerSync);
        
      if(AsSyncingInvestor!=null)
           return Serialize(AsSyncingInvestor);
        
      if(AsSyncingTradingCode!=null)
           return Serialize(AsSyncingTradingCode);
        
      if(AsSyncingInvestorGroup!=null)
           return Serialize(AsSyncingInvestorGroup);
        
      if(AsSyncingTradingAccount!=null)
           return Serialize(AsSyncingTradingAccount);
        
      if(AsSyncingInvestorPosition!=null)
           return Serialize(AsSyncingInvestorPosition);
        
      if(AsSyncingInstrumentMarginRate!=null)
           return Serialize(AsSyncingInstrumentMarginRate);
        
      if(AsSyncingInstrumentCommissionRate!=null)
           return Serialize(AsSyncingInstrumentCommissionRate);
        
      if(AsSyncingInstrumentTradingRight!=null)
           return Serialize(AsSyncingInstrumentTradingRight);
        
      if(AsQryOrder!=null)
           return Serialize(AsQryOrder);
        
      if(AsQryTrade!=null)
           return Serialize(AsQryTrade);
        
      if(AsQryInvestorPosition!=null)
           return Serialize(AsQryInvestorPosition);
        
      if(AsQryTradingAccount!=null)
           return Serialize(AsQryTradingAccount);
        
      if(AsQryInvestor!=null)
           return Serialize(AsQryInvestor);
        
      if(AsQryTradingCode!=null)
           return Serialize(AsQryTradingCode);
        
      if(AsQryInvestorGroup!=null)
           return Serialize(AsQryInvestorGroup);
        
      if(AsQryInstrumentMarginRate!=null)
           return Serialize(AsQryInstrumentMarginRate);
        
      if(AsQryInstrumentCommissionRate!=null)
           return Serialize(AsQryInstrumentCommissionRate);
        
      if(AsQryInstrumentTradingRight!=null)
           return Serialize(AsQryInstrumentTradingRight);
        
      if(AsQryBroker!=null)
           return Serialize(AsQryBroker);
        
      if(AsQryTrader!=null)
           return Serialize(AsQryTrader);
        
      if(AsQrySuperUserFunction!=null)
           return Serialize(AsQrySuperUserFunction);
        
      if(AsQryUserSession!=null)
           return Serialize(AsQryUserSession);
        
      if(AsQryPartBroker!=null)
           return Serialize(AsQryPartBroker);
        
      if(AsQryFrontStatus!=null)
           return Serialize(AsQryFrontStatus);
        
      if(AsQryExchangeOrder!=null)
           return Serialize(AsQryExchangeOrder);
        
      if(AsQryOrderAction!=null)
           return Serialize(AsQryOrderAction);
        
      if(AsQryExchangeOrderAction!=null)
           return Serialize(AsQryExchangeOrderAction);
        
      if(AsQrySuperUser!=null)
           return Serialize(AsQrySuperUser);
        
      if(AsQryExchange!=null)
           return Serialize(AsQryExchange);
        
      if(AsQryProduct!=null)
           return Serialize(AsQryProduct);
        
      if(AsQryInstrument!=null)
           return Serialize(AsQryInstrument);
        
      if(AsQryDepthMarketData!=null)
           return Serialize(AsQryDepthMarketData);
        
      if(AsQryBrokerUser!=null)
           return Serialize(AsQryBrokerUser);
        
      if(AsQryBrokerUserFunction!=null)
           return Serialize(AsQryBrokerUserFunction);
        
      if(AsQryTraderOffer!=null)
           return Serialize(AsQryTraderOffer);
        
      if(AsQrySyncDeposit!=null)
           return Serialize(AsQrySyncDeposit);
        
      if(AsQrySettlementInfo!=null)
           return Serialize(AsQrySettlementInfo);
        
      if(AsQryExchangeMarginRate!=null)
           return Serialize(AsQryExchangeMarginRate);
        
      if(AsQryExchangeMarginRateAdjust!=null)
           return Serialize(AsQryExchangeMarginRateAdjust);
        
      if(AsQryExchangeRate!=null)
           return Serialize(AsQryExchangeRate);
        
      if(AsQrySyncFundMortgage!=null)
           return Serialize(AsQrySyncFundMortgage);
        
      if(AsQryHisOrder!=null)
           return Serialize(AsQryHisOrder);
        
      if(AsOptionInstrMiniMargin!=null)
           return Serialize(AsOptionInstrMiniMargin);
        
      if(AsOptionInstrMarginAdjust!=null)
           return Serialize(AsOptionInstrMarginAdjust);
        
      if(AsOptionInstrCommRate!=null)
           return Serialize(AsOptionInstrCommRate);
        
      if(AsOptionInstrTradeCost!=null)
           return Serialize(AsOptionInstrTradeCost);
        
      if(AsQryOptionInstrTradeCost!=null)
           return Serialize(AsQryOptionInstrTradeCost);
        
      if(AsQryOptionInstrCommRate!=null)
           return Serialize(AsQryOptionInstrCommRate);
        
      if(AsIndexPrice!=null)
           return Serialize(AsIndexPrice);
        
      if(AsInputExecOrder!=null)
           return Serialize(AsInputExecOrder);
        
      if(AsInputExecOrderAction!=null)
           return Serialize(AsInputExecOrderAction);
        
      if(AsExecOrder!=null)
           return Serialize(AsExecOrder);
        
      if(AsExecOrderAction!=null)
           return Serialize(AsExecOrderAction);
        
      if(AsQryExecOrder!=null)
           return Serialize(AsQryExecOrder);
        
      if(AsExchangeExecOrder!=null)
           return Serialize(AsExchangeExecOrder);
        
      if(AsQryExchangeExecOrder!=null)
           return Serialize(AsQryExchangeExecOrder);
        
      if(AsQryExecOrderAction!=null)
           return Serialize(AsQryExecOrderAction);
        
      if(AsExchangeExecOrderAction!=null)
           return Serialize(AsExchangeExecOrderAction);
        
      if(AsQryExchangeExecOrderAction!=null)
           return Serialize(AsQryExchangeExecOrderAction);
        
      if(AsErrExecOrder!=null)
           return Serialize(AsErrExecOrder);
        
      if(AsQryErrExecOrder!=null)
           return Serialize(AsQryErrExecOrder);
        
      if(AsErrExecOrderAction!=null)
           return Serialize(AsErrExecOrderAction);
        
      if(AsQryErrExecOrderAction!=null)
           return Serialize(AsQryErrExecOrderAction);
        
      if(AsOptionInstrTradingRight!=null)
           return Serialize(AsOptionInstrTradingRight);
        
      if(AsQryOptionInstrTradingRight!=null)
           return Serialize(AsQryOptionInstrTradingRight);
        
      if(AsInputForQuote!=null)
           return Serialize(AsInputForQuote);
        
      if(AsForQuote!=null)
           return Serialize(AsForQuote);
        
      if(AsQryForQuote!=null)
           return Serialize(AsQryForQuote);
        
      if(AsExchangeForQuote!=null)
           return Serialize(AsExchangeForQuote);
        
      if(AsQryExchangeForQuote!=null)
           return Serialize(AsQryExchangeForQuote);
        
      if(AsInputQuote!=null)
           return Serialize(AsInputQuote);
        
      if(AsInputQuoteAction!=null)
           return Serialize(AsInputQuoteAction);
        
      if(AsQuote!=null)
           return Serialize(AsQuote);
        
      if(AsQuoteAction!=null)
           return Serialize(AsQuoteAction);
        
      if(AsQryQuote!=null)
           return Serialize(AsQryQuote);
        
      if(AsExchangeQuote!=null)
           return Serialize(AsExchangeQuote);
        
      if(AsQryExchangeQuote!=null)
           return Serialize(AsQryExchangeQuote);
        
      if(AsQryQuoteAction!=null)
           return Serialize(AsQryQuoteAction);
        
      if(AsExchangeQuoteAction!=null)
           return Serialize(AsExchangeQuoteAction);
        
      if(AsQryExchangeQuoteAction!=null)
           return Serialize(AsQryExchangeQuoteAction);
        
      if(AsOptionInstrDelta!=null)
           return Serialize(AsOptionInstrDelta);
        
      if(AsForQuoteRsp!=null)
           return Serialize(AsForQuoteRsp);
        
      if(AsStrikeOffset!=null)
           return Serialize(AsStrikeOffset);
        
      if(AsQryStrikeOffset!=null)
           return Serialize(AsQryStrikeOffset);
        
      if(AsInputBatchOrderAction!=null)
           return Serialize(AsInputBatchOrderAction);
        
      if(AsBatchOrderAction!=null)
           return Serialize(AsBatchOrderAction);
        
      if(AsExchangeBatchOrderAction!=null)
           return Serialize(AsExchangeBatchOrderAction);
        
      if(AsQryBatchOrderAction!=null)
           return Serialize(AsQryBatchOrderAction);
        
      if(AsCombInstrumentGuard!=null)
           return Serialize(AsCombInstrumentGuard);
        
      if(AsQryCombInstrumentGuard!=null)
           return Serialize(AsQryCombInstrumentGuard);
        
      if(AsInputCombAction!=null)
           return Serialize(AsInputCombAction);
        
      if(AsCombAction!=null)
           return Serialize(AsCombAction);
        
      if(AsQryCombAction!=null)
           return Serialize(AsQryCombAction);
        
      if(AsExchangeCombAction!=null)
           return Serialize(AsExchangeCombAction);
        
      if(AsQryExchangeCombAction!=null)
           return Serialize(AsQryExchangeCombAction);
        
      if(AsProductExchRate!=null)
           return Serialize(AsProductExchRate);
        
      if(AsQryProductExchRate!=null)
           return Serialize(AsQryProductExchRate);
        
      if(AsQryForQuoteParam!=null)
           return Serialize(AsQryForQuoteParam);
        
      if(AsForQuoteParam!=null)
           return Serialize(AsForQuoteParam);
        
      if(AsMMOptionInstrCommRate!=null)
           return Serialize(AsMMOptionInstrCommRate);
        
      if(AsQryMMOptionInstrCommRate!=null)
           return Serialize(AsQryMMOptionInstrCommRate);
        
      if(AsMMInstrumentCommissionRate!=null)
           return Serialize(AsMMInstrumentCommissionRate);
        
      if(AsQryMMInstrumentCommissionRate!=null)
           return Serialize(AsQryMMInstrumentCommissionRate);
        
      if(AsInstrumentOrderCommRate!=null)
           return Serialize(AsInstrumentOrderCommRate);
        
      if(AsQryInstrumentOrderCommRate!=null)
           return Serialize(AsQryInstrumentOrderCommRate);
        
      if(AsTradeParam!=null)
           return Serialize(AsTradeParam);
        
      if(AsInstrumentMarginRateUL!=null)
           return Serialize(AsInstrumentMarginRateUL);
        
      if(AsFutureLimitPosiParam!=null)
           return Serialize(AsFutureLimitPosiParam);
        
      if(AsLoginForbiddenIP!=null)
           return Serialize(AsLoginForbiddenIP);
        
      if(AsIPList!=null)
           return Serialize(AsIPList);
        
      if(AsInputOptionSelfClose!=null)
           return Serialize(AsInputOptionSelfClose);
        
      if(AsInputOptionSelfCloseAction!=null)
           return Serialize(AsInputOptionSelfCloseAction);
        
      if(AsOptionSelfClose!=null)
           return Serialize(AsOptionSelfClose);
        
      if(AsOptionSelfCloseAction!=null)
           return Serialize(AsOptionSelfCloseAction);
        
      if(AsQryOptionSelfClose!=null)
           return Serialize(AsQryOptionSelfClose);
        
      if(AsExchangeOptionSelfClose!=null)
           return Serialize(AsExchangeOptionSelfClose);
        
      if(AsQryOptionSelfCloseAction!=null)
           return Serialize(AsQryOptionSelfCloseAction);
        
      if(AsExchangeOptionSelfCloseAction!=null)
           return Serialize(AsExchangeOptionSelfCloseAction);
        
      if(AsSyncDelaySwap!=null)
           return Serialize(AsSyncDelaySwap);
        
      if(AsQrySyncDelaySwap!=null)
           return Serialize(AsQrySyncDelaySwap);
        
      if(AsInvestUnit!=null)
           return Serialize(AsInvestUnit);
        
      if(AsQryInvestUnit!=null)
           return Serialize(AsQryInvestUnit);
        
      if(AsSecAgentCheckMode!=null)
           return Serialize(AsSecAgentCheckMode);
        
      if(AsSecAgentTradeInfo!=null)
           return Serialize(AsSecAgentTradeInfo);
        
      if(AsMarketData!=null)
           return Serialize(AsMarketData);
        
      if(AsMarketDataBase!=null)
           return Serialize(AsMarketDataBase);
        
      if(AsMarketDataStatic!=null)
           return Serialize(AsMarketDataStatic);
        
      if(AsMarketDataLastMatch!=null)
           return Serialize(AsMarketDataLastMatch);
        
      if(AsMarketDataBestPrice!=null)
           return Serialize(AsMarketDataBestPrice);
        
      if(AsMarketDataBid23!=null)
           return Serialize(AsMarketDataBid23);
        
      if(AsMarketDataAsk23!=null)
           return Serialize(AsMarketDataAsk23);
        
      if(AsMarketDataBid45!=null)
           return Serialize(AsMarketDataBid45);
        
      if(AsMarketDataAsk45!=null)
           return Serialize(AsMarketDataAsk45);
        
      if(AsMarketDataUpdateTime!=null)
           return Serialize(AsMarketDataUpdateTime);
        
      if(AsMarketDataExchange!=null)
           return Serialize(AsMarketDataExchange);
        
      if(AsSpecificInstrument!=null)
           return Serialize(AsSpecificInstrument);
        
      if(AsInstrumentStatus!=null)
           return Serialize(AsInstrumentStatus);
        
      if(AsQryInstrumentStatus!=null)
           return Serialize(AsQryInstrumentStatus);
        
      if(AsInvestorAccount!=null)
           return Serialize(AsInvestorAccount);
        
      if(AsPositionProfitAlgorithm!=null)
           return Serialize(AsPositionProfitAlgorithm);
        
      if(AsDiscount!=null)
           return Serialize(AsDiscount);
        
      if(AsQryTransferBank!=null)
           return Serialize(AsQryTransferBank);
        
      if(AsTransferBank!=null)
           return Serialize(AsTransferBank);
        
      if(AsQryInvestorPositionDetail!=null)
           return Serialize(AsQryInvestorPositionDetail);
        
      if(AsInvestorPositionDetail!=null)
           return Serialize(AsInvestorPositionDetail);
        
      if(AsTradingAccountPassword!=null)
           return Serialize(AsTradingAccountPassword);
        
      if(AsMDTraderOffer!=null)
           return Serialize(AsMDTraderOffer);
        
      if(AsQryMDTraderOffer!=null)
           return Serialize(AsQryMDTraderOffer);
        
      if(AsQryNotice!=null)
           return Serialize(AsQryNotice);
        
      if(AsNotice!=null)
           return Serialize(AsNotice);
        
      if(AsUserRight!=null)
           return Serialize(AsUserRight);
        
      if(AsQrySettlementInfoConfirm!=null)
           return Serialize(AsQrySettlementInfoConfirm);
        
      if(AsLoadSettlementInfo!=null)
           return Serialize(AsLoadSettlementInfo);
        
      if(AsBrokerWithdrawAlgorithm!=null)
           return Serialize(AsBrokerWithdrawAlgorithm);
        
      if(AsTradingAccountPasswordUpdateV1!=null)
           return Serialize(AsTradingAccountPasswordUpdateV1);
        
      if(AsTradingAccountPasswordUpdate!=null)
           return Serialize(AsTradingAccountPasswordUpdate);
        
      if(AsQryCombinationLeg!=null)
           return Serialize(AsQryCombinationLeg);
        
      if(AsQrySyncStatus!=null)
           return Serialize(AsQrySyncStatus);
        
      if(AsCombinationLeg!=null)
           return Serialize(AsCombinationLeg);
        
      if(AsSyncStatus!=null)
           return Serialize(AsSyncStatus);
        
      if(AsQryLinkMan!=null)
           return Serialize(AsQryLinkMan);
        
      if(AsLinkMan!=null)
           return Serialize(AsLinkMan);
        
      if(AsQryBrokerUserEvent!=null)
           return Serialize(AsQryBrokerUserEvent);
        
      if(AsBrokerUserEvent!=null)
           return Serialize(AsBrokerUserEvent);
        
      if(AsQryContractBank!=null)
           return Serialize(AsQryContractBank);
        
      if(AsContractBank!=null)
           return Serialize(AsContractBank);
        
      if(AsInvestorPositionCombineDetail!=null)
           return Serialize(AsInvestorPositionCombineDetail);
        
      if(AsParkedOrder!=null)
           return Serialize(AsParkedOrder);
        
      if(AsParkedOrderAction!=null)
           return Serialize(AsParkedOrderAction);
        
      if(AsQryParkedOrder!=null)
           return Serialize(AsQryParkedOrder);
        
      if(AsQryParkedOrderAction!=null)
           return Serialize(AsQryParkedOrderAction);
        
      if(AsRemoveParkedOrder!=null)
           return Serialize(AsRemoveParkedOrder);
        
      if(AsRemoveParkedOrderAction!=null)
           return Serialize(AsRemoveParkedOrderAction);
        
      if(AsInvestorWithdrawAlgorithm!=null)
           return Serialize(AsInvestorWithdrawAlgorithm);
        
      if(AsQryInvestorPositionCombineDetail!=null)
           return Serialize(AsQryInvestorPositionCombineDetail);
        
      if(AsMarketDataAveragePrice!=null)
           return Serialize(AsMarketDataAveragePrice);
        
      if(AsVerifyInvestorPassword!=null)
           return Serialize(AsVerifyInvestorPassword);
        
      if(AsUserIP!=null)
           return Serialize(AsUserIP);
        
      if(AsTradingNoticeInfo!=null)
           return Serialize(AsTradingNoticeInfo);
        
      if(AsTradingNotice!=null)
           return Serialize(AsTradingNotice);
        
      if(AsQryTradingNotice!=null)
           return Serialize(AsQryTradingNotice);
        
      if(AsQryErrOrder!=null)
           return Serialize(AsQryErrOrder);
        
      if(AsErrOrder!=null)
           return Serialize(AsErrOrder);
        
      if(AsErrorConditionalOrder!=null)
           return Serialize(AsErrorConditionalOrder);
        
      if(AsQryErrOrderAction!=null)
           return Serialize(AsQryErrOrderAction);
        
      if(AsErrOrderAction!=null)
           return Serialize(AsErrOrderAction);
        
      if(AsQryExchangeSequence!=null)
           return Serialize(AsQryExchangeSequence);
        
      if(AsExchangeSequence!=null)
           return Serialize(AsExchangeSequence);
        
      if(AsQueryMaxOrderVolumeWithPrice!=null)
           return Serialize(AsQueryMaxOrderVolumeWithPrice);
        
      if(AsQryBrokerTradingParams!=null)
           return Serialize(AsQryBrokerTradingParams);
        
      if(AsBrokerTradingParams!=null)
           return Serialize(AsBrokerTradingParams);
        
      if(AsQryBrokerTradingAlgos!=null)
           return Serialize(AsQryBrokerTradingAlgos);
        
      if(AsBrokerTradingAlgos!=null)
           return Serialize(AsBrokerTradingAlgos);
        
      if(AsQueryBrokerDeposit!=null)
           return Serialize(AsQueryBrokerDeposit);
        
      if(AsBrokerDeposit!=null)
           return Serialize(AsBrokerDeposit);
        
      if(AsQryCFMMCBrokerKey!=null)
           return Serialize(AsQryCFMMCBrokerKey);
        
      if(AsCFMMCBrokerKey!=null)
           return Serialize(AsCFMMCBrokerKey);
        
      if(AsCFMMCTradingAccountKey!=null)
           return Serialize(AsCFMMCTradingAccountKey);
        
      if(AsQryCFMMCTradingAccountKey!=null)
           return Serialize(AsQryCFMMCTradingAccountKey);
        
      if(AsBrokerUserOTPParam!=null)
           return Serialize(AsBrokerUserOTPParam);
        
      if(AsManualSyncBrokerUserOTP!=null)
           return Serialize(AsManualSyncBrokerUserOTP);
        
      if(AsCommRateModel!=null)
           return Serialize(AsCommRateModel);
        
      if(AsQryCommRateModel!=null)
           return Serialize(AsQryCommRateModel);
        
      if(AsMarginModel!=null)
           return Serialize(AsMarginModel);
        
      if(AsQryMarginModel!=null)
           return Serialize(AsQryMarginModel);
        
      if(AsEWarrantOffset!=null)
           return Serialize(AsEWarrantOffset);
        
      if(AsQryEWarrantOffset!=null)
           return Serialize(AsQryEWarrantOffset);
        
      if(AsQryInvestorProductGroupMargin!=null)
           return Serialize(AsQryInvestorProductGroupMargin);
        
      if(AsInvestorProductGroupMargin!=null)
           return Serialize(AsInvestorProductGroupMargin);
        
      if(AsQueryCFMMCTradingAccountToken!=null)
           return Serialize(AsQueryCFMMCTradingAccountToken);
        
      if(AsCFMMCTradingAccountToken!=null)
           return Serialize(AsCFMMCTradingAccountToken);
        
      if(AsQryProductGroup!=null)
           return Serialize(AsQryProductGroup);
        
      if(AsProductGroup!=null)
           return Serialize(AsProductGroup);
        
      if(AsBulletin!=null)
           return Serialize(AsBulletin);
        
      if(AsQryBulletin!=null)
           return Serialize(AsQryBulletin);
        
      if(AsReqOpenAccount!=null)
           return Serialize(AsReqOpenAccount);
        
      if(AsReqCancelAccount!=null)
           return Serialize(AsReqCancelAccount);
        
      if(AsReqChangeAccount!=null)
           return Serialize(AsReqChangeAccount);
        
      if(AsReqTransfer!=null)
           return Serialize(AsReqTransfer);
        
      if(AsRspTransfer!=null)
           return Serialize(AsRspTransfer);
        
      if(AsReqRepeal!=null)
           return Serialize(AsReqRepeal);
        
      if(AsRspRepeal!=null)
           return Serialize(AsRspRepeal);
        
      if(AsReqQueryAccount!=null)
           return Serialize(AsReqQueryAccount);
        
      if(AsRspQueryAccount!=null)
           return Serialize(AsRspQueryAccount);
        
      if(AsFutureSignIO!=null)
           return Serialize(AsFutureSignIO);
        
      if(AsRspFutureSignIn!=null)
           return Serialize(AsRspFutureSignIn);
        
      if(AsReqFutureSignOut!=null)
           return Serialize(AsReqFutureSignOut);
        
      if(AsRspFutureSignOut!=null)
           return Serialize(AsRspFutureSignOut);
        
      if(AsReqQueryTradeResultBySerial!=null)
           return Serialize(AsReqQueryTradeResultBySerial);
        
      if(AsRspQueryTradeResultBySerial!=null)
           return Serialize(AsRspQueryTradeResultBySerial);
        
      if(AsReqDayEndFileReady!=null)
           return Serialize(AsReqDayEndFileReady);
        
      if(AsReturnResult!=null)
           return Serialize(AsReturnResult);
        
      if(AsVerifyFuturePassword!=null)
           return Serialize(AsVerifyFuturePassword);
        
      if(AsVerifyCustInfo!=null)
           return Serialize(AsVerifyCustInfo);
        
      if(AsVerifyFuturePasswordAndCustInfo!=null)
           return Serialize(AsVerifyFuturePasswordAndCustInfo);
        
      if(AsDepositResultInform!=null)
           return Serialize(AsDepositResultInform);
        
      if(AsReqSyncKey!=null)
           return Serialize(AsReqSyncKey);
        
      if(AsRspSyncKey!=null)
           return Serialize(AsRspSyncKey);
        
      if(AsNotifyQueryAccount!=null)
           return Serialize(AsNotifyQueryAccount);
        
      if(AsTransferSerial!=null)
           return Serialize(AsTransferSerial);
        
      if(AsQryTransferSerial!=null)
           return Serialize(AsQryTransferSerial);
        
      if(AsNotifyFutureSignIn!=null)
           return Serialize(AsNotifyFutureSignIn);
        
      if(AsNotifyFutureSignOut!=null)
           return Serialize(AsNotifyFutureSignOut);
        
      if(AsNotifySyncKey!=null)
           return Serialize(AsNotifySyncKey);
        
      if(AsQryAccountregister!=null)
           return Serialize(AsQryAccountregister);
        
      if(AsAccountregister!=null)
           return Serialize(AsAccountregister);
        
      if(AsOpenAccount!=null)
           return Serialize(AsOpenAccount);
        
      if(AsCancelAccount!=null)
           return Serialize(AsCancelAccount);
        
      if(AsChangeAccount!=null)
           return Serialize(AsChangeAccount);
        
      if(AsSecAgentACIDMap!=null)
           return Serialize(AsSecAgentACIDMap);
        
      if(AsQrySecAgentACIDMap!=null)
           return Serialize(AsQrySecAgentACIDMap);
        
      if(AsUserRightsAssign!=null)
           return Serialize(AsUserRightsAssign);
        
      if(AsBrokerUserRightAssign!=null)
           return Serialize(AsBrokerUserRightAssign);
        
      if(AsDRTransfer!=null)
           return Serialize(AsDRTransfer);
        
      if(AsFensUserInfo!=null)
           return Serialize(AsFensUserInfo);
        
      if(AsCurrTransferIdentity!=null)
           return Serialize(AsCurrTransferIdentity);
        
      if(AsLoginForbiddenUser!=null)
           return Serialize(AsLoginForbiddenUser);
        
      if(AsQryLoginForbiddenUser!=null)
           return Serialize(AsQryLoginForbiddenUser);
        
      if(AsMulticastGroupInfo!=null)
           return Serialize(AsMulticastGroupInfo);
        
      if(AsTradingAccountReserve!=null)
           return Serialize(AsTradingAccountReserve);
        
      if(AsQryLoginForbiddenIP!=null)
           return Serialize(AsQryLoginForbiddenIP);
        
      if(AsQryIPList!=null)
           return Serialize(AsQryIPList);
        
      if(AsQryUserRightsAssign!=null)
           return Serialize(AsQryUserRightsAssign);
        
      if(AsReserveOpenAccountConfirm!=null)
           return Serialize(AsReserveOpenAccountConfirm);
        
      if(AsReserveOpenAccount!=null)
           return Serialize(AsReserveOpenAccount);
        
      if(AsAccountProperty!=null)
           return Serialize(AsAccountProperty);
        
      if(AsQryCurrDRIdentity!=null)
           return Serialize(AsQryCurrDRIdentity);
        
      if(AsCurrDRIdentity!=null)
           return Serialize(AsCurrDRIdentity);
        
      if(AsQrySecAgentCheckMode!=null)
           return Serialize(AsQrySecAgentCheckMode);
        
      if(AsQrySecAgentTradeInfo!=null)
           return Serialize(AsQrySecAgentTradeInfo);
        
      if(AsUserSystemInfo!=null)
           return Serialize(AsUserSystemInfo);
        
      if(AsReqUserAuthMethod!=null)
           return Serialize(AsReqUserAuthMethod);
        
      if(AsRspUserAuthMethod!=null)
           return Serialize(AsRspUserAuthMethod);
        
      if(AsReqGenUserCaptcha!=null)
           return Serialize(AsReqGenUserCaptcha);
        
      if(AsRspGenUserCaptcha!=null)
           return Serialize(AsRspGenUserCaptcha);
        
      if(AsReqGenUserText!=null)
           return Serialize(AsReqGenUserText);
        
      if(AsRspGenUserText!=null)
           return Serialize(AsRspGenUserText);
        
      if(AsReqUserLoginWithCaptcha!=null)
           return Serialize(AsReqUserLoginWithCaptcha);
        
      if(AsReqUserLoginWithText!=null)
           return Serialize(AsReqUserLoginWithText);
        
      if(AsReqUserLoginWithOTP!=null)
           return Serialize(AsReqUserLoginWithOTP);
        
      if(AsReqApiHandshake!=null)
           return Serialize(AsReqApiHandshake);
        
      if(AsRspApiHandshake!=null)
           return Serialize(AsRspApiHandshake);
        
      if(AsReqVerifyApiKey!=null)
           return Serialize(AsReqVerifyApiKey);
        
      if(AsDepartmentUser!=null)
           return Serialize(AsDepartmentUser);
        
      if(AsQueryFreq!=null)
           return Serialize(AsQueryFreq);
        
             return "";
        }

        private static string Serialize<T>(T entity)
        {
            var buffer = new StringBuilder();
            var serializer = new XmlSerializer(typeof(T));
            using (TextWriter writer = new StringWriter(buffer)) {
                serializer.Serialize(writer, entity);
            }
            return buffer.ToString();
        }  
    }
}
