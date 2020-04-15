using SmartQuant;

namespace QuantBox
{
    public class OptionChainData : DataObject
    {
        public override byte TypeId => OptionChainDataType.OptionChainData;
        public readonly byte DataTypeId;

        public OptionChainData()
        {

        }
    }
}
