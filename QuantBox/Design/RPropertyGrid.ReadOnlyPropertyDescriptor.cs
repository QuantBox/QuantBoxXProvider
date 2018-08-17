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
using System.Drawing.Design;

namespace Rajeev.Windows.Forms
{
    partial class RPropertyGrid
    {
        /// <summary>
        /// Represents a special variation of <see cref="T:System.ComponentModel.PropertyDescriptor"/> which is always read only.
        /// </summary>
         private class ReadOnlyPropertyDescriptor : PropertyDescriptor
         {
             private PropertyDescriptor _originalPropertyDescriptor;
             private ReadOnlyConverter _typeConverter;

             private static UITypeEditor _editor = new UITypeEditor();

             /// <summary>
             /// Initializes a new instance of the <see cref="ReadOnlyPropertyDescriptor"/> class.
             /// </summary>
             /// <param name="originalPropertyDescriptor">The original property descriptor.</param>
             public ReadOnlyPropertyDescriptor(PropertyDescriptor originalPropertyDescriptor)
                 : base(originalPropertyDescriptor)
             {
                 _originalPropertyDescriptor = originalPropertyDescriptor;
                 _typeConverter = new ReadOnlyConverter(originalPropertyDescriptor.Converter);
             }

             /// <summary>
             /// When overridden in a derived class, returns whether resetting an object changes its value.
             /// </summary>
             /// <param name="component">The component to test for reset capability.</param>
             /// <returns>
             /// true if resetting the component changes its value; otherwise, false.
             /// </returns>
             public override bool CanResetValue(object component)
             {
                 return _originalPropertyDescriptor.CanResetValue(component);
             }

             /// <summary>
             /// When overridden in a derived class, gets the type of the component this property is bound to.
             /// </summary>
             /// <value></value>
             /// <returns>A <see cref="T:System.Type"/> that represents the type of component this property is bound to. When the <see cref="M:System.ComponentModel.PropertyDescriptor.GetValue(System.Object)"/> or <see cref="M:System.ComponentModel.PropertyDescriptor.SetValue(System.Object,System.Object)"/> methods are invoked, the object specified might be an instance of this type.</returns>
             public override Type ComponentType
             {
                 get { return _originalPropertyDescriptor.ComponentType; }
             }

             /// <summary>
             /// Gets the type converter for this property.
             /// </summary>
             /// <value></value>
             /// <returns>A <see cref="T:System.ComponentModel.TypeConverter"/> that is used to convert the <see cref="T:System.Type"/> of this property.</returns>
             /// <PermissionSet>
             /// 	<IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/>
             /// </PermissionSet>
             public override TypeConverter Converter
             {
                 get { return _typeConverter; }
             }

             /// <summary>
             /// Gets an editor of the specified type.
             /// </summary>
             /// <param name="editorBaseType">The base type of editor, which is used to differentiate between multiple editors that a property supports.</param>
             /// <returns>
             /// An instance of the requested editor type, or null if an editor cannot be found.
             /// </returns>
             public override object GetEditor(Type editorBaseType)
             {
                 //return _originalPropertyDescriptor.GetEditor(editorBaseType);
                 return _editor;
             }

             /// <summary>
             /// When overridden in a derived class, gets the current value of the property on a component.
             /// </summary>
             /// <param name="component">The component with the property for which to retrieve the value.</param>
             /// <returns>
             /// The value of a property for a given component.
             /// </returns>
             public override object GetValue(object component)
             {
                 return _originalPropertyDescriptor.GetValue(component);
             }

             /// <summary>
             /// When overridden in a derived class, gets a value indicating whether this property is read-only.
             /// </summary>
             /// <value></value>
             /// <returns>Always returns true.</returns>
             public override bool IsReadOnly
             {
                 get { return true; }
             }

             /// <summary>
             /// When overridden in a derived class, gets the type of the property.
             /// </summary>
             /// <value></value>
             /// <returns>A <see cref="T:System.Type"/> that represents the type of the property.</returns>
             public override Type PropertyType
             {
                 get { return _originalPropertyDescriptor.PropertyType; }
             }

             /// <summary>
             /// When overridden in a derived class, resets the value for this property of the component to the default value.
             /// </summary>
             /// <param name="component">The component with the property value that is to be reset to the default value.</param>
             public override void ResetValue(object component)
             {
                 _originalPropertyDescriptor.ResetValue(component);
             }

             /// <summary>
             /// When overridden in a derived class, sets the value of the component to a different value.
             /// </summary>
             /// <param name="component">The component with the property value that is to be set.</param>
             /// <param name="value">The new value.</param>
             public override void SetValue(object component, object value)
             {
                 _originalPropertyDescriptor.SetValue(component, value);
             }

             /// <summary>
             /// When overridden in a derived class, determines a value indicating whether the value of this property needs to be persisted.
             /// </summary>
             /// <param name="component">The component with the property to be examined for persistence.</param>
             /// <returns>
             /// true if the property should be persisted; otherwise, false.
             /// </returns>
             public override bool ShouldSerializeValue(object component)
             {
                 return _originalPropertyDescriptor.ShouldSerializeValue(component);
             }

         }
    }
}
