using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpeedDating.Web.Areas.Admin.Models.Event;
using SpeedDating.Web.Services;
using WooCommerceNET.WooCommerce.v3;

namespace SpeedDating.Web.Areas.Admin.Controllers
{
    public class EventController : BaseAdminController
    {
        private readonly IWoocommerceService _woocommerceService;

        public EventController(IWoocommerceService woocommerceService)
        {
            _woocommerceService = woocommerceService;
        }

        public IActionResult Create()
        {
            EventModel model = new EventModel()
            {
                EventDate = DateTime.Now.Date
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(EventModel model)
        {
            

            return View();
        }
    }
}
