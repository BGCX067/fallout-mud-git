namespace Mud.World.Map
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Location
    {
        public IDictionary<Direction, Passage> Exits { get; private set; } 

        public string Title { get; private set; }

        public string Description { get; private set; }
    }
}
