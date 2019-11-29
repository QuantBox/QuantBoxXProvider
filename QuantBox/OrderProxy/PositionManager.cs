using SmartQuant;
using System;
using System.Collections.Generic;
using QuantBox.XApi;
using OrderSide = SmartQuant.OrderSide;

namespace QuantBox.OrderProxy
{
    public class PositionManager
    {
        private readonly IdArray<DualPosition> _positions = new IdArray<DualPosition>();

        private OrderFlags GetOrderFlags(Order order)
        {
            var openCloseType = order.GetOpenClose();
            var isOpen = (openCloseType == OpenCloseType.Open);
            var isCloseToday = (openCloseType == OpenCloseType.CloseToday);
            return new OrderFlags(isOpen, isCloseToday);
        }

        private static bool FillInToday(DateTime openDateTime)
        {
            var now = DateTime.Now;
            if (openDateTime > now) {
                return true;
            }

            if (openDateTime.Date == now.Date) {
                return openDateTime.Hour > 15 || now.Hour <= 15;
            }

            if (TradingCalendar.Instance.GetNextTradingDay(openDateTime) == now.Date) {
                return openDateTime.Hour > 15 && now.Hour <= 15;
            }
            return false;
        }

        public PositionManager(Portfolio portfolio)
        {
            if (portfolio != null) {
                InitPosition(portfolio);
            }
        }

        public void InitPosition(Portfolio portfolio)
        {
            foreach (var position in portfolio.Positions) {
                var dualPosition = new DualPosition {
                    Instrument = position.Instrument,
                    Long = { Qty = position.LongPositionQty },
                    Short = { Qty = position.ShortPositionQty }
                };
                foreach (var fill in position.Fills) {
                    if (FillInToday(fill.DateTime)) {
                        if (fill.Side == OrderSide.Buy) {
                            switch (fill.SubSide) {
                                case SubSide.BuyCover:
                                    dualPosition.Short.QtyToday -= fill.Qty;
                                    break;
                                case SubSide.SellShort:
                                case SubSide.Undefined:
                                    dualPosition.Long.QtyToday += fill.Qty;
                                    break;
                            }
                        }
                        else {
                            switch (fill.SubSide) {
                                case SubSide.BuyCover:
                                case SubSide.Undefined:
                                    dualPosition.Long.QtyToday -= fill.Qty;
                                    break;
                                case SubSide.SellShort:
                                    dualPosition.Short.QtyToday += fill.Qty;
                                    break;
                            }
                        }
                    }
                }
                _positions[position.InstrumentId] = dualPosition;
            }
        }

        public void ProcessExecutionReport(ExecutionReport report)
        {
            GetPosition(report.Instrument).ProcessExecutionReport(report, GetOrderFlags(report.Order));
        }

        public IEnumerable<DualPosition> GetAllPositions()
        {
            for (int i = 0; i < _positions.Size; i++) {
                if (_positions[i] != null)
                    yield return _positions[i];
            }
        }

        public DualPosition GetPosition(Instrument instrument)
        {
            var record = _positions[instrument.Id];
            if (record == null) {
                record = new DualPosition();
                record.Instrument = instrument;
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
