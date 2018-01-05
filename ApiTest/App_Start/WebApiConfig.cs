using ApiTest.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ApiTest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 設定和服務

            // 6.移除 XML Formatter。
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Filters.Add(new ModelValidationFilterAttribute());
            config.EnableQuerySupport();

            // Web API 路由
            config.MapHttpAttributeRoutes();

            // 5.修改預設路由 "api/" 為 ""。
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
