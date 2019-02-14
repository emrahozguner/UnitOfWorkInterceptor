using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using WebApi.Interfaces;
using WebApi.Repository;

namespace WebApi.Dependency
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<TypedFactoryFacility>();

            container.Register(
                Classes.FromAssemblyContaining<UserService>()
                    .Pick()
                    .WithServiceAllInterfaces()
                    .LifestylePerWebRequest()
                    .Configure(x => x.Named(x.Implementation.Name))
                    .ConfigureIf(x => typeof(IApiService).IsAssignableFrom(x.Implementation),
                        y => y.Interceptors<UnitOfWork.UnitOfWorkInterceptor>()));
        }
    }
}