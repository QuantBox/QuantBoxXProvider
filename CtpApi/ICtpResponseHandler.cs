/*
 * User: hetao
 * Date: 2014/5/26 星期一
 * Time: 9:14
 * 
 */
using System;

namespace QuantBox.Sfit.Api
{
	/// <summary>
	/// Description of ICtpResponseHandler.
	/// </summary>
	public interface ICtpResponseHandler
	{
		void SetResponseHandler(byte type, Action<CtpResponse> handler);
		void ProcessResponse(CtpResponse rsp);
	}
}
