using System;
using PizzaFactory.ConsoleApp.Runner;

namespace PizzaFactory.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Pizza factory!");

            var serviceProvider = new PizzaFactoryServiceContainer();

            var runner = serviceProvider.GetService<IPizzaFactoryRunner>();

            runner.Run();

            Console.ReadKey();
        }
    }
}
