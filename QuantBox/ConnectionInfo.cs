using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.Serialization;
using System.Windows.Forms.Design;
using QuantBox.XApi;

namespace QuantBox
{
    [DataContract]
    public class ConnectionInfo
    {
        private const string CategoryInfo = "Information";
        private const string CategoryType = "Type";

        [Editor(typeof(FileNameEditor), typeof(UITypeEditor))]
        [DataMember]
        public string ApiPath { get; set; }

        [Category(CategoryInfo)]
        [ReadOnly(true)]
        [DataMember]
        public string Name { get; set; }

        [Category(CategoryInfo)]
        [ReadOnly(true)]
        [DataMember]
        public string Version { get; set; }

        [TypeConverter(typeof(Design.UserSelectorConverter))]
        [DataMember]
        public int User { get; set; }

        [TypeConverter(typeof(Design.ServerSelectorConverter))]
        [DataMember]
        public int Server { get; set; }

        [DataMember]
        public string LogPrefix { get; set; }

        [DataMember]
        public bool Active { get; set; }

        [Category(CategoryType)]
        [ReadOnly(true)]
        [DataMember]
        public ApiType Type { get; set; }

        [Category(CategoryType)]
        [Editor(typeof(Design.ApiTypeSelectorEditor), typeof(UITypeEditor))]
        [DataMember]
        public ApiType UseType { get; set; }

        public override string ToString()
        {
            return $"LogPrefix={LogPrefix};UseType={UseType};Name={Name}";
        }

        public ConnectionInfo Clone()
        {
            return (ConnectionInfo)MemberwiseClone();
        }
    }
}