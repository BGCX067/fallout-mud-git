using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mud.Domain.Model
{
    public class Region
    {
        public string Name { get; set; }
        public List<Location> Locations { get; set; }
    }
}
