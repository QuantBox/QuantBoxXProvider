using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartQuant;

namespace QuantBox
{
    public class OptionStrategy : Strategy
    {
        public OptionStrategy(Framework framework, string name)
            : base(framework, name)
        {
        }

        protected sealed override void OnUserEvent(Event e)
        {
            if (e.TypeId == OptionChainDataType.OptionChainData)
            {

            }
            else
            {
                OnUserEvent2(e);
            }
        }

        protected virtual void OnUserEvent2(Event e)
        {

        }
    }
}
