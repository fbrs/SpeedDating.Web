using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SpeedDating.Web.Models;
using SpeedDating.Web.Services;

namespace SpeedDating.Web.Areas.Admin.Controllers
{
    public class UserController : BaseAdminController
    {

        private readonly IWorkContext _workContext;

        public UserController(IWorkContext workContext)
        {
            _workContext = workContext;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync();

            return RedirectToAction("Login", "User",new { Area = ""});
        }
    }
}
