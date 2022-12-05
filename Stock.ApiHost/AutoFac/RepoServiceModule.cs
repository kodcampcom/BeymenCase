using Autofac;
using Stock.Core.Models;
using Stock.Core.Repository;
using Stock.Core.Services;
using Stock.Core.UnitOfWork;
using Stock.Repository.Context;
using Stock.Repository.Repositories;
using Stock.Repository.UnitOfWorks;
using Stock.Service.Mapping;
using Stock.Service.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace Stock.ApiHost.AutoFac
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(ProductMapping));
            var coreAssembly = Assembly.GetAssembly(typeof(ProductResponseDto));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly, coreAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly, coreAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<ProductService>().As<IProductService>();
        }
    }
}
