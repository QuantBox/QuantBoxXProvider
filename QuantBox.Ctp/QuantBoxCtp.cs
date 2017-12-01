using System;
using System.Collections.Generic;
using QuantBox.XApi;
using SmartQuant;

namespace QuantBox
{
    public class QuantBoxCtp : XProvider, IExecutionProvider, IDataProvider, IInstrumentProvider
    {
        private const string ProviderName = "天风CTP";

        protected override XProviderSettings LoadSettings()
        {
            var defaultSettings = new XProviderSettings {
                Id = 61,
                Name = ProviderName,
                Url = "www.thanf.com",
                Description = "QuantBox CTP 插件",
                UserProductInfo = "OpenQuant",
                Connections = new List<ConnectionInfo>(),
                Users = new List<UserInfo>(),
                Servers = new List<ServerInfo>(),
            };

            var settings = XProviderSettings.Load(QBHelper.GetConfigPath(GetSettingsFileName()));
            if (settings == null) {
                settings = defaultSettings;
            }
            else {
                settings.Id = defaultSettings.Id;
                settings.Url = defaultSettings.Url;
                settings.Description = defaultSettings.Description;
                settings.Name = ProviderName;
            }
            return settings;
        }

        protected override IDictionary<string, string> GetServerPropertyMap()
        {
            return new Dictionary<string, string>{
                {"Label", "标识"},
                {"Name", "名称"},
                {"Type", "服务类别"},
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