using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mud.Domain.Data;

namespace Mud.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        public bool ValidateUserName(string name)
        {
            return false;
        }
    }
}
