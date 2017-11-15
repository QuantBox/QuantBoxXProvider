/*
 * User: hetao
 * Date: 2014/5/23 星期五
 * Time: 17:01
 * 
 */
using System;

namespace QuantBox.Sfit.Api
{
	/// <summary>
	/// CTP API Error ID.
	/// </summary>
	public static class CtpErrorType
	{
		public const int NONE = 0;
		public const int INVALID_DATA_SYNC_STATUS = 1;
		public const int INCONSISTENT_INFORMATION = 2;
		public const int INVALID_LOGIN = 3;
		public const int USER_NOT_ACTIVE = 4;
		public const int DUPLICATE_LOGIN = 5;
		public const int NOT_LOGIN_YET = 6;
		public const int NOT_INITED = 7;
		public const int FRONT_NOT_ACTIVE = 8;
		public const int NO_PRIVILEGE = 9;
		public const int CHANGE_OTHER_PASSWORD = 10;
		public const int USER_NOT_FOUND = 11;
		public const int BROKER_NOT_FOUND = 12;
		public const int INVESTOR_NOT_FOUND = 13;
		public const int OLD_PASSWORD_MISMATCH = 14;
		public const int BAD_FIELD = 15;
		public const int INSTRUMENT_NOT_FOUND = 16;
		public const int INSTRUMENT_NOT_TRADING = 17;
		public const int NOT_EXCHANGE_PARTICIPANT = 18;
		public const int INVESTOR_NOT_ACTIVE = 19;
		public const int NOT_EXCHANGE_CLIENT = 20;
		public const int NO_VALID_TRADER_AVAILABLE = 21;
		public const int DUPLICATE_ORDER_REF = 22;
		public const int BAD_ORDER_ACTION_FIELD = 23;
		public const int DUPLICATE_ORDER_ACTION_REF = 24;
		public const int ORDER_NOT_FOUND = 25;
		public const int INSUITABLE_ORDER_STATUS = 26;
		public const int UNSUPPORTED_FUNCTION = 27;
		public const int NO_TRADING_RIGHT = 28;
		public const int CLOSE_ONLY = 29;
		public const int OVER_CLOSE_POSITION = 30;
		public const int INSUFFICIENT_MONEY = 31;
		public const int DUPLICATE_PK = 32;
		public const int CANNOT_FIND_PK = 33;
		public const int CAN_NOT_INACTIVE_BROKER = 34;
		public const int BROKER_SYNCHRONIZING = 35;
		public const int BROKER_SYNCHRONIZED = 36;
		public const int SHORT_SELL = 37;
		public const int INVALID_SETTLEMENT_REF = 38;
		public const int CFFEX_NETWORK_ERROR = 39;
		public const int CFFEX_OVER_REQUEST = 40;
		public const int CFFEX_OVER_REQUEST_PER_SECOND = 41;
		public const int SETTLEMENT_INFO_NOT_CONFIRMED = 42;
		public const int DEPOSIT_NOT_FOUND = 43;
		public const int EXCHANG_TRADING = 44;
		public const int PARKEDORDER_NOT_FOUND = 45;
		public const int PARKEDORDER_HASSENDED = 46;
		public const int PARKEDORDER_HASDELETE = 47;
		public const int INVALID_INVESTORIDORPASSWORD = 48;
		public const int INVALID_LOGIN_IPADDRESS = 49;
		public const int OVER_CLOSETODAY_POSITION = 50;
		public const int OVER_CLOSEYESTERDAY_POSITION = 51;
		public const int BROKER_NOT_ENOUGH_CONDORDER = 52;
		public const int INVESTOR_NOT_ENOUGH_CONDORDER = 53;
		public const int BROKER_NOT_SUPPORT_CONDORDER = 54;
		public const int RESEND_ORDER_BROKERINVESTOR_NOTMATCH = 55;
		public const int SYC_OTP_FAILED = 56;
		public const int OTP_MISMATCH = 57;
		public const int OTPPARAM_NOT_FOUND = 58;
		public const int UNSUPPORTED_OTPTYPE = 59;
		public const int SINGLEUSERSESSION_EXCEED_LIMIT = 60;
		public const int EXCHANGE_UNSUPPORTED_ARBITRAGE = 61;
		public const int NO_CONDITIONAL_ORDER_RIGHT = 62;
		public const int AUTH_FAILED = 63;
		public const int NOT_AUTHENT = 64;
		public const int SWAPORDER_UNSUPPORTED = 65;
		public const int OPTIONS_ONLY_SUPPORT_SPEC = 66;
		public const int DUPLICATE_EXECORDER_REF = 67;
		public const int RESEND_EXECORDER_BROKERINVESTOR_NOTMATCH = 68;
		public const int EXECORDER_NOTOPTIONS = 69;
		public const int OPTIONS_NOT_SUPPORT_EXEC = 70;
		public const int BAD_EXECORDER_ACTION_FIELD = 71;
		public const int DUPLICATE_EXECORDER_ACTION_REF = 72;
		public const int EXECORDER_NOT_FOUND = 73;
		public const int OVER_EXECUTE_POSITION = 74;
		public const int LOGIN_FORBIDDEN = 75;
		public const int INVALID_TRANSFER_AGENT = 76;
		public const int NO_FOUND_FUNCTION = 77;
		public const int SEND_EXCHANGEORDER_FAILED = 78;
		public const int SEND_EXCHANGEORDERACTION_FAILED = 79;
		public const int PRICETYPE_NOTSUPPORT_BYEXCHANGE = 80;
		public const int BAD_EXECUTE_TYPE = 81;
		public const int BAD_OPTION_INSTR = 82;
		public const int INSTR_NOTSUPPORT_FORQUOTE = 83;
		public const int RESEND_QUOTE_BROKERINVESTOR_NOTMATCH = 84;
		public const int INSTR_NOTSUPPORT_QUOTE = 85;
		public const int QUOTE_NOT_FOUND = 86;
		public const int OPTIONS_NOT_SUPPORT_ABANDON = 87;
		public const int COMBOPTIONS_SUPPORT_IOC_ONLY = 88;
		public const int OPEN_FILE_FAILED = 89;
		public const int NEED_RETRY = 90;
		//<!--灾备系统错误代码 -->
		public const int NO_TRADING_RIGHT_IN_SEPC_DR = 101;
		public const int NO_DR_NO = 102;
		//<!--转帐系统错误代码 -->
		public const int SEND_INSTITUTION_CODE_ERROR = 1000;
		public const int NO_GET_PLATFORM_SN = 1001;
		public const int ILLEGAL_TRANSFER_BANK = 1002;
		public const int ALREADY_OPEN_ACCOUNT = 1003;
		public const int NOT_OPEN_ACCOUNT = 1004;
		public const int PROCESSING = 1005;
		public const int OVERTIME = 1006;
		public const int RECORD_NOT_FOUND = 1007;
		public const int NO_FOUND_REVERSAL_ORIGINAL_TRANSACTION = 1008;
		public const int CONNECT_HOST_FAILED = 1009;
		public const int SEND_FAILED = 1010;
		public const int LATE_RESPONSE = 1011;
		public const int REVERSAL_BANKID_NOT_MATCH = 1012;
		public const int REVERSAL_BANKACCOUNT_NOT_MATCH = 1013;
		public const int REVERSAL_BROKERID_NOT_MATCH = 1014;
		public const int REVERSAL_ACCOUNTID_NOT_MATCH = 1015;
		public const int REVERSAL_AMOUNT_NOT_MATCH = 1016;
		public const int DB_OPERATION_FAILED = 1017;
		public const int SEND_ASP_FAILURE = 1018;
		public const int NOT_SIGNIN = 1019;
		public const int ALREADY_SIGNIN = 1020;
		public const int AMOUNT_OR_TIMES_OVER = 1021;
		public const int NOT_IN_TRANSFER_TIME = 1022;
		public const int BANK_SERVER_ERROR = 1023;
		public const int BANK_SERIAL_IS_REPEALED = 1024;
		public const int BANK_SERIAL_NOT_EXIST = 1025;
		public const int NOT_ORGAN_MAP = 1026;
		public const int EXIST_TRANSFER = 1027;
		public const int BANK_FORBID_REVERSAL = 1028;
		public const int DUP_BANK_SERIAL = 1029;
		public const int FBT_SYSTEM_BUSY = 1030;
		public const int MACKEY_SYNCING = 1031;
		public const int ACCOUNTID_ALREADY_REGISTER = 1032;
		public const int BANKACCOUNT_ALREADY_REGISTER = 1033;
		public const int DUP_BANK_SERIAL_REDO_OK = 1034;
		public const int CURRENCYID_NOT_SUPPORTED = 1035;
		public const int INVALID_MAC = 1036;
		public const int NOT_SUPPORT_SECAGENT_BY_BANK = 1037;
		public const int PINKEY_SYNCING = 1038;
		public const int SECAGENT_OPEN_ACCOUNT_BY_CCB = 1039;		
		//<!-- add for transfer begin -->
		public const int NO_VALID_BANKOFFER_AVAILABLE = 2000;
		public const int PASSWORD_MISMATCH = 2001;
		public const int DUPLATION_BANK_SERIAL = 2004;
		public const int DUPLATION_OFFER_SERIAL = 2005;
		public const int SERIAL_NOT_EXSIT = 2006;
		public const int SERIAL_IS_REPEALED = 2007;
		public const int SERIAL_MISMATCH = 2008;
		public const int IdentifiedCardNo_MISMATCH = 2009;
		public const int ACCOUNT_NOT_FUND = 2011;
		public const int ACCOUNT_NOT_ACTIVE = 2012;
		public const int NOT_ALLOW_REPEAL_BYMANUAL = 2013;
		public const int AMOUNT_OUTOFTHEWAY = 2014;
		public const int EXCHANGERATE_NOT_FOUND = 2015;
		public const int WAITING_OFFER_RSP = 999999;
		//<!-- add for transfer end -->
		//<!--换汇系统错误代码 bgn-->
		public const int FBE_NO_GET_PLATFORM_SN = 3001;
		public const int FBE_ILLEGAL_TRANSFER_BANK = 3002;
		public const int FBE_PROCESSING = 3005;
		public const int FBE_OVERTIME = 3006;
		public const int FBE_RECORD_NOT_FOUND = 3007;
		public const int FBE_CONNECT_HOST_FAILED = 3009;
		public const int FBE_SEND_FAILED = 3010;
		public const int FBE_LATE_RESPONSE = 3011;
		public const int FBE_DB_OPERATION_FAILED = 3017;
		public const int FBE_NOT_SIGNIN = 3019;
		public const int FBE_ALREADY_SIGNIN = 3020;
		public const int FBE_AMOUNT_OR_TIMES_OVER = 3021;
		public const int FBE_NOT_IN_TRANSFER_TIME = 3022;
		public const int FBE_BANK_SERVER_ERROR = 3023;
		public const int FBE_NOT_ORGAN_MAP = 3026;
		public const int FBE_SYSTEM_BUSY = 3030;
		public const int FBE_CURRENCYID_NOT_SUPPORTED = 3035;
		public const int FBE_WRONG_BANK_ACCOUNT = 3036;
		public const int FBE_BANK_ACCOUNT_NO_FUNDS = 3037;
		public const int FBE_DUP_CERT_NO = 3038;
		//<!--换汇系统错误代码 end-->
	}
}
