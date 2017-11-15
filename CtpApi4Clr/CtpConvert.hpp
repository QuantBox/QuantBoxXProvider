#pragma once
#include "StdAfx.h"
#include <windows.h>
#include "ThostFtdcUserApiStruct.h"

using namespace System;
using namespace System::Runtime::InteropServices;

namespace QuantBox {
	namespace Sfit {
		namespace Api {
			private ref class CtpConvert abstract sealed
			{
			public:
				static CtpReqUserLogin^ ToClass(CThostFtdcReqUserLoginField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcReqUserLoginField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpReqUserLogin^>(Marshal::PtrToStructure(ptr, CtpReqUserLogin::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpReqUserLogin^ source, CThostFtdcReqUserLoginField& dest)
				{
					int size = sizeof(CThostFtdcReqUserLoginField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpRspUserLogin^ ToClass(CThostFtdcRspUserLoginField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcRspUserLoginField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpRspUserLogin^>(Marshal::PtrToStructure(ptr, CtpRspUserLogin::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpRspUserLogin^ source, CThostFtdcRspUserLoginField& dest)
				{
					int size = sizeof(CThostFtdcRspUserLoginField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpUserLogout^ ToClass(CThostFtdcUserLogoutField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcUserLogoutField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpUserLogout^>(Marshal::PtrToStructure(ptr, CtpUserLogout::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpUserLogout^ source, CThostFtdcUserLogoutField& dest)
				{
					int size = sizeof(CThostFtdcUserLogoutField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpForceUserLogout^ ToClass(CThostFtdcForceUserLogoutField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcForceUserLogoutField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpForceUserLogout^>(Marshal::PtrToStructure(ptr, CtpForceUserLogout::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpForceUserLogout^ source, CThostFtdcForceUserLogoutField& dest)
				{
					int size = sizeof(CThostFtdcForceUserLogoutField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpReqAuthenticate^ ToClass(CThostFtdcReqAuthenticateField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcReqAuthenticateField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpReqAuthenticate^>(Marshal::PtrToStructure(ptr, CtpReqAuthenticate::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpReqAuthenticate^ source, CThostFtdcReqAuthenticateField& dest)
				{
					int size = sizeof(CThostFtdcReqAuthenticateField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpRspAuthenticate^ ToClass(CThostFtdcRspAuthenticateField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcRspAuthenticateField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpRspAuthenticate^>(Marshal::PtrToStructure(ptr, CtpRspAuthenticate::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpRspAuthenticate^ source, CThostFtdcRspAuthenticateField& dest)
				{
					int size = sizeof(CThostFtdcRspAuthenticateField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpAuthenticationInfo^ ToClass(CThostFtdcAuthenticationInfoField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcAuthenticationInfoField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpAuthenticationInfo^>(Marshal::PtrToStructure(ptr, CtpAuthenticationInfo::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpAuthenticationInfo^ source, CThostFtdcAuthenticationInfoField& dest)
				{
					int size = sizeof(CThostFtdcAuthenticationInfoField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpTransferHeader^ ToClass(CThostFtdcTransferHeaderField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcTransferHeaderField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpTransferHeader^>(Marshal::PtrToStructure(ptr, CtpTransferHeader::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpTransferHeader^ source, CThostFtdcTransferHeaderField& dest)
				{
					int size = sizeof(CThostFtdcTransferHeaderField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpTransferBankToFutureReq^ ToClass(CThostFtdcTransferBankToFutureReqField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcTransferBankToFutureReqField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpTransferBankToFutureReq^>(Marshal::PtrToStructure(ptr, CtpTransferBankToFutureReq::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpTransferBankToFutureReq^ source, CThostFtdcTransferBankToFutureReqField& dest)
				{
					int size = sizeof(CThostFtdcTransferBankToFutureReqField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpTransferBankToFutureRsp^ ToClass(CThostFtdcTransferBankToFutureRspField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcTransferBankToFutureRspField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpTransferBankToFutureRsp^>(Marshal::PtrToStructure(ptr, CtpTransferBankToFutureRsp::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpTransferBankToFutureRsp^ source, CThostFtdcTransferBankToFutureRspField& dest)
				{
					int size = sizeof(CThostFtdcTransferBankToFutureRspField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpTransferFutureToBankReq^ ToClass(CThostFtdcTransferFutureToBankReqField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcTransferFutureToBankReqField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpTransferFutureToBankReq^>(Marshal::PtrToStructure(ptr, CtpTransferFutureToBankReq::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpTransferFutureToBankReq^ source, CThostFtdcTransferFutureToBankReqField& dest)
				{
					int size = sizeof(CThostFtdcTransferFutureToBankReqField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpTransferFutureToBankRsp^ ToClass(CThostFtdcTransferFutureToBankRspField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcTransferFutureToBankRspField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpTransferFutureToBankRsp^>(Marshal::PtrToStructure(ptr, CtpTransferFutureToBankRsp::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpTransferFutureToBankRsp^ source, CThostFtdcTransferFutureToBankRspField& dest)
				{
					int size = sizeof(CThostFtdcTransferFutureToBankRspField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpTransferQryBankReq^ ToClass(CThostFtdcTransferQryBankReqField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcTransferQryBankReqField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpTransferQryBankReq^>(Marshal::PtrToStructure(ptr, CtpTransferQryBankReq::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpTransferQryBankReq^ source, CThostFtdcTransferQryBankReqField& dest)
				{
					int size = sizeof(CThostFtdcTransferQryBankReqField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpTransferQryBankRsp^ ToClass(CThostFtdcTransferQryBankRspField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcTransferQryBankRspField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpTransferQryBankRsp^>(Marshal::PtrToStructure(ptr, CtpTransferQryBankRsp::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpTransferQryBankRsp^ source, CThostFtdcTransferQryBankRspField& dest)
				{
					int size = sizeof(CThostFtdcTransferQryBankRspField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpTransferQryDetailReq^ ToClass(CThostFtdcTransferQryDetailReqField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcTransferQryDetailReqField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpTransferQryDetailReq^>(Marshal::PtrToStructure(ptr, CtpTransferQryDetailReq::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpTransferQryDetailReq^ source, CThostFtdcTransferQryDetailReqField& dest)
				{
					int size = sizeof(CThostFtdcTransferQryDetailReqField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpTransferQryDetailRsp^ ToClass(CThostFtdcTransferQryDetailRspField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcTransferQryDetailRspField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpTransferQryDetailRsp^>(Marshal::PtrToStructure(ptr, CtpTransferQryDetailRsp::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpTransferQryDetailRsp^ source, CThostFtdcTransferQryDetailRspField& dest)
				{
					int size = sizeof(CThostFtdcTransferQryDetailRspField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpRspInfo^ ToClass(CThostFtdcRspInfoField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcRspInfoField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpRspInfo^>(Marshal::PtrToStructure(ptr, CtpRspInfo::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpRspInfo^ source, CThostFtdcRspInfoField& dest)
				{
					int size = sizeof(CThostFtdcRspInfoField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpExchange^ ToClass(CThostFtdcExchangeField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcExchangeField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpExchange^>(Marshal::PtrToStructure(ptr, CtpExchange::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpExchange^ source, CThostFtdcExchangeField& dest)
				{
					int size = sizeof(CThostFtdcExchangeField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpProduct^ ToClass(CThostFtdcProductField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcProductField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpProduct^>(Marshal::PtrToStructure(ptr, CtpProduct::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpProduct^ source, CThostFtdcProductField& dest)
				{
					int size = sizeof(CThostFtdcProductField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpInstrument^ ToClass(CThostFtdcInstrumentField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcInstrumentField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpInstrument^>(Marshal::PtrToStructure(ptr, CtpInstrument::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpInstrument^ source, CThostFtdcInstrumentField& dest)
				{
					int size = sizeof(CThostFtdcInstrumentField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpBroker^ ToClass(CThostFtdcBrokerField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcBrokerField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpBroker^>(Marshal::PtrToStructure(ptr, CtpBroker::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpBroker^ source, CThostFtdcBrokerField& dest)
				{
					int size = sizeof(CThostFtdcBrokerField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpTrader^ ToClass(CThostFtdcTraderField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcTraderField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpTrader^>(Marshal::PtrToStructure(ptr, CtpTrader::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpTrader^ source, CThostFtdcTraderField& dest)
				{
					int size = sizeof(CThostFtdcTraderField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpInvestor^ ToClass(CThostFtdcInvestorField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcInvestorField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpInvestor^>(Marshal::PtrToStructure(ptr, CtpInvestor::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpInvestor^ source, CThostFtdcInvestorField& dest)
				{
					int size = sizeof(CThostFtdcInvestorField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpTradingCode^ ToClass(CThostFtdcTradingCodeField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcTradingCodeField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpTradingCode^>(Marshal::PtrToStructure(ptr, CtpTradingCode::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpTradingCode^ source, CThostFtdcTradingCodeField& dest)
				{
					int size = sizeof(CThostFtdcTradingCodeField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpPartBroker^ ToClass(CThostFtdcPartBrokerField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcPartBrokerField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpPartBroker^>(Marshal::PtrToStructure(ptr, CtpPartBroker::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpPartBroker^ source, CThostFtdcPartBrokerField& dest)
				{
					int size = sizeof(CThostFtdcPartBrokerField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpSuperUser^ ToClass(CThostFtdcSuperUserField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcSuperUserField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpSuperUser^>(Marshal::PtrToStructure(ptr, CtpSuperUser::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpSuperUser^ source, CThostFtdcSuperUserField& dest)
				{
					int size = sizeof(CThostFtdcSuperUserField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpSuperUserFunction^ ToClass(CThostFtdcSuperUserFunctionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcSuperUserFunctionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpSuperUserFunction^>(Marshal::PtrToStructure(ptr, CtpSuperUserFunction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpSuperUserFunction^ source, CThostFtdcSuperUserFunctionField& dest)
				{
					int size = sizeof(CThostFtdcSuperUserFunctionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpInvestorGroup^ ToClass(CThostFtdcInvestorGroupField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcInvestorGroupField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpInvestorGroup^>(Marshal::PtrToStructure(ptr, CtpInvestorGroup::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpInvestorGroup^ source, CThostFtdcInvestorGroupField& dest)
				{
					int size = sizeof(CThostFtdcInvestorGroupField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpTradingAccount^ ToClass(CThostFtdcTradingAccountField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcTradingAccountField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpTradingAccount^>(Marshal::PtrToStructure(ptr, CtpTradingAccount::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpTradingAccount^ source, CThostFtdcTradingAccountField& dest)
				{
					int size = sizeof(CThostFtdcTradingAccountField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpInvestorPosition^ ToClass(CThostFtdcInvestorPositionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcInvestorPositionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpInvestorPosition^>(Marshal::PtrToStructure(ptr, CtpInvestorPosition::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpInvestorPosition^ source, CThostFtdcInvestorPositionField& dest)
				{
					int size = sizeof(CThostFtdcInvestorPositionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpInstrumentMarginRate^ ToClass(CThostFtdcInstrumentMarginRateField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcInstrumentMarginRateField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpInstrumentMarginRate^>(Marshal::PtrToStructure(ptr, CtpInstrumentMarginRate::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpInstrumentMarginRate^ source, CThostFtdcInstrumentMarginRateField& dest)
				{
					int size = sizeof(CThostFtdcInstrumentMarginRateField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpInstrumentCommissionRate^ ToClass(CThostFtdcInstrumentCommissionRateField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcInstrumentCommissionRateField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpInstrumentCommissionRate^>(Marshal::PtrToStructure(ptr, CtpInstrumentCommissionRate::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpInstrumentCommissionRate^ source, CThostFtdcInstrumentCommissionRateField& dest)
				{
					int size = sizeof(CThostFtdcInstrumentCommissionRateField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpDepthMarketData^ ToClass(CThostFtdcDepthMarketDataField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcDepthMarketDataField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpDepthMarketData^>(Marshal::PtrToStructure(ptr, CtpDepthMarketData::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpDepthMarketData^ source, CThostFtdcDepthMarketDataField& dest)
				{
					int size = sizeof(CThostFtdcDepthMarketDataField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpInstrumentTradingRight^ ToClass(CThostFtdcInstrumentTradingRightField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcInstrumentTradingRightField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpInstrumentTradingRight^>(Marshal::PtrToStructure(ptr, CtpInstrumentTradingRight::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpInstrumentTradingRight^ source, CThostFtdcInstrumentTradingRightField& dest)
				{
					int size = sizeof(CThostFtdcInstrumentTradingRightField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpBrokerUser^ ToClass(CThostFtdcBrokerUserField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcBrokerUserField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpBrokerUser^>(Marshal::PtrToStructure(ptr, CtpBrokerUser::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpBrokerUser^ source, CThostFtdcBrokerUserField& dest)
				{
					int size = sizeof(CThostFtdcBrokerUserField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpBrokerUserPassword^ ToClass(CThostFtdcBrokerUserPasswordField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcBrokerUserPasswordField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpBrokerUserPassword^>(Marshal::PtrToStructure(ptr, CtpBrokerUserPassword::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpBrokerUserPassword^ source, CThostFtdcBrokerUserPasswordField& dest)
				{
					int size = sizeof(CThostFtdcBrokerUserPasswordField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpBrokerUserFunction^ ToClass(CThostFtdcBrokerUserFunctionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcBrokerUserFunctionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpBrokerUserFunction^>(Marshal::PtrToStructure(ptr, CtpBrokerUserFunction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpBrokerUserFunction^ source, CThostFtdcBrokerUserFunctionField& dest)
				{
					int size = sizeof(CThostFtdcBrokerUserFunctionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpTraderOffer^ ToClass(CThostFtdcTraderOfferField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcTraderOfferField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpTraderOffer^>(Marshal::PtrToStructure(ptr, CtpTraderOffer::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpTraderOffer^ source, CThostFtdcTraderOfferField& dest)
				{
					int size = sizeof(CThostFtdcTraderOfferField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpSettlementInfo^ ToClass(CThostFtdcSettlementInfoField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcSettlementInfoField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpSettlementInfo^>(Marshal::PtrToStructure(ptr, CtpSettlementInfo::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpSettlementInfo^ source, CThostFtdcSettlementInfoField& dest)
				{
					int size = sizeof(CThostFtdcSettlementInfoField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpInstrumentMarginRateAdjust^ ToClass(CThostFtdcInstrumentMarginRateAdjustField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcInstrumentMarginRateAdjustField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpInstrumentMarginRateAdjust^>(Marshal::PtrToStructure(ptr, CtpInstrumentMarginRateAdjust::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpInstrumentMarginRateAdjust^ source, CThostFtdcInstrumentMarginRateAdjustField& dest)
				{
					int size = sizeof(CThostFtdcInstrumentMarginRateAdjustField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpExchangeMarginRate^ ToClass(CThostFtdcExchangeMarginRateField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcExchangeMarginRateField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpExchangeMarginRate^>(Marshal::PtrToStructure(ptr, CtpExchangeMarginRate::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpExchangeMarginRate^ source, CThostFtdcExchangeMarginRateField& dest)
				{
					int size = sizeof(CThostFtdcExchangeMarginRateField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpExchangeMarginRateAdjust^ ToClass(CThostFtdcExchangeMarginRateAdjustField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcExchangeMarginRateAdjustField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpExchangeMarginRateAdjust^>(Marshal::PtrToStructure(ptr, CtpExchangeMarginRateAdjust::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpExchangeMarginRateAdjust^ source, CThostFtdcExchangeMarginRateAdjustField& dest)
				{
					int size = sizeof(CThostFtdcExchangeMarginRateAdjustField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpExchangeRate^ ToClass(CThostFtdcExchangeRateField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcExchangeRateField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpExchangeRate^>(Marshal::PtrToStructure(ptr, CtpExchangeRate::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpExchangeRate^ source, CThostFtdcExchangeRateField& dest)
				{
					int size = sizeof(CThostFtdcExchangeRateField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpSettlementRef^ ToClass(CThostFtdcSettlementRefField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcSettlementRefField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpSettlementRef^>(Marshal::PtrToStructure(ptr, CtpSettlementRef::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpSettlementRef^ source, CThostFtdcSettlementRefField& dest)
				{
					int size = sizeof(CThostFtdcSettlementRefField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpCurrentTime^ ToClass(CThostFtdcCurrentTimeField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcCurrentTimeField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpCurrentTime^>(Marshal::PtrToStructure(ptr, CtpCurrentTime::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpCurrentTime^ source, CThostFtdcCurrentTimeField& dest)
				{
					int size = sizeof(CThostFtdcCurrentTimeField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpCommPhase^ ToClass(CThostFtdcCommPhaseField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcCommPhaseField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpCommPhase^>(Marshal::PtrToStructure(ptr, CtpCommPhase::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpCommPhase^ source, CThostFtdcCommPhaseField& dest)
				{
					int size = sizeof(CThostFtdcCommPhaseField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpLoginInfo^ ToClass(CThostFtdcLoginInfoField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcLoginInfoField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpLoginInfo^>(Marshal::PtrToStructure(ptr, CtpLoginInfo::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpLoginInfo^ source, CThostFtdcLoginInfoField& dest)
				{
					int size = sizeof(CThostFtdcLoginInfoField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpLogoutAll^ ToClass(CThostFtdcLogoutAllField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcLogoutAllField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpLogoutAll^>(Marshal::PtrToStructure(ptr, CtpLogoutAll::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpLogoutAll^ source, CThostFtdcLogoutAllField& dest)
				{
					int size = sizeof(CThostFtdcLogoutAllField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpFrontStatus^ ToClass(CThostFtdcFrontStatusField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcFrontStatusField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpFrontStatus^>(Marshal::PtrToStructure(ptr, CtpFrontStatus::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpFrontStatus^ source, CThostFtdcFrontStatusField& dest)
				{
					int size = sizeof(CThostFtdcFrontStatusField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpUserPasswordUpdate^ ToClass(CThostFtdcUserPasswordUpdateField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcUserPasswordUpdateField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpUserPasswordUpdate^>(Marshal::PtrToStructure(ptr, CtpUserPasswordUpdate::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpUserPasswordUpdate^ source, CThostFtdcUserPasswordUpdateField& dest)
				{
					int size = sizeof(CThostFtdcUserPasswordUpdateField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpInputOrder^ ToClass(CThostFtdcInputOrderField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcInputOrderField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpInputOrder^>(Marshal::PtrToStructure(ptr, CtpInputOrder::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpInputOrder^ source, CThostFtdcInputOrderField& dest)
				{
					int size = sizeof(CThostFtdcInputOrderField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpOrder^ ToClass(CThostFtdcOrderField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcOrderField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpOrder^>(Marshal::PtrToStructure(ptr, CtpOrder::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpOrder^ source, CThostFtdcOrderField& dest)
				{
					int size = sizeof(CThostFtdcOrderField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpExchangeOrder^ ToClass(CThostFtdcExchangeOrderField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcExchangeOrderField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpExchangeOrder^>(Marshal::PtrToStructure(ptr, CtpExchangeOrder::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpExchangeOrder^ source, CThostFtdcExchangeOrderField& dest)
				{
					int size = sizeof(CThostFtdcExchangeOrderField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpExchangeOrderInsertError^ ToClass(CThostFtdcExchangeOrderInsertErrorField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcExchangeOrderInsertErrorField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpExchangeOrderInsertError^>(Marshal::PtrToStructure(ptr, CtpExchangeOrderInsertError::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpExchangeOrderInsertError^ source, CThostFtdcExchangeOrderInsertErrorField& dest)
				{
					int size = sizeof(CThostFtdcExchangeOrderInsertErrorField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpInputOrderAction^ ToClass(CThostFtdcInputOrderActionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcInputOrderActionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpInputOrderAction^>(Marshal::PtrToStructure(ptr, CtpInputOrderAction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpInputOrderAction^ source, CThostFtdcInputOrderActionField& dest)
				{
					int size = sizeof(CThostFtdcInputOrderActionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpOrderAction^ ToClass(CThostFtdcOrderActionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcOrderActionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpOrderAction^>(Marshal::PtrToStructure(ptr, CtpOrderAction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpOrderAction^ source, CThostFtdcOrderActionField& dest)
				{
					int size = sizeof(CThostFtdcOrderActionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpExchangeOrderAction^ ToClass(CThostFtdcExchangeOrderActionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcExchangeOrderActionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpExchangeOrderAction^>(Marshal::PtrToStructure(ptr, CtpExchangeOrderAction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpExchangeOrderAction^ source, CThostFtdcExchangeOrderActionField& dest)
				{
					int size = sizeof(CThostFtdcExchangeOrderActionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpExchangeOrderActionError^ ToClass(CThostFtdcExchangeOrderActionErrorField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcExchangeOrderActionErrorField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpExchangeOrderActionError^>(Marshal::PtrToStructure(ptr, CtpExchangeOrderActionError::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpExchangeOrderActionError^ source, CThostFtdcExchangeOrderActionErrorField& dest)
				{
					int size = sizeof(CThostFtdcExchangeOrderActionErrorField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpExchangeTrade^ ToClass(CThostFtdcExchangeTradeField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcExchangeTradeField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpExchangeTrade^>(Marshal::PtrToStructure(ptr, CtpExchangeTrade::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpExchangeTrade^ source, CThostFtdcExchangeTradeField& dest)
				{
					int size = sizeof(CThostFtdcExchangeTradeField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpTrade^ ToClass(CThostFtdcTradeField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcTradeField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpTrade^>(Marshal::PtrToStructure(ptr, CtpTrade::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpTrade^ source, CThostFtdcTradeField& dest)
				{
					int size = sizeof(CThostFtdcTradeField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpUserSession^ ToClass(CThostFtdcUserSessionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcUserSessionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpUserSession^>(Marshal::PtrToStructure(ptr, CtpUserSession::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpUserSession^ source, CThostFtdcUserSessionField& dest)
				{
					int size = sizeof(CThostFtdcUserSessionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQueryMaxOrderVolume^ ToClass(CThostFtdcQueryMaxOrderVolumeField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQueryMaxOrderVolumeField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQueryMaxOrderVolume^>(Marshal::PtrToStructure(ptr, CtpQueryMaxOrderVolume::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQueryMaxOrderVolume^ source, CThostFtdcQueryMaxOrderVolumeField& dest)
				{
					int size = sizeof(CThostFtdcQueryMaxOrderVolumeField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpSettlementInfoConfirm^ ToClass(CThostFtdcSettlementInfoConfirmField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcSettlementInfoConfirmField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpSettlementInfoConfirm^>(Marshal::PtrToStructure(ptr, CtpSettlementInfoConfirm::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpSettlementInfoConfirm^ source, CThostFtdcSettlementInfoConfirmField& dest)
				{
					int size = sizeof(CThostFtdcSettlementInfoConfirmField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpSyncDeposit^ ToClass(CThostFtdcSyncDepositField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcSyncDepositField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpSyncDeposit^>(Marshal::PtrToStructure(ptr, CtpSyncDeposit::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpSyncDeposit^ source, CThostFtdcSyncDepositField& dest)
				{
					int size = sizeof(CThostFtdcSyncDepositField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpSyncFundMortgage^ ToClass(CThostFtdcSyncFundMortgageField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcSyncFundMortgageField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpSyncFundMortgage^>(Marshal::PtrToStructure(ptr, CtpSyncFundMortgage::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpSyncFundMortgage^ source, CThostFtdcSyncFundMortgageField& dest)
				{
					int size = sizeof(CThostFtdcSyncFundMortgageField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpBrokerSync^ ToClass(CThostFtdcBrokerSyncField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcBrokerSyncField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpBrokerSync^>(Marshal::PtrToStructure(ptr, CtpBrokerSync::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpBrokerSync^ source, CThostFtdcBrokerSyncField& dest)
				{
					int size = sizeof(CThostFtdcBrokerSyncField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpSyncingInvestor^ ToClass(CThostFtdcSyncingInvestorField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcSyncingInvestorField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpSyncingInvestor^>(Marshal::PtrToStructure(ptr, CtpSyncingInvestor::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpSyncingInvestor^ source, CThostFtdcSyncingInvestorField& dest)
				{
					int size = sizeof(CThostFtdcSyncingInvestorField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpSyncingTradingCode^ ToClass(CThostFtdcSyncingTradingCodeField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcSyncingTradingCodeField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpSyncingTradingCode^>(Marshal::PtrToStructure(ptr, CtpSyncingTradingCode::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpSyncingTradingCode^ source, CThostFtdcSyncingTradingCodeField& dest)
				{
					int size = sizeof(CThostFtdcSyncingTradingCodeField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpSyncingInvestorGroup^ ToClass(CThostFtdcSyncingInvestorGroupField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcSyncingInvestorGroupField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpSyncingInvestorGroup^>(Marshal::PtrToStructure(ptr, CtpSyncingInvestorGroup::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpSyncingInvestorGroup^ source, CThostFtdcSyncingInvestorGroupField& dest)
				{
					int size = sizeof(CThostFtdcSyncingInvestorGroupField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpSyncingTradingAccount^ ToClass(CThostFtdcSyncingTradingAccountField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcSyncingTradingAccountField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpSyncingTradingAccount^>(Marshal::PtrToStructure(ptr, CtpSyncingTradingAccount::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpSyncingTradingAccount^ source, CThostFtdcSyncingTradingAccountField& dest)
				{
					int size = sizeof(CThostFtdcSyncingTradingAccountField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpSyncingInvestorPosition^ ToClass(CThostFtdcSyncingInvestorPositionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcSyncingInvestorPositionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpSyncingInvestorPosition^>(Marshal::PtrToStructure(ptr, CtpSyncingInvestorPosition::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpSyncingInvestorPosition^ source, CThostFtdcSyncingInvestorPositionField& dest)
				{
					int size = sizeof(CThostFtdcSyncingInvestorPositionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpSyncingInstrumentMarginRate^ ToClass(CThostFtdcSyncingInstrumentMarginRateField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcSyncingInstrumentMarginRateField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpSyncingInstrumentMarginRate^>(Marshal::PtrToStructure(ptr, CtpSyncingInstrumentMarginRate::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpSyncingInstrumentMarginRate^ source, CThostFtdcSyncingInstrumentMarginRateField& dest)
				{
					int size = sizeof(CThostFtdcSyncingInstrumentMarginRateField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpSyncingInstrumentCommissionRate^ ToClass(CThostFtdcSyncingInstrumentCommissionRateField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcSyncingInstrumentCommissionRateField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpSyncingInstrumentCommissionRate^>(Marshal::PtrToStructure(ptr, CtpSyncingInstrumentCommissionRate::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpSyncingInstrumentCommissionRate^ source, CThostFtdcSyncingInstrumentCommissionRateField& dest)
				{
					int size = sizeof(CThostFtdcSyncingInstrumentCommissionRateField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpSyncingInstrumentTradingRight^ ToClass(CThostFtdcSyncingInstrumentTradingRightField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcSyncingInstrumentTradingRightField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpSyncingInstrumentTradingRight^>(Marshal::PtrToStructure(ptr, CtpSyncingInstrumentTradingRight::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpSyncingInstrumentTradingRight^ source, CThostFtdcSyncingInstrumentTradingRightField& dest)
				{
					int size = sizeof(CThostFtdcSyncingInstrumentTradingRightField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryOrder^ ToClass(CThostFtdcQryOrderField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryOrderField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryOrder^>(Marshal::PtrToStructure(ptr, CtpQryOrder::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryOrder^ source, CThostFtdcQryOrderField& dest)
				{
					int size = sizeof(CThostFtdcQryOrderField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryTrade^ ToClass(CThostFtdcQryTradeField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryTradeField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryTrade^>(Marshal::PtrToStructure(ptr, CtpQryTrade::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryTrade^ source, CThostFtdcQryTradeField& dest)
				{
					int size = sizeof(CThostFtdcQryTradeField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryInvestorPosition^ ToClass(CThostFtdcQryInvestorPositionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryInvestorPositionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryInvestorPosition^>(Marshal::PtrToStructure(ptr, CtpQryInvestorPosition::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryInvestorPosition^ source, CThostFtdcQryInvestorPositionField& dest)
				{
					int size = sizeof(CThostFtdcQryInvestorPositionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryTradingAccount^ ToClass(CThostFtdcQryTradingAccountField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryTradingAccountField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryTradingAccount^>(Marshal::PtrToStructure(ptr, CtpQryTradingAccount::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryTradingAccount^ source, CThostFtdcQryTradingAccountField& dest)
				{
					int size = sizeof(CThostFtdcQryTradingAccountField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryInvestor^ ToClass(CThostFtdcQryInvestorField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryInvestorField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryInvestor^>(Marshal::PtrToStructure(ptr, CtpQryInvestor::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryInvestor^ source, CThostFtdcQryInvestorField& dest)
				{
					int size = sizeof(CThostFtdcQryInvestorField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryTradingCode^ ToClass(CThostFtdcQryTradingCodeField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryTradingCodeField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryTradingCode^>(Marshal::PtrToStructure(ptr, CtpQryTradingCode::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryTradingCode^ source, CThostFtdcQryTradingCodeField& dest)
				{
					int size = sizeof(CThostFtdcQryTradingCodeField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryInvestorGroup^ ToClass(CThostFtdcQryInvestorGroupField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryInvestorGroupField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryInvestorGroup^>(Marshal::PtrToStructure(ptr, CtpQryInvestorGroup::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryInvestorGroup^ source, CThostFtdcQryInvestorGroupField& dest)
				{
					int size = sizeof(CThostFtdcQryInvestorGroupField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryInstrumentMarginRate^ ToClass(CThostFtdcQryInstrumentMarginRateField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryInstrumentMarginRateField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryInstrumentMarginRate^>(Marshal::PtrToStructure(ptr, CtpQryInstrumentMarginRate::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryInstrumentMarginRate^ source, CThostFtdcQryInstrumentMarginRateField& dest)
				{
					int size = sizeof(CThostFtdcQryInstrumentMarginRateField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryInstrumentCommissionRate^ ToClass(CThostFtdcQryInstrumentCommissionRateField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryInstrumentCommissionRateField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryInstrumentCommissionRate^>(Marshal::PtrToStructure(ptr, CtpQryInstrumentCommissionRate::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryInstrumentCommissionRate^ source, CThostFtdcQryInstrumentCommissionRateField& dest)
				{
					int size = sizeof(CThostFtdcQryInstrumentCommissionRateField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryInstrumentTradingRight^ ToClass(CThostFtdcQryInstrumentTradingRightField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryInstrumentTradingRightField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryInstrumentTradingRight^>(Marshal::PtrToStructure(ptr, CtpQryInstrumentTradingRight::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryInstrumentTradingRight^ source, CThostFtdcQryInstrumentTradingRightField& dest)
				{
					int size = sizeof(CThostFtdcQryInstrumentTradingRightField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryBroker^ ToClass(CThostFtdcQryBrokerField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryBrokerField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryBroker^>(Marshal::PtrToStructure(ptr, CtpQryBroker::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryBroker^ source, CThostFtdcQryBrokerField& dest)
				{
					int size = sizeof(CThostFtdcQryBrokerField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryTrader^ ToClass(CThostFtdcQryTraderField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryTraderField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryTrader^>(Marshal::PtrToStructure(ptr, CtpQryTrader::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryTrader^ source, CThostFtdcQryTraderField& dest)
				{
					int size = sizeof(CThostFtdcQryTraderField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQrySuperUserFunction^ ToClass(CThostFtdcQrySuperUserFunctionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQrySuperUserFunctionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQrySuperUserFunction^>(Marshal::PtrToStructure(ptr, CtpQrySuperUserFunction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQrySuperUserFunction^ source, CThostFtdcQrySuperUserFunctionField& dest)
				{
					int size = sizeof(CThostFtdcQrySuperUserFunctionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryUserSession^ ToClass(CThostFtdcQryUserSessionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryUserSessionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryUserSession^>(Marshal::PtrToStructure(ptr, CtpQryUserSession::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryUserSession^ source, CThostFtdcQryUserSessionField& dest)
				{
					int size = sizeof(CThostFtdcQryUserSessionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryPartBroker^ ToClass(CThostFtdcQryPartBrokerField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryPartBrokerField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryPartBroker^>(Marshal::PtrToStructure(ptr, CtpQryPartBroker::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryPartBroker^ source, CThostFtdcQryPartBrokerField& dest)
				{
					int size = sizeof(CThostFtdcQryPartBrokerField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryFrontStatus^ ToClass(CThostFtdcQryFrontStatusField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryFrontStatusField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryFrontStatus^>(Marshal::PtrToStructure(ptr, CtpQryFrontStatus::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryFrontStatus^ source, CThostFtdcQryFrontStatusField& dest)
				{
					int size = sizeof(CThostFtdcQryFrontStatusField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryExchangeOrder^ ToClass(CThostFtdcQryExchangeOrderField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryExchangeOrderField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryExchangeOrder^>(Marshal::PtrToStructure(ptr, CtpQryExchangeOrder::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryExchangeOrder^ source, CThostFtdcQryExchangeOrderField& dest)
				{
					int size = sizeof(CThostFtdcQryExchangeOrderField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryOrderAction^ ToClass(CThostFtdcQryOrderActionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryOrderActionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryOrderAction^>(Marshal::PtrToStructure(ptr, CtpQryOrderAction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryOrderAction^ source, CThostFtdcQryOrderActionField& dest)
				{
					int size = sizeof(CThostFtdcQryOrderActionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryExchangeOrderAction^ ToClass(CThostFtdcQryExchangeOrderActionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryExchangeOrderActionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryExchangeOrderAction^>(Marshal::PtrToStructure(ptr, CtpQryExchangeOrderAction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryExchangeOrderAction^ source, CThostFtdcQryExchangeOrderActionField& dest)
				{
					int size = sizeof(CThostFtdcQryExchangeOrderActionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQrySuperUser^ ToClass(CThostFtdcQrySuperUserField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQrySuperUserField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQrySuperUser^>(Marshal::PtrToStructure(ptr, CtpQrySuperUser::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQrySuperUser^ source, CThostFtdcQrySuperUserField& dest)
				{
					int size = sizeof(CThostFtdcQrySuperUserField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryExchange^ ToClass(CThostFtdcQryExchangeField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryExchangeField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryExchange^>(Marshal::PtrToStructure(ptr, CtpQryExchange::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryExchange^ source, CThostFtdcQryExchangeField& dest)
				{
					int size = sizeof(CThostFtdcQryExchangeField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryProduct^ ToClass(CThostFtdcQryProductField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryProductField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryProduct^>(Marshal::PtrToStructure(ptr, CtpQryProduct::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryProduct^ source, CThostFtdcQryProductField& dest)
				{
					int size = sizeof(CThostFtdcQryProductField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryInstrument^ ToClass(CThostFtdcQryInstrumentField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryInstrumentField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryInstrument^>(Marshal::PtrToStructure(ptr, CtpQryInstrument::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryInstrument^ source, CThostFtdcQryInstrumentField& dest)
				{
					int size = sizeof(CThostFtdcQryInstrumentField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryDepthMarketData^ ToClass(CThostFtdcQryDepthMarketDataField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryDepthMarketDataField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryDepthMarketData^>(Marshal::PtrToStructure(ptr, CtpQryDepthMarketData::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryDepthMarketData^ source, CThostFtdcQryDepthMarketDataField& dest)
				{
					int size = sizeof(CThostFtdcQryDepthMarketDataField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryBrokerUser^ ToClass(CThostFtdcQryBrokerUserField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryBrokerUserField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryBrokerUser^>(Marshal::PtrToStructure(ptr, CtpQryBrokerUser::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryBrokerUser^ source, CThostFtdcQryBrokerUserField& dest)
				{
					int size = sizeof(CThostFtdcQryBrokerUserField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryBrokerUserFunction^ ToClass(CThostFtdcQryBrokerUserFunctionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryBrokerUserFunctionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryBrokerUserFunction^>(Marshal::PtrToStructure(ptr, CtpQryBrokerUserFunction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryBrokerUserFunction^ source, CThostFtdcQryBrokerUserFunctionField& dest)
				{
					int size = sizeof(CThostFtdcQryBrokerUserFunctionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryTraderOffer^ ToClass(CThostFtdcQryTraderOfferField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryTraderOfferField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryTraderOffer^>(Marshal::PtrToStructure(ptr, CtpQryTraderOffer::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryTraderOffer^ source, CThostFtdcQryTraderOfferField& dest)
				{
					int size = sizeof(CThostFtdcQryTraderOfferField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQrySyncDeposit^ ToClass(CThostFtdcQrySyncDepositField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQrySyncDepositField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQrySyncDeposit^>(Marshal::PtrToStructure(ptr, CtpQrySyncDeposit::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQrySyncDeposit^ source, CThostFtdcQrySyncDepositField& dest)
				{
					int size = sizeof(CThostFtdcQrySyncDepositField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQrySettlementInfo^ ToClass(CThostFtdcQrySettlementInfoField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQrySettlementInfoField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQrySettlementInfo^>(Marshal::PtrToStructure(ptr, CtpQrySettlementInfo::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQrySettlementInfo^ source, CThostFtdcQrySettlementInfoField& dest)
				{
					int size = sizeof(CThostFtdcQrySettlementInfoField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryExchangeMarginRate^ ToClass(CThostFtdcQryExchangeMarginRateField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryExchangeMarginRateField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryExchangeMarginRate^>(Marshal::PtrToStructure(ptr, CtpQryExchangeMarginRate::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryExchangeMarginRate^ source, CThostFtdcQryExchangeMarginRateField& dest)
				{
					int size = sizeof(CThostFtdcQryExchangeMarginRateField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryExchangeMarginRateAdjust^ ToClass(CThostFtdcQryExchangeMarginRateAdjustField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryExchangeMarginRateAdjustField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryExchangeMarginRateAdjust^>(Marshal::PtrToStructure(ptr, CtpQryExchangeMarginRateAdjust::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryExchangeMarginRateAdjust^ source, CThostFtdcQryExchangeMarginRateAdjustField& dest)
				{
					int size = sizeof(CThostFtdcQryExchangeMarginRateAdjustField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryExchangeRate^ ToClass(CThostFtdcQryExchangeRateField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryExchangeRateField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryExchangeRate^>(Marshal::PtrToStructure(ptr, CtpQryExchangeRate::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryExchangeRate^ source, CThostFtdcQryExchangeRateField& dest)
				{
					int size = sizeof(CThostFtdcQryExchangeRateField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQrySyncFundMortgage^ ToClass(CThostFtdcQrySyncFundMortgageField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQrySyncFundMortgageField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQrySyncFundMortgage^>(Marshal::PtrToStructure(ptr, CtpQrySyncFundMortgage::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQrySyncFundMortgage^ source, CThostFtdcQrySyncFundMortgageField& dest)
				{
					int size = sizeof(CThostFtdcQrySyncFundMortgageField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryHisOrder^ ToClass(CThostFtdcQryHisOrderField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryHisOrderField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryHisOrder^>(Marshal::PtrToStructure(ptr, CtpQryHisOrder::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryHisOrder^ source, CThostFtdcQryHisOrderField& dest)
				{
					int size = sizeof(CThostFtdcQryHisOrderField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpOptionInstrMiniMargin^ ToClass(CThostFtdcOptionInstrMiniMarginField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcOptionInstrMiniMarginField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpOptionInstrMiniMargin^>(Marshal::PtrToStructure(ptr, CtpOptionInstrMiniMargin::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpOptionInstrMiniMargin^ source, CThostFtdcOptionInstrMiniMarginField& dest)
				{
					int size = sizeof(CThostFtdcOptionInstrMiniMarginField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpOptionInstrMarginAdjust^ ToClass(CThostFtdcOptionInstrMarginAdjustField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcOptionInstrMarginAdjustField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpOptionInstrMarginAdjust^>(Marshal::PtrToStructure(ptr, CtpOptionInstrMarginAdjust::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpOptionInstrMarginAdjust^ source, CThostFtdcOptionInstrMarginAdjustField& dest)
				{
					int size = sizeof(CThostFtdcOptionInstrMarginAdjustField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpOptionInstrCommRate^ ToClass(CThostFtdcOptionInstrCommRateField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcOptionInstrCommRateField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpOptionInstrCommRate^>(Marshal::PtrToStructure(ptr, CtpOptionInstrCommRate::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpOptionInstrCommRate^ source, CThostFtdcOptionInstrCommRateField& dest)
				{
					int size = sizeof(CThostFtdcOptionInstrCommRateField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpOptionInstrTradeCost^ ToClass(CThostFtdcOptionInstrTradeCostField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcOptionInstrTradeCostField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpOptionInstrTradeCost^>(Marshal::PtrToStructure(ptr, CtpOptionInstrTradeCost::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpOptionInstrTradeCost^ source, CThostFtdcOptionInstrTradeCostField& dest)
				{
					int size = sizeof(CThostFtdcOptionInstrTradeCostField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryOptionInstrTradeCost^ ToClass(CThostFtdcQryOptionInstrTradeCostField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryOptionInstrTradeCostField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryOptionInstrTradeCost^>(Marshal::PtrToStructure(ptr, CtpQryOptionInstrTradeCost::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryOptionInstrTradeCost^ source, CThostFtdcQryOptionInstrTradeCostField& dest)
				{
					int size = sizeof(CThostFtdcQryOptionInstrTradeCostField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryOptionInstrCommRate^ ToClass(CThostFtdcQryOptionInstrCommRateField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryOptionInstrCommRateField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryOptionInstrCommRate^>(Marshal::PtrToStructure(ptr, CtpQryOptionInstrCommRate::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryOptionInstrCommRate^ source, CThostFtdcQryOptionInstrCommRateField& dest)
				{
					int size = sizeof(CThostFtdcQryOptionInstrCommRateField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpIndexPrice^ ToClass(CThostFtdcIndexPriceField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcIndexPriceField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpIndexPrice^>(Marshal::PtrToStructure(ptr, CtpIndexPrice::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpIndexPrice^ source, CThostFtdcIndexPriceField& dest)
				{
					int size = sizeof(CThostFtdcIndexPriceField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpInputExecOrder^ ToClass(CThostFtdcInputExecOrderField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcInputExecOrderField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpInputExecOrder^>(Marshal::PtrToStructure(ptr, CtpInputExecOrder::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpInputExecOrder^ source, CThostFtdcInputExecOrderField& dest)
				{
					int size = sizeof(CThostFtdcInputExecOrderField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpInputExecOrderAction^ ToClass(CThostFtdcInputExecOrderActionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcInputExecOrderActionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpInputExecOrderAction^>(Marshal::PtrToStructure(ptr, CtpInputExecOrderAction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpInputExecOrderAction^ source, CThostFtdcInputExecOrderActionField& dest)
				{
					int size = sizeof(CThostFtdcInputExecOrderActionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpExecOrder^ ToClass(CThostFtdcExecOrderField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcExecOrderField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpExecOrder^>(Marshal::PtrToStructure(ptr, CtpExecOrder::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpExecOrder^ source, CThostFtdcExecOrderField& dest)
				{
					int size = sizeof(CThostFtdcExecOrderField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpExecOrderAction^ ToClass(CThostFtdcExecOrderActionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcExecOrderActionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpExecOrderAction^>(Marshal::PtrToStructure(ptr, CtpExecOrderAction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpExecOrderAction^ source, CThostFtdcExecOrderActionField& dest)
				{
					int size = sizeof(CThostFtdcExecOrderActionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryExecOrder^ ToClass(CThostFtdcQryExecOrderField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryExecOrderField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryExecOrder^>(Marshal::PtrToStructure(ptr, CtpQryExecOrder::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryExecOrder^ source, CThostFtdcQryExecOrderField& dest)
				{
					int size = sizeof(CThostFtdcQryExecOrderField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpExchangeExecOrder^ ToClass(CThostFtdcExchangeExecOrderField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcExchangeExecOrderField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpExchangeExecOrder^>(Marshal::PtrToStructure(ptr, CtpExchangeExecOrder::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpExchangeExecOrder^ source, CThostFtdcExchangeExecOrderField& dest)
				{
					int size = sizeof(CThostFtdcExchangeExecOrderField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryExchangeExecOrder^ ToClass(CThostFtdcQryExchangeExecOrderField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryExchangeExecOrderField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryExchangeExecOrder^>(Marshal::PtrToStructure(ptr, CtpQryExchangeExecOrder::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryExchangeExecOrder^ source, CThostFtdcQryExchangeExecOrderField& dest)
				{
					int size = sizeof(CThostFtdcQryExchangeExecOrderField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryExecOrderAction^ ToClass(CThostFtdcQryExecOrderActionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryExecOrderActionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryExecOrderAction^>(Marshal::PtrToStructure(ptr, CtpQryExecOrderAction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryExecOrderAction^ source, CThostFtdcQryExecOrderActionField& dest)
				{
					int size = sizeof(CThostFtdcQryExecOrderActionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpExchangeExecOrderAction^ ToClass(CThostFtdcExchangeExecOrderActionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcExchangeExecOrderActionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpExchangeExecOrderAction^>(Marshal::PtrToStructure(ptr, CtpExchangeExecOrderAction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpExchangeExecOrderAction^ source, CThostFtdcExchangeExecOrderActionField& dest)
				{
					int size = sizeof(CThostFtdcExchangeExecOrderActionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryExchangeExecOrderAction^ ToClass(CThostFtdcQryExchangeExecOrderActionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryExchangeExecOrderActionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryExchangeExecOrderAction^>(Marshal::PtrToStructure(ptr, CtpQryExchangeExecOrderAction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryExchangeExecOrderAction^ source, CThostFtdcQryExchangeExecOrderActionField& dest)
				{
					int size = sizeof(CThostFtdcQryExchangeExecOrderActionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpErrExecOrder^ ToClass(CThostFtdcErrExecOrderField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcErrExecOrderField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpErrExecOrder^>(Marshal::PtrToStructure(ptr, CtpErrExecOrder::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpErrExecOrder^ source, CThostFtdcErrExecOrderField& dest)
				{
					int size = sizeof(CThostFtdcErrExecOrderField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryErrExecOrder^ ToClass(CThostFtdcQryErrExecOrderField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryErrExecOrderField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryErrExecOrder^>(Marshal::PtrToStructure(ptr, CtpQryErrExecOrder::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryErrExecOrder^ source, CThostFtdcQryErrExecOrderField& dest)
				{
					int size = sizeof(CThostFtdcQryErrExecOrderField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpErrExecOrderAction^ ToClass(CThostFtdcErrExecOrderActionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcErrExecOrderActionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpErrExecOrderAction^>(Marshal::PtrToStructure(ptr, CtpErrExecOrderAction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpErrExecOrderAction^ source, CThostFtdcErrExecOrderActionField& dest)
				{
					int size = sizeof(CThostFtdcErrExecOrderActionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryErrExecOrderAction^ ToClass(CThostFtdcQryErrExecOrderActionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryErrExecOrderActionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryErrExecOrderAction^>(Marshal::PtrToStructure(ptr, CtpQryErrExecOrderAction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryErrExecOrderAction^ source, CThostFtdcQryErrExecOrderActionField& dest)
				{
					int size = sizeof(CThostFtdcQryErrExecOrderActionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpOptionInstrTradingRight^ ToClass(CThostFtdcOptionInstrTradingRightField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcOptionInstrTradingRightField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpOptionInstrTradingRight^>(Marshal::PtrToStructure(ptr, CtpOptionInstrTradingRight::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpOptionInstrTradingRight^ source, CThostFtdcOptionInstrTradingRightField& dest)
				{
					int size = sizeof(CThostFtdcOptionInstrTradingRightField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryOptionInstrTradingRight^ ToClass(CThostFtdcQryOptionInstrTradingRightField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryOptionInstrTradingRightField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryOptionInstrTradingRight^>(Marshal::PtrToStructure(ptr, CtpQryOptionInstrTradingRight::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryOptionInstrTradingRight^ source, CThostFtdcQryOptionInstrTradingRightField& dest)
				{
					int size = sizeof(CThostFtdcQryOptionInstrTradingRightField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpInputForQuote^ ToClass(CThostFtdcInputForQuoteField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcInputForQuoteField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpInputForQuote^>(Marshal::PtrToStructure(ptr, CtpInputForQuote::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpInputForQuote^ source, CThostFtdcInputForQuoteField& dest)
				{
					int size = sizeof(CThostFtdcInputForQuoteField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpForQuote^ ToClass(CThostFtdcForQuoteField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcForQuoteField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpForQuote^>(Marshal::PtrToStructure(ptr, CtpForQuote::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpForQuote^ source, CThostFtdcForQuoteField& dest)
				{
					int size = sizeof(CThostFtdcForQuoteField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryForQuote^ ToClass(CThostFtdcQryForQuoteField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryForQuoteField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryForQuote^>(Marshal::PtrToStructure(ptr, CtpQryForQuote::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryForQuote^ source, CThostFtdcQryForQuoteField& dest)
				{
					int size = sizeof(CThostFtdcQryForQuoteField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpExchangeForQuote^ ToClass(CThostFtdcExchangeForQuoteField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcExchangeForQuoteField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpExchangeForQuote^>(Marshal::PtrToStructure(ptr, CtpExchangeForQuote::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpExchangeForQuote^ source, CThostFtdcExchangeForQuoteField& dest)
				{
					int size = sizeof(CThostFtdcExchangeForQuoteField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryExchangeForQuote^ ToClass(CThostFtdcQryExchangeForQuoteField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryExchangeForQuoteField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryExchangeForQuote^>(Marshal::PtrToStructure(ptr, CtpQryExchangeForQuote::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryExchangeForQuote^ source, CThostFtdcQryExchangeForQuoteField& dest)
				{
					int size = sizeof(CThostFtdcQryExchangeForQuoteField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpInputQuote^ ToClass(CThostFtdcInputQuoteField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcInputQuoteField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpInputQuote^>(Marshal::PtrToStructure(ptr, CtpInputQuote::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpInputQuote^ source, CThostFtdcInputQuoteField& dest)
				{
					int size = sizeof(CThostFtdcInputQuoteField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpInputQuoteAction^ ToClass(CThostFtdcInputQuoteActionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcInputQuoteActionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpInputQuoteAction^>(Marshal::PtrToStructure(ptr, CtpInputQuoteAction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpInputQuoteAction^ source, CThostFtdcInputQuoteActionField& dest)
				{
					int size = sizeof(CThostFtdcInputQuoteActionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQuote^ ToClass(CThostFtdcQuoteField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQuoteField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQuote^>(Marshal::PtrToStructure(ptr, CtpQuote::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQuote^ source, CThostFtdcQuoteField& dest)
				{
					int size = sizeof(CThostFtdcQuoteField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQuoteAction^ ToClass(CThostFtdcQuoteActionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQuoteActionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQuoteAction^>(Marshal::PtrToStructure(ptr, CtpQuoteAction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQuoteAction^ source, CThostFtdcQuoteActionField& dest)
				{
					int size = sizeof(CThostFtdcQuoteActionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryQuote^ ToClass(CThostFtdcQryQuoteField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryQuoteField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryQuote^>(Marshal::PtrToStructure(ptr, CtpQryQuote::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryQuote^ source, CThostFtdcQryQuoteField& dest)
				{
					int size = sizeof(CThostFtdcQryQuoteField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpExchangeQuote^ ToClass(CThostFtdcExchangeQuoteField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcExchangeQuoteField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpExchangeQuote^>(Marshal::PtrToStructure(ptr, CtpExchangeQuote::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpExchangeQuote^ source, CThostFtdcExchangeQuoteField& dest)
				{
					int size = sizeof(CThostFtdcExchangeQuoteField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryExchangeQuote^ ToClass(CThostFtdcQryExchangeQuoteField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryExchangeQuoteField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryExchangeQuote^>(Marshal::PtrToStructure(ptr, CtpQryExchangeQuote::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryExchangeQuote^ source, CThostFtdcQryExchangeQuoteField& dest)
				{
					int size = sizeof(CThostFtdcQryExchangeQuoteField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryQuoteAction^ ToClass(CThostFtdcQryQuoteActionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryQuoteActionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryQuoteAction^>(Marshal::PtrToStructure(ptr, CtpQryQuoteAction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryQuoteAction^ source, CThostFtdcQryQuoteActionField& dest)
				{
					int size = sizeof(CThostFtdcQryQuoteActionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpExchangeQuoteAction^ ToClass(CThostFtdcExchangeQuoteActionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcExchangeQuoteActionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpExchangeQuoteAction^>(Marshal::PtrToStructure(ptr, CtpExchangeQuoteAction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpExchangeQuoteAction^ source, CThostFtdcExchangeQuoteActionField& dest)
				{
					int size = sizeof(CThostFtdcExchangeQuoteActionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryExchangeQuoteAction^ ToClass(CThostFtdcQryExchangeQuoteActionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryExchangeQuoteActionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryExchangeQuoteAction^>(Marshal::PtrToStructure(ptr, CtpQryExchangeQuoteAction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryExchangeQuoteAction^ source, CThostFtdcQryExchangeQuoteActionField& dest)
				{
					int size = sizeof(CThostFtdcQryExchangeQuoteActionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpOptionInstrDelta^ ToClass(CThostFtdcOptionInstrDeltaField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcOptionInstrDeltaField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpOptionInstrDelta^>(Marshal::PtrToStructure(ptr, CtpOptionInstrDelta::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpOptionInstrDelta^ source, CThostFtdcOptionInstrDeltaField& dest)
				{
					int size = sizeof(CThostFtdcOptionInstrDeltaField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpForQuoteRsp^ ToClass(CThostFtdcForQuoteRspField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcForQuoteRspField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpForQuoteRsp^>(Marshal::PtrToStructure(ptr, CtpForQuoteRsp::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpForQuoteRsp^ source, CThostFtdcForQuoteRspField& dest)
				{
					int size = sizeof(CThostFtdcForQuoteRspField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpStrikeOffset^ ToClass(CThostFtdcStrikeOffsetField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcStrikeOffsetField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpStrikeOffset^>(Marshal::PtrToStructure(ptr, CtpStrikeOffset::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpStrikeOffset^ source, CThostFtdcStrikeOffsetField& dest)
				{
					int size = sizeof(CThostFtdcStrikeOffsetField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryStrikeOffset^ ToClass(CThostFtdcQryStrikeOffsetField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryStrikeOffsetField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryStrikeOffset^>(Marshal::PtrToStructure(ptr, CtpQryStrikeOffset::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryStrikeOffset^ source, CThostFtdcQryStrikeOffsetField& dest)
				{
					int size = sizeof(CThostFtdcQryStrikeOffsetField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpInputBatchOrderAction^ ToClass(CThostFtdcInputBatchOrderActionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcInputBatchOrderActionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpInputBatchOrderAction^>(Marshal::PtrToStructure(ptr, CtpInputBatchOrderAction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpInputBatchOrderAction^ source, CThostFtdcInputBatchOrderActionField& dest)
				{
					int size = sizeof(CThostFtdcInputBatchOrderActionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpBatchOrderAction^ ToClass(CThostFtdcBatchOrderActionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcBatchOrderActionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpBatchOrderAction^>(Marshal::PtrToStructure(ptr, CtpBatchOrderAction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpBatchOrderAction^ source, CThostFtdcBatchOrderActionField& dest)
				{
					int size = sizeof(CThostFtdcBatchOrderActionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpExchangeBatchOrderAction^ ToClass(CThostFtdcExchangeBatchOrderActionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcExchangeBatchOrderActionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpExchangeBatchOrderAction^>(Marshal::PtrToStructure(ptr, CtpExchangeBatchOrderAction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpExchangeBatchOrderAction^ source, CThostFtdcExchangeBatchOrderActionField& dest)
				{
					int size = sizeof(CThostFtdcExchangeBatchOrderActionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryBatchOrderAction^ ToClass(CThostFtdcQryBatchOrderActionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryBatchOrderActionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryBatchOrderAction^>(Marshal::PtrToStructure(ptr, CtpQryBatchOrderAction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryBatchOrderAction^ source, CThostFtdcQryBatchOrderActionField& dest)
				{
					int size = sizeof(CThostFtdcQryBatchOrderActionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpCombInstrumentGuard^ ToClass(CThostFtdcCombInstrumentGuardField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcCombInstrumentGuardField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpCombInstrumentGuard^>(Marshal::PtrToStructure(ptr, CtpCombInstrumentGuard::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpCombInstrumentGuard^ source, CThostFtdcCombInstrumentGuardField& dest)
				{
					int size = sizeof(CThostFtdcCombInstrumentGuardField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryCombInstrumentGuard^ ToClass(CThostFtdcQryCombInstrumentGuardField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryCombInstrumentGuardField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryCombInstrumentGuard^>(Marshal::PtrToStructure(ptr, CtpQryCombInstrumentGuard::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryCombInstrumentGuard^ source, CThostFtdcQryCombInstrumentGuardField& dest)
				{
					int size = sizeof(CThostFtdcQryCombInstrumentGuardField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpInputCombAction^ ToClass(CThostFtdcInputCombActionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcInputCombActionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpInputCombAction^>(Marshal::PtrToStructure(ptr, CtpInputCombAction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpInputCombAction^ source, CThostFtdcInputCombActionField& dest)
				{
					int size = sizeof(CThostFtdcInputCombActionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpCombAction^ ToClass(CThostFtdcCombActionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcCombActionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpCombAction^>(Marshal::PtrToStructure(ptr, CtpCombAction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpCombAction^ source, CThostFtdcCombActionField& dest)
				{
					int size = sizeof(CThostFtdcCombActionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryCombAction^ ToClass(CThostFtdcQryCombActionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryCombActionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryCombAction^>(Marshal::PtrToStructure(ptr, CtpQryCombAction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryCombAction^ source, CThostFtdcQryCombActionField& dest)
				{
					int size = sizeof(CThostFtdcQryCombActionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpExchangeCombAction^ ToClass(CThostFtdcExchangeCombActionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcExchangeCombActionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpExchangeCombAction^>(Marshal::PtrToStructure(ptr, CtpExchangeCombAction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpExchangeCombAction^ source, CThostFtdcExchangeCombActionField& dest)
				{
					int size = sizeof(CThostFtdcExchangeCombActionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryExchangeCombAction^ ToClass(CThostFtdcQryExchangeCombActionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryExchangeCombActionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryExchangeCombAction^>(Marshal::PtrToStructure(ptr, CtpQryExchangeCombAction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryExchangeCombAction^ source, CThostFtdcQryExchangeCombActionField& dest)
				{
					int size = sizeof(CThostFtdcQryExchangeCombActionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpProductExchRate^ ToClass(CThostFtdcProductExchRateField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcProductExchRateField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpProductExchRate^>(Marshal::PtrToStructure(ptr, CtpProductExchRate::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpProductExchRate^ source, CThostFtdcProductExchRateField& dest)
				{
					int size = sizeof(CThostFtdcProductExchRateField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryProductExchRate^ ToClass(CThostFtdcQryProductExchRateField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryProductExchRateField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryProductExchRate^>(Marshal::PtrToStructure(ptr, CtpQryProductExchRate::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryProductExchRate^ source, CThostFtdcQryProductExchRateField& dest)
				{
					int size = sizeof(CThostFtdcQryProductExchRateField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryForQuoteParam^ ToClass(CThostFtdcQryForQuoteParamField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryForQuoteParamField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryForQuoteParam^>(Marshal::PtrToStructure(ptr, CtpQryForQuoteParam::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryForQuoteParam^ source, CThostFtdcQryForQuoteParamField& dest)
				{
					int size = sizeof(CThostFtdcQryForQuoteParamField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpForQuoteParam^ ToClass(CThostFtdcForQuoteParamField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcForQuoteParamField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpForQuoteParam^>(Marshal::PtrToStructure(ptr, CtpForQuoteParam::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpForQuoteParam^ source, CThostFtdcForQuoteParamField& dest)
				{
					int size = sizeof(CThostFtdcForQuoteParamField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpMarketData^ ToClass(CThostFtdcMarketDataField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcMarketDataField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpMarketData^>(Marshal::PtrToStructure(ptr, CtpMarketData::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpMarketData^ source, CThostFtdcMarketDataField& dest)
				{
					int size = sizeof(CThostFtdcMarketDataField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpMarketDataBase^ ToClass(CThostFtdcMarketDataBaseField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcMarketDataBaseField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpMarketDataBase^>(Marshal::PtrToStructure(ptr, CtpMarketDataBase::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpMarketDataBase^ source, CThostFtdcMarketDataBaseField& dest)
				{
					int size = sizeof(CThostFtdcMarketDataBaseField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpMarketDataStatic^ ToClass(CThostFtdcMarketDataStaticField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcMarketDataStaticField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpMarketDataStatic^>(Marshal::PtrToStructure(ptr, CtpMarketDataStatic::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpMarketDataStatic^ source, CThostFtdcMarketDataStaticField& dest)
				{
					int size = sizeof(CThostFtdcMarketDataStaticField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpMarketDataLastMatch^ ToClass(CThostFtdcMarketDataLastMatchField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcMarketDataLastMatchField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpMarketDataLastMatch^>(Marshal::PtrToStructure(ptr, CtpMarketDataLastMatch::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpMarketDataLastMatch^ source, CThostFtdcMarketDataLastMatchField& dest)
				{
					int size = sizeof(CThostFtdcMarketDataLastMatchField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpMarketDataBestPrice^ ToClass(CThostFtdcMarketDataBestPriceField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcMarketDataBestPriceField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpMarketDataBestPrice^>(Marshal::PtrToStructure(ptr, CtpMarketDataBestPrice::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpMarketDataBestPrice^ source, CThostFtdcMarketDataBestPriceField& dest)
				{
					int size = sizeof(CThostFtdcMarketDataBestPriceField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpMarketDataBid23^ ToClass(CThostFtdcMarketDataBid23Field* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcMarketDataBid23Field);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpMarketDataBid23^>(Marshal::PtrToStructure(ptr, CtpMarketDataBid23::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpMarketDataBid23^ source, CThostFtdcMarketDataBid23Field& dest)
				{
					int size = sizeof(CThostFtdcMarketDataBid23Field);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpMarketDataAsk23^ ToClass(CThostFtdcMarketDataAsk23Field* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcMarketDataAsk23Field);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpMarketDataAsk23^>(Marshal::PtrToStructure(ptr, CtpMarketDataAsk23::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpMarketDataAsk23^ source, CThostFtdcMarketDataAsk23Field& dest)
				{
					int size = sizeof(CThostFtdcMarketDataAsk23Field);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpMarketDataBid45^ ToClass(CThostFtdcMarketDataBid45Field* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcMarketDataBid45Field);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpMarketDataBid45^>(Marshal::PtrToStructure(ptr, CtpMarketDataBid45::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpMarketDataBid45^ source, CThostFtdcMarketDataBid45Field& dest)
				{
					int size = sizeof(CThostFtdcMarketDataBid45Field);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpMarketDataAsk45^ ToClass(CThostFtdcMarketDataAsk45Field* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcMarketDataAsk45Field);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpMarketDataAsk45^>(Marshal::PtrToStructure(ptr, CtpMarketDataAsk45::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpMarketDataAsk45^ source, CThostFtdcMarketDataAsk45Field& dest)
				{
					int size = sizeof(CThostFtdcMarketDataAsk45Field);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpMarketDataUpdateTime^ ToClass(CThostFtdcMarketDataUpdateTimeField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcMarketDataUpdateTimeField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpMarketDataUpdateTime^>(Marshal::PtrToStructure(ptr, CtpMarketDataUpdateTime::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpMarketDataUpdateTime^ source, CThostFtdcMarketDataUpdateTimeField& dest)
				{
					int size = sizeof(CThostFtdcMarketDataUpdateTimeField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpMarketDataExchange^ ToClass(CThostFtdcMarketDataExchangeField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcMarketDataExchangeField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpMarketDataExchange^>(Marshal::PtrToStructure(ptr, CtpMarketDataExchange::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpMarketDataExchange^ source, CThostFtdcMarketDataExchangeField& dest)
				{
					int size = sizeof(CThostFtdcMarketDataExchangeField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpSpecificInstrument^ ToClass(CThostFtdcSpecificInstrumentField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcSpecificInstrumentField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpSpecificInstrument^>(Marshal::PtrToStructure(ptr, CtpSpecificInstrument::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpSpecificInstrument^ source, CThostFtdcSpecificInstrumentField& dest)
				{
					int size = sizeof(CThostFtdcSpecificInstrumentField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpInstrumentStatus^ ToClass(CThostFtdcInstrumentStatusField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcInstrumentStatusField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpInstrumentStatus^>(Marshal::PtrToStructure(ptr, CtpInstrumentStatus::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpInstrumentStatus^ source, CThostFtdcInstrumentStatusField& dest)
				{
					int size = sizeof(CThostFtdcInstrumentStatusField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryInstrumentStatus^ ToClass(CThostFtdcQryInstrumentStatusField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryInstrumentStatusField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryInstrumentStatus^>(Marshal::PtrToStructure(ptr, CtpQryInstrumentStatus::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryInstrumentStatus^ source, CThostFtdcQryInstrumentStatusField& dest)
				{
					int size = sizeof(CThostFtdcQryInstrumentStatusField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpInvestorAccount^ ToClass(CThostFtdcInvestorAccountField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcInvestorAccountField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpInvestorAccount^>(Marshal::PtrToStructure(ptr, CtpInvestorAccount::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpInvestorAccount^ source, CThostFtdcInvestorAccountField& dest)
				{
					int size = sizeof(CThostFtdcInvestorAccountField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpPositionProfitAlgorithm^ ToClass(CThostFtdcPositionProfitAlgorithmField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcPositionProfitAlgorithmField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpPositionProfitAlgorithm^>(Marshal::PtrToStructure(ptr, CtpPositionProfitAlgorithm::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpPositionProfitAlgorithm^ source, CThostFtdcPositionProfitAlgorithmField& dest)
				{
					int size = sizeof(CThostFtdcPositionProfitAlgorithmField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpDiscount^ ToClass(CThostFtdcDiscountField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcDiscountField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpDiscount^>(Marshal::PtrToStructure(ptr, CtpDiscount::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpDiscount^ source, CThostFtdcDiscountField& dest)
				{
					int size = sizeof(CThostFtdcDiscountField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryTransferBank^ ToClass(CThostFtdcQryTransferBankField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryTransferBankField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryTransferBank^>(Marshal::PtrToStructure(ptr, CtpQryTransferBank::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryTransferBank^ source, CThostFtdcQryTransferBankField& dest)
				{
					int size = sizeof(CThostFtdcQryTransferBankField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpTransferBank^ ToClass(CThostFtdcTransferBankField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcTransferBankField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpTransferBank^>(Marshal::PtrToStructure(ptr, CtpTransferBank::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpTransferBank^ source, CThostFtdcTransferBankField& dest)
				{
					int size = sizeof(CThostFtdcTransferBankField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryInvestorPositionDetail^ ToClass(CThostFtdcQryInvestorPositionDetailField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryInvestorPositionDetailField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryInvestorPositionDetail^>(Marshal::PtrToStructure(ptr, CtpQryInvestorPositionDetail::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryInvestorPositionDetail^ source, CThostFtdcQryInvestorPositionDetailField& dest)
				{
					int size = sizeof(CThostFtdcQryInvestorPositionDetailField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpInvestorPositionDetail^ ToClass(CThostFtdcInvestorPositionDetailField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcInvestorPositionDetailField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpInvestorPositionDetail^>(Marshal::PtrToStructure(ptr, CtpInvestorPositionDetail::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpInvestorPositionDetail^ source, CThostFtdcInvestorPositionDetailField& dest)
				{
					int size = sizeof(CThostFtdcInvestorPositionDetailField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpTradingAccountPassword^ ToClass(CThostFtdcTradingAccountPasswordField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcTradingAccountPasswordField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpTradingAccountPassword^>(Marshal::PtrToStructure(ptr, CtpTradingAccountPassword::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpTradingAccountPassword^ source, CThostFtdcTradingAccountPasswordField& dest)
				{
					int size = sizeof(CThostFtdcTradingAccountPasswordField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpMDTraderOffer^ ToClass(CThostFtdcMDTraderOfferField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcMDTraderOfferField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpMDTraderOffer^>(Marshal::PtrToStructure(ptr, CtpMDTraderOffer::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpMDTraderOffer^ source, CThostFtdcMDTraderOfferField& dest)
				{
					int size = sizeof(CThostFtdcMDTraderOfferField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryMDTraderOffer^ ToClass(CThostFtdcQryMDTraderOfferField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryMDTraderOfferField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryMDTraderOffer^>(Marshal::PtrToStructure(ptr, CtpQryMDTraderOffer::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryMDTraderOffer^ source, CThostFtdcQryMDTraderOfferField& dest)
				{
					int size = sizeof(CThostFtdcQryMDTraderOfferField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryNotice^ ToClass(CThostFtdcQryNoticeField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryNoticeField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryNotice^>(Marshal::PtrToStructure(ptr, CtpQryNotice::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryNotice^ source, CThostFtdcQryNoticeField& dest)
				{
					int size = sizeof(CThostFtdcQryNoticeField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpNotice^ ToClass(CThostFtdcNoticeField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcNoticeField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpNotice^>(Marshal::PtrToStructure(ptr, CtpNotice::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpNotice^ source, CThostFtdcNoticeField& dest)
				{
					int size = sizeof(CThostFtdcNoticeField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpUserRight^ ToClass(CThostFtdcUserRightField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcUserRightField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpUserRight^>(Marshal::PtrToStructure(ptr, CtpUserRight::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpUserRight^ source, CThostFtdcUserRightField& dest)
				{
					int size = sizeof(CThostFtdcUserRightField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQrySettlementInfoConfirm^ ToClass(CThostFtdcQrySettlementInfoConfirmField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQrySettlementInfoConfirmField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQrySettlementInfoConfirm^>(Marshal::PtrToStructure(ptr, CtpQrySettlementInfoConfirm::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQrySettlementInfoConfirm^ source, CThostFtdcQrySettlementInfoConfirmField& dest)
				{
					int size = sizeof(CThostFtdcQrySettlementInfoConfirmField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpLoadSettlementInfo^ ToClass(CThostFtdcLoadSettlementInfoField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcLoadSettlementInfoField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpLoadSettlementInfo^>(Marshal::PtrToStructure(ptr, CtpLoadSettlementInfo::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpLoadSettlementInfo^ source, CThostFtdcLoadSettlementInfoField& dest)
				{
					int size = sizeof(CThostFtdcLoadSettlementInfoField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpBrokerWithdrawAlgorithm^ ToClass(CThostFtdcBrokerWithdrawAlgorithmField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcBrokerWithdrawAlgorithmField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpBrokerWithdrawAlgorithm^>(Marshal::PtrToStructure(ptr, CtpBrokerWithdrawAlgorithm::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpBrokerWithdrawAlgorithm^ source, CThostFtdcBrokerWithdrawAlgorithmField& dest)
				{
					int size = sizeof(CThostFtdcBrokerWithdrawAlgorithmField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpTradingAccountPasswordUpdateV1^ ToClass(CThostFtdcTradingAccountPasswordUpdateV1Field* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcTradingAccountPasswordUpdateV1Field);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpTradingAccountPasswordUpdateV1^>(Marshal::PtrToStructure(ptr, CtpTradingAccountPasswordUpdateV1::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpTradingAccountPasswordUpdateV1^ source, CThostFtdcTradingAccountPasswordUpdateV1Field& dest)
				{
					int size = sizeof(CThostFtdcTradingAccountPasswordUpdateV1Field);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpTradingAccountPasswordUpdate^ ToClass(CThostFtdcTradingAccountPasswordUpdateField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcTradingAccountPasswordUpdateField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpTradingAccountPasswordUpdate^>(Marshal::PtrToStructure(ptr, CtpTradingAccountPasswordUpdate::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpTradingAccountPasswordUpdate^ source, CThostFtdcTradingAccountPasswordUpdateField& dest)
				{
					int size = sizeof(CThostFtdcTradingAccountPasswordUpdateField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryCombinationLeg^ ToClass(CThostFtdcQryCombinationLegField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryCombinationLegField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryCombinationLeg^>(Marshal::PtrToStructure(ptr, CtpQryCombinationLeg::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryCombinationLeg^ source, CThostFtdcQryCombinationLegField& dest)
				{
					int size = sizeof(CThostFtdcQryCombinationLegField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQrySyncStatus^ ToClass(CThostFtdcQrySyncStatusField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQrySyncStatusField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQrySyncStatus^>(Marshal::PtrToStructure(ptr, CtpQrySyncStatus::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQrySyncStatus^ source, CThostFtdcQrySyncStatusField& dest)
				{
					int size = sizeof(CThostFtdcQrySyncStatusField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpCombinationLeg^ ToClass(CThostFtdcCombinationLegField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcCombinationLegField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpCombinationLeg^>(Marshal::PtrToStructure(ptr, CtpCombinationLeg::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpCombinationLeg^ source, CThostFtdcCombinationLegField& dest)
				{
					int size = sizeof(CThostFtdcCombinationLegField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpSyncStatus^ ToClass(CThostFtdcSyncStatusField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcSyncStatusField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpSyncStatus^>(Marshal::PtrToStructure(ptr, CtpSyncStatus::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpSyncStatus^ source, CThostFtdcSyncStatusField& dest)
				{
					int size = sizeof(CThostFtdcSyncStatusField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryLinkMan^ ToClass(CThostFtdcQryLinkManField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryLinkManField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryLinkMan^>(Marshal::PtrToStructure(ptr, CtpQryLinkMan::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryLinkMan^ source, CThostFtdcQryLinkManField& dest)
				{
					int size = sizeof(CThostFtdcQryLinkManField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpLinkMan^ ToClass(CThostFtdcLinkManField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcLinkManField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpLinkMan^>(Marshal::PtrToStructure(ptr, CtpLinkMan::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpLinkMan^ source, CThostFtdcLinkManField& dest)
				{
					int size = sizeof(CThostFtdcLinkManField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryBrokerUserEvent^ ToClass(CThostFtdcQryBrokerUserEventField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryBrokerUserEventField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryBrokerUserEvent^>(Marshal::PtrToStructure(ptr, CtpQryBrokerUserEvent::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryBrokerUserEvent^ source, CThostFtdcQryBrokerUserEventField& dest)
				{
					int size = sizeof(CThostFtdcQryBrokerUserEventField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpBrokerUserEvent^ ToClass(CThostFtdcBrokerUserEventField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcBrokerUserEventField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpBrokerUserEvent^>(Marshal::PtrToStructure(ptr, CtpBrokerUserEvent::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpBrokerUserEvent^ source, CThostFtdcBrokerUserEventField& dest)
				{
					int size = sizeof(CThostFtdcBrokerUserEventField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryContractBank^ ToClass(CThostFtdcQryContractBankField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryContractBankField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryContractBank^>(Marshal::PtrToStructure(ptr, CtpQryContractBank::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryContractBank^ source, CThostFtdcQryContractBankField& dest)
				{
					int size = sizeof(CThostFtdcQryContractBankField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpContractBank^ ToClass(CThostFtdcContractBankField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcContractBankField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpContractBank^>(Marshal::PtrToStructure(ptr, CtpContractBank::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpContractBank^ source, CThostFtdcContractBankField& dest)
				{
					int size = sizeof(CThostFtdcContractBankField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpInvestorPositionCombineDetail^ ToClass(CThostFtdcInvestorPositionCombineDetailField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcInvestorPositionCombineDetailField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpInvestorPositionCombineDetail^>(Marshal::PtrToStructure(ptr, CtpInvestorPositionCombineDetail::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpInvestorPositionCombineDetail^ source, CThostFtdcInvestorPositionCombineDetailField& dest)
				{
					int size = sizeof(CThostFtdcInvestorPositionCombineDetailField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpParkedOrder^ ToClass(CThostFtdcParkedOrderField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcParkedOrderField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpParkedOrder^>(Marshal::PtrToStructure(ptr, CtpParkedOrder::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpParkedOrder^ source, CThostFtdcParkedOrderField& dest)
				{
					int size = sizeof(CThostFtdcParkedOrderField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpParkedOrderAction^ ToClass(CThostFtdcParkedOrderActionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcParkedOrderActionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpParkedOrderAction^>(Marshal::PtrToStructure(ptr, CtpParkedOrderAction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpParkedOrderAction^ source, CThostFtdcParkedOrderActionField& dest)
				{
					int size = sizeof(CThostFtdcParkedOrderActionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryParkedOrder^ ToClass(CThostFtdcQryParkedOrderField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryParkedOrderField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryParkedOrder^>(Marshal::PtrToStructure(ptr, CtpQryParkedOrder::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryParkedOrder^ source, CThostFtdcQryParkedOrderField& dest)
				{
					int size = sizeof(CThostFtdcQryParkedOrderField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryParkedOrderAction^ ToClass(CThostFtdcQryParkedOrderActionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryParkedOrderActionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryParkedOrderAction^>(Marshal::PtrToStructure(ptr, CtpQryParkedOrderAction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryParkedOrderAction^ source, CThostFtdcQryParkedOrderActionField& dest)
				{
					int size = sizeof(CThostFtdcQryParkedOrderActionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpRemoveParkedOrder^ ToClass(CThostFtdcRemoveParkedOrderField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcRemoveParkedOrderField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpRemoveParkedOrder^>(Marshal::PtrToStructure(ptr, CtpRemoveParkedOrder::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpRemoveParkedOrder^ source, CThostFtdcRemoveParkedOrderField& dest)
				{
					int size = sizeof(CThostFtdcRemoveParkedOrderField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpRemoveParkedOrderAction^ ToClass(CThostFtdcRemoveParkedOrderActionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcRemoveParkedOrderActionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpRemoveParkedOrderAction^>(Marshal::PtrToStructure(ptr, CtpRemoveParkedOrderAction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpRemoveParkedOrderAction^ source, CThostFtdcRemoveParkedOrderActionField& dest)
				{
					int size = sizeof(CThostFtdcRemoveParkedOrderActionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpInvestorWithdrawAlgorithm^ ToClass(CThostFtdcInvestorWithdrawAlgorithmField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcInvestorWithdrawAlgorithmField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpInvestorWithdrawAlgorithm^>(Marshal::PtrToStructure(ptr, CtpInvestorWithdrawAlgorithm::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpInvestorWithdrawAlgorithm^ source, CThostFtdcInvestorWithdrawAlgorithmField& dest)
				{
					int size = sizeof(CThostFtdcInvestorWithdrawAlgorithmField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryInvestorPositionCombineDetail^ ToClass(CThostFtdcQryInvestorPositionCombineDetailField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryInvestorPositionCombineDetailField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryInvestorPositionCombineDetail^>(Marshal::PtrToStructure(ptr, CtpQryInvestorPositionCombineDetail::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryInvestorPositionCombineDetail^ source, CThostFtdcQryInvestorPositionCombineDetailField& dest)
				{
					int size = sizeof(CThostFtdcQryInvestorPositionCombineDetailField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpMarketDataAveragePrice^ ToClass(CThostFtdcMarketDataAveragePriceField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcMarketDataAveragePriceField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpMarketDataAveragePrice^>(Marshal::PtrToStructure(ptr, CtpMarketDataAveragePrice::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpMarketDataAveragePrice^ source, CThostFtdcMarketDataAveragePriceField& dest)
				{
					int size = sizeof(CThostFtdcMarketDataAveragePriceField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpVerifyInvestorPassword^ ToClass(CThostFtdcVerifyInvestorPasswordField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcVerifyInvestorPasswordField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpVerifyInvestorPassword^>(Marshal::PtrToStructure(ptr, CtpVerifyInvestorPassword::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpVerifyInvestorPassword^ source, CThostFtdcVerifyInvestorPasswordField& dest)
				{
					int size = sizeof(CThostFtdcVerifyInvestorPasswordField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpUserIP^ ToClass(CThostFtdcUserIPField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcUserIPField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpUserIP^>(Marshal::PtrToStructure(ptr, CtpUserIP::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpUserIP^ source, CThostFtdcUserIPField& dest)
				{
					int size = sizeof(CThostFtdcUserIPField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpTradingNoticeInfo^ ToClass(CThostFtdcTradingNoticeInfoField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcTradingNoticeInfoField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpTradingNoticeInfo^>(Marshal::PtrToStructure(ptr, CtpTradingNoticeInfo::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpTradingNoticeInfo^ source, CThostFtdcTradingNoticeInfoField& dest)
				{
					int size = sizeof(CThostFtdcTradingNoticeInfoField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpTradingNotice^ ToClass(CThostFtdcTradingNoticeField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcTradingNoticeField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpTradingNotice^>(Marshal::PtrToStructure(ptr, CtpTradingNotice::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpTradingNotice^ source, CThostFtdcTradingNoticeField& dest)
				{
					int size = sizeof(CThostFtdcTradingNoticeField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryTradingNotice^ ToClass(CThostFtdcQryTradingNoticeField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryTradingNoticeField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryTradingNotice^>(Marshal::PtrToStructure(ptr, CtpQryTradingNotice::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryTradingNotice^ source, CThostFtdcQryTradingNoticeField& dest)
				{
					int size = sizeof(CThostFtdcQryTradingNoticeField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryErrOrder^ ToClass(CThostFtdcQryErrOrderField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryErrOrderField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryErrOrder^>(Marshal::PtrToStructure(ptr, CtpQryErrOrder::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryErrOrder^ source, CThostFtdcQryErrOrderField& dest)
				{
					int size = sizeof(CThostFtdcQryErrOrderField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpErrOrder^ ToClass(CThostFtdcErrOrderField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcErrOrderField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpErrOrder^>(Marshal::PtrToStructure(ptr, CtpErrOrder::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpErrOrder^ source, CThostFtdcErrOrderField& dest)
				{
					int size = sizeof(CThostFtdcErrOrderField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpErrorConditionalOrder^ ToClass(CThostFtdcErrorConditionalOrderField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcErrorConditionalOrderField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpErrorConditionalOrder^>(Marshal::PtrToStructure(ptr, CtpErrorConditionalOrder::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpErrorConditionalOrder^ source, CThostFtdcErrorConditionalOrderField& dest)
				{
					int size = sizeof(CThostFtdcErrorConditionalOrderField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryErrOrderAction^ ToClass(CThostFtdcQryErrOrderActionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryErrOrderActionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryErrOrderAction^>(Marshal::PtrToStructure(ptr, CtpQryErrOrderAction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryErrOrderAction^ source, CThostFtdcQryErrOrderActionField& dest)
				{
					int size = sizeof(CThostFtdcQryErrOrderActionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpErrOrderAction^ ToClass(CThostFtdcErrOrderActionField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcErrOrderActionField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpErrOrderAction^>(Marshal::PtrToStructure(ptr, CtpErrOrderAction::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpErrOrderAction^ source, CThostFtdcErrOrderActionField& dest)
				{
					int size = sizeof(CThostFtdcErrOrderActionField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryExchangeSequence^ ToClass(CThostFtdcQryExchangeSequenceField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryExchangeSequenceField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryExchangeSequence^>(Marshal::PtrToStructure(ptr, CtpQryExchangeSequence::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryExchangeSequence^ source, CThostFtdcQryExchangeSequenceField& dest)
				{
					int size = sizeof(CThostFtdcQryExchangeSequenceField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpExchangeSequence^ ToClass(CThostFtdcExchangeSequenceField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcExchangeSequenceField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpExchangeSequence^>(Marshal::PtrToStructure(ptr, CtpExchangeSequence::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpExchangeSequence^ source, CThostFtdcExchangeSequenceField& dest)
				{
					int size = sizeof(CThostFtdcExchangeSequenceField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQueryMaxOrderVolumeWithPrice^ ToClass(CThostFtdcQueryMaxOrderVolumeWithPriceField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQueryMaxOrderVolumeWithPriceField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQueryMaxOrderVolumeWithPrice^>(Marshal::PtrToStructure(ptr, CtpQueryMaxOrderVolumeWithPrice::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQueryMaxOrderVolumeWithPrice^ source, CThostFtdcQueryMaxOrderVolumeWithPriceField& dest)
				{
					int size = sizeof(CThostFtdcQueryMaxOrderVolumeWithPriceField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryBrokerTradingParams^ ToClass(CThostFtdcQryBrokerTradingParamsField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryBrokerTradingParamsField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryBrokerTradingParams^>(Marshal::PtrToStructure(ptr, CtpQryBrokerTradingParams::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryBrokerTradingParams^ source, CThostFtdcQryBrokerTradingParamsField& dest)
				{
					int size = sizeof(CThostFtdcQryBrokerTradingParamsField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpBrokerTradingParams^ ToClass(CThostFtdcBrokerTradingParamsField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcBrokerTradingParamsField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpBrokerTradingParams^>(Marshal::PtrToStructure(ptr, CtpBrokerTradingParams::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpBrokerTradingParams^ source, CThostFtdcBrokerTradingParamsField& dest)
				{
					int size = sizeof(CThostFtdcBrokerTradingParamsField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryBrokerTradingAlgos^ ToClass(CThostFtdcQryBrokerTradingAlgosField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryBrokerTradingAlgosField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryBrokerTradingAlgos^>(Marshal::PtrToStructure(ptr, CtpQryBrokerTradingAlgos::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryBrokerTradingAlgos^ source, CThostFtdcQryBrokerTradingAlgosField& dest)
				{
					int size = sizeof(CThostFtdcQryBrokerTradingAlgosField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpBrokerTradingAlgos^ ToClass(CThostFtdcBrokerTradingAlgosField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcBrokerTradingAlgosField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpBrokerTradingAlgos^>(Marshal::PtrToStructure(ptr, CtpBrokerTradingAlgos::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpBrokerTradingAlgos^ source, CThostFtdcBrokerTradingAlgosField& dest)
				{
					int size = sizeof(CThostFtdcBrokerTradingAlgosField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQueryBrokerDeposit^ ToClass(CThostFtdcQueryBrokerDepositField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQueryBrokerDepositField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQueryBrokerDeposit^>(Marshal::PtrToStructure(ptr, CtpQueryBrokerDeposit::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQueryBrokerDeposit^ source, CThostFtdcQueryBrokerDepositField& dest)
				{
					int size = sizeof(CThostFtdcQueryBrokerDepositField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpBrokerDeposit^ ToClass(CThostFtdcBrokerDepositField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcBrokerDepositField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpBrokerDeposit^>(Marshal::PtrToStructure(ptr, CtpBrokerDeposit::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpBrokerDeposit^ source, CThostFtdcBrokerDepositField& dest)
				{
					int size = sizeof(CThostFtdcBrokerDepositField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryCFMMCBrokerKey^ ToClass(CThostFtdcQryCFMMCBrokerKeyField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryCFMMCBrokerKeyField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryCFMMCBrokerKey^>(Marshal::PtrToStructure(ptr, CtpQryCFMMCBrokerKey::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryCFMMCBrokerKey^ source, CThostFtdcQryCFMMCBrokerKeyField& dest)
				{
					int size = sizeof(CThostFtdcQryCFMMCBrokerKeyField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpCFMMCBrokerKey^ ToClass(CThostFtdcCFMMCBrokerKeyField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcCFMMCBrokerKeyField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpCFMMCBrokerKey^>(Marshal::PtrToStructure(ptr, CtpCFMMCBrokerKey::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpCFMMCBrokerKey^ source, CThostFtdcCFMMCBrokerKeyField& dest)
				{
					int size = sizeof(CThostFtdcCFMMCBrokerKeyField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpCFMMCTradingAccountKey^ ToClass(CThostFtdcCFMMCTradingAccountKeyField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcCFMMCTradingAccountKeyField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpCFMMCTradingAccountKey^>(Marshal::PtrToStructure(ptr, CtpCFMMCTradingAccountKey::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpCFMMCTradingAccountKey^ source, CThostFtdcCFMMCTradingAccountKeyField& dest)
				{
					int size = sizeof(CThostFtdcCFMMCTradingAccountKeyField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryCFMMCTradingAccountKey^ ToClass(CThostFtdcQryCFMMCTradingAccountKeyField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryCFMMCTradingAccountKeyField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryCFMMCTradingAccountKey^>(Marshal::PtrToStructure(ptr, CtpQryCFMMCTradingAccountKey::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryCFMMCTradingAccountKey^ source, CThostFtdcQryCFMMCTradingAccountKeyField& dest)
				{
					int size = sizeof(CThostFtdcQryCFMMCTradingAccountKeyField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpBrokerUserOTPParam^ ToClass(CThostFtdcBrokerUserOTPParamField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcBrokerUserOTPParamField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpBrokerUserOTPParam^>(Marshal::PtrToStructure(ptr, CtpBrokerUserOTPParam::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpBrokerUserOTPParam^ source, CThostFtdcBrokerUserOTPParamField& dest)
				{
					int size = sizeof(CThostFtdcBrokerUserOTPParamField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpManualSyncBrokerUserOTP^ ToClass(CThostFtdcManualSyncBrokerUserOTPField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcManualSyncBrokerUserOTPField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpManualSyncBrokerUserOTP^>(Marshal::PtrToStructure(ptr, CtpManualSyncBrokerUserOTP::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpManualSyncBrokerUserOTP^ source, CThostFtdcManualSyncBrokerUserOTPField& dest)
				{
					int size = sizeof(CThostFtdcManualSyncBrokerUserOTPField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpCommRateModel^ ToClass(CThostFtdcCommRateModelField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcCommRateModelField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpCommRateModel^>(Marshal::PtrToStructure(ptr, CtpCommRateModel::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpCommRateModel^ source, CThostFtdcCommRateModelField& dest)
				{
					int size = sizeof(CThostFtdcCommRateModelField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryCommRateModel^ ToClass(CThostFtdcQryCommRateModelField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryCommRateModelField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryCommRateModel^>(Marshal::PtrToStructure(ptr, CtpQryCommRateModel::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryCommRateModel^ source, CThostFtdcQryCommRateModelField& dest)
				{
					int size = sizeof(CThostFtdcQryCommRateModelField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpMarginModel^ ToClass(CThostFtdcMarginModelField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcMarginModelField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpMarginModel^>(Marshal::PtrToStructure(ptr, CtpMarginModel::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpMarginModel^ source, CThostFtdcMarginModelField& dest)
				{
					int size = sizeof(CThostFtdcMarginModelField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryMarginModel^ ToClass(CThostFtdcQryMarginModelField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryMarginModelField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryMarginModel^>(Marshal::PtrToStructure(ptr, CtpQryMarginModel::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryMarginModel^ source, CThostFtdcQryMarginModelField& dest)
				{
					int size = sizeof(CThostFtdcQryMarginModelField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpEWarrantOffset^ ToClass(CThostFtdcEWarrantOffsetField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcEWarrantOffsetField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpEWarrantOffset^>(Marshal::PtrToStructure(ptr, CtpEWarrantOffset::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpEWarrantOffset^ source, CThostFtdcEWarrantOffsetField& dest)
				{
					int size = sizeof(CThostFtdcEWarrantOffsetField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryEWarrantOffset^ ToClass(CThostFtdcQryEWarrantOffsetField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryEWarrantOffsetField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryEWarrantOffset^>(Marshal::PtrToStructure(ptr, CtpQryEWarrantOffset::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryEWarrantOffset^ source, CThostFtdcQryEWarrantOffsetField& dest)
				{
					int size = sizeof(CThostFtdcQryEWarrantOffsetField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryInvestorProductGroupMargin^ ToClass(CThostFtdcQryInvestorProductGroupMarginField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryInvestorProductGroupMarginField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryInvestorProductGroupMargin^>(Marshal::PtrToStructure(ptr, CtpQryInvestorProductGroupMargin::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryInvestorProductGroupMargin^ source, CThostFtdcQryInvestorProductGroupMarginField& dest)
				{
					int size = sizeof(CThostFtdcQryInvestorProductGroupMarginField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpInvestorProductGroupMargin^ ToClass(CThostFtdcInvestorProductGroupMarginField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcInvestorProductGroupMarginField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpInvestorProductGroupMargin^>(Marshal::PtrToStructure(ptr, CtpInvestorProductGroupMargin::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpInvestorProductGroupMargin^ source, CThostFtdcInvestorProductGroupMarginField& dest)
				{
					int size = sizeof(CThostFtdcInvestorProductGroupMarginField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQueryCFMMCTradingAccountToken^ ToClass(CThostFtdcQueryCFMMCTradingAccountTokenField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQueryCFMMCTradingAccountTokenField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQueryCFMMCTradingAccountToken^>(Marshal::PtrToStructure(ptr, CtpQueryCFMMCTradingAccountToken::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQueryCFMMCTradingAccountToken^ source, CThostFtdcQueryCFMMCTradingAccountTokenField& dest)
				{
					int size = sizeof(CThostFtdcQueryCFMMCTradingAccountTokenField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpCFMMCTradingAccountToken^ ToClass(CThostFtdcCFMMCTradingAccountTokenField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcCFMMCTradingAccountTokenField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpCFMMCTradingAccountToken^>(Marshal::PtrToStructure(ptr, CtpCFMMCTradingAccountToken::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpCFMMCTradingAccountToken^ source, CThostFtdcCFMMCTradingAccountTokenField& dest)
				{
					int size = sizeof(CThostFtdcCFMMCTradingAccountTokenField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryProductGroup^ ToClass(CThostFtdcQryProductGroupField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryProductGroupField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryProductGroup^>(Marshal::PtrToStructure(ptr, CtpQryProductGroup::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryProductGroup^ source, CThostFtdcQryProductGroupField& dest)
				{
					int size = sizeof(CThostFtdcQryProductGroupField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpProductGroup^ ToClass(CThostFtdcProductGroupField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcProductGroupField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpProductGroup^>(Marshal::PtrToStructure(ptr, CtpProductGroup::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpProductGroup^ source, CThostFtdcProductGroupField& dest)
				{
					int size = sizeof(CThostFtdcProductGroupField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpReqOpenAccount^ ToClass(CThostFtdcReqOpenAccountField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcReqOpenAccountField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpReqOpenAccount^>(Marshal::PtrToStructure(ptr, CtpReqOpenAccount::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpReqOpenAccount^ source, CThostFtdcReqOpenAccountField& dest)
				{
					int size = sizeof(CThostFtdcReqOpenAccountField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpReqCancelAccount^ ToClass(CThostFtdcReqCancelAccountField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcReqCancelAccountField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpReqCancelAccount^>(Marshal::PtrToStructure(ptr, CtpReqCancelAccount::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpReqCancelAccount^ source, CThostFtdcReqCancelAccountField& dest)
				{
					int size = sizeof(CThostFtdcReqCancelAccountField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpReqChangeAccount^ ToClass(CThostFtdcReqChangeAccountField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcReqChangeAccountField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpReqChangeAccount^>(Marshal::PtrToStructure(ptr, CtpReqChangeAccount::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpReqChangeAccount^ source, CThostFtdcReqChangeAccountField& dest)
				{
					int size = sizeof(CThostFtdcReqChangeAccountField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpReqTransfer^ ToClass(CThostFtdcReqTransferField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcReqTransferField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpReqTransfer^>(Marshal::PtrToStructure(ptr, CtpReqTransfer::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpReqTransfer^ source, CThostFtdcReqTransferField& dest)
				{
					int size = sizeof(CThostFtdcReqTransferField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpRspTransfer^ ToClass(CThostFtdcRspTransferField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcRspTransferField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpRspTransfer^>(Marshal::PtrToStructure(ptr, CtpRspTransfer::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpRspTransfer^ source, CThostFtdcRspTransferField& dest)
				{
					int size = sizeof(CThostFtdcRspTransferField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpReqRepeal^ ToClass(CThostFtdcReqRepealField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcReqRepealField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpReqRepeal^>(Marshal::PtrToStructure(ptr, CtpReqRepeal::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpReqRepeal^ source, CThostFtdcReqRepealField& dest)
				{
					int size = sizeof(CThostFtdcReqRepealField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpRspRepeal^ ToClass(CThostFtdcRspRepealField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcRspRepealField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpRspRepeal^>(Marshal::PtrToStructure(ptr, CtpRspRepeal::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpRspRepeal^ source, CThostFtdcRspRepealField& dest)
				{
					int size = sizeof(CThostFtdcRspRepealField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpReqQueryAccount^ ToClass(CThostFtdcReqQueryAccountField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcReqQueryAccountField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpReqQueryAccount^>(Marshal::PtrToStructure(ptr, CtpReqQueryAccount::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpReqQueryAccount^ source, CThostFtdcReqQueryAccountField& dest)
				{
					int size = sizeof(CThostFtdcReqQueryAccountField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpRspQueryAccount^ ToClass(CThostFtdcRspQueryAccountField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcRspQueryAccountField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpRspQueryAccount^>(Marshal::PtrToStructure(ptr, CtpRspQueryAccount::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpRspQueryAccount^ source, CThostFtdcRspQueryAccountField& dest)
				{
					int size = sizeof(CThostFtdcRspQueryAccountField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpFutureSignIO^ ToClass(CThostFtdcFutureSignIOField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcFutureSignIOField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpFutureSignIO^>(Marshal::PtrToStructure(ptr, CtpFutureSignIO::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpFutureSignIO^ source, CThostFtdcFutureSignIOField& dest)
				{
					int size = sizeof(CThostFtdcFutureSignIOField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpRspFutureSignIn^ ToClass(CThostFtdcRspFutureSignInField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcRspFutureSignInField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpRspFutureSignIn^>(Marshal::PtrToStructure(ptr, CtpRspFutureSignIn::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpRspFutureSignIn^ source, CThostFtdcRspFutureSignInField& dest)
				{
					int size = sizeof(CThostFtdcRspFutureSignInField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpReqFutureSignOut^ ToClass(CThostFtdcReqFutureSignOutField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcReqFutureSignOutField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpReqFutureSignOut^>(Marshal::PtrToStructure(ptr, CtpReqFutureSignOut::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpReqFutureSignOut^ source, CThostFtdcReqFutureSignOutField& dest)
				{
					int size = sizeof(CThostFtdcReqFutureSignOutField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpRspFutureSignOut^ ToClass(CThostFtdcRspFutureSignOutField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcRspFutureSignOutField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpRspFutureSignOut^>(Marshal::PtrToStructure(ptr, CtpRspFutureSignOut::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpRspFutureSignOut^ source, CThostFtdcRspFutureSignOutField& dest)
				{
					int size = sizeof(CThostFtdcRspFutureSignOutField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpReqQueryTradeResultBySerial^ ToClass(CThostFtdcReqQueryTradeResultBySerialField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcReqQueryTradeResultBySerialField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpReqQueryTradeResultBySerial^>(Marshal::PtrToStructure(ptr, CtpReqQueryTradeResultBySerial::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpReqQueryTradeResultBySerial^ source, CThostFtdcReqQueryTradeResultBySerialField& dest)
				{
					int size = sizeof(CThostFtdcReqQueryTradeResultBySerialField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpRspQueryTradeResultBySerial^ ToClass(CThostFtdcRspQueryTradeResultBySerialField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcRspQueryTradeResultBySerialField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpRspQueryTradeResultBySerial^>(Marshal::PtrToStructure(ptr, CtpRspQueryTradeResultBySerial::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpRspQueryTradeResultBySerial^ source, CThostFtdcRspQueryTradeResultBySerialField& dest)
				{
					int size = sizeof(CThostFtdcRspQueryTradeResultBySerialField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpReqDayEndFileReady^ ToClass(CThostFtdcReqDayEndFileReadyField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcReqDayEndFileReadyField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpReqDayEndFileReady^>(Marshal::PtrToStructure(ptr, CtpReqDayEndFileReady::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpReqDayEndFileReady^ source, CThostFtdcReqDayEndFileReadyField& dest)
				{
					int size = sizeof(CThostFtdcReqDayEndFileReadyField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpReturnResult^ ToClass(CThostFtdcReturnResultField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcReturnResultField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpReturnResult^>(Marshal::PtrToStructure(ptr, CtpReturnResult::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpReturnResult^ source, CThostFtdcReturnResultField& dest)
				{
					int size = sizeof(CThostFtdcReturnResultField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpVerifyFuturePassword^ ToClass(CThostFtdcVerifyFuturePasswordField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcVerifyFuturePasswordField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpVerifyFuturePassword^>(Marshal::PtrToStructure(ptr, CtpVerifyFuturePassword::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpVerifyFuturePassword^ source, CThostFtdcVerifyFuturePasswordField& dest)
				{
					int size = sizeof(CThostFtdcVerifyFuturePasswordField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpVerifyCustInfo^ ToClass(CThostFtdcVerifyCustInfoField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcVerifyCustInfoField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpVerifyCustInfo^>(Marshal::PtrToStructure(ptr, CtpVerifyCustInfo::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpVerifyCustInfo^ source, CThostFtdcVerifyCustInfoField& dest)
				{
					int size = sizeof(CThostFtdcVerifyCustInfoField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpVerifyFuturePasswordAndCustInfo^ ToClass(CThostFtdcVerifyFuturePasswordAndCustInfoField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcVerifyFuturePasswordAndCustInfoField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpVerifyFuturePasswordAndCustInfo^>(Marshal::PtrToStructure(ptr, CtpVerifyFuturePasswordAndCustInfo::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpVerifyFuturePasswordAndCustInfo^ source, CThostFtdcVerifyFuturePasswordAndCustInfoField& dest)
				{
					int size = sizeof(CThostFtdcVerifyFuturePasswordAndCustInfoField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpDepositResultInform^ ToClass(CThostFtdcDepositResultInformField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcDepositResultInformField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpDepositResultInform^>(Marshal::PtrToStructure(ptr, CtpDepositResultInform::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpDepositResultInform^ source, CThostFtdcDepositResultInformField& dest)
				{
					int size = sizeof(CThostFtdcDepositResultInformField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpReqSyncKey^ ToClass(CThostFtdcReqSyncKeyField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcReqSyncKeyField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpReqSyncKey^>(Marshal::PtrToStructure(ptr, CtpReqSyncKey::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpReqSyncKey^ source, CThostFtdcReqSyncKeyField& dest)
				{
					int size = sizeof(CThostFtdcReqSyncKeyField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpRspSyncKey^ ToClass(CThostFtdcRspSyncKeyField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcRspSyncKeyField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpRspSyncKey^>(Marshal::PtrToStructure(ptr, CtpRspSyncKey::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpRspSyncKey^ source, CThostFtdcRspSyncKeyField& dest)
				{
					int size = sizeof(CThostFtdcRspSyncKeyField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpNotifyQueryAccount^ ToClass(CThostFtdcNotifyQueryAccountField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcNotifyQueryAccountField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpNotifyQueryAccount^>(Marshal::PtrToStructure(ptr, CtpNotifyQueryAccount::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpNotifyQueryAccount^ source, CThostFtdcNotifyQueryAccountField& dest)
				{
					int size = sizeof(CThostFtdcNotifyQueryAccountField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpTransferSerial^ ToClass(CThostFtdcTransferSerialField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcTransferSerialField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpTransferSerial^>(Marshal::PtrToStructure(ptr, CtpTransferSerial::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpTransferSerial^ source, CThostFtdcTransferSerialField& dest)
				{
					int size = sizeof(CThostFtdcTransferSerialField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryTransferSerial^ ToClass(CThostFtdcQryTransferSerialField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryTransferSerialField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryTransferSerial^>(Marshal::PtrToStructure(ptr, CtpQryTransferSerial::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryTransferSerial^ source, CThostFtdcQryTransferSerialField& dest)
				{
					int size = sizeof(CThostFtdcQryTransferSerialField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpNotifyFutureSignIn^ ToClass(CThostFtdcNotifyFutureSignInField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcNotifyFutureSignInField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpNotifyFutureSignIn^>(Marshal::PtrToStructure(ptr, CtpNotifyFutureSignIn::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpNotifyFutureSignIn^ source, CThostFtdcNotifyFutureSignInField& dest)
				{
					int size = sizeof(CThostFtdcNotifyFutureSignInField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpNotifyFutureSignOut^ ToClass(CThostFtdcNotifyFutureSignOutField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcNotifyFutureSignOutField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpNotifyFutureSignOut^>(Marshal::PtrToStructure(ptr, CtpNotifyFutureSignOut::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpNotifyFutureSignOut^ source, CThostFtdcNotifyFutureSignOutField& dest)
				{
					int size = sizeof(CThostFtdcNotifyFutureSignOutField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpNotifySyncKey^ ToClass(CThostFtdcNotifySyncKeyField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcNotifySyncKeyField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpNotifySyncKey^>(Marshal::PtrToStructure(ptr, CtpNotifySyncKey::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpNotifySyncKey^ source, CThostFtdcNotifySyncKeyField& dest)
				{
					int size = sizeof(CThostFtdcNotifySyncKeyField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryAccountregister^ ToClass(CThostFtdcQryAccountregisterField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryAccountregisterField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryAccountregister^>(Marshal::PtrToStructure(ptr, CtpQryAccountregister::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryAccountregister^ source, CThostFtdcQryAccountregisterField& dest)
				{
					int size = sizeof(CThostFtdcQryAccountregisterField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpAccountregister^ ToClass(CThostFtdcAccountregisterField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcAccountregisterField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpAccountregister^>(Marshal::PtrToStructure(ptr, CtpAccountregister::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpAccountregister^ source, CThostFtdcAccountregisterField& dest)
				{
					int size = sizeof(CThostFtdcAccountregisterField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpOpenAccount^ ToClass(CThostFtdcOpenAccountField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcOpenAccountField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpOpenAccount^>(Marshal::PtrToStructure(ptr, CtpOpenAccount::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpOpenAccount^ source, CThostFtdcOpenAccountField& dest)
				{
					int size = sizeof(CThostFtdcOpenAccountField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpCancelAccount^ ToClass(CThostFtdcCancelAccountField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcCancelAccountField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpCancelAccount^>(Marshal::PtrToStructure(ptr, CtpCancelAccount::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpCancelAccount^ source, CThostFtdcCancelAccountField& dest)
				{
					int size = sizeof(CThostFtdcCancelAccountField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpChangeAccount^ ToClass(CThostFtdcChangeAccountField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcChangeAccountField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpChangeAccount^>(Marshal::PtrToStructure(ptr, CtpChangeAccount::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpChangeAccount^ source, CThostFtdcChangeAccountField& dest)
				{
					int size = sizeof(CThostFtdcChangeAccountField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpSecAgentACIDMap^ ToClass(CThostFtdcSecAgentACIDMapField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcSecAgentACIDMapField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpSecAgentACIDMap^>(Marshal::PtrToStructure(ptr, CtpSecAgentACIDMap::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpSecAgentACIDMap^ source, CThostFtdcSecAgentACIDMapField& dest)
				{
					int size = sizeof(CThostFtdcSecAgentACIDMapField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQrySecAgentACIDMap^ ToClass(CThostFtdcQrySecAgentACIDMapField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQrySecAgentACIDMapField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQrySecAgentACIDMap^>(Marshal::PtrToStructure(ptr, CtpQrySecAgentACIDMap::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQrySecAgentACIDMap^ source, CThostFtdcQrySecAgentACIDMapField& dest)
				{
					int size = sizeof(CThostFtdcQrySecAgentACIDMapField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpUserRightsAssign^ ToClass(CThostFtdcUserRightsAssignField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcUserRightsAssignField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpUserRightsAssign^>(Marshal::PtrToStructure(ptr, CtpUserRightsAssign::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpUserRightsAssign^ source, CThostFtdcUserRightsAssignField& dest)
				{
					int size = sizeof(CThostFtdcUserRightsAssignField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpBrokerUserRightAssign^ ToClass(CThostFtdcBrokerUserRightAssignField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcBrokerUserRightAssignField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpBrokerUserRightAssign^>(Marshal::PtrToStructure(ptr, CtpBrokerUserRightAssign::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpBrokerUserRightAssign^ source, CThostFtdcBrokerUserRightAssignField& dest)
				{
					int size = sizeof(CThostFtdcBrokerUserRightAssignField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpDRTransfer^ ToClass(CThostFtdcDRTransferField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcDRTransferField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpDRTransfer^>(Marshal::PtrToStructure(ptr, CtpDRTransfer::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpDRTransfer^ source, CThostFtdcDRTransferField& dest)
				{
					int size = sizeof(CThostFtdcDRTransferField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpFensUserInfo^ ToClass(CThostFtdcFensUserInfoField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcFensUserInfoField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpFensUserInfo^>(Marshal::PtrToStructure(ptr, CtpFensUserInfo::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpFensUserInfo^ source, CThostFtdcFensUserInfoField& dest)
				{
					int size = sizeof(CThostFtdcFensUserInfoField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpCurrTransferIdentity^ ToClass(CThostFtdcCurrTransferIdentityField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcCurrTransferIdentityField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpCurrTransferIdentity^>(Marshal::PtrToStructure(ptr, CtpCurrTransferIdentity::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpCurrTransferIdentity^ source, CThostFtdcCurrTransferIdentityField& dest)
				{
					int size = sizeof(CThostFtdcCurrTransferIdentityField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpLoginForbiddenUser^ ToClass(CThostFtdcLoginForbiddenUserField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcLoginForbiddenUserField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpLoginForbiddenUser^>(Marshal::PtrToStructure(ptr, CtpLoginForbiddenUser::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpLoginForbiddenUser^ source, CThostFtdcLoginForbiddenUserField& dest)
				{
					int size = sizeof(CThostFtdcLoginForbiddenUserField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpQryLoginForbiddenUser^ ToClass(CThostFtdcQryLoginForbiddenUserField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcQryLoginForbiddenUserField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpQryLoginForbiddenUser^>(Marshal::PtrToStructure(ptr, CtpQryLoginForbiddenUser::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpQryLoginForbiddenUser^ source, CThostFtdcQryLoginForbiddenUserField& dest)
				{
					int size = sizeof(CThostFtdcQryLoginForbiddenUserField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpMulticastGroupInfo^ ToClass(CThostFtdcMulticastGroupInfoField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcMulticastGroupInfoField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpMulticastGroupInfo^>(Marshal::PtrToStructure(ptr, CtpMulticastGroupInfo::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpMulticastGroupInfo^ source, CThostFtdcMulticastGroupInfoField& dest)
				{
					int size = sizeof(CThostFtdcMulticastGroupInfoField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

				static CtpTradingAccountReserve^ ToClass(CThostFtdcTradingAccountReserveField* source)
				{
					if (source != NULL) {
						int size = sizeof(CThostFtdcTradingAccountReserveField);
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							memcpy(ptr.ToPointer(), source, size);
							return dynamic_cast<CtpTradingAccountReserve^>(Marshal::PtrToStructure(ptr, CtpTradingAccountReserve::typeid));
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					return nullptr;
				}

				static void ToStruct(CtpTradingAccountReserve^ source, CThostFtdcTradingAccountReserveField& dest)
				{
					int size = sizeof(CThostFtdcTradingAccountReserveField);
					if (source != nullptr) {
						auto ptr = Marshal::AllocHGlobal(size);
						try
						{
							Marshal::StructureToPtr(source, ptr, false);
							memcpy(&dest, ptr.ToPointer(), size);
						}
						finally {
							Marshal::FreeHGlobal(ptr);
						}
					}
					else {
						memset(&dest, 0, size);
					}
				}

			};
		};
	};
}