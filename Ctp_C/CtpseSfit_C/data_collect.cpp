#include "stdafx.h"
#include <DataCollect.h>


#define DLL __declspec(dllexport)
#ifdef __cplusplus
extern "C"
{
#endif
	///获取AES加密和RSA加密的终端信息 
	///@pSystemInfo 出参 空间需要调用者自己分配 至少270个字节
	///@nLen 出参 获取到的采集信息的长度
	///采集信息内可能含有‘\0’ 建议调用者使用内存复制
DLL int CALLBACK CtpGetSystemInfo(char* pSystemInfo,int& nLen)
    {
		return CTP_GetSystemInfo(pSystemInfo, nLen);
    }
#ifdef __cplusplus
}
#endif