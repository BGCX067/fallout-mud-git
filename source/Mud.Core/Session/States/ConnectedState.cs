namespace Mud.Core.Session.States
{
    using System;

    public class ConnectedState : SessionState
    {
        public override void Init(UserSession session)
        {
            session.WriteToUser("Please enter your character name or type NEW:");
        }

        public override void ProcessInput(UserSession session, string input)
        {
            throw new Exception("Pindol test");

            if (input.ToLower() == "new")
            {
                session.WriteToUser("Functionality not implemented..." + Environment.NewLine, false);
                session.WriteToUser("Disconnecting..." + Environment.NewLine, false);
                session.Connection.Disconnect();
            }

            session.WriteToUser(session.Connection.Ip.ToString());
        }
    }
}
