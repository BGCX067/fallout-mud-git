using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mud.Net.Abstraction;

namespace Mud.Net.EventData
{
    public class CommandRecivedArgs: ConnectionArgs
    {
        public CommandRecivedArgs(IConnection connection, string command)
            : base(connection)
        {
            this.Command = command;
        }
        public string Command { get; private set; }
    }
}
