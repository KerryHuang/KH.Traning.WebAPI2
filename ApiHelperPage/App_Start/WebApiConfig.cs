using ApiHelperPage.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ApiHelperPage
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 設定和服務
            config.EnableSystemDiagnosticsTracing();
            config.Filters.Add(new ElmahErrorAttribute());
            config.Filters.Add(new ApiVersionAttribute());

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "NotFound",
                routeTemplate: "{*path}",
                defaults: new { controller = "Error404", action = "NotFound" }
            );
        }
    }
}
