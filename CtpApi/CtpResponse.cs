using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantBox.Sfit.Api
{
    public struct CtpResponse
    {
        public const byte True = 1;
        public const byte False = 0;

        public CtpResponse(byte[] clientID, byte id)
        {
            ClientID = clientID;
            TypeId = id;
            Item1 = new CtpAny(0);
            Item2 = null;
            RequestID = 0;
            IsLast = True;
            UserID = "";
        }

        public CtpResponse(byte[] clientID, byte id, object objValue, CtpRspInfo rspInfo = null)
            : this(clientID, id)
        {
            Item1 = new CtpAny(objValue);
            Item2 = rspInfo;
            UserID = "";
        }

        public CtpResponse(byte[] clientID, byte id, int intValue, CtpRspInfo rspInfo = null)
            : this(clientID, id)
        {
            Item1 = new CtpAny(intValue);
            Item2 = rspInfo;
        }

        public CtpResponse(string userID, byte id, object objValue, CtpRspInfo rspInfo = null)
            : this(null, id)
        {
            Item1 = new CtpAny(objValue);
            Item2 = rspInfo;
            UserID = userID;
        }

        public CtpResponse(string userID, byte id, int intValue, CtpRspInfo rspInfo = null)
            : this(null, id)
        {
            Item1 = new CtpAny(intValue);
            Item2 = rspInfo;
            UserID = userID;
        }

        public string UserID;
        public byte[] ClientID;
        public byte TypeId;
        public CtpAny Item1;
        public CtpRspInfo Item2;
        public int RequestID;
        public byte IsLast;
    }
}
