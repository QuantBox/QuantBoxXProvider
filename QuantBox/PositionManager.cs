using System;
using System.Collections.Generic;
using SmartQuant;

namespace QuantBox
{
    public class PositionManager
    {
        private readonly IdArray<DualPosition> _positions = new IdArray<DualPosition>();

        public PositionManager(DateTime lastMarketCloseTime) : this(null, lastMarketCloseTime)
        {
        }

        public PositionManager(Portfolio portfolio, DateTime lastMarketCloseTime)
        {
            if (portfolio != null) {
                InitPosition(portfolio, lastMarketCloseTime);
            }
        }

        private static (double longQty, double shortQty) GetHistoryQty(Position position, DateTime lastMarketCloseTime)
        {
            var longQty = 0d;
            var shortQty = 0d;
            foreach (var fill in position.Fills) {
                if (fill.Order.TransactTime > lastMarketCloseTime) {
                    continue;
                }

                if (fill.Side == OrderSide.Buy) {
                    switch (fill.SubSide) {
                        case SubSide.BuyCover:
                            //买平
                            shortQty -= fill.Qty;
                            break;
                        case SubSide.Undefined:
                            //买开
                            longQty += fill.Qty;
                            break;
                    }
                }
                else {
                    switch (fill.SubSide) {
                        case SubSide.Undefined:
                            //卖平
                            longQty -= fill.Qty;
                            break;
                        case SubSide.SellShort:
                            //卖开
                            shortQty += fill.Qty;
                            break;
                    }
                }
            }

            return (longQty, shortQty);
        }

        private void InitPosition(Portfolio portfolio, DateTime lastMarketCloseTime)
        {
            foreach (var position in portfolio.Positions) {
                (double hisLongQty, double hisShortQty) = GetHistoryQty(position, lastMarketCloseTime);

                var dualPosition = new DualPosition {
                    Instrument = position.Instrument,
                    Long = {
                        Qty = position.LongPositionQty,
                        QtyToday = position.LongPositionQty - hisLongQty
                    },
                    Short = {
                        Qty = position.ShortPositionQty,
                        QtyToday = position.ShortPositionQty - hisShortQty
                    }
                };

                _positions[position.InstrumentId] = dualPosition;
            }
        }

        public IEnumerable<DualPosition> GetAllPositions()
        {
            for (int i = 0; i < _positions.Size; i++) {
                if (_positions[i] != null)
                    yield return _positions[i];
            }
        }

        public DualPosition GetPosition(Instrument instrument, bool createNew = true)
        {
            var record = _positions[instrument.Id];
            if (createNew && record == null) {
                record = new DualPosition {Instrument = instrument};
                _positions[instrument.Id] = record;
            }
            return record;
        }

        public void Reset()
        {
            _positions.Clear();
        }

        public void ChangeTradingDay()
        {
            for (int i = 0; i < _positions.Size; i++) {
                _positions[i]?.ChangeTradingDay();
            }
        }
    }
}
