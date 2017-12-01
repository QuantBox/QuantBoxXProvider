/*
 * User: hetao
 * Date: 2014/5/26 星期一
 * Time: 9:14
 * 
 */
using System;

namespace QuantBox.Sfit.Api
{
    public delegate void CtpResponseAction(ref CtpResponse rsp);
    /// <summary>
    /// Description of ICtpResponseHandler.
    /// </summary>
    public interface ICtpResponseHandler
    {
        void SetResponseHandler(byte type, CtpResponseAction handler);
        void ProcessResponse(ref CtpResponse rsp);
    }
}
