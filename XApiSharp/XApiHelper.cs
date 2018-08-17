using System;
using System.IO;
using Ideafixxxer.Generics;
using QuantBox.XApi.Nactive;

namespace QuantBox.XApi
{
    public static class XApiHelper
    {
        public static bool IsManagedAssembly(string fileName)
        {
            using (Stream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            using (var binaryReader = new BinaryReader(fileStream)) {
                if (fileStream.Length < 64) {
                    return false;
                }

                //PE Header starts @ 0x3C (60). Its a 4 byte header.
                fileStream.Position = 0x3C;
                var peHeaderPointer = binaryReader.ReadUInt32();
                if (peHeaderPointer == 0) {
                    peHeaderPointer = 0x80;
                }

                // Ensure there is at least enough room for the following structures:
                //     24 byte PE Signature & Header
                //     28 byte Standard Fields         (24 bytes for PE32+)
                //     68 byte NT Fields               (88 bytes for PE32+)
                // >= 128 byte Data Dictionary Table
                if (peHeaderPointer > fileStream.Length - 256) {
                    return false;
                }

                // Check the PE signature.  Should equal 'PE\0\0'.
                fileStream.Position = peHeaderPointer;
                var peHeaderSignature = binaryReader.ReadUInt32();
                if (peHeaderSignature != 0x00004550) {
                    return false;
                }

                // skip over the PEHeader fields
                fileStream.Position += 20;

                const ushort PE32 = 0x10b;
                const ushort PE32Plus = 0x20b;

                // Read PE magic number from Standard Fields to determine format.
                var peFormat = binaryReader.ReadUInt16();
                if (peFormat != PE32 && peFormat != PE32Plus) {
                    return false;
                }

                // Read the 15th Data Dictionary RVA field which contains the CLI header RVA.
                // When this is non-zero then the file contains CLI data otherwise not.
                var dataDictionaryStart = (ushort)(peHeaderPointer + (peFormat == PE32 ? 232 : 248));
                fileStream.Position = dataDictionaryStart;

                var cliHeaderRva = binaryReader.ReadUInt32();
                return cliHeaderRva != 0;
            }
        }
        public static ExchangeType GetExchangeType(string exchange)
        {
            if (string.IsNullOrEmpty(exchange)) {
                return ExchangeType.Undefined;
            }
            switch (exchange[1]) {
                case 'H':
                    return ExchangeType.SHFE;
                case 'C':
                    return ExchangeType.DCE;
                case 'Z':
                    if (exchange[0] == 'C') {
                        return ExchangeType.CZCE;
                    }
                    return ExchangeType.SZSE;
                case 'F':
                    return ExchangeType.CFFEX;
                case 'N':
                    return ExchangeType.INE;
                case 'S':
                    return ExchangeType.SSE;
                case 'G':
                    return ExchangeType.SGE;
                case 'E':
                    return ExchangeType.NEEQ;
                case 'K':
                    return ExchangeType.HKEx;
                default:
                    return ExchangeType.Undefined;
            }
        }

        #region Byte Array Read/Write

        internal static string Text(this InternalErrorField field)
        {
            if (field == null) {
                return string.Empty;
            }
            return PInvokeUtility.ReadString(field.Text);
        }

        internal static string Text(this InternalLogField field)
        {
            if (field == null) {
                return string.Empty;
            }
            return PInvokeUtility.ReadString(field.Message);
        }

        internal static string Text(this InternalRspUserLoginField field)
        {
            if (field == null) {
                return string.Empty;
            }
            return PInvokeUtility.ReadString(field.Text);
        }

        public static string Text(this OrderField field)
        {
            if (field == null) {
                return string.Empty;
            }
            return PInvokeUtility.ReadString(field.Text);
        }

        public static void SetText(this OrderField field, string text)
        {
            field.Text = PInvokeUtility.Gb2312.GetBytes(text);
        }

        internal static string Name(this InternalRspUserLoginField field)
        {
            if (field == null) {
                return string.Empty;
            }
            return PInvokeUtility.ReadString(field.InvestorName);
        }

        public static string Name(this InstrumentField field)
        {
            if (field == null) {
                return string.Empty;
            }
            return PInvokeUtility.ReadString(field.InstrumentName);
        }

        public static void SetName(this InstrumentField field, string name)
        {
            field.InstrumentName = PInvokeUtility.Gb2312.GetBytes(name);
        }

        public static string Name(this PositionField field)
        {
            if (field == null) {
                return string.Empty;
            }
            return PInvokeUtility.ReadString(field.InstrumentName);
        }

        public static string Name(this InvestorField field)
        {
            if (field == null) {
                return string.Empty;
            }
            return PInvokeUtility.ReadString(field.InvestorName);
        }

        #endregion

        #region DateTime

        private static DateTime GetDateTime(int date)
        {
            if (date <= 0) {
                return DateTime.Today;
            }
            var year = date / 10000;
            var month = date % 10000 / 100;
            var day = date % 100;
            return new DateTime(Math.Max(year, 1970), Math.Max(month, 1), Math.Max(day, 1));
        }

        private static DateTime GetDateTime(int date, int time, int ms = 0)
        {
            var hh = time / 10000;
            var mm = time % 10000 / 100;
            var ss = time % 100;
            if (date <= 0) {
                return DateTime.Today.Add(new TimeSpan(hh, mm, ss));
            }
            var year = date / 10000;
            var month = date % 10000 / 100;
            var day = date % 100;
            return new DateTime(Math.Max(year, 1970), Math.Max(month, 1), Math.Max(day, 1), hh, mm, ss, ms);
        }

        public static TimeSpan EnterTime(this InstrumentStatusField field)
        {
            var hh = field.EnterTime / 10000;
            var mm = field.EnterTime % 10000 / 100;
            var ss = field.EnterTime % 100;
            return new TimeSpan(hh, mm, ss);
        }

        public static DateTime TradingDay(this RspUserLoginField field)
        {
            if (field == null || field.TradingDay == 0) {
                return DateTime.MaxValue;
            }
            return field.TradingDay > 0 ? GetDateTime(field.TradingDay) : DateTime.Today;
        }

        public static DateTime TradingDay(this DepthMarketDataField field)
        {
            if (field == null || field.TradingDay == 0) {
                return DateTime.MaxValue;
            }
            return field.TradingDay > 0 ? GetDateTime(field.TradingDay) : DateTime.Today;
        }

        public static DateTime ExchangeDateTime(this DepthMarketDataField field)
        {
            if (field == null || field.UpdateTime <= 0) {
                return DateTime.MaxValue;
            }
            return GetDateTime(field.ActionDay, field.UpdateTime, field.UpdateMillisec);
        }

        public static DateTime UpdateTime(this TradeField field)
        {
            if (field == null || field.Time == 0) {
                return DateTime.MaxValue;
            }
            return GetDateTime(field.Date, field.Time);
        }

        public static DateTime UpdateTime(this OrderField field)
        {
            if (field == null || field.Time == 0) {
                return DateTime.MaxValue;
            }
            return GetDateTime(field.Date, field.Time);
        }

        public static DateTime ExpireDate(this InstrumentField field)
        {
            if (field != null && field.ExpireDate > 0) {
                return GetDateTime(field.ExpireDate);
            }
            return DateTime.MaxValue;
        }

        #endregion

        #region Log Output

        public static string RawErrorMsg(this RspUserLoginField field)
        {
            if (field == null) {
                return string.Empty;
            }
            return $"[XErrorID={field.XErrorID},RawErrorID={field.RawErrorID},Message={field.Text}]";
        }

        public static string DebugInfo(this OrderField field)
        {
            if (field == null) {
                return string.Empty;
            }
            return $"[InstrumentID={field.InstrumentID};ExchangeID={field.ExchangeID};Side={field.Side};Qty={field.Qty};LeavesQty={field.LeavesQty};Price={field.Price};OpenClose={field.OpenClose};HedgeFlag={field.HedgeFlag};LocalID={field.LocalID};ID={field.ID};OrderID={field.OrderID};Date={field.Date};Time={field.Time};Type={field.Type};TimeInForce={field.TimeInForce};Status={field.Status};ExecType={field.ExecType};XErrorID={field.XErrorID};RawErrorID={field.RawErrorID};Text={field.Text()}]";
        }

        public static string DebugInfo(this TradeField field)
        {
            if (field == null) {
                return string.Empty;
            }
            return $"[InstrumentID={field.InstrumentID};ExchangeID={field.ExchangeID};Side={field.Side};Qty={field.Qty};Price={field.Price};OpenClose={field.OpenClose};HedgeFlag={field.HedgeFlag};ID={field.ID};TradeID={field.TradeID};Date={field.Date};Time={field.Time};Commission={field.Commission}]";
        }

        public static string DebugInfo(this RspUserLoginField field)
        {
            if (field == null) {
                return string.Empty;
            }
            return $"[TradingDay={field.TradingDay},LoginTime={field.LoginTime},InvestorName={field.InvestorName},XErrorID={field.XErrorID},Message={field.Text}]";
        }

        public static string DebugInfo(this AccountField field)
        {
            if (field == null) {
                return string.Empty;
            }
            return $"[AccountID={field.AccountID};CurrencyID={field.CurrencyID};Balance={field.Balance};Available={field.Available}]";
        }

        public static string DebugInfo(this PositionField field)
        {
            if (field == null) {
                return string.Empty;
            }
            return $"[{field.InstrumentID};{field.ExchangeID};{Enum<HedgeFlagType>.ToString(field.HedgeFlag)};{Enum<PositionSide>.ToString(field.Side)};Position={field.Position};TodayPosition={field.TodayPosition};HistoryPosition={field.HistoryPosition};ID={field.ID}]";
        }

        #endregion

        public static bool OrderIsDone(this OrderField filed)
        {
            if (filed == null) {
                return false;
            }
            switch (filed.Status) {
                case OrderStatus.Cancelled:
                case OrderStatus.Expired:
                case OrderStatus.Filled:
                case OrderStatus.Rejected:
                case OrderStatus.Replaced:
                    return true;
                default:
                    return false;
            }
        }
    }
}