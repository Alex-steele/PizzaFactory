using System;
using PizzaFactory.Core;

namespace PizzaFactory.ConsoleApp.Runner
{
    public class PizzaFactoryRunner : IPizzaFactoryRunner
    {
        private readonly IRandomPizzaGenerator generator;

        public PizzaFactoryRunner(IRandomPizzaGenerator generator)
        {
            this.generator = generator;
        }


        public void Run()
        {
            Console.WriteLine("Preparing your pizzas");

            var result = generator.GeneratePizzas(50);

            foreach(var pizza in result)
            {
                Console.WriteLine($"{pizza.PizzaTopping} pizza with a {pizza.PizzaBase} base");
            }

        }
    }
}
