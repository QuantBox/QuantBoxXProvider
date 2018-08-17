using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartQuant;

namespace QuantBox
{
    public class JsonOrderServer : OrderServer
    {
        private readonly Framework _framework;
        private string _seriesFile;
        private readonly Thread _thread;
        private readonly EventQueue _queue = new EventQueue();
        private readonly JsonSerializerSettings _serializerSettings;

        private void ThreadRun()
        {
            Console.WriteLine($@"JsonOrderServer thread started: Framework = {_framework.Name} Clock = {_framework.Clock.GetModeAsString()}");
            while (true) {
                if (_queue.IsEmpty()) {
                    Thread.Sleep(1);
                }
                else {
                    ProcessMessage((ExecutionMessage)_queue.Dequeue());
                }
            }
        }

        private void GetSeriesFile(string name)
        {
            _seriesFile = Path.Combine(Installation.DataDir.FullName, name + ".json");
        }

        public override int Get(string name)
        {
            GetSeriesFile(name);
            return -1;
        }

        private void ProcessMessage(ExecutionMessage msg)
        {
            var text = JsonConvert.SerializeObject(msg, Formatting.None, _serializerSettings);
            File.AppendAllText(_seriesFile, text + Environment.NewLine);
        }

        private static IgnoreSerializerContractResolver IgnoreMessageFileds()
        {
            var jsonResolver = new IgnoreSerializerContractResolver();
            var type = typeof(ExecutionMessage);
            jsonResolver.IgnoreProperty(type, "order");
            return jsonResolver;
        }

        public JsonOrderServer(Framework framework) :
            base(framework)
        {
            _framework = framework;
            _serializerSettings = new JsonSerializerSettings();
            _serializerSettings.ContractResolver = IgnoreMessageFileds();
            _thread = new Thread(ThreadRun);
            _thread.IsBackground = true;
            _thread.Name = "JsonOrderServer thread";
            _thread.Start();
        }
        
        public override void Save(ExecutionMessage message, int id = -1)
        {
            lock (this) {
                _queue.Enqueue(message);
            }
        }

        public override List<ExecutionMessage> Load(string name = null)
        {
            var list = new List<ExecutionMessage>();
            GetSeriesFile(name);
            if (!File.Exists(_seriesFile)) {
                return list;
            }
            var reader = new JsonTextReader(new StringReader(File.ReadAllText(_seriesFile)));
            reader.SupportMultipleContent = true;
            while (true) {
                if (!reader.Read()) {
                    break;
                }

                var token = JToken.Load(reader);
                var type = token["typeId"].Value<int>();
                switch (type) {
                    case EventType.ExecutionCommand:
                        list.Add(token.ToObject<ExecutionCommand>());
                        break;
                    case EventType.ExecutionReport:
                        list.Add(token.ToObject<ExecutionReport>());
                        break;
                    case EventType.AccountReport:
                        list.Add(token.ToObject<AccountReport>());
                        break;
                }
            }
            return list;
        }
    }
}
