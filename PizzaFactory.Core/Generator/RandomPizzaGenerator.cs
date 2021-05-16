using System;
using System.Collections.Generic;
using System.Linq;
using PizzaFactory.Data;
using PizzaFactory.Data.PizzaBases;
using PizzaFactory.Data.PizzaToppings;

namespace PizzaFactory.Core.Generator
{
    public class RandomPizzaGenerator : IRandomPizzaGenerator
    {
        private readonly IBaseCookingTime baseCookingTime;
        private readonly IEnumerable<IPizzaBase> pizzaBases;
        private readonly IEnumerable<IPizzaTopping> pizzaToppings;

        public RandomPizzaGenerator(IBaseCookingTime baseCookingTime, IEnumerable<IPizzaBase> pizzaBases, IEnumerable<IPizzaTopping> pizzaToppings)
        {
            this.baseCookingTime = baseCookingTime;
            this.pizzaBases = pizzaBases;
            this.pizzaToppings = pizzaToppings;
        }

        public IEnumerable<Pizza> GeneratePizzas(int numberOfPizzas)
        {
            var pizzas = new List<Pizza>();

            var random = new Random();

            for (var i = 0; i < numberOfPizzas; i++)
            {
                var randomTopping = pizzaToppings.ElementAt(random.Next(pizzaToppings.Count()));

                var randomBase = pizzaBases.ElementAt(random.Next(pizzaBases.Count()));

                pizzas.Add(new Pizza(randomTopping, randomBase, baseCookingTime.Time));
            }

            return pizzas;
        }
    }
}
