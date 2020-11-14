using SpeedDating.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedDating.Web.Domain
{
    public class Role : BaseEntity
    {
        
        public string Name { get; set; }

        public string SystemName { get; set; }

        public virtual List<UserRole> UserRoles { get; set; }
    }
}
