using System.Collections.Generic;
using NLog;
using SmartQuant;

namespace QuantBox
{
    public class TickSizeSlippageProvider : ISlippageProvider
    {
        public double Slippage { get; set; }

        public IdArray<double> InstrumentSlippages { get; set; } = new IdArray<double>();

        public TickSizeSlippageProvider SetDefault(double slippage)
        {
            Slippage = slippage;
            return this;
        }

        public TickSizeSlippageProvider AddSlippage(Instrument instrument, double slippage)
        {
            if (slippage <= 0) {
                DisableSlippage(instrument);
            }
            else {
                InstrumentSlippages[instrument.Id] = slippage;
            }
            return this;
        }

        public TickSizeSlippageProvider DisableSlippage(Instrument instrument)
        {
            InstrumentSlippages[instrument.Id] = -1;
            return this;
        }

        public double GetPrice(ExecutionReport report)
        {
            var slippage = InstrumentSlippages[report.InstrumentId];
            if (slippage < 0) {
                slippage = Slippage;
            }
            var offset = slippage * report.Instrument.TickSize;
            double price = report.LastPx;
            switch (report.Side) {
                case OrderSide.Buy:
                    price += offset;
                    break;
                case OrderSide.Sell:
                    price -= offset;
                    break;
            }
            return price;
        }
    }
}
