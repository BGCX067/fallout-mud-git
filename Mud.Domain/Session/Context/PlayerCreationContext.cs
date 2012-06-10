using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mud.Domain.Session.Context
{
    public class PlayerCreationContext:SessionContext
    {
        private string _playerName;

        public PlayerCreationContext(Session session, string playerName)
            : base(session)
        {
            _playerName = playerName;
            _session.SendMessage("Nowa postac:");
        }

        public override void ProcessCommand(string command)
        {
            
        }
    }
}
