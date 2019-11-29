using System;
using System.IO;
using System.Reflection;
using Skyline;
using SmartQuant;

namespace QuantBox
{
    public static class TimeSeriesExtensions
    {
        public static void Save(this TimeSeries s, string filename)
        {
            using (var fs = new FileStream(filename, FileMode.CreateNew, FileAccess.Write)) {
                Save(s, fs);
            }
        }

        public static void Save(this TimeSeries s, Stream stream)
        {
            using (var writer = new BinaryWriter(stream)) {
                for (var i = 0; i < s.Count; i++) {
                    var item = s.GetItem(i);
                    writer.Write(item.DateTime.Ticks);
                    writer.Write(item.Value);
                }
            }
        }

        public static void Load(this TimeSeries s, string filename)
        {
            using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read)) {
                Load(s, fs);
            }
        }

        public static void Load(this TimeSeries s, Stream stream)
        {
            using (var reader = new BinaryReader(stream)) {
                while (reader.PeekChar() != -1) {
                    s.Add(new DateTime(reader.ReadInt64()), reader.ReadDouble());
                }
            }
        }

    }
}