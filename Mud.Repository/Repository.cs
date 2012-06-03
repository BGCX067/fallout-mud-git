using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Mud.Repository
{
    public static class Repository
    {
        static Repository()
        {
            Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Data"].ConnectionString);
            Connection.Open();
        }
        public static IDbConnection Connection { get; private set; }
        public static IPlayerRepository Player { get; private set; }
        public static IMapRepository Map { get; private set; }
    }
}
