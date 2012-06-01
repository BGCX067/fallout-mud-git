using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mud.Domain.Abstraction;

namespace Mud.Domain.Model
{
    public class Location : Thing
    {
        public string Description { get; set; }
        public List<Thing> Things { get; set; }
        public List<Exit> Exits { get; set; }
    }
}
