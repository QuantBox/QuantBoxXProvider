using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.Serialization;
using System.Windows.Forms.Design;
using Newtonsoft.Json;
using QuantBox.Design;
using QuantBox.XApi;

namespace QuantBox
{
    [DefaultProperty("Label")]
    [TypeConverter(typeof(ServerInfoConverter))]
    [JsonConverter(typeof(NoTypeConverterJsonConverter<ServerInfo>))]
    [DataContract]
    public class ServerInfo
    {
        private const string OpenQuant = "OpenQuant";

        [Category("标签")]
        [DataMember]
        public string Label { get; set; }

        [Category("标签")]
        [DataMember]
        public string Name { get; set; }

        [Category("标签")]
        [Editor(typeof(ApiTypeSelectorEditor), typeof(UITypeEditor))]
        [DataMember]
        public ApiType Type { get; set; }

        /// <summary>
        /// 订阅主题
        /// </summary>
        [Category("行情 - Femas")]
        [Description("Femas")]
        [DataMember]
        public int TopicId { get; set; }

        [Category("流重传方式")]
        [DataMember]
        public ResumeType MarketDataTopicResumeType { get; set; }
        [Category("流重传方式")]
        [DataMember]
        public ResumeType PrivateTopicResumeType { get; set; }
        [Category("流重传方式")]
        [DataMember]
        public ResumeType PublicTopicResumeType { get; set; }
        [Category("流重传方式")]
        [DataMember]
        public ResumeType UserTopicResumeType { get; set; }

        [Category("服务端信息")]
        [DataMember]
        public string BrokerID { get; set; }

        [Category("客户端认证")]
        [DataMember]
        public string UserProductInfo { get; set; }

        [Category("客户端认证")]
        [DataMember]
        public string AuthCode { get; set; }

        [Category("服务端信息")]
        [DataMember]
        public string Address { get; set; }

        [Category("配置信息")]
        [Editor(typeof(FileNameEditor), typeof(UITypeEditor))]
        [DataMember]
        public string ConfigPath { get; set; }

        [Category("配置信息")]
        [Editor(typeof(FileNameEditor), typeof(UITypeEditor))]
        [DataMember]
        public string ConfigPath2 { get; set; }

        /// <summary>
        /// 端口号
        /// </summary>
        [Category("服务端信息")]
        [DataMember]
        public int Port { get; set; }
        /// <summary>
        /// UDP行情
        /// </summary>
        [Category("行情")]
        [Description("CTP-网络连接模式")]
        [DataMember]
        public bool IsUsingUdp { get; set; }
        /// <summary>
        /// 多播行情
        /// </summary>
        [Category("行情")]
        [Description("CTP-行情广播模式")]
        [DataMember]
        public bool IsMulticast { get; set; }

        public ServerInfo()
        {
            UserProductInfo = OpenQuant;
        }

        public ServerInfoField Get()
        {
            var field = new ServerInfoField {
                IsUsingUdp = IsUsingUdp,
                IsMulticast = IsMulticast,
                TopicId = TopicId,
                Port = Port,
                MarketDataTopicResumeType = MarketDataTopicResumeType,
                PrivateTopicResumeType = PrivateTopicResumeType,
                PublicTopicResumeType = PublicTopicResumeType,
                UserTopicResumeType = UserTopicResumeType,
                BrokerID = BrokerID,
                UserProductInfo = UserProductInfo,
                AuthCode = AuthCode,
                Address = Address
            };
            return field;
        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(Label) ? "空服务" : Label;
        }

        public ServerInfo Clone()
        {
            return (ServerInfo)MemberwiseClone();
        }
    }
}
