using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace QuantBox.Sfit.Api
{
    ///<summary>
    ///TFtdcTraderIDType是一个交易所交易员代码类型
    ///</summary>
    /// TThostFtdcTraderIDType 是基础类型

    ///<summary>
    ///TFtdcInvestorIDType是一个投资者代码类型
    ///</summary>
    /// TThostFtdcInvestorIDType 是基础类型

    ///<summary>
    ///TFtdcBrokerIDType是一个经纪公司代码类型
    ///</summary>
    /// TThostFtdcBrokerIDType 是基础类型

    ///<summary>
    ///TFtdcBrokerAbbrType是一个经纪公司简称类型
    ///</summary>
    /// TThostFtdcBrokerAbbrType 是基础类型

    ///<summary>
    ///TFtdcBrokerNameType是一个经纪公司名称类型
    ///</summary>
    /// TThostFtdcBrokerNameType 是基础类型

    ///<summary>
    ///TFtdcExchangeInstIDType是一个合约在交易所的代码类型
    ///</summary>
    /// TThostFtdcExchangeInstIDType 是基础类型

    ///<summary>
    ///TFtdcOrderRefType是一个报单引用类型
    ///</summary>
    /// TThostFtdcOrderRefType 是基础类型

    ///<summary>
    ///TFtdcParticipantIDType是一个会员代码类型
    ///</summary>
    /// TThostFtdcParticipantIDType 是基础类型

    ///<summary>
    ///TFtdcUserIDType是一个用户代码类型
    ///</summary>
    /// TThostFtdcUserIDType 是基础类型

    ///<summary>
    ///TFtdcPasswordType是一个密码类型
    ///</summary>
    /// TThostFtdcPasswordType 是基础类型

    ///<summary>
    ///TFtdcClientIDType是一个交易编码类型
    ///</summary>
    /// TThostFtdcClientIDType 是基础类型

    ///<summary>
    ///TFtdcInstrumentIDType是一个合约代码类型
    ///</summary>
    /// TThostFtdcInstrumentIDType 是基础类型

    ///<summary>
    ///TFtdcMarketIDType是一个市场代码类型
    ///</summary>
    /// TThostFtdcMarketIDType 是基础类型

    ///<summary>
    ///TFtdcProductNameType是一个产品名称类型
    ///</summary>
    /// TThostFtdcProductNameType 是基础类型

    ///<summary>
    ///TFtdcExchangeIDType是一个交易所代码类型
    ///</summary>
    /// TThostFtdcExchangeIDType 是基础类型

    ///<summary>
    ///TFtdcExchangeNameType是一个交易所名称类型
    ///</summary>
    /// TThostFtdcExchangeNameType 是基础类型

    ///<summary>
    ///TFtdcExchangeAbbrType是一个交易所简称类型
    ///</summary>
    /// TThostFtdcExchangeAbbrType 是基础类型

    ///<summary>
    ///TFtdcExchangeFlagType是一个交易所标志类型
    ///</summary>
    /// TThostFtdcExchangeFlagType 是基础类型

    ///<summary>
    ///TFtdcMacAddressType是一个Mac地址类型
    ///</summary>
    /// TThostFtdcMacAddressType 是基础类型

    ///<summary>
    ///TFtdcSystemIDType是一个系统编号类型
    ///</summary>
    /// TThostFtdcSystemIDType 是基础类型

    ///<summary>
    ///TFtdcExchangePropertyType是一个交易所属性类型
    ///</summary>
    public static class CtpExchangePropertyType
    {
        ///<summary>
        ///正常
        ///</summary>
        public const byte Normal = (byte)'0';
        ///<summary>
        ///根据成交生成报单
        ///</summary>
        public const byte GenOrderByTrade = (byte)'1';
    };

    ///<summary>
    ///TFtdcDateType是一个日期类型
    ///</summary>
    /// TThostFtdcDateType 是基础类型

    ///<summary>
    ///TFtdcTimeType是一个时间类型
    ///</summary>
    /// TThostFtdcTimeType 是基础类型

    ///<summary>
    ///TFtdcLongTimeType是一个长时间类型
    ///</summary>
    /// TThostFtdcLongTimeType 是基础类型

    ///<summary>
    ///TFtdcInstrumentNameType是一个合约名称类型
    ///</summary>
    /// TThostFtdcInstrumentNameType 是基础类型

    ///<summary>
    ///TFtdcSettlementGroupIDType是一个结算组代码类型
    ///</summary>
    /// TThostFtdcSettlementGroupIDType 是基础类型

    ///<summary>
    ///TFtdcOrderSysIDType是一个报单编号类型
    ///</summary>
    /// TThostFtdcOrderSysIDType 是基础类型

    ///<summary>
    ///TFtdcTradeIDType是一个成交编号类型
    ///</summary>
    /// TThostFtdcTradeIDType 是基础类型

    ///<summary>
    ///TFtdcCommandTypeType是一个DB命令类型类型
    ///</summary>
    /// TThostFtdcCommandTypeType 是基础类型

    ///<summary>
    ///TFtdcIPAddressType是一个IP地址类型
    ///</summary>
    /// TThostFtdcIPAddressType 是基础类型

    ///<summary>
    ///TFtdcIPPortType是一个IP端口类型
    ///</summary>
    /// TThostFtdcIPPortType 是基础类型

    ///<summary>
    ///TFtdcProductInfoType是一个产品信息类型
    ///</summary>
    /// TThostFtdcProductInfoType 是基础类型

    ///<summary>
    ///TFtdcProtocolInfoType是一个协议信息类型
    ///</summary>
    /// TThostFtdcProtocolInfoType 是基础类型

    ///<summary>
    ///TFtdcBusinessUnitType是一个业务单元类型
    ///</summary>
    /// TThostFtdcBusinessUnitType 是基础类型

    ///<summary>
    ///TFtdcDepositSeqNoType是一个出入金流水号类型
    ///</summary>
    /// TThostFtdcDepositSeqNoType 是基础类型

    ///<summary>
    ///TFtdcIdentifiedCardNoType是一个证件号码类型
    ///</summary>
    /// TThostFtdcIdentifiedCardNoType 是基础类型

    ///<summary>
    ///TFtdcIdCardTypeType是一个证件类型类型
    ///</summary>
    public static class CtpIdCardTypeType
    {
        ///<summary>
        ///组织机构代码
        ///</summary>
        public const byte EID = (byte)'0';
        ///<summary>
        ///中国公民身份证
        ///</summary>
        public const byte IDCard = (byte)'1';
        ///<summary>
        ///军官证
        ///</summary>
        public const byte OfficerIDCard = (byte)'2';
        ///<summary>
        ///警官证
        ///</summary>
        public const byte PoliceIDCard = (byte)'3';
        ///<summary>
        ///士兵证
        ///</summary>
        public const byte SoldierIDCard = (byte)'4';
        ///<summary>
        ///户口簿
        ///</summary>
        public const byte HouseholdRegister = (byte)'5';
        ///<summary>
        ///护照
        ///</summary>
        public const byte Passport = (byte)'6';
        ///<summary>
        ///台胞证
        ///</summary>
        public const byte TaiwanCompatriotIDCard = (byte)'7';
        ///<summary>
        ///回乡证
        ///</summary>
        public const byte HomeComingCard = (byte)'8';
        ///<summary>
        ///营业执照号
        ///</summary>
        public const byte LicenseNo = (byte)'9';
        ///<summary>
        ///税务登记号/当地纳税ID
        ///</summary>
        public const byte TaxNo = (byte)'A';
        ///<summary>
        ///港澳居民来往内地通行证
        ///</summary>
        public const byte HMMainlandTravelPermit = (byte)'B';
        ///<summary>
        ///台湾居民来往大陆通行证
        ///</summary>
        public const byte TwMainlandTravelPermit = (byte)'C';
        ///<summary>
        ///驾照
        ///</summary>
        public const byte DrivingLicense = (byte)'D';
        ///<summary>
        ///当地社保ID
        ///</summary>
        public const byte SocialID = (byte)'F';
        ///<summary>
        ///当地身份证
        ///</summary>
        public const byte LocalID = (byte)'G';
        ///<summary>
        ///商业登记证
        ///</summary>
        public const byte BusinessRegistration = (byte)'H';
        ///<summary>
        ///港澳永久性居民身份证
        ///</summary>
        public const byte HKMCIDCard = (byte)'I';
        ///<summary>
        ///人行开户许可证
        ///</summary>
        public const byte AccountsPermits = (byte)'J';
        ///<summary>
        ///其他证件
        ///</summary>
        public const byte OtherCard = (byte)'x';
    };

    ///<summary>
    ///TFtdcOrderLocalIDType是一个本地报单编号类型
    ///</summary>
    /// TThostFtdcOrderLocalIDType 是基础类型

    ///<summary>
    ///TFtdcUserNameType是一个用户名称类型
    ///</summary>
    /// TThostFtdcUserNameType 是基础类型

    ///<summary>
    ///TFtdcPartyNameType是一个参与人名称类型
    ///</summary>
    /// TThostFtdcPartyNameType 是基础类型

    ///<summary>
    ///TFtdcErrorMsgType是一个错误信息类型
    ///</summary>
    /// TThostFtdcErrorMsgType 是基础类型

    ///<summary>
    ///TFtdcFieldNameType是一个字段名类型
    ///</summary>
    /// TThostFtdcFieldNameType 是基础类型

    ///<summary>
    ///TFtdcFieldContentType是一个字段内容类型
    ///</summary>
    /// TThostFtdcFieldContentType 是基础类型

    ///<summary>
    ///TFtdcSystemNameType是一个系统名称类型
    ///</summary>
    /// TThostFtdcSystemNameType 是基础类型

    ///<summary>
    ///TFtdcContentType是一个消息正文类型
    ///</summary>
    /// TThostFtdcContentType 是基础类型

    ///<summary>
    ///TFtdcInvestorRangeType是一个投资者范围类型
    ///</summary>
    public static class CtpInvestorRangeType
    {
        ///<summary>
        ///所有
        ///</summary>
        public const byte All = (byte)'1';
        ///<summary>
        ///投资者组
        ///</summary>
        public const byte Group = (byte)'2';
        ///<summary>
        ///单一投资者
        ///</summary>
        public const byte Single = (byte)'3';
    };

    ///<summary>
    ///TFtdcDepartmentRangeType是一个投资者范围类型
    ///</summary>
    /// TThostFtdcDepartmentRangeType 未被使用

    ///<summary>
    ///TFtdcDataSyncStatusType是一个数据同步状态类型
    ///</summary>
    public static class CtpDataSyncStatusType
    {
        ///<summary>
        ///未同步
        ///</summary>
        public const byte Asynchronous = (byte)'1';
        ///<summary>
        ///同步中
        ///</summary>
        public const byte Synchronizing = (byte)'2';
        ///<summary>
        ///已同步
        ///</summary>
        public const byte Synchronized = (byte)'3';
    };

    ///<summary>
    ///TFtdcBrokerDataSyncStatusType是一个经纪公司数据同步状态类型
    ///</summary>
    /// TThostFtdcBrokerDataSyncStatusType 未被使用

    ///<summary>
    ///TFtdcExchangeConnectStatusType是一个交易所连接状态类型
    ///</summary>
    /// TThostFtdcExchangeConnectStatusType 未被使用

    ///<summary>
    ///TFtdcTraderConnectStatusType是一个交易所交易员连接状态类型
    ///</summary>
    public static class CtpTraderConnectStatusType
    {
        ///<summary>
        ///没有任何连接
        ///</summary>
        public const byte NotConnected = (byte)'1';
        ///<summary>
        ///已经连接
        ///</summary>
        public const byte Connected = (byte)'2';
        ///<summary>
        ///已经发出合约查询请求
        ///</summary>
        public const byte QryInstrumentSent = (byte)'3';
        ///<summary>
        ///订阅私有流
        ///</summary>
        public const byte SubPrivateFlow = (byte)'4';
    };

    ///<summary>
    ///TFtdcFunctionCodeType是一个功能代码类型
    ///</summary>
    public static class CtpFunctionCodeType
    {
        ///<summary>
        ///数据异步化
        ///</summary>
        public const byte DataAsync = (byte)'1';
        ///<summary>
        ///强制用户登出
        ///</summary>
        public const byte ForceUserLogout = (byte)'2';
        ///<summary>
        ///变更管理用户口令
        ///</summary>
        public const byte UserPasswordUpdate = (byte)'3';
        ///<summary>
        ///变更经纪公司口令
        ///</summary>
        public const byte BrokerPasswordUpdate = (byte)'4';
        ///<summary>
        ///变更投资者口令
        ///</summary>
        public const byte InvestorPasswordUpdate = (byte)'5';
        ///<summary>
        ///报单插入
        ///</summary>
        public const byte OrderInsert = (byte)'6';
        ///<summary>
        ///报单操作
        ///</summary>
        public const byte OrderAction = (byte)'7';
        ///<summary>
        ///同步系统数据
        ///</summary>
        public const byte SyncSystemData = (byte)'8';
        ///<summary>
        ///同步经纪公司数据
        ///</summary>
        public const byte SyncBrokerData = (byte)'9';
        ///<summary>
        ///批量同步经纪公司数据
        ///</summary>
        public const byte BachSyncBrokerData = (byte)'A';
        ///<summary>
        ///超级查询
        ///</summary>
        public const byte SuperQuery = (byte)'B';
        ///<summary>
        ///预埋报单插入
        ///</summary>
        public const byte ParkedOrderInsert = (byte)'C';
        ///<summary>
        ///预埋报单操作
        ///</summary>
        public const byte ParkedOrderAction = (byte)'D';
        ///<summary>
        ///同步动态令牌
        ///</summary>
        public const byte SyncOTP = (byte)'E';
        ///<summary>
        ///删除未知单
        ///</summary>
        public const byte DeleteOrder = (byte)'F';
    };

    ///<summary>
    ///TFtdcBrokerFunctionCodeType是一个经纪公司功能代码类型
    ///</summary>
    public static class CtpBrokerFunctionCodeType
    {
        ///<summary>
        ///强制用户登出
        ///</summary>
        public const byte ForceUserLogout = (byte)'1';
        ///<summary>
        ///变更用户口令
        ///</summary>
        public const byte UserPasswordUpdate = (byte)'2';
        ///<summary>
        ///同步经纪公司数据
        ///</summary>
        public const byte SyncBrokerData = (byte)'3';
        ///<summary>
        ///批量同步经纪公司数据
        ///</summary>
        public const byte BachSyncBrokerData = (byte)'4';
        ///<summary>
        ///报单插入
        ///</summary>
        public const byte OrderInsert = (byte)'5';
        ///<summary>
        ///报单操作
        ///</summary>
        public const byte OrderAction = (byte)'6';
        ///<summary>
        ///全部查询
        ///</summary>
        public const byte AllQuery = (byte)'7';
        ///<summary>
        ///系统功能：登入/登出/修改密码等
        ///</summary>
        public const byte log = (byte)'a';
        ///<summary>
        ///基本查询：查询基础数据，如合约，交易所等常量
        ///</summary>
        public const byte BaseQry = (byte)'b';
        ///<summary>
        ///交易查询：如查成交，委托
        ///</summary>
        public const byte TradeQry = (byte)'c';
        ///<summary>
        ///交易功能：报单，撤单
        ///</summary>
        public const byte Trade = (byte)'d';
        ///<summary>
        ///银期转账
        ///</summary>
        public const byte Virement = (byte)'e';
        ///<summary>
        ///风险监控
        ///</summary>
        public const byte Risk = (byte)'f';
        ///<summary>
        ///查询/管理：查询会话，踢人等
        ///</summary>
        public const byte Session = (byte)'g';
        ///<summary>
        ///风控通知控制
        ///</summary>
        public const byte RiskNoticeCtl = (byte)'h';
        ///<summary>
        ///风控通知发送
        ///</summary>
        public const byte RiskNotice = (byte)'i';
        ///<summary>
        ///察看经纪公司资金权限
        ///</summary>
        public const byte BrokerDeposit = (byte)'j';
        ///<summary>
        ///资金查询
        ///</summary>
        public const byte QueryFund = (byte)'k';
        ///<summary>
        ///报单查询
        ///</summary>
        public const byte QueryOrder = (byte)'l';
        ///<summary>
        ///成交查询
        ///</summary>
        public const byte QueryTrade = (byte)'m';
        ///<summary>
        ///持仓查询
        ///</summary>
        public const byte QueryPosition = (byte)'n';
        ///<summary>
        ///行情查询
        ///</summary>
        public const byte QueryMarketData = (byte)'o';
        ///<summary>
        ///用户事件查询
        ///</summary>
        public const byte QueryUserEvent = (byte)'p';
        ///<summary>
        ///风险通知查询
        ///</summary>
        public const byte QueryRiskNotify = (byte)'q';
        ///<summary>
        ///出入金查询
        ///</summary>
        public const byte QueryFundChange = (byte)'r';
        ///<summary>
        ///投资者信息查询
        ///</summary>
        public const byte QueryInvestor = (byte)'s';
        ///<summary>
        ///交易编码查询
        ///</summary>
        public const byte QueryTradingCode = (byte)'t';
        ///<summary>
        ///强平
        ///</summary>
        public const byte ForceClose = (byte)'u';
        ///<summary>
        ///压力测试
        ///</summary>
        public const byte PressTest = (byte)'v';
        ///<summary>
        ///权益反算
        ///</summary>
        public const byte RemainCalc = (byte)'w';
        ///<summary>
        ///净持仓保证金指标
        ///</summary>
        public const byte NetPositionInd = (byte)'x';
        ///<summary>
        ///风险预算
        ///</summary>
        public const byte RiskPredict = (byte)'y';
        ///<summary>
        ///数据导出
        ///</summary>
        public const byte DataExport = (byte)'z';
        ///<summary>
        ///风控指标设置
        ///</summary>
        public const byte RiskTargetSetup = (byte)'A';
        ///<summary>
        ///行情预警
        ///</summary>
        public const byte MarketDataWarn = (byte)'B';
        ///<summary>
        ///业务通知查询
        ///</summary>
        public const byte QryBizNotice = (byte)'C';
        ///<summary>
        ///业务通知模板设置
        ///</summary>
        public const byte CfgBizNotice = (byte)'D';
        ///<summary>
        ///同步动态令牌
        ///</summary>
        public const byte SyncOTP = (byte)'E';
        ///<summary>
        ///发送业务通知
        ///</summary>
        public const byte SendBizNotice = (byte)'F';
        ///<summary>
        ///风险级别标准设置
        ///</summary>
        public const byte CfgRiskLevelStd = (byte)'G';
        ///<summary>
        ///交易终端应急功能
        ///</summary>
        public const byte TbCommand = (byte)'H';
        ///<summary>
        ///删除未知单
        ///</summary>
        public const byte DeleteOrder = (byte)'J';
        ///<summary>
        ///预埋报单插入
        ///</summary>
        public const byte ParkedOrderInsert = (byte)'K';
        ///<summary>
        ///预埋报单操作
        ///</summary>
        public const byte ParkedOrderAction = (byte)'L';
    };

    ///<summary>
    ///TFtdcOrderActionStatusType是一个报单操作状态类型
    ///</summary>
    public static class CtpOrderActionStatusType
    {
        ///<summary>
        ///已经提交
        ///</summary>
        public const byte Submitted = (byte)'a';
        ///<summary>
        ///已经接受
        ///</summary>
        public const byte Accepted = (byte)'b';
        ///<summary>
        ///已经被拒绝
        ///</summary>
        public const byte Rejected = (byte)'c';
    };

    ///<summary>
    ///TFtdcOrderStatusType是一个报单状态类型
    ///</summary>
    public static class CtpOrderStatusType
    {
        ///<summary>
        ///全部成交
        ///</summary>
        public const byte AllTraded = (byte)'0';
        ///<summary>
        ///部分成交还在队列中
        ///</summary>
        public const byte PartTradedQueueing = (byte)'1';
        ///<summary>
        ///部分成交不在队列中
        ///</summary>
        public const byte PartTradedNotQueueing = (byte)'2';
        ///<summary>
        ///未成交还在队列中
        ///</summary>
        public const byte NoTradeQueueing = (byte)'3';
        ///<summary>
        ///未成交不在队列中
        ///</summary>
        public const byte NoTradeNotQueueing = (byte)'4';
        ///<summary>
        ///撤单
        ///</summary>
        public const byte Canceled = (byte)'5';
        ///<summary>
        ///未知
        ///</summary>
        public const byte Unknown = (byte)'a';
        ///<summary>
        ///尚未触发
        ///</summary>
        public const byte NotTouched = (byte)'b';
        ///<summary>
        ///已触发
        ///</summary>
        public const byte Touched = (byte)'c';
    };

    ///<summary>
    ///TFtdcOrderSubmitStatusType是一个报单提交状态类型
    ///</summary>
    public static class CtpOrderSubmitStatusType
    {
        ///<summary>
        ///已经提交
        ///</summary>
        public const byte InsertSubmitted = (byte)'0';
        ///<summary>
        ///撤单已经提交
        ///</summary>
        public const byte CancelSubmitted = (byte)'1';
        ///<summary>
        ///修改已经提交
        ///</summary>
        public const byte ModifySubmitted = (byte)'2';
        ///<summary>
        ///已经接受
        ///</summary>
        public const byte Accepted = (byte)'3';
        ///<summary>
        ///报单已经被拒绝
        ///</summary>
        public const byte InsertRejected = (byte)'4';
        ///<summary>
        ///撤单已经被拒绝
        ///</summary>
        public const byte CancelRejected = (byte)'5';
        ///<summary>
        ///改单已经被拒绝
        ///</summary>
        public const byte ModifyRejected = (byte)'6';
    };

    ///<summary>
    ///TFtdcPositionDateType是一个持仓日期类型
    ///</summary>
    public static class CtpPositionDateType
    {
        ///<summary>
        ///今日持仓
        ///</summary>
        public const byte Today = (byte)'1';
        ///<summary>
        ///历史持仓
        ///</summary>
        public const byte History = (byte)'2';
    };

    ///<summary>
    ///TFtdcPositionDateTypeType是一个持仓日期类型类型
    ///</summary>
    public static class CtpPositionDateTypeType
    {
        ///<summary>
        ///使用历史持仓
        ///</summary>
        public const byte UseHistory = (byte)'1';
        ///<summary>
        ///不使用历史持仓
        ///</summary>
        public const byte NoUseHistory = (byte)'2';
    };

    ///<summary>
    ///TFtdcTradingRoleType是一个交易角色类型
    ///</summary>
    public static class CtpTradingRoleType
    {
        ///<summary>
        ///代理
        ///</summary>
        public const byte Broker = (byte)'1';
        ///<summary>
        ///自营
        ///</summary>
        public const byte Host = (byte)'2';
        ///<summary>
        ///做市商
        ///</summary>
        public const byte Maker = (byte)'3';
    };

    ///<summary>
    ///TFtdcProductClassType是一个产品类型类型
    ///</summary>
    public static class CtpProductClassType
    {
        ///<summary>
        ///期货
        ///</summary>
        public const byte Futures = (byte)'1';
        ///<summary>
        ///期货期权
        ///</summary>
        public const byte Options = (byte)'2';
        ///<summary>
        ///组合
        ///</summary>
        public const byte Combination = (byte)'3';
        ///<summary>
        ///即期
        ///</summary>
        public const byte Spot = (byte)'4';
        ///<summary>
        ///期转现
        ///</summary>
        public const byte EFP = (byte)'5';
        ///<summary>
        ///现货期权
        ///</summary>
        public const byte SpotOption = (byte)'6';
    };

    ///<summary>
    ///TFtdcInstLifePhaseType是一个合约生命周期状态类型
    ///</summary>
    public static class CtpInstLifePhaseType
    {
        ///<summary>
        ///未上市
        ///</summary>
        public const byte NotStart = (byte)'0';
        ///<summary>
        ///上市
        ///</summary>
        public const byte Started = (byte)'1';
        ///<summary>
        ///停牌
        ///</summary>
        public const byte Pause = (byte)'2';
        ///<summary>
        ///到期
        ///</summary>
        public const byte Expired = (byte)'3';
    };

    ///<summary>
    ///TFtdcDirectionType是一个买卖方向类型
    ///</summary>
    public static class CtpDirectionType
    {
        ///<summary>
        ///买
        ///</summary>
        public const byte Buy = (byte)'0';
        ///<summary>
        ///卖
        ///</summary>
        public const byte Sell = (byte)'1';
    };

    ///<summary>
    ///TFtdcPositionTypeType是一个持仓类型类型
    ///</summary>
    public static class CtpPositionTypeType
    {
        ///<summary>
        ///净持仓
        ///</summary>
        public const byte Net = (byte)'1';
        ///<summary>
        ///综合持仓
        ///</summary>
        public const byte Gross = (byte)'2';
    };

    ///<summary>
    ///TFtdcPosiDirectionType是一个持仓多空方向类型
    ///</summary>
    public static class CtpPosiDirectionType
    {
        ///<summary>
        ///净
        ///</summary>
        public const byte Net = (byte)'1';
        ///<summary>
        ///多头
        ///</summary>
        public const byte Long = (byte)'2';
        ///<summary>
        ///空头
        ///</summary>
        public const byte Short = (byte)'3';
    };

    ///<summary>
    ///TFtdcSysSettlementStatusType是一个系统结算状态类型
    ///</summary>
    /// TThostFtdcSysSettlementStatusType 未被使用

    ///<summary>
    ///TFtdcRatioAttrType是一个费率属性类型
    ///</summary>
    /// TThostFtdcRatioAttrType 未被使用

    ///<summary>
    ///TFtdcHedgeFlagType是一个投机套保标志类型
    ///</summary>
    public static class CtpHedgeFlagType
    {
        ///<summary>
        ///投机
        ///</summary>
        public const byte Speculation = (byte)'1';
        ///<summary>
        ///套利
        ///</summary>
        public const byte Arbitrage = (byte)'2';
        ///<summary>
        ///套保
        ///</summary>
        public const byte Hedge = (byte)'3';
    };

    ///<summary>
    ///TFtdcBillHedgeFlagType是一个投机套保标志类型
    ///</summary>
    /// TThostFtdcBillHedgeFlagType 未被使用

    ///<summary>
    ///TFtdcClientIDTypeType是一个交易编码类型类型
    ///</summary>
    public static class CtpClientIDTypeType
    {
        ///<summary>
        ///投机
        ///</summary>
        public const byte Speculation = (byte)'1';
        ///<summary>
        ///套利
        ///</summary>
        public const byte Arbitrage = (byte)'2';
        ///<summary>
        ///套保
        ///</summary>
        public const byte Hedge = (byte)'3';
    };

    ///<summary>
    ///TFtdcOrderPriceTypeType是一个报单价格条件类型
    ///</summary>
    public static class CtpOrderPriceTypeType
    {
        ///<summary>
        ///任意价
        ///</summary>
        public const byte AnyPrice = (byte)'1';
        ///<summary>
        ///限价
        ///</summary>
        public const byte LimitPrice = (byte)'2';
        ///<summary>
        ///最优价
        ///</summary>
        public const byte BestPrice = (byte)'3';
        ///<summary>
        ///最新价
        ///</summary>
        public const byte LastPrice = (byte)'4';
        ///<summary>
        ///最新价浮动上浮1个ticks
        ///</summary>
        public const byte LastPricePlusOneTicks = (byte)'5';
        ///<summary>
        ///最新价浮动上浮2个ticks
        ///</summary>
        public const byte LastPricePlusTwoTicks = (byte)'6';
        ///<summary>
        ///最新价浮动上浮3个ticks
        ///</summary>
        public const byte LastPricePlusThreeTicks = (byte)'7';
        ///<summary>
        ///卖一价
        ///</summary>
        public const byte AskPrice1 = (byte)'8';
        ///<summary>
        ///卖一价浮动上浮1个ticks
        ///</summary>
        public const byte AskPrice1PlusOneTicks = (byte)'9';
        ///<summary>
        ///卖一价浮动上浮2个ticks
        ///</summary>
        public const byte AskPrice1PlusTwoTicks = (byte)'A';
        ///<summary>
        ///卖一价浮动上浮3个ticks
        ///</summary>
        public const byte AskPrice1PlusThreeTicks = (byte)'B';
        ///<summary>
        ///买一价
        ///</summary>
        public const byte BidPrice1 = (byte)'C';
        ///<summary>
        ///买一价浮动上浮1个ticks
        ///</summary>
        public const byte BidPrice1PlusOneTicks = (byte)'D';
        ///<summary>
        ///买一价浮动上浮2个ticks
        ///</summary>
        public const byte BidPrice1PlusTwoTicks = (byte)'E';
        ///<summary>
        ///买一价浮动上浮3个ticks
        ///</summary>
        public const byte BidPrice1PlusThreeTicks = (byte)'F';
        ///<summary>
        ///五档价
        ///</summary>
        public const byte FiveLevelPrice = (byte)'G';
    };

    ///<summary>
    ///TFtdcOffsetFlagType是一个开平标志类型
    ///</summary>
    public static class CtpOffsetFlagType
    {
        ///<summary>
        ///开仓
        ///</summary>
        public const byte Open = (byte)'0';
        ///<summary>
        ///平仓
        ///</summary>
        public const byte Close = (byte)'1';
        ///<summary>
        ///强平
        ///</summary>
        public const byte ForceClose = (byte)'2';
        ///<summary>
        ///平今
        ///</summary>
        public const byte CloseToday = (byte)'3';
        ///<summary>
        ///平昨
        ///</summary>
        public const byte CloseYesterday = (byte)'4';
        ///<summary>
        ///强减
        ///</summary>
        public const byte ForceOff = (byte)'5';
        ///<summary>
        ///本地强平
        ///</summary>
        public const byte LocalForceClose = (byte)'6';
    };

    ///<summary>
    ///TFtdcForceCloseReasonType是一个强平原因类型
    ///</summary>
    public static class CtpForceCloseReasonType
    {
        ///<summary>
        ///非强平
        ///</summary>
        public const byte NotForceClose = (byte)'0';
        ///<summary>
        ///资金不足
        ///</summary>
        public const byte LackDeposit = (byte)'1';
        ///<summary>
        ///客户超仓
        ///</summary>
        public const byte ClientOverPositionLimit = (byte)'2';
        ///<summary>
        ///会员超仓
        ///</summary>
        public const byte MemberOverPositionLimit = (byte)'3';
        ///<summary>
        ///持仓非整数倍
        ///</summary>
        public const byte NotMultiple = (byte)'4';
        ///<summary>
        ///违规
        ///</summary>
        public const byte Violation = (byte)'5';
        ///<summary>
        ///其它
        ///</summary>
        public const byte Other = (byte)'6';
        ///<summary>
        ///自然人临近交割
        ///</summary>
        public const byte PersonDeliv = (byte)'7';
    };

    ///<summary>
    ///TFtdcOrderTypeType是一个报单类型类型
    ///</summary>
    public static class CtpOrderTypeType
    {
        ///<summary>
        ///正常
        ///</summary>
        public const byte Normal = (byte)'0';
        ///<summary>
        ///报价衍生
        ///</summary>
        public const byte DeriveFromQuote = (byte)'1';
        ///<summary>
        ///组合衍生
        ///</summary>
        public const byte DeriveFromCombination = (byte)'2';
        ///<summary>
        ///组合报单
        ///</summary>
        public const byte Combination = (byte)'3';
        ///<summary>
        ///条件单
        ///</summary>
        public const byte ConditionalOrder = (byte)'4';
        ///<summary>
        ///互换单
        ///</summary>
        public const byte Swap = (byte)'5';
    };

    ///<summary>
    ///TFtdcTimeConditionType是一个有效期类型类型
    ///</summary>
    public static class CtpTimeConditionType
    {
        ///<summary>
        ///立即完成，否则撤销
        ///</summary>
        public const byte IOC = (byte)'1';
        ///<summary>
        ///本节有效
        ///</summary>
        public const byte GFS = (byte)'2';
        ///<summary>
        ///当日有效
        ///</summary>
        public const byte GFD = (byte)'3';
        ///<summary>
        ///指定日期前有效
        ///</summary>
        public const byte GTD = (byte)'4';
        ///<summary>
        ///撤销前有效
        ///</summary>
        public const byte GTC = (byte)'5';
        ///<summary>
        ///集合竞价有效
        ///</summary>
        public const byte GFA = (byte)'6';
    };

    ///<summary>
    ///TFtdcVolumeConditionType是一个成交量类型类型
    ///</summary>
    public static class CtpVolumeConditionType
    {
        ///<summary>
        ///任何数量
        ///</summary>
        public const byte AV = (byte)'1';
        ///<summary>
        ///最小数量
        ///</summary>
        public const byte MV = (byte)'2';
        ///<summary>
        ///全部数量
        ///</summary>
        public const byte CV = (byte)'3';
    };

    ///<summary>
    ///TFtdcContingentConditionType是一个触发条件类型
    ///</summary>
    public static class CtpContingentConditionType
    {
        ///<summary>
        ///立即
        ///</summary>
        public const byte Immediately = (byte)'1';
        ///<summary>
        ///止损
        ///</summary>
        public const byte Touch = (byte)'2';
        ///<summary>
        ///止赢
        ///</summary>
        public const byte TouchProfit = (byte)'3';
        ///<summary>
        ///预埋单
        ///</summary>
        public const byte ParkedOrder = (byte)'4';
        ///<summary>
        ///最新价大于条件价
        ///</summary>
        public const byte LastPriceGreaterThanStopPrice = (byte)'5';
        ///<summary>
        ///最新价大于等于条件价
        ///</summary>
        public const byte LastPriceGreaterEqualStopPrice = (byte)'6';
        ///<summary>
        ///最新价小于条件价
        ///</summary>
        public const byte LastPriceLesserThanStopPrice = (byte)'7';
        ///<summary>
        ///最新价小于等于条件价
        ///</summary>
        public const byte LastPriceLesserEqualStopPrice = (byte)'8';
        ///<summary>
        ///卖一价大于条件价
        ///</summary>
        public const byte AskPriceGreaterThanStopPrice = (byte)'9';
        ///<summary>
        ///卖一价大于等于条件价
        ///</summary>
        public const byte AskPriceGreaterEqualStopPrice = (byte)'A';
        ///<summary>
        ///卖一价小于条件价
        ///</summary>
        public const byte AskPriceLesserThanStopPrice = (byte)'B';
        ///<summary>
        ///卖一价小于等于条件价
        ///</summary>
        public const byte AskPriceLesserEqualStopPrice = (byte)'C';
        ///<summary>
        ///买一价大于条件价
        ///</summary>
        public const byte BidPriceGreaterThanStopPrice = (byte)'D';
        ///<summary>
        ///买一价大于等于条件价
        ///</summary>
        public const byte BidPriceGreaterEqualStopPrice = (byte)'E';
        ///<summary>
        ///买一价小于条件价
        ///</summary>
        public const byte BidPriceLesserThanStopPrice = (byte)'F';
        ///<summary>
        ///买一价小于等于条件价
        ///</summary>
        public const byte BidPriceLesserEqualStopPrice = (byte)'H';
    };

    ///<summary>
    ///TFtdcActionFlagType是一个操作标志类型
    ///</summary>
    public static class CtpActionFlagType
    {
        ///<summary>
        ///删除
        ///</summary>
        public const byte Delete = (byte)'0';
        ///<summary>
        ///修改
        ///</summary>
        public const byte Modify = (byte)'3';
    };

    ///<summary>
    ///TFtdcTradingRightType是一个交易权限类型
    ///</summary>
    public static class CtpTradingRightType
    {
        ///<summary>
        ///可以交易
        ///</summary>
        public const byte Allow = (byte)'0';
        ///<summary>
        ///只能平仓
        ///</summary>
        public const byte CloseOnly = (byte)'1';
        ///<summary>
        ///不能交易
        ///</summary>
        public const byte Forbidden = (byte)'2';
    };

    ///<summary>
    ///TFtdcOrderSourceType是一个报单来源类型
    ///</summary>
    public static class CtpOrderSourceType
    {
        ///<summary>
        ///来自参与者
        ///</summary>
        public const byte Participant = (byte)'0';
        ///<summary>
        ///来自管理员
        ///</summary>
        public const byte Administrator = (byte)'1';
    };

    ///<summary>
    ///TFtdcTradeTypeType是一个成交类型类型
    ///</summary>
    public static class CtpTradeTypeType
    {
        ///<summary>
        ///组合持仓拆分为单一持仓,初始化不应包含该类型的持仓
        ///</summary>
        public const byte SplitCombination = (byte)'#';
        ///<summary>
        ///普通成交
        ///</summary>
        public const byte Common = (byte)'0';
        ///<summary>
        ///期权执行
        ///</summary>
        public const byte OptionsExecution = (byte)'1';
        ///<summary>
        ///OTC成交
        ///</summary>
        public const byte OTC = (byte)'2';
        ///<summary>
        ///期转现衍生成交
        ///</summary>
        public const byte EFPDerived = (byte)'3';
        ///<summary>
        ///组合衍生成交
        ///</summary>
        public const byte CombinationDerived = (byte)'4';
    };

    ///<summary>
    ///TFtdcPriceSourceType是一个成交价来源类型
    ///</summary>
    public static class CtpPriceSourceType
    {
        ///<summary>
        ///前成交价
        ///</summary>
        public const byte LastPrice = (byte)'0';
        ///<summary>
        ///买委托价
        ///</summary>
        public const byte Buy = (byte)'1';
        ///<summary>
        ///卖委托价
        ///</summary>
        public const byte Sell = (byte)'2';
    };

    ///<summary>
    ///TFtdcInstrumentStatusType是一个合约交易状态类型
    ///</summary>
    public static class CtpInstrumentStatusType
    {
        ///<summary>
        ///开盘前
        ///</summary>
        public const byte BeforeTrading = (byte)'0';
        ///<summary>
        ///非交易
        ///</summary>
        public const byte NoTrading = (byte)'1';
        ///<summary>
        ///连续交易
        ///</summary>
        public const byte Continous = (byte)'2';
        ///<summary>
        ///集合竞价报单
        ///</summary>
        public const byte AuctionOrdering = (byte)'3';
        ///<summary>
        ///集合竞价价格平衡
        ///</summary>
        public const byte AuctionBalance = (byte)'4';
        ///<summary>
        ///集合竞价撮合
        ///</summary>
        public const byte AuctionMatch = (byte)'5';
        ///<summary>
        ///收盘
        ///</summary>
        public const byte Closed = (byte)'6';
    };

    ///<summary>
    ///TFtdcInstStatusEnterReasonType是一个品种进入交易状态原因类型
    ///</summary>
    public static class CtpInstStatusEnterReasonType
    {
        ///<summary>
        ///自动切换
        ///</summary>
        public const byte Automatic = (byte)'1';
        ///<summary>
        ///手动切换
        ///</summary>
        public const byte Manual = (byte)'2';
        ///<summary>
        ///熔断
        ///</summary>
        public const byte Fuse = (byte)'3';
    };

    ///<summary>
    ///TFtdcOrderActionRefType是一个报单操作引用类型
    ///</summary>
    /// TThostFtdcOrderActionRefType 是基础类型

    ///<summary>
    ///TFtdcInstallCountType是一个安装数量类型
    ///</summary>
    /// TThostFtdcInstallCountType 是基础类型

    ///<summary>
    ///TFtdcInstallIDType是一个安装编号类型
    ///</summary>
    /// TThostFtdcInstallIDType 是基础类型

    ///<summary>
    ///TFtdcErrorIDType是一个错误代码类型
    ///</summary>
    /// TThostFtdcErrorIDType 是基础类型

    ///<summary>
    ///TFtdcSettlementIDType是一个结算编号类型
    ///</summary>
    /// TThostFtdcSettlementIDType 是基础类型

    ///<summary>
    ///TFtdcVolumeType是一个数量类型
    ///</summary>
    /// TThostFtdcVolumeType 是基础类型

    ///<summary>
    ///TFtdcFrontIDType是一个前置编号类型
    ///</summary>
    /// TThostFtdcFrontIDType 是基础类型

    ///<summary>
    ///TFtdcSessionIDType是一个会话编号类型
    ///</summary>
    /// TThostFtdcSessionIDType 是基础类型

    ///<summary>
    ///TFtdcSequenceNoType是一个序号类型
    ///</summary>
    /// TThostFtdcSequenceNoType 是基础类型

    ///<summary>
    ///TFtdcCommandNoType是一个DB命令序号类型
    ///</summary>
    /// TThostFtdcCommandNoType 是基础类型

    ///<summary>
    ///TFtdcMillisecType是一个时间（毫秒）类型
    ///</summary>
    /// TThostFtdcMillisecType 是基础类型

    ///<summary>
    ///TFtdcVolumeMultipleType是一个合约数量乘数类型
    ///</summary>
    /// TThostFtdcVolumeMultipleType 是基础类型

    ///<summary>
    ///TFtdcTradingSegmentSNType是一个交易阶段编号类型
    ///</summary>
    /// TThostFtdcTradingSegmentSNType 是基础类型

    ///<summary>
    ///TFtdcRequestIDType是一个请求编号类型
    ///</summary>
    /// TThostFtdcRequestIDType 是基础类型

    ///<summary>
    ///TFtdcYearType是一个年份类型
    ///</summary>
    /// TThostFtdcYearType 是基础类型

    ///<summary>
    ///TFtdcMonthType是一个月份类型
    ///</summary>
    /// TThostFtdcMonthType 是基础类型

    ///<summary>
    ///TFtdcBoolType是一个布尔型类型
    ///</summary>
    /// TThostFtdcBoolType 是基础类型

    ///<summary>
    ///TFtdcPriceType是一个价格类型
    ///</summary>
    /// TThostFtdcPriceType 是基础类型

    ///<summary>
    ///TFtdcCombOffsetFlagType是一个组合开平标志类型
    ///</summary>
    /// TThostFtdcCombOffsetFlagType 是基础类型

    ///<summary>
    ///TFtdcCombHedgeFlagType是一个组合投机套保标志类型
    ///</summary>
    /// TThostFtdcCombHedgeFlagType 是基础类型

    ///<summary>
    ///TFtdcRatioType是一个比率类型
    ///</summary>
    /// TThostFtdcRatioType 是基础类型

    ///<summary>
    ///TFtdcMoneyType是一个资金类型
    ///</summary>
    /// TThostFtdcMoneyType 是基础类型

    ///<summary>
    ///TFtdcLargeVolumeType是一个大额数量类型
    ///</summary>
    /// TThostFtdcLargeVolumeType 是基础类型

    ///<summary>
    ///TFtdcSequenceSeriesType是一个序列系列号类型
    ///</summary>
    /// TThostFtdcSequenceSeriesType 是基础类型

    ///<summary>
    ///TFtdcCommPhaseNoType是一个通讯时段编号类型
    ///</summary>
    /// TThostFtdcCommPhaseNoType 是基础类型

    ///<summary>
    ///TFtdcSequenceLabelType是一个序列编号类型
    ///</summary>
    /// TThostFtdcSequenceLabelType 是基础类型

    ///<summary>
    ///TFtdcUnderlyingMultipleType是一个基础商品乘数类型
    ///</summary>
    /// TThostFtdcUnderlyingMultipleType 是基础类型

    ///<summary>
    ///TFtdcPriorityType是一个优先级类型
    ///</summary>
    /// TThostFtdcPriorityType 是基础类型

    ///<summary>
    ///TFtdcContractCodeType是一个合同编号类型
    ///</summary>
    /// TThostFtdcContractCodeType 是基础类型

    ///<summary>
    ///TFtdcCityType是一个市类型
    ///</summary>
    /// TThostFtdcCityType 是基础类型

    ///<summary>
    ///TFtdcIsStockType是一个是否股民类型
    ///</summary>
    /// TThostFtdcIsStockType 是基础类型

    ///<summary>
    ///TFtdcChannelType是一个渠道类型
    ///</summary>
    /// TThostFtdcChannelType 是基础类型

    ///<summary>
    ///TFtdcAddressType是一个通讯地址类型
    ///</summary>
    /// TThostFtdcAddressType 是基础类型

    ///<summary>
    ///TFtdcZipCodeType是一个邮政编码类型
    ///</summary>
    /// TThostFtdcZipCodeType 是基础类型

    ///<summary>
    ///TFtdcTelephoneType是一个联系电话类型
    ///</summary>
    /// TThostFtdcTelephoneType 是基础类型

    ///<summary>
    ///TFtdcFaxType是一个传真类型
    ///</summary>
    /// TThostFtdcFaxType 是基础类型

    ///<summary>
    ///TFtdcMobileType是一个手机类型
    ///</summary>
    /// TThostFtdcMobileType 是基础类型

    ///<summary>
    ///TFtdcEMailType是一个电子邮件类型
    ///</summary>
    /// TThostFtdcEMailType 是基础类型

    ///<summary>
    ///TFtdcMemoType是一个备注类型
    ///</summary>
    /// TThostFtdcMemoType 是基础类型

    ///<summary>
    ///TFtdcCompanyCodeType是一个企业代码类型
    ///</summary>
    /// TThostFtdcCompanyCodeType 是基础类型

    ///<summary>
    ///TFtdcWebsiteType是一个网站地址类型
    ///</summary>
    /// TThostFtdcWebsiteType 是基础类型

    ///<summary>
    ///TFtdcTaxNoType是一个税务登记号类型
    ///</summary>
    /// TThostFtdcTaxNoType 是基础类型

    ///<summary>
    ///TFtdcBatchStatusType是一个处理状态类型
    ///</summary>
    /// TThostFtdcBatchStatusType 未被使用

    ///<summary>
    ///TFtdcPropertyIDType是一个属性代码类型
    ///</summary>
    /// TThostFtdcPropertyIDType 是基础类型

    ///<summary>
    ///TFtdcPropertyNameType是一个属性名称类型
    ///</summary>
    /// TThostFtdcPropertyNameType 是基础类型

    ///<summary>
    ///TFtdcLicenseNoType是一个营业执照号类型
    ///</summary>
    /// TThostFtdcLicenseNoType 是基础类型

    ///<summary>
    ///TFtdcAgentIDType是一个经纪人代码类型
    ///</summary>
    /// TThostFtdcAgentIDType 是基础类型

    ///<summary>
    ///TFtdcAgentNameType是一个经纪人名称类型
    ///</summary>
    /// TThostFtdcAgentNameType 是基础类型

    ///<summary>
    ///TFtdcAgentGroupIDType是一个经纪人组代码类型
    ///</summary>
    /// TThostFtdcAgentGroupIDType 是基础类型

    ///<summary>
    ///TFtdcAgentGroupNameType是一个经纪人组名称类型
    ///</summary>
    /// TThostFtdcAgentGroupNameType 是基础类型

    ///<summary>
    ///TFtdcReturnStyleType是一个按品种返还方式类型
    ///</summary>
    /// TThostFtdcReturnStyleType 未被使用

    ///<summary>
    ///TFtdcReturnPatternType是一个返还模式类型
    ///</summary>
    /// TThostFtdcReturnPatternType 未被使用

    ///<summary>
    ///TFtdcReturnLevelType是一个返还级别类型
    ///</summary>
    /// TThostFtdcReturnLevelType 未被使用

    ///<summary>
    ///TFtdcReturnStandardType是一个返还标准类型
    ///</summary>
    /// TThostFtdcReturnStandardType 未被使用

    ///<summary>
    ///TFtdcMortgageTypeType是一个质押类型类型
    ///</summary>
    /// TThostFtdcMortgageTypeType 未被使用

    ///<summary>
    ///TFtdcInvestorSettlementParamIDType是一个投资者结算参数代码类型
    ///</summary>
    /// TThostFtdcInvestorSettlementParamIDType 未被使用

    ///<summary>
    ///TFtdcExchangeSettlementParamIDType是一个交易所结算参数代码类型
    ///</summary>
    /// TThostFtdcExchangeSettlementParamIDType 未被使用

    ///<summary>
    ///TFtdcSystemParamIDType是一个系统参数代码类型
    ///</summary>
    /// TThostFtdcSystemParamIDType 未被使用

    ///<summary>
    ///TFtdcTradeParamIDType是一个交易系统参数代码类型
    ///</summary>
    /// TThostFtdcTradeParamIDType 未被使用

    ///<summary>
    ///TFtdcSettlementParamValueType是一个参数代码值类型
    ///</summary>
    /// TThostFtdcSettlementParamValueType 是基础类型

    ///<summary>
    ///TFtdcCounterIDType是一个计数器代码类型
    ///</summary>
    /// TThostFtdcCounterIDType 是基础类型

    ///<summary>
    ///TFtdcInvestorGroupNameType是一个投资者分组名称类型
    ///</summary>
    /// TThostFtdcInvestorGroupNameType 是基础类型

    ///<summary>
    ///TFtdcBrandCodeType是一个牌号类型
    ///</summary>
    /// TThostFtdcBrandCodeType 是基础类型

    ///<summary>
    ///TFtdcWarehouseType是一个仓库类型
    ///</summary>
    /// TThostFtdcWarehouseType 是基础类型

    ///<summary>
    ///TFtdcProductDateType是一个产期类型
    ///</summary>
    /// TThostFtdcProductDateType 是基础类型

    ///<summary>
    ///TFtdcGradeType是一个等级类型
    ///</summary>
    /// TThostFtdcGradeType 是基础类型

    ///<summary>
    ///TFtdcClassifyType是一个类别类型
    ///</summary>
    /// TThostFtdcClassifyType 是基础类型

    ///<summary>
    ///TFtdcPositionType是一个货位类型
    ///</summary>
    /// TThostFtdcPositionType 是基础类型

    ///<summary>
    ///TFtdcYieldlyType是一个产地类型
    ///</summary>
    /// TThostFtdcYieldlyType 是基础类型

    ///<summary>
    ///TFtdcWeightType是一个公定重量类型
    ///</summary>
    /// TThostFtdcWeightType 是基础类型

    ///<summary>
    ///TFtdcSubEntryFundNoType是一个分项资金流水号类型
    ///</summary>
    /// TThostFtdcSubEntryFundNoType 是基础类型

    ///<summary>
    ///TFtdcFileIDType是一个文件标识类型
    ///</summary>
    /// TThostFtdcFileIDType 未被使用

    ///<summary>
    ///TFtdcFileNameType是一个文件名称类型
    ///</summary>
    /// TThostFtdcFileNameType 是基础类型

    ///<summary>
    ///TFtdcFileTypeType是一个文件上传类型类型
    ///</summary>
    /// TThostFtdcFileTypeType 未被使用

    ///<summary>
    ///TFtdcFileFormatType是一个文件格式类型
    ///</summary>
    /// TThostFtdcFileFormatType 未被使用

    ///<summary>
    ///TFtdcFileUploadStatusType是一个文件状态类型
    ///</summary>
    /// TThostFtdcFileUploadStatusType 未被使用

    ///<summary>
    ///TFtdcTransferDirectionType是一个移仓方向类型
    ///</summary>
    /// TThostFtdcTransferDirectionType 未被使用

    ///<summary>
    ///TFtdcUploadModeType是一个上传文件类型类型
    ///</summary>
    /// TThostFtdcUploadModeType 是基础类型

    ///<summary>
    ///TFtdcAccountIDType是一个投资者帐号类型
    ///</summary>
    /// TThostFtdcAccountIDType 是基础类型

    ///<summary>
    ///TFtdcBankFlagType是一个银行统一标识类型类型
    ///</summary>
    /// TThostFtdcBankFlagType 是基础类型

    ///<summary>
    ///TFtdcBankAccountType是一个银行账户类型
    ///</summary>
    /// TThostFtdcBankAccountType 是基础类型

    ///<summary>
    ///TFtdcOpenNameType是一个银行账户的开户人名称类型
    ///</summary>
    /// TThostFtdcOpenNameType 是基础类型

    ///<summary>
    ///TFtdcOpenBankType是一个银行账户的开户行类型
    ///</summary>
    /// TThostFtdcOpenBankType 是基础类型

    ///<summary>
    ///TFtdcBankNameType是一个银行名称类型
    ///</summary>
    /// TThostFtdcBankNameType 是基础类型

    ///<summary>
    ///TFtdcPublishPathType是一个发布路径类型
    ///</summary>
    /// TThostFtdcPublishPathType 是基础类型

    ///<summary>
    ///TFtdcOperatorIDType是一个操作员代码类型
    ///</summary>
    /// TThostFtdcOperatorIDType 是基础类型

    ///<summary>
    ///TFtdcMonthCountType是一个月份数量类型
    ///</summary>
    /// TThostFtdcMonthCountType 是基础类型

    ///<summary>
    ///TFtdcAdvanceMonthArrayType是一个月份提前数组类型
    ///</summary>
    /// TThostFtdcAdvanceMonthArrayType 是基础类型

    ///<summary>
    ///TFtdcDateExprType是一个日期表达式类型
    ///</summary>
    /// TThostFtdcDateExprType 是基础类型

    ///<summary>
    ///TFtdcInstrumentIDExprType是一个合约代码表达式类型
    ///</summary>
    /// TThostFtdcInstrumentIDExprType 是基础类型

    ///<summary>
    ///TFtdcInstrumentNameExprType是一个合约名称表达式类型
    ///</summary>
    /// TThostFtdcInstrumentNameExprType 是基础类型

    ///<summary>
    ///TFtdcSpecialCreateRuleType是一个特殊的创建规则类型
    ///</summary>
    /// TThostFtdcSpecialCreateRuleType 未被使用

    ///<summary>
    ///TFtdcBasisPriceTypeType是一个挂牌基准价类型类型
    ///</summary>
    /// TThostFtdcBasisPriceTypeType 未被使用

    ///<summary>
    ///TFtdcProductLifePhaseType是一个产品生命周期状态类型
    ///</summary>
    /// TThostFtdcProductLifePhaseType 未被使用

    ///<summary>
    ///TFtdcDeliveryModeType是一个交割方式类型
    ///</summary>
    /// TThostFtdcDeliveryModeType 未被使用

    ///<summary>
    ///TFtdcLogLevelType是一个日志级别类型
    ///</summary>
    /// TThostFtdcLogLevelType 是基础类型

    ///<summary>
    ///TFtdcProcessNameType是一个存储过程名称类型
    ///</summary>
    /// TThostFtdcProcessNameType 是基础类型

    ///<summary>
    ///TFtdcOperationMemoType是一个操作摘要类型
    ///</summary>
    /// TThostFtdcOperationMemoType 是基础类型

    ///<summary>
    ///TFtdcFundIOTypeType是一个出入金类型类型
    ///</summary>
    /// TThostFtdcFundIOTypeType 未被使用

    ///<summary>
    ///TFtdcFundTypeType是一个资金类型类型
    ///</summary>
    /// TThostFtdcFundTypeType 未被使用

    ///<summary>
    ///TFtdcFundDirectionType是一个出入金方向类型
    ///</summary>
    /// TThostFtdcFundDirectionType 未被使用

    ///<summary>
    ///TFtdcFundStatusType是一个资金状态类型
    ///</summary>
    /// TThostFtdcFundStatusType 未被使用

    ///<summary>
    ///TFtdcBillNoType是一个票据号类型
    ///</summary>
    /// TThostFtdcBillNoType 是基础类型

    ///<summary>
    ///TFtdcBillNameType是一个票据名称类型
    ///</summary>
    /// TThostFtdcBillNameType 是基础类型

    ///<summary>
    ///TFtdcPublishStatusType是一个发布状态类型
    ///</summary>
    /// TThostFtdcPublishStatusType 未被使用

    ///<summary>
    ///TFtdcEnumValueIDType是一个枚举值代码类型
    ///</summary>
    /// TThostFtdcEnumValueIDType 是基础类型

    ///<summary>
    ///TFtdcEnumValueTypeType是一个枚举值类型类型
    ///</summary>
    /// TThostFtdcEnumValueTypeType 是基础类型

    ///<summary>
    ///TFtdcEnumValueLabelType是一个枚举值名称类型
    ///</summary>
    /// TThostFtdcEnumValueLabelType 是基础类型

    ///<summary>
    ///TFtdcEnumValueResultType是一个枚举值结果类型
    ///</summary>
    /// TThostFtdcEnumValueResultType 是基础类型

    ///<summary>
    ///TFtdcSystemStatusType是一个系统状态类型
    ///</summary>
    /// TThostFtdcSystemStatusType 未被使用

    ///<summary>
    ///TFtdcSettlementStatusType是一个结算状态类型
    ///</summary>
    /// TThostFtdcSettlementStatusType 未被使用

    ///<summary>
    ///TFtdcRangeIntTypeType是一个限定值类型类型
    ///</summary>
    /// TThostFtdcRangeIntTypeType 是基础类型

    ///<summary>
    ///TFtdcRangeIntFromType是一个限定值下限类型
    ///</summary>
    /// TThostFtdcRangeIntFromType 是基础类型

    ///<summary>
    ///TFtdcRangeIntToType是一个限定值上限类型
    ///</summary>
    /// TThostFtdcRangeIntToType 是基础类型

    ///<summary>
    ///TFtdcFunctionIDType是一个功能代码类型
    ///</summary>
    /// TThostFtdcFunctionIDType 是基础类型

    ///<summary>
    ///TFtdcFunctionValueCodeType是一个功能编码类型
    ///</summary>
    /// TThostFtdcFunctionValueCodeType 是基础类型

    ///<summary>
    ///TFtdcFunctionNameType是一个功能名称类型
    ///</summary>
    /// TThostFtdcFunctionNameType 是基础类型

    ///<summary>
    ///TFtdcRoleIDType是一个角色编号类型
    ///</summary>
    /// TThostFtdcRoleIDType 是基础类型

    ///<summary>
    ///TFtdcRoleNameType是一个角色名称类型
    ///</summary>
    /// TThostFtdcRoleNameType 是基础类型

    ///<summary>
    ///TFtdcDescriptionType是一个描述类型
    ///</summary>
    /// TThostFtdcDescriptionType 是基础类型

    ///<summary>
    ///TFtdcCombineIDType是一个组合编号类型
    ///</summary>
    /// TThostFtdcCombineIDType 是基础类型

    ///<summary>
    ///TFtdcCombineTypeType是一个组合类型类型
    ///</summary>
    /// TThostFtdcCombineTypeType 是基础类型

    ///<summary>
    ///TFtdcInvestorTypeType是一个投资者类型类型
    ///</summary>
    /// TThostFtdcInvestorTypeType 未被使用

    ///<summary>
    ///TFtdcBrokerTypeType是一个经纪公司类型类型
    ///</summary>
    /// TThostFtdcBrokerTypeType 未被使用

    ///<summary>
    ///TFtdcRiskLevelType是一个风险等级类型
    ///</summary>
    /// TThostFtdcRiskLevelType 未被使用

    ///<summary>
    ///TFtdcFeeAcceptStyleType是一个手续费收取方式类型
    ///</summary>
    /// TThostFtdcFeeAcceptStyleType 未被使用

    ///<summary>
    ///TFtdcPasswordTypeType是一个密码类型类型
    ///</summary>
    /// TThostFtdcPasswordTypeType 未被使用

    ///<summary>
    ///TFtdcAlgorithmType是一个盈亏算法类型
    ///</summary>
    public static class CtpAlgorithmType
    {
        ///<summary>
        ///浮盈浮亏都计算
        ///</summary>
        public const byte All = (byte)'1';
        ///<summary>
        ///浮盈不计，浮亏计
        ///</summary>
        public const byte OnlyLost = (byte)'2';
        ///<summary>
        ///浮盈计，浮亏不计
        ///</summary>
        public const byte OnlyGain = (byte)'3';
        ///<summary>
        ///浮盈浮亏都不计算
        ///</summary>
        public const byte None = (byte)'4';
    };

    ///<summary>
    ///TFtdcIncludeCloseProfitType是一个是否包含平仓盈利类型
    ///</summary>
    public static class CtpIncludeCloseProfitType
    {
        ///<summary>
        ///包含平仓盈利
        ///</summary>
        public const byte Include = (byte)'0';
        ///<summary>
        ///不包含平仓盈利
        ///</summary>
        public const byte NotInclude = (byte)'2';
    };

    ///<summary>
    ///TFtdcAllWithoutTradeType是一个是否受可提比例限制类型
    ///</summary>
    public static class CtpAllWithoutTradeType
    {
        ///<summary>
        ///无仓无成交不受可提比例限制
        ///</summary>
        public const byte Enable = (byte)'0';
        ///<summary>
        ///受可提比例限制
        ///</summary>
        public const byte Disable = (byte)'2';
        ///<summary>
        ///无仓不受可提比例限制
        ///</summary>
        public const byte NoHoldEnable = (byte)'3';
    };

    ///<summary>
    ///TFtdcCommentType是一个盈亏算法说明类型
    ///</summary>
    /// TThostFtdcCommentType 是基础类型

    ///<summary>
    ///TFtdcVersionType是一个版本号类型
    ///</summary>
    /// TThostFtdcVersionType 是基础类型

    ///<summary>
    ///TFtdcTradeCodeType是一个交易代码类型
    ///</summary>
    /// TThostFtdcTradeCodeType 是基础类型

    ///<summary>
    ///TFtdcTradeDateType是一个交易日期类型
    ///</summary>
    /// TThostFtdcTradeDateType 是基础类型

    ///<summary>
    ///TFtdcTradeTimeType是一个交易时间类型
    ///</summary>
    /// TThostFtdcTradeTimeType 是基础类型

    ///<summary>
    ///TFtdcTradeSerialType是一个发起方流水号类型
    ///</summary>
    /// TThostFtdcTradeSerialType 是基础类型

    ///<summary>
    ///TFtdcTradeSerialNoType是一个发起方流水号类型
    ///</summary>
    /// TThostFtdcTradeSerialNoType 是基础类型

    ///<summary>
    ///TFtdcFutureIDType是一个期货公司代码类型
    ///</summary>
    /// TThostFtdcFutureIDType 是基础类型

    ///<summary>
    ///TFtdcBankIDType是一个银行代码类型
    ///</summary>
    /// TThostFtdcBankIDType 是基础类型

    ///<summary>
    ///TFtdcBankBrchIDType是一个银行分中心代码类型
    ///</summary>
    /// TThostFtdcBankBrchIDType 是基础类型

    ///<summary>
    ///TFtdcBankBranchIDType是一个分中心代码类型
    ///</summary>
    /// TThostFtdcBankBranchIDType 是基础类型

    ///<summary>
    ///TFtdcOperNoType是一个交易柜员类型
    ///</summary>
    /// TThostFtdcOperNoType 是基础类型

    ///<summary>
    ///TFtdcDeviceIDType是一个渠道标志类型
    ///</summary>
    /// TThostFtdcDeviceIDType 是基础类型

    ///<summary>
    ///TFtdcRecordNumType是一个记录数类型
    ///</summary>
    /// TThostFtdcRecordNumType 是基础类型

    ///<summary>
    ///TFtdcFutureAccountType是一个期货资金账号类型
    ///</summary>
    /// TThostFtdcFutureAccountType 是基础类型

    ///<summary>
    ///TFtdcFuturePwdFlagType是一个资金密码核对标志类型
    ///</summary>
    public static class CtpFuturePwdFlagType
    {
        ///<summary>
        ///不核对
        ///</summary>
        public const byte UnCheck = (byte)'0';
        ///<summary>
        ///核对
        ///</summary>
        public const byte Check = (byte)'1';
    };

    ///<summary>
    ///TFtdcTransferTypeType是一个银期转账类型类型
    ///</summary>
    /// TThostFtdcTransferTypeType 未被使用

    ///<summary>
    ///TFtdcFutureAccPwdType是一个期货资金密码类型
    ///</summary>
    /// TThostFtdcFutureAccPwdType 是基础类型

    ///<summary>
    ///TFtdcCurrencyCodeType是一个币种类型
    ///</summary>
    /// TThostFtdcCurrencyCodeType 是基础类型

    ///<summary>
    ///TFtdcRetCodeType是一个响应代码类型
    ///</summary>
    /// TThostFtdcRetCodeType 是基础类型

    ///<summary>
    ///TFtdcRetInfoType是一个响应信息类型
    ///</summary>
    /// TThostFtdcRetInfoType 是基础类型

    ///<summary>
    ///TFtdcTradeAmtType是一个银行总余额类型
    ///</summary>
    /// TThostFtdcTradeAmtType 是基础类型

    ///<summary>
    ///TFtdcUseAmtType是一个银行可用余额类型
    ///</summary>
    /// TThostFtdcUseAmtType 是基础类型

    ///<summary>
    ///TFtdcFetchAmtType是一个银行可取余额类型
    ///</summary>
    /// TThostFtdcFetchAmtType 是基础类型

    ///<summary>
    ///TFtdcTransferValidFlagType是一个转账有效标志类型
    ///</summary>
    public static class CtpTransferValidFlagType
    {
        ///<summary>
        ///无效或失败
        ///</summary>
        public const byte Invalid = (byte)'0';
        ///<summary>
        ///有效
        ///</summary>
        public const byte Valid = (byte)'1';
        ///<summary>
        ///冲正
        ///</summary>
        public const byte Reverse = (byte)'2';
    };

    ///<summary>
    ///TFtdcCertCodeType是一个证件号码类型
    ///</summary>
    /// TThostFtdcCertCodeType 是基础类型

    ///<summary>
    ///TFtdcReasonType是一个事由类型
    ///</summary>
    /// TThostFtdcReasonType 未被使用

    ///<summary>
    ///TFtdcFundProjectIDType是一个资金项目编号类型
    ///</summary>
    /// TThostFtdcFundProjectIDType 是基础类型

    ///<summary>
    ///TFtdcSexType是一个性别类型
    ///</summary>
    /// TThostFtdcSexType 未被使用

    ///<summary>
    ///TFtdcProfessionType是一个职业类型
    ///</summary>
    /// TThostFtdcProfessionType 是基础类型

    ///<summary>
    ///TFtdcNationalType是一个国籍类型
    ///</summary>
    /// TThostFtdcNationalType 是基础类型

    ///<summary>
    ///TFtdcProvinceType是一个省类型
    ///</summary>
    /// TThostFtdcProvinceType 是基础类型

    ///<summary>
    ///TFtdcRegionType是一个区类型
    ///</summary>
    /// TThostFtdcRegionType 是基础类型

    ///<summary>
    ///TFtdcCountryType是一个国家类型
    ///</summary>
    /// TThostFtdcCountryType 是基础类型

    ///<summary>
    ///TFtdcLicenseNOType是一个营业执照类型
    ///</summary>
    /// TThostFtdcLicenseNOType 是基础类型

    ///<summary>
    ///TFtdcCompanyTypeType是一个企业性质类型
    ///</summary>
    /// TThostFtdcCompanyTypeType 是基础类型

    ///<summary>
    ///TFtdcBusinessScopeType是一个经营范围类型
    ///</summary>
    /// TThostFtdcBusinessScopeType 是基础类型

    ///<summary>
    ///TFtdcCapitalCurrencyType是一个注册资本币种类型
    ///</summary>
    /// TThostFtdcCapitalCurrencyType 是基础类型

    ///<summary>
    ///TFtdcUserTypeType是一个用户类型类型
    ///</summary>
    public static class CtpUserTypeType
    {
        ///<summary>
        ///投资者
        ///</summary>
        public const byte Investor = (byte)'0';
        ///<summary>
        ///操作员
        ///</summary>
        public const byte Operator = (byte)'1';
        ///<summary>
        ///管理员
        ///</summary>
        public const byte SuperUser = (byte)'2';
    };

    ///<summary>
    ///TFtdcRateTypeType是一个费率类型类型
    ///</summary>
    /// TThostFtdcRateTypeType 未被使用

    ///<summary>
    ///TFtdcNoteTypeType是一个通知类型类型
    ///</summary>
    /// TThostFtdcNoteTypeType 未被使用

    ///<summary>
    ///TFtdcSettlementStyleType是一个结算单方式类型
    ///</summary>
    /// TThostFtdcSettlementStyleType 未被使用

    ///<summary>
    ///TFtdcBrokerDNSType是一个域名类型
    ///</summary>
    /// TThostFtdcBrokerDNSType 是基础类型

    ///<summary>
    ///TFtdcSentenceType是一个语句类型
    ///</summary>
    /// TThostFtdcSentenceType 是基础类型

    ///<summary>
    ///TFtdcSettlementBillTypeType是一个结算单类型类型
    ///</summary>
    /// TThostFtdcSettlementBillTypeType 未被使用

    ///<summary>
    ///TFtdcUserRightTypeType是一个客户权限类型类型
    ///</summary>
    public static class CtpUserRightTypeType
    {
        ///<summary>
        ///登录
        ///</summary>
        public const byte Logon = (byte)'1';
        ///<summary>
        ///银期转帐
        ///</summary>
        public const byte Transfer = (byte)'2';
        ///<summary>
        ///邮寄结算单
        ///</summary>
        public const byte EMail = (byte)'3';
        ///<summary>
        ///传真结算单
        ///</summary>
        public const byte Fax = (byte)'4';
        ///<summary>
        ///条件单
        ///</summary>
        public const byte ConditionOrder = (byte)'5';
    };

    ///<summary>
    ///TFtdcMarginPriceTypeType是一个保证金价格类型类型
    ///</summary>
    public static class CtpMarginPriceTypeType
    {
        ///<summary>
        ///昨结算价
        ///</summary>
        public const byte PreSettlementPrice = (byte)'1';
        ///<summary>
        ///最新价
        ///</summary>
        public const byte SettlementPrice = (byte)'2';
        ///<summary>
        ///成交均价
        ///</summary>
        public const byte AveragePrice = (byte)'3';
        ///<summary>
        ///开仓价
        ///</summary>
        public const byte OpenPrice = (byte)'4';
    };

    ///<summary>
    ///TFtdcBillGenStatusType是一个结算单生成状态类型
    ///</summary>
    /// TThostFtdcBillGenStatusType 未被使用

    ///<summary>
    ///TFtdcAlgoTypeType是一个算法类型类型
    ///</summary>
    /// TThostFtdcAlgoTypeType 未被使用

    ///<summary>
    ///TFtdcHandlePositionAlgoIDType是一个持仓处理算法编号类型
    ///</summary>
    public static class CtpHandlePositionAlgoIDType
    {
        ///<summary>
        ///基本
        ///</summary>
        public const byte Base = (byte)'1';
        ///<summary>
        ///大连商品交易所
        ///</summary>
        public const byte DCE = (byte)'2';
        ///<summary>
        ///郑州商品交易所
        ///</summary>
        public const byte CZCE = (byte)'3';
    };

    ///<summary>
    ///TFtdcFindMarginRateAlgoIDType是一个寻找保证金率算法编号类型
    ///</summary>
    public static class CtpFindMarginRateAlgoIDType
    {
        ///<summary>
        ///基本
        ///</summary>
        public const byte Base = (byte)'1';
        ///<summary>
        ///大连商品交易所
        ///</summary>
        public const byte DCE = (byte)'2';
        ///<summary>
        ///郑州商品交易所
        ///</summary>
        public const byte CZCE = (byte)'3';
    };

    ///<summary>
    ///TFtdcHandleTradingAccountAlgoIDType是一个资金处理算法编号类型
    ///</summary>
    public static class CtpHandleTradingAccountAlgoIDType
    {
        ///<summary>
        ///基本
        ///</summary>
        public const byte Base = (byte)'1';
        ///<summary>
        ///大连商品交易所
        ///</summary>
        public const byte DCE = (byte)'2';
        ///<summary>
        ///郑州商品交易所
        ///</summary>
        public const byte CZCE = (byte)'3';
    };

    ///<summary>
    ///TFtdcPersonTypeType是一个联系人类型类型
    ///</summary>
    public static class CtpPersonTypeType
    {
        ///<summary>
        ///指定下单人
        ///</summary>
        public const byte Order = (byte)'1';
        ///<summary>
        ///开户授权人
        ///</summary>
        public const byte Open = (byte)'2';
        ///<summary>
        ///资金调拨人
        ///</summary>
        public const byte Fund = (byte)'3';
        ///<summary>
        ///结算单确认人
        ///</summary>
        public const byte Settlement = (byte)'4';
        ///<summary>
        ///法人
        ///</summary>
        public const byte Company = (byte)'5';
        ///<summary>
        ///法人代表
        ///</summary>
        public const byte Corporation = (byte)'6';
        ///<summary>
        ///投资者联系人
        ///</summary>
        public const byte LinkMan = (byte)'7';
        ///<summary>
        ///分户管理资产负责人
        ///</summary>
        public const byte Ledger = (byte)'8';
        ///<summary>
        ///托（保）管人
        ///</summary>
        public const byte Trustee = (byte)'9';
        ///<summary>
        ///托（保）管机构法人代表
        ///</summary>
        public const byte TrusteeCorporation = (byte)'A';
        ///<summary>
        ///托（保）管机构开户授权人
        ///</summary>
        public const byte TrusteeOpen = (byte)'B';
        ///<summary>
        ///托（保）管机构联系人
        ///</summary>
        public const byte TrusteeContact = (byte)'C';
        ///<summary>
        ///境外自然人参考证件
        ///</summary>
        public const byte ForeignerRefer = (byte)'D';
        ///<summary>
        ///法人代表参考证件
        ///</summary>
        public const byte CorporationRefer = (byte)'E';
    };

    ///<summary>
    ///TFtdcQueryInvestorRangeType是一个查询范围类型
    ///</summary>
    /// TThostFtdcQueryInvestorRangeType 未被使用

    ///<summary>
    ///TFtdcInvestorRiskStatusType是一个投资者风险状态类型
    ///</summary>
    /// TThostFtdcInvestorRiskStatusType 未被使用

    ///<summary>
    ///TFtdcLegIDType是一个单腿编号类型
    ///</summary>
    /// TThostFtdcLegIDType 是基础类型

    ///<summary>
    ///TFtdcLegMultipleType是一个单腿乘数类型
    ///</summary>
    /// TThostFtdcLegMultipleType 是基础类型

    ///<summary>
    ///TFtdcImplyLevelType是一个派生层数类型
    ///</summary>
    /// TThostFtdcImplyLevelType 是基础类型

    ///<summary>
    ///TFtdcClearAccountType是一个结算账户类型
    ///</summary>
    /// TThostFtdcClearAccountType 是基础类型

    ///<summary>
    ///TFtdcOrganNOType是一个结算账户类型
    ///</summary>
    /// TThostFtdcOrganNOType 是基础类型

    ///<summary>
    ///TFtdcClearbarchIDType是一个结算账户联行号类型
    ///</summary>
    /// TThostFtdcClearbarchIDType 是基础类型

    ///<summary>
    ///TFtdcUserEventTypeType是一个用户事件类型类型
    ///</summary>
    public static class CtpUserEventTypeType
    {
        ///<summary>
        ///登录
        ///</summary>
        public const byte Login = (byte)'1';
        ///<summary>
        ///登出
        ///</summary>
        public const byte Logout = (byte)'2';
        ///<summary>
        ///交易成功
        ///</summary>
        public const byte Trading = (byte)'3';
        ///<summary>
        ///交易失败
        ///</summary>
        public const byte TradingError = (byte)'4';
        ///<summary>
        ///修改密码
        ///</summary>
        public const byte UpdatePassword = (byte)'5';
        ///<summary>
        ///客户端认证
        ///</summary>
        public const byte Authenticate = (byte)'6';
        ///<summary>
        ///其他
        ///</summary>
        public const byte Other = (byte)'9';
    };

    ///<summary>
    ///TFtdcUserEventInfoType是一个用户事件信息类型
    ///</summary>
    /// TThostFtdcUserEventInfoType 是基础类型

    ///<summary>
    ///TFtdcCloseStyleType是一个平仓方式类型
    ///</summary>
    /// TThostFtdcCloseStyleType 未被使用

    ///<summary>
    ///TFtdcStatModeType是一个统计方式类型
    ///</summary>
    /// TThostFtdcStatModeType 未被使用

    ///<summary>
    ///TFtdcParkedOrderStatusType是一个预埋单状态类型
    ///</summary>
    public static class CtpParkedOrderStatusType
    {
        ///<summary>
        ///未发送
        ///</summary>
        public const byte NotSend = (byte)'1';
        ///<summary>
        ///已发送
        ///</summary>
        public const byte Send = (byte)'2';
        ///<summary>
        ///已删除
        ///</summary>
        public const byte Deleted = (byte)'3';
    };

    ///<summary>
    ///TFtdcParkedOrderIDType是一个预埋报单编号类型
    ///</summary>
    /// TThostFtdcParkedOrderIDType 是基础类型

    ///<summary>
    ///TFtdcParkedOrderActionIDType是一个预埋撤单编号类型
    ///</summary>
    /// TThostFtdcParkedOrderActionIDType 是基础类型

    ///<summary>
    ///TFtdcVirDealStatusType是一个处理状态类型
    ///</summary>
    /// TThostFtdcVirDealStatusType 未被使用

    ///<summary>
    ///TFtdcOrgSystemIDType是一个原有系统代码类型
    ///</summary>
    /// TThostFtdcOrgSystemIDType 未被使用

    ///<summary>
    ///TFtdcVirTradeStatusType是一个交易状态类型
    ///</summary>
    /// TThostFtdcVirTradeStatusType 未被使用

    ///<summary>
    ///TFtdcVirBankAccTypeType是一个银行帐户类型类型
    ///</summary>
    /// TThostFtdcVirBankAccTypeType 未被使用

    ///<summary>
    ///TFtdcVirementStatusType是一个银行帐户类型类型
    ///</summary>
    /// TThostFtdcVirementStatusType 未被使用

    ///<summary>
    ///TFtdcVirementAvailAbilityType是一个有效标志类型
    ///</summary>
    /// TThostFtdcVirementAvailAbilityType 未被使用

    ///<summary>
    ///TFtdcVirementTradeCodeType是一个交易代码类型
    ///</summary>
    /// TThostFtdcVirementTradeCodeType 未被使用

    ///<summary>
    ///TFtdcPhotoTypeNameType是一个影像类型名称类型
    ///</summary>
    /// TThostFtdcPhotoTypeNameType 是基础类型

    ///<summary>
    ///TFtdcPhotoTypeIDType是一个影像类型代码类型
    ///</summary>
    /// TThostFtdcPhotoTypeIDType 是基础类型

    ///<summary>
    ///TFtdcPhotoNameType是一个影像名称类型
    ///</summary>
    /// TThostFtdcPhotoNameType 是基础类型

    ///<summary>
    ///TFtdcTopicIDType是一个主题代码类型
    ///</summary>
    /// TThostFtdcTopicIDType 是基础类型

    ///<summary>
    ///TFtdcReportTypeIDType是一个交易报告类型标识类型
    ///</summary>
    /// TThostFtdcReportTypeIDType 是基础类型

    ///<summary>
    ///TFtdcCharacterIDType是一个交易特征代码类型
    ///</summary>
    /// TThostFtdcCharacterIDType 是基础类型

    ///<summary>
    ///TFtdcAMLParamIDType是一个参数代码类型
    ///</summary>
    /// TThostFtdcAMLParamIDType 是基础类型

    ///<summary>
    ///TFtdcAMLInvestorTypeType是一个投资者类型类型
    ///</summary>
    /// TThostFtdcAMLInvestorTypeType 是基础类型

    ///<summary>
    ///TFtdcAMLIdCardTypeType是一个证件类型类型
    ///</summary>
    /// TThostFtdcAMLIdCardTypeType 是基础类型

    ///<summary>
    ///TFtdcAMLTradeDirectType是一个资金进出方向类型
    ///</summary>
    /// TThostFtdcAMLTradeDirectType 是基础类型

    ///<summary>
    ///TFtdcAMLTradeModelType是一个资金进出方式类型
    ///</summary>
    /// TThostFtdcAMLTradeModelType 是基础类型

    ///<summary>
    ///TFtdcAMLOpParamValueType是一个业务参数代码值类型
    ///</summary>
    /// TThostFtdcAMLOpParamValueType 是基础类型

    ///<summary>
    ///TFtdcAMLCustomerCardTypeType是一个客户身份证件/证明文件类型类型
    ///</summary>
    /// TThostFtdcAMLCustomerCardTypeType 是基础类型

    ///<summary>
    ///TFtdcAMLInstitutionNameType是一个金融机构网点名称类型
    ///</summary>
    /// TThostFtdcAMLInstitutionNameType 是基础类型

    ///<summary>
    ///TFtdcAMLDistrictIDType是一个金融机构网点所在地区行政区划代码类型
    ///</summary>
    /// TThostFtdcAMLDistrictIDType 是基础类型

    ///<summary>
    ///TFtdcAMLRelationShipType是一个金融机构网点与大额交易的关系类型
    ///</summary>
    /// TThostFtdcAMLRelationShipType 是基础类型

    ///<summary>
    ///TFtdcAMLInstitutionTypeType是一个金融机构网点代码类型类型
    ///</summary>
    /// TThostFtdcAMLInstitutionTypeType 是基础类型

    ///<summary>
    ///TFtdcAMLInstitutionIDType是一个金融机构网点代码类型
    ///</summary>
    /// TThostFtdcAMLInstitutionIDType 是基础类型

    ///<summary>
    ///TFtdcAMLAccountTypeType是一个账户类型类型
    ///</summary>
    /// TThostFtdcAMLAccountTypeType 是基础类型

    ///<summary>
    ///TFtdcAMLTradingTypeType是一个交易方式类型
    ///</summary>
    /// TThostFtdcAMLTradingTypeType 是基础类型

    ///<summary>
    ///TFtdcAMLTransactClassType是一个涉外收支交易分类与代码类型
    ///</summary>
    /// TThostFtdcAMLTransactClassType 是基础类型

    ///<summary>
    ///TFtdcAMLCapitalIOType是一个资金收付标识类型
    ///</summary>
    /// TThostFtdcAMLCapitalIOType 是基础类型

    ///<summary>
    ///TFtdcAMLSiteType是一个交易地点类型
    ///</summary>
    /// TThostFtdcAMLSiteType 是基础类型

    ///<summary>
    ///TFtdcAMLCapitalPurposeType是一个资金用途类型
    ///</summary>
    /// TThostFtdcAMLCapitalPurposeType 是基础类型

    ///<summary>
    ///TFtdcAMLReportTypeType是一个报文类型类型
    ///</summary>
    /// TThostFtdcAMLReportTypeType 是基础类型

    ///<summary>
    ///TFtdcAMLSerialNoType是一个编号类型
    ///</summary>
    /// TThostFtdcAMLSerialNoType 是基础类型

    ///<summary>
    ///TFtdcAMLStatusType是一个状态类型
    ///</summary>
    /// TThostFtdcAMLStatusType 是基础类型

    ///<summary>
    ///TFtdcAMLGenStatusType是一个Aml生成方式类型
    ///</summary>
    /// TThostFtdcAMLGenStatusType 未被使用

    ///<summary>
    ///TFtdcAMLSeqCodeType是一个业务标识号类型
    ///</summary>
    /// TThostFtdcAMLSeqCodeType 是基础类型

    ///<summary>
    ///TFtdcAMLFileNameType是一个AML文件名类型
    ///</summary>
    /// TThostFtdcAMLFileNameType 是基础类型

    ///<summary>
    ///TFtdcAMLMoneyType是一个反洗钱资金类型
    ///</summary>
    /// TThostFtdcAMLMoneyType 是基础类型

    ///<summary>
    ///TFtdcAMLFileAmountType是一个反洗钱资金类型
    ///</summary>
    /// TThostFtdcAMLFileAmountType 是基础类型

    ///<summary>
    ///TFtdcCFMMCKeyType是一个密钥类型(保证金监管)类型
    ///</summary>
    /// TThostFtdcCFMMCKeyType 是基础类型

    ///<summary>
    ///TFtdcCFMMCTokenType是一个令牌类型(保证金监管)类型
    ///</summary>
    /// TThostFtdcCFMMCTokenType 是基础类型

    ///<summary>
    ///TFtdcCFMMCKeyKindType是一个动态密钥类别(保证金监管)类型
    ///</summary>
    public static class CtpCFMMCKeyKindType
    {
        ///<summary>
        ///主动请求更新
        ///</summary>
        public const byte REQUEST = (byte)'R';
        ///<summary>
        ///CFMMC自动更新
        ///</summary>
        public const byte AUTO = (byte)'A';
        ///<summary>
        ///CFMMC手动更新
        ///</summary>
        public const byte MANUAL = (byte)'M';
    };

    ///<summary>
    ///TFtdcAMLReportNameType是一个报文名称类型
    ///</summary>
    /// TThostFtdcAMLReportNameType 是基础类型

    ///<summary>
    ///TFtdcIndividualNameType是一个个人姓名类型
    ///</summary>
    /// TThostFtdcIndividualNameType 是基础类型

    ///<summary>
    ///TFtdcCurrencyIDType是一个币种代码类型
    ///</summary>
    /// TThostFtdcCurrencyIDType 是基础类型

    ///<summary>
    ///TFtdcCustNumberType是一个客户编号类型
    ///</summary>
    /// TThostFtdcCustNumberType 是基础类型

    ///<summary>
    ///TFtdcOrganCodeType是一个机构编码类型
    ///</summary>
    /// TThostFtdcOrganCodeType 是基础类型

    ///<summary>
    ///TFtdcOrganNameType是一个机构名称类型
    ///</summary>
    /// TThostFtdcOrganNameType 是基础类型

    ///<summary>
    ///TFtdcSuperOrganCodeType是一个上级机构编码,即期货公司总部、银行总行类型
    ///</summary>
    /// TThostFtdcSuperOrganCodeType 是基础类型

    ///<summary>
    ///TFtdcSubBranchIDType是一个分支机构类型
    ///</summary>
    /// TThostFtdcSubBranchIDType 是基础类型

    ///<summary>
    ///TFtdcSubBranchNameType是一个分支机构名称类型
    ///</summary>
    /// TThostFtdcSubBranchNameType 是基础类型

    ///<summary>
    ///TFtdcBranchNetCodeType是一个机构网点号类型
    ///</summary>
    /// TThostFtdcBranchNetCodeType 是基础类型

    ///<summary>
    ///TFtdcBranchNetNameType是一个机构网点名称类型
    ///</summary>
    /// TThostFtdcBranchNetNameType 是基础类型

    ///<summary>
    ///TFtdcOrganFlagType是一个机构标识类型
    ///</summary>
    /// TThostFtdcOrganFlagType 是基础类型

    ///<summary>
    ///TFtdcBankCodingForFutureType是一个银行对期货公司的编码类型
    ///</summary>
    /// TThostFtdcBankCodingForFutureType 是基础类型

    ///<summary>
    ///TFtdcBankReturnCodeType是一个银行对返回码的定义类型
    ///</summary>
    /// TThostFtdcBankReturnCodeType 是基础类型

    ///<summary>
    ///TFtdcPlateReturnCodeType是一个银期转帐平台对返回码的定义类型
    ///</summary>
    /// TThostFtdcPlateReturnCodeType 是基础类型

    ///<summary>
    ///TFtdcBankSubBranchIDType是一个银行分支机构编码类型
    ///</summary>
    /// TThostFtdcBankSubBranchIDType 是基础类型

    ///<summary>
    ///TFtdcFutureBranchIDType是一个期货分支机构编码类型
    ///</summary>
    /// TThostFtdcFutureBranchIDType 是基础类型

    ///<summary>
    ///TFtdcReturnCodeType是一个返回代码类型
    ///</summary>
    /// TThostFtdcReturnCodeType 是基础类型

    ///<summary>
    ///TFtdcOperatorCodeType是一个操作员类型
    ///</summary>
    /// TThostFtdcOperatorCodeType 是基础类型

    ///<summary>
    ///TFtdcClearDepIDType是一个机构结算帐户机构号类型
    ///</summary>
    /// TThostFtdcClearDepIDType 是基础类型

    ///<summary>
    ///TFtdcClearBrchIDType是一个机构结算帐户联行号类型
    ///</summary>
    /// TThostFtdcClearBrchIDType 是基础类型

    ///<summary>
    ///TFtdcClearNameType是一个机构结算帐户名称类型
    ///</summary>
    /// TThostFtdcClearNameType 是基础类型

    ///<summary>
    ///TFtdcBankAccountNameType是一个银行帐户名称类型
    ///</summary>
    /// TThostFtdcBankAccountNameType 是基础类型

    ///<summary>
    ///TFtdcInvDepIDType是一个机构投资人账号机构号类型
    ///</summary>
    /// TThostFtdcInvDepIDType 是基础类型

    ///<summary>
    ///TFtdcInvBrchIDType是一个机构投资人联行号类型
    ///</summary>
    /// TThostFtdcInvBrchIDType 是基础类型

    ///<summary>
    ///TFtdcMessageFormatVersionType是一个信息格式版本类型
    ///</summary>
    /// TThostFtdcMessageFormatVersionType 是基础类型

    ///<summary>
    ///TFtdcDigestType是一个摘要类型
    ///</summary>
    /// TThostFtdcDigestType 是基础类型

    ///<summary>
    ///TFtdcAuthenticDataType是一个认证数据类型
    ///</summary>
    /// TThostFtdcAuthenticDataType 是基础类型

    ///<summary>
    ///TFtdcPasswordKeyType是一个密钥类型
    ///</summary>
    /// TThostFtdcPasswordKeyType 是基础类型

    ///<summary>
    ///TFtdcFutureAccountNameType是一个期货帐户名称类型
    ///</summary>
    /// TThostFtdcFutureAccountNameType 是基础类型

    ///<summary>
    ///TFtdcMobilePhoneType是一个手机类型
    ///</summary>
    /// TThostFtdcMobilePhoneType 是基础类型

    ///<summary>
    ///TFtdcFutureMainKeyType是一个期货公司主密钥类型
    ///</summary>
    /// TThostFtdcFutureMainKeyType 是基础类型

    ///<summary>
    ///TFtdcFutureWorkKeyType是一个期货公司工作密钥类型
    ///</summary>
    /// TThostFtdcFutureWorkKeyType 是基础类型

    ///<summary>
    ///TFtdcFutureTransKeyType是一个期货公司传输密钥类型
    ///</summary>
    /// TThostFtdcFutureTransKeyType 是基础类型

    ///<summary>
    ///TFtdcBankMainKeyType是一个银行主密钥类型
    ///</summary>
    /// TThostFtdcBankMainKeyType 是基础类型

    ///<summary>
    ///TFtdcBankWorkKeyType是一个银行工作密钥类型
    ///</summary>
    /// TThostFtdcBankWorkKeyType 是基础类型

    ///<summary>
    ///TFtdcBankTransKeyType是一个银行传输密钥类型
    ///</summary>
    /// TThostFtdcBankTransKeyType 是基础类型

    ///<summary>
    ///TFtdcBankServerDescriptionType是一个银行服务器描述信息类型
    ///</summary>
    /// TThostFtdcBankServerDescriptionType 是基础类型

    ///<summary>
    ///TFtdcAddInfoType是一个附加信息类型
    ///</summary>
    /// TThostFtdcAddInfoType 是基础类型

    ///<summary>
    ///TFtdcDescrInfoForReturnCodeType是一个返回码描述类型
    ///</summary>
    /// TThostFtdcDescrInfoForReturnCodeType 是基础类型

    ///<summary>
    ///TFtdcCountryCodeType是一个国家代码类型
    ///</summary>
    /// TThostFtdcCountryCodeType 是基础类型

    ///<summary>
    ///TFtdcSerialType是一个流水号类型
    ///</summary>
    /// TThostFtdcSerialType 是基础类型

    ///<summary>
    ///TFtdcPlateSerialType是一个平台流水号类型
    ///</summary>
    /// TThostFtdcPlateSerialType 是基础类型

    ///<summary>
    ///TFtdcBankSerialType是一个银行流水号类型
    ///</summary>
    /// TThostFtdcBankSerialType 是基础类型

    ///<summary>
    ///TFtdcCorrectSerialType是一个被冲正交易流水号类型
    ///</summary>
    /// TThostFtdcCorrectSerialType 是基础类型

    ///<summary>
    ///TFtdcFutureSerialType是一个期货公司流水号类型
    ///</summary>
    /// TThostFtdcFutureSerialType 是基础类型

    ///<summary>
    ///TFtdcApplicationIDType是一个应用标识类型
    ///</summary>
    /// TThostFtdcApplicationIDType 是基础类型

    ///<summary>
    ///TFtdcBankProxyIDType是一个银行代理标识类型
    ///</summary>
    /// TThostFtdcBankProxyIDType 是基础类型

    ///<summary>
    ///TFtdcFBTCoreIDType是一个银期转帐核心系统标识类型
    ///</summary>
    /// TThostFtdcFBTCoreIDType 是基础类型

    ///<summary>
    ///TFtdcServerPortType是一个服务端口号类型
    ///</summary>
    /// TThostFtdcServerPortType 是基础类型

    ///<summary>
    ///TFtdcRepealedTimesType是一个已经冲正次数类型
    ///</summary>
    /// TThostFtdcRepealedTimesType 是基础类型

    ///<summary>
    ///TFtdcRepealTimeIntervalType是一个冲正时间间隔类型
    ///</summary>
    /// TThostFtdcRepealTimeIntervalType 是基础类型

    ///<summary>
    ///TFtdcTotalTimesType是一个每日累计转帐次数类型
    ///</summary>
    /// TThostFtdcTotalTimesType 是基础类型

    ///<summary>
    ///TFtdcFBTRequestIDType是一个请求ID类型
    ///</summary>
    /// TThostFtdcFBTRequestIDType 是基础类型

    ///<summary>
    ///TFtdcTIDType是一个交易ID类型
    ///</summary>
    /// TThostFtdcTIDType 是基础类型

    ///<summary>
    ///TFtdcTradeAmountType是一个交易金额（元）类型
    ///</summary>
    /// TThostFtdcTradeAmountType 是基础类型

    ///<summary>
    ///TFtdcCustFeeType是一个应收客户费用（元）类型
    ///</summary>
    /// TThostFtdcCustFeeType 是基础类型

    ///<summary>
    ///TFtdcFutureFeeType是一个应收期货公司费用（元）类型
    ///</summary>
    /// TThostFtdcFutureFeeType 是基础类型

    ///<summary>
    ///TFtdcSingleMaxAmtType是一个单笔最高限额类型
    ///</summary>
    /// TThostFtdcSingleMaxAmtType 是基础类型

    ///<summary>
    ///TFtdcSingleMinAmtType是一个单笔最低限额类型
    ///</summary>
    /// TThostFtdcSingleMinAmtType 是基础类型

    ///<summary>
    ///TFtdcTotalAmtType是一个每日累计转帐额度类型
    ///</summary>
    /// TThostFtdcTotalAmtType 是基础类型

    ///<summary>
    ///TFtdcCertificationTypeType是一个证件类型类型
    ///</summary>
    /// TThostFtdcCertificationTypeType 未被使用

    ///<summary>
    ///TFtdcFileBusinessCodeType是一个文件业务功能类型
    ///</summary>
    public static class CtpFileBusinessCodeType
    {
        ///<summary>
        ///其他
        ///</summary>
        public const byte Others = (byte)'0';
        ///<summary>
        ///转账交易明细对账
        ///</summary>
        public const byte TransferDetails = (byte)'1';
        ///<summary>
        ///客户账户状态对账
        ///</summary>
        public const byte CustAccStatus = (byte)'2';
        ///<summary>
        ///账户类交易明细对账
        ///</summary>
        public const byte AccountTradeDetails = (byte)'3';
        ///<summary>
        ///期货账户信息变更明细对账
        ///</summary>
        public const byte FutureAccountChangeInfoDetails = (byte)'4';
        ///<summary>
        ///客户资金台账余额明细对账
        ///</summary>
        public const byte CustMoneyDetail = (byte)'5';
        ///<summary>
        ///客户销户结息明细对账
        ///</summary>
        public const byte CustCancelAccountInfo = (byte)'6';
        ///<summary>
        ///客户资金余额对账结果
        ///</summary>
        public const byte CustMoneyResult = (byte)'7';
        ///<summary>
        ///其它对账异常结果文件
        ///</summary>
        public const byte OthersExceptionResult = (byte)'8';
        ///<summary>
        ///客户结息净额明细
        ///</summary>
        public const byte CustInterestNetMoneyDetails = (byte)'9';
        ///<summary>
        ///客户资金交收明细
        ///</summary>
        public const byte CustMoneySendAndReceiveDetails = (byte)'a';
        ///<summary>
        ///法人存管银行资金交收汇总
        ///</summary>
        public const byte CorporationMoneyTotal = (byte)'b';
        ///<summary>
        ///主体间资金交收汇总
        ///</summary>
        public const byte MainbodyMoneyTotal = (byte)'c';
        ///<summary>
        ///总分平衡监管数据
        ///</summary>
        public const byte MainPartMonitorData = (byte)'d';
        ///<summary>
        ///存管银行备付金余额
        ///</summary>
        public const byte PreparationMoney = (byte)'e';
        ///<summary>
        ///协办存管银行资金监管数据
        ///</summary>
        public const byte BankMoneyMonitorData = (byte)'f';
    };

    ///<summary>
    ///TFtdcCashExchangeCodeType是一个汇钞标志类型
    ///</summary>
    public static class CtpCashExchangeCodeType
    {
        ///<summary>
        ///汇
        ///</summary>
        public const byte Exchange = (byte)'1';
        ///<summary>
        ///钞
        ///</summary>
        public const byte Cash = (byte)'2';
    };

    ///<summary>
    ///TFtdcYesNoIndicatorType是一个是或否标识类型
    ///</summary>
    public static class CtpYesNoIndicatorType
    {
        ///<summary>
        ///是
        ///</summary>
        public const byte Yes = (byte)'0';
        ///<summary>
        ///否
        ///</summary>
        public const byte No = (byte)'1';
    };

    ///<summary>
    ///TFtdcBanlanceTypeType是一个余额类型类型
    ///</summary>
    /// TThostFtdcBanlanceTypeType 未被使用

    ///<summary>
    ///TFtdcGenderType是一个性别类型
    ///</summary>
    public static class CtpGenderType
    {
        ///<summary>
        ///未知状态
        ///</summary>
        public const byte Unknown = (byte)'0';
        ///<summary>
        ///男
        ///</summary>
        public const byte Male = (byte)'1';
        ///<summary>
        ///女
        ///</summary>
        public const byte Female = (byte)'2';
    };

    ///<summary>
    ///TFtdcFeePayFlagType是一个费用支付标志类型
    ///</summary>
    public static class CtpFeePayFlagType
    {
        ///<summary>
        ///由受益方支付费用
        ///</summary>
        public const byte BEN = (byte)'0';
        ///<summary>
        ///由发送方支付费用
        ///</summary>
        public const byte OUR = (byte)'1';
        ///<summary>
        ///由发送方支付发起的费用，受益方支付接受的费用
        ///</summary>
        public const byte SHA = (byte)'2';
    };

    ///<summary>
    ///TFtdcPassWordKeyTypeType是一个密钥类型类型
    ///</summary>
    /// TThostFtdcPassWordKeyTypeType 未被使用

    ///<summary>
    ///TFtdcFBTPassWordTypeType是一个密码类型类型
    ///</summary>
    /// TThostFtdcFBTPassWordTypeType 未被使用

    ///<summary>
    ///TFtdcFBTEncryModeType是一个加密方式类型
    ///</summary>
    /// TThostFtdcFBTEncryModeType 未被使用

    ///<summary>
    ///TFtdcBankRepealFlagType是一个银行冲正标志类型
    ///</summary>
    public static class CtpBankRepealFlagType
    {
        ///<summary>
        ///银行无需自动冲正
        ///</summary>
        public const byte BankNotNeedRepeal = (byte)'0';
        ///<summary>
        ///银行待自动冲正
        ///</summary>
        public const byte BankWaitingRepeal = (byte)'1';
        ///<summary>
        ///银行已自动冲正
        ///</summary>
        public const byte BankBeenRepealed = (byte)'2';
    };

    ///<summary>
    ///TFtdcBrokerRepealFlagType是一个期商冲正标志类型
    ///</summary>
    public static class CtpBrokerRepealFlagType
    {
        ///<summary>
        ///期商无需自动冲正
        ///</summary>
        public const byte BrokerNotNeedRepeal = (byte)'0';
        ///<summary>
        ///期商待自动冲正
        ///</summary>
        public const byte BrokerWaitingRepeal = (byte)'1';
        ///<summary>
        ///期商已自动冲正
        ///</summary>
        public const byte BrokerBeenRepealed = (byte)'2';
    };

    ///<summary>
    ///TFtdcInstitutionTypeType是一个机构类别类型
    ///</summary>
    public static class CtpInstitutionTypeType
    {
        ///<summary>
        ///银行
        ///</summary>
        public const byte Bank = (byte)'0';
        ///<summary>
        ///期商
        ///</summary>
        public const byte Future = (byte)'1';
        ///<summary>
        ///券商
        ///</summary>
        public const byte Store = (byte)'2';
    };

    ///<summary>
    ///TFtdcLastFragmentType是一个最后分片标志类型
    ///</summary>
    public static class CtpLastFragmentType
    {
        ///<summary>
        ///是最后分片
        ///</summary>
        public const byte Yes = (byte)'0';
        ///<summary>
        ///不是最后分片
        ///</summary>
        public const byte No = (byte)'1';
    };

    ///<summary>
    ///TFtdcBankAccStatusType是一个银行账户状态类型
    ///</summary>
    /// TThostFtdcBankAccStatusType 未被使用

    ///<summary>
    ///TFtdcMoneyAccountStatusType是一个资金账户状态类型
    ///</summary>
    public static class CtpMoneyAccountStatusType
    {
        ///<summary>
        ///正常
        ///</summary>
        public const byte Normal = (byte)'0';
        ///<summary>
        ///销户
        ///</summary>
        public const byte Cancel = (byte)'1';
    };

    ///<summary>
    ///TFtdcManageStatusType是一个存管状态类型
    ///</summary>
    /// TThostFtdcManageStatusType 未被使用

    ///<summary>
    ///TFtdcSystemTypeType是一个应用系统类型类型
    ///</summary>
    /// TThostFtdcSystemTypeType 未被使用

    ///<summary>
    ///TFtdcTxnEndFlagType是一个银期转帐划转结果标志类型
    ///</summary>
    /// TThostFtdcTxnEndFlagType 未被使用

    ///<summary>
    ///TFtdcProcessStatusType是一个银期转帐服务处理状态类型
    ///</summary>
    /// TThostFtdcProcessStatusType 未被使用

    ///<summary>
    ///TFtdcCustTypeType是一个客户类型类型
    ///</summary>
    public static class CtpCustTypeType
    {
        ///<summary>
        ///自然人
        ///</summary>
        public const byte Person = (byte)'0';
        ///<summary>
        ///机构户
        ///</summary>
        public const byte Institution = (byte)'1';
    };

    ///<summary>
    ///TFtdcFBTTransferDirectionType是一个银期转帐方向类型
    ///</summary>
    /// TThostFtdcFBTTransferDirectionType 未被使用

    ///<summary>
    ///TFtdcOpenOrDestroyType是一个开销户类别类型
    ///</summary>
    public static class CtpOpenOrDestroyType
    {
        ///<summary>
        ///开户
        ///</summary>
        public const byte Open = (byte)'1';
        ///<summary>
        ///销户
        ///</summary>
        public const byte Destroy = (byte)'0';
    };

    ///<summary>
    ///TFtdcAvailabilityFlagType是一个有效标志类型
    ///</summary>
    public static class CtpAvailabilityFlagType
    {
        ///<summary>
        ///未确认
        ///</summary>
        public const byte Invalid = (byte)'0';
        ///<summary>
        ///有效
        ///</summary>
        public const byte Valid = (byte)'1';
        ///<summary>
        ///冲正
        ///</summary>
        public const byte Repeal = (byte)'2';
    };

    ///<summary>
    ///TFtdcOrganTypeType是一个机构类型类型
    ///</summary>
    /// TThostFtdcOrganTypeType 未被使用

    ///<summary>
    ///TFtdcOrganLevelType是一个机构级别类型
    ///</summary>
    /// TThostFtdcOrganLevelType 未被使用

    ///<summary>
    ///TFtdcProtocalIDType是一个协议类型类型
    ///</summary>
    /// TThostFtdcProtocalIDType 未被使用

    ///<summary>
    ///TFtdcConnectModeType是一个套接字连接方式类型
    ///</summary>
    /// TThostFtdcConnectModeType 未被使用

    ///<summary>
    ///TFtdcSyncModeType是一个套接字通信方式类型
    ///</summary>
    /// TThostFtdcSyncModeType 未被使用

    ///<summary>
    ///TFtdcBankAccTypeType是一个银行帐号类型类型
    ///</summary>
    public static class CtpBankAccTypeType
    {
        ///<summary>
        ///银行存折
        ///</summary>
        public const byte BankBook = (byte)'1';
        ///<summary>
        ///储蓄卡
        ///</summary>
        public const byte SavingCard = (byte)'2';
        ///<summary>
        ///信用卡
        ///</summary>
        public const byte CreditCard = (byte)'3';
    };

    ///<summary>
    ///TFtdcFutureAccTypeType是一个期货公司帐号类型类型
    ///</summary>
    public static class CtpFutureAccTypeType
    {
        ///<summary>
        ///银行存折
        ///</summary>
        public const byte BankBook = (byte)'1';
        ///<summary>
        ///储蓄卡
        ///</summary>
        public const byte SavingCard = (byte)'2';
        ///<summary>
        ///信用卡
        ///</summary>
        public const byte CreditCard = (byte)'3';
    };

    ///<summary>
    ///TFtdcOrganStatusType是一个接入机构状态类型
    ///</summary>
    /// TThostFtdcOrganStatusType 未被使用

    ///<summary>
    ///TFtdcCCBFeeModeType是一个建行收费模式类型
    ///</summary>
    /// TThostFtdcCCBFeeModeType 未被使用

    ///<summary>
    ///TFtdcCommApiTypeType是一个通讯API类型类型
    ///</summary>
    /// TThostFtdcCommApiTypeType 未被使用

    ///<summary>
    ///TFtdcServiceIDType是一个服务编号类型
    ///</summary>
    /// TThostFtdcServiceIDType 是基础类型

    ///<summary>
    ///TFtdcServiceLineNoType是一个服务线路编号类型
    ///</summary>
    /// TThostFtdcServiceLineNoType 是基础类型

    ///<summary>
    ///TFtdcServiceNameType是一个服务名类型
    ///</summary>
    /// TThostFtdcServiceNameType 是基础类型

    ///<summary>
    ///TFtdcLinkStatusType是一个连接状态类型
    ///</summary>
    /// TThostFtdcLinkStatusType 未被使用

    ///<summary>
    ///TFtdcCommApiPointerType是一个通讯API指针类型
    ///</summary>
    /// TThostFtdcCommApiPointerType 是基础类型

    ///<summary>
    ///TFtdcPwdFlagType是一个密码核对标志类型
    ///</summary>
    public static class CtpPwdFlagType
    {
        ///<summary>
        ///不核对
        ///</summary>
        public const byte NoCheck = (byte)'0';
        ///<summary>
        ///明文核对
        ///</summary>
        public const byte BlankCheck = (byte)'1';
        ///<summary>
        ///密文核对
        ///</summary>
        public const byte EncryptCheck = (byte)'2';
    };

    ///<summary>
    ///TFtdcSecuAccTypeType是一个期货帐号类型类型
    ///</summary>
    /// TThostFtdcSecuAccTypeType 未被使用

    ///<summary>
    ///TFtdcTransferStatusType是一个转账交易状态类型
    ///</summary>
    public static class CtpTransferStatusType
    {
        ///<summary>
        ///正常
        ///</summary>
        public const byte Normal = (byte)'0';
        ///<summary>
        ///被冲正
        ///</summary>
        public const byte Repealed = (byte)'1';
    };

    ///<summary>
    ///TFtdcSponsorTypeType是一个发起方类型
    ///</summary>
    /// TThostFtdcSponsorTypeType 未被使用

    ///<summary>
    ///TFtdcReqRspTypeType是一个请求响应类别类型
    ///</summary>
    /// TThostFtdcReqRspTypeType 未被使用

    ///<summary>
    ///TFtdcFBTUserEventTypeType是一个银期转帐用户事件类型类型
    ///</summary>
    /// TThostFtdcFBTUserEventTypeType 未被使用

    ///<summary>
    ///TFtdcBankIDByBankType是一个银行自己的编码类型
    ///</summary>
    /// TThostFtdcBankIDByBankType 是基础类型

    ///<summary>
    ///TFtdcBankOperNoType是一个银行操作员号类型
    ///</summary>
    /// TThostFtdcBankOperNoType 是基础类型

    ///<summary>
    ///TFtdcBankCustNoType是一个银行客户号类型
    ///</summary>
    /// TThostFtdcBankCustNoType 是基础类型

    ///<summary>
    ///TFtdcDBOPSeqNoType是一个递增的序列号类型
    ///</summary>
    /// TThostFtdcDBOPSeqNoType 是基础类型

    ///<summary>
    ///TFtdcTableNameType是一个FBT表名类型
    ///</summary>
    /// TThostFtdcTableNameType 是基础类型

    ///<summary>
    ///TFtdcPKNameType是一个FBT表操作主键名类型
    ///</summary>
    /// TThostFtdcPKNameType 是基础类型

    ///<summary>
    ///TFtdcPKValueType是一个FBT表操作主键值类型
    ///</summary>
    /// TThostFtdcPKValueType 是基础类型

    ///<summary>
    ///TFtdcDBOperationType是一个记录操作类型类型
    ///</summary>
    /// TThostFtdcDBOperationType 未被使用

    ///<summary>
    ///TFtdcSyncFlagType是一个同步标记类型
    ///</summary>
    /// TThostFtdcSyncFlagType 未被使用

    ///<summary>
    ///TFtdcTargetIDType是一个同步目标编号类型
    ///</summary>
    /// TThostFtdcTargetIDType 是基础类型

    ///<summary>
    ///TFtdcSyncTypeType是一个同步类型类型
    ///</summary>
    /// TThostFtdcSyncTypeType 未被使用

    ///<summary>
    ///TFtdcFBETimeType是一个各种换汇时间类型
    ///</summary>
    /// TThostFtdcFBETimeType 是基础类型

    ///<summary>
    ///TFtdcFBEBankNoType是一个换汇银行行号类型
    ///</summary>
    /// TThostFtdcFBEBankNoType 是基础类型

    ///<summary>
    ///TFtdcFBECertNoType是一个换汇凭证号类型
    ///</summary>
    /// TThostFtdcFBECertNoType 是基础类型

    ///<summary>
    ///TFtdcExDirectionType是一个换汇方向类型
    ///</summary>
    /// TThostFtdcExDirectionType 未被使用

    ///<summary>
    ///TFtdcFBEBankAccountType是一个换汇银行账户类型
    ///</summary>
    /// TThostFtdcFBEBankAccountType 是基础类型

    ///<summary>
    ///TFtdcFBEBankAccountNameType是一个换汇银行账户名类型
    ///</summary>
    /// TThostFtdcFBEBankAccountNameType 是基础类型

    ///<summary>
    ///TFtdcFBEAmtType是一个各种换汇金额类型
    ///</summary>
    /// TThostFtdcFBEAmtType 是基础类型

    ///<summary>
    ///TFtdcFBEBusinessTypeType是一个换汇业务类型类型
    ///</summary>
    /// TThostFtdcFBEBusinessTypeType 是基础类型

    ///<summary>
    ///TFtdcFBEPostScriptType是一个换汇附言类型
    ///</summary>
    /// TThostFtdcFBEPostScriptType 是基础类型

    ///<summary>
    ///TFtdcFBERemarkType是一个换汇备注类型
    ///</summary>
    /// TThostFtdcFBERemarkType 是基础类型

    ///<summary>
    ///TFtdcExRateType是一个换汇汇率类型
    ///</summary>
    /// TThostFtdcExRateType 是基础类型

    ///<summary>
    ///TFtdcFBEResultFlagType是一个换汇成功标志类型
    ///</summary>
    /// TThostFtdcFBEResultFlagType 未被使用

    ///<summary>
    ///TFtdcFBERtnMsgType是一个换汇返回信息类型
    ///</summary>
    /// TThostFtdcFBERtnMsgType 是基础类型

    ///<summary>
    ///TFtdcFBEExtendMsgType是一个换汇扩展信息类型
    ///</summary>
    /// TThostFtdcFBEExtendMsgType 是基础类型

    ///<summary>
    ///TFtdcFBEBusinessSerialType是一个换汇记账流水号类型
    ///</summary>
    /// TThostFtdcFBEBusinessSerialType 是基础类型

    ///<summary>
    ///TFtdcFBESystemSerialType是一个换汇流水号类型
    ///</summary>
    /// TThostFtdcFBESystemSerialType 是基础类型

    ///<summary>
    ///TFtdcFBETotalExCntType是一个换汇交易总笔数类型
    ///</summary>
    /// TThostFtdcFBETotalExCntType 是基础类型

    ///<summary>
    ///TFtdcFBEExchStatusType是一个换汇交易状态类型
    ///</summary>
    /// TThostFtdcFBEExchStatusType 未被使用

    ///<summary>
    ///TFtdcFBEFileFlagType是一个换汇文件标志类型
    ///</summary>
    /// TThostFtdcFBEFileFlagType 未被使用

    ///<summary>
    ///TFtdcFBEAlreadyTradeType是一个换汇已交易标志类型
    ///</summary>
    /// TThostFtdcFBEAlreadyTradeType 未被使用

    ///<summary>
    ///TFtdcFBEOpenBankType是一个换汇账户开户行类型
    ///</summary>
    /// TThostFtdcFBEOpenBankType 是基础类型

    ///<summary>
    ///TFtdcFBEUserEventTypeType是一个银期换汇用户事件类型类型
    ///</summary>
    /// TThostFtdcFBEUserEventTypeType 未被使用

    ///<summary>
    ///TFtdcFBEFileNameType是一个换汇相关文件名类型
    ///</summary>
    /// TThostFtdcFBEFileNameType 是基础类型

    ///<summary>
    ///TFtdcFBEBatchSerialType是一个换汇批次号类型
    ///</summary>
    /// TThostFtdcFBEBatchSerialType 是基础类型

    ///<summary>
    ///TFtdcFBEReqFlagType是一个换汇发送标志类型
    ///</summary>
    /// TThostFtdcFBEReqFlagType 未被使用

    ///<summary>
    ///TFtdcNotifyClassType是一个风险通知类型类型
    ///</summary>
    /// TThostFtdcNotifyClassType 未被使用

    ///<summary>
    ///TFtdcRiskNofityInfoType是一个客户风险通知消息类型
    ///</summary>
    /// TThostFtdcRiskNofityInfoType 是基础类型

    ///<summary>
    ///TFtdcForceCloseSceneIdType是一个强平场景编号类型
    ///</summary>
    /// TThostFtdcForceCloseSceneIdType 是基础类型

    ///<summary>
    ///TFtdcForceCloseTypeType是一个强平单类型类型
    ///</summary>
    /// TThostFtdcForceCloseTypeType 未被使用

    ///<summary>
    ///TFtdcInstrumentIDsType是一个多个产品代码,用+分隔,如cu+zn类型
    ///</summary>
    /// TThostFtdcInstrumentIDsType 是基础类型

    ///<summary>
    ///TFtdcRiskNotifyMethodType是一个风险通知途径类型
    ///</summary>
    /// TThostFtdcRiskNotifyMethodType 未被使用

    ///<summary>
    ///TFtdcRiskNotifyStatusType是一个风险通知状态类型
    ///</summary>
    /// TThostFtdcRiskNotifyStatusType 未被使用

    ///<summary>
    ///TFtdcRiskUserEventType是一个风控用户操作事件类型
    ///</summary>
    /// TThostFtdcRiskUserEventType 未被使用

    ///<summary>
    ///TFtdcParamIDType是一个参数代码类型
    ///</summary>
    /// TThostFtdcParamIDType 是基础类型

    ///<summary>
    ///TFtdcParamNameType是一个参数名类型
    ///</summary>
    /// TThostFtdcParamNameType 是基础类型

    ///<summary>
    ///TFtdcParamValueType是一个参数值类型
    ///</summary>
    /// TThostFtdcParamValueType 是基础类型

    ///<summary>
    ///TFtdcConditionalOrderSortTypeType是一个条件单索引条件类型
    ///</summary>
    /// TThostFtdcConditionalOrderSortTypeType 未被使用

    ///<summary>
    ///TFtdcSendTypeType是一个报送状态类型
    ///</summary>
    /// TThostFtdcSendTypeType 未被使用

    ///<summary>
    ///TFtdcClientIDStatusType是一个交易编码状态类型
    ///</summary>
    /// TThostFtdcClientIDStatusType 未被使用

    ///<summary>
    ///TFtdcIndustryIDType是一个行业编码类型
    ///</summary>
    /// TThostFtdcIndustryIDType 是基础类型

    ///<summary>
    ///TFtdcQuestionIDType是一个特有信息编号类型
    ///</summary>
    /// TThostFtdcQuestionIDType 是基础类型

    ///<summary>
    ///TFtdcQuestionContentType是一个特有信息说明类型
    ///</summary>
    /// TThostFtdcQuestionContentType 是基础类型

    ///<summary>
    ///TFtdcOptionIDType是一个选项编号类型
    ///</summary>
    /// TThostFtdcOptionIDType 是基础类型

    ///<summary>
    ///TFtdcOptionContentType是一个选项说明类型
    ///</summary>
    /// TThostFtdcOptionContentType 是基础类型

    ///<summary>
    ///TFtdcQuestionTypeType是一个特有信息类型类型
    ///</summary>
    /// TThostFtdcQuestionTypeType 未被使用

    ///<summary>
    ///TFtdcProcessIDType是一个业务流水号类型
    ///</summary>
    /// TThostFtdcProcessIDType 是基础类型

    ///<summary>
    ///TFtdcSeqNoType是一个流水号类型
    ///</summary>
    /// TThostFtdcSeqNoType 是基础类型

    ///<summary>
    ///TFtdcUOAProcessStatusType是一个流程状态类型
    ///</summary>
    /// TThostFtdcUOAProcessStatusType 是基础类型

    ///<summary>
    ///TFtdcProcessTypeType是一个流程功能类型类型
    ///</summary>
    /// TThostFtdcProcessTypeType 是基础类型

    ///<summary>
    ///TFtdcBusinessTypeType是一个业务类型类型
    ///</summary>
    /// TThostFtdcBusinessTypeType 未被使用

    ///<summary>
    ///TFtdcCfmmcReturnCodeType是一个监控中心返回码类型
    ///</summary>
    /// TThostFtdcCfmmcReturnCodeType 未被使用

    ///<summary>
    ///TFtdcExReturnCodeType是一个交易所返回码类型
    ///</summary>
    /// TThostFtdcExReturnCodeType 是基础类型

    ///<summary>
    ///TFtdcClientTypeType是一个客户类型类型
    ///</summary>
    /// TThostFtdcClientTypeType 未被使用

    ///<summary>
    ///TFtdcExchangeIDTypeType是一个交易所编号类型
    ///</summary>
    /// TThostFtdcExchangeIDTypeType 未被使用

    ///<summary>
    ///TFtdcExClientIDTypeType是一个交易编码类型类型
    ///</summary>
    /// TThostFtdcExClientIDTypeType 未被使用

    ///<summary>
    ///TFtdcClientClassifyType是一个客户分类码类型
    ///</summary>
    /// TThostFtdcClientClassifyType 是基础类型

    ///<summary>
    ///TFtdcUOAOrganTypeType是一个单位性质类型
    ///</summary>
    /// TThostFtdcUOAOrganTypeType 是基础类型

    ///<summary>
    ///TFtdcUOACountryCodeType是一个国家代码类型
    ///</summary>
    /// TThostFtdcUOACountryCodeType 是基础类型

    ///<summary>
    ///TFtdcAreaCodeType是一个区号类型
    ///</summary>
    /// TThostFtdcAreaCodeType 是基础类型

    ///<summary>
    ///TFtdcFuturesIDType是一个监控中心为客户分配的代码类型
    ///</summary>
    /// TThostFtdcFuturesIDType 是基础类型

    ///<summary>
    ///TFtdcCffmcDateType是一个日期类型
    ///</summary>
    /// TThostFtdcCffmcDateType 是基础类型

    ///<summary>
    ///TFtdcCffmcTimeType是一个时间类型
    ///</summary>
    /// TThostFtdcCffmcTimeType 是基础类型

    ///<summary>
    ///TFtdcNocIDType是一个组织机构代码类型
    ///</summary>
    /// TThostFtdcNocIDType 是基础类型

    ///<summary>
    ///TFtdcUpdateFlagType是一个更新状态类型
    ///</summary>
    /// TThostFtdcUpdateFlagType 未被使用

    ///<summary>
    ///TFtdcApplyOperateIDType是一个申请动作类型
    ///</summary>
    /// TThostFtdcApplyOperateIDType 未被使用

    ///<summary>
    ///TFtdcApplyStatusIDType是一个申请状态类型
    ///</summary>
    /// TThostFtdcApplyStatusIDType 未被使用

    ///<summary>
    ///TFtdcSendMethodType是一个发送方式类型
    ///</summary>
    /// TThostFtdcSendMethodType 未被使用

    ///<summary>
    ///TFtdcEventTypeType是一个业务操作类型类型
    ///</summary>
    /// TThostFtdcEventTypeType 是基础类型

    ///<summary>
    ///TFtdcEventModeType是一个操作方法类型
    ///</summary>
    /// TThostFtdcEventModeType 未被使用

    ///<summary>
    ///TFtdcUOAAutoSendType是一个统一开户申请自动发送类型
    ///</summary>
    /// TThostFtdcUOAAutoSendType 未被使用

    ///<summary>
    ///TFtdcQueryDepthType是一个查询深度类型
    ///</summary>
    /// TThostFtdcQueryDepthType 是基础类型

    ///<summary>
    ///TFtdcDataCenterIDType是一个数据中心代码类型
    ///</summary>
    /// TThostFtdcDataCenterIDType 是基础类型

    ///<summary>
    ///TFtdcFlowIDType是一个流程ID类型
    ///</summary>
    /// TThostFtdcFlowIDType 未被使用

    ///<summary>
    ///TFtdcCheckLevelType是一个复核级别类型
    ///</summary>
    /// TThostFtdcCheckLevelType 未被使用

    ///<summary>
    ///TFtdcCheckNoType是一个操作次数类型
    ///</summary>
    /// TThostFtdcCheckNoType 是基础类型

    ///<summary>
    ///TFtdcCheckStatusType是一个复核级别类型
    ///</summary>
    /// TThostFtdcCheckStatusType 未被使用

    ///<summary>
    ///TFtdcUsedStatusType是一个生效状态类型
    ///</summary>
    /// TThostFtdcUsedStatusType 未被使用

    ///<summary>
    ///TFtdcRateTemplateNameType是一个模型名称类型
    ///</summary>
    /// TThostFtdcRateTemplateNameType 是基础类型

    ///<summary>
    ///TFtdcPropertyStringType是一个用于查询的投资属性字段类型
    ///</summary>
    /// TThostFtdcPropertyStringType 是基础类型

    ///<summary>
    ///TFtdcBankAcountOriginType是一个账户来源类型
    ///</summary>
    /// TThostFtdcBankAcountOriginType 未被使用

    ///<summary>
    ///TFtdcMonthBillTradeSumType是一个结算单月报成交汇总方式类型
    ///</summary>
    /// TThostFtdcMonthBillTradeSumType 未被使用

    ///<summary>
    ///TFtdcFBTTradeCodeEnumType是一个银期交易代码枚举类型
    ///</summary>
    /// TThostFtdcFBTTradeCodeEnumType 未被使用

    ///<summary>
    ///TFtdcRateTemplateIDType是一个模型代码类型
    ///</summary>
    /// TThostFtdcRateTemplateIDType 是基础类型

    ///<summary>
    ///TFtdcRiskRateType是一个风险度类型
    ///</summary>
    /// TThostFtdcRiskRateType 是基础类型

    ///<summary>
    ///TFtdcTimestampType是一个时间戳类型
    ///</summary>
    /// TThostFtdcTimestampType 是基础类型

    ///<summary>
    ///TFtdcInvestorIDRuleNameType是一个号段规则名称类型
    ///</summary>
    /// TThostFtdcInvestorIDRuleNameType 是基础类型

    ///<summary>
    ///TFtdcInvestorIDRuleExprType是一个号段规则表达式类型
    ///</summary>
    /// TThostFtdcInvestorIDRuleExprType 是基础类型

    ///<summary>
    ///TFtdcLastDriftType是一个上次OTP漂移值类型
    ///</summary>
    /// TThostFtdcLastDriftType 是基础类型

    ///<summary>
    ///TFtdcLastSuccessType是一个上次OTP成功值类型
    ///</summary>
    /// TThostFtdcLastSuccessType 是基础类型

    ///<summary>
    ///TFtdcAuthKeyType是一个令牌密钥类型
    ///</summary>
    /// TThostFtdcAuthKeyType 是基础类型

    ///<summary>
    ///TFtdcSerialNumberType是一个序列号类型
    ///</summary>
    /// TThostFtdcSerialNumberType 是基础类型

    ///<summary>
    ///TFtdcOTPTypeType是一个动态令牌类型类型
    ///</summary>
    public static class CtpOTPTypeType
    {
        ///<summary>
        ///无动态令牌
        ///</summary>
        public const byte NONE = (byte)'0';
        ///<summary>
        ///时间令牌
        ///</summary>
        public const byte TOTP = (byte)'1';
    };

    ///<summary>
    ///TFtdcOTPVendorsIDType是一个动态令牌提供商类型
    ///</summary>
    /// TThostFtdcOTPVendorsIDType 是基础类型

    ///<summary>
    ///TFtdcOTPVendorsNameType是一个动态令牌提供商名称类型
    ///</summary>
    /// TThostFtdcOTPVendorsNameType 是基础类型

    ///<summary>
    ///TFtdcOTPStatusType是一个动态令牌状态类型
    ///</summary>
    /// TThostFtdcOTPStatusType 未被使用

    ///<summary>
    ///TFtdcBrokerUserTypeType是一个经济公司用户类型类型
    ///</summary>
    /// TThostFtdcBrokerUserTypeType 未被使用

    ///<summary>
    ///TFtdcFutureTypeType是一个期货类型类型
    ///</summary>
    /// TThostFtdcFutureTypeType 未被使用

    ///<summary>
    ///TFtdcFundEventTypeType是一个资金管理操作类型类型
    ///</summary>
    /// TThostFtdcFundEventTypeType 未被使用

    ///<summary>
    ///TFtdcAccountSourceTypeType是一个资金账户来源类型
    ///</summary>
    /// TThostFtdcAccountSourceTypeType 未被使用

    ///<summary>
    ///TFtdcCodeSourceTypeType是一个交易编码来源类型
    ///</summary>
    /// TThostFtdcCodeSourceTypeType 未被使用

    ///<summary>
    ///TFtdcUserRangeType是一个操作员范围类型
    ///</summary>
    /// TThostFtdcUserRangeType 未被使用

    ///<summary>
    ///TFtdcTimeSpanType是一个时间跨度类型
    ///</summary>
    /// TThostFtdcTimeSpanType 是基础类型

    ///<summary>
    ///TFtdcImportSequenceIDType是一个动态令牌导入批次编号类型
    ///</summary>
    /// TThostFtdcImportSequenceIDType 是基础类型

    ///<summary>
    ///TFtdcByGroupType是一个交易统计表按客户统计方式类型
    ///</summary>
    /// TThostFtdcByGroupType 未被使用

    ///<summary>
    ///TFtdcTradeSumStatModeType是一个交易统计表按范围统计方式类型
    ///</summary>
    /// TThostFtdcTradeSumStatModeType 未被使用

    ///<summary>
    ///TFtdcComTypeType是一个组合成交类型类型
    ///</summary>
    /// TThostFtdcComTypeType 是基础类型

    ///<summary>
    ///TFtdcUserProductIDType是一个产品标识类型
    ///</summary>
    /// TThostFtdcUserProductIDType 是基础类型

    ///<summary>
    ///TFtdcUserProductNameType是一个产品名称类型
    ///</summary>
    /// TThostFtdcUserProductNameType 是基础类型

    ///<summary>
    ///TFtdcUserProductMemoType是一个产品说明类型
    ///</summary>
    /// TThostFtdcUserProductMemoType 是基础类型

    ///<summary>
    ///TFtdcCSRCCancelFlagType是一个新增或变更标志类型
    ///</summary>
    /// TThostFtdcCSRCCancelFlagType 是基础类型

    ///<summary>
    ///TFtdcCSRCDateType是一个日期类型
    ///</summary>
    /// TThostFtdcCSRCDateType 是基础类型

    ///<summary>
    ///TFtdcCSRCInvestorNameType是一个客户名称类型
    ///</summary>
    /// TThostFtdcCSRCInvestorNameType 是基础类型

    ///<summary>
    ///TFtdcCSRCOpenInvestorNameType是一个客户名称类型
    ///</summary>
    /// TThostFtdcCSRCOpenInvestorNameType 是基础类型

    ///<summary>
    ///TFtdcCSRCInvestorIDType是一个客户代码类型
    ///</summary>
    /// TThostFtdcCSRCInvestorIDType 是基础类型

    ///<summary>
    ///TFtdcCSRCIdentifiedCardNoType是一个证件号码类型
    ///</summary>
    /// TThostFtdcCSRCIdentifiedCardNoType 是基础类型

    ///<summary>
    ///TFtdcCSRCClientIDType是一个交易编码类型
    ///</summary>
    /// TThostFtdcCSRCClientIDType 是基础类型

    ///<summary>
    ///TFtdcCSRCBankFlagType是一个银行标识类型
    ///</summary>
    /// TThostFtdcCSRCBankFlagType 是基础类型

    ///<summary>
    ///TFtdcCSRCBankAccountType是一个银行账户类型
    ///</summary>
    /// TThostFtdcCSRCBankAccountType 是基础类型

    ///<summary>
    ///TFtdcCSRCOpenNameType是一个开户人类型
    ///</summary>
    /// TThostFtdcCSRCOpenNameType 是基础类型

    ///<summary>
    ///TFtdcCSRCMemoType是一个说明类型
    ///</summary>
    /// TThostFtdcCSRCMemoType 是基础类型

    ///<summary>
    ///TFtdcCSRCTimeType是一个时间类型
    ///</summary>
    /// TThostFtdcCSRCTimeType 是基础类型

    ///<summary>
    ///TFtdcCSRCTradeIDType是一个成交流水号类型
    ///</summary>
    /// TThostFtdcCSRCTradeIDType 是基础类型

    ///<summary>
    ///TFtdcCSRCExchangeInstIDType是一个合约代码类型
    ///</summary>
    /// TThostFtdcCSRCExchangeInstIDType 是基础类型

    ///<summary>
    ///TFtdcCSRCMortgageNameType是一个质押品名称类型
    ///</summary>
    /// TThostFtdcCSRCMortgageNameType 是基础类型

    ///<summary>
    ///TFtdcCSRCReasonType是一个事由类型
    ///</summary>
    /// TThostFtdcCSRCReasonType 是基础类型

    ///<summary>
    ///TFtdcIsSettlementType是一个是否为非结算会员类型
    ///</summary>
    /// TThostFtdcIsSettlementType 是基础类型

    ///<summary>
    ///TFtdcCSRCMoneyType是一个资金类型
    ///</summary>
    /// TThostFtdcCSRCMoneyType 是基础类型

    ///<summary>
    ///TFtdcCSRCPriceType是一个价格类型
    ///</summary>
    /// TThostFtdcCSRCPriceType 是基础类型

    ///<summary>
    ///TFtdcCSRCOptionsTypeType是一个期权类型类型
    ///</summary>
    /// TThostFtdcCSRCOptionsTypeType 是基础类型

    ///<summary>
    ///TFtdcCSRCStrikePriceType是一个执行价类型
    ///</summary>
    /// TThostFtdcCSRCStrikePriceType 是基础类型

    ///<summary>
    ///TFtdcCSRCTargetProductIDType是一个标的品种类型
    ///</summary>
    /// TThostFtdcCSRCTargetProductIDType 是基础类型

    ///<summary>
    ///TFtdcCSRCTargetInstrIDType是一个标的合约类型
    ///</summary>
    /// TThostFtdcCSRCTargetInstrIDType 是基础类型

    ///<summary>
    ///TFtdcCommModelNameType是一个手续费率模板名称类型
    ///</summary>
    /// TThostFtdcCommModelNameType 是基础类型

    ///<summary>
    ///TFtdcCommModelMemoType是一个手续费率模板备注类型
    ///</summary>
    /// TThostFtdcCommModelMemoType 是基础类型

    ///<summary>
    ///TFtdcExprSetModeType是一个日期表达式设置类型类型
    ///</summary>
    /// TThostFtdcExprSetModeType 未被使用

    ///<summary>
    ///TFtdcRateInvestorRangeType是一个投资者范围类型
    ///</summary>
    /// TThostFtdcRateInvestorRangeType 未被使用

    ///<summary>
    ///TFtdcAgentBrokerIDType是一个代理经纪公司代码类型
    ///</summary>
    /// TThostFtdcAgentBrokerIDType 是基础类型

    ///<summary>
    ///TFtdcDRIdentityIDType是一个交易中心代码类型
    ///</summary>
    /// TThostFtdcDRIdentityIDType 是基础类型

    ///<summary>
    ///TFtdcDRIdentityNameType是一个交易中心名称类型
    ///</summary>
    /// TThostFtdcDRIdentityNameType 是基础类型

    ///<summary>
    ///TFtdcDBLinkIDType是一个DBLink标识号类型
    ///</summary>
    /// TThostFtdcDBLinkIDType 是基础类型

    ///<summary>
    ///TFtdcSyncDataStatusType是一个主次用系统数据同步状态类型
    ///</summary>
    /// TThostFtdcSyncDataStatusType 未被使用

    ///<summary>
    ///TFtdcTradeSourceType是一个成交来源类型
    ///</summary>
    public static class CtpTradeSourceType
    {
        ///<summary>
        ///来自交易所普通回报
        ///</summary>
        public const byte NORMAL = (byte)'0';
        ///<summary>
        ///来自查询
        ///</summary>
        public const byte QUERY = (byte)'1';
    };

    ///<summary>
    ///TFtdcFlexStatModeType是一个产品合约统计方式类型
    ///</summary>
    /// TThostFtdcFlexStatModeType 未被使用

    ///<summary>
    ///TFtdcByInvestorRangeType是一个投资者范围统计方式类型
    ///</summary>
    /// TThostFtdcByInvestorRangeType 未被使用

    ///<summary>
    ///TFtdcSRiskRateType是一个风险度类型
    ///</summary>
    /// TThostFtdcSRiskRateType 是基础类型

    ///<summary>
    ///TFtdcSequenceNo12Type是一个序号类型
    ///</summary>
    /// TThostFtdcSequenceNo12Type 是基础类型

    ///<summary>
    ///TFtdcPropertyInvestorRangeType是一个投资者范围类型
    ///</summary>
    /// TThostFtdcPropertyInvestorRangeType 未被使用

    ///<summary>
    ///TFtdcFileStatusType是一个文件状态类型
    ///</summary>
    /// TThostFtdcFileStatusType 未被使用

    ///<summary>
    ///TFtdcFileGenStyleType是一个文件生成方式类型
    ///</summary>
    /// TThostFtdcFileGenStyleType 未被使用

    ///<summary>
    ///TFtdcSysOperModeType是一个系统日志操作方法类型
    ///</summary>
    /// TThostFtdcSysOperModeType 未被使用

    ///<summary>
    ///TFtdcSysOperTypeType是一个系统日志操作类型类型
    ///</summary>
    /// TThostFtdcSysOperTypeType 未被使用

    ///<summary>
    ///TFtdcCSRCDataQueyTypeType是一个上报数据查询类型类型
    ///</summary>
    /// TThostFtdcCSRCDataQueyTypeType 未被使用

    ///<summary>
    ///TFtdcFreezeStatusType是一个休眠状态类型
    ///</summary>
    /// TThostFtdcFreezeStatusType 未被使用

    ///<summary>
    ///TFtdcStandardStatusType是一个规范状态类型
    ///</summary>
    /// TThostFtdcStandardStatusType 未被使用

    ///<summary>
    ///TFtdcCSRCFreezeStatusType是一个休眠状态类型
    ///</summary>
    /// TThostFtdcCSRCFreezeStatusType 是基础类型

    ///<summary>
    ///TFtdcRightParamTypeType是一个配置类型类型
    ///</summary>
    /// TThostFtdcRightParamTypeType 未被使用

    ///<summary>
    ///TFtdcRightTemplateIDType是一个模板代码类型
    ///</summary>
    /// TThostFtdcRightTemplateIDType 是基础类型

    ///<summary>
    ///TFtdcRightTemplateNameType是一个模板名称类型
    ///</summary>
    /// TThostFtdcRightTemplateNameType 是基础类型

    ///<summary>
    ///TFtdcDataStatusType是一个反洗钱审核表数据状态类型
    ///</summary>
    /// TThostFtdcDataStatusType 未被使用

    ///<summary>
    ///TFtdcAMLCheckStatusType是一个审核状态类型
    ///</summary>
    /// TThostFtdcAMLCheckStatusType 未被使用

    ///<summary>
    ///TFtdcAmlDateTypeType是一个日期类型类型
    ///</summary>
    /// TThostFtdcAmlDateTypeType 未被使用

    ///<summary>
    ///TFtdcAmlCheckLevelType是一个审核级别类型
    ///</summary>
    /// TThostFtdcAmlCheckLevelType 未被使用

    ///<summary>
    ///TFtdcAmlCheckFlowType是一个反洗钱数据抽取审核流程类型
    ///</summary>
    /// TThostFtdcAmlCheckFlowType 是基础类型

    ///<summary>
    ///TFtdcDataTypeType是一个数据类型类型
    ///</summary>
    /// TThostFtdcDataTypeType 是基础类型

    ///<summary>
    ///TFtdcExportFileTypeType是一个导出文件类型类型
    ///</summary>
    /// TThostFtdcExportFileTypeType 未被使用

    ///<summary>
    ///TFtdcSettleManagerTypeType是一个结算配置类型类型
    ///</summary>
    /// TThostFtdcSettleManagerTypeType 未被使用

    ///<summary>
    ///TFtdcSettleManagerIDType是一个结算配置代码类型
    ///</summary>
    /// TThostFtdcSettleManagerIDType 是基础类型

    ///<summary>
    ///TFtdcSettleManagerNameType是一个结算配置名称类型
    ///</summary>
    /// TThostFtdcSettleManagerNameType 是基础类型

    ///<summary>
    ///TFtdcSettleManagerLevelType是一个结算配置等级类型
    ///</summary>
    /// TThostFtdcSettleManagerLevelType 未被使用

    ///<summary>
    ///TFtdcSettleManagerGroupType是一个模块分组类型
    ///</summary>
    /// TThostFtdcSettleManagerGroupType 未被使用

    ///<summary>
    ///TFtdcCheckResultMemoType是一个核对结果说明类型
    ///</summary>
    /// TThostFtdcCheckResultMemoType 是基础类型

    ///<summary>
    ///TFtdcFunctionUrlType是一个功能链接类型
    ///</summary>
    /// TThostFtdcFunctionUrlType 是基础类型

    ///<summary>
    ///TFtdcAuthInfoType是一个客户端认证信息类型
    ///</summary>
    /// TThostFtdcAuthInfoType 是基础类型

    ///<summary>
    ///TFtdcAuthCodeType是一个客户端认证码类型
    ///</summary>
    /// TThostFtdcAuthCodeType 是基础类型

    ///<summary>
    ///TFtdcLimitUseTypeType是一个保值额度使用类型类型
    ///</summary>
    /// TThostFtdcLimitUseTypeType 未被使用

    ///<summary>
    ///TFtdcDataResourceType是一个数据来源类型
    ///</summary>
    /// TThostFtdcDataResourceType 未被使用

    ///<summary>
    ///TFtdcMarginTypeType是一个保证金类型类型
    ///</summary>
    /// TThostFtdcMarginTypeType 未被使用

    ///<summary>
    ///TFtdcActiveTypeType是一个生效类型类型
    ///</summary>
    /// TThostFtdcActiveTypeType 未被使用

    ///<summary>
    ///TFtdcMarginRateTypeType是一个冲突保证金率类型类型
    ///</summary>
    /// TThostFtdcMarginRateTypeType 未被使用

    ///<summary>
    ///TFtdcBackUpStatusType是一个备份数据状态类型
    ///</summary>
    /// TThostFtdcBackUpStatusType 未被使用

    ///<summary>
    ///TFtdcInitSettlementType是一个结算初始化状态类型
    ///</summary>
    /// TThostFtdcInitSettlementType 未被使用

    ///<summary>
    ///TFtdcReportStatusType是一个报表数据生成状态类型
    ///</summary>
    /// TThostFtdcReportStatusType 未被使用

    ///<summary>
    ///TFtdcSaveStatusType是一个数据归档状态类型
    ///</summary>
    /// TThostFtdcSaveStatusType 未被使用

    ///<summary>
    ///TFtdcSettArchiveStatusType是一个结算确认数据归档状态类型
    ///</summary>
    /// TThostFtdcSettArchiveStatusType 未被使用

    ///<summary>
    ///TFtdcCTPTypeType是一个CTP交易系统类型类型
    ///</summary>
    /// TThostFtdcCTPTypeType 未被使用

    ///<summary>
    ///TFtdcToolIDType是一个工具代码类型
    ///</summary>
    /// TThostFtdcToolIDType 是基础类型

    ///<summary>
    ///TFtdcToolNameType是一个工具名称类型
    ///</summary>
    /// TThostFtdcToolNameType 是基础类型

    ///<summary>
    ///TFtdcCloseDealTypeType是一个平仓处理类型类型
    ///</summary>
    public static class CtpCloseDealTypeType
    {
        ///<summary>
        ///正常
        ///</summary>
        public const byte Normal = (byte)'0';
        ///<summary>
        ///投机平仓优先
        ///</summary>
        public const byte SpecFirst = (byte)'1';
    };

    ///<summary>
    ///TFtdcMortgageFundUseRangeType是一个货币质押资金可用范围类型
    ///</summary>
    public static class CtpMortgageFundUseRangeType
    {
        ///<summary>
        ///不能使用
        ///</summary>
        public const byte None = (byte)'0';
        ///<summary>
        ///用于保证金
        ///</summary>
        public const byte Margin = (byte)'1';
        ///<summary>
        ///用于手续费、盈亏、保证金
        ///</summary>
        public const byte All = (byte)'2';
    };

    ///<summary>
    ///TFtdcCurrencyUnitType是一个币种单位数量类型
    ///</summary>
    /// TThostFtdcCurrencyUnitType 是基础类型

    ///<summary>
    ///TFtdcExchangeRateType是一个汇率类型
    ///</summary>
    /// TThostFtdcExchangeRateType 是基础类型

    ///<summary>
    ///TFtdcSpecProductTypeType是一个特殊产品类型类型
    ///</summary>
    /// TThostFtdcSpecProductTypeType 未被使用

    ///<summary>
    ///TFtdcFundMortgageTypeType是一个货币质押类型类型
    ///</summary>
    /// TThostFtdcFundMortgageTypeType 未被使用

    ///<summary>
    ///TFtdcAccountSettlementParamIDType是一个投资者账户结算参数代码类型
    ///</summary>
    /// TThostFtdcAccountSettlementParamIDType 未被使用

    ///<summary>
    ///TFtdcCurrencyNameType是一个币种名称类型
    ///</summary>
    /// TThostFtdcCurrencyNameType 是基础类型

    ///<summary>
    ///TFtdcCurrencySignType是一个币种符号类型
    ///</summary>
    /// TThostFtdcCurrencySignType 是基础类型

    ///<summary>
    ///TFtdcFundMortDirectionType是一个货币质押方向类型
    ///</summary>
    /// TThostFtdcFundMortDirectionType 未被使用

    ///<summary>
    ///TFtdcBusinessClassType是一个换汇类别类型
    ///</summary>
    /// TThostFtdcBusinessClassType 未被使用

    ///<summary>
    ///TFtdcSwapSourceTypeType是一个换汇数据来源类型
    ///</summary>
    /// TThostFtdcSwapSourceTypeType 未被使用

    ///<summary>
    ///TFtdcCurrExDirectionType是一个换汇类型类型
    ///</summary>
    /// TThostFtdcCurrExDirectionType 未被使用

    ///<summary>
    ///TFtdcCurrencySwapStatusType是一个申请状态类型
    ///</summary>
    /// TThostFtdcCurrencySwapStatusType 未被使用

    ///<summary>
    ///TFtdcCurrExchCertNoType是一个凭证号类型
    ///</summary>
    /// TThostFtdcCurrExchCertNoType 是基础类型

    ///<summary>
    ///TFtdcBatchSerialNoType是一个批次号类型
    ///</summary>
    /// TThostFtdcBatchSerialNoType 是基础类型

    ///<summary>
    ///TFtdcReqFlagType是一个换汇发送标志类型
    ///</summary>
    /// TThostFtdcReqFlagType 未被使用

    ///<summary>
    ///TFtdcResFlagType是一个换汇返回成功标志类型
    ///</summary>
    /// TThostFtdcResFlagType 未被使用

    ///<summary>
    ///TFtdcPageControlType是一个换汇页面控制类型
    ///</summary>
    /// TThostFtdcPageControlType 是基础类型

    ///<summary>
    ///TFtdcRecordCountType是一个记录数类型
    ///</summary>
    /// TThostFtdcRecordCountType 是基础类型

    ///<summary>
    ///TFtdcCurrencySwapMemoType是一个换汇需确认信息类型
    ///</summary>
    /// TThostFtdcCurrencySwapMemoType 是基础类型

    ///<summary>
    ///TFtdcExStatusType是一个修改状态类型
    ///</summary>
    /// TThostFtdcExStatusType 未被使用

    ///<summary>
    ///TFtdcClientRegionType是一个开户客户地域类型
    ///</summary>
    /// TThostFtdcClientRegionType 未被使用

    ///<summary>
    ///TFtdcWorkPlaceType是一个工作单位类型
    ///</summary>
    /// TThostFtdcWorkPlaceType 是基础类型

    ///<summary>
    ///TFtdcBusinessPeriodType是一个经营期限类型
    ///</summary>
    /// TThostFtdcBusinessPeriodType 是基础类型

    ///<summary>
    ///TFtdcWebSiteType是一个网址类型
    ///</summary>
    /// TThostFtdcWebSiteType 是基础类型

    ///<summary>
    ///TFtdcUOAIdCardTypeType是一个统一开户证件类型类型
    ///</summary>
    /// TThostFtdcUOAIdCardTypeType 是基础类型

    ///<summary>
    ///TFtdcClientModeType是一个开户模式类型
    ///</summary>
    /// TThostFtdcClientModeType 是基础类型

    ///<summary>
    ///TFtdcInvestorFullNameType是一个投资者全称类型
    ///</summary>
    /// TThostFtdcInvestorFullNameType 是基础类型

    ///<summary>
    ///TFtdcUOABrokerIDType是一个境外中介机构ID类型
    ///</summary>
    /// TThostFtdcUOABrokerIDType 是基础类型

    ///<summary>
    ///TFtdcUOAZipCodeType是一个邮政编码类型
    ///</summary>
    /// TThostFtdcUOAZipCodeType 是基础类型

    ///<summary>
    ///TFtdcUOAEMailType是一个电子邮箱类型
    ///</summary>
    /// TThostFtdcUOAEMailType 是基础类型

    ///<summary>
    ///TFtdcOldCityType是一个城市类型
    ///</summary>
    /// TThostFtdcOldCityType 是基础类型

    ///<summary>
    ///TFtdcCorporateIdentifiedCardNoType是一个法人代表证件号码类型
    ///</summary>
    /// TThostFtdcCorporateIdentifiedCardNoType 是基础类型

    ///<summary>
    ///TFtdcHasBoardType是一个是否有董事会类型
    ///</summary>
    /// TThostFtdcHasBoardType 未被使用

    ///<summary>
    ///TFtdcStartModeType是一个启动模式类型
    ///</summary>
    /// TThostFtdcStartModeType 未被使用

    ///<summary>
    ///TFtdcTemplateTypeType是一个模型类型类型
    ///</summary>
    /// TThostFtdcTemplateTypeType 未被使用

    ///<summary>
    ///TFtdcLoginModeType是一个登录模式类型
    ///</summary>
    public static class CtpLoginModeType
    {
        ///<summary>
        ///交易
        ///</summary>
        public const byte Trade = (byte)'0';
        ///<summary>
        ///转账
        ///</summary>
        public const byte Transfer = (byte)'1';
    };

    ///<summary>
    ///TFtdcPromptTypeType是一个日历提示类型类型
    ///</summary>
    /// TThostFtdcPromptTypeType 未被使用

    ///<summary>
    ///TFtdcLedgerManageIDType是一个分户管理资产编码类型
    ///</summary>
    /// TThostFtdcLedgerManageIDType 是基础类型

    ///<summary>
    ///TFtdcInvestVarietyType是一个投资品种类型
    ///</summary>
    /// TThostFtdcInvestVarietyType 是基础类型

    ///<summary>
    ///TFtdcBankAccountTypeType是一个账户类别类型
    ///</summary>
    /// TThostFtdcBankAccountTypeType 是基础类型

    ///<summary>
    ///TFtdcLedgerManageBankType是一个开户银行类型
    ///</summary>
    /// TThostFtdcLedgerManageBankType 是基础类型

    ///<summary>
    ///TFtdcCffexDepartmentNameType是一个开户营业部类型
    ///</summary>
    /// TThostFtdcCffexDepartmentNameType 是基础类型

    ///<summary>
    ///TFtdcCffexDepartmentCodeType是一个营业部代码类型
    ///</summary>
    /// TThostFtdcCffexDepartmentCodeType 是基础类型

    ///<summary>
    ///TFtdcHasTrusteeType是一个是否有托管人类型
    ///</summary>
    /// TThostFtdcHasTrusteeType 未被使用

    ///<summary>
    ///TFtdcCSRCMemo1Type是一个说明类型
    ///</summary>
    /// TThostFtdcCSRCMemo1Type 是基础类型

    ///<summary>
    ///TFtdcAssetmgrCFullNameType是一个代理资产管理业务的期货公司全称类型
    ///</summary>
    /// TThostFtdcAssetmgrCFullNameType 是基础类型

    ///<summary>
    ///TFtdcAssetmgrApprovalNOType是一个资产管理业务批文号类型
    ///</summary>
    /// TThostFtdcAssetmgrApprovalNOType 是基础类型

    ///<summary>
    ///TFtdcAssetmgrMgrNameType是一个资产管理业务负责人姓名类型
    ///</summary>
    /// TThostFtdcAssetmgrMgrNameType 是基础类型

    ///<summary>
    ///TFtdcAmTypeType是一个机构类型类型
    ///</summary>
    /// TThostFtdcAmTypeType 未被使用

    ///<summary>
    ///TFtdcCSRCAmTypeType是一个机构类型类型
    ///</summary>
    /// TThostFtdcCSRCAmTypeType 是基础类型

    ///<summary>
    ///TFtdcCSRCFundIOTypeType是一个出入金类型类型
    ///</summary>
    /// TThostFtdcCSRCFundIOTypeType 未被使用

    ///<summary>
    ///TFtdcCusAccountTypeType是一个结算账户类型类型
    ///</summary>
    /// TThostFtdcCusAccountTypeType 未被使用

    ///<summary>
    ///TFtdcCSRCNationalType是一个国籍类型
    ///</summary>
    /// TThostFtdcCSRCNationalType 是基础类型

    ///<summary>
    ///TFtdcCSRCSecAgentIDType是一个二级代理ID类型
    ///</summary>
    /// TThostFtdcCSRCSecAgentIDType 是基础类型

    ///<summary>
    ///TFtdcLanguageTypeType是一个通知语言类型类型
    ///</summary>
    /// TThostFtdcLanguageTypeType 未被使用

    ///<summary>
    ///TFtdcAmAccountType是一个投资账户类型
    ///</summary>
    /// TThostFtdcAmAccountType 是基础类型

    ///<summary>
    ///TFtdcAssetmgrClientTypeType是一个资产管理客户类型类型
    ///</summary>
    /// TThostFtdcAssetmgrClientTypeType 未被使用

    ///<summary>
    ///TFtdcAssetmgrTypeType是一个投资类型类型
    ///</summary>
    /// TThostFtdcAssetmgrTypeType 未被使用

    ///<summary>
    ///TFtdcUOMType是一个计量单位类型
    ///</summary>
    /// TThostFtdcUOMType 是基础类型

    ///<summary>
    ///TFtdcSHFEInstLifePhaseType是一个上期所合约生命周期状态类型
    ///</summary>
    /// TThostFtdcSHFEInstLifePhaseType 是基础类型

    ///<summary>
    ///TFtdcSHFEProductClassType是一个产品类型类型
    ///</summary>
    /// TThostFtdcSHFEProductClassType 是基础类型

    ///<summary>
    ///TFtdcPriceDecimalType是一个价格小数位类型
    ///</summary>
    /// TThostFtdcPriceDecimalType 是基础类型

    ///<summary>
    ///TFtdcInTheMoneyFlagType是一个平值期权标志类型
    ///</summary>
    /// TThostFtdcInTheMoneyFlagType 是基础类型

    ///<summary>
    ///TFtdcCheckInstrTypeType是一个合约比较类型类型
    ///</summary>
    /// TThostFtdcCheckInstrTypeType 未被使用

    ///<summary>
    ///TFtdcDeliveryTypeType是一个交割类型类型
    ///</summary>
    /// TThostFtdcDeliveryTypeType 未被使用

    ///<summary>
    ///TFtdcBigMoneyType是一个资金类型
    ///</summary>
    /// TThostFtdcBigMoneyType 是基础类型

    ///<summary>
    ///TFtdcMaxMarginSideAlgorithmType是一个大额单边保证金算法类型
    ///</summary>
    public static class CtpMaxMarginSideAlgorithmType
    {
        ///<summary>
        ///不使用大额单边保证金算法
        ///</summary>
        public const byte NO = (byte)'0';
        ///<summary>
        ///使用大额单边保证金算法
        ///</summary>
        public const byte YES = (byte)'1';
    };

    ///<summary>
    ///TFtdcDAClientTypeType是一个资产管理客户类型类型
    ///</summary>
    /// TThostFtdcDAClientTypeType 未被使用

    ///<summary>
    ///TFtdcCombinInstrIDType是一个套利合约代码类型
    ///</summary>
    /// TThostFtdcCombinInstrIDType 是基础类型

    ///<summary>
    ///TFtdcCombinSettlePriceType是一个各腿结算价类型
    ///</summary>
    /// TThostFtdcCombinSettlePriceType 是基础类型

    ///<summary>
    ///TFtdcDCEPriorityType是一个优先级类型
    ///</summary>
    /// TThostFtdcDCEPriorityType 是基础类型

    ///<summary>
    ///TFtdcTradeGroupIDType是一个成交组号类型
    ///</summary>
    /// TThostFtdcTradeGroupIDType 是基础类型

    ///<summary>
    ///TFtdcIsCheckPrepaType是一个是否校验开户可用资金类型
    ///</summary>
    /// TThostFtdcIsCheckPrepaType 是基础类型

    ///<summary>
    ///TFtdcUOAAssetmgrTypeType是一个投资类型类型
    ///</summary>
    /// TThostFtdcUOAAssetmgrTypeType 未被使用

    ///<summary>
    ///TFtdcDirectionEnType是一个买卖方向类型
    ///</summary>
    /// TThostFtdcDirectionEnType 未被使用

    ///<summary>
    ///TFtdcOffsetFlagEnType是一个开平标志类型
    ///</summary>
    /// TThostFtdcOffsetFlagEnType 未被使用

    ///<summary>
    ///TFtdcHedgeFlagEnType是一个投机套保标志类型
    ///</summary>
    /// TThostFtdcHedgeFlagEnType 未被使用

    ///<summary>
    ///TFtdcFundIOTypeEnType是一个出入金类型类型
    ///</summary>
    /// TThostFtdcFundIOTypeEnType 未被使用

    ///<summary>
    ///TFtdcFundTypeEnType是一个资金类型类型
    ///</summary>
    /// TThostFtdcFundTypeEnType 未被使用

    ///<summary>
    ///TFtdcFundDirectionEnType是一个出入金方向类型
    ///</summary>
    /// TThostFtdcFundDirectionEnType 未被使用

    ///<summary>
    ///TFtdcFundMortDirectionEnType是一个货币质押方向类型
    ///</summary>
    /// TThostFtdcFundMortDirectionEnType 未被使用

    ///<summary>
    ///TFtdcSwapBusinessTypeType是一个换汇业务种类类型
    ///</summary>
    /// TThostFtdcSwapBusinessTypeType 是基础类型

    ///<summary>
    ///TFtdcOptionsTypeType是一个期权类型类型
    ///</summary>
    public static class CtpOptionsTypeType
    {
        ///<summary>
        ///看涨
        ///</summary>
        public const byte CallOptions = (byte)'1';
        ///<summary>
        ///看跌
        ///</summary>
        public const byte PutOptions = (byte)'2';
    };

    ///<summary>
    ///TFtdcStrikeModeType是一个执行方式类型
    ///</summary>
    /// TThostFtdcStrikeModeType 未被使用

    ///<summary>
    ///TFtdcStrikeTypeType是一个执行类型类型
    ///</summary>
    /// TThostFtdcStrikeTypeType 未被使用

    ///<summary>
    ///TFtdcApplyTypeType是一个中金所期权放弃执行申请类型类型
    ///</summary>
    /// TThostFtdcApplyTypeType 未被使用

    ///<summary>
    ///TFtdcGiveUpDataSourceType是一个放弃执行申请数据来源类型
    ///</summary>
    /// TThostFtdcGiveUpDataSourceType 未被使用

    ///<summary>
    ///TFtdcExecOrderSysIDType是一个执行宣告系统编号类型
    ///</summary>
    /// TThostFtdcExecOrderSysIDType 是基础类型

    ///<summary>
    ///TFtdcExecResultType是一个执行结果类型
    ///</summary>
    public static class CtpExecResultType
    {
        ///<summary>
        ///没有执行
        ///</summary>
        public const byte NoExec = (byte)'n';
        ///<summary>
        ///已经取消
        ///</summary>
        public const byte Canceled = (byte)'c';
        ///<summary>
        ///执行成功
        ///</summary>
        public const byte OK = (byte)'0';
        ///<summary>
        ///期权持仓不够
        ///</summary>
        public const byte NoPosition = (byte)'1';
        ///<summary>
        ///资金不够
        ///</summary>
        public const byte NoDeposit = (byte)'2';
        ///<summary>
        ///会员不存在
        ///</summary>
        public const byte NoParticipant = (byte)'3';
        ///<summary>
        ///客户不存在
        ///</summary>
        public const byte NoClient = (byte)'4';
        ///<summary>
        ///合约不存在
        ///</summary>
        public const byte NoInstrument = (byte)'6';
        ///<summary>
        ///没有执行权限
        ///</summary>
        public const byte NoRight = (byte)'7';
        ///<summary>
        ///不合理的数量
        ///</summary>
        public const byte InvalidVolume = (byte)'8';
        ///<summary>
        ///没有足够的历史成交
        ///</summary>
        public const byte NoEnoughHistoryTrade = (byte)'9';
        ///<summary>
        ///未知
        ///</summary>
        public const byte Unknown = (byte)'a';
    };

    ///<summary>
    ///TFtdcStrikeSequenceType是一个执行序号类型
    ///</summary>
    /// TThostFtdcStrikeSequenceType 是基础类型

    ///<summary>
    ///TFtdcStrikeTimeType是一个执行时间类型
    ///</summary>
    /// TThostFtdcStrikeTimeType 是基础类型

    ///<summary>
    ///TFtdcCombinationTypeType是一个组合类型类型
    ///</summary>
    public static class CtpCombinationTypeType
    {
        ///<summary>
        ///期货组合
        ///</summary>
        public const byte Future = (byte)'0';
        ///<summary>
        ///垂直价差BUL
        ///</summary>
        public const byte BUL = (byte)'1';
        ///<summary>
        ///垂直价差BER
        ///</summary>
        public const byte BER = (byte)'2';
        ///<summary>
        ///跨式组合
        ///</summary>
        public const byte STD = (byte)'3';
        ///<summary>
        ///宽跨式组合
        ///</summary>
        public const byte STG = (byte)'4';
        ///<summary>
        ///备兑组合
        ///</summary>
        public const byte PRT = (byte)'5';
        ///<summary>
        ///时间价差组合
        ///</summary>
        public const byte CLD = (byte)'6';
    };

    ///<summary>
    ///TFtdcOptionRoyaltyPriceTypeType是一个期权权利金价格类型类型
    ///</summary>
    public static class CtpOptionRoyaltyPriceTypeType
    {
        ///<summary>
        ///昨结算价
        ///</summary>
        public const byte PreSettlementPrice = (byte)'1';
        ///<summary>
        ///开仓价
        ///</summary>
        public const byte OpenPrice = (byte)'4';
    };

    ///<summary>
    ///TFtdcBalanceAlgorithmType是一个权益算法类型
    ///</summary>
    public static class CtpBalanceAlgorithmType
    {
        ///<summary>
        ///不计算期权市值盈亏
        ///</summary>
        public const byte Default = (byte)'1';
        ///<summary>
        ///计算期权市值亏损
        ///</summary>
        public const byte IncludeOptValLost = (byte)'2';
    };

    ///<summary>
    ///TFtdcActionTypeType是一个执行类型类型
    ///</summary>
    public static class CtpActionTypeType
    {
        ///<summary>
        ///执行
        ///</summary>
        public const byte Exec = (byte)'1';
        ///<summary>
        ///放弃
        ///</summary>
        public const byte Abandon = (byte)'2';
    };

    ///<summary>
    ///TFtdcForQuoteStatusType是一个询价状态类型
    ///</summary>
    public static class CtpForQuoteStatusType
    {
        ///<summary>
        ///已经提交
        ///</summary>
        public const byte Submitted = (byte)'a';
        ///<summary>
        ///已经接受
        ///</summary>
        public const byte Accepted = (byte)'b';
        ///<summary>
        ///已经被拒绝
        ///</summary>
        public const byte Rejected = (byte)'c';
    };

    ///<summary>
    ///TFtdcValueMethodType是一个取值方式类型
    ///</summary>
    public static class CtpValueMethodType
    {
        ///<summary>
        ///按绝对值
        ///</summary>
        public const byte Absolute = (byte)'0';
        ///<summary>
        ///按比率
        ///</summary>
        public const byte Ratio = (byte)'1';
    };

    ///<summary>
    ///TFtdcExecOrderPositionFlagType是一个期权行权后是否保留期货头寸的标记类型
    ///</summary>
    public static class CtpExecOrderPositionFlagType
    {
        ///<summary>
        ///保留
        ///</summary>
        public const byte Reserve = (byte)'0';
        ///<summary>
        ///不保留
        ///</summary>
        public const byte UnReserve = (byte)'1';
    };

    ///<summary>
    ///TFtdcExecOrderCloseFlagType是一个期权行权后生成的头寸是否自动平仓类型
    ///</summary>
    public static class CtpExecOrderCloseFlagType
    {
        ///<summary>
        ///自动平仓
        ///</summary>
        public const byte AutoClose = (byte)'0';
        ///<summary>
        ///免于自动平仓
        ///</summary>
        public const byte NotToClose = (byte)'1';
    };

    ///<summary>
    ///TFtdcProductTypeType是一个产品类型类型
    ///</summary>
    /// TThostFtdcProductTypeType 未被使用

    ///<summary>
    ///TFtdcCZCEUploadFileNameType是一个郑商所结算文件名类型
    ///</summary>
    /// TThostFtdcCZCEUploadFileNameType 未被使用

    ///<summary>
    ///TFtdcDCEUploadFileNameType是一个大商所结算文件名类型
    ///</summary>
    /// TThostFtdcDCEUploadFileNameType 未被使用

    ///<summary>
    ///TFtdcSHFEUploadFileNameType是一个上期所结算文件名类型
    ///</summary>
    /// TThostFtdcSHFEUploadFileNameType 未被使用

    ///<summary>
    ///TFtdcCFFEXUploadFileNameType是一个中金所结算文件名类型
    ///</summary>
    /// TThostFtdcCFFEXUploadFileNameType 未被使用

    ///<summary>
    ///TFtdcCombDirectionType是一个组合指令方向类型
    ///</summary>
    public static class CtpCombDirectionType
    {
        ///<summary>
        ///申请组合
        ///</summary>
        public const byte Comb = (byte)'0';
        ///<summary>
        ///申请拆分
        ///</summary>
        public const byte UnComb = (byte)'1';
    };

    ///<summary>
    ///用户登录请求
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpReqUserLogin
    {
        ///<summary>
        ///交易日
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///密码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Password;
        ///<summary>
        ///用户端产品信息
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string UserProductInfo;
        ///<summary>
        ///接口端产品信息
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string InterfaceProductInfo;
        ///<summary>
        ///协议信息
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ProtocolInfo;
        ///<summary>
        ///Mac地址
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string MacAddress;
        ///<summary>
        ///动态密码
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string OneTimePassword;
        ///<summary>
        ///终端IP地址
        ///</summary>
        [DataMember(Order = 10)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string ClientIPAddress;

        public static byte[] GetData(CtpReqUserLogin obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradingDay);
                writer.Write(obj.BrokerID);
                writer.Write(obj.UserID);
                writer.Write(obj.Password);
                writer.Write(obj.UserProductInfo);
                writer.Write(obj.InterfaceProductInfo);
                writer.Write(obj.ProtocolInfo);
                writer.Write(obj.MacAddress);
                writer.Write(obj.OneTimePassword);
                writer.Write(obj.ClientIPAddress);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///用户登录应答
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpRspUserLogin
    {
        ///<summary>
        ///交易日
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///登录成功时间
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string LoginTime;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///交易系统名称
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string SystemName;
        ///<summary>
        ///前置编号
        ///</summary>
        [DataMember(Order = 6)]
        public int FrontID;
        ///<summary>
        ///会话编号
        ///</summary>
        [DataMember(Order = 7)]
        public int SessionID;
        ///<summary>
        ///最大报单引用
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string MaxOrderRef;
        ///<summary>
        ///上期所时间
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string SHFETime;
        ///<summary>
        ///大商所时间
        ///</summary>
        [DataMember(Order = 10)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string DCETime;
        ///<summary>
        ///郑商所时间
        ///</summary>
        [DataMember(Order = 11)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string CZCETime;
        ///<summary>
        ///中金所时间
        ///</summary>
        [DataMember(Order = 12)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string FFEXTime;
        ///<summary>
        ///能源中心时间
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string INETime;

        public static byte[] GetData(CtpRspUserLogin obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradingDay);
                writer.Write(obj.LoginTime);
                writer.Write(obj.BrokerID);
                writer.Write(obj.UserID);
                writer.Write(obj.SystemName);
                writer.Write(obj.FrontID);
                writer.Write(obj.SessionID);
                writer.Write(obj.MaxOrderRef);
                writer.Write(obj.SHFETime);
                writer.Write(obj.DCETime);
                writer.Write(obj.CZCETime);
                writer.Write(obj.FFEXTime);
                writer.Write(obj.INETime);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///用户登出请求
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpUserLogout
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;

        public static byte[] GetData(CtpUserLogout obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.UserID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///强制交易员退出
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpForceUserLogout
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;

        public static byte[] GetData(CtpForceUserLogout obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.UserID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///客户端认证请求
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpReqAuthenticate
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///用户端产品信息
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string UserProductInfo;
        ///<summary>
        ///认证码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string AuthCode;

        public static byte[] GetData(CtpReqAuthenticate obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.UserID);
                writer.Write(obj.UserProductInfo);
                writer.Write(obj.AuthCode);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///客户端认证响应
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpRspAuthenticate
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///用户端产品信息
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string UserProductInfo;

        public static byte[] GetData(CtpRspAuthenticate obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.UserID);
                writer.Write(obj.UserProductInfo);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///客户端认证信息
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpAuthenticationInfo
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///用户端产品信息
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string UserProductInfo;
        ///<summary>
        ///认证信息
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string AuthInfo;
        ///<summary>
        ///是否为认证结果
        ///</summary>
        [DataMember(Order = 5)]
        public int IsResult;

        public static byte[] GetData(CtpAuthenticationInfo obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.UserID);
                writer.Write(obj.UserProductInfo);
                writer.Write(obj.AuthInfo);
                writer.Write(obj.IsResult);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///银期转帐报文头
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpTransferHeader
    {
        ///<summary>
        ///版本号，常量，1.0
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string Version;
        ///<summary>
        ///交易代码，必填
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string TradeCode;
        ///<summary>
        ///交易日期，必填，格式：yyyymmdd
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeDate;
        ///<summary>
        ///交易时间，必填，格式：hhmmss
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeTime;
        ///<summary>
        ///发起方流水号，N/A
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeSerial;
        ///<summary>
        ///期货公司代码，必填
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string FutureID;
        ///<summary>
        ///银行代码，根据查询银行得到，必填
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分中心代码，根据查询银行得到，必填
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBrchID;
        ///<summary>
        ///操作员，N/A
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string OperNo;
        ///<summary>
        ///交易设备类型，N/A
        ///</summary>
        [DataMember(Order = 10)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string DeviceID;
        ///<summary>
        ///记录数，N/A
        ///</summary>
        [DataMember(Order = 11)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string RecordNum;
        ///<summary>
        ///会话编号，N/A
        ///</summary>
        [DataMember(Order = 12)]
        public int SessionID;
        ///<summary>
        ///请求编号，N/A
        ///</summary>
        [DataMember(Order = 13)]
        public int RequestID;

        public static byte[] GetData(CtpTransferHeader obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.Version);
                writer.Write(obj.TradeCode);
                writer.Write(obj.TradeDate);
                writer.Write(obj.TradeTime);
                writer.Write(obj.TradeSerial);
                writer.Write(obj.FutureID);
                writer.Write(obj.BankID);
                writer.Write(obj.BankBrchID);
                writer.Write(obj.OperNo);
                writer.Write(obj.DeviceID);
                writer.Write(obj.RecordNum);
                writer.Write(obj.SessionID);
                writer.Write(obj.RequestID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///银行资金转期货请求，TradeCode=202001
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpTransferBankToFutureReq
    {
        ///<summary>
        ///期货资金账户
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string FutureAccount;
        ///<summary>
        ///密码标志
        ///</summary>
        [DataMember(Order = 2)]
        public byte FuturePwdFlag;
        ///<summary>
        ///密码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string FutureAccPwd;
        ///<summary>
        ///转账金额
        ///</summary>
        [DataMember(Order = 4)]
        public double TradeAmt;
        ///<summary>
        ///客户手续费
        ///</summary>
        [DataMember(Order = 5)]
        public double CustFee;
        ///<summary>
        ///币种：RMB-人民币 USD-美圆 HKD-港元
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyCode;

        public static byte[] GetData(CtpTransferBankToFutureReq obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.FutureAccount);
                writer.Write(obj.FuturePwdFlag);
                writer.Write(obj.FutureAccPwd);
                writer.Write(obj.TradeAmt);
                writer.Write(obj.CustFee);
                writer.Write(obj.CurrencyCode);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///银行资金转期货请求响应
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpTransferBankToFutureRsp
    {
        ///<summary>
        ///响应代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string RetCode;
        ///<summary>
        ///响应信息
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string RetInfo;
        ///<summary>
        ///资金账户
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string FutureAccount;
        ///<summary>
        ///转帐金额
        ///</summary>
        [DataMember(Order = 4)]
        public double TradeAmt;
        ///<summary>
        ///应收客户手续费
        ///</summary>
        [DataMember(Order = 5)]
        public double CustFee;
        ///<summary>
        ///币种
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyCode;

        public static byte[] GetData(CtpTransferBankToFutureRsp obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.RetCode);
                writer.Write(obj.RetInfo);
                writer.Write(obj.FutureAccount);
                writer.Write(obj.TradeAmt);
                writer.Write(obj.CustFee);
                writer.Write(obj.CurrencyCode);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///期货资金转银行请求，TradeCode=202002
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpTransferFutureToBankReq
    {
        ///<summary>
        ///期货资金账户
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string FutureAccount;
        ///<summary>
        ///密码标志
        ///</summary>
        [DataMember(Order = 2)]
        public byte FuturePwdFlag;
        ///<summary>
        ///密码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string FutureAccPwd;
        ///<summary>
        ///转账金额
        ///</summary>
        [DataMember(Order = 4)]
        public double TradeAmt;
        ///<summary>
        ///客户手续费
        ///</summary>
        [DataMember(Order = 5)]
        public double CustFee;
        ///<summary>
        ///币种：RMB-人民币 USD-美圆 HKD-港元
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyCode;

        public static byte[] GetData(CtpTransferFutureToBankReq obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.FutureAccount);
                writer.Write(obj.FuturePwdFlag);
                writer.Write(obj.FutureAccPwd);
                writer.Write(obj.TradeAmt);
                writer.Write(obj.CustFee);
                writer.Write(obj.CurrencyCode);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///期货资金转银行请求响应
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpTransferFutureToBankRsp
    {
        ///<summary>
        ///响应代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string RetCode;
        ///<summary>
        ///响应信息
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string RetInfo;
        ///<summary>
        ///资金账户
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string FutureAccount;
        ///<summary>
        ///转帐金额
        ///</summary>
        [DataMember(Order = 4)]
        public double TradeAmt;
        ///<summary>
        ///应收客户手续费
        ///</summary>
        [DataMember(Order = 5)]
        public double CustFee;
        ///<summary>
        ///币种
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyCode;

        public static byte[] GetData(CtpTransferFutureToBankRsp obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.RetCode);
                writer.Write(obj.RetInfo);
                writer.Write(obj.FutureAccount);
                writer.Write(obj.TradeAmt);
                writer.Write(obj.CustFee);
                writer.Write(obj.CurrencyCode);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询银行资金请求，TradeCode=204002
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpTransferQryBankReq
    {
        ///<summary>
        ///期货资金账户
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string FutureAccount;
        ///<summary>
        ///密码标志
        ///</summary>
        [DataMember(Order = 2)]
        public byte FuturePwdFlag;
        ///<summary>
        ///密码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string FutureAccPwd;
        ///<summary>
        ///币种：RMB-人民币 USD-美圆 HKD-港元
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyCode;

        public static byte[] GetData(CtpTransferQryBankReq obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.FutureAccount);
                writer.Write(obj.FuturePwdFlag);
                writer.Write(obj.FutureAccPwd);
                writer.Write(obj.CurrencyCode);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询银行资金请求响应
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpTransferQryBankRsp
    {
        ///<summary>
        ///响应代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string RetCode;
        ///<summary>
        ///响应信息
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string RetInfo;
        ///<summary>
        ///资金账户
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string FutureAccount;
        ///<summary>
        ///银行余额
        ///</summary>
        [DataMember(Order = 4)]
        public double TradeAmt;
        ///<summary>
        ///银行可用余额
        ///</summary>
        [DataMember(Order = 5)]
        public double UseAmt;
        ///<summary>
        ///银行可取余额
        ///</summary>
        [DataMember(Order = 6)]
        public double FetchAmt;
        ///<summary>
        ///币种
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyCode;

        public static byte[] GetData(CtpTransferQryBankRsp obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.RetCode);
                writer.Write(obj.RetInfo);
                writer.Write(obj.FutureAccount);
                writer.Write(obj.TradeAmt);
                writer.Write(obj.UseAmt);
                writer.Write(obj.FetchAmt);
                writer.Write(obj.CurrencyCode);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询银行交易明细请求，TradeCode=204999
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpTransferQryDetailReq
    {
        ///<summary>
        ///期货资金账户
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string FutureAccount;

        public static byte[] GetData(CtpTransferQryDetailReq obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.FutureAccount);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询银行交易明细请求响应
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpTransferQryDetailRsp
    {
        ///<summary>
        ///交易日期
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeDate;
        ///<summary>
        ///交易时间
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeTime;
        ///<summary>
        ///交易代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string TradeCode;
        ///<summary>
        ///期货流水号
        ///</summary>
        [DataMember(Order = 4)]
        public int FutureSerial;
        ///<summary>
        ///期货公司代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string FutureID;
        ///<summary>
        ///资金帐号
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 22)]
        public string FutureAccount;
        ///<summary>
        ///银行流水号
        ///</summary>
        [DataMember(Order = 7)]
        public int BankSerial;
        ///<summary>
        ///银行代码
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分中心代码
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBrchID;
        ///<summary>
        ///银行账号
        ///</summary>
        [DataMember(Order = 10)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankAccount;
        ///<summary>
        ///证件号码
        ///</summary>
        [DataMember(Order = 11)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string CertCode;
        ///<summary>
        ///货币代码
        ///</summary>
        [DataMember(Order = 12)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyCode;
        ///<summary>
        ///发生金额
        ///</summary>
        [DataMember(Order = 13)]
        public double TxAmount;
        ///<summary>
        ///有效标志
        ///</summary>
        [DataMember(Order = 14)]
        public byte Flag;

        public static byte[] GetData(CtpTransferQryDetailRsp obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradeDate);
                writer.Write(obj.TradeTime);
                writer.Write(obj.TradeCode);
                writer.Write(obj.FutureSerial);
                writer.Write(obj.FutureID);
                writer.Write(obj.FutureAccount);
                writer.Write(obj.BankSerial);
                writer.Write(obj.BankID);
                writer.Write(obj.BankBrchID);
                writer.Write(obj.BankAccount);
                writer.Write(obj.CertCode);
                writer.Write(obj.CurrencyCode);
                writer.Write(obj.TxAmount);
                writer.Write(obj.Flag);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///响应信息
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpRspInfo
    {
        ///<summary>
        ///错误代码
        ///</summary>
        [DataMember(Order = 1)]
        public int ErrorID;
        ///<summary>
        ///错误信息
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string ErrorMsg;

        public static byte[] GetData(CtpRspInfo obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ErrorID);
                writer.Write(obj.ErrorMsg);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///交易所
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpExchange
    {
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///交易所名称
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 61)]
        public string ExchangeName;
        ///<summary>
        ///交易所属性
        ///</summary>
        [DataMember(Order = 3)]
        public byte ExchangeProperty;

        public static byte[] GetData(CtpExchange obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ExchangeName);
                writer.Write(obj.ExchangeProperty);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///产品
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpProduct
    {
        ///<summary>
        ///产品代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ProductID;
        ///<summary>
        ///产品名称
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ProductName;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///产品类型
        ///</summary>
        [DataMember(Order = 4)]
        public byte ProductClass;
        ///<summary>
        ///合约数量乘数
        ///</summary>
        [DataMember(Order = 5)]
        public int VolumeMultiple;
        ///<summary>
        ///最小变动价位
        ///</summary>
        [DataMember(Order = 6)]
        public double PriceTick;
        ///<summary>
        ///市价单最大下单量
        ///</summary>
        [DataMember(Order = 7)]
        public int MaxMarketOrderVolume;
        ///<summary>
        ///市价单最小下单量
        ///</summary>
        [DataMember(Order = 8)]
        public int MinMarketOrderVolume;
        ///<summary>
        ///限价单最大下单量
        ///</summary>
        [DataMember(Order = 9)]
        public int MaxLimitOrderVolume;
        ///<summary>
        ///限价单最小下单量
        ///</summary>
        [DataMember(Order = 10)]
        public int MinLimitOrderVolume;
        ///<summary>
        ///持仓类型
        ///</summary>
        [DataMember(Order = 11)]
        public byte PositionType;
        ///<summary>
        ///持仓日期类型
        ///</summary>
        [DataMember(Order = 12)]
        public byte PositionDateType;
        ///<summary>
        ///平仓处理类型
        ///</summary>
        [DataMember(Order = 13)]
        public byte CloseDealType;
        ///<summary>
        ///交易币种类型
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string TradeCurrencyID;
        ///<summary>
        ///质押资金可用范围
        ///</summary>
        [DataMember(Order = 15)]
        public byte MortgageFundUseRange;
        ///<summary>
        ///交易所产品代码
        ///</summary>
        [DataMember(Order = 16)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ExchangeProductID;
        ///<summary>
        ///合约基础商品乘数
        ///</summary>
        [DataMember(Order = 17)]
        public double UnderlyingMultiple;

        public static byte[] GetData(CtpProduct obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ProductID);
                writer.Write(obj.ProductName);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ProductClass);
                writer.Write(obj.VolumeMultiple);
                writer.Write(obj.PriceTick);
                writer.Write(obj.MaxMarketOrderVolume);
                writer.Write(obj.MinMarketOrderVolume);
                writer.Write(obj.MaxLimitOrderVolume);
                writer.Write(obj.MinLimitOrderVolume);
                writer.Write(obj.PositionType);
                writer.Write(obj.PositionDateType);
                writer.Write(obj.CloseDealType);
                writer.Write(obj.TradeCurrencyID);
                writer.Write(obj.MortgageFundUseRange);
                writer.Write(obj.ExchangeProductID);
                writer.Write(obj.UnderlyingMultiple);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///合约
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpInstrument
    {
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///合约名称
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string InstrumentName;
        ///<summary>
        ///合约在交易所的代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ExchangeInstID;
        ///<summary>
        ///产品代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ProductID;
        ///<summary>
        ///产品类型
        ///</summary>
        [DataMember(Order = 6)]
        public byte ProductClass;
        ///<summary>
        ///交割年份
        ///</summary>
        [DataMember(Order = 7)]
        public int DeliveryYear;
        ///<summary>
        ///交割月
        ///</summary>
        [DataMember(Order = 8)]
        public int DeliveryMonth;
        ///<summary>
        ///市价单最大下单量
        ///</summary>
        [DataMember(Order = 9)]
        public int MaxMarketOrderVolume;
        ///<summary>
        ///市价单最小下单量
        ///</summary>
        [DataMember(Order = 10)]
        public int MinMarketOrderVolume;
        ///<summary>
        ///限价单最大下单量
        ///</summary>
        [DataMember(Order = 11)]
        public int MaxLimitOrderVolume;
        ///<summary>
        ///限价单最小下单量
        ///</summary>
        [DataMember(Order = 12)]
        public int MinLimitOrderVolume;
        ///<summary>
        ///合约数量乘数
        ///</summary>
        [DataMember(Order = 13)]
        public int VolumeMultiple;
        ///<summary>
        ///最小变动价位
        ///</summary>
        [DataMember(Order = 14)]
        public double PriceTick;
        ///<summary>
        ///创建日
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string CreateDate;
        ///<summary>
        ///上市日
        ///</summary>
        [DataMember(Order = 16)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string OpenDate;
        ///<summary>
        ///到期日
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExpireDate;
        ///<summary>
        ///开始交割日
        ///</summary>
        [DataMember(Order = 18)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string StartDelivDate;
        ///<summary>
        ///结束交割日
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string EndDelivDate;
        ///<summary>
        ///合约生命周期状态
        ///</summary>
        [DataMember(Order = 20)]
        public byte InstLifePhase;
        ///<summary>
        ///当前是否交易
        ///</summary>
        [DataMember(Order = 21)]
        public int IsTrading;
        ///<summary>
        ///持仓类型
        ///</summary>
        [DataMember(Order = 22)]
        public byte PositionType;
        ///<summary>
        ///持仓日期类型
        ///</summary>
        [DataMember(Order = 23)]
        public byte PositionDateType;
        ///<summary>
        ///多头保证金率
        ///</summary>
        [DataMember(Order = 24)]
        public double LongMarginRatio;
        ///<summary>
        ///空头保证金率
        ///</summary>
        [DataMember(Order = 25)]
        public double ShortMarginRatio;
        ///<summary>
        ///是否使用大额单边保证金算法
        ///</summary>
        [DataMember(Order = 26)]
        public byte MaxMarginSideAlgorithm;
        ///<summary>
        ///基础商品代码
        ///</summary>
        [DataMember(Order = 27)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string UnderlyingInstrID;
        ///<summary>
        ///执行价
        ///</summary>
        [DataMember(Order = 28)]
        public double StrikePrice;
        ///<summary>
        ///期权类型
        ///</summary>
        [DataMember(Order = 29)]
        public byte OptionsType;
        ///<summary>
        ///合约基础商品乘数
        ///</summary>
        [DataMember(Order = 30)]
        public double UnderlyingMultiple;
        ///<summary>
        ///组合类型
        ///</summary>
        [DataMember(Order = 31)]
        public byte CombinationType;

        public static byte[] GetData(CtpInstrument obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.InstrumentID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.InstrumentName);
                writer.Write(obj.ExchangeInstID);
                writer.Write(obj.ProductID);
                writer.Write(obj.ProductClass);
                writer.Write(obj.DeliveryYear);
                writer.Write(obj.DeliveryMonth);
                writer.Write(obj.MaxMarketOrderVolume);
                writer.Write(obj.MinMarketOrderVolume);
                writer.Write(obj.MaxLimitOrderVolume);
                writer.Write(obj.MinLimitOrderVolume);
                writer.Write(obj.VolumeMultiple);
                writer.Write(obj.PriceTick);
                writer.Write(obj.CreateDate);
                writer.Write(obj.OpenDate);
                writer.Write(obj.ExpireDate);
                writer.Write(obj.StartDelivDate);
                writer.Write(obj.EndDelivDate);
                writer.Write(obj.InstLifePhase);
                writer.Write(obj.IsTrading);
                writer.Write(obj.PositionType);
                writer.Write(obj.PositionDateType);
                writer.Write(obj.LongMarginRatio);
                writer.Write(obj.ShortMarginRatio);
                writer.Write(obj.MaxMarginSideAlgorithm);
                writer.Write(obj.UnderlyingInstrID);
                writer.Write(obj.StrikePrice);
                writer.Write(obj.OptionsType);
                writer.Write(obj.UnderlyingMultiple);
                writer.Write(obj.CombinationType);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///经纪公司
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpBroker
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///经纪公司简称
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string BrokerAbbr;
        ///<summary>
        ///经纪公司名称
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string BrokerName;
        ///<summary>
        ///是否活跃
        ///</summary>
        [DataMember(Order = 4)]
        public int IsActive;

        public static byte[] GetData(CtpBroker obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.BrokerAbbr);
                writer.Write(obj.BrokerName);
                writer.Write(obj.IsActive);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///交易所交易员
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpTrader
    {
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///密码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Password;
        ///<summary>
        ///安装数量
        ///</summary>
        [DataMember(Order = 5)]
        public int InstallCount;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;

        public static byte[] GetData(CtpTrader obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ExchangeID);
                writer.Write(obj.TraderID);
                writer.Write(obj.ParticipantID);
                writer.Write(obj.Password);
                writer.Write(obj.InstallCount);
                writer.Write(obj.BrokerID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///投资者
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpInvestor
    {
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者分组代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorGroupID;
        ///<summary>
        ///投资者名称
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string InvestorName;
        ///<summary>
        ///证件类型
        ///</summary>
        [DataMember(Order = 5)]
        public byte IdentifiedCardType;
        ///<summary>
        ///证件号码
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string IdentifiedCardNo;
        ///<summary>
        ///是否活跃
        ///</summary>
        [DataMember(Order = 7)]
        public int IsActive;
        ///<summary>
        ///联系电话
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Telephone;
        ///<summary>
        ///通讯地址
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
        public string Address;
        ///<summary>
        ///开户日期
        ///</summary>
        [DataMember(Order = 10)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string OpenDate;
        ///<summary>
        ///手机
        ///</summary>
        [DataMember(Order = 11)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Mobile;
        ///<summary>
        ///手续费率模板代码
        ///</summary>
        [DataMember(Order = 12)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string CommModelID;
        ///<summary>
        ///保证金率模板代码
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string MarginModelID;

        public static byte[] GetData(CtpInvestor obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.InvestorID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorGroupID);
                writer.Write(obj.InvestorName);
                writer.Write(obj.IdentifiedCardType);
                writer.Write(obj.IdentifiedCardNo);
                writer.Write(obj.IsActive);
                writer.Write(obj.Telephone);
                writer.Write(obj.Address);
                writer.Write(obj.OpenDate);
                writer.Write(obj.Mobile);
                writer.Write(obj.CommModelID);
                writer.Write(obj.MarginModelID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///交易编码
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpTradingCode
    {
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///客户代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClientID;
        ///<summary>
        ///是否活跃
        ///</summary>
        [DataMember(Order = 5)]
        public int IsActive;
        ///<summary>
        ///交易编码类型
        ///</summary>
        [DataMember(Order = 6)]
        public byte ClientIDType;

        public static byte[] GetData(CtpTradingCode obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.InvestorID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ClientID);
                writer.Write(obj.IsActive);
                writer.Write(obj.ClientIDType);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///会员编码和经纪公司编码对照表
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpPartBroker
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///是否活跃
        ///</summary>
        [DataMember(Order = 4)]
        public int IsActive;

        public static byte[] GetData(CtpPartBroker obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ParticipantID);
                writer.Write(obj.IsActive);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///管理用户
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpSuperUser
    {
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///用户名称
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string UserName;
        ///<summary>
        ///密码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Password;
        ///<summary>
        ///是否活跃
        ///</summary>
        [DataMember(Order = 4)]
        public int IsActive;

        public static byte[] GetData(CtpSuperUser obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.UserID);
                writer.Write(obj.UserName);
                writer.Write(obj.Password);
                writer.Write(obj.IsActive);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///管理用户功能权限
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpSuperUserFunction
    {
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///功能代码
        ///</summary>
        [DataMember(Order = 2)]
        public byte FunctionCode;

        public static byte[] GetData(CtpSuperUserFunction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.UserID);
                writer.Write(obj.FunctionCode);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///投资者组
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpInvestorGroup
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者分组代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorGroupID;
        ///<summary>
        ///投资者分组名称
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string InvestorGroupName;

        public static byte[] GetData(CtpInvestorGroup obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorGroupID);
                writer.Write(obj.InvestorGroupName);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///资金账户
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpTradingAccount
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者帐号
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string AccountID;
        ///<summary>
        ///上次质押金额
        ///</summary>
        [DataMember(Order = 3)]
        public double PreMortgage;
        ///<summary>
        ///上次信用额度
        ///</summary>
        [DataMember(Order = 4)]
        public double PreCredit;
        ///<summary>
        ///上次存款额
        ///</summary>
        [DataMember(Order = 5)]
        public double PreDeposit;
        ///<summary>
        ///上次结算准备金
        ///</summary>
        [DataMember(Order = 6)]
        public double PreBalance;
        ///<summary>
        ///上次占用的保证金
        ///</summary>
        [DataMember(Order = 7)]
        public double PreMargin;
        ///<summary>
        ///利息基数
        ///</summary>
        [DataMember(Order = 8)]
        public double InterestBase;
        ///<summary>
        ///利息收入
        ///</summary>
        [DataMember(Order = 9)]
        public double Interest;
        ///<summary>
        ///入金金额
        ///</summary>
        [DataMember(Order = 10)]
        public double Deposit;
        ///<summary>
        ///出金金额
        ///</summary>
        [DataMember(Order = 11)]
        public double Withdraw;
        ///<summary>
        ///冻结的保证金
        ///</summary>
        [DataMember(Order = 12)]
        public double FrozenMargin;
        ///<summary>
        ///冻结的资金
        ///</summary>
        [DataMember(Order = 13)]
        public double FrozenCash;
        ///<summary>
        ///冻结的手续费
        ///</summary>
        [DataMember(Order = 14)]
        public double FrozenCommission;
        ///<summary>
        ///当前保证金总额
        ///</summary>
        [DataMember(Order = 15)]
        public double CurrMargin;
        ///<summary>
        ///资金差额
        ///</summary>
        [DataMember(Order = 16)]
        public double CashIn;
        ///<summary>
        ///手续费
        ///</summary>
        [DataMember(Order = 17)]
        public double Commission;
        ///<summary>
        ///平仓盈亏
        ///</summary>
        [DataMember(Order = 18)]
        public double CloseProfit;
        ///<summary>
        ///持仓盈亏
        ///</summary>
        [DataMember(Order = 19)]
        public double PositionProfit;
        ///<summary>
        ///期货结算准备金
        ///</summary>
        [DataMember(Order = 20)]
        public double Balance;
        ///<summary>
        ///可用资金
        ///</summary>
        [DataMember(Order = 21)]
        public double Available;
        ///<summary>
        ///可取资金
        ///</summary>
        [DataMember(Order = 22)]
        public double WithdrawQuota;
        ///<summary>
        ///基本准备金
        ///</summary>
        [DataMember(Order = 23)]
        public double Reserve;
        ///<summary>
        ///交易日
        ///</summary>
        [DataMember(Order = 24)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///结算编号
        ///</summary>
        [DataMember(Order = 25)]
        public int SettlementID;
        ///<summary>
        ///信用额度
        ///</summary>
        [DataMember(Order = 26)]
        public double Credit;
        ///<summary>
        ///质押金额
        ///</summary>
        [DataMember(Order = 27)]
        public double Mortgage;
        ///<summary>
        ///交易所保证金
        ///</summary>
        [DataMember(Order = 28)]
        public double ExchangeMargin;
        ///<summary>
        ///投资者交割保证金
        ///</summary>
        [DataMember(Order = 29)]
        public double DeliveryMargin;
        ///<summary>
        ///交易所交割保证金
        ///</summary>
        [DataMember(Order = 30)]
        public double ExchangeDeliveryMargin;
        ///<summary>
        ///保底期货结算准备金
        ///</summary>
        [DataMember(Order = 31)]
        public double ReserveBalance;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 32)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;
        ///<summary>
        ///上次货币质入金额
        ///</summary>
        [DataMember(Order = 33)]
        public double PreFundMortgageIn;
        ///<summary>
        ///上次货币质出金额
        ///</summary>
        [DataMember(Order = 34)]
        public double PreFundMortgageOut;
        ///<summary>
        ///货币质入金额
        ///</summary>
        [DataMember(Order = 35)]
        public double FundMortgageIn;
        ///<summary>
        ///货币质出金额
        ///</summary>
        [DataMember(Order = 36)]
        public double FundMortgageOut;
        ///<summary>
        ///货币质押余额
        ///</summary>
        [DataMember(Order = 37)]
        public double FundMortgageAvailable;
        ///<summary>
        ///可质押货币金额
        ///</summary>
        [DataMember(Order = 38)]
        public double MortgageableFund;
        ///<summary>
        ///特殊产品占用保证金
        ///</summary>
        [DataMember(Order = 39)]
        public double SpecProductMargin;
        ///<summary>
        ///特殊产品冻结保证金
        ///</summary>
        [DataMember(Order = 40)]
        public double SpecProductFrozenMargin;
        ///<summary>
        ///特殊产品手续费
        ///</summary>
        [DataMember(Order = 41)]
        public double SpecProductCommission;
        ///<summary>
        ///特殊产品冻结手续费
        ///</summary>
        [DataMember(Order = 42)]
        public double SpecProductFrozenCommission;
        ///<summary>
        ///特殊产品持仓盈亏
        ///</summary>
        [DataMember(Order = 43)]
        public double SpecProductPositionProfit;
        ///<summary>
        ///特殊产品平仓盈亏
        ///</summary>
        [DataMember(Order = 44)]
        public double SpecProductCloseProfit;
        ///<summary>
        ///根据持仓盈亏算法计算的特殊产品持仓盈亏
        ///</summary>
        [DataMember(Order = 45)]
        public double SpecProductPositionProfitByAlg;
        ///<summary>
        ///特殊产品交易所保证金
        ///</summary>
        [DataMember(Order = 46)]
        public double SpecProductExchangeMargin;

        public static byte[] GetData(CtpTradingAccount obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.AccountID);
                writer.Write(obj.PreMortgage);
                writer.Write(obj.PreCredit);
                writer.Write(obj.PreDeposit);
                writer.Write(obj.PreBalance);
                writer.Write(obj.PreMargin);
                writer.Write(obj.InterestBase);
                writer.Write(obj.Interest);
                writer.Write(obj.Deposit);
                writer.Write(obj.Withdraw);
                writer.Write(obj.FrozenMargin);
                writer.Write(obj.FrozenCash);
                writer.Write(obj.FrozenCommission);
                writer.Write(obj.CurrMargin);
                writer.Write(obj.CashIn);
                writer.Write(obj.Commission);
                writer.Write(obj.CloseProfit);
                writer.Write(obj.PositionProfit);
                writer.Write(obj.Balance);
                writer.Write(obj.Available);
                writer.Write(obj.WithdrawQuota);
                writer.Write(obj.Reserve);
                writer.Write(obj.TradingDay);
                writer.Write(obj.SettlementID);
                writer.Write(obj.Credit);
                writer.Write(obj.Mortgage);
                writer.Write(obj.ExchangeMargin);
                writer.Write(obj.DeliveryMargin);
                writer.Write(obj.ExchangeDeliveryMargin);
                writer.Write(obj.ReserveBalance);
                writer.Write(obj.CurrencyID);
                writer.Write(obj.PreFundMortgageIn);
                writer.Write(obj.PreFundMortgageOut);
                writer.Write(obj.FundMortgageIn);
                writer.Write(obj.FundMortgageOut);
                writer.Write(obj.FundMortgageAvailable);
                writer.Write(obj.MortgageableFund);
                writer.Write(obj.SpecProductMargin);
                writer.Write(obj.SpecProductFrozenMargin);
                writer.Write(obj.SpecProductCommission);
                writer.Write(obj.SpecProductFrozenCommission);
                writer.Write(obj.SpecProductPositionProfit);
                writer.Write(obj.SpecProductCloseProfit);
                writer.Write(obj.SpecProductPositionProfitByAlg);
                writer.Write(obj.SpecProductExchangeMargin);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///投资者持仓
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpInvestorPosition
    {
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///持仓多空方向
        ///</summary>
        [DataMember(Order = 4)]
        public byte PosiDirection;
        ///<summary>
        ///投机套保标志
        ///</summary>
        [DataMember(Order = 5)]
        public byte HedgeFlag;
        ///<summary>
        ///持仓日期
        ///</summary>
        [DataMember(Order = 6)]
        public byte PositionDate;
        ///<summary>
        ///上日持仓
        ///</summary>
        [DataMember(Order = 7)]
        public int YdPosition;
        ///<summary>
        ///今日持仓
        ///</summary>
        [DataMember(Order = 8)]
        public int Position;
        ///<summary>
        ///多头冻结
        ///</summary>
        [DataMember(Order = 9)]
        public int LongFrozen;
        ///<summary>
        ///空头冻结
        ///</summary>
        [DataMember(Order = 10)]
        public int ShortFrozen;
        ///<summary>
        ///开仓冻结金额
        ///</summary>
        [DataMember(Order = 11)]
        public double LongFrozenAmount;
        ///<summary>
        ///开仓冻结金额
        ///</summary>
        [DataMember(Order = 12)]
        public double ShortFrozenAmount;
        ///<summary>
        ///开仓量
        ///</summary>
        [DataMember(Order = 13)]
        public int OpenVolume;
        ///<summary>
        ///平仓量
        ///</summary>
        [DataMember(Order = 14)]
        public int CloseVolume;
        ///<summary>
        ///开仓金额
        ///</summary>
        [DataMember(Order = 15)]
        public double OpenAmount;
        ///<summary>
        ///平仓金额
        ///</summary>
        [DataMember(Order = 16)]
        public double CloseAmount;
        ///<summary>
        ///持仓成本
        ///</summary>
        [DataMember(Order = 17)]
        public double PositionCost;
        ///<summary>
        ///上次占用的保证金
        ///</summary>
        [DataMember(Order = 18)]
        public double PreMargin;
        ///<summary>
        ///占用的保证金
        ///</summary>
        [DataMember(Order = 19)]
        public double UseMargin;
        ///<summary>
        ///冻结的保证金
        ///</summary>
        [DataMember(Order = 20)]
        public double FrozenMargin;
        ///<summary>
        ///冻结的资金
        ///</summary>
        [DataMember(Order = 21)]
        public double FrozenCash;
        ///<summary>
        ///冻结的手续费
        ///</summary>
        [DataMember(Order = 22)]
        public double FrozenCommission;
        ///<summary>
        ///资金差额
        ///</summary>
        [DataMember(Order = 23)]
        public double CashIn;
        ///<summary>
        ///手续费
        ///</summary>
        [DataMember(Order = 24)]
        public double Commission;
        ///<summary>
        ///平仓盈亏
        ///</summary>
        [DataMember(Order = 25)]
        public double CloseProfit;
        ///<summary>
        ///持仓盈亏
        ///</summary>
        [DataMember(Order = 26)]
        public double PositionProfit;
        ///<summary>
        ///上次结算价
        ///</summary>
        [DataMember(Order = 27)]
        public double PreSettlementPrice;
        ///<summary>
        ///本次结算价
        ///</summary>
        [DataMember(Order = 28)]
        public double SettlementPrice;
        ///<summary>
        ///交易日
        ///</summary>
        [DataMember(Order = 29)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///结算编号
        ///</summary>
        [DataMember(Order = 30)]
        public int SettlementID;
        ///<summary>
        ///开仓成本
        ///</summary>
        [DataMember(Order = 31)]
        public double OpenCost;
        ///<summary>
        ///交易所保证金
        ///</summary>
        [DataMember(Order = 32)]
        public double ExchangeMargin;
        ///<summary>
        ///组合成交形成的持仓
        ///</summary>
        [DataMember(Order = 33)]
        public int CombPosition;
        ///<summary>
        ///组合多头冻结
        ///</summary>
        [DataMember(Order = 34)]
        public int CombLongFrozen;
        ///<summary>
        ///组合空头冻结
        ///</summary>
        [DataMember(Order = 35)]
        public int CombShortFrozen;
        ///<summary>
        ///逐日盯市平仓盈亏
        ///</summary>
        [DataMember(Order = 36)]
        public double CloseProfitByDate;
        ///<summary>
        ///逐笔对冲平仓盈亏
        ///</summary>
        [DataMember(Order = 37)]
        public double CloseProfitByTrade;
        ///<summary>
        ///今日持仓
        ///</summary>
        [DataMember(Order = 38)]
        public int TodayPosition;
        ///<summary>
        ///保证金率
        ///</summary>
        [DataMember(Order = 39)]
        public double MarginRateByMoney;
        ///<summary>
        ///保证金率(按手数)
        ///</summary>
        [DataMember(Order = 40)]
        public double MarginRateByVolume;
        ///<summary>
        ///执行冻结
        ///</summary>
        [DataMember(Order = 41)]
        public int StrikeFrozen;
        ///<summary>
        ///执行冻结金额
        ///</summary>
        [DataMember(Order = 42)]
        public double StrikeFrozenAmount;
        ///<summary>
        ///放弃执行冻结
        ///</summary>
        [DataMember(Order = 43)]
        public int AbandonFrozen;

        public static byte[] GetData(CtpInvestorPosition obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.InstrumentID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.PosiDirection);
                writer.Write(obj.HedgeFlag);
                writer.Write(obj.PositionDate);
                writer.Write(obj.YdPosition);
                writer.Write(obj.Position);
                writer.Write(obj.LongFrozen);
                writer.Write(obj.ShortFrozen);
                writer.Write(obj.LongFrozenAmount);
                writer.Write(obj.ShortFrozenAmount);
                writer.Write(obj.OpenVolume);
                writer.Write(obj.CloseVolume);
                writer.Write(obj.OpenAmount);
                writer.Write(obj.CloseAmount);
                writer.Write(obj.PositionCost);
                writer.Write(obj.PreMargin);
                writer.Write(obj.UseMargin);
                writer.Write(obj.FrozenMargin);
                writer.Write(obj.FrozenCash);
                writer.Write(obj.FrozenCommission);
                writer.Write(obj.CashIn);
                writer.Write(obj.Commission);
                writer.Write(obj.CloseProfit);
                writer.Write(obj.PositionProfit);
                writer.Write(obj.PreSettlementPrice);
                writer.Write(obj.SettlementPrice);
                writer.Write(obj.TradingDay);
                writer.Write(obj.SettlementID);
                writer.Write(obj.OpenCost);
                writer.Write(obj.ExchangeMargin);
                writer.Write(obj.CombPosition);
                writer.Write(obj.CombLongFrozen);
                writer.Write(obj.CombShortFrozen);
                writer.Write(obj.CloseProfitByDate);
                writer.Write(obj.CloseProfitByTrade);
                writer.Write(obj.TodayPosition);
                writer.Write(obj.MarginRateByMoney);
                writer.Write(obj.MarginRateByVolume);
                writer.Write(obj.StrikeFrozen);
                writer.Write(obj.StrikeFrozenAmount);
                writer.Write(obj.AbandonFrozen);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///合约保证金率
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpInstrumentMarginRate
    {
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///投资者范围
        ///</summary>
        [DataMember(Order = 2)]
        public byte InvestorRange;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///投机套保标志
        ///</summary>
        [DataMember(Order = 5)]
        public byte HedgeFlag;
        ///<summary>
        ///多头保证金率
        ///</summary>
        [DataMember(Order = 6)]
        public double LongMarginRatioByMoney;
        ///<summary>
        ///多头保证金费
        ///</summary>
        [DataMember(Order = 7)]
        public double LongMarginRatioByVolume;
        ///<summary>
        ///空头保证金率
        ///</summary>
        [DataMember(Order = 8)]
        public double ShortMarginRatioByMoney;
        ///<summary>
        ///空头保证金费
        ///</summary>
        [DataMember(Order = 9)]
        public double ShortMarginRatioByVolume;
        ///<summary>
        ///是否相对交易所收取
        ///</summary>
        [DataMember(Order = 10)]
        public int IsRelative;

        public static byte[] GetData(CtpInstrumentMarginRate obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.InstrumentID);
                writer.Write(obj.InvestorRange);
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.HedgeFlag);
                writer.Write(obj.LongMarginRatioByMoney);
                writer.Write(obj.LongMarginRatioByVolume);
                writer.Write(obj.ShortMarginRatioByMoney);
                writer.Write(obj.ShortMarginRatioByVolume);
                writer.Write(obj.IsRelative);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///合约手续费率
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpInstrumentCommissionRate
    {
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///投资者范围
        ///</summary>
        [DataMember(Order = 2)]
        public byte InvestorRange;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///开仓手续费率
        ///</summary>
        [DataMember(Order = 5)]
        public double OpenRatioByMoney;
        ///<summary>
        ///开仓手续费
        ///</summary>
        [DataMember(Order = 6)]
        public double OpenRatioByVolume;
        ///<summary>
        ///平仓手续费率
        ///</summary>
        [DataMember(Order = 7)]
        public double CloseRatioByMoney;
        ///<summary>
        ///平仓手续费
        ///</summary>
        [DataMember(Order = 8)]
        public double CloseRatioByVolume;
        ///<summary>
        ///平今手续费率
        ///</summary>
        [DataMember(Order = 9)]
        public double CloseTodayRatioByMoney;
        ///<summary>
        ///平今手续费
        ///</summary>
        [DataMember(Order = 10)]
        public double CloseTodayRatioByVolume;

        public static byte[] GetData(CtpInstrumentCommissionRate obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.InstrumentID);
                writer.Write(obj.InvestorRange);
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.OpenRatioByMoney);
                writer.Write(obj.OpenRatioByVolume);
                writer.Write(obj.CloseRatioByMoney);
                writer.Write(obj.CloseRatioByVolume);
                writer.Write(obj.CloseTodayRatioByMoney);
                writer.Write(obj.CloseTodayRatioByVolume);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///深度行情
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpDepthMarketData
    {
        ///<summary>
        ///交易日
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///合约在交易所的代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ExchangeInstID;
        ///<summary>
        ///最新价
        ///</summary>
        [DataMember(Order = 5)]
        public double LastPrice;
        ///<summary>
        ///上次结算价
        ///</summary>
        [DataMember(Order = 6)]
        public double PreSettlementPrice;
        ///<summary>
        ///昨收盘
        ///</summary>
        [DataMember(Order = 7)]
        public double PreClosePrice;
        ///<summary>
        ///昨持仓量
        ///</summary>
        [DataMember(Order = 8)]
        public double PreOpenInterest;
        ///<summary>
        ///今开盘
        ///</summary>
        [DataMember(Order = 9)]
        public double OpenPrice;
        ///<summary>
        ///最高价
        ///</summary>
        [DataMember(Order = 10)]
        public double HighestPrice;
        ///<summary>
        ///最低价
        ///</summary>
        [DataMember(Order = 11)]
        public double LowestPrice;
        ///<summary>
        ///数量
        ///</summary>
        [DataMember(Order = 12)]
        public int Volume;
        ///<summary>
        ///成交金额
        ///</summary>
        [DataMember(Order = 13)]
        public double Turnover;
        ///<summary>
        ///持仓量
        ///</summary>
        [DataMember(Order = 14)]
        public double OpenInterest;
        ///<summary>
        ///今收盘
        ///</summary>
        [DataMember(Order = 15)]
        public double ClosePrice;
        ///<summary>
        ///本次结算价
        ///</summary>
        [DataMember(Order = 16)]
        public double SettlementPrice;
        ///<summary>
        ///涨停板价
        ///</summary>
        [DataMember(Order = 17)]
        public double UpperLimitPrice;
        ///<summary>
        ///跌停板价
        ///</summary>
        [DataMember(Order = 18)]
        public double LowerLimitPrice;
        ///<summary>
        ///昨虚实度
        ///</summary>
        [DataMember(Order = 19)]
        public double PreDelta;
        ///<summary>
        ///今虚实度
        ///</summary>
        [DataMember(Order = 20)]
        public double CurrDelta;
        ///<summary>
        ///最后修改时间
        ///</summary>
        [DataMember(Order = 21)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string UpdateTime;
        ///<summary>
        ///最后修改毫秒
        ///</summary>
        [DataMember(Order = 22)]
        public int UpdateMillisec;
        ///<summary>
        ///申买价一
        ///</summary>
        [DataMember(Order = 23)]
        public double BidPrice1;
        ///<summary>
        ///申买量一
        ///</summary>
        [DataMember(Order = 24)]
        public int BidVolume1;
        ///<summary>
        ///申卖价一
        ///</summary>
        [DataMember(Order = 25)]
        public double AskPrice1;
        ///<summary>
        ///申卖量一
        ///</summary>
        [DataMember(Order = 26)]
        public int AskVolume1;
        ///<summary>
        ///申买价二
        ///</summary>
        [DataMember(Order = 27)]
        public double BidPrice2;
        ///<summary>
        ///申买量二
        ///</summary>
        [DataMember(Order = 28)]
        public int BidVolume2;
        ///<summary>
        ///申卖价二
        ///</summary>
        [DataMember(Order = 29)]
        public double AskPrice2;
        ///<summary>
        ///申卖量二
        ///</summary>
        [DataMember(Order = 30)]
        public int AskVolume2;
        ///<summary>
        ///申买价三
        ///</summary>
        [DataMember(Order = 31)]
        public double BidPrice3;
        ///<summary>
        ///申买量三
        ///</summary>
        [DataMember(Order = 32)]
        public int BidVolume3;
        ///<summary>
        ///申卖价三
        ///</summary>
        [DataMember(Order = 33)]
        public double AskPrice3;
        ///<summary>
        ///申卖量三
        ///</summary>
        [DataMember(Order = 34)]
        public int AskVolume3;
        ///<summary>
        ///申买价四
        ///</summary>
        [DataMember(Order = 35)]
        public double BidPrice4;
        ///<summary>
        ///申买量四
        ///</summary>
        [DataMember(Order = 36)]
        public int BidVolume4;
        ///<summary>
        ///申卖价四
        ///</summary>
        [DataMember(Order = 37)]
        public double AskPrice4;
        ///<summary>
        ///申卖量四
        ///</summary>
        [DataMember(Order = 38)]
        public int AskVolume4;
        ///<summary>
        ///申买价五
        ///</summary>
        [DataMember(Order = 39)]
        public double BidPrice5;
        ///<summary>
        ///申买量五
        ///</summary>
        [DataMember(Order = 40)]
        public int BidVolume5;
        ///<summary>
        ///申卖价五
        ///</summary>
        [DataMember(Order = 41)]
        public double AskPrice5;
        ///<summary>
        ///申卖量五
        ///</summary>
        [DataMember(Order = 42)]
        public int AskVolume5;
        ///<summary>
        ///当日均价
        ///</summary>
        [DataMember(Order = 43)]
        public double AveragePrice;
        ///<summary>
        ///业务日期
        ///</summary>
        [DataMember(Order = 44)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ActionDay;

        public static byte[] GetData(CtpDepthMarketData obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradingDay);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ExchangeInstID);
                writer.Write(obj.LastPrice);
                writer.Write(obj.PreSettlementPrice);
                writer.Write(obj.PreClosePrice);
                writer.Write(obj.PreOpenInterest);
                writer.Write(obj.OpenPrice);
                writer.Write(obj.HighestPrice);
                writer.Write(obj.LowestPrice);
                writer.Write(obj.Volume);
                writer.Write(obj.Turnover);
                writer.Write(obj.OpenInterest);
                writer.Write(obj.ClosePrice);
                writer.Write(obj.SettlementPrice);
                writer.Write(obj.UpperLimitPrice);
                writer.Write(obj.LowerLimitPrice);
                writer.Write(obj.PreDelta);
                writer.Write(obj.CurrDelta);
                writer.Write(obj.UpdateTime);
                writer.Write(obj.UpdateMillisec);
                writer.Write(obj.BidPrice1);
                writer.Write(obj.BidVolume1);
                writer.Write(obj.AskPrice1);
                writer.Write(obj.AskVolume1);
                writer.Write(obj.BidPrice2);
                writer.Write(obj.BidVolume2);
                writer.Write(obj.AskPrice2);
                writer.Write(obj.AskVolume2);
                writer.Write(obj.BidPrice3);
                writer.Write(obj.BidVolume3);
                writer.Write(obj.AskPrice3);
                writer.Write(obj.AskVolume3);
                writer.Write(obj.BidPrice4);
                writer.Write(obj.BidVolume4);
                writer.Write(obj.AskPrice4);
                writer.Write(obj.AskVolume4);
                writer.Write(obj.BidPrice5);
                writer.Write(obj.BidVolume5);
                writer.Write(obj.AskPrice5);
                writer.Write(obj.AskVolume5);
                writer.Write(obj.AveragePrice);
                writer.Write(obj.ActionDay);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///投资者合约交易权限
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpInstrumentTradingRight
    {
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///投资者范围
        ///</summary>
        [DataMember(Order = 2)]
        public byte InvestorRange;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///交易权限
        ///</summary>
        [DataMember(Order = 5)]
        public byte TradingRight;

        public static byte[] GetData(CtpInstrumentTradingRight obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.InstrumentID);
                writer.Write(obj.InvestorRange);
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.TradingRight);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///经纪公司用户
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpBrokerUser
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///用户名称
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string UserName;
        ///<summary>
        ///用户类型
        ///</summary>
        [DataMember(Order = 4)]
        public byte UserType;
        ///<summary>
        ///是否活跃
        ///</summary>
        [DataMember(Order = 5)]
        public int IsActive;
        ///<summary>
        ///是否使用令牌
        ///</summary>
        [DataMember(Order = 6)]
        public int IsUsingOTP;

        public static byte[] GetData(CtpBrokerUser obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.UserID);
                writer.Write(obj.UserName);
                writer.Write(obj.UserType);
                writer.Write(obj.IsActive);
                writer.Write(obj.IsUsingOTP);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///经纪公司用户口令
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpBrokerUserPassword
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///密码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Password;

        public static byte[] GetData(CtpBrokerUserPassword obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.UserID);
                writer.Write(obj.Password);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///经纪公司用户功能权限
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpBrokerUserFunction
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///经纪公司功能代码
        ///</summary>
        [DataMember(Order = 3)]
        public byte BrokerFunctionCode;

        public static byte[] GetData(CtpBrokerUserFunction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.UserID);
                writer.Write(obj.BrokerFunctionCode);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///交易所交易员报盘机
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpTraderOffer
    {
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///密码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Password;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 5)]
        public int InstallID;
        ///<summary>
        ///本地报单编号
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string OrderLocalID;
        ///<summary>
        ///交易所交易员连接状态
        ///</summary>
        [DataMember(Order = 7)]
        public byte TraderConnectStatus;
        ///<summary>
        ///发出连接请求的日期
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ConnectRequestDate;
        ///<summary>
        ///发出连接请求的时间
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ConnectRequestTime;
        ///<summary>
        ///上次报告日期
        ///</summary>
        [DataMember(Order = 10)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string LastReportDate;
        ///<summary>
        ///上次报告时间
        ///</summary>
        [DataMember(Order = 11)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string LastReportTime;
        ///<summary>
        ///完成连接日期
        ///</summary>
        [DataMember(Order = 12)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ConnectDate;
        ///<summary>
        ///完成连接时间
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ConnectTime;
        ///<summary>
        ///启动日期
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string StartDate;
        ///<summary>
        ///启动时间
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string StartTime;
        ///<summary>
        ///交易日
        ///</summary>
        [DataMember(Order = 16)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///本席位最大成交编号
        ///</summary>
        [DataMember(Order = 18)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string MaxTradeID;
        ///<summary>
        ///本席位最大报单备拷
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string MaxOrderMessageReference;

        public static byte[] GetData(CtpTraderOffer obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ExchangeID);
                writer.Write(obj.TraderID);
                writer.Write(obj.ParticipantID);
                writer.Write(obj.Password);
                writer.Write(obj.InstallID);
                writer.Write(obj.OrderLocalID);
                writer.Write(obj.TraderConnectStatus);
                writer.Write(obj.ConnectRequestDate);
                writer.Write(obj.ConnectRequestTime);
                writer.Write(obj.LastReportDate);
                writer.Write(obj.LastReportTime);
                writer.Write(obj.ConnectDate);
                writer.Write(obj.ConnectTime);
                writer.Write(obj.StartDate);
                writer.Write(obj.StartTime);
                writer.Write(obj.TradingDay);
                writer.Write(obj.BrokerID);
                writer.Write(obj.MaxTradeID);
                writer.Write(obj.MaxOrderMessageReference);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///投资者结算结果
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpSettlementInfo
    {
        ///<summary>
        ///交易日
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///结算编号
        ///</summary>
        [DataMember(Order = 2)]
        public int SettlementID;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///序号
        ///</summary>
        [DataMember(Order = 5)]
        public int SequenceNo;
        ///<summary>
        ///消息正文
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 501)]
        public string Content;

        public static byte[] GetData(CtpSettlementInfo obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradingDay);
                writer.Write(obj.SettlementID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.SequenceNo);
                writer.Write(obj.Content);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///合约保证金率调整
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpInstrumentMarginRateAdjust
    {
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///投资者范围
        ///</summary>
        [DataMember(Order = 2)]
        public byte InvestorRange;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///投机套保标志
        ///</summary>
        [DataMember(Order = 5)]
        public byte HedgeFlag;
        ///<summary>
        ///多头保证金率
        ///</summary>
        [DataMember(Order = 6)]
        public double LongMarginRatioByMoney;
        ///<summary>
        ///多头保证金费
        ///</summary>
        [DataMember(Order = 7)]
        public double LongMarginRatioByVolume;
        ///<summary>
        ///空头保证金率
        ///</summary>
        [DataMember(Order = 8)]
        public double ShortMarginRatioByMoney;
        ///<summary>
        ///空头保证金费
        ///</summary>
        [DataMember(Order = 9)]
        public double ShortMarginRatioByVolume;
        ///<summary>
        ///是否相对交易所收取
        ///</summary>
        [DataMember(Order = 10)]
        public int IsRelative;

        public static byte[] GetData(CtpInstrumentMarginRateAdjust obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.InstrumentID);
                writer.Write(obj.InvestorRange);
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.HedgeFlag);
                writer.Write(obj.LongMarginRatioByMoney);
                writer.Write(obj.LongMarginRatioByVolume);
                writer.Write(obj.ShortMarginRatioByMoney);
                writer.Write(obj.ShortMarginRatioByVolume);
                writer.Write(obj.IsRelative);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///交易所保证金率
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpExchangeMarginRate
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///投机套保标志
        ///</summary>
        [DataMember(Order = 3)]
        public byte HedgeFlag;
        ///<summary>
        ///多头保证金率
        ///</summary>
        [DataMember(Order = 4)]
        public double LongMarginRatioByMoney;
        ///<summary>
        ///多头保证金费
        ///</summary>
        [DataMember(Order = 5)]
        public double LongMarginRatioByVolume;
        ///<summary>
        ///空头保证金率
        ///</summary>
        [DataMember(Order = 6)]
        public double ShortMarginRatioByMoney;
        ///<summary>
        ///空头保证金费
        ///</summary>
        [DataMember(Order = 7)]
        public double ShortMarginRatioByVolume;

        public static byte[] GetData(CtpExchangeMarginRate obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.HedgeFlag);
                writer.Write(obj.LongMarginRatioByMoney);
                writer.Write(obj.LongMarginRatioByVolume);
                writer.Write(obj.ShortMarginRatioByMoney);
                writer.Write(obj.ShortMarginRatioByVolume);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///交易所保证金率调整
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpExchangeMarginRateAdjust
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///投机套保标志
        ///</summary>
        [DataMember(Order = 3)]
        public byte HedgeFlag;
        ///<summary>
        ///跟随交易所投资者多头保证金率
        ///</summary>
        [DataMember(Order = 4)]
        public double LongMarginRatioByMoney;
        ///<summary>
        ///跟随交易所投资者多头保证金费
        ///</summary>
        [DataMember(Order = 5)]
        public double LongMarginRatioByVolume;
        ///<summary>
        ///跟随交易所投资者空头保证金率
        ///</summary>
        [DataMember(Order = 6)]
        public double ShortMarginRatioByMoney;
        ///<summary>
        ///跟随交易所投资者空头保证金费
        ///</summary>
        [DataMember(Order = 7)]
        public double ShortMarginRatioByVolume;
        ///<summary>
        ///交易所多头保证金率
        ///</summary>
        [DataMember(Order = 8)]
        public double ExchLongMarginRatioByMoney;
        ///<summary>
        ///交易所多头保证金费
        ///</summary>
        [DataMember(Order = 9)]
        public double ExchLongMarginRatioByVolume;
        ///<summary>
        ///交易所空头保证金率
        ///</summary>
        [DataMember(Order = 10)]
        public double ExchShortMarginRatioByMoney;
        ///<summary>
        ///交易所空头保证金费
        ///</summary>
        [DataMember(Order = 11)]
        public double ExchShortMarginRatioByVolume;
        ///<summary>
        ///不跟随交易所投资者多头保证金率
        ///</summary>
        [DataMember(Order = 12)]
        public double NoLongMarginRatioByMoney;
        ///<summary>
        ///不跟随交易所投资者多头保证金费
        ///</summary>
        [DataMember(Order = 13)]
        public double NoLongMarginRatioByVolume;
        ///<summary>
        ///不跟随交易所投资者空头保证金率
        ///</summary>
        [DataMember(Order = 14)]
        public double NoShortMarginRatioByMoney;
        ///<summary>
        ///不跟随交易所投资者空头保证金费
        ///</summary>
        [DataMember(Order = 15)]
        public double NoShortMarginRatioByVolume;

        public static byte[] GetData(CtpExchangeMarginRateAdjust obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.HedgeFlag);
                writer.Write(obj.LongMarginRatioByMoney);
                writer.Write(obj.LongMarginRatioByVolume);
                writer.Write(obj.ShortMarginRatioByMoney);
                writer.Write(obj.ShortMarginRatioByVolume);
                writer.Write(obj.ExchLongMarginRatioByMoney);
                writer.Write(obj.ExchLongMarginRatioByVolume);
                writer.Write(obj.ExchShortMarginRatioByMoney);
                writer.Write(obj.ExchShortMarginRatioByVolume);
                writer.Write(obj.NoLongMarginRatioByMoney);
                writer.Write(obj.NoLongMarginRatioByVolume);
                writer.Write(obj.NoShortMarginRatioByMoney);
                writer.Write(obj.NoShortMarginRatioByVolume);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///汇率
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpExchangeRate
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///源币种
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string FromCurrencyID;
        ///<summary>
        ///源币种单位数量
        ///</summary>
        [DataMember(Order = 3)]
        public double FromCurrencyUnit;
        ///<summary>
        ///目标币种
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string ToCurrencyID;
        ///<summary>
        ///汇率
        ///</summary>
        [DataMember(Order = 5)]
        public double ExchangeRate;

        public static byte[] GetData(CtpExchangeRate obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.FromCurrencyID);
                writer.Write(obj.FromCurrencyUnit);
                writer.Write(obj.ToCurrencyID);
                writer.Write(obj.ExchangeRate);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///结算引用
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpSettlementRef
    {
        ///<summary>
        ///交易日
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///结算编号
        ///</summary>
        [DataMember(Order = 2)]
        public int SettlementID;

        public static byte[] GetData(CtpSettlementRef obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradingDay);
                writer.Write(obj.SettlementID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///当前时间
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpCurrentTime
    {
        ///<summary>
        ///当前日期
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string CurrDate;
        ///<summary>
        ///当前时间
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string CurrTime;
        ///<summary>
        ///当前时间（毫秒）
        ///</summary>
        [DataMember(Order = 3)]
        public int CurrMillisec;
        ///<summary>
        ///业务日期
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ActionDay;

        public static byte[] GetData(CtpCurrentTime obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.CurrDate);
                writer.Write(obj.CurrTime);
                writer.Write(obj.CurrMillisec);
                writer.Write(obj.ActionDay);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///通讯阶段
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpCommPhase
    {
        ///<summary>
        ///交易日
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///通讯时段编号
        ///</summary>
        [DataMember(Order = 2)]
        public short CommPhaseNo;
        ///<summary>
        ///系统编号
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string SystemID;

        public static byte[] GetData(CtpCommPhase obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradingDay);
                writer.Write(obj.CommPhaseNo);
                writer.Write(obj.SystemID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///登录信息
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpLoginInfo
    {
        ///<summary>
        ///前置编号
        ///</summary>
        [DataMember(Order = 1)]
        public int FrontID;
        ///<summary>
        ///会话编号
        ///</summary>
        [DataMember(Order = 2)]
        public int SessionID;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///登录日期
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string LoginDate;
        ///<summary>
        ///登录时间
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string LoginTime;
        ///<summary>
        ///IP地址
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string IPAddress;
        ///<summary>
        ///用户端产品信息
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string UserProductInfo;
        ///<summary>
        ///接口端产品信息
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string InterfaceProductInfo;
        ///<summary>
        ///协议信息
        ///</summary>
        [DataMember(Order = 10)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ProtocolInfo;
        ///<summary>
        ///系统名称
        ///</summary>
        [DataMember(Order = 11)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string SystemName;
        ///<summary>
        ///密码
        ///</summary>
        [DataMember(Order = 12)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Password;
        ///<summary>
        ///最大报单引用
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string MaxOrderRef;
        ///<summary>
        ///上期所时间
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string SHFETime;
        ///<summary>
        ///大商所时间
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string DCETime;
        ///<summary>
        ///郑商所时间
        ///</summary>
        [DataMember(Order = 16)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string CZCETime;
        ///<summary>
        ///中金所时间
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string FFEXTime;
        ///<summary>
        ///Mac地址
        ///</summary>
        [DataMember(Order = 18)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string MacAddress;
        ///<summary>
        ///动态密码
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string OneTimePassword;
        ///<summary>
        ///能源中心时间
        ///</summary>
        [DataMember(Order = 20)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string INETime;

        public static byte[] GetData(CtpLoginInfo obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.FrontID);
                writer.Write(obj.SessionID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.UserID);
                writer.Write(obj.LoginDate);
                writer.Write(obj.LoginTime);
                writer.Write(obj.IPAddress);
                writer.Write(obj.UserProductInfo);
                writer.Write(obj.InterfaceProductInfo);
                writer.Write(obj.ProtocolInfo);
                writer.Write(obj.SystemName);
                writer.Write(obj.Password);
                writer.Write(obj.MaxOrderRef);
                writer.Write(obj.SHFETime);
                writer.Write(obj.DCETime);
                writer.Write(obj.CZCETime);
                writer.Write(obj.FFEXTime);
                writer.Write(obj.MacAddress);
                writer.Write(obj.OneTimePassword);
                writer.Write(obj.INETime);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///登录信息
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpLogoutAll
    {
        ///<summary>
        ///前置编号
        ///</summary>
        [DataMember(Order = 1)]
        public int FrontID;
        ///<summary>
        ///会话编号
        ///</summary>
        [DataMember(Order = 2)]
        public int SessionID;
        ///<summary>
        ///系统名称
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string SystemName;

        public static byte[] GetData(CtpLogoutAll obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.FrontID);
                writer.Write(obj.SessionID);
                writer.Write(obj.SystemName);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///前置状态
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpFrontStatus
    {
        ///<summary>
        ///前置编号
        ///</summary>
        [DataMember(Order = 1)]
        public int FrontID;
        ///<summary>
        ///上次报告日期
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string LastReportDate;
        ///<summary>
        ///上次报告时间
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string LastReportTime;
        ///<summary>
        ///是否活跃
        ///</summary>
        [DataMember(Order = 4)]
        public int IsActive;

        public static byte[] GetData(CtpFrontStatus obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.FrontID);
                writer.Write(obj.LastReportDate);
                writer.Write(obj.LastReportTime);
                writer.Write(obj.IsActive);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///用户口令变更
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpUserPasswordUpdate
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///原来的口令
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string OldPassword;
        ///<summary>
        ///新的口令
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string NewPassword;

        public static byte[] GetData(CtpUserPasswordUpdate obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.UserID);
                writer.Write(obj.OldPassword);
                writer.Write(obj.NewPassword);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///输入报单
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpInputOrder
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///报单引用
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string OrderRef;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///报单价格条件
        ///</summary>
        [DataMember(Order = 6)]
        public byte OrderPriceType;
        ///<summary>
        ///买卖方向
        ///</summary>
        [DataMember(Order = 7)]
        public byte Direction;
        ///<summary>
        ///组合开平标志
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string CombOffsetFlag;
        ///<summary>
        ///组合投机套保标志
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string CombHedgeFlag;
        ///<summary>
        ///价格
        ///</summary>
        [DataMember(Order = 10)]
        public double LimitPrice;
        ///<summary>
        ///数量
        ///</summary>
        [DataMember(Order = 11)]
        public int VolumeTotalOriginal;
        ///<summary>
        ///有效期类型
        ///</summary>
        [DataMember(Order = 12)]
        public byte TimeCondition;
        ///<summary>
        ///GTD日期
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string GTDDate;
        ///<summary>
        ///成交量类型
        ///</summary>
        [DataMember(Order = 14)]
        public byte VolumeCondition;
        ///<summary>
        ///最小成交量
        ///</summary>
        [DataMember(Order = 15)]
        public int MinVolume;
        ///<summary>
        ///触发条件
        ///</summary>
        [DataMember(Order = 16)]
        public byte ContingentCondition;
        ///<summary>
        ///止损价
        ///</summary>
        [DataMember(Order = 17)]
        public double StopPrice;
        ///<summary>
        ///强平原因
        ///</summary>
        [DataMember(Order = 18)]
        public byte ForceCloseReason;
        ///<summary>
        ///自动挂起标志
        ///</summary>
        [DataMember(Order = 19)]
        public int IsAutoSuspend;
        ///<summary>
        ///业务单元
        ///</summary>
        [DataMember(Order = 20)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string BusinessUnit;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 21)]
        public int RequestID;
        ///<summary>
        ///用户强评标志
        ///</summary>
        [DataMember(Order = 22)]
        public int UserForceClose;
        ///<summary>
        ///互换单标志
        ///</summary>
        [DataMember(Order = 23)]
        public int IsSwapOrder;

        public static byte[] GetData(CtpInputOrder obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.OrderRef);
                writer.Write(obj.UserID);
                writer.Write(obj.OrderPriceType);
                writer.Write(obj.Direction);
                writer.Write(obj.CombOffsetFlag);
                writer.Write(obj.CombHedgeFlag);
                writer.Write(obj.LimitPrice);
                writer.Write(obj.VolumeTotalOriginal);
                writer.Write(obj.TimeCondition);
                writer.Write(obj.GTDDate);
                writer.Write(obj.VolumeCondition);
                writer.Write(obj.MinVolume);
                writer.Write(obj.ContingentCondition);
                writer.Write(obj.StopPrice);
                writer.Write(obj.ForceCloseReason);
                writer.Write(obj.IsAutoSuspend);
                writer.Write(obj.BusinessUnit);
                writer.Write(obj.RequestID);
                writer.Write(obj.UserForceClose);
                writer.Write(obj.IsSwapOrder);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///报单
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpOrder
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///报单引用
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string OrderRef;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///报单价格条件
        ///</summary>
        [DataMember(Order = 6)]
        public byte OrderPriceType;
        ///<summary>
        ///买卖方向
        ///</summary>
        [DataMember(Order = 7)]
        public byte Direction;
        ///<summary>
        ///组合开平标志
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string CombOffsetFlag;
        ///<summary>
        ///组合投机套保标志
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string CombHedgeFlag;
        ///<summary>
        ///价格
        ///</summary>
        [DataMember(Order = 10)]
        public double LimitPrice;
        ///<summary>
        ///数量
        ///</summary>
        [DataMember(Order = 11)]
        public int VolumeTotalOriginal;
        ///<summary>
        ///有效期类型
        ///</summary>
        [DataMember(Order = 12)]
        public byte TimeCondition;
        ///<summary>
        ///GTD日期
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string GTDDate;
        ///<summary>
        ///成交量类型
        ///</summary>
        [DataMember(Order = 14)]
        public byte VolumeCondition;
        ///<summary>
        ///最小成交量
        ///</summary>
        [DataMember(Order = 15)]
        public int MinVolume;
        ///<summary>
        ///触发条件
        ///</summary>
        [DataMember(Order = 16)]
        public byte ContingentCondition;
        ///<summary>
        ///止损价
        ///</summary>
        [DataMember(Order = 17)]
        public double StopPrice;
        ///<summary>
        ///强平原因
        ///</summary>
        [DataMember(Order = 18)]
        public byte ForceCloseReason;
        ///<summary>
        ///自动挂起标志
        ///</summary>
        [DataMember(Order = 19)]
        public int IsAutoSuspend;
        ///<summary>
        ///业务单元
        ///</summary>
        [DataMember(Order = 20)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string BusinessUnit;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 21)]
        public int RequestID;
        ///<summary>
        ///本地报单编号
        ///</summary>
        [DataMember(Order = 22)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string OrderLocalID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 23)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 24)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///客户代码
        ///</summary>
        [DataMember(Order = 25)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClientID;
        ///<summary>
        ///合约在交易所的代码
        ///</summary>
        [DataMember(Order = 26)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ExchangeInstID;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 27)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 28)]
        public int InstallID;
        ///<summary>
        ///报单提交状态
        ///</summary>
        [DataMember(Order = 29)]
        public byte OrderSubmitStatus;
        ///<summary>
        ///报单提示序号
        ///</summary>
        [DataMember(Order = 30)]
        public int NotifySequence;
        ///<summary>
        ///交易日
        ///</summary>
        [DataMember(Order = 31)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///结算编号
        ///</summary>
        [DataMember(Order = 32)]
        public int SettlementID;
        ///<summary>
        ///报单编号
        ///</summary>
        [DataMember(Order = 33)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string OrderSysID;
        ///<summary>
        ///报单来源
        ///</summary>
        [DataMember(Order = 34)]
        public byte OrderSource;
        ///<summary>
        ///报单状态
        ///</summary>
        [DataMember(Order = 35)]
        public byte OrderStatus;
        ///<summary>
        ///报单类型
        ///</summary>
        [DataMember(Order = 36)]
        public byte OrderType;
        ///<summary>
        ///今成交数量
        ///</summary>
        [DataMember(Order = 37)]
        public int VolumeTraded;
        ///<summary>
        ///剩余数量
        ///</summary>
        [DataMember(Order = 38)]
        public int VolumeTotal;
        ///<summary>
        ///报单日期
        ///</summary>
        [DataMember(Order = 39)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string InsertDate;
        ///<summary>
        ///委托时间
        ///</summary>
        [DataMember(Order = 40)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string InsertTime;
        ///<summary>
        ///激活时间
        ///</summary>
        [DataMember(Order = 41)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ActiveTime;
        ///<summary>
        ///挂起时间
        ///</summary>
        [DataMember(Order = 42)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string SuspendTime;
        ///<summary>
        ///最后修改时间
        ///</summary>
        [DataMember(Order = 43)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string UpdateTime;
        ///<summary>
        ///撤销时间
        ///</summary>
        [DataMember(Order = 44)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string CancelTime;
        ///<summary>
        ///最后修改交易所交易员代码
        ///</summary>
        [DataMember(Order = 45)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ActiveTraderID;
        ///<summary>
        ///结算会员编号
        ///</summary>
        [DataMember(Order = 46)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClearingPartID;
        ///<summary>
        ///序号
        ///</summary>
        [DataMember(Order = 47)]
        public int SequenceNo;
        ///<summary>
        ///前置编号
        ///</summary>
        [DataMember(Order = 48)]
        public int FrontID;
        ///<summary>
        ///会话编号
        ///</summary>
        [DataMember(Order = 49)]
        public int SessionID;
        ///<summary>
        ///用户端产品信息
        ///</summary>
        [DataMember(Order = 50)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string UserProductInfo;
        ///<summary>
        ///状态信息
        ///</summary>
        [DataMember(Order = 51)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string StatusMsg;
        ///<summary>
        ///用户强评标志
        ///</summary>
        [DataMember(Order = 52)]
        public int UserForceClose;
        ///<summary>
        ///操作用户代码
        ///</summary>
        [DataMember(Order = 53)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string ActiveUserID;
        ///<summary>
        ///经纪公司报单编号
        ///</summary>
        [DataMember(Order = 54)]
        public int BrokerOrderSeq;
        ///<summary>
        ///相关报单
        ///</summary>
        [DataMember(Order = 55)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string RelativeOrderSysID;
        ///<summary>
        ///郑商所成交数量
        ///</summary>
        [DataMember(Order = 56)]
        public int ZCETotalTradedVolume;
        ///<summary>
        ///互换单标志
        ///</summary>
        [DataMember(Order = 57)]
        public int IsSwapOrder;

        public static byte[] GetData(CtpOrder obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.OrderRef);
                writer.Write(obj.UserID);
                writer.Write(obj.OrderPriceType);
                writer.Write(obj.Direction);
                writer.Write(obj.CombOffsetFlag);
                writer.Write(obj.CombHedgeFlag);
                writer.Write(obj.LimitPrice);
                writer.Write(obj.VolumeTotalOriginal);
                writer.Write(obj.TimeCondition);
                writer.Write(obj.GTDDate);
                writer.Write(obj.VolumeCondition);
                writer.Write(obj.MinVolume);
                writer.Write(obj.ContingentCondition);
                writer.Write(obj.StopPrice);
                writer.Write(obj.ForceCloseReason);
                writer.Write(obj.IsAutoSuspend);
                writer.Write(obj.BusinessUnit);
                writer.Write(obj.RequestID);
                writer.Write(obj.OrderLocalID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ParticipantID);
                writer.Write(obj.ClientID);
                writer.Write(obj.ExchangeInstID);
                writer.Write(obj.TraderID);
                writer.Write(obj.InstallID);
                writer.Write(obj.OrderSubmitStatus);
                writer.Write(obj.NotifySequence);
                writer.Write(obj.TradingDay);
                writer.Write(obj.SettlementID);
                writer.Write(obj.OrderSysID);
                writer.Write(obj.OrderSource);
                writer.Write(obj.OrderStatus);
                writer.Write(obj.OrderType);
                writer.Write(obj.VolumeTraded);
                writer.Write(obj.VolumeTotal);
                writer.Write(obj.InsertDate);
                writer.Write(obj.InsertTime);
                writer.Write(obj.ActiveTime);
                writer.Write(obj.SuspendTime);
                writer.Write(obj.UpdateTime);
                writer.Write(obj.CancelTime);
                writer.Write(obj.ActiveTraderID);
                writer.Write(obj.ClearingPartID);
                writer.Write(obj.SequenceNo);
                writer.Write(obj.FrontID);
                writer.Write(obj.SessionID);
                writer.Write(obj.UserProductInfo);
                writer.Write(obj.StatusMsg);
                writer.Write(obj.UserForceClose);
                writer.Write(obj.ActiveUserID);
                writer.Write(obj.BrokerOrderSeq);
                writer.Write(obj.RelativeOrderSysID);
                writer.Write(obj.ZCETotalTradedVolume);
                writer.Write(obj.IsSwapOrder);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///交易所报单
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpExchangeOrder
    {
        ///<summary>
        ///报单价格条件
        ///</summary>
        [DataMember(Order = 1)]
        public byte OrderPriceType;
        ///<summary>
        ///买卖方向
        ///</summary>
        [DataMember(Order = 2)]
        public byte Direction;
        ///<summary>
        ///组合开平标志
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string CombOffsetFlag;
        ///<summary>
        ///组合投机套保标志
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string CombHedgeFlag;
        ///<summary>
        ///价格
        ///</summary>
        [DataMember(Order = 5)]
        public double LimitPrice;
        ///<summary>
        ///数量
        ///</summary>
        [DataMember(Order = 6)]
        public int VolumeTotalOriginal;
        ///<summary>
        ///有效期类型
        ///</summary>
        [DataMember(Order = 7)]
        public byte TimeCondition;
        ///<summary>
        ///GTD日期
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string GTDDate;
        ///<summary>
        ///成交量类型
        ///</summary>
        [DataMember(Order = 9)]
        public byte VolumeCondition;
        ///<summary>
        ///最小成交量
        ///</summary>
        [DataMember(Order = 10)]
        public int MinVolume;
        ///<summary>
        ///触发条件
        ///</summary>
        [DataMember(Order = 11)]
        public byte ContingentCondition;
        ///<summary>
        ///止损价
        ///</summary>
        [DataMember(Order = 12)]
        public double StopPrice;
        ///<summary>
        ///强平原因
        ///</summary>
        [DataMember(Order = 13)]
        public byte ForceCloseReason;
        ///<summary>
        ///自动挂起标志
        ///</summary>
        [DataMember(Order = 14)]
        public int IsAutoSuspend;
        ///<summary>
        ///业务单元
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string BusinessUnit;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 16)]
        public int RequestID;
        ///<summary>
        ///本地报单编号
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string OrderLocalID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 18)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///客户代码
        ///</summary>
        [DataMember(Order = 20)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClientID;
        ///<summary>
        ///合约在交易所的代码
        ///</summary>
        [DataMember(Order = 21)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ExchangeInstID;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 22)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 23)]
        public int InstallID;
        ///<summary>
        ///报单提交状态
        ///</summary>
        [DataMember(Order = 24)]
        public byte OrderSubmitStatus;
        ///<summary>
        ///报单提示序号
        ///</summary>
        [DataMember(Order = 25)]
        public int NotifySequence;
        ///<summary>
        ///交易日
        ///</summary>
        [DataMember(Order = 26)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///结算编号
        ///</summary>
        [DataMember(Order = 27)]
        public int SettlementID;
        ///<summary>
        ///报单编号
        ///</summary>
        [DataMember(Order = 28)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string OrderSysID;
        ///<summary>
        ///报单来源
        ///</summary>
        [DataMember(Order = 29)]
        public byte OrderSource;
        ///<summary>
        ///报单状态
        ///</summary>
        [DataMember(Order = 30)]
        public byte OrderStatus;
        ///<summary>
        ///报单类型
        ///</summary>
        [DataMember(Order = 31)]
        public byte OrderType;
        ///<summary>
        ///今成交数量
        ///</summary>
        [DataMember(Order = 32)]
        public int VolumeTraded;
        ///<summary>
        ///剩余数量
        ///</summary>
        [DataMember(Order = 33)]
        public int VolumeTotal;
        ///<summary>
        ///报单日期
        ///</summary>
        [DataMember(Order = 34)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string InsertDate;
        ///<summary>
        ///委托时间
        ///</summary>
        [DataMember(Order = 35)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string InsertTime;
        ///<summary>
        ///激活时间
        ///</summary>
        [DataMember(Order = 36)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ActiveTime;
        ///<summary>
        ///挂起时间
        ///</summary>
        [DataMember(Order = 37)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string SuspendTime;
        ///<summary>
        ///最后修改时间
        ///</summary>
        [DataMember(Order = 38)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string UpdateTime;
        ///<summary>
        ///撤销时间
        ///</summary>
        [DataMember(Order = 39)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string CancelTime;
        ///<summary>
        ///最后修改交易所交易员代码
        ///</summary>
        [DataMember(Order = 40)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ActiveTraderID;
        ///<summary>
        ///结算会员编号
        ///</summary>
        [DataMember(Order = 41)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClearingPartID;
        ///<summary>
        ///序号
        ///</summary>
        [DataMember(Order = 42)]
        public int SequenceNo;

        public static byte[] GetData(CtpExchangeOrder obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.OrderPriceType);
                writer.Write(obj.Direction);
                writer.Write(obj.CombOffsetFlag);
                writer.Write(obj.CombHedgeFlag);
                writer.Write(obj.LimitPrice);
                writer.Write(obj.VolumeTotalOriginal);
                writer.Write(obj.TimeCondition);
                writer.Write(obj.GTDDate);
                writer.Write(obj.VolumeCondition);
                writer.Write(obj.MinVolume);
                writer.Write(obj.ContingentCondition);
                writer.Write(obj.StopPrice);
                writer.Write(obj.ForceCloseReason);
                writer.Write(obj.IsAutoSuspend);
                writer.Write(obj.BusinessUnit);
                writer.Write(obj.RequestID);
                writer.Write(obj.OrderLocalID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ParticipantID);
                writer.Write(obj.ClientID);
                writer.Write(obj.ExchangeInstID);
                writer.Write(obj.TraderID);
                writer.Write(obj.InstallID);
                writer.Write(obj.OrderSubmitStatus);
                writer.Write(obj.NotifySequence);
                writer.Write(obj.TradingDay);
                writer.Write(obj.SettlementID);
                writer.Write(obj.OrderSysID);
                writer.Write(obj.OrderSource);
                writer.Write(obj.OrderStatus);
                writer.Write(obj.OrderType);
                writer.Write(obj.VolumeTraded);
                writer.Write(obj.VolumeTotal);
                writer.Write(obj.InsertDate);
                writer.Write(obj.InsertTime);
                writer.Write(obj.ActiveTime);
                writer.Write(obj.SuspendTime);
                writer.Write(obj.UpdateTime);
                writer.Write(obj.CancelTime);
                writer.Write(obj.ActiveTraderID);
                writer.Write(obj.ClearingPartID);
                writer.Write(obj.SequenceNo);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///交易所报单插入失败
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpExchangeOrderInsertError
    {
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 4)]
        public int InstallID;
        ///<summary>
        ///本地报单编号
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string OrderLocalID;
        ///<summary>
        ///错误代码
        ///</summary>
        [DataMember(Order = 6)]
        public int ErrorID;
        ///<summary>
        ///错误信息
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string ErrorMsg;

        public static byte[] GetData(CtpExchangeOrderInsertError obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ParticipantID);
                writer.Write(obj.TraderID);
                writer.Write(obj.InstallID);
                writer.Write(obj.OrderLocalID);
                writer.Write(obj.ErrorID);
                writer.Write(obj.ErrorMsg);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///输入报单操作
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpInputOrderAction
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///报单操作引用
        ///</summary>
        [DataMember(Order = 3)]
        public int OrderActionRef;
        ///<summary>
        ///报单引用
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string OrderRef;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 5)]
        public int RequestID;
        ///<summary>
        ///前置编号
        ///</summary>
        [DataMember(Order = 6)]
        public int FrontID;
        ///<summary>
        ///会话编号
        ///</summary>
        [DataMember(Order = 7)]
        public int SessionID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///报单编号
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string OrderSysID;
        ///<summary>
        ///操作标志
        ///</summary>
        [DataMember(Order = 10)]
        public byte ActionFlag;
        ///<summary>
        ///价格
        ///</summary>
        [DataMember(Order = 11)]
        public double LimitPrice;
        ///<summary>
        ///数量变化
        ///</summary>
        [DataMember(Order = 12)]
        public int VolumeChange;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;

        public static byte[] GetData(CtpInputOrderAction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.OrderActionRef);
                writer.Write(obj.OrderRef);
                writer.Write(obj.RequestID);
                writer.Write(obj.FrontID);
                writer.Write(obj.SessionID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.OrderSysID);
                writer.Write(obj.ActionFlag);
                writer.Write(obj.LimitPrice);
                writer.Write(obj.VolumeChange);
                writer.Write(obj.UserID);
                writer.Write(obj.InstrumentID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///报单操作
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpOrderAction
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///报单操作引用
        ///</summary>
        [DataMember(Order = 3)]
        public int OrderActionRef;
        ///<summary>
        ///报单引用
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string OrderRef;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 5)]
        public int RequestID;
        ///<summary>
        ///前置编号
        ///</summary>
        [DataMember(Order = 6)]
        public int FrontID;
        ///<summary>
        ///会话编号
        ///</summary>
        [DataMember(Order = 7)]
        public int SessionID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///报单编号
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string OrderSysID;
        ///<summary>
        ///操作标志
        ///</summary>
        [DataMember(Order = 10)]
        public byte ActionFlag;
        ///<summary>
        ///价格
        ///</summary>
        [DataMember(Order = 11)]
        public double LimitPrice;
        ///<summary>
        ///数量变化
        ///</summary>
        [DataMember(Order = 12)]
        public int VolumeChange;
        ///<summary>
        ///操作日期
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ActionDate;
        ///<summary>
        ///操作时间
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ActionTime;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 16)]
        public int InstallID;
        ///<summary>
        ///本地报单编号
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string OrderLocalID;
        ///<summary>
        ///操作本地编号
        ///</summary>
        [DataMember(Order = 18)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string ActionLocalID;
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///客户代码
        ///</summary>
        [DataMember(Order = 20)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClientID;
        ///<summary>
        ///业务单元
        ///</summary>
        [DataMember(Order = 21)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string BusinessUnit;
        ///<summary>
        ///报单操作状态
        ///</summary>
        [DataMember(Order = 22)]
        public byte OrderActionStatus;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 23)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///状态信息
        ///</summary>
        [DataMember(Order = 24)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string StatusMsg;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 25)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;

        public static byte[] GetData(CtpOrderAction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.OrderActionRef);
                writer.Write(obj.OrderRef);
                writer.Write(obj.RequestID);
                writer.Write(obj.FrontID);
                writer.Write(obj.SessionID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.OrderSysID);
                writer.Write(obj.ActionFlag);
                writer.Write(obj.LimitPrice);
                writer.Write(obj.VolumeChange);
                writer.Write(obj.ActionDate);
                writer.Write(obj.ActionTime);
                writer.Write(obj.TraderID);
                writer.Write(obj.InstallID);
                writer.Write(obj.OrderLocalID);
                writer.Write(obj.ActionLocalID);
                writer.Write(obj.ParticipantID);
                writer.Write(obj.ClientID);
                writer.Write(obj.BusinessUnit);
                writer.Write(obj.OrderActionStatus);
                writer.Write(obj.UserID);
                writer.Write(obj.StatusMsg);
                writer.Write(obj.InstrumentID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///交易所报单操作
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpExchangeOrderAction
    {
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///报单编号
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string OrderSysID;
        ///<summary>
        ///操作标志
        ///</summary>
        [DataMember(Order = 3)]
        public byte ActionFlag;
        ///<summary>
        ///价格
        ///</summary>
        [DataMember(Order = 4)]
        public double LimitPrice;
        ///<summary>
        ///数量变化
        ///</summary>
        [DataMember(Order = 5)]
        public int VolumeChange;
        ///<summary>
        ///操作日期
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ActionDate;
        ///<summary>
        ///操作时间
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ActionTime;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 9)]
        public int InstallID;
        ///<summary>
        ///本地报单编号
        ///</summary>
        [DataMember(Order = 10)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string OrderLocalID;
        ///<summary>
        ///操作本地编号
        ///</summary>
        [DataMember(Order = 11)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string ActionLocalID;
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 12)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///客户代码
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClientID;
        ///<summary>
        ///业务单元
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string BusinessUnit;
        ///<summary>
        ///报单操作状态
        ///</summary>
        [DataMember(Order = 15)]
        public byte OrderActionStatus;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 16)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;

        public static byte[] GetData(CtpExchangeOrderAction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ExchangeID);
                writer.Write(obj.OrderSysID);
                writer.Write(obj.ActionFlag);
                writer.Write(obj.LimitPrice);
                writer.Write(obj.VolumeChange);
                writer.Write(obj.ActionDate);
                writer.Write(obj.ActionTime);
                writer.Write(obj.TraderID);
                writer.Write(obj.InstallID);
                writer.Write(obj.OrderLocalID);
                writer.Write(obj.ActionLocalID);
                writer.Write(obj.ParticipantID);
                writer.Write(obj.ClientID);
                writer.Write(obj.BusinessUnit);
                writer.Write(obj.OrderActionStatus);
                writer.Write(obj.UserID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///交易所报单操作失败
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpExchangeOrderActionError
    {
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///报单编号
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string OrderSysID;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 4)]
        public int InstallID;
        ///<summary>
        ///本地报单编号
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string OrderLocalID;
        ///<summary>
        ///操作本地编号
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string ActionLocalID;
        ///<summary>
        ///错误代码
        ///</summary>
        [DataMember(Order = 7)]
        public int ErrorID;
        ///<summary>
        ///错误信息
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string ErrorMsg;

        public static byte[] GetData(CtpExchangeOrderActionError obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ExchangeID);
                writer.Write(obj.OrderSysID);
                writer.Write(obj.TraderID);
                writer.Write(obj.InstallID);
                writer.Write(obj.OrderLocalID);
                writer.Write(obj.ActionLocalID);
                writer.Write(obj.ErrorID);
                writer.Write(obj.ErrorMsg);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///交易所成交
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpExchangeTrade
    {
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///成交编号
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TradeID;
        ///<summary>
        ///买卖方向
        ///</summary>
        [DataMember(Order = 3)]
        public byte Direction;
        ///<summary>
        ///报单编号
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string OrderSysID;
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///客户代码
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClientID;
        ///<summary>
        ///交易角色
        ///</summary>
        [DataMember(Order = 7)]
        public byte TradingRole;
        ///<summary>
        ///合约在交易所的代码
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ExchangeInstID;
        ///<summary>
        ///开平标志
        ///</summary>
        [DataMember(Order = 9)]
        public byte OffsetFlag;
        ///<summary>
        ///投机套保标志
        ///</summary>
        [DataMember(Order = 10)]
        public byte HedgeFlag;
        ///<summary>
        ///价格
        ///</summary>
        [DataMember(Order = 11)]
        public double Price;
        ///<summary>
        ///数量
        ///</summary>
        [DataMember(Order = 12)]
        public int Volume;
        ///<summary>
        ///成交时期
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeDate;
        ///<summary>
        ///成交时间
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeTime;
        ///<summary>
        ///成交类型
        ///</summary>
        [DataMember(Order = 15)]
        public byte TradeType;
        ///<summary>
        ///成交价来源
        ///</summary>
        [DataMember(Order = 16)]
        public byte PriceSource;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;
        ///<summary>
        ///本地报单编号
        ///</summary>
        [DataMember(Order = 18)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string OrderLocalID;
        ///<summary>
        ///结算会员编号
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClearingPartID;
        ///<summary>
        ///业务单元
        ///</summary>
        [DataMember(Order = 20)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string BusinessUnit;
        ///<summary>
        ///序号
        ///</summary>
        [DataMember(Order = 21)]
        public int SequenceNo;
        ///<summary>
        ///成交来源
        ///</summary>
        [DataMember(Order = 22)]
        public byte TradeSource;

        public static byte[] GetData(CtpExchangeTrade obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ExchangeID);
                writer.Write(obj.TradeID);
                writer.Write(obj.Direction);
                writer.Write(obj.OrderSysID);
                writer.Write(obj.ParticipantID);
                writer.Write(obj.ClientID);
                writer.Write(obj.TradingRole);
                writer.Write(obj.ExchangeInstID);
                writer.Write(obj.OffsetFlag);
                writer.Write(obj.HedgeFlag);
                writer.Write(obj.Price);
                writer.Write(obj.Volume);
                writer.Write(obj.TradeDate);
                writer.Write(obj.TradeTime);
                writer.Write(obj.TradeType);
                writer.Write(obj.PriceSource);
                writer.Write(obj.TraderID);
                writer.Write(obj.OrderLocalID);
                writer.Write(obj.ClearingPartID);
                writer.Write(obj.BusinessUnit);
                writer.Write(obj.SequenceNo);
                writer.Write(obj.TradeSource);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///成交
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpTrade
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///报单引用
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string OrderRef;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///成交编号
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TradeID;
        ///<summary>
        ///买卖方向
        ///</summary>
        [DataMember(Order = 8)]
        public byte Direction;
        ///<summary>
        ///报单编号
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string OrderSysID;
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 10)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///客户代码
        ///</summary>
        [DataMember(Order = 11)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClientID;
        ///<summary>
        ///交易角色
        ///</summary>
        [DataMember(Order = 12)]
        public byte TradingRole;
        ///<summary>
        ///合约在交易所的代码
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ExchangeInstID;
        ///<summary>
        ///开平标志
        ///</summary>
        [DataMember(Order = 14)]
        public byte OffsetFlag;
        ///<summary>
        ///投机套保标志
        ///</summary>
        [DataMember(Order = 15)]
        public byte HedgeFlag;
        ///<summary>
        ///价格
        ///</summary>
        [DataMember(Order = 16)]
        public double Price;
        ///<summary>
        ///数量
        ///</summary>
        [DataMember(Order = 17)]
        public int Volume;
        ///<summary>
        ///成交时期
        ///</summary>
        [DataMember(Order = 18)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeDate;
        ///<summary>
        ///成交时间
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeTime;
        ///<summary>
        ///成交类型
        ///</summary>
        [DataMember(Order = 20)]
        public byte TradeType;
        ///<summary>
        ///成交价来源
        ///</summary>
        [DataMember(Order = 21)]
        public byte PriceSource;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 22)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;
        ///<summary>
        ///本地报单编号
        ///</summary>
        [DataMember(Order = 23)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string OrderLocalID;
        ///<summary>
        ///结算会员编号
        ///</summary>
        [DataMember(Order = 24)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClearingPartID;
        ///<summary>
        ///业务单元
        ///</summary>
        [DataMember(Order = 25)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string BusinessUnit;
        ///<summary>
        ///序号
        ///</summary>
        [DataMember(Order = 26)]
        public int SequenceNo;
        ///<summary>
        ///交易日
        ///</summary>
        [DataMember(Order = 27)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///结算编号
        ///</summary>
        [DataMember(Order = 28)]
        public int SettlementID;
        ///<summary>
        ///经纪公司报单编号
        ///</summary>
        [DataMember(Order = 29)]
        public int BrokerOrderSeq;
        ///<summary>
        ///成交来源
        ///</summary>
        [DataMember(Order = 30)]
        public byte TradeSource;

        public static byte[] GetData(CtpTrade obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.OrderRef);
                writer.Write(obj.UserID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.TradeID);
                writer.Write(obj.Direction);
                writer.Write(obj.OrderSysID);
                writer.Write(obj.ParticipantID);
                writer.Write(obj.ClientID);
                writer.Write(obj.TradingRole);
                writer.Write(obj.ExchangeInstID);
                writer.Write(obj.OffsetFlag);
                writer.Write(obj.HedgeFlag);
                writer.Write(obj.Price);
                writer.Write(obj.Volume);
                writer.Write(obj.TradeDate);
                writer.Write(obj.TradeTime);
                writer.Write(obj.TradeType);
                writer.Write(obj.PriceSource);
                writer.Write(obj.TraderID);
                writer.Write(obj.OrderLocalID);
                writer.Write(obj.ClearingPartID);
                writer.Write(obj.BusinessUnit);
                writer.Write(obj.SequenceNo);
                writer.Write(obj.TradingDay);
                writer.Write(obj.SettlementID);
                writer.Write(obj.BrokerOrderSeq);
                writer.Write(obj.TradeSource);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///用户会话
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpUserSession
    {
        ///<summary>
        ///前置编号
        ///</summary>
        [DataMember(Order = 1)]
        public int FrontID;
        ///<summary>
        ///会话编号
        ///</summary>
        [DataMember(Order = 2)]
        public int SessionID;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///登录日期
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string LoginDate;
        ///<summary>
        ///登录时间
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string LoginTime;
        ///<summary>
        ///IP地址
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string IPAddress;
        ///<summary>
        ///用户端产品信息
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string UserProductInfo;
        ///<summary>
        ///接口端产品信息
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string InterfaceProductInfo;
        ///<summary>
        ///协议信息
        ///</summary>
        [DataMember(Order = 10)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ProtocolInfo;
        ///<summary>
        ///Mac地址
        ///</summary>
        [DataMember(Order = 11)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string MacAddress;

        public static byte[] GetData(CtpUserSession obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.FrontID);
                writer.Write(obj.SessionID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.UserID);
                writer.Write(obj.LoginDate);
                writer.Write(obj.LoginTime);
                writer.Write(obj.IPAddress);
                writer.Write(obj.UserProductInfo);
                writer.Write(obj.InterfaceProductInfo);
                writer.Write(obj.ProtocolInfo);
                writer.Write(obj.MacAddress);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询最大报单数量
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQueryMaxOrderVolume
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///买卖方向
        ///</summary>
        [DataMember(Order = 4)]
        public byte Direction;
        ///<summary>
        ///开平标志
        ///</summary>
        [DataMember(Order = 5)]
        public byte OffsetFlag;
        ///<summary>
        ///投机套保标志
        ///</summary>
        [DataMember(Order = 6)]
        public byte HedgeFlag;
        ///<summary>
        ///最大允许报单数量
        ///</summary>
        [DataMember(Order = 7)]
        public int MaxVolume;

        public static byte[] GetData(CtpQueryMaxOrderVolume obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.Direction);
                writer.Write(obj.OffsetFlag);
                writer.Write(obj.HedgeFlag);
                writer.Write(obj.MaxVolume);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///投资者结算结果确认信息
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpSettlementInfoConfirm
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///确认日期
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ConfirmDate;
        ///<summary>
        ///确认时间
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ConfirmTime;

        public static byte[] GetData(CtpSettlementInfoConfirm obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.ConfirmDate);
                writer.Write(obj.ConfirmTime);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///出入金同步
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpSyncDeposit
    {
        ///<summary>
        ///出入金流水号
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
        public string DepositSeqNo;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///入金金额
        ///</summary>
        [DataMember(Order = 4)]
        public double Deposit;
        ///<summary>
        ///是否强制进行
        ///</summary>
        [DataMember(Order = 5)]
        public int IsForce;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;

        public static byte[] GetData(CtpSyncDeposit obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.DepositSeqNo);
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.Deposit);
                writer.Write(obj.IsForce);
                writer.Write(obj.CurrencyID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///货币质押同步
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpSyncFundMortgage
    {
        ///<summary>
        ///货币质押流水号
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
        public string MortgageSeqNo;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///源币种
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string FromCurrencyID;
        ///<summary>
        ///质押金额
        ///</summary>
        [DataMember(Order = 5)]
        public double MortgageAmount;
        ///<summary>
        ///目标币种
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string ToCurrencyID;

        public static byte[] GetData(CtpSyncFundMortgage obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.MortgageSeqNo);
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.FromCurrencyID);
                writer.Write(obj.MortgageAmount);
                writer.Write(obj.ToCurrencyID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///经纪公司同步
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpBrokerSync
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;

        public static byte[] GetData(CtpBrokerSync obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///正在同步中的投资者
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpSyncingInvestor
    {
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者分组代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorGroupID;
        ///<summary>
        ///投资者名称
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string InvestorName;
        ///<summary>
        ///证件类型
        ///</summary>
        [DataMember(Order = 5)]
        public byte IdentifiedCardType;
        ///<summary>
        ///证件号码
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string IdentifiedCardNo;
        ///<summary>
        ///是否活跃
        ///</summary>
        [DataMember(Order = 7)]
        public int IsActive;
        ///<summary>
        ///联系电话
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Telephone;
        ///<summary>
        ///通讯地址
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
        public string Address;
        ///<summary>
        ///开户日期
        ///</summary>
        [DataMember(Order = 10)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string OpenDate;
        ///<summary>
        ///手机
        ///</summary>
        [DataMember(Order = 11)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Mobile;
        ///<summary>
        ///手续费率模板代码
        ///</summary>
        [DataMember(Order = 12)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string CommModelID;
        ///<summary>
        ///保证金率模板代码
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string MarginModelID;

        public static byte[] GetData(CtpSyncingInvestor obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.InvestorID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorGroupID);
                writer.Write(obj.InvestorName);
                writer.Write(obj.IdentifiedCardType);
                writer.Write(obj.IdentifiedCardNo);
                writer.Write(obj.IsActive);
                writer.Write(obj.Telephone);
                writer.Write(obj.Address);
                writer.Write(obj.OpenDate);
                writer.Write(obj.Mobile);
                writer.Write(obj.CommModelID);
                writer.Write(obj.MarginModelID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///正在同步中的交易代码
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpSyncingTradingCode
    {
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///客户代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClientID;
        ///<summary>
        ///是否活跃
        ///</summary>
        [DataMember(Order = 5)]
        public int IsActive;
        ///<summary>
        ///交易编码类型
        ///</summary>
        [DataMember(Order = 6)]
        public byte ClientIDType;

        public static byte[] GetData(CtpSyncingTradingCode obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.InvestorID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ClientID);
                writer.Write(obj.IsActive);
                writer.Write(obj.ClientIDType);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///正在同步中的投资者分组
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpSyncingInvestorGroup
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者分组代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorGroupID;
        ///<summary>
        ///投资者分组名称
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string InvestorGroupName;

        public static byte[] GetData(CtpSyncingInvestorGroup obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorGroupID);
                writer.Write(obj.InvestorGroupName);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///正在同步中的交易账号
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpSyncingTradingAccount
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者帐号
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string AccountID;
        ///<summary>
        ///上次质押金额
        ///</summary>
        [DataMember(Order = 3)]
        public double PreMortgage;
        ///<summary>
        ///上次信用额度
        ///</summary>
        [DataMember(Order = 4)]
        public double PreCredit;
        ///<summary>
        ///上次存款额
        ///</summary>
        [DataMember(Order = 5)]
        public double PreDeposit;
        ///<summary>
        ///上次结算准备金
        ///</summary>
        [DataMember(Order = 6)]
        public double PreBalance;
        ///<summary>
        ///上次占用的保证金
        ///</summary>
        [DataMember(Order = 7)]
        public double PreMargin;
        ///<summary>
        ///利息基数
        ///</summary>
        [DataMember(Order = 8)]
        public double InterestBase;
        ///<summary>
        ///利息收入
        ///</summary>
        [DataMember(Order = 9)]
        public double Interest;
        ///<summary>
        ///入金金额
        ///</summary>
        [DataMember(Order = 10)]
        public double Deposit;
        ///<summary>
        ///出金金额
        ///</summary>
        [DataMember(Order = 11)]
        public double Withdraw;
        ///<summary>
        ///冻结的保证金
        ///</summary>
        [DataMember(Order = 12)]
        public double FrozenMargin;
        ///<summary>
        ///冻结的资金
        ///</summary>
        [DataMember(Order = 13)]
        public double FrozenCash;
        ///<summary>
        ///冻结的手续费
        ///</summary>
        [DataMember(Order = 14)]
        public double FrozenCommission;
        ///<summary>
        ///当前保证金总额
        ///</summary>
        [DataMember(Order = 15)]
        public double CurrMargin;
        ///<summary>
        ///资金差额
        ///</summary>
        [DataMember(Order = 16)]
        public double CashIn;
        ///<summary>
        ///手续费
        ///</summary>
        [DataMember(Order = 17)]
        public double Commission;
        ///<summary>
        ///平仓盈亏
        ///</summary>
        [DataMember(Order = 18)]
        public double CloseProfit;
        ///<summary>
        ///持仓盈亏
        ///</summary>
        [DataMember(Order = 19)]
        public double PositionProfit;
        ///<summary>
        ///期货结算准备金
        ///</summary>
        [DataMember(Order = 20)]
        public double Balance;
        ///<summary>
        ///可用资金
        ///</summary>
        [DataMember(Order = 21)]
        public double Available;
        ///<summary>
        ///可取资金
        ///</summary>
        [DataMember(Order = 22)]
        public double WithdrawQuota;
        ///<summary>
        ///基本准备金
        ///</summary>
        [DataMember(Order = 23)]
        public double Reserve;
        ///<summary>
        ///交易日
        ///</summary>
        [DataMember(Order = 24)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///结算编号
        ///</summary>
        [DataMember(Order = 25)]
        public int SettlementID;
        ///<summary>
        ///信用额度
        ///</summary>
        [DataMember(Order = 26)]
        public double Credit;
        ///<summary>
        ///质押金额
        ///</summary>
        [DataMember(Order = 27)]
        public double Mortgage;
        ///<summary>
        ///交易所保证金
        ///</summary>
        [DataMember(Order = 28)]
        public double ExchangeMargin;
        ///<summary>
        ///投资者交割保证金
        ///</summary>
        [DataMember(Order = 29)]
        public double DeliveryMargin;
        ///<summary>
        ///交易所交割保证金
        ///</summary>
        [DataMember(Order = 30)]
        public double ExchangeDeliveryMargin;
        ///<summary>
        ///保底期货结算准备金
        ///</summary>
        [DataMember(Order = 31)]
        public double ReserveBalance;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 32)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;
        ///<summary>
        ///上次货币质入金额
        ///</summary>
        [DataMember(Order = 33)]
        public double PreFundMortgageIn;
        ///<summary>
        ///上次货币质出金额
        ///</summary>
        [DataMember(Order = 34)]
        public double PreFundMortgageOut;
        ///<summary>
        ///货币质入金额
        ///</summary>
        [DataMember(Order = 35)]
        public double FundMortgageIn;
        ///<summary>
        ///货币质出金额
        ///</summary>
        [DataMember(Order = 36)]
        public double FundMortgageOut;
        ///<summary>
        ///货币质押余额
        ///</summary>
        [DataMember(Order = 37)]
        public double FundMortgageAvailable;
        ///<summary>
        ///可质押货币金额
        ///</summary>
        [DataMember(Order = 38)]
        public double MortgageableFund;
        ///<summary>
        ///特殊产品占用保证金
        ///</summary>
        [DataMember(Order = 39)]
        public double SpecProductMargin;
        ///<summary>
        ///特殊产品冻结保证金
        ///</summary>
        [DataMember(Order = 40)]
        public double SpecProductFrozenMargin;
        ///<summary>
        ///特殊产品手续费
        ///</summary>
        [DataMember(Order = 41)]
        public double SpecProductCommission;
        ///<summary>
        ///特殊产品冻结手续费
        ///</summary>
        [DataMember(Order = 42)]
        public double SpecProductFrozenCommission;
        ///<summary>
        ///特殊产品持仓盈亏
        ///</summary>
        [DataMember(Order = 43)]
        public double SpecProductPositionProfit;
        ///<summary>
        ///特殊产品平仓盈亏
        ///</summary>
        [DataMember(Order = 44)]
        public double SpecProductCloseProfit;
        ///<summary>
        ///根据持仓盈亏算法计算的特殊产品持仓盈亏
        ///</summary>
        [DataMember(Order = 45)]
        public double SpecProductPositionProfitByAlg;
        ///<summary>
        ///特殊产品交易所保证金
        ///</summary>
        [DataMember(Order = 46)]
        public double SpecProductExchangeMargin;

        public static byte[] GetData(CtpSyncingTradingAccount obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.AccountID);
                writer.Write(obj.PreMortgage);
                writer.Write(obj.PreCredit);
                writer.Write(obj.PreDeposit);
                writer.Write(obj.PreBalance);
                writer.Write(obj.PreMargin);
                writer.Write(obj.InterestBase);
                writer.Write(obj.Interest);
                writer.Write(obj.Deposit);
                writer.Write(obj.Withdraw);
                writer.Write(obj.FrozenMargin);
                writer.Write(obj.FrozenCash);
                writer.Write(obj.FrozenCommission);
                writer.Write(obj.CurrMargin);
                writer.Write(obj.CashIn);
                writer.Write(obj.Commission);
                writer.Write(obj.CloseProfit);
                writer.Write(obj.PositionProfit);
                writer.Write(obj.Balance);
                writer.Write(obj.Available);
                writer.Write(obj.WithdrawQuota);
                writer.Write(obj.Reserve);
                writer.Write(obj.TradingDay);
                writer.Write(obj.SettlementID);
                writer.Write(obj.Credit);
                writer.Write(obj.Mortgage);
                writer.Write(obj.ExchangeMargin);
                writer.Write(obj.DeliveryMargin);
                writer.Write(obj.ExchangeDeliveryMargin);
                writer.Write(obj.ReserveBalance);
                writer.Write(obj.CurrencyID);
                writer.Write(obj.PreFundMortgageIn);
                writer.Write(obj.PreFundMortgageOut);
                writer.Write(obj.FundMortgageIn);
                writer.Write(obj.FundMortgageOut);
                writer.Write(obj.FundMortgageAvailable);
                writer.Write(obj.MortgageableFund);
                writer.Write(obj.SpecProductMargin);
                writer.Write(obj.SpecProductFrozenMargin);
                writer.Write(obj.SpecProductCommission);
                writer.Write(obj.SpecProductFrozenCommission);
                writer.Write(obj.SpecProductPositionProfit);
                writer.Write(obj.SpecProductCloseProfit);
                writer.Write(obj.SpecProductPositionProfitByAlg);
                writer.Write(obj.SpecProductExchangeMargin);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///正在同步中的投资者持仓
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpSyncingInvestorPosition
    {
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///持仓多空方向
        ///</summary>
        [DataMember(Order = 4)]
        public byte PosiDirection;
        ///<summary>
        ///投机套保标志
        ///</summary>
        [DataMember(Order = 5)]
        public byte HedgeFlag;
        ///<summary>
        ///持仓日期
        ///</summary>
        [DataMember(Order = 6)]
        public byte PositionDate;
        ///<summary>
        ///上日持仓
        ///</summary>
        [DataMember(Order = 7)]
        public int YdPosition;
        ///<summary>
        ///今日持仓
        ///</summary>
        [DataMember(Order = 8)]
        public int Position;
        ///<summary>
        ///多头冻结
        ///</summary>
        [DataMember(Order = 9)]
        public int LongFrozen;
        ///<summary>
        ///空头冻结
        ///</summary>
        [DataMember(Order = 10)]
        public int ShortFrozen;
        ///<summary>
        ///开仓冻结金额
        ///</summary>
        [DataMember(Order = 11)]
        public double LongFrozenAmount;
        ///<summary>
        ///开仓冻结金额
        ///</summary>
        [DataMember(Order = 12)]
        public double ShortFrozenAmount;
        ///<summary>
        ///开仓量
        ///</summary>
        [DataMember(Order = 13)]
        public int OpenVolume;
        ///<summary>
        ///平仓量
        ///</summary>
        [DataMember(Order = 14)]
        public int CloseVolume;
        ///<summary>
        ///开仓金额
        ///</summary>
        [DataMember(Order = 15)]
        public double OpenAmount;
        ///<summary>
        ///平仓金额
        ///</summary>
        [DataMember(Order = 16)]
        public double CloseAmount;
        ///<summary>
        ///持仓成本
        ///</summary>
        [DataMember(Order = 17)]
        public double PositionCost;
        ///<summary>
        ///上次占用的保证金
        ///</summary>
        [DataMember(Order = 18)]
        public double PreMargin;
        ///<summary>
        ///占用的保证金
        ///</summary>
        [DataMember(Order = 19)]
        public double UseMargin;
        ///<summary>
        ///冻结的保证金
        ///</summary>
        [DataMember(Order = 20)]
        public double FrozenMargin;
        ///<summary>
        ///冻结的资金
        ///</summary>
        [DataMember(Order = 21)]
        public double FrozenCash;
        ///<summary>
        ///冻结的手续费
        ///</summary>
        [DataMember(Order = 22)]
        public double FrozenCommission;
        ///<summary>
        ///资金差额
        ///</summary>
        [DataMember(Order = 23)]
        public double CashIn;
        ///<summary>
        ///手续费
        ///</summary>
        [DataMember(Order = 24)]
        public double Commission;
        ///<summary>
        ///平仓盈亏
        ///</summary>
        [DataMember(Order = 25)]
        public double CloseProfit;
        ///<summary>
        ///持仓盈亏
        ///</summary>
        [DataMember(Order = 26)]
        public double PositionProfit;
        ///<summary>
        ///上次结算价
        ///</summary>
        [DataMember(Order = 27)]
        public double PreSettlementPrice;
        ///<summary>
        ///本次结算价
        ///</summary>
        [DataMember(Order = 28)]
        public double SettlementPrice;
        ///<summary>
        ///交易日
        ///</summary>
        [DataMember(Order = 29)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///结算编号
        ///</summary>
        [DataMember(Order = 30)]
        public int SettlementID;
        ///<summary>
        ///开仓成本
        ///</summary>
        [DataMember(Order = 31)]
        public double OpenCost;
        ///<summary>
        ///交易所保证金
        ///</summary>
        [DataMember(Order = 32)]
        public double ExchangeMargin;
        ///<summary>
        ///组合成交形成的持仓
        ///</summary>
        [DataMember(Order = 33)]
        public int CombPosition;
        ///<summary>
        ///组合多头冻结
        ///</summary>
        [DataMember(Order = 34)]
        public int CombLongFrozen;
        ///<summary>
        ///组合空头冻结
        ///</summary>
        [DataMember(Order = 35)]
        public int CombShortFrozen;
        ///<summary>
        ///逐日盯市平仓盈亏
        ///</summary>
        [DataMember(Order = 36)]
        public double CloseProfitByDate;
        ///<summary>
        ///逐笔对冲平仓盈亏
        ///</summary>
        [DataMember(Order = 37)]
        public double CloseProfitByTrade;
        ///<summary>
        ///今日持仓
        ///</summary>
        [DataMember(Order = 38)]
        public int TodayPosition;
        ///<summary>
        ///保证金率
        ///</summary>
        [DataMember(Order = 39)]
        public double MarginRateByMoney;
        ///<summary>
        ///保证金率(按手数)
        ///</summary>
        [DataMember(Order = 40)]
        public double MarginRateByVolume;
        ///<summary>
        ///执行冻结
        ///</summary>
        [DataMember(Order = 41)]
        public int StrikeFrozen;
        ///<summary>
        ///执行冻结金额
        ///</summary>
        [DataMember(Order = 42)]
        public double StrikeFrozenAmount;
        ///<summary>
        ///放弃执行冻结
        ///</summary>
        [DataMember(Order = 43)]
        public int AbandonFrozen;

        public static byte[] GetData(CtpSyncingInvestorPosition obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.InstrumentID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.PosiDirection);
                writer.Write(obj.HedgeFlag);
                writer.Write(obj.PositionDate);
                writer.Write(obj.YdPosition);
                writer.Write(obj.Position);
                writer.Write(obj.LongFrozen);
                writer.Write(obj.ShortFrozen);
                writer.Write(obj.LongFrozenAmount);
                writer.Write(obj.ShortFrozenAmount);
                writer.Write(obj.OpenVolume);
                writer.Write(obj.CloseVolume);
                writer.Write(obj.OpenAmount);
                writer.Write(obj.CloseAmount);
                writer.Write(obj.PositionCost);
                writer.Write(obj.PreMargin);
                writer.Write(obj.UseMargin);
                writer.Write(obj.FrozenMargin);
                writer.Write(obj.FrozenCash);
                writer.Write(obj.FrozenCommission);
                writer.Write(obj.CashIn);
                writer.Write(obj.Commission);
                writer.Write(obj.CloseProfit);
                writer.Write(obj.PositionProfit);
                writer.Write(obj.PreSettlementPrice);
                writer.Write(obj.SettlementPrice);
                writer.Write(obj.TradingDay);
                writer.Write(obj.SettlementID);
                writer.Write(obj.OpenCost);
                writer.Write(obj.ExchangeMargin);
                writer.Write(obj.CombPosition);
                writer.Write(obj.CombLongFrozen);
                writer.Write(obj.CombShortFrozen);
                writer.Write(obj.CloseProfitByDate);
                writer.Write(obj.CloseProfitByTrade);
                writer.Write(obj.TodayPosition);
                writer.Write(obj.MarginRateByMoney);
                writer.Write(obj.MarginRateByVolume);
                writer.Write(obj.StrikeFrozen);
                writer.Write(obj.StrikeFrozenAmount);
                writer.Write(obj.AbandonFrozen);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///正在同步中的合约保证金率
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpSyncingInstrumentMarginRate
    {
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///投资者范围
        ///</summary>
        [DataMember(Order = 2)]
        public byte InvestorRange;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///投机套保标志
        ///</summary>
        [DataMember(Order = 5)]
        public byte HedgeFlag;
        ///<summary>
        ///多头保证金率
        ///</summary>
        [DataMember(Order = 6)]
        public double LongMarginRatioByMoney;
        ///<summary>
        ///多头保证金费
        ///</summary>
        [DataMember(Order = 7)]
        public double LongMarginRatioByVolume;
        ///<summary>
        ///空头保证金率
        ///</summary>
        [DataMember(Order = 8)]
        public double ShortMarginRatioByMoney;
        ///<summary>
        ///空头保证金费
        ///</summary>
        [DataMember(Order = 9)]
        public double ShortMarginRatioByVolume;
        ///<summary>
        ///是否相对交易所收取
        ///</summary>
        [DataMember(Order = 10)]
        public int IsRelative;

        public static byte[] GetData(CtpSyncingInstrumentMarginRate obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.InstrumentID);
                writer.Write(obj.InvestorRange);
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.HedgeFlag);
                writer.Write(obj.LongMarginRatioByMoney);
                writer.Write(obj.LongMarginRatioByVolume);
                writer.Write(obj.ShortMarginRatioByMoney);
                writer.Write(obj.ShortMarginRatioByVolume);
                writer.Write(obj.IsRelative);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///正在同步中的合约手续费率
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpSyncingInstrumentCommissionRate
    {
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///投资者范围
        ///</summary>
        [DataMember(Order = 2)]
        public byte InvestorRange;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///开仓手续费率
        ///</summary>
        [DataMember(Order = 5)]
        public double OpenRatioByMoney;
        ///<summary>
        ///开仓手续费
        ///</summary>
        [DataMember(Order = 6)]
        public double OpenRatioByVolume;
        ///<summary>
        ///平仓手续费率
        ///</summary>
        [DataMember(Order = 7)]
        public double CloseRatioByMoney;
        ///<summary>
        ///平仓手续费
        ///</summary>
        [DataMember(Order = 8)]
        public double CloseRatioByVolume;
        ///<summary>
        ///平今手续费率
        ///</summary>
        [DataMember(Order = 9)]
        public double CloseTodayRatioByMoney;
        ///<summary>
        ///平今手续费
        ///</summary>
        [DataMember(Order = 10)]
        public double CloseTodayRatioByVolume;

        public static byte[] GetData(CtpSyncingInstrumentCommissionRate obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.InstrumentID);
                writer.Write(obj.InvestorRange);
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.OpenRatioByMoney);
                writer.Write(obj.OpenRatioByVolume);
                writer.Write(obj.CloseRatioByMoney);
                writer.Write(obj.CloseRatioByVolume);
                writer.Write(obj.CloseTodayRatioByMoney);
                writer.Write(obj.CloseTodayRatioByVolume);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///正在同步中的合约交易权限
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpSyncingInstrumentTradingRight
    {
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///投资者范围
        ///</summary>
        [DataMember(Order = 2)]
        public byte InvestorRange;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///交易权限
        ///</summary>
        [DataMember(Order = 5)]
        public byte TradingRight;

        public static byte[] GetData(CtpSyncingInstrumentTradingRight obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.InstrumentID);
                writer.Write(obj.InvestorRange);
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.TradingRight);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询报单
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryOrder
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///报单编号
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string OrderSysID;
        ///<summary>
        ///开始时间
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string InsertTimeStart;
        ///<summary>
        ///结束时间
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string InsertTimeEnd;

        public static byte[] GetData(CtpQryOrder obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.OrderSysID);
                writer.Write(obj.InsertTimeStart);
                writer.Write(obj.InsertTimeEnd);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询成交
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryTrade
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///成交编号
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TradeID;
        ///<summary>
        ///开始时间
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeTimeStart;
        ///<summary>
        ///结束时间
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeTimeEnd;

        public static byte[] GetData(CtpQryTrade obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.TradeID);
                writer.Write(obj.TradeTimeStart);
                writer.Write(obj.TradeTimeEnd);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询投资者持仓
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryInvestorPosition
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;

        public static byte[] GetData(CtpQryInvestorPosition obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询资金账户
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryTradingAccount
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;

        public static byte[] GetData(CtpQryTradingAccount obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.CurrencyID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询投资者
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryInvestor
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;

        public static byte[] GetData(CtpQryInvestor obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询交易编码
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryTradingCode
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///客户代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClientID;
        ///<summary>
        ///交易编码类型
        ///</summary>
        [DataMember(Order = 5)]
        public byte ClientIDType;

        public static byte[] GetData(CtpQryTradingCode obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ClientID);
                writer.Write(obj.ClientIDType);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询投资者组
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryInvestorGroup
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;

        public static byte[] GetData(CtpQryInvestorGroup obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询合约保证金率
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryInstrumentMarginRate
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///投机套保标志
        ///</summary>
        [DataMember(Order = 4)]
        public byte HedgeFlag;

        public static byte[] GetData(CtpQryInstrumentMarginRate obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.HedgeFlag);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询手续费率
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryInstrumentCommissionRate
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;

        public static byte[] GetData(CtpQryInstrumentCommissionRate obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询合约交易权限
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryInstrumentTradingRight
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;

        public static byte[] GetData(CtpQryInstrumentTradingRight obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询经纪公司
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryBroker
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;

        public static byte[] GetData(CtpQryBroker obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询交易员
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryTrader
    {
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;

        public static byte[] GetData(CtpQryTrader obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ParticipantID);
                writer.Write(obj.TraderID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询管理用户功能权限
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQrySuperUserFunction
    {
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;

        public static byte[] GetData(CtpQrySuperUserFunction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.UserID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询用户会话
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryUserSession
    {
        ///<summary>
        ///前置编号
        ///</summary>
        [DataMember(Order = 1)]
        public int FrontID;
        ///<summary>
        ///会话编号
        ///</summary>
        [DataMember(Order = 2)]
        public int SessionID;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;

        public static byte[] GetData(CtpQryUserSession obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.FrontID);
                writer.Write(obj.SessionID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.UserID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询经纪公司会员代码
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryPartBroker
    {
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;

        public static byte[] GetData(CtpQryPartBroker obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ExchangeID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.ParticipantID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询前置状态
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryFrontStatus
    {
        ///<summary>
        ///前置编号
        ///</summary>
        [DataMember(Order = 1)]
        public int FrontID;

        public static byte[] GetData(CtpQryFrontStatus obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.FrontID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询交易所报单
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryExchangeOrder
    {
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///客户代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClientID;
        ///<summary>
        ///合约在交易所的代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ExchangeInstID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;

        public static byte[] GetData(CtpQryExchangeOrder obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ParticipantID);
                writer.Write(obj.ClientID);
                writer.Write(obj.ExchangeInstID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.TraderID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询报单操作
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryOrderAction
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;

        public static byte[] GetData(CtpQryOrderAction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.ExchangeID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询交易所报单操作
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryExchangeOrderAction
    {
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///客户代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClientID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;

        public static byte[] GetData(CtpQryExchangeOrderAction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ParticipantID);
                writer.Write(obj.ClientID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.TraderID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询管理用户
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQrySuperUser
    {
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;

        public static byte[] GetData(CtpQrySuperUser obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.UserID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询交易所
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryExchange
    {
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;

        public static byte[] GetData(CtpQryExchange obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ExchangeID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询产品
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryProduct
    {
        ///<summary>
        ///产品代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ProductID;
        ///<summary>
        ///产品类型
        ///</summary>
        [DataMember(Order = 2)]
        public byte ProductClass;

        public static byte[] GetData(CtpQryProduct obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ProductID);
                writer.Write(obj.ProductClass);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询合约
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryInstrument
    {
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///合约在交易所的代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ExchangeInstID;
        ///<summary>
        ///产品代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ProductID;

        public static byte[] GetData(CtpQryInstrument obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.InstrumentID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ExchangeInstID);
                writer.Write(obj.ProductID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询行情
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryDepthMarketData
    {
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;

        public static byte[] GetData(CtpQryDepthMarketData obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.InstrumentID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询经纪公司用户
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryBrokerUser
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;

        public static byte[] GetData(CtpQryBrokerUser obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.UserID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询经纪公司用户权限
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryBrokerUserFunction
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;

        public static byte[] GetData(CtpQryBrokerUserFunction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.UserID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询交易员报盘机
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryTraderOffer
    {
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;

        public static byte[] GetData(CtpQryTraderOffer obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ParticipantID);
                writer.Write(obj.TraderID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询出入金流水
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQrySyncDeposit
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///出入金流水号
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
        public string DepositSeqNo;

        public static byte[] GetData(CtpQrySyncDeposit obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.DepositSeqNo);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询投资者结算结果
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQrySettlementInfo
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///交易日
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;

        public static byte[] GetData(CtpQrySettlementInfo obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.TradingDay);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询交易所保证金率
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryExchangeMarginRate
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///投机套保标志
        ///</summary>
        [DataMember(Order = 3)]
        public byte HedgeFlag;

        public static byte[] GetData(CtpQryExchangeMarginRate obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.HedgeFlag);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询交易所调整保证金率
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryExchangeMarginRateAdjust
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///投机套保标志
        ///</summary>
        [DataMember(Order = 3)]
        public byte HedgeFlag;

        public static byte[] GetData(CtpQryExchangeMarginRateAdjust obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.HedgeFlag);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询汇率
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryExchangeRate
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///源币种
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string FromCurrencyID;
        ///<summary>
        ///目标币种
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string ToCurrencyID;

        public static byte[] GetData(CtpQryExchangeRate obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.FromCurrencyID);
                writer.Write(obj.ToCurrencyID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询货币质押流水
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQrySyncFundMortgage
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///货币质押流水号
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
        public string MortgageSeqNo;

        public static byte[] GetData(CtpQrySyncFundMortgage obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.MortgageSeqNo);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询报单
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryHisOrder
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///报单编号
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string OrderSysID;
        ///<summary>
        ///开始时间
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string InsertTimeStart;
        ///<summary>
        ///结束时间
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string InsertTimeEnd;
        ///<summary>
        ///交易日
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///结算编号
        ///</summary>
        [DataMember(Order = 9)]
        public int SettlementID;

        public static byte[] GetData(CtpQryHisOrder obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.OrderSysID);
                writer.Write(obj.InsertTimeStart);
                writer.Write(obj.InsertTimeEnd);
                writer.Write(obj.TradingDay);
                writer.Write(obj.SettlementID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///当前期权合约最小保证金
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpOptionInstrMiniMargin
    {
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///投资者范围
        ///</summary>
        [DataMember(Order = 2)]
        public byte InvestorRange;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///单位（手）期权合约最小保证金
        ///</summary>
        [DataMember(Order = 5)]
        public double MinMargin;
        ///<summary>
        ///取值方式
        ///</summary>
        [DataMember(Order = 6)]
        public byte ValueMethod;
        ///<summary>
        ///是否跟随交易所收取
        ///</summary>
        [DataMember(Order = 7)]
        public int IsRelative;

        public static byte[] GetData(CtpOptionInstrMiniMargin obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.InstrumentID);
                writer.Write(obj.InvestorRange);
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.MinMargin);
                writer.Write(obj.ValueMethod);
                writer.Write(obj.IsRelative);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///当前期权合约保证金调整系数
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpOptionInstrMarginAdjust
    {
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///投资者范围
        ///</summary>
        [DataMember(Order = 2)]
        public byte InvestorRange;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///投机空头保证金调整系数
        ///</summary>
        [DataMember(Order = 5)]
        public double SShortMarginRatioByMoney;
        ///<summary>
        ///投机空头保证金调整系数
        ///</summary>
        [DataMember(Order = 6)]
        public double SShortMarginRatioByVolume;
        ///<summary>
        ///保值空头保证金调整系数
        ///</summary>
        [DataMember(Order = 7)]
        public double HShortMarginRatioByMoney;
        ///<summary>
        ///保值空头保证金调整系数
        ///</summary>
        [DataMember(Order = 8)]
        public double HShortMarginRatioByVolume;
        ///<summary>
        ///套利空头保证金调整系数
        ///</summary>
        [DataMember(Order = 9)]
        public double AShortMarginRatioByMoney;
        ///<summary>
        ///套利空头保证金调整系数
        ///</summary>
        [DataMember(Order = 10)]
        public double AShortMarginRatioByVolume;
        ///<summary>
        ///是否跟随交易所收取
        ///</summary>
        [DataMember(Order = 11)]
        public int IsRelative;

        public static byte[] GetData(CtpOptionInstrMarginAdjust obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.InstrumentID);
                writer.Write(obj.InvestorRange);
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.SShortMarginRatioByMoney);
                writer.Write(obj.SShortMarginRatioByVolume);
                writer.Write(obj.HShortMarginRatioByMoney);
                writer.Write(obj.HShortMarginRatioByVolume);
                writer.Write(obj.AShortMarginRatioByMoney);
                writer.Write(obj.AShortMarginRatioByVolume);
                writer.Write(obj.IsRelative);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///当前期权合约手续费的详细内容
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpOptionInstrCommRate
    {
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///投资者范围
        ///</summary>
        [DataMember(Order = 2)]
        public byte InvestorRange;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///开仓手续费率
        ///</summary>
        [DataMember(Order = 5)]
        public double OpenRatioByMoney;
        ///<summary>
        ///开仓手续费
        ///</summary>
        [DataMember(Order = 6)]
        public double OpenRatioByVolume;
        ///<summary>
        ///平仓手续费率
        ///</summary>
        [DataMember(Order = 7)]
        public double CloseRatioByMoney;
        ///<summary>
        ///平仓手续费
        ///</summary>
        [DataMember(Order = 8)]
        public double CloseRatioByVolume;
        ///<summary>
        ///平今手续费率
        ///</summary>
        [DataMember(Order = 9)]
        public double CloseTodayRatioByMoney;
        ///<summary>
        ///平今手续费
        ///</summary>
        [DataMember(Order = 10)]
        public double CloseTodayRatioByVolume;
        ///<summary>
        ///执行手续费率
        ///</summary>
        [DataMember(Order = 11)]
        public double StrikeRatioByMoney;
        ///<summary>
        ///执行手续费
        ///</summary>
        [DataMember(Order = 12)]
        public double StrikeRatioByVolume;

        public static byte[] GetData(CtpOptionInstrCommRate obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.InstrumentID);
                writer.Write(obj.InvestorRange);
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.OpenRatioByMoney);
                writer.Write(obj.OpenRatioByVolume);
                writer.Write(obj.CloseRatioByMoney);
                writer.Write(obj.CloseRatioByVolume);
                writer.Write(obj.CloseTodayRatioByMoney);
                writer.Write(obj.CloseTodayRatioByVolume);
                writer.Write(obj.StrikeRatioByMoney);
                writer.Write(obj.StrikeRatioByVolume);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///期权交易成本
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpOptionInstrTradeCost
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///投机套保标志
        ///</summary>
        [DataMember(Order = 4)]
        public byte HedgeFlag;
        ///<summary>
        ///期权合约保证金不变部分
        ///</summary>
        [DataMember(Order = 5)]
        public double FixedMargin;
        ///<summary>
        ///期权合约最小保证金
        ///</summary>
        [DataMember(Order = 6)]
        public double MiniMargin;
        ///<summary>
        ///期权合约权利金
        ///</summary>
        [DataMember(Order = 7)]
        public double Royalty;
        ///<summary>
        ///交易所期权合约保证金不变部分
        ///</summary>
        [DataMember(Order = 8)]
        public double ExchFixedMargin;
        ///<summary>
        ///交易所期权合约最小保证金
        ///</summary>
        [DataMember(Order = 9)]
        public double ExchMiniMargin;

        public static byte[] GetData(CtpOptionInstrTradeCost obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.HedgeFlag);
                writer.Write(obj.FixedMargin);
                writer.Write(obj.MiniMargin);
                writer.Write(obj.Royalty);
                writer.Write(obj.ExchFixedMargin);
                writer.Write(obj.ExchMiniMargin);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///期权交易成本查询
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryOptionInstrTradeCost
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///投机套保标志
        ///</summary>
        [DataMember(Order = 4)]
        public byte HedgeFlag;
        ///<summary>
        ///期权合约报价
        ///</summary>
        [DataMember(Order = 5)]
        public double InputPrice;
        ///<summary>
        ///标的价格,填0则用昨结算价
        ///</summary>
        [DataMember(Order = 6)]
        public double UnderlyingPrice;

        public static byte[] GetData(CtpQryOptionInstrTradeCost obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.HedgeFlag);
                writer.Write(obj.InputPrice);
                writer.Write(obj.UnderlyingPrice);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///期权手续费率查询
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryOptionInstrCommRate
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;

        public static byte[] GetData(CtpQryOptionInstrCommRate obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///股指现货指数
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpIndexPrice
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///指数现货收盘价
        ///</summary>
        [DataMember(Order = 3)]
        public double ClosePrice;

        public static byte[] GetData(CtpIndexPrice obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.ClosePrice);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///输入的执行宣告
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpInputExecOrder
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///执行宣告引用
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string ExecOrderRef;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///数量
        ///</summary>
        [DataMember(Order = 6)]
        public int Volume;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 7)]
        public int RequestID;
        ///<summary>
        ///业务单元
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string BusinessUnit;
        ///<summary>
        ///开平标志
        ///</summary>
        [DataMember(Order = 9)]
        public byte OffsetFlag;
        ///<summary>
        ///投机套保标志
        ///</summary>
        [DataMember(Order = 10)]
        public byte HedgeFlag;
        ///<summary>
        ///执行类型
        ///</summary>
        [DataMember(Order = 11)]
        public byte ActionType;
        ///<summary>
        ///保留头寸申请的持仓方向
        ///</summary>
        [DataMember(Order = 12)]
        public byte PosiDirection;
        ///<summary>
        ///期权行权后是否保留期货头寸的标记
        ///</summary>
        [DataMember(Order = 13)]
        public byte ReservePositionFlag;
        ///<summary>
        ///期权行权后生成的头寸是否自动平仓
        ///</summary>
        [DataMember(Order = 14)]
        public byte CloseFlag;

        public static byte[] GetData(CtpInputExecOrder obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.ExecOrderRef);
                writer.Write(obj.UserID);
                writer.Write(obj.Volume);
                writer.Write(obj.RequestID);
                writer.Write(obj.BusinessUnit);
                writer.Write(obj.OffsetFlag);
                writer.Write(obj.HedgeFlag);
                writer.Write(obj.ActionType);
                writer.Write(obj.PosiDirection);
                writer.Write(obj.ReservePositionFlag);
                writer.Write(obj.CloseFlag);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///输入执行宣告操作
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpInputExecOrderAction
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///执行宣告操作引用
        ///</summary>
        [DataMember(Order = 3)]
        public int ExecOrderActionRef;
        ///<summary>
        ///执行宣告引用
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string ExecOrderRef;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 5)]
        public int RequestID;
        ///<summary>
        ///前置编号
        ///</summary>
        [DataMember(Order = 6)]
        public int FrontID;
        ///<summary>
        ///会话编号
        ///</summary>
        [DataMember(Order = 7)]
        public int SessionID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///执行宣告操作编号
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ExecOrderSysID;
        ///<summary>
        ///操作标志
        ///</summary>
        [DataMember(Order = 10)]
        public byte ActionFlag;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 11)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 12)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;

        public static byte[] GetData(CtpInputExecOrderAction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.ExecOrderActionRef);
                writer.Write(obj.ExecOrderRef);
                writer.Write(obj.RequestID);
                writer.Write(obj.FrontID);
                writer.Write(obj.SessionID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ExecOrderSysID);
                writer.Write(obj.ActionFlag);
                writer.Write(obj.UserID);
                writer.Write(obj.InstrumentID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///执行宣告
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpExecOrder
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///执行宣告引用
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string ExecOrderRef;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///数量
        ///</summary>
        [DataMember(Order = 6)]
        public int Volume;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 7)]
        public int RequestID;
        ///<summary>
        ///业务单元
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string BusinessUnit;
        ///<summary>
        ///开平标志
        ///</summary>
        [DataMember(Order = 9)]
        public byte OffsetFlag;
        ///<summary>
        ///投机套保标志
        ///</summary>
        [DataMember(Order = 10)]
        public byte HedgeFlag;
        ///<summary>
        ///执行类型
        ///</summary>
        [DataMember(Order = 11)]
        public byte ActionType;
        ///<summary>
        ///保留头寸申请的持仓方向
        ///</summary>
        [DataMember(Order = 12)]
        public byte PosiDirection;
        ///<summary>
        ///期权行权后是否保留期货头寸的标记
        ///</summary>
        [DataMember(Order = 13)]
        public byte ReservePositionFlag;
        ///<summary>
        ///期权行权后生成的头寸是否自动平仓
        ///</summary>
        [DataMember(Order = 14)]
        public byte CloseFlag;
        ///<summary>
        ///本地执行宣告编号
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string ExecOrderLocalID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 16)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///客户代码
        ///</summary>
        [DataMember(Order = 18)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClientID;
        ///<summary>
        ///合约在交易所的代码
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ExchangeInstID;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 20)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 21)]
        public int InstallID;
        ///<summary>
        ///执行宣告提交状态
        ///</summary>
        [DataMember(Order = 22)]
        public byte OrderSubmitStatus;
        ///<summary>
        ///报单提示序号
        ///</summary>
        [DataMember(Order = 23)]
        public int NotifySequence;
        ///<summary>
        ///交易日
        ///</summary>
        [DataMember(Order = 24)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///结算编号
        ///</summary>
        [DataMember(Order = 25)]
        public int SettlementID;
        ///<summary>
        ///执行宣告编号
        ///</summary>
        [DataMember(Order = 26)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ExecOrderSysID;
        ///<summary>
        ///报单日期
        ///</summary>
        [DataMember(Order = 27)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string InsertDate;
        ///<summary>
        ///插入时间
        ///</summary>
        [DataMember(Order = 28)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string InsertTime;
        ///<summary>
        ///撤销时间
        ///</summary>
        [DataMember(Order = 29)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string CancelTime;
        ///<summary>
        ///执行结果
        ///</summary>
        [DataMember(Order = 30)]
        public byte ExecResult;
        ///<summary>
        ///结算会员编号
        ///</summary>
        [DataMember(Order = 31)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClearingPartID;
        ///<summary>
        ///序号
        ///</summary>
        [DataMember(Order = 32)]
        public int SequenceNo;
        ///<summary>
        ///前置编号
        ///</summary>
        [DataMember(Order = 33)]
        public int FrontID;
        ///<summary>
        ///会话编号
        ///</summary>
        [DataMember(Order = 34)]
        public int SessionID;
        ///<summary>
        ///用户端产品信息
        ///</summary>
        [DataMember(Order = 35)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string UserProductInfo;
        ///<summary>
        ///状态信息
        ///</summary>
        [DataMember(Order = 36)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string StatusMsg;
        ///<summary>
        ///操作用户代码
        ///</summary>
        [DataMember(Order = 37)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string ActiveUserID;
        ///<summary>
        ///经纪公司报单编号
        ///</summary>
        [DataMember(Order = 38)]
        public int BrokerExecOrderSeq;

        public static byte[] GetData(CtpExecOrder obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.ExecOrderRef);
                writer.Write(obj.UserID);
                writer.Write(obj.Volume);
                writer.Write(obj.RequestID);
                writer.Write(obj.BusinessUnit);
                writer.Write(obj.OffsetFlag);
                writer.Write(obj.HedgeFlag);
                writer.Write(obj.ActionType);
                writer.Write(obj.PosiDirection);
                writer.Write(obj.ReservePositionFlag);
                writer.Write(obj.CloseFlag);
                writer.Write(obj.ExecOrderLocalID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ParticipantID);
                writer.Write(obj.ClientID);
                writer.Write(obj.ExchangeInstID);
                writer.Write(obj.TraderID);
                writer.Write(obj.InstallID);
                writer.Write(obj.OrderSubmitStatus);
                writer.Write(obj.NotifySequence);
                writer.Write(obj.TradingDay);
                writer.Write(obj.SettlementID);
                writer.Write(obj.ExecOrderSysID);
                writer.Write(obj.InsertDate);
                writer.Write(obj.InsertTime);
                writer.Write(obj.CancelTime);
                writer.Write(obj.ExecResult);
                writer.Write(obj.ClearingPartID);
                writer.Write(obj.SequenceNo);
                writer.Write(obj.FrontID);
                writer.Write(obj.SessionID);
                writer.Write(obj.UserProductInfo);
                writer.Write(obj.StatusMsg);
                writer.Write(obj.ActiveUserID);
                writer.Write(obj.BrokerExecOrderSeq);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///执行宣告操作
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpExecOrderAction
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///执行宣告操作引用
        ///</summary>
        [DataMember(Order = 3)]
        public int ExecOrderActionRef;
        ///<summary>
        ///执行宣告引用
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string ExecOrderRef;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 5)]
        public int RequestID;
        ///<summary>
        ///前置编号
        ///</summary>
        [DataMember(Order = 6)]
        public int FrontID;
        ///<summary>
        ///会话编号
        ///</summary>
        [DataMember(Order = 7)]
        public int SessionID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///执行宣告操作编号
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ExecOrderSysID;
        ///<summary>
        ///操作标志
        ///</summary>
        [DataMember(Order = 10)]
        public byte ActionFlag;
        ///<summary>
        ///操作日期
        ///</summary>
        [DataMember(Order = 11)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ActionDate;
        ///<summary>
        ///操作时间
        ///</summary>
        [DataMember(Order = 12)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ActionTime;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 14)]
        public int InstallID;
        ///<summary>
        ///本地执行宣告编号
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string ExecOrderLocalID;
        ///<summary>
        ///操作本地编号
        ///</summary>
        [DataMember(Order = 16)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string ActionLocalID;
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///客户代码
        ///</summary>
        [DataMember(Order = 18)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClientID;
        ///<summary>
        ///业务单元
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string BusinessUnit;
        ///<summary>
        ///报单操作状态
        ///</summary>
        [DataMember(Order = 20)]
        public byte OrderActionStatus;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 21)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///执行类型
        ///</summary>
        [DataMember(Order = 22)]
        public byte ActionType;
        ///<summary>
        ///状态信息
        ///</summary>
        [DataMember(Order = 23)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string StatusMsg;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 24)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;

        public static byte[] GetData(CtpExecOrderAction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.ExecOrderActionRef);
                writer.Write(obj.ExecOrderRef);
                writer.Write(obj.RequestID);
                writer.Write(obj.FrontID);
                writer.Write(obj.SessionID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ExecOrderSysID);
                writer.Write(obj.ActionFlag);
                writer.Write(obj.ActionDate);
                writer.Write(obj.ActionTime);
                writer.Write(obj.TraderID);
                writer.Write(obj.InstallID);
                writer.Write(obj.ExecOrderLocalID);
                writer.Write(obj.ActionLocalID);
                writer.Write(obj.ParticipantID);
                writer.Write(obj.ClientID);
                writer.Write(obj.BusinessUnit);
                writer.Write(obj.OrderActionStatus);
                writer.Write(obj.UserID);
                writer.Write(obj.ActionType);
                writer.Write(obj.StatusMsg);
                writer.Write(obj.InstrumentID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///执行宣告查询
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryExecOrder
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///执行宣告编号
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ExecOrderSysID;
        ///<summary>
        ///开始时间
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string InsertTimeStart;
        ///<summary>
        ///结束时间
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string InsertTimeEnd;

        public static byte[] GetData(CtpQryExecOrder obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ExecOrderSysID);
                writer.Write(obj.InsertTimeStart);
                writer.Write(obj.InsertTimeEnd);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///交易所执行宣告信息
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpExchangeExecOrder
    {
        ///<summary>
        ///数量
        ///</summary>
        [DataMember(Order = 1)]
        public int Volume;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 2)]
        public int RequestID;
        ///<summary>
        ///业务单元
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string BusinessUnit;
        ///<summary>
        ///开平标志
        ///</summary>
        [DataMember(Order = 4)]
        public byte OffsetFlag;
        ///<summary>
        ///投机套保标志
        ///</summary>
        [DataMember(Order = 5)]
        public byte HedgeFlag;
        ///<summary>
        ///执行类型
        ///</summary>
        [DataMember(Order = 6)]
        public byte ActionType;
        ///<summary>
        ///保留头寸申请的持仓方向
        ///</summary>
        [DataMember(Order = 7)]
        public byte PosiDirection;
        ///<summary>
        ///期权行权后是否保留期货头寸的标记
        ///</summary>
        [DataMember(Order = 8)]
        public byte ReservePositionFlag;
        ///<summary>
        ///期权行权后生成的头寸是否自动平仓
        ///</summary>
        [DataMember(Order = 9)]
        public byte CloseFlag;
        ///<summary>
        ///本地执行宣告编号
        ///</summary>
        [DataMember(Order = 10)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string ExecOrderLocalID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 11)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 12)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///客户代码
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClientID;
        ///<summary>
        ///合约在交易所的代码
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ExchangeInstID;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 16)]
        public int InstallID;
        ///<summary>
        ///执行宣告提交状态
        ///</summary>
        [DataMember(Order = 17)]
        public byte OrderSubmitStatus;
        ///<summary>
        ///报单提示序号
        ///</summary>
        [DataMember(Order = 18)]
        public int NotifySequence;
        ///<summary>
        ///交易日
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///结算编号
        ///</summary>
        [DataMember(Order = 20)]
        public int SettlementID;
        ///<summary>
        ///执行宣告编号
        ///</summary>
        [DataMember(Order = 21)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ExecOrderSysID;
        ///<summary>
        ///报单日期
        ///</summary>
        [DataMember(Order = 22)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string InsertDate;
        ///<summary>
        ///插入时间
        ///</summary>
        [DataMember(Order = 23)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string InsertTime;
        ///<summary>
        ///撤销时间
        ///</summary>
        [DataMember(Order = 24)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string CancelTime;
        ///<summary>
        ///执行结果
        ///</summary>
        [DataMember(Order = 25)]
        public byte ExecResult;
        ///<summary>
        ///结算会员编号
        ///</summary>
        [DataMember(Order = 26)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClearingPartID;
        ///<summary>
        ///序号
        ///</summary>
        [DataMember(Order = 27)]
        public int SequenceNo;

        public static byte[] GetData(CtpExchangeExecOrder obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.Volume);
                writer.Write(obj.RequestID);
                writer.Write(obj.BusinessUnit);
                writer.Write(obj.OffsetFlag);
                writer.Write(obj.HedgeFlag);
                writer.Write(obj.ActionType);
                writer.Write(obj.PosiDirection);
                writer.Write(obj.ReservePositionFlag);
                writer.Write(obj.CloseFlag);
                writer.Write(obj.ExecOrderLocalID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ParticipantID);
                writer.Write(obj.ClientID);
                writer.Write(obj.ExchangeInstID);
                writer.Write(obj.TraderID);
                writer.Write(obj.InstallID);
                writer.Write(obj.OrderSubmitStatus);
                writer.Write(obj.NotifySequence);
                writer.Write(obj.TradingDay);
                writer.Write(obj.SettlementID);
                writer.Write(obj.ExecOrderSysID);
                writer.Write(obj.InsertDate);
                writer.Write(obj.InsertTime);
                writer.Write(obj.CancelTime);
                writer.Write(obj.ExecResult);
                writer.Write(obj.ClearingPartID);
                writer.Write(obj.SequenceNo);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///交易所执行宣告查询
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryExchangeExecOrder
    {
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///客户代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClientID;
        ///<summary>
        ///合约在交易所的代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ExchangeInstID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;

        public static byte[] GetData(CtpQryExchangeExecOrder obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ParticipantID);
                writer.Write(obj.ClientID);
                writer.Write(obj.ExchangeInstID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.TraderID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///执行宣告操作查询
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryExecOrderAction
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;

        public static byte[] GetData(CtpQryExecOrderAction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.ExchangeID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///交易所执行宣告操作
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpExchangeExecOrderAction
    {
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///执行宣告操作编号
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ExecOrderSysID;
        ///<summary>
        ///操作标志
        ///</summary>
        [DataMember(Order = 3)]
        public byte ActionFlag;
        ///<summary>
        ///操作日期
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ActionDate;
        ///<summary>
        ///操作时间
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ActionTime;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 7)]
        public int InstallID;
        ///<summary>
        ///本地执行宣告编号
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string ExecOrderLocalID;
        ///<summary>
        ///操作本地编号
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string ActionLocalID;
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 10)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///客户代码
        ///</summary>
        [DataMember(Order = 11)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClientID;
        ///<summary>
        ///业务单元
        ///</summary>
        [DataMember(Order = 12)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string BusinessUnit;
        ///<summary>
        ///报单操作状态
        ///</summary>
        [DataMember(Order = 13)]
        public byte OrderActionStatus;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///执行类型
        ///</summary>
        [DataMember(Order = 15)]
        public byte ActionType;

        public static byte[] GetData(CtpExchangeExecOrderAction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ExecOrderSysID);
                writer.Write(obj.ActionFlag);
                writer.Write(obj.ActionDate);
                writer.Write(obj.ActionTime);
                writer.Write(obj.TraderID);
                writer.Write(obj.InstallID);
                writer.Write(obj.ExecOrderLocalID);
                writer.Write(obj.ActionLocalID);
                writer.Write(obj.ParticipantID);
                writer.Write(obj.ClientID);
                writer.Write(obj.BusinessUnit);
                writer.Write(obj.OrderActionStatus);
                writer.Write(obj.UserID);
                writer.Write(obj.ActionType);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///交易所执行宣告操作查询
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryExchangeExecOrderAction
    {
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///客户代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClientID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;

        public static byte[] GetData(CtpQryExchangeExecOrderAction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ParticipantID);
                writer.Write(obj.ClientID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.TraderID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///错误执行宣告
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpErrExecOrder
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///执行宣告引用
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string ExecOrderRef;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///数量
        ///</summary>
        [DataMember(Order = 6)]
        public int Volume;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 7)]
        public int RequestID;
        ///<summary>
        ///业务单元
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string BusinessUnit;
        ///<summary>
        ///开平标志
        ///</summary>
        [DataMember(Order = 9)]
        public byte OffsetFlag;
        ///<summary>
        ///投机套保标志
        ///</summary>
        [DataMember(Order = 10)]
        public byte HedgeFlag;
        ///<summary>
        ///执行类型
        ///</summary>
        [DataMember(Order = 11)]
        public byte ActionType;
        ///<summary>
        ///保留头寸申请的持仓方向
        ///</summary>
        [DataMember(Order = 12)]
        public byte PosiDirection;
        ///<summary>
        ///期权行权后是否保留期货头寸的标记
        ///</summary>
        [DataMember(Order = 13)]
        public byte ReservePositionFlag;
        ///<summary>
        ///期权行权后生成的头寸是否自动平仓
        ///</summary>
        [DataMember(Order = 14)]
        public byte CloseFlag;
        ///<summary>
        ///错误代码
        ///</summary>
        [DataMember(Order = 15)]
        public int ErrorID;
        ///<summary>
        ///错误信息
        ///</summary>
        [DataMember(Order = 16)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string ErrorMsg;

        public static byte[] GetData(CtpErrExecOrder obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.ExecOrderRef);
                writer.Write(obj.UserID);
                writer.Write(obj.Volume);
                writer.Write(obj.RequestID);
                writer.Write(obj.BusinessUnit);
                writer.Write(obj.OffsetFlag);
                writer.Write(obj.HedgeFlag);
                writer.Write(obj.ActionType);
                writer.Write(obj.PosiDirection);
                writer.Write(obj.ReservePositionFlag);
                writer.Write(obj.CloseFlag);
                writer.Write(obj.ErrorID);
                writer.Write(obj.ErrorMsg);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询错误执行宣告
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryErrExecOrder
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;

        public static byte[] GetData(CtpQryErrExecOrder obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///错误执行宣告操作
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpErrExecOrderAction
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///执行宣告操作引用
        ///</summary>
        [DataMember(Order = 3)]
        public int ExecOrderActionRef;
        ///<summary>
        ///执行宣告引用
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string ExecOrderRef;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 5)]
        public int RequestID;
        ///<summary>
        ///前置编号
        ///</summary>
        [DataMember(Order = 6)]
        public int FrontID;
        ///<summary>
        ///会话编号
        ///</summary>
        [DataMember(Order = 7)]
        public int SessionID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///执行宣告操作编号
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ExecOrderSysID;
        ///<summary>
        ///操作标志
        ///</summary>
        [DataMember(Order = 10)]
        public byte ActionFlag;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 11)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 12)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///错误代码
        ///</summary>
        [DataMember(Order = 13)]
        public int ErrorID;
        ///<summary>
        ///错误信息
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string ErrorMsg;

        public static byte[] GetData(CtpErrExecOrderAction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.ExecOrderActionRef);
                writer.Write(obj.ExecOrderRef);
                writer.Write(obj.RequestID);
                writer.Write(obj.FrontID);
                writer.Write(obj.SessionID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ExecOrderSysID);
                writer.Write(obj.ActionFlag);
                writer.Write(obj.UserID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.ErrorID);
                writer.Write(obj.ErrorMsg);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询错误执行宣告操作
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryErrExecOrderAction
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;

        public static byte[] GetData(CtpQryErrExecOrderAction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///投资者期权合约交易权限
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpOptionInstrTradingRight
    {
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///投资者范围
        ///</summary>
        [DataMember(Order = 2)]
        public byte InvestorRange;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///买卖方向
        ///</summary>
        [DataMember(Order = 5)]
        public byte Direction;
        ///<summary>
        ///交易权限
        ///</summary>
        [DataMember(Order = 6)]
        public byte TradingRight;

        public static byte[] GetData(CtpOptionInstrTradingRight obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.InstrumentID);
                writer.Write(obj.InvestorRange);
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.Direction);
                writer.Write(obj.TradingRight);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询期权合约交易权限
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryOptionInstrTradingRight
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///买卖方向
        ///</summary>
        [DataMember(Order = 4)]
        public byte Direction;

        public static byte[] GetData(CtpQryOptionInstrTradingRight obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.Direction);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///输入的询价
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpInputForQuote
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///询价引用
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string ForQuoteRef;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;

        public static byte[] GetData(CtpInputForQuote obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.ForQuoteRef);
                writer.Write(obj.UserID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///询价
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpForQuote
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///询价引用
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string ForQuoteRef;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///本地询价编号
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string ForQuoteLocalID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///客户代码
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClientID;
        ///<summary>
        ///合约在交易所的代码
        ///</summary>
        [DataMember(Order = 10)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ExchangeInstID;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 11)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 12)]
        public int InstallID;
        ///<summary>
        ///报单日期
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string InsertDate;
        ///<summary>
        ///插入时间
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string InsertTime;
        ///<summary>
        ///询价状态
        ///</summary>
        [DataMember(Order = 15)]
        public byte ForQuoteStatus;
        ///<summary>
        ///前置编号
        ///</summary>
        [DataMember(Order = 16)]
        public int FrontID;
        ///<summary>
        ///会话编号
        ///</summary>
        [DataMember(Order = 17)]
        public int SessionID;
        ///<summary>
        ///状态信息
        ///</summary>
        [DataMember(Order = 18)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string StatusMsg;
        ///<summary>
        ///操作用户代码
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string ActiveUserID;
        ///<summary>
        ///经纪公司询价编号
        ///</summary>
        [DataMember(Order = 20)]
        public int BrokerForQutoSeq;

        public static byte[] GetData(CtpForQuote obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.ForQuoteRef);
                writer.Write(obj.UserID);
                writer.Write(obj.ForQuoteLocalID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ParticipantID);
                writer.Write(obj.ClientID);
                writer.Write(obj.ExchangeInstID);
                writer.Write(obj.TraderID);
                writer.Write(obj.InstallID);
                writer.Write(obj.InsertDate);
                writer.Write(obj.InsertTime);
                writer.Write(obj.ForQuoteStatus);
                writer.Write(obj.FrontID);
                writer.Write(obj.SessionID);
                writer.Write(obj.StatusMsg);
                writer.Write(obj.ActiveUserID);
                writer.Write(obj.BrokerForQutoSeq);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///询价查询
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryForQuote
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///开始时间
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string InsertTimeStart;
        ///<summary>
        ///结束时间
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string InsertTimeEnd;

        public static byte[] GetData(CtpQryForQuote obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.InsertTimeStart);
                writer.Write(obj.InsertTimeEnd);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///交易所询价信息
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpExchangeForQuote
    {
        ///<summary>
        ///本地询价编号
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string ForQuoteLocalID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///客户代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClientID;
        ///<summary>
        ///合约在交易所的代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ExchangeInstID;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 7)]
        public int InstallID;
        ///<summary>
        ///报单日期
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string InsertDate;
        ///<summary>
        ///插入时间
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string InsertTime;
        ///<summary>
        ///询价状态
        ///</summary>
        [DataMember(Order = 10)]
        public byte ForQuoteStatus;

        public static byte[] GetData(CtpExchangeForQuote obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ForQuoteLocalID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ParticipantID);
                writer.Write(obj.ClientID);
                writer.Write(obj.ExchangeInstID);
                writer.Write(obj.TraderID);
                writer.Write(obj.InstallID);
                writer.Write(obj.InsertDate);
                writer.Write(obj.InsertTime);
                writer.Write(obj.ForQuoteStatus);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///交易所询价查询
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryExchangeForQuote
    {
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///客户代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClientID;
        ///<summary>
        ///合约在交易所的代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ExchangeInstID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;

        public static byte[] GetData(CtpQryExchangeForQuote obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ParticipantID);
                writer.Write(obj.ClientID);
                writer.Write(obj.ExchangeInstID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.TraderID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///输入的报价
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpInputQuote
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///报价引用
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string QuoteRef;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///卖价格
        ///</summary>
        [DataMember(Order = 6)]
        public double AskPrice;
        ///<summary>
        ///买价格
        ///</summary>
        [DataMember(Order = 7)]
        public double BidPrice;
        ///<summary>
        ///卖数量
        ///</summary>
        [DataMember(Order = 8)]
        public int AskVolume;
        ///<summary>
        ///买数量
        ///</summary>
        [DataMember(Order = 9)]
        public int BidVolume;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 10)]
        public int RequestID;
        ///<summary>
        ///业务单元
        ///</summary>
        [DataMember(Order = 11)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string BusinessUnit;
        ///<summary>
        ///卖开平标志
        ///</summary>
        [DataMember(Order = 12)]
        public byte AskOffsetFlag;
        ///<summary>
        ///买开平标志
        ///</summary>
        [DataMember(Order = 13)]
        public byte BidOffsetFlag;
        ///<summary>
        ///卖投机套保标志
        ///</summary>
        [DataMember(Order = 14)]
        public byte AskHedgeFlag;
        ///<summary>
        ///买投机套保标志
        ///</summary>
        [DataMember(Order = 15)]
        public byte BidHedgeFlag;
        ///<summary>
        ///衍生卖报单引用
        ///</summary>
        [DataMember(Order = 16)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string AskOrderRef;
        ///<summary>
        ///衍生买报单引用
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string BidOrderRef;
        ///<summary>
        ///应价编号
        ///</summary>
        [DataMember(Order = 18)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ForQuoteSysID;

        public static byte[] GetData(CtpInputQuote obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.QuoteRef);
                writer.Write(obj.UserID);
                writer.Write(obj.AskPrice);
                writer.Write(obj.BidPrice);
                writer.Write(obj.AskVolume);
                writer.Write(obj.BidVolume);
                writer.Write(obj.RequestID);
                writer.Write(obj.BusinessUnit);
                writer.Write(obj.AskOffsetFlag);
                writer.Write(obj.BidOffsetFlag);
                writer.Write(obj.AskHedgeFlag);
                writer.Write(obj.BidHedgeFlag);
                writer.Write(obj.AskOrderRef);
                writer.Write(obj.BidOrderRef);
                writer.Write(obj.ForQuoteSysID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///输入报价操作
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpInputQuoteAction
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///报价操作引用
        ///</summary>
        [DataMember(Order = 3)]
        public int QuoteActionRef;
        ///<summary>
        ///报价引用
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string QuoteRef;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 5)]
        public int RequestID;
        ///<summary>
        ///前置编号
        ///</summary>
        [DataMember(Order = 6)]
        public int FrontID;
        ///<summary>
        ///会话编号
        ///</summary>
        [DataMember(Order = 7)]
        public int SessionID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///报价操作编号
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string QuoteSysID;
        ///<summary>
        ///操作标志
        ///</summary>
        [DataMember(Order = 10)]
        public byte ActionFlag;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 11)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 12)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;

        public static byte[] GetData(CtpInputQuoteAction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.QuoteActionRef);
                writer.Write(obj.QuoteRef);
                writer.Write(obj.RequestID);
                writer.Write(obj.FrontID);
                writer.Write(obj.SessionID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.QuoteSysID);
                writer.Write(obj.ActionFlag);
                writer.Write(obj.UserID);
                writer.Write(obj.InstrumentID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///报价
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQuote
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///报价引用
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string QuoteRef;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///卖价格
        ///</summary>
        [DataMember(Order = 6)]
        public double AskPrice;
        ///<summary>
        ///买价格
        ///</summary>
        [DataMember(Order = 7)]
        public double BidPrice;
        ///<summary>
        ///卖数量
        ///</summary>
        [DataMember(Order = 8)]
        public int AskVolume;
        ///<summary>
        ///买数量
        ///</summary>
        [DataMember(Order = 9)]
        public int BidVolume;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 10)]
        public int RequestID;
        ///<summary>
        ///业务单元
        ///</summary>
        [DataMember(Order = 11)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string BusinessUnit;
        ///<summary>
        ///卖开平标志
        ///</summary>
        [DataMember(Order = 12)]
        public byte AskOffsetFlag;
        ///<summary>
        ///买开平标志
        ///</summary>
        [DataMember(Order = 13)]
        public byte BidOffsetFlag;
        ///<summary>
        ///卖投机套保标志
        ///</summary>
        [DataMember(Order = 14)]
        public byte AskHedgeFlag;
        ///<summary>
        ///买投机套保标志
        ///</summary>
        [DataMember(Order = 15)]
        public byte BidHedgeFlag;
        ///<summary>
        ///本地报价编号
        ///</summary>
        [DataMember(Order = 16)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string QuoteLocalID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 18)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///客户代码
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClientID;
        ///<summary>
        ///合约在交易所的代码
        ///</summary>
        [DataMember(Order = 20)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ExchangeInstID;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 21)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 22)]
        public int InstallID;
        ///<summary>
        ///报价提示序号
        ///</summary>
        [DataMember(Order = 23)]
        public int NotifySequence;
        ///<summary>
        ///报价提交状态
        ///</summary>
        [DataMember(Order = 24)]
        public byte OrderSubmitStatus;
        ///<summary>
        ///交易日
        ///</summary>
        [DataMember(Order = 25)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///结算编号
        ///</summary>
        [DataMember(Order = 26)]
        public int SettlementID;
        ///<summary>
        ///报价编号
        ///</summary>
        [DataMember(Order = 27)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string QuoteSysID;
        ///<summary>
        ///报单日期
        ///</summary>
        [DataMember(Order = 28)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string InsertDate;
        ///<summary>
        ///插入时间
        ///</summary>
        [DataMember(Order = 29)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string InsertTime;
        ///<summary>
        ///撤销时间
        ///</summary>
        [DataMember(Order = 30)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string CancelTime;
        ///<summary>
        ///报价状态
        ///</summary>
        [DataMember(Order = 31)]
        public byte QuoteStatus;
        ///<summary>
        ///结算会员编号
        ///</summary>
        [DataMember(Order = 32)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClearingPartID;
        ///<summary>
        ///序号
        ///</summary>
        [DataMember(Order = 33)]
        public int SequenceNo;
        ///<summary>
        ///卖方报单编号
        ///</summary>
        [DataMember(Order = 34)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string AskOrderSysID;
        ///<summary>
        ///买方报单编号
        ///</summary>
        [DataMember(Order = 35)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string BidOrderSysID;
        ///<summary>
        ///前置编号
        ///</summary>
        [DataMember(Order = 36)]
        public int FrontID;
        ///<summary>
        ///会话编号
        ///</summary>
        [DataMember(Order = 37)]
        public int SessionID;
        ///<summary>
        ///用户端产品信息
        ///</summary>
        [DataMember(Order = 38)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string UserProductInfo;
        ///<summary>
        ///状态信息
        ///</summary>
        [DataMember(Order = 39)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string StatusMsg;
        ///<summary>
        ///操作用户代码
        ///</summary>
        [DataMember(Order = 40)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string ActiveUserID;
        ///<summary>
        ///经纪公司报价编号
        ///</summary>
        [DataMember(Order = 41)]
        public int BrokerQuoteSeq;
        ///<summary>
        ///衍生卖报单引用
        ///</summary>
        [DataMember(Order = 42)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string AskOrderRef;
        ///<summary>
        ///衍生买报单引用
        ///</summary>
        [DataMember(Order = 43)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string BidOrderRef;
        ///<summary>
        ///应价编号
        ///</summary>
        [DataMember(Order = 44)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ForQuoteSysID;

        public static byte[] GetData(CtpQuote obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.QuoteRef);
                writer.Write(obj.UserID);
                writer.Write(obj.AskPrice);
                writer.Write(obj.BidPrice);
                writer.Write(obj.AskVolume);
                writer.Write(obj.BidVolume);
                writer.Write(obj.RequestID);
                writer.Write(obj.BusinessUnit);
                writer.Write(obj.AskOffsetFlag);
                writer.Write(obj.BidOffsetFlag);
                writer.Write(obj.AskHedgeFlag);
                writer.Write(obj.BidHedgeFlag);
                writer.Write(obj.QuoteLocalID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ParticipantID);
                writer.Write(obj.ClientID);
                writer.Write(obj.ExchangeInstID);
                writer.Write(obj.TraderID);
                writer.Write(obj.InstallID);
                writer.Write(obj.NotifySequence);
                writer.Write(obj.OrderSubmitStatus);
                writer.Write(obj.TradingDay);
                writer.Write(obj.SettlementID);
                writer.Write(obj.QuoteSysID);
                writer.Write(obj.InsertDate);
                writer.Write(obj.InsertTime);
                writer.Write(obj.CancelTime);
                writer.Write(obj.QuoteStatus);
                writer.Write(obj.ClearingPartID);
                writer.Write(obj.SequenceNo);
                writer.Write(obj.AskOrderSysID);
                writer.Write(obj.BidOrderSysID);
                writer.Write(obj.FrontID);
                writer.Write(obj.SessionID);
                writer.Write(obj.UserProductInfo);
                writer.Write(obj.StatusMsg);
                writer.Write(obj.ActiveUserID);
                writer.Write(obj.BrokerQuoteSeq);
                writer.Write(obj.AskOrderRef);
                writer.Write(obj.BidOrderRef);
                writer.Write(obj.ForQuoteSysID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///报价操作
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQuoteAction
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///报价操作引用
        ///</summary>
        [DataMember(Order = 3)]
        public int QuoteActionRef;
        ///<summary>
        ///报价引用
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string QuoteRef;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 5)]
        public int RequestID;
        ///<summary>
        ///前置编号
        ///</summary>
        [DataMember(Order = 6)]
        public int FrontID;
        ///<summary>
        ///会话编号
        ///</summary>
        [DataMember(Order = 7)]
        public int SessionID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///报价操作编号
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string QuoteSysID;
        ///<summary>
        ///操作标志
        ///</summary>
        [DataMember(Order = 10)]
        public byte ActionFlag;
        ///<summary>
        ///操作日期
        ///</summary>
        [DataMember(Order = 11)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ActionDate;
        ///<summary>
        ///操作时间
        ///</summary>
        [DataMember(Order = 12)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ActionTime;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 14)]
        public int InstallID;
        ///<summary>
        ///本地报价编号
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string QuoteLocalID;
        ///<summary>
        ///操作本地编号
        ///</summary>
        [DataMember(Order = 16)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string ActionLocalID;
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///客户代码
        ///</summary>
        [DataMember(Order = 18)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClientID;
        ///<summary>
        ///业务单元
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string BusinessUnit;
        ///<summary>
        ///报单操作状态
        ///</summary>
        [DataMember(Order = 20)]
        public byte OrderActionStatus;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 21)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///状态信息
        ///</summary>
        [DataMember(Order = 22)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string StatusMsg;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 23)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;

        public static byte[] GetData(CtpQuoteAction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.QuoteActionRef);
                writer.Write(obj.QuoteRef);
                writer.Write(obj.RequestID);
                writer.Write(obj.FrontID);
                writer.Write(obj.SessionID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.QuoteSysID);
                writer.Write(obj.ActionFlag);
                writer.Write(obj.ActionDate);
                writer.Write(obj.ActionTime);
                writer.Write(obj.TraderID);
                writer.Write(obj.InstallID);
                writer.Write(obj.QuoteLocalID);
                writer.Write(obj.ActionLocalID);
                writer.Write(obj.ParticipantID);
                writer.Write(obj.ClientID);
                writer.Write(obj.BusinessUnit);
                writer.Write(obj.OrderActionStatus);
                writer.Write(obj.UserID);
                writer.Write(obj.StatusMsg);
                writer.Write(obj.InstrumentID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///报价查询
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryQuote
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///报价编号
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string QuoteSysID;
        ///<summary>
        ///开始时间
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string InsertTimeStart;
        ///<summary>
        ///结束时间
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string InsertTimeEnd;

        public static byte[] GetData(CtpQryQuote obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.QuoteSysID);
                writer.Write(obj.InsertTimeStart);
                writer.Write(obj.InsertTimeEnd);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///交易所报价信息
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpExchangeQuote
    {
        ///<summary>
        ///卖价格
        ///</summary>
        [DataMember(Order = 1)]
        public double AskPrice;
        ///<summary>
        ///买价格
        ///</summary>
        [DataMember(Order = 2)]
        public double BidPrice;
        ///<summary>
        ///卖数量
        ///</summary>
        [DataMember(Order = 3)]
        public int AskVolume;
        ///<summary>
        ///买数量
        ///</summary>
        [DataMember(Order = 4)]
        public int BidVolume;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 5)]
        public int RequestID;
        ///<summary>
        ///业务单元
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string BusinessUnit;
        ///<summary>
        ///卖开平标志
        ///</summary>
        [DataMember(Order = 7)]
        public byte AskOffsetFlag;
        ///<summary>
        ///买开平标志
        ///</summary>
        [DataMember(Order = 8)]
        public byte BidOffsetFlag;
        ///<summary>
        ///卖投机套保标志
        ///</summary>
        [DataMember(Order = 9)]
        public byte AskHedgeFlag;
        ///<summary>
        ///买投机套保标志
        ///</summary>
        [DataMember(Order = 10)]
        public byte BidHedgeFlag;
        ///<summary>
        ///本地报价编号
        ///</summary>
        [DataMember(Order = 11)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string QuoteLocalID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 12)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///客户代码
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClientID;
        ///<summary>
        ///合约在交易所的代码
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ExchangeInstID;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 16)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 17)]
        public int InstallID;
        ///<summary>
        ///报价提示序号
        ///</summary>
        [DataMember(Order = 18)]
        public int NotifySequence;
        ///<summary>
        ///报价提交状态
        ///</summary>
        [DataMember(Order = 19)]
        public byte OrderSubmitStatus;
        ///<summary>
        ///交易日
        ///</summary>
        [DataMember(Order = 20)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///结算编号
        ///</summary>
        [DataMember(Order = 21)]
        public int SettlementID;
        ///<summary>
        ///报价编号
        ///</summary>
        [DataMember(Order = 22)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string QuoteSysID;
        ///<summary>
        ///报单日期
        ///</summary>
        [DataMember(Order = 23)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string InsertDate;
        ///<summary>
        ///插入时间
        ///</summary>
        [DataMember(Order = 24)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string InsertTime;
        ///<summary>
        ///撤销时间
        ///</summary>
        [DataMember(Order = 25)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string CancelTime;
        ///<summary>
        ///报价状态
        ///</summary>
        [DataMember(Order = 26)]
        public byte QuoteStatus;
        ///<summary>
        ///结算会员编号
        ///</summary>
        [DataMember(Order = 27)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClearingPartID;
        ///<summary>
        ///序号
        ///</summary>
        [DataMember(Order = 28)]
        public int SequenceNo;
        ///<summary>
        ///卖方报单编号
        ///</summary>
        [DataMember(Order = 29)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string AskOrderSysID;
        ///<summary>
        ///买方报单编号
        ///</summary>
        [DataMember(Order = 30)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string BidOrderSysID;
        ///<summary>
        ///应价编号
        ///</summary>
        [DataMember(Order = 31)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ForQuoteSysID;

        public static byte[] GetData(CtpExchangeQuote obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.AskPrice);
                writer.Write(obj.BidPrice);
                writer.Write(obj.AskVolume);
                writer.Write(obj.BidVolume);
                writer.Write(obj.RequestID);
                writer.Write(obj.BusinessUnit);
                writer.Write(obj.AskOffsetFlag);
                writer.Write(obj.BidOffsetFlag);
                writer.Write(obj.AskHedgeFlag);
                writer.Write(obj.BidHedgeFlag);
                writer.Write(obj.QuoteLocalID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ParticipantID);
                writer.Write(obj.ClientID);
                writer.Write(obj.ExchangeInstID);
                writer.Write(obj.TraderID);
                writer.Write(obj.InstallID);
                writer.Write(obj.NotifySequence);
                writer.Write(obj.OrderSubmitStatus);
                writer.Write(obj.TradingDay);
                writer.Write(obj.SettlementID);
                writer.Write(obj.QuoteSysID);
                writer.Write(obj.InsertDate);
                writer.Write(obj.InsertTime);
                writer.Write(obj.CancelTime);
                writer.Write(obj.QuoteStatus);
                writer.Write(obj.ClearingPartID);
                writer.Write(obj.SequenceNo);
                writer.Write(obj.AskOrderSysID);
                writer.Write(obj.BidOrderSysID);
                writer.Write(obj.ForQuoteSysID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///交易所报价查询
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryExchangeQuote
    {
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///客户代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClientID;
        ///<summary>
        ///合约在交易所的代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ExchangeInstID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;

        public static byte[] GetData(CtpQryExchangeQuote obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ParticipantID);
                writer.Write(obj.ClientID);
                writer.Write(obj.ExchangeInstID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.TraderID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///报价操作查询
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryQuoteAction
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;

        public static byte[] GetData(CtpQryQuoteAction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.ExchangeID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///交易所报价操作
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpExchangeQuoteAction
    {
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///报价操作编号
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string QuoteSysID;
        ///<summary>
        ///操作标志
        ///</summary>
        [DataMember(Order = 3)]
        public byte ActionFlag;
        ///<summary>
        ///操作日期
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ActionDate;
        ///<summary>
        ///操作时间
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ActionTime;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 7)]
        public int InstallID;
        ///<summary>
        ///本地报价编号
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string QuoteLocalID;
        ///<summary>
        ///操作本地编号
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string ActionLocalID;
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 10)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///客户代码
        ///</summary>
        [DataMember(Order = 11)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClientID;
        ///<summary>
        ///业务单元
        ///</summary>
        [DataMember(Order = 12)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string BusinessUnit;
        ///<summary>
        ///报单操作状态
        ///</summary>
        [DataMember(Order = 13)]
        public byte OrderActionStatus;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;

        public static byte[] GetData(CtpExchangeQuoteAction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ExchangeID);
                writer.Write(obj.QuoteSysID);
                writer.Write(obj.ActionFlag);
                writer.Write(obj.ActionDate);
                writer.Write(obj.ActionTime);
                writer.Write(obj.TraderID);
                writer.Write(obj.InstallID);
                writer.Write(obj.QuoteLocalID);
                writer.Write(obj.ActionLocalID);
                writer.Write(obj.ParticipantID);
                writer.Write(obj.ClientID);
                writer.Write(obj.BusinessUnit);
                writer.Write(obj.OrderActionStatus);
                writer.Write(obj.UserID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///交易所报价操作查询
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryExchangeQuoteAction
    {
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///客户代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClientID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;

        public static byte[] GetData(CtpQryExchangeQuoteAction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ParticipantID);
                writer.Write(obj.ClientID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.TraderID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///期权合约delta值
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpOptionInstrDelta
    {
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///投资者范围
        ///</summary>
        [DataMember(Order = 2)]
        public byte InvestorRange;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///Delta值
        ///</summary>
        [DataMember(Order = 5)]
        public double Delta;

        public static byte[] GetData(CtpOptionInstrDelta obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.InstrumentID);
                writer.Write(obj.InvestorRange);
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.Delta);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///发给做市商的询价请求
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpForQuoteRsp
    {
        ///<summary>
        ///交易日
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///询价编号
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ForQuoteSysID;
        ///<summary>
        ///询价时间
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ForQuoteTime;
        ///<summary>
        ///业务日期
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ActionDay;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;

        public static byte[] GetData(CtpForQuoteRsp obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradingDay);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.ForQuoteSysID);
                writer.Write(obj.ForQuoteTime);
                writer.Write(obj.ActionDay);
                writer.Write(obj.ExchangeID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///当前期权合约执行偏移值的详细内容
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpStrikeOffset
    {
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///投资者范围
        ///</summary>
        [DataMember(Order = 2)]
        public byte InvestorRange;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///执行偏移值
        ///</summary>
        [DataMember(Order = 5)]
        public double Offset;

        public static byte[] GetData(CtpStrikeOffset obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.InstrumentID);
                writer.Write(obj.InvestorRange);
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.Offset);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///期权执行偏移值查询
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryStrikeOffset
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;

        public static byte[] GetData(CtpQryStrikeOffset obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///输入批量报单操作
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpInputBatchOrderAction
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///报单操作引用
        ///</summary>
        [DataMember(Order = 3)]
        public int OrderActionRef;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 4)]
        public int RequestID;
        ///<summary>
        ///前置编号
        ///</summary>
        [DataMember(Order = 5)]
        public int FrontID;
        ///<summary>
        ///会话编号
        ///</summary>
        [DataMember(Order = 6)]
        public int SessionID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;

        public static byte[] GetData(CtpInputBatchOrderAction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.OrderActionRef);
                writer.Write(obj.RequestID);
                writer.Write(obj.FrontID);
                writer.Write(obj.SessionID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.UserID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///批量报单操作
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpBatchOrderAction
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///报单操作引用
        ///</summary>
        [DataMember(Order = 3)]
        public int OrderActionRef;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 4)]
        public int RequestID;
        ///<summary>
        ///前置编号
        ///</summary>
        [DataMember(Order = 5)]
        public int FrontID;
        ///<summary>
        ///会话编号
        ///</summary>
        [DataMember(Order = 6)]
        public int SessionID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///操作日期
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ActionDate;
        ///<summary>
        ///操作时间
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ActionTime;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 10)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 11)]
        public int InstallID;
        ///<summary>
        ///操作本地编号
        ///</summary>
        [DataMember(Order = 12)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string ActionLocalID;
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///客户代码
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClientID;
        ///<summary>
        ///业务单元
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string BusinessUnit;
        ///<summary>
        ///报单操作状态
        ///</summary>
        [DataMember(Order = 16)]
        public byte OrderActionStatus;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///状态信息
        ///</summary>
        [DataMember(Order = 18)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string StatusMsg;

        public static byte[] GetData(CtpBatchOrderAction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.OrderActionRef);
                writer.Write(obj.RequestID);
                writer.Write(obj.FrontID);
                writer.Write(obj.SessionID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ActionDate);
                writer.Write(obj.ActionTime);
                writer.Write(obj.TraderID);
                writer.Write(obj.InstallID);
                writer.Write(obj.ActionLocalID);
                writer.Write(obj.ParticipantID);
                writer.Write(obj.ClientID);
                writer.Write(obj.BusinessUnit);
                writer.Write(obj.OrderActionStatus);
                writer.Write(obj.UserID);
                writer.Write(obj.StatusMsg);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///交易所批量报单操作
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpExchangeBatchOrderAction
    {
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///操作日期
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ActionDate;
        ///<summary>
        ///操作时间
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ActionTime;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 5)]
        public int InstallID;
        ///<summary>
        ///操作本地编号
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string ActionLocalID;
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///客户代码
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClientID;
        ///<summary>
        ///业务单元
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string BusinessUnit;
        ///<summary>
        ///报单操作状态
        ///</summary>
        [DataMember(Order = 10)]
        public byte OrderActionStatus;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 11)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;

        public static byte[] GetData(CtpExchangeBatchOrderAction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ActionDate);
                writer.Write(obj.ActionTime);
                writer.Write(obj.TraderID);
                writer.Write(obj.InstallID);
                writer.Write(obj.ActionLocalID);
                writer.Write(obj.ParticipantID);
                writer.Write(obj.ClientID);
                writer.Write(obj.BusinessUnit);
                writer.Write(obj.OrderActionStatus);
                writer.Write(obj.UserID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询批量报单操作
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryBatchOrderAction
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;

        public static byte[] GetData(CtpQryBatchOrderAction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.ExchangeID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///组合合约安全系数
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpCombInstrumentGuard
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///
        ///</summary>
        [DataMember(Order = 3)]
        public double GuarantRatio;

        public static byte[] GetData(CtpCombInstrumentGuard obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.GuarantRatio);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///组合合约安全系数查询
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryCombInstrumentGuard
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;

        public static byte[] GetData(CtpQryCombInstrumentGuard obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InstrumentID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///输入的申请组合
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpInputCombAction
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///组合引用
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string CombActionRef;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///买卖方向
        ///</summary>
        [DataMember(Order = 6)]
        public byte Direction;
        ///<summary>
        ///数量
        ///</summary>
        [DataMember(Order = 7)]
        public int Volume;
        ///<summary>
        ///组合指令方向
        ///</summary>
        [DataMember(Order = 8)]
        public byte CombDirection;
        ///<summary>
        ///投机套保标志
        ///</summary>
        [DataMember(Order = 9)]
        public byte HedgeFlag;

        public static byte[] GetData(CtpInputCombAction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.CombActionRef);
                writer.Write(obj.UserID);
                writer.Write(obj.Direction);
                writer.Write(obj.Volume);
                writer.Write(obj.CombDirection);
                writer.Write(obj.HedgeFlag);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///申请组合
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpCombAction
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///组合引用
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string CombActionRef;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///买卖方向
        ///</summary>
        [DataMember(Order = 6)]
        public byte Direction;
        ///<summary>
        ///数量
        ///</summary>
        [DataMember(Order = 7)]
        public int Volume;
        ///<summary>
        ///组合指令方向
        ///</summary>
        [DataMember(Order = 8)]
        public byte CombDirection;
        ///<summary>
        ///投机套保标志
        ///</summary>
        [DataMember(Order = 9)]
        public byte HedgeFlag;
        ///<summary>
        ///本地申请组合编号
        ///</summary>
        [DataMember(Order = 10)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string ActionLocalID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 11)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 12)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///客户代码
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClientID;
        ///<summary>
        ///合约在交易所的代码
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ExchangeInstID;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 16)]
        public int InstallID;
        ///<summary>
        ///组合状态
        ///</summary>
        [DataMember(Order = 17)]
        public byte ActionStatus;
        ///<summary>
        ///报单提示序号
        ///</summary>
        [DataMember(Order = 18)]
        public int NotifySequence;
        ///<summary>
        ///交易日
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///结算编号
        ///</summary>
        [DataMember(Order = 20)]
        public int SettlementID;
        ///<summary>
        ///序号
        ///</summary>
        [DataMember(Order = 21)]
        public int SequenceNo;
        ///<summary>
        ///前置编号
        ///</summary>
        [DataMember(Order = 22)]
        public int FrontID;
        ///<summary>
        ///会话编号
        ///</summary>
        [DataMember(Order = 23)]
        public int SessionID;
        ///<summary>
        ///用户端产品信息
        ///</summary>
        [DataMember(Order = 24)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string UserProductInfo;
        ///<summary>
        ///状态信息
        ///</summary>
        [DataMember(Order = 25)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string StatusMsg;

        public static byte[] GetData(CtpCombAction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.CombActionRef);
                writer.Write(obj.UserID);
                writer.Write(obj.Direction);
                writer.Write(obj.Volume);
                writer.Write(obj.CombDirection);
                writer.Write(obj.HedgeFlag);
                writer.Write(obj.ActionLocalID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ParticipantID);
                writer.Write(obj.ClientID);
                writer.Write(obj.ExchangeInstID);
                writer.Write(obj.TraderID);
                writer.Write(obj.InstallID);
                writer.Write(obj.ActionStatus);
                writer.Write(obj.NotifySequence);
                writer.Write(obj.TradingDay);
                writer.Write(obj.SettlementID);
                writer.Write(obj.SequenceNo);
                writer.Write(obj.FrontID);
                writer.Write(obj.SessionID);
                writer.Write(obj.UserProductInfo);
                writer.Write(obj.StatusMsg);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///申请组合查询
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryCombAction
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;

        public static byte[] GetData(CtpQryCombAction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.ExchangeID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///交易所申请组合信息
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpExchangeCombAction
    {
        ///<summary>
        ///买卖方向
        ///</summary>
        [DataMember(Order = 1)]
        public byte Direction;
        ///<summary>
        ///数量
        ///</summary>
        [DataMember(Order = 2)]
        public int Volume;
        ///<summary>
        ///组合指令方向
        ///</summary>
        [DataMember(Order = 3)]
        public byte CombDirection;
        ///<summary>
        ///投机套保标志
        ///</summary>
        [DataMember(Order = 4)]
        public byte HedgeFlag;
        ///<summary>
        ///本地申请组合编号
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string ActionLocalID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///客户代码
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClientID;
        ///<summary>
        ///合约在交易所的代码
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ExchangeInstID;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 10)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 11)]
        public int InstallID;
        ///<summary>
        ///组合状态
        ///</summary>
        [DataMember(Order = 12)]
        public byte ActionStatus;
        ///<summary>
        ///报单提示序号
        ///</summary>
        [DataMember(Order = 13)]
        public int NotifySequence;
        ///<summary>
        ///交易日
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///结算编号
        ///</summary>
        [DataMember(Order = 15)]
        public int SettlementID;
        ///<summary>
        ///序号
        ///</summary>
        [DataMember(Order = 16)]
        public int SequenceNo;

        public static byte[] GetData(CtpExchangeCombAction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.Direction);
                writer.Write(obj.Volume);
                writer.Write(obj.CombDirection);
                writer.Write(obj.HedgeFlag);
                writer.Write(obj.ActionLocalID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ParticipantID);
                writer.Write(obj.ClientID);
                writer.Write(obj.ExchangeInstID);
                writer.Write(obj.TraderID);
                writer.Write(obj.InstallID);
                writer.Write(obj.ActionStatus);
                writer.Write(obj.NotifySequence);
                writer.Write(obj.TradingDay);
                writer.Write(obj.SettlementID);
                writer.Write(obj.SequenceNo);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///交易所申请组合查询
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryExchangeCombAction
    {
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///客户代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClientID;
        ///<summary>
        ///合约在交易所的代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ExchangeInstID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;

        public static byte[] GetData(CtpQryExchangeCombAction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ParticipantID);
                writer.Write(obj.ClientID);
                writer.Write(obj.ExchangeInstID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.TraderID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///产品报价汇率
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpProductExchRate
    {
        ///<summary>
        ///产品代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ProductID;
        ///<summary>
        ///报价币种类型
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string QuoteCurrencyID;
        ///<summary>
        ///汇率
        ///</summary>
        [DataMember(Order = 3)]
        public double ExchangeRate;

        public static byte[] GetData(CtpProductExchRate obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ProductID);
                writer.Write(obj.QuoteCurrencyID);
                writer.Write(obj.ExchangeRate);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///产品报价汇率查询
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryProductExchRate
    {
        ///<summary>
        ///产品代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ProductID;

        public static byte[] GetData(CtpQryProductExchRate obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ProductID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询询价价差参数
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryForQuoteParam
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;

        public static byte[] GetData(CtpQryForQuoteParam obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.ExchangeID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///询价价差参数
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpForQuoteParam
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///最新价
        ///</summary>
        [DataMember(Order = 4)]
        public double LastPrice;
        ///<summary>
        ///价差
        ///</summary>
        [DataMember(Order = 5)]
        public double PriceInterval;

        public static byte[] GetData(CtpForQuoteParam obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.LastPrice);
                writer.Write(obj.PriceInterval);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///市场行情
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpMarketData
    {
        ///<summary>
        ///交易日
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///合约在交易所的代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ExchangeInstID;
        ///<summary>
        ///最新价
        ///</summary>
        [DataMember(Order = 5)]
        public double LastPrice;
        ///<summary>
        ///上次结算价
        ///</summary>
        [DataMember(Order = 6)]
        public double PreSettlementPrice;
        ///<summary>
        ///昨收盘
        ///</summary>
        [DataMember(Order = 7)]
        public double PreClosePrice;
        ///<summary>
        ///昨持仓量
        ///</summary>
        [DataMember(Order = 8)]
        public double PreOpenInterest;
        ///<summary>
        ///今开盘
        ///</summary>
        [DataMember(Order = 9)]
        public double OpenPrice;
        ///<summary>
        ///最高价
        ///</summary>
        [DataMember(Order = 10)]
        public double HighestPrice;
        ///<summary>
        ///最低价
        ///</summary>
        [DataMember(Order = 11)]
        public double LowestPrice;
        ///<summary>
        ///数量
        ///</summary>
        [DataMember(Order = 12)]
        public int Volume;
        ///<summary>
        ///成交金额
        ///</summary>
        [DataMember(Order = 13)]
        public double Turnover;
        ///<summary>
        ///持仓量
        ///</summary>
        [DataMember(Order = 14)]
        public double OpenInterest;
        ///<summary>
        ///今收盘
        ///</summary>
        [DataMember(Order = 15)]
        public double ClosePrice;
        ///<summary>
        ///本次结算价
        ///</summary>
        [DataMember(Order = 16)]
        public double SettlementPrice;
        ///<summary>
        ///涨停板价
        ///</summary>
        [DataMember(Order = 17)]
        public double UpperLimitPrice;
        ///<summary>
        ///跌停板价
        ///</summary>
        [DataMember(Order = 18)]
        public double LowerLimitPrice;
        ///<summary>
        ///昨虚实度
        ///</summary>
        [DataMember(Order = 19)]
        public double PreDelta;
        ///<summary>
        ///今虚实度
        ///</summary>
        [DataMember(Order = 20)]
        public double CurrDelta;
        ///<summary>
        ///最后修改时间
        ///</summary>
        [DataMember(Order = 21)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string UpdateTime;
        ///<summary>
        ///最后修改毫秒
        ///</summary>
        [DataMember(Order = 22)]
        public int UpdateMillisec;
        ///<summary>
        ///业务日期
        ///</summary>
        [DataMember(Order = 23)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ActionDay;

        public static byte[] GetData(CtpMarketData obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradingDay);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ExchangeInstID);
                writer.Write(obj.LastPrice);
                writer.Write(obj.PreSettlementPrice);
                writer.Write(obj.PreClosePrice);
                writer.Write(obj.PreOpenInterest);
                writer.Write(obj.OpenPrice);
                writer.Write(obj.HighestPrice);
                writer.Write(obj.LowestPrice);
                writer.Write(obj.Volume);
                writer.Write(obj.Turnover);
                writer.Write(obj.OpenInterest);
                writer.Write(obj.ClosePrice);
                writer.Write(obj.SettlementPrice);
                writer.Write(obj.UpperLimitPrice);
                writer.Write(obj.LowerLimitPrice);
                writer.Write(obj.PreDelta);
                writer.Write(obj.CurrDelta);
                writer.Write(obj.UpdateTime);
                writer.Write(obj.UpdateMillisec);
                writer.Write(obj.ActionDay);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///行情基础属性
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpMarketDataBase
    {
        ///<summary>
        ///交易日
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///上次结算价
        ///</summary>
        [DataMember(Order = 2)]
        public double PreSettlementPrice;
        ///<summary>
        ///昨收盘
        ///</summary>
        [DataMember(Order = 3)]
        public double PreClosePrice;
        ///<summary>
        ///昨持仓量
        ///</summary>
        [DataMember(Order = 4)]
        public double PreOpenInterest;
        ///<summary>
        ///昨虚实度
        ///</summary>
        [DataMember(Order = 5)]
        public double PreDelta;

        public static byte[] GetData(CtpMarketDataBase obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradingDay);
                writer.Write(obj.PreSettlementPrice);
                writer.Write(obj.PreClosePrice);
                writer.Write(obj.PreOpenInterest);
                writer.Write(obj.PreDelta);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///行情静态属性
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpMarketDataStatic
    {
        ///<summary>
        ///今开盘
        ///</summary>
        [DataMember(Order = 1)]
        public double OpenPrice;
        ///<summary>
        ///最高价
        ///</summary>
        [DataMember(Order = 2)]
        public double HighestPrice;
        ///<summary>
        ///最低价
        ///</summary>
        [DataMember(Order = 3)]
        public double LowestPrice;
        ///<summary>
        ///今收盘
        ///</summary>
        [DataMember(Order = 4)]
        public double ClosePrice;
        ///<summary>
        ///涨停板价
        ///</summary>
        [DataMember(Order = 5)]
        public double UpperLimitPrice;
        ///<summary>
        ///跌停板价
        ///</summary>
        [DataMember(Order = 6)]
        public double LowerLimitPrice;
        ///<summary>
        ///本次结算价
        ///</summary>
        [DataMember(Order = 7)]
        public double SettlementPrice;
        ///<summary>
        ///今虚实度
        ///</summary>
        [DataMember(Order = 8)]
        public double CurrDelta;

        public static byte[] GetData(CtpMarketDataStatic obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.OpenPrice);
                writer.Write(obj.HighestPrice);
                writer.Write(obj.LowestPrice);
                writer.Write(obj.ClosePrice);
                writer.Write(obj.UpperLimitPrice);
                writer.Write(obj.LowerLimitPrice);
                writer.Write(obj.SettlementPrice);
                writer.Write(obj.CurrDelta);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///行情最新成交属性
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpMarketDataLastMatch
    {
        ///<summary>
        ///最新价
        ///</summary>
        [DataMember(Order = 1)]
        public double LastPrice;
        ///<summary>
        ///数量
        ///</summary>
        [DataMember(Order = 2)]
        public int Volume;
        ///<summary>
        ///成交金额
        ///</summary>
        [DataMember(Order = 3)]
        public double Turnover;
        ///<summary>
        ///持仓量
        ///</summary>
        [DataMember(Order = 4)]
        public double OpenInterest;

        public static byte[] GetData(CtpMarketDataLastMatch obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.LastPrice);
                writer.Write(obj.Volume);
                writer.Write(obj.Turnover);
                writer.Write(obj.OpenInterest);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///行情最优价属性
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpMarketDataBestPrice
    {
        ///<summary>
        ///申买价一
        ///</summary>
        [DataMember(Order = 1)]
        public double BidPrice1;
        ///<summary>
        ///申买量一
        ///</summary>
        [DataMember(Order = 2)]
        public int BidVolume1;
        ///<summary>
        ///申卖价一
        ///</summary>
        [DataMember(Order = 3)]
        public double AskPrice1;
        ///<summary>
        ///申卖量一
        ///</summary>
        [DataMember(Order = 4)]
        public int AskVolume1;

        public static byte[] GetData(CtpMarketDataBestPrice obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BidPrice1);
                writer.Write(obj.BidVolume1);
                writer.Write(obj.AskPrice1);
                writer.Write(obj.AskVolume1);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///行情申买二、三属性
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpMarketDataBid23
    {
        ///<summary>
        ///申买价二
        ///</summary>
        [DataMember(Order = 1)]
        public double BidPrice2;
        ///<summary>
        ///申买量二
        ///</summary>
        [DataMember(Order = 2)]
        public int BidVolume2;
        ///<summary>
        ///申买价三
        ///</summary>
        [DataMember(Order = 3)]
        public double BidPrice3;
        ///<summary>
        ///申买量三
        ///</summary>
        [DataMember(Order = 4)]
        public int BidVolume3;

        public static byte[] GetData(CtpMarketDataBid23 obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BidPrice2);
                writer.Write(obj.BidVolume2);
                writer.Write(obj.BidPrice3);
                writer.Write(obj.BidVolume3);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///行情申卖二、三属性
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpMarketDataAsk23
    {
        ///<summary>
        ///申卖价二
        ///</summary>
        [DataMember(Order = 1)]
        public double AskPrice2;
        ///<summary>
        ///申卖量二
        ///</summary>
        [DataMember(Order = 2)]
        public int AskVolume2;
        ///<summary>
        ///申卖价三
        ///</summary>
        [DataMember(Order = 3)]
        public double AskPrice3;
        ///<summary>
        ///申卖量三
        ///</summary>
        [DataMember(Order = 4)]
        public int AskVolume3;

        public static byte[] GetData(CtpMarketDataAsk23 obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.AskPrice2);
                writer.Write(obj.AskVolume2);
                writer.Write(obj.AskPrice3);
                writer.Write(obj.AskVolume3);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///行情申买四、五属性
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpMarketDataBid45
    {
        ///<summary>
        ///申买价四
        ///</summary>
        [DataMember(Order = 1)]
        public double BidPrice4;
        ///<summary>
        ///申买量四
        ///</summary>
        [DataMember(Order = 2)]
        public int BidVolume4;
        ///<summary>
        ///申买价五
        ///</summary>
        [DataMember(Order = 3)]
        public double BidPrice5;
        ///<summary>
        ///申买量五
        ///</summary>
        [DataMember(Order = 4)]
        public int BidVolume5;

        public static byte[] GetData(CtpMarketDataBid45 obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BidPrice4);
                writer.Write(obj.BidVolume4);
                writer.Write(obj.BidPrice5);
                writer.Write(obj.BidVolume5);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///行情申卖四、五属性
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpMarketDataAsk45
    {
        ///<summary>
        ///申卖价四
        ///</summary>
        [DataMember(Order = 1)]
        public double AskPrice4;
        ///<summary>
        ///申卖量四
        ///</summary>
        [DataMember(Order = 2)]
        public int AskVolume4;
        ///<summary>
        ///申卖价五
        ///</summary>
        [DataMember(Order = 3)]
        public double AskPrice5;
        ///<summary>
        ///申卖量五
        ///</summary>
        [DataMember(Order = 4)]
        public int AskVolume5;

        public static byte[] GetData(CtpMarketDataAsk45 obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.AskPrice4);
                writer.Write(obj.AskVolume4);
                writer.Write(obj.AskPrice5);
                writer.Write(obj.AskVolume5);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///行情更新时间属性
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpMarketDataUpdateTime
    {
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///最后修改时间
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string UpdateTime;
        ///<summary>
        ///最后修改毫秒
        ///</summary>
        [DataMember(Order = 3)]
        public int UpdateMillisec;
        ///<summary>
        ///业务日期
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ActionDay;

        public static byte[] GetData(CtpMarketDataUpdateTime obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.InstrumentID);
                writer.Write(obj.UpdateTime);
                writer.Write(obj.UpdateMillisec);
                writer.Write(obj.ActionDay);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///行情交易所代码属性
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpMarketDataExchange
    {
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;

        public static byte[] GetData(CtpMarketDataExchange obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ExchangeID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///指定的合约
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpSpecificInstrument
    {
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;

        public static byte[] GetData(CtpSpecificInstrument obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.InstrumentID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///合约状态
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpInstrumentStatus
    {
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///合约在交易所的代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ExchangeInstID;
        ///<summary>
        ///结算组代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string SettlementGroupID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///合约交易状态
        ///</summary>
        [DataMember(Order = 5)]
        public byte InstrumentStatus;
        ///<summary>
        ///交易阶段编号
        ///</summary>
        [DataMember(Order = 6)]
        public int TradingSegmentSN;
        ///<summary>
        ///进入本状态时间
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string EnterTime;
        ///<summary>
        ///进入本状态原因
        ///</summary>
        [DataMember(Order = 8)]
        public byte EnterReason;

        public static byte[] GetData(CtpInstrumentStatus obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ExchangeInstID);
                writer.Write(obj.SettlementGroupID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.InstrumentStatus);
                writer.Write(obj.TradingSegmentSN);
                writer.Write(obj.EnterTime);
                writer.Write(obj.EnterReason);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询合约状态
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryInstrumentStatus
    {
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///合约在交易所的代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ExchangeInstID;

        public static byte[] GetData(CtpQryInstrumentStatus obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ExchangeInstID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///投资者账户
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpInvestorAccount
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///投资者帐号
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string AccountID;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;

        public static byte[] GetData(CtpInvestorAccount obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.AccountID);
                writer.Write(obj.CurrencyID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///浮动盈亏算法
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpPositionProfitAlgorithm
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者帐号
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string AccountID;
        ///<summary>
        ///盈亏算法
        ///</summary>
        [DataMember(Order = 3)]
        public byte Algorithm;
        ///<summary>
        ///备注
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 161)]
        public string Memo;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;

        public static byte[] GetData(CtpPositionProfitAlgorithm obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.AccountID);
                writer.Write(obj.Algorithm);
                writer.Write(obj.Memo);
                writer.Write(obj.CurrencyID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///会员资金折扣
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpDiscount
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者范围
        ///</summary>
        [DataMember(Order = 2)]
        public byte InvestorRange;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///资金折扣比例
        ///</summary>
        [DataMember(Order = 4)]
        public double Discount;

        public static byte[] GetData(CtpDiscount obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorRange);
                writer.Write(obj.InvestorID);
                writer.Write(obj.Discount);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询转帐银行
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryTransferBank
    {
        ///<summary>
        ///银行代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分中心代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBrchID;

        public static byte[] GetData(CtpQryTransferBank obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BankID);
                writer.Write(obj.BankBrchID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///转帐银行
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpTransferBank
    {
        ///<summary>
        ///银行代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分中心代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBrchID;
        ///<summary>
        ///银行名称
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
        public string BankName;
        ///<summary>
        ///是否活跃
        ///</summary>
        [DataMember(Order = 4)]
        public int IsActive;

        public static byte[] GetData(CtpTransferBank obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BankID);
                writer.Write(obj.BankBrchID);
                writer.Write(obj.BankName);
                writer.Write(obj.IsActive);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询投资者持仓明细
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryInvestorPositionDetail
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;

        public static byte[] GetData(CtpQryInvestorPositionDetail obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///投资者持仓明细
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpInvestorPositionDetail
    {
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///投机套保标志
        ///</summary>
        [DataMember(Order = 4)]
        public byte HedgeFlag;
        ///<summary>
        ///买卖
        ///</summary>
        [DataMember(Order = 5)]
        public byte Direction;
        ///<summary>
        ///开仓日期
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string OpenDate;
        ///<summary>
        ///成交编号
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TradeID;
        ///<summary>
        ///数量
        ///</summary>
        [DataMember(Order = 8)]
        public int Volume;
        ///<summary>
        ///开仓价
        ///</summary>
        [DataMember(Order = 9)]
        public double OpenPrice;
        ///<summary>
        ///交易日
        ///</summary>
        [DataMember(Order = 10)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///结算编号
        ///</summary>
        [DataMember(Order = 11)]
        public int SettlementID;
        ///<summary>
        ///成交类型
        ///</summary>
        [DataMember(Order = 12)]
        public byte TradeType;
        ///<summary>
        ///组合合约代码
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string CombInstrumentID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///逐日盯市平仓盈亏
        ///</summary>
        [DataMember(Order = 15)]
        public double CloseProfitByDate;
        ///<summary>
        ///逐笔对冲平仓盈亏
        ///</summary>
        [DataMember(Order = 16)]
        public double CloseProfitByTrade;
        ///<summary>
        ///逐日盯市持仓盈亏
        ///</summary>
        [DataMember(Order = 17)]
        public double PositionProfitByDate;
        ///<summary>
        ///逐笔对冲持仓盈亏
        ///</summary>
        [DataMember(Order = 18)]
        public double PositionProfitByTrade;
        ///<summary>
        ///投资者保证金
        ///</summary>
        [DataMember(Order = 19)]
        public double Margin;
        ///<summary>
        ///交易所保证金
        ///</summary>
        [DataMember(Order = 20)]
        public double ExchMargin;
        ///<summary>
        ///保证金率
        ///</summary>
        [DataMember(Order = 21)]
        public double MarginRateByMoney;
        ///<summary>
        ///保证金率(按手数)
        ///</summary>
        [DataMember(Order = 22)]
        public double MarginRateByVolume;
        ///<summary>
        ///昨结算价
        ///</summary>
        [DataMember(Order = 23)]
        public double LastSettlementPrice;
        ///<summary>
        ///结算价
        ///</summary>
        [DataMember(Order = 24)]
        public double SettlementPrice;
        ///<summary>
        ///平仓量
        ///</summary>
        [DataMember(Order = 25)]
        public int CloseVolume;
        ///<summary>
        ///平仓金额
        ///</summary>
        [DataMember(Order = 26)]
        public double CloseAmount;

        public static byte[] GetData(CtpInvestorPositionDetail obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.InstrumentID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.HedgeFlag);
                writer.Write(obj.Direction);
                writer.Write(obj.OpenDate);
                writer.Write(obj.TradeID);
                writer.Write(obj.Volume);
                writer.Write(obj.OpenPrice);
                writer.Write(obj.TradingDay);
                writer.Write(obj.SettlementID);
                writer.Write(obj.TradeType);
                writer.Write(obj.CombInstrumentID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.CloseProfitByDate);
                writer.Write(obj.CloseProfitByTrade);
                writer.Write(obj.PositionProfitByDate);
                writer.Write(obj.PositionProfitByTrade);
                writer.Write(obj.Margin);
                writer.Write(obj.ExchMargin);
                writer.Write(obj.MarginRateByMoney);
                writer.Write(obj.MarginRateByVolume);
                writer.Write(obj.LastSettlementPrice);
                writer.Write(obj.SettlementPrice);
                writer.Write(obj.CloseVolume);
                writer.Write(obj.CloseAmount);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///资金账户口令域
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpTradingAccountPassword
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者帐号
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string AccountID;
        ///<summary>
        ///密码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Password;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;

        public static byte[] GetData(CtpTradingAccountPassword obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.AccountID);
                writer.Write(obj.Password);
                writer.Write(obj.CurrencyID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///交易所行情报盘机
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpMDTraderOffer
    {
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///密码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Password;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 5)]
        public int InstallID;
        ///<summary>
        ///本地报单编号
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string OrderLocalID;
        ///<summary>
        ///交易所交易员连接状态
        ///</summary>
        [DataMember(Order = 7)]
        public byte TraderConnectStatus;
        ///<summary>
        ///发出连接请求的日期
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ConnectRequestDate;
        ///<summary>
        ///发出连接请求的时间
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ConnectRequestTime;
        ///<summary>
        ///上次报告日期
        ///</summary>
        [DataMember(Order = 10)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string LastReportDate;
        ///<summary>
        ///上次报告时间
        ///</summary>
        [DataMember(Order = 11)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string LastReportTime;
        ///<summary>
        ///完成连接日期
        ///</summary>
        [DataMember(Order = 12)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ConnectDate;
        ///<summary>
        ///完成连接时间
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ConnectTime;
        ///<summary>
        ///启动日期
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string StartDate;
        ///<summary>
        ///启动时间
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string StartTime;
        ///<summary>
        ///交易日
        ///</summary>
        [DataMember(Order = 16)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///本席位最大成交编号
        ///</summary>
        [DataMember(Order = 18)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string MaxTradeID;
        ///<summary>
        ///本席位最大报单备拷
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string MaxOrderMessageReference;

        public static byte[] GetData(CtpMDTraderOffer obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ExchangeID);
                writer.Write(obj.TraderID);
                writer.Write(obj.ParticipantID);
                writer.Write(obj.Password);
                writer.Write(obj.InstallID);
                writer.Write(obj.OrderLocalID);
                writer.Write(obj.TraderConnectStatus);
                writer.Write(obj.ConnectRequestDate);
                writer.Write(obj.ConnectRequestTime);
                writer.Write(obj.LastReportDate);
                writer.Write(obj.LastReportTime);
                writer.Write(obj.ConnectDate);
                writer.Write(obj.ConnectTime);
                writer.Write(obj.StartDate);
                writer.Write(obj.StartTime);
                writer.Write(obj.TradingDay);
                writer.Write(obj.BrokerID);
                writer.Write(obj.MaxTradeID);
                writer.Write(obj.MaxOrderMessageReference);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询行情报盘机
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryMDTraderOffer
    {
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;

        public static byte[] GetData(CtpQryMDTraderOffer obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ParticipantID);
                writer.Write(obj.TraderID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询客户通知
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryNotice
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;

        public static byte[] GetData(CtpQryNotice obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///客户通知
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpNotice
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///消息正文
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 501)]
        public string Content;
        ///<summary>
        ///经纪公司通知内容序列号
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
        public string SequenceLabel;

        public static byte[] GetData(CtpNotice obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.Content);
                writer.Write(obj.SequenceLabel);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///用户权限
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpUserRight
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///客户权限类型
        ///</summary>
        [DataMember(Order = 3)]
        public byte UserRightType;
        ///<summary>
        ///是否禁止
        ///</summary>
        [DataMember(Order = 4)]
        public int IsForbidden;

        public static byte[] GetData(CtpUserRight obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.UserID);
                writer.Write(obj.UserRightType);
                writer.Write(obj.IsForbidden);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询结算信息确认域
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQrySettlementInfoConfirm
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;

        public static byte[] GetData(CtpQrySettlementInfoConfirm obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///装载结算信息
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpLoadSettlementInfo
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;

        public static byte[] GetData(CtpLoadSettlementInfo obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///经纪公司可提资金算法表
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpBrokerWithdrawAlgorithm
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///可提资金算法
        ///</summary>
        [DataMember(Order = 2)]
        public byte WithdrawAlgorithm;
        ///<summary>
        ///资金使用率
        ///</summary>
        [DataMember(Order = 3)]
        public double UsingRatio;
        ///<summary>
        ///可提是否包含平仓盈利
        ///</summary>
        [DataMember(Order = 4)]
        public byte IncludeCloseProfit;
        ///<summary>
        ///本日无仓且无成交客户是否受可提比例限制
        ///</summary>
        [DataMember(Order = 5)]
        public byte AllWithoutTrade;
        ///<summary>
        ///可用是否包含平仓盈利
        ///</summary>
        [DataMember(Order = 6)]
        public byte AvailIncludeCloseProfit;
        ///<summary>
        ///是否启用用户事件
        ///</summary>
        [DataMember(Order = 7)]
        public int IsBrokerUserEvent;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;
        ///<summary>
        ///货币质押比率
        ///</summary>
        [DataMember(Order = 9)]
        public double FundMortgageRatio;
        ///<summary>
        ///权益算法
        ///</summary>
        [DataMember(Order = 10)]
        public byte BalanceAlgorithm;

        public static byte[] GetData(CtpBrokerWithdrawAlgorithm obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.WithdrawAlgorithm);
                writer.Write(obj.UsingRatio);
                writer.Write(obj.IncludeCloseProfit);
                writer.Write(obj.AllWithoutTrade);
                writer.Write(obj.AvailIncludeCloseProfit);
                writer.Write(obj.IsBrokerUserEvent);
                writer.Write(obj.CurrencyID);
                writer.Write(obj.FundMortgageRatio);
                writer.Write(obj.BalanceAlgorithm);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///资金账户口令变更域
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpTradingAccountPasswordUpdateV1
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///原来的口令
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string OldPassword;
        ///<summary>
        ///新的口令
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string NewPassword;

        public static byte[] GetData(CtpTradingAccountPasswordUpdateV1 obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.OldPassword);
                writer.Write(obj.NewPassword);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///资金账户口令变更域
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpTradingAccountPasswordUpdate
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者帐号
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string AccountID;
        ///<summary>
        ///原来的口令
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string OldPassword;
        ///<summary>
        ///新的口令
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string NewPassword;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;

        public static byte[] GetData(CtpTradingAccountPasswordUpdate obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.AccountID);
                writer.Write(obj.OldPassword);
                writer.Write(obj.NewPassword);
                writer.Write(obj.CurrencyID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询组合合约分腿
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryCombinationLeg
    {
        ///<summary>
        ///组合合约代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string CombInstrumentID;
        ///<summary>
        ///单腿编号
        ///</summary>
        [DataMember(Order = 2)]
        public int LegID;
        ///<summary>
        ///单腿合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string LegInstrumentID;

        public static byte[] GetData(CtpQryCombinationLeg obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.CombInstrumentID);
                writer.Write(obj.LegID);
                writer.Write(obj.LegInstrumentID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询组合合约分腿
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQrySyncStatus
    {
        ///<summary>
        ///交易日
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;

        public static byte[] GetData(CtpQrySyncStatus obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradingDay);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///组合交易合约的单腿
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpCombinationLeg
    {
        ///<summary>
        ///组合合约代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string CombInstrumentID;
        ///<summary>
        ///单腿编号
        ///</summary>
        [DataMember(Order = 2)]
        public int LegID;
        ///<summary>
        ///单腿合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string LegInstrumentID;
        ///<summary>
        ///买卖方向
        ///</summary>
        [DataMember(Order = 4)]
        public byte Direction;
        ///<summary>
        ///单腿乘数
        ///</summary>
        [DataMember(Order = 5)]
        public int LegMultiple;
        ///<summary>
        ///派生层数
        ///</summary>
        [DataMember(Order = 6)]
        public int ImplyLevel;

        public static byte[] GetData(CtpCombinationLeg obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.CombInstrumentID);
                writer.Write(obj.LegID);
                writer.Write(obj.LegInstrumentID);
                writer.Write(obj.Direction);
                writer.Write(obj.LegMultiple);
                writer.Write(obj.ImplyLevel);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///数据同步状态
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpSyncStatus
    {
        ///<summary>
        ///交易日
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///数据同步状态
        ///</summary>
        [DataMember(Order = 2)]
        public byte DataSyncStatus;

        public static byte[] GetData(CtpSyncStatus obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradingDay);
                writer.Write(obj.DataSyncStatus);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询联系人
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryLinkMan
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;

        public static byte[] GetData(CtpQryLinkMan obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///联系人
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpLinkMan
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///联系人类型
        ///</summary>
        [DataMember(Order = 3)]
        public byte PersonType;
        ///<summary>
        ///证件类型
        ///</summary>
        [DataMember(Order = 4)]
        public byte IdentifiedCardType;
        ///<summary>
        ///证件号码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string IdentifiedCardNo;
        ///<summary>
        ///名称
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string PersonName;
        ///<summary>
        ///联系电话
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Telephone;
        ///<summary>
        ///通讯地址
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
        public string Address;
        ///<summary>
        ///邮政编码
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string ZipCode;
        ///<summary>
        ///优先级
        ///</summary>
        [DataMember(Order = 10)]
        public int Priority;
        ///<summary>
        ///开户邮政编码
        ///</summary>
        [DataMember(Order = 11)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string UOAZipCode;
        ///<summary>
        ///全称
        ///</summary>
        [DataMember(Order = 12)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
        public string PersonFullName;

        public static byte[] GetData(CtpLinkMan obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.PersonType);
                writer.Write(obj.IdentifiedCardType);
                writer.Write(obj.IdentifiedCardNo);
                writer.Write(obj.PersonName);
                writer.Write(obj.Telephone);
                writer.Write(obj.Address);
                writer.Write(obj.ZipCode);
                writer.Write(obj.Priority);
                writer.Write(obj.UOAZipCode);
                writer.Write(obj.PersonFullName);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询经纪公司用户事件
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryBrokerUserEvent
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///用户事件类型
        ///</summary>
        [DataMember(Order = 3)]
        public byte UserEventType;

        public static byte[] GetData(CtpQryBrokerUserEvent obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.UserID);
                writer.Write(obj.UserEventType);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询经纪公司用户事件
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpBrokerUserEvent
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///用户事件类型
        ///</summary>
        [DataMember(Order = 3)]
        public byte UserEventType;
        ///<summary>
        ///用户事件序号
        ///</summary>
        [DataMember(Order = 4)]
        public int EventSequenceNo;
        ///<summary>
        ///事件发生日期
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string EventDate;
        ///<summary>
        ///事件发生时间
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string EventTime;
        ///<summary>
        ///用户事件信息
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1025)]
        public string UserEventInfo;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;

        public static byte[] GetData(CtpBrokerUserEvent obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.UserID);
                writer.Write(obj.UserEventType);
                writer.Write(obj.EventSequenceNo);
                writer.Write(obj.EventDate);
                writer.Write(obj.EventTime);
                writer.Write(obj.UserEventInfo);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询签约银行请求
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryContractBank
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///银行代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分中心代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBrchID;

        public static byte[] GetData(CtpQryContractBank obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.BankID);
                writer.Write(obj.BankBrchID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询签约银行响应
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpContractBank
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///银行代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分中心代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBrchID;
        ///<summary>
        ///银行名称
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
        public string BankName;

        public static byte[] GetData(CtpContractBank obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.BankID);
                writer.Write(obj.BankBrchID);
                writer.Write(obj.BankName);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///投资者组合持仓明细
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpInvestorPositionCombineDetail
    {
        ///<summary>
        ///交易日
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///开仓日期
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string OpenDate;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///结算编号
        ///</summary>
        [DataMember(Order = 4)]
        public int SettlementID;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///组合编号
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ComTradeID;
        ///<summary>
        ///撮合编号
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TradeID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///投机套保标志
        ///</summary>
        [DataMember(Order = 10)]
        public byte HedgeFlag;
        ///<summary>
        ///买卖
        ///</summary>
        [DataMember(Order = 11)]
        public byte Direction;
        ///<summary>
        ///持仓量
        ///</summary>
        [DataMember(Order = 12)]
        public int TotalAmt;
        ///<summary>
        ///投资者保证金
        ///</summary>
        [DataMember(Order = 13)]
        public double Margin;
        ///<summary>
        ///交易所保证金
        ///</summary>
        [DataMember(Order = 14)]
        public double ExchMargin;
        ///<summary>
        ///保证金率
        ///</summary>
        [DataMember(Order = 15)]
        public double MarginRateByMoney;
        ///<summary>
        ///保证金率(按手数)
        ///</summary>
        [DataMember(Order = 16)]
        public double MarginRateByVolume;
        ///<summary>
        ///单腿编号
        ///</summary>
        [DataMember(Order = 17)]
        public int LegID;
        ///<summary>
        ///单腿乘数
        ///</summary>
        [DataMember(Order = 18)]
        public int LegMultiple;
        ///<summary>
        ///组合持仓合约编码
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string CombInstrumentID;
        ///<summary>
        ///成交组号
        ///</summary>
        [DataMember(Order = 20)]
        public int TradeGroupID;

        public static byte[] GetData(CtpInvestorPositionCombineDetail obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradingDay);
                writer.Write(obj.OpenDate);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.SettlementID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.ComTradeID);
                writer.Write(obj.TradeID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.HedgeFlag);
                writer.Write(obj.Direction);
                writer.Write(obj.TotalAmt);
                writer.Write(obj.Margin);
                writer.Write(obj.ExchMargin);
                writer.Write(obj.MarginRateByMoney);
                writer.Write(obj.MarginRateByVolume);
                writer.Write(obj.LegID);
                writer.Write(obj.LegMultiple);
                writer.Write(obj.CombInstrumentID);
                writer.Write(obj.TradeGroupID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///预埋单
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpParkedOrder
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///报单引用
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string OrderRef;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///报单价格条件
        ///</summary>
        [DataMember(Order = 6)]
        public byte OrderPriceType;
        ///<summary>
        ///买卖方向
        ///</summary>
        [DataMember(Order = 7)]
        public byte Direction;
        ///<summary>
        ///组合开平标志
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string CombOffsetFlag;
        ///<summary>
        ///组合投机套保标志
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string CombHedgeFlag;
        ///<summary>
        ///价格
        ///</summary>
        [DataMember(Order = 10)]
        public double LimitPrice;
        ///<summary>
        ///数量
        ///</summary>
        [DataMember(Order = 11)]
        public int VolumeTotalOriginal;
        ///<summary>
        ///有效期类型
        ///</summary>
        [DataMember(Order = 12)]
        public byte TimeCondition;
        ///<summary>
        ///GTD日期
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string GTDDate;
        ///<summary>
        ///成交量类型
        ///</summary>
        [DataMember(Order = 14)]
        public byte VolumeCondition;
        ///<summary>
        ///最小成交量
        ///</summary>
        [DataMember(Order = 15)]
        public int MinVolume;
        ///<summary>
        ///触发条件
        ///</summary>
        [DataMember(Order = 16)]
        public byte ContingentCondition;
        ///<summary>
        ///止损价
        ///</summary>
        [DataMember(Order = 17)]
        public double StopPrice;
        ///<summary>
        ///强平原因
        ///</summary>
        [DataMember(Order = 18)]
        public byte ForceCloseReason;
        ///<summary>
        ///自动挂起标志
        ///</summary>
        [DataMember(Order = 19)]
        public int IsAutoSuspend;
        ///<summary>
        ///业务单元
        ///</summary>
        [DataMember(Order = 20)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string BusinessUnit;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 21)]
        public int RequestID;
        ///<summary>
        ///用户强评标志
        ///</summary>
        [DataMember(Order = 22)]
        public int UserForceClose;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 23)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///预埋报单编号
        ///</summary>
        [DataMember(Order = 24)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string ParkedOrderID;
        ///<summary>
        ///用户类型
        ///</summary>
        [DataMember(Order = 25)]
        public byte UserType;
        ///<summary>
        ///预埋单状态
        ///</summary>
        [DataMember(Order = 26)]
        public byte Status;
        ///<summary>
        ///错误代码
        ///</summary>
        [DataMember(Order = 27)]
        public int ErrorID;
        ///<summary>
        ///错误信息
        ///</summary>
        [DataMember(Order = 28)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string ErrorMsg;
        ///<summary>
        ///互换单标志
        ///</summary>
        [DataMember(Order = 29)]
        public int IsSwapOrder;

        public static byte[] GetData(CtpParkedOrder obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.OrderRef);
                writer.Write(obj.UserID);
                writer.Write(obj.OrderPriceType);
                writer.Write(obj.Direction);
                writer.Write(obj.CombOffsetFlag);
                writer.Write(obj.CombHedgeFlag);
                writer.Write(obj.LimitPrice);
                writer.Write(obj.VolumeTotalOriginal);
                writer.Write(obj.TimeCondition);
                writer.Write(obj.GTDDate);
                writer.Write(obj.VolumeCondition);
                writer.Write(obj.MinVolume);
                writer.Write(obj.ContingentCondition);
                writer.Write(obj.StopPrice);
                writer.Write(obj.ForceCloseReason);
                writer.Write(obj.IsAutoSuspend);
                writer.Write(obj.BusinessUnit);
                writer.Write(obj.RequestID);
                writer.Write(obj.UserForceClose);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ParkedOrderID);
                writer.Write(obj.UserType);
                writer.Write(obj.Status);
                writer.Write(obj.ErrorID);
                writer.Write(obj.ErrorMsg);
                writer.Write(obj.IsSwapOrder);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///输入预埋单操作
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpParkedOrderAction
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///报单操作引用
        ///</summary>
        [DataMember(Order = 3)]
        public int OrderActionRef;
        ///<summary>
        ///报单引用
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string OrderRef;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 5)]
        public int RequestID;
        ///<summary>
        ///前置编号
        ///</summary>
        [DataMember(Order = 6)]
        public int FrontID;
        ///<summary>
        ///会话编号
        ///</summary>
        [DataMember(Order = 7)]
        public int SessionID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///报单编号
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string OrderSysID;
        ///<summary>
        ///操作标志
        ///</summary>
        [DataMember(Order = 10)]
        public byte ActionFlag;
        ///<summary>
        ///价格
        ///</summary>
        [DataMember(Order = 11)]
        public double LimitPrice;
        ///<summary>
        ///数量变化
        ///</summary>
        [DataMember(Order = 12)]
        public int VolumeChange;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///预埋撤单单编号
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string ParkedOrderActionID;
        ///<summary>
        ///用户类型
        ///</summary>
        [DataMember(Order = 16)]
        public byte UserType;
        ///<summary>
        ///预埋撤单状态
        ///</summary>
        [DataMember(Order = 17)]
        public byte Status;
        ///<summary>
        ///错误代码
        ///</summary>
        [DataMember(Order = 18)]
        public int ErrorID;
        ///<summary>
        ///错误信息
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string ErrorMsg;

        public static byte[] GetData(CtpParkedOrderAction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.OrderActionRef);
                writer.Write(obj.OrderRef);
                writer.Write(obj.RequestID);
                writer.Write(obj.FrontID);
                writer.Write(obj.SessionID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.OrderSysID);
                writer.Write(obj.ActionFlag);
                writer.Write(obj.LimitPrice);
                writer.Write(obj.VolumeChange);
                writer.Write(obj.UserID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.ParkedOrderActionID);
                writer.Write(obj.UserType);
                writer.Write(obj.Status);
                writer.Write(obj.ErrorID);
                writer.Write(obj.ErrorMsg);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询预埋单
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryParkedOrder
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;

        public static byte[] GetData(CtpQryParkedOrder obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.ExchangeID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询预埋撤单
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryParkedOrderAction
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;

        public static byte[] GetData(CtpQryParkedOrderAction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.ExchangeID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///删除预埋单
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpRemoveParkedOrder
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///预埋报单编号
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string ParkedOrderID;

        public static byte[] GetData(CtpRemoveParkedOrder obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.ParkedOrderID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///删除预埋撤单
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpRemoveParkedOrderAction
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///预埋撤单编号
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string ParkedOrderActionID;

        public static byte[] GetData(CtpRemoveParkedOrderAction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.ParkedOrderActionID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///经纪公司可提资金算法表
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpInvestorWithdrawAlgorithm
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者范围
        ///</summary>
        [DataMember(Order = 2)]
        public byte InvestorRange;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///可提资金比例
        ///</summary>
        [DataMember(Order = 4)]
        public double UsingRatio;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;
        ///<summary>
        ///货币质押比率
        ///</summary>
        [DataMember(Order = 6)]
        public double FundMortgageRatio;

        public static byte[] GetData(CtpInvestorWithdrawAlgorithm obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorRange);
                writer.Write(obj.InvestorID);
                writer.Write(obj.UsingRatio);
                writer.Write(obj.CurrencyID);
                writer.Write(obj.FundMortgageRatio);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询组合持仓明细
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryInvestorPositionCombineDetail
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///组合持仓合约编码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string CombInstrumentID;

        public static byte[] GetData(CtpQryInvestorPositionCombineDetail obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.CombInstrumentID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///成交均价
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpMarketDataAveragePrice
    {
        ///<summary>
        ///当日均价
        ///</summary>
        [DataMember(Order = 1)]
        public double AveragePrice;

        public static byte[] GetData(CtpMarketDataAveragePrice obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.AveragePrice);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///校验投资者密码
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpVerifyInvestorPassword
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///密码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Password;

        public static byte[] GetData(CtpVerifyInvestorPassword obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.Password);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///用户IP
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpUserIP
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///IP地址
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string IPAddress;
        ///<summary>
        ///IP地址掩码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string IPMask;
        ///<summary>
        ///Mac地址
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string MacAddress;

        public static byte[] GetData(CtpUserIP obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.UserID);
                writer.Write(obj.IPAddress);
                writer.Write(obj.IPMask);
                writer.Write(obj.MacAddress);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///用户事件通知信息
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpTradingNoticeInfo
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///发送时间
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string SendTime;
        ///<summary>
        ///消息正文
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 501)]
        public string FieldContent;
        ///<summary>
        ///序列系列号
        ///</summary>
        [DataMember(Order = 5)]
        public short SequenceSeries;
        ///<summary>
        ///序列号
        ///</summary>
        [DataMember(Order = 6)]
        public int SequenceNo;

        public static byte[] GetData(CtpTradingNoticeInfo obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.SendTime);
                writer.Write(obj.FieldContent);
                writer.Write(obj.SequenceSeries);
                writer.Write(obj.SequenceNo);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///用户事件通知
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpTradingNotice
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者范围
        ///</summary>
        [DataMember(Order = 2)]
        public byte InvestorRange;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///序列系列号
        ///</summary>
        [DataMember(Order = 4)]
        public short SequenceSeries;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///发送时间
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string SendTime;
        ///<summary>
        ///序列号
        ///</summary>
        [DataMember(Order = 7)]
        public int SequenceNo;
        ///<summary>
        ///消息正文
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 501)]
        public string FieldContent;

        public static byte[] GetData(CtpTradingNotice obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorRange);
                writer.Write(obj.InvestorID);
                writer.Write(obj.SequenceSeries);
                writer.Write(obj.UserID);
                writer.Write(obj.SendTime);
                writer.Write(obj.SequenceNo);
                writer.Write(obj.FieldContent);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询交易事件通知
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryTradingNotice
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;

        public static byte[] GetData(CtpQryTradingNotice obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询错误报单
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryErrOrder
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;

        public static byte[] GetData(CtpQryErrOrder obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///错误报单
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpErrOrder
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///报单引用
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string OrderRef;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///报单价格条件
        ///</summary>
        [DataMember(Order = 6)]
        public byte OrderPriceType;
        ///<summary>
        ///买卖方向
        ///</summary>
        [DataMember(Order = 7)]
        public byte Direction;
        ///<summary>
        ///组合开平标志
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string CombOffsetFlag;
        ///<summary>
        ///组合投机套保标志
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string CombHedgeFlag;
        ///<summary>
        ///价格
        ///</summary>
        [DataMember(Order = 10)]
        public double LimitPrice;
        ///<summary>
        ///数量
        ///</summary>
        [DataMember(Order = 11)]
        public int VolumeTotalOriginal;
        ///<summary>
        ///有效期类型
        ///</summary>
        [DataMember(Order = 12)]
        public byte TimeCondition;
        ///<summary>
        ///GTD日期
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string GTDDate;
        ///<summary>
        ///成交量类型
        ///</summary>
        [DataMember(Order = 14)]
        public byte VolumeCondition;
        ///<summary>
        ///最小成交量
        ///</summary>
        [DataMember(Order = 15)]
        public int MinVolume;
        ///<summary>
        ///触发条件
        ///</summary>
        [DataMember(Order = 16)]
        public byte ContingentCondition;
        ///<summary>
        ///止损价
        ///</summary>
        [DataMember(Order = 17)]
        public double StopPrice;
        ///<summary>
        ///强平原因
        ///</summary>
        [DataMember(Order = 18)]
        public byte ForceCloseReason;
        ///<summary>
        ///自动挂起标志
        ///</summary>
        [DataMember(Order = 19)]
        public int IsAutoSuspend;
        ///<summary>
        ///业务单元
        ///</summary>
        [DataMember(Order = 20)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string BusinessUnit;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 21)]
        public int RequestID;
        ///<summary>
        ///用户强评标志
        ///</summary>
        [DataMember(Order = 22)]
        public int UserForceClose;
        ///<summary>
        ///错误代码
        ///</summary>
        [DataMember(Order = 23)]
        public int ErrorID;
        ///<summary>
        ///错误信息
        ///</summary>
        [DataMember(Order = 24)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string ErrorMsg;
        ///<summary>
        ///互换单标志
        ///</summary>
        [DataMember(Order = 25)]
        public int IsSwapOrder;

        public static byte[] GetData(CtpErrOrder obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.OrderRef);
                writer.Write(obj.UserID);
                writer.Write(obj.OrderPriceType);
                writer.Write(obj.Direction);
                writer.Write(obj.CombOffsetFlag);
                writer.Write(obj.CombHedgeFlag);
                writer.Write(obj.LimitPrice);
                writer.Write(obj.VolumeTotalOriginal);
                writer.Write(obj.TimeCondition);
                writer.Write(obj.GTDDate);
                writer.Write(obj.VolumeCondition);
                writer.Write(obj.MinVolume);
                writer.Write(obj.ContingentCondition);
                writer.Write(obj.StopPrice);
                writer.Write(obj.ForceCloseReason);
                writer.Write(obj.IsAutoSuspend);
                writer.Write(obj.BusinessUnit);
                writer.Write(obj.RequestID);
                writer.Write(obj.UserForceClose);
                writer.Write(obj.ErrorID);
                writer.Write(obj.ErrorMsg);
                writer.Write(obj.IsSwapOrder);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询错误报单操作
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpErrorConditionalOrder
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///报单引用
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string OrderRef;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///报单价格条件
        ///</summary>
        [DataMember(Order = 6)]
        public byte OrderPriceType;
        ///<summary>
        ///买卖方向
        ///</summary>
        [DataMember(Order = 7)]
        public byte Direction;
        ///<summary>
        ///组合开平标志
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string CombOffsetFlag;
        ///<summary>
        ///组合投机套保标志
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string CombHedgeFlag;
        ///<summary>
        ///价格
        ///</summary>
        [DataMember(Order = 10)]
        public double LimitPrice;
        ///<summary>
        ///数量
        ///</summary>
        [DataMember(Order = 11)]
        public int VolumeTotalOriginal;
        ///<summary>
        ///有效期类型
        ///</summary>
        [DataMember(Order = 12)]
        public byte TimeCondition;
        ///<summary>
        ///GTD日期
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string GTDDate;
        ///<summary>
        ///成交量类型
        ///</summary>
        [DataMember(Order = 14)]
        public byte VolumeCondition;
        ///<summary>
        ///最小成交量
        ///</summary>
        [DataMember(Order = 15)]
        public int MinVolume;
        ///<summary>
        ///触发条件
        ///</summary>
        [DataMember(Order = 16)]
        public byte ContingentCondition;
        ///<summary>
        ///止损价
        ///</summary>
        [DataMember(Order = 17)]
        public double StopPrice;
        ///<summary>
        ///强平原因
        ///</summary>
        [DataMember(Order = 18)]
        public byte ForceCloseReason;
        ///<summary>
        ///自动挂起标志
        ///</summary>
        [DataMember(Order = 19)]
        public int IsAutoSuspend;
        ///<summary>
        ///业务单元
        ///</summary>
        [DataMember(Order = 20)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string BusinessUnit;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 21)]
        public int RequestID;
        ///<summary>
        ///本地报单编号
        ///</summary>
        [DataMember(Order = 22)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string OrderLocalID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 23)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 24)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///客户代码
        ///</summary>
        [DataMember(Order = 25)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClientID;
        ///<summary>
        ///合约在交易所的代码
        ///</summary>
        [DataMember(Order = 26)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ExchangeInstID;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 27)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 28)]
        public int InstallID;
        ///<summary>
        ///报单提交状态
        ///</summary>
        [DataMember(Order = 29)]
        public byte OrderSubmitStatus;
        ///<summary>
        ///报单提示序号
        ///</summary>
        [DataMember(Order = 30)]
        public int NotifySequence;
        ///<summary>
        ///交易日
        ///</summary>
        [DataMember(Order = 31)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///结算编号
        ///</summary>
        [DataMember(Order = 32)]
        public int SettlementID;
        ///<summary>
        ///报单编号
        ///</summary>
        [DataMember(Order = 33)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string OrderSysID;
        ///<summary>
        ///报单来源
        ///</summary>
        [DataMember(Order = 34)]
        public byte OrderSource;
        ///<summary>
        ///报单状态
        ///</summary>
        [DataMember(Order = 35)]
        public byte OrderStatus;
        ///<summary>
        ///报单类型
        ///</summary>
        [DataMember(Order = 36)]
        public byte OrderType;
        ///<summary>
        ///今成交数量
        ///</summary>
        [DataMember(Order = 37)]
        public int VolumeTraded;
        ///<summary>
        ///剩余数量
        ///</summary>
        [DataMember(Order = 38)]
        public int VolumeTotal;
        ///<summary>
        ///报单日期
        ///</summary>
        [DataMember(Order = 39)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string InsertDate;
        ///<summary>
        ///委托时间
        ///</summary>
        [DataMember(Order = 40)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string InsertTime;
        ///<summary>
        ///激活时间
        ///</summary>
        [DataMember(Order = 41)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ActiveTime;
        ///<summary>
        ///挂起时间
        ///</summary>
        [DataMember(Order = 42)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string SuspendTime;
        ///<summary>
        ///最后修改时间
        ///</summary>
        [DataMember(Order = 43)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string UpdateTime;
        ///<summary>
        ///撤销时间
        ///</summary>
        [DataMember(Order = 44)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string CancelTime;
        ///<summary>
        ///最后修改交易所交易员代码
        ///</summary>
        [DataMember(Order = 45)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string ActiveTraderID;
        ///<summary>
        ///结算会员编号
        ///</summary>
        [DataMember(Order = 46)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClearingPartID;
        ///<summary>
        ///序号
        ///</summary>
        [DataMember(Order = 47)]
        public int SequenceNo;
        ///<summary>
        ///前置编号
        ///</summary>
        [DataMember(Order = 48)]
        public int FrontID;
        ///<summary>
        ///会话编号
        ///</summary>
        [DataMember(Order = 49)]
        public int SessionID;
        ///<summary>
        ///用户端产品信息
        ///</summary>
        [DataMember(Order = 50)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string UserProductInfo;
        ///<summary>
        ///状态信息
        ///</summary>
        [DataMember(Order = 51)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string StatusMsg;
        ///<summary>
        ///用户强评标志
        ///</summary>
        [DataMember(Order = 52)]
        public int UserForceClose;
        ///<summary>
        ///操作用户代码
        ///</summary>
        [DataMember(Order = 53)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string ActiveUserID;
        ///<summary>
        ///经纪公司报单编号
        ///</summary>
        [DataMember(Order = 54)]
        public int BrokerOrderSeq;
        ///<summary>
        ///相关报单
        ///</summary>
        [DataMember(Order = 55)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string RelativeOrderSysID;
        ///<summary>
        ///郑商所成交数量
        ///</summary>
        [DataMember(Order = 56)]
        public int ZCETotalTradedVolume;
        ///<summary>
        ///错误代码
        ///</summary>
        [DataMember(Order = 57)]
        public int ErrorID;
        ///<summary>
        ///错误信息
        ///</summary>
        [DataMember(Order = 58)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string ErrorMsg;
        ///<summary>
        ///互换单标志
        ///</summary>
        [DataMember(Order = 59)]
        public int IsSwapOrder;

        public static byte[] GetData(CtpErrorConditionalOrder obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.OrderRef);
                writer.Write(obj.UserID);
                writer.Write(obj.OrderPriceType);
                writer.Write(obj.Direction);
                writer.Write(obj.CombOffsetFlag);
                writer.Write(obj.CombHedgeFlag);
                writer.Write(obj.LimitPrice);
                writer.Write(obj.VolumeTotalOriginal);
                writer.Write(obj.TimeCondition);
                writer.Write(obj.GTDDate);
                writer.Write(obj.VolumeCondition);
                writer.Write(obj.MinVolume);
                writer.Write(obj.ContingentCondition);
                writer.Write(obj.StopPrice);
                writer.Write(obj.ForceCloseReason);
                writer.Write(obj.IsAutoSuspend);
                writer.Write(obj.BusinessUnit);
                writer.Write(obj.RequestID);
                writer.Write(obj.OrderLocalID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ParticipantID);
                writer.Write(obj.ClientID);
                writer.Write(obj.ExchangeInstID);
                writer.Write(obj.TraderID);
                writer.Write(obj.InstallID);
                writer.Write(obj.OrderSubmitStatus);
                writer.Write(obj.NotifySequence);
                writer.Write(obj.TradingDay);
                writer.Write(obj.SettlementID);
                writer.Write(obj.OrderSysID);
                writer.Write(obj.OrderSource);
                writer.Write(obj.OrderStatus);
                writer.Write(obj.OrderType);
                writer.Write(obj.VolumeTraded);
                writer.Write(obj.VolumeTotal);
                writer.Write(obj.InsertDate);
                writer.Write(obj.InsertTime);
                writer.Write(obj.ActiveTime);
                writer.Write(obj.SuspendTime);
                writer.Write(obj.UpdateTime);
                writer.Write(obj.CancelTime);
                writer.Write(obj.ActiveTraderID);
                writer.Write(obj.ClearingPartID);
                writer.Write(obj.SequenceNo);
                writer.Write(obj.FrontID);
                writer.Write(obj.SessionID);
                writer.Write(obj.UserProductInfo);
                writer.Write(obj.StatusMsg);
                writer.Write(obj.UserForceClose);
                writer.Write(obj.ActiveUserID);
                writer.Write(obj.BrokerOrderSeq);
                writer.Write(obj.RelativeOrderSysID);
                writer.Write(obj.ZCETotalTradedVolume);
                writer.Write(obj.ErrorID);
                writer.Write(obj.ErrorMsg);
                writer.Write(obj.IsSwapOrder);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询错误报单操作
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryErrOrderAction
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;

        public static byte[] GetData(CtpQryErrOrderAction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///错误报单操作
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpErrOrderAction
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///报单操作引用
        ///</summary>
        [DataMember(Order = 3)]
        public int OrderActionRef;
        ///<summary>
        ///报单引用
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string OrderRef;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 5)]
        public int RequestID;
        ///<summary>
        ///前置编号
        ///</summary>
        [DataMember(Order = 6)]
        public int FrontID;
        ///<summary>
        ///会话编号
        ///</summary>
        [DataMember(Order = 7)]
        public int SessionID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///报单编号
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string OrderSysID;
        ///<summary>
        ///操作标志
        ///</summary>
        [DataMember(Order = 10)]
        public byte ActionFlag;
        ///<summary>
        ///价格
        ///</summary>
        [DataMember(Order = 11)]
        public double LimitPrice;
        ///<summary>
        ///数量变化
        ///</summary>
        [DataMember(Order = 12)]
        public int VolumeChange;
        ///<summary>
        ///操作日期
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ActionDate;
        ///<summary>
        ///操作时间
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ActionTime;
        ///<summary>
        ///交易所交易员代码
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string TraderID;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 16)]
        public int InstallID;
        ///<summary>
        ///本地报单编号
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string OrderLocalID;
        ///<summary>
        ///操作本地编号
        ///</summary>
        [DataMember(Order = 18)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string ActionLocalID;
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///客户代码
        ///</summary>
        [DataMember(Order = 20)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClientID;
        ///<summary>
        ///业务单元
        ///</summary>
        [DataMember(Order = 21)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string BusinessUnit;
        ///<summary>
        ///报单操作状态
        ///</summary>
        [DataMember(Order = 22)]
        public byte OrderActionStatus;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 23)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///状态信息
        ///</summary>
        [DataMember(Order = 24)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string StatusMsg;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 25)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///错误代码
        ///</summary>
        [DataMember(Order = 26)]
        public int ErrorID;
        ///<summary>
        ///错误信息
        ///</summary>
        [DataMember(Order = 27)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string ErrorMsg;

        public static byte[] GetData(CtpErrOrderAction obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.OrderActionRef);
                writer.Write(obj.OrderRef);
                writer.Write(obj.RequestID);
                writer.Write(obj.FrontID);
                writer.Write(obj.SessionID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.OrderSysID);
                writer.Write(obj.ActionFlag);
                writer.Write(obj.LimitPrice);
                writer.Write(obj.VolumeChange);
                writer.Write(obj.ActionDate);
                writer.Write(obj.ActionTime);
                writer.Write(obj.TraderID);
                writer.Write(obj.InstallID);
                writer.Write(obj.OrderLocalID);
                writer.Write(obj.ActionLocalID);
                writer.Write(obj.ParticipantID);
                writer.Write(obj.ClientID);
                writer.Write(obj.BusinessUnit);
                writer.Write(obj.OrderActionStatus);
                writer.Write(obj.UserID);
                writer.Write(obj.StatusMsg);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.ErrorID);
                writer.Write(obj.ErrorMsg);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询交易所状态
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryExchangeSequence
    {
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;

        public static byte[] GetData(CtpQryExchangeSequence obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ExchangeID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///交易所状态
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpExchangeSequence
    {
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///序号
        ///</summary>
        [DataMember(Order = 2)]
        public int SequenceNo;
        ///<summary>
        ///合约交易状态
        ///</summary>
        [DataMember(Order = 3)]
        public byte MarketStatus;

        public static byte[] GetData(CtpExchangeSequence obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ExchangeID);
                writer.Write(obj.SequenceNo);
                writer.Write(obj.MarketStatus);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///根据价格查询最大报单数量
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQueryMaxOrderVolumeWithPrice
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///买卖方向
        ///</summary>
        [DataMember(Order = 4)]
        public byte Direction;
        ///<summary>
        ///开平标志
        ///</summary>
        [DataMember(Order = 5)]
        public byte OffsetFlag;
        ///<summary>
        ///投机套保标志
        ///</summary>
        [DataMember(Order = 6)]
        public byte HedgeFlag;
        ///<summary>
        ///最大允许报单数量
        ///</summary>
        [DataMember(Order = 7)]
        public int MaxVolume;
        ///<summary>
        ///报单价格
        ///</summary>
        [DataMember(Order = 8)]
        public double Price;

        public static byte[] GetData(CtpQueryMaxOrderVolumeWithPrice obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.Direction);
                writer.Write(obj.OffsetFlag);
                writer.Write(obj.HedgeFlag);
                writer.Write(obj.MaxVolume);
                writer.Write(obj.Price);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询经纪公司交易参数
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryBrokerTradingParams
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;

        public static byte[] GetData(CtpQryBrokerTradingParams obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.CurrencyID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///经纪公司交易参数
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpBrokerTradingParams
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///保证金价格类型
        ///</summary>
        [DataMember(Order = 3)]
        public byte MarginPriceType;
        ///<summary>
        ///盈亏算法
        ///</summary>
        [DataMember(Order = 4)]
        public byte Algorithm;
        ///<summary>
        ///可用是否包含平仓盈利
        ///</summary>
        [DataMember(Order = 5)]
        public byte AvailIncludeCloseProfit;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;
        ///<summary>
        ///期权权利金价格类型
        ///</summary>
        [DataMember(Order = 7)]
        public byte OptionRoyaltyPriceType;

        public static byte[] GetData(CtpBrokerTradingParams obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.MarginPriceType);
                writer.Write(obj.Algorithm);
                writer.Write(obj.AvailIncludeCloseProfit);
                writer.Write(obj.CurrencyID);
                writer.Write(obj.OptionRoyaltyPriceType);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询经纪公司交易算法
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryBrokerTradingAlgos
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;

        public static byte[] GetData(CtpQryBrokerTradingAlgos obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.InstrumentID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///经纪公司交易算法
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpBrokerTradingAlgos
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///持仓处理算法编号
        ///</summary>
        [DataMember(Order = 4)]
        public byte HandlePositionAlgoID;
        ///<summary>
        ///寻找保证金率算法编号
        ///</summary>
        [DataMember(Order = 5)]
        public byte FindMarginRateAlgoID;
        ///<summary>
        ///资金处理算法编号
        ///</summary>
        [DataMember(Order = 6)]
        public byte HandleTradingAccountAlgoID;

        public static byte[] GetData(CtpBrokerTradingAlgos obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.HandlePositionAlgoID);
                writer.Write(obj.FindMarginRateAlgoID);
                writer.Write(obj.HandleTradingAccountAlgoID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询经纪公司资金
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQueryBrokerDeposit
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;

        public static byte[] GetData(CtpQueryBrokerDeposit obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.ExchangeID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///经纪公司资金
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpBrokerDeposit
    {
        ///<summary>
        ///交易日期
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///会员代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///上次结算准备金
        ///</summary>
        [DataMember(Order = 5)]
        public double PreBalance;
        ///<summary>
        ///当前保证金总额
        ///</summary>
        [DataMember(Order = 6)]
        public double CurrMargin;
        ///<summary>
        ///平仓盈亏
        ///</summary>
        [DataMember(Order = 7)]
        public double CloseProfit;
        ///<summary>
        ///期货结算准备金
        ///</summary>
        [DataMember(Order = 8)]
        public double Balance;
        ///<summary>
        ///入金金额
        ///</summary>
        [DataMember(Order = 9)]
        public double Deposit;
        ///<summary>
        ///出金金额
        ///</summary>
        [DataMember(Order = 10)]
        public double Withdraw;
        ///<summary>
        ///可提资金
        ///</summary>
        [DataMember(Order = 11)]
        public double Available;
        ///<summary>
        ///基本准备金
        ///</summary>
        [DataMember(Order = 12)]
        public double Reserve;
        ///<summary>
        ///冻结的保证金
        ///</summary>
        [DataMember(Order = 13)]
        public double FrozenMargin;

        public static byte[] GetData(CtpBrokerDeposit obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradingDay);
                writer.Write(obj.BrokerID);
                writer.Write(obj.ParticipantID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.PreBalance);
                writer.Write(obj.CurrMargin);
                writer.Write(obj.CloseProfit);
                writer.Write(obj.Balance);
                writer.Write(obj.Deposit);
                writer.Write(obj.Withdraw);
                writer.Write(obj.Available);
                writer.Write(obj.Reserve);
                writer.Write(obj.FrozenMargin);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询保证金监管系统经纪公司密钥
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryCFMMCBrokerKey
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;

        public static byte[] GetData(CtpQryCFMMCBrokerKey obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///保证金监管系统经纪公司密钥
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpCFMMCBrokerKey
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///经纪公司统一编码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///密钥生成日期
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string CreateDate;
        ///<summary>
        ///密钥生成时间
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string CreateTime;
        ///<summary>
        ///密钥编号
        ///</summary>
        [DataMember(Order = 5)]
        public int KeyID;
        ///<summary>
        ///动态密钥
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string CurrentKey;
        ///<summary>
        ///动态密钥类型
        ///</summary>
        [DataMember(Order = 7)]
        public byte KeyKind;

        public static byte[] GetData(CtpCFMMCBrokerKey obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.ParticipantID);
                writer.Write(obj.CreateDate);
                writer.Write(obj.CreateTime);
                writer.Write(obj.KeyID);
                writer.Write(obj.CurrentKey);
                writer.Write(obj.KeyKind);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///保证金监管系统经纪公司资金账户密钥
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpCFMMCTradingAccountKey
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///经纪公司统一编码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///投资者帐号
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string AccountID;
        ///<summary>
        ///密钥编号
        ///</summary>
        [DataMember(Order = 4)]
        public int KeyID;
        ///<summary>
        ///动态密钥
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string CurrentKey;

        public static byte[] GetData(CtpCFMMCTradingAccountKey obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.ParticipantID);
                writer.Write(obj.AccountID);
                writer.Write(obj.KeyID);
                writer.Write(obj.CurrentKey);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///请求查询保证金监管系统经纪公司资金账户密钥
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryCFMMCTradingAccountKey
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;

        public static byte[] GetData(CtpQryCFMMCTradingAccountKey obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///用户动态令牌参数
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpBrokerUserOTPParam
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///动态令牌提供商
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
        public string OTPVendorsID;
        ///<summary>
        ///动态令牌序列号
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string SerialNumber;
        ///<summary>
        ///令牌密钥
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string AuthKey;
        ///<summary>
        ///漂移值
        ///</summary>
        [DataMember(Order = 6)]
        public int LastDrift;
        ///<summary>
        ///成功值
        ///</summary>
        [DataMember(Order = 7)]
        public int LastSuccess;
        ///<summary>
        ///动态令牌类型
        ///</summary>
        [DataMember(Order = 8)]
        public byte OTPType;

        public static byte[] GetData(CtpBrokerUserOTPParam obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.UserID);
                writer.Write(obj.OTPVendorsID);
                writer.Write(obj.SerialNumber);
                writer.Write(obj.AuthKey);
                writer.Write(obj.LastDrift);
                writer.Write(obj.LastSuccess);
                writer.Write(obj.OTPType);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///手工同步用户动态令牌
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpManualSyncBrokerUserOTP
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///动态令牌类型
        ///</summary>
        [DataMember(Order = 3)]
        public byte OTPType;
        ///<summary>
        ///第一个动态密码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string FirstOTP;
        ///<summary>
        ///第二个动态密码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string SecondOTP;

        public static byte[] GetData(CtpManualSyncBrokerUserOTP obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.UserID);
                writer.Write(obj.OTPType);
                writer.Write(obj.FirstOTP);
                writer.Write(obj.SecondOTP);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///投资者手续费率模板
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpCommRateModel
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///手续费率模板代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string CommModelID;
        ///<summary>
        ///模板名称
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 161)]
        public string CommModelName;

        public static byte[] GetData(CtpCommRateModel obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.CommModelID);
                writer.Write(obj.CommModelName);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///请求查询投资者手续费率模板
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryCommRateModel
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///手续费率模板代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string CommModelID;

        public static byte[] GetData(CtpQryCommRateModel obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.CommModelID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///投资者保证金率模板
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpMarginModel
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///保证金率模板代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string MarginModelID;
        ///<summary>
        ///模板名称
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 161)]
        public string MarginModelName;

        public static byte[] GetData(CtpMarginModel obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.MarginModelID);
                writer.Write(obj.MarginModelName);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///请求查询投资者保证金率模板
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryMarginModel
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///保证金率模板代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string MarginModelID;

        public static byte[] GetData(CtpQryMarginModel obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.MarginModelID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///仓单折抵信息
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpEWarrantOffset
    {
        ///<summary>
        ///交易日期
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        ///<summary>
        ///买卖方向
        ///</summary>
        [DataMember(Order = 6)]
        public byte Direction;
        ///<summary>
        ///投机套保标志
        ///</summary>
        [DataMember(Order = 7)]
        public byte HedgeFlag;
        ///<summary>
        ///数量
        ///</summary>
        [DataMember(Order = 8)]
        public int Volume;

        public static byte[] GetData(CtpEWarrantOffset obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradingDay);
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.InstrumentID);
                writer.Write(obj.Direction);
                writer.Write(obj.HedgeFlag);
                writer.Write(obj.Volume);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询仓单折抵信息
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryEWarrantOffset
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///合约代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;

        public static byte[] GetData(CtpQryEWarrantOffset obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.InstrumentID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询投资者品种/跨品种保证金
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryInvestorProductGroupMargin
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///品种/跨品种标示
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ProductGroupID;
        ///<summary>
        ///投机套保标志
        ///</summary>
        [DataMember(Order = 4)]
        public byte HedgeFlag;

        public static byte[] GetData(CtpQryInvestorProductGroupMargin obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.ProductGroupID);
                writer.Write(obj.HedgeFlag);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///投资者品种/跨品种保证金
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpInvestorProductGroupMargin
    {
        ///<summary>
        ///品种/跨品种标示
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ProductGroupID;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///交易日
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///结算编号
        ///</summary>
        [DataMember(Order = 5)]
        public int SettlementID;
        ///<summary>
        ///冻结的保证金
        ///</summary>
        [DataMember(Order = 6)]
        public double FrozenMargin;
        ///<summary>
        ///多头冻结的保证金
        ///</summary>
        [DataMember(Order = 7)]
        public double LongFrozenMargin;
        ///<summary>
        ///空头冻结的保证金
        ///</summary>
        [DataMember(Order = 8)]
        public double ShortFrozenMargin;
        ///<summary>
        ///占用的保证金
        ///</summary>
        [DataMember(Order = 9)]
        public double UseMargin;
        ///<summary>
        ///多头保证金
        ///</summary>
        [DataMember(Order = 10)]
        public double LongUseMargin;
        ///<summary>
        ///空头保证金
        ///</summary>
        [DataMember(Order = 11)]
        public double ShortUseMargin;
        ///<summary>
        ///交易所保证金
        ///</summary>
        [DataMember(Order = 12)]
        public double ExchMargin;
        ///<summary>
        ///交易所多头保证金
        ///</summary>
        [DataMember(Order = 13)]
        public double LongExchMargin;
        ///<summary>
        ///交易所空头保证金
        ///</summary>
        [DataMember(Order = 14)]
        public double ShortExchMargin;
        ///<summary>
        ///平仓盈亏
        ///</summary>
        [DataMember(Order = 15)]
        public double CloseProfit;
        ///<summary>
        ///冻结的手续费
        ///</summary>
        [DataMember(Order = 16)]
        public double FrozenCommission;
        ///<summary>
        ///手续费
        ///</summary>
        [DataMember(Order = 17)]
        public double Commission;
        ///<summary>
        ///冻结的资金
        ///</summary>
        [DataMember(Order = 18)]
        public double FrozenCash;
        ///<summary>
        ///资金差额
        ///</summary>
        [DataMember(Order = 19)]
        public double CashIn;
        ///<summary>
        ///持仓盈亏
        ///</summary>
        [DataMember(Order = 20)]
        public double PositionProfit;
        ///<summary>
        ///折抵总金额
        ///</summary>
        [DataMember(Order = 21)]
        public double OffsetAmount;
        ///<summary>
        ///多头折抵总金额
        ///</summary>
        [DataMember(Order = 22)]
        public double LongOffsetAmount;
        ///<summary>
        ///空头折抵总金额
        ///</summary>
        [DataMember(Order = 23)]
        public double ShortOffsetAmount;
        ///<summary>
        ///交易所折抵总金额
        ///</summary>
        [DataMember(Order = 24)]
        public double ExchOffsetAmount;
        ///<summary>
        ///交易所多头折抵总金额
        ///</summary>
        [DataMember(Order = 25)]
        public double LongExchOffsetAmount;
        ///<summary>
        ///交易所空头折抵总金额
        ///</summary>
        [DataMember(Order = 26)]
        public double ShortExchOffsetAmount;
        ///<summary>
        ///投机套保标志
        ///</summary>
        [DataMember(Order = 27)]
        public byte HedgeFlag;

        public static byte[] GetData(CtpInvestorProductGroupMargin obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ProductGroupID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.TradingDay);
                writer.Write(obj.SettlementID);
                writer.Write(obj.FrozenMargin);
                writer.Write(obj.LongFrozenMargin);
                writer.Write(obj.ShortFrozenMargin);
                writer.Write(obj.UseMargin);
                writer.Write(obj.LongUseMargin);
                writer.Write(obj.ShortUseMargin);
                writer.Write(obj.ExchMargin);
                writer.Write(obj.LongExchMargin);
                writer.Write(obj.ShortExchMargin);
                writer.Write(obj.CloseProfit);
                writer.Write(obj.FrozenCommission);
                writer.Write(obj.Commission);
                writer.Write(obj.FrozenCash);
                writer.Write(obj.CashIn);
                writer.Write(obj.PositionProfit);
                writer.Write(obj.OffsetAmount);
                writer.Write(obj.LongOffsetAmount);
                writer.Write(obj.ShortOffsetAmount);
                writer.Write(obj.ExchOffsetAmount);
                writer.Write(obj.LongExchOffsetAmount);
                writer.Write(obj.ShortExchOffsetAmount);
                writer.Write(obj.HedgeFlag);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询监控中心用户令牌
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQueryCFMMCTradingAccountToken
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;

        public static byte[] GetData(CtpQueryCFMMCTradingAccountToken obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///监控中心用户令牌
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpCFMMCTradingAccountToken
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///经纪公司统一编码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ParticipantID;
        ///<summary>
        ///投资者帐号
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string AccountID;
        ///<summary>
        ///密钥编号
        ///</summary>
        [DataMember(Order = 4)]
        public int KeyID;
        ///<summary>
        ///动态令牌
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string Token;

        public static byte[] GetData(CtpCFMMCTradingAccountToken obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.ParticipantID);
                writer.Write(obj.AccountID);
                writer.Write(obj.KeyID);
                writer.Write(obj.Token);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询产品组
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryProductGroup
    {
        ///<summary>
        ///产品代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ProductID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;

        public static byte[] GetData(CtpQryProductGroup obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ProductID);
                writer.Write(obj.ExchangeID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///投资者品种/跨品种保证金产品组
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpProductGroup
    {
        ///<summary>
        ///产品代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ProductID;
        ///<summary>
        ///交易所代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        ///<summary>
        ///产品组代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ProductGroupID;

        public static byte[] GetData(CtpProductGroup obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ProductID);
                writer.Write(obj.ExchangeID);
                writer.Write(obj.ProductGroupID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///转帐开户请求
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpReqOpenAccount
    {
        ///<summary>
        ///业务功能码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string TradeCode;
        ///<summary>
        ///银行代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分支机构代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBranchID;
        ///<summary>
        ///期商代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///期商分支机构代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string BrokerBranchID;
        ///<summary>
        ///交易日期
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeDate;
        ///<summary>
        ///交易时间
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeTime;
        ///<summary>
        ///银行流水号
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string BankSerial;
        ///<summary>
        ///交易系统日期
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///银期平台消息流水号
        ///</summary>
        [DataMember(Order = 10)]
        public int PlateSerial;
        ///<summary>
        ///最后分片标志
        ///</summary>
        [DataMember(Order = 11)]
        public byte LastFragment;
        ///<summary>
        ///会话号
        ///</summary>
        [DataMember(Order = 12)]
        public int SessionID;
        ///<summary>
        ///客户姓名
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string CustomerName;
        ///<summary>
        ///证件类型
        ///</summary>
        [DataMember(Order = 14)]
        public byte IdCardType;
        ///<summary>
        ///证件号码
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string IdentifiedCardNo;
        ///<summary>
        ///性别
        ///</summary>
        [DataMember(Order = 16)]
        public byte Gender;
        ///<summary>
        ///国家代码
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string CountryCode;
        ///<summary>
        ///客户类型
        ///</summary>
        [DataMember(Order = 18)]
        public byte CustType;
        ///<summary>
        ///地址
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
        public string Address;
        ///<summary>
        ///邮编
        ///</summary>
        [DataMember(Order = 20)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string ZipCode;
        ///<summary>
        ///电话号码
        ///</summary>
        [DataMember(Order = 21)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Telephone;
        ///<summary>
        ///手机
        ///</summary>
        [DataMember(Order = 22)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string MobilePhone;
        ///<summary>
        ///传真
        ///</summary>
        [DataMember(Order = 23)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Fax;
        ///<summary>
        ///电子邮件
        ///</summary>
        [DataMember(Order = 24)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string EMail;
        ///<summary>
        ///资金账户状态
        ///</summary>
        [DataMember(Order = 25)]
        public byte MoneyAccountStatus;
        ///<summary>
        ///银行帐号
        ///</summary>
        [DataMember(Order = 26)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankAccount;
        ///<summary>
        ///银行密码
        ///</summary>
        [DataMember(Order = 27)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankPassWord;
        ///<summary>
        ///投资者帐号
        ///</summary>
        [DataMember(Order = 28)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string AccountID;
        ///<summary>
        ///期货密码
        ///</summary>
        [DataMember(Order = 29)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Password;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 30)]
        public int InstallID;
        ///<summary>
        ///验证客户证件号码标志
        ///</summary>
        [DataMember(Order = 31)]
        public byte VerifyCertNoFlag;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 32)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;
        ///<summary>
        ///汇钞标志
        ///</summary>
        [DataMember(Order = 33)]
        public byte CashExchangeCode;
        ///<summary>
        ///摘要
        ///</summary>
        [DataMember(Order = 34)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
        public string Digest;
        ///<summary>
        ///银行帐号类型
        ///</summary>
        [DataMember(Order = 35)]
        public byte BankAccType;
        ///<summary>
        ///渠道标志
        ///</summary>
        [DataMember(Order = 36)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string DeviceID;
        ///<summary>
        ///期货单位帐号类型
        ///</summary>
        [DataMember(Order = 37)]
        public byte BankSecuAccType;
        ///<summary>
        ///期货公司银行编码
        ///</summary>
        [DataMember(Order = 38)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string BrokerIDByBank;
        ///<summary>
        ///期货单位帐号
        ///</summary>
        [DataMember(Order = 39)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankSecuAcc;
        ///<summary>
        ///银行密码标志
        ///</summary>
        [DataMember(Order = 40)]
        public byte BankPwdFlag;
        ///<summary>
        ///期货资金密码核对标志
        ///</summary>
        [DataMember(Order = 41)]
        public byte SecuPwdFlag;
        ///<summary>
        ///交易柜员
        ///</summary>
        [DataMember(Order = 42)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string OperNo;
        ///<summary>
        ///交易ID
        ///</summary>
        [DataMember(Order = 43)]
        public int TID;
        ///<summary>
        ///用户标识
        ///</summary>
        [DataMember(Order = 44)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;

        public static byte[] GetData(CtpReqOpenAccount obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradeCode);
                writer.Write(obj.BankID);
                writer.Write(obj.BankBranchID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.BrokerBranchID);
                writer.Write(obj.TradeDate);
                writer.Write(obj.TradeTime);
                writer.Write(obj.BankSerial);
                writer.Write(obj.TradingDay);
                writer.Write(obj.PlateSerial);
                writer.Write(obj.LastFragment);
                writer.Write(obj.SessionID);
                writer.Write(obj.CustomerName);
                writer.Write(obj.IdCardType);
                writer.Write(obj.IdentifiedCardNo);
                writer.Write(obj.Gender);
                writer.Write(obj.CountryCode);
                writer.Write(obj.CustType);
                writer.Write(obj.Address);
                writer.Write(obj.ZipCode);
                writer.Write(obj.Telephone);
                writer.Write(obj.MobilePhone);
                writer.Write(obj.Fax);
                writer.Write(obj.EMail);
                writer.Write(obj.MoneyAccountStatus);
                writer.Write(obj.BankAccount);
                writer.Write(obj.BankPassWord);
                writer.Write(obj.AccountID);
                writer.Write(obj.Password);
                writer.Write(obj.InstallID);
                writer.Write(obj.VerifyCertNoFlag);
                writer.Write(obj.CurrencyID);
                writer.Write(obj.CashExchangeCode);
                writer.Write(obj.Digest);
                writer.Write(obj.BankAccType);
                writer.Write(obj.DeviceID);
                writer.Write(obj.BankSecuAccType);
                writer.Write(obj.BrokerIDByBank);
                writer.Write(obj.BankSecuAcc);
                writer.Write(obj.BankPwdFlag);
                writer.Write(obj.SecuPwdFlag);
                writer.Write(obj.OperNo);
                writer.Write(obj.TID);
                writer.Write(obj.UserID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///转帐销户请求
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpReqCancelAccount
    {
        ///<summary>
        ///业务功能码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string TradeCode;
        ///<summary>
        ///银行代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分支机构代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBranchID;
        ///<summary>
        ///期商代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///期商分支机构代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string BrokerBranchID;
        ///<summary>
        ///交易日期
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeDate;
        ///<summary>
        ///交易时间
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeTime;
        ///<summary>
        ///银行流水号
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string BankSerial;
        ///<summary>
        ///交易系统日期
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///银期平台消息流水号
        ///</summary>
        [DataMember(Order = 10)]
        public int PlateSerial;
        ///<summary>
        ///最后分片标志
        ///</summary>
        [DataMember(Order = 11)]
        public byte LastFragment;
        ///<summary>
        ///会话号
        ///</summary>
        [DataMember(Order = 12)]
        public int SessionID;
        ///<summary>
        ///客户姓名
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string CustomerName;
        ///<summary>
        ///证件类型
        ///</summary>
        [DataMember(Order = 14)]
        public byte IdCardType;
        ///<summary>
        ///证件号码
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string IdentifiedCardNo;
        ///<summary>
        ///性别
        ///</summary>
        [DataMember(Order = 16)]
        public byte Gender;
        ///<summary>
        ///国家代码
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string CountryCode;
        ///<summary>
        ///客户类型
        ///</summary>
        [DataMember(Order = 18)]
        public byte CustType;
        ///<summary>
        ///地址
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
        public string Address;
        ///<summary>
        ///邮编
        ///</summary>
        [DataMember(Order = 20)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string ZipCode;
        ///<summary>
        ///电话号码
        ///</summary>
        [DataMember(Order = 21)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Telephone;
        ///<summary>
        ///手机
        ///</summary>
        [DataMember(Order = 22)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string MobilePhone;
        ///<summary>
        ///传真
        ///</summary>
        [DataMember(Order = 23)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Fax;
        ///<summary>
        ///电子邮件
        ///</summary>
        [DataMember(Order = 24)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string EMail;
        ///<summary>
        ///资金账户状态
        ///</summary>
        [DataMember(Order = 25)]
        public byte MoneyAccountStatus;
        ///<summary>
        ///银行帐号
        ///</summary>
        [DataMember(Order = 26)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankAccount;
        ///<summary>
        ///银行密码
        ///</summary>
        [DataMember(Order = 27)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankPassWord;
        ///<summary>
        ///投资者帐号
        ///</summary>
        [DataMember(Order = 28)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string AccountID;
        ///<summary>
        ///期货密码
        ///</summary>
        [DataMember(Order = 29)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Password;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 30)]
        public int InstallID;
        ///<summary>
        ///验证客户证件号码标志
        ///</summary>
        [DataMember(Order = 31)]
        public byte VerifyCertNoFlag;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 32)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;
        ///<summary>
        ///汇钞标志
        ///</summary>
        [DataMember(Order = 33)]
        public byte CashExchangeCode;
        ///<summary>
        ///摘要
        ///</summary>
        [DataMember(Order = 34)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
        public string Digest;
        ///<summary>
        ///银行帐号类型
        ///</summary>
        [DataMember(Order = 35)]
        public byte BankAccType;
        ///<summary>
        ///渠道标志
        ///</summary>
        [DataMember(Order = 36)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string DeviceID;
        ///<summary>
        ///期货单位帐号类型
        ///</summary>
        [DataMember(Order = 37)]
        public byte BankSecuAccType;
        ///<summary>
        ///期货公司银行编码
        ///</summary>
        [DataMember(Order = 38)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string BrokerIDByBank;
        ///<summary>
        ///期货单位帐号
        ///</summary>
        [DataMember(Order = 39)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankSecuAcc;
        ///<summary>
        ///银行密码标志
        ///</summary>
        [DataMember(Order = 40)]
        public byte BankPwdFlag;
        ///<summary>
        ///期货资金密码核对标志
        ///</summary>
        [DataMember(Order = 41)]
        public byte SecuPwdFlag;
        ///<summary>
        ///交易柜员
        ///</summary>
        [DataMember(Order = 42)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string OperNo;
        ///<summary>
        ///交易ID
        ///</summary>
        [DataMember(Order = 43)]
        public int TID;
        ///<summary>
        ///用户标识
        ///</summary>
        [DataMember(Order = 44)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;

        public static byte[] GetData(CtpReqCancelAccount obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradeCode);
                writer.Write(obj.BankID);
                writer.Write(obj.BankBranchID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.BrokerBranchID);
                writer.Write(obj.TradeDate);
                writer.Write(obj.TradeTime);
                writer.Write(obj.BankSerial);
                writer.Write(obj.TradingDay);
                writer.Write(obj.PlateSerial);
                writer.Write(obj.LastFragment);
                writer.Write(obj.SessionID);
                writer.Write(obj.CustomerName);
                writer.Write(obj.IdCardType);
                writer.Write(obj.IdentifiedCardNo);
                writer.Write(obj.Gender);
                writer.Write(obj.CountryCode);
                writer.Write(obj.CustType);
                writer.Write(obj.Address);
                writer.Write(obj.ZipCode);
                writer.Write(obj.Telephone);
                writer.Write(obj.MobilePhone);
                writer.Write(obj.Fax);
                writer.Write(obj.EMail);
                writer.Write(obj.MoneyAccountStatus);
                writer.Write(obj.BankAccount);
                writer.Write(obj.BankPassWord);
                writer.Write(obj.AccountID);
                writer.Write(obj.Password);
                writer.Write(obj.InstallID);
                writer.Write(obj.VerifyCertNoFlag);
                writer.Write(obj.CurrencyID);
                writer.Write(obj.CashExchangeCode);
                writer.Write(obj.Digest);
                writer.Write(obj.BankAccType);
                writer.Write(obj.DeviceID);
                writer.Write(obj.BankSecuAccType);
                writer.Write(obj.BrokerIDByBank);
                writer.Write(obj.BankSecuAcc);
                writer.Write(obj.BankPwdFlag);
                writer.Write(obj.SecuPwdFlag);
                writer.Write(obj.OperNo);
                writer.Write(obj.TID);
                writer.Write(obj.UserID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///变更银行账户请求
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpReqChangeAccount
    {
        ///<summary>
        ///业务功能码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string TradeCode;
        ///<summary>
        ///银行代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分支机构代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBranchID;
        ///<summary>
        ///期商代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///期商分支机构代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string BrokerBranchID;
        ///<summary>
        ///交易日期
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeDate;
        ///<summary>
        ///交易时间
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeTime;
        ///<summary>
        ///银行流水号
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string BankSerial;
        ///<summary>
        ///交易系统日期
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///银期平台消息流水号
        ///</summary>
        [DataMember(Order = 10)]
        public int PlateSerial;
        ///<summary>
        ///最后分片标志
        ///</summary>
        [DataMember(Order = 11)]
        public byte LastFragment;
        ///<summary>
        ///会话号
        ///</summary>
        [DataMember(Order = 12)]
        public int SessionID;
        ///<summary>
        ///客户姓名
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string CustomerName;
        ///<summary>
        ///证件类型
        ///</summary>
        [DataMember(Order = 14)]
        public byte IdCardType;
        ///<summary>
        ///证件号码
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string IdentifiedCardNo;
        ///<summary>
        ///性别
        ///</summary>
        [DataMember(Order = 16)]
        public byte Gender;
        ///<summary>
        ///国家代码
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string CountryCode;
        ///<summary>
        ///客户类型
        ///</summary>
        [DataMember(Order = 18)]
        public byte CustType;
        ///<summary>
        ///地址
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
        public string Address;
        ///<summary>
        ///邮编
        ///</summary>
        [DataMember(Order = 20)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string ZipCode;
        ///<summary>
        ///电话号码
        ///</summary>
        [DataMember(Order = 21)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Telephone;
        ///<summary>
        ///手机
        ///</summary>
        [DataMember(Order = 22)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string MobilePhone;
        ///<summary>
        ///传真
        ///</summary>
        [DataMember(Order = 23)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Fax;
        ///<summary>
        ///电子邮件
        ///</summary>
        [DataMember(Order = 24)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string EMail;
        ///<summary>
        ///资金账户状态
        ///</summary>
        [DataMember(Order = 25)]
        public byte MoneyAccountStatus;
        ///<summary>
        ///银行帐号
        ///</summary>
        [DataMember(Order = 26)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankAccount;
        ///<summary>
        ///银行密码
        ///</summary>
        [DataMember(Order = 27)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankPassWord;
        ///<summary>
        ///新银行帐号
        ///</summary>
        [DataMember(Order = 28)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string NewBankAccount;
        ///<summary>
        ///新银行密码
        ///</summary>
        [DataMember(Order = 29)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string NewBankPassWord;
        ///<summary>
        ///投资者帐号
        ///</summary>
        [DataMember(Order = 30)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string AccountID;
        ///<summary>
        ///期货密码
        ///</summary>
        [DataMember(Order = 31)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Password;
        ///<summary>
        ///银行帐号类型
        ///</summary>
        [DataMember(Order = 32)]
        public byte BankAccType;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 33)]
        public int InstallID;
        ///<summary>
        ///验证客户证件号码标志
        ///</summary>
        [DataMember(Order = 34)]
        public byte VerifyCertNoFlag;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 35)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;
        ///<summary>
        ///期货公司银行编码
        ///</summary>
        [DataMember(Order = 36)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string BrokerIDByBank;
        ///<summary>
        ///银行密码标志
        ///</summary>
        [DataMember(Order = 37)]
        public byte BankPwdFlag;
        ///<summary>
        ///期货资金密码核对标志
        ///</summary>
        [DataMember(Order = 38)]
        public byte SecuPwdFlag;
        ///<summary>
        ///交易ID
        ///</summary>
        [DataMember(Order = 39)]
        public int TID;
        ///<summary>
        ///摘要
        ///</summary>
        [DataMember(Order = 40)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
        public string Digest;

        public static byte[] GetData(CtpReqChangeAccount obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradeCode);
                writer.Write(obj.BankID);
                writer.Write(obj.BankBranchID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.BrokerBranchID);
                writer.Write(obj.TradeDate);
                writer.Write(obj.TradeTime);
                writer.Write(obj.BankSerial);
                writer.Write(obj.TradingDay);
                writer.Write(obj.PlateSerial);
                writer.Write(obj.LastFragment);
                writer.Write(obj.SessionID);
                writer.Write(obj.CustomerName);
                writer.Write(obj.IdCardType);
                writer.Write(obj.IdentifiedCardNo);
                writer.Write(obj.Gender);
                writer.Write(obj.CountryCode);
                writer.Write(obj.CustType);
                writer.Write(obj.Address);
                writer.Write(obj.ZipCode);
                writer.Write(obj.Telephone);
                writer.Write(obj.MobilePhone);
                writer.Write(obj.Fax);
                writer.Write(obj.EMail);
                writer.Write(obj.MoneyAccountStatus);
                writer.Write(obj.BankAccount);
                writer.Write(obj.BankPassWord);
                writer.Write(obj.NewBankAccount);
                writer.Write(obj.NewBankPassWord);
                writer.Write(obj.AccountID);
                writer.Write(obj.Password);
                writer.Write(obj.BankAccType);
                writer.Write(obj.InstallID);
                writer.Write(obj.VerifyCertNoFlag);
                writer.Write(obj.CurrencyID);
                writer.Write(obj.BrokerIDByBank);
                writer.Write(obj.BankPwdFlag);
                writer.Write(obj.SecuPwdFlag);
                writer.Write(obj.TID);
                writer.Write(obj.Digest);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///转账请求
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpReqTransfer
    {
        ///<summary>
        ///业务功能码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string TradeCode;
        ///<summary>
        ///银行代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分支机构代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBranchID;
        ///<summary>
        ///期商代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///期商分支机构代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string BrokerBranchID;
        ///<summary>
        ///交易日期
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeDate;
        ///<summary>
        ///交易时间
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeTime;
        ///<summary>
        ///银行流水号
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string BankSerial;
        ///<summary>
        ///交易系统日期
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///银期平台消息流水号
        ///</summary>
        [DataMember(Order = 10)]
        public int PlateSerial;
        ///<summary>
        ///最后分片标志
        ///</summary>
        [DataMember(Order = 11)]
        public byte LastFragment;
        ///<summary>
        ///会话号
        ///</summary>
        [DataMember(Order = 12)]
        public int SessionID;
        ///<summary>
        ///客户姓名
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string CustomerName;
        ///<summary>
        ///证件类型
        ///</summary>
        [DataMember(Order = 14)]
        public byte IdCardType;
        ///<summary>
        ///证件号码
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string IdentifiedCardNo;
        ///<summary>
        ///客户类型
        ///</summary>
        [DataMember(Order = 16)]
        public byte CustType;
        ///<summary>
        ///银行帐号
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankAccount;
        ///<summary>
        ///银行密码
        ///</summary>
        [DataMember(Order = 18)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankPassWord;
        ///<summary>
        ///投资者帐号
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string AccountID;
        ///<summary>
        ///期货密码
        ///</summary>
        [DataMember(Order = 20)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Password;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 21)]
        public int InstallID;
        ///<summary>
        ///期货公司流水号
        ///</summary>
        [DataMember(Order = 22)]
        public int FutureSerial;
        ///<summary>
        ///用户标识
        ///</summary>
        [DataMember(Order = 23)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///验证客户证件号码标志
        ///</summary>
        [DataMember(Order = 24)]
        public byte VerifyCertNoFlag;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 25)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;
        ///<summary>
        ///转帐金额
        ///</summary>
        [DataMember(Order = 26)]
        public double TradeAmount;
        ///<summary>
        ///期货可取金额
        ///</summary>
        [DataMember(Order = 27)]
        public double FutureFetchAmount;
        ///<summary>
        ///费用支付标志
        ///</summary>
        [DataMember(Order = 28)]
        public byte FeePayFlag;
        ///<summary>
        ///应收客户费用
        ///</summary>
        [DataMember(Order = 29)]
        public double CustFee;
        ///<summary>
        ///应收期货公司费用
        ///</summary>
        [DataMember(Order = 30)]
        public double BrokerFee;
        ///<summary>
        ///发送方给接收方的消息
        ///</summary>
        [DataMember(Order = 31)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string Message;
        ///<summary>
        ///摘要
        ///</summary>
        [DataMember(Order = 32)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
        public string Digest;
        ///<summary>
        ///银行帐号类型
        ///</summary>
        [DataMember(Order = 33)]
        public byte BankAccType;
        ///<summary>
        ///渠道标志
        ///</summary>
        [DataMember(Order = 34)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string DeviceID;
        ///<summary>
        ///期货单位帐号类型
        ///</summary>
        [DataMember(Order = 35)]
        public byte BankSecuAccType;
        ///<summary>
        ///期货公司银行编码
        ///</summary>
        [DataMember(Order = 36)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string BrokerIDByBank;
        ///<summary>
        ///期货单位帐号
        ///</summary>
        [DataMember(Order = 37)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankSecuAcc;
        ///<summary>
        ///银行密码标志
        ///</summary>
        [DataMember(Order = 38)]
        public byte BankPwdFlag;
        ///<summary>
        ///期货资金密码核对标志
        ///</summary>
        [DataMember(Order = 39)]
        public byte SecuPwdFlag;
        ///<summary>
        ///交易柜员
        ///</summary>
        [DataMember(Order = 40)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string OperNo;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 41)]
        public int RequestID;
        ///<summary>
        ///交易ID
        ///</summary>
        [DataMember(Order = 42)]
        public int TID;
        ///<summary>
        ///转账交易状态
        ///</summary>
        [DataMember(Order = 43)]
        public byte TransferStatus;

        public static byte[] GetData(CtpReqTransfer obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradeCode);
                writer.Write(obj.BankID);
                writer.Write(obj.BankBranchID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.BrokerBranchID);
                writer.Write(obj.TradeDate);
                writer.Write(obj.TradeTime);
                writer.Write(obj.BankSerial);
                writer.Write(obj.TradingDay);
                writer.Write(obj.PlateSerial);
                writer.Write(obj.LastFragment);
                writer.Write(obj.SessionID);
                writer.Write(obj.CustomerName);
                writer.Write(obj.IdCardType);
                writer.Write(obj.IdentifiedCardNo);
                writer.Write(obj.CustType);
                writer.Write(obj.BankAccount);
                writer.Write(obj.BankPassWord);
                writer.Write(obj.AccountID);
                writer.Write(obj.Password);
                writer.Write(obj.InstallID);
                writer.Write(obj.FutureSerial);
                writer.Write(obj.UserID);
                writer.Write(obj.VerifyCertNoFlag);
                writer.Write(obj.CurrencyID);
                writer.Write(obj.TradeAmount);
                writer.Write(obj.FutureFetchAmount);
                writer.Write(obj.FeePayFlag);
                writer.Write(obj.CustFee);
                writer.Write(obj.BrokerFee);
                writer.Write(obj.Message);
                writer.Write(obj.Digest);
                writer.Write(obj.BankAccType);
                writer.Write(obj.DeviceID);
                writer.Write(obj.BankSecuAccType);
                writer.Write(obj.BrokerIDByBank);
                writer.Write(obj.BankSecuAcc);
                writer.Write(obj.BankPwdFlag);
                writer.Write(obj.SecuPwdFlag);
                writer.Write(obj.OperNo);
                writer.Write(obj.RequestID);
                writer.Write(obj.TID);
                writer.Write(obj.TransferStatus);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///银行发起银行资金转期货响应
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpRspTransfer
    {
        ///<summary>
        ///业务功能码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string TradeCode;
        ///<summary>
        ///银行代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分支机构代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBranchID;
        ///<summary>
        ///期商代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///期商分支机构代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string BrokerBranchID;
        ///<summary>
        ///交易日期
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeDate;
        ///<summary>
        ///交易时间
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeTime;
        ///<summary>
        ///银行流水号
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string BankSerial;
        ///<summary>
        ///交易系统日期
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///银期平台消息流水号
        ///</summary>
        [DataMember(Order = 10)]
        public int PlateSerial;
        ///<summary>
        ///最后分片标志
        ///</summary>
        [DataMember(Order = 11)]
        public byte LastFragment;
        ///<summary>
        ///会话号
        ///</summary>
        [DataMember(Order = 12)]
        public int SessionID;
        ///<summary>
        ///客户姓名
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string CustomerName;
        ///<summary>
        ///证件类型
        ///</summary>
        [DataMember(Order = 14)]
        public byte IdCardType;
        ///<summary>
        ///证件号码
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string IdentifiedCardNo;
        ///<summary>
        ///客户类型
        ///</summary>
        [DataMember(Order = 16)]
        public byte CustType;
        ///<summary>
        ///银行帐号
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankAccount;
        ///<summary>
        ///银行密码
        ///</summary>
        [DataMember(Order = 18)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankPassWord;
        ///<summary>
        ///投资者帐号
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string AccountID;
        ///<summary>
        ///期货密码
        ///</summary>
        [DataMember(Order = 20)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Password;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 21)]
        public int InstallID;
        ///<summary>
        ///期货公司流水号
        ///</summary>
        [DataMember(Order = 22)]
        public int FutureSerial;
        ///<summary>
        ///用户标识
        ///</summary>
        [DataMember(Order = 23)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///验证客户证件号码标志
        ///</summary>
        [DataMember(Order = 24)]
        public byte VerifyCertNoFlag;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 25)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;
        ///<summary>
        ///转帐金额
        ///</summary>
        [DataMember(Order = 26)]
        public double TradeAmount;
        ///<summary>
        ///期货可取金额
        ///</summary>
        [DataMember(Order = 27)]
        public double FutureFetchAmount;
        ///<summary>
        ///费用支付标志
        ///</summary>
        [DataMember(Order = 28)]
        public byte FeePayFlag;
        ///<summary>
        ///应收客户费用
        ///</summary>
        [DataMember(Order = 29)]
        public double CustFee;
        ///<summary>
        ///应收期货公司费用
        ///</summary>
        [DataMember(Order = 30)]
        public double BrokerFee;
        ///<summary>
        ///发送方给接收方的消息
        ///</summary>
        [DataMember(Order = 31)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string Message;
        ///<summary>
        ///摘要
        ///</summary>
        [DataMember(Order = 32)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
        public string Digest;
        ///<summary>
        ///银行帐号类型
        ///</summary>
        [DataMember(Order = 33)]
        public byte BankAccType;
        ///<summary>
        ///渠道标志
        ///</summary>
        [DataMember(Order = 34)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string DeviceID;
        ///<summary>
        ///期货单位帐号类型
        ///</summary>
        [DataMember(Order = 35)]
        public byte BankSecuAccType;
        ///<summary>
        ///期货公司银行编码
        ///</summary>
        [DataMember(Order = 36)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string BrokerIDByBank;
        ///<summary>
        ///期货单位帐号
        ///</summary>
        [DataMember(Order = 37)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankSecuAcc;
        ///<summary>
        ///银行密码标志
        ///</summary>
        [DataMember(Order = 38)]
        public byte BankPwdFlag;
        ///<summary>
        ///期货资金密码核对标志
        ///</summary>
        [DataMember(Order = 39)]
        public byte SecuPwdFlag;
        ///<summary>
        ///交易柜员
        ///</summary>
        [DataMember(Order = 40)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string OperNo;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 41)]
        public int RequestID;
        ///<summary>
        ///交易ID
        ///</summary>
        [DataMember(Order = 42)]
        public int TID;
        ///<summary>
        ///转账交易状态
        ///</summary>
        [DataMember(Order = 43)]
        public byte TransferStatus;
        ///<summary>
        ///错误代码
        ///</summary>
        [DataMember(Order = 44)]
        public int ErrorID;
        ///<summary>
        ///错误信息
        ///</summary>
        [DataMember(Order = 45)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string ErrorMsg;

        public static byte[] GetData(CtpRspTransfer obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradeCode);
                writer.Write(obj.BankID);
                writer.Write(obj.BankBranchID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.BrokerBranchID);
                writer.Write(obj.TradeDate);
                writer.Write(obj.TradeTime);
                writer.Write(obj.BankSerial);
                writer.Write(obj.TradingDay);
                writer.Write(obj.PlateSerial);
                writer.Write(obj.LastFragment);
                writer.Write(obj.SessionID);
                writer.Write(obj.CustomerName);
                writer.Write(obj.IdCardType);
                writer.Write(obj.IdentifiedCardNo);
                writer.Write(obj.CustType);
                writer.Write(obj.BankAccount);
                writer.Write(obj.BankPassWord);
                writer.Write(obj.AccountID);
                writer.Write(obj.Password);
                writer.Write(obj.InstallID);
                writer.Write(obj.FutureSerial);
                writer.Write(obj.UserID);
                writer.Write(obj.VerifyCertNoFlag);
                writer.Write(obj.CurrencyID);
                writer.Write(obj.TradeAmount);
                writer.Write(obj.FutureFetchAmount);
                writer.Write(obj.FeePayFlag);
                writer.Write(obj.CustFee);
                writer.Write(obj.BrokerFee);
                writer.Write(obj.Message);
                writer.Write(obj.Digest);
                writer.Write(obj.BankAccType);
                writer.Write(obj.DeviceID);
                writer.Write(obj.BankSecuAccType);
                writer.Write(obj.BrokerIDByBank);
                writer.Write(obj.BankSecuAcc);
                writer.Write(obj.BankPwdFlag);
                writer.Write(obj.SecuPwdFlag);
                writer.Write(obj.OperNo);
                writer.Write(obj.RequestID);
                writer.Write(obj.TID);
                writer.Write(obj.TransferStatus);
                writer.Write(obj.ErrorID);
                writer.Write(obj.ErrorMsg);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///冲正请求
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpReqRepeal
    {
        ///<summary>
        ///冲正时间间隔
        ///</summary>
        [DataMember(Order = 1)]
        public int RepealTimeInterval;
        ///<summary>
        ///已经冲正次数
        ///</summary>
        [DataMember(Order = 2)]
        public int RepealedTimes;
        ///<summary>
        ///银行冲正标志
        ///</summary>
        [DataMember(Order = 3)]
        public byte BankRepealFlag;
        ///<summary>
        ///期商冲正标志
        ///</summary>
        [DataMember(Order = 4)]
        public byte BrokerRepealFlag;
        ///<summary>
        ///被冲正平台流水号
        ///</summary>
        [DataMember(Order = 5)]
        public int PlateRepealSerial;
        ///<summary>
        ///被冲正银行流水号
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string BankRepealSerial;
        ///<summary>
        ///被冲正期货流水号
        ///</summary>
        [DataMember(Order = 7)]
        public int FutureRepealSerial;
        ///<summary>
        ///业务功能码
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string TradeCode;
        ///<summary>
        ///银行代码
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分支机构代码
        ///</summary>
        [DataMember(Order = 10)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBranchID;
        ///<summary>
        ///期商代码
        ///</summary>
        [DataMember(Order = 11)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///期商分支机构代码
        ///</summary>
        [DataMember(Order = 12)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string BrokerBranchID;
        ///<summary>
        ///交易日期
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeDate;
        ///<summary>
        ///交易时间
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeTime;
        ///<summary>
        ///银行流水号
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string BankSerial;
        ///<summary>
        ///交易系统日期
        ///</summary>
        [DataMember(Order = 16)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///银期平台消息流水号
        ///</summary>
        [DataMember(Order = 17)]
        public int PlateSerial;
        ///<summary>
        ///最后分片标志
        ///</summary>
        [DataMember(Order = 18)]
        public byte LastFragment;
        ///<summary>
        ///会话号
        ///</summary>
        [DataMember(Order = 19)]
        public int SessionID;
        ///<summary>
        ///客户姓名
        ///</summary>
        [DataMember(Order = 20)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string CustomerName;
        ///<summary>
        ///证件类型
        ///</summary>
        [DataMember(Order = 21)]
        public byte IdCardType;
        ///<summary>
        ///证件号码
        ///</summary>
        [DataMember(Order = 22)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string IdentifiedCardNo;
        ///<summary>
        ///客户类型
        ///</summary>
        [DataMember(Order = 23)]
        public byte CustType;
        ///<summary>
        ///银行帐号
        ///</summary>
        [DataMember(Order = 24)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankAccount;
        ///<summary>
        ///银行密码
        ///</summary>
        [DataMember(Order = 25)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankPassWord;
        ///<summary>
        ///投资者帐号
        ///</summary>
        [DataMember(Order = 26)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string AccountID;
        ///<summary>
        ///期货密码
        ///</summary>
        [DataMember(Order = 27)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Password;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 28)]
        public int InstallID;
        ///<summary>
        ///期货公司流水号
        ///</summary>
        [DataMember(Order = 29)]
        public int FutureSerial;
        ///<summary>
        ///用户标识
        ///</summary>
        [DataMember(Order = 30)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///验证客户证件号码标志
        ///</summary>
        [DataMember(Order = 31)]
        public byte VerifyCertNoFlag;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 32)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;
        ///<summary>
        ///转帐金额
        ///</summary>
        [DataMember(Order = 33)]
        public double TradeAmount;
        ///<summary>
        ///期货可取金额
        ///</summary>
        [DataMember(Order = 34)]
        public double FutureFetchAmount;
        ///<summary>
        ///费用支付标志
        ///</summary>
        [DataMember(Order = 35)]
        public byte FeePayFlag;
        ///<summary>
        ///应收客户费用
        ///</summary>
        [DataMember(Order = 36)]
        public double CustFee;
        ///<summary>
        ///应收期货公司费用
        ///</summary>
        [DataMember(Order = 37)]
        public double BrokerFee;
        ///<summary>
        ///发送方给接收方的消息
        ///</summary>
        [DataMember(Order = 38)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string Message;
        ///<summary>
        ///摘要
        ///</summary>
        [DataMember(Order = 39)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
        public string Digest;
        ///<summary>
        ///银行帐号类型
        ///</summary>
        [DataMember(Order = 40)]
        public byte BankAccType;
        ///<summary>
        ///渠道标志
        ///</summary>
        [DataMember(Order = 41)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string DeviceID;
        ///<summary>
        ///期货单位帐号类型
        ///</summary>
        [DataMember(Order = 42)]
        public byte BankSecuAccType;
        ///<summary>
        ///期货公司银行编码
        ///</summary>
        [DataMember(Order = 43)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string BrokerIDByBank;
        ///<summary>
        ///期货单位帐号
        ///</summary>
        [DataMember(Order = 44)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankSecuAcc;
        ///<summary>
        ///银行密码标志
        ///</summary>
        [DataMember(Order = 45)]
        public byte BankPwdFlag;
        ///<summary>
        ///期货资金密码核对标志
        ///</summary>
        [DataMember(Order = 46)]
        public byte SecuPwdFlag;
        ///<summary>
        ///交易柜员
        ///</summary>
        [DataMember(Order = 47)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string OperNo;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 48)]
        public int RequestID;
        ///<summary>
        ///交易ID
        ///</summary>
        [DataMember(Order = 49)]
        public int TID;
        ///<summary>
        ///转账交易状态
        ///</summary>
        [DataMember(Order = 50)]
        public byte TransferStatus;

        public static byte[] GetData(CtpReqRepeal obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.RepealTimeInterval);
                writer.Write(obj.RepealedTimes);
                writer.Write(obj.BankRepealFlag);
                writer.Write(obj.BrokerRepealFlag);
                writer.Write(obj.PlateRepealSerial);
                writer.Write(obj.BankRepealSerial);
                writer.Write(obj.FutureRepealSerial);
                writer.Write(obj.TradeCode);
                writer.Write(obj.BankID);
                writer.Write(obj.BankBranchID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.BrokerBranchID);
                writer.Write(obj.TradeDate);
                writer.Write(obj.TradeTime);
                writer.Write(obj.BankSerial);
                writer.Write(obj.TradingDay);
                writer.Write(obj.PlateSerial);
                writer.Write(obj.LastFragment);
                writer.Write(obj.SessionID);
                writer.Write(obj.CustomerName);
                writer.Write(obj.IdCardType);
                writer.Write(obj.IdentifiedCardNo);
                writer.Write(obj.CustType);
                writer.Write(obj.BankAccount);
                writer.Write(obj.BankPassWord);
                writer.Write(obj.AccountID);
                writer.Write(obj.Password);
                writer.Write(obj.InstallID);
                writer.Write(obj.FutureSerial);
                writer.Write(obj.UserID);
                writer.Write(obj.VerifyCertNoFlag);
                writer.Write(obj.CurrencyID);
                writer.Write(obj.TradeAmount);
                writer.Write(obj.FutureFetchAmount);
                writer.Write(obj.FeePayFlag);
                writer.Write(obj.CustFee);
                writer.Write(obj.BrokerFee);
                writer.Write(obj.Message);
                writer.Write(obj.Digest);
                writer.Write(obj.BankAccType);
                writer.Write(obj.DeviceID);
                writer.Write(obj.BankSecuAccType);
                writer.Write(obj.BrokerIDByBank);
                writer.Write(obj.BankSecuAcc);
                writer.Write(obj.BankPwdFlag);
                writer.Write(obj.SecuPwdFlag);
                writer.Write(obj.OperNo);
                writer.Write(obj.RequestID);
                writer.Write(obj.TID);
                writer.Write(obj.TransferStatus);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///冲正响应
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpRspRepeal
    {
        ///<summary>
        ///冲正时间间隔
        ///</summary>
        [DataMember(Order = 1)]
        public int RepealTimeInterval;
        ///<summary>
        ///已经冲正次数
        ///</summary>
        [DataMember(Order = 2)]
        public int RepealedTimes;
        ///<summary>
        ///银行冲正标志
        ///</summary>
        [DataMember(Order = 3)]
        public byte BankRepealFlag;
        ///<summary>
        ///期商冲正标志
        ///</summary>
        [DataMember(Order = 4)]
        public byte BrokerRepealFlag;
        ///<summary>
        ///被冲正平台流水号
        ///</summary>
        [DataMember(Order = 5)]
        public int PlateRepealSerial;
        ///<summary>
        ///被冲正银行流水号
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string BankRepealSerial;
        ///<summary>
        ///被冲正期货流水号
        ///</summary>
        [DataMember(Order = 7)]
        public int FutureRepealSerial;
        ///<summary>
        ///业务功能码
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string TradeCode;
        ///<summary>
        ///银行代码
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分支机构代码
        ///</summary>
        [DataMember(Order = 10)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBranchID;
        ///<summary>
        ///期商代码
        ///</summary>
        [DataMember(Order = 11)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///期商分支机构代码
        ///</summary>
        [DataMember(Order = 12)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string BrokerBranchID;
        ///<summary>
        ///交易日期
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeDate;
        ///<summary>
        ///交易时间
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeTime;
        ///<summary>
        ///银行流水号
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string BankSerial;
        ///<summary>
        ///交易系统日期
        ///</summary>
        [DataMember(Order = 16)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///银期平台消息流水号
        ///</summary>
        [DataMember(Order = 17)]
        public int PlateSerial;
        ///<summary>
        ///最后分片标志
        ///</summary>
        [DataMember(Order = 18)]
        public byte LastFragment;
        ///<summary>
        ///会话号
        ///</summary>
        [DataMember(Order = 19)]
        public int SessionID;
        ///<summary>
        ///客户姓名
        ///</summary>
        [DataMember(Order = 20)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string CustomerName;
        ///<summary>
        ///证件类型
        ///</summary>
        [DataMember(Order = 21)]
        public byte IdCardType;
        ///<summary>
        ///证件号码
        ///</summary>
        [DataMember(Order = 22)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string IdentifiedCardNo;
        ///<summary>
        ///客户类型
        ///</summary>
        [DataMember(Order = 23)]
        public byte CustType;
        ///<summary>
        ///银行帐号
        ///</summary>
        [DataMember(Order = 24)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankAccount;
        ///<summary>
        ///银行密码
        ///</summary>
        [DataMember(Order = 25)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankPassWord;
        ///<summary>
        ///投资者帐号
        ///</summary>
        [DataMember(Order = 26)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string AccountID;
        ///<summary>
        ///期货密码
        ///</summary>
        [DataMember(Order = 27)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Password;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 28)]
        public int InstallID;
        ///<summary>
        ///期货公司流水号
        ///</summary>
        [DataMember(Order = 29)]
        public int FutureSerial;
        ///<summary>
        ///用户标识
        ///</summary>
        [DataMember(Order = 30)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///验证客户证件号码标志
        ///</summary>
        [DataMember(Order = 31)]
        public byte VerifyCertNoFlag;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 32)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;
        ///<summary>
        ///转帐金额
        ///</summary>
        [DataMember(Order = 33)]
        public double TradeAmount;
        ///<summary>
        ///期货可取金额
        ///</summary>
        [DataMember(Order = 34)]
        public double FutureFetchAmount;
        ///<summary>
        ///费用支付标志
        ///</summary>
        [DataMember(Order = 35)]
        public byte FeePayFlag;
        ///<summary>
        ///应收客户费用
        ///</summary>
        [DataMember(Order = 36)]
        public double CustFee;
        ///<summary>
        ///应收期货公司费用
        ///</summary>
        [DataMember(Order = 37)]
        public double BrokerFee;
        ///<summary>
        ///发送方给接收方的消息
        ///</summary>
        [DataMember(Order = 38)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string Message;
        ///<summary>
        ///摘要
        ///</summary>
        [DataMember(Order = 39)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
        public string Digest;
        ///<summary>
        ///银行帐号类型
        ///</summary>
        [DataMember(Order = 40)]
        public byte BankAccType;
        ///<summary>
        ///渠道标志
        ///</summary>
        [DataMember(Order = 41)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string DeviceID;
        ///<summary>
        ///期货单位帐号类型
        ///</summary>
        [DataMember(Order = 42)]
        public byte BankSecuAccType;
        ///<summary>
        ///期货公司银行编码
        ///</summary>
        [DataMember(Order = 43)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string BrokerIDByBank;
        ///<summary>
        ///期货单位帐号
        ///</summary>
        [DataMember(Order = 44)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankSecuAcc;
        ///<summary>
        ///银行密码标志
        ///</summary>
        [DataMember(Order = 45)]
        public byte BankPwdFlag;
        ///<summary>
        ///期货资金密码核对标志
        ///</summary>
        [DataMember(Order = 46)]
        public byte SecuPwdFlag;
        ///<summary>
        ///交易柜员
        ///</summary>
        [DataMember(Order = 47)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string OperNo;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 48)]
        public int RequestID;
        ///<summary>
        ///交易ID
        ///</summary>
        [DataMember(Order = 49)]
        public int TID;
        ///<summary>
        ///转账交易状态
        ///</summary>
        [DataMember(Order = 50)]
        public byte TransferStatus;
        ///<summary>
        ///错误代码
        ///</summary>
        [DataMember(Order = 51)]
        public int ErrorID;
        ///<summary>
        ///错误信息
        ///</summary>
        [DataMember(Order = 52)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string ErrorMsg;

        public static byte[] GetData(CtpRspRepeal obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.RepealTimeInterval);
                writer.Write(obj.RepealedTimes);
                writer.Write(obj.BankRepealFlag);
                writer.Write(obj.BrokerRepealFlag);
                writer.Write(obj.PlateRepealSerial);
                writer.Write(obj.BankRepealSerial);
                writer.Write(obj.FutureRepealSerial);
                writer.Write(obj.TradeCode);
                writer.Write(obj.BankID);
                writer.Write(obj.BankBranchID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.BrokerBranchID);
                writer.Write(obj.TradeDate);
                writer.Write(obj.TradeTime);
                writer.Write(obj.BankSerial);
                writer.Write(obj.TradingDay);
                writer.Write(obj.PlateSerial);
                writer.Write(obj.LastFragment);
                writer.Write(obj.SessionID);
                writer.Write(obj.CustomerName);
                writer.Write(obj.IdCardType);
                writer.Write(obj.IdentifiedCardNo);
                writer.Write(obj.CustType);
                writer.Write(obj.BankAccount);
                writer.Write(obj.BankPassWord);
                writer.Write(obj.AccountID);
                writer.Write(obj.Password);
                writer.Write(obj.InstallID);
                writer.Write(obj.FutureSerial);
                writer.Write(obj.UserID);
                writer.Write(obj.VerifyCertNoFlag);
                writer.Write(obj.CurrencyID);
                writer.Write(obj.TradeAmount);
                writer.Write(obj.FutureFetchAmount);
                writer.Write(obj.FeePayFlag);
                writer.Write(obj.CustFee);
                writer.Write(obj.BrokerFee);
                writer.Write(obj.Message);
                writer.Write(obj.Digest);
                writer.Write(obj.BankAccType);
                writer.Write(obj.DeviceID);
                writer.Write(obj.BankSecuAccType);
                writer.Write(obj.BrokerIDByBank);
                writer.Write(obj.BankSecuAcc);
                writer.Write(obj.BankPwdFlag);
                writer.Write(obj.SecuPwdFlag);
                writer.Write(obj.OperNo);
                writer.Write(obj.RequestID);
                writer.Write(obj.TID);
                writer.Write(obj.TransferStatus);
                writer.Write(obj.ErrorID);
                writer.Write(obj.ErrorMsg);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询账户信息请求
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpReqQueryAccount
    {
        ///<summary>
        ///业务功能码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string TradeCode;
        ///<summary>
        ///银行代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分支机构代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBranchID;
        ///<summary>
        ///期商代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///期商分支机构代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string BrokerBranchID;
        ///<summary>
        ///交易日期
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeDate;
        ///<summary>
        ///交易时间
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeTime;
        ///<summary>
        ///银行流水号
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string BankSerial;
        ///<summary>
        ///交易系统日期
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///银期平台消息流水号
        ///</summary>
        [DataMember(Order = 10)]
        public int PlateSerial;
        ///<summary>
        ///最后分片标志
        ///</summary>
        [DataMember(Order = 11)]
        public byte LastFragment;
        ///<summary>
        ///会话号
        ///</summary>
        [DataMember(Order = 12)]
        public int SessionID;
        ///<summary>
        ///客户姓名
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string CustomerName;
        ///<summary>
        ///证件类型
        ///</summary>
        [DataMember(Order = 14)]
        public byte IdCardType;
        ///<summary>
        ///证件号码
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string IdentifiedCardNo;
        ///<summary>
        ///客户类型
        ///</summary>
        [DataMember(Order = 16)]
        public byte CustType;
        ///<summary>
        ///银行帐号
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankAccount;
        ///<summary>
        ///银行密码
        ///</summary>
        [DataMember(Order = 18)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankPassWord;
        ///<summary>
        ///投资者帐号
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string AccountID;
        ///<summary>
        ///期货密码
        ///</summary>
        [DataMember(Order = 20)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Password;
        ///<summary>
        ///期货公司流水号
        ///</summary>
        [DataMember(Order = 21)]
        public int FutureSerial;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 22)]
        public int InstallID;
        ///<summary>
        ///用户标识
        ///</summary>
        [DataMember(Order = 23)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///验证客户证件号码标志
        ///</summary>
        [DataMember(Order = 24)]
        public byte VerifyCertNoFlag;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 25)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;
        ///<summary>
        ///摘要
        ///</summary>
        [DataMember(Order = 26)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
        public string Digest;
        ///<summary>
        ///银行帐号类型
        ///</summary>
        [DataMember(Order = 27)]
        public byte BankAccType;
        ///<summary>
        ///渠道标志
        ///</summary>
        [DataMember(Order = 28)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string DeviceID;
        ///<summary>
        ///期货单位帐号类型
        ///</summary>
        [DataMember(Order = 29)]
        public byte BankSecuAccType;
        ///<summary>
        ///期货公司银行编码
        ///</summary>
        [DataMember(Order = 30)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string BrokerIDByBank;
        ///<summary>
        ///期货单位帐号
        ///</summary>
        [DataMember(Order = 31)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankSecuAcc;
        ///<summary>
        ///银行密码标志
        ///</summary>
        [DataMember(Order = 32)]
        public byte BankPwdFlag;
        ///<summary>
        ///期货资金密码核对标志
        ///</summary>
        [DataMember(Order = 33)]
        public byte SecuPwdFlag;
        ///<summary>
        ///交易柜员
        ///</summary>
        [DataMember(Order = 34)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string OperNo;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 35)]
        public int RequestID;
        ///<summary>
        ///交易ID
        ///</summary>
        [DataMember(Order = 36)]
        public int TID;

        public static byte[] GetData(CtpReqQueryAccount obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradeCode);
                writer.Write(obj.BankID);
                writer.Write(obj.BankBranchID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.BrokerBranchID);
                writer.Write(obj.TradeDate);
                writer.Write(obj.TradeTime);
                writer.Write(obj.BankSerial);
                writer.Write(obj.TradingDay);
                writer.Write(obj.PlateSerial);
                writer.Write(obj.LastFragment);
                writer.Write(obj.SessionID);
                writer.Write(obj.CustomerName);
                writer.Write(obj.IdCardType);
                writer.Write(obj.IdentifiedCardNo);
                writer.Write(obj.CustType);
                writer.Write(obj.BankAccount);
                writer.Write(obj.BankPassWord);
                writer.Write(obj.AccountID);
                writer.Write(obj.Password);
                writer.Write(obj.FutureSerial);
                writer.Write(obj.InstallID);
                writer.Write(obj.UserID);
                writer.Write(obj.VerifyCertNoFlag);
                writer.Write(obj.CurrencyID);
                writer.Write(obj.Digest);
                writer.Write(obj.BankAccType);
                writer.Write(obj.DeviceID);
                writer.Write(obj.BankSecuAccType);
                writer.Write(obj.BrokerIDByBank);
                writer.Write(obj.BankSecuAcc);
                writer.Write(obj.BankPwdFlag);
                writer.Write(obj.SecuPwdFlag);
                writer.Write(obj.OperNo);
                writer.Write(obj.RequestID);
                writer.Write(obj.TID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询账户信息响应
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpRspQueryAccount
    {
        ///<summary>
        ///业务功能码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string TradeCode;
        ///<summary>
        ///银行代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分支机构代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBranchID;
        ///<summary>
        ///期商代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///期商分支机构代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string BrokerBranchID;
        ///<summary>
        ///交易日期
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeDate;
        ///<summary>
        ///交易时间
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeTime;
        ///<summary>
        ///银行流水号
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string BankSerial;
        ///<summary>
        ///交易系统日期
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///银期平台消息流水号
        ///</summary>
        [DataMember(Order = 10)]
        public int PlateSerial;
        ///<summary>
        ///最后分片标志
        ///</summary>
        [DataMember(Order = 11)]
        public byte LastFragment;
        ///<summary>
        ///会话号
        ///</summary>
        [DataMember(Order = 12)]
        public int SessionID;
        ///<summary>
        ///客户姓名
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string CustomerName;
        ///<summary>
        ///证件类型
        ///</summary>
        [DataMember(Order = 14)]
        public byte IdCardType;
        ///<summary>
        ///证件号码
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string IdentifiedCardNo;
        ///<summary>
        ///客户类型
        ///</summary>
        [DataMember(Order = 16)]
        public byte CustType;
        ///<summary>
        ///银行帐号
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankAccount;
        ///<summary>
        ///银行密码
        ///</summary>
        [DataMember(Order = 18)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankPassWord;
        ///<summary>
        ///投资者帐号
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string AccountID;
        ///<summary>
        ///期货密码
        ///</summary>
        [DataMember(Order = 20)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Password;
        ///<summary>
        ///期货公司流水号
        ///</summary>
        [DataMember(Order = 21)]
        public int FutureSerial;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 22)]
        public int InstallID;
        ///<summary>
        ///用户标识
        ///</summary>
        [DataMember(Order = 23)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///验证客户证件号码标志
        ///</summary>
        [DataMember(Order = 24)]
        public byte VerifyCertNoFlag;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 25)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;
        ///<summary>
        ///摘要
        ///</summary>
        [DataMember(Order = 26)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
        public string Digest;
        ///<summary>
        ///银行帐号类型
        ///</summary>
        [DataMember(Order = 27)]
        public byte BankAccType;
        ///<summary>
        ///渠道标志
        ///</summary>
        [DataMember(Order = 28)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string DeviceID;
        ///<summary>
        ///期货单位帐号类型
        ///</summary>
        [DataMember(Order = 29)]
        public byte BankSecuAccType;
        ///<summary>
        ///期货公司银行编码
        ///</summary>
        [DataMember(Order = 30)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string BrokerIDByBank;
        ///<summary>
        ///期货单位帐号
        ///</summary>
        [DataMember(Order = 31)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankSecuAcc;
        ///<summary>
        ///银行密码标志
        ///</summary>
        [DataMember(Order = 32)]
        public byte BankPwdFlag;
        ///<summary>
        ///期货资金密码核对标志
        ///</summary>
        [DataMember(Order = 33)]
        public byte SecuPwdFlag;
        ///<summary>
        ///交易柜员
        ///</summary>
        [DataMember(Order = 34)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string OperNo;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 35)]
        public int RequestID;
        ///<summary>
        ///交易ID
        ///</summary>
        [DataMember(Order = 36)]
        public int TID;
        ///<summary>
        ///银行可用金额
        ///</summary>
        [DataMember(Order = 37)]
        public double BankUseAmount;
        ///<summary>
        ///银行可取金额
        ///</summary>
        [DataMember(Order = 38)]
        public double BankFetchAmount;

        public static byte[] GetData(CtpRspQueryAccount obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradeCode);
                writer.Write(obj.BankID);
                writer.Write(obj.BankBranchID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.BrokerBranchID);
                writer.Write(obj.TradeDate);
                writer.Write(obj.TradeTime);
                writer.Write(obj.BankSerial);
                writer.Write(obj.TradingDay);
                writer.Write(obj.PlateSerial);
                writer.Write(obj.LastFragment);
                writer.Write(obj.SessionID);
                writer.Write(obj.CustomerName);
                writer.Write(obj.IdCardType);
                writer.Write(obj.IdentifiedCardNo);
                writer.Write(obj.CustType);
                writer.Write(obj.BankAccount);
                writer.Write(obj.BankPassWord);
                writer.Write(obj.AccountID);
                writer.Write(obj.Password);
                writer.Write(obj.FutureSerial);
                writer.Write(obj.InstallID);
                writer.Write(obj.UserID);
                writer.Write(obj.VerifyCertNoFlag);
                writer.Write(obj.CurrencyID);
                writer.Write(obj.Digest);
                writer.Write(obj.BankAccType);
                writer.Write(obj.DeviceID);
                writer.Write(obj.BankSecuAccType);
                writer.Write(obj.BrokerIDByBank);
                writer.Write(obj.BankSecuAcc);
                writer.Write(obj.BankPwdFlag);
                writer.Write(obj.SecuPwdFlag);
                writer.Write(obj.OperNo);
                writer.Write(obj.RequestID);
                writer.Write(obj.TID);
                writer.Write(obj.BankUseAmount);
                writer.Write(obj.BankFetchAmount);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///期商签到签退
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpFutureSignIO
    {
        ///<summary>
        ///业务功能码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string TradeCode;
        ///<summary>
        ///银行代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分支机构代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBranchID;
        ///<summary>
        ///期商代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///期商分支机构代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string BrokerBranchID;
        ///<summary>
        ///交易日期
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeDate;
        ///<summary>
        ///交易时间
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeTime;
        ///<summary>
        ///银行流水号
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string BankSerial;
        ///<summary>
        ///交易系统日期
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///银期平台消息流水号
        ///</summary>
        [DataMember(Order = 10)]
        public int PlateSerial;
        ///<summary>
        ///最后分片标志
        ///</summary>
        [DataMember(Order = 11)]
        public byte LastFragment;
        ///<summary>
        ///会话号
        ///</summary>
        [DataMember(Order = 12)]
        public int SessionID;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 13)]
        public int InstallID;
        ///<summary>
        ///用户标识
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///摘要
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
        public string Digest;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 16)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;
        ///<summary>
        ///渠道标志
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string DeviceID;
        ///<summary>
        ///期货公司银行编码
        ///</summary>
        [DataMember(Order = 18)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string BrokerIDByBank;
        ///<summary>
        ///交易柜员
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string OperNo;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 20)]
        public int RequestID;
        ///<summary>
        ///交易ID
        ///</summary>
        [DataMember(Order = 21)]
        public int TID;

        public static byte[] GetData(CtpFutureSignIO obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradeCode);
                writer.Write(obj.BankID);
                writer.Write(obj.BankBranchID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.BrokerBranchID);
                writer.Write(obj.TradeDate);
                writer.Write(obj.TradeTime);
                writer.Write(obj.BankSerial);
                writer.Write(obj.TradingDay);
                writer.Write(obj.PlateSerial);
                writer.Write(obj.LastFragment);
                writer.Write(obj.SessionID);
                writer.Write(obj.InstallID);
                writer.Write(obj.UserID);
                writer.Write(obj.Digest);
                writer.Write(obj.CurrencyID);
                writer.Write(obj.DeviceID);
                writer.Write(obj.BrokerIDByBank);
                writer.Write(obj.OperNo);
                writer.Write(obj.RequestID);
                writer.Write(obj.TID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///期商签到响应
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpRspFutureSignIn
    {
        ///<summary>
        ///业务功能码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string TradeCode;
        ///<summary>
        ///银行代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分支机构代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBranchID;
        ///<summary>
        ///期商代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///期商分支机构代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string BrokerBranchID;
        ///<summary>
        ///交易日期
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeDate;
        ///<summary>
        ///交易时间
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeTime;
        ///<summary>
        ///银行流水号
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string BankSerial;
        ///<summary>
        ///交易系统日期
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///银期平台消息流水号
        ///</summary>
        [DataMember(Order = 10)]
        public int PlateSerial;
        ///<summary>
        ///最后分片标志
        ///</summary>
        [DataMember(Order = 11)]
        public byte LastFragment;
        ///<summary>
        ///会话号
        ///</summary>
        [DataMember(Order = 12)]
        public int SessionID;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 13)]
        public int InstallID;
        ///<summary>
        ///用户标识
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///摘要
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
        public string Digest;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 16)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;
        ///<summary>
        ///渠道标志
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string DeviceID;
        ///<summary>
        ///期货公司银行编码
        ///</summary>
        [DataMember(Order = 18)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string BrokerIDByBank;
        ///<summary>
        ///交易柜员
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string OperNo;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 20)]
        public int RequestID;
        ///<summary>
        ///交易ID
        ///</summary>
        [DataMember(Order = 21)]
        public int TID;
        ///<summary>
        ///错误代码
        ///</summary>
        [DataMember(Order = 22)]
        public int ErrorID;
        ///<summary>
        ///错误信息
        ///</summary>
        [DataMember(Order = 23)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string ErrorMsg;
        ///<summary>
        ///PIN密钥
        ///</summary>
        [DataMember(Order = 24)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string PinKey;
        ///<summary>
        ///MAC密钥
        ///</summary>
        [DataMember(Order = 25)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string MacKey;

        public static byte[] GetData(CtpRspFutureSignIn obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradeCode);
                writer.Write(obj.BankID);
                writer.Write(obj.BankBranchID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.BrokerBranchID);
                writer.Write(obj.TradeDate);
                writer.Write(obj.TradeTime);
                writer.Write(obj.BankSerial);
                writer.Write(obj.TradingDay);
                writer.Write(obj.PlateSerial);
                writer.Write(obj.LastFragment);
                writer.Write(obj.SessionID);
                writer.Write(obj.InstallID);
                writer.Write(obj.UserID);
                writer.Write(obj.Digest);
                writer.Write(obj.CurrencyID);
                writer.Write(obj.DeviceID);
                writer.Write(obj.BrokerIDByBank);
                writer.Write(obj.OperNo);
                writer.Write(obj.RequestID);
                writer.Write(obj.TID);
                writer.Write(obj.ErrorID);
                writer.Write(obj.ErrorMsg);
                writer.Write(obj.PinKey);
                writer.Write(obj.MacKey);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///期商签退请求
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpReqFutureSignOut
    {
        ///<summary>
        ///业务功能码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string TradeCode;
        ///<summary>
        ///银行代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分支机构代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBranchID;
        ///<summary>
        ///期商代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///期商分支机构代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string BrokerBranchID;
        ///<summary>
        ///交易日期
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeDate;
        ///<summary>
        ///交易时间
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeTime;
        ///<summary>
        ///银行流水号
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string BankSerial;
        ///<summary>
        ///交易系统日期
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///银期平台消息流水号
        ///</summary>
        [DataMember(Order = 10)]
        public int PlateSerial;
        ///<summary>
        ///最后分片标志
        ///</summary>
        [DataMember(Order = 11)]
        public byte LastFragment;
        ///<summary>
        ///会话号
        ///</summary>
        [DataMember(Order = 12)]
        public int SessionID;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 13)]
        public int InstallID;
        ///<summary>
        ///用户标识
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///摘要
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
        public string Digest;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 16)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;
        ///<summary>
        ///渠道标志
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string DeviceID;
        ///<summary>
        ///期货公司银行编码
        ///</summary>
        [DataMember(Order = 18)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string BrokerIDByBank;
        ///<summary>
        ///交易柜员
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string OperNo;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 20)]
        public int RequestID;
        ///<summary>
        ///交易ID
        ///</summary>
        [DataMember(Order = 21)]
        public int TID;

        public static byte[] GetData(CtpReqFutureSignOut obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradeCode);
                writer.Write(obj.BankID);
                writer.Write(obj.BankBranchID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.BrokerBranchID);
                writer.Write(obj.TradeDate);
                writer.Write(obj.TradeTime);
                writer.Write(obj.BankSerial);
                writer.Write(obj.TradingDay);
                writer.Write(obj.PlateSerial);
                writer.Write(obj.LastFragment);
                writer.Write(obj.SessionID);
                writer.Write(obj.InstallID);
                writer.Write(obj.UserID);
                writer.Write(obj.Digest);
                writer.Write(obj.CurrencyID);
                writer.Write(obj.DeviceID);
                writer.Write(obj.BrokerIDByBank);
                writer.Write(obj.OperNo);
                writer.Write(obj.RequestID);
                writer.Write(obj.TID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///期商签退响应
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpRspFutureSignOut
    {
        ///<summary>
        ///业务功能码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string TradeCode;
        ///<summary>
        ///银行代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分支机构代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBranchID;
        ///<summary>
        ///期商代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///期商分支机构代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string BrokerBranchID;
        ///<summary>
        ///交易日期
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeDate;
        ///<summary>
        ///交易时间
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeTime;
        ///<summary>
        ///银行流水号
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string BankSerial;
        ///<summary>
        ///交易系统日期
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///银期平台消息流水号
        ///</summary>
        [DataMember(Order = 10)]
        public int PlateSerial;
        ///<summary>
        ///最后分片标志
        ///</summary>
        [DataMember(Order = 11)]
        public byte LastFragment;
        ///<summary>
        ///会话号
        ///</summary>
        [DataMember(Order = 12)]
        public int SessionID;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 13)]
        public int InstallID;
        ///<summary>
        ///用户标识
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///摘要
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
        public string Digest;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 16)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;
        ///<summary>
        ///渠道标志
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string DeviceID;
        ///<summary>
        ///期货公司银行编码
        ///</summary>
        [DataMember(Order = 18)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string BrokerIDByBank;
        ///<summary>
        ///交易柜员
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string OperNo;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 20)]
        public int RequestID;
        ///<summary>
        ///交易ID
        ///</summary>
        [DataMember(Order = 21)]
        public int TID;
        ///<summary>
        ///错误代码
        ///</summary>
        [DataMember(Order = 22)]
        public int ErrorID;
        ///<summary>
        ///错误信息
        ///</summary>
        [DataMember(Order = 23)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string ErrorMsg;

        public static byte[] GetData(CtpRspFutureSignOut obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradeCode);
                writer.Write(obj.BankID);
                writer.Write(obj.BankBranchID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.BrokerBranchID);
                writer.Write(obj.TradeDate);
                writer.Write(obj.TradeTime);
                writer.Write(obj.BankSerial);
                writer.Write(obj.TradingDay);
                writer.Write(obj.PlateSerial);
                writer.Write(obj.LastFragment);
                writer.Write(obj.SessionID);
                writer.Write(obj.InstallID);
                writer.Write(obj.UserID);
                writer.Write(obj.Digest);
                writer.Write(obj.CurrencyID);
                writer.Write(obj.DeviceID);
                writer.Write(obj.BrokerIDByBank);
                writer.Write(obj.OperNo);
                writer.Write(obj.RequestID);
                writer.Write(obj.TID);
                writer.Write(obj.ErrorID);
                writer.Write(obj.ErrorMsg);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询指定流水号的交易结果请求
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpReqQueryTradeResultBySerial
    {
        ///<summary>
        ///业务功能码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string TradeCode;
        ///<summary>
        ///银行代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分支机构代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBranchID;
        ///<summary>
        ///期商代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///期商分支机构代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string BrokerBranchID;
        ///<summary>
        ///交易日期
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeDate;
        ///<summary>
        ///交易时间
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeTime;
        ///<summary>
        ///银行流水号
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string BankSerial;
        ///<summary>
        ///交易系统日期
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///银期平台消息流水号
        ///</summary>
        [DataMember(Order = 10)]
        public int PlateSerial;
        ///<summary>
        ///最后分片标志
        ///</summary>
        [DataMember(Order = 11)]
        public byte LastFragment;
        ///<summary>
        ///会话号
        ///</summary>
        [DataMember(Order = 12)]
        public int SessionID;
        ///<summary>
        ///流水号
        ///</summary>
        [DataMember(Order = 13)]
        public int Reference;
        ///<summary>
        ///本流水号发布者的机构类型
        ///</summary>
        [DataMember(Order = 14)]
        public byte RefrenceIssureType;
        ///<summary>
        ///本流水号发布者机构编码
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
        public string RefrenceIssure;
        ///<summary>
        ///客户姓名
        ///</summary>
        [DataMember(Order = 16)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string CustomerName;
        ///<summary>
        ///证件类型
        ///</summary>
        [DataMember(Order = 17)]
        public byte IdCardType;
        ///<summary>
        ///证件号码
        ///</summary>
        [DataMember(Order = 18)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string IdentifiedCardNo;
        ///<summary>
        ///客户类型
        ///</summary>
        [DataMember(Order = 19)]
        public byte CustType;
        ///<summary>
        ///银行帐号
        ///</summary>
        [DataMember(Order = 20)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankAccount;
        ///<summary>
        ///银行密码
        ///</summary>
        [DataMember(Order = 21)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankPassWord;
        ///<summary>
        ///投资者帐号
        ///</summary>
        [DataMember(Order = 22)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string AccountID;
        ///<summary>
        ///期货密码
        ///</summary>
        [DataMember(Order = 23)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Password;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 24)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;
        ///<summary>
        ///转帐金额
        ///</summary>
        [DataMember(Order = 25)]
        public double TradeAmount;
        ///<summary>
        ///摘要
        ///</summary>
        [DataMember(Order = 26)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
        public string Digest;

        public static byte[] GetData(CtpReqQueryTradeResultBySerial obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradeCode);
                writer.Write(obj.BankID);
                writer.Write(obj.BankBranchID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.BrokerBranchID);
                writer.Write(obj.TradeDate);
                writer.Write(obj.TradeTime);
                writer.Write(obj.BankSerial);
                writer.Write(obj.TradingDay);
                writer.Write(obj.PlateSerial);
                writer.Write(obj.LastFragment);
                writer.Write(obj.SessionID);
                writer.Write(obj.Reference);
                writer.Write(obj.RefrenceIssureType);
                writer.Write(obj.RefrenceIssure);
                writer.Write(obj.CustomerName);
                writer.Write(obj.IdCardType);
                writer.Write(obj.IdentifiedCardNo);
                writer.Write(obj.CustType);
                writer.Write(obj.BankAccount);
                writer.Write(obj.BankPassWord);
                writer.Write(obj.AccountID);
                writer.Write(obj.Password);
                writer.Write(obj.CurrencyID);
                writer.Write(obj.TradeAmount);
                writer.Write(obj.Digest);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询指定流水号的交易结果响应
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpRspQueryTradeResultBySerial
    {
        ///<summary>
        ///业务功能码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string TradeCode;
        ///<summary>
        ///银行代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分支机构代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBranchID;
        ///<summary>
        ///期商代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///期商分支机构代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string BrokerBranchID;
        ///<summary>
        ///交易日期
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeDate;
        ///<summary>
        ///交易时间
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeTime;
        ///<summary>
        ///银行流水号
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string BankSerial;
        ///<summary>
        ///交易系统日期
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///银期平台消息流水号
        ///</summary>
        [DataMember(Order = 10)]
        public int PlateSerial;
        ///<summary>
        ///最后分片标志
        ///</summary>
        [DataMember(Order = 11)]
        public byte LastFragment;
        ///<summary>
        ///会话号
        ///</summary>
        [DataMember(Order = 12)]
        public int SessionID;
        ///<summary>
        ///错误代码
        ///</summary>
        [DataMember(Order = 13)]
        public int ErrorID;
        ///<summary>
        ///错误信息
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string ErrorMsg;
        ///<summary>
        ///流水号
        ///</summary>
        [DataMember(Order = 15)]
        public int Reference;
        ///<summary>
        ///本流水号发布者的机构类型
        ///</summary>
        [DataMember(Order = 16)]
        public byte RefrenceIssureType;
        ///<summary>
        ///本流水号发布者机构编码
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
        public string RefrenceIssure;
        ///<summary>
        ///原始返回代码
        ///</summary>
        [DataMember(Order = 18)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string OriginReturnCode;
        ///<summary>
        ///原始返回码描述
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string OriginDescrInfoForReturnCode;
        ///<summary>
        ///银行帐号
        ///</summary>
        [DataMember(Order = 20)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankAccount;
        ///<summary>
        ///银行密码
        ///</summary>
        [DataMember(Order = 21)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankPassWord;
        ///<summary>
        ///投资者帐号
        ///</summary>
        [DataMember(Order = 22)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string AccountID;
        ///<summary>
        ///期货密码
        ///</summary>
        [DataMember(Order = 23)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Password;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 24)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;
        ///<summary>
        ///转帐金额
        ///</summary>
        [DataMember(Order = 25)]
        public double TradeAmount;
        ///<summary>
        ///摘要
        ///</summary>
        [DataMember(Order = 26)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
        public string Digest;

        public static byte[] GetData(CtpRspQueryTradeResultBySerial obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradeCode);
                writer.Write(obj.BankID);
                writer.Write(obj.BankBranchID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.BrokerBranchID);
                writer.Write(obj.TradeDate);
                writer.Write(obj.TradeTime);
                writer.Write(obj.BankSerial);
                writer.Write(obj.TradingDay);
                writer.Write(obj.PlateSerial);
                writer.Write(obj.LastFragment);
                writer.Write(obj.SessionID);
                writer.Write(obj.ErrorID);
                writer.Write(obj.ErrorMsg);
                writer.Write(obj.Reference);
                writer.Write(obj.RefrenceIssureType);
                writer.Write(obj.RefrenceIssure);
                writer.Write(obj.OriginReturnCode);
                writer.Write(obj.OriginDescrInfoForReturnCode);
                writer.Write(obj.BankAccount);
                writer.Write(obj.BankPassWord);
                writer.Write(obj.AccountID);
                writer.Write(obj.Password);
                writer.Write(obj.CurrencyID);
                writer.Write(obj.TradeAmount);
                writer.Write(obj.Digest);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///日终文件就绪请求
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpReqDayEndFileReady
    {
        ///<summary>
        ///业务功能码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string TradeCode;
        ///<summary>
        ///银行代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分支机构代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBranchID;
        ///<summary>
        ///期商代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///期商分支机构代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string BrokerBranchID;
        ///<summary>
        ///交易日期
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeDate;
        ///<summary>
        ///交易时间
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeTime;
        ///<summary>
        ///银行流水号
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string BankSerial;
        ///<summary>
        ///交易系统日期
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///银期平台消息流水号
        ///</summary>
        [DataMember(Order = 10)]
        public int PlateSerial;
        ///<summary>
        ///最后分片标志
        ///</summary>
        [DataMember(Order = 11)]
        public byte LastFragment;
        ///<summary>
        ///会话号
        ///</summary>
        [DataMember(Order = 12)]
        public int SessionID;
        ///<summary>
        ///文件业务功能
        ///</summary>
        [DataMember(Order = 13)]
        public byte FileBusinessCode;
        ///<summary>
        ///摘要
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
        public string Digest;

        public static byte[] GetData(CtpReqDayEndFileReady obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradeCode);
                writer.Write(obj.BankID);
                writer.Write(obj.BankBranchID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.BrokerBranchID);
                writer.Write(obj.TradeDate);
                writer.Write(obj.TradeTime);
                writer.Write(obj.BankSerial);
                writer.Write(obj.TradingDay);
                writer.Write(obj.PlateSerial);
                writer.Write(obj.LastFragment);
                writer.Write(obj.SessionID);
                writer.Write(obj.FileBusinessCode);
                writer.Write(obj.Digest);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///返回结果
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpReturnResult
    {
        ///<summary>
        ///返回代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string ReturnCode;
        ///<summary>
        ///返回码描述
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string DescrInfoForReturnCode;

        public static byte[] GetData(CtpReturnResult obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.ReturnCode);
                writer.Write(obj.DescrInfoForReturnCode);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///验证期货资金密码
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpVerifyFuturePassword
    {
        ///<summary>
        ///业务功能码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string TradeCode;
        ///<summary>
        ///银行代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分支机构代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBranchID;
        ///<summary>
        ///期商代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///期商分支机构代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string BrokerBranchID;
        ///<summary>
        ///交易日期
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeDate;
        ///<summary>
        ///交易时间
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeTime;
        ///<summary>
        ///银行流水号
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string BankSerial;
        ///<summary>
        ///交易系统日期
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///银期平台消息流水号
        ///</summary>
        [DataMember(Order = 10)]
        public int PlateSerial;
        ///<summary>
        ///最后分片标志
        ///</summary>
        [DataMember(Order = 11)]
        public byte LastFragment;
        ///<summary>
        ///会话号
        ///</summary>
        [DataMember(Order = 12)]
        public int SessionID;
        ///<summary>
        ///投资者帐号
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string AccountID;
        ///<summary>
        ///期货密码
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Password;
        ///<summary>
        ///银行帐号
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankAccount;
        ///<summary>
        ///银行密码
        ///</summary>
        [DataMember(Order = 16)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankPassWord;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 17)]
        public int InstallID;
        ///<summary>
        ///交易ID
        ///</summary>
        [DataMember(Order = 18)]
        public int TID;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;

        public static byte[] GetData(CtpVerifyFuturePassword obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradeCode);
                writer.Write(obj.BankID);
                writer.Write(obj.BankBranchID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.BrokerBranchID);
                writer.Write(obj.TradeDate);
                writer.Write(obj.TradeTime);
                writer.Write(obj.BankSerial);
                writer.Write(obj.TradingDay);
                writer.Write(obj.PlateSerial);
                writer.Write(obj.LastFragment);
                writer.Write(obj.SessionID);
                writer.Write(obj.AccountID);
                writer.Write(obj.Password);
                writer.Write(obj.BankAccount);
                writer.Write(obj.BankPassWord);
                writer.Write(obj.InstallID);
                writer.Write(obj.TID);
                writer.Write(obj.CurrencyID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///验证客户信息
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpVerifyCustInfo
    {
        ///<summary>
        ///客户姓名
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string CustomerName;
        ///<summary>
        ///证件类型
        ///</summary>
        [DataMember(Order = 2)]
        public byte IdCardType;
        ///<summary>
        ///证件号码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string IdentifiedCardNo;
        ///<summary>
        ///客户类型
        ///</summary>
        [DataMember(Order = 4)]
        public byte CustType;

        public static byte[] GetData(CtpVerifyCustInfo obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.CustomerName);
                writer.Write(obj.IdCardType);
                writer.Write(obj.IdentifiedCardNo);
                writer.Write(obj.CustType);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///验证期货资金密码和客户信息
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpVerifyFuturePasswordAndCustInfo
    {
        ///<summary>
        ///客户姓名
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string CustomerName;
        ///<summary>
        ///证件类型
        ///</summary>
        [DataMember(Order = 2)]
        public byte IdCardType;
        ///<summary>
        ///证件号码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string IdentifiedCardNo;
        ///<summary>
        ///客户类型
        ///</summary>
        [DataMember(Order = 4)]
        public byte CustType;
        ///<summary>
        ///投资者帐号
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string AccountID;
        ///<summary>
        ///期货密码
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Password;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;

        public static byte[] GetData(CtpVerifyFuturePasswordAndCustInfo obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.CustomerName);
                writer.Write(obj.IdCardType);
                writer.Write(obj.IdentifiedCardNo);
                writer.Write(obj.CustType);
                writer.Write(obj.AccountID);
                writer.Write(obj.Password);
                writer.Write(obj.CurrencyID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///验证期货资金密码和客户信息
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpDepositResultInform
    {
        ///<summary>
        ///出入金流水号，该流水号为银期报盘返回的流水号
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
        public string DepositSeqNo;
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///入金金额
        ///</summary>
        [DataMember(Order = 4)]
        public double Deposit;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 5)]
        public int RequestID;
        ///<summary>
        ///返回代码
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string ReturnCode;
        ///<summary>
        ///返回码描述
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string DescrInfoForReturnCode;

        public static byte[] GetData(CtpDepositResultInform obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.DepositSeqNo);
                writer.Write(obj.BrokerID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.Deposit);
                writer.Write(obj.RequestID);
                writer.Write(obj.ReturnCode);
                writer.Write(obj.DescrInfoForReturnCode);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///交易核心向银期报盘发出密钥同步请求
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpReqSyncKey
    {
        ///<summary>
        ///业务功能码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string TradeCode;
        ///<summary>
        ///银行代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分支机构代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBranchID;
        ///<summary>
        ///期商代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///期商分支机构代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string BrokerBranchID;
        ///<summary>
        ///交易日期
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeDate;
        ///<summary>
        ///交易时间
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeTime;
        ///<summary>
        ///银行流水号
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string BankSerial;
        ///<summary>
        ///交易系统日期
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///银期平台消息流水号
        ///</summary>
        [DataMember(Order = 10)]
        public int PlateSerial;
        ///<summary>
        ///最后分片标志
        ///</summary>
        [DataMember(Order = 11)]
        public byte LastFragment;
        ///<summary>
        ///会话号
        ///</summary>
        [DataMember(Order = 12)]
        public int SessionID;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 13)]
        public int InstallID;
        ///<summary>
        ///用户标识
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///交易核心给银期报盘的消息
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string Message;
        ///<summary>
        ///渠道标志
        ///</summary>
        [DataMember(Order = 16)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string DeviceID;
        ///<summary>
        ///期货公司银行编码
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string BrokerIDByBank;
        ///<summary>
        ///交易柜员
        ///</summary>
        [DataMember(Order = 18)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string OperNo;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 19)]
        public int RequestID;
        ///<summary>
        ///交易ID
        ///</summary>
        [DataMember(Order = 20)]
        public int TID;

        public static byte[] GetData(CtpReqSyncKey obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradeCode);
                writer.Write(obj.BankID);
                writer.Write(obj.BankBranchID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.BrokerBranchID);
                writer.Write(obj.TradeDate);
                writer.Write(obj.TradeTime);
                writer.Write(obj.BankSerial);
                writer.Write(obj.TradingDay);
                writer.Write(obj.PlateSerial);
                writer.Write(obj.LastFragment);
                writer.Write(obj.SessionID);
                writer.Write(obj.InstallID);
                writer.Write(obj.UserID);
                writer.Write(obj.Message);
                writer.Write(obj.DeviceID);
                writer.Write(obj.BrokerIDByBank);
                writer.Write(obj.OperNo);
                writer.Write(obj.RequestID);
                writer.Write(obj.TID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///交易核心向银期报盘发出密钥同步响应
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpRspSyncKey
    {
        ///<summary>
        ///业务功能码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string TradeCode;
        ///<summary>
        ///银行代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分支机构代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBranchID;
        ///<summary>
        ///期商代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///期商分支机构代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string BrokerBranchID;
        ///<summary>
        ///交易日期
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeDate;
        ///<summary>
        ///交易时间
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeTime;
        ///<summary>
        ///银行流水号
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string BankSerial;
        ///<summary>
        ///交易系统日期
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///银期平台消息流水号
        ///</summary>
        [DataMember(Order = 10)]
        public int PlateSerial;
        ///<summary>
        ///最后分片标志
        ///</summary>
        [DataMember(Order = 11)]
        public byte LastFragment;
        ///<summary>
        ///会话号
        ///</summary>
        [DataMember(Order = 12)]
        public int SessionID;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 13)]
        public int InstallID;
        ///<summary>
        ///用户标识
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///交易核心给银期报盘的消息
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string Message;
        ///<summary>
        ///渠道标志
        ///</summary>
        [DataMember(Order = 16)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string DeviceID;
        ///<summary>
        ///期货公司银行编码
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string BrokerIDByBank;
        ///<summary>
        ///交易柜员
        ///</summary>
        [DataMember(Order = 18)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string OperNo;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 19)]
        public int RequestID;
        ///<summary>
        ///交易ID
        ///</summary>
        [DataMember(Order = 20)]
        public int TID;
        ///<summary>
        ///错误代码
        ///</summary>
        [DataMember(Order = 21)]
        public int ErrorID;
        ///<summary>
        ///错误信息
        ///</summary>
        [DataMember(Order = 22)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string ErrorMsg;

        public static byte[] GetData(CtpRspSyncKey obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradeCode);
                writer.Write(obj.BankID);
                writer.Write(obj.BankBranchID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.BrokerBranchID);
                writer.Write(obj.TradeDate);
                writer.Write(obj.TradeTime);
                writer.Write(obj.BankSerial);
                writer.Write(obj.TradingDay);
                writer.Write(obj.PlateSerial);
                writer.Write(obj.LastFragment);
                writer.Write(obj.SessionID);
                writer.Write(obj.InstallID);
                writer.Write(obj.UserID);
                writer.Write(obj.Message);
                writer.Write(obj.DeviceID);
                writer.Write(obj.BrokerIDByBank);
                writer.Write(obj.OperNo);
                writer.Write(obj.RequestID);
                writer.Write(obj.TID);
                writer.Write(obj.ErrorID);
                writer.Write(obj.ErrorMsg);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询账户信息通知
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpNotifyQueryAccount
    {
        ///<summary>
        ///业务功能码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string TradeCode;
        ///<summary>
        ///银行代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分支机构代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBranchID;
        ///<summary>
        ///期商代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///期商分支机构代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string BrokerBranchID;
        ///<summary>
        ///交易日期
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeDate;
        ///<summary>
        ///交易时间
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeTime;
        ///<summary>
        ///银行流水号
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string BankSerial;
        ///<summary>
        ///交易系统日期
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///银期平台消息流水号
        ///</summary>
        [DataMember(Order = 10)]
        public int PlateSerial;
        ///<summary>
        ///最后分片标志
        ///</summary>
        [DataMember(Order = 11)]
        public byte LastFragment;
        ///<summary>
        ///会话号
        ///</summary>
        [DataMember(Order = 12)]
        public int SessionID;
        ///<summary>
        ///客户姓名
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string CustomerName;
        ///<summary>
        ///证件类型
        ///</summary>
        [DataMember(Order = 14)]
        public byte IdCardType;
        ///<summary>
        ///证件号码
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string IdentifiedCardNo;
        ///<summary>
        ///客户类型
        ///</summary>
        [DataMember(Order = 16)]
        public byte CustType;
        ///<summary>
        ///银行帐号
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankAccount;
        ///<summary>
        ///银行密码
        ///</summary>
        [DataMember(Order = 18)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankPassWord;
        ///<summary>
        ///投资者帐号
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string AccountID;
        ///<summary>
        ///期货密码
        ///</summary>
        [DataMember(Order = 20)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Password;
        ///<summary>
        ///期货公司流水号
        ///</summary>
        [DataMember(Order = 21)]
        public int FutureSerial;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 22)]
        public int InstallID;
        ///<summary>
        ///用户标识
        ///</summary>
        [DataMember(Order = 23)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///验证客户证件号码标志
        ///</summary>
        [DataMember(Order = 24)]
        public byte VerifyCertNoFlag;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 25)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;
        ///<summary>
        ///摘要
        ///</summary>
        [DataMember(Order = 26)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
        public string Digest;
        ///<summary>
        ///银行帐号类型
        ///</summary>
        [DataMember(Order = 27)]
        public byte BankAccType;
        ///<summary>
        ///渠道标志
        ///</summary>
        [DataMember(Order = 28)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string DeviceID;
        ///<summary>
        ///期货单位帐号类型
        ///</summary>
        [DataMember(Order = 29)]
        public byte BankSecuAccType;
        ///<summary>
        ///期货公司银行编码
        ///</summary>
        [DataMember(Order = 30)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string BrokerIDByBank;
        ///<summary>
        ///期货单位帐号
        ///</summary>
        [DataMember(Order = 31)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankSecuAcc;
        ///<summary>
        ///银行密码标志
        ///</summary>
        [DataMember(Order = 32)]
        public byte BankPwdFlag;
        ///<summary>
        ///期货资金密码核对标志
        ///</summary>
        [DataMember(Order = 33)]
        public byte SecuPwdFlag;
        ///<summary>
        ///交易柜员
        ///</summary>
        [DataMember(Order = 34)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string OperNo;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 35)]
        public int RequestID;
        ///<summary>
        ///交易ID
        ///</summary>
        [DataMember(Order = 36)]
        public int TID;
        ///<summary>
        ///银行可用金额
        ///</summary>
        [DataMember(Order = 37)]
        public double BankUseAmount;
        ///<summary>
        ///银行可取金额
        ///</summary>
        [DataMember(Order = 38)]
        public double BankFetchAmount;
        ///<summary>
        ///错误代码
        ///</summary>
        [DataMember(Order = 39)]
        public int ErrorID;
        ///<summary>
        ///错误信息
        ///</summary>
        [DataMember(Order = 40)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string ErrorMsg;

        public static byte[] GetData(CtpNotifyQueryAccount obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradeCode);
                writer.Write(obj.BankID);
                writer.Write(obj.BankBranchID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.BrokerBranchID);
                writer.Write(obj.TradeDate);
                writer.Write(obj.TradeTime);
                writer.Write(obj.BankSerial);
                writer.Write(obj.TradingDay);
                writer.Write(obj.PlateSerial);
                writer.Write(obj.LastFragment);
                writer.Write(obj.SessionID);
                writer.Write(obj.CustomerName);
                writer.Write(obj.IdCardType);
                writer.Write(obj.IdentifiedCardNo);
                writer.Write(obj.CustType);
                writer.Write(obj.BankAccount);
                writer.Write(obj.BankPassWord);
                writer.Write(obj.AccountID);
                writer.Write(obj.Password);
                writer.Write(obj.FutureSerial);
                writer.Write(obj.InstallID);
                writer.Write(obj.UserID);
                writer.Write(obj.VerifyCertNoFlag);
                writer.Write(obj.CurrencyID);
                writer.Write(obj.Digest);
                writer.Write(obj.BankAccType);
                writer.Write(obj.DeviceID);
                writer.Write(obj.BankSecuAccType);
                writer.Write(obj.BrokerIDByBank);
                writer.Write(obj.BankSecuAcc);
                writer.Write(obj.BankPwdFlag);
                writer.Write(obj.SecuPwdFlag);
                writer.Write(obj.OperNo);
                writer.Write(obj.RequestID);
                writer.Write(obj.TID);
                writer.Write(obj.BankUseAmount);
                writer.Write(obj.BankFetchAmount);
                writer.Write(obj.ErrorID);
                writer.Write(obj.ErrorMsg);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///银期转账交易流水表
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpTransferSerial
    {
        ///<summary>
        ///平台流水号
        ///</summary>
        [DataMember(Order = 1)]
        public int PlateSerial;
        ///<summary>
        ///交易发起方日期
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeDate;
        ///<summary>
        ///交易日期
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///交易时间
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeTime;
        ///<summary>
        ///交易代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string TradeCode;
        ///<summary>
        ///会话编号
        ///</summary>
        [DataMember(Order = 6)]
        public int SessionID;
        ///<summary>
        ///银行编码
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分支机构编码
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBranchID;
        ///<summary>
        ///银行帐号类型
        ///</summary>
        [DataMember(Order = 9)]
        public byte BankAccType;
        ///<summary>
        ///银行帐号
        ///</summary>
        [DataMember(Order = 10)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankAccount;
        ///<summary>
        ///银行流水号
        ///</summary>
        [DataMember(Order = 11)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string BankSerial;
        ///<summary>
        ///期货公司编码
        ///</summary>
        [DataMember(Order = 12)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///期商分支机构代码
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string BrokerBranchID;
        ///<summary>
        ///期货公司帐号类型
        ///</summary>
        [DataMember(Order = 14)]
        public byte FutureAccType;
        ///<summary>
        ///投资者帐号
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string AccountID;
        ///<summary>
        ///投资者代码
        ///</summary>
        [DataMember(Order = 16)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string InvestorID;
        ///<summary>
        ///期货公司流水号
        ///</summary>
        [DataMember(Order = 17)]
        public int FutureSerial;
        ///<summary>
        ///证件类型
        ///</summary>
        [DataMember(Order = 18)]
        public byte IdCardType;
        ///<summary>
        ///证件号码
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string IdentifiedCardNo;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 20)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;
        ///<summary>
        ///交易金额
        ///</summary>
        [DataMember(Order = 21)]
        public double TradeAmount;
        ///<summary>
        ///应收客户费用
        ///</summary>
        [DataMember(Order = 22)]
        public double CustFee;
        ///<summary>
        ///应收期货公司费用
        ///</summary>
        [DataMember(Order = 23)]
        public double BrokerFee;
        ///<summary>
        ///有效标志
        ///</summary>
        [DataMember(Order = 24)]
        public byte AvailabilityFlag;
        ///<summary>
        ///操作员
        ///</summary>
        [DataMember(Order = 25)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string OperatorCode;
        ///<summary>
        ///新银行帐号
        ///</summary>
        [DataMember(Order = 26)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankNewAccount;
        ///<summary>
        ///错误代码
        ///</summary>
        [DataMember(Order = 27)]
        public int ErrorID;
        ///<summary>
        ///错误信息
        ///</summary>
        [DataMember(Order = 28)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string ErrorMsg;

        public static byte[] GetData(CtpTransferSerial obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.PlateSerial);
                writer.Write(obj.TradeDate);
                writer.Write(obj.TradingDay);
                writer.Write(obj.TradeTime);
                writer.Write(obj.TradeCode);
                writer.Write(obj.SessionID);
                writer.Write(obj.BankID);
                writer.Write(obj.BankBranchID);
                writer.Write(obj.BankAccType);
                writer.Write(obj.BankAccount);
                writer.Write(obj.BankSerial);
                writer.Write(obj.BrokerID);
                writer.Write(obj.BrokerBranchID);
                writer.Write(obj.FutureAccType);
                writer.Write(obj.AccountID);
                writer.Write(obj.InvestorID);
                writer.Write(obj.FutureSerial);
                writer.Write(obj.IdCardType);
                writer.Write(obj.IdentifiedCardNo);
                writer.Write(obj.CurrencyID);
                writer.Write(obj.TradeAmount);
                writer.Write(obj.CustFee);
                writer.Write(obj.BrokerFee);
                writer.Write(obj.AvailabilityFlag);
                writer.Write(obj.OperatorCode);
                writer.Write(obj.BankNewAccount);
                writer.Write(obj.ErrorID);
                writer.Write(obj.ErrorMsg);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///请求查询转帐流水
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryTransferSerial
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者帐号
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string AccountID;
        ///<summary>
        ///银行编码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;

        public static byte[] GetData(CtpQryTransferSerial obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.AccountID);
                writer.Write(obj.BankID);
                writer.Write(obj.CurrencyID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///期商签到通知
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpNotifyFutureSignIn
    {
        ///<summary>
        ///业务功能码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string TradeCode;
        ///<summary>
        ///银行代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分支机构代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBranchID;
        ///<summary>
        ///期商代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///期商分支机构代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string BrokerBranchID;
        ///<summary>
        ///交易日期
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeDate;
        ///<summary>
        ///交易时间
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeTime;
        ///<summary>
        ///银行流水号
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string BankSerial;
        ///<summary>
        ///交易系统日期
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///银期平台消息流水号
        ///</summary>
        [DataMember(Order = 10)]
        public int PlateSerial;
        ///<summary>
        ///最后分片标志
        ///</summary>
        [DataMember(Order = 11)]
        public byte LastFragment;
        ///<summary>
        ///会话号
        ///</summary>
        [DataMember(Order = 12)]
        public int SessionID;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 13)]
        public int InstallID;
        ///<summary>
        ///用户标识
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///摘要
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
        public string Digest;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 16)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;
        ///<summary>
        ///渠道标志
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string DeviceID;
        ///<summary>
        ///期货公司银行编码
        ///</summary>
        [DataMember(Order = 18)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string BrokerIDByBank;
        ///<summary>
        ///交易柜员
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string OperNo;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 20)]
        public int RequestID;
        ///<summary>
        ///交易ID
        ///</summary>
        [DataMember(Order = 21)]
        public int TID;
        ///<summary>
        ///错误代码
        ///</summary>
        [DataMember(Order = 22)]
        public int ErrorID;
        ///<summary>
        ///错误信息
        ///</summary>
        [DataMember(Order = 23)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string ErrorMsg;
        ///<summary>
        ///PIN密钥
        ///</summary>
        [DataMember(Order = 24)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string PinKey;
        ///<summary>
        ///MAC密钥
        ///</summary>
        [DataMember(Order = 25)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string MacKey;

        public static byte[] GetData(CtpNotifyFutureSignIn obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradeCode);
                writer.Write(obj.BankID);
                writer.Write(obj.BankBranchID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.BrokerBranchID);
                writer.Write(obj.TradeDate);
                writer.Write(obj.TradeTime);
                writer.Write(obj.BankSerial);
                writer.Write(obj.TradingDay);
                writer.Write(obj.PlateSerial);
                writer.Write(obj.LastFragment);
                writer.Write(obj.SessionID);
                writer.Write(obj.InstallID);
                writer.Write(obj.UserID);
                writer.Write(obj.Digest);
                writer.Write(obj.CurrencyID);
                writer.Write(obj.DeviceID);
                writer.Write(obj.BrokerIDByBank);
                writer.Write(obj.OperNo);
                writer.Write(obj.RequestID);
                writer.Write(obj.TID);
                writer.Write(obj.ErrorID);
                writer.Write(obj.ErrorMsg);
                writer.Write(obj.PinKey);
                writer.Write(obj.MacKey);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///期商签退通知
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpNotifyFutureSignOut
    {
        ///<summary>
        ///业务功能码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string TradeCode;
        ///<summary>
        ///银行代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分支机构代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBranchID;
        ///<summary>
        ///期商代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///期商分支机构代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string BrokerBranchID;
        ///<summary>
        ///交易日期
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeDate;
        ///<summary>
        ///交易时间
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeTime;
        ///<summary>
        ///银行流水号
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string BankSerial;
        ///<summary>
        ///交易系统日期
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///银期平台消息流水号
        ///</summary>
        [DataMember(Order = 10)]
        public int PlateSerial;
        ///<summary>
        ///最后分片标志
        ///</summary>
        [DataMember(Order = 11)]
        public byte LastFragment;
        ///<summary>
        ///会话号
        ///</summary>
        [DataMember(Order = 12)]
        public int SessionID;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 13)]
        public int InstallID;
        ///<summary>
        ///用户标识
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///摘要
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
        public string Digest;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 16)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;
        ///<summary>
        ///渠道标志
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string DeviceID;
        ///<summary>
        ///期货公司银行编码
        ///</summary>
        [DataMember(Order = 18)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string BrokerIDByBank;
        ///<summary>
        ///交易柜员
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string OperNo;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 20)]
        public int RequestID;
        ///<summary>
        ///交易ID
        ///</summary>
        [DataMember(Order = 21)]
        public int TID;
        ///<summary>
        ///错误代码
        ///</summary>
        [DataMember(Order = 22)]
        public int ErrorID;
        ///<summary>
        ///错误信息
        ///</summary>
        [DataMember(Order = 23)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string ErrorMsg;

        public static byte[] GetData(CtpNotifyFutureSignOut obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradeCode);
                writer.Write(obj.BankID);
                writer.Write(obj.BankBranchID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.BrokerBranchID);
                writer.Write(obj.TradeDate);
                writer.Write(obj.TradeTime);
                writer.Write(obj.BankSerial);
                writer.Write(obj.TradingDay);
                writer.Write(obj.PlateSerial);
                writer.Write(obj.LastFragment);
                writer.Write(obj.SessionID);
                writer.Write(obj.InstallID);
                writer.Write(obj.UserID);
                writer.Write(obj.Digest);
                writer.Write(obj.CurrencyID);
                writer.Write(obj.DeviceID);
                writer.Write(obj.BrokerIDByBank);
                writer.Write(obj.OperNo);
                writer.Write(obj.RequestID);
                writer.Write(obj.TID);
                writer.Write(obj.ErrorID);
                writer.Write(obj.ErrorMsg);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///交易核心向银期报盘发出密钥同步处理结果的通知
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpNotifySyncKey
    {
        ///<summary>
        ///业务功能码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string TradeCode;
        ///<summary>
        ///银行代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分支机构代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBranchID;
        ///<summary>
        ///期商代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///期商分支机构代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string BrokerBranchID;
        ///<summary>
        ///交易日期
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeDate;
        ///<summary>
        ///交易时间
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeTime;
        ///<summary>
        ///银行流水号
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string BankSerial;
        ///<summary>
        ///交易系统日期
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///银期平台消息流水号
        ///</summary>
        [DataMember(Order = 10)]
        public int PlateSerial;
        ///<summary>
        ///最后分片标志
        ///</summary>
        [DataMember(Order = 11)]
        public byte LastFragment;
        ///<summary>
        ///会话号
        ///</summary>
        [DataMember(Order = 12)]
        public int SessionID;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 13)]
        public int InstallID;
        ///<summary>
        ///用户标识
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///交易核心给银期报盘的消息
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string Message;
        ///<summary>
        ///渠道标志
        ///</summary>
        [DataMember(Order = 16)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string DeviceID;
        ///<summary>
        ///期货公司银行编码
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string BrokerIDByBank;
        ///<summary>
        ///交易柜员
        ///</summary>
        [DataMember(Order = 18)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string OperNo;
        ///<summary>
        ///请求编号
        ///</summary>
        [DataMember(Order = 19)]
        public int RequestID;
        ///<summary>
        ///交易ID
        ///</summary>
        [DataMember(Order = 20)]
        public int TID;
        ///<summary>
        ///错误代码
        ///</summary>
        [DataMember(Order = 21)]
        public int ErrorID;
        ///<summary>
        ///错误信息
        ///</summary>
        [DataMember(Order = 22)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string ErrorMsg;

        public static byte[] GetData(CtpNotifySyncKey obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradeCode);
                writer.Write(obj.BankID);
                writer.Write(obj.BankBranchID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.BrokerBranchID);
                writer.Write(obj.TradeDate);
                writer.Write(obj.TradeTime);
                writer.Write(obj.BankSerial);
                writer.Write(obj.TradingDay);
                writer.Write(obj.PlateSerial);
                writer.Write(obj.LastFragment);
                writer.Write(obj.SessionID);
                writer.Write(obj.InstallID);
                writer.Write(obj.UserID);
                writer.Write(obj.Message);
                writer.Write(obj.DeviceID);
                writer.Write(obj.BrokerIDByBank);
                writer.Write(obj.OperNo);
                writer.Write(obj.RequestID);
                writer.Write(obj.TID);
                writer.Write(obj.ErrorID);
                writer.Write(obj.ErrorMsg);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///请求查询银期签约关系
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryAccountregister
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者帐号
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string AccountID;
        ///<summary>
        ///银行编码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分支机构编码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBranchID;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;

        public static byte[] GetData(CtpQryAccountregister obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.AccountID);
                writer.Write(obj.BankID);
                writer.Write(obj.BankBranchID);
                writer.Write(obj.CurrencyID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///客户开销户信息表
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpAccountregister
    {
        ///<summary>
        ///交易日期
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeDay;
        ///<summary>
        ///银行编码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分支机构编码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBranchID;
        ///<summary>
        ///银行帐号
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankAccount;
        ///<summary>
        ///期货公司编码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///期货公司分支机构编码
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string BrokerBranchID;
        ///<summary>
        ///投资者帐号
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string AccountID;
        ///<summary>
        ///证件类型
        ///</summary>
        [DataMember(Order = 8)]
        public byte IdCardType;
        ///<summary>
        ///证件号码
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string IdentifiedCardNo;
        ///<summary>
        ///客户姓名
        ///</summary>
        [DataMember(Order = 10)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string CustomerName;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 11)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;
        ///<summary>
        ///开销户类别
        ///</summary>
        [DataMember(Order = 12)]
        public byte OpenOrDestroy;
        ///<summary>
        ///签约日期
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string RegDate;
        ///<summary>
        ///解约日期
        ///</summary>
        [DataMember(Order = 14)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string OutDate;
        ///<summary>
        ///交易ID
        ///</summary>
        [DataMember(Order = 15)]
        public int TID;
        ///<summary>
        ///客户类型
        ///</summary>
        [DataMember(Order = 16)]
        public byte CustType;
        ///<summary>
        ///银行帐号类型
        ///</summary>
        [DataMember(Order = 17)]
        public byte BankAccType;

        public static byte[] GetData(CtpAccountregister obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradeDay);
                writer.Write(obj.BankID);
                writer.Write(obj.BankBranchID);
                writer.Write(obj.BankAccount);
                writer.Write(obj.BrokerID);
                writer.Write(obj.BrokerBranchID);
                writer.Write(obj.AccountID);
                writer.Write(obj.IdCardType);
                writer.Write(obj.IdentifiedCardNo);
                writer.Write(obj.CustomerName);
                writer.Write(obj.CurrencyID);
                writer.Write(obj.OpenOrDestroy);
                writer.Write(obj.RegDate);
                writer.Write(obj.OutDate);
                writer.Write(obj.TID);
                writer.Write(obj.CustType);
                writer.Write(obj.BankAccType);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///银期开户信息
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpOpenAccount
    {
        ///<summary>
        ///业务功能码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string TradeCode;
        ///<summary>
        ///银行代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分支机构代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBranchID;
        ///<summary>
        ///期商代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///期商分支机构代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string BrokerBranchID;
        ///<summary>
        ///交易日期
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeDate;
        ///<summary>
        ///交易时间
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeTime;
        ///<summary>
        ///银行流水号
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string BankSerial;
        ///<summary>
        ///交易系统日期
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///银期平台消息流水号
        ///</summary>
        [DataMember(Order = 10)]
        public int PlateSerial;
        ///<summary>
        ///最后分片标志
        ///</summary>
        [DataMember(Order = 11)]
        public byte LastFragment;
        ///<summary>
        ///会话号
        ///</summary>
        [DataMember(Order = 12)]
        public int SessionID;
        ///<summary>
        ///客户姓名
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string CustomerName;
        ///<summary>
        ///证件类型
        ///</summary>
        [DataMember(Order = 14)]
        public byte IdCardType;
        ///<summary>
        ///证件号码
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string IdentifiedCardNo;
        ///<summary>
        ///性别
        ///</summary>
        [DataMember(Order = 16)]
        public byte Gender;
        ///<summary>
        ///国家代码
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string CountryCode;
        ///<summary>
        ///客户类型
        ///</summary>
        [DataMember(Order = 18)]
        public byte CustType;
        ///<summary>
        ///地址
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
        public string Address;
        ///<summary>
        ///邮编
        ///</summary>
        [DataMember(Order = 20)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string ZipCode;
        ///<summary>
        ///电话号码
        ///</summary>
        [DataMember(Order = 21)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Telephone;
        ///<summary>
        ///手机
        ///</summary>
        [DataMember(Order = 22)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string MobilePhone;
        ///<summary>
        ///传真
        ///</summary>
        [DataMember(Order = 23)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Fax;
        ///<summary>
        ///电子邮件
        ///</summary>
        [DataMember(Order = 24)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string EMail;
        ///<summary>
        ///资金账户状态
        ///</summary>
        [DataMember(Order = 25)]
        public byte MoneyAccountStatus;
        ///<summary>
        ///银行帐号
        ///</summary>
        [DataMember(Order = 26)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankAccount;
        ///<summary>
        ///银行密码
        ///</summary>
        [DataMember(Order = 27)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankPassWord;
        ///<summary>
        ///投资者帐号
        ///</summary>
        [DataMember(Order = 28)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string AccountID;
        ///<summary>
        ///期货密码
        ///</summary>
        [DataMember(Order = 29)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Password;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 30)]
        public int InstallID;
        ///<summary>
        ///验证客户证件号码标志
        ///</summary>
        [DataMember(Order = 31)]
        public byte VerifyCertNoFlag;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 32)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;
        ///<summary>
        ///汇钞标志
        ///</summary>
        [DataMember(Order = 33)]
        public byte CashExchangeCode;
        ///<summary>
        ///摘要
        ///</summary>
        [DataMember(Order = 34)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
        public string Digest;
        ///<summary>
        ///银行帐号类型
        ///</summary>
        [DataMember(Order = 35)]
        public byte BankAccType;
        ///<summary>
        ///渠道标志
        ///</summary>
        [DataMember(Order = 36)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string DeviceID;
        ///<summary>
        ///期货单位帐号类型
        ///</summary>
        [DataMember(Order = 37)]
        public byte BankSecuAccType;
        ///<summary>
        ///期货公司银行编码
        ///</summary>
        [DataMember(Order = 38)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string BrokerIDByBank;
        ///<summary>
        ///期货单位帐号
        ///</summary>
        [DataMember(Order = 39)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankSecuAcc;
        ///<summary>
        ///银行密码标志
        ///</summary>
        [DataMember(Order = 40)]
        public byte BankPwdFlag;
        ///<summary>
        ///期货资金密码核对标志
        ///</summary>
        [DataMember(Order = 41)]
        public byte SecuPwdFlag;
        ///<summary>
        ///交易柜员
        ///</summary>
        [DataMember(Order = 42)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string OperNo;
        ///<summary>
        ///交易ID
        ///</summary>
        [DataMember(Order = 43)]
        public int TID;
        ///<summary>
        ///用户标识
        ///</summary>
        [DataMember(Order = 44)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///错误代码
        ///</summary>
        [DataMember(Order = 45)]
        public int ErrorID;
        ///<summary>
        ///错误信息
        ///</summary>
        [DataMember(Order = 46)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string ErrorMsg;

        public static byte[] GetData(CtpOpenAccount obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradeCode);
                writer.Write(obj.BankID);
                writer.Write(obj.BankBranchID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.BrokerBranchID);
                writer.Write(obj.TradeDate);
                writer.Write(obj.TradeTime);
                writer.Write(obj.BankSerial);
                writer.Write(obj.TradingDay);
                writer.Write(obj.PlateSerial);
                writer.Write(obj.LastFragment);
                writer.Write(obj.SessionID);
                writer.Write(obj.CustomerName);
                writer.Write(obj.IdCardType);
                writer.Write(obj.IdentifiedCardNo);
                writer.Write(obj.Gender);
                writer.Write(obj.CountryCode);
                writer.Write(obj.CustType);
                writer.Write(obj.Address);
                writer.Write(obj.ZipCode);
                writer.Write(obj.Telephone);
                writer.Write(obj.MobilePhone);
                writer.Write(obj.Fax);
                writer.Write(obj.EMail);
                writer.Write(obj.MoneyAccountStatus);
                writer.Write(obj.BankAccount);
                writer.Write(obj.BankPassWord);
                writer.Write(obj.AccountID);
                writer.Write(obj.Password);
                writer.Write(obj.InstallID);
                writer.Write(obj.VerifyCertNoFlag);
                writer.Write(obj.CurrencyID);
                writer.Write(obj.CashExchangeCode);
                writer.Write(obj.Digest);
                writer.Write(obj.BankAccType);
                writer.Write(obj.DeviceID);
                writer.Write(obj.BankSecuAccType);
                writer.Write(obj.BrokerIDByBank);
                writer.Write(obj.BankSecuAcc);
                writer.Write(obj.BankPwdFlag);
                writer.Write(obj.SecuPwdFlag);
                writer.Write(obj.OperNo);
                writer.Write(obj.TID);
                writer.Write(obj.UserID);
                writer.Write(obj.ErrorID);
                writer.Write(obj.ErrorMsg);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///银期销户信息
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpCancelAccount
    {
        ///<summary>
        ///业务功能码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string TradeCode;
        ///<summary>
        ///银行代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分支机构代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBranchID;
        ///<summary>
        ///期商代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///期商分支机构代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string BrokerBranchID;
        ///<summary>
        ///交易日期
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeDate;
        ///<summary>
        ///交易时间
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeTime;
        ///<summary>
        ///银行流水号
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string BankSerial;
        ///<summary>
        ///交易系统日期
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///银期平台消息流水号
        ///</summary>
        [DataMember(Order = 10)]
        public int PlateSerial;
        ///<summary>
        ///最后分片标志
        ///</summary>
        [DataMember(Order = 11)]
        public byte LastFragment;
        ///<summary>
        ///会话号
        ///</summary>
        [DataMember(Order = 12)]
        public int SessionID;
        ///<summary>
        ///客户姓名
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string CustomerName;
        ///<summary>
        ///证件类型
        ///</summary>
        [DataMember(Order = 14)]
        public byte IdCardType;
        ///<summary>
        ///证件号码
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string IdentifiedCardNo;
        ///<summary>
        ///性别
        ///</summary>
        [DataMember(Order = 16)]
        public byte Gender;
        ///<summary>
        ///国家代码
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string CountryCode;
        ///<summary>
        ///客户类型
        ///</summary>
        [DataMember(Order = 18)]
        public byte CustType;
        ///<summary>
        ///地址
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
        public string Address;
        ///<summary>
        ///邮编
        ///</summary>
        [DataMember(Order = 20)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string ZipCode;
        ///<summary>
        ///电话号码
        ///</summary>
        [DataMember(Order = 21)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Telephone;
        ///<summary>
        ///手机
        ///</summary>
        [DataMember(Order = 22)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string MobilePhone;
        ///<summary>
        ///传真
        ///</summary>
        [DataMember(Order = 23)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Fax;
        ///<summary>
        ///电子邮件
        ///</summary>
        [DataMember(Order = 24)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string EMail;
        ///<summary>
        ///资金账户状态
        ///</summary>
        [DataMember(Order = 25)]
        public byte MoneyAccountStatus;
        ///<summary>
        ///银行帐号
        ///</summary>
        [DataMember(Order = 26)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankAccount;
        ///<summary>
        ///银行密码
        ///</summary>
        [DataMember(Order = 27)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankPassWord;
        ///<summary>
        ///投资者帐号
        ///</summary>
        [DataMember(Order = 28)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string AccountID;
        ///<summary>
        ///期货密码
        ///</summary>
        [DataMember(Order = 29)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Password;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 30)]
        public int InstallID;
        ///<summary>
        ///验证客户证件号码标志
        ///</summary>
        [DataMember(Order = 31)]
        public byte VerifyCertNoFlag;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 32)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;
        ///<summary>
        ///汇钞标志
        ///</summary>
        [DataMember(Order = 33)]
        public byte CashExchangeCode;
        ///<summary>
        ///摘要
        ///</summary>
        [DataMember(Order = 34)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
        public string Digest;
        ///<summary>
        ///银行帐号类型
        ///</summary>
        [DataMember(Order = 35)]
        public byte BankAccType;
        ///<summary>
        ///渠道标志
        ///</summary>
        [DataMember(Order = 36)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public string DeviceID;
        ///<summary>
        ///期货单位帐号类型
        ///</summary>
        [DataMember(Order = 37)]
        public byte BankSecuAccType;
        ///<summary>
        ///期货公司银行编码
        ///</summary>
        [DataMember(Order = 38)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string BrokerIDByBank;
        ///<summary>
        ///期货单位帐号
        ///</summary>
        [DataMember(Order = 39)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankSecuAcc;
        ///<summary>
        ///银行密码标志
        ///</summary>
        [DataMember(Order = 40)]
        public byte BankPwdFlag;
        ///<summary>
        ///期货资金密码核对标志
        ///</summary>
        [DataMember(Order = 41)]
        public byte SecuPwdFlag;
        ///<summary>
        ///交易柜员
        ///</summary>
        [DataMember(Order = 42)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        public string OperNo;
        ///<summary>
        ///交易ID
        ///</summary>
        [DataMember(Order = 43)]
        public int TID;
        ///<summary>
        ///用户标识
        ///</summary>
        [DataMember(Order = 44)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///错误代码
        ///</summary>
        [DataMember(Order = 45)]
        public int ErrorID;
        ///<summary>
        ///错误信息
        ///</summary>
        [DataMember(Order = 46)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string ErrorMsg;

        public static byte[] GetData(CtpCancelAccount obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradeCode);
                writer.Write(obj.BankID);
                writer.Write(obj.BankBranchID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.BrokerBranchID);
                writer.Write(obj.TradeDate);
                writer.Write(obj.TradeTime);
                writer.Write(obj.BankSerial);
                writer.Write(obj.TradingDay);
                writer.Write(obj.PlateSerial);
                writer.Write(obj.LastFragment);
                writer.Write(obj.SessionID);
                writer.Write(obj.CustomerName);
                writer.Write(obj.IdCardType);
                writer.Write(obj.IdentifiedCardNo);
                writer.Write(obj.Gender);
                writer.Write(obj.CountryCode);
                writer.Write(obj.CustType);
                writer.Write(obj.Address);
                writer.Write(obj.ZipCode);
                writer.Write(obj.Telephone);
                writer.Write(obj.MobilePhone);
                writer.Write(obj.Fax);
                writer.Write(obj.EMail);
                writer.Write(obj.MoneyAccountStatus);
                writer.Write(obj.BankAccount);
                writer.Write(obj.BankPassWord);
                writer.Write(obj.AccountID);
                writer.Write(obj.Password);
                writer.Write(obj.InstallID);
                writer.Write(obj.VerifyCertNoFlag);
                writer.Write(obj.CurrencyID);
                writer.Write(obj.CashExchangeCode);
                writer.Write(obj.Digest);
                writer.Write(obj.BankAccType);
                writer.Write(obj.DeviceID);
                writer.Write(obj.BankSecuAccType);
                writer.Write(obj.BrokerIDByBank);
                writer.Write(obj.BankSecuAcc);
                writer.Write(obj.BankPwdFlag);
                writer.Write(obj.SecuPwdFlag);
                writer.Write(obj.OperNo);
                writer.Write(obj.TID);
                writer.Write(obj.UserID);
                writer.Write(obj.ErrorID);
                writer.Write(obj.ErrorMsg);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///银期变更银行账号信息
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpChangeAccount
    {
        ///<summary>
        ///业务功能码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string TradeCode;
        ///<summary>
        ///银行代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string BankID;
        ///<summary>
        ///银行分支机构代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string BankBranchID;
        ///<summary>
        ///期商代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///期商分支机构代码
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string BrokerBranchID;
        ///<summary>
        ///交易日期
        ///</summary>
        [DataMember(Order = 6)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeDate;
        ///<summary>
        ///交易时间
        ///</summary>
        [DataMember(Order = 7)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeTime;
        ///<summary>
        ///银行流水号
        ///</summary>
        [DataMember(Order = 8)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string BankSerial;
        ///<summary>
        ///交易系统日期
        ///</summary>
        [DataMember(Order = 9)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        ///<summary>
        ///银期平台消息流水号
        ///</summary>
        [DataMember(Order = 10)]
        public int PlateSerial;
        ///<summary>
        ///最后分片标志
        ///</summary>
        [DataMember(Order = 11)]
        public byte LastFragment;
        ///<summary>
        ///会话号
        ///</summary>
        [DataMember(Order = 12)]
        public int SessionID;
        ///<summary>
        ///客户姓名
        ///</summary>
        [DataMember(Order = 13)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string CustomerName;
        ///<summary>
        ///证件类型
        ///</summary>
        [DataMember(Order = 14)]
        public byte IdCardType;
        ///<summary>
        ///证件号码
        ///</summary>
        [DataMember(Order = 15)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string IdentifiedCardNo;
        ///<summary>
        ///性别
        ///</summary>
        [DataMember(Order = 16)]
        public byte Gender;
        ///<summary>
        ///国家代码
        ///</summary>
        [DataMember(Order = 17)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string CountryCode;
        ///<summary>
        ///客户类型
        ///</summary>
        [DataMember(Order = 18)]
        public byte CustType;
        ///<summary>
        ///地址
        ///</summary>
        [DataMember(Order = 19)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 101)]
        public string Address;
        ///<summary>
        ///邮编
        ///</summary>
        [DataMember(Order = 20)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string ZipCode;
        ///<summary>
        ///电话号码
        ///</summary>
        [DataMember(Order = 21)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Telephone;
        ///<summary>
        ///手机
        ///</summary>
        [DataMember(Order = 22)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string MobilePhone;
        ///<summary>
        ///传真
        ///</summary>
        [DataMember(Order = 23)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Fax;
        ///<summary>
        ///电子邮件
        ///</summary>
        [DataMember(Order = 24)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string EMail;
        ///<summary>
        ///资金账户状态
        ///</summary>
        [DataMember(Order = 25)]
        public byte MoneyAccountStatus;
        ///<summary>
        ///银行帐号
        ///</summary>
        [DataMember(Order = 26)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankAccount;
        ///<summary>
        ///银行密码
        ///</summary>
        [DataMember(Order = 27)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string BankPassWord;
        ///<summary>
        ///新银行帐号
        ///</summary>
        [DataMember(Order = 28)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string NewBankAccount;
        ///<summary>
        ///新银行密码
        ///</summary>
        [DataMember(Order = 29)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string NewBankPassWord;
        ///<summary>
        ///投资者帐号
        ///</summary>
        [DataMember(Order = 30)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string AccountID;
        ///<summary>
        ///期货密码
        ///</summary>
        [DataMember(Order = 31)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Password;
        ///<summary>
        ///银行帐号类型
        ///</summary>
        [DataMember(Order = 32)]
        public byte BankAccType;
        ///<summary>
        ///安装编号
        ///</summary>
        [DataMember(Order = 33)]
        public int InstallID;
        ///<summary>
        ///验证客户证件号码标志
        ///</summary>
        [DataMember(Order = 34)]
        public byte VerifyCertNoFlag;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 35)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;
        ///<summary>
        ///期货公司银行编码
        ///</summary>
        [DataMember(Order = 36)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string BrokerIDByBank;
        ///<summary>
        ///银行密码标志
        ///</summary>
        [DataMember(Order = 37)]
        public byte BankPwdFlag;
        ///<summary>
        ///期货资金密码核对标志
        ///</summary>
        [DataMember(Order = 38)]
        public byte SecuPwdFlag;
        ///<summary>
        ///交易ID
        ///</summary>
        [DataMember(Order = 39)]
        public int TID;
        ///<summary>
        ///摘要
        ///</summary>
        [DataMember(Order = 40)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
        public string Digest;
        ///<summary>
        ///错误代码
        ///</summary>
        [DataMember(Order = 41)]
        public int ErrorID;
        ///<summary>
        ///错误信息
        ///</summary>
        [DataMember(Order = 42)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string ErrorMsg;

        public static byte[] GetData(CtpChangeAccount obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.TradeCode);
                writer.Write(obj.BankID);
                writer.Write(obj.BankBranchID);
                writer.Write(obj.BrokerID);
                writer.Write(obj.BrokerBranchID);
                writer.Write(obj.TradeDate);
                writer.Write(obj.TradeTime);
                writer.Write(obj.BankSerial);
                writer.Write(obj.TradingDay);
                writer.Write(obj.PlateSerial);
                writer.Write(obj.LastFragment);
                writer.Write(obj.SessionID);
                writer.Write(obj.CustomerName);
                writer.Write(obj.IdCardType);
                writer.Write(obj.IdentifiedCardNo);
                writer.Write(obj.Gender);
                writer.Write(obj.CountryCode);
                writer.Write(obj.CustType);
                writer.Write(obj.Address);
                writer.Write(obj.ZipCode);
                writer.Write(obj.Telephone);
                writer.Write(obj.MobilePhone);
                writer.Write(obj.Fax);
                writer.Write(obj.EMail);
                writer.Write(obj.MoneyAccountStatus);
                writer.Write(obj.BankAccount);
                writer.Write(obj.BankPassWord);
                writer.Write(obj.NewBankAccount);
                writer.Write(obj.NewBankPassWord);
                writer.Write(obj.AccountID);
                writer.Write(obj.Password);
                writer.Write(obj.BankAccType);
                writer.Write(obj.InstallID);
                writer.Write(obj.VerifyCertNoFlag);
                writer.Write(obj.CurrencyID);
                writer.Write(obj.BrokerIDByBank);
                writer.Write(obj.BankPwdFlag);
                writer.Write(obj.SecuPwdFlag);
                writer.Write(obj.TID);
                writer.Write(obj.Digest);
                writer.Write(obj.ErrorID);
                writer.Write(obj.ErrorMsg);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///二级代理操作员银期权限
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpSecAgentACIDMap
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///资金账户
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string AccountID;
        ///<summary>
        ///币种
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;
        ///<summary>
        ///境外中介机构资金帐号
        ///</summary>
        [DataMember(Order = 5)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string BrokerSecAgentID;

        public static byte[] GetData(CtpSecAgentACIDMap obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.UserID);
                writer.Write(obj.AccountID);
                writer.Write(obj.CurrencyID);
                writer.Write(obj.BrokerSecAgentID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///二级代理操作员银期权限查询
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQrySecAgentACIDMap
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///资金账户
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string AccountID;
        ///<summary>
        ///币种
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;

        public static byte[] GetData(CtpQrySecAgentACIDMap obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.UserID);
                writer.Write(obj.AccountID);
                writer.Write(obj.CurrencyID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///灾备中心交易权限
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpUserRightsAssign
    {
        ///<summary>
        ///应用单元代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///交易中心代码
        ///</summary>
        [DataMember(Order = 3)]
        public int DRIdentityID;

        public static byte[] GetData(CtpUserRightsAssign obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.UserID);
                writer.Write(obj.DRIdentityID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///经济公司是否有在本标示的交易权限
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpBrokerUserRightAssign
    {
        ///<summary>
        ///应用单元代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///交易中心代码
        ///</summary>
        [DataMember(Order = 2)]
        public int DRIdentityID;
        ///<summary>
        ///能否交易
        ///</summary>
        [DataMember(Order = 3)]
        public int Tradeable;

        public static byte[] GetData(CtpBrokerUserRightAssign obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.DRIdentityID);
                writer.Write(obj.Tradeable);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///灾备交易转换报文
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpDRTransfer
    {
        ///<summary>
        ///原交易中心代码
        ///</summary>
        [DataMember(Order = 1)]
        public int OrigDRIdentityID;
        ///<summary>
        ///目标交易中心代码
        ///</summary>
        [DataMember(Order = 2)]
        public int DestDRIdentityID;
        ///<summary>
        ///原应用单元代码
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string OrigBrokerID;
        ///<summary>
        ///目标易用单元代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string DestBrokerID;

        public static byte[] GetData(CtpDRTransfer obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.OrigDRIdentityID);
                writer.Write(obj.DestDRIdentityID);
                writer.Write(obj.OrigBrokerID);
                writer.Write(obj.DestBrokerID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///Fens用户信息
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpFensUserInfo
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///登录模式
        ///</summary>
        [DataMember(Order = 3)]
        public byte LoginMode;

        public static byte[] GetData(CtpFensUserInfo obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.UserID);
                writer.Write(obj.LoginMode);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///当前银期所属交易中心
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpCurrTransferIdentity
    {
        ///<summary>
        ///交易中心代码
        ///</summary>
        [DataMember(Order = 1)]
        public int IdentityID;

        public static byte[] GetData(CtpCurrTransferIdentity obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.IdentityID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///禁止登录用户
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpLoginForbiddenUser
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        ///<summary>
        ///IP地址
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string IPAddress;

        public static byte[] GetData(CtpLoginForbiddenUser obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.UserID);
                writer.Write(obj.IPAddress);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///查询禁止登录用户
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpQryLoginForbiddenUser
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///用户代码
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;

        public static byte[] GetData(CtpQryLoginForbiddenUser obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.UserID);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///UDP组播组信息
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpMulticastGroupInfo
    {
        ///<summary>
        ///组播组IP地址
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string GroupIP;
        ///<summary>
        ///组播组IP端口
        ///</summary>
        [DataMember(Order = 2)]
        public int GroupPort;
        ///<summary>
        ///源地址
        ///</summary>
        [DataMember(Order = 3)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string SourceIP;

        public static byte[] GetData(CtpMulticastGroupInfo obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.GroupIP);
                writer.Write(obj.GroupPort);
                writer.Write(obj.SourceIP);
                return stream.ToArray();
            }
        }
    };

    ///<summary>
    ///资金账户基本准备金
    ///</summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class CtpTradingAccountReserve
    {
        ///<summary>
        ///经纪公司代码
        ///</summary>
        [DataMember(Order = 1)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        ///<summary>
        ///投资者帐号
        ///</summary>
        [DataMember(Order = 2)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string AccountID;
        ///<summary>
        ///基本准备金
        ///</summary>
        [DataMember(Order = 3)]
        public double Reserve;
        ///<summary>
        ///币种代码
        ///</summary>
        [DataMember(Order = 4)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string CurrencyID;

        public static byte[] GetData(CtpTradingAccountReserve obj)
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream)) {
                writer.Write(obj.BrokerID);
                writer.Write(obj.AccountID);
                writer.Write(obj.Reserve);
                writer.Write(obj.CurrencyID);
                return stream.ToArray();
            }
        }
    };

}