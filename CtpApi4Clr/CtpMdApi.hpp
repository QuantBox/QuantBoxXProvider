#pragma once
#include <memory>
#include <msclr\marshal.h>
#include <ThostFtdcMdApi.h>

#include "CtpConvert.hpp"
#include "CMdSpi.hpp"

using namespace System;
using namespace msclr;
using namespace msclr::interop;

namespace QuantBox {
	namespace Sfit {
		namespace Api {

			public ref class CtpMdApi : public CtpMdSpi, public ICtpRequestHandler {
			private:
				CThostFtdcMdApi* _native;
				CThostFtdcMdSpi* _spi;
				array<Func<CtpRequest, int>^>^ _handerList;

				char* _flowPath;

				void InitApi(String^ flowPath)
				{
					_flowPath = new char[256];
					marshal_context context;
					strcpy_s(_flowPath, 255, context.marshal_as<const char*>(flowPath));

					_native = CThostFtdcMdApi::CreateFtdcMdApi(_flowPath);
					_spi = new CMdSpi(this);
				}

				int NullRequestHandler(CtpRequest req)
				{
					return -1;
				}

				void InitHandlerList()
				{
					_handerList = gcnew array<Func<CtpRequest, int>^>(CtpRequestType::Max);
					for (auto i = 0; i < CtpRequestType::Max; i++) {
						_handerList[i] = gcnew Func<CtpRequest, int>(this, &CtpMdApi::NullRequestHandler);
					}
					_handerList[CtpRequestType::SubscribeMarketData] = gcnew Func<CtpRequest, int>(this, &CtpMdApi::DoSubscribeMarketData);
					_handerList[CtpRequestType::UnSubscribeMarketData] = gcnew Func<CtpRequest, int>(this, &CtpMdApi::DoUnSubscribeMarketData);
					_handerList[CtpRequestType::SubscribeForQuoteRsp] = gcnew Func<CtpRequest, int>(this, &CtpMdApi::DoSubscribeForQuoteRsp);
					_handerList[CtpRequestType::UnSubscribeForQuoteRsp] = gcnew Func<CtpRequest, int>(this, &CtpMdApi::DoUnSubscribeForQuoteRsp);
					_handerList[CtpRequestType::ReqUserLogin] = gcnew Func<CtpRequest, int>(this, &CtpMdApi::DoReqUserLogin);
					_handerList[CtpRequestType::ReqUserLogout] = gcnew Func<CtpRequest, int>(this, &CtpMdApi::DoReqUserLogout);
				}
#pragma region Request Handler
				int DoSubscribeMarketData(CtpRequest req)
				{
					auto data = req.Args.AsStringArray;
					std::auto_ptr<char*> auto_tmp(new char*[data->Length]);
					char** tmp = auto_tmp.get();

					marshal_context context;
					for (int i = 0; i < data->Length; i++)
					{
						tmp[i] = (char*)context.marshal_as<const char*>(data[i]);
					}

					return _native->SubscribeMarketData(tmp, data->Length);

				}

				int DoUnSubscribeMarketData(CtpRequest req)
				{
					auto data = req.Args.AsStringArray;
					std::auto_ptr<char*> auto_tmp(new char*[data->Length]);
					char** tmp = auto_tmp.get();

					marshal_context context;
					for (int i = 0; i < data->Length; i++)
					{
						tmp[i] = (char*)context.marshal_as<const char*>(data[i]);
					}

					return _native->UnSubscribeMarketData(tmp, data->Length);

				}

				int DoSubscribeForQuoteRsp(CtpRequest req)
				{
					auto data = req.Args.AsStringArray;
					std::auto_ptr<char*> auto_tmp(new char*[data->Length]);
					char** tmp = auto_tmp.get();

					marshal_context context;
					for (int i = 0; i < data->Length; i++)
					{
						tmp[i] = (char*)context.marshal_as<const char*>(data[i]);
					}

					return _native->SubscribeForQuoteRsp(tmp, data->Length);

				}

				int DoUnSubscribeForQuoteRsp(CtpRequest req)
				{
					auto data = req.Args.AsStringArray;
					std::auto_ptr<char*> auto_tmp(new char*[data->Length]);
					char** tmp = auto_tmp.get();

					marshal_context context;
					for (int i = 0; i < data->Length; i++)
					{
						tmp[i] = (char*)context.marshal_as<const char*>(data[i]);
					}

					return _native->UnSubscribeForQuoteRsp(tmp, data->Length);

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

#pragma endregion
			public:
				CtpMdApi(String^ flowPath)
				{
					InitHandlerList();
					InitApi(flowPath);
				}

				!CtpMdApi(void)
				{
					Release();
				}

				~CtpMdApi(void)
				{
					this->!CtpMdApi();
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

				///订阅行情。
		///@param ppInstrumentID 合约ID  
		///@param nCount 要订阅/退订行情的合约个数
		///@remark 
				int SubscribeMarketData(array<String^>^ instrumentID)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::SubscribeMarketData;
					req.Args = CtpAny(instrumentID);
					return ProcessRequest(req);
				}

				///退订行情。
		///@param ppInstrumentID 合约ID  
		///@param nCount 要订阅/退订行情的合约个数
		///@remark 
				int UnSubscribeMarketData(array<String^>^ instrumentID)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::UnSubscribeMarketData;
					req.Args = CtpAny(instrumentID);
					return ProcessRequest(req);
				}

				///订阅询价。
		///@param ppInstrumentID 合约ID  
		///@param nCount 要订阅/退订行情的合约个数
		///@remark 
				int SubscribeForQuoteRsp(array<String^>^ instrumentID, int count)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::SubscribeForQuoteRsp;
					req.Args = CtpAny(instrumentID);
					return ProcessRequest(req);
				}

				///退订询价。
		///@param ppInstrumentID 合约ID  
		///@param nCount 要订阅/退订行情的合约个数
		///@remark 
				int UnSubscribeForQuoteRsp(array<String^>^ instrumentID, int count)
				{
					CtpRequest req;
					req.TypeId = CtpRequestType::UnSubscribeForQuoteRsp;
					req.Args = CtpAny(instrumentID);
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
			};
		};
	};
}