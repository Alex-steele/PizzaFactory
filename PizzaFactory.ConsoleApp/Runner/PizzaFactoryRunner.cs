using System;
using PizzaFactory.Core.Commands;

namespace PizzaFactory.ConsoleApp.Runner
{
    public class PizzaFactoryRunner : IPizzaFactoryRunner
    {
        private readonly IGeneratePizzasCommand generatePizzasCommand;

        public PizzaFactoryRunner(IGeneratePizzasCommand generatePizzasCommand)
        {
            this.generatePizzasCommand = generatePizzasCommand;
        }

        public void Run()
        {
            Console.WriteLine("Great! Now enter the amount of pizzas you would like:");

            while (true)
            {
                var numberOfPizzasString = Console.ReadLine();

                if (int.TryParse(numberOfPizzasString, out var numberOfPizzas))
                {
                    var result = generatePizzasCommand.Execute(numberOfPizzas);

                    foreach (var pizza in result)
                    {
                        Console.WriteLine($"Cooking a {pizza.PizzaTopping.Name} pizza with a {pizza.PizzaBase.Name} base...");
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("That's not a number! try again:");
                }
            }
        }
    }
}

