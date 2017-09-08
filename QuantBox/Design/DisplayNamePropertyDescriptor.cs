using System;
using System.ComponentModel;

namespace QuantBox.Design
{
    internal class DisplayNamePropertyDescriptor : PropertyDescriptor
    {
        private readonly PropertyDescriptor _parent;

        public DisplayNamePropertyDescriptor(PropertyDescriptor parent, string displayName)
            : base(parent)
        {
            DisplayName = displayName;
            _parent = parent;
        }

        public override string DisplayName { get; }

        public override bool ShouldSerializeValue(object component)
        {
            return _parent.ShouldSerializeValue(component);
        }

        public override void SetValue(object component, object value)
        {
            _parent.SetValue(component, value);
        }
        public override object GetValue(object component)
        {
            return _parent.GetValue(component);
        }
        public override void ResetValue(object component)
        {
            _parent.ResetValue(component);
        }
        public override bool CanResetValue(object component)
        {
            return _parent.CanResetValue(component);
        }
        public override bool IsReadOnly => _parent.IsReadOnly;

        public override void AddValueChanged(object component, EventHandler handler)
        {
            _parent.AddValueChanged(component, handler);
        }
        public override void RemoveValueChanged(object component, EventHandler handler)
        {
            _parent.RemoveValueChanged(component, handler);
        }
        public override bool SupportsChangeEvents => _parent.SupportsChangeEvents;

        public override Type PropertyType => _parent.PropertyType;

        public override TypeConverter Converter => _parent.Converter;

        public override Type ComponentType => _parent.ComponentType;

        public override string Description => _parent.Description;

        public override PropertyDescriptorCollection GetChildProperties(object instance, Attribute[] filter)
        {
            return _parent.GetChildProperties(instance, filter);
        }
        public override string Name => _parent.Name;
    }
}