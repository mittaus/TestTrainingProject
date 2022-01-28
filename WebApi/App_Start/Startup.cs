using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using System.Web.Http;

[assembly: OwinStartup(typeof(WebApi.App_Start.Startup))]

namespace WebApi.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration httpConfiguration = new HttpConfiguration();
            WebApiConfig.Register(httpConfiguration);
            app.UseWebApi(httpConfiguration);
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }

        //public void Configure(IAppBuilder app)//IApplicationBuilder app, IWebHostEnvironment env)
        //{
        //    //if (app.)
        //    //{
        //    //    app.UseDeveloperExceptionPage();
        //    //}
        //}
    }
}
