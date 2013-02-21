using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Golf_Roster_Creator.Helpers
{
    public static class ConnectionHelper
    {
        public static readonly string ConnectionStringName = "GolferRosterCreatorConnectionString";

        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
        }
    }

}