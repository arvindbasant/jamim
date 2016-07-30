using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using Com.Jamim.Controllers.Customer;

namespace Com.Jamim.UI
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // Register dependencies in controllers
            builder.RegisterControllers(typeof(HomeController).Assembly);
            builder.RegisterControllers(typeof(LocationController).Assembly);

            // Register dependencies in filter attributes
            builder.RegisterFilterProvider();

            // Register dependencies in custom views
            builder.RegisterSource(new ViewRegistrationSource());

            //Register our Data dependencies
            builder.RegisterModule(new CustomerModule());

            var container = builder.Build();

            // Set MVC DI resolver to use our Autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}