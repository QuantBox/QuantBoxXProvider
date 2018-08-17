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

namespace Rajeev.Windows.Forms
{
    partial class RPropertyGrid
    {
        /// <summary>
        /// Represents a class that wraps the specified object so that all its properties become read only.
        /// </summary>
        private class ReadOnlyWrapper : ICustomTypeDescriptor
        {
            private object _wrappedObject;
            private ReadOnlyConverter _typeConverter;

            /// <summary>
            /// Initializes a new instance of the <see cref="ReadOnlyWrapper"/> class.
            /// </summary>
            /// <param name="wrappedObject">The selected object.</param>
            public ReadOnlyWrapper(object wrappedObject)
            {
                _wrappedObject = wrappedObject;
                _typeConverter = new ReadOnlyConverter(TypeDescriptor.GetConverter(_wrappedObject));
            }

            /// <summary>
            /// Gets the wrapped object.
            /// </summary>
            /// <value>The wrapped object.</value>
            public object WrappedObject
            {
                get { return _wrappedObject; }
            }

            #region ICustomTypeDescriptor Members

            public AttributeCollection GetAttributes()
            {
                return TypeDescriptor.GetAttributes(_wrappedObject);
            }

            public string GetClassName()
            {
                return TypeDescriptor.GetClassName(_wrappedObject);
            }

            public string GetComponentName()
            {
                return TypeDescriptor.GetComponentName(_wrappedObject);
            }

            public TypeConverter GetConverter()
            {
                return _typeConverter;
            }

            public EventDescriptor GetDefaultEvent()
            {
                return TypeDescriptor.GetDefaultEvent(_wrappedObject);
            }

            public PropertyDescriptor GetDefaultProperty()
            {
                return TypeDescriptor.GetDefaultProperty(_wrappedObject);
            }

            public object GetEditor(Type editorBaseType)
            {
                return TypeDescriptor.GetEditor(_wrappedObject, editorBaseType);
            }

            public EventDescriptorCollection GetEvents(Attribute[] attributes)
            {
                return TypeDescriptor.GetEvents(_wrappedObject, attributes);
            }

            public EventDescriptorCollection GetEvents()
            {
                return TypeDescriptor.GetEvents(_wrappedObject);
            }

            public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
            {
                PropertyDescriptorCollection originalProperties = TypeDescriptor.GetProperties(_wrappedObject, attributes);
                PropertyDescriptor[] readOnlyProperties = new PropertyDescriptor[originalProperties.Count];

                for (int i = 0; i < originalProperties.Count; i++)
                {
                    readOnlyProperties[i] = new ReadOnlyPropertyDescriptor(originalProperties[i]);
                }

                return new PropertyDescriptorCollection(readOnlyProperties);
            }

            public PropertyDescriptorCollection GetProperties()
            {
                return TypeDescriptor.GetProperties(_wrappedObject);
            }

            public object GetPropertyOwner(PropertyDescriptor pd)
            {
                return _wrappedObject;
            }

            #endregion
        }
    }
}
