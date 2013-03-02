namespace Mud.Server.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Mud.Communication;

    class Program
    {
        private static void Main(string[] args)
        {
            var server = new ConnectionManager(4000);
            server.UserConnected += ServerUserConnected;
            server.Start();
            string input;
            while ((input = System.Console.ReadLine()) != "exit")
            {
                server.Broadcast(input+"\n\r");
            }
            server.Stop();
        }

        static void ServerUserConnected(ConnectionManager arg1, TcpConnection arg2)
        {
            System.Console.WriteLine(arg2.Ip.ToString());
        }
    }
}
