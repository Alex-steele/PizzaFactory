using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PizzaFactory.ConsoleApp.Runner;
using PizzaFactory.Core;
using Serilog;

namespace PizzaFactory.ConsoleApp
{
    public static class HostBuilder
    {
        public static IHost Build(IConfigurationRoot config)
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddTransient<IGeneratePizzasCommand, GeneratePizzasCommand>();
                    services.AddTransient<IPizzaFactoryRunner, PizzaFactoryRunner>();
                    services.AddTransient<IRandomPizzaGenerator>(_ => new RandomPizzaGenerator(int.Parse(config["BaseCookingTime"])));
                    services.AddTransient<ICookingInterval>(_ => new CookingInterval(int.Parse(config["CookingInterval"])));
                })
                .UseSerilog()
                .Build();
        }
    }
}
