using SpeedDating.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedDating.Web.Domain
{
    public class User : BaseEntity
    {
        private List<UserRole> _userRoles;

        public string Email { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public DateTime CreatedOnCet { get; set; }

        public bool Active { get; set; }

        public virtual List<UserRole> UserRoles
        {
            get => _userRoles ?? (_userRoles = new List<UserRole>());
            protected set => _userRoles = value;
        }



    }
}
