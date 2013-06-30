namespace Mud.Core.Session
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Mud.Abstractions.Communication;

    public class SessionManager
    {
        private readonly Dictionary<Guid, UserSession> sessions = new Dictionary<Guid, UserSession>();

        private readonly object lockVar = new object();
       
        public void OnInputReceived(Guid connectionId, string input)
        {
            UserSession session = null;
            lock (this.sessions)
            {
                if (this.sessions.ContainsKey(connectionId))
                {
                    session = this.sessions[connectionId];
                }
            }

            if (session != null)
            {
                session.ProcessInput(input);
            }
        }

        public void OnSessionConnected(IConnection connection)
        {
            var session = new UserSession(connection);
            lock (this.sessions)
            {
                this.sessions.Add(connection.Id, session);
            }
        }

        public void OnSessionDisconnected(Guid connectionId)
        {
            lock (this.sessions)
            {
                if (this.sessions.ContainsKey(connectionId))
                {
                    // TODO: inform game engine
                    this.sessions.Remove(connectionId);
                }
            }
        }
    }
}
