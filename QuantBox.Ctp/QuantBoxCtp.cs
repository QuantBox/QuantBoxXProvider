using System.Collections.Generic;
using SmartQuant;

namespace QuantBox
{
    public class QuantBoxCtp : XProvider, IExecutionProvider, IDataProvider, IInstrumentProvider
    {
        private const string ProviderName = "QuantBoxCtp";
        protected override XProviderSettings LoadSettings()
        {
            var settings = XProviderSettings.Load(QBHelper.GetConfigPath(ProviderName));
            if (settings == null) {
                settings = new XProviderSettings {
                    Id = 51,
                    Name = ProviderName,
                    Url = "www.thanf.com",
                    Description = " 天风期货 CTP 插件",
                    UserProductInfo = "OpenQuant",
                    Connections = new List<ConnectionInfo>(),
                    Users = new List<UserInfo>(),
                    Servers = new List<ServerInfo>(),
                };
            }
            else {
                settings.Name = ProviderName;
            }
            return settings;
        }

        protected override IDictionary<string, string> GetServerPropertyMap()
        {
            return new Dictionary<string, string>{
                {"Label", "标识"},
                {"PublicTopicResumeType", "PublicTopicResumeType"},
                {"PrivateTopicResumeType", "PrivateTopicResumeType"},
                {"UserTopicResumeType", "UserTopicResumeType"},
                {"UserProductInfo", "UserProductInfo"},
                {"BrokerID", "BrokerID"},
                {"AuthCode", "AuthCode"},
                {"Address", "Address"},
                {"Port", "Port"},
                {"IsUsingUdp", "IsUsingUdp"},
                {"IsMulticast","IsMulticast"}
            };
        }

        protected override IDictionary<string, string> GetUserPropertyMap()
        {
            return new Dictionary<string, string>{
                {"Label", "标识"},
                {"UserId", "用户名"},
                {"Password", "密码"}
            };
        }

        public QuantBoxCtp(Framework framework)
            : base(framework)
        {
        }
    }
}