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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace Rajeev.Windows.Forms
{
    /// <summary>
    /// Provides a version of <see cref="T:System.Windows.Forms.PropertyGrid"/> with the capability of displaying object as read-only.
    /// </summary>
    public partial class RPropertyGrid : PropertyGrid
    {
        private bool _readOnly;
        private bool _selectionChangedInternally;
        private ReadOnlyCollection<object> _originalSelectedObjects;

        /// <summary>
        /// Initializes a new instance of the <see cref="RPropertyGrid"/> class.
        /// </summary>
        public RPropertyGrid()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="P:SelectedObjects"/> is displayed as read only.
        /// </summary>
        /// <value><c>true</c> if read only; otherwise, <c>false</c>.</value>
        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                SetReadOnly();
            }
        }

        /// <summary>
        /// Gets the original unwrapped selected object.
        /// </summary>
        /// <remarks>
        /// Use this property instead of <see cref="P:SelectedObject"/> to get the correct unwrapped object that is being displayed.
        /// If the <see cref="ReadOnly"/> property is set to <c>false</c> then the value returned by both this property and <see cref="P:SelectedObject"/> will be the same.
        /// </remarks>
        /// <value>The original selected object.</value>
        public object OriginalSelectedObject
        {
            get 
            {
                object selectedObject = null;

                if (null != _originalSelectedObjects && _originalSelectedObjects.Count > 0)
                {
                    selectedObject = _originalSelectedObjects[0];
                }

                return selectedObject;
            }           
        }

        /// <summary>
        /// Gets the original unwrapped selected objects.
        /// </summary>
        /// <remarks>
        /// Use this property instead of <see cref="P:SelectedObjects"/> to get the correct unwrapped objects that are being displayed.
        /// If the <see cref="ReadOnly"/> property is set to <c>false</c> then the values returned by both this property and <see cref="P:SelectedObjects"/> will be the same.
        /// </remarks>
        /// <value>The original selected objects.</value>
        public ReadOnlyCollection<object> OriginalSelectedObjects
        {
            get { return _originalSelectedObjects; }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.PropertyGrid.SelectedObjectsChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnSelectedObjectsChanged(EventArgs e)
        {
            if (!_selectionChangedInternally)
            {
                base.OnSelectedObjectsChanged(e);

                _originalSelectedObjects = new ReadOnlyCollection<object>(SelectedObjects);
                SetReadOnly();
            }           
        }

        private void SetReadOnly()
        {
            if (null != _originalSelectedObjects)
            {
                _selectionChangedInternally = true;

                if (_readOnly)
                {
                    object[] wrappedSelectedObjects = new object[SelectedObjects.Length];
                    for (int i = 0; i < wrappedSelectedObjects.Length; i++)
                    {
                        wrappedSelectedObjects[i] = new ReadOnlyWrapper(SelectedObjects[i]);
                    }

                    SelectedObjects = wrappedSelectedObjects;
                }
                else
                {
                    SelectedObjects = _originalSelectedObjects.ToArray();
                }

                _selectionChangedInternally = false;
            }
        }
    }
}
