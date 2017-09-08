using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace QuantBox.Design
{
    internal abstract class ComboBoxItemTypeConverter : TypeConverter
    {
        protected readonly SortedDictionary<int, object> Items = new SortedDictionary<int, object>();

        protected abstract void GetItems(ITypeDescriptorContext context);

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            GetItems(context);
            return new StandardValuesCollection(Items.Keys);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return true;
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object v)
        {
            if (v is string) {
                foreach (var pair in Items) {
                    if (pair.Value.ToString() == v.ToString())
                        return pair.Key;
                }
            }
            return base.ConvertFrom(context, culture, v);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object v, Type destinationType)
        {
            GetItems(context);
            if (destinationType == typeof(string) && v is int) {
                foreach (var pair in Items) {
                    if (pair.Key == (int)v)
                        return pair.Value.ToString();
                }
                return "";
            }
            return base.ConvertTo(context, culture, v, destinationType);
        }
    }
}