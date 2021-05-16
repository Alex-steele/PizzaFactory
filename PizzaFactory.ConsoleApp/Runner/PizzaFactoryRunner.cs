using System;
using Microsoft.Extensions.Logging;
using PizzaFactory.Core.Commands;
using PizzaFactory.Core.ConfigValues.Interfaces;

namespace PizzaFactory.ConsoleApp.Runner
{
    public class PizzaFactoryRunner : IPizzaFactoryRunner
    {
        private readonly IGeneratePizzasCommand generatePizzasCommand;
        private readonly ICookingInterval cookingInterval;
        private readonly ILogger<PizzaFactoryRunner> logger;

        public PizzaFactoryRunner(
            IGeneratePizzasCommand generatePizzasCommand,
            ICookingInterval cookingInterval,
            ILogger<PizzaFactoryRunner> logger)
        {
            this.generatePizzasCommand = generatePizzasCommand;
            this.cookingInterval = cookingInterval;
            this.logger = logger;
        }

        public void Run()
        {
            logger.LogInformation("Starting app runner");

            Console.WriteLine("\nGreat! Now enter the amount of pizzas you would like:");

            while (true)
            {
                var numberOfPizzasString = Console.ReadLine();

                if (int.TryParse(numberOfPizzasString, out var numberOfPizzas) && numberOfPizzas > 0 && numberOfPizzas < 1000)
                {
                    Console.WriteLine($"\nCooking {numberOfPizzas} pizzas with a {cookingInterval.Message}\n");

                    var result = generatePizzasCommand.Execute(numberOfPizzas);

                    foreach (var pizza in result)
                    {
                        Console.WriteLine($"Cooking a {pizza.PizzaTopping.Name} pizza with a {pizza.PizzaBase.Name} base..." +
                            $"\n Pizza cooking time: {pizza.CookingTime}ms");
                    }

                    logger.LogInformation($"Successfully added {numberOfPizzas} pizzas to file");

                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a number greater than 0 and less than 1000:");
                }
            }
        }
    }
}

