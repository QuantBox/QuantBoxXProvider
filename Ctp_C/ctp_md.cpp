#include "stdafx.h"
#include <ThostFtdcMdApi.h>

#define CALLBACK _stdcall
#define DLL __declspec(dllexport)

#ifdef __cplusplus
extern "C"
{
#endif

	///当客户端与交易后台建立起通信连接时（还未登录前），该方法被调用。
	typedef void (CALLBACK * Md_OnFrontConnected)();
	DLL void CALLBACK Md_Set_OnFrontConnected(void* instance, Md_OnFrontConnected callback);
	///当客户端与交易后台通信连接断开时，该方法被调用。当发生这个情况后，API会自动重新连接，客户端可不做处理。
	///@param nReason 错误原因
	///        0x1001 网络读失败
	///        0x1002 网络写失败
	///        0x2001 接收心跳超时
	///        0x2002 发送心跳失败
	///        0x2003 收到错误报文
	typedef void (CALLBACK * Md_OnFrontDisconnected)(int nReason);
	DLL void CALLBACK Md_Set_OnFrontDisconnected(void* instance, Md_OnFrontDisconnected callback);
	///心跳超时警告。当长时间未收到报文时，该方法被调用。
	///@param nTimeLapse 距离上次接收报文的时间
	typedef void (CALLBACK * Md_OnHeartBeatWarning)(int nTimeLapse);
	DLL void CALLBACK Md_Set_OnHeartBeatWarning(void* instance, Md_OnHeartBeatWarning callback);
	///登录请求响应
	typedef void (CALLBACK * Md_OnRspUserLogin)(CThostFtdcRspUserLoginField *pRspUserLogin, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Md_Set_OnRspUserLogin(void* instance, Md_OnRspUserLogin callback);
	///登出请求响应
	typedef void (CALLBACK * Md_OnRspUserLogout)(CThostFtdcUserLogoutField *pUserLogout, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Md_Set_OnRspUserLogout(void* instance, Md_OnRspUserLogout callback);
	///错误应答
	typedef void (CALLBACK * Md_OnRspError)(CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Md_Set_OnRspError(void* instance, Md_OnRspError callback);
	///订阅行情应答
	typedef void (CALLBACK * Md_OnRspSubMarketData)(CThostFtdcSpecificInstrumentField *pSpecificInstrument, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Md_Set_OnRspSubMarketData(void* instance, Md_OnRspSubMarketData callback);
	///取消订阅行情应答
	typedef void (CALLBACK * Md_OnRspUnSubMarketData)(CThostFtdcSpecificInstrumentField *pSpecificInstrument, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Md_Set_OnRspUnSubMarketData(void* instance, Md_OnRspUnSubMarketData callback);
	///订阅询价应答
	typedef void (CALLBACK * Md_OnRspSubForQuoteRsp)(CThostFtdcSpecificInstrumentField *pSpecificInstrument, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Md_Set_OnRspSubForQuoteRsp(void* instance, Md_OnRspSubForQuoteRsp callback);
	///取消订阅询价应答
	typedef void (CALLBACK * Md_OnRspUnSubForQuoteRsp)(CThostFtdcSpecificInstrumentField *pSpecificInstrument, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	DLL void CALLBACK Md_Set_OnRspUnSubForQuoteRsp(void* instance, Md_OnRspUnSubForQuoteRsp callback);
	///深度行情通知
	typedef void (CALLBACK * Md_OnRtnDepthMarketData)(CThostFtdcDepthMarketDataField *pDepthMarketData);
	DLL void CALLBACK Md_Set_OnRtnDepthMarketData(void* instance, Md_OnRtnDepthMarketData callback);
	///询价通知
	typedef void (CALLBACK * Md_OnRtnForQuoteRsp)(CThostFtdcForQuoteRspField *pForQuoteRsp);
	DLL void CALLBACK Md_Set_OnRtnForQuoteRsp(void* instance, Md_OnRtnForQuoteRsp callback);
	DLL void* CALLBACK Md_Create(const char* path);
	DLL void CALLBACK Md_Init(void* instance);
	DLL void CALLBACK Md_Release(void* instance);
	DLL int CALLBACK Md_Join(void* instance);
	///获取当前交易日
	///@retrun 获取到的交易日
	///@remark 只有登录成功后,才能得到正确的交易日
	DLL const char* CALLBACK Md_GetTradingDay(void* instance);
	///注册前置机网络地址
	///@param pszFrontAddress：前置机网络地址。
	///@remark 网络地址的格式为：“protocol://ipaddress:port”，如：”tcp://127.0.0.1:17001”。 
	///@remark “tcp”代表传输协议，“127.0.0.1”代表服务器地址。”17001”代表服务器端口号。
	DLL void CALLBACK Md_RegisterFront(void* instance, char* frontAddress);
	///注册名字服务器网络地址
	///@param pszNsAddress：名字服务器网络地址。
	///@remark 网络地址的格式为：“protocol://ipaddress:port”，如：”tcp://127.0.0.1:12001”。 
	///@remark “tcp”代表传输协议，“127.0.0.1”代表服务器地址。”12001”代表服务器端口号。
	///@remark RegisterNameServer优先于RegisterFront    
	DLL void CALLBACK Md_RegisterNameServer(void* instance, char* nsAddress);
	///订阅行情。
///@param ppInstrumentID 合约ID  
///@param nCount 要订阅/退订行情的合约个数
///@remark 
	DLL int CALLBACK Md_SubscribeMarketData(void* instance, char* ppInstrumentID[], int nCount);
	///退订行情。
///@param ppInstrumentID 合约ID  
///@param nCount 要订阅/退订行情的合约个数
///@remark 
	DLL int CALLBACK Md_UnSubscribeMarketData(void* instance, char* ppInstrumentID[], int nCount);
	///订阅询价。
///@param ppInstrumentID 合约ID  
///@param nCount 要订阅/退订行情的合约个数
///@remark 
	DLL int CALLBACK Md_SubscribeForQuoteRsp(void* instance, char* ppInstrumentID[], int nCount);
	///退订询价。
///@param ppInstrumentID 合约ID  
///@param nCount 要订阅/退订行情的合约个数
///@remark 
	DLL int CALLBACK Md_UnSubscribeForQuoteRsp(void* instance, char* ppInstrumentID[], int nCount);
	///用户登录请求
	DLL int CALLBACK Md_ReqUserLogin(void* instance, CThostFtdcReqUserLoginField *pReqUserLoginField, int nRequestID);
	///登出请求
	DLL int CALLBACK Md_ReqUserLogout(void* instance, CThostFtdcUserLogoutField *pUserLogout, int nRequestID);
#ifdef __cplusplus
}
#endif

class CMySfitMd : public CThostFtdcMdSpi
{
public:
	CThostFtdcMdApi* native;
	Md_OnFrontConnected _OnFrontConnected;
	Md_OnFrontDisconnected _OnFrontDisconnected;
	Md_OnHeartBeatWarning _OnHeartBeatWarning;
	Md_OnRspUserLogin _OnRspUserLogin;
	Md_OnRspUserLogout _OnRspUserLogout;
	Md_OnRspError _OnRspError;
	Md_OnRspSubMarketData _OnRspSubMarketData;
	Md_OnRspUnSubMarketData _OnRspUnSubMarketData;
	Md_OnRspSubForQuoteRsp _OnRspSubForQuoteRsp;
	Md_OnRspUnSubForQuoteRsp _OnRspUnSubForQuoteRsp;
	Md_OnRtnDepthMarketData _OnRtnDepthMarketData;
	Md_OnRtnForQuoteRsp _OnRtnForQuoteRsp;
public:
	explicit CMySfitMd(const char* path)
	{
		native = CThostFtdcMdApi::CreateFtdcMdApi(path);
		native->RegisterSpi(this);
	};
	virtual ~CMySfitMd(void)
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
	///错误应答
	void OnRspError(CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspError(pRspInfo, nRequestID, bIsLast);
	}
	///订阅行情应答
	void OnRspSubMarketData(CThostFtdcSpecificInstrumentField *pSpecificInstrument, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspSubMarketData(pSpecificInstrument, pRspInfo, nRequestID, bIsLast);
	}
	///取消订阅行情应答
	void OnRspUnSubMarketData(CThostFtdcSpecificInstrumentField *pSpecificInstrument, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspUnSubMarketData(pSpecificInstrument, pRspInfo, nRequestID, bIsLast);
	}
	///订阅询价应答
	void OnRspSubForQuoteRsp(CThostFtdcSpecificInstrumentField *pSpecificInstrument, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspSubForQuoteRsp(pSpecificInstrument, pRspInfo, nRequestID, bIsLast);
	}
	///取消订阅询价应答
	void OnRspUnSubForQuoteRsp(CThostFtdcSpecificInstrumentField *pSpecificInstrument, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast) override
	{
		_OnRspUnSubForQuoteRsp(pSpecificInstrument, pRspInfo, nRequestID, bIsLast);
	}
	///深度行情通知
	void OnRtnDepthMarketData(CThostFtdcDepthMarketDataField *pDepthMarketData) override
	{
		_OnRtnDepthMarketData(pDepthMarketData);
	}
	///询价通知
	void OnRtnForQuoteRsp(CThostFtdcForQuoteRspField *pForQuoteRsp) override
	{
		_OnRtnForQuoteRsp(pForQuoteRsp);
	}
};

void CALLBACK Md_Set_OnFrontConnected(void* instance, Md_OnFrontConnected callback)
{
	auto api = static_cast<CMySfitMd*>(instance);
	api->_OnFrontConnected = callback;
}
void CALLBACK Md_Set_OnFrontDisconnected(void* instance, Md_OnFrontDisconnected callback)
{
	auto api = static_cast<CMySfitMd*>(instance);
	api->_OnFrontDisconnected = callback;
}
void CALLBACK Md_Set_OnHeartBeatWarning(void* instance, Md_OnHeartBeatWarning callback)
{
	auto api = static_cast<CMySfitMd*>(instance);
	api->_OnHeartBeatWarning = callback;
}
void CALLBACK Md_Set_OnRspUserLogin(void* instance, Md_OnRspUserLogin callback)
{
	auto api = static_cast<CMySfitMd*>(instance);
	api->_OnRspUserLogin = callback;
}
void CALLBACK Md_Set_OnRspUserLogout(void* instance, Md_OnRspUserLogout callback)
{
	auto api = static_cast<CMySfitMd*>(instance);
	api->_OnRspUserLogout = callback;
}
void CALLBACK Md_Set_OnRspError(void* instance, Md_OnRspError callback)
{
	auto api = static_cast<CMySfitMd*>(instance);
	api->_OnRspError = callback;
}
void CALLBACK Md_Set_OnRspSubMarketData(void* instance, Md_OnRspSubMarketData callback)
{
	auto api = static_cast<CMySfitMd*>(instance);
	api->_OnRspSubMarketData = callback;
}
void CALLBACK Md_Set_OnRspUnSubMarketData(void* instance, Md_OnRspUnSubMarketData callback)
{
	auto api = static_cast<CMySfitMd*>(instance);
	api->_OnRspUnSubMarketData = callback;
}
void CALLBACK Md_Set_OnRspSubForQuoteRsp(void* instance, Md_OnRspSubForQuoteRsp callback)
{
	auto api = static_cast<CMySfitMd*>(instance);
	api->_OnRspSubForQuoteRsp = callback;
}
void CALLBACK Md_Set_OnRspUnSubForQuoteRsp(void* instance, Md_OnRspUnSubForQuoteRsp callback)
{
	auto api = static_cast<CMySfitMd*>(instance);
	api->_OnRspUnSubForQuoteRsp = callback;
}
void CALLBACK Md_Set_OnRtnDepthMarketData(void* instance, Md_OnRtnDepthMarketData callback)
{
	auto api = static_cast<CMySfitMd*>(instance);
	api->_OnRtnDepthMarketData = callback;
}
void CALLBACK Md_Set_OnRtnForQuoteRsp(void* instance, Md_OnRtnForQuoteRsp callback)
{
	auto api = static_cast<CMySfitMd*>(instance);
	api->_OnRtnForQuoteRsp = callback;
}
void* CALLBACK Md_Create(const char* path)
{
	return new CMySfitMd(path);
}

void CALLBACK Md_Init(void* instance)
{
	auto api = static_cast<CMySfitMd*>(instance);
	api->native->Init();
}

void CALLBACK Md_Release(void* instance)
{
	auto api = static_cast<CMySfitMd*>(instance);
	delete api;
}

int CALLBACK Md_Join(void* instance)
{
	auto api = static_cast<CMySfitMd*>(instance);
	return api->native->Join();
}

///获取当前交易日
///@retrun 获取到的交易日
///@remark 只有登录成功后,才能得到正确的交易日
const char* CALLBACK Md_GetTradingDay(void* instance)
{
	auto api = static_cast<CMySfitMd*>(instance);
	return api->native->GetTradingDay();
}
///注册前置机网络地址
///@param pszFrontAddress：前置机网络地址。
///@remark 网络地址的格式为：“protocol://ipaddress:port”，如：”tcp://127.0.0.1:17001”。 
///@remark “tcp”代表传输协议，“127.0.0.1”代表服务器地址。”17001”代表服务器端口号。
void CALLBACK Md_RegisterFront(void* instance, char* frontAddress)
{
	auto api = static_cast<CMySfitMd*>(instance);
	api->native->RegisterFront(frontAddress);
}
///注册名字服务器网络地址
///@param pszNsAddress：名字服务器网络地址。
///@remark 网络地址的格式为：“protocol://ipaddress:port”，如：”tcp://127.0.0.1:12001”。 
///@remark “tcp”代表传输协议，“127.0.0.1”代表服务器地址。”12001”代表服务器端口号。
///@remark RegisterNameServer优先于RegisterFront    
void CALLBACK Md_RegisterNameServer(void* instance, char* nsAddress)
{
	auto api = static_cast<CMySfitMd*>(instance);
	api->native->RegisterNameServer(nsAddress);
}
///订阅行情。
///@param ppInstrumentID 合约ID  
///@param nCount 要订阅/退订行情的合约个数
///@remark 
int CALLBACK Md_SubscribeMarketData(void* instance, char* ppInstrumentID[], int nCount)
{
	auto api = static_cast<CMySfitMd*>(instance);
	return api->native->SubscribeMarketData(ppInstrumentID, nCount);
}
///退订行情。
///@param ppInstrumentID 合约ID  
///@param nCount 要订阅/退订行情的合约个数
///@remark 
int CALLBACK Md_UnSubscribeMarketData(void* instance, char* ppInstrumentID[], int nCount)
{
	auto api = static_cast<CMySfitMd*>(instance);
	return api->native->UnSubscribeMarketData(ppInstrumentID, nCount);
}
///订阅询价。
///@param ppInstrumentID 合约ID  
///@param nCount 要订阅/退订行情的合约个数
///@remark 
int CALLBACK Md_SubscribeForQuoteRsp(void* instance, char* ppInstrumentID[], int nCount)
{
	auto api = static_cast<CMySfitMd*>(instance);
	return api->native->SubscribeForQuoteRsp(ppInstrumentID, nCount);
}
///退订询价。
///@param ppInstrumentID 合约ID  
///@param nCount 要订阅/退订行情的合约个数
///@remark 
int CALLBACK Md_UnSubscribeForQuoteRsp(void* instance, char* ppInstrumentID[], int nCount)
{
	auto api = static_cast<CMySfitMd*>(instance);
	return api->native->UnSubscribeForQuoteRsp(ppInstrumentID, nCount);
}
///用户登录请求
int CALLBACK Md_ReqUserLogin(void* instance, CThostFtdcReqUserLoginField *pReqUserLoginField, int nRequestID)
{
	auto api = static_cast<CMySfitMd*>(instance);
	return api->native->ReqUserLogin(pReqUserLoginField, nRequestID);
}
///登出请求
int CALLBACK Md_ReqUserLogout(void* instance, CThostFtdcUserLogoutField *pUserLogout, int nRequestID)
{
	auto api = static_cast<CMySfitMd*>(instance);
	return api->native->ReqUserLogout(pUserLogout, nRequestID);
}
