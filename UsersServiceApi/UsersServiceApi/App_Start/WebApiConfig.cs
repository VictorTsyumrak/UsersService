using System.Web.Http;

namespace UsersServiceApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.ConfigureDependencyResolver();
            config.ConfigureFilters();
        }
    }
}
