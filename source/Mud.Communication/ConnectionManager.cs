namespace Mud.Communication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net.Sockets;
    using System.Net;

    public class ConnectionManager
    {
        /// <summary>
        /// Synch object
        /// </summary>
        private readonly object lockVar = new object();

        private readonly int port;

        private bool started;

        private Socket serverSocket;

        private readonly List<TcpConnection> connections = new List<TcpConnection>();

        public event Action<ConnectionManager, TcpConnection> UserConnected;
        public event Action<ConnectionManager, TcpConnection> UserDisconnected;

        public ConnectionManager()
        {
            this.port = 4000;
        }
        public ConnectionManager(int port)
        {
            this.port = port;
        }

        public void Start()
        {
            if (this.started)
                return;

            this.started = true;

            try
            {
                this.serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                var localIp = new IPEndPoint(IPAddress.Any, this.port);
                this.serverSocket.Bind(localIp);
                this.serverSocket.Listen(4);
                this.serverSocket.BeginAccept(this.OnClientConnect, null);
            }
            catch (SocketException se)
            {
                if (se.ErrorCode == 10048)
                {
                    string message = string.Format(PortInUseException.MessageFormat, se.ErrorCode, se.Message, this.port);
                    throw new PortInUseException(message);
                }

                throw;
            }
        }

        public void Broadcast(string message)
        {
            var tempConnections = new List<TcpConnection>(this.connections);
            foreach (TcpConnection conn in tempConnections)
            {
                conn.Send(message);
            }
        }

        private void OnClientConnect(IAsyncResult asyncResult)
        {
            try
            {
                Socket socket = this.serverSocket.EndAccept(asyncResult);
                var conn = new TcpConnection(socket);
                conn.Disconnected += this.OnClientDisconnected;
                conn.MessageReceived += MessageReceived;
                conn.StartListen();

                lock (lockVar)
                {
                    this.connections.Add(conn);
                }

                if (this.UserConnected != null)
                {
                    this.UserConnected(this, conn);
                }
                //SessionManager.OnSessionConnected(new Session.Session(conn));

                this.serverSocket.BeginAccept(this.OnClientConnect, null);
            }
            catch (ObjectDisposedException)
            {
                // This exception was preventing the console from closing when the
                // shutdown command was issued.
            }
        }

        private void MessageReceived(TcpConnection arg1, string arg2)
        {
            throw new NotImplementedException();
        }

        private void OnClientDisconnected(TcpConnection sender)
        {
            lock (lockVar)
            {
                this.connections.Remove(sender);
            }

            if (this.UserDisconnected != null)
            {
                this.UserDisconnected(this, sender);
            }
        }

        public void Stop()
        {
            if (this.serverSocket != null)
            {
                this.serverSocket.Close();
            }

            var tempConnections = new List<TcpConnection>(this.connections);
            foreach (TcpConnection conn in tempConnections)
            {
                conn.Disconnect();
            }

        }
    }
}
