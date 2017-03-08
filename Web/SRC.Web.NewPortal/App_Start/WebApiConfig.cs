using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SRC.Web.NewPortal.filters;
using System.Web.Routing;

namespace SRC.Web.NewPortal
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // xml response dönmesini engelliyor
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            //config.Routes.MapHttpRoute(
            //    "DefaultApi",
            //    "api/{controller}/{action}/{id}",
            //    new { id = RouteParameter.Optional }
            //);

            RouteTable.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            ).RouteHandler = new SessionStateRouteHandler();
        }
    }
}
