using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRC.Web.Portal.Models
{
    public class HeaderMenuItem
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public string ClassDetails { get; set; }
        public string ControllerName { get; set; }

        public string ActiveClass
        {
            get
            {
                return HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString() == ControllerName ? "active" : string.Empty;
            }
        }
    }
}