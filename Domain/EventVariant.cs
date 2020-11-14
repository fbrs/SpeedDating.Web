using SpeedDating.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedDating.Web.Domain
{
    public class EventVariant : BaseEntity
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal SalePrice { get; set; }

        public string Description { get; set; }

        public int WPId { get; set; }


    }
}
