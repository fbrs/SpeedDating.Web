using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedDating.Web.Core
{
    public static class Constants
    {
        public static class Areas
        {
            public const string Admin = "Admin";
        }

        public static class Roles
        {
            public const string SystemAdministrator = "SpeedDating.SystemAdministrator";

            public const string Administrator = "SpeedDating.Administrator";

            public const string Manager = "SpeedDating.Manager";
            
            public const string Customer = "SpeedDating.Customer";
        }
    }
}
