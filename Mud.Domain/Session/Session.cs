using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mud.Domain.Abstraction;
using Mud.Domain.Delegates;
using Mud.Domain.EventData;
using Mud.Domain.Session.Context;
using Mud.Domain.Output;
using StructureMap;

namespace Mud.Domain.Session
{
    public class Session : IController
    {
        private IConnection _connection;
        private SessionContext _context;
        private IOutputParser _outputParser;

        public event SessionTerminatedEventHandler OnSessionTerminate;

        public Session(IConnection con)
        {
            _connection = con;
            _connection.UserCommand += new UserCommandEventHandler(ConnectionUserCommand);
            _outputParser = ObjectFactory.GetInstance<IOutputParser>();
            this.SetContext(new StartContext(this));
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

        public void SendMessage(string message, bool isPrompt)
        {
            Flush(message);
            if (!isPrompt)
                SendPrompt();
        }

        public void SendPrompt()
        {
            Flush(System.Environment.NewLine + GetPrompt());
        }

        private void OnActionRecived()
        {
            if (ActionRecived != null)
            {
                ActionRecived(this, new EventArgs());
            }
        }

        public void SetContext(SessionContext cont)
        {
            _context = null;
            _context = cont;
            _context.Init();
        }

        public void Terminate()
        {
            this._connection.Disconnect();
            if (OnSessionTerminate != null)
            {
                OnSessionTerminate(this, new EventArgs());
            }
        }

        private string GetPrompt()
        {
            return _context.GetPrompt();
        }

        private void Flush(string message)
        {
            _connection.Send(_outputParser.Parse("&w" + message));
        }
    }
}