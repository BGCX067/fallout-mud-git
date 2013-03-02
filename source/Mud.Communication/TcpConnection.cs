namespace Mud.Communication
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;

    public class TcpConnection
    {
        private readonly Socket socket;

        private bool connected;

        private readonly byte[] buffer;

        private readonly MessageBuffer messageBuffer;

        public event Action<TcpConnection, string> MessageReceived;

        public event Action<TcpConnection> Disconnected;

        public IPAddress Ip { get; private set; }

        public TcpConnection(Socket socket)
        {
            this.socket = socket;
            buffer = new byte[1];
            var remoteEndPoint = (IPEndPoint)socket.RemoteEndPoint;
            connected = true;
            this.Ip = remoteEndPoint.Address;
            this.messageBuffer = new MessageBuffer();
            this.messageBuffer.Message += this.OnMessage;
        }

        public void StartListen()
        {
            this.Listen();
        }

        public void Disconnect()
        {
            this.OnConnectionDisconnect();
        }

        public void Send(string message)
        {
            this.Send(Encoding.GetEncoding(437).GetBytes(message));
        }

        private void Send(byte[] data)
        {
            try
            {
                this.socket.BeginSend(data, 0, data.Length, 0, this.OnSendComplete, null);
            }
            catch 
            {
                this.OnConnectionDisconnect();
            }
        }

        private void Listen()
        {
            try
            {
                this.socket.BeginReceive(this.buffer, 0, this.buffer.Length, SocketFlags.None, this.OnDataReceived, null);
            }
            catch
            {
                this.OnConnectionDisconnect();
            }
        }

        private void OnMessage(string message)
        {
            if (this.MessageReceived != null)
            {
                this.MessageReceived(this, message);
            }
        }

        private void OnDataReceived(IAsyncResult asyncResult)
        {
            try
            {
                if (this.socket.Connected)
                {
                    int bytesCount = this.socket.EndReceive(asyncResult);

                    if (bytesCount == 0)
                    {
                        this.OnConnectionDisconnect();
                    }
                    else
                    {
                        if (this.buffer.Length > 0)
                        {
                            this.messageBuffer.Push(this.buffer);
                        }

                        this.Listen();
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

        private void OnSendComplete(IAsyncResult asyncResult)
        {
            try
            {
                this.socket.EndSend(asyncResult);
            }
            catch
            {
                this.OnConnectionDisconnect();
            }
        }

        private void OnConnectionDisconnect()
        {
            if (this.socket.Connected)
            {
                this.socket.Shutdown(SocketShutdown.Both);
                this.socket.Close();
            }
            if (this.connected)
            {
                this.connected = false;
                if (this.Disconnected != null)
                {
                    this.Disconnected(this);
                }
            }
        }
    }
}
