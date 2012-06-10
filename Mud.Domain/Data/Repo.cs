using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;

namespace Mud.Domain.Data
{
    public static class Repo
    {
        public static IPlayerRepository Player { get; private set; }
        public static IMapRepository Map { get; private set; }

        private static bool _initialized = false;
        public static void Initialize()
        {
            if (_initialized)
                return;
            Player = ObjectFactory.GetInstance<IPlayerRepository>();
            Map = ObjectFactory.GetInstance<IMapRepository>();
            _initialized = true;
        }

    }
}
