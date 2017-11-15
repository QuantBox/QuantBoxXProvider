using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantBox.Sfit.Api
{
    public delegate void CtpEventHandler4<T>(object sender, T response, CtpRspInfo rspInfo, int requestID, bool isLast);
    public delegate void CtpEventHandler3(object sender, CtpRspInfo rspInfo, int requestID, bool isLast);
    public delegate void CtpEventHandler2<T>(object sender, T response, CtpRspInfo rspInfo);
    public delegate void CtpEventHandler<T>(object sender, T response);
    public delegate void CtpEventHandler(object sender);
}
