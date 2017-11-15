#pragma once

#include <msclr\auto_gcroot.h>
#include <ThostFtdcMdApi.h>
#include "CtpConvert.hpp"

using namespace msclr;
using namespace System;

namespace QuantBox { namespace Sfit { namespace Api {
    class CMdSpi : public CThostFtdcMdSpi
    {
	private:
		auto_gcroot<CtpMdSpi^> _callback;
	public:
		CMdSpi(auto_gcroot<CtpMdSpi^> callback) { _callback = callback; } 
        CMdSpi(void) {};
		~CMdSpi(void) {};
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
        
        ///登录请求响应
 virtual void OnRspUserLogin(CThostFtdcRspUserLoginField *pRspUserLogin,CThostFtdcRspInfoField *pRspInfo,int nRequestID,bool bIsLast)
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
 virtual void OnRspUserLogout(CThostFtdcUserLogoutField *pUserLogout,CThostFtdcRspInfoField *pRspInfo,int nRequestID,bool bIsLast)
        {
            CtpResponse rsp;
            rsp.TypeId = CtpResponseType::OnRspUserLogout;
rsp.Item1 = CtpAny(CtpConvert::ToClass(pUserLogout));
rsp.Item2 = CtpConvert::ToClass(pRspInfo);
rsp.RequestID = nRequestID;
rsp.IsLast = bIsLast;
_callback->ProcessResponse(rsp);
        }
        
        ///错误应答
 virtual void OnRspError(CThostFtdcRspInfoField *pRspInfo,int nRequestID,bool bIsLast)
        {
            CtpResponse rsp;
            rsp.TypeId = CtpResponseType::OnRspError;
rsp.Item1 = CtpAny(CtpConvert::ToClass(pRspInfo));
rsp.RequestID = nRequestID;
rsp.IsLast = bIsLast;
_callback->ProcessResponse(rsp);
        }
        
        ///订阅行情应答
 virtual void OnRspSubMarketData(CThostFtdcSpecificInstrumentField *pSpecificInstrument,CThostFtdcRspInfoField *pRspInfo,int nRequestID,bool bIsLast)
        {
            CtpResponse rsp;
            rsp.TypeId = CtpResponseType::OnRspSubMarketData;
rsp.Item1 = CtpAny(CtpConvert::ToClass(pSpecificInstrument));
rsp.Item2 = CtpConvert::ToClass(pRspInfo);
rsp.RequestID = nRequestID;
rsp.IsLast = bIsLast;
_callback->ProcessResponse(rsp);
        }
        
        ///取消订阅行情应答
 virtual void OnRspUnSubMarketData(CThostFtdcSpecificInstrumentField *pSpecificInstrument,CThostFtdcRspInfoField *pRspInfo,int nRequestID,bool bIsLast)
        {
            CtpResponse rsp;
            rsp.TypeId = CtpResponseType::OnRspUnSubMarketData;
rsp.Item1 = CtpAny(CtpConvert::ToClass(pSpecificInstrument));
rsp.Item2 = CtpConvert::ToClass(pRspInfo);
rsp.RequestID = nRequestID;
rsp.IsLast = bIsLast;
_callback->ProcessResponse(rsp);
        }
        
        ///订阅询价应答
 virtual void OnRspSubForQuoteRsp(CThostFtdcSpecificInstrumentField *pSpecificInstrument,CThostFtdcRspInfoField *pRspInfo,int nRequestID,bool bIsLast)
        {
            CtpResponse rsp;
            rsp.TypeId = CtpResponseType::OnRspSubForQuoteRsp;
rsp.Item1 = CtpAny(CtpConvert::ToClass(pSpecificInstrument));
rsp.Item2 = CtpConvert::ToClass(pRspInfo);
rsp.RequestID = nRequestID;
rsp.IsLast = bIsLast;
_callback->ProcessResponse(rsp);
        }
        
        ///取消订阅询价应答
 virtual void OnRspUnSubForQuoteRsp(CThostFtdcSpecificInstrumentField *pSpecificInstrument,CThostFtdcRspInfoField *pRspInfo,int nRequestID,bool bIsLast)
        {
            CtpResponse rsp;
            rsp.TypeId = CtpResponseType::OnRspUnSubForQuoteRsp;
rsp.Item1 = CtpAny(CtpConvert::ToClass(pSpecificInstrument));
rsp.Item2 = CtpConvert::ToClass(pRspInfo);
rsp.RequestID = nRequestID;
rsp.IsLast = bIsLast;
_callback->ProcessResponse(rsp);
        }
        
        ///深度行情通知
 virtual void OnRtnDepthMarketData(CThostFtdcDepthMarketDataField *pDepthMarketData)
        {
            CtpResponse rsp;
            rsp.TypeId = CtpResponseType::OnRtnDepthMarketData;
rsp.Item1 = CtpAny(CtpConvert::ToClass(pDepthMarketData));
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
        
    };
};};}    