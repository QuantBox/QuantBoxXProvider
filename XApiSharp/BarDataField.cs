using System;
using System.Collections.Generic;
using System.Text;

namespace QuantBox.XApi
{
    public class BarDataField
    {
        public DateTime CloseDateTime;
        public DateTime OpenDateTime;
        public double Low;
        public double High;
        public double Open;
        public double Close;
        public int Volume;
        public double Turnover;
        public int OpenInterest;
        public string Symbol;
        public long BarSize;

        public BarDataField()
        {
        }

        public BarDataField(DateTime openDateTime, DateTime closeDateTime, string symbol, long barSize, double open, double close, double high, double low, double turnover, int openInterest)
        {
            OpenDateTime = openDateTime;
            CloseDateTime = closeDateTime;
            Symbol = symbol;
            BarSize = barSize;
            Open = open;
            Close = close;
            High = high;
            Low = low;
            OpenInterest = openInterest;
            Turnover = turnover;
        }

        public override string ToString()
        {
            return $"{OpenDateTime:dd_HH:mm}-{CloseDateTime:dd_HH:mm},{Open},{Close},{High},{Low}";
        }
    }
}
