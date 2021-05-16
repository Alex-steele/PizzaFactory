using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PizzaFactory.ConsoleApp.Runner;
using PizzaFactory.Core.Commands;
using PizzaFactory.Core.Generator;
using Serilog;
using PizzaFactory.Core.ConfigValues;
using PizzaFactory.Core.ConfigValues.Interfaces;
using PizzaFactory.Data.Extensions;

namespace PizzaFactory.ConsoleApp
{
    public static class HostBuilder
    {
        public static IHost Build(IConfigurationRoot config)
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.ConfigureDataServices(config);

                    services.AddTransient<IGeneratePizzasCommand, GeneratePizzasCommand>();
                    services.AddTransient<IPizzaFactoryRunner, PizzaFactoryRunner>();
                    services.AddTransient<IRandomPizzaGenerator, RandomPizzaGenerator>();
                    services.AddTransient<ICookingInterval>(_ => new FixedCookingInterval(int.Parse(config["CookingInterval"])));
                    services.AddTransient<IBaseCookingTime>(_ => new BaseCookingTime(int.Parse(config["BaseCookingTime"])));
                })
                .UseSerilog()
                .Build();
        }
    }
}
