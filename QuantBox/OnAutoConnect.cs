using SmartQuant;

namespace QuantBox
{
    internal class OnAutoConnect : Event
    {
        public override byte TypeId => XEventType.OnAutoReconnect;
    }
}
