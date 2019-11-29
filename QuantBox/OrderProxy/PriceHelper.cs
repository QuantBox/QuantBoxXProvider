using System;
using SmartQuant;

namespace QuantBox.OrderProxy
{
    internal class PriceHelper
    {
        public double UpperLimitPrice { get; private set; }
        public double LowerLimitPrice { get; private set; }
        public double TickSize { get; private set; }

        public PriceHelper(double tickSize)
        {
            UpperLimitPrice = double.MaxValue;
            LowerLimitPrice = double.MinValue;
            TickSize = Math.Max(0.0001, tickSize);
        }

        public PriceHelper(double upperLimitPrice, double lowerLimitPrice, double tickSize)
        {
            UpperLimitPrice = upperLimitPrice;
            LowerLimitPrice = lowerLimitPrice;
            TickSize = Math.Max(0.0001, tickSize);
        }

        public override string ToString()
        {
            return $"TickSize:{TickSize},LowerLimitPrice:{LowerLimitPrice},UpperLimitPrice:{UpperLimitPrice}";
        }

        public int GetLevelByPrice(double price, OrderSide side)
        {
            price = Math.Min(price, UpperLimitPrice);
            price = Math.Max(price, LowerLimitPrice);

            var index = (int)(side == OrderSide.Buy ? Math.Ceiling(price / TickSize) : Math.Floor(price / TickSize));
            return index;
        }

        public double GetPriceByLevel(int level)
        {
            return Math.Round(level * TickSize, 8);
        }

        public double FixPrice(double price, OrderSide side)
        {
            return GetPriceByLevel(GetLevelByPrice(price, side));
        }

        public double GetMatchPrice(Instrument instrument, OrderSide side)
        {
            if (side == OrderSide.Sell) {
                var bid = instrument.Bid;
                if (bid != null)
                    return bid.Price;
            }

            if (side == OrderSide.Buy) {
                var ask = instrument.Ask;
                if (ask != null)
                    return ask.Price;
            }

            var trade = instrument.Trade;
            if (trade != null)
                return trade.Price;

            var bar = instrument.Bar;
            if (bar != null)
                return bar.Close;

            return 0;
        }

        // 在对手价上加一定跳数
        public double GetMatchPrice(Instrument instrument, OrderSide side, double jump)
        {
            var price = GetMatchPrice(instrument, side);
            if (side == OrderSide.Buy) {
                price += jump * TickSize;
            }
            else {
                price -= jump * TickSize;
            }

            // 修正一下价格
            return FixPrice(price, side);
        }
    }
}