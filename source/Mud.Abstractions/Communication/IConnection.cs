namespace Mud.Abstractions.Communication
{
    using System;
    using System.Net;

    public interface IConnection
    {
        event Action<IConnection, string> MessageReceived;

        event Action<IConnection> Disconnected;

        IPAddress Ip { get; }

        void Disconnect();

        void Send(string message);
    }
}
