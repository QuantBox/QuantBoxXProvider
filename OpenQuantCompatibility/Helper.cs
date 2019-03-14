using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
#if DynamicMethodVisualizer
using Microsoft.VisualStudio.DebuggerVisualizers;
#endif
using SmartQuant;

namespace OpenQuant
{
    public class Helper
    {
        #region Fast Invoke
        [Conditional("DEBUG")]
        public static void ShowDynamicMethodVisualizer(object objectToVisualize)
        {
#if DynamicMethodVisualizer
            var visualizerHost = new VisualizerDevelopmentHost(objectToVisualize, typeof(DynamicMethodVisualizer.MethodBodyVisualizer), typeof(DynamicMethodVisualizer.MethodBodyObjectSource));
            visualizerHost.ShowVisualizer();
#endif
        }

        private delegate object FastInvokeHandler(object target, object[] paramters);
        private delegate object FastConstructorHandler(params object[] paramters);
        private static FastConstructorHandler CreateFastConstructor(ConstructorInfo methodInfo)
        {
            if (methodInfo.DeclaringType == null) {
                return null;
            }
            var dynamicMethod = new DynamicMethod(
                string.Empty,
                typeof(object),
                new[] { typeof(object[]) },
                methodInfo.DeclaringType.Module,
                true);

            var il = dynamicMethod.GetILGenerator();
            var parameters = methodInfo.GetParameters();
            var paramTypes = new Type[parameters.Length];
            for (var i = 0; i < paramTypes.Length; i++) {
                if (parameters[i].ParameterType.IsByRef)
                    paramTypes[i] = parameters[i].ParameterType.GetElementType();
                else
                    paramTypes[i] = parameters[i].ParameterType;
            }
            var locals = new LocalBuilder[paramTypes.Length];

            for (var i = 0; i < paramTypes.Length; i++) {
                locals[i] = il.DeclareLocal(paramTypes[i], true);
            }
            for (var i = 0; i < paramTypes.Length; i++) {
                il.Emit(OpCodes.Ldarg_0);
                EmitFastInt(il, i);
                il.Emit(OpCodes.Ldelem_Ref);
                EmitCastToReference(il, paramTypes[i]);
                il.Emit(OpCodes.Stloc, locals[i]);
            }
            for (var i = 0; i < paramTypes.Length; i++) {
                if (parameters[i].ParameterType.IsByRef)
                    il.Emit(OpCodes.Ldloca_S, locals[i]);
                else
                    il.Emit(OpCodes.Ldloc, locals[i]);
            }
            il.Emit(OpCodes.Newobj, methodInfo);

            for (var i = 0; i < paramTypes.Length; i++) {
                if (parameters[i].ParameterType.IsByRef) {
                    il.Emit(OpCodes.Ldarg_1);
                    EmitFastInt(il, i);
                    il.Emit(OpCodes.Ldloc, locals[i]);
                    if (locals[i].LocalType.IsValueType)
                        il.Emit(OpCodes.Box, locals[i].LocalType);
                    il.Emit(OpCodes.Stelem_Ref);
                }
            }

            il.Emit(OpCodes.Ret);
            ShowDynamicMethodVisualizer(dynamicMethod);
            return (FastConstructorHandler)dynamicMethod.CreateDelegate(typeof(FastConstructorHandler));
        }
        private static void EmitCastToReference(ILGenerator il, Type type)
        {
            if (type.IsValueType) {
                il.Emit(OpCodes.Unbox_Any, type);
            }
            else {
                il.Emit(OpCodes.Castclass, type);
            }
        }
        private static void EmitFastInt(ILGenerator il, int value)
        {
            switch (value) {
                case -1:
                    il.Emit(OpCodes.Ldc_I4_M1);
                    return;
                case 0:
                    il.Emit(OpCodes.Ldc_I4_0);
                    return;
                case 1:
                    il.Emit(OpCodes.Ldc_I4_1);
                    return;
                case 2:
                    il.Emit(OpCodes.Ldc_I4_2);
                    return;
                case 3:
                    il.Emit(OpCodes.Ldc_I4_3);
                    return;
                case 4:
                    il.Emit(OpCodes.Ldc_I4_4);
                    return;
                case 5:
                    il.Emit(OpCodes.Ldc_I4_5);
                    return;
                case 6:
                    il.Emit(OpCodes.Ldc_I4_6);
                    return;
                case 7:
                    il.Emit(OpCodes.Ldc_I4_7);
                    return;
                case 8:
                    il.Emit(OpCodes.Ldc_I4_8);
                    return;
            }

            if (value > -129 && value < 128) {
                il.Emit(OpCodes.Ldc_I4_S, (sbyte)value);
            }
            else {
                il.Emit(OpCodes.Ldc_I4, value);
            }
        }
        private static void EmitBoxIfNeeded(ILGenerator il, Type type)
        {
            if (type.IsValueType) {
                il.Emit(OpCodes.Box, type);
            }
        }
        private static FastInvokeHandler CreateFastInvoker(MethodInfo methodInfo)
        {
            if (methodInfo.DeclaringType == null) {
                return null;
            }
            var dynamicMethod = new DynamicMethod(
                string.Empty,
                typeof(object),
                new[] { typeof(object), typeof(object[]) },
                methodInfo.DeclaringType.Module,
                true);

            var il = dynamicMethod.GetILGenerator();
            var parameters = methodInfo.GetParameters();
            var paramTypes = new Type[parameters.Length];
            for (var i = 0; i < paramTypes.Length; i++) {
                if (parameters[i].ParameterType.IsByRef)
                    paramTypes[i] = parameters[i].ParameterType.GetElementType();
                else
                    paramTypes[i] = parameters[i].ParameterType;
            }
            var locals = new LocalBuilder[paramTypes.Length];

            for (var i = 0; i < paramTypes.Length; i++) {
                locals[i] = il.DeclareLocal(paramTypes[i], true);
            }
            for (var i = 0; i < paramTypes.Length; i++) {
                il.Emit(OpCodes.Ldarg_1);
                EmitFastInt(il, i);
                il.Emit(OpCodes.Ldelem_Ref);
                EmitCastToReference(il, paramTypes[i]);
                il.Emit(OpCodes.Stloc, locals[i]);
            }
            if (!methodInfo.IsStatic) {
                il.Emit(OpCodes.Ldarg_0);
            }
            for (var i = 0; i < paramTypes.Length; i++) {
                if (parameters[i].ParameterType.IsByRef)
                    il.Emit(OpCodes.Ldloca_S, locals[i]);
                else
                    il.Emit(OpCodes.Ldloc, locals[i]);
            }
            if (methodInfo.IsStatic)
                il.EmitCall(OpCodes.Call, methodInfo, null);
            else
                il.EmitCall(OpCodes.Callvirt, methodInfo, null);
            if (methodInfo.ReturnType == typeof(void))
                il.Emit(OpCodes.Ldnull);
            else
                EmitBoxIfNeeded(il, methodInfo.ReturnType);

            for (var i = 0; i < paramTypes.Length; i++) {
                if (parameters[i].ParameterType.IsByRef) {
                    il.Emit(OpCodes.Ldarg_1);
                    EmitFastInt(il, i);
                    il.Emit(OpCodes.Ldloc, locals[i]);
                    if (locals[i].LocalType.IsValueType)
                        il.Emit(OpCodes.Box, locals[i].LocalType);
                    il.Emit(OpCodes.Stelem_Ref);
                }
            }

            il.Emit(OpCodes.Ret);
            ShowDynamicMethodVisualizer(dynamicMethod);
            return (FastInvokeHandler)dynamicMethod.CreateDelegate(typeof(FastInvokeHandler));
        }

        #endregion

        private static FastInvokeHandler GetSizeGetter()
        {
            var prop = typeof(Tick).GetProperty("Size");
            return CreateFastInvoker(prop.GetMethod);
        }

        private static FastConstructorHandler GetTickConstructor<T>(ref bool doubleSize) where T : Tick
        {
            foreach (var info in typeof(T).GetConstructors()) {
                var @params = info.GetParameters();
                if (typeof(T) == typeof(Trade)
                    && @params.Length == 6
                    && @params[1].ParameterType == typeof(DateTime)) {
                    doubleSize = @params.Last().ParameterType == typeof(double);
                    return CreateFastConstructor(info);
                }

                if (typeof(T) != typeof(Trade) && @params.Length == 6) {
                    return CreateFastConstructor(info);
                }
            }
            return null;
        }

        private static FastConstructorHandler GetBarConstructor()
        {
            foreach (var info in typeof(Bar).GetConstructors()) {
                var @params = info.GetParameters();
                if (@params.Length == 12) {
                    return CreateFastConstructor(info);
                }
            }
            return null;
        }

        static Helper()
        {
            LegsProperty = typeof(Instrument).GetProperty("Legs", BindingFlags.Instance | BindingFlags.Public);
            TickConstructor = GetTickConstructor<Tick>(ref DoubleSize);
            AskConstructor = GetTickConstructor<Ask>(ref DoubleSize);
            BidConstructor = GetTickConstructor<Bid>(ref DoubleSize);
            TradeConstructor = GetTickConstructor<Trade>(ref DoubleSize);
            BarConstructor = GetBarConstructor();
            SizeHandler = GetSizeGetter();
        }

#if DEBUG
        public static Ask NewTick(object[] items)
        {
            DateTime dateTime = (DateTime)items[0];
            DateTime exchangeDateTime = (DateTime)items[1];
            byte providerId = (byte)items[2];
            int instrumentId = (int)items[3];
            double price = (double)items[4];
            int size = (int)items[5];
            return new Ask(dateTime, exchangeDateTime, providerId, instrumentId, price, size);
        }
#endif

        private static readonly PropertyInfo LegsProperty;
        public static void AddLeg(Instrument inst, Leg leg)
        {
            if (LegsProperty == null) {
                return;
            }
            var legs = (List<Leg>)LegsProperty.GetValue(inst);
            legs?.Add(leg);
        }

        public static readonly bool DoubleSize;
        private static readonly FastConstructorHandler TickConstructor;
        private static readonly FastConstructorHandler AskConstructor;
        private static readonly FastConstructorHandler BidConstructor;
        private static readonly FastConstructorHandler TradeConstructor;
        private static readonly FastConstructorHandler BarConstructor;
        private static readonly FastInvokeHandler SizeHandler;

        public static T NewTick<T>(
            DateTime dateTime,
            DateTime exchangeDateTime,
            byte providerId,
            int instrumentId,
            double price,
            double size) where T : Tick
        {
            FastConstructorHandler handler = null;
            if (typeof(T) == typeof(Tick))
                handler = TickConstructor;
            if (typeof(T) == typeof(Ask))
                handler = AskConstructor;
            if (typeof(T) == typeof(Bid))
                handler = BidConstructor;
            if (typeof(T) == typeof(Trade))
                handler = TradeConstructor;
            if (DoubleSize) {
                return (T)handler?.Invoke(dateTime, exchangeDateTime, providerId, instrumentId, price, size);
            }
            return (T)handler?.Invoke(dateTime, exchangeDateTime, providerId, instrumentId, price, (int)size);
        }

        public static Bar NewBar(
            DateTime openDateTime,
            DateTime closeDateTime,
            int providerId,
            int instrumentId,
            BarType type,
            long size,
            double open = 0, double high = 0, double low = 0, double close = 0,
            double volume = 0, long openInt = 0)
        {
            if (DoubleSize) {
                return (Bar)BarConstructor?.Invoke(
                    openDateTime, closeDateTime,
                    providerId, instrumentId,
                    type, size,
                    open, high, low, close,
                    volume, openInt);
            }
            return (Bar)BarConstructor?.Invoke(
                openDateTime, closeDateTime,
                providerId, instrumentId,
                type, size,
                open, high, low, close,
                (long)volume, openInt);
        }

        public static double GetDoubleSize(Tick tick)
        {
            if (DoubleSize) {
                return (double)SizeHandler(tick, new object[] { });
            }
            return GetIntSize(tick);
        }

        public static int GetIntSize(Tick tick)
        {
            if (DoubleSize) {
                return (int)GetDoubleSize(tick);
            }
            return (int)SizeHandler(tick, new object[] { });
        }
    }
}
