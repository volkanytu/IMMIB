using System.Web;
using System.Web.Mvc;

namespace SRC.WebService.CrmService
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
