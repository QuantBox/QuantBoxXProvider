using System;
using System.Collections.Generic;
using System.Threading.Tasks.Dataflow;
using SmartQuant;

namespace QuantBox
{
    internal class SubscribeManager
    {
        private readonly XProvider _provider;
        private readonly ActionBlock<Event> _action;
        private readonly Dictionary<int, Instrument> _instruments = new Dictionary<int, Instrument>();

        private void SubscribeAction(Event e)
        {
            switch (e.TypeId) {
                case EventType.OnDisconnect:
                    _instruments.Clear();
                    break;
                case EventType.OnConnect:
                    foreach (var item in _instruments) {
                        _provider.Market.Subscribe(item.Value);
                    }
                    break;
                case EventType.OnSubscribe:
                    var sub = (OnSubscribe)e;
                    if (_provider.IsConnected) {
                        _provider.Market.Subscribe(sub.Instrument);
                    }
                    if (!_instruments.ContainsKey(sub.Instrument.Id)) {
                        _instruments.Add(sub.Instrument.Id, sub.Instrument);
                    }
                    break;
                case EventType.OnUnsubscribe:
                    var unsub = (OnUnsubscribe)e;
                    _instruments.Remove(unsub.Instrument.Id);
                    if (_provider.IsConnected) {
                        _provider.Market.Unsubscribe(unsub.Instrument);
                    }
                    break;
            }
        }

        public SubscribeManager(XProvider provider)
        {
            _provider = provider;
            _action = new ActionBlock<Event>((Action<Event>)SubscribeAction);
        }

        public void Subscribe(Instrument inst)
        {
            _action.Post(new OnSubscribe(inst));
        }

        public void Unsubscribe(Instrument inst)
        {
            _action.Post(new OnUnsubscribe(inst));
        }

        public void Clear()
        {
            _action.Post(new OnDisconnect());
        }

        public void Resubscribe()
        {
            _action.Post(new OnConnect());
        }
    }
}