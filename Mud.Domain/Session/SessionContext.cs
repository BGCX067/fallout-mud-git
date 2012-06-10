using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mud.Domain.Session
{
    public abstract class SessionContext
    {
        protected Session _session;

        public SessionContext(Session session)
        {
            _session = session;
        }

        public abstract void ProcessCommand(string command);

        public abstract string GetPrompt();

        public abstract void Init();
    }
}
