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
        }



        public override void ProcessCommand(string command)
        {
            switch (command.ToLower())
            {
                case "nowy":
                    _session.SetContext(new PlayerCreationContext(_session, command));
                    break;
                default:
                    if (Repo.Player.ValidateUserName(command))
                        _session.SendMessage("spoko");
                    else
                    {
                        _session.SendMessage(StaticMessages.wrongPlayerName);
                        _session.Terminate();
                    }
                    break;
            }
        }

        public override string GetPrompt()
        {
            return "";
        }

        public override void Init()
        {
            _session.SendMessage(StaticMessages.splashScreen);
            _session.SendMessage(StaticMessages.choosePlayerPrompt, true);
        }
    }
}
