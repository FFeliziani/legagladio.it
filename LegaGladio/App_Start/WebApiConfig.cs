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
                routeTemplate: "api/login/",
                defaults: new { controller = "login" }
            );
            config.Routes.MapHttpRoute(
                name: "LogoutApi",
                routeTemplate: "api/logout/{token}",
                defaults: new { controller = "logout" }
            );
            config.Routes.MapHttpRoute(
                name: "ReadApi",
                routeTemplate: "api/{controller}/{action}/"
            );
            config.Routes.MapHttpRoute(
                name: "ReadByIdApi",
                routeTemplate: "api/{controller}/{action}/withId/{id}/"
            );
            config.Routes.MapHttpRoute(
                name: "CreateApi",
                routeTemplate: "api/{controller}/{action}/{token}/"
            );
            //config.Routes.MapHttpRoute(
            //    name: "UpdateApi",
            //    routeTemplate: "api/{controller}/{action}/{token}/{id}/"
            //);
            config.Routes.MapHttpRoute(
                name: "DeleteApi",
                routeTemplate: "api/{controller}/{action}/{token}/{id}/"
            );
        }
    }
}
