using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mud.Domain.Connection;
using Mud.Domain.Delegates;
using Mud.Domain.EventData;

namespace Mud.ConsoleServer
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionManager server = new ConnectionManager();
            server.UserDisconnected += new UserDisconnectedEventHandler(_server_UserDisconnected);
            server.UserConnected += new UserConnectedEventHandler(_server_UserConnected);
            server.Start();
            string input;
            while ((input = Console.ReadLine()) != "quit")
            {

            }
        }

        static void _server_UserDisconnected(object sender, ConnectionArgs args)
        {
            Console.WriteLine("Rozłączenie : " + args.Connection.Ip.ToString());
        }

        static void _server_UserConnected(object sender, ConnectionArgs args)
        {
            Console.WriteLine("Połączenie : " + args.Connection.Ip.ToString());
        }

    }
}
