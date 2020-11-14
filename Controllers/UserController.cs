using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SpeedDating.Web.Core;
using SpeedDating.Web.Models;
using SpeedDating.Web.Services;

namespace SpeedDating.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IWorkContext _workContext;


        public UserController(IUserService userService, IWorkContext workContext)
        {
            _userService = userService;
            _workContext = workContext;
        }

        public IActionResult Login()
        {
            LoginModel model = new LoginModel();

            var userPrincipals = HttpContext.User.Identity as ClaimsIdentity;

            var email = userPrincipals.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            if (!string.IsNullOrEmpty(email))
                return RedirectToAction("Dashboard", "User", new { Area = Constants.Areas.Admin });


            return View(model);
        }
        
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            var user = _userService.LogInUser(model.Login, model.Password);

            if (user == null)
                return RedirectToAction("Login");

            List<Claim> userClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email)
            };

            var userIdentity = new ClaimsIdentity(userClaims, "User.Claims");

            var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });

            HttpContext.SignInAsync(userPrincipal);

            _workContext.CurrentUser = user;

            return RedirectToAction("Dashboard", "User", new { Area = Constants.Areas.Admin });
        }

        public IActionResult Registration()
        {
            RegistrationModel model = new RegistrationModel();

            return View(model);
        }

        public IActionResult Registration(RegistrationModel registrationModel)
        {



            return View();
        }
    }
}
