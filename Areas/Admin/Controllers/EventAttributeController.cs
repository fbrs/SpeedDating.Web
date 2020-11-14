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
    public class EventAttributeController : BaseAdminController
    {
        private readonly IWoocommerceService _woocomerceService;

        public EventAttributeController(IWoocommerceService woocomerceService)
        {
            _woocomerceService = woocomerceService;
        }

        public IActionResult Create()
        {
            EventAttributeModel model = new EventAttributeModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(EventAttributeModel model)
        {
            ProductAttribute attribute = new ProductAttribute
            {
                name = model.Name
            };

            var wooAttribute = _woocomerceService.CreateProductAttribute(attribute);

            if(wooAttribute != null)
            {
                List<ProductAttributeTerm> options = new List<ProductAttributeTerm>();
                foreach (var option in model.EventAttributeOptions)
                {
                    options.Add(new ProductAttributeTerm
                    {
                        name = option
                    });
                }

                _woocomerceService.CreateProductAttributeTerms(options, wooAttribute.id.Value);
            }

            return View();
        }
    }
}
