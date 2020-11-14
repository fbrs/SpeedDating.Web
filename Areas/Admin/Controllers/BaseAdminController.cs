using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpeedDating.Web.Core;

namespace SpeedDating.Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area(Constants.Areas.Admin)]
    public class BaseAdminController : Controller
    {
       
    }
}
