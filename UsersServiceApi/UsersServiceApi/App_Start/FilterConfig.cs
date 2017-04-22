using System.Web.Http;
using UsersServiceApi.Filters;

namespace UsersServiceApi
{
    public static class FilterConfig
    {
        public static void ConfigureFilters(this HttpConfiguration config)
        {
            config.Filters.Add(new GlobalExceptionFilterAttribute());
            config.Filters.Add(new ActionLoggerAttribute());
            config.Filters.Add(new ValidateModelAttribute());
        }
    }
}