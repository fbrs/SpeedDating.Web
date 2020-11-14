using SpeedDating.Web.Core;
using SpeedDating.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace SpeedDating.Web.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<Role> _roleRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<UserRole> _userRoleRepository;


        public UserService(IRepository<Role> roleRepository, IRepository<User> userRepository, IRepository<UserRole> userRoleRepository)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
        }

        public void InitAdminUser(string email, string password)
        {
            User u = new User();
            u.Email = email;

            u.Active = true;
            u.CreatedOnCet = DateTime.Now;

            InitUserPasswordHash(u, password);

            var role = _roleRepository.Table.Where(x => x.SystemName == Constants.Roles.SystemAdministrator).FirstOrDefault();
            if (role != null)
            {
                u.UserRoles.Add(new UserRole { Role = role, User = u });

                _userRepository.Insert(u);
            }
            else
            {
                // loger nenalezena role
            }
        }

        public void InitRoles()
        {
            List<Role> roles = new List<Role>();

            roles.Add(new Role
            {
                Name = "System administrátor",
                SystemName = Constants.Roles.SystemAdministrator,
            });

            roles.Add(new Role
            {
                Name = "Administrátor",
                SystemName = Constants.Roles.Administrator,
            });

            roles.Add(new Role
            {
                Name = "Správce",
                SystemName = Constants.Roles.Manager,
            });

            roles.Add(new Role
            {
                Name = "Zákazník",
                SystemName = Constants.Roles.Customer,
            });

            _roleRepository.Insert(roles);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="email">valid email</param>
        /// <param name="password">password</param>
        /// <returns>null if user doesnt exists or password is incorrect</returns>
        public User LogInUser(string email, string password)
        {
            var user = _userRepository.Table.Where(x => x.Email == email).FirstOrDefault();

            if (user != null)
            {
                if (user.Password == HashPassword(password, user.Salt))
                    return user;
            }

            return null;
        }

        public void RegisterUser(string email, string password)
        {
            User u = new User();
            u.Email = email;

            u.Active = true;
            u.CreatedOnCet = DateTime.Now;

            InitUserPasswordHash(u, password);

            var role = _roleRepository.Table.Where(x => x.SystemName == Constants.Roles.Customer).FirstOrDefault();
            if (role != null)
            {
                u.UserRoles.Add(new UserRole { Role = role, User = u });

                _userRepository.Insert(u);
            }
            else
            {
                // loger nenalezena role
            }
        }

        private void InitUserPasswordHash(User user, string password)
        {
            byte[] salt;

            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            string slt = Convert.ToBase64String(salt);
            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password + slt);

            string hashedPassword = HashPassword(password, slt);

            user.Password = hashedPassword;
            user.Salt = slt;
        }

        private string HashPassword(string password, string salt)
        {
            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password + salt);

            using (SHA256Managed sHA256 = new SHA256Managed())
            {
                byte[] hash = sHA256.ComputeHash(passwordBytes);

                string hashedPassword = Convert.ToBase64String(hash);

                return hashedPassword;
            }
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.Table.FirstOrDefault(x => x.Email == email);
        }
    }
}
