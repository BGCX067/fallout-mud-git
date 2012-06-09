using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mud.Domain.Model;

namespace Mud.Domain.Data
{
    public interface IMapRepository
    {
        IList<Region> AllRegions();
        IList<Location> GetAllLocations();
        IList<Exit> GetAllExits();
    }
}
