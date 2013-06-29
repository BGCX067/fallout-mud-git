namespace Mud.Server.Console
{
    using System;
    using Mud.Abstractions.Communication;
    using Mud.Core;

    public class Program
    {
        private static void Main(string[] args)
        {
            var server = ApplicationServices.ConnectionManager;
            server.UserConnected += ServerUserConnected;
            server.Start(4000);
            string input;
            while ((input = Console.ReadLine()) != "exit")
            {
                server.Broadcast("Admin mowi: " + input + "\n\r");
            }

            server.Stop();
        }

        private static void ServerUserConnected(IConnection connection)
        {
            Console.WriteLine(connection.Ip.ToString());
        }
    }
}
