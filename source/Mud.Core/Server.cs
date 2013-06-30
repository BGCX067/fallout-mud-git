namespace Mud.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Mud.Abstractions.Communication;
    using Mud.Communication.Tcp;
    using Mud.Core.Session;

    public class Server
    {
        private readonly IConnectionManager connectionManager = new TcpConnectionManager();

        private readonly SessionManager sessionManager = new SessionManager();

        public void Run()
        {
            this.connectionManager.Start(4000);
            this.connectionManager.UserConnected += this.OnUserConnected;
            this.connectionManager.UserDisconnected += this.OnUserDisconnected;
        }

        public void Stop()
        {
            // TODO: implement
            throw new NotImplementedException();
        }

        public void Broadcast(string message)
        {
            this.connectionManager.Broadcast(message);
        }

        private void OnUserConnected(IConnection connection)
        {
            this.sessionManager.OnSessionConnected(connection);
            connection.MessageReceived += this.MessageReceived;
        }

        private void OnUserDisconnected(IConnection connection)
        {
            this.sessionManager.OnSessionDisconnected(connection.Id);
            connection.MessageReceived -= this.MessageReceived;
        }

        private void MessageReceived(IConnection connection, string message)
        {
            this.sessionManager.OnInputReceived(connection.Id, message);
        }
    }
}
