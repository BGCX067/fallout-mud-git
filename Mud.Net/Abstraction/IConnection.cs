using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Mud.Net.Delegates;

namespace Mud.Net.Abstraction
{
    public interface IConnection
    {
        void Send(byte[] data);
        void Send(string message);
        void Disconnect();

        string LastInput { get; set; }

        IPAddress Ip { get; }

        /// <summary>Gets or sets the last string used to end input from the client.</summary>
        string LastInputTerminator { get; set; }

        /// <summary>Recived data not yet parsed as an action</summary>
        StringBuilder CommandBuffer { get; }

        event UserCommandEventHandler UserCommand;
    }
}
