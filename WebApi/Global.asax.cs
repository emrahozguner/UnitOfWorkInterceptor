using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using UnitOfWorkInterceptor;
using WebApi.App_Data;
using WebApi.Dependency;

namespace WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new WindsorContainer();
            container.Register(Component.For<UnitOfWork.UnitOfWorkInterceptor>().LifestyleSingleton());
            container.Register(Component.For<ExceptionHandlingInterceptor>().LifestyleSingleton());
            container.Install(new ServiceInstaller());
            container.Install(new RepositoryInstaller());
            container.Install(new NHibernateInstaller());
            container.Install(new WebApiControllerInstaller());
            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator),
                new ApiControllerActivator(container));
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}