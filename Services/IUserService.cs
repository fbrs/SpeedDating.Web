using SpeedDating.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedDating.Web.Services
{
    public interface IUserService
    {
        void RegisterUser(string email, string password);

        void InitRoles();

        void InitAdminUser(string email, string password);

        User LogInUser(string email, string password);

        User GetUserByEmail(string email);
        
    }
}
