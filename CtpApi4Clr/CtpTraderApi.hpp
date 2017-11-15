#pragma once
#include <memory>
#include <msclr\marshal.h>
#include <ThostFtdcTraderApi.h>

#include "CtpConvert.hpp"
#include "CTraderSpi.hpp"

using namespace System;
using namespace msclr;
using namespace msclr::interop;

namespace QuantBox {
	namespace Sfit {
		namespace Api {

			public ref class CtpTraderApi : public CtpTraderSpi, public ICtpRequestHandler {
			private:
				CThostFtdcTraderApi* _native;
				CThostFtdcTraderSpi* _spi;
				array<Func<CtpRequest, int>^>^ _handerList;

				char* _flowPath;

				void InitApi(String^ flowPath)
				{
					_flowPath = new char[256];
					marshal_context context;
					strcpy_s(_flowPath, 255, context.marshal_as<const char*>(flowPath));

					_native = CThostFtdcTraderApi::CreateFtdcTraderApi(_flowPath);
					_spi = new CTraderSpi(this);
				}

				int NullRequestHandler(CtpRequest req)
				{
					return -1;
				}

				void InitHandlerList()
				{
					_handerList = gcnew array<Func<CtpRequest, int>^>(CtpRequestType::Max);
					for (auto i = 0; i < CtpRequestType::Max; i++) {
						_handerList[i] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::NullRequestHandler);
					}
					_handerList[CtpRequestType::ReqAuthenticate] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqAuthenticate);
					_handerList[CtpRequestType::ReqUserLogin] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqUserLogin);
					_handerList[CtpRequestType::ReqUserLogout] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqUserLogout);
					_handerList[CtpRequestType::ReqUserPasswordUpdate] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqUserPasswordUpdate);
					_handerList[CtpRequestType::ReqTradingAccountPasswordUpdate] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqTradingAccountPasswordUpdate);
					_handerList[CtpRequestType::ReqOrderInsert] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqOrderInsert);
					_handerList[CtpRequestType::ReqParkedOrderInsert] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqParkedOrderInsert);
					_handerList[CtpRequestType::ReqParkedOrderAction] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqParkedOrderAction);
					_handerList[CtpRequestType::ReqOrderAction] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqOrderAction);
					_handerList[CtpRequestType::ReqQueryMaxOrderVolume] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQueryMaxOrderVolume);
					_handerList[CtpRequestType::ReqSettlementInfoConfirm] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqSettlementInfoConfirm);
					_handerList[CtpRequestType::ReqRemoveParkedOrder] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqRemoveParkedOrder);
					_handerList[CtpRequestType::ReqRemoveParkedOrderAction] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqRemoveParkedOrderAction);
					_handerList[CtpRequestType::ReqExecOrderInsert] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqExecOrderInsert);
					_handerList[CtpRequestType::ReqExecOrderAction] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqExecOrderAction);
					_handerList[CtpRequestType::ReqForQuoteInsert] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqForQuoteInsert);
					_handerList[CtpRequestType::ReqQuoteInsert] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQuoteInsert);
					_handerList[CtpRequestType::ReqQuoteAction] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQuoteAction);
					_handerList[CtpRequestType::ReqBatchOrderAction] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqBatchOrderAction);
					_handerList[CtpRequestType::ReqCombActionInsert] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqCombActionInsert);
					_handerList[CtpRequestType::ReqQryOrder] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryOrder);
					_handerList[CtpRequestType::ReqQryTrade] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryTrade);
					_handerList[CtpRequestType::ReqQryInvestorPosition] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryInvestorPosition);
					_handerList[CtpRequestType::ReqQryTradingAccount] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryTradingAccount);
					_handerList[CtpRequestType::ReqQryInvestor] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryInvestor);
					_handerList[CtpRequestType::ReqQryTradingCode] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryTradingCode);
					_handerList[CtpRequestType::ReqQryInstrumentMarginRate] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryInstrumentMarginRate);
					_handerList[CtpRequestType::ReqQryInstrumentCommissionRate] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryInstrumentCommissionRate);
					_handerList[CtpRequestType::ReqQryExchange] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryExchange);
					_handerList[CtpRequestType::ReqQryProduct] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryProduct);
					_handerList[CtpRequestType::ReqQryInstrument] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryInstrument);
					_handerList[CtpRequestType::ReqQryDepthMarketData] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryDepthMarketData);
					_handerList[CtpRequestType::ReqQrySettlementInfo] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQrySettlementInfo);
					_handerList[CtpRequestType::ReqQryTransferBank] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryTransferBank);
					_handerList[CtpRequestType::ReqQryInvestorPositionDetail] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryInvestorPositionDetail);
					_handerList[CtpRequestType::ReqQryNotice] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryNotice);
					_handerList[CtpRequestType::ReqQrySettlementInfoConfirm] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQrySettlementInfoConfirm);
					_handerList[CtpRequestType::ReqQryInvestorPositionCombineDetail] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryInvestorPositionCombineDetail);
					_handerList[CtpRequestType::ReqQryCFMMCTradingAccountKey] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryCFMMCTradingAccountKey);
					_handerList[CtpRequestType::ReqQryEWarrantOffset] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryEWarrantOffset);
					_handerList[CtpRequestType::ReqQryInvestorProductGroupMargin] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryInvestorProductGroupMargin);
					_handerList[CtpRequestType::ReqQryExchangeMarginRate] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryExchangeMarginRate);
					_handerList[CtpRequestType::ReqQryExchangeMarginRateAdjust] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryExchangeMarginRateAdjust);
					_handerList[CtpRequestType::ReqQryExchangeRate] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryExchangeRate);
					_handerList[CtpRequestType::ReqQrySecAgentACIDMap] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQrySecAgentACIDMap);
					_handerList[CtpRequestType::ReqQryProductExchRate] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryProductExchRate);
					_handerList[CtpRequestType::ReqQryProductGroup] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryProductGroup);
					_handerList[CtpRequestType::ReqQryOptionInstrTradeCost] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryOptionInstrTradeCost);
					_handerList[CtpRequestType::ReqQryOptionInstrCommRate] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryOptionInstrCommRate);
					_handerList[CtpRequestType::ReqQryExecOrder] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryExecOrder);
					_handerList[CtpRequestType::ReqQryForQuote] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryForQuote);
					_handerList[CtpRequestType::ReqQryQuote] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryQuote);
					_handerList[CtpRequestType::ReqQryCombInstrumentGuard] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryCombInstrumentGuard);
					_handerList[CtpRequestType::ReqQryCombAction] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryCombAction);
					_handerList[CtpRequestType::ReqQryTransferSerial] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryTransferSerial);
					_handerList[CtpRequestType::ReqQryAccountregister] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryAccountregister);
					_handerList[CtpRequestType::ReqQryContractBank] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryContractBank);
					_handerList[CtpRequestType::ReqQryParkedOrder] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryParkedOrder);
					_handerList[CtpRequestType::ReqQryParkedOrderAction] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryParkedOrderAction);
					_handerList[CtpRequestType::ReqQryTradingNotice] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryTradingNotice);
					_handerList[CtpRequestType::ReqQryBrokerTradingParams] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryBrokerTradingParams);
					_handerList[CtpRequestType::ReqQryBrokerTradingAlgos] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQryBrokerTradingAlgos);
					_handerList[CtpRequestType::ReqQueryCFMMCTradingAccountToken] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQueryCFMMCTradingAccountToken);
					_handerList[CtpRequestType::ReqFromBankToFutureByFuture] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqFromBankToFutureByFuture);
					_handerList[CtpRequestType::ReqFromFutureToBankByFuture] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqFromFutureToBankByFuture);
					_handerList[CtpRequestType::ReqQueryBankAccountMoneyByFuture] = gcnew Func<CtpRequest, int>(this, &CtpTraderApi::DoReqQueryBankAccountMoneyByFuture);
				}
#pragma region Request Handler
				int DoReqAuthenticate(CtpRequest req)
				{
					auto data = req.Args.AsReqAuthenticate;
					CThostFtdcReqAuthenticateField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqAuthenticate(&tmp, req.RequestID);
				}

				int DoReqUserLogin(CtpRequest req)
				{
					auto data = req.Args.AsReqUserLogin;
					CThostFtdcReqUserLoginField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqUserLogin(&tmp, req.RequestID);
				}

				int DoReqUserLogout(CtpRequest req)
				{
					auto data = req.Args.AsUserLogout;
					CThostFtdcUserLogoutField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqUserLogout(&tmp, req.RequestID);
				}

				int DoReqUserPasswordUpdate(CtpRequest req)
				{
					auto data = req.Args.AsUserPasswordUpdate;
					CThostFtdcUserPasswordUpdateField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqUserPasswordUpdate(&tmp, req.RequestID);
				}

				int DoReqTradingAccountPasswordUpdate(CtpRequest req)
				{
					auto data = req.Args.AsTradingAccountPasswordUpdate;
					CThostFtdcTradingAccountPasswordUpdateField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqTradingAccountPasswordUpdate(&tmp, req.RequestID);
				}

				int DoReqOrderInsert(CtpRequest req)
				{
					auto data = req.Args.AsInputOrder;
					CThostFtdcInputOrderField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqOrderInsert(&tmp, req.RequestID);
				}

				int DoReqParkedOrderInsert(CtpRequest req)
				{
					auto data = req.Args.AsParkedOrder;
					CThostFtdcParkedOrderField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqParkedOrderInsert(&tmp, req.RequestID);
				}

				int DoReqParkedOrderAction(CtpRequest req)
				{
					auto data = req.Args.AsParkedOrderAction;
					CThostFtdcParkedOrderActionField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqParkedOrderAction(&tmp, req.RequestID);
				}

				int DoReqOrderAction(CtpRequest req)
				{
					auto data = req.Args.AsInputOrderAction;
					CThostFtdcInputOrderActionField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqOrderAction(&tmp, req.RequestID);
				}

				int DoReqQueryMaxOrderVolume(CtpRequest req)
				{
					auto data = req.Args.AsQueryMaxOrderVolume;
					CThostFtdcQueryMaxOrderVolumeField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQueryMaxOrderVolume(&tmp, req.RequestID);
				}

				int DoReqSettlementInfoConfirm(CtpRequest req)
				{
					auto data = req.Args.AsSettlementInfoConfirm;
					CThostFtdcSettlementInfoConfirmField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqSettlementInfoConfirm(&tmp, req.RequestID);
				}

				int DoReqRemoveParkedOrder(CtpRequest req)
				{
					auto data = req.Args.AsRemoveParkedOrder;
					CThostFtdcRemoveParkedOrderField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqRemoveParkedOrder(&tmp, req.RequestID);
				}

				int DoReqRemoveParkedOrderAction(CtpRequest req)
				{
					auto data = req.Args.AsRemoveParkedOrderAction;
					CThostFtdcRemoveParkedOrderActionField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqRemoveParkedOrderAction(&tmp, req.RequestID);
				}

				int DoReqExecOrderInsert(CtpRequest req)
				{
					auto data = req.Args.AsInputExecOrder;
					CThostFtdcInputExecOrderField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqExecOrderInsert(&tmp, req.RequestID);
				}

				int DoReqExecOrderAction(CtpRequest req)
				{
					auto data = req.Args.AsInputExecOrderAction;
					CThostFtdcInputExecOrderActionField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqExecOrderAction(&tmp, req.RequestID);
				}

				int DoReqForQuoteInsert(CtpRequest req)
				{
					auto data = req.Args.AsInputForQuote;
					CThostFtdcInputForQuoteField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqForQuoteInsert(&tmp, req.RequestID);
				}

				int DoReqQuoteInsert(CtpRequest req)
				{
					auto data = req.Args.AsInputQuote;
					CThostFtdcInputQuoteField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQuoteInsert(&tmp, req.RequestID);
				}

				int DoReqQuoteAction(CtpRequest req)
				{
					auto data = req.Args.AsInputQuoteAction;
					CThostFtdcInputQuoteActionField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQuoteAction(&tmp, req.RequestID);
				}

				int DoReqBatchOrderAction(CtpRequest req)
				{
					auto data = req.Args.AsInputBatchOrderAction;
					CThostFtdcInputBatchOrderActionField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqBatchOrderAction(&tmp, req.RequestID);
				}

				int DoReqCombActionInsert(CtpRequest req)
				{
					auto data = req.Args.AsInputCombAction;
					CThostFtdcInputCombActionField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqCombActionInsert(&tmp, req.RequestID);
				}

				int DoReqQryOrder(CtpRequest req)
				{
					auto data = req.Args.AsQryOrder;
					CThostFtdcQryOrderField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryOrder(&tmp, req.RequestID);
				}

				int DoReqQryTrade(CtpRequest req)
				{
					auto data = req.Args.AsQryTrade;
					CThostFtdcQryTradeField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryTrade(&tmp, req.RequestID);
				}

				int DoReqQryInvestorPosition(CtpRequest req)
				{
					auto data = req.Args.AsQryInvestorPosition;
					CThostFtdcQryInvestorPositionField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryInvestorPosition(&tmp, req.RequestID);
				}

				int DoReqQryTradingAccount(CtpRequest req)
				{
					auto data = req.Args.AsQryTradingAccount;
					CThostFtdcQryTradingAccountField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryTradingAccount(&tmp, req.RequestID);
				}

				int DoReqQryInvestor(CtpRequest req)
				{
					auto data = req.Args.AsQryInvestor;
					CThostFtdcQryInvestorField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryInvestor(&tmp, req.RequestID);
				}

				int DoReqQryTradingCode(CtpRequest req)
				{
					auto data = req.Args.AsQryTradingCode;
					CThostFtdcQryTradingCodeField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryTradingCode(&tmp, req.RequestID);
				}

				int DoReqQryInstrumentMarginRate(CtpRequest req)
				{
					auto data = req.Args.AsQryInstrumentMarginRate;
					CThostFtdcQryInstrumentMarginRateField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryInstrumentMarginRate(&tmp, req.RequestID);
				}

				int DoReqQryInstrumentCommissionRate(CtpRequest req)
				{
					auto data = req.Args.AsQryInstrumentCommissionRate;
					CThostFtdcQryInstrumentCommissionRateField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryInstrumentCommissionRate(&tmp, req.RequestID);
				}

				int DoReqQryExchange(CtpRequest req)
				{
					auto data = req.Args.AsQryExchange;
					CThostFtdcQryExchangeField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryExchange(&tmp, req.RequestID);
				}

				int DoReqQryProduct(CtpRequest req)
				{
					auto data = req.Args.AsQryProduct;
					CThostFtdcQryProductField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryProduct(&tmp, req.RequestID);
				}

				int DoReqQryInstrument(CtpRequest req)
				{
					auto data = req.Args.AsQryInstrument;
					CThostFtdcQryInstrumentField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryInstrument(&tmp, req.RequestID);
				}

				int DoReqQryDepthMarketData(CtpRequest req)
				{
					auto data = req.Args.AsQryDepthMarketData;
					CThostFtdcQryDepthMarketDataField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryDepthMarketData(&tmp, req.RequestID);
				}

				int DoReqQrySettlementInfo(CtpRequest req)
				{
					auto data = req.Args.AsQrySettlementInfo;
					CThostFtdcQrySettlementInfoField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQrySettlementInfo(&tmp, req.RequestID);
				}

				int DoReqQryTransferBank(CtpRequest req)
				{
					auto data = req.Args.AsQryTransferBank;
					CThostFtdcQryTransferBankField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryTransferBank(&tmp, req.RequestID);
				}

				int DoReqQryInvestorPositionDetail(CtpRequest req)
				{
					auto data = req.Args.AsQryInvestorPositionDetail;
					CThostFtdcQryInvestorPositionDetailField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryInvestorPositionDetail(&tmp, req.RequestID);
				}

				int DoReqQryNotice(CtpRequest req)
				{
					auto data = req.Args.AsQryNotice;
					CThostFtdcQryNoticeField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryNotice(&tmp, req.RequestID);
				}

				int DoReqQrySettlementInfoConfirm(CtpRequest req)
				{
					auto data = req.Args.AsQrySettlementInfoConfirm;
					CThostFtdcQrySettlementInfoConfirmField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQrySettlementInfoConfirm(&tmp, req.RequestID);
				}

				int DoReqQryInvestorPositionCombineDetail(CtpRequest req)
				{
					auto data = req.Args.AsQryInvestorPositionCombineDetail;
					CThostFtdcQryInvestorPositionCombineDetailField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryInvestorPositionCombineDetail(&tmp, req.RequestID);
				}

				int DoReqQryCFMMCTradingAccountKey(CtpRequest req)
				{
					auto data = req.Args.AsQryCFMMCTradingAccountKey;
					CThostFtdcQryCFMMCTradingAccountKeyField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryCFMMCTradingAccountKey(&tmp, req.RequestID);
				}

				int DoReqQryEWarrantOffset(CtpRequest req)
				{
					auto data = req.Args.AsQryEWarrantOffset;
					CThostFtdcQryEWarrantOffsetField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryEWarrantOffset(&tmp, req.RequestID);
				}

				int DoReqQryInvestorProductGroupMargin(CtpRequest req)
				{
					auto data = req.Args.AsQryInvestorProductGroupMargin;
					CThostFtdcQryInvestorProductGroupMarginField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryInvestorProductGroupMargin(&tmp, req.RequestID);
				}

				int DoReqQryExchangeMarginRate(CtpRequest req)
				{
					auto data = req.Args.AsQryExchangeMarginRate;
					CThostFtdcQryExchangeMarginRateField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryExchangeMarginRate(&tmp, req.RequestID);
				}

				int DoReqQryExchangeMarginRateAdjust(CtpRequest req)
				{
					auto data = req.Args.AsQryExchangeMarginRateAdjust;
					CThostFtdcQryExchangeMarginRateAdjustField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryExchangeMarginRateAdjust(&tmp, req.RequestID);
				}

				int DoReqQryExchangeRate(CtpRequest req)
				{
					auto data = req.Args.AsQryExchangeRate;
					CThostFtdcQryExchangeRateField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryExchangeRate(&tmp, req.RequestID);
				}

				int DoReqQrySecAgentACIDMap(CtpRequest req)
				{
					auto data = req.Args.AsQrySecAgentACIDMap;
					CThostFtdcQrySecAgentACIDMapField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQrySecAgentACIDMap(&tmp, req.RequestID);
				}

				int DoReqQryProductExchRate(CtpRequest req)
				{
					auto data = req.Args.AsQryProductExchRate;
					CThostFtdcQryProductExchRateField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryProductExchRate(&tmp, req.RequestID);
				}

				int DoReqQryProductGroup(CtpRequest req)
				{
					auto data = req.Args.AsQryProductGroup;
					CThostFtdcQryProductGroupField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryProductGroup(&tmp, req.RequestID);
				}

				int DoReqQryOptionInstrTradeCost(CtpRequest req)
				{
					auto data = req.Args.AsQryOptionInstrTradeCost;
					CThostFtdcQryOptionInstrTradeCostField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryOptionInstrTradeCost(&tmp, req.RequestID);
				}

				int DoReqQryOptionInstrCommRate(CtpRequest req)
				{
					auto data = req.Args.AsQryOptionInstrCommRate;
					CThostFtdcQryOptionInstrCommRateField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryOptionInstrCommRate(&tmp, req.RequestID);
				}

				int DoReqQryExecOrder(CtpRequest req)
				{
					auto data = req.Args.AsQryExecOrder;
					CThostFtdcQryExecOrderField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryExecOrder(&tmp, req.RequestID);
				}

				int DoReqQryForQuote(CtpRequest req)
				{
					auto data = req.Args.AsQryForQuote;
					CThostFtdcQryForQuoteField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryForQuote(&tmp, req.RequestID);
				}

				int DoReqQryQuote(CtpRequest req)
				{
					auto data = req.Args.AsQryQuote;
					CThostFtdcQryQuoteField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryQuote(&tmp, req.RequestID);
				}

				int DoReqQryCombInstrumentGuard(CtpRequest req)
				{
					auto data = req.Args.AsQryCombInstrumentGuard;
					CThostFtdcQryCombInstrumentGuardField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryCombInstrumentGuard(&tmp, req.RequestID);
				}

				int DoReqQryCombAction(CtpRequest req)
				{
					auto data = req.Args.AsQryCombAction;
					CThostFtdcQryCombActionField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryCombAction(&tmp, req.RequestID);
				}

				int DoReqQryTransferSerial(CtpRequest req)
				{
					auto data = req.Args.AsQryTransferSerial;
					CThostFtdcQryTransferSerialField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryTransferSerial(&tmp, req.RequestID);
				}

				int DoReqQryAccountregister(CtpRequest req)
				{
					auto data = req.Args.AsQryAccountregister;
					CThostFtdcQryAccountregisterField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryAccountregister(&tmp, req.RequestID);
				}

				int DoReqQryContractBank(CtpRequest req)
				{
					auto data = req.Args.AsQryContractBank;
					CThostFtdcQryContractBankField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryContractBank(&tmp, req.RequestID);
				}

				int DoReqQryParkedOrder(CtpRequest req)
				{
					auto data = req.Args.AsQryParkedOrder;
					CThostFtdcQryParkedOrderField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryParkedOrder(&tmp, req.RequestID);
				}

				int DoReqQryParkedOrderAction(CtpRequest req)
				{
					auto data = req.Args.AsQryParkedOrderAction;
					CThostFtdcQryParkedOrderActionField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryParkedOrderAction(&tmp, req.RequestID);
				}

				int DoReqQryTradingNotice(CtpRequest req)
				{
					auto data = req.Args.AsQryTradingNotice;
					CThostFtdcQryTradingNoticeField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryTradingNotice(&tmp, req.RequestID);
				}

				int DoReqQryBrokerTradingParams(CtpRequest req)
				{
					auto data = req.Args.AsQryBrokerTradingParams;
					CThostFtdcQryBrokerTradingParamsField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryBrokerTradingParams(&tmp, req.RequestID);
				}

				int DoReqQryBrokerTradingAlgos(CtpRequest req)
				{
					auto data = req.Args.AsQryBrokerTradingAlgos;
					CThostFtdcQryBrokerTradingAlgosField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQryBrokerTradingAlgos(&tmp, req.RequestID);
				}

				int DoReqQueryCFMMCTradingAccountToken(CtpRequest req)
				{
					auto data = req.Args.AsQueryCFMMCTradingAccountToken;
					CThostFtdcQueryCFMMCTradingAccountTokenField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQueryCFMMCTradingAccountToken(&tmp, req.RequestID);
				}

				int DoReqFromBankToFutureByFuture(CtpRequest req)
				{
					auto data = req.Args.AsReqTransfer;
					CThostFtdcReqTransferField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqFromBankToFutureByFuture(&tmp, req.RequestID);
				}

				int DoReqFromFutureToBankByFuture(CtpRequest req)
				{
					auto data = req.Args.AsReqTransfer;
					CThostFtdcReqTransferField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqFromFutureToBankByFuture(&tmp, req.RequestID);
				}

				int DoReqQueryBankAccountMoneyByFuture(CtpRequest req)
				{
					auto data = req.Args.AsReqQueryAccount;
					CThostFtdcReqQueryAccountField tmp;
					CtpConvert::ToStruct(data, tmp);
					return _native->ReqQueryBankAccountMoneyByFuture(&tmp, req.RequestID);
				}

#pragma endregion
			public:
				CtpTraderApi(String^ flowPath)
				{
					InitHandlerList();
					InitApi(flowPath);
				}

				!CtpTraderApi(void)
				{
					Release();
				}

				~CtpTraderApi(void)
				{
					this->!CtpTraderApi();
				}

				virtual int ProcessRequest(CtpRequest req)
				{
					switch (req.TypeId) {
					case CtpRequestType::Request:
					case CtpRequestType::Max:
						return -1;
					default:
						return _handerList[req.TypeId](req);
					}
				}

				property array<Func<CtpRequest, int>^>^ ReqHandlerList { array<Func<CtpRequest, int>^>^ get() { return _handerList; }}
			public:
				void Init()
				{
					_native->Init();
					_native->RegisterSpi(_spi);
				}

				void Release()
				{
					if (_spi != nullptr) {
						_native->RegisterSpi(NULL);
						_native->Release();

						delete _spi;
						_spi = nullptr;
						delete[] _flowPath;
						_flowPath = nullptr;
					}
				}

				int Join()
				{
					return _native->Join();
				}

				///获取当前交易日
				///@retrun 获取到的交易日
				///@remark 只有登录成功后,才能得到正确的交易日
				String^ GetTradingDay()
				{
					return marshal_as<String^>(_native->GetTradingDay());
				}

				///注册前置机网络地址
				///@param pszFrontAddress：前置机网络地址。
				///@remark 网络地址的格式为：“protocol://ipaddress:port”，如：”tcp://127.0.0.1:17001”。 
				///@remark “tcp”代表传输协议，“127.0.0.1”代表服务器地址。”17001”代表服务器端口号。
				void RegisterFront(String^ frontAddress)
				{
					marshal_context context;
					_native->RegisterFront((char*)context.marshal_as<const char*>(frontAddress));
				}

				///注册名字服务器网络地址
				///@param pszNsAddress：名字服务器网络地址。
				///@remark 网络地址的格式为：“protocol://ipaddress:port”，如：”tcp://127.0.0.1:12001”。 
				///@remark “tcp”代表传输协议，“127.0.0.1”代表服务器地址。”12001”代表服务器端口号。
				///@remark RegisterNameServer优先于RegisterFront
				void RegisterNameServer(String^ nsAddress)
				{
					marshal_context context;
					_native->RegisterNameServer((char*)context.marshal_as<const char*>(nsAddress));
				}
				///订阅私有流。
				///@param nResumeType 私有流重传方式  
				///        THOST_TERT_RESTART:从本交易日开始重传
				///        THOST_TERT_RESUME:从上次收到的续传
				///        THOST_TERT_QUICK:只传送登录后私有流的内容
				///@remark 该方法要在Init方法前调用。若不调用则不会收到私有流的数据。
				void SubscribePrivateTopic(CtpResumeType resumeType)
				{
					_native->SubscribePrivateTopic((::THOST_TE_RESUME_TYPE)resumeType);
				}

				///订阅公共流。
				///@param nResumeType 公共流重传方式  
				///        THOST_TERT_RESTART:从本交易日开始重传
				///        THOST_TERT_RESUME:从上次收到的续传
				///        THOST_TERT_QUICK:只传送登录后公共流的内容
				///@remark 该方法要在Init方法前调用。若不调用则不会收到公共流的数据。
				void SubscribePublicTopic(CtpResumeType resumeType)
				{
					_native->SubscribePublicTopic((::THOST_TE_RESUME_TYPE)resumeType);
				}

				///客户端认证请求
				int ReqAuthenticate(CtpReqAuthenticate^ reqAuthenticateField, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqAuthenticate;
					req.Args = CtpAny(reqAuthenticateField);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///用户登录请求
				int ReqUserLogin(CtpReqUserLogin^ reqUserLoginField, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqUserLogin;
					req.Args = CtpAny(reqUserLoginField);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///登出请求
				int ReqUserLogout(CtpUserLogout^ userLogout, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqUserLogout;
					req.Args = CtpAny(userLogout);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///用户口令更新请求
				int ReqUserPasswordUpdate(CtpUserPasswordUpdate^ userPasswordUpdate, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqUserPasswordUpdate;
					req.Args = CtpAny(userPasswordUpdate);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///资金账户口令更新请求
				int ReqTradingAccountPasswordUpdate(CtpTradingAccountPasswordUpdate^ tradingAccountPasswordUpdate, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqTradingAccountPasswordUpdate;
					req.Args = CtpAny(tradingAccountPasswordUpdate);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///报单录入请求
				int ReqOrderInsert(CtpInputOrder^ inputOrder, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqOrderInsert;
					req.Args = CtpAny(inputOrder);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///预埋单录入请求
				int ReqParkedOrderInsert(CtpParkedOrder^ parkedOrder, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqParkedOrderInsert;
					req.Args = CtpAny(parkedOrder);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///预埋撤单录入请求
				int ReqParkedOrderAction(CtpParkedOrderAction^ parkedOrderAction, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqParkedOrderAction;
					req.Args = CtpAny(parkedOrderAction);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///报单操作请求
				int ReqOrderAction(CtpInputOrderAction^ inputOrderAction, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqOrderAction;
					req.Args = CtpAny(inputOrderAction);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///查询最大报单数量请求
				int ReqQueryMaxOrderVolume(CtpQueryMaxOrderVolume^ queryMaxOrderVolume, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQueryMaxOrderVolume;
					req.Args = CtpAny(queryMaxOrderVolume);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///投资者结算结果确认
				int ReqSettlementInfoConfirm(CtpSettlementInfoConfirm^ settlementInfoConfirm, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqSettlementInfoConfirm;
					req.Args = CtpAny(settlementInfoConfirm);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求删除预埋单
				int ReqRemoveParkedOrder(CtpRemoveParkedOrder^ removeParkedOrder, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqRemoveParkedOrder;
					req.Args = CtpAny(removeParkedOrder);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求删除预埋撤单
				int ReqRemoveParkedOrderAction(CtpRemoveParkedOrderAction^ removeParkedOrderAction, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqRemoveParkedOrderAction;
					req.Args = CtpAny(removeParkedOrderAction);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///执行宣告录入请求
				int ReqExecOrderInsert(CtpInputExecOrder^ inputExecOrder, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqExecOrderInsert;
					req.Args = CtpAny(inputExecOrder);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///执行宣告操作请求
				int ReqExecOrderAction(CtpInputExecOrderAction^ inputExecOrderAction, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqExecOrderAction;
					req.Args = CtpAny(inputExecOrderAction);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///询价录入请求
				int ReqForQuoteInsert(CtpInputForQuote^ inputForQuote, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqForQuoteInsert;
					req.Args = CtpAny(inputForQuote);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///报价录入请求
				int ReqQuoteInsert(CtpInputQuote^ inputQuote, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQuoteInsert;
					req.Args = CtpAny(inputQuote);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///报价操作请求
				int ReqQuoteAction(CtpInputQuoteAction^ inputQuoteAction, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQuoteAction;
					req.Args = CtpAny(inputQuoteAction);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///批量报单操作请求
				int ReqBatchOrderAction(CtpInputBatchOrderAction^ inputBatchOrderAction, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqBatchOrderAction;
					req.Args = CtpAny(inputBatchOrderAction);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///申请组合录入请求
				int ReqCombActionInsert(CtpInputCombAction^ inputCombAction, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqCombActionInsert;
					req.Args = CtpAny(inputCombAction);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询报单
				int ReqQryOrder(CtpQryOrder^ qryOrder, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryOrder;
					req.Args = CtpAny(qryOrder);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询成交
				int ReqQryTrade(CtpQryTrade^ qryTrade, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryTrade;
					req.Args = CtpAny(qryTrade);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询投资者持仓
				int ReqQryInvestorPosition(CtpQryInvestorPosition^ qryInvestorPosition, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryInvestorPosition;
					req.Args = CtpAny(qryInvestorPosition);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询资金账户
				int ReqQryTradingAccount(CtpQryTradingAccount^ qryTradingAccount, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryTradingAccount;
					req.Args = CtpAny(qryTradingAccount);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询投资者
				int ReqQryInvestor(CtpQryInvestor^ qryInvestor, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryInvestor;
					req.Args = CtpAny(qryInvestor);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询交易编码
				int ReqQryTradingCode(CtpQryTradingCode^ qryTradingCode, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryTradingCode;
					req.Args = CtpAny(qryTradingCode);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询合约保证金率
				int ReqQryInstrumentMarginRate(CtpQryInstrumentMarginRate^ qryInstrumentMarginRate, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryInstrumentMarginRate;
					req.Args = CtpAny(qryInstrumentMarginRate);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询合约手续费率
				int ReqQryInstrumentCommissionRate(CtpQryInstrumentCommissionRate^ qryInstrumentCommissionRate, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryInstrumentCommissionRate;
					req.Args = CtpAny(qryInstrumentCommissionRate);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询交易所
				int ReqQryExchange(CtpQryExchange^ qryExchange, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryExchange;
					req.Args = CtpAny(qryExchange);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询产品
				int ReqQryProduct(CtpQryProduct^ qryProduct, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryProduct;
					req.Args = CtpAny(qryProduct);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询合约
				int ReqQryInstrument(CtpQryInstrument^ qryInstrument, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryInstrument;
					req.Args = CtpAny(qryInstrument);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询行情
				int ReqQryDepthMarketData(CtpQryDepthMarketData^ qryDepthMarketData, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryDepthMarketData;
					req.Args = CtpAny(qryDepthMarketData);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询投资者结算结果
				int ReqQrySettlementInfo(CtpQrySettlementInfo^ qrySettlementInfo, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQrySettlementInfo;
					req.Args = CtpAny(qrySettlementInfo);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询转帐银行
				int ReqQryTransferBank(CtpQryTransferBank^ qryTransferBank, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryTransferBank;
					req.Args = CtpAny(qryTransferBank);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询投资者持仓明细
				int ReqQryInvestorPositionDetail(CtpQryInvestorPositionDetail^ qryInvestorPositionDetail, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryInvestorPositionDetail;
					req.Args = CtpAny(qryInvestorPositionDetail);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询客户通知
				int ReqQryNotice(CtpQryNotice^ qryNotice, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryNotice;
					req.Args = CtpAny(qryNotice);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询结算信息确认
				int ReqQrySettlementInfoConfirm(CtpQrySettlementInfoConfirm^ qrySettlementInfoConfirm, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQrySettlementInfoConfirm;
					req.Args = CtpAny(qrySettlementInfoConfirm);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询投资者持仓明细
				int ReqQryInvestorPositionCombineDetail(CtpQryInvestorPositionCombineDetail^ qryInvestorPositionCombineDetail, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryInvestorPositionCombineDetail;
					req.Args = CtpAny(qryInvestorPositionCombineDetail);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询保证金监管系统经纪公司资金账户密钥
				int ReqQryCFMMCTradingAccountKey(CtpQryCFMMCTradingAccountKey^ qryCFMMCTradingAccountKey, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryCFMMCTradingAccountKey;
					req.Args = CtpAny(qryCFMMCTradingAccountKey);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询仓单折抵信息
				int ReqQryEWarrantOffset(CtpQryEWarrantOffset^ qryEWarrantOffset, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryEWarrantOffset;
					req.Args = CtpAny(qryEWarrantOffset);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询投资者品种/跨品种保证金
				int ReqQryInvestorProductGroupMargin(CtpQryInvestorProductGroupMargin^ qryInvestorProductGroupMargin, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryInvestorProductGroupMargin;
					req.Args = CtpAny(qryInvestorProductGroupMargin);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询交易所保证金率
				int ReqQryExchangeMarginRate(CtpQryExchangeMarginRate^ qryExchangeMarginRate, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryExchangeMarginRate;
					req.Args = CtpAny(qryExchangeMarginRate);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询交易所调整保证金率
				int ReqQryExchangeMarginRateAdjust(CtpQryExchangeMarginRateAdjust^ qryExchangeMarginRateAdjust, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryExchangeMarginRateAdjust;
					req.Args = CtpAny(qryExchangeMarginRateAdjust);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询汇率
				int ReqQryExchangeRate(CtpQryExchangeRate^ qryExchangeRate, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryExchangeRate;
					req.Args = CtpAny(qryExchangeRate);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询二级代理操作员银期权限
				int ReqQrySecAgentACIDMap(CtpQrySecAgentACIDMap^ qrySecAgentACIDMap, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQrySecAgentACIDMap;
					req.Args = CtpAny(qrySecAgentACIDMap);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询产品报价汇率
				int ReqQryProductExchRate(CtpQryProductExchRate^ qryProductExchRate, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryProductExchRate;
					req.Args = CtpAny(qryProductExchRate);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询产品组
				int ReqQryProductGroup(CtpQryProductGroup^ qryProductGroup, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryProductGroup;
					req.Args = CtpAny(qryProductGroup);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询期权交易成本
				int ReqQryOptionInstrTradeCost(CtpQryOptionInstrTradeCost^ qryOptionInstrTradeCost, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryOptionInstrTradeCost;
					req.Args = CtpAny(qryOptionInstrTradeCost);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询期权合约手续费
				int ReqQryOptionInstrCommRate(CtpQryOptionInstrCommRate^ qryOptionInstrCommRate, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryOptionInstrCommRate;
					req.Args = CtpAny(qryOptionInstrCommRate);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询执行宣告
				int ReqQryExecOrder(CtpQryExecOrder^ qryExecOrder, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryExecOrder;
					req.Args = CtpAny(qryExecOrder);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询询价
				int ReqQryForQuote(CtpQryForQuote^ qryForQuote, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryForQuote;
					req.Args = CtpAny(qryForQuote);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询报价
				int ReqQryQuote(CtpQryQuote^ qryQuote, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryQuote;
					req.Args = CtpAny(qryQuote);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询组合合约安全系数
				int ReqQryCombInstrumentGuard(CtpQryCombInstrumentGuard^ qryCombInstrumentGuard, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryCombInstrumentGuard;
					req.Args = CtpAny(qryCombInstrumentGuard);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询申请组合
				int ReqQryCombAction(CtpQryCombAction^ qryCombAction, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryCombAction;
					req.Args = CtpAny(qryCombAction);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询转帐流水
				int ReqQryTransferSerial(CtpQryTransferSerial^ qryTransferSerial, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryTransferSerial;
					req.Args = CtpAny(qryTransferSerial);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询银期签约关系
				int ReqQryAccountregister(CtpQryAccountregister^ qryAccountregister, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryAccountregister;
					req.Args = CtpAny(qryAccountregister);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询签约银行
				int ReqQryContractBank(CtpQryContractBank^ qryContractBank, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryContractBank;
					req.Args = CtpAny(qryContractBank);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询预埋单
				int ReqQryParkedOrder(CtpQryParkedOrder^ qryParkedOrder, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryParkedOrder;
					req.Args = CtpAny(qryParkedOrder);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询预埋撤单
				int ReqQryParkedOrderAction(CtpQryParkedOrderAction^ qryParkedOrderAction, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryParkedOrderAction;
					req.Args = CtpAny(qryParkedOrderAction);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询交易通知
				int ReqQryTradingNotice(CtpQryTradingNotice^ qryTradingNotice, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryTradingNotice;
					req.Args = CtpAny(qryTradingNotice);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询经纪公司交易参数
				int ReqQryBrokerTradingParams(CtpQryBrokerTradingParams^ qryBrokerTradingParams, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryBrokerTradingParams;
					req.Args = CtpAny(qryBrokerTradingParams);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询经纪公司交易算法
				int ReqQryBrokerTradingAlgos(CtpQryBrokerTradingAlgos^ qryBrokerTradingAlgos, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQryBrokerTradingAlgos;
					req.Args = CtpAny(qryBrokerTradingAlgos);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///请求查询监控中心用户令牌
				int ReqQueryCFMMCTradingAccountToken(CtpQueryCFMMCTradingAccountToken^ queryCFMMCTradingAccountToken, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQueryCFMMCTradingAccountToken;
					req.Args = CtpAny(queryCFMMCTradingAccountToken);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///期货发起银行资金转期货请求
				int ReqFromBankToFutureByFuture(CtpReqTransfer^ reqTransfer, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqFromBankToFutureByFuture;
					req.Args = CtpAny(reqTransfer);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///期货发起期货资金转银行请求
				int ReqFromFutureToBankByFuture(CtpReqTransfer^ reqTransfer, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqFromFutureToBankByFuture;
					req.Args = CtpAny(reqTransfer);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}

				///期货发起查询银行余额请求
				int ReqQueryBankAccountMoneyByFuture(CtpReqQueryAccount^ reqQueryAccount, int requestId)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::ReqQueryBankAccountMoneyByFuture;
					req.Args = CtpAny(reqQueryAccount);
					req.RequestID = requestId;
					return ProcessRequest(req);
				}
			};
		};
	};
}