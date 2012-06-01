using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mud.Domain.EventData;

namespace Mud.Domain.Delegates
{
    public delegate void UserConnectedEventHandler(object sender, ConnectionArgs args);

    public delegate void UserDisconnectedEventHandler(object sender, ConnectionArgs args);

    public delegate void UserDataRecivedEventHandler(object sender, DataRecivedArgs args);

    public delegate void UserCommandEventHandler(object sender, CommandRecivedArgs args);

}
