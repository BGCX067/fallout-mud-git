using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mud.Domain.Session.Context
{
    public class StartContext : SessionContext
    {
        public StartContext(Session session)
            : base(session)
        {
            _session.SendMessage("Podaj nazwe postaci, lub wpisz 'nowy':", true);
        }

        public override void ProcessCommand(string command)
        {
            switch (command.ToLower())
            {
                case "nowy":
                    _session.SendMessage("No way");
                    break;
                default:
                    _session.SendMessage("Niema takiego");
                    break;
            }
        }
    }
}
