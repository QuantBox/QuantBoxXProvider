using System;
using System.Collections.Generic;
using System.Reflection;
using QuantBox.XApi;
using SmartQuant;
using InstrumentType = SmartQuant.InstrumentType;
using PutCall = SmartQuant.PutCall;

namespace QuantBox
{
    internal class Convertor
    {
        private static readonly List<FieldInfo> AccountFields = new List<FieldInfo>();
        private readonly XProvider _provider;
        private readonly Dictionary<string, AccountPosition> _positions = new Dictionary<string, AccountPosition>();
        private readonly IdArray<DepthMarketDataField> _marketData = new IdArray<DepthMarketDataField>();
        private readonly IdArray<bool> _instInitFlag = new IdArray<bool>();

        static Convertor()
        {
            foreach (var field in typeof(AccountField).GetFields()) {
                AccountFields.Add(field);
            }
        }

        public Convertor(XProvider provider)
        {
            _provider = provider;
        }

        public static HedgeFlagType GetHedgeFlag(Order order, HedgeFlagType defaultValue)
        {
            var flag = order.GetHedgeFlag();
            if (flag == HedgeFlagType.Undefined) {
                flag = defaultValue;
            }
            return flag;
        }

        public static XApi.OrderSide GetSide(Order order)
        {
            var side = order.GetSide();
            if (side == XApi.OrderSide.Undefined) {
                return (XApi.OrderSide)order.Side;
            }
            return side;
        }

        public Instrument GetInstument(InstrumentField field)
        {
            var inst = new Instrument((InstrumentType)field.Type, field.Symbol);
            inst.AltId.Add(new AltId(_provider.Id, field.InstrumentID, field.ExchangeID));
            inst.PutCall = (PutCall)field.OptionsType;
            inst.Strike = field.StrikePrice;
            inst.Exchange = field.ExchangeID;
            inst.CurrencyId = CurrencyId.CNY;
            inst.TickSize = field.PriceTick;
            inst.Factor = field.VolumeMultiple;
            inst.PriceFormat = "F" + QBHelper.GetPrecision(field.PriceTick);
            inst.Maturity = field.ExpireDate();
            if (!string.IsNullOrEmpty(field.UnderlyingInstrID)) {
                var underlying = _provider.InstrumentManager.Get(field.UnderlyingInstrID);
                if (underlying == null) {
                    _provider.Logger.Warn($"没有找到合约标的物{field.UnderlyingInstrID},请先导入合约标的物");
                }
                else {
                    inst.Legs.Add(new Leg(underlying));
                }
            }
            return inst;
        }

        public void ProcessAccount(AccountField account)
        {
            var data = new AccountData(DateTime.Now, AccountDataType.AccountValue, account.AccountID, _provider.Id, _provider.Id);
            foreach (var field in AccountFields) {
                data.Fields.Add(field.Name, field.GetValue(account));
            }
            data.Fields.Add(QBHelper.UserDataName, account);
            _provider.ProcessAccount(data);
        }

        public void ProcessPosition(PositionField position)
        {
            if (position == null) {
                return;
            }
            if (!_positions.TryGetValue(position.InstrumentID, out AccountPosition item)) {
                item = new AccountPosition();
                _positions.Add(position.InstrumentID, item);
            }
            item.AddPosition(position);

            var data = new AccountData(DateTime.Now, AccountDataType.Position, position.AccountID, _provider.Id, _provider.Id);
            data.Fields.Add(AccountDataField.SYMBOL, item.InstrumentId);
            data.Fields.Add(AccountDataField.EXCHANGE, item.ExchangeId);
            data.Fields.Add(AccountDataField.QTY, item.Qty);
            data.Fields.Add(AccountDataField.LONG_QTY, item.LongQty);
            data.Fields.Add(AccountDataField.SHORT_QTY, item.ShortQty);
            data.Fields.Add(QBHelper.UserDataName, item);
            _provider.ProcessAccount(data);
        }

        public void ProcessMarketData(DepthMarketDataField field)
        {
            var inst = _provider.InstrumentManager.Get(field.InstrumentID);
            if (!_instInitFlag[inst.Id]) {
                if (field.OpenPrice > 0) {
                    inst.SetMarketData(field);
                    _instInitFlag[inst.Id] = true;
                }
            }
            var last = _marketData[inst.Id]?.Volume ?? 0;
            _marketData[inst.Id] = field;
            var datetime = DateTime.Now;
            var exchageTime = field.ExchangeDateTime();
            if (exchageTime == DateTime.MaxValue) {
                _provider.Logger.Warn($"交易所时间解析错误，{field.ActionDay}.{field.UpdateTime}.{field.UpdateMillisec}");
            }
            if (field.Asks.Length > 0) {
                var ask = new Ask(datetime, exchageTime, _provider.Id, inst.Id, field.Asks[0].Price, field.Asks[0].Size);
                _provider.ProcessMarketData(ask);
            }
            if (field.Bids.Length > 0) {
                var bid = new Bid(datetime, exchageTime, _provider.Id, inst.Id, field.Bids[0].Price, field.Bids[0].Size);
                _provider.ProcessMarketData(bid);
            }
            var trade = new QBTrade(datetime, exchageTime, _provider.Id, inst.Id, field.LastPrice, (int)(field.Volume - last));
            trade.Field = field;
            _provider.ProcessMarketData(trade);
        }
    }
}
