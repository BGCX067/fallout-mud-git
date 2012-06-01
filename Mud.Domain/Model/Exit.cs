using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mud.Domain.Enums;

namespace Mud.Domain.Model
{
    public class Exit
    {
        private Location _destination;
        public Direction Direction { get; private set; }

        public Exit(Location dest, Direction dir)
        {
            _destination = dest;
            this.Direction = dir;
        }
    }
}
