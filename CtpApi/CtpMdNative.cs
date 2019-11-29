using System;
using System.Runtime.InteropServices;

namespace QuantBox.Sfit.Api
{
    public static class CtpMdNative
    {
        [DllImport("sfit_ctp_x64.dll",
            CallingConvention = CallingConvention.StdCall,
            CharSet = CharSet.Ansi,
            EntryPoint = "Md_Create")]
        public static extern IntPtr Create(string path);
        [DllImport("sfit_ctp_x64.dll",
            CallingConvention = CallingConvention.StdCall,
            CharSet = CharSet.Ansi,
            EntryPoint = "Md_Init")]
        public static extern void Init(IntPtr instance);
        [DllImport("sfit_ctp_x64.dll",
            CallingConvention = CallingConvention.StdCall,
            CharSet = CharSet.Ansi,
            EntryPoint = "Md_Release")]
        public static extern void Release(IntPtr instance);
        [DllImport("sfit_ctp_x64.dll",
            CallingConvention = CallingConvention.StdCall,
            CharSet = CharSet.Ansi,
            EntryPoint = "Md_Join")]
        public static extern int Join(IntPtr instance);
        [DllImport("sfit_ctp_x64.dll",
            CallingConvention = CallingConvention.StdCall,
            CharSet = CharSet.Ansi,
            EntryPoint = "Md_GetTradingDay")]
        public static extern string GetTradingDay(IntPtr instance);
        [DllImport("sfit_ctp_x64.dll",
            CallingConvention = CallingConvention.StdCall,
            CharSet = CharSet.Ansi,
            EntryPoint = "Md_RegisterFront")]
        public static extern void RegisterFront(IntPtr instance, string frontAddress);
        [DllImport("sfit_ctp_x64.dll",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Md_RegisterNameServer")]
        public static extern void RegisterNameServer(IntPtr instance, string nsAddress);
        [DllImport("sfit_ctp_x64.dll",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Md_RegisterFensUserInfo")]
        public static extern void RegisterFensUserInfo(IntPtr instance, CtpFensUserInfo fensUserInfo);
        [DllImport("sfit_ctp_x64.dll",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Md_SubscribeMarketData")]
        public static extern int SubscribeMarketData(IntPtr instance,string[] instrumentID,int count);
        [DllImport("sfit_ctp_x64.dll",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Md_UnSubscribeMarketData")]
        public static extern int UnSubscribeMarketData(IntPtr instance,string[] instrumentID,int count);
        [DllImport("sfit_ctp_x64.dll",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Md_SubscribeForQuoteRsp")]
        public static extern int SubscribeForQuoteRsp(IntPtr instance,string[] instrumentID,int count);
        [DllImport("sfit_ctp_x64.dll",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Md_UnSubscribeForQuoteRsp")]
        public static extern int UnSubscribeForQuoteRsp(IntPtr instance,string[] instrumentID,int count);
        [DllImport("sfit_ctp_x64.dll",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Md_ReqUserLogin")]
        public static extern int ReqUserLogin(IntPtr instance,CtpReqUserLogin reqUserLoginField,int requestId);
        [DllImport("sfit_ctp_x64.dll",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Md_ReqUserLogout")]
        public static extern int ReqUserLogout(IntPtr instance,CtpUserLogout userLogout,int requestId);
  
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnFrontConnected();
        [DllImport("sfit_ctp_x64.dll",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Md_Set_OnFrontConnected")]
        public static extern void SetOnFrontConnected(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnFrontConnected callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnFrontDisconnected(int reason);
        [DllImport("sfit_ctp_x64.dll",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Md_Set_OnFrontDisconnected")]
        public static extern void SetOnFrontDisconnected(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnFrontDisconnected callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnHeartBeatWarning(int timeLapse);
        [DllImport("sfit_ctp_x64.dll",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Md_Set_OnHeartBeatWarning")]
        public static extern void SetOnHeartBeatWarning(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnHeartBeatWarning callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspUserLogin(CtpRspUserLogin rspUserLogin,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctp_x64.dll",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Md_Set_OnRspUserLogin")]
        public static extern void SetOnRspUserLogin(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspUserLogin callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspUserLogout(CtpUserLogout userLogout,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctp_x64.dll",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Md_Set_OnRspUserLogout")]
        public static extern void SetOnRspUserLogout(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspUserLogout callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspError(CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctp_x64.dll",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Md_Set_OnRspError")]
        public static extern void SetOnRspError(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspError callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspSubMarketData(CtpSpecificInstrument specificInstrument,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctp_x64.dll",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Md_Set_OnRspSubMarketData")]
        public static extern void SetOnRspSubMarketData(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspSubMarketData callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspUnSubMarketData(CtpSpecificInstrument specificInstrument,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctp_x64.dll",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Md_Set_OnRspUnSubMarketData")]
        public static extern void SetOnRspUnSubMarketData(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspUnSubMarketData callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspSubForQuoteRsp(CtpSpecificInstrument specificInstrument,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctp_x64.dll",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Md_Set_OnRspSubForQuoteRsp")]
        public static extern void SetOnRspSubForQuoteRsp(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspSubForQuoteRsp callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRspUnSubForQuoteRsp(CtpSpecificInstrument specificInstrument,CtpRspInfo rspInfo,int requestId,bool isLast);
        [DllImport("sfit_ctp_x64.dll",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Md_Set_OnRspUnSubForQuoteRsp")]
        public static extern void SetOnRspUnSubForQuoteRsp(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRspUnSubForQuoteRsp callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRtnDepthMarketData(CtpDepthMarketData depthMarketData);
        [DllImport("sfit_ctp_x64.dll",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Md_Set_OnRtnDepthMarketData")]
        public static extern void SetOnRtnDepthMarketData(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRtnDepthMarketData callback);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void OnRtnForQuoteRsp(CtpForQuoteRsp forQuoteRsp);
        [DllImport("sfit_ctp_x64.dll",
            CallingConvention = CallingConvention.StdCall, 
            CharSet = CharSet.Ansi,
            EntryPoint = "Md_Set_OnRtnForQuoteRsp")]
        public static extern void SetOnRtnForQuoteRsp(IntPtr instance, [MarshalAs(UnmanagedType.FunctionPtr)]OnRtnForQuoteRsp callback);
        
    }
}