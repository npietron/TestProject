using System.Web.Http;
using TestProject.Services.Mapper;

namespace TestProject.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            MappingsConfig.RegisterMappings();

            AutofacConfig.RegisterTypes(config);

            ODataConfig.Register(config);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
