using Com.Jamim.Infrastructure.Configuration;
using Com.Jamim.Infrastructure.Logging;
using Com.Jamim.Model.Products;
using Com.Jamim.Model.Catalog;
using Com.Jamim.Model.Locations;
using Com.Jamim.Model.Stores;
using Com.Jamim.Repository;
using Com.Jamim.Repository.Repositories;
using Com.Jamim.Infrastructure.UnitOfWork;

using Com.Jamim.Services.Customer.Abstract;
using Com.Jamim.Services.Customer.Concrete;

using Com.Jamim.Infrastructure.CookieStorage;

using Autofac;
using System.Web.Mvc;

namespace Com.Jamim.UI
{
    public class CustomerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
         

            builder.RegisterType<WebConfigApplicationSettings>().As<IApplicationSettings>().InstancePerRequest();
            builder.RegisterType<JamimLogAdapter>().As<ILogger>().InstancePerRequest();
            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerRequest();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().InstancePerRequest();
            builder.RegisterType<CategoryAccessRepository>().As<ICategoryAccessRepository>().InstancePerRequest();
            builder.RegisterType<CatalogRepository>().As<ICatalogRepository>().InstancePerRequest();
            builder.RegisterType<RegionRepository>().As<IRegionRepository>().InstancePerRequest();
            builder.RegisterType<ServiceAreaRepository>().As<IServiceAreaRepository>().InstancePerRequest();
            builder.RegisterType<StoreRepository>().As<IStoreRepository>().InstancePerRequest();

            builder.RegisterType<ProductCatalogueService>().As<IProductCatalogueService>().InstancePerRequest();
            builder.RegisterType<LocationService>().As<ILocationService>().InstancePerRequest();
            builder.RegisterType<StoreService>().As<IStoreService>().InstancePerRequest();


            builder.RegisterType<CookieStorageService>().As<ICookieStorageService>().InstancePerRequest();
            builder.RegisterType<EFUnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            base.Load(builder);         
        }
    }
}