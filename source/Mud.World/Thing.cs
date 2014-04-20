namespace Mud.World
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Mud.Core;

    public abstract class Thing : MultiThreadObject
    {
        private readonly List<Thing> childs = new List<Thing>();

        private Thing parent;

        public IEnumerable<Thing> Childs
        {
            get
            {
                return this.childs;
            }
        }

        public void Insert(Thing child)
        {
            // TODO: remove from prev parent
            child.parent = this;
            this.childs.Add(child);
        }
    }
}
