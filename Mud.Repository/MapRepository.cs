using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Mud.Domain.Data;
using Mud.Domain.Model;

namespace Mud.Repository.Impl
{
    public class MapRepository : IMapRepository
    {

        public IList<Region> AllRegions()
        {
            throw new NotImplementedException();
        }

        public IList<Location> GetAllLocations()
        {
            throw new NotImplementedException();
        }

        public IList<Exit> GetAllExits()
        {
            throw new NotImplementedException();
        }
    }
}
