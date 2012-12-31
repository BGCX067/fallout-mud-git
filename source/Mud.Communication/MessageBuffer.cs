namespace Mud.Communication
{
    using System;
    using System.Text;

    public class MessageBuffer
    {
        public const string NewLineMarker = "\r";

        private readonly StringBuilder sb;

        public event Action<string> Message;

        public MessageBuffer()
        {
            sb = new StringBuilder();
        }

        /// <summary>
        /// Only 1 element array should be passed
        /// </summary>
        /// <param name="data">Data (1 element byte array)</param>
        public void Push(byte[] data)
        {
            string input = Encoding.ASCII.GetString(data);
            input = input.Replace("\n", NewLineMarker);
            sb.Append(input);

            this.CheckMessage();
        }

        private void CheckMessage()
        {
            var buff = sb.ToString();
            if (buff.Contains(NewLineMarker))
            {
                this.OnMessage(buff.Replace(NewLineMarker, ""));
                sb.Clear();
            }
        }

        private void OnMessage(string message)
        {
            if (this.Message != null)
            {
                this.Message(message);
            }
        }
    }
}
