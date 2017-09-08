using System.Collections.Generic;
using System.ComponentModel;

namespace QuantBox.Design
{
    internal class ServerSelectorConverter : ComboBoxItemTypeConverter
    {
        protected override void GetItems(ITypeDescriptorContext context)
        {
            Items.Clear();
            if (context?.Instance is ConnectionInfo) {
                for (var i = 0; i < Servers.Count; i++) {
                    Items[i] = Servers[i];
                }
            }
        }

        internal static IList<ServerInfo> Servers;
    }
}