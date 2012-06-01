using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mud.Domain.Abstraction;

namespace Mud.Domain.Model
{
    public class LivingThing
    {
        private IController _controller;

        public LivingThing(IController controller)
            : base()
        {
            _controller = controller;
            _controller.ActionRecived += ControllerActionRecived;
        }

        private void ControllerActionRecived(object sender, EventArgs e)
        {
            
        }
    }
}
