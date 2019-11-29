using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Skyline;

namespace QuantBox
{
    [DataContract]
    public class XProviderSettings
    {
        [DataMember]
        public byte Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public string UserProductInfo { get; set; }

        public List<ServerInfo> Servers { get; set; }

        public List<UserInfo> Users { get; set; }

        public List<ConnectionInfo> Connections { get; set; }

        public List<TimeRange> SessionTimes { get; set; }

        private static void SaveItems<T>(T obj, string path, string name)
        {
            var file = Path.Combine(Path.GetDirectoryName(path), $"{Path.GetFileNameWithoutExtension(path)}.{name}.json");
            File.WriteAllText(file, JsonConvert.SerializeObject(obj, Formatting.Indented));
        }

        public void Save(string path)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(this, Formatting.Indented));
            SaveItems(Users, path, nameof(Users));
            SaveItems(Servers, path, nameof(Servers));
            SaveItems(Connections, path, nameof(Connections));
            SaveItems(SessionTimes, path, nameof(SessionTimes));
        }

        private static List<T> LoadItems<T>(string path, string name)
        {
            var file = Path.Combine(Path.GetDirectoryName(path), $"{Path.GetFileNameWithoutExtension(path)}.{name}.json");
            if (File.Exists(file)) {
                return JsonConvert.DeserializeObject<List<T>>(QBHelper.ReadOnlyAllText(file));
            }
            return new List<T>();
        }

        public static XProviderSettings Load(string path)
        {
            if (File.Exists(path)) {
                var settings = JsonConvert.DeserializeObject<XProviderSettings>(QBHelper.ReadOnlyAllText(path));
                settings.Users = LoadItems<UserInfo>(path, nameof(Users));
                settings.Servers = LoadItems<ServerInfo>(path, nameof(Servers));
                settings.Connections = LoadItems<ConnectionInfo>(path, nameof(Connections));
                settings.SessionTimes = LoadItems<TimeRange>(path, nameof(SessionTimes));
                return settings;
            }
            return null;
        }
    }
}
