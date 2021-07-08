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
            Console.WriteLine("Welcome to Pizza Factory! \n\nPlease enter the path of a .txt file to display the pizzas:");

            string filePath;

            while(true)
            {
                filePath = Console.ReadLine();

                if(filePath.EndsWith(".txt"))
                {
                    break;
                }

                Console.WriteLine("Please enter the path of a .txt file");
            }

            var config = BuildConfig(new ConfigurationBuilder());
            config["FilePath"] = filePath;

            SetUpLogging(config);

            var host = HostBuilder.Build(config);

            var runner = ActivatorUtilities.CreateInstance<PizzaFactoryRunner>(host.Services);

            try
            {
                runner.Run();
                Console.WriteLine("All done! check your file to see your pizzas.");
            }
            catch(IOException ex)
            {
                Console.WriteLine(ex.Message);
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

        static void SetUpLogging(IConfigurationRoot config)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .WriteTo.File(config["LoggingPath"])
                .CreateLogger();
        }
    }
}
