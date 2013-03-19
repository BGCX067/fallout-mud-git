namespace Mud.World
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Mud.Core;

    public class Thing : MultiThreadObject
    {
        private readonly List<Thing> childs;

        private Thing parent;

        public Thing()
        {
            this.childs = new List<Thing>();
        }

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
