namespace QuantBox.Sfit.Api
{
    public abstract class CtpSpi : ICtpResponseHandler
    {
        public abstract void SetResponseHandler(byte type, CtpResponseAction handler);
        public abstract void ProcessResponse(ref CtpResponse rsp);
    }
}
