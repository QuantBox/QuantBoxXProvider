using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;
using QuantBox.XApi;
using SmartQuant;

namespace QuantBox
{
    public class QuantBoxCtpse : XProvider, IInstrumentProvider
    {
#if !INC_API
        static QuantBoxCtpse()
        {
            AssemblyResolver.AddPath(Path.Combine(Path.GetDirectoryName(Installation.ConfigDir.FullName), "XAPI\\x64\\CTPSE\\"));
        }
#endif
        private const string CtpServers = "ctpse_servers";
        private const string CtpSessions = "ctpse_sessions";
        private const string CtpConnections = "ctpse_connections";
        private const string CtpUsers = "ctpse_users";
        private const string ProviderName = "QuantBoxCtpse";

        private static void MergeServers(XProviderSettings settings, JToken token)
        {
            var current = token.First;
            while (current != null) {
                var server = ServerInfo.Load(current);
                settings.Servers.Add(server);
                current = current.Next;
            }
        }

        private static void MergeServers(XProviderSettings settings)
        {
            //settings.Servers.Clear();
            //if (ProviderGlobals.Public.TryGet(CtpServers, out var value)) {
            //    MergeServers(settings, JToken.Parse(value));
            //}
            //if (ProviderGlobals.Private.TryGet(CtpServers, out value)) {
            //    MergeServers(settings, JToken.Parse(value));
            //}
        }

        private static void MergeUsers(XProviderSettings settings)
        {
            //if (!ProviderGlobals.Private.TryGet(CtpUsers, out var value))
            //    return;

            //var current = JToken.Parse(value).First;
            //while (current != null) {
            //    var user = UserInfo.Load(current);
            //    var exists = settings.Users.Exists(n => n.UserId == user.UserId);
            //    if (!exists) {
            //        settings.Users.Insert(0, user);
            //    }
            //    current = current.Next;
            //}
        }

        private static XProviderSettings MergeSettings(XProviderSettings settings)
        {
            //if (ProviderGlobals.AccountInfo != null) {
            //    MergeServers(settings);
            //    MergeUsers(settings);
            //}
            return settings;
        }

        private static bool IsThanfVersion()
        {
            //foreach (var asm in AppDomain.CurrentDomain.GetAssemblies()) {
            //    var name = asm.GetName();
            //    if (name.Name == "QuantBox.Shared" && name.GetPublicKey().Length > 0) {
            //        return true;
            //    }
            //}
            return false;
        }

        protected override XProviderSettings LoadSettings()
        {
            var defaultSettings = new XProviderSettings {
                Id = QuantBoxConst.PIdCtp,
                Name = ProviderName,
                Url = "www.quntbox.cn",
                Description = "QuantBox Ctpse 插件",
                UserProductInfo = "OpenQuant",
                Connections = new List<ConnectionInfo>(),
                Users = new List<UserInfo>(),
                Servers = new List<ServerInfo>(),
            };

            var settings = XProviderSettings.Load(QBHelper.GetConfigPath(base.GetSettingsFileName()));
            if (settings == null) {
                settings = defaultSettings;
            }
            else {
                settings.Id = defaultSettings.Id;
                settings.Url = defaultSettings.Url;
                settings.Description = defaultSettings.Description;
                settings.Name = ProviderName;
            }
            return IsThanfVersion() ? MergeSettings(settings) : settings;
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

#if INC_API
        protected override XTradingApi CreateXApi(ConnectionInfo info)
        {
            if ((info.Type & ApiType.MarketData) == ApiType.MarketData) {
                return new XTradingApi(new CtpQuote());
            }
            else if ((info.Type & ApiType.Trade) == ApiType.Trade) {
                return new XTradingApi(new CtpTrader());
            }
            return base.CreateXApi(info);
        }
#endif

        public QuantBoxCtpse(Framework framework)
            : base(framework)
        {
        }
    }
}