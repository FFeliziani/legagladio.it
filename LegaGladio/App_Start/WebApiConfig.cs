using System.Web.Http;

namespace LegaGladio
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute("LoginApi", "api/login/", new { controller = "login" }
            );
            config.Routes.MapHttpRoute("LogoutApi", "api/logout/{token}", new { controller = "logout" }
            );
            config.Routes.MapHttpRoute("ReadApi", "api/{controller}/{action}/"
            );
            config.Routes.MapHttpRoute("ReadByIdApi", "api/{controller}/{action}/withId/{id}/"
            );
            config.Routes.MapHttpRoute("CreateApi", "api/{controller}/{action}/{token}/"
            );
            //config.Routes.MapHttpRoute(
            //    name: "UpdateApi",
            //    routeTemplate: "api/{controller}/{action}/{token}/{id}/"
            //);
            config.Routes.MapHttpRoute("DeleteApi", "api/{controller}/{action}/{token}/{id}/"
            );
        }
    }
}
