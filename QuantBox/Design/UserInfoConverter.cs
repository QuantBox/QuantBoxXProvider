using System.Collections.Generic;

namespace QuantBox.Design
{
    internal class UserInfoConverter : ApiSettingsConverter
    {
        protected override IDictionary<string, string> PropertyMap => Provider.GetUserPropertyMap();
        internal static XProvider Provider;
    }
}