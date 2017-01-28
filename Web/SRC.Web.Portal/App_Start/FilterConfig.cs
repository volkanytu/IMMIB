using SRC.Web.Portal.Filters;
//using SRC.Web.Portal.Filters;
using System.Web;
using System.Web.Mvc;

namespace SRC.Web.Portal
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            filters.Add(new ErrorAttribute());
        }
    }
}
