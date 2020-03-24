using System.Collections.Generic;
using QuantBox.XApi;
using SmartQuant;

namespace QuantBox
{
    public class QuantBoxCtpse : XProvider, IInstrumentProvider
    {
        private const string ProviderName = "QuantBoxCtpse";

        protected override XProviderSettings LoadSettings()
        {
            var defaultSettings = new XProviderSettings {
                Id = QuantBoxConst.PIdCtp,
                Name = ProviderName,
                Url = "www.quantbox.cn",
                Description = "QuantBox Ctpse 插件",
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

        protected override ServerInfoField GetServerInfo(ServerInfo info)
        {
            var field = base.GetServerInfo(info);
            field.ExtInfoChar128 = info.AppId;
            return field;
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
                {"AppId", "客户端标识(看穿式监管)"},
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

        public QuantBoxCtpse(Framework framework)
            : base(framework)
        {
        }
    }
}