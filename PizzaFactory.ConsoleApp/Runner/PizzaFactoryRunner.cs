using System;
using PizzaFactory.Core.Commands;
using PizzaFactory.Core.ConfigValues.Interfaces;

namespace PizzaFactory.ConsoleApp.Runner
{
    public class PizzaFactoryRunner : IPizzaFactoryRunner
    {
        private readonly IGeneratePizzasCommand generatePizzasCommand;
        private readonly ICookingInterval cookingInterval;

        public PizzaFactoryRunner(IGeneratePizzasCommand generatePizzasCommand, ICookingInterval cookingInterval)
        {
            this.generatePizzasCommand = generatePizzasCommand;
            this.cookingInterval = cookingInterval;
        }

        public void Run()
        {
            Console.WriteLine("\nGreat! Now enter the amount of pizzas you would like:");

            while (true)
            {
                var numberOfPizzasString = Console.ReadLine();

                if (int.TryParse(numberOfPizzasString, out var numberOfPizzas))
                {
                    Console.WriteLine($"\nCooking {numberOfPizzas} pizzas with a {cookingInterval.Message}\n");

                    var result = generatePizzasCommand.Execute(numberOfPizzas);

                    foreach (var pizza in result)
                    {
                        Console.WriteLine($"Cooking a {pizza.PizzaTopping.Name} pizza with a {pizza.PizzaBase.Name} base..." +
                            $"\n Pizza cooking time: {pizza.CookingTime}ms");
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

