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

        private void DoSubscribe(Instrument inst)
        {
            _provider.market.Subscribe(inst);
            _provider.SubscribeDone(inst);
        }

        private void SubscribeAction(Event e)
        {
            switch (e.TypeId) {
                case EventType.OnDisconnect:
                    _instruments.Clear();
                    break;
                case EventType.OnConnect:
                    if (_provider.market.Connected) {
                        foreach (var item in _instruments) {
                            DoSubscribe(item.Value);
                        }
                    }
                    break;
                case EventType.OnSubscribe:
                    var sub = (OnSubscribe)e;
                    if (_instruments.ContainsKey(sub.Instrument.Id)) {
                        return;
                    }
                    if (_provider.IsConnected) {
                        DoSubscribe(sub.Instrument);
                    }
                    _instruments[sub.Instrument.Id] = sub.Instrument;
                    break;
                case EventType.OnUnsubscribe:
                    var unsubscribe = (OnUnsubscribe)e;
                    _instruments.Remove(unsubscribe.Instrument.Id);
                    if (_provider.IsConnected) {
                        _provider.market.Unsubscribe(unsubscribe.Instrument);
                    }
                    break;
            }
        }

        public SubscribeManager(XProvider provider)
        {
            _provider = provider;
            _action = new ActionBlock<Event>(SubscribeAction, DataflowHelper.SpscBlockOptions);
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