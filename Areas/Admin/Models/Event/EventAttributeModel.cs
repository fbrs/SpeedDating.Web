using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedDating.Web.Areas.Admin.Models.Event
{
    public class EventAttributeModel
    {
        public int Id { get; set; }

        public int WoocommerceId { get; set; }

        [Display(Name = "Název")]
        public string Name { get; set; }

        [Display(Name = "Název možnosti")]
        public List<string> EventAttributeOptions { get; set; }

        public EventAttributeModel()
        {
            EventAttributeOptions = new List<string>();
        }
    }
}
