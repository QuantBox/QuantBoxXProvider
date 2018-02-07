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
        private static readonly DepthMarketDataField EmptyMarketData = new DepthMarketDataField();

        private readonly XProvider _provider;
        private readonly Dictionary<string, AccountPosition> _positions = new Dictionary<string, AccountPosition>();
        private readonly IdArray<DepthMarketDataField> _marketData = new IdArray<DepthMarketDataField>();
        private readonly IdArray<bool> _instInitFlag = new IdArray<bool>();
        private readonly IdArray<TimeRangeManager> _instTimeRange = new IdArray<TimeRangeManager>();
        private readonly IDictionary<string, Instrument> _instruments = new Dictionary<string, Instrument>();

        static Convertor()
        {
            foreach (var field in typeof(AccountField).GetFields()) {
                AccountFields.Add(field);
            }
            EmptyMarketData.OpenInterest = 0;
            EmptyMarketData.Turnover = 0;
            EmptyMarketData.Volume = 0;
        }

        public Convertor(XProvider provider)
        {
            _provider = provider;
            Init();
        }

        public void Init()
        {
            _instInitFlag.Clear();
            _instruments.Clear();
            foreach (var inst in _provider.InstrumentManager.Instruments) {
                if (inst.Maturity < DateTime.Today &&
                    (inst.Type == InstrumentType.Future
                        || inst.Type == InstrumentType.FutureOption
                        || inst.Type == InstrumentType.Option))
                    continue;
                var key = inst.GetSymbol(_provider.GetAltId());
                if (inst.Type == InstrumentType.Stock || inst.Type == InstrumentType.Index) {
                    key = key + "." + inst.GetExchange(_provider.GetAltId());
                }
                _instruments.Remove(key);
                _instruments.Add(key, inst);
                _marketData[inst.Id] = EmptyMarketData;
            }
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
            if (!string.IsNullOrEmpty(field.UnderlyingInstrID)
                && field.UnderlyingInstrID != field.ProductID
                && !field.InstrumentID.EndsWith("efp")) {
                var underlying = _provider.InstrumentManager.Get(field.UnderlyingInstrID);
                if (underlying == null) {
                    //_provider.Logger.Warn($"没有找到合约标的物{field.UnderlyingInstrID},请先导入合约标的物");
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
            if (!_positions.TryGetValue(position.InstrumentID, out var item)) {
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
            _instruments.TryGetValue(field.InstrumentID, out var inst);
            if (inst == null) {
                inst = _provider.InstrumentManager.Get(field.InstrumentID);
                if (inst == null) {
                    return;
                }
            }

            var datetime = DateTime.Now;
            var exchangeTime = field.ExchangeDateTime();
            if (exchangeTime.Year == DateTime.MaxValue.Year) {
                _provider.Logger.Warn($"交易所时间解析错误，{field.ActionDay}.{field.UpdateTime}.{field.UpdateMillisec}");
                exchangeTime = datetime;
            }
            else {
                if (_provider.NightTradingTimeCorrection) {
                    exchangeTime = Helper.CorrectionActionDay(datetime, exchangeTime);
                }
            }

            if (!_instInitFlag[inst.Id]) {
                if (datetime.Day == exchangeTime.Day && Math.Abs(datetime.Hour - exchangeTime.Hour) > 1) {
                    return;
                }
                _instTimeRange[inst.Id] = inst.GetTimeFilter();
                if (field.OpenPrice > 0) {
                    inst.SetMarketData(field);
                    _instInitFlag[inst.Id] = true;
                }
            }

            var last = _marketData[inst.Id];
            if (field.ClosePrice > 0) {
                _marketData[inst.Id] = EmptyMarketData;
            }
            else {
                _marketData[inst.Id] = field;
            }

            var filter = _instTimeRange[inst.Id];
            if (_provider.DiscardNoTrading) {
                if (!filter.InRange(exchangeTime.TimeOfDay)) {
                    return;
                }
            }

            if (field.Asks?.Length > 0) {
                var ask = new Ask(datetime, exchangeTime, _provider.Id, inst.Id, field.Asks[0].Price, field.Asks[0].Size);
                _provider.ProcessMarketData(ask);
            }
            if (field.Bids?.Length > 0) {
                var bid = new Bid(datetime, exchangeTime, _provider.Id, inst.Id, field.Bids[0].Price, field.Bids[0].Size);
                _provider.ProcessMarketData(bid);
            }

            if (!(field.LastPrice > double.Epsilon))
                return;

            var trade = new QBTrade(datetime, exchangeTime, _provider.Id, inst.Id, field.LastPrice, 0);
            if (_provider.VolumeIsAccumulated) {
                trade.Size = (int)(field.Volume - last.Volume);
                trade.OpenInterest = field.OpenInterest - last.OpenInterest;
                trade.Turnover = field.Turnover - last.Turnover;
            }
            else {
                trade.Size = (int)field.Volume;
                trade.OpenInterest = field.OpenInterest;
                trade.Turnover = field.Turnover;
            }

            if (_provider.DiscardEmptyTrade && trade.Size <= 0)
                return;
            trade.Field = field;
            _provider.ProcessMarketData(trade);
        }
    }
}
