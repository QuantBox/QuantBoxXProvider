/* ----------------------------------------------------------------------------------------------
 * 
 * Author: Rajeev Ravindranath (rajeev511@gmail.com) 
 * Platform: Microsoft .Net 4.0
 * Coded using: Microsoft Visual Studio 2010 
 * OS: Microsoft Windows 7
 * 
 * ----------------------------------------------------------------------------------------------
 * ----------------------------------------------------------------------------------------------
 * 
 * Although, I have tried meticulously to make the following source code as correct as possible
 * I assume no responsibility for absolutely any kind of loss incurred due to the use of it. If
 * any error/inconsistency is found in it, I may try to fix it but I provide no such assurance. 
 * 
 * ----------------------------------------------------------------------------------------------
 * ----------------------------------------------------------------------------------------------
 * 
 * You shall not:
 * - use this work for any monetary profit, without the prior written consent of the author.
 * - remove or modify this disclaimer.
 * - pass this on as your own work.
 * 
 * If you ever publish something that uses this in the original or modified form, please do mention 
 * it along with the author's name and email id.
 * 
 * ----------------------------------------------------------------------------------------------
 * ----------------------------------------------------------------------------------------------
 * 
 * Thank You.
 * Rajeev
 * 
 * ----------------------------------------------------------------------------------------------
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;
using System.Collections;

namespace Rajeev.Windows.Forms
{
    partial class RPropertyGrid
    {
        /// <summary>
        /// Represents the special <see cref="T:System.ComponentModel.TypeConverter"/> that makes every property of the applicable object as read only.
        /// </summary>
        private class ReadOnlyConverter : TypeConverter
        {            
            private TypeConverter _originalConverter;

            /// <summary>
            /// Initializes a new instance of the <see cref="ReadOnlyConverter"/> class.
            /// </summary>
            /// <param name="originalConverter">The original converter.</param>
            public ReadOnlyConverter(TypeConverter originalConverter)
            {
                _originalConverter = originalConverter;
            }

            /// <summary>
            /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
            /// <param name="sourceType">A <see cref="T:System.Type"/> that represents the type you want to convert from.</param>
            /// <returns>
            /// true if this converter can perform the conversion; otherwise, false.
            /// </returns>
            public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            {
                return _originalConverter.CanConvertFrom(context, sourceType);
            }

            /// <summary>
            /// Returns whether this converter can convert the object to the specified type, using the specified context.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
            /// <param name="destinationType">A <see cref="T:System.Type"/> that represents the type you want to convert to.</param>
            /// <returns>
            /// true if this converter can perform the conversion; otherwise, false.
            /// </returns>
            public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
            {
                return _originalConverter.CanConvertTo(context, destinationType);
            }

            /// <summary>
            /// Converts the given object to the type of this converter, using the specified context and culture information.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
            /// <param name="culture">The <see cref="T:System.Globalization.CultureInfo"/> to use as the current culture.</param>
            /// <param name="value">The <see cref="T:System.Object"/> to convert.</param>
            /// <returns>
            /// An <see cref="T:System.Object"/> that represents the converted value.
            /// </returns>
            /// <exception cref="T:System.NotSupportedException">The conversion cannot be performed. </exception>
            public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
            {
                return _originalConverter.ConvertFrom(context, culture, value);
            }

            /// <summary>
            /// Converts the given value object to the specified type, using the specified context and culture information.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
            /// <param name="culture">A <see cref="T:System.Globalization.CultureInfo"/>. If null is passed, the current culture is assumed.</param>
            /// <param name="value">The <see cref="T:System.Object"/> to convert.</param>
            /// <param name="destinationType">The <see cref="T:System.Type"/> to convert the <paramref name="value"/> parameter to.</param>
            /// <returns>
            /// An <see cref="T:System.Object"/> that represents the converted value.
            /// </returns>
            /// <exception cref="T:System.ArgumentNullException">The <paramref name="destinationType"/> parameter is null. </exception>
            /// <exception cref="T:System.NotSupportedException">The conversion cannot be performed. </exception>
            public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
            {
                return _originalConverter.ConvertTo(context, culture, value, destinationType);
            }

            /// <summary>
            /// Creates an instance of the type that this <see cref="T:System.ComponentModel.TypeConverter"/> is associated with, using the specified context, given a set of property values for the object.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
            /// <param name="propertyValues">An <see cref="T:System.Collections.IDictionary"/> of new property values.</param>
            /// <returns>
            /// An <see cref="T:System.Object"/> representing the given <see cref="T:System.Collections.IDictionary"/>, or null if the object cannot be created. This method always returns null.
            /// </returns>
            public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
            {
                return _originalConverter.CreateInstance(context, propertyValues);
            }

            /// <summary>
            /// Returns whether changing a value on this object requires a call to <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)"/> to create a new value, using the specified context.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
            /// <returns>
            /// true if changing a property on this object requires a call to <see cref="M:System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)"/> to create a new value; otherwise, false.
            /// </returns>
            public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
            {
                return _originalConverter.GetCreateInstanceSupported(context);
            }

            /// <summary>
            /// Returns a collection of properties for the type of array specified by the value parameter, using the specified context and attributes.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
            /// <param name="value">An <see cref="T:System.Object"/> that specifies the type of array for which to get properties.</param>
            /// <param name="attributes">An array of type <see cref="T:System.Attribute"/> that is used as a filter.</param>
            /// <remarks>
            /// This is the point where instead of the actual properties of the object a collection of special, always read only, <see cref="T:System.ComponentModel.PropertyDescriptor"/> is returned.
            /// </remarks>
            /// <returns>
            /// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"/> with the properties that are exposed for this data type, or null if there are no properties.
            /// </returns>
            public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
            {
                PropertyDescriptorCollection originalProperties = _originalConverter.GetProperties(context, value, attributes);
                PropertyDescriptor[] readOnlyProperties = new PropertyDescriptor[originalProperties.Count];

                for (int i = 0; i < originalProperties.Count; i++)
                {
                    readOnlyProperties[i] = new ReadOnlyPropertyDescriptor(originalProperties[i]);
                }

                return new PropertyDescriptorCollection(readOnlyProperties);
            }

            /// <summary>
            /// Returns whether this object supports properties, using the specified context.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
            /// <returns>
            /// true if <see cref="M:System.ComponentModel.TypeConverter.GetProperties(System.Object)"/> should be called to find the properties of this object; otherwise, false.
            /// </returns>
            public override bool GetPropertiesSupported(ITypeDescriptorContext context)
            {
                return _originalConverter.GetPropertiesSupported(context);
            }

            /// <summary>
            /// Returns a collection of standard values for the data type this type converter is designed for when provided with a format context.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context that can be used to extract additional information about the environment from which this converter is invoked. This parameter or properties of this parameter can be null.</param>
            /// <returns>
            /// A <see cref="T:System.ComponentModel.TypeConverter.StandardValuesCollection"/> that holds a standard set of valid values, or null if the data type does not support a standard set of values.
            /// </returns>
            public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            {
                return _originalConverter.GetStandardValues(context);
            }

            /// <summary>
            /// Returns whether the collection of standard values returned from <see cref="M:System.ComponentModel.TypeConverter.GetStandardValues"/> is an exclusive list of possible values, using the specified context.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
            /// <returns>
            /// true if the <see cref="T:System.ComponentModel.TypeConverter.StandardValuesCollection"/> returned from <see cref="M:System.ComponentModel.TypeConverter.GetStandardValues"/> is an exhaustive list of possible values; false if other values are possible.
            /// </returns>
            public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
            {
                return _originalConverter.GetStandardValuesExclusive(context);
            }

            /// <summary>
            /// Returns whether this object supports a standard set of values that can be picked from a list, using the specified context.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
            /// <returns>
            /// true if <see cref="M:System.ComponentModel.TypeConverter.GetStandardValues"/> should be called to find a common set of values the object supports; otherwise, false.
            /// </returns>
            public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
            {
                return _originalConverter.GetStandardValuesSupported(context);
            }

            /// <summary>
            /// Returns whether the given value object is valid for this type and for the specified context.
            /// </summary>
            /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
            /// <param name="value">The <see cref="T:System.Object"/> to test for validity.</param>
            /// <returns>
            /// true if the specified value is valid for this object; otherwise, false.
            /// </returns>
            public override bool IsValid(ITypeDescriptorContext context, object value)
            {
                return _originalConverter.IsValid(context, value);
            }
        }
    }
}
