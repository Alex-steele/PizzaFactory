using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using PizzaFactory.Data.Repositories;
using PizzaFactory.Data.ConfigValues;

namespace PizzaFactory.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureDataServices(this IServiceCollection services, IConfigurationRoot config)
        {
            services.AddTransient<IPizzaRepository, PizzaRepository>();
            services.AddTransient<IFilePathProvider>(_ => new FilePathProvider(config["FilePath"]));

            return services;
        }
    }
}
