using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using Skyline;
using SmartQuant;

namespace QuantBox
{
    public static class FrameworkExtensions
    {
        public static readonly FastFieldInfo<EventManager, bool> ThreadExitField;
        public static readonly FastFieldInfo<Clock, IEventQueue> ClockEventQueueField;
        public static readonly FastFieldInfo<EventBus, int> EventBusAttachedCountField;
        public static readonly FastFieldInfo<EventBus, EventQueue[]> EventBusAttachedField;

        private static readonly FastFieldInfo<SubscriptionManager, Dictionary<int, Dictionary<Instrument, int>>> SubscriptionManagerSubscriptionsField;
        private static readonly FastFieldInfo<EventDispatcher, Framework> EventDispatcherFrameworkField;
        private static readonly FastFieldInfo<Portfolio, Framework> PortfolioFrameworkField;
        private static readonly FastFieldInfo<Provider, Framework> ProviderFrameworkField;
        private static readonly FastFieldInfo<ProviderManager, Framework> ProviderManagerFrameworkField;
        private static readonly FastFieldInfo<DataManager, Framework> DataManagerFrameworkField;
        private static readonly FastFieldInfo<InstrumentManager, Framework> InstrumentManagerFrameworkField;
        private static readonly FastFieldInfo<Instrument, Framework> InstrumentFrameworkField;
        private static readonly FastFieldInfo<Strategy, Framework> StrategyFrameworkField;
        private static readonly FastFieldInfo<Clock, ClockMode> ClockModeFiled;
        private static readonly FastFieldInfo<Reminder, Clock> ReminderClockFiled;
        private static readonly FieldInfo EventManagerThreadField;

        static FastFieldInfo<T, TField> GetFastField<T, TField>()
        {
            foreach (var field in typeof(T).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)) {
                if (field.FieldType == typeof(TField)) {
                    return new FastFieldInfo<T, TField>(field);
                }
            }
            return null;
        }

        static FrameworkExtensions()
        {
            SubscriptionManagerSubscriptionsField = GetFastField<SubscriptionManager, Dictionary<int, Dictionary<Instrument, int>>>();
            EventBusAttachedField = GetFastField<EventBus, EventQueue[]>();
            EventBusAttachedCountField = GetFastField<EventBus, int>();
            ClockEventQueueField = GetFastField<Clock, IEventQueue>();
            EventDispatcherFrameworkField = GetFastField<EventDispatcher, Framework>();
            ProviderManagerFrameworkField = GetFastField<ProviderManager, Framework>();
            InstrumentManagerFrameworkField = GetFastField<InstrumentManager, Framework>();
            DataManagerFrameworkField = GetFastField<DataManager, Framework>();
            PortfolioFrameworkField = GetFastField<Portfolio, Framework>();
            ProviderFrameworkField = GetFastField<Provider, Framework>();
            StrategyFrameworkField = GetFastField<Strategy, Framework>();
            InstrumentFrameworkField = GetFastField<Instrument, Framework>();

            ClockModeFiled = GetFastField<Clock, ClockMode>();
            ReminderClockFiled = GetFastField<Reminder, Clock>();
            foreach (var item in typeof(EventManager).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)) {
                if (item.FieldType == typeof(bool) && item.GetRequiredCustomModifiers().Any(x => x == typeof(IsVolatile))) {
                    ThreadExitField = new FastFieldInfo<EventManager, bool>(item);
                }
                else if (item.FieldType == typeof(Thread)) {
                    EventManagerThreadField = item;
                }
            }
        }

        public static List<byte> Unsubscribe(this SubscriptionManager manager, Instrument inst)
        {
            var list = new List<byte>();
            var dict = SubscriptionManagerSubscriptionsField.Getter(manager);
            foreach (var item in dict) {
                if (item.Value.ContainsKey(inst)) {
                    list.Add((byte)item.Key);
                }
            }
            foreach (var id in list) {
                manager.Unsubscribe(id, inst);
            }
            return list;
        }

        public static Thread ChangeEventThread(this Framework framework, ParameterizedThreadStart threadRun)
        {
            if (ThreadExitField != null) {
                ThreadExitField.Setter(framework.EventManager, true);
                var queue = new EventQueue(size: 10);
                queue.IsSynched = true;
                queue.Enqueue(new OnQueueOpened(queue));
                queue.Enqueue(new OnQueueClosed(queue));
                framework.EventBus.ServicePipe.Add(queue);

                var thread = (Thread)EventManagerThreadField.GetValue(framework.EventManager);
                while (thread.IsAlive) {
                    Thread.Sleep(10);
                }
                thread.Join();
                ThreadExitField.Setter(framework.EventManager, false);
                var ret = StartEventThread();
                EventManagerThreadField.SetValue(framework.EventManager, ret);
                return ret;
            }

            return null;

            Thread StartEventThread()
            {
                var thread = new Thread(threadRun);
                thread.Name = "Event Manager Thread";
                thread.IsBackground = true;
                thread.Start(framework);
                return thread;
            }
        }

        public static Framework GetFramework(this Portfolio portfolio)
        {
            return PortfolioFrameworkField.Getter(portfolio);
        }

        public static Framework GetFramework(this Provider provider)
        {
            return ProviderFrameworkField.Getter(provider);
        }

        public static Framework GetFramework(this DataManager manager)
        {
            return DataManagerFrameworkField.Getter(manager);
        }

        public static Framework GetFramework(this EventDispatcher manager)
        {
            return EventDispatcherFrameworkField.Getter(manager);
        }

        public static Framework GetFramework(this Instrument inst)
        {
            return InstrumentFrameworkField.Getter(inst);
        }

        public static Framework GetFramework(this InstrumentManager manager)
        {
            return InstrumentManagerFrameworkField.Getter(manager);
        }

        public static Framework GetFramework(this Strategy s)
        {
            return StrategyFrameworkField.Getter(s);
        }

        public static void SetFramework(this Strategy s, Framework f)
        {
            StrategyFrameworkField?.Setter(s, f);
        }

        public static bool TryGetValue<T>(this Global g, string key, out T v)
        {
            if (g.ContainsKey(key)) {
                v = (T)g[key];
                return true;
            }
            v = default;
            return false;
        }

        public static void SetMode(this Clock clock, ClockMode mode)
        {
            ClockModeFiled.Setter(clock, mode);
        }

        public static void SetClock(this Reminder reminder, Clock clock)
        {
            ReminderClockFiled.Setter(reminder, clock);
        }

        public static void AddNew(this ProviderManager manager, IProvider provider)
        {
            byte newid = 0;
            for (byte i = 0; i < 100; i++) {
                if (manager.Providers.GetById(i) == null) {
                    newid = i;
                    break;
                }
            }
            provider.Id = newid;
            manager.AddProvider(provider);
        }

        public static XProvider GetProvider(this ProviderManager manager, string typeName, byte id, string server, string user)
        {
            foreach (var p in manager.Providers) {
                if (p is XProvider xp && xp.GetType().Name == typeName) {
                    var (s, u, _) = xp.GetConnectInfo();
                    if (s == server && u == user) {
                        return xp;
                    }
                }
            }
            return (XProvider)manager.GetExecutionProvider(id);
        }

        /// <summary>
        /// 获取指定服务器、用户的Ufx插件
        /// </summary>
        /// <returns></returns>
        public static XProvider NewUfx(this ProviderManager manager, string server, string user, string password)
        {
            var ufx = GetUfx(manager, server, user);
            if (ufx.Id == QuantBoxConst.PIdUfx) {
                ufx = (XProvider)Activator.CreateInstance(ufx.GetType(), ufx.GetFramework());
                ufx.Name += $"({server}_{user})";
                manager.AddNew(ufx);
            }
            ufx.SetConnectInfo(server, user, password);
            ufx.ConnectTrader = true;
            ufx.ConnectMarketData = true;
            return ufx;
        }

        public static XProvider GetUfx(this ProviderManager manager, string server, string user)
        {
            return GetProvider(manager, "QuantBoxUfx", QuantBoxConst.PIdUfx, server, user);
        }

        public static XProvider GetUfx(this ProviderManager manager)
        {
            return (XProvider)manager.GetExecutionProvider(QuantBoxConst.PIdUfx);
        }

        public static OrderAgent GetUfxAgent(this ProviderManager manager)
        {
            var ufx = GetUfx(manager);
            var agent = GetAgent(manager, OrderAgent.DefaultName);
            if (agent == null) {
                agent = new OrderAgent(ProviderManagerFrameworkField.Getter(manager));
                manager.AddNew(agent);
            }
            agent.ExecutionProvider = ufx;
            return agent;
        }

        /// <summary>
        /// 获取指定服务器、用户的CTP插件
        /// </summary>
        /// <returns></returns>
        public static XProvider NewCtp(this ProviderManager manager, string server, string user, string password)
        {
            var ctp = GetCtp(manager, server, user);
            if (ctp.Id == QuantBoxConst.PIdCtp) {
                ctp = (XProvider)Activator.CreateInstance(ctp.GetType(), ctp.GetFramework());
                ctp.Name += $"({server}_{user})";
                manager.AddNew(ctp);
            }
            ctp.SetConnectInfo(server, user, password);
            ctp.ConnectTrader = true;
            ctp.ConnectMarketData = true;
            return ctp;
        }

        /// <summary>
        /// 获取指定服务器、用户的CTP插件，只连接行情
        /// </summary>        
        /// <returns></returns>
        public static XProvider NewCtpData(this ProviderManager manager, string server, string user, string password)
        {
            var ctp = NewCtp(manager, server, user, password);
            ctp.ConnectTrader = false;
            ctp.ConnectMarketData = true;
            return ctp;
        }

        /// <summary>
        /// 获取订单助手，使用指定服务器、用户的CTP插件
        /// </summary>
        /// <returns></returns>
        public static (OrderAgent, XProvider) NewCtpAgent(this ProviderManager manager, string server, string user, string password)
        {
            var name = OrderAgent.DefaultName + $"({server}_{user})";
            var agent = GetAgent(manager, name);
            if (agent == null) {
                agent = new OrderAgent(ProviderManagerFrameworkField.Getter(manager), name);
                manager.AddNew(agent);
            }
            var ctp = NewCtp(manager, server, user, password);
            agent.ExecutionProvider = ctp;
            return (agent, ctp);
        }

        public static XProvider GetCtp(this ProviderManager manager, string server, string user)
        {
            return GetProvider(manager, "QuantBoxCtpse", QuantBoxConst.PIdCtp, server, user);
        }

        /// <summary>
        /// 获取默认的CTP插件
        /// </summary>
        /// <returns></returns>
        public static XProvider GetCtp(this ProviderManager manager)
        {
            return (XProvider)manager.GetExecutionProvider(QuantBoxConst.PIdCtp);
        }

        /// <summary>
        /// 获取默认的CTP插件，只连接行情
        /// </summary>
        /// <returns></returns>
        public static XProvider GetCtpData(this ProviderManager manager)
        {
            var ctp = GetCtp(manager);
            ctp.ConnectTrader = false;
            ctp.ConnectMarketData = true;
            return ctp;
        }

        private static OrderAgent GetAgent(ProviderManager manager, string name)
        {
            return (OrderAgent)manager.Providers[name];
        }

        /// <summary>
        /// 获取订单助手，使用指定默认的CTP插件
        /// </summary>
        /// <returns></returns>
        public static OrderAgent GetCtpAgent(this ProviderManager manager)
        {
            var ctp = (XProvider)manager.GetExecutionProvider(QuantBoxConst.PIdCtp);
            ctp.ConnectTrader = true;
            var agent = GetAgent(manager, OrderAgent.DefaultName);
            if (agent == null) {
                agent = new OrderAgent(ProviderManagerFrameworkField.Getter(manager));
                manager.AddNew(agent);
            }
            agent.ExecutionProvider = ctp;
            return agent;
        }

        public static SmartQuant.EventPipe GetSystemPipe(this EventBus bus)
        {
            var hash = new HashSet<SmartQuant.EventPipe> { bus.DataPipe, bus.ExecutionPipe, bus.ServicePipe, bus.HistoricalPipe };
            foreach (var item in typeof(EventBus).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)) {
                if (item.FieldType == typeof(SmartQuant.EventPipe)) {
                    var pipe = (SmartQuant.EventPipe)item.GetValue(bus);
                    if (!hash.Contains(pipe)) {
                        return pipe;
                    }
                }
            }
            return null;
        }

        public static bool InThread(this EventManager manager)
        {
            return ((Thread)EventManagerThreadField.GetValue(manager)).ManagedThreadId == Thread.CurrentThread.ManagedThreadId;
        }
    }
}
