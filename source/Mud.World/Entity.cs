namespace Mud.World
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Mud.Core;

    public abstract class Entity : MultiThreadObject
    {
        private readonly List<Behavior> behaviors = new List<Behavior>();

        public IEnumerable<Behavior> Behaviors
        {
            get
            {
                return this.behaviors;
            }
        }
    }
}
