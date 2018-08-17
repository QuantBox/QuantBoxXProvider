using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace QuantBox.Design
{
    internal class TimeSpanEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService service = null;
            if (provider != null)
                service = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

            if (service != null) {
                var dtp = new DateTimePicker();
                if (value != null) {
                    dtp.Value = DateTime.Today.Add((TimeSpan)value);
                    dtp.Format = DateTimePickerFormat.Time;
                    dtp.ShowUpDown = true;
                    service.DropDownControl(dtp);
                }
                value = dtp.Value.TimeOfDay;
            }
            return value;
        }
    }
}