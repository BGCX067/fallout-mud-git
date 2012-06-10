using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mud.Domain.Output
{
    public interface IOutputParser
    {
        string Parse(string message);
    }
}
