using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using SmartQuant;

namespace QuantBox.Design
{
    internal abstract class ProviderTypeConverter : TypeConverter
    {
        private readonly SortedDictionary<int, IProvider> _items = new SortedDictionary<int, IProvider>();

        private void GetProviders()
        {
            _items.Add(-1, null);
            foreach (var provider in Framework.Current.ProviderManager.Providers) {
                if (Filter(provider) && !_items.ContainsKey(provider.Id)) {
                    _items.Add(provider.Id, provider);
                }
            }
        }

        protected abstract bool Filter(IProvider provider);

        public ProviderTypeConverter()
        {
            GetProviders();
        }

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
            return new StandardValuesCollection(_items.Keys);
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
                if (string.IsNullOrEmpty(v.ToString())) {
                    return -1;
                }
                foreach (var pair in _items) {
                    if (pair.Value?.Name == v.ToString())
                        return pair.Key;
                }
            }
            return base.ConvertFrom(context, culture, v);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object v, Type destinationType)
        {
            if (destinationType == typeof(string) && v is int) {
                if ((int)v < byte.MinValue && (int)v > byte.MaxValue) {
                    return " ";
                }
                _items.TryGetValue((byte)(int)v, out IProvider provider);
                return provider?.Name;
            }
            return base.ConvertTo(context, culture, v, destinationType);
        }
    }
}
