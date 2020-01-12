using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartQuant;

namespace TaLib
{
    public partial class Core
    {
        private static void SeriesCopy(SmartQuant.ISeries source, long sourceIndex, Array destinationArray, long destinationIndex, long length)
        {
            for (var i = 0; i < length; i++) {
                destinationArray.SetValue(source[i + (int)sourceIndex], i + destinationIndex);
            }
        }
    }

    public abstract class TaIndicator : SmartQuant.Indicator
    {
        protected static readonly double[] InOpen = { 0 };
        protected static readonly double[] InClose = { 0 };
        protected static readonly double[] InHigh = { 0 };
        protected static readonly double[] InLow = { 0 };
        protected static readonly double[] InVolume = { 0 };

        protected TaIndicator(ISeries input) : base(input)
        {
        }
    }
}
