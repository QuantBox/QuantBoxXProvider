using System.Collections.Generic;
using System.ComponentModel;

namespace QuantBox.Design
{
    internal class UserSelectorConverter : ComboBoxItemTypeConverter
    {
        protected override void GetItems(ITypeDescriptorContext context)
        {
            Items.Clear();
            if (context?.Instance is ConnectionInfo) {
                for (var i = 0; i < Users.Count; i++) {
                    Items[i] = Users[i];
                }
            }
        }

        internal static IList<UserInfo> Users;
    }
}