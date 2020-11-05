using System;
using System.Runtime.InteropServices;

namespace QuantBox.Sfit.Api
{
    public static class CtpTraderNative
    {
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall,
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Create")]
        public static extern IntPtr Create(string path);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall,
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Init")]
        public static extern void Init(IntPtr instance);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall,
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Release")]
        public static extern void Release(IntPtr instance);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall,
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Join")]
        public static extern int Join(IntPtr instance);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall,
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_GetTradingDay")]
        public static extern string GetTradingDay(IntPtr instance);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall,
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_RegisterFront")]
        public static extern void RegisterFront(IntPtr instance, string frontAddress);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_RegisterNameServer")]
        public static extern void RegisterNameServer(IntPtr instance, string nsAddress);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_RegisterFensUserInfo")]
        public static extern void RegisterFensUserInfo(IntPtr instance, CtpFensUserInfo fensUserInfo);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_SubscribePrivateTopic")]
        public static extern void SubscribePrivateTopic(IntPtr instance, int resumeType);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_SubscribePublicTopic")]
        public static extern void SubscribePublicTopic(IntPtr instance, int resumeType);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqAuthenticate")]
        public static extern int ReqAuthenticate(IntPtr instance,CtpReqAuthenticate reqAuthenticateField,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_RegisterUserSystemInfo")]
        public static extern int RegisterUserSystemInfo(IntPtr instance,CtpUserSystemInfo userSystemInfo);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_SubmitUserSystemInfo")]
        public static extern int SubmitUserSystemInfo(IntPtr instance,CtpUserSystemInfo userSystemInfo);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqUserLogin")]
        public static extern int ReqUserLogin(IntPtr instance,CtpReqUserLogin reqUserLoginField,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqUserLogout")]
        public static extern int ReqUserLogout(IntPtr instance,CtpUserLogout userLogout,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqUserPasswordUpdate")]
        public static extern int ReqUserPasswordUpdate(IntPtr instance,CtpUserPasswordUpdate userPasswordUpdate,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqTradingAccountPasswordUpdate")]
        public static extern int ReqTradingAccountPasswordUpdate(IntPtr instance,CtpTradingAccountPasswordUpdate tradingAccountPasswordUpdate,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqUserAuthMethod")]
        public static extern int ReqUserAuthMethod(IntPtr instance,CtpReqUserAuthMethod reqUserAuthMethod,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqGenUserCaptcha")]
        public static extern int ReqGenUserCaptcha(IntPtr instance,CtpReqGenUserCaptcha reqGenUserCaptcha,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqGenUserText")]
        public static extern int ReqGenUserText(IntPtr instance,CtpReqGenUserText reqGenUserText,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqUserLoginWithCaptcha")]
        public static extern int ReqUserLoginWithCaptcha(IntPtr instance,CtpReqUserLoginWithCaptcha reqUserLoginWithCaptcha,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqUserLoginWithText")]
        public static extern int ReqUserLoginWithText(IntPtr instance,CtpReqUserLoginWithText reqUserLoginWithText,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqUserLoginWithOTP")]
        public static extern int ReqUserLoginWithOTP(IntPtr instance,CtpReqUserLoginWithOTP reqUserLoginWithOTP,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqOrderInsert")]
        public static extern int ReqOrderInsert(IntPtr instance,CtpInputOrder inputOrder,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqParkedOrderInsert")]
        public static extern int ReqParkedOrderInsert(IntPtr instance,CtpParkedOrder parkedOrder,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqParkedOrderAction")]
        public static extern int ReqParkedOrderAction(IntPtr instance,CtpParkedOrderAction parkedOrderAction,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqOrderAction")]
        public static extern int ReqOrderAction(IntPtr instance,CtpInputOrderAction inputOrderAction,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQueryMaxOrderVolume")]
        public static extern int ReqQueryMaxOrderVolume(IntPtr instance,CtpQueryMaxOrderVolume queryMaxOrderVolume,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqSettlementInfoConfirm")]
        public static extern int ReqSettlementInfoConfirm(IntPtr instance,CtpSettlementInfoConfirm settlementInfoConfirm,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqRemoveParkedOrder")]
        public static extern int ReqRemoveParkedOrder(IntPtr instance,CtpRemoveParkedOrder removeParkedOrder,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqRemoveParkedOrderAction")]
        public static extern int ReqRemoveParkedOrderAction(IntPtr instance,CtpRemoveParkedOrderAction removeParkedOrderAction,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqExecOrderInsert")]
        public static extern int ReqExecOrderInsert(IntPtr instance,CtpInputExecOrder inputExecOrder,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqExecOrderAction")]
        public static extern int ReqExecOrderAction(IntPtr instance,CtpInputExecOrderAction inputExecOrderAction,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqForQuoteInsert")]
        public static extern int ReqForQuoteInsert(IntPtr instance,CtpInputForQuote inputForQuote,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQuoteInsert")]
        public static extern int ReqQuoteInsert(IntPtr instance,CtpInputQuote inputQuote,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQuoteAction")]
        public static extern int ReqQuoteAction(IntPtr instance,CtpInputQuoteAction inputQuoteAction,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqBatchOrderAction")]
        public static extern int ReqBatchOrderAction(IntPtr instance,CtpInputBatchOrderAction inputBatchOrderAction,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqOptionSelfCloseInsert")]
        public static extern int ReqOptionSelfCloseInsert(IntPtr instance,CtpInputOptionSelfClose inputOptionSelfClose,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqOptionSelfCloseAction")]
        public static extern int ReqOptionSelfCloseAction(IntPtr instance,CtpInputOptionSelfCloseAction inputOptionSelfCloseAction,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqCombActionInsert")]
        public static extern int ReqCombActionInsert(IntPtr instance,CtpInputCombAction inputCombAction,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryOrder")]
        public static extern int ReqQryOrder(IntPtr instance,CtpQryOrder qryOrder,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryTrade")]
        public static extern int ReqQryTrade(IntPtr instance,CtpQryTrade qryTrade,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryInvestorPosition")]
        public static extern int ReqQryInvestorPosition(IntPtr instance,CtpQryInvestorPosition qryInvestorPosition,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryTradingAccount")]
        public static extern int ReqQryTradingAccount(IntPtr instance,CtpQryTradingAccount qryTradingAccount,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryInvestor")]
        public static extern int ReqQryInvestor(IntPtr instance,CtpQryInvestor qryInvestor,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryTradingCode")]
        public static extern int ReqQryTradingCode(IntPtr instance,CtpQryTradingCode qryTradingCode,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryInstrumentMarginRate")]
        public static extern int ReqQryInstrumentMarginRate(IntPtr instance,CtpQryInstrumentMarginRate qryInstrumentMarginRate,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryInstrumentCommissionRate")]
        public static extern int ReqQryInstrumentCommissionRate(IntPtr instance,CtpQryInstrumentCommissionRate qryInstrumentCommissionRate,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryExchange")]
        public static extern int ReqQryExchange(IntPtr instance,CtpQryExchange qryExchange,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryProduct")]
        public static extern int ReqQryProduct(IntPtr instance,CtpQryProduct qryProduct,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryInstrument")]
        public static extern int ReqQryInstrument(IntPtr instance,CtpQryInstrument qryInstrument,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryDepthMarketData")]
        public static extern int ReqQryDepthMarketData(IntPtr instance,CtpQryDepthMarketData qryDepthMarketData,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQrySettlementInfo")]
        public static extern int ReqQrySettlementInfo(IntPtr instance,CtpQrySettlementInfo qrySettlementInfo,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryTransferBank")]
        public static extern int ReqQryTransferBank(IntPtr instance,CtpQryTransferBank qryTransferBank,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryInvestorPositionDetail")]
        public static extern int ReqQryInvestorPositionDetail(IntPtr instance,CtpQryInvestorPositionDetail qryInvestorPositionDetail,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryNotice")]
        public static extern int ReqQryNotice(IntPtr instance,CtpQryNotice qryNotice,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQrySettlementInfoConfirm")]
        public static extern int ReqQrySettlementInfoConfirm(IntPtr instance,CtpQrySettlementInfoConfirm qrySettlementInfoConfirm,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryInvestorPositionCombineDetail")]
        public static extern int ReqQryInvestorPositionCombineDetail(IntPtr instance,CtpQryInvestorPositionCombineDetail qryInvestorPositionCombineDetail,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryCFMMCTradingAccountKey")]
        public static extern int ReqQryCFMMCTradingAccountKey(IntPtr instance,CtpQryCFMMCTradingAccountKey qryCFMMCTradingAccountKey,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryEWarrantOffset")]
        public static extern int ReqQryEWarrantOffset(IntPtr instance,CtpQryEWarrantOffset qryEWarrantOffset,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryInvestorProductGroupMargin")]
        public static extern int ReqQryInvestorProductGroupMargin(IntPtr instance,CtpQryInvestorProductGroupMargin qryInvestorProductGroupMargin,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryExchangeMarginRate")]
        public static extern int ReqQryExchangeMarginRate(IntPtr instance,CtpQryExchangeMarginRate qryExchangeMarginRate,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryExchangeMarginRateAdjust")]
        public static extern int ReqQryExchangeMarginRateAdjust(IntPtr instance,CtpQryExchangeMarginRateAdjust qryExchangeMarginRateAdjust,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryExchangeRate")]
        public static extern int ReqQryExchangeRate(IntPtr instance,CtpQryExchangeRate qryExchangeRate,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQrySecAgentACIDMap")]
        public static extern int ReqQrySecAgentACIDMap(IntPtr instance,CtpQrySecAgentACIDMap qrySecAgentACIDMap,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryProductExchRate")]
        public static extern int ReqQryProductExchRate(IntPtr instance,CtpQryProductExchRate qryProductExchRate,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryProductGroup")]
        public static extern int ReqQryProductGroup(IntPtr instance,CtpQryProductGroup qryProductGroup,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryMMInstrumentCommissionRate")]
        public static extern int ReqQryMMInstrumentCommissionRate(IntPtr instance,CtpQryMMInstrumentCommissionRate qryMMInstrumentCommissionRate,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryMMOptionInstrCommRate")]
        public static extern int ReqQryMMOptionInstrCommRate(IntPtr instance,CtpQryMMOptionInstrCommRate qryMMOptionInstrCommRate,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryInstrumentOrderCommRate")]
        public static extern int ReqQryInstrumentOrderCommRate(IntPtr instance,CtpQryInstrumentOrderCommRate qryInstrumentOrderCommRate,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQrySecAgentTradingAccount")]
        public static extern int ReqQrySecAgentTradingAccount(IntPtr instance,CtpQryTradingAccount qryTradingAccount,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQrySecAgentCheckMode")]
        public static extern int ReqQrySecAgentCheckMode(IntPtr instance,CtpQrySecAgentCheckMode qrySecAgentCheckMode,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQrySecAgentTradeInfo")]
        public static extern int ReqQrySecAgentTradeInfo(IntPtr instance,CtpQrySecAgentTradeInfo qrySecAgentTradeInfo,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryOptionInstrTradeCost")]
        public static extern int ReqQryOptionInstrTradeCost(IntPtr instance,CtpQryOptionInstrTradeCost qryOptionInstrTradeCost,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryOptionInstrCommRate")]
        public static extern int ReqQryOptionInstrCommRate(IntPtr instance,CtpQryOptionInstrCommRate qryOptionInstrCommRate,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryExecOrder")]
        public static extern int ReqQryExecOrder(IntPtr instance,CtpQryExecOrder qryExecOrder,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryForQuote")]
        public static extern int ReqQryForQuote(IntPtr instance,CtpQryForQuote qryForQuote,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryQuote")]
        public static extern int ReqQryQuote(IntPtr instance,CtpQryQuote qryQuote,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryOptionSelfClose")]
        public static extern int ReqQryOptionSelfClose(IntPtr instance,CtpQryOptionSelfClose qryOptionSelfClose,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryInvestUnit")]
        public static extern int ReqQryInvestUnit(IntPtr instance,CtpQryInvestUnit qryInvestUnit,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryCombInstrumentGuard")]
        public static extern int ReqQryCombInstrumentGuard(IntPtr instance,CtpQryCombInstrumentGuard qryCombInstrumentGuard,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryCombAction")]
        public static extern int ReqQryCombAction(IntPtr instance,CtpQryCombAction qryCombAction,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryTransferSerial")]
        public static extern int ReqQryTransferSerial(IntPtr instance,CtpQryTransferSerial qryTransferSerial,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryAccountregister")]
        public static extern int ReqQryAccountregister(IntPtr instance,CtpQryAccountregister qryAccountregister,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryContractBank")]
        public static extern int ReqQryContractBank(IntPtr instance,CtpQryContractBank qryContractBank,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryParkedOrder")]
        public static extern int ReqQryParkedOrder(IntPtr instance,CtpQryParkedOrder qryParkedOrder,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryParkedOrderAction")]
        public static extern int ReqQryParkedOrderAction(IntPtr instance,CtpQryParkedOrderAction qryParkedOrderAction,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryTradingNotice")]
        public static extern int ReqQryTradingNotice(IntPtr instance,CtpQryTradingNotice qryTradingNotice,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryBrokerTradingParams")]
        public static extern int ReqQryBrokerTradingParams(IntPtr instance,CtpQryBrokerTradingParams qryBrokerTradingParams,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQryBrokerTradingAlgos")]
        public static extern int ReqQryBrokerTradingAlgos(IntPtr instance,CtpQryBrokerTradingAlgos qryBrokerTradingAlgos,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQueryCFMMCTradingAccountToken")]
        public static extern int ReqQueryCFMMCTradingAccountToken(IntPtr instance,CtpQueryCFMMCTradingAccountToken queryCFMMCTradingAccountToken,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqFromBankToFutureByFuture")]
        public static extern int ReqFromBankToFutureByFuture(IntPtr instance,CtpReqTransfer reqTransfer,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqFromFutureToBankByFuture")]
        public static extern int ReqFromFutureToBankByFuture(IntPtr instance,CtpReqTransfer reqTransfer,int requestId);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_ReqQueryBankAccountMoneyByFuture")]
        public static extern int ReqQueryBankAccountMoneyByFuture(IntPtr instance,CtpReqQueryAccount reqQueryAccount,int requestId);
  
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnFrontConnected();
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnFrontConnected")]
        public static extern void SetOnFrontConnected(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnFrontConnected callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnFrontDisconnected(int reason);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnFrontDisconnected")]
        public static extern void SetOnFrontDisconnected(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnFrontDisconnected callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnHeartBeatWarning(int timeLapse);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnHeartBeatWarning")]
        public static extern void SetOnHeartBeatWarning(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnHeartBeatWarning callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspAuthenticate(CtpRspAuthenticate rspAuthenticateField,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspAuthenticate")]
        public static extern void SetOnRspAuthenticate(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspAuthenticate callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspUserLogin(CtpRspUserLogin rspUserLogin,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspUserLogin")]
        public static extern void SetOnRspUserLogin(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspUserLogin callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspUserLogout(CtpUserLogout userLogout,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspUserLogout")]
        public static extern void SetOnRspUserLogout(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspUserLogout callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspUserPasswordUpdate(CtpUserPasswordUpdate userPasswordUpdate,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspUserPasswordUpdate")]
        public static extern void SetOnRspUserPasswordUpdate(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspUserPasswordUpdate callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspTradingAccountPasswordUpdate(CtpTradingAccountPasswordUpdate tradingAccountPasswordUpdate,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspTradingAccountPasswordUpdate")]
        public static extern void SetOnRspTradingAccountPasswordUpdate(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspTradingAccountPasswordUpdate callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspUserAuthMethod(CtpRspUserAuthMethod rspUserAuthMethod,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspUserAuthMethod")]
        public static extern void SetOnRspUserAuthMethod(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspUserAuthMethod callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspGenUserCaptcha(CtpRspGenUserCaptcha rspGenUserCaptcha,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspGenUserCaptcha")]
        public static extern void SetOnRspGenUserCaptcha(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspGenUserCaptcha callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspGenUserText(CtpRspGenUserText rspGenUserText,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspGenUserText")]
        public static extern void SetOnRspGenUserText(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspGenUserText callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspOrderInsert(CtpInputOrder inputOrder,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspOrderInsert")]
        public static extern void SetOnRspOrderInsert(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspOrderInsert callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspParkedOrderInsert(CtpParkedOrder parkedOrder,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspParkedOrderInsert")]
        public static extern void SetOnRspParkedOrderInsert(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspParkedOrderInsert callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspParkedOrderAction(CtpParkedOrderAction parkedOrderAction,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspParkedOrderAction")]
        public static extern void SetOnRspParkedOrderAction(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspParkedOrderAction callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspOrderAction(CtpInputOrderAction inputOrderAction,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspOrderAction")]
        public static extern void SetOnRspOrderAction(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspOrderAction callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQueryMaxOrderVolume(CtpQueryMaxOrderVolume queryMaxOrderVolume,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQueryMaxOrderVolume")]
        public static extern void SetOnRspQueryMaxOrderVolume(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQueryMaxOrderVolume callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspSettlementInfoConfirm(CtpSettlementInfoConfirm settlementInfoConfirm,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspSettlementInfoConfirm")]
        public static extern void SetOnRspSettlementInfoConfirm(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspSettlementInfoConfirm callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspRemoveParkedOrder(CtpRemoveParkedOrder removeParkedOrder,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspRemoveParkedOrder")]
        public static extern void SetOnRspRemoveParkedOrder(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspRemoveParkedOrder callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspRemoveParkedOrderAction(CtpRemoveParkedOrderAction removeParkedOrderAction,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspRemoveParkedOrderAction")]
        public static extern void SetOnRspRemoveParkedOrderAction(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspRemoveParkedOrderAction callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspExecOrderInsert(CtpInputExecOrder inputExecOrder,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspExecOrderInsert")]
        public static extern void SetOnRspExecOrderInsert(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspExecOrderInsert callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspExecOrderAction(CtpInputExecOrderAction inputExecOrderAction,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspExecOrderAction")]
        public static extern void SetOnRspExecOrderAction(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspExecOrderAction callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspForQuoteInsert(CtpInputForQuote inputForQuote,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspForQuoteInsert")]
        public static extern void SetOnRspForQuoteInsert(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspForQuoteInsert callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQuoteInsert(CtpInputQuote inputQuote,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQuoteInsert")]
        public static extern void SetOnRspQuoteInsert(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQuoteInsert callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQuoteAction(CtpInputQuoteAction inputQuoteAction,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQuoteAction")]
        public static extern void SetOnRspQuoteAction(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQuoteAction callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspBatchOrderAction(CtpInputBatchOrderAction inputBatchOrderAction,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspBatchOrderAction")]
        public static extern void SetOnRspBatchOrderAction(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspBatchOrderAction callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspOptionSelfCloseInsert(CtpInputOptionSelfClose inputOptionSelfClose,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspOptionSelfCloseInsert")]
        public static extern void SetOnRspOptionSelfCloseInsert(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspOptionSelfCloseInsert callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspOptionSelfCloseAction(CtpInputOptionSelfCloseAction inputOptionSelfCloseAction,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspOptionSelfCloseAction")]
        public static extern void SetOnRspOptionSelfCloseAction(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspOptionSelfCloseAction callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspCombActionInsert(CtpInputCombAction inputCombAction,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspCombActionInsert")]
        public static extern void SetOnRspCombActionInsert(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspCombActionInsert callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryOrder(CtpOrder order,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryOrder")]
        public static extern void SetOnRspQryOrder(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryOrder callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryTrade(CtpTrade trade,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryTrade")]
        public static extern void SetOnRspQryTrade(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryTrade callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryInvestorPosition(CtpInvestorPosition investorPosition,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryInvestorPosition")]
        public static extern void SetOnRspQryInvestorPosition(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryInvestorPosition callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryTradingAccount(CtpTradingAccount tradingAccount,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryTradingAccount")]
        public static extern void SetOnRspQryTradingAccount(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryTradingAccount callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryInvestor(CtpInvestor investor,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryInvestor")]
        public static extern void SetOnRspQryInvestor(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryInvestor callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryTradingCode(CtpTradingCode tradingCode,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryTradingCode")]
        public static extern void SetOnRspQryTradingCode(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryTradingCode callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryInstrumentMarginRate(CtpInstrumentMarginRate instrumentMarginRate,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryInstrumentMarginRate")]
        public static extern void SetOnRspQryInstrumentMarginRate(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryInstrumentMarginRate callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryInstrumentCommissionRate(CtpInstrumentCommissionRate instrumentCommissionRate,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryInstrumentCommissionRate")]
        public static extern void SetOnRspQryInstrumentCommissionRate(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryInstrumentCommissionRate callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryExchange(CtpExchange exchange,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryExchange")]
        public static extern void SetOnRspQryExchange(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryExchange callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryProduct(CtpProduct product,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryProduct")]
        public static extern void SetOnRspQryProduct(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryProduct callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryInstrument(CtpInstrument instrument,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryInstrument")]
        public static extern void SetOnRspQryInstrument(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryInstrument callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryDepthMarketData(CtpDepthMarketData depthMarketData,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryDepthMarketData")]
        public static extern void SetOnRspQryDepthMarketData(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryDepthMarketData callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQrySettlementInfo(CtpSettlementInfo settlementInfo,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQrySettlementInfo")]
        public static extern void SetOnRspQrySettlementInfo(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQrySettlementInfo callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryTransferBank(CtpTransferBank transferBank,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryTransferBank")]
        public static extern void SetOnRspQryTransferBank(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryTransferBank callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryInvestorPositionDetail(CtpInvestorPositionDetail investorPositionDetail,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryInvestorPositionDetail")]
        public static extern void SetOnRspQryInvestorPositionDetail(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryInvestorPositionDetail callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryNotice(CtpNotice notice,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryNotice")]
        public static extern void SetOnRspQryNotice(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryNotice callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQrySettlementInfoConfirm(CtpSettlementInfoConfirm settlementInfoConfirm,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQrySettlementInfoConfirm")]
        public static extern void SetOnRspQrySettlementInfoConfirm(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQrySettlementInfoConfirm callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryInvestorPositionCombineDetail(CtpInvestorPositionCombineDetail investorPositionCombineDetail,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryInvestorPositionCombineDetail")]
        public static extern void SetOnRspQryInvestorPositionCombineDetail(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryInvestorPositionCombineDetail callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryCFMMCTradingAccountKey(CtpCFMMCTradingAccountKey cFMMCTradingAccountKey,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryCFMMCTradingAccountKey")]
        public static extern void SetOnRspQryCFMMCTradingAccountKey(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryCFMMCTradingAccountKey callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryEWarrantOffset(CtpEWarrantOffset eWarrantOffset,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryEWarrantOffset")]
        public static extern void SetOnRspQryEWarrantOffset(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryEWarrantOffset callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryInvestorProductGroupMargin(CtpInvestorProductGroupMargin investorProductGroupMargin,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryInvestorProductGroupMargin")]
        public static extern void SetOnRspQryInvestorProductGroupMargin(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryInvestorProductGroupMargin callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryExchangeMarginRate(CtpExchangeMarginRate exchangeMarginRate,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryExchangeMarginRate")]
        public static extern void SetOnRspQryExchangeMarginRate(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryExchangeMarginRate callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryExchangeMarginRateAdjust(CtpExchangeMarginRateAdjust exchangeMarginRateAdjust,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryExchangeMarginRateAdjust")]
        public static extern void SetOnRspQryExchangeMarginRateAdjust(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryExchangeMarginRateAdjust callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryExchangeRate(CtpExchangeRate exchangeRate,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryExchangeRate")]
        public static extern void SetOnRspQryExchangeRate(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryExchangeRate callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQrySecAgentACIDMap(CtpSecAgentACIDMap secAgentACIDMap,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQrySecAgentACIDMap")]
        public static extern void SetOnRspQrySecAgentACIDMap(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQrySecAgentACIDMap callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryProductExchRate(CtpProductExchRate productExchRate,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryProductExchRate")]
        public static extern void SetOnRspQryProductExchRate(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryProductExchRate callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryProductGroup(CtpProductGroup productGroup,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryProductGroup")]
        public static extern void SetOnRspQryProductGroup(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryProductGroup callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryMMInstrumentCommissionRate(CtpMMInstrumentCommissionRate mMInstrumentCommissionRate,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryMMInstrumentCommissionRate")]
        public static extern void SetOnRspQryMMInstrumentCommissionRate(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryMMInstrumentCommissionRate callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryMMOptionInstrCommRate(CtpMMOptionInstrCommRate mMOptionInstrCommRate,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryMMOptionInstrCommRate")]
        public static extern void SetOnRspQryMMOptionInstrCommRate(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryMMOptionInstrCommRate callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryInstrumentOrderCommRate(CtpInstrumentOrderCommRate instrumentOrderCommRate,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryInstrumentOrderCommRate")]
        public static extern void SetOnRspQryInstrumentOrderCommRate(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryInstrumentOrderCommRate callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQrySecAgentTradingAccount(CtpTradingAccount tradingAccount,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQrySecAgentTradingAccount")]
        public static extern void SetOnRspQrySecAgentTradingAccount(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQrySecAgentTradingAccount callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQrySecAgentCheckMode(CtpSecAgentCheckMode secAgentCheckMode,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQrySecAgentCheckMode")]
        public static extern void SetOnRspQrySecAgentCheckMode(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQrySecAgentCheckMode callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQrySecAgentTradeInfo(CtpSecAgentTradeInfo secAgentTradeInfo,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQrySecAgentTradeInfo")]
        public static extern void SetOnRspQrySecAgentTradeInfo(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQrySecAgentTradeInfo callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryOptionInstrTradeCost(CtpOptionInstrTradeCost optionInstrTradeCost,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryOptionInstrTradeCost")]
        public static extern void SetOnRspQryOptionInstrTradeCost(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryOptionInstrTradeCost callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryOptionInstrCommRate(CtpOptionInstrCommRate optionInstrCommRate,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryOptionInstrCommRate")]
        public static extern void SetOnRspQryOptionInstrCommRate(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryOptionInstrCommRate callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryExecOrder(CtpExecOrder execOrder,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryExecOrder")]
        public static extern void SetOnRspQryExecOrder(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryExecOrder callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryForQuote(CtpForQuote forQuote,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryForQuote")]
        public static extern void SetOnRspQryForQuote(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryForQuote callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryQuote(CtpQuote quote,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryQuote")]
        public static extern void SetOnRspQryQuote(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryQuote callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryOptionSelfClose(CtpOptionSelfClose optionSelfClose,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryOptionSelfClose")]
        public static extern void SetOnRspQryOptionSelfClose(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryOptionSelfClose callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryInvestUnit(CtpInvestUnit investUnit,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryInvestUnit")]
        public static extern void SetOnRspQryInvestUnit(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryInvestUnit callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryCombInstrumentGuard(CtpCombInstrumentGuard combInstrumentGuard,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryCombInstrumentGuard")]
        public static extern void SetOnRspQryCombInstrumentGuard(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryCombInstrumentGuard callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryCombAction(CtpCombAction combAction,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryCombAction")]
        public static extern void SetOnRspQryCombAction(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryCombAction callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryTransferSerial(CtpTransferSerial transferSerial,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryTransferSerial")]
        public static extern void SetOnRspQryTransferSerial(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryTransferSerial callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryAccountregister(CtpAccountregister accountregister,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryAccountregister")]
        public static extern void SetOnRspQryAccountregister(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryAccountregister callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspError(CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspError")]
        public static extern void SetOnRspError(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspError callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRtnOrder(CtpOrder order);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRtnOrder")]
        public static extern void SetOnRtnOrder(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRtnOrder callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRtnTrade(CtpTrade trade);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRtnTrade")]
        public static extern void SetOnRtnTrade(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRtnTrade callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnErrRtnOrderInsert(CtpInputOrder inputOrder,CtpRspInfo rspInfo);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnErrRtnOrderInsert")]
        public static extern void SetOnErrRtnOrderInsert(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnErrRtnOrderInsert callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnErrRtnOrderAction(CtpOrderAction orderAction,CtpRspInfo rspInfo);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnErrRtnOrderAction")]
        public static extern void SetOnErrRtnOrderAction(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnErrRtnOrderAction callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRtnInstrumentStatus(CtpInstrumentStatus instrumentStatus);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRtnInstrumentStatus")]
        public static extern void SetOnRtnInstrumentStatus(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRtnInstrumentStatus callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRtnBulletin(CtpBulletin bulletin);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRtnBulletin")]
        public static extern void SetOnRtnBulletin(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRtnBulletin callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRtnTradingNotice(CtpTradingNoticeInfo tradingNoticeInfo);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRtnTradingNotice")]
        public static extern void SetOnRtnTradingNotice(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRtnTradingNotice callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRtnErrorConditionalOrder(CtpErrorConditionalOrder errorConditionalOrder);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRtnErrorConditionalOrder")]
        public static extern void SetOnRtnErrorConditionalOrder(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRtnErrorConditionalOrder callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRtnExecOrder(CtpExecOrder execOrder);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRtnExecOrder")]
        public static extern void SetOnRtnExecOrder(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRtnExecOrder callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnErrRtnExecOrderInsert(CtpInputExecOrder inputExecOrder,CtpRspInfo rspInfo);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnErrRtnExecOrderInsert")]
        public static extern void SetOnErrRtnExecOrderInsert(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnErrRtnExecOrderInsert callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnErrRtnExecOrderAction(CtpExecOrderAction execOrderAction,CtpRspInfo rspInfo);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnErrRtnExecOrderAction")]
        public static extern void SetOnErrRtnExecOrderAction(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnErrRtnExecOrderAction callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnErrRtnForQuoteInsert(CtpInputForQuote inputForQuote,CtpRspInfo rspInfo);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnErrRtnForQuoteInsert")]
        public static extern void SetOnErrRtnForQuoteInsert(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnErrRtnForQuoteInsert callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRtnQuote(CtpQuote quote);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRtnQuote")]
        public static extern void SetOnRtnQuote(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRtnQuote callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnErrRtnQuoteInsert(CtpInputQuote inputQuote,CtpRspInfo rspInfo);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnErrRtnQuoteInsert")]
        public static extern void SetOnErrRtnQuoteInsert(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnErrRtnQuoteInsert callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnErrRtnQuoteAction(CtpQuoteAction quoteAction,CtpRspInfo rspInfo);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnErrRtnQuoteAction")]
        public static extern void SetOnErrRtnQuoteAction(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnErrRtnQuoteAction callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRtnForQuoteRsp(CtpForQuoteRsp forQuoteRsp);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRtnForQuoteRsp")]
        public static extern void SetOnRtnForQuoteRsp(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRtnForQuoteRsp callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRtnCFMMCTradingAccountToken(CtpCFMMCTradingAccountToken cFMMCTradingAccountToken);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRtnCFMMCTradingAccountToken")]
        public static extern void SetOnRtnCFMMCTradingAccountToken(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRtnCFMMCTradingAccountToken callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnErrRtnBatchOrderAction(CtpBatchOrderAction batchOrderAction,CtpRspInfo rspInfo);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnErrRtnBatchOrderAction")]
        public static extern void SetOnErrRtnBatchOrderAction(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnErrRtnBatchOrderAction callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRtnOptionSelfClose(CtpOptionSelfClose optionSelfClose);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRtnOptionSelfClose")]
        public static extern void SetOnRtnOptionSelfClose(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRtnOptionSelfClose callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnErrRtnOptionSelfCloseInsert(CtpInputOptionSelfClose inputOptionSelfClose,CtpRspInfo rspInfo);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnErrRtnOptionSelfCloseInsert")]
        public static extern void SetOnErrRtnOptionSelfCloseInsert(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnErrRtnOptionSelfCloseInsert callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnErrRtnOptionSelfCloseAction(CtpOptionSelfCloseAction optionSelfCloseAction,CtpRspInfo rspInfo);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnErrRtnOptionSelfCloseAction")]
        public static extern void SetOnErrRtnOptionSelfCloseAction(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnErrRtnOptionSelfCloseAction callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRtnCombAction(CtpCombAction combAction);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRtnCombAction")]
        public static extern void SetOnRtnCombAction(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRtnCombAction callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnErrRtnCombActionInsert(CtpInputCombAction inputCombAction,CtpRspInfo rspInfo);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnErrRtnCombActionInsert")]
        public static extern void SetOnErrRtnCombActionInsert(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnErrRtnCombActionInsert callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryContractBank(CtpContractBank contractBank,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryContractBank")]
        public static extern void SetOnRspQryContractBank(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryContractBank callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryParkedOrder(CtpParkedOrder parkedOrder,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryParkedOrder")]
        public static extern void SetOnRspQryParkedOrder(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryParkedOrder callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryParkedOrderAction(CtpParkedOrderAction parkedOrderAction,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryParkedOrderAction")]
        public static extern void SetOnRspQryParkedOrderAction(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryParkedOrderAction callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryTradingNotice(CtpTradingNotice tradingNotice,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryTradingNotice")]
        public static extern void SetOnRspQryTradingNotice(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryTradingNotice callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryBrokerTradingParams(CtpBrokerTradingParams brokerTradingParams,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryBrokerTradingParams")]
        public static extern void SetOnRspQryBrokerTradingParams(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryBrokerTradingParams callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQryBrokerTradingAlgos(CtpBrokerTradingAlgos brokerTradingAlgos,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQryBrokerTradingAlgos")]
        public static extern void SetOnRspQryBrokerTradingAlgos(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQryBrokerTradingAlgos callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQueryCFMMCTradingAccountToken(CtpQueryCFMMCTradingAccountToken queryCFMMCTradingAccountToken,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQueryCFMMCTradingAccountToken")]
        public static extern void SetOnRspQueryCFMMCTradingAccountToken(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQueryCFMMCTradingAccountToken callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRtnFromBankToFutureByBank(CtpRspTransfer rspTransfer);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRtnFromBankToFutureByBank")]
        public static extern void SetOnRtnFromBankToFutureByBank(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRtnFromBankToFutureByBank callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRtnFromFutureToBankByBank(CtpRspTransfer rspTransfer);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRtnFromFutureToBankByBank")]
        public static extern void SetOnRtnFromFutureToBankByBank(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRtnFromFutureToBankByBank callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRtnRepealFromBankToFutureByBank(CtpRspRepeal rspRepeal);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRtnRepealFromBankToFutureByBank")]
        public static extern void SetOnRtnRepealFromBankToFutureByBank(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRtnRepealFromBankToFutureByBank callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRtnRepealFromFutureToBankByBank(CtpRspRepeal rspRepeal);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRtnRepealFromFutureToBankByBank")]
        public static extern void SetOnRtnRepealFromFutureToBankByBank(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRtnRepealFromFutureToBankByBank callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRtnFromBankToFutureByFuture(CtpRspTransfer rspTransfer);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRtnFromBankToFutureByFuture")]
        public static extern void SetOnRtnFromBankToFutureByFuture(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRtnFromBankToFutureByFuture callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRtnFromFutureToBankByFuture(CtpRspTransfer rspTransfer);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRtnFromFutureToBankByFuture")]
        public static extern void SetOnRtnFromFutureToBankByFuture(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRtnFromFutureToBankByFuture callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRtnRepealFromBankToFutureByFutureManual(CtpRspRepeal rspRepeal);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRtnRepealFromBankToFutureByFutureManual")]
        public static extern void SetOnRtnRepealFromBankToFutureByFutureManual(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRtnRepealFromBankToFutureByFutureManual callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRtnRepealFromFutureToBankByFutureManual(CtpRspRepeal rspRepeal);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRtnRepealFromFutureToBankByFutureManual")]
        public static extern void SetOnRtnRepealFromFutureToBankByFutureManual(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRtnRepealFromFutureToBankByFutureManual callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRtnQueryBankBalanceByFuture(CtpNotifyQueryAccount notifyQueryAccount);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRtnQueryBankBalanceByFuture")]
        public static extern void SetOnRtnQueryBankBalanceByFuture(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRtnQueryBankBalanceByFuture callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnErrRtnBankToFutureByFuture(CtpReqTransfer reqTransfer,CtpRspInfo rspInfo);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnErrRtnBankToFutureByFuture")]
        public static extern void SetOnErrRtnBankToFutureByFuture(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnErrRtnBankToFutureByFuture callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnErrRtnFutureToBankByFuture(CtpReqTransfer reqTransfer,CtpRspInfo rspInfo);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnErrRtnFutureToBankByFuture")]
        public static extern void SetOnErrRtnFutureToBankByFuture(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnErrRtnFutureToBankByFuture callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnErrRtnRepealBankToFutureByFutureManual(CtpReqRepeal reqRepeal,CtpRspInfo rspInfo);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnErrRtnRepealBankToFutureByFutureManual")]
        public static extern void SetOnErrRtnRepealBankToFutureByFutureManual(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnErrRtnRepealBankToFutureByFutureManual callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnErrRtnRepealFutureToBankByFutureManual(CtpReqRepeal reqRepeal,CtpRspInfo rspInfo);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnErrRtnRepealFutureToBankByFutureManual")]
        public static extern void SetOnErrRtnRepealFutureToBankByFutureManual(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnErrRtnRepealFutureToBankByFutureManual callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnErrRtnQueryBankBalanceByFuture(CtpReqQueryAccount reqQueryAccount,CtpRspInfo rspInfo);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnErrRtnQueryBankBalanceByFuture")]
        public static extern void SetOnErrRtnQueryBankBalanceByFuture(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnErrRtnQueryBankBalanceByFuture callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRtnRepealFromBankToFutureByFuture(CtpRspRepeal rspRepeal);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRtnRepealFromBankToFutureByFuture")]
        public static extern void SetOnRtnRepealFromBankToFutureByFuture(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRtnRepealFromBankToFutureByFuture callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRtnRepealFromFutureToBankByFuture(CtpRspRepeal rspRepeal);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRtnRepealFromFutureToBankByFuture")]
        public static extern void SetOnRtnRepealFromFutureToBankByFuture(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRtnRepealFromFutureToBankByFuture callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspFromBankToFutureByFuture(CtpReqTransfer reqTransfer,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspFromBankToFutureByFuture")]
        public static extern void SetOnRspFromBankToFutureByFuture(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspFromBankToFutureByFuture callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspFromFutureToBankByFuture(CtpReqTransfer reqTransfer,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspFromFutureToBankByFuture")]
        public static extern void SetOnRspFromFutureToBankByFuture(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspFromFutureToBankByFuture callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspQueryBankAccountMoneyByFuture(CtpReqQueryAccount reqQueryAccount,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRspQueryBankAccountMoneyByFuture")]
        public static extern void SetOnRspQueryBankAccountMoneyByFuture(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspQueryBankAccountMoneyByFuture callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRtnOpenAccountByBank(CtpOpenAccount openAccount);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRtnOpenAccountByBank")]
        public static extern void SetOnRtnOpenAccountByBank(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRtnOpenAccountByBank callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRtnCancelAccountByBank(CtpCancelAccount cancelAccount);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRtnCancelAccountByBank")]
        public static extern void SetOnRtnCancelAccountByBank(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRtnCancelAccountByBank callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRtnChangeAccountByBank(CtpChangeAccount changeAccount);
        [DllImport("sfit_ctpse_x64",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Trader_Set_OnRtnChangeAccountByBank")]
        public static extern void SetOnRtnChangeAccountByBank(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRtnChangeAccountByBank callback);
        
    }
}