namespace Mud.World.Map
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Passage
    {
        public Passage(Location first, Location second)
        {
            this.FirstLocation = first;
            this.SecondLocation = second;
        }

        public Location FirstLocation { get; private set; }

        public Location SecondLocation { get; private set; }
    }
}
