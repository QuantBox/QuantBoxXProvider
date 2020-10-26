using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Skyline;
using SmartQuant;

namespace QuantBox
{
    public static class StopExtensions
    {
        private static readonly FastFieldInfo<Stop, double> QtyField;
        private static readonly FastFieldInfo<Stop, Strategy> StrategyField;
        private static readonly FastFieldInfo<Stop, DateTime> CreationTimeField;

        static StopExtensions()
        {
            var creationTimeField = typeof(Stop).GetField("creationTime", BindingFlags.Instance | BindingFlags.NonPublic);
            if (creationTimeField != null) {
                CreationTimeField = new FastFieldInfo<Stop, DateTime>(creationTimeField);
            }
            var strategyField = typeof(Stop).GetField("strategy", BindingFlags.Instance | BindingFlags.NonPublic);
            if (strategyField != null) {
                StrategyField = new FastFieldInfo<Stop, Strategy>(strategyField);
            }
            var qtyField = typeof(Stop).GetField("qty", BindingFlags.Instance | BindingFlags.NonPublic);
            if (qtyField != null) {
                QtyField = new FastFieldInfo<Stop, double>(qtyField);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetQty(this Stop s, double qty)
        {
            QtyField?.Setter(s, qty);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetStrategy(this Stop s, Strategy strategy)
        {
            StrategyField?.Setter(s, strategy);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetCreationTime(this Stop s, DateTime dateTime)
        {
            CreationTimeField?.Setter(s, dateTime);
        }

        internal static byte[] GetObjectId(this Stop s)
        {
            return (byte[])s.Fields[QuantBoxConst.StopIdOffset];
        }

        internal static void SetObjectId(this Stop s, byte[] id)
        {
            s.Fields[QuantBoxConst.StopIdOffset] = id;
        }
    }
}