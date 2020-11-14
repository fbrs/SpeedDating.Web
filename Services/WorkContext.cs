using Microsoft.AspNetCore.Http;
using SpeedDating.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SpeedDating.Web.Services
{
    public class WorkContext : IWorkContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        
        private User _currentUser;

        public WorkContext(IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        public User CurrentUser { 
            get 
            {
                if (_currentUser != null)
                    return _currentUser;

                var userPrincipals = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;

                var email = userPrincipals.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

                if (!string.IsNullOrEmpty(email))
                {
                    var user = _userService.GetUserByEmail(email);

                    if (user != null)
                        _currentUser = user;
                    else
                    {
                        //guest
                    }
                }
                else
                {
                    //guest
                }

                
                return _currentUser;
            } 
            set { _currentUser = value; } 
        }

        
    }
}
