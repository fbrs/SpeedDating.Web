using Microsoft.AspNetCore.Mvc;
using SpeedDating.Web.Areas.Admin.Models.Event;
using SpeedDating.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WooCommerceNET.WooCommerce.v3;

namespace SpeedDating.Web.Areas.Admin.Controllers
{
    public class EventCategoryController : BaseAdminController
    {
        private readonly IWoocommerceService _woocomerceService;

        public EventCategoryController(IWoocommerceService woocomerceService)
        {
            _woocomerceService = woocomerceService;
        }

        public IActionResult Create()
        {
            EventCategoryModel model = new EventCategoryModel();


            return View(model);
        }

        [HttpPost]
        public IActionResult Create(EventCategoryModel model)
        {
            ProductCategory category = new ProductCategory
            {
                name = model.Name,
                description = model.Description,
                slug = model.Slug
            };

            var wooCategoru = _woocomerceService.CreateCategory(category);


            return View();
        }
    }
}
