namespace QuantBox.XApi
{
    public class LogField
    {
        public LogLevel Level { get; private set; }
        public string Message { get; private set; }

        internal LogField(InternalLogField field)
        {
            Level = field.Level;
            Message = field.Text();
        }

        public LogField(LogLevel level, string message)
        {
            Level = level;
            Message = message;
        }
    }
}