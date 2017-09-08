using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace QuantBox.Design
{
    internal abstract class ApiSettingsConverter : ExpandableObjectConverter
    {
        protected abstract IDictionary<string, string> PropertyMap { get; }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            var props = base.GetProperties(context, value, attributes);
            var list = new List<PropertyDescriptor>(props.Count);
            var map = PropertyMap;
            if (map == null) {
                list.AddRange(props.Cast<PropertyDescriptor>());
            }
            else {
                foreach (PropertyDescriptor prop in props) {
                    map.TryGetValue(prop.Name, out string displayName);
                    if (string.IsNullOrEmpty(displayName)) {
                        continue;
                    }
                    if (displayName != prop.DisplayName) {
                        list.Add(new DisplayNamePropertyDescriptor(prop, displayName));
                    }
                    else {
                        list.Add(prop);
                    }
                }
            }
            return new PropertyDescriptorCollection(list.ToArray(), true);
        }
    }
}