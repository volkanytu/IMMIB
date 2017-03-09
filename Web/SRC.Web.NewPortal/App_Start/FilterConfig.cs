using SRC.Web.NewPortal.filters;
using System.Web;
using System.Web.Mvc;

namespace SRC.Web.NewPortal
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //filters.Add(new AuthenticationFilter());
        }
    }
}
