using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PizzaFactory.ConsoleApp.Runner;
using PizzaFactory.Core.Commands;
using PizzaFactory.Core.Generator;
using PizzaFactory.Data.PizzaToppings;
using Serilog;
using PizzaFactory.Data.PizzaBases;
using PizzaFactory.Core.ConfigValues;
using PizzaFactory.Core.ConfigValues.Interfaces;
using PizzaFactory.Data.Repositories;
using PizzaFactory.Data.ConfigValues;

namespace PizzaFactory.ConsoleApp
{
    public static class HostBuilder
    {
        public static IHost Build(IConfigurationRoot config)
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
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

                    services.AddTransient<IGeneratePizzasCommand, GeneratePizzasCommand>();
                    services.AddTransient<IPizzaFactoryRunner, PizzaFactoryRunner>();
                    services.AddTransient<IRandomPizzaGenerator, RandomPizzaGenerator>();
                    services.AddTransient<IPizzaRepository, PizzaRepository>();
                    services.AddTransient<ICookingInterval>(_ => new FixedCookingInterval(int.Parse(config["CookingInterval"])));
                    services.AddTransient<IBaseCookingTime>(_ => new BaseCookingTime(int.Parse(config["BaseCookingTime"])));
                    services.AddTransient<IFilePathProvider>(_ => new FilePathProvider(config["FilePath"]));
                })
                .UseSerilog()
                .Build();
        }
    }
}
