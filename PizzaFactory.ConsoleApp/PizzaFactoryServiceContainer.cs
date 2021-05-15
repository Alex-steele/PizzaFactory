using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using PizzaFactory.Core;
using PizzaFactory.ConsoleApp.Runner;

namespace PizzaFactory.ConsoleApp
{
    public class PizzaFactoryServiceContainer
    {
        private readonly IServiceProvider serviceProvider;

        public PizzaFactoryServiceContainer()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var x = config["BaseCookingTime"];

            var services = new ServiceCollection();

            services.AddSingleton<IRandomPizzaGenerator>(_ => new RandomPizzaGenerator(int.Parse(config["BaseCookingTime"])));
            services.AddSingleton<IPizzaFactoryRunner, PizzaFactoryRunner>();

            serviceProvider = services.BuildServiceProvider();
        }

        public T GetService<T>()
        {
            return serviceProvider.GetService<T>();
        }
    }
}
