using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Mud.Repository
{
    public interface IMapRepository
    {
        IDataReader AllRegions();
        IDataReader GetAllLocations();
        IDataReader GetAllExits();
    }
}
