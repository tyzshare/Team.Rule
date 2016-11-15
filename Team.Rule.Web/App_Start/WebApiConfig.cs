using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Team.Rule.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v1/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
