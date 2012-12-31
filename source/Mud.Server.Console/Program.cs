using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mud.Communication;

namespace Mud.Server.Console
{
    class Program
    {
        private static void Main(string[] args)
        {
            var server = new ConnectionManager(4000);
            server.Start();
            string input;
            while ((input = System.Console.ReadLine()) != "exit")
            {
                server.Broadcast(input);
            }
            server.Stop();
        }
    }
}
