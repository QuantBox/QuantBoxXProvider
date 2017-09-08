using System.Collections.Generic;

namespace QuantBox.Design
{
    internal class ServerInfoConverter : ApiSettingsConverter
    {
        protected override IDictionary<string,string> PropertyMap  => Provider.GetServerPropertyMap();
        internal static XProvider Provider;
    }
}
