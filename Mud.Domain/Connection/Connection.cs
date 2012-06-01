using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Collections;
using System.Threading;
using System.Diagnostics;
using System.Net;
using Mud.Domain.Abstraction;
using Mud.Domain.Command;
using Mud.Domain.Delegates;
using Mud.Domain.EventData;

namespace Mud.Domain.Connection
{
    public class Connection :IConnection
    {
        private Socket _clientSocket;

        private InputParser _parser;

        private ConnectionManager _parent;

        public event UserDisconnectedEventHandler UserDisconnected;

        public event UserCommandEventHandler UserCommand;

        public IPAddress Ip { get; private set; }

        public string LastInputTerminator { get; set; }
        
        public string LastInput { get; set; }

        public StringBuilder CommandBuffer { get; private set; }

        /// <summary>
        /// Buffer
        /// </summary>
        private byte[] _buffer;

        private bool _listening;

        private bool _connected;

        public Connection(Socket socket, ConnectionManager server)
        {
            _clientSocket = socket;
            _parent = server;
            this.CommandBuffer = new StringBuilder();
            var remoteEndPoint = (IPEndPoint)_clientSocket.RemoteEndPoint;
            _connected = true;
            this.Ip = remoteEndPoint.Address;
            _buffer = new byte[1];
            _parser = new InputParser();
            _parser.UserCommandReceived += new UserCommandEventHandler(ParserUserCommandReceived);
        }

        private void ParserUserCommandReceived(object sender, CommandRecivedArgs args)
        {
            if (UserCommand != null)
            {
                UserCommand(this, args);
            }
        }

        public void Disconnect()
        {
            OnConnectionDisconnect();
        }

        public void Send(string data)
        {
            this.Send(Encoding.GetEncoding(437).GetBytes(data));
        }

        public void Send(byte[] data)
        {
            try
            {
                _clientSocket.BeginSend(data, 0, data.Length, 0, new AsyncCallback(this.OnSendComplete), null);
            }
            catch (SocketException)
            {
                this.OnConnectionDisconnect();
            }
            catch (ObjectDisposedException)
            {
                this.OnConnectionDisconnect();
            }
        }

        public void StartListen()
        {
            if (!_listening)
            {
                this.ListenForData();
                _listening = true;
            }
        }

        private void OnSendComplete(IAsyncResult asyncResult)
        {
            try
            {
                _clientSocket.EndSend(asyncResult);
                //TODO: fire event
            }
            catch
            {
                this.OnConnectionDisconnect();
            }
        }

        private void ListenForData()
        {
            try
            {
                _clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None,
                        new AsyncCallback(this.OnDataReceived), null);
            }
            catch (SocketException)
            {
                this.OnConnectionDisconnect();
            }
        }

        private void OnDataReceived(IAsyncResult asyncResult)
        {
            try
            {
                int iRx;

                if (_clientSocket.Connected)
                {
                    iRx = _clientSocket.EndReceive(asyncResult);

                    if (iRx == 0)
                    {
                        this.OnConnectionDisconnect();
                    }
                    else
                    {
                        if (_buffer.Length > 0)
                        {
                            _parser.OnDataReceived(this, _buffer);
                        }
                        this.ListenForData();
                    }
                }
            }
            catch (ObjectDisposedException)
            {
                this.OnConnectionDisconnect();
            }
            catch (ThreadAbortException)
            {
                this.OnConnectionDisconnect();
            }
            catch (Exception)
            {
                //TODO: log exception
                this.OnConnectionDisconnect();
            }
        }

        private void OnConnectionDisconnect()
        {
            if (_clientSocket.Connected)
            {
                _clientSocket.Shutdown(SocketShutdown.Both);
                _clientSocket.Close();
            }
            if (_connected)
            {
                _connected = false;
                if (this.UserDisconnected != null)
                {
                    this.UserDisconnected(this, new ConnectionArgs(this));
                }
            }
        }

    }
}
