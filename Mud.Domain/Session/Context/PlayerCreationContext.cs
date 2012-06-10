using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mud.Domain.Session.Context
{
    public class PlayerCreationContext : SessionContext
    {
        private string _playerName;

        public PlayerCreationContext(Session session, string playerName)
            : base(session)
        {
            _playerName = playerName;
            
        }

        public override void ProcessCommand(string command)
        {

        }

        public override string GetPrompt()
        {
            return ">";
        }

        public override void Init()
        {
            _session.SendMessage(StaticMessages.newPlayerStart);
        }
    }
}
