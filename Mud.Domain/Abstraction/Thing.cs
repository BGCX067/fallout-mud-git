using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mud.Domain.Abstraction
{
    public abstract class Thing
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public List<Thing> Children { get; private set; }

        public Thing()
        {
            Children = new List<Thing>();
        }

        public Thing Parent { get; set; }
    }
}
