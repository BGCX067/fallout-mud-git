namespace Mud.Core.Session
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Mud.Abstractions.Communication;
    using Mud.Core.Session.States;

    public class UserSession
    {
        private readonly IConnection connection;

        private bool userAtPrompt;

        private SessionState currentState;

        public UserSession(IConnection connection)
        {
            this.connection = connection;

            this.SetState(new ConnectedState());
        }

        public IConnection Connection
        {
            get
            {
                return this.connection;
            }
        }

        public void ProcessInput(string input)
        {
            if (this.currentState != null)
            {
                this.userAtPrompt = false;
                this.currentState.ProcessInput(this, input);
            }
        }

        public void WriteToUser(string message)
        {
            this.WriteToUser(message, true);
        }

        public void WriteToUser(string message, bool withPrompt)
        {
            if (this.userAtPrompt)
            {
                message = Environment.NewLine + message;
            }

            this.userAtPrompt = false;
            if (withPrompt)
            {
                string prompt = this.GetPrompt();

                if (!message.EndsWith(Environment.NewLine + prompt))
                {
                    message = message + Environment.NewLine + prompt;
                }

                this.userAtPrompt = true;
            }

            this.connection.Send(message);
        }

        public void SetState(SessionState newState)
        {
            this.currentState = newState;
            this.currentState.Init(this);
        }

        private string GetPrompt()
        {
            if (this.currentState != null)
            {
                return this.currentState.Prompt;
            }

            return string.Empty;
        }
    }
}
