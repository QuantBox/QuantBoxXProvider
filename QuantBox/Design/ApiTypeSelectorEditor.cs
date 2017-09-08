using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using QuantBox.XApi;

namespace QuantBox.Design
{
    internal class ApiTypeSelectorEditor : ObjectSelectorEditor
    {
        private Selector _selector;

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            base.EditValue(context, provider, value);
            _selector.BeforeSelect -= SelectBefore;
            var type = 0;
            foreach (SelectorNode node in _selector.Nodes) {
                if (node.Checked) {
                    type |= (int)node.value;
                }
            }
            return (ApiType)type;
        }

        protected override void FillTreeWithData(Selector selector, ITypeDescriptorContext context, IServiceProvider provider)
        {
            if (context?.Instance != null) {
                var instance = (ConnectionInfo)context.Instance;
                _selector = selector;
                selector.CheckBoxes = true;
                selector.BeforeSelect += SelectBefore;
                selector.Clear();
                foreach (ApiType category in Enum.GetValues(typeof(ApiType))) {
                    if (category != ApiType.None) {
                        if ((instance.Type & category) == category) {
                            selector.AddNode(category.ToString(), (int)category, null).Checked = (instance.UseType & category) == category;
                        }
                    }
                }
                selector.SelectedNode = null;
            }
            else {
                base.FillTreeWithData(selector, context, provider);
            }
        }

        private static void SelectBefore(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
