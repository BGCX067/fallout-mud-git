using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mud.Domain.Delegates;
using Mud.Domain.Abstraction;
using Mud.Domain.EventData;

namespace Mud.Domain.Command
{
    public class InputParser
    {
        private static string newLineMarker = "\r";

        public event UserCommandEventHandler UserCommandReceived;

        public void OnDataReceived(IConnection sender, byte[] data)
        {
            string input = Encoding.ASCII.GetString(data);
            sender.CommandBuffer.Append(input);
            input = sender.CommandBuffer.ToString();
            input = StripDodgyTerminator(sender, input);
            if (input.Length == 0)
            {
                return;
            }
            SetLastTerminator(sender, input);
            input = input.Replace("\n", newLineMarker);
            input = input.Replace("\r\r", newLineMarker);

            if (input.Contains(newLineMarker))
            {
                if (input == newLineMarker)
                {
                    this.RaiseInputReceived(new ConnectionArgs(sender), string.Empty);
                }
                bool fullCommand = input.EndsWith(newLineMarker);

                string[] commands = input.Split(new string[] { newLineMarker }, StringSplitOptions.RemoveEmptyEntries);
                string action = string.Empty;
                for (int i = 0; i < commands.Length; i++)
                {
                    action = commands[i].Trim();
                    if ((i < commands.Length - 1) || (i == commands.Length - 1 && fullCommand))
                    {
                        sender.LastInput = action;
                        this.RaiseInputReceived(new ConnectionArgs(sender), action);
                    }
                }
                sender.CommandBuffer.Clear();
                if (!fullCommand)
                {
                    sender.CommandBuffer.Append(action);
                }
            }
        }

        private static string StripDodgyTerminator(IConnection sender, string input)
        {
            if ((sender.LastInputTerminator == "\r") && input.StartsWith("\n"))
            {
                input = input.Replace("\n", string.Empty);
            }
            else if ((sender.LastInputTerminator == "\n") && input.StartsWith("\r"))
            {
                input = input.Replace("\r", string.Empty);
            }

            return input;
        }

        private static void SetLastTerminator(IConnection sender, string input)
        {
            if (input.Contains("\r") & input.Contains("\n"))
            {
                sender.LastInputTerminator = "\r\n";
            }
            else if (input.Contains("\r"))
            {
                sender.LastInputTerminator = "\r";
            }
            else if (input.Contains("\n"))
            {
                sender.LastInputTerminator = "\n";
            }
        }


        private void RaiseInputReceived(ConnectionArgs connectionArgs, string action)
        {
            if (this.UserCommandReceived != null)
            {
                this.UserCommandReceived(this, new CommandRecivedArgs(connectionArgs.Connection, action));
            }
        }



    }
}
