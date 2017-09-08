using System;
using SmartQuant;

namespace QuantBox
{
    public class EventPipe
    {
        private Framework _framework;

        private readonly LinkedList<IEventQueue> _queues = new LinkedList<IEventQueue>();
        
        public EventPipe(Framework framework)
        {
            _framework = framework;
        }

        public int Count => _queues.Count;

        public void Add(IEventQueue queue)
        {
            _queues.Add(queue);
        }

        public void Remove(IEventQueue queue)
        {
            _queues.Remove(queue);
        }

        public bool IsEmpty()
        {
            if (_queues.Count != 0) {
                for (var node = _queues.First; node != null; node = node.Next) {
                    if (!node.Data.IsEmpty()) {
                        return false;
                    }
                }
            }
            return true;
        }

        public Event Read()
        {
            if (_queues.Count != 0) {
                var next = _queues.First;
                LinkedListNode<IEventQueue> prev = null;
                while (next != null) {
                    if (!next.Data.IsEmpty()) {
                        var @event = next.Data.Read();
                        if (@event.TypeId == EventType.OnQueueClosed/*175*/) {
                            if (prev == null) {
                                _queues.First = next.Next;
                            }
                            else {
                                prev.Next = next.Next;
                            }
                            _queues.Count--;
                        }
                        return @event;
                    }
                    prev = next;
                    next = next.Next;
                }
            }
            return null;
        }

        public Event Dequeue()
        {
            return null;
        }

        public void Clear()
        {
            _queues.Clear();
        }
    }
}
