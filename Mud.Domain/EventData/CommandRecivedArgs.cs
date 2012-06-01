using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mud.Domain.Abstraction;

namespace Mud.Domain.EventData
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
