using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mud.Domain.Session
{
    public static class SessionManager
    {
        private static readonly List<Session> _sessions = new List<Session>();

        public static void OnSessionConnected(Session newSession)
        {
            _sessions.Add(newSession);
           
        }

    }
}
