using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuantBox.Design
{
    public class FolderNameEditor2 : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var browser = new FolderBrowser2();
            if (value != null) {
                browser.DirectoryPath = $"{value}";
            }

            if (browser.ShowDialog(null) == DialogResult.OK)
                return browser.DirectoryPath;

            return value;
        }
    }
}
