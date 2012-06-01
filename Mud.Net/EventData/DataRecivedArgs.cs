using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mud.Net.Abstraction;

namespace Mud.Net.EventData
{
    public class DataRecivedArgs : ConnectionArgs
    {
        public DataRecivedArgs(IConnection connection, byte[] data)
            : base(connection)
        {
            Data = data;
        }
        public byte[] Data { get; private set; }
    }
}
