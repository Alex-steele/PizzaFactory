using System;
using System.Collections.Generic;
using PizzaFactory.Data;

namespace PizzaFactory.Core
{
    public class RandomPizzaGenerator : IRandomPizzaGenerator
    {
        private readonly double baseCookingTime;

        public RandomPizzaGenerator(double baseCookingTime)
        {
            this.baseCookingTime = baseCookingTime;
        }

        public IEnumerable<Pizza> GeneratePizzas(int numberOfPizzas)
        {
            var pizzas = new List<Pizza>();

            var toppings = Enum.GetNames(typeof(PizzaTopping));
            var bases = Enum.GetNames(typeof(PizzaBase));

            var random = new Random();

            for (var i = 0; i < numberOfPizzas; i++)
            {
                var randomTopping = (PizzaTopping)Enum.Parse(typeof(PizzaTopping), toppings.GetValue(random.Next(toppings.Length)).ToString());

                var randomBase = (PizzaBase)Enum.Parse(typeof(PizzaBase), bases.GetValue(random.Next(bases.Length)).ToString());

                pizzas.Add(new Pizza(randomTopping, randomBase, baseCookingTime));
            }

            return pizzas;
        }
    }
}
