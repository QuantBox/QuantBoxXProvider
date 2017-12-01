/*
 * User: hetao
 * Date: 2014/5/26 星期一
 * Time: 9:10
 * 
 */
using System;
using System.Security;

namespace QuantBox.Sfit.Api
{
    public delegate int CtpRequestFunc(ref CtpRequest req);
    public interface ICtpRequestHandler
    {
        int ProcessRequest(ref CtpRequest req);
    }
}
