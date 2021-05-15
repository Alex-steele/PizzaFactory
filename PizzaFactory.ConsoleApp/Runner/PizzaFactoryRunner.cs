using System;
using PizzaFactory.Core;

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
                    generatePizzasCommand.Execute(numberOfPizzas);
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
