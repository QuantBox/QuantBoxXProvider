// stdafx.cpp : source file that includes just the standard includes
// CtpApi4Clr.pch will be the pre-compiled header
// stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"
#include "CtpConvert.hpp"
#include "CtpMdApi.hpp"
#include "CtpTraderApi.hpp"

#ifndef _WIN64
#pragma comment(lib, "..\\external-bin\\ctp630\\x86\\thostmduserapi.lib")
#pragma comment(lib, "..\\external-bin\\ctp630\\x86\\thosttraderapi.lib")
#else
#pragma comment(lib, "..\\external-bin\\ctp630\\x64\\thostmduserapi.lib")
#pragma comment(lib, "..\\external-bin\\ctp630\\x64\\thosttraderapi.lib")
#endif // !_WIN64
