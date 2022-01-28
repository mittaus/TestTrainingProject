using System.Web.Http;
using WebApi.ActionFilters;

namespace WebApi.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v1/{controller}/{id}",
                defaults: new
                {
                    id = RouteParameter.Optional
                });
            //config.Filters.Add(new LoggingFilterAttribute());
            //config.Filters.Add(new GlobalExceptionAttribute());
        }
    }
}
