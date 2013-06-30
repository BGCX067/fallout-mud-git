namespace Mud.Core.Session
{
    public abstract class SessionState
    {
        public virtual string Prompt
        {
            get
            {
                return "> ";
            }
        }

        public abstract void ProcessInput(UserSession session, string input);

        public abstract void Init(UserSession session);
    }
}
