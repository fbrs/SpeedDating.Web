using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedDating.Web.Areas.Admin.Models.Event
{
    public class EventCategoryModel
    {
        public int Id { get; set; }

        public int WoocommerceId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Slug { get; set; }
    }
}
