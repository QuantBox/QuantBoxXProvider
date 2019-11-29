using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using SmartQuant;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace QuantBox
{
    public static class DataManagerExtensions
    {
        private static void DownloadDataRequest(Framework framework, HistoricalDataRequest request, Action<HistoricalData> action)
        {
            var wait = new AutoResetEvent(false);
            var hdata = framework.ProviderManager.GetHistoricalDataProvider(QuantBoxConst.PIdHisData);
            if (hdata != null) {
                framework.EventManager.Dispatcher.HistoricalData += OnHistoricalData;
                framework.EventManager.Dispatcher.HistoricalDataEnd += OnHistoricalDataEnd;
                hdata.Send(request);
                while (!wait.WaitOne(0)) {
                    Application.DoEvents();
                }
                framework.EventManager.Dispatcher.HistoricalData -= OnHistoricalData;
                framework.EventManager.Dispatcher.HistoricalDataEnd -= OnHistoricalDataEnd;
            }
            void OnHistoricalData(object sender, HistoricalDataEventArgs args)
            {
                action(args.Data);
            }
            void OnHistoricalDataEnd(object sender, HistoricalDataEndEventArgs args)
            {
                wait.Set();
            }
        }

        private static BarSeries DownloadBars(DataManager manager, Instrument inst, long barSize, DateTime dateTime1, DateTime dateTime2)
        {
            var bars = new BarSeries();
            var request = new HistoricalDataRequest() {
                RequestId = Guid.NewGuid().ToString("N"),
                DataType = DataObjectType.Bar,
                BarSize = barSize,
                Instrument = inst,
                DateTime1 = dateTime1,
                DateTime2 = dateTime2
            };
            DownloadDataRequest(manager.GetFramework(), request, OnHistoricalData);
            return bars;
            void OnHistoricalData(HistoricalData data)
            {
                foreach (var item in data.Objects) {
                    switch (item.TypeId) {
                        case DataObjectType.Bar:
                            bars.Add((Bar)item);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 下载一分钟Bar
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="inst"></param>
        /// <param name="dateTime1"></param>
        /// <param name="dateTime2"></param>
        /// <returns></returns>
        public static BarSeries DownloadMinBars(this DataManager manager, Instrument inst, DateTime dateTime1, DateTime dateTime2)
        {
            return DownloadBars(manager, inst, QuantBoxConst.MinBarSize, dateTime1, dateTime2);
        }

        /// <summary>
        /// 下载日线
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="inst"></param>
        /// <param name="dateTime1"></param>
        /// <param name="dateTime2"></param>
        /// <returns></returns>
        public static BarSeries DownloadDayBars(this DataManager manager, Instrument inst, DateTime dateTime1, DateTime dateTime2)
        {
            return DownloadBars(manager, inst, QuantBoxConst.DayBarSize, dateTime1, dateTime2);
        }

        /// <summary>
        /// 下载 Tick 数据，返回值（ask,bid,trade）
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="inst"></param>
        /// <param name="dateTime1"></param>
        /// <param name="dateTime2"></param>
        /// <returns></returns>
        public static (TickSeries asks, TickSeries bids, TickSeries trades) DownloadTicks(this DataManager manager, Instrument inst, DateTime dateTime1, DateTime dateTime2)
        {
            var asks = new TickSeries();
            var bids = new TickSeries();
            var trades = new TickSeries();
            var request = new HistoricalDataRequest() {
                RequestId = Guid.NewGuid().ToString("N"),
                DataType = DataObjectType.Tick,
                Instrument = inst,
                DateTime1 = dateTime1,
                DateTime2 = dateTime2
            };
            DownloadDataRequest(manager.GetFramework(), request, OnHistoricalData);
            return (asks, bids, trades);
            void OnHistoricalData(HistoricalData data)
            {
                foreach (var item in data.Objects) {
                    switch (item.TypeId) {
                        case DataObjectType.Ask:
                            asks.Add((Ask)item);
                            break;
                        case DataObjectType.Bid:
                            bids.Add((Bid)item);
                            break;
                        case DataObjectType.Trade:
                            trades.Add((Trade)item);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private static List<Instrument> GetInstrumentList(Framework framework, InstrumentType? filter = null, DateTime? tradingDay = null, bool onlyMain = false)
        {
            var list = new List<Instrument>();
            var wait = new AutoResetEvent(false);
            var hdata = framework.ProviderManager.GetInstrumentProvider(QuantBoxConst.PIdHisData);
            if (hdata != null) {
                framework.EventManager.Dispatcher.InstrumentDefinition += OnInstrumentDefinition;
                framework.EventManager.Dispatcher.InstrumentDefinitionEnd += OnInstrumentDefinitionEnd;
                hdata.Send(new InstrumentDefinitionRequest() {
                    Id = Guid.NewGuid().ToString("N"),
                    FilterType = filter,
                    FilterExchange = tradingDay.HasValue ? tradingDay.Value.ToString("yyyyMMdd") : string.Empty,
                    FilterSymbol = onlyMain ? "main" : string.Empty
                }); ;
                while (!wait.WaitOne(0)) {
                    if (framework.EventManager.InThread() || framework.EventManager.Status != EventManagerStatus.Running) {
                        framework.EventManager.OnEvent(framework.EventBus.Dequeue());
                    }
                    else {
                        Application.DoEvents();
                    }
                }
                framework.EventManager.Dispatcher.InstrumentDefinition -= OnInstrumentDefinition;
                framework.EventManager.Dispatcher.InstrumentDefinitionEnd -= OnInstrumentDefinitionEnd;
            }
            return list;

            void OnInstrumentDefinition(object sender, InstrumentDefinitionEventArgs args)
            {
                foreach (var item in args.Definition.Instruments) {
                    list.Add(item);
                }
            }
            void OnInstrumentDefinitionEnd(object sender, InstrumentDefinitionEndEventArgs args)
            {
                wait.Set();
            }
        }

        /// <summary>
        /// 获取主力合约
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="tradingDay"></param>
        /// <returns></returns>
        public static List<Instrument> GetMainFutures(this InstrumentManager manager, DateTime? tradingDay = null)
        {            
            var framework = manager.GetFramework();
            if (!tradingDay.HasValue) {
                tradingDay = TradingCalendar.Instance.GetPrevTradingDay(DateTime.Today);
            }
            return GetInstrumentList(framework, InstrumentType.Future, tradingDay, true);
        }

        /// <summary>
        /// 获取上市合约
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="tradingDay"></param>
        /// <returns></returns>
        public static List<Instrument> GetLiveFutures(this InstrumentManager manager, DateTime? tradingDay = null)
        {
            var framework = manager.GetFramework();
            if (!tradingDay.HasValue) {
                tradingDay = DateTime.Today;
            }
            return GetInstrumentList(framework, InstrumentType.Future, tradingDay);
        }

        /// <summary>
        /// 更新期货上市合约
        /// </summary>
        /// <param name="manager"></param>
        public static void UpdateLiveFutures(this InstrumentManager manager, DateTime? tradingDay = null)
        {
            var framework = manager.GetFramework();
            var list = GetLiveFutures(manager, tradingDay);
            foreach (var item in list) {
                if (!framework.InstrumentManager.Contains(item.Symbol)) {
                    framework.InstrumentManager.Add(item);
                }
            }
        }

        public static List<Instrument> GetLiveFutureOptions(this InstrumentManager manager, DateTime? tradingDay = null)
        {
            var framework = manager.GetFramework();
            return GetInstrumentList(framework, InstrumentType.FutureOption, tradingDay);
        }

        /// <summary>
        /// 更新期货期权上市合约
        /// </summary>
        /// <param name="manager"></param>
        public static void UpdateLiveFutureOptions(this InstrumentManager manager, bool includeEtf = false, DateTime? tradingDay = null)
        {
            var framework = manager.GetFramework();
            var list = GetLiveFutureOptions(manager, tradingDay);
            foreach (var item in list) {
                if (!includeEtf && Regex.IsMatch(item.Symbol, @"^\d+$")) {
                    continue;
                }
                if (!framework.InstrumentManager.Contains(item.Symbol)) {
                    framework.InstrumentManager.Add(item);
                }
            }
        }

        /// <summary>
        /// 获取指定的合约列表，如果合约不存在就从数据中心下载。
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="symbols"></param>
        public static List<Instrument> GetInstruments(this InstrumentManager manager, params string[] symbols)
        {
            var framework = manager.GetFramework();
            var result = new List<Instrument>();
            var missing = new HashSet<string>();
            foreach (var item in symbols) {
                if (Find(result, item) != null) {
                    continue;
                }
                var inst = manager.Get(item);
                if (inst != null) {
                    result.Add(inst);
                }
                else {
                    if (!missing.Contains(item)) {
                        missing.Add(item);
                    }
                }
            }

            if (missing.Count > 0) {
                var list = GetInstrumentList(framework);
                foreach (var item in missing) {
                    var inst = Find(list, item);
                    if (inst != null) {
                        manager.Add(inst);
                        result.Add(inst);
                    }
                }
            }

            return result;

            Instrument Find(List<Instrument> insts, string symbol)
            {
                return insts.SingleOrDefault(n => n.Symbol == symbol || n.GetSymbol(QuantBoxConst.PIdHisData) == symbol);
            }
        }

        public static BarSeries TradeToDayBar(this DataManager manager, Instrument inst)
        {
            return TradeToBar(manager, inst, QuantBoxConst.DayBarSize, DateTime.MinValue, DateTime.Today);
        }
        public static BarSeries TradeToMinBar(this DataManager manager, Instrument inst)
        {
            return TradeToBar(manager, inst, 60, DateTime.MinValue, DateTime.Today);
        }

        private static DateTime CorrectionDateTime1(DateTime dateTime)
        {
            if (dateTime.TimeOfDay == TimeSpan.Zero) {
                var calendar = TradingCalendar.Instance;
                if (!calendar.IsTradingDay(dateTime)) {
                    dateTime = calendar.GetNextTradingDay(dateTime);
                }
                if (calendar.IsNightOpen(dateTime)) {
                    dateTime = calendar.GetPrevTradingDay(dateTime).AddHours(16);
                }
            }
            return dateTime;
        }

        private static DateTime CorrectionDateTime2(DateTime dateTime)
        {
            if (dateTime.TimeOfDay == TimeSpan.Zero) {
                dateTime = dateTime.AddHours(16);
            }
            return dateTime;
        }

        public static BarSeries TradeToBar(this DataManager manager, Instrument inst, long barSize, DateTime dateTime1, DateTime dateTime2)
        {
            var items = manager.GetDataSeries(inst, DataObjectType.Trade);
            if (items == null || items.Count == 0) {
                return new BarSeries();
            }
            var index1 = dateTime1 == DateTime.MinValue ? 0 : items.GetIndex(CorrectionDateTime1(dateTime1), SearchOption.Next);
            var index2 = dateTime2 == DateTime.Today ? items.Count - 1 : items.GetIndex(CorrectionDateTime2(dateTime2));
            if (index1 < 0 || index2 < 0) {
                return new BarSeries();
            }
            return Data.Compression.BarCompressor.GetCompressor(inst, 0, barSize).Compress(new Data.Compression.DataSeriesEnumerator(items, (int)index1, (int)index2));
        }

        public static BarSeries GetMinBars(this DataManager manager, Instrument inst)
        {
            return GetTimeBars(manager, inst, 60, DateTime.MinValue, DateTime.Today);
        }

        public static BarSeries GetTimeBars(this DataManager manager, Instrument inst, long barSize)
        {
            return GetTimeBars(manager, inst, barSize, DateTime.MinValue, DateTime.Today);
        }

        public static BarSeries GetTimeBars(this DataManager manager, Instrument inst, long barSize, DateTime dateTime1, DateTime dateTime2)
        {
            var items = manager.GetDataSeries(inst, DataObjectType.Bar, BarType.Time, barSize);
            if (items == null || items.Count == 0) {
                return new BarSeries();
            }

            dateTime1 = dateTime1 <= items.DateTime1 ? DateTime.MinValue : CorrectionDateTime1(dateTime1);
            dateTime2 = dateTime2 >= items.DateTime2 ? DateTime.Today : CorrectionDateTime2(dateTime2);

            var index1 = dateTime1 == DateTime.MinValue ? 0 : items.GetIndex(dateTime1, SearchOption.Next);
            var index2 = dateTime2 == DateTime.Today ? items.Count - 1 : items.GetIndex(dateTime2);
            if (index1 < 0 || index2 < 0) {
                return new BarSeries();
            }
            var bars = new BarSeries((int)(index2 - index1 + 1));
            for (long i = index1; i <= index2; i++) {
                bars.Add((Bar)items[i]);
            }
            return bars;
        }

        public static void ClearBars(this DataManager manager, Instrument inst, params long[] barSizes)
        {
            foreach (var item in barSizes) {
                manager.DeleteDataSeries(inst, DataObjectType.Bar, BarType.Time, item);
            }
        }

        public static void UseBarBacktest(this IDataSimulator simulator, Instrument inst, BarSeries inputBars, params long[] barSizes) 
        {
            var framework = ((DataSimulator)simulator).GetFramework();
            framework.EventManager.Dispatcher.SimulatorStop += DispatcherSimulatorStop;
            var dm = framework.DataManager;

            if (simulator.DateTime1 == DateTime.MinValue) {
                simulator.DateTime1 = inputBars.First.OpenDateTime;
                simulator.DateTime2 = inputBars.Last.CloseDateTime;
            }
            var list = new List<BarSeries>();
            foreach (var size in barSizes) {
                if (size == inputBars.First.Size) {
                    list.Add(inputBars);
                }
                else {
                    var bars = GetTimeBars(dm, inst, size, simulator.DateTime1, simulator.DateTime2);
                    if (bars.Count == 0) {
                        bars = inputBars.TimeCompress(inst, size);
                    }
                    list.Add(bars);
                }
            }
            simulator.SubscribeBar = false;
            simulator.SubscribeBarSlice = false;
            simulator.SubscribeAsk = false;
            simulator.SubscribeBid = false;
            simulator.SubscribeTrade = false;
            simulator.SubscribeQuote = false;
            simulator.SubscribeLevelII = false;
            simulator.Series.AddRange(list);
        }

        public static void UseBarBacktest(this IDataSimulator simulator, Instrument inst, long inputBarSize, params long[] barSizes)
        {
            var framework = ((DataSimulator)simulator).GetFramework();
            var dm = framework.DataManager;
            var inputBars = GetTimeBars(dm, inst, inputBarSize, simulator.DateTime1, simulator.DateTime2);
            if (inputBars.Count == 0) {
                return;
            }
            UseBarBacktest(simulator, inst, inputBars, barSizes);
        }

        private static void DispatcherSimulatorStop(object sender, EventArgs e)
        {
            ((EventDispatcher)sender).SimulatorStop -= DispatcherSimulatorStop;
            ((EventDispatcher)sender).GetFramework().DataSimulator.Series.Clear();
        }

        internal static long[] GlobalOptimizeBarFilter;

        public static void UseBarOptimize(this IDataSimulator simulator, Instrument inst, long inputBarSize, params long[] barSizes)
        {
            var framework = ((DataSimulator)simulator).GetFramework();
            var dm = framework.DataManager;
            var inputBars = GetTimeBars(dm, inst, inputBarSize, simulator.DateTime1, simulator.DateTime2);
            if (inputBars.Count == 0) {
                return;
            }
            foreach (var size in barSizes) {
                simulator.BarFilter.Add(BarType.Time, size);
                if (size == inputBarSize) {
                    continue;
                }
                else {
                    var bars = GetTimeBars(dm, inst, size, simulator.DateTime1, simulator.DateTime2);
                    if (bars.Count == 0) {
                        bars = inputBars.TimeCompress(inst, size);
                        dm.Save(bars);
                    }
                }
            }
            GlobalOptimizeBarFilter = barSizes;
            framework.EventManager.Filter = new QBOptimizeBarFilter(framework);
            simulator.SubscribeBar = true;
            simulator.SubscribeAsk = false;
            simulator.SubscribeBid = false;
            simulator.SubscribeTrade = false;
            simulator.SubscribeQuote = false;
            simulator.SubscribeLevelII = false;
        }

        public static (TickSeries, TickSeries, TickSeries) ReadFromLocal(this DataManager manager, Instrument inst, string path)
        {
            return Convertor.MarketDataToTick(LiteMarketDatabase.Read(path), inst);
        }

        public static (TickSeries, TickSeries, TickSeries) ReadFromHost(this DataManager manager, Instrument inst, string url, string user = "", string password = "")
        {
            return Convertor.MarketDataToTick(LiteMarketDatabase.ReadFromHost(url, user, password), inst);
        }
    }
}
