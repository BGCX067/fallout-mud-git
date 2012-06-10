using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading.Tasks;
using Mud.Domain.Abstraction;
using Mud.Domain.Delegates;
using Mud.Domain.Exceptions;
using Mud.Domain.EventData;
using Mud.Domain.Session;

namespace Mud.Domain.Connection
{
    public class ConnectionManager
    {
        /// <summary>
        /// Synch object
        /// </summary>
        private static readonly object lockVar = new object();

        private int _port;

        private bool _started;

        private Socket _serverSocket;

        private List<IConnection> _connections = new List<IConnection>();

        public event UserConnectedEventHandler UserConnected;
        public event UserDisconnectedEventHandler UserDisconnected;

        public ConnectionManager()
        {
            _port = 4000;
        }
        public ConnectionManager(int port)
        {
            _port = port;
        }

        public void Start()
        {
            if (_started)
                return;
            _started = true;
            try
            {
                _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint localIP = new IPEndPoint(IPAddress.Any, _port);
                _serverSocket.Bind(localIP);
                _serverSocket.Listen(4);
                _serverSocket.BeginAccept(new AsyncCallback(this.OnClientConnect), null);
            }
            catch (SocketException se)
            {
                if (se.ErrorCode == 10048)
                {
                    string format = "Error number {0}: {1}. Port number {2} is already in use.";
                    string message = string.Format(format, se.ErrorCode, se.Message, _port);
                    throw new PortInUseException(message);
                }
                throw;
            }
        }

        private void OnClientConnect(IAsyncResult asyncResult)
        {
            try
            {
                Socket socket = _serverSocket.EndAccept(asyncResult);
                Connection conn = new Connection(socket, this);
                conn.UserDisconnected += new UserDisconnectedEventHandler(EventHandlerClientDisconnected);
                conn.StartListen();
                lock (lockVar)
                {
                    _connections.Add(conn);
                }
                if (this.UserConnected != null)
                {
                    this.UserConnected(this, new ConnectionArgs(conn));
                }
                SessionManager.OnSessionConnected(new Session.Session(conn));

                _serverSocket.BeginAccept(new AsyncCallback(this.OnClientConnect), null);
            }
            catch (ObjectDisposedException)
            {
                // This exception was preventing the console from closing when the
                // shutdown command was issued.
            }
        }

        private void EventHandlerClientDisconnected(object sender, ConnectionArgs args)
        {
            lock (lockVar)
            {
                _connections.Remove(args.Connection);
            }

            if (this.UserDisconnected != null)
            {
                this.UserDisconnected(this, args);
            }
        }

        /// <summary>Close all connected sockets.</summary>
        public void Stop()
        {
            if (_serverSocket != null)
            {
                _serverSocket.Close();
            }

            IList<IConnection> tempConnections = new List<IConnection>(_connections);
            foreach (IConnection conn in tempConnections)
            {
                conn.Send("Serwer został wyłączony. Połączenie przerwane...");
                conn.Disconnect();
            }

        }
    }
}
