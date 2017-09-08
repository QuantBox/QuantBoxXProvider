using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace QuantBox.Design
{
    internal class XApiSettingsTypeEditor : UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (context?.Instance == null || provider == null) {
                return base.EditValue(context, provider, value);
            }
            if (provider.GetService(typeof(IWindowsFormsEditorService)) is IWindowsFormsEditorService service) {
                var instance = (XProvider)context.Instance;
                var dialog = new XApiSettingsDialog(instance);
                service.ShowDialog(dialog);
            }
            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if (context?.Instance != null) {
                return UITypeEditorEditStyle.Modal;
            }
            return base.GetEditStyle(context);
        }
    }
}
