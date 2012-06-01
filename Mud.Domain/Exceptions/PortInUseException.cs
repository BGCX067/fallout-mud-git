using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mud.Domain.Exceptions
{
    public class PortInUseException: Exception
    {
        public PortInUseException(string message)
            : base(message)
        {
        }
    }
}
