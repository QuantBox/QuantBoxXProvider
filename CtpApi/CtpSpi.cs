using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantBox.Sfit.Api
{
    public abstract class CtpSpi : ICtpResponseHandler
    {
        public abstract void SetResponseHandler(byte type, Action<CtpResponse> handler);
        public abstract void ProcessResponse(CtpResponse rsp);
    }
}
