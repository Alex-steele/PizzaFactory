using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PizzaFactory.Core.Commands;
using PizzaFactory.Data.PizzaToppings;

namespace PizzaFactory.ConsoleApp.Runner
{
    public class PizzaFactoryRunner : IPizzaFactoryRunner
    {
        private readonly IGeneratePizzasCommand generatePizzasCommand;
        private readonly IEnumerable<IPizzaTopping> toppings;

        public PizzaFactoryRunner(IGeneratePizzasCommand generatePizzasCommand, IEnumerable<IPizzaTopping> toppings)
        {
            this.generatePizzasCommand = generatePizzasCommand;
            this.toppings = toppings;
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
