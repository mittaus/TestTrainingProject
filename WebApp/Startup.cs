//using Autofac;
//using BusinessServices;
//using Microsoft.Owin;
//using Owin;
//using System;
//using System.Linq;
//using System.Reflection;
//using System.Threading.Tasks;
//using System.Web.Compilation;
//using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using BusinessServices;
using DataModel.UnitOfWork;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Http;
using WebApp.Controllers;

[assembly: OwinStartup(typeof(WebApp.Startup))]

namespace WebApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            // Get our http configuration
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Register the Autofac middleware FIRST. This also adds
            // Autofac-injected middleware registered with the container.
            var container = ConfigureInversionOfControl(app, config);

            // Register all areas
            //System.Web.Mvc.AreaRegistration.RegisterAllAreas();
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            

            // Use our web api
            app.UseWebApi(config);
        }
        /// <summary>
        /// Configures Autofac DI/IoC
        /// </summary>
        /// <param name="app"></param>
        /// <param name="config"></param>
        private IContainer ConfigureInversionOfControl(IAppBuilder app, HttpConfiguration config)
        {

            // Create our container
            var builder = new ContainerBuilder();

            // You can register controllers all at once using assembly scanning...
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Register our module
            builder.RegisterModule(new AutofacModule());

            // Build
            var container = builder.Build();

            // Lets Web API know it should locate services using the AutofacWebApiDependencyResolver
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            //GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // Return our container
            return container;
        }

    }

    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            //// Create our Singletons
            //builder.RegisterType<DatabaseContext>().As<DbContext>().InstancePerRequest();

            //// Create our Services
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<ProductServices>().As<IProductServices>().InstancePerRequest();
            //builder.RegisterType<AnswerService>().As<IAnswerService>().InstancePerRequest();
            //builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerRequest();
            //builder.RegisterType<FeedService>().As<IFeedService>().InstancePerRequest();
            //builder.RegisterType<FilterService>().As<IFilterService>().InstancePerRequest();
            //builder.RegisterType<QuestionGroupService>().As<IQuestionGroupService>().InstancePerRequest();
            //builder.RegisterType<StateService>().As<IStateService>().InstancePerRequest();

            //// Create our providers
            //builder.RegisterType<ProductServices>().As<IProductServices>().InstancePerLifetimeScope();
            ////builder.RegisterType<AnswerProvider>().As<IAnswerProvider>().InstancePerLifetimeScope();
            //builder.RegisterType<CategoryProvider>().As<ICategoryProvider>().InstancePerRequest();
            //builder.RegisterType<FeedProvider>().As<IFeedProvider>().InstancePerRequest();
            //builder.RegisterType<FilterProvider>().As<IFilterProvider>().InstancePerRequest();
            //builder.RegisterType<QuestionGroupProvider>().As<IQuestionGroupProvider>().InstancePerRequest();
            //builder.RegisterType<StateProvider>().As<IStateProvider>().InstancePerRequest();
        }
    }
}
