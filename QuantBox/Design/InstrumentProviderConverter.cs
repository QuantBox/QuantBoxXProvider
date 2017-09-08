using SmartQuant;

namespace QuantBox.Design
{
    internal class InstrumentProviderConverter : ProviderTypeConverter
    {
        protected override bool Filter(IProvider provider)
        {
            return provider is IInstrumentProvider;
        }
    }
}
