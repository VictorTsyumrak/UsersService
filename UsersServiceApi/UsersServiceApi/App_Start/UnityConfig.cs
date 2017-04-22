using System.Data.Entity;
using System.Web.Http;
using BusinessLayer.Services.Implementation;
using BusinessLayer.Services.Interfaces;
using Microsoft.Practices.Unity;
using DataLayer;
using Microsoft.Practices.Unity.WebApi;

namespace UsersServiceApi
{
    public static class UnityConfig
    {
        public static void ConfigureDependencyResolver(this HttpConfiguration config)
        {
			var container = new UnityContainer();

            container.RegisterType<DbContext, DefaultContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUsersService, UsersService>();
            container.RegisterType(typeof(IRepository<>), typeof(EntityFrameworkGenericRepository<>));
            container.RegisterType(typeof(IRepositoryAsync<>), typeof(EntityFrameworkGenericRepository<>));
            container.RegisterInstance(AutoMapperConfig.Configure().CreateMapper());

            config.DependencyResolver = new UnityHierarchicalDependencyResolver(container);
        }
    }
}