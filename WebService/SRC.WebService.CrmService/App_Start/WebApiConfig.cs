using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SRC.WebService.CrmService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // xml response dönmesini engelliyip, JSON döndürür
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "{controller}/{action}/{id}",
                new { id = RouteParameter.Optional }
            );
        }
    }
}
