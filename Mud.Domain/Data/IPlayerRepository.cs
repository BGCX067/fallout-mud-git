using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mud.Domain.Data
{
    public interface IPlayerRepository
    {
        bool ValidateUserName(string name);
    }
}
