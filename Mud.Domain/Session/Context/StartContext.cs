using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mud.Domain.Data;

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
                    _session.SetContext(new PlayerCreationContext(_session, command));
                    break;
                default:
                    if (Repo.Player.ValidateUser(command))
                        _session.SendMessage("spoko");
                    else
                    {
                        _session.SendMessage("Postac o podanej nazwie nie istnieje. Rozlaczam...");
                        _session.Terminate();
                    }
                    break;
            }
        }
    }
}
