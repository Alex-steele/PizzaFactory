using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaFactory.ConsoleApp.Runner;
using Serilog;

namespace PizzaFactory.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Pizza Factory! \nPlease enter the path of the file to display the pizzas:");
            var filePath = Console.ReadLine();

            var config = BuildConfig(new ConfigurationBuilder());

            SetUpLogging(config, filePath);

            var host = HostBuilder.Build(config);

            var runner = ActivatorUtilities.CreateInstance<PizzaFactoryRunner>(host.Services);

            try
            {
                runner.Run();
                Console.WriteLine("All done! check your file to see your pizzas.");
            }
            catch
            {
                Console.WriteLine("Something went wrong :(");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        static IConfigurationRoot BuildConfig(IConfigurationBuilder builder)
        {
            return builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();
        }

        static void SetUpLogging(IConfigurationRoot config, string filePath)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .WriteTo.File(filePath)
                .CreateLogger();
        }
    }
}
