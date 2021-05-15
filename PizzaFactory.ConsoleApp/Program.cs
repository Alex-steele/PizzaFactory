using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PizzaFactory.ConsoleApp.Runner;
using PizzaFactory.Core;
using Serilog;

namespace PizzaFactory.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = BuildConfig(new ConfigurationBuilder());

            Console.WriteLine("Welcome to Pizza Factory! \nPlease enter the path of the file to display the pizzas:");
            var filePath = Console.ReadLine();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .WriteTo.File(filePath)
                .CreateLogger();

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddTransient<IGeneratePizzasCommand, GeneratePizzasCommand>();
                    services.AddTransient<IPizzaFactoryRunner, PizzaFactoryRunner>();
                    services.AddSingleton<IRandomPizzaGenerator>(_ => new RandomPizzaGenerator(int.Parse(config["BaseCookingTime"])));
                })
                .UseSerilog()
                .Build();

            var runner = ActivatorUtilities.CreateInstance<PizzaFactoryRunner>(host.Services);

            runner.Run();

            Console.ReadKey();
        }

        static IConfigurationRoot BuildConfig(IConfigurationBuilder builder)
        {
            return builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();
        }
    }
}
