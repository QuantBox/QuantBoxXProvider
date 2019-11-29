using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SmartQuant;

namespace QuantBox
{
    public class QBCommissionProvider : ICommissionProvider
    {
        public struct InstrumentCommission
        {
            public double Pershare;
            public double Percent;
            public InstrumentCommission(double pershare = 0, double percent = 0)
            {
                Pershare = pershare;
                Percent = percent;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool IsEmpty()
            {
                return Pershare == 0 && Percent == 0;
            }
        }

        private string GetProduct(string symbol)
        {
            var match = Regex.Match(symbol, "([a-zA-Z]+)\\d+");
            if (match.Success) {
                return match.Groups[1].Value;
            }
            return string.Empty;
        }

        private double GetCommission(ExecutionReport report, ref InstrumentCommission ic)
        {
            var num = ic.Pershare * report.LastQty + ic.Percent * report.Instrument.Factor * report.LastQty * report.LastPx;
            return Math.Max(num, MinCommission);
        }

        public QBCommissionProvider()
        {
            InstrumentCommissions = new IdArray<InstrumentCommission>();
            ProductCommissions = new Dictionary<string, InstrumentCommission>();
        }

        public IdArray<InstrumentCommission> InstrumentCommissions;
        public Dictionary<string, InstrumentCommission> ProductCommissions;
        public InstrumentCommission Default;

        public CommissionType Type { get; set; }
        public double Commission { get; set; }
        public double MinCommission { get; set; }

        public double GetCommission(ExecutionReport report)
        {
            var ic = InstrumentCommissions[report.InstrumentId];
            if (ic.IsEmpty()) {
                if (ProductCommissions.TryGetValue(GetProduct(report.Instrument.Symbol), out ic)) {
                    InstrumentCommissions[report.InstrumentId] = ic;
                }
                else
                    ic = Default;
            }
            return GetCommission(report, ref ic);
        }

        public QBCommissionProvider SetDefault(double pershare = 0, double percent = 0)
        {
            Default.Percent = percent;
            Default.Pershare = pershare;
            return this;
        }

        public QBCommissionProvider SetInstrument(Instrument inst, double pershare = 0, double percent = 0)
        {
            InstrumentCommissions[inst.Id] = new InstrumentCommission(pershare, percent);
            return this;
        }

        public QBCommissionProvider SetProduct(string product, double pershare = 0, double percent = 0)
        {
            ProductCommissions[product] = new InstrumentCommission(pershare, percent);
            return this;
        }
    }
}
