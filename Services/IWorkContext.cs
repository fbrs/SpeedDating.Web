using SpeedDating.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedDating.Web.Services
{
    public interface IWorkContext
    {
        User CurrentUser { get; set; }
    }
}
