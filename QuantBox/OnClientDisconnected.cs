using SmartQuant;

namespace QuantBox
{
    internal class OnClientDisconnected : Event
    {
        public override byte TypeId => XEventType.OnClientDisconnected;
    }
}
