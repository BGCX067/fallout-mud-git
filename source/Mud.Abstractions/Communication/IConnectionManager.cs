namespace Mud.Abstractions.Communication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IConnectionManager
    {
        event Action<IConnection> UserConnected;

        event Action<IConnection> UserDisconnected;

        void Start(int port);

        void Stop();

        void Broadcast(string message);
    }
}
