using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;
using WebApi.Entity;
using WebApi.Entity.Maps;

namespace WebApi.Dependency
{
    public class NHibernateInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey("ConnString")).ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>())
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                .ExposeConfiguration(cfg =>
                {
                    cfg.CurrentSessionContext<CallSessionContext>();
                })
                .BuildSessionFactory();

            //container.Register(
            //    Component.For<ISessionFactory>().UsingFactoryMethod(sessionFactory).LifestyleSingleton());
        }
    }
}