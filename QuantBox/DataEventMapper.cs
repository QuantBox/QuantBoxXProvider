using System;
using System.IO;
using LiteDB;
using SmartQuant;

namespace QuantBox
{
    public enum ObjectTableOwner
    {
        Order,Stop
    }

    public delegate void ObjectTableReader(ObjectTableOwner owner, ObjectTable table, BinaryReader writer);
    public delegate void ObjectTableWriter(ObjectTableOwner owner, ObjectTable table, BinaryWriter writer);

    internal class DataEventMapper : BsonMapper
    {
        public DataEventMapper(ObjectTableWriter fieldsWriter, ObjectTableReader fieldsReader)
        {
            ReportSerializer = new ExecutionReportSerializer();
            CommandSerializer = new ExecutionCommandSerializer(fieldsWriter, fieldsReader);
            StopSerializer = new StopSerializer(fieldsWriter, fieldsReader);
            RegisterType(CommandSerializer.ToBson, CommandSerializer.ToCommand);
            RegisterType(ReportSerializer.ToBson, ReportSerializer.ToReport);
            RegisterType(StopSerializer.ToBson, StopSerializer.ToStop);
            RegisterType(PortfolioSerializer.ToBson, PortfolioSerializer.ToPortfolio);
        }

        public readonly StopSerializer StopSerializer;
        public readonly ExecutionReportSerializer ReportSerializer;
        public readonly ExecutionCommandSerializer CommandSerializer;
    }
}