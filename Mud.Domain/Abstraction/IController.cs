using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mud.Domain.Delegates;

namespace Mud.Domain.Abstraction
{
    public interface IController
    {
        event ActionRecivedEventHandler ActionRecived;
        void SendMessage(string message);
    }
}
