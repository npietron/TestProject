using System.Web.Http;
using System.Web.Http.Cors;

namespace TestProject.WebApi
{
    public static class CorsConfig
    {
        public static void EnableCors(HttpConfiguration config)
        {
            // Web API configuration and services
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
        }
    }
}