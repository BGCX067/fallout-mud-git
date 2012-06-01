using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mud.Domain.Model
{
    public class World
    {
        public string Name { get; set; }
        public List<Region> Regions { get; set; }
    }
}
