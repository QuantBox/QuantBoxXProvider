using System;
using TaLib;
namespace QuantBox
{
    /// <summary>
    /// Vector Trigonometric ACos (Math Transform)
    /// </summary>
    public class TaAcos : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaAcos";
            description = "Vector Trigonometric ACos (Math Transform)";
            Clear();
            calculate = true;
        }

        public TaAcos(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Acos(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Acos(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Chaikin A/D Line (Volume Indicators)
    /// </summary>
    public class TaAd : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaAd";
            description = "Chaikin A/D Line (Volume Indicators)";
            Clear();
            calculate = true;
        }

        public TaAd(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Ad(index, index, InHigh, InLow, InClose, InVolume,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Ad(index, index, InHigh, InLow, InClose, InVolume,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Vector Arithmetic Add (Math Operators)
    /// </summary>
    public class TaAdd : TaIndicator
    {
        private SmartQuant.ISeries _input2;
        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaAdd";
            description = "Vector Arithmetic Add (Math Operators)";
            Clear();
            calculate = true;
        }

        public TaAdd(SmartQuant.ISeries input, SmartQuant.ISeries input2) : base(input)
        {
            _input2 = input2;
            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Add(index, index, input, _input2,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, SmartQuant.ISeries input2)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Add(index, index, input, input2,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Chaikin A/D Oscillator (Volume Indicators)
    /// </summary>
    public class TaAdOsc : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaAdOsc({FastPeriod},{SlowPeriod})";
            description = "Chaikin A/D Oscillator (Volume Indicators)";
            Clear();
            calculate = true;
        }

        public TaAdOsc(SmartQuant.ISeries input, int fastPeriod = 3, int slowPeriod = 10) : base(input)
        {

            FastPeriod = fastPeriod;
            SlowPeriod = slowPeriod;
            Init();
        }

        public int FastPeriod { get; }
        public int SlowPeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.AdOsc(index, index, InHigh, InLow, InClose, InVolume, FastPeriod, SlowPeriod,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int fastPeriod = 3, int slowPeriod = 10)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.AdOsc(index, index, InHigh, InLow, InClose, InVolume, fastPeriod, slowPeriod,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Average Directional Movement Index (Momentum Indicators)
    /// </summary>
    public class TaAdx : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaAdx({TimePeriod})";
            description = "Average Directional Movement Index (Momentum Indicators)";
            Clear();
            calculate = true;
        }

        public TaAdx(SmartQuant.ISeries input, int timePeriod = 14) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Adx(index, index, InHigh, InLow, InClose, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 14)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Adx(index, index, InHigh, InLow, InClose, timePeriod,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Average Directional Movement Index Rating (Momentum Indicators)
    /// </summary>
    public class TaAdxr : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaAdxr({TimePeriod})";
            description = "Average Directional Movement Index Rating (Momentum Indicators)";
            Clear();
            calculate = true;
        }

        public TaAdxr(SmartQuant.ISeries input, int timePeriod = 14) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Adxr(index, index, InHigh, InLow, InClose, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 14)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Adxr(index, index, InHigh, InLow, InClose, timePeriod,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Absolute Price Oscillator (Momentum Indicators)
    /// </summary>
    public class TaApo : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaApo({FastPeriod},{SlowPeriod},{MAType})";
            description = "Absolute Price Oscillator (Momentum Indicators)";
            Clear();
            calculate = true;
        }

        public TaApo(SmartQuant.ISeries input, int fastPeriod = 12, int slowPeriod = 26, TaLib.Core.MAType maType = TaLib.Core.MAType.Sma) : base(input)
        {

            FastPeriod = fastPeriod;
            SlowPeriod = slowPeriod;
            MAType = maType;
            Init();
        }

        public int FastPeriod { get; }
        public int SlowPeriod { get; }
        public TaLib.Core.MAType MAType { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Apo(index, index, input, FastPeriod, SlowPeriod, MAType,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int fastPeriod = 12, int slowPeriod = 26, TaLib.Core.MAType maType = TaLib.Core.MAType.Sma)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Apo(index, index, input, fastPeriod, slowPeriod, maType,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Aroon (Momentum Indicators)
    /// </summary>
    public class TaAroon : TaIndicator
    {

        private readonly double[] _AroonDown = new double[1];
        private readonly double[] _AroonUp = new double[1];
        protected override void Init()
        {
            name = $"TaAroon({TimePeriod})";
            description = "Aroon (Momentum Indicators)";
            Clear();
            calculate = true;
        }

        public TaAroon(SmartQuant.ISeries input, int timePeriod = 14) : base(input)
        {

            TimePeriod = timePeriod;
            AroonUp = new SmartQuant.TimeSeries();
            Init();
        }

        public int TimePeriod { get; }
        public SmartQuant.TimeSeries AroonDown => this;
        public SmartQuant.TimeSeries AroonUp { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Aroon(index, index, InHigh, InLow, TimePeriod,
                ref outBegIdx, ref outNBElement, _AroonDown, _AroonUp, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _AroonDown[0]);
                AroonUp.Add(datetime, _AroonUp[0]);
            }
        }

        public static (double, double) Value(SmartQuant.ISeries input, int index, int timePeriod = 14)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _AroonDown = new double[1];
            var _AroonUp = new double[1];
            var ret = TaLib.Core.Aroon(index, index, InHigh, InLow, timePeriod,
                ref outBegIdx, ref outNBElement, _AroonDown, _AroonUp, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return (_AroonDown[0], _AroonUp[0]);
            }
            return (double.NaN, double.NaN);
        }
    }
    /// <summary>
    /// Aroon Oscillator (Momentum Indicators)
    /// </summary>
    public class TaAroonOsc : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaAroonOsc({TimePeriod})";
            description = "Aroon Oscillator (Momentum Indicators)";
            Clear();
            calculate = true;
        }

        public TaAroonOsc(SmartQuant.ISeries input, int timePeriod = 14) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.AroonOsc(index, index, InHigh, InLow, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 14)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.AroonOsc(index, index, InHigh, InLow, timePeriod,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Vector Trigonometric ASin (Math Transform)
    /// </summary>
    public class TaAsin : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaAsin";
            description = "Vector Trigonometric ASin (Math Transform)";
            Clear();
            calculate = true;
        }

        public TaAsin(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Asin(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Asin(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Vector Trigonometric ATan (Math Transform)
    /// </summary>
    public class TaAtan : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaAtan";
            description = "Vector Trigonometric ATan (Math Transform)";
            Clear();
            calculate = true;
        }

        public TaAtan(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Atan(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Atan(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Average True Range (Volatility Indicators)
    /// </summary>
    public class TaAtr : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaAtr({TimePeriod})";
            description = "Average True Range (Volatility Indicators)";
            Clear();
            calculate = true;
        }

        public TaAtr(SmartQuant.ISeries input, int timePeriod = 14) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Atr(index, index, InHigh, InLow, InClose, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 14)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Atr(index, index, InHigh, InLow, InClose, timePeriod,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Average Price (Price Transform)
    /// </summary>
    public class TaAvgPrice : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaAvgPrice";
            description = "Average Price (Price Transform)";
            Clear();
            calculate = true;
        }

        public TaAvgPrice(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.AvgPrice(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.AvgPrice(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Bollinger Bands (Overlap Studies)
    /// </summary>
    public class TaBbands : TaIndicator
    {

        private readonly double[] _RealUpperBand = new double[1];
        private readonly double[] _RealMiddleBand = new double[1];
        private readonly double[] _RealLowerBand = new double[1];
        protected override void Init()
        {
            name = $"TaBbands({TimePeriod},{DeviationsUp},{DeviationsDown},{MAType})";
            description = "Bollinger Bands (Overlap Studies)";
            Clear();
            calculate = true;
        }

        public TaBbands(SmartQuant.ISeries input, int timePeriod = 5, double deviationsUp = 2.000000e+0, double deviationsDown = 2.000000e+0, TaLib.Core.MAType maType = TaLib.Core.MAType.Sma) : base(input)
        {

            TimePeriod = timePeriod;
            DeviationsUp = deviationsUp;
            DeviationsDown = deviationsDown;
            MAType = maType;
            RealMiddleBand = new SmartQuant.TimeSeries();
            RealLowerBand = new SmartQuant.TimeSeries();
            Init();
        }

        public int TimePeriod { get; }
        public double DeviationsUp { get; }
        public double DeviationsDown { get; }
        public TaLib.Core.MAType MAType { get; }
        public SmartQuant.TimeSeries RealUpperBand => this;
        public SmartQuant.TimeSeries RealMiddleBand { get; }

        public SmartQuant.TimeSeries RealLowerBand { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Bbands(index, index, input, TimePeriod, DeviationsUp, DeviationsDown, MAType,
                ref outBegIdx, ref outNBElement, _RealUpperBand, _RealMiddleBand, _RealLowerBand);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _RealUpperBand[0]);
                RealMiddleBand.Add(datetime, _RealMiddleBand[0]);

                RealLowerBand.Add(datetime, _RealLowerBand[0]);
            }
        }

        public static (double, double, double) Value(SmartQuant.ISeries input, int index, int timePeriod = 5, double deviationsUp = 2.000000e+0, double deviationsDown = 2.000000e+0, TaLib.Core.MAType maType = TaLib.Core.MAType.Sma)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _RealUpperBand = new double[1];
            var _RealMiddleBand = new double[1];
            var _RealLowerBand = new double[1];
            var ret = TaLib.Core.Bbands(index, index, input, timePeriod, deviationsUp, deviationsDown, maType,
                ref outBegIdx, ref outNBElement, _RealUpperBand, _RealMiddleBand, _RealLowerBand);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return (_RealUpperBand[0], _RealMiddleBand[0], _RealLowerBand[0]);
            }
            return (double.NaN, double.NaN, double.NaN);
        }
    }
    /// <summary>
    /// Beta (Statistic Functions)
    /// </summary>
    public class TaBeta : TaIndicator
    {
        private SmartQuant.ISeries _input2;
        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaBeta({TimePeriod})";
            description = "Beta (Statistic Functions)";
            Clear();
            calculate = true;
        }

        public TaBeta(SmartQuant.ISeries input, SmartQuant.ISeries input2, int timePeriod = 5) : base(input)
        {
            _input2 = input2;
            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Beta(index, index, input, _input2, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, SmartQuant.ISeries input2, int timePeriod = 5)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Beta(index, index, input, input2, timePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Balance Of Power (Momentum Indicators)
    /// </summary>
    public class TaBop : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaBop";
            description = "Balance Of Power (Momentum Indicators)";
            Clear();
            calculate = true;
        }

        public TaBop(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Bop(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Bop(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Commodity Channel Index (Momentum Indicators)
    /// </summary>
    public class TaCci : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaCci({TimePeriod})";
            description = "Commodity Channel Index (Momentum Indicators)";
            Clear();
            calculate = true;
        }

        public TaCci(SmartQuant.ISeries input, int timePeriod = 14) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Cci(index, index, InHigh, InLow, InClose, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 14)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Cci(index, index, InHigh, InLow, InClose, timePeriod,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Two Crows (Pattern Recognition)
    /// </summary>
    public class TaCdl2Crows : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdl2Crows";
            description = "Two Crows (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdl2Crows(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Cdl2Crows(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.Cdl2Crows(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Three Black Crows (Pattern Recognition)
    /// </summary>
    public class TaCdl3BlackCrows : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdl3BlackCrows";
            description = "Three Black Crows (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdl3BlackCrows(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Cdl3BlackCrows(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.Cdl3BlackCrows(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Three Inside Up/Down (Pattern Recognition)
    /// </summary>
    public class TaCdl3Inside : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdl3Inside";
            description = "Three Inside Up/Down (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdl3Inside(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Cdl3Inside(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.Cdl3Inside(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Three-Line Strike  (Pattern Recognition)
    /// </summary>
    public class TaCdl3LineStrike : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdl3LineStrike";
            description = "Three-Line Strike  (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdl3LineStrike(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Cdl3LineStrike(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.Cdl3LineStrike(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Three Outside Up/Down (Pattern Recognition)
    /// </summary>
    public class TaCdl3Outside : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdl3Outside";
            description = "Three Outside Up/Down (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdl3Outside(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Cdl3Outside(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.Cdl3Outside(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Three Stars In The South (Pattern Recognition)
    /// </summary>
    public class TaCdl3StarsInSouth : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdl3StarsInSouth";
            description = "Three Stars In The South (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdl3StarsInSouth(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Cdl3StarsInSouth(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.Cdl3StarsInSouth(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Three Advancing White Soldiers (Pattern Recognition)
    /// </summary>
    public class TaCdl3WhiteSoldiers : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdl3WhiteSoldiers";
            description = "Three Advancing White Soldiers (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdl3WhiteSoldiers(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Cdl3WhiteSoldiers(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.Cdl3WhiteSoldiers(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Abandoned Baby (Pattern Recognition)
    /// </summary>
    public class TaCdlAbandonedBaby : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlAbandonedBaby({Penetration})";
            description = "Abandoned Baby (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlAbandonedBaby(SmartQuant.ISeries input, double penetration = 3.000000e-1) : base(input)
        {

            Penetration = penetration;
            Init();
        }

        public double Penetration { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlAbandonedBaby(index, index, InOpen, InHigh, InLow, InClose, Penetration,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index, double penetration = 3.000000e-1)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlAbandonedBaby(index, index, InOpen, InHigh, InLow, InClose, penetration,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Advance Block (Pattern Recognition)
    /// </summary>
    public class TaCdlAdvanceBlock : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlAdvanceBlock";
            description = "Advance Block (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlAdvanceBlock(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlAdvanceBlock(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlAdvanceBlock(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Belt-hold (Pattern Recognition)
    /// </summary>
    public class TaCdlBeltHold : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlBeltHold";
            description = "Belt-hold (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlBeltHold(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlBeltHold(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlBeltHold(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Breakaway (Pattern Recognition)
    /// </summary>
    public class TaCdlBreakaway : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlBreakaway";
            description = "Breakaway (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlBreakaway(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlBreakaway(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlBreakaway(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Closing Marubozu (Pattern Recognition)
    /// </summary>
    public class TaCdlClosingMarubozu : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlClosingMarubozu";
            description = "Closing Marubozu (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlClosingMarubozu(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlClosingMarubozu(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlClosingMarubozu(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Concealing Baby Swallow (Pattern Recognition)
    /// </summary>
    public class TaCdlConcealBabysWall : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlConcealBabysWall";
            description = "Concealing Baby Swallow (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlConcealBabysWall(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlConcealBabysWall(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlConcealBabysWall(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Counterattack (Pattern Recognition)
    /// </summary>
    public class TaCdlCounterAttack : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlCounterAttack";
            description = "Counterattack (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlCounterAttack(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlCounterAttack(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlCounterAttack(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Dark Cloud Cover (Pattern Recognition)
    /// </summary>
    public class TaCdlDarkCloudCover : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlDarkCloudCover({Penetration})";
            description = "Dark Cloud Cover (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlDarkCloudCover(SmartQuant.ISeries input, double penetration = 5.000000e-1) : base(input)
        {

            Penetration = penetration;
            Init();
        }

        public double Penetration { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlDarkCloudCover(index, index, InOpen, InHigh, InLow, InClose, Penetration,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index, double penetration = 5.000000e-1)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlDarkCloudCover(index, index, InOpen, InHigh, InLow, InClose, penetration,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Doji (Pattern Recognition)
    /// </summary>
    public class TaCdlDoji : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlDoji";
            description = "Doji (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlDoji(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlDoji(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlDoji(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Doji Star (Pattern Recognition)
    /// </summary>
    public class TaCdlDojiStar : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlDojiStar";
            description = "Doji Star (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlDojiStar(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlDojiStar(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlDojiStar(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Dragonfly Doji (Pattern Recognition)
    /// </summary>
    public class TaCdlDragonflyDoji : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlDragonflyDoji";
            description = "Dragonfly Doji (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlDragonflyDoji(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlDragonflyDoji(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlDragonflyDoji(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Engulfing Pattern (Pattern Recognition)
    /// </summary>
    public class TaCdlEngulfing : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlEngulfing";
            description = "Engulfing Pattern (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlEngulfing(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlEngulfing(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlEngulfing(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Evening Doji Star (Pattern Recognition)
    /// </summary>
    public class TaCdlEveningDojiStar : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlEveningDojiStar({Penetration})";
            description = "Evening Doji Star (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlEveningDojiStar(SmartQuant.ISeries input, double penetration = 3.000000e-1) : base(input)
        {

            Penetration = penetration;
            Init();
        }

        public double Penetration { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlEveningDojiStar(index, index, InOpen, InHigh, InLow, InClose, Penetration,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index, double penetration = 3.000000e-1)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlEveningDojiStar(index, index, InOpen, InHigh, InLow, InClose, penetration,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Evening Star (Pattern Recognition)
    /// </summary>
    public class TaCdlEveningStar : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlEveningStar({Penetration})";
            description = "Evening Star (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlEveningStar(SmartQuant.ISeries input, double penetration = 3.000000e-1) : base(input)
        {

            Penetration = penetration;
            Init();
        }

        public double Penetration { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlEveningStar(index, index, InOpen, InHigh, InLow, InClose, Penetration,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index, double penetration = 3.000000e-1)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlEveningStar(index, index, InOpen, InHigh, InLow, InClose, penetration,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Up/Down-gap side-by-side white lines (Pattern Recognition)
    /// </summary>
    public class TaCdlGapSideSideWhite : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlGapSideSideWhite";
            description = "Up/Down-gap side-by-side white lines (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlGapSideSideWhite(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlGapSideSideWhite(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlGapSideSideWhite(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Gravestone Doji (Pattern Recognition)
    /// </summary>
    public class TaCdlGravestoneDoji : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlGravestoneDoji";
            description = "Gravestone Doji (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlGravestoneDoji(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlGravestoneDoji(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlGravestoneDoji(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Hammer (Pattern Recognition)
    /// </summary>
    public class TaCdlHammer : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlHammer";
            description = "Hammer (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlHammer(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlHammer(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlHammer(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Hanging Man (Pattern Recognition)
    /// </summary>
    public class TaCdlHangingMan : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlHangingMan";
            description = "Hanging Man (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlHangingMan(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlHangingMan(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlHangingMan(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Harami Pattern (Pattern Recognition)
    /// </summary>
    public class TaCdlHarami : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlHarami";
            description = "Harami Pattern (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlHarami(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlHarami(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlHarami(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Harami Cross Pattern (Pattern Recognition)
    /// </summary>
    public class TaCdlHaramiCross : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlHaramiCross";
            description = "Harami Cross Pattern (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlHaramiCross(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlHaramiCross(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlHaramiCross(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// High-Wave Candle (Pattern Recognition)
    /// </summary>
    public class TaCdlHignWave : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlHignWave";
            description = "High-Wave Candle (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlHignWave(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlHignWave(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlHignWave(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Hikkake Pattern (Pattern Recognition)
    /// </summary>
    public class TaCdlHikkake : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlHikkake";
            description = "Hikkake Pattern (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlHikkake(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlHikkake(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlHikkake(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Modified Hikkake Pattern (Pattern Recognition)
    /// </summary>
    public class TaCdlHikkakeMod : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlHikkakeMod";
            description = "Modified Hikkake Pattern (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlHikkakeMod(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlHikkakeMod(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlHikkakeMod(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Homing Pigeon (Pattern Recognition)
    /// </summary>
    public class TaCdlHomingPigeon : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlHomingPigeon";
            description = "Homing Pigeon (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlHomingPigeon(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlHomingPigeon(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlHomingPigeon(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Identical Three Crows (Pattern Recognition)
    /// </summary>
    public class TaCdlIdentical3Crows : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlIdentical3Crows";
            description = "Identical Three Crows (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlIdentical3Crows(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlIdentical3Crows(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlIdentical3Crows(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// In-Neck Pattern (Pattern Recognition)
    /// </summary>
    public class TaCdlInNeck : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlInNeck";
            description = "In-Neck Pattern (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlInNeck(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlInNeck(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlInNeck(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Inverted Hammer (Pattern Recognition)
    /// </summary>
    public class TaCdlInvertedHammer : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlInvertedHammer";
            description = "Inverted Hammer (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlInvertedHammer(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlInvertedHammer(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlInvertedHammer(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Kicking (Pattern Recognition)
    /// </summary>
    public class TaCdlKicking : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlKicking";
            description = "Kicking (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlKicking(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlKicking(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlKicking(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Kicking - bull/bear determined by the longer marubozu (Pattern Recognition)
    /// </summary>
    public class TaCdlKickingByLength : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlKickingByLength";
            description = "Kicking - bull/bear determined by the longer marubozu (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlKickingByLength(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlKickingByLength(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlKickingByLength(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Ladder Bottom (Pattern Recognition)
    /// </summary>
    public class TaCdlLadderBottom : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlLadderBottom";
            description = "Ladder Bottom (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlLadderBottom(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlLadderBottom(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlLadderBottom(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Long Legged Doji (Pattern Recognition)
    /// </summary>
    public class TaCdlLongLeggedDoji : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlLongLeggedDoji";
            description = "Long Legged Doji (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlLongLeggedDoji(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlLongLeggedDoji(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlLongLeggedDoji(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Long Line Candle (Pattern Recognition)
    /// </summary>
    public class TaCdlLongLine : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlLongLine";
            description = "Long Line Candle (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlLongLine(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlLongLine(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlLongLine(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Marubozu (Pattern Recognition)
    /// </summary>
    public class TaCdlMarubozu : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlMarubozu";
            description = "Marubozu (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlMarubozu(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlMarubozu(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlMarubozu(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Matching Low (Pattern Recognition)
    /// </summary>
    public class TaCdlMatchingLow : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlMatchingLow";
            description = "Matching Low (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlMatchingLow(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlMatchingLow(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlMatchingLow(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Mat Hold (Pattern Recognition)
    /// </summary>
    public class TaCdlMatHold : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlMatHold({Penetration})";
            description = "Mat Hold (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlMatHold(SmartQuant.ISeries input, double penetration = 5.000000e-1) : base(input)
        {

            Penetration = penetration;
            Init();
        }

        public double Penetration { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlMatHold(index, index, InOpen, InHigh, InLow, InClose, Penetration,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index, double penetration = 5.000000e-1)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlMatHold(index, index, InOpen, InHigh, InLow, InClose, penetration,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Morning Doji Star (Pattern Recognition)
    /// </summary>
    public class TaCdlMorningDojiStar : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlMorningDojiStar({Penetration})";
            description = "Morning Doji Star (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlMorningDojiStar(SmartQuant.ISeries input, double penetration = 3.000000e-1) : base(input)
        {

            Penetration = penetration;
            Init();
        }

        public double Penetration { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlMorningDojiStar(index, index, InOpen, InHigh, InLow, InClose, Penetration,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index, double penetration = 3.000000e-1)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlMorningDojiStar(index, index, InOpen, InHigh, InLow, InClose, penetration,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Morning Star (Pattern Recognition)
    /// </summary>
    public class TaCdlMorningStar : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlMorningStar({Penetration})";
            description = "Morning Star (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlMorningStar(SmartQuant.ISeries input, double penetration = 3.000000e-1) : base(input)
        {

            Penetration = penetration;
            Init();
        }

        public double Penetration { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlMorningStar(index, index, InOpen, InHigh, InLow, InClose, Penetration,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index, double penetration = 3.000000e-1)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlMorningStar(index, index, InOpen, InHigh, InLow, InClose, penetration,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// On-Neck Pattern (Pattern Recognition)
    /// </summary>
    public class TaCdlOnNeck : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlOnNeck";
            description = "On-Neck Pattern (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlOnNeck(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlOnNeck(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlOnNeck(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Piercing Pattern (Pattern Recognition)
    /// </summary>
    public class TaCdlPiercing : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlPiercing";
            description = "Piercing Pattern (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlPiercing(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlPiercing(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlPiercing(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Rickshaw Man (Pattern Recognition)
    /// </summary>
    public class TaCdlRickshawMan : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlRickshawMan";
            description = "Rickshaw Man (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlRickshawMan(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlRickshawMan(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlRickshawMan(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Rising/Falling Three Methods (Pattern Recognition)
    /// </summary>
    public class TaCdlRiseFall3Methods : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlRiseFall3Methods";
            description = "Rising/Falling Three Methods (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlRiseFall3Methods(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlRiseFall3Methods(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlRiseFall3Methods(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Separating Lines (Pattern Recognition)
    /// </summary>
    public class TaCdlSeperatingLines : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlSeperatingLines";
            description = "Separating Lines (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlSeperatingLines(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlSeperatingLines(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlSeperatingLines(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Shooting Star (Pattern Recognition)
    /// </summary>
    public class TaCdlShootingStar : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlShootingStar";
            description = "Shooting Star (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlShootingStar(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlShootingStar(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlShootingStar(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Short Line Candle (Pattern Recognition)
    /// </summary>
    public class TaCdlShortLine : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlShortLine";
            description = "Short Line Candle (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlShortLine(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlShortLine(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlShortLine(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Spinning Top (Pattern Recognition)
    /// </summary>
    public class TaCdlSpinningTop : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlSpinningTop";
            description = "Spinning Top (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlSpinningTop(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlSpinningTop(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlSpinningTop(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Stalled Pattern (Pattern Recognition)
    /// </summary>
    public class TaCdlStalledPattern : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlStalledPattern";
            description = "Stalled Pattern (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlStalledPattern(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlStalledPattern(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlStalledPattern(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Stick Sandwich (Pattern Recognition)
    /// </summary>
    public class TaCdlStickSandwhich : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlStickSandwhich";
            description = "Stick Sandwich (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlStickSandwhich(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlStickSandwhich(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlStickSandwhich(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Takuri (Dragonfly Doji with very long lower shadow) (Pattern Recognition)
    /// </summary>
    public class TaCdlTakuri : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlTakuri";
            description = "Takuri (Dragonfly Doji with very long lower shadow) (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlTakuri(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlTakuri(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlTakuri(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Tasuki Gap (Pattern Recognition)
    /// </summary>
    public class TaCdlTasukiGap : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlTasukiGap";
            description = "Tasuki Gap (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlTasukiGap(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlTasukiGap(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlTasukiGap(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Thrusting Pattern (Pattern Recognition)
    /// </summary>
    public class TaCdlThrusting : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlThrusting";
            description = "Thrusting Pattern (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlThrusting(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlThrusting(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlThrusting(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Tristar Pattern (Pattern Recognition)
    /// </summary>
    public class TaCdlTristar : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlTristar";
            description = "Tristar Pattern (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlTristar(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlTristar(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlTristar(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Unique 3 River (Pattern Recognition)
    /// </summary>
    public class TaCdlUnique3River : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlUnique3River";
            description = "Unique 3 River (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlUnique3River(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlUnique3River(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlUnique3River(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Upside Gap Two Crows (Pattern Recognition)
    /// </summary>
    public class TaCdlUpsideGap2Crows : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlUpsideGap2Crows";
            description = "Upside Gap Two Crows (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlUpsideGap2Crows(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlUpsideGap2Crows(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlUpsideGap2Crows(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Upside/Downside Gap Three Methods (Pattern Recognition)
    /// </summary>
    public class TaCdlXSideGap3Methods : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaCdlXSideGap3Methods";
            description = "Upside/Downside Gap Three Methods (Pattern Recognition)";
            Clear();
            calculate = true;
        }

        public TaCdlXSideGap3Methods(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.CdlXSideGap3Methods(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.CdlXSideGap3Methods(index, index, InOpen, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Integer, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Vector Ceil (Math Transform)
    /// </summary>
    public class TaCeil : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaCeil";
            description = "Vector Ceil (Math Transform)";
            Clear();
            calculate = true;
        }

        public TaCeil(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Ceil(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Ceil(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Chande Momentum Oscillator (Momentum Indicators)
    /// </summary>
    public class TaCmo : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaCmo({TimePeriod})";
            description = "Chande Momentum Oscillator (Momentum Indicators)";
            Clear();
            calculate = true;
        }

        public TaCmo(SmartQuant.ISeries input, int timePeriod = 14) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Cmo(index, index, input, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 14)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Cmo(index, index, input, timePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Pearson's Correlation Coefficient (r) (Statistic Functions)
    /// </summary>
    public class TaCorrel : TaIndicator
    {
        private SmartQuant.ISeries _input2;
        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaCorrel({TimePeriod})";
            description = "Pearson's Correlation Coefficient (r) (Statistic Functions)";
            Clear();
            calculate = true;
        }

        public TaCorrel(SmartQuant.ISeries input, SmartQuant.ISeries input2, int timePeriod = 30) : base(input)
        {
            _input2 = input2;
            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Correl(index, index, input, _input2, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, SmartQuant.ISeries input2, int timePeriod = 30)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Correl(index, index, input, input2, timePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Vector Trigonometric Cos (Math Transform)
    /// </summary>
    public class TaCos : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaCos";
            description = "Vector Trigonometric Cos (Math Transform)";
            Clear();
            calculate = true;
        }

        public TaCos(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Cos(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Cos(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Vector Trigonometric Cosh (Math Transform)
    /// </summary>
    public class TaCosh : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaCosh";
            description = "Vector Trigonometric Cosh (Math Transform)";
            Clear();
            calculate = true;
        }

        public TaCosh(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Cosh(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Cosh(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Double Exponential Moving Average (Overlap Studies)
    /// </summary>
    public class TaDema : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaDema({TimePeriod})";
            description = "Double Exponential Moving Average (Overlap Studies)";
            Clear();
            calculate = true;
        }

        public TaDema(SmartQuant.ISeries input, int timePeriod = 30) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Dema(index, index, input, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 30)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Dema(index, index, input, timePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Vector Arithmetic Div (Math Operators)
    /// </summary>
    public class TaDiv : TaIndicator
    {
        private SmartQuant.ISeries _input2;
        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaDiv";
            description = "Vector Arithmetic Div (Math Operators)";
            Clear();
            calculate = true;
        }

        public TaDiv(SmartQuant.ISeries input, SmartQuant.ISeries input2) : base(input)
        {
            _input2 = input2;
            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Div(index, index, input, _input2,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, SmartQuant.ISeries input2)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Div(index, index, input, input2,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Directional Movement Index (Momentum Indicators)
    /// </summary>
    public class TaDx : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaDx({TimePeriod})";
            description = "Directional Movement Index (Momentum Indicators)";
            Clear();
            calculate = true;
        }

        public TaDx(SmartQuant.ISeries input, int timePeriod = 14) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Dx(index, index, InHigh, InLow, InClose, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 14)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Dx(index, index, InHigh, InLow, InClose, timePeriod,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Exponential Moving Average (Overlap Studies)
    /// </summary>
    public class TaEma : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaEma({TimePeriod})";
            description = "Exponential Moving Average (Overlap Studies)";
            Clear();
            calculate = true;
        }

        public TaEma(SmartQuant.ISeries input, int timePeriod = 30) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Ema(index, index, input, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 30)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Ema(index, index, input, timePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Vector Arithmetic Exp (Math Transform)
    /// </summary>
    public class TaExp : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaExp";
            description = "Vector Arithmetic Exp (Math Transform)";
            Clear();
            calculate = true;
        }

        public TaExp(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Exp(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Exp(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Vector Floor (Math Transform)
    /// </summary>
    public class TaFloor : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaFloor";
            description = "Vector Floor (Math Transform)";
            Clear();
            calculate = true;
        }

        public TaFloor(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Floor(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Floor(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Hilbert Transform - Dominant Cycle Period (Cycle Indicators)
    /// </summary>
    public class TaHtDcPeriod : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaHtDcPeriod";
            description = "Hilbert Transform - Dominant Cycle Period (Cycle Indicators)";
            Clear();
            calculate = true;
        }

        public TaHtDcPeriod(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.HtDcPeriod(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.HtDcPeriod(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Hilbert Transform - Dominant Cycle Phase (Cycle Indicators)
    /// </summary>
    public class TaHtDcPhase : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaHtDcPhase";
            description = "Hilbert Transform - Dominant Cycle Phase (Cycle Indicators)";
            Clear();
            calculate = true;
        }

        public TaHtDcPhase(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.HtDcPhase(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.HtDcPhase(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Hilbert Transform - Phasor Components (Cycle Indicators)
    /// </summary>
    public class TaHtPhasor : TaIndicator
    {

        private readonly double[] _InPhase = new double[1];
        private readonly double[] _Quadrature = new double[1];
        protected override void Init()
        {
            name = $"TaHtPhasor";
            description = "Hilbert Transform - Phasor Components (Cycle Indicators)";
            Clear();
            calculate = true;
        }

        public TaHtPhasor(SmartQuant.ISeries input) : base(input)
        {

            Quadrature = new SmartQuant.TimeSeries();
            Init();
        }

        public SmartQuant.TimeSeries InPhase => this;
        public SmartQuant.TimeSeries Quadrature { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.HtPhasor(index, index, input,
                ref outBegIdx, ref outNBElement, _InPhase, _Quadrature);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _InPhase[0]);
                Quadrature.Add(datetime, _Quadrature[0]);
            }
        }

        public static (double, double) Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _InPhase = new double[1];
            var _Quadrature = new double[1];
            var ret = TaLib.Core.HtPhasor(index, index, input,
                ref outBegIdx, ref outNBElement, _InPhase, _Quadrature);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return (_InPhase[0], _Quadrature[0]);
            }
            return (double.NaN, double.NaN);
        }
    }
    /// <summary>
    /// Hilbert Transform - SineWave (Cycle Indicators)
    /// </summary>
    public class TaHtSine : TaIndicator
    {

        private readonly double[] _Sine = new double[1];
        private readonly double[] _LeadSine = new double[1];
        protected override void Init()
        {
            name = $"TaHtSine";
            description = "Hilbert Transform - SineWave (Cycle Indicators)";
            Clear();
            calculate = true;
        }

        public TaHtSine(SmartQuant.ISeries input) : base(input)
        {

            LeadSine = new SmartQuant.TimeSeries();
            Init();
        }

        public SmartQuant.TimeSeries Sine => this;
        public SmartQuant.TimeSeries LeadSine { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.HtSine(index, index, input,
                ref outBegIdx, ref outNBElement, _Sine, _LeadSine);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Sine[0]);
                LeadSine.Add(datetime, _LeadSine[0]);
            }
        }

        public static (double, double) Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Sine = new double[1];
            var _LeadSine = new double[1];
            var ret = TaLib.Core.HtSine(index, index, input,
                ref outBegIdx, ref outNBElement, _Sine, _LeadSine);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return (_Sine[0], _LeadSine[0]);
            }
            return (double.NaN, double.NaN);
        }
    }
    /// <summary>
    /// Hilbert Transform - Instantaneous Trendline (Overlap Studies)
    /// </summary>
    public class TaHtTrendline : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaHtTrendline";
            description = "Hilbert Transform - Instantaneous Trendline (Overlap Studies)";
            Clear();
            calculate = true;
        }

        public TaHtTrendline(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.HtTrendline(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.HtTrendline(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Hilbert Transform - Trend vs Cycle Mode (Cycle Indicators)
    /// </summary>
    public class TaHtTrendMode : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaHtTrendMode";
            description = "Hilbert Transform - Trend vs Cycle Mode (Cycle Indicators)";
            Clear();
            calculate = true;
        }

        public TaHtTrendMode(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.HtTrendMode(index, index, input,
                ref outBegIdx, ref outNBElement, _Integer);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.HtTrendMode(index, index, input,
                ref outBegIdx, ref outNBElement, _Integer);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Kaufman Adaptive Moving Average (Overlap Studies)
    /// </summary>
    public class TaKama : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaKama({TimePeriod})";
            description = "Kaufman Adaptive Moving Average (Overlap Studies)";
            Clear();
            calculate = true;
        }

        public TaKama(SmartQuant.ISeries input, int timePeriod = 30) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Kama(index, index, input, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 30)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Kama(index, index, input, timePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Linear Regression (Statistic Functions)
    /// </summary>
    public class TaLinearReg : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaLinearReg({TimePeriod})";
            description = "Linear Regression (Statistic Functions)";
            Clear();
            calculate = true;
        }

        public TaLinearReg(SmartQuant.ISeries input, int timePeriod = 14) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.LinearReg(index, index, input, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 14)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.LinearReg(index, index, input, timePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Linear Regression Angle (Statistic Functions)
    /// </summary>
    public class TaLinearRegAngle : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaLinearRegAngle({TimePeriod})";
            description = "Linear Regression Angle (Statistic Functions)";
            Clear();
            calculate = true;
        }

        public TaLinearRegAngle(SmartQuant.ISeries input, int timePeriod = 14) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.LinearRegAngle(index, index, input, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 14)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.LinearRegAngle(index, index, input, timePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Linear Regression Intercept (Statistic Functions)
    /// </summary>
    public class TaLinearRegIntercept : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaLinearRegIntercept({TimePeriod})";
            description = "Linear Regression Intercept (Statistic Functions)";
            Clear();
            calculate = true;
        }

        public TaLinearRegIntercept(SmartQuant.ISeries input, int timePeriod = 14) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.LinearRegIntercept(index, index, input, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 14)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.LinearRegIntercept(index, index, input, timePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Linear Regression Slope (Statistic Functions)
    /// </summary>
    public class TaLinearRegSlope : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaLinearRegSlope({TimePeriod})";
            description = "Linear Regression Slope (Statistic Functions)";
            Clear();
            calculate = true;
        }

        public TaLinearRegSlope(SmartQuant.ISeries input, int timePeriod = 14) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.LinearRegSlope(index, index, input, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 14)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.LinearRegSlope(index, index, input, timePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Vector Log Natural (Math Transform)
    /// </summary>
    public class TaLn : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaLn";
            description = "Vector Log Natural (Math Transform)";
            Clear();
            calculate = true;
        }

        public TaLn(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Ln(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Ln(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Vector Log10 (Math Transform)
    /// </summary>
    public class TaLog10 : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaLog10";
            description = "Vector Log10 (Math Transform)";
            Clear();
            calculate = true;
        }

        public TaLog10(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Log10(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Log10(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Moving average (Overlap Studies)
    /// </summary>
    public class TaMovingAverage : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaMovingAverage({TimePeriod},{MAType})";
            description = "Moving average (Overlap Studies)";
            Clear();
            calculate = true;
        }

        public TaMovingAverage(SmartQuant.ISeries input, int timePeriod = 30, TaLib.Core.MAType maType = TaLib.Core.MAType.Sma) : base(input)
        {

            TimePeriod = timePeriod;
            MAType = maType;
            Init();
        }

        public int TimePeriod { get; }
        public TaLib.Core.MAType MAType { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.MovingAverage(index, index, input, TimePeriod, MAType,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 30, TaLib.Core.MAType maType = TaLib.Core.MAType.Sma)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.MovingAverage(index, index, input, timePeriod, maType,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Moving Average Convergence/Divergence (Momentum Indicators)
    /// </summary>
    public class TaMacd : TaIndicator
    {

        private readonly double[] _MACD = new double[1];
        private readonly double[] _MACDSignal = new double[1];
        private readonly double[] _MACDHist = new double[1];
        protected override void Init()
        {
            name = $"TaMacd({FastPeriod},{SlowPeriod},{SignalPeriod})";
            description = "Moving Average Convergence/Divergence (Momentum Indicators)";
            Clear();
            calculate = true;
        }

        public TaMacd(SmartQuant.ISeries input, int fastPeriod = 12, int slowPeriod = 26, int signalPeriod = 9) : base(input)
        {

            FastPeriod = fastPeriod;
            SlowPeriod = slowPeriod;
            SignalPeriod = signalPeriod;
            MACDSignal = new SmartQuant.TimeSeries();
            MACDHist = new SmartQuant.TimeSeries();
            Init();
        }

        public int FastPeriod { get; }
        public int SlowPeriod { get; }
        public int SignalPeriod { get; }
        public SmartQuant.TimeSeries MACD => this;
        public SmartQuant.TimeSeries MACDSignal { get; }

        public SmartQuant.TimeSeries MACDHist { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Macd(index, index, input, FastPeriod, SlowPeriod, SignalPeriod,
                ref outBegIdx, ref outNBElement, _MACD, _MACDSignal, _MACDHist);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _MACD[0]);
                MACDSignal.Add(datetime, _MACDSignal[0]);
                MACDHist.Add(datetime, _MACDHist[0]);
            }
        }

        public static (double, double, double) Value(SmartQuant.ISeries input, int index, int fastPeriod = 12, int slowPeriod = 26, int signalPeriod = 9)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _MACD = new double[1];
            var _MACDSignal = new double[1];
            var _MACDHist = new double[1];
            var ret = TaLib.Core.Macd(index, index, input, fastPeriod, slowPeriod, signalPeriod,
                ref outBegIdx, ref outNBElement, _MACD, _MACDSignal, _MACDHist);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return (_MACD[0], _MACDSignal[0], _MACDHist[0]);
            }
            return (double.NaN, double.NaN, double.NaN);
        }
    }
    /// <summary>
    /// MACD with controllable MA type (Momentum Indicators)
    /// </summary>
    public class TaMacdExt : TaIndicator
    {

        private readonly double[] _MACD = new double[1];
        private readonly double[] _MACDSignal = new double[1];
        private readonly double[] _MACDHist = new double[1];
        protected override void Init()
        {
            name = $"TaMacdExt({FastPeriod},{FastMA},{SlowPeriod},{SlowMA},{SignalPeriod},{SignalMA})";
            description = "MACD with controllable MA type (Momentum Indicators)";
            Clear();
            calculate = true;
        }

        public TaMacdExt(SmartQuant.ISeries input, int fastPeriod = 12, TaLib.Core.MAType fastMA = TaLib.Core.MAType.Sma, int slowPeriod = 26, TaLib.Core.MAType slowMA = TaLib.Core.MAType.Sma, int signalPeriod = 9, TaLib.Core.MAType signalMA = TaLib.Core.MAType.Sma) : base(input)
        {

            FastPeriod = fastPeriod;
            FastMA = fastMA;
            SlowPeriod = slowPeriod;
            SlowMA = slowMA;
            SignalPeriod = signalPeriod;
            SignalMA = signalMA;
            MACDSignal = new SmartQuant.TimeSeries();
            MACDHist = new SmartQuant.TimeSeries();
            Init();
        }

        public int FastPeriod { get; }
        public TaLib.Core.MAType FastMA { get; }
        public int SlowPeriod { get; }
        public TaLib.Core.MAType SlowMA { get; }
        public int SignalPeriod { get; }
        public TaLib.Core.MAType SignalMA { get; }
        public SmartQuant.TimeSeries MACD => this;
        public SmartQuant.TimeSeries MACDSignal { get; }

        public SmartQuant.TimeSeries MACDHist { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.MacdExt(index, index, input, FastPeriod, FastMA, SlowPeriod, SlowMA, SignalPeriod, SignalMA,
                ref outBegIdx, ref outNBElement, _MACD, _MACDSignal, _MACDHist);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _MACD[0]);
                MACDSignal.Add(datetime, _MACDSignal[0]);

                MACDHist.Add(datetime, _MACDHist[0]);
            }
        }

        public static (double, double, double) Value(SmartQuant.ISeries input, int index, int fastPeriod = 12, TaLib.Core.MAType fastMA = TaLib.Core.MAType.Sma, int slowPeriod = 26, TaLib.Core.MAType slowMA = TaLib.Core.MAType.Sma, int signalPeriod = 9, TaLib.Core.MAType signalMA = TaLib.Core.MAType.Sma)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _MACD = new double[1];
            var _MACDSignal = new double[1];
            var _MACDHist = new double[1];
            var ret = TaLib.Core.MacdExt(index, index, input, fastPeriod, fastMA, slowPeriod, slowMA, signalPeriod, signalMA,
                ref outBegIdx, ref outNBElement, _MACD, _MACDSignal, _MACDHist);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return (_MACD[0], _MACDSignal[0], _MACDHist[0]);
            }
            return (double.NaN, double.NaN, double.NaN);
        }
    }
    /// <summary>
    /// Moving Average Convergence/Divergence Fix 12/26 (Momentum Indicators)
    /// </summary>
    public class TaMacdFix : TaIndicator
    {

        private readonly double[] _MACD = new double[1];
        private readonly double[] _MACDSignal = new double[1];
        private readonly double[] _MACDHist = new double[1];
        protected override void Init()
        {
            name = $"TaMacdFix({SignalPeriod})";
            description = "Moving Average Convergence/Divergence Fix 12/26 (Momentum Indicators)";
            Clear();
            calculate = true;
        }

        public TaMacdFix(SmartQuant.ISeries input, int signalPeriod = 9) : base(input)
        {

            SignalPeriod = signalPeriod;
            MACDSignal = new SmartQuant.TimeSeries();
            MACDHist = new SmartQuant.TimeSeries();
            Init();
        }

        public int SignalPeriod { get; }
        public SmartQuant.TimeSeries MACD => this;
        public SmartQuant.TimeSeries MACDSignal { get; }

        public SmartQuant.TimeSeries MACDHist { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.MacdFix(index, index, input, SignalPeriod,
                ref outBegIdx, ref outNBElement, _MACD, _MACDSignal, _MACDHist);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _MACD[0]);
                MACDSignal.Add(datetime, _MACDSignal[0]);

                MACDHist.Add(datetime, _MACDHist[0]);
            }
        }

        public static (double, double, double) Value(SmartQuant.ISeries input, int index, int signalPeriod = 9)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _MACD = new double[1];
            var _MACDSignal = new double[1];
            var _MACDHist = new double[1];
            var ret = TaLib.Core.MacdFix(index, index, input, signalPeriod,
                ref outBegIdx, ref outNBElement, _MACD, _MACDSignal, _MACDHist);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return (_MACD[0], _MACDSignal[0], _MACDHist[0]);
            }
            return (double.NaN, double.NaN, double.NaN);
        }
    }
    /// <summary>
    /// MESA Adaptive Moving Average (Overlap Studies)
    /// </summary>
    public class TaMama : TaIndicator
    {

        private readonly double[] _MAMA = new double[1];
        private readonly double[] _FAMA = new double[1];
        protected override void Init()
        {
            name = $"TaMama({FastLimit},{SlowLimit})";
            description = "MESA Adaptive Moving Average (Overlap Studies)";
            Clear();
            calculate = true;
        }

        public TaMama(SmartQuant.ISeries input, double fastLimit = 5.000000e-1, double slowLimit = 5.000000e-2) : base(input)
        {

            FastLimit = fastLimit;
            SlowLimit = slowLimit;
            FAMA = new SmartQuant.TimeSeries();
            Init();
        }

        public double FastLimit { get; }
        public double SlowLimit { get; }
        public SmartQuant.TimeSeries MAMA => this;
        public SmartQuant.TimeSeries FAMA { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Mama(index, index, input, FastLimit, SlowLimit,
                ref outBegIdx, ref outNBElement, _MAMA, _FAMA);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _MAMA[0]);
                FAMA.Add(datetime, _FAMA[0]);
            }
        }

        public static (double, double) Value(SmartQuant.ISeries input, int index, double fastLimit = 5.000000e-1, double slowLimit = 5.000000e-2)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _MAMA = new double[1];
            var _FAMA = new double[1];
            var ret = TaLib.Core.Mama(index, index, input, fastLimit, slowLimit,
                ref outBegIdx, ref outNBElement, _MAMA, _FAMA);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return (_MAMA[0], _FAMA[0]);
            }
            return (double.NaN, double.NaN);
        }
    }
    /// <summary>
    /// Moving average with variable period (Overlap Studies)
    /// </summary>
    public class TaMovingAverageVariablePeriod : TaIndicator
    {
        private SmartQuant.ISeries _input2;
        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaMovingAverageVariablePeriod({MinimumPeriod},{MaximumPeriod},{MAType})";
            description = "Moving average with variable period (Overlap Studies)";
            Clear();
            calculate = true;
        }

        public TaMovingAverageVariablePeriod(SmartQuant.ISeries input, SmartQuant.ISeries input2, int minimumPeriod = 2, int maximumPeriod = 30, TaLib.Core.MAType maType = TaLib.Core.MAType.Sma) : base(input)
        {
            _input2 = input2;
            MinimumPeriod = minimumPeriod;
            MaximumPeriod = maximumPeriod;
            MAType = maType;
            Init();
        }

        public int MinimumPeriod { get; }
        public int MaximumPeriod { get; }
        public TaLib.Core.MAType MAType { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.MovingAverageVariablePeriod(index, index, input, _input2, MinimumPeriod, MaximumPeriod, MAType,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, SmartQuant.ISeries input2, int minimumPeriod = 2, int maximumPeriod = 30, TaLib.Core.MAType maType = TaLib.Core.MAType.Sma)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.MovingAverageVariablePeriod(index, index, input, input2, minimumPeriod, maximumPeriod, maType,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Highest value over a specified period (Math Operators)
    /// </summary>
    public class TaMax : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaMax({TimePeriod})";
            description = "Highest value over a specified period (Math Operators)";
            Clear();
            calculate = true;
        }

        public TaMax(SmartQuant.ISeries input, int timePeriod = 30) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Max(index, index, input, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 30)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Max(index, index, input, timePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Index of highest value over a specified period (Math Operators)
    /// </summary>
    public class TaMaxIndex : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaMaxIndex({TimePeriod})";
            description = "Index of highest value over a specified period (Math Operators)";
            Clear();
            calculate = true;
        }

        public TaMaxIndex(SmartQuant.ISeries input, int timePeriod = 30) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.MaxIndex(index, index, input, TimePeriod,
                ref outBegIdx, ref outNBElement, _Integer);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index, int timePeriod = 30)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.MaxIndex(index, index, input, timePeriod,
                ref outBegIdx, ref outNBElement, _Integer);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Median Price (Price Transform)
    /// </summary>
    public class TaMedPrice : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaMedPrice";
            description = "Median Price (Price Transform)";
            Clear();
            calculate = true;
        }

        public TaMedPrice(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.MedPrice(index, index, InHigh, InLow,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.MedPrice(index, index, InHigh, InLow,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Money Flow Index (Momentum Indicators)
    /// </summary>
    public class TaMfi : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaMfi({TimePeriod})";
            description = "Money Flow Index (Momentum Indicators)";
            Clear();
            calculate = true;
        }

        public TaMfi(SmartQuant.ISeries input, int timePeriod = 14) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Mfi(index, index, InHigh, InLow, InClose, InVolume, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 14)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Mfi(index, index, InHigh, InLow, InClose, InVolume, timePeriod,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// MidPoint over period (Overlap Studies)
    /// </summary>
    public class TaMidPoint : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaMidPoint({TimePeriod})";
            description = "MidPoint over period (Overlap Studies)";
            Clear();
            calculate = true;
        }

        public TaMidPoint(SmartQuant.ISeries input, int timePeriod = 14) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.MidPoint(index, index, input, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 14)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.MidPoint(index, index, input, timePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Midpoint Price over period (Overlap Studies)
    /// </summary>
    public class TaMidPrice : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaMidPrice({TimePeriod})";
            description = "Midpoint Price over period (Overlap Studies)";
            Clear();
            calculate = true;
        }

        public TaMidPrice(SmartQuant.ISeries input, int timePeriod = 14) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.MidPrice(index, index, InHigh, InLow, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 14)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.MidPrice(index, index, InHigh, InLow, timePeriod,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Lowest value over a specified period (Math Operators)
    /// </summary>
    public class TaMin : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaMin({TimePeriod})";
            description = "Lowest value over a specified period (Math Operators)";
            Clear();
            calculate = true;
        }

        public TaMin(SmartQuant.ISeries input, int timePeriod = 30) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Min(index, index, input, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 30)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Min(index, index, input, timePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Index of lowest value over a specified period (Math Operators)
    /// </summary>
    public class TaMinIndex : TaIndicator
    {

        private readonly int[] _Integer = new int[1];
        protected override void Init()
        {
            name = $"TaMinIndex({TimePeriod})";
            description = "Index of lowest value over a specified period (Math Operators)";
            Clear();
            calculate = true;
        }

        public TaMinIndex(SmartQuant.ISeries input, int timePeriod = 30) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.MinIndex(index, index, input, TimePeriod,
                ref outBegIdx, ref outNBElement, _Integer);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Integer[0]);
            }
        }

        public static int Value(SmartQuant.ISeries input, int index, int timePeriod = 30)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Integer = new int[1];
            var ret = TaLib.Core.MinIndex(index, index, input, timePeriod,
                ref outBegIdx, ref outNBElement, _Integer);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Integer[0];
            }
            return -1;
        }
    }
    /// <summary>
    /// Lowest and highest values over a specified period (Math Operators)
    /// </summary>
    public class TaMinMax : TaIndicator
    {

        private readonly double[] _Min = new double[1];
        private readonly double[] _Max = new double[1];
        protected override void Init()
        {
            name = $"TaMinMax({TimePeriod})";
            description = "Lowest and highest values over a specified period (Math Operators)";
            Clear();
            calculate = true;
        }

        public TaMinMax(SmartQuant.ISeries input, int timePeriod = 30) : base(input)
        {

            TimePeriod = timePeriod;
            Max = new SmartQuant.TimeSeries();
            Init();
        }

        public int TimePeriod { get; }
        public SmartQuant.TimeSeries Min => this;
        public SmartQuant.TimeSeries Max { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.MinMax(index, index, input, TimePeriod,
                ref outBegIdx, ref outNBElement, _Min, _Max);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Min[0]);
                Max.Add(datetime, _Max[0]);
            }
        }

        public static (double, double) Value(SmartQuant.ISeries input, int index, int timePeriod = 30)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Min = new double[1];
            var _Max = new double[1];
            var ret = TaLib.Core.MinMax(index, index, input, timePeriod,
                ref outBegIdx, ref outNBElement, _Min, _Max);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return (_Min[0], _Max[0]);
            }
            return (double.NaN, double.NaN);
        }
    }
    /// <summary>
    /// Indexes of lowest and highest values over a specified period (Math Operators)
    /// </summary>
    public class TaMinMaxIndex : TaIndicator
    {

        private readonly int[] _MinIdx = new int[1];
        private readonly int[] _MaxIdx = new int[1];
        protected override void Init()
        {
            name = $"TaMinMaxIndex({TimePeriod})";
            description = "Indexes of lowest and highest values over a specified period (Math Operators)";
            Clear();
            calculate = true;
        }

        public TaMinMaxIndex(SmartQuant.ISeries input, int timePeriod = 30) : base(input)
        {

            TimePeriod = timePeriod;
            MaxIdx = new SmartQuant.TimeSeries();
            Init();
        }

        public int TimePeriod { get; }
        public SmartQuant.TimeSeries MinIdx => this;
        public SmartQuant.TimeSeries MaxIdx { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.MinMaxIndex(index, index, input, TimePeriod,
                ref outBegIdx, ref outNBElement, _MinIdx, _MaxIdx);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _MinIdx[0]);
                MaxIdx.Add(datetime, _MaxIdx[0]);
            }
        }

        public static (int, int) Value(SmartQuant.ISeries input, int index, int timePeriod = 30)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _MinIdx = new int[1];
            var _MaxIdx = new int[1];
            var ret = TaLib.Core.MinMaxIndex(index, index, input, timePeriod,
                ref outBegIdx, ref outNBElement, _MinIdx, _MaxIdx);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return (_MinIdx[0], _MaxIdx[0]);
            }
            return (-1, -1);
        }
    }
    /// <summary>
    /// Minus Directional Indicator (Momentum Indicators)
    /// </summary>
    public class TaMinusDI : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaMinusDI({TimePeriod})";
            description = "Minus Directional Indicator (Momentum Indicators)";
            Clear();
            calculate = true;
        }

        public TaMinusDI(SmartQuant.ISeries input, int timePeriod = 14) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.MinusDI(index, index, InHigh, InLow, InClose, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 14)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.MinusDI(index, index, InHigh, InLow, InClose, timePeriod,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Minus Directional Movement (Momentum Indicators)
    /// </summary>
    public class TaMinusDM : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaMinusDM({TimePeriod})";
            description = "Minus Directional Movement (Momentum Indicators)";
            Clear();
            calculate = true;
        }

        public TaMinusDM(SmartQuant.ISeries input, int timePeriod = 14) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.MinusDM(index, index, InHigh, InLow, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 14)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.MinusDM(index, index, InHigh, InLow, timePeriod,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Momentum (Momentum Indicators)
    /// </summary>
    public class TaMom : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaMom({TimePeriod})";
            description = "Momentum (Momentum Indicators)";
            Clear();
            calculate = true;
        }

        public TaMom(SmartQuant.ISeries input, int timePeriod = 10) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Mom(index, index, input, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 10)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Mom(index, index, input, timePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Vector Arithmetic Mult (Math Operators)
    /// </summary>
    public class TaMult : TaIndicator
    {
        private SmartQuant.ISeries _input2;
        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaMult";
            description = "Vector Arithmetic Mult (Math Operators)";
            Clear();
            calculate = true;
        }

        public TaMult(SmartQuant.ISeries input, SmartQuant.ISeries input2) : base(input)
        {
            _input2 = input2;
            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Mult(index, index, input, _input2,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, SmartQuant.ISeries input2)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Mult(index, index, input, input2,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Normalized Average True Range (Volatility Indicators)
    /// </summary>
    public class TaNatr : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaNatr({TimePeriod})";
            description = "Normalized Average True Range (Volatility Indicators)";
            Clear();
            calculate = true;
        }

        public TaNatr(SmartQuant.ISeries input, int timePeriod = 14) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Natr(index, index, InHigh, InLow, InClose, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 14)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Natr(index, index, InHigh, InLow, InClose, timePeriod,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// On Balance Volume (Volume Indicators)
    /// </summary>
    public class TaObv : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaObv";
            description = "On Balance Volume (Volume Indicators)";
            Clear();
            calculate = true;
        }

        public TaObv(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Obv(index, index, InClose, InVolume,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Obv(index, index, InClose, InVolume,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Plus Directional Indicator (Momentum Indicators)
    /// </summary>
    public class TaPlusDI : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaPlusDI({TimePeriod})";
            description = "Plus Directional Indicator (Momentum Indicators)";
            Clear();
            calculate = true;
        }

        public TaPlusDI(SmartQuant.ISeries input, int timePeriod = 14) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.PlusDI(index, index, InHigh, InLow, InClose, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 14)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.PlusDI(index, index, InHigh, InLow, InClose, timePeriod,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Plus Directional Movement (Momentum Indicators)
    /// </summary>
    public class TaPlusDM : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaPlusDM({TimePeriod})";
            description = "Plus Directional Movement (Momentum Indicators)";
            Clear();
            calculate = true;
        }

        public TaPlusDM(SmartQuant.ISeries input, int timePeriod = 14) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.PlusDM(index, index, InHigh, InLow, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 14)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.PlusDM(index, index, InHigh, InLow, timePeriod,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Percentage Price Oscillator (Momentum Indicators)
    /// </summary>
    public class TaPpo : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaPpo({FastPeriod},{SlowPeriod},{MAType})";
            description = "Percentage Price Oscillator (Momentum Indicators)";
            Clear();
            calculate = true;
        }

        public TaPpo(SmartQuant.ISeries input, int fastPeriod = 12, int slowPeriod = 26, TaLib.Core.MAType maType = TaLib.Core.MAType.Sma) : base(input)
        {

            FastPeriod = fastPeriod;
            SlowPeriod = slowPeriod;
            MAType = maType;
            Init();
        }

        public int FastPeriod { get; }
        public int SlowPeriod { get; }
        public TaLib.Core.MAType MAType { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Ppo(index, index, input, FastPeriod, SlowPeriod, MAType,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int fastPeriod = 12, int slowPeriod = 26, TaLib.Core.MAType maType = TaLib.Core.MAType.Sma)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Ppo(index, index, input, fastPeriod, slowPeriod, maType,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Rate of change : ((price/prevPrice)-1)*100 (Momentum Indicators)
    /// </summary>
    public class TaRoc : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaRoc({TimePeriod})";
            description = "Rate of change : ((price/prevPrice)-1)*100 (Momentum Indicators)";
            Clear();
            calculate = true;
        }

        public TaRoc(SmartQuant.ISeries input, int timePeriod = 10) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Roc(index, index, input, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 10)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Roc(index, index, input, timePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Rate of change Percentage: (price-prevPrice)/prevPrice (Momentum Indicators)
    /// </summary>
    public class TaRocP : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaRocP({TimePeriod})";
            description = "Rate of change Percentage: (price-prevPrice)/prevPrice (Momentum Indicators)";
            Clear();
            calculate = true;
        }

        public TaRocP(SmartQuant.ISeries input, int timePeriod = 10) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.RocP(index, index, input, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 10)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.RocP(index, index, input, timePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Rate of change ratio: (price/prevPrice) (Momentum Indicators)
    /// </summary>
    public class TaRocR : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaRocR({TimePeriod})";
            description = "Rate of change ratio: (price/prevPrice) (Momentum Indicators)";
            Clear();
            calculate = true;
        }

        public TaRocR(SmartQuant.ISeries input, int timePeriod = 10) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.RocR(index, index, input, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 10)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.RocR(index, index, input, timePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Rate of change ratio 100 scale: (price/prevPrice)*100 (Momentum Indicators)
    /// </summary>
    public class TaRocR100 : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaRocR100({TimePeriod})";
            description = "Rate of change ratio 100 scale: (price/prevPrice)*100 (Momentum Indicators)";
            Clear();
            calculate = true;
        }

        public TaRocR100(SmartQuant.ISeries input, int timePeriod = 10) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.RocR100(index, index, input, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 10)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.RocR100(index, index, input, timePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Relative Strength Index (Momentum Indicators)
    /// </summary>
    public class TaRsi : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaRsi({TimePeriod})";
            description = "Relative Strength Index (Momentum Indicators)";
            Clear();
            calculate = true;
        }

        public TaRsi(SmartQuant.ISeries input, int timePeriod = 14) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Rsi(index, index, input, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 14)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Rsi(index, index, input, timePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Parabolic SAR (Overlap Studies)
    /// </summary>
    public class TaSar : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaSar({AccelerationFactor},{AFMaximum})";
            description = "Parabolic SAR (Overlap Studies)";
            Clear();
            calculate = true;
        }

        public TaSar(SmartQuant.ISeries input, double accelerationFactor = 2.000000e-2, double aFMaximum = 2.000000e-1) : base(input)
        {

            AccelerationFactor = accelerationFactor;
            AFMaximum = aFMaximum;
            Init();
        }

        public double AccelerationFactor { get; }
        public double AFMaximum { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Sar(index, index, InHigh, InLow, AccelerationFactor, AFMaximum,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, double accelerationFactor = 2.000000e-2, double aFMaximum = 2.000000e-1)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Sar(index, index, InHigh, InLow, accelerationFactor, aFMaximum,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Parabolic SAR - Extended (Overlap Studies)
    /// </summary>
    public class TaSarExt : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaSarExt({StartValue},{OffsetonReverse},{AFInitLong},{AFLong},{AFMaxLong},{AFInitShort},{AFShort},{AFMaxShort})";
            description = "Parabolic SAR - Extended (Overlap Studies)";
            Clear();
            calculate = true;
        }

        public TaSarExt(SmartQuant.ISeries input, double startValue = 0.000000e+0, double offsetonReverse = 0.000000e+0, double aFInitLong = 2.000000e-2, double aFLong = 2.000000e-2, double aFMaxLong = 2.000000e-1, double aFInitShort = 2.000000e-2, double aFShort = 2.000000e-2, double aFMaxShort = 2.000000e-1) : base(input)
        {

            StartValue = startValue;
            OffsetonReverse = offsetonReverse;
            AFInitLong = aFInitLong;
            AFLong = aFLong;
            AFMaxLong = aFMaxLong;
            AFInitShort = aFInitShort;
            AFShort = aFShort;
            AFMaxShort = aFMaxShort;
            Init();
        }

        public double StartValue { get; }
        public double OffsetonReverse { get; }
        public double AFInitLong { get; }
        public double AFLong { get; }
        public double AFMaxLong { get; }
        public double AFInitShort { get; }
        public double AFShort { get; }
        public double AFMaxShort { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.SarExt(index, index, InHigh, InLow, StartValue, OffsetonReverse, AFInitLong, AFLong, AFMaxLong, AFInitShort, AFShort, AFMaxShort,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, double startValue = 0.000000e+0, double offsetonReverse = 0.000000e+0, double aFInitLong = 2.000000e-2, double aFLong = 2.000000e-2, double aFMaxLong = 2.000000e-1, double aFInitShort = 2.000000e-2, double aFShort = 2.000000e-2, double aFMaxShort = 2.000000e-1)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.SarExt(index, index, InHigh, InLow, startValue, offsetonReverse, aFInitLong, aFLong, aFMaxLong, aFInitShort, aFShort, aFMaxShort,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Vector Trigonometric Sin (Math Transform)
    /// </summary>
    public class TaSin : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaSin";
            description = "Vector Trigonometric Sin (Math Transform)";
            Clear();
            calculate = true;
        }

        public TaSin(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Sin(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Sin(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Vector Trigonometric Sinh (Math Transform)
    /// </summary>
    public class TaSinh : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaSinh";
            description = "Vector Trigonometric Sinh (Math Transform)";
            Clear();
            calculate = true;
        }

        public TaSinh(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Sinh(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Sinh(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Simple Moving Average (Overlap Studies)
    /// </summary>
    public class TaSma : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaSma({TimePeriod})";
            description = "Simple Moving Average (Overlap Studies)";
            Clear();
            calculate = true;
        }

        public TaSma(SmartQuant.ISeries input, int timePeriod = 30) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Sma(index, index, input, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 30)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Sma(index, index, input, timePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Vector Square Root (Math Transform)
    /// </summary>
    public class TaSqrt : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaSqrt";
            description = "Vector Square Root (Math Transform)";
            Clear();
            calculate = true;
        }

        public TaSqrt(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Sqrt(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Sqrt(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Standard Deviation (Statistic Functions)
    /// </summary>
    public class TaStdDev : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaStdDev({TimePeriod},{Deviations})";
            description = "Standard Deviation (Statistic Functions)";
            Clear();
            calculate = true;
        }

        public TaStdDev(SmartQuant.ISeries input, int timePeriod = 5, double deviations = 1.000000e+0) : base(input)
        {

            TimePeriod = timePeriod;
            Deviations = deviations;
            Init();
        }

        public int TimePeriod { get; }
        public double Deviations { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.StdDev(index, index, input, TimePeriod, Deviations,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 5, double deviations = 1.000000e+0)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.StdDev(index, index, input, timePeriod, deviations,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Stochastic (Momentum Indicators)
    /// </summary>
    public class TaStoch : TaIndicator
    {

        private readonly double[] _SlowK = new double[1];
        private readonly double[] _SlowD = new double[1];
        protected override void Init()
        {
            name = $"TaStoch({FastKPeriod},{SlowKPeriod},{SlowKMA},{SlowDPeriod},{SlowDMA})";
            description = "Stochastic (Momentum Indicators)";
            Clear();
            calculate = true;
        }

        public TaStoch(SmartQuant.ISeries input, int fastKPeriod = 5, int slowKPeriod = 3, TaLib.Core.MAType slowKMA = TaLib.Core.MAType.Sma, int slowDPeriod = 3, TaLib.Core.MAType slowDMA = TaLib.Core.MAType.Sma) : base(input)
        {

            FastKPeriod = fastKPeriod;
            SlowKPeriod = slowKPeriod;
            SlowKMA = slowKMA;
            SlowDPeriod = slowDPeriod;
            SlowDMA = slowDMA;
            SlowD = new SmartQuant.TimeSeries();
            Init();
        }

        public int FastKPeriod { get; }
        public int SlowKPeriod { get; }
        public TaLib.Core.MAType SlowKMA { get; }
        public int SlowDPeriod { get; }
        public TaLib.Core.MAType SlowDMA { get; }
        public SmartQuant.TimeSeries SlowK => this;
        public SmartQuant.TimeSeries SlowD { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Stoch(index, index, InHigh, InLow, InClose, FastKPeriod, SlowKPeriod, SlowKMA, SlowDPeriod, SlowDMA,
                ref outBegIdx, ref outNBElement, _SlowK, _SlowD, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _SlowK[0]);
                SlowD.Add(datetime, _SlowD[0]);
            }
        }

        public static (double, double) Value(SmartQuant.ISeries input, int index, int fastKPeriod = 5, int slowKPeriod = 3, TaLib.Core.MAType slowKMA = TaLib.Core.MAType.Sma, int slowDPeriod = 3, TaLib.Core.MAType slowDMA = TaLib.Core.MAType.Sma)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _SlowK = new double[1];
            var _SlowD = new double[1];
            var ret = TaLib.Core.Stoch(index, index, InHigh, InLow, InClose, fastKPeriod, slowKPeriod, slowKMA, slowDPeriod, slowDMA,
                ref outBegIdx, ref outNBElement, _SlowK, _SlowD, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return (_SlowK[0], _SlowD[0]);
            }
            return (double.NaN, double.NaN);
        }
    }
    /// <summary>
    /// Stochastic Fast (Momentum Indicators)
    /// </summary>
    public class TaStochF : TaIndicator
    {

        private readonly double[] _FastK = new double[1];
        private readonly double[] _FastD = new double[1];
        protected override void Init()
        {
            name = $"TaStochF({FastKPeriod},{FastDPeriod},{FastDMA})";
            description = "Stochastic Fast (Momentum Indicators)";
            Clear();
            calculate = true;
        }

        public TaStochF(SmartQuant.ISeries input, int fastKPeriod = 5, int fastDPeriod = 3, TaLib.Core.MAType fastDMA = TaLib.Core.MAType.Sma) : base(input)
        {

            FastKPeriod = fastKPeriod;
            FastDPeriod = fastDPeriod;
            FastDMA = fastDMA;
            FastD = new SmartQuant.TimeSeries();
            Init();
        }

        public int FastKPeriod { get; }
        public int FastDPeriod { get; }
        public TaLib.Core.MAType FastDMA { get; }
        public SmartQuant.TimeSeries FastK => this;
        public SmartQuant.TimeSeries FastD { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.StochF(index, index, InHigh, InLow, InClose, FastKPeriod, FastDPeriod, FastDMA,
                ref outBegIdx, ref outNBElement, _FastK, _FastD, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _FastK[0]);
                FastD.Add(datetime, _FastD[0]);
            }
        }

        public static (double, double) Value(SmartQuant.ISeries input, int index, int fastKPeriod = 5, int fastDPeriod = 3, TaLib.Core.MAType fastDMA = TaLib.Core.MAType.Sma)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _FastK = new double[1];
            var _FastD = new double[1];
            var ret = TaLib.Core.StochF(index, index, InHigh, InLow, InClose, fastKPeriod, fastDPeriod, fastDMA,
                ref outBegIdx, ref outNBElement, _FastK, _FastD, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return (_FastK[0], _FastD[0]);
            }
            return (double.NaN, double.NaN);
        }
    }
    /// <summary>
    /// Stochastic Relative Strength Index (Momentum Indicators)
    /// </summary>
    public class TaStochRsi : TaIndicator
    {

        private readonly double[] _FastK = new double[1];
        private readonly double[] _FastD = new double[1];
        protected override void Init()
        {
            name = $"TaStochRsi({TimePeriod},{FastKPeriod},{FastDPeriod},{FastDMA})";
            description = "Stochastic Relative Strength Index (Momentum Indicators)";
            Clear();
            calculate = true;
        }

        public TaStochRsi(SmartQuant.ISeries input, int timePeriod = 14, int fastKPeriod = 5, int fastDPeriod = 3, TaLib.Core.MAType fastDMA = TaLib.Core.MAType.Sma) : base(input)
        {

            TimePeriod = timePeriod;
            FastKPeriod = fastKPeriod;
            FastDPeriod = fastDPeriod;
            FastDMA = fastDMA;
            FastD = new SmartQuant.TimeSeries();
            Init();
        }

        public int TimePeriod { get; }
        public int FastKPeriod { get; }
        public int FastDPeriod { get; }
        public TaLib.Core.MAType FastDMA { get; }
        public SmartQuant.TimeSeries FastK => this;
        public SmartQuant.TimeSeries FastD { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.StochRsi(index, index, input, TimePeriod, FastKPeriod, FastDPeriod, FastDMA,
                ref outBegIdx, ref outNBElement, _FastK, _FastD);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _FastK[0]);
                FastD.Add(datetime, _FastD[0]);
            }
        }

        public static (double, double) Value(SmartQuant.ISeries input, int index, int timePeriod = 14, int fastKPeriod = 5, int fastDPeriod = 3, TaLib.Core.MAType fastDMA = TaLib.Core.MAType.Sma)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _FastK = new double[1];
            var _FastD = new double[1];
            var ret = TaLib.Core.StochRsi(index, index, input, timePeriod, fastKPeriod, fastDPeriod, fastDMA,
                ref outBegIdx, ref outNBElement, _FastK, _FastD);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return (_FastK[0], _FastD[0]);
            }
            return (double.NaN, double.NaN);
        }
    }
    /// <summary>
    /// Vector Arithmetic Substraction (Math Operators)
    /// </summary>
    public class TaSub : TaIndicator
    {
        private SmartQuant.ISeries _input2;
        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaSub";
            description = "Vector Arithmetic Substraction (Math Operators)";
            Clear();
            calculate = true;
        }

        public TaSub(SmartQuant.ISeries input, SmartQuant.ISeries input2) : base(input)
        {
            _input2 = input2;
            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Sub(index, index, input, _input2,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, SmartQuant.ISeries input2)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Sub(index, index, input, input2,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Summation (Math Operators)
    /// </summary>
    public class TaSum : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaSum({TimePeriod})";
            description = "Summation (Math Operators)";
            Clear();
            calculate = true;
        }

        public TaSum(SmartQuant.ISeries input, int timePeriod = 30) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Sum(index, index, input, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 30)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Sum(index, index, input, timePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Triple Exponential Moving Average (T3) (Overlap Studies)
    /// </summary>
    public class TaT3 : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaT3({TimePeriod},{VolumeFactor})";
            description = "Triple Exponential Moving Average (T3) (Overlap Studies)";
            Clear();
            calculate = true;
        }

        public TaT3(SmartQuant.ISeries input, int timePeriod = 5, double volumeFactor = 7.000000e-1) : base(input)
        {

            TimePeriod = timePeriod;
            VolumeFactor = volumeFactor;
            Init();
        }

        public int TimePeriod { get; }
        public double VolumeFactor { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.T3(index, index, input, TimePeriod, VolumeFactor,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 5, double volumeFactor = 7.000000e-1)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.T3(index, index, input, timePeriod, volumeFactor,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Vector Trigonometric Tan (Math Transform)
    /// </summary>
    public class TaTan : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaTan";
            description = "Vector Trigonometric Tan (Math Transform)";
            Clear();
            calculate = true;
        }

        public TaTan(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Tan(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Tan(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Vector Trigonometric Tanh (Math Transform)
    /// </summary>
    public class TaTanh : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaTanh";
            description = "Vector Trigonometric Tanh (Math Transform)";
            Clear();
            calculate = true;
        }

        public TaTanh(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Tanh(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Tanh(index, index, input,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Triple Exponential Moving Average (Overlap Studies)
    /// </summary>
    public class TaTema : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaTema({TimePeriod})";
            description = "Triple Exponential Moving Average (Overlap Studies)";
            Clear();
            calculate = true;
        }

        public TaTema(SmartQuant.ISeries input, int timePeriod = 30) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Tema(index, index, input, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 30)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Tema(index, index, input, timePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// True Range (Volatility Indicators)
    /// </summary>
    public class TaTrueRange : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaTrueRange";
            description = "True Range (Volatility Indicators)";
            Clear();
            calculate = true;
        }

        public TaTrueRange(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.TrueRange(index, index, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.TrueRange(index, index, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Triangular Moving Average (Overlap Studies)
    /// </summary>
    public class TaTrima : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaTrima({TimePeriod})";
            description = "Triangular Moving Average (Overlap Studies)";
            Clear();
            calculate = true;
        }

        public TaTrima(SmartQuant.ISeries input, int timePeriod = 30) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Trima(index, index, input, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 30)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Trima(index, index, input, timePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// 1-day Rate-Of-Change (ROC) of a Triple Smooth EMA (Momentum Indicators)
    /// </summary>
    public class TaTrix : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaTrix({TimePeriod})";
            description = "1-day Rate-Of-Change (ROC) of a Triple Smooth EMA (Momentum Indicators)";
            Clear();
            calculate = true;
        }

        public TaTrix(SmartQuant.ISeries input, int timePeriod = 30) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Trix(index, index, input, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 30)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Trix(index, index, input, timePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Time Series Forecast (Statistic Functions)
    /// </summary>
    public class TaTsf : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaTsf({TimePeriod})";
            description = "Time Series Forecast (Statistic Functions)";
            Clear();
            calculate = true;
        }

        public TaTsf(SmartQuant.ISeries input, int timePeriod = 14) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Tsf(index, index, input, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 14)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Tsf(index, index, input, timePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Typical Price (Price Transform)
    /// </summary>
    public class TaTypPrice : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaTypPrice";
            description = "Typical Price (Price Transform)";
            Clear();
            calculate = true;
        }

        public TaTypPrice(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.TypPrice(index, index, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.TypPrice(index, index, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Ultimate Oscillator (Momentum Indicators)
    /// </summary>
    public class TaUltOsc : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaUltOsc({FirstPeriod},{SecondPeriod},{ThirdPeriod})";
            description = "Ultimate Oscillator (Momentum Indicators)";
            Clear();
            calculate = true;
        }

        public TaUltOsc(SmartQuant.ISeries input, int firstPeriod = 7, int secondPeriod = 14, int thirdPeriod = 28) : base(input)
        {

            FirstPeriod = firstPeriod;
            SecondPeriod = secondPeriod;
            ThirdPeriod = thirdPeriod;
            Init();
        }

        public int FirstPeriod { get; }
        public int SecondPeriod { get; }
        public int ThirdPeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.UltOsc(index, index, InHigh, InLow, InClose, FirstPeriod, SecondPeriod, ThirdPeriod,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int firstPeriod = 7, int secondPeriod = 14, int thirdPeriod = 28)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.UltOsc(index, index, InHigh, InLow, InClose, firstPeriod, secondPeriod, thirdPeriod,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Variance (Statistic Functions)
    /// </summary>
    public class TaVariance : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaVariance({TimePeriod},{Deviations})";
            description = "Variance (Statistic Functions)";
            Clear();
            calculate = true;
        }

        public TaVariance(SmartQuant.ISeries input, int timePeriod = 5, double deviations = 1.000000e+0) : base(input)
        {

            TimePeriod = timePeriod;
            Deviations = deviations;
            Init();
        }

        public int TimePeriod { get; }
        public double Deviations { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Variance(index, index, input, TimePeriod, Deviations,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 5, double deviations = 1.000000e+0)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Variance(index, index, input, timePeriod, deviations,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Weighted Close Price (Price Transform)
    /// </summary>
    public class TaWclPrice : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaWclPrice";
            description = "Weighted Close Price (Price Transform)";
            Clear();
            calculate = true;
        }

        public TaWclPrice(SmartQuant.ISeries input) : base(input)
        {

            Init();
        }

        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.WclPrice(index, index, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.WclPrice(index, index, InHigh, InLow, InClose,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Williams' %R (Momentum Indicators)
    /// </summary>
    public class TaWillR : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaWillR({TimePeriod})";
            description = "Williams' %R (Momentum Indicators)";
            Clear();
            calculate = true;
        }

        public TaWillR(SmartQuant.ISeries input, int timePeriod = 14) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.WillR(index, index, InHigh, InLow, InClose, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 14)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.WillR(index, index, InHigh, InLow, InClose, timePeriod,
                ref outBegIdx, ref outNBElement, _Real, input);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
    /// <summary>
    /// Weighted Moving Average (Overlap Studies)
    /// </summary>
    public class TaWma : TaIndicator
    {

        private readonly double[] _Real = new double[1];
        protected override void Init()
        {
            name = $"TaWma({TimePeriod})";
            description = "Weighted Moving Average (Overlap Studies)";
            Clear();
            calculate = true;
        }

        public TaWma(SmartQuant.ISeries input, int timePeriod = 30) : base(input)
        {

            TimePeriod = timePeriod;
            Init();
        }

        public int TimePeriod { get; }
        public override void Calculate(int index)
        {
            var outBegIdx = 0;
            var outNBElement = 0;
            var ret = TaLib.Core.Wma(index, index, input, TimePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                var datetime = input.GetDateTime(index);
                Add(datetime, _Real[0]);
            }
        }

        public static double Value(SmartQuant.ISeries input, int index, int timePeriod = 30)
        {
            var InOpen = new double[] { 0 };
            var InClose = new double[] { 0 };
            var InHigh = new double[] { 0 };
            var InLow = new double[] { 0 };
            var InVolume = new double[] { 0 };
            var outBegIdx = 0;
            var outNBElement = 0;
            var _Real = new double[1];
            var ret = TaLib.Core.Wma(index, index, input, timePeriod,
                ref outBegIdx, ref outNBElement, _Real);
            if (ret == TaLib.Core.RetCode.Success && outNBElement > 0) {
                return _Real[0];
            }
            return double.NaN;
        }
    }
}