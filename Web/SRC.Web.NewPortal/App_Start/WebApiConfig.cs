using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SRC.Web.NewPortal
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // xml response dönmesini engelliyor
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "{controller}/{action}/{id}",
                new { id = RouteParameter.Optional }
            );
        }
    }
}
