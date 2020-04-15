using System;
using System.Collections.Generic;
using System.Threading;
using SmartQuant;
using System.Linq;

namespace QuantBox
{
    public class ChainDataSimulation : Provider, IDataSimulator
    {
        private readonly BarFilter _barFilter = new BarFilter();
        private volatile bool _isExiting = true;
        private volatile bool _isRunning = false;
        private readonly Dictionary<string, Instrument> _chainList = new Dictionary<string, Instrument>();
        private Thread _thread;

        public ChainDataSimulation(Framework framework) : base(framework)
        {
            id = QuantBoxConst.PIdOptionSimData;
        }

        public bool RunOnSubscribe { get; set; } = false;
        public DateTime DateTime1 { get; set; }
        public DateTime DateTime2 { get; set; }
        public bool SubscribeBid { get; set; }
        public bool SubscribeAsk { get; set; }
        public bool SubscribeQuote { get; set; } = false;
        public bool SubscribeTrade { get; set; }
        public bool SubscribeBar { get; set; }
        public bool SubscribeBarSlice { get; set; } = false;
        public bool SubscribeLevelII { get; set; }
        public bool SubscribeNews { get; set; } = false;
        public bool SubscribeFundamental { get; set; } = false;
        public bool SubscribeAll { get; set; } = false;
        public BarFilter BarFilter => _barFilter;
        public DataProcessor Processor { get; set; } = new DataProcessor();
        public List<IDataSeries> Series { get; set; } = new List<IDataSeries>();

        public void Run()
        {
            if (_thread == null) {
                _thread = new Thread(new ThreadStart(Do));
                _thread.IsBackground = true;
                _thread.Name = $"{nameof(ChainDataSimulation)} Thread";
                _thread.Start();
            }
        }

        private void Do()
        {
            Console.WriteLine($"{DateTime.Now} {nameof(ChainDataSimulation)} thread started");
            if (!IsConnected) {
                Connect();
            }
            var queue = new EventQueue(1, 0, 2, 10, null);
            queue.IsSynched = true;
            queue.Enqueue(new OnQueueOpened(queue));
            queue.Enqueue(new OnSimulatorStart(DateTime1, DateTime2, 0L));
            queue.Enqueue(new OnQueueClosed(queue));
            framework.EventBus.DataPipe.Add(queue);
            _isRunning = true;
            _isExiting = false;
            var insts = framework.InstrumentManager.Instruments;
            while (!_isExiting) {

            }
        }

        public override void Subscribe(Instrument instrument)
        {
            if (_isRunning) {
                return;
            }

            if (instrument.Symbol.StartsWith("?") && !_chainList.ContainsKey(instrument.Symbol)) {
                _chainList.Add(instrument.Symbol, instrument);
            }
        }

        public override void Subscribe(InstrumentList instruments)
        {
            foreach (var item in instruments) {
                Subscribe(item);
            }
        }
    }
}
