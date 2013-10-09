namespace Mud.Server.Console
{
    using System;
    using Mud.Core;

    public class Program
    {
        private static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();
            var server = new Server();
            server.Run();
            string input;
            while ((input = Console.ReadLine()) != "exit")
            {
                server.Broadcast("Admin says: " + input + Environment.NewLine);
            }

            server.Stop();
        }
    }
}
