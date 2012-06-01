using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mud.Domain.Abstraction;
using Mud.Domain.Delegates;
using Mud.Domain.EventData;
using Mud.Domain.Session.Context;

namespace Mud.Domain.Session
{
    public class Session : IController
    {
        private IConnection _connection;
        private SessionContext _context;


        public Session(IConnection con)
        {
            _connection = con;
            _connection.UserCommand += new UserCommandEventHandler(ConnectionUserCommand);
            _context = new StartContext(this);
        }

        private void ConnectionUserCommand(object sender, CommandRecivedArgs args)
        {
            _context.ProcessCommand(args.Command);  
        }


        public event ActionRecivedEventHandler ActionRecived;


        public void SendMessage(string message)
        {
            this.SendMessage(message, false);
        }

        public void SendMessage(string message,bool isPrompt)
        {
            _connection.Send(message);
            if (!isPrompt)
                _connection.Send(System.Environment.NewLine + GetPrompt());
        }


        public void OnActionRecived()
        {
            if (ActionRecived != null)
            {
                ActionRecived(this, new EventArgs());
            }
        }


        private string GetPrompt()
        {
            return "> ";
        }
    }
}
