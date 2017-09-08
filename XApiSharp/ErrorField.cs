namespace QuantBox.XApi
{
    public class ErrorField
    {
        /// <summary>
        /// 错误代码
        /// </summary>
        public readonly int XErrorId;
        /// <summary>
        /// 错误代码
        /// </summary>
        public readonly int RawErrorId;
        /// <summary>
        /// 错误信息
        /// </summary>
        public readonly string Text;
        /// <summary>
        /// 信息来源
        /// </summary>
        public readonly string Source;

        public ErrorField(int errorId, int rawErrorId, string text, string source)
        {
            XErrorId = errorId;
            RawErrorId = rawErrorId;
            Text = text;
            Source = source;
        }

        internal ErrorField(InternalErrorField field)
        {
            XErrorId = field.XErrorID;
            RawErrorId = field.RawErrorID;
            Text = field.Text();
            Source = field.Source;
        }
    }
}