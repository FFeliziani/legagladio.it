using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace LegaGladio
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "LoginApi",
                routeTemplate: "api/login/{username}/{password}",
                defaults: new { controller = "login" }
            );
            config.Routes.MapHttpRoute(
                name: "LogoutApi",
                routeTemplate: "api/logout/{token}",
                defaults: new { controller = "logout" }
            );
            config.Routes.MapHttpRoute(
                name: "WriteApi",
                routeTemplate: "api/{controller}/{action}/{token}/{data}"
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
