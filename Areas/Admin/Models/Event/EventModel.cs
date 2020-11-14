using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedDating.Web.Areas.Admin.Models.Event
{
    public class EventModel
    {
        [Display(Name = "Datum akce")]
        public DateTime EventDate { get; set; }

        [Display(Name = "Název")]
        public string Name { get; set;}
        
        [Display(Name = "Popis")]
        public string Description { get; set; }

        [Display(Name = "Kapacita")]
        public int Capacity { get; set; } = 20;

        [Display(Name = "Cena ženy")]
        public decimal? WomanPrice { get; set; }

        [Display(Name = "Cena muži")]
        public decimal? ManPrice { get; set; }

        public EventType EventType { get; set; }
    }

    public enum EventType
    {
        GIRLANDGIRL = 1,
        BOYANDGIRL = 2,
        BOYANDBOY = 3
    }
}
