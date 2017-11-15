#pragma once

#include <msclr\auto_gcroot.h>
#include <ThostFtdcTraderApi.h>
#include "CtpConvert.hpp"

using namespace msclr;
using namespace System;

namespace QuantBox {
	namespace Sfit {
		namespace Api {
			class CTraderSpi : public CThostFtdcTraderSpi
			{
			private:
				auto_gcroot<CtpTraderSpi^> _callback;
			public:
				CTraderSpi(auto_gcroot<CtpTraderSpi^> callback) { _callback = callback; }
				CTraderSpi(void) {};
				~CTraderSpi(void) {};
			public:
				///当客户端与交易后台建立起通信连接时（还未登录前），该方法被调用。
				virtual void OnFrontConnected()
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnFrontConnected;
					_callback->ProcessResponse(rsp);
				}

				///当客户端与交易后台通信连接断开时，该方法被调用。当发生这个情况后，API会自动重新连接，客户端可不做处理。
		///@param nReason 错误原因
		///        0x1001 网络读失败
		///        0x1002 网络写失败
		///        0x2001 接收心跳超时
		///        0x2002 发送心跳失败
		///        0x2003 收到错误报文
				virtual void OnFrontDisconnected(int nReason)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnFrontDisconnected;
					rsp.Item1 = CtpAny(nReason);
					_callback->ProcessResponse(rsp);
				}

				///心跳超时警告。当长时间未收到报文时，该方法被调用。
		///@param nTimeLapse 距离上次接收报文的时间
				virtual void OnHeartBeatWarning(int nTimeLapse)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnHeartBeatWarning;
					rsp.Item1 = CtpAny(nTimeLapse);
					_callback->ProcessResponse(rsp);
				}

				///客户端认证响应
				virtual void OnRspAuthenticate(CThostFtdcRspAuthenticateField *pRspAuthenticateField, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspAuthenticate;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pRspAuthenticateField));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///登录请求响应
				virtual void OnRspUserLogin(CThostFtdcRspUserLoginField *pRspUserLogin, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspUserLogin;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pRspUserLogin));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///登出请求响应
				virtual void OnRspUserLogout(CThostFtdcUserLogoutField *pUserLogout, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspUserLogout;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pUserLogout));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///用户口令更新请求响应
				virtual void OnRspUserPasswordUpdate(CThostFtdcUserPasswordUpdateField *pUserPasswordUpdate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspUserPasswordUpdate;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pUserPasswordUpdate));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///资金账户口令更新请求响应
				virtual void OnRspTradingAccountPasswordUpdate(CThostFtdcTradingAccountPasswordUpdateField *pTradingAccountPasswordUpdate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspTradingAccountPasswordUpdate;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pTradingAccountPasswordUpdate));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///报单录入请求响应
				virtual void OnRspOrderInsert(CThostFtdcInputOrderField *pInputOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspOrderInsert;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pInputOrder));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///预埋单录入请求响应
				virtual void OnRspParkedOrderInsert(CThostFtdcParkedOrderField *pParkedOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspParkedOrderInsert;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pParkedOrder));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///预埋撤单录入请求响应
				virtual void OnRspParkedOrderAction(CThostFtdcParkedOrderActionField *pParkedOrderAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspParkedOrderAction;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pParkedOrderAction));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///报单操作请求响应
				virtual void OnRspOrderAction(CThostFtdcInputOrderActionField *pInputOrderAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspOrderAction;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pInputOrderAction));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///查询最大报单数量响应
				virtual void OnRspQueryMaxOrderVolume(CThostFtdcQueryMaxOrderVolumeField *pQueryMaxOrderVolume, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQueryMaxOrderVolume;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pQueryMaxOrderVolume));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///投资者结算结果确认响应
				virtual void OnRspSettlementInfoConfirm(CThostFtdcSettlementInfoConfirmField *pSettlementInfoConfirm, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspSettlementInfoConfirm;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pSettlementInfoConfirm));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///删除预埋单响应
				virtual void OnRspRemoveParkedOrder(CThostFtdcRemoveParkedOrderField *pRemoveParkedOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspRemoveParkedOrder;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pRemoveParkedOrder));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///删除预埋撤单响应
				virtual void OnRspRemoveParkedOrderAction(CThostFtdcRemoveParkedOrderActionField *pRemoveParkedOrderAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspRemoveParkedOrderAction;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pRemoveParkedOrderAction));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///执行宣告录入请求响应
				virtual void OnRspExecOrderInsert(CThostFtdcInputExecOrderField *pInputExecOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspExecOrderInsert;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pInputExecOrder));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///执行宣告操作请求响应
				virtual void OnRspExecOrderAction(CThostFtdcInputExecOrderActionField *pInputExecOrderAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspExecOrderAction;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pInputExecOrderAction));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///询价录入请求响应
				virtual void OnRspForQuoteInsert(CThostFtdcInputForQuoteField *pInputForQuote, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspForQuoteInsert;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pInputForQuote));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///报价录入请求响应
				virtual void OnRspQuoteInsert(CThostFtdcInputQuoteField *pInputQuote, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQuoteInsert;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pInputQuote));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///报价操作请求响应
				virtual void OnRspQuoteAction(CThostFtdcInputQuoteActionField *pInputQuoteAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQuoteAction;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pInputQuoteAction));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///批量报单操作请求响应
				virtual void OnRspBatchOrderAction(CThostFtdcInputBatchOrderActionField *pInputBatchOrderAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspBatchOrderAction;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pInputBatchOrderAction));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///申请组合录入请求响应
				virtual void OnRspCombActionInsert(CThostFtdcInputCombActionField *pInputCombAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspCombActionInsert;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pInputCombAction));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询报单响应
				virtual void OnRspQryOrder(CThostFtdcOrderField *pOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryOrder;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pOrder));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询成交响应
				virtual void OnRspQryTrade(CThostFtdcTradeField *pTrade, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryTrade;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pTrade));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询投资者持仓响应
				virtual void OnRspQryInvestorPosition(CThostFtdcInvestorPositionField *pInvestorPosition, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryInvestorPosition;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pInvestorPosition));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询资金账户响应
				virtual void OnRspQryTradingAccount(CThostFtdcTradingAccountField *pTradingAccount, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryTradingAccount;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pTradingAccount));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询投资者响应
				virtual void OnRspQryInvestor(CThostFtdcInvestorField *pInvestor, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryInvestor;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pInvestor));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询交易编码响应
				virtual void OnRspQryTradingCode(CThostFtdcTradingCodeField *pTradingCode, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryTradingCode;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pTradingCode));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询合约保证金率响应
				virtual void OnRspQryInstrumentMarginRate(CThostFtdcInstrumentMarginRateField *pInstrumentMarginRate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryInstrumentMarginRate;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pInstrumentMarginRate));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询合约手续费率响应
				virtual void OnRspQryInstrumentCommissionRate(CThostFtdcInstrumentCommissionRateField *pInstrumentCommissionRate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryInstrumentCommissionRate;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pInstrumentCommissionRate));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询交易所响应
				virtual void OnRspQryExchange(CThostFtdcExchangeField *pExchange, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryExchange;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pExchange));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询产品响应
				virtual void OnRspQryProduct(CThostFtdcProductField *pProduct, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryProduct;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pProduct));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询合约响应
				virtual void OnRspQryInstrument(CThostFtdcInstrumentField *pInstrument, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryInstrument;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pInstrument));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询行情响应
				virtual void OnRspQryDepthMarketData(CThostFtdcDepthMarketDataField *pDepthMarketData, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryDepthMarketData;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pDepthMarketData));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询投资者结算结果响应
				virtual void OnRspQrySettlementInfo(CThostFtdcSettlementInfoField *pSettlementInfo, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQrySettlementInfo;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pSettlementInfo));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询转帐银行响应
				virtual void OnRspQryTransferBank(CThostFtdcTransferBankField *pTransferBank, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryTransferBank;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pTransferBank));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询投资者持仓明细响应
				virtual void OnRspQryInvestorPositionDetail(CThostFtdcInvestorPositionDetailField *pInvestorPositionDetail, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryInvestorPositionDetail;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pInvestorPositionDetail));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询客户通知响应
				virtual void OnRspQryNotice(CThostFtdcNoticeField *pNotice, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryNotice;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pNotice));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询结算信息确认响应
				virtual void OnRspQrySettlementInfoConfirm(CThostFtdcSettlementInfoConfirmField *pSettlementInfoConfirm, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQrySettlementInfoConfirm;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pSettlementInfoConfirm));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询投资者持仓明细响应
				virtual void OnRspQryInvestorPositionCombineDetail(CThostFtdcInvestorPositionCombineDetailField *pInvestorPositionCombineDetail, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryInvestorPositionCombineDetail;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pInvestorPositionCombineDetail));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///查询保证金监管系统经纪公司资金账户密钥响应
				virtual void OnRspQryCFMMCTradingAccountKey(CThostFtdcCFMMCTradingAccountKeyField *pCFMMCTradingAccountKey, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryCFMMCTradingAccountKey;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pCFMMCTradingAccountKey));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询仓单折抵信息响应
				virtual void OnRspQryEWarrantOffset(CThostFtdcEWarrantOffsetField *pEWarrantOffset, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryEWarrantOffset;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pEWarrantOffset));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询投资者品种/跨品种保证金响应
				virtual void OnRspQryInvestorProductGroupMargin(CThostFtdcInvestorProductGroupMarginField *pInvestorProductGroupMargin, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryInvestorProductGroupMargin;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pInvestorProductGroupMargin));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询交易所保证金率响应
				virtual void OnRspQryExchangeMarginRate(CThostFtdcExchangeMarginRateField *pExchangeMarginRate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryExchangeMarginRate;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pExchangeMarginRate));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询交易所调整保证金率响应
				virtual void OnRspQryExchangeMarginRateAdjust(CThostFtdcExchangeMarginRateAdjustField *pExchangeMarginRateAdjust, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryExchangeMarginRateAdjust;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pExchangeMarginRateAdjust));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询汇率响应
				virtual void OnRspQryExchangeRate(CThostFtdcExchangeRateField *pExchangeRate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryExchangeRate;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pExchangeRate));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询二级代理操作员银期权限响应
				virtual void OnRspQrySecAgentACIDMap(CThostFtdcSecAgentACIDMapField *pSecAgentACIDMap, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQrySecAgentACIDMap;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pSecAgentACIDMap));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询产品报价汇率
				virtual void OnRspQryProductExchRate(CThostFtdcProductExchRateField *pProductExchRate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryProductExchRate;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pProductExchRate));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询产品组
				virtual void OnRspQryProductGroup(CThostFtdcProductGroupField *pProductGroup, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryProductGroup;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pProductGroup));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询期权交易成本响应
				virtual void OnRspQryOptionInstrTradeCost(CThostFtdcOptionInstrTradeCostField *pOptionInstrTradeCost, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryOptionInstrTradeCost;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pOptionInstrTradeCost));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询期权合约手续费响应
				virtual void OnRspQryOptionInstrCommRate(CThostFtdcOptionInstrCommRateField *pOptionInstrCommRate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryOptionInstrCommRate;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pOptionInstrCommRate));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询执行宣告响应
				virtual void OnRspQryExecOrder(CThostFtdcExecOrderField *pExecOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryExecOrder;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pExecOrder));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询询价响应
				virtual void OnRspQryForQuote(CThostFtdcForQuoteField *pForQuote, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryForQuote;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pForQuote));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询报价响应
				virtual void OnRspQryQuote(CThostFtdcQuoteField *pQuote, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryQuote;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pQuote));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询组合合约安全系数响应
				virtual void OnRspQryCombInstrumentGuard(CThostFtdcCombInstrumentGuardField *pCombInstrumentGuard, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryCombInstrumentGuard;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pCombInstrumentGuard));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询申请组合响应
				virtual void OnRspQryCombAction(CThostFtdcCombActionField *pCombAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryCombAction;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pCombAction));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询转帐流水响应
				virtual void OnRspQryTransferSerial(CThostFtdcTransferSerialField *pTransferSerial, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryTransferSerial;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pTransferSerial));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询银期签约关系响应
				virtual void OnRspQryAccountregister(CThostFtdcAccountregisterField *pAccountregister, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryAccountregister;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pAccountregister));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///错误应答
				virtual void OnRspError(CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspError;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pRspInfo));
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///报单通知
				virtual void OnRtnOrder(CThostFtdcOrderField *pOrder)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRtnOrder;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pOrder));
					_callback->ProcessResponse(rsp);
				}

				///成交通知
				virtual void OnRtnTrade(CThostFtdcTradeField *pTrade)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRtnTrade;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pTrade));
					_callback->ProcessResponse(rsp);
				}

				///报单录入错误回报
				virtual void OnErrRtnOrderInsert(CThostFtdcInputOrderField *pInputOrder, CThostFtdcRspInfoField *pRspInfo)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnErrRtnOrderInsert;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pInputOrder));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					_callback->ProcessResponse(rsp);
				}

				///报单操作错误回报
				virtual void OnErrRtnOrderAction(CThostFtdcOrderActionField *pOrderAction, CThostFtdcRspInfoField *pRspInfo)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnErrRtnOrderAction;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pOrderAction));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					_callback->ProcessResponse(rsp);
				}

				///合约交易状态通知
				virtual void OnRtnInstrumentStatus(CThostFtdcInstrumentStatusField *pInstrumentStatus)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRtnInstrumentStatus;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pInstrumentStatus));
					_callback->ProcessResponse(rsp);
				}

				///交易通知
				virtual void OnRtnTradingNotice(CThostFtdcTradingNoticeInfoField *pTradingNoticeInfo)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRtnTradingNotice;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pTradingNoticeInfo));
					_callback->ProcessResponse(rsp);
				}

				///提示条件单校验错误
				virtual void OnRtnErrorConditionalOrder(CThostFtdcErrorConditionalOrderField *pErrorConditionalOrder)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRtnErrorConditionalOrder;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pErrorConditionalOrder));
					_callback->ProcessResponse(rsp);
				}

				///执行宣告通知
				virtual void OnRtnExecOrder(CThostFtdcExecOrderField *pExecOrder)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRtnExecOrder;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pExecOrder));
					_callback->ProcessResponse(rsp);
				}

				///执行宣告录入错误回报
				virtual void OnErrRtnExecOrderInsert(CThostFtdcInputExecOrderField *pInputExecOrder, CThostFtdcRspInfoField *pRspInfo)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnErrRtnExecOrderInsert;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pInputExecOrder));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					_callback->ProcessResponse(rsp);
				}

				///执行宣告操作错误回报
				virtual void OnErrRtnExecOrderAction(CThostFtdcExecOrderActionField *pExecOrderAction, CThostFtdcRspInfoField *pRspInfo)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnErrRtnExecOrderAction;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pExecOrderAction));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					_callback->ProcessResponse(rsp);
				}

				///询价录入错误回报
				virtual void OnErrRtnForQuoteInsert(CThostFtdcInputForQuoteField *pInputForQuote, CThostFtdcRspInfoField *pRspInfo)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnErrRtnForQuoteInsert;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pInputForQuote));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					_callback->ProcessResponse(rsp);
				}

				///报价通知
				virtual void OnRtnQuote(CThostFtdcQuoteField *pQuote)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRtnQuote;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pQuote));
					_callback->ProcessResponse(rsp);
				}

				///报价录入错误回报
				virtual void OnErrRtnQuoteInsert(CThostFtdcInputQuoteField *pInputQuote, CThostFtdcRspInfoField *pRspInfo)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnErrRtnQuoteInsert;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pInputQuote));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					_callback->ProcessResponse(rsp);
				}

				///报价操作错误回报
				virtual void OnErrRtnQuoteAction(CThostFtdcQuoteActionField *pQuoteAction, CThostFtdcRspInfoField *pRspInfo)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnErrRtnQuoteAction;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pQuoteAction));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					_callback->ProcessResponse(rsp);
				}

				///询价通知
				virtual void OnRtnForQuoteRsp(CThostFtdcForQuoteRspField *pForQuoteRsp)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRtnForQuoteRsp;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pForQuoteRsp));
					_callback->ProcessResponse(rsp);
				}

				///保证金监控中心用户令牌
				virtual void OnRtnCFMMCTradingAccountToken(CThostFtdcCFMMCTradingAccountTokenField *pCFMMCTradingAccountToken)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRtnCFMMCTradingAccountToken;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pCFMMCTradingAccountToken));
					_callback->ProcessResponse(rsp);
				}

				///批量报单操作错误回报
				virtual void OnErrRtnBatchOrderAction(CThostFtdcBatchOrderActionField *pBatchOrderAction, CThostFtdcRspInfoField *pRspInfo)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnErrRtnBatchOrderAction;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pBatchOrderAction));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					_callback->ProcessResponse(rsp);
				}

				///申请组合通知
				virtual void OnRtnCombAction(CThostFtdcCombActionField *pCombAction)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRtnCombAction;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pCombAction));
					_callback->ProcessResponse(rsp);
				}

				///申请组合录入错误回报
				virtual void OnErrRtnCombActionInsert(CThostFtdcInputCombActionField *pInputCombAction, CThostFtdcRspInfoField *pRspInfo)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnErrRtnCombActionInsert;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pInputCombAction));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					_callback->ProcessResponse(rsp);
				}

				///请求查询签约银行响应
				virtual void OnRspQryContractBank(CThostFtdcContractBankField *pContractBank, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryContractBank;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pContractBank));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询预埋单响应
				virtual void OnRspQryParkedOrder(CThostFtdcParkedOrderField *pParkedOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryParkedOrder;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pParkedOrder));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询预埋撤单响应
				virtual void OnRspQryParkedOrderAction(CThostFtdcParkedOrderActionField *pParkedOrderAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryParkedOrderAction;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pParkedOrderAction));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询交易通知响应
				virtual void OnRspQryTradingNotice(CThostFtdcTradingNoticeField *pTradingNotice, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryTradingNotice;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pTradingNotice));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询经纪公司交易参数响应
				virtual void OnRspQryBrokerTradingParams(CThostFtdcBrokerTradingParamsField *pBrokerTradingParams, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryBrokerTradingParams;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pBrokerTradingParams));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询经纪公司交易算法响应
				virtual void OnRspQryBrokerTradingAlgos(CThostFtdcBrokerTradingAlgosField *pBrokerTradingAlgos, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQryBrokerTradingAlgos;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pBrokerTradingAlgos));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///请求查询监控中心用户令牌
				virtual void OnRspQueryCFMMCTradingAccountToken(CThostFtdcQueryCFMMCTradingAccountTokenField *pQueryCFMMCTradingAccountToken, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQueryCFMMCTradingAccountToken;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pQueryCFMMCTradingAccountToken));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///银行发起银行资金转期货通知
				virtual void OnRtnFromBankToFutureByBank(CThostFtdcRspTransferField *pRspTransfer)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRtnFromBankToFutureByBank;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pRspTransfer));
					_callback->ProcessResponse(rsp);
				}

				///银行发起期货资金转银行通知
				virtual void OnRtnFromFutureToBankByBank(CThostFtdcRspTransferField *pRspTransfer)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRtnFromFutureToBankByBank;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pRspTransfer));
					_callback->ProcessResponse(rsp);
				}

				///银行发起冲正银行转期货通知
				virtual void OnRtnRepealFromBankToFutureByBank(CThostFtdcRspRepealField *pRspRepeal)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRtnRepealFromBankToFutureByBank;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pRspRepeal));
					_callback->ProcessResponse(rsp);
				}

				///银行发起冲正期货转银行通知
				virtual void OnRtnRepealFromFutureToBankByBank(CThostFtdcRspRepealField *pRspRepeal)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRtnRepealFromFutureToBankByBank;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pRspRepeal));
					_callback->ProcessResponse(rsp);
				}

				///期货发起银行资金转期货通知
				virtual void OnRtnFromBankToFutureByFuture(CThostFtdcRspTransferField *pRspTransfer)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRtnFromBankToFutureByFuture;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pRspTransfer));
					_callback->ProcessResponse(rsp);
				}

				///期货发起期货资金转银行通知
				virtual void OnRtnFromFutureToBankByFuture(CThostFtdcRspTransferField *pRspTransfer)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRtnFromFutureToBankByFuture;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pRspTransfer));
					_callback->ProcessResponse(rsp);
				}

				///系统运行时期货端手工发起冲正银行转期货请求，银行处理完毕后报盘发回的通知
				virtual void OnRtnRepealFromBankToFutureByFutureManual(CThostFtdcRspRepealField *pRspRepeal)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRtnRepealFromBankToFutureByFutureManual;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pRspRepeal));
					_callback->ProcessResponse(rsp);
				}

				///系统运行时期货端手工发起冲正期货转银行请求，银行处理完毕后报盘发回的通知
				virtual void OnRtnRepealFromFutureToBankByFutureManual(CThostFtdcRspRepealField *pRspRepeal)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRtnRepealFromFutureToBankByFutureManual;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pRspRepeal));
					_callback->ProcessResponse(rsp);
				}

				///期货发起查询银行余额通知
				virtual void OnRtnQueryBankBalanceByFuture(CThostFtdcNotifyQueryAccountField *pNotifyQueryAccount)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRtnQueryBankBalanceByFuture;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pNotifyQueryAccount));
					_callback->ProcessResponse(rsp);
				}

				///期货发起银行资金转期货错误回报
				virtual void OnErrRtnBankToFutureByFuture(CThostFtdcReqTransferField *pReqTransfer, CThostFtdcRspInfoField *pRspInfo)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnErrRtnBankToFutureByFuture;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pReqTransfer));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					_callback->ProcessResponse(rsp);
				}

				///期货发起期货资金转银行错误回报
				virtual void OnErrRtnFutureToBankByFuture(CThostFtdcReqTransferField *pReqTransfer, CThostFtdcRspInfoField *pRspInfo)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnErrRtnFutureToBankByFuture;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pReqTransfer));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					_callback->ProcessResponse(rsp);
				}

				///系统运行时期货端手工发起冲正银行转期货错误回报
				virtual void OnErrRtnRepealBankToFutureByFutureManual(CThostFtdcReqRepealField *pReqRepeal, CThostFtdcRspInfoField *pRspInfo)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnErrRtnRepealBankToFutureByFutureManual;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pReqRepeal));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					_callback->ProcessResponse(rsp);
				}

				///系统运行时期货端手工发起冲正期货转银行错误回报
				virtual void OnErrRtnRepealFutureToBankByFutureManual(CThostFtdcReqRepealField *pReqRepeal, CThostFtdcRspInfoField *pRspInfo)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnErrRtnRepealFutureToBankByFutureManual;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pReqRepeal));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					_callback->ProcessResponse(rsp);
				}

				///期货发起查询银行余额错误回报
				virtual void OnErrRtnQueryBankBalanceByFuture(CThostFtdcReqQueryAccountField *pReqQueryAccount, CThostFtdcRspInfoField *pRspInfo)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnErrRtnQueryBankBalanceByFuture;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pReqQueryAccount));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					_callback->ProcessResponse(rsp);
				}

				///期货发起冲正银行转期货请求，银行处理完毕后报盘发回的通知
				virtual void OnRtnRepealFromBankToFutureByFuture(CThostFtdcRspRepealField *pRspRepeal)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRtnRepealFromBankToFutureByFuture;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pRspRepeal));
					_callback->ProcessResponse(rsp);
				}

				///期货发起冲正期货转银行请求，银行处理完毕后报盘发回的通知
				virtual void OnRtnRepealFromFutureToBankByFuture(CThostFtdcRspRepealField *pRspRepeal)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRtnRepealFromFutureToBankByFuture;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pRspRepeal));
					_callback->ProcessResponse(rsp);
				}

				///期货发起银行资金转期货应答
				virtual void OnRspFromBankToFutureByFuture(CThostFtdcReqTransferField *pReqTransfer, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspFromBankToFutureByFuture;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pReqTransfer));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///期货发起期货资金转银行应答
				virtual void OnRspFromFutureToBankByFuture(CThostFtdcReqTransferField *pReqTransfer, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspFromFutureToBankByFuture;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pReqTransfer));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///期货发起查询银行余额应答
				virtual void OnRspQueryBankAccountMoneyByFuture(CThostFtdcReqQueryAccountField *pReqQueryAccount, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRspQueryBankAccountMoneyByFuture;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pReqQueryAccount));
					rsp.Item2 = CtpConvert::ToClass(pRspInfo);
					rsp.RequestID = nRequestID;
					rsp.IsLast = bIsLast;
					_callback->ProcessResponse(rsp);
				}

				///银行发起银期开户通知
				virtual void OnRtnOpenAccountByBank(CThostFtdcOpenAccountField *pOpenAccount)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRtnOpenAccountByBank;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pOpenAccount));
					_callback->ProcessResponse(rsp);
				}

				///银行发起银期销户通知
				virtual void OnRtnCancelAccountByBank(CThostFtdcCancelAccountField *pCancelAccount)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRtnCancelAccountByBank;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pCancelAccount));
					_callback->ProcessResponse(rsp);
				}

				///银行发起变更银行账号通知
				virtual void OnRtnChangeAccountByBank(CThostFtdcChangeAccountField *pChangeAccount)
				{
					CtpResponse rsp;
					rsp.TypeId = CtpResponseType::OnRtnChangeAccountByBank;
					rsp.Item1 = CtpAny(CtpConvert::ToClass(pChangeAccount));
					_callback->ProcessResponse(rsp);
				}

			};
		};
	};
}