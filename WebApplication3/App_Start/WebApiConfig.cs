using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApplication3.Formatters;

namespace WebApplication3
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 設定和服務
            config.Formatters.Add(new ProductFormatter());

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );        
        }
    }
}
