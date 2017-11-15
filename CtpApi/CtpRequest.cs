using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantBox.Sfit.Api
{
    public struct CtpRequest
    {
        public readonly byte[] ClientID;
        public byte TypeId;
        public CtpAny Args;
        public int RequestID;

        public CtpRequest(byte[] clientID, byte id)
        {
            ClientID = clientID;
            TypeId = id;
            RequestID = 0;
            Args = new CtpAny(0);
        }

        public CtpRequest(byte id, int data, int requestID)
            : this(null, id)
        {
            Args = new CtpAny(data);
            RequestID = requestID;
        }

        public CtpRequest(byte id, object data, int requestID)
            : this(null, id)
        {
            Args = new CtpAny(data);
            RequestID = requestID;
        }

        public CtpRequest(byte[] clientID, byte id, int data)
            : this(clientID, id)
        {
            Args = new CtpAny(data);
        }

        public CtpRequest(byte[] clientID, byte id, object data)
            : this(clientID, id)
        {
            Args = new CtpAny(data);
        }
    }
}
