#include "stdafx.h"
#include <ThostFtdcTraderApi.h>

#define CALLBACK _stdcall
#define DLL __declspec(dllexport)

#ifdef __cplusplus
extern "C"
{
#endif

	///当客户端与交易后台建立起通信连接时（还未登录前），该方法被调用。
	typedef void (CALLBACK * Trader_OnFrontConnected)();
	DLL void CALLBACK Trader_Set_OnFrontConnected(void* instance, Trader_OnFrontConnected callback);
	///当客户端与交易后台通信连接断开时，该方法被调用。当发生这个情况后，API会自动重新连接，客户端可不做处理。
	///@param nReason 错误原因
	///        0x1001 网络读失败
	///        0x1002 网络写失败
	///        0x2001 接收心跳超时
	///        0x2002 发送心跳失败
	///        0x2003 收到错误报文
	typedef void (CALLBACK * Trader_OnFrontDisconnected)(int nReason);
	DLL void CALLBACK Trader_Set_OnFrontDisconnected(void* instance, Trader_OnFrontDisconnected callback);
	///心跳超时警告。当长时间未收到报文时，该方法被调用。
	///@param nTimeLapse 距离上次接收报文的时间
	typedef void (CALLBACK * Trader_OnHeartBeatWarning)(int nTimeLapse);
	DLL void CALLBACK Trader_Set_OnHeartBeatWarning(void* instance, Trader_OnHeartBeatWarning callback);
	///客户端认证响应
	typedef void (CALLBACK * Trader_OnRspAuthenticate)(CThostFtdcRspAuthenticateField *pRspAuthenticateField, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspAuthenticate(void* instance, Trader_OnRspAuthenticate callback);
	///登录请求响应
	typedef void (CALLBACK * Trader_OnRspUserLogin)(CThostFtdcRspUserLoginField *pRspUserLogin, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspUserLogin(void* instance, Trader_OnRspUserLogin callback);
	///登出请求响应
	typedef void (CALLBACK * Trader_OnRspUserLogout)(CThostFtdcUserLogoutField *pUserLogout, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspUserLogout(void* instance, Trader_OnRspUserLogout callback);
	///用户口令更新请求响应
	typedef void (CALLBACK * Trader_OnRspUserPasswordUpdate)(CThostFtdcUserPasswordUpdateField *pUserPasswordUpdate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspUserPasswordUpdate(void* instance, Trader_OnRspUserPasswordUpdate callback);
	///资金账户口令更新请求响应
	typedef void (CALLBACK * Trader_OnRspTradingAccountPasswordUpdate)(CThostFtdcTradingAccountPasswordUpdateField *pTradingAccountPasswordUpdate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspTradingAccountPasswordUpdate(void* instance, Trader_OnRspTradingAccountPasswordUpdate callback);
	///报单录入请求响应
	typedef void (CALLBACK * Trader_OnRspOrderInsert)(CThostFtdcInputOrderField *pInputOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspOrderInsert(void* instance, Trader_OnRspOrderInsert callback);
	///预埋单录入请求响应
	typedef void (CALLBACK * Trader_OnRspParkedOrderInsert)(CThostFtdcParkedOrderField *pParkedOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspParkedOrderInsert(void* instance, Trader_OnRspParkedOrderInsert callback);
	///预埋撤单录入请求响应
	typedef void (CALLBACK * Trader_OnRspParkedOrderAction)(CThostFtdcParkedOrderActionField *pParkedOrderAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspParkedOrderAction(void* instance, Trader_OnRspParkedOrderAction callback);
	///报单操作请求响应
	typedef void (CALLBACK * Trader_OnRspOrderAction)(CThostFtdcInputOrderActionField *pInputOrderAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspOrderAction(void* instance, Trader_OnRspOrderAction callback);
	///查询最大报单数量响应
	typedef void (CALLBACK * Trader_OnRspQueryMaxOrderVolume)(CThostFtdcQueryMaxOrderVolumeField *pQueryMaxOrderVolume, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQueryMaxOrderVolume(void* instance, Trader_OnRspQueryMaxOrderVolume callback);
	///投资者结算结果确认响应
	typedef void (CALLBACK * Trader_OnRspSettlementInfoConfirm)(CThostFtdcSettlementInfoConfirmField *pSettlementInfoConfirm, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspSettlementInfoConfirm(void* instance, Trader_OnRspSettlementInfoConfirm callback);
	///删除预埋单响应
	typedef void (CALLBACK * Trader_OnRspRemoveParkedOrder)(CThostFtdcRemoveParkedOrderField *pRemoveParkedOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspRemoveParkedOrder(void* instance, Trader_OnRspRemoveParkedOrder callback);
	///删除预埋撤单响应
	typedef void (CALLBACK * Trader_OnRspRemoveParkedOrderAction)(CThostFtdcRemoveParkedOrderActionField *pRemoveParkedOrderAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspRemoveParkedOrderAction(void* instance, Trader_OnRspRemoveParkedOrderAction callback);
	///执行宣告录入请求响应
	typedef void (CALLBACK * Trader_OnRspExecOrderInsert)(CThostFtdcInputExecOrderField *pInputExecOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspExecOrderInsert(void* instance, Trader_OnRspExecOrderInsert callback);
	///执行宣告操作请求响应
	typedef void (CALLBACK * Trader_OnRspExecOrderAction)(CThostFtdcInputExecOrderActionField *pInputExecOrderAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspExecOrderAction(void* instance, Trader_OnRspExecOrderAction callback);
	///询价录入请求响应
	typedef void (CALLBACK * Trader_OnRspForQuoteInsert)(CThostFtdcInputForQuoteField *pInputForQuote, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspForQuoteInsert(void* instance, Trader_OnRspForQuoteInsert callback);
	///报价录入请求响应
	typedef void (CALLBACK * Trader_OnRspQuoteInsert)(CThostFtdcInputQuoteField *pInputQuote, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQuoteInsert(void* instance, Trader_OnRspQuoteInsert callback);
	///报价操作请求响应
	typedef void (CALLBACK * Trader_OnRspQuoteAction)(CThostFtdcInputQuoteActionField *pInputQuoteAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQuoteAction(void* instance, Trader_OnRspQuoteAction callback);
	///批量报单操作请求响应
	typedef void (CALLBACK * Trader_OnRspBatchOrderAction)(CThostFtdcInputBatchOrderActionField *pInputBatchOrderAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspBatchOrderAction(void* instance, Trader_OnRspBatchOrderAction callback);
	///申请组合录入请求响应
	typedef void (CALLBACK * Trader_OnRspCombActionInsert)(CThostFtdcInputCombActionField *pInputCombAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspCombActionInsert(void* instance, Trader_OnRspCombActionInsert callback);
	///请求查询报单响应
	typedef void (CALLBACK * Trader_OnRspQryOrder)(CThostFtdcOrderField *pOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryOrder(void* instance, Trader_OnRspQryOrder callback);
	///请求查询成交响应
	typedef void (CALLBACK * Trader_OnRspQryTrade)(CThostFtdcTradeField *pTrade, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryTrade(void* instance, Trader_OnRspQryTrade callback);
	///请求查询投资者持仓响应
	typedef void (CALLBACK * Trader_OnRspQryInvestorPosition)(CThostFtdcInvestorPositionField *pInvestorPosition, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryInvestorPosition(void* instance, Trader_OnRspQryInvestorPosition callback);
	///请求查询资金账户响应
	typedef void (CALLBACK * Trader_OnRspQryTradingAccount)(CThostFtdcTradingAccountField *pTradingAccount, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryTradingAccount(void* instance, Trader_OnRspQryTradingAccount callback);
	///请求查询投资者响应
	typedef void (CALLBACK * Trader_OnRspQryInvestor)(CThostFtdcInvestorField *pInvestor, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryInvestor(void* instance, Trader_OnRspQryInvestor callback);
	///请求查询交易编码响应
	typedef void (CALLBACK * Trader_OnRspQryTradingCode)(CThostFtdcTradingCodeField *pTradingCode, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryTradingCode(void* instance, Trader_OnRspQryTradingCode callback);
	///请求查询合约保证金率响应
	typedef void (CALLBACK * Trader_OnRspQryInstrumentMarginRate)(CThostFtdcInstrumentMarginRateField *pInstrumentMarginRate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryInstrumentMarginRate(void* instance, Trader_OnRspQryInstrumentMarginRate callback);
	///请求查询合约手续费率响应
	typedef void (CALLBACK * Trader_OnRspQryInstrumentCommissionRate)(CThostFtdcInstrumentCommissionRateField *pInstrumentCommissionRate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryInstrumentCommissionRate(void* instance, Trader_OnRspQryInstrumentCommissionRate callback);
	///请求查询交易所响应
	typedef void (CALLBACK * Trader_OnRspQryExchange)(CThostFtdcExchangeField *pExchange, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryExchange(void* instance, Trader_OnRspQryExchange callback);
	///请求查询产品响应
	typedef void (CALLBACK * Trader_OnRspQryProduct)(CThostFtdcProductField *pProduct, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryProduct(void* instance, Trader_OnRspQryProduct callback);
	///请求查询合约响应
	typedef void (CALLBACK * Trader_OnRspQryInstrument)(CThostFtdcInstrumentField *pInstrument, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryInstrument(void* instance, Trader_OnRspQryInstrument callback);
	///请求查询行情响应
	typedef void (CALLBACK * Trader_OnRspQryDepthMarketData)(CThostFtdcDepthMarketDataField *pDepthMarketData, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryDepthMarketData(void* instance, Trader_OnRspQryDepthMarketData callback);
	///请求查询投资者结算结果响应
	typedef void (CALLBACK * Trader_OnRspQrySettlementInfo)(CThostFtdcSettlementInfoField *pSettlementInfo, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQrySettlementInfo(void* instance, Trader_OnRspQrySettlementInfo callback);
	///请求查询转帐银行响应
	typedef void (CALLBACK * Trader_OnRspQryTransferBank)(CThostFtdcTransferBankField *pTransferBank, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryTransferBank(void* instance, Trader_OnRspQryTransferBank callback);
	///请求查询投资者持仓明细响应
	typedef void (CALLBACK * Trader_OnRspQryInvestorPositionDetail)(CThostFtdcInvestorPositionDetailField *pInvestorPositionDetail, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryInvestorPositionDetail(void* instance, Trader_OnRspQryInvestorPositionDetail callback);
	///请求查询客户通知响应
	typedef void (CALLBACK * Trader_OnRspQryNotice)(CThostFtdcNoticeField *pNotice, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryNotice(void* instance, Trader_OnRspQryNotice callback);
	///请求查询结算信息确认响应
	typedef void (CALLBACK * Trader_OnRspQrySettlementInfoConfirm)(CThostFtdcSettlementInfoConfirmField *pSettlementInfoConfirm, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQrySettlementInfoConfirm(void* instance, Trader_OnRspQrySettlementInfoConfirm callback);
	///请求查询投资者持仓明细响应
	typedef void (CALLBACK * Trader_OnRspQryInvestorPositionCombineDetail)(CThostFtdcInvestorPositionCombineDetailField *pInvestorPositionCombineDetail, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryInvestorPositionCombineDetail(void* instance, Trader_OnRspQryInvestorPositionCombineDetail callback);
	///查询保证金监管系统经纪公司资金账户密钥响应
	typedef void (CALLBACK * Trader_OnRspQryCFMMCTradingAccountKey)(CThostFtdcCFMMCTradingAccountKeyField *pCFMMCTradingAccountKey, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryCFMMCTradingAccountKey(void* instance, Trader_OnRspQryCFMMCTradingAccountKey callback);
	///请求查询仓单折抵信息响应
	typedef void (CALLBACK * Trader_OnRspQryEWarrantOffset)(CThostFtdcEWarrantOffsetField *pEWarrantOffset, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryEWarrantOffset(void* instance, Trader_OnRspQryEWarrantOffset callback);
	///请求查询投资者品种/跨品种保证金响应
	typedef void (CALLBACK * Trader_OnRspQryInvestorProductGroupMargin)(CThostFtdcInvestorProductGroupMarginField *pInvestorProductGroupMargin, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryInvestorProductGroupMargin(void* instance, Trader_OnRspQryInvestorProductGroupMargin callback);
	///请求查询交易所保证金率响应
	typedef void (CALLBACK * Trader_OnRspQryExchangeMarginRate)(CThostFtdcExchangeMarginRateField *pExchangeMarginRate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryExchangeMarginRate(void* instance, Trader_OnRspQryExchangeMarginRate callback);
	///请求查询交易所调整保证金率响应
	typedef void (CALLBACK * Trader_OnRspQryExchangeMarginRateAdjust)(CThostFtdcExchangeMarginRateAdjustField *pExchangeMarginRateAdjust, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryExchangeMarginRateAdjust(void* instance, Trader_OnRspQryExchangeMarginRateAdjust callback);
	///请求查询汇率响应
	typedef void (CALLBACK * Trader_OnRspQryExchangeRate)(CThostFtdcExchangeRateField *pExchangeRate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryExchangeRate(void* instance, Trader_OnRspQryExchangeRate callback);
	///请求查询二级代理操作员银期权限响应
	typedef void (CALLBACK * Trader_OnRspQrySecAgentACIDMap)(CThostFtdcSecAgentACIDMapField *pSecAgentACIDMap, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQrySecAgentACIDMap(void* instance, Trader_OnRspQrySecAgentACIDMap callback);
	///请求查询产品报价汇率
	typedef void (CALLBACK * Trader_OnRspQryProductExchRate)(CThostFtdcProductExchRateField *pProductExchRate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryProductExchRate(void* instance, Trader_OnRspQryProductExchRate callback);
	///请求查询产品组
	typedef void (CALLBACK * Trader_OnRspQryProductGroup)(CThostFtdcProductGroupField *pProductGroup, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryProductGroup(void* instance, Trader_OnRspQryProductGroup callback);
	///请求查询期权交易成本响应
	typedef void (CALLBACK * Trader_OnRspQryOptionInstrTradeCost)(CThostFtdcOptionInstrTradeCostField *pOptionInstrTradeCost, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryOptionInstrTradeCost(void* instance, Trader_OnRspQryOptionInstrTradeCost callback);
	///请求查询期权合约手续费响应
	typedef void (CALLBACK * Trader_OnRspQryOptionInstrCommRate)(CThostFtdcOptionInstrCommRateField *pOptionInstrCommRate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryOptionInstrCommRate(void* instance, Trader_OnRspQryOptionInstrCommRate callback);
	///请求查询执行宣告响应
	typedef void (CALLBACK * Trader_OnRspQryExecOrder)(CThostFtdcExecOrderField *pExecOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryExecOrder(void* instance, Trader_OnRspQryExecOrder callback);
	///请求查询询价响应
	typedef void (CALLBACK * Trader_OnRspQryForQuote)(CThostFtdcForQuoteField *pForQuote, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryForQuote(void* instance, Trader_OnRspQryForQuote callback);
	///请求查询报价响应
	typedef void (CALLBACK * Trader_OnRspQryQuote)(CThostFtdcQuoteField *pQuote, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryQuote(void* instance, Trader_OnRspQryQuote callback);
	///请求查询组合合约安全系数响应
	typedef void (CALLBACK * Trader_OnRspQryCombInstrumentGuard)(CThostFtdcCombInstrumentGuardField *pCombInstrumentGuard, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryCombInstrumentGuard(void* instance, Trader_OnRspQryCombInstrumentGuard callback);
	///请求查询申请组合响应
	typedef void (CALLBACK * Trader_OnRspQryCombAction)(CThostFtdcCombActionField *pCombAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryCombAction(void* instance, Trader_OnRspQryCombAction callback);
	///请求查询转帐流水响应
	typedef void (CALLBACK * Trader_OnRspQryTransferSerial)(CThostFtdcTransferSerialField *pTransferSerial, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryTransferSerial(void* instance, Trader_OnRspQryTransferSerial callback);
	///请求查询银期签约关系响应
	typedef void (CALLBACK * Trader_OnRspQryAccountregister)(CThostFtdcAccountregisterField *pAccountregister, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryAccountregister(void* instance, Trader_OnRspQryAccountregister callback);
	///错误应答
	typedef void (CALLBACK * Trader_OnRspError)(CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspError(void* instance, Trader_OnRspError callback);
	///报单通知
	typedef void (CALLBACK * Trader_OnRtnOrder)(CThostFtdcOrderField *pOrder);
	DLL void CALLBACK Trader_Set_OnRtnOrder(void* instance, Trader_OnRtnOrder callback);
	///成交通知
	typedef void (CALLBACK * Trader_OnRtnTrade)(CThostFtdcTradeField *pTrade);
	DLL void CALLBACK Trader_Set_OnRtnTrade(void* instance, Trader_OnRtnTrade callback);
	///报单录入错误回报
	typedef void (CALLBACK * Trader_OnErrRtnOrderInsert)(CThostFtdcInputOrderField *pInputOrder, CThostFtdcRspInfoField *pRspInfo);
	DLL void CALLBACK Trader_Set_OnErrRtnOrderInsert(void* instance, Trader_OnErrRtnOrderInsert callback);
	///报单操作错误回报
	typedef void (CALLBACK * Trader_OnErrRtnOrderAction)(CThostFtdcOrderActionField *pOrderAction, CThostFtdcRspInfoField *pRspInfo);
	DLL void CALLBACK Trader_Set_OnErrRtnOrderAction(void* instance, Trader_OnErrRtnOrderAction callback);
	///合约交易状态通知
	typedef void (CALLBACK * Trader_OnRtnInstrumentStatus)(CThostFtdcInstrumentStatusField *pInstrumentStatus);
	DLL void CALLBACK Trader_Set_OnRtnInstrumentStatus(void* instance, Trader_OnRtnInstrumentStatus callback);
	///交易通知
	typedef void (CALLBACK * Trader_OnRtnTradingNotice)(CThostFtdcTradingNoticeInfoField *pTradingNoticeInfo);
	DLL void CALLBACK Trader_Set_OnRtnTradingNotice(void* instance, Trader_OnRtnTradingNotice callback);
	///提示条件单校验错误
	typedef void (CALLBACK * Trader_OnRtnErrorConditionalOrder)(CThostFtdcErrorConditionalOrderField *pErrorConditionalOrder);
	DLL void CALLBACK Trader_Set_OnRtnErrorConditionalOrder(void* instance, Trader_OnRtnErrorConditionalOrder callback);
	///执行宣告通知
	typedef void (CALLBACK * Trader_OnRtnExecOrder)(CThostFtdcExecOrderField *pExecOrder);
	DLL void CALLBACK Trader_Set_OnRtnExecOrder(void* instance, Trader_OnRtnExecOrder callback);
	///执行宣告录入错误回报
	typedef void (CALLBACK * Trader_OnErrRtnExecOrderInsert)(CThostFtdcInputExecOrderField *pInputExecOrder, CThostFtdcRspInfoField *pRspInfo);
	DLL void CALLBACK Trader_Set_OnErrRtnExecOrderInsert(void* instance, Trader_OnErrRtnExecOrderInsert callback);
	///执行宣告操作错误回报
	typedef void (CALLBACK * Trader_OnErrRtnExecOrderAction)(CThostFtdcExecOrderActionField *pExecOrderAction, CThostFtdcRspInfoField *pRspInfo);
	DLL void CALLBACK Trader_Set_OnErrRtnExecOrderAction(void* instance, Trader_OnErrRtnExecOrderAction callback);
	///询价录入错误回报
	typedef void (CALLBACK * Trader_OnErrRtnForQuoteInsert)(CThostFtdcInputForQuoteField *pInputForQuote, CThostFtdcRspInfoField *pRspInfo);
	DLL void CALLBACK Trader_Set_OnErrRtnForQuoteInsert(void* instance, Trader_OnErrRtnForQuoteInsert callback);
	///报价通知
	typedef void (CALLBACK * Trader_OnRtnQuote)(CThostFtdcQuoteField *pQuote);
	DLL void CALLBACK Trader_Set_OnRtnQuote(void* instance, Trader_OnRtnQuote callback);
	///报价录入错误回报
	typedef void (CALLBACK * Trader_OnErrRtnQuoteInsert)(CThostFtdcInputQuoteField *pInputQuote, CThostFtdcRspInfoField *pRspInfo);
	DLL void CALLBACK Trader_Set_OnErrRtnQuoteInsert(void* instance, Trader_OnErrRtnQuoteInsert callback);
	///报价操作错误回报
	typedef void (CALLBACK * Trader_OnErrRtnQuoteAction)(CThostFtdcQuoteActionField *pQuoteAction, CThostFtdcRspInfoField *pRspInfo);
	DLL void CALLBACK Trader_Set_OnErrRtnQuoteAction(void* instance, Trader_OnErrRtnQuoteAction callback);
	///询价通知
	typedef void (CALLBACK * Trader_OnRtnForQuoteRsp)(CThostFtdcForQuoteRspField *pForQuoteRsp);
	DLL void CALLBACK Trader_Set_OnRtnForQuoteRsp(void* instance, Trader_OnRtnForQuoteRsp callback);
	///保证金监控中心用户令牌
	typedef void (CALLBACK * Trader_OnRtnCFMMCTradingAccountToken)(CThostFtdcCFMMCTradingAccountTokenField *pCFMMCTradingAccountToken);
	DLL void CALLBACK Trader_Set_OnRtnCFMMCTradingAccountToken(void* instance, Trader_OnRtnCFMMCTradingAccountToken callback);
	///批量报单操作错误回报
	typedef void (CALLBACK * Trader_OnErrRtnBatchOrderAction)(CThostFtdcBatchOrderActionField *pBatchOrderAction, CThostFtdcRspInfoField *pRspInfo);
	DLL void CALLBACK Trader_Set_OnErrRtnBatchOrderAction(void* instance, Trader_OnErrRtnBatchOrderAction callback);
	///申请组合通知
	typedef void (CALLBACK * Trader_OnRtnCombAction)(CThostFtdcCombActionField *pCombAction);
	DLL void CALLBACK Trader_Set_OnRtnCombAction(void* instance, Trader_OnRtnCombAction callback);
	///申请组合录入错误回报
	typedef void (CALLBACK * Trader_OnErrRtnCombActionInsert)(CThostFtdcInputCombActionField *pInputCombAction, CThostFtdcRspInfoField *pRspInfo);
	DLL void CALLBACK Trader_Set_OnErrRtnCombActionInsert(void* instance, Trader_OnErrRtnCombActionInsert callback);
	///请求查询签约银行响应
	typedef void (CALLBACK * Trader_OnRspQryContractBank)(CThostFtdcContractBankField *pContractBank, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryContractBank(void* instance, Trader_OnRspQryContractBank callback);
	///请求查询预埋单响应
	typedef void (CALLBACK * Trader_OnRspQryParkedOrder)(CThostFtdcParkedOrderField *pParkedOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryParkedOrder(void* instance, Trader_OnRspQryParkedOrder callback);
	///请求查询预埋撤单响应
	typedef void (CALLBACK * Trader_OnRspQryParkedOrderAction)(CThostFtdcParkedOrderActionField *pParkedOrderAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryParkedOrderAction(void* instance, Trader_OnRspQryParkedOrderAction callback);
	///请求查询交易通知响应
	typedef void (CALLBACK * Trader_OnRspQryTradingNotice)(CThostFtdcTradingNoticeField *pTradingNotice, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryTradingNotice(void* instance, Trader_OnRspQryTradingNotice callback);
	///请求查询经纪公司交易参数响应
	typedef void (CALLBACK * Trader_OnRspQryBrokerTradingParams)(CThostFtdcBrokerTradingParamsField *pBrokerTradingParams, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryBrokerTradingParams(void* instance, Trader_OnRspQryBrokerTradingParams callback);
	///请求查询经纪公司交易算法响应
	typedef void (CALLBACK * Trader_OnRspQryBrokerTradingAlgos)(CThostFtdcBrokerTradingAlgosField *pBrokerTradingAlgos, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQryBrokerTradingAlgos(void* instance, Trader_OnRspQryBrokerTradingAlgos callback);
	///请求查询监控中心用户令牌
	typedef void (CALLBACK * Trader_OnRspQueryCFMMCTradingAccountToken)(CThostFtdcQueryCFMMCTradingAccountTokenField *pQueryCFMMCTradingAccountToken, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQueryCFMMCTradingAccountToken(void* instance, Trader_OnRspQueryCFMMCTradingAccountToken callback);
	///银行发起银行资金转期货通知
	typedef void (CALLBACK * Trader_OnRtnFromBankToFutureByBank)(CThostFtdcRspTransferField *pRspTransfer);
	DLL void CALLBACK Trader_Set_OnRtnFromBankToFutureByBank(void* instance, Trader_OnRtnFromBankToFutureByBank callback);
	///银行发起期货资金转银行通知
	typedef void (CALLBACK * Trader_OnRtnFromFutureToBankByBank)(CThostFtdcRspTransferField *pRspTransfer);
	DLL void CALLBACK Trader_Set_OnRtnFromFutureToBankByBank(void* instance, Trader_OnRtnFromFutureToBankByBank callback);
	///银行发起冲正银行转期货通知
	typedef void (CALLBACK * Trader_OnRtnRepealFromBankToFutureByBank)(CThostFtdcRspRepealField *pRspRepeal);
	DLL void CALLBACK Trader_Set_OnRtnRepealFromBankToFutureByBank(void* instance, Trader_OnRtnRepealFromBankToFutureByBank callback);
	///银行发起冲正期货转银行通知
	typedef void (CALLBACK * Trader_OnRtnRepealFromFutureToBankByBank)(CThostFtdcRspRepealField *pRspRepeal);
	DLL void CALLBACK Trader_Set_OnRtnRepealFromFutureToBankByBank(void* instance, Trader_OnRtnRepealFromFutureToBankByBank callback);
	///期货发起银行资金转期货通知
	typedef void (CALLBACK * Trader_OnRtnFromBankToFutureByFuture)(CThostFtdcRspTransferField *pRspTransfer);
	DLL void CALLBACK Trader_Set_OnRtnFromBankToFutureByFuture(void* instance, Trader_OnRtnFromBankToFutureByFuture callback);
	///期货发起期货资金转银行通知
	typedef void (CALLBACK * Trader_OnRtnFromFutureToBankByFuture)(CThostFtdcRspTransferField *pRspTransfer);
	DLL void CALLBACK Trader_Set_OnRtnFromFutureToBankByFuture(void* instance, Trader_OnRtnFromFutureToBankByFuture callback);
	///系统运行时期货端手工发起冲正银行转期货请求，银行处理完毕后报盘发回的通知
	typedef void (CALLBACK * Trader_OnRtnRepealFromBankToFutureByFutureManual)(CThostFtdcRspRepealField *pRspRepeal);
	DLL void CALLBACK Trader_Set_OnRtnRepealFromBankToFutureByFutureManual(void* instance, Trader_OnRtnRepealFromBankToFutureByFutureManual callback);
	///系统运行时期货端手工发起冲正期货转银行请求，银行处理完毕后报盘发回的通知
	typedef void (CALLBACK * Trader_OnRtnRepealFromFutureToBankByFutureManual)(CThostFtdcRspRepealField *pRspRepeal);
	DLL void CALLBACK Trader_Set_OnRtnRepealFromFutureToBankByFutureManual(void* instance, Trader_OnRtnRepealFromFutureToBankByFutureManual callback);
	///期货发起查询银行余额通知
	typedef void (CALLBACK * Trader_OnRtnQueryBankBalanceByFuture)(CThostFtdcNotifyQueryAccountField *pNotifyQueryAccount);
	DLL void CALLBACK Trader_Set_OnRtnQueryBankBalanceByFuture(void* instance, Trader_OnRtnQueryBankBalanceByFuture callback);
	///期货发起银行资金转期货错误回报
	typedef void (CALLBACK * Trader_OnErrRtnBankToFutureByFuture)(CThostFtdcReqTransferField *pReqTransfer, CThostFtdcRspInfoField *pRspInfo);
	DLL void CALLBACK Trader_Set_OnErrRtnBankToFutureByFuture(void* instance, Trader_OnErrRtnBankToFutureByFuture callback);
	///期货发起期货资金转银行错误回报
	typedef void (CALLBACK * Trader_OnErrRtnFutureToBankByFuture)(CThostFtdcReqTransferField *pReqTransfer, CThostFtdcRspInfoField *pRspInfo);
	DLL void CALLBACK Trader_Set_OnErrRtnFutureToBankByFuture(void* instance, Trader_OnErrRtnFutureToBankByFuture callback);
	///系统运行时期货端手工发起冲正银行转期货错误回报
	typedef void (CALLBACK * Trader_OnErrRtnRepealBankToFutureByFutureManual)(CThostFtdcReqRepealField *pReqRepeal, CThostFtdcRspInfoField *pRspInfo);
	DLL void CALLBACK Trader_Set_OnErrRtnRepealBankToFutureByFutureManual(void* instance, Trader_OnErrRtnRepealBankToFutureByFutureManual callback);
	///系统运行时期货端手工发起冲正期货转银行错误回报
	typedef void (CALLBACK * Trader_OnErrRtnRepealFutureToBankByFutureManual)(CThostFtdcReqRepealField *pReqRepeal, CThostFtdcRspInfoField *pRspInfo);
	DLL void CALLBACK Trader_Set_OnErrRtnRepealFutureToBankByFutureManual(void* instance, Trader_OnErrRtnRepealFutureToBankByFutureManual callback);
	///期货发起查询银行余额错误回报
	typedef void (CALLBACK * Trader_OnErrRtnQueryBankBalanceByFuture)(CThostFtdcReqQueryAccountField *pReqQueryAccount, CThostFtdcRspInfoField *pRspInfo);
	DLL void CALLBACK Trader_Set_OnErrRtnQueryBankBalanceByFuture(void* instance, Trader_OnErrRtnQueryBankBalanceByFuture callback);
	///期货发起冲正银行转期货请求，银行处理完毕后报盘发回的通知
	typedef void (CALLBACK * Trader_OnRtnRepealFromBankToFutureByFuture)(CThostFtdcRspRepealField *pRspRepeal);
	DLL void CALLBACK Trader_Set_OnRtnRepealFromBankToFutureByFuture(void* instance, Trader_OnRtnRepealFromBankToFutureByFuture callback);
	///期货发起冲正期货转银行请求，银行处理完毕后报盘发回的通知
	typedef void (CALLBACK * Trader_OnRtnRepealFromFutureToBankByFuture)(CThostFtdcRspRepealField *pRspRepeal);
	DLL void CALLBACK Trader_Set_OnRtnRepealFromFutureToBankByFuture(void* instance, Trader_OnRtnRepealFromFutureToBankByFuture callback);
	///期货发起银行资金转期货应答
	typedef void (CALLBACK * Trader_OnRspFromBankToFutureByFuture)(CThostFtdcReqTransferField *pReqTransfer, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspFromBankToFutureByFuture(void* instance, Trader_OnRspFromBankToFutureByFuture callback);
	///期货发起期货资金转银行应答
	typedef void (CALLBACK * Trader_OnRspFromFutureToBankByFuture)(CThostFtdcReqTransferField *pReqTransfer, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspFromFutureToBankByFuture(void* instance, Trader_OnRspFromFutureToBankByFuture callback);
	///期货发起查询银行余额应答
	typedef void (CALLBACK * Trader_OnRspQueryBankAccountMoneyByFuture)(CThostFtdcReqQueryAccountField *pReqQueryAccount, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Trader_Set_OnRspQueryBankAccountMoneyByFuture(void* instance, Trader_OnRspQueryBankAccountMoneyByFuture callback);
	///银行发起银期开户通知
	typedef void (CALLBACK * Trader_OnRtnOpenAccountByBank)(CThostFtdcOpenAccountField *pOpenAccount);
	DLL void CALLBACK Trader_Set_OnRtnOpenAccountByBank(void* instance, Trader_OnRtnOpenAccountByBank callback);
	///银行发起银期销户通知
	typedef void (CALLBACK * Trader_OnRtnCancelAccountByBank)(CThostFtdcCancelAccountField *pCancelAccount);
	DLL void CALLBACK Trader_Set_OnRtnCancelAccountByBank(void* instance, Trader_OnRtnCancelAccountByBank callback);
	///银行发起变更银行账号通知
	typedef void (CALLBACK * Trader_OnRtnChangeAccountByBank)(CThostFtdcChangeAccountField *pChangeAccount);
	DLL void CALLBACK Trader_Set_OnRtnChangeAccountByBank(void* instance, Trader_OnRtnChangeAccountByBank callback);
	DLL void* CALLBACK Trader_Create(const char* path);
	DLL void CALLBACK Trader_Init(void* instance);
	DLL void CALLBACK Trader_Release(void* instance);
	DLL int CALLBACK Trader_Join(void* instance);
	///获取当前交易日
	///@retrun 获取到的交易日
	///@remark 只有登录成功后,才能得到正确的交易日
	DLL const char* CALLBACK Trader_GetTradingDay(void* instance);
	///注册前置机网络地址
	///@param pszFrontAddress：前置机网络地址。
	///@remark 网络地址的格式为：“protocol://ipaddress:port”，如：”tcp://127.0.0.1:17001”。 
	///@remark “tcp”代表传输协议，“127.0.0.1”代表服务器地址。”17001”代表服务器端口号。
	DLL void CALLBACK Trader_RegisterFront(void* instance, char* frontAddress);
	///注册名字服务器网络地址
	///@param pszNsAddress：名字服务器网络地址。
	///@remark 网络地址的格式为：“protocol://ipaddress:port”，如：”tcp://127.0.0.1:12001”。 
	///@remark “tcp”代表传输协议，“127.0.0.1”代表服务器地址。”12001”代表服务器端口号。
	///@remark RegisterNameServer优先于RegisterFront    
	DLL void CALLBACK Trader_RegisterNameServer(void* instance, char* nsAddress);
	///订阅私有流。
	///@param nResumeType 私有流重传方式  
	///        THOST_TERT_RESTART:从本交易日开始重传
	///        THOST_TERT_RESUME:从上次收到的续传
	///        THOST_TERT_QUICK:只传送登录后私有流的内容
	///@remark 该方法要在Init方法前调用。若不调用则不会收到私有流的数据。
	DLL void CALLBACK Trader_SubscribePrivateTopic(void* instance, int resumeType);

	///订阅公共流。
	///@param nResumeType 公共流重传方式  
	///        THOST_TERT_RESTART:从本交易日开始重传
	///        THOST_TERT_RESUME:从上次收到的续传
	///        THOST_TERT_QUICK:只传送登录后公共流的内容
	///@remark 该方法要在Init方法前调用。若不调用则不会收到公共流的数据。
	DLL void CALLBACK Trader_SubscribePublicTopic(void* instance, int resumeType);
	///客户端认证请求
	DLL int CALLBACK Trader_ReqAuthenticate(void* instance, CThostFtdcReqAuthenticateField *pReqAuthenticateField, int nRequestID);
	///用户登录请求
	DLL int CALLBACK Trader_ReqUserLogin(void* instance, CThostFtdcReqUserLoginField *pReqUserLoginField, int nRequestID);
	///登出请求
	DLL int CALLBACK Trader_ReqUserLogout(void* instance, CThostFtdcUserLogoutField *pUserLogout, int nRequestID);
	///用户口令更新请求
	DLL int CALLBACK Trader_ReqUserPasswordUpdate(void* instance, CThostFtdcUserPasswordUpdateField *pUserPasswordUpdate, int nRequestID);
	///资金账户口令更新请求
	DLL int CALLBACK Trader_ReqTradingAccountPasswordUpdate(void* instance, CThostFtdcTradingAccountPasswordUpdateField *pTradingAccountPasswordUpdate, int nRequestID);
	///报单录入请求
	DLL int CALLBACK Trader_ReqOrderInsert(void* instance, CThostFtdcInputOrderField *pInputOrder, int nRequestID);
	///预埋单录入请求
	DLL int CALLBACK Trader_ReqParkedOrderInsert(void* instance, CThostFtdcParkedOrderField *pParkedOrder, int nRequestID);
	///预埋撤单录入请求
	DLL int CALLBACK Trader_ReqParkedOrderAction(void* instance, CThostFtdcParkedOrderActionField *pParkedOrderAction, int nRequestID);
	///报单操作请求
	DLL int CALLBACK Trader_ReqOrderAction(void* instance, CThostFtdcInputOrderActionField *pInputOrderAction, int nRequestID);
	///查询最大报单数量请求
	DLL int CALLBACK Trader_ReqQueryMaxOrderVolume(void* instance, CThostFtdcQueryMaxOrderVolumeField *pQueryMaxOrderVolume, int nRequestID);
	///投资者结算结果确认
	DLL int CALLBACK Trader_ReqSettlementInfoConfirm(void* instance, CThostFtdcSettlementInfoConfirmField *pSettlementInfoConfirm, int nRequestID);
	///请求删除预埋单
	DLL int CALLBACK Trader_ReqRemoveParkedOrder(void* instance, CThostFtdcRemoveParkedOrderField *pRemoveParkedOrder, int nRequestID);
	///请求删除预埋撤单
	DLL int CALLBACK Trader_ReqRemoveParkedOrderAction(void* instance, CThostFtdcRemoveParkedOrderActionField *pRemoveParkedOrderAction, int nRequestID);
	///执行宣告录入请求
	DLL int CALLBACK Trader_ReqExecOrderInsert(void* instance, CThostFtdcInputExecOrderField *pInputExecOrder, int nRequestID);
	///执行宣告操作请求
	DLL int CALLBACK Trader_ReqExecOrderAction(void* instance, CThostFtdcInputExecOrderActionField *pInputExecOrderAction, int nRequestID);
	///询价录入请求
	DLL int CALLBACK Trader_ReqForQuoteInsert(void* instance, CThostFtdcInputForQuoteField *pInputForQuote, int nRequestID);
	///报价录入请求
	DLL int CALLBACK Trader_ReqQuoteInsert(void* instance, CThostFtdcInputQuoteField *pInputQuote, int nRequestID);
	///报价操作请求
	DLL int CALLBACK Trader_ReqQuoteAction(void* instance, CThostFtdcInputQuoteActionField *pInputQuoteAction, int nRequestID);
	///批量报单操作请求
	DLL int CALLBACK Trader_ReqBatchOrderAction(void* instance, CThostFtdcInputBatchOrderActionField *pInputBatchOrderAction, int nRequestID);
	///申请组合录入请求
	DLL int CALLBACK Trader_ReqCombActionInsert(void* instance, CThostFtdcInputCombActionField *pInputCombAction, int nRequestID);
	///请求查询报单
	DLL int CALLBACK Trader_ReqQryOrder(void* instance, CThostFtdcQryOrderField *pQryOrder, int nRequestID);
	///请求查询成交
	DLL int CALLBACK Trader_ReqQryTrade(void* instance, CThostFtdcQryTradeField *pQryTrade, int nRequestID);
	///请求查询投资者持仓
	DLL int CALLBACK Trader_ReqQryInvestorPosition(void* instance, CThostFtdcQryInvestorPositionField *pQryInvestorPosition, int nRequestID);
	///请求查询资金账户
	DLL int CALLBACK Trader_ReqQryTradingAccount(void* instance, CThostFtdcQryTradingAccountField *pQryTradingAccount, int nRequestID);
	///请求查询投资者
	DLL int CALLBACK Trader_ReqQryInvestor(void* instance, CThostFtdcQryInvestorField *pQryInvestor, int nRequestID);
	///请求查询交易编码
	DLL int CALLBACK Trader_ReqQryTradingCode(void* instance, CThostFtdcQryTradingCodeField *pQryTradingCode, int nRequestID);
	///请求查询合约保证金率
	DLL int CALLBACK Trader_ReqQryInstrumentMarginRate(void* instance, CThostFtdcQryInstrumentMarginRateField *pQryInstrumentMarginRate, int nRequestID);
	///请求查询合约手续费率
	DLL int CALLBACK Trader_ReqQryInstrumentCommissionRate(void* instance, CThostFtdcQryInstrumentCommissionRateField *pQryInstrumentCommissionRate, int nRequestID);
	///请求查询交易所
	DLL int CALLBACK Trader_ReqQryExchange(void* instance, CThostFtdcQryExchangeField *pQryExchange, int nRequestID);
	///请求查询产品
	DLL int CALLBACK Trader_ReqQryProduct(void* instance, CThostFtdcQryProductField *pQryProduct, int nRequestID);
	///请求查询合约
	DLL int CALLBACK Trader_ReqQryInstrument(void* instance, CThostFtdcQryInstrumentField *pQryInstrument, int nRequestID);
	///请求查询行情
	DLL int CALLBACK Trader_ReqQryDepthMarketData(void* instance, CThostFtdcQryDepthMarketDataField *pQryDepthMarketData, int nRequestID);
	///请求查询投资者结算结果
	DLL int CALLBACK Trader_ReqQrySettlementInfo(void* instance, CThostFtdcQrySettlementInfoField *pQrySettlementInfo, int nRequestID);
	///请求查询转帐银行
	DLL int CALLBACK Trader_ReqQryTransferBank(void* instance, CThostFtdcQryTransferBankField *pQryTransferBank, int nRequestID);
	///请求查询投资者持仓明细
	DLL int CALLBACK Trader_ReqQryInvestorPositionDetail(void* instance, CThostFtdcQryInvestorPositionDetailField *pQryInvestorPositionDetail, int nRequestID);
	///请求查询客户通知
	DLL int CALLBACK Trader_ReqQryNotice(void* instance, CThostFtdcQryNoticeField *pQryNotice, int nRequestID);
	///请求查询结算信息确认
	DLL int CALLBACK Trader_ReqQrySettlementInfoConfirm(void* instance, CThostFtdcQrySettlementInfoConfirmField *pQrySettlementInfoConfirm, int nRequestID);
	///请求查询投资者持仓明细
	DLL int CALLBACK Trader_ReqQryInvestorPositionCombineDetail(void* instance, CThostFtdcQryInvestorPositionCombineDetailField *pQryInvestorPositionCombineDetail, int nRequestID);
	///请求查询保证金监管系统经纪公司资金账户密钥
	DLL int CALLBACK Trader_ReqQryCFMMCTradingAccountKey(void* instance, CThostFtdcQryCFMMCTradingAccountKeyField *pQryCFMMCTradingAccountKey, int nRequestID);
	///请求查询仓单折抵信息
	DLL int CALLBACK Trader_ReqQryEWarrantOffset(void* instance, CThostFtdcQryEWarrantOffsetField *pQryEWarrantOffset, int nRequestID);
	///请求查询投资者品种/跨品种保证金
	DLL int CALLBACK Trader_ReqQryInvestorProductGroupMargin(void* instance, CThostFtdcQryInvestorProductGroupMarginField *pQryInvestorProductGroupMargin, int nRequestID);
	///请求查询交易所保证金率
	DLL int CALLBACK Trader_ReqQryExchangeMarginRate(void* instance, CThostFtdcQryExchangeMarginRateField *pQryExchangeMarginRate, int nRequestID);
	///请求查询交易所调整保证金率
	DLL int CALLBACK Trader_ReqQryExchangeMarginRateAdjust(void* instance, CThostFtdcQryExchangeMarginRateAdjustField *pQryExchangeMarginRateAdjust, int nRequestID);
	///请求查询汇率
	DLL int CALLBACK Trader_ReqQryExchangeRate(void* instance, CThostFtdcQryExchangeRateField *pQryExchangeRate, int nRequestID);
	///请求查询二级代理操作员银期权限
	DLL int CALLBACK Trader_ReqQrySecAgentACIDMap(void* instance, CThostFtdcQrySecAgentACIDMapField *pQrySecAgentACIDMap, int nRequestID);
	///请求查询产品报价汇率
	DLL int CALLBACK Trader_ReqQryProductExchRate(void* instance, CThostFtdcQryProductExchRateField *pQryProductExchRate, int nRequestID);
	///请求查询产品组
	DLL int CALLBACK Trader_ReqQryProductGroup(void* instance, CThostFtdcQryProductGroupField *pQryProductGroup, int nRequestID);
	///请求查询期权交易成本
	DLL int CALLBACK Trader_ReqQryOptionInstrTradeCost(void* instance, CThostFtdcQryOptionInstrTradeCostField *pQryOptionInstrTradeCost, int nRequestID);
	///请求查询期权合约手续费
	DLL int CALLBACK Trader_ReqQryOptionInstrCommRate(void* instance, CThostFtdcQryOptionInstrCommRateField *pQryOptionInstrCommRate, int nRequestID);
	///请求查询执行宣告
	DLL int CALLBACK Trader_ReqQryExecOrder(void* instance, CThostFtdcQryExecOrderField *pQryExecOrder, int nRequestID);
	///请求查询询价
	DLL int CALLBACK Trader_ReqQryForQuote(void* instance, CThostFtdcQryForQuoteField *pQryForQuote, int nRequestID);
	///请求查询报价
	DLL int CALLBACK Trader_ReqQryQuote(void* instance, CThostFtdcQryQuoteField *pQryQuote, int nRequestID);
	///请求查询组合合约安全系数
	DLL int CALLBACK Trader_ReqQryCombInstrumentGuard(void* instance, CThostFtdcQryCombInstrumentGuardField *pQryCombInstrumentGuard, int nRequestID);
	///请求查询申请组合
	DLL int CALLBACK Trader_ReqQryCombAction(void* instance, CThostFtdcQryCombActionField *pQryCombAction, int nRequestID);
	///请求查询转帐流水
	DLL int CALLBACK Trader_ReqQryTransferSerial(void* instance, CThostFtdcQryTransferSerialField *pQryTransferSerial, int nRequestID);
	///请求查询银期签约关系
	DLL int CALLBACK Trader_ReqQryAccountregister(void* instance, CThostFtdcQryAccountregisterField *pQryAccountregister, int nRequestID);
	///请求查询签约银行
	DLL int CALLBACK Trader_ReqQryContractBank(void* instance, CThostFtdcQryContractBankField *pQryContractBank, int nRequestID);
	///请求查询预埋单
	DLL int CALLBACK Trader_ReqQryParkedOrder(void* instance, CThostFtdcQryParkedOrderField *pQryParkedOrder, int nRequestID);
	///请求查询预埋撤单
	DLL int CALLBACK Trader_ReqQryParkedOrderAction(void* instance, CThostFtdcQryParkedOrderActionField *pQryParkedOrderAction, int nRequestID);
	///请求查询交易通知
	DLL int CALLBACK Trader_ReqQryTradingNotice(void* instance, CThostFtdcQryTradingNoticeField *pQryTradingNotice, int nRequestID);
	///请求查询经纪公司交易参数
	DLL int CALLBACK Trader_ReqQryBrokerTradingParams(void* instance, CThostFtdcQryBrokerTradingParamsField *pQryBrokerTradingParams, int nRequestID);
	///请求查询经纪公司交易算法
	DLL int CALLBACK Trader_ReqQryBrokerTradingAlgos(void* instance, CThostFtdcQryBrokerTradingAlgosField *pQryBrokerTradingAlgos, int nRequestID);
	///请求查询监控中心用户令牌
	DLL int CALLBACK Trader_ReqQueryCFMMCTradingAccountToken(void* instance, CThostFtdcQueryCFMMCTradingAccountTokenField *pQueryCFMMCTradingAccountToken, int nRequestID);
	///期货发起银行资金转期货请求
	DLL int CALLBACK Trader_ReqFromBankToFutureByFuture(void* instance, CThostFtdcReqTransferField *pReqTransfer, int nRequestID);
	///期货发起期货资金转银行请求
	DLL int CALLBACK Trader_ReqFromFutureToBankByFuture(void* instance, CThostFtdcReqTransferField *pReqTransfer, int nRequestID);
	///期货发起查询银行余额请求
	DLL int CALLBACK Trader_ReqQueryBankAccountMoneyByFuture(void* instance, CThostFtdcReqQueryAccountField *pReqQueryAccount, int nRequestID);
#ifdef __cplusplus
}
#endif

class CMySfitTrader : public CThostFtdcTraderSpi
{
public:
	CThostFtdcTraderApi* native;
	Trader_OnFrontConnected _OnFrontConnected;
	Trader_OnFrontDisconnected _OnFrontDisconnected;
	Trader_OnHeartBeatWarning _OnHeartBeatWarning;
	Trader_OnRspAuthenticate _OnRspAuthenticate;
	Trader_OnRspUserLogin _OnRspUserLogin;
	Trader_OnRspUserLogout _OnRspUserLogout;
	Trader_OnRspUserPasswordUpdate _OnRspUserPasswordUpdate;
	Trader_OnRspTradingAccountPasswordUpdate _OnRspTradingAccountPasswordUpdate;
	Trader_OnRspOrderInsert _OnRspOrderInsert;
	Trader_OnRspParkedOrderInsert _OnRspParkedOrderInsert;
	Trader_OnRspParkedOrderAction _OnRspParkedOrderAction;
	Trader_OnRspOrderAction _OnRspOrderAction;
	Trader_OnRspQueryMaxOrderVolume _OnRspQueryMaxOrderVolume;
	Trader_OnRspSettlementInfoConfirm _OnRspSettlementInfoConfirm;
	Trader_OnRspRemoveParkedOrder _OnRspRemoveParkedOrder;
	Trader_OnRspRemoveParkedOrderAction _OnRspRemoveParkedOrderAction;
	Trader_OnRspExecOrderInsert _OnRspExecOrderInsert;
	Trader_OnRspExecOrderAction _OnRspExecOrderAction;
	Trader_OnRspForQuoteInsert _OnRspForQuoteInsert;
	Trader_OnRspQuoteInsert _OnRspQuoteInsert;
	Trader_OnRspQuoteAction _OnRspQuoteAction;
	Trader_OnRspBatchOrderAction _OnRspBatchOrderAction;
	Trader_OnRspCombActionInsert _OnRspCombActionInsert;
	Trader_OnRspQryOrder _OnRspQryOrder;
	Trader_OnRspQryTrade _OnRspQryTrade;
	Trader_OnRspQryInvestorPosition _OnRspQryInvestorPosition;
	Trader_OnRspQryTradingAccount _OnRspQryTradingAccount;
	Trader_OnRspQryInvestor _OnRspQryInvestor;
	Trader_OnRspQryTradingCode _OnRspQryTradingCode;
	Trader_OnRspQryInstrumentMarginRate _OnRspQryInstrumentMarginRate;
	Trader_OnRspQryInstrumentCommissionRate _OnRspQryInstrumentCommissionRate;
	Trader_OnRspQryExchange _OnRspQryExchange;
	Trader_OnRspQryProduct _OnRspQryProduct;
	Trader_OnRspQryInstrument _OnRspQryInstrument;
	Trader_OnRspQryDepthMarketData _OnRspQryDepthMarketData;
	Trader_OnRspQrySettlementInfo _OnRspQrySettlementInfo;
	Trader_OnRspQryTransferBank _OnRspQryTransferBank;
	Trader_OnRspQryInvestorPositionDetail _OnRspQryInvestorPositionDetail;
	Trader_OnRspQryNotice _OnRspQryNotice;
	Trader_OnRspQrySettlementInfoConfirm _OnRspQrySettlementInfoConfirm;
	Trader_OnRspQryInvestorPositionCombineDetail _OnRspQryInvestorPositionCombineDetail;
	Trader_OnRspQryCFMMCTradingAccountKey _OnRspQryCFMMCTradingAccountKey;
	Trader_OnRspQryEWarrantOffset _OnRspQryEWarrantOffset;
	Trader_OnRspQryInvestorProductGroupMargin _OnRspQryInvestorProductGroupMargin;
	Trader_OnRspQryExchangeMarginRate _OnRspQryExchangeMarginRate;
	Trader_OnRspQryExchangeMarginRateAdjust _OnRspQryExchangeMarginRateAdjust;
	Trader_OnRspQryExchangeRate _OnRspQryExchangeRate;
	Trader_OnRspQrySecAgentACIDMap _OnRspQrySecAgentACIDMap;
	Trader_OnRspQryProductExchRate _OnRspQryProductExchRate;
	Trader_OnRspQryProductGroup _OnRspQryProductGroup;
	Trader_OnRspQryOptionInstrTradeCost _OnRspQryOptionInstrTradeCost;
	Trader_OnRspQryOptionInstrCommRate _OnRspQryOptionInstrCommRate;
	Trader_OnRspQryExecOrder _OnRspQryExecOrder;
	Trader_OnRspQryForQuote _OnRspQryForQuote;
	Trader_OnRspQryQuote _OnRspQryQuote;
	Trader_OnRspQryCombInstrumentGuard _OnRspQryCombInstrumentGuard;
	Trader_OnRspQryCombAction _OnRspQryCombAction;
	Trader_OnRspQryTransferSerial _OnRspQryTransferSerial;
	Trader_OnRspQryAccountregister _OnRspQryAccountregister;
	Trader_OnRspError _OnRspError;
	Trader_OnRtnOrder _OnRtnOrder;
	Trader_OnRtnTrade _OnRtnTrade;
	Trader_OnErrRtnOrderInsert _OnErrRtnOrderInsert;
	Trader_OnErrRtnOrderAction _OnErrRtnOrderAction;
	Trader_OnRtnInstrumentStatus _OnRtnInstrumentStatus;
	Trader_OnRtnTradingNotice _OnRtnTradingNotice;
	Trader_OnRtnErrorConditionalOrder _OnRtnErrorConditionalOrder;
	Trader_OnRtnExecOrder _OnRtnExecOrder;
	Trader_OnErrRtnExecOrderInsert _OnErrRtnExecOrderInsert;
	Trader_OnErrRtnExecOrderAction _OnErrRtnExecOrderAction;
	Trader_OnErrRtnForQuoteInsert _OnErrRtnForQuoteInsert;
	Trader_OnRtnQuote _OnRtnQuote;
	Trader_OnErrRtnQuoteInsert _OnErrRtnQuoteInsert;
	Trader_OnErrRtnQuoteAction _OnErrRtnQuoteAction;
	Trader_OnRtnForQuoteRsp _OnRtnForQuoteRsp;
	Trader_OnRtnCFMMCTradingAccountToken _OnRtnCFMMCTradingAccountToken;
	Trader_OnErrRtnBatchOrderAction _OnErrRtnBatchOrderAction;
	Trader_OnRtnCombAction _OnRtnCombAction;
	Trader_OnErrRtnCombActionInsert _OnErrRtnCombActionInsert;
	Trader_OnRspQryContractBank _OnRspQryContractBank;
	Trader_OnRspQryParkedOrder _OnRspQryParkedOrder;
	Trader_OnRspQryParkedOrderAction _OnRspQryParkedOrderAction;
	Trader_OnRspQryTradingNotice _OnRspQryTradingNotice;
	Trader_OnRspQryBrokerTradingParams _OnRspQryBrokerTradingParams;
	Trader_OnRspQryBrokerTradingAlgos _OnRspQryBrokerTradingAlgos;
	Trader_OnRspQueryCFMMCTradingAccountToken _OnRspQueryCFMMCTradingAccountToken;
	Trader_OnRtnFromBankToFutureByBank _OnRtnFromBankToFutureByBank;
	Trader_OnRtnFromFutureToBankByBank _OnRtnFromFutureToBankByBank;
	Trader_OnRtnRepealFromBankToFutureByBank _OnRtnRepealFromBankToFutureByBank;
	Trader_OnRtnRepealFromFutureToBankByBank _OnRtnRepealFromFutureToBankByBank;
	Trader_OnRtnFromBankToFutureByFuture _OnRtnFromBankToFutureByFuture;
	Trader_OnRtnFromFutureToBankByFuture _OnRtnFromFutureToBankByFuture;
	Trader_OnRtnRepealFromBankToFutureByFutureManual _OnRtnRepealFromBankToFutureByFutureManual;
	Trader_OnRtnRepealFromFutureToBankByFutureManual _OnRtnRepealFromFutureToBankByFutureManual;
	Trader_OnRtnQueryBankBalanceByFuture _OnRtnQueryBankBalanceByFuture;
	Trader_OnErrRtnBankToFutureByFuture _OnErrRtnBankToFutureByFuture;
	Trader_OnErrRtnFutureToBankByFuture _OnErrRtnFutureToBankByFuture;
	Trader_OnErrRtnRepealBankToFutureByFutureManual _OnErrRtnRepealBankToFutureByFutureManual;
	Trader_OnErrRtnRepealFutureToBankByFutureManual _OnErrRtnRepealFutureToBankByFutureManual;
	Trader_OnErrRtnQueryBankBalanceByFuture _OnErrRtnQueryBankBalanceByFuture;
	Trader_OnRtnRepealFromBankToFutureByFuture _OnRtnRepealFromBankToFutureByFuture;
	Trader_OnRtnRepealFromFutureToBankByFuture _OnRtnRepealFromFutureToBankByFuture;
	Trader_OnRspFromBankToFutureByFuture _OnRspFromBankToFutureByFuture;
	Trader_OnRspFromFutureToBankByFuture _OnRspFromFutureToBankByFuture;
	Trader_OnRspQueryBankAccountMoneyByFuture _OnRspQueryBankAccountMoneyByFuture;
	Trader_OnRtnOpenAccountByBank _OnRtnOpenAccountByBank;
	Trader_OnRtnCancelAccountByBank _OnRtnCancelAccountByBank;
	Trader_OnRtnChangeAccountByBank _OnRtnChangeAccountByBank;
public:
	explicit CMySfitTrader(const char* path)
	{
		native = CThostFtdcTraderApi::CreateFtdcTraderApi(path);
		native->RegisterSpi(this);
	};
	virtual ~CMySfitTrader(void)
	{
		native->RegisterSpi(nullptr);
		native->Release();
		native = nullptr;
	};
public:
	///当客户端与交易后台建立起通信连接时（还未登录前），该方法被调用。
	void OnFrontConnected() override
	{
		_OnFrontConnected();
	}
	///当客户端与交易后台通信连接断开时，该方法被调用。当发生这个情况后，API会自动重新连接，客户端可不做处理。
///@param nReason 错误原因
///        0x1001 网络读失败
///        0x1002 网络写失败
///        0x2001 接收心跳超时
///        0x2002 发送心跳失败
///        0x2003 收到错误报文
	void OnFrontDisconnected(int nReason) override
	{
		_OnFrontDisconnected(nReason);
	}
	///心跳超时警告。当长时间未收到报文时，该方法被调用。
///@param nTimeLapse 距离上次接收报文的时间
	void OnHeartBeatWarning(int nTimeLapse) override
	{
		_OnHeartBeatWarning(nTimeLapse);
	}
	///客户端认证响应
	void OnRspAuthenticate(CThostFtdcRspAuthenticateField *pRspAuthenticateField, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspAuthenticate(pRspAuthenticateField, pRspInfo, nRequestID, bIsLast);
	}
	///登录请求响应
	void OnRspUserLogin(CThostFtdcRspUserLoginField *pRspUserLogin, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspUserLogin(pRspUserLogin, pRspInfo, nRequestID, bIsLast);
	}
	///登出请求响应
	void OnRspUserLogout(CThostFtdcUserLogoutField *pUserLogout, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspUserLogout(pUserLogout, pRspInfo, nRequestID, bIsLast);
	}
	///用户口令更新请求响应
	void OnRspUserPasswordUpdate(CThostFtdcUserPasswordUpdateField *pUserPasswordUpdate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspUserPasswordUpdate(pUserPasswordUpdate, pRspInfo, nRequestID, bIsLast);
	}
	///资金账户口令更新请求响应
	void OnRspTradingAccountPasswordUpdate(CThostFtdcTradingAccountPasswordUpdateField *pTradingAccountPasswordUpdate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspTradingAccountPasswordUpdate(pTradingAccountPasswordUpdate, pRspInfo, nRequestID, bIsLast);
	}
	///报单录入请求响应
	void OnRspOrderInsert(CThostFtdcInputOrderField *pInputOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspOrderInsert(pInputOrder, pRspInfo, nRequestID, bIsLast);
	}
	///预埋单录入请求响应
	void OnRspParkedOrderInsert(CThostFtdcParkedOrderField *pParkedOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspParkedOrderInsert(pParkedOrder, pRspInfo, nRequestID, bIsLast);
	}
	///预埋撤单录入请求响应
	void OnRspParkedOrderAction(CThostFtdcParkedOrderActionField *pParkedOrderAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspParkedOrderAction(pParkedOrderAction, pRspInfo, nRequestID, bIsLast);
	}
	///报单操作请求响应
	void OnRspOrderAction(CThostFtdcInputOrderActionField *pInputOrderAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspOrderAction(pInputOrderAction, pRspInfo, nRequestID, bIsLast);
	}
	///查询最大报单数量响应
	void OnRspQueryMaxOrderVolume(CThostFtdcQueryMaxOrderVolumeField *pQueryMaxOrderVolume, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQueryMaxOrderVolume(pQueryMaxOrderVolume, pRspInfo, nRequestID, bIsLast);
	}
	///投资者结算结果确认响应
	void OnRspSettlementInfoConfirm(CThostFtdcSettlementInfoConfirmField *pSettlementInfoConfirm, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspSettlementInfoConfirm(pSettlementInfoConfirm, pRspInfo, nRequestID, bIsLast);
	}
	///删除预埋单响应
	void OnRspRemoveParkedOrder(CThostFtdcRemoveParkedOrderField *pRemoveParkedOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspRemoveParkedOrder(pRemoveParkedOrder, pRspInfo, nRequestID, bIsLast);
	}
	///删除预埋撤单响应
	void OnRspRemoveParkedOrderAction(CThostFtdcRemoveParkedOrderActionField *pRemoveParkedOrderAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspRemoveParkedOrderAction(pRemoveParkedOrderAction, pRspInfo, nRequestID, bIsLast);
	}
	///执行宣告录入请求响应
	void OnRspExecOrderInsert(CThostFtdcInputExecOrderField *pInputExecOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspExecOrderInsert(pInputExecOrder, pRspInfo, nRequestID, bIsLast);
	}
	///执行宣告操作请求响应
	void OnRspExecOrderAction(CThostFtdcInputExecOrderActionField *pInputExecOrderAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspExecOrderAction(pInputExecOrderAction, pRspInfo, nRequestID, bIsLast);
	}
	///询价录入请求响应
	void OnRspForQuoteInsert(CThostFtdcInputForQuoteField *pInputForQuote, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspForQuoteInsert(pInputForQuote, pRspInfo, nRequestID, bIsLast);
	}
	///报价录入请求响应
	void OnRspQuoteInsert(CThostFtdcInputQuoteField *pInputQuote, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQuoteInsert(pInputQuote, pRspInfo, nRequestID, bIsLast);
	}
	///报价操作请求响应
	void OnRspQuoteAction(CThostFtdcInputQuoteActionField *pInputQuoteAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQuoteAction(pInputQuoteAction, pRspInfo, nRequestID, bIsLast);
	}
	///批量报单操作请求响应
	void OnRspBatchOrderAction(CThostFtdcInputBatchOrderActionField *pInputBatchOrderAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspBatchOrderAction(pInputBatchOrderAction, pRspInfo, nRequestID, bIsLast);
	}
	///申请组合录入请求响应
	void OnRspCombActionInsert(CThostFtdcInputCombActionField *pInputCombAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspCombActionInsert(pInputCombAction, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询报单响应
	void OnRspQryOrder(CThostFtdcOrderField *pOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryOrder(pOrder, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询成交响应
	void OnRspQryTrade(CThostFtdcTradeField *pTrade, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryTrade(pTrade, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询投资者持仓响应
	void OnRspQryInvestorPosition(CThostFtdcInvestorPositionField *pInvestorPosition, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryInvestorPosition(pInvestorPosition, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询资金账户响应
	void OnRspQryTradingAccount(CThostFtdcTradingAccountField *pTradingAccount, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryTradingAccount(pTradingAccount, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询投资者响应
	void OnRspQryInvestor(CThostFtdcInvestorField *pInvestor, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryInvestor(pInvestor, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询交易编码响应
	void OnRspQryTradingCode(CThostFtdcTradingCodeField *pTradingCode, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryTradingCode(pTradingCode, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询合约保证金率响应
	void OnRspQryInstrumentMarginRate(CThostFtdcInstrumentMarginRateField *pInstrumentMarginRate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryInstrumentMarginRate(pInstrumentMarginRate, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询合约手续费率响应
	void OnRspQryInstrumentCommissionRate(CThostFtdcInstrumentCommissionRateField *pInstrumentCommissionRate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryInstrumentCommissionRate(pInstrumentCommissionRate, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询交易所响应
	void OnRspQryExchange(CThostFtdcExchangeField *pExchange, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryExchange(pExchange, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询产品响应
	void OnRspQryProduct(CThostFtdcProductField *pProduct, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryProduct(pProduct, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询合约响应
	void OnRspQryInstrument(CThostFtdcInstrumentField *pInstrument, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryInstrument(pInstrument, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询行情响应
	void OnRspQryDepthMarketData(CThostFtdcDepthMarketDataField *pDepthMarketData, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryDepthMarketData(pDepthMarketData, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询投资者结算结果响应
	void OnRspQrySettlementInfo(CThostFtdcSettlementInfoField *pSettlementInfo, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQrySettlementInfo(pSettlementInfo, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询转帐银行响应
	void OnRspQryTransferBank(CThostFtdcTransferBankField *pTransferBank, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryTransferBank(pTransferBank, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询投资者持仓明细响应
	void OnRspQryInvestorPositionDetail(CThostFtdcInvestorPositionDetailField *pInvestorPositionDetail, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryInvestorPositionDetail(pInvestorPositionDetail, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询客户通知响应
	void OnRspQryNotice(CThostFtdcNoticeField *pNotice, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryNotice(pNotice, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询结算信息确认响应
	void OnRspQrySettlementInfoConfirm(CThostFtdcSettlementInfoConfirmField *pSettlementInfoConfirm, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQrySettlementInfoConfirm(pSettlementInfoConfirm, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询投资者持仓明细响应
	void OnRspQryInvestorPositionCombineDetail(CThostFtdcInvestorPositionCombineDetailField *pInvestorPositionCombineDetail, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryInvestorPositionCombineDetail(pInvestorPositionCombineDetail, pRspInfo, nRequestID, bIsLast);
	}
	///查询保证金监管系统经纪公司资金账户密钥响应
	void OnRspQryCFMMCTradingAccountKey(CThostFtdcCFMMCTradingAccountKeyField *pCFMMCTradingAccountKey, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryCFMMCTradingAccountKey(pCFMMCTradingAccountKey, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询仓单折抵信息响应
	void OnRspQryEWarrantOffset(CThostFtdcEWarrantOffsetField *pEWarrantOffset, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryEWarrantOffset(pEWarrantOffset, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询投资者品种/跨品种保证金响应
	void OnRspQryInvestorProductGroupMargin(CThostFtdcInvestorProductGroupMarginField *pInvestorProductGroupMargin, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryInvestorProductGroupMargin(pInvestorProductGroupMargin, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询交易所保证金率响应
	void OnRspQryExchangeMarginRate(CThostFtdcExchangeMarginRateField *pExchangeMarginRate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryExchangeMarginRate(pExchangeMarginRate, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询交易所调整保证金率响应
	void OnRspQryExchangeMarginRateAdjust(CThostFtdcExchangeMarginRateAdjustField *pExchangeMarginRateAdjust, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryExchangeMarginRateAdjust(pExchangeMarginRateAdjust, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询汇率响应
	void OnRspQryExchangeRate(CThostFtdcExchangeRateField *pExchangeRate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryExchangeRate(pExchangeRate, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询二级代理操作员银期权限响应
	void OnRspQrySecAgentACIDMap(CThostFtdcSecAgentACIDMapField *pSecAgentACIDMap, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQrySecAgentACIDMap(pSecAgentACIDMap, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询产品报价汇率
	void OnRspQryProductExchRate(CThostFtdcProductExchRateField *pProductExchRate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryProductExchRate(pProductExchRate, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询产品组
	void OnRspQryProductGroup(CThostFtdcProductGroupField *pProductGroup, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryProductGroup(pProductGroup, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询期权交易成本响应
	void OnRspQryOptionInstrTradeCost(CThostFtdcOptionInstrTradeCostField *pOptionInstrTradeCost, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryOptionInstrTradeCost(pOptionInstrTradeCost, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询期权合约手续费响应
	void OnRspQryOptionInstrCommRate(CThostFtdcOptionInstrCommRateField *pOptionInstrCommRate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryOptionInstrCommRate(pOptionInstrCommRate, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询执行宣告响应
	void OnRspQryExecOrder(CThostFtdcExecOrderField *pExecOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryExecOrder(pExecOrder, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询询价响应
	void OnRspQryForQuote(CThostFtdcForQuoteField *pForQuote, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryForQuote(pForQuote, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询报价响应
	void OnRspQryQuote(CThostFtdcQuoteField *pQuote, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryQuote(pQuote, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询组合合约安全系数响应
	void OnRspQryCombInstrumentGuard(CThostFtdcCombInstrumentGuardField *pCombInstrumentGuard, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryCombInstrumentGuard(pCombInstrumentGuard, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询申请组合响应
	void OnRspQryCombAction(CThostFtdcCombActionField *pCombAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryCombAction(pCombAction, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询转帐流水响应
	void OnRspQryTransferSerial(CThostFtdcTransferSerialField *pTransferSerial, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryTransferSerial(pTransferSerial, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询银期签约关系响应
	void OnRspQryAccountregister(CThostFtdcAccountregisterField *pAccountregister, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryAccountregister(pAccountregister, pRspInfo, nRequestID, bIsLast);
	}
	///错误应答
	void OnRspError(CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspError(pRspInfo, nRequestID, bIsLast);
	}
	///报单通知
	void OnRtnOrder(CThostFtdcOrderField *pOrder) override
	{
		_OnRtnOrder(pOrder);
	}
	///成交通知
	void OnRtnTrade(CThostFtdcTradeField *pTrade) override
	{
		_OnRtnTrade(pTrade);
	}
	///报单录入错误回报
	void OnErrRtnOrderInsert(CThostFtdcInputOrderField *pInputOrder, CThostFtdcRspInfoField *pRspInfo) override
	{
		_OnErrRtnOrderInsert(pInputOrder, pRspInfo);
	}
	///报单操作错误回报
	void OnErrRtnOrderAction(CThostFtdcOrderActionField *pOrderAction, CThostFtdcRspInfoField *pRspInfo) override
	{
		_OnErrRtnOrderAction(pOrderAction, pRspInfo);
	}
	///合约交易状态通知
	void OnRtnInstrumentStatus(CThostFtdcInstrumentStatusField *pInstrumentStatus) override
	{
		_OnRtnInstrumentStatus(pInstrumentStatus);
	}
	///交易通知
	void OnRtnTradingNotice(CThostFtdcTradingNoticeInfoField *pTradingNoticeInfo) override
	{
		_OnRtnTradingNotice(pTradingNoticeInfo);
	}
	///提示条件单校验错误
	void OnRtnErrorConditionalOrder(CThostFtdcErrorConditionalOrderField *pErrorConditionalOrder) override
	{
		_OnRtnErrorConditionalOrder(pErrorConditionalOrder);
	}
	///执行宣告通知
	void OnRtnExecOrder(CThostFtdcExecOrderField *pExecOrder) override
	{
		_OnRtnExecOrder(pExecOrder);
	}
	///执行宣告录入错误回报
	void OnErrRtnExecOrderInsert(CThostFtdcInputExecOrderField *pInputExecOrder, CThostFtdcRspInfoField *pRspInfo) override
	{
		_OnErrRtnExecOrderInsert(pInputExecOrder, pRspInfo);
	}
	///执行宣告操作错误回报
	void OnErrRtnExecOrderAction(CThostFtdcExecOrderActionField *pExecOrderAction, CThostFtdcRspInfoField *pRspInfo) override
	{
		_OnErrRtnExecOrderAction(pExecOrderAction, pRspInfo);
	}
	///询价录入错误回报
	void OnErrRtnForQuoteInsert(CThostFtdcInputForQuoteField *pInputForQuote, CThostFtdcRspInfoField *pRspInfo) override
	{
		_OnErrRtnForQuoteInsert(pInputForQuote, pRspInfo);
	}
	///报价通知
	void OnRtnQuote(CThostFtdcQuoteField *pQuote) override
	{
		_OnRtnQuote(pQuote);
	}
	///报价录入错误回报
	void OnErrRtnQuoteInsert(CThostFtdcInputQuoteField *pInputQuote, CThostFtdcRspInfoField *pRspInfo) override
	{
		_OnErrRtnQuoteInsert(pInputQuote, pRspInfo);
	}
	///报价操作错误回报
	void OnErrRtnQuoteAction(CThostFtdcQuoteActionField *pQuoteAction, CThostFtdcRspInfoField *pRspInfo) override
	{
		_OnErrRtnQuoteAction(pQuoteAction, pRspInfo);
	}
	///询价通知
	void OnRtnForQuoteRsp(CThostFtdcForQuoteRspField *pForQuoteRsp) override
	{
		_OnRtnForQuoteRsp(pForQuoteRsp);
	}
	///保证金监控中心用户令牌
	void OnRtnCFMMCTradingAccountToken(CThostFtdcCFMMCTradingAccountTokenField *pCFMMCTradingAccountToken) override
	{
		_OnRtnCFMMCTradingAccountToken(pCFMMCTradingAccountToken);
	}
	///批量报单操作错误回报
	void OnErrRtnBatchOrderAction(CThostFtdcBatchOrderActionField *pBatchOrderAction, CThostFtdcRspInfoField *pRspInfo) override
	{
		_OnErrRtnBatchOrderAction(pBatchOrderAction, pRspInfo);
	}
	///申请组合通知
	void OnRtnCombAction(CThostFtdcCombActionField *pCombAction) override
	{
		_OnRtnCombAction(pCombAction);
	}
	///申请组合录入错误回报
	void OnErrRtnCombActionInsert(CThostFtdcInputCombActionField *pInputCombAction, CThostFtdcRspInfoField *pRspInfo) override
	{
		_OnErrRtnCombActionInsert(pInputCombAction, pRspInfo);
	}
	///请求查询签约银行响应
	void OnRspQryContractBank(CThostFtdcContractBankField *pContractBank, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryContractBank(pContractBank, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询预埋单响应
	void OnRspQryParkedOrder(CThostFtdcParkedOrderField *pParkedOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryParkedOrder(pParkedOrder, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询预埋撤单响应
	void OnRspQryParkedOrderAction(CThostFtdcParkedOrderActionField *pParkedOrderAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryParkedOrderAction(pParkedOrderAction, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询交易通知响应
	void OnRspQryTradingNotice(CThostFtdcTradingNoticeField *pTradingNotice, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryTradingNotice(pTradingNotice, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询经纪公司交易参数响应
	void OnRspQryBrokerTradingParams(CThostFtdcBrokerTradingParamsField *pBrokerTradingParams, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryBrokerTradingParams(pBrokerTradingParams, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询经纪公司交易算法响应
	void OnRspQryBrokerTradingAlgos(CThostFtdcBrokerTradingAlgosField *pBrokerTradingAlgos, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQryBrokerTradingAlgos(pBrokerTradingAlgos, pRspInfo, nRequestID, bIsLast);
	}
	///请求查询监控中心用户令牌
	void OnRspQueryCFMMCTradingAccountToken(CThostFtdcQueryCFMMCTradingAccountTokenField *pQueryCFMMCTradingAccountToken, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQueryCFMMCTradingAccountToken(pQueryCFMMCTradingAccountToken, pRspInfo, nRequestID, bIsLast);
	}
	///银行发起银行资金转期货通知
	void OnRtnFromBankToFutureByBank(CThostFtdcRspTransferField *pRspTransfer) override
	{
		_OnRtnFromBankToFutureByBank(pRspTransfer);
	}
	///银行发起期货资金转银行通知
	void OnRtnFromFutureToBankByBank(CThostFtdcRspTransferField *pRspTransfer) override
	{
		_OnRtnFromFutureToBankByBank(pRspTransfer);
	}
	///银行发起冲正银行转期货通知
	void OnRtnRepealFromBankToFutureByBank(CThostFtdcRspRepealField *pRspRepeal) override
	{
		_OnRtnRepealFromBankToFutureByBank(pRspRepeal);
	}
	///银行发起冲正期货转银行通知
	void OnRtnRepealFromFutureToBankByBank(CThostFtdcRspRepealField *pRspRepeal) override
	{
		_OnRtnRepealFromFutureToBankByBank(pRspRepeal);
	}
	///期货发起银行资金转期货通知
	void OnRtnFromBankToFutureByFuture(CThostFtdcRspTransferField *pRspTransfer) override
	{
		_OnRtnFromBankToFutureByFuture(pRspTransfer);
	}
	///期货发起期货资金转银行通知
	void OnRtnFromFutureToBankByFuture(CThostFtdcRspTransferField *pRspTransfer) override
	{
		_OnRtnFromFutureToBankByFuture(pRspTransfer);
	}
	///系统运行时期货端手工发起冲正银行转期货请求，银行处理完毕后报盘发回的通知
	void OnRtnRepealFromBankToFutureByFutureManual(CThostFtdcRspRepealField *pRspRepeal) override
	{
		_OnRtnRepealFromBankToFutureByFutureManual(pRspRepeal);
	}
	///系统运行时期货端手工发起冲正期货转银行请求，银行处理完毕后报盘发回的通知
	void OnRtnRepealFromFutureToBankByFutureManual(CThostFtdcRspRepealField *pRspRepeal) override
	{
		_OnRtnRepealFromFutureToBankByFutureManual(pRspRepeal);
	}
	///期货发起查询银行余额通知
	void OnRtnQueryBankBalanceByFuture(CThostFtdcNotifyQueryAccountField *pNotifyQueryAccount) override
	{
		_OnRtnQueryBankBalanceByFuture(pNotifyQueryAccount);
	}
	///期货发起银行资金转期货错误回报
	void OnErrRtnBankToFutureByFuture(CThostFtdcReqTransferField *pReqTransfer, CThostFtdcRspInfoField *pRspInfo) override
	{
		_OnErrRtnBankToFutureByFuture(pReqTransfer, pRspInfo);
	}
	///期货发起期货资金转银行错误回报
	void OnErrRtnFutureToBankByFuture(CThostFtdcReqTransferField *pReqTransfer, CThostFtdcRspInfoField *pRspInfo) override
	{
		_OnErrRtnFutureToBankByFuture(pReqTransfer, pRspInfo);
	}
	///系统运行时期货端手工发起冲正银行转期货错误回报
	void OnErrRtnRepealBankToFutureByFutureManual(CThostFtdcReqRepealField *pReqRepeal, CThostFtdcRspInfoField *pRspInfo) override
	{
		_OnErrRtnRepealBankToFutureByFutureManual(pReqRepeal, pRspInfo);
	}
	///系统运行时期货端手工发起冲正期货转银行错误回报
	void OnErrRtnRepealFutureToBankByFutureManual(CThostFtdcReqRepealField *pReqRepeal, CThostFtdcRspInfoField *pRspInfo) override
	{
		_OnErrRtnRepealFutureToBankByFutureManual(pReqRepeal, pRspInfo);
	}
	///期货发起查询银行余额错误回报
	void OnErrRtnQueryBankBalanceByFuture(CThostFtdcReqQueryAccountField *pReqQueryAccount, CThostFtdcRspInfoField *pRspInfo) override
	{
		_OnErrRtnQueryBankBalanceByFuture(pReqQueryAccount, pRspInfo);
	}
	///期货发起冲正银行转期货请求，银行处理完毕后报盘发回的通知
	void OnRtnRepealFromBankToFutureByFuture(CThostFtdcRspRepealField *pRspRepeal) override
	{
		_OnRtnRepealFromBankToFutureByFuture(pRspRepeal);
	}
	///期货发起冲正期货转银行请求，银行处理完毕后报盘发回的通知
	void OnRtnRepealFromFutureToBankByFuture(CThostFtdcRspRepealField *pRspRepeal) override
	{
		_OnRtnRepealFromFutureToBankByFuture(pRspRepeal);
	}
	///期货发起银行资金转期货应答
	void OnRspFromBankToFutureByFuture(CThostFtdcReqTransferField *pReqTransfer, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspFromBankToFutureByFuture(pReqTransfer, pRspInfo, nRequestID, bIsLast);
	}
	///期货发起期货资金转银行应答
	void OnRspFromFutureToBankByFuture(CThostFtdcReqTransferField *pReqTransfer, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspFromFutureToBankByFuture(pReqTransfer, pRspInfo, nRequestID, bIsLast);
	}
	///期货发起查询银行余额应答
	void OnRspQueryBankAccountMoneyByFuture(CThostFtdcReqQueryAccountField *pReqQueryAccount, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspQueryBankAccountMoneyByFuture(pReqQueryAccount, pRspInfo, nRequestID, bIsLast);
	}
	///银行发起银期开户通知
	void OnRtnOpenAccountByBank(CThostFtdcOpenAccountField *pOpenAccount) override
	{
		_OnRtnOpenAccountByBank(pOpenAccount);
	}
	///银行发起银期销户通知
	void OnRtnCancelAccountByBank(CThostFtdcCancelAccountField *pCancelAccount) override
	{
		_OnRtnCancelAccountByBank(pCancelAccount);
	}
	///银行发起变更银行账号通知
	void OnRtnChangeAccountByBank(CThostFtdcChangeAccountField *pChangeAccount) override
	{
		_OnRtnChangeAccountByBank(pChangeAccount);
	}
};

void CALLBACK Trader_Set_OnFrontConnected(void* instance, Trader_OnFrontConnected callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnFrontConnected = callback;
}
void CALLBACK Trader_Set_OnFrontDisconnected(void* instance, Trader_OnFrontDisconnected callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnFrontDisconnected = callback;
}
void CALLBACK Trader_Set_OnHeartBeatWarning(void* instance, Trader_OnHeartBeatWarning callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnHeartBeatWarning = callback;
}
void CALLBACK Trader_Set_OnRspAuthenticate(void* instance, Trader_OnRspAuthenticate callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspAuthenticate = callback;
}
void CALLBACK Trader_Set_OnRspUserLogin(void* instance, Trader_OnRspUserLogin callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspUserLogin = callback;
}
void CALLBACK Trader_Set_OnRspUserLogout(void* instance, Trader_OnRspUserLogout callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspUserLogout = callback;
}
void CALLBACK Trader_Set_OnRspUserPasswordUpdate(void* instance, Trader_OnRspUserPasswordUpdate callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspUserPasswordUpdate = callback;
}
void CALLBACK Trader_Set_OnRspTradingAccountPasswordUpdate(void* instance, Trader_OnRspTradingAccountPasswordUpdate callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspTradingAccountPasswordUpdate = callback;
}
void CALLBACK Trader_Set_OnRspOrderInsert(void* instance, Trader_OnRspOrderInsert callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspOrderInsert = callback;
}
void CALLBACK Trader_Set_OnRspParkedOrderInsert(void* instance, Trader_OnRspParkedOrderInsert callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspParkedOrderInsert = callback;
}
void CALLBACK Trader_Set_OnRspParkedOrderAction(void* instance, Trader_OnRspParkedOrderAction callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspParkedOrderAction = callback;
}
void CALLBACK Trader_Set_OnRspOrderAction(void* instance, Trader_OnRspOrderAction callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspOrderAction = callback;
}
void CALLBACK Trader_Set_OnRspQueryMaxOrderVolume(void* instance, Trader_OnRspQueryMaxOrderVolume callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQueryMaxOrderVolume = callback;
}
void CALLBACK Trader_Set_OnRspSettlementInfoConfirm(void* instance, Trader_OnRspSettlementInfoConfirm callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspSettlementInfoConfirm = callback;
}
void CALLBACK Trader_Set_OnRspRemoveParkedOrder(void* instance, Trader_OnRspRemoveParkedOrder callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspRemoveParkedOrder = callback;
}
void CALLBACK Trader_Set_OnRspRemoveParkedOrderAction(void* instance, Trader_OnRspRemoveParkedOrderAction callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspRemoveParkedOrderAction = callback;
}
void CALLBACK Trader_Set_OnRspExecOrderInsert(void* instance, Trader_OnRspExecOrderInsert callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspExecOrderInsert = callback;
}
void CALLBACK Trader_Set_OnRspExecOrderAction(void* instance, Trader_OnRspExecOrderAction callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspExecOrderAction = callback;
}
void CALLBACK Trader_Set_OnRspForQuoteInsert(void* instance, Trader_OnRspForQuoteInsert callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspForQuoteInsert = callback;
}
void CALLBACK Trader_Set_OnRspQuoteInsert(void* instance, Trader_OnRspQuoteInsert callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQuoteInsert = callback;
}
void CALLBACK Trader_Set_OnRspQuoteAction(void* instance, Trader_OnRspQuoteAction callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQuoteAction = callback;
}
void CALLBACK Trader_Set_OnRspBatchOrderAction(void* instance, Trader_OnRspBatchOrderAction callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspBatchOrderAction = callback;
}
void CALLBACK Trader_Set_OnRspCombActionInsert(void* instance, Trader_OnRspCombActionInsert callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspCombActionInsert = callback;
}
void CALLBACK Trader_Set_OnRspQryOrder(void* instance, Trader_OnRspQryOrder callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryOrder = callback;
}
void CALLBACK Trader_Set_OnRspQryTrade(void* instance, Trader_OnRspQryTrade callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryTrade = callback;
}
void CALLBACK Trader_Set_OnRspQryInvestorPosition(void* instance, Trader_OnRspQryInvestorPosition callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryInvestorPosition = callback;
}
void CALLBACK Trader_Set_OnRspQryTradingAccount(void* instance, Trader_OnRspQryTradingAccount callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryTradingAccount = callback;
}
void CALLBACK Trader_Set_OnRspQryInvestor(void* instance, Trader_OnRspQryInvestor callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryInvestor = callback;
}
void CALLBACK Trader_Set_OnRspQryTradingCode(void* instance, Trader_OnRspQryTradingCode callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryTradingCode = callback;
}
void CALLBACK Trader_Set_OnRspQryInstrumentMarginRate(void* instance, Trader_OnRspQryInstrumentMarginRate callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryInstrumentMarginRate = callback;
}
void CALLBACK Trader_Set_OnRspQryInstrumentCommissionRate(void* instance, Trader_OnRspQryInstrumentCommissionRate callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryInstrumentCommissionRate = callback;
}
void CALLBACK Trader_Set_OnRspQryExchange(void* instance, Trader_OnRspQryExchange callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryExchange = callback;
}
void CALLBACK Trader_Set_OnRspQryProduct(void* instance, Trader_OnRspQryProduct callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryProduct = callback;
}
void CALLBACK Trader_Set_OnRspQryInstrument(void* instance, Trader_OnRspQryInstrument callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryInstrument = callback;
}
void CALLBACK Trader_Set_OnRspQryDepthMarketData(void* instance, Trader_OnRspQryDepthMarketData callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryDepthMarketData = callback;
}
void CALLBACK Trader_Set_OnRspQrySettlementInfo(void* instance, Trader_OnRspQrySettlementInfo callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQrySettlementInfo = callback;
}
void CALLBACK Trader_Set_OnRspQryTransferBank(void* instance, Trader_OnRspQryTransferBank callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryTransferBank = callback;
}
void CALLBACK Trader_Set_OnRspQryInvestorPositionDetail(void* instance, Trader_OnRspQryInvestorPositionDetail callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryInvestorPositionDetail = callback;
}
void CALLBACK Trader_Set_OnRspQryNotice(void* instance, Trader_OnRspQryNotice callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryNotice = callback;
}
void CALLBACK Trader_Set_OnRspQrySettlementInfoConfirm(void* instance, Trader_OnRspQrySettlementInfoConfirm callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQrySettlementInfoConfirm = callback;
}
void CALLBACK Trader_Set_OnRspQryInvestorPositionCombineDetail(void* instance, Trader_OnRspQryInvestorPositionCombineDetail callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryInvestorPositionCombineDetail = callback;
}
void CALLBACK Trader_Set_OnRspQryCFMMCTradingAccountKey(void* instance, Trader_OnRspQryCFMMCTradingAccountKey callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryCFMMCTradingAccountKey = callback;
}
void CALLBACK Trader_Set_OnRspQryEWarrantOffset(void* instance, Trader_OnRspQryEWarrantOffset callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryEWarrantOffset = callback;
}
void CALLBACK Trader_Set_OnRspQryInvestorProductGroupMargin(void* instance, Trader_OnRspQryInvestorProductGroupMargin callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryInvestorProductGroupMargin = callback;
}
void CALLBACK Trader_Set_OnRspQryExchangeMarginRate(void* instance, Trader_OnRspQryExchangeMarginRate callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryExchangeMarginRate = callback;
}
void CALLBACK Trader_Set_OnRspQryExchangeMarginRateAdjust(void* instance, Trader_OnRspQryExchangeMarginRateAdjust callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryExchangeMarginRateAdjust = callback;
}
void CALLBACK Trader_Set_OnRspQryExchangeRate(void* instance, Trader_OnRspQryExchangeRate callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryExchangeRate = callback;
}
void CALLBACK Trader_Set_OnRspQrySecAgentACIDMap(void* instance, Trader_OnRspQrySecAgentACIDMap callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQrySecAgentACIDMap = callback;
}
void CALLBACK Trader_Set_OnRspQryProductExchRate(void* instance, Trader_OnRspQryProductExchRate callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryProductExchRate = callback;
}
void CALLBACK Trader_Set_OnRspQryProductGroup(void* instance, Trader_OnRspQryProductGroup callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryProductGroup = callback;
}
void CALLBACK Trader_Set_OnRspQryOptionInstrTradeCost(void* instance, Trader_OnRspQryOptionInstrTradeCost callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryOptionInstrTradeCost = callback;
}
void CALLBACK Trader_Set_OnRspQryOptionInstrCommRate(void* instance, Trader_OnRspQryOptionInstrCommRate callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryOptionInstrCommRate = callback;
}
void CALLBACK Trader_Set_OnRspQryExecOrder(void* instance, Trader_OnRspQryExecOrder callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryExecOrder = callback;
}
void CALLBACK Trader_Set_OnRspQryForQuote(void* instance, Trader_OnRspQryForQuote callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryForQuote = callback;
}
void CALLBACK Trader_Set_OnRspQryQuote(void* instance, Trader_OnRspQryQuote callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryQuote = callback;
}
void CALLBACK Trader_Set_OnRspQryCombInstrumentGuard(void* instance, Trader_OnRspQryCombInstrumentGuard callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryCombInstrumentGuard = callback;
}
void CALLBACK Trader_Set_OnRspQryCombAction(void* instance, Trader_OnRspQryCombAction callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryCombAction = callback;
}
void CALLBACK Trader_Set_OnRspQryTransferSerial(void* instance, Trader_OnRspQryTransferSerial callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryTransferSerial = callback;
}
void CALLBACK Trader_Set_OnRspQryAccountregister(void* instance, Trader_OnRspQryAccountregister callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryAccountregister = callback;
}
void CALLBACK Trader_Set_OnRspError(void* instance, Trader_OnRspError callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspError = callback;
}
void CALLBACK Trader_Set_OnRtnOrder(void* instance, Trader_OnRtnOrder callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRtnOrder = callback;
}
void CALLBACK Trader_Set_OnRtnTrade(void* instance, Trader_OnRtnTrade callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRtnTrade = callback;
}
void CALLBACK Trader_Set_OnErrRtnOrderInsert(void* instance, Trader_OnErrRtnOrderInsert callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnErrRtnOrderInsert = callback;
}
void CALLBACK Trader_Set_OnErrRtnOrderAction(void* instance, Trader_OnErrRtnOrderAction callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnErrRtnOrderAction = callback;
}
void CALLBACK Trader_Set_OnRtnInstrumentStatus(void* instance, Trader_OnRtnInstrumentStatus callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRtnInstrumentStatus = callback;
}
void CALLBACK Trader_Set_OnRtnTradingNotice(void* instance, Trader_OnRtnTradingNotice callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRtnTradingNotice = callback;
}
void CALLBACK Trader_Set_OnRtnErrorConditionalOrder(void* instance, Trader_OnRtnErrorConditionalOrder callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRtnErrorConditionalOrder = callback;
}
void CALLBACK Trader_Set_OnRtnExecOrder(void* instance, Trader_OnRtnExecOrder callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRtnExecOrder = callback;
}
void CALLBACK Trader_Set_OnErrRtnExecOrderInsert(void* instance, Trader_OnErrRtnExecOrderInsert callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnErrRtnExecOrderInsert = callback;
}
void CALLBACK Trader_Set_OnErrRtnExecOrderAction(void* instance, Trader_OnErrRtnExecOrderAction callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnErrRtnExecOrderAction = callback;
}
void CALLBACK Trader_Set_OnErrRtnForQuoteInsert(void* instance, Trader_OnErrRtnForQuoteInsert callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnErrRtnForQuoteInsert = callback;
}
void CALLBACK Trader_Set_OnRtnQuote(void* instance, Trader_OnRtnQuote callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRtnQuote = callback;
}
void CALLBACK Trader_Set_OnErrRtnQuoteInsert(void* instance, Trader_OnErrRtnQuoteInsert callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnErrRtnQuoteInsert = callback;
}
void CALLBACK Trader_Set_OnErrRtnQuoteAction(void* instance, Trader_OnErrRtnQuoteAction callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnErrRtnQuoteAction = callback;
}
void CALLBACK Trader_Set_OnRtnForQuoteRsp(void* instance, Trader_OnRtnForQuoteRsp callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRtnForQuoteRsp = callback;
}
void CALLBACK Trader_Set_OnRtnCFMMCTradingAccountToken(void* instance, Trader_OnRtnCFMMCTradingAccountToken callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRtnCFMMCTradingAccountToken = callback;
}
void CALLBACK Trader_Set_OnErrRtnBatchOrderAction(void* instance, Trader_OnErrRtnBatchOrderAction callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnErrRtnBatchOrderAction = callback;
}
void CALLBACK Trader_Set_OnRtnCombAction(void* instance, Trader_OnRtnCombAction callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRtnCombAction = callback;
}
void CALLBACK Trader_Set_OnErrRtnCombActionInsert(void* instance, Trader_OnErrRtnCombActionInsert callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnErrRtnCombActionInsert = callback;
}
void CALLBACK Trader_Set_OnRspQryContractBank(void* instance, Trader_OnRspQryContractBank callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryContractBank = callback;
}
void CALLBACK Trader_Set_OnRspQryParkedOrder(void* instance, Trader_OnRspQryParkedOrder callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryParkedOrder = callback;
}
void CALLBACK Trader_Set_OnRspQryParkedOrderAction(void* instance, Trader_OnRspQryParkedOrderAction callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryParkedOrderAction = callback;
}
void CALLBACK Trader_Set_OnRspQryTradingNotice(void* instance, Trader_OnRspQryTradingNotice callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryTradingNotice = callback;
}
void CALLBACK Trader_Set_OnRspQryBrokerTradingParams(void* instance, Trader_OnRspQryBrokerTradingParams callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryBrokerTradingParams = callback;
}
void CALLBACK Trader_Set_OnRspQryBrokerTradingAlgos(void* instance, Trader_OnRspQryBrokerTradingAlgos callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQryBrokerTradingAlgos = callback;
}
void CALLBACK Trader_Set_OnRspQueryCFMMCTradingAccountToken(void* instance, Trader_OnRspQueryCFMMCTradingAccountToken callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQueryCFMMCTradingAccountToken = callback;
}
void CALLBACK Trader_Set_OnRtnFromBankToFutureByBank(void* instance, Trader_OnRtnFromBankToFutureByBank callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRtnFromBankToFutureByBank = callback;
}
void CALLBACK Trader_Set_OnRtnFromFutureToBankByBank(void* instance, Trader_OnRtnFromFutureToBankByBank callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRtnFromFutureToBankByBank = callback;
}
void CALLBACK Trader_Set_OnRtnRepealFromBankToFutureByBank(void* instance, Trader_OnRtnRepealFromBankToFutureByBank callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRtnRepealFromBankToFutureByBank = callback;
}
void CALLBACK Trader_Set_OnRtnRepealFromFutureToBankByBank(void* instance, Trader_OnRtnRepealFromFutureToBankByBank callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRtnRepealFromFutureToBankByBank = callback;
}
void CALLBACK Trader_Set_OnRtnFromBankToFutureByFuture(void* instance, Trader_OnRtnFromBankToFutureByFuture callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRtnFromBankToFutureByFuture = callback;
}
void CALLBACK Trader_Set_OnRtnFromFutureToBankByFuture(void* instance, Trader_OnRtnFromFutureToBankByFuture callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRtnFromFutureToBankByFuture = callback;
}
void CALLBACK Trader_Set_OnRtnRepealFromBankToFutureByFutureManual(void* instance, Trader_OnRtnRepealFromBankToFutureByFutureManual callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRtnRepealFromBankToFutureByFutureManual = callback;
}
void CALLBACK Trader_Set_OnRtnRepealFromFutureToBankByFutureManual(void* instance, Trader_OnRtnRepealFromFutureToBankByFutureManual callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRtnRepealFromFutureToBankByFutureManual = callback;
}
void CALLBACK Trader_Set_OnRtnQueryBankBalanceByFuture(void* instance, Trader_OnRtnQueryBankBalanceByFuture callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRtnQueryBankBalanceByFuture = callback;
}
void CALLBACK Trader_Set_OnErrRtnBankToFutureByFuture(void* instance, Trader_OnErrRtnBankToFutureByFuture callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnErrRtnBankToFutureByFuture = callback;
}
void CALLBACK Trader_Set_OnErrRtnFutureToBankByFuture(void* instance, Trader_OnErrRtnFutureToBankByFuture callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnErrRtnFutureToBankByFuture = callback;
}
void CALLBACK Trader_Set_OnErrRtnRepealBankToFutureByFutureManual(void* instance, Trader_OnErrRtnRepealBankToFutureByFutureManual callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnErrRtnRepealBankToFutureByFutureManual = callback;
}
void CALLBACK Trader_Set_OnErrRtnRepealFutureToBankByFutureManual(void* instance, Trader_OnErrRtnRepealFutureToBankByFutureManual callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnErrRtnRepealFutureToBankByFutureManual = callback;
}
void CALLBACK Trader_Set_OnErrRtnQueryBankBalanceByFuture(void* instance, Trader_OnErrRtnQueryBankBalanceByFuture callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnErrRtnQueryBankBalanceByFuture = callback;
}
void CALLBACK Trader_Set_OnRtnRepealFromBankToFutureByFuture(void* instance, Trader_OnRtnRepealFromBankToFutureByFuture callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRtnRepealFromBankToFutureByFuture = callback;
}
void CALLBACK Trader_Set_OnRtnRepealFromFutureToBankByFuture(void* instance, Trader_OnRtnRepealFromFutureToBankByFuture callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRtnRepealFromFutureToBankByFuture = callback;
}
void CALLBACK Trader_Set_OnRspFromBankToFutureByFuture(void* instance, Trader_OnRspFromBankToFutureByFuture callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspFromBankToFutureByFuture = callback;
}
void CALLBACK Trader_Set_OnRspFromFutureToBankByFuture(void* instance, Trader_OnRspFromFutureToBankByFuture callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspFromFutureToBankByFuture = callback;
}
void CALLBACK Trader_Set_OnRspQueryBankAccountMoneyByFuture(void* instance, Trader_OnRspQueryBankAccountMoneyByFuture callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRspQueryBankAccountMoneyByFuture = callback;
}
void CALLBACK Trader_Set_OnRtnOpenAccountByBank(void* instance, Trader_OnRtnOpenAccountByBank callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRtnOpenAccountByBank = callback;
}
void CALLBACK Trader_Set_OnRtnCancelAccountByBank(void* instance, Trader_OnRtnCancelAccountByBank callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRtnCancelAccountByBank = callback;
}
void CALLBACK Trader_Set_OnRtnChangeAccountByBank(void* instance, Trader_OnRtnChangeAccountByBank callback)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->_OnRtnChangeAccountByBank = callback;
}
void* CALLBACK Trader_Create(const char* path)
{
	return new CMySfitTrader(path);
}

void CALLBACK Trader_Init(void* instance)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->native->Init();
}

void CALLBACK Trader_Release(void* instance)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	delete api;
}

int CALLBACK Trader_Join(void* instance)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->Join();
}

///获取当前交易日
///@retrun 获取到的交易日
///@remark 只有登录成功后,才能得到正确的交易日
const char* CALLBACK Trader_GetTradingDay(void* instance)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->GetTradingDay();
}
///注册前置机网络地址
///@param pszFrontAddress：前置机网络地址。
///@remark 网络地址的格式为：“protocol://ipaddress:port”，如：”tcp://127.0.0.1:17001”。 
///@remark “tcp”代表传输协议，“127.0.0.1”代表服务器地址。”17001”代表服务器端口号。
void CALLBACK Trader_RegisterFront(void* instance, char* frontAddress)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->native->RegisterFront(frontAddress);
}
///注册名字服务器网络地址
///@param pszNsAddress：名字服务器网络地址。
///@remark 网络地址的格式为：“protocol://ipaddress:port”，如：”tcp://127.0.0.1:12001”。 
///@remark “tcp”代表传输协议，“127.0.0.1”代表服务器地址。”12001”代表服务器端口号。
///@remark RegisterNameServer优先于RegisterFront    
void CALLBACK Trader_RegisterNameServer(void* instance, char* nsAddress)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->native->RegisterNameServer(nsAddress);
}
///订阅私有流。
///@param nResumeType 私有流重传方式  
///        THOST_TERT_RESTART:从本交易日开始重传
///        THOST_TERT_RESUME:从上次收到的续传
///        THOST_TERT_QUICK:只传送登录后私有流的内容
///@remark 该方法要在Init方法前调用。若不调用则不会收到私有流的数据。
void CALLBACK Trader_SubscribePrivateTopic(void* instance, int resumeType)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->native->SubscribePrivateTopic((::THOST_TE_RESUME_TYPE)resumeType);
}

///订阅公共流。
///@param nResumeType 公共流重传方式  
///        THOST_TERT_RESTART:从本交易日开始重传
///        THOST_TERT_RESUME:从上次收到的续传
///        THOST_TERT_QUICK:只传送登录后公共流的内容
///@remark 该方法要在Init方法前调用。若不调用则不会收到公共流的数据。
void CALLBACK Trader_SubscribePublicTopic(void* instance, int resumeType)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	api->native->SubscribePublicTopic((::THOST_TE_RESUME_TYPE)resumeType);
}
///客户端认证请求
int CALLBACK Trader_ReqAuthenticate(void* instance, CThostFtdcReqAuthenticateField *pReqAuthenticateField, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqAuthenticate(pReqAuthenticateField, nRequestID);
}
///用户登录请求
int CALLBACK Trader_ReqUserLogin(void* instance, CThostFtdcReqUserLoginField *pReqUserLoginField, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqUserLogin(pReqUserLoginField, nRequestID);
}
///登出请求
int CALLBACK Trader_ReqUserLogout(void* instance, CThostFtdcUserLogoutField *pUserLogout, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqUserLogout(pUserLogout, nRequestID);
}
///用户口令更新请求
int CALLBACK Trader_ReqUserPasswordUpdate(void* instance, CThostFtdcUserPasswordUpdateField *pUserPasswordUpdate, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqUserPasswordUpdate(pUserPasswordUpdate, nRequestID);
}
///资金账户口令更新请求
int CALLBACK Trader_ReqTradingAccountPasswordUpdate(void* instance, CThostFtdcTradingAccountPasswordUpdateField *pTradingAccountPasswordUpdate, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqTradingAccountPasswordUpdate(pTradingAccountPasswordUpdate, nRequestID);
}
///报单录入请求
int CALLBACK Trader_ReqOrderInsert(void* instance, CThostFtdcInputOrderField *pInputOrder, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqOrderInsert(pInputOrder, nRequestID);
}
///预埋单录入请求
int CALLBACK Trader_ReqParkedOrderInsert(void* instance, CThostFtdcParkedOrderField *pParkedOrder, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqParkedOrderInsert(pParkedOrder, nRequestID);
}
///预埋撤单录入请求
int CALLBACK Trader_ReqParkedOrderAction(void* instance, CThostFtdcParkedOrderActionField *pParkedOrderAction, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqParkedOrderAction(pParkedOrderAction, nRequestID);
}
///报单操作请求
int CALLBACK Trader_ReqOrderAction(void* instance, CThostFtdcInputOrderActionField *pInputOrderAction, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqOrderAction(pInputOrderAction, nRequestID);
}
///查询最大报单数量请求
int CALLBACK Trader_ReqQueryMaxOrderVolume(void* instance, CThostFtdcQueryMaxOrderVolumeField *pQueryMaxOrderVolume, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQueryMaxOrderVolume(pQueryMaxOrderVolume, nRequestID);
}
///投资者结算结果确认
int CALLBACK Trader_ReqSettlementInfoConfirm(void* instance, CThostFtdcSettlementInfoConfirmField *pSettlementInfoConfirm, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqSettlementInfoConfirm(pSettlementInfoConfirm, nRequestID);
}
///请求删除预埋单
int CALLBACK Trader_ReqRemoveParkedOrder(void* instance, CThostFtdcRemoveParkedOrderField *pRemoveParkedOrder, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqRemoveParkedOrder(pRemoveParkedOrder, nRequestID);
}
///请求删除预埋撤单
int CALLBACK Trader_ReqRemoveParkedOrderAction(void* instance, CThostFtdcRemoveParkedOrderActionField *pRemoveParkedOrderAction, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqRemoveParkedOrderAction(pRemoveParkedOrderAction, nRequestID);
}
///执行宣告录入请求
int CALLBACK Trader_ReqExecOrderInsert(void* instance, CThostFtdcInputExecOrderField *pInputExecOrder, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqExecOrderInsert(pInputExecOrder, nRequestID);
}
///执行宣告操作请求
int CALLBACK Trader_ReqExecOrderAction(void* instance, CThostFtdcInputExecOrderActionField *pInputExecOrderAction, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqExecOrderAction(pInputExecOrderAction, nRequestID);
}
///询价录入请求
int CALLBACK Trader_ReqForQuoteInsert(void* instance, CThostFtdcInputForQuoteField *pInputForQuote, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqForQuoteInsert(pInputForQuote, nRequestID);
}
///报价录入请求
int CALLBACK Trader_ReqQuoteInsert(void* instance, CThostFtdcInputQuoteField *pInputQuote, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQuoteInsert(pInputQuote, nRequestID);
}
///报价操作请求
int CALLBACK Trader_ReqQuoteAction(void* instance, CThostFtdcInputQuoteActionField *pInputQuoteAction, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQuoteAction(pInputQuoteAction, nRequestID);
}
///批量报单操作请求
int CALLBACK Trader_ReqBatchOrderAction(void* instance, CThostFtdcInputBatchOrderActionField *pInputBatchOrderAction, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqBatchOrderAction(pInputBatchOrderAction, nRequestID);
}
///申请组合录入请求
int CALLBACK Trader_ReqCombActionInsert(void* instance, CThostFtdcInputCombActionField *pInputCombAction, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqCombActionInsert(pInputCombAction, nRequestID);
}
///请求查询报单
int CALLBACK Trader_ReqQryOrder(void* instance, CThostFtdcQryOrderField *pQryOrder, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryOrder(pQryOrder, nRequestID);
}
///请求查询成交
int CALLBACK Trader_ReqQryTrade(void* instance, CThostFtdcQryTradeField *pQryTrade, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryTrade(pQryTrade, nRequestID);
}
///请求查询投资者持仓
int CALLBACK Trader_ReqQryInvestorPosition(void* instance, CThostFtdcQryInvestorPositionField *pQryInvestorPosition, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryInvestorPosition(pQryInvestorPosition, nRequestID);
}
///请求查询资金账户
int CALLBACK Trader_ReqQryTradingAccount(void* instance, CThostFtdcQryTradingAccountField *pQryTradingAccount, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryTradingAccount(pQryTradingAccount, nRequestID);
}
///请求查询投资者
int CALLBACK Trader_ReqQryInvestor(void* instance, CThostFtdcQryInvestorField *pQryInvestor, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryInvestor(pQryInvestor, nRequestID);
}
///请求查询交易编码
int CALLBACK Trader_ReqQryTradingCode(void* instance, CThostFtdcQryTradingCodeField *pQryTradingCode, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryTradingCode(pQryTradingCode, nRequestID);
}
///请求查询合约保证金率
int CALLBACK Trader_ReqQryInstrumentMarginRate(void* instance, CThostFtdcQryInstrumentMarginRateField *pQryInstrumentMarginRate, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryInstrumentMarginRate(pQryInstrumentMarginRate, nRequestID);
}
///请求查询合约手续费率
int CALLBACK Trader_ReqQryInstrumentCommissionRate(void* instance, CThostFtdcQryInstrumentCommissionRateField *pQryInstrumentCommissionRate, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryInstrumentCommissionRate(pQryInstrumentCommissionRate, nRequestID);
}
///请求查询交易所
int CALLBACK Trader_ReqQryExchange(void* instance, CThostFtdcQryExchangeField *pQryExchange, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryExchange(pQryExchange, nRequestID);
}
///请求查询产品
int CALLBACK Trader_ReqQryProduct(void* instance, CThostFtdcQryProductField *pQryProduct, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryProduct(pQryProduct, nRequestID);
}
///请求查询合约
int CALLBACK Trader_ReqQryInstrument(void* instance, CThostFtdcQryInstrumentField *pQryInstrument, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryInstrument(pQryInstrument, nRequestID);
}
///请求查询行情
int CALLBACK Trader_ReqQryDepthMarketData(void* instance, CThostFtdcQryDepthMarketDataField *pQryDepthMarketData, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryDepthMarketData(pQryDepthMarketData, nRequestID);
}
///请求查询投资者结算结果
int CALLBACK Trader_ReqQrySettlementInfo(void* instance, CThostFtdcQrySettlementInfoField *pQrySettlementInfo, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQrySettlementInfo(pQrySettlementInfo, nRequestID);
}
///请求查询转帐银行
int CALLBACK Trader_ReqQryTransferBank(void* instance, CThostFtdcQryTransferBankField *pQryTransferBank, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryTransferBank(pQryTransferBank, nRequestID);
}
///请求查询投资者持仓明细
int CALLBACK Trader_ReqQryInvestorPositionDetail(void* instance, CThostFtdcQryInvestorPositionDetailField *pQryInvestorPositionDetail, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryInvestorPositionDetail(pQryInvestorPositionDetail, nRequestID);
}
///请求查询客户通知
int CALLBACK Trader_ReqQryNotice(void* instance, CThostFtdcQryNoticeField *pQryNotice, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryNotice(pQryNotice, nRequestID);
}
///请求查询结算信息确认
int CALLBACK Trader_ReqQrySettlementInfoConfirm(void* instance, CThostFtdcQrySettlementInfoConfirmField *pQrySettlementInfoConfirm, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQrySettlementInfoConfirm(pQrySettlementInfoConfirm, nRequestID);
}
///请求查询投资者持仓明细
int CALLBACK Trader_ReqQryInvestorPositionCombineDetail(void* instance, CThostFtdcQryInvestorPositionCombineDetailField *pQryInvestorPositionCombineDetail, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryInvestorPositionCombineDetail(pQryInvestorPositionCombineDetail, nRequestID);
}
///请求查询保证金监管系统经纪公司资金账户密钥
int CALLBACK Trader_ReqQryCFMMCTradingAccountKey(void* instance, CThostFtdcQryCFMMCTradingAccountKeyField *pQryCFMMCTradingAccountKey, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryCFMMCTradingAccountKey(pQryCFMMCTradingAccountKey, nRequestID);
}
///请求查询仓单折抵信息
int CALLBACK Trader_ReqQryEWarrantOffset(void* instance, CThostFtdcQryEWarrantOffsetField *pQryEWarrantOffset, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryEWarrantOffset(pQryEWarrantOffset, nRequestID);
}
///请求查询投资者品种/跨品种保证金
int CALLBACK Trader_ReqQryInvestorProductGroupMargin(void* instance, CThostFtdcQryInvestorProductGroupMarginField *pQryInvestorProductGroupMargin, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryInvestorProductGroupMargin(pQryInvestorProductGroupMargin, nRequestID);
}
///请求查询交易所保证金率
int CALLBACK Trader_ReqQryExchangeMarginRate(void* instance, CThostFtdcQryExchangeMarginRateField *pQryExchangeMarginRate, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryExchangeMarginRate(pQryExchangeMarginRate, nRequestID);
}
///请求查询交易所调整保证金率
int CALLBACK Trader_ReqQryExchangeMarginRateAdjust(void* instance, CThostFtdcQryExchangeMarginRateAdjustField *pQryExchangeMarginRateAdjust, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryExchangeMarginRateAdjust(pQryExchangeMarginRateAdjust, nRequestID);
}
///请求查询汇率
int CALLBACK Trader_ReqQryExchangeRate(void* instance, CThostFtdcQryExchangeRateField *pQryExchangeRate, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryExchangeRate(pQryExchangeRate, nRequestID);
}
///请求查询二级代理操作员银期权限
int CALLBACK Trader_ReqQrySecAgentACIDMap(void* instance, CThostFtdcQrySecAgentACIDMapField *pQrySecAgentACIDMap, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQrySecAgentACIDMap(pQrySecAgentACIDMap, nRequestID);
}
///请求查询产品报价汇率
int CALLBACK Trader_ReqQryProductExchRate(void* instance, CThostFtdcQryProductExchRateField *pQryProductExchRate, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryProductExchRate(pQryProductExchRate, nRequestID);
}
///请求查询产品组
int CALLBACK Trader_ReqQryProductGroup(void* instance, CThostFtdcQryProductGroupField *pQryProductGroup, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryProductGroup(pQryProductGroup, nRequestID);
}
///请求查询期权交易成本
int CALLBACK Trader_ReqQryOptionInstrTradeCost(void* instance, CThostFtdcQryOptionInstrTradeCostField *pQryOptionInstrTradeCost, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryOptionInstrTradeCost(pQryOptionInstrTradeCost, nRequestID);
}
///请求查询期权合约手续费
int CALLBACK Trader_ReqQryOptionInstrCommRate(void* instance, CThostFtdcQryOptionInstrCommRateField *pQryOptionInstrCommRate, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryOptionInstrCommRate(pQryOptionInstrCommRate, nRequestID);
}
///请求查询执行宣告
int CALLBACK Trader_ReqQryExecOrder(void* instance, CThostFtdcQryExecOrderField *pQryExecOrder, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryExecOrder(pQryExecOrder, nRequestID);
}
///请求查询询价
int CALLBACK Trader_ReqQryForQuote(void* instance, CThostFtdcQryForQuoteField *pQryForQuote, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryForQuote(pQryForQuote, nRequestID);
}
///请求查询报价
int CALLBACK Trader_ReqQryQuote(void* instance, CThostFtdcQryQuoteField *pQryQuote, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryQuote(pQryQuote, nRequestID);
}
///请求查询组合合约安全系数
int CALLBACK Trader_ReqQryCombInstrumentGuard(void* instance, CThostFtdcQryCombInstrumentGuardField *pQryCombInstrumentGuard, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryCombInstrumentGuard(pQryCombInstrumentGuard, nRequestID);
}
///请求查询申请组合
int CALLBACK Trader_ReqQryCombAction(void* instance, CThostFtdcQryCombActionField *pQryCombAction, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryCombAction(pQryCombAction, nRequestID);
}
///请求查询转帐流水
int CALLBACK Trader_ReqQryTransferSerial(void* instance, CThostFtdcQryTransferSerialField *pQryTransferSerial, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryTransferSerial(pQryTransferSerial, nRequestID);
}
///请求查询银期签约关系
int CALLBACK Trader_ReqQryAccountregister(void* instance, CThostFtdcQryAccountregisterField *pQryAccountregister, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryAccountregister(pQryAccountregister, nRequestID);
}
///请求查询签约银行
int CALLBACK Trader_ReqQryContractBank(void* instance, CThostFtdcQryContractBankField *pQryContractBank, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryContractBank(pQryContractBank, nRequestID);
}
///请求查询预埋单
int CALLBACK Trader_ReqQryParkedOrder(void* instance, CThostFtdcQryParkedOrderField *pQryParkedOrder, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryParkedOrder(pQryParkedOrder, nRequestID);
}
///请求查询预埋撤单
int CALLBACK Trader_ReqQryParkedOrderAction(void* instance, CThostFtdcQryParkedOrderActionField *pQryParkedOrderAction, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryParkedOrderAction(pQryParkedOrderAction, nRequestID);
}
///请求查询交易通知
int CALLBACK Trader_ReqQryTradingNotice(void* instance, CThostFtdcQryTradingNoticeField *pQryTradingNotice, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryTradingNotice(pQryTradingNotice, nRequestID);
}
///请求查询经纪公司交易参数
int CALLBACK Trader_ReqQryBrokerTradingParams(void* instance, CThostFtdcQryBrokerTradingParamsField *pQryBrokerTradingParams, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryBrokerTradingParams(pQryBrokerTradingParams, nRequestID);
}
///请求查询经纪公司交易算法
int CALLBACK Trader_ReqQryBrokerTradingAlgos(void* instance, CThostFtdcQryBrokerTradingAlgosField *pQryBrokerTradingAlgos, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQryBrokerTradingAlgos(pQryBrokerTradingAlgos, nRequestID);
}
///请求查询监控中心用户令牌
int CALLBACK Trader_ReqQueryCFMMCTradingAccountToken(void* instance, CThostFtdcQueryCFMMCTradingAccountTokenField *pQueryCFMMCTradingAccountToken, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQueryCFMMCTradingAccountToken(pQueryCFMMCTradingAccountToken, nRequestID);
}
///期货发起银行资金转期货请求
int CALLBACK Trader_ReqFromBankToFutureByFuture(void* instance, CThostFtdcReqTransferField *pReqTransfer, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqFromBankToFutureByFuture(pReqTransfer, nRequestID);
}
///期货发起期货资金转银行请求
int CALLBACK Trader_ReqFromFutureToBankByFuture(void* instance, CThostFtdcReqTransferField *pReqTransfer, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqFromFutureToBankByFuture(pReqTransfer, nRequestID);
}
///期货发起查询银行余额请求
int CALLBACK Trader_ReqQueryBankAccountMoneyByFuture(void* instance, CThostFtdcReqQueryAccountField *pReqQueryAccount, int nRequestID)
{
	auto api = static_cast<CMySfitTrader*>(instance);
	return api->native->ReqQueryBankAccountMoneyByFuture(pReqQueryAccount, nRequestID);
}
