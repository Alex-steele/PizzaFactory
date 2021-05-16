using Microsoft.Extensions.DependencyInjection;
using PizzaFactory.Data.PizzaBases;
using Microsoft.Extensions.Configuration;
using PizzaFactory.Data.PizzaToppings;
using PizzaFactory.Data.Repositories;
using PizzaFactory.Data.ConfigValues;

namespace PizzaFactory.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureDataServices(this IServiceCollection services, IConfigurationRoot config)
        {
            //Reflection method
            //var toppings = Assembly.GetAssembly(typeof(IPizzaTopping)).GetTypes()
            //    .Where(x => x.Namespace == "PizzaFactory.Data.PizzaToppings" && x.IsClass && !x.IsAbstract);

            //foreach(var topping in toppings)
            //{
            //    services.AddTransient(provider => (IPizzaTopping)ActivatorUtilities.CreateInstance(provider, topping));
            //}

            services.AddTransient<IPizzaTopping, Pepperoni>();
            services.AddTransient<IPizzaTopping, Vegetable>();
            services.AddTransient<IPizzaTopping, HamAndMushroom>();

            services.AddTransient<IPizzaBase, DeepPan>();
            services.AddTransient<IPizzaBase, ThinAndCrispy>();
            services.AddTransient<IPizzaBase, StuffedCrust>();

            services.AddTransient<IPizzaRepository, PizzaRepository>();
            services.AddTransient<IFilePathProvider>(_ => new FilePathProvider(config["FilePath"]));

            return services;
        }
    }
}
