using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartQuant;

namespace QuantBox.OrderProxy
{
    internal class EmptyDataProvider : Provider, IDataProvider
    {
        public static readonly EmptyDataProvider Instance;
        static EmptyDataProvider()
        {
            Instance = new EmptyDataProvider(null);
        }
        public EmptyDataProvider(Framework framework) : base(framework)
        {
        }
    }
}
