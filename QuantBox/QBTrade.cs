using System;
using QuantBox.XApi;
using SmartQuant;

namespace QuantBox
{
    public class QBTrade : Trade
    {
        public DepthMarketDataField Field;

        public QBTrade()
        {
        }

        public QBTrade(Trade trade) : base(trade)
        {
        }

        public QBTrade(Tick tick) : base(tick)
        {
        }

        public QBTrade(DateTime dateTime, byte providerId, int instrumentId, double price, int size) : base(dateTime, providerId, instrumentId, price, size)
        {
        }

        public QBTrade(DateTime dateTime, byte providerId, int instrumentId, double price, int size, sbyte direction) : base(dateTime, providerId, instrumentId, price, size, direction)
        {
        }

        public QBTrade(DateTime dateTime, DateTime exchangeDateTime, byte providerId, int instrumentId, double price, int size) : base(dateTime, exchangeDateTime, providerId, instrumentId, price, size)
        {
        }

        public QBTrade(DateTime dateTime, DateTime exchangeDateTime, byte providerId, int instrumentId, double price, int size, sbyte direction) : base(dateTime, exchangeDateTime, providerId, instrumentId, price, size, direction)
        {
        }
    }
}