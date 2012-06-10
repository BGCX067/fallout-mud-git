using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mud.Domain.Session
{
    public static class SessionManager
    {
        private static readonly List<Session> _sessions = new List<Session>();

        private static readonly object lockVar = new object();

        public static void OnSessionConnected(Session newSession)
        {
            _sessions.Add(newSession);
            newSession.OnSessionTerminate += new Delegates.SessionTerminatedEventHandler(newSession_OnSessionTerminate);
        }

        private static void newSession_OnSessionTerminate(object sender, EventArgs e)
        {
            lock (lockVar)
            {
                _sessions.Remove(sender as Session);
            }
        }


    }
}
