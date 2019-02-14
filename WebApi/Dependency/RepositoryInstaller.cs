using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using WebApi.Repository.Base;

namespace WebApi.Dependency
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromThisAssembly()
                    .Pick()
                    .WithServiceAllInterfaces()
                    .LifestylePerWebRequest()
                    .Configure(x => x.Named(x.Implementation.Name))
                    .ConfigureIf(x => typeof(IRepository<>).IsAssignableFrom(x.Implementation), null));
        }
    }
}