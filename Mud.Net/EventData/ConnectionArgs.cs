using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mud.Net.Abstraction;

namespace Mud.Net.EventData
{
    public class ConnectionArgs : EventArgs
    {
        public ConnectionArgs(IConnection connection)
        {
            this.Connection = connection;
        }
        public IConnection Connection { get; private set; }
    }
}
