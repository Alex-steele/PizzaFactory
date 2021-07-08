using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using PizzaFactory.Core.ConfigValues.Interfaces;
using PizzaFactory.Data;

namespace PizzaFactory.Core.Generator
{
    public class RandomPizzaGenerator : IRandomPizzaGenerator
    {
        private readonly IConfigValueProvider config;
        private readonly ILogger<RandomPizzaGenerator> logger;

        public RandomPizzaGenerator(
            IConfigValueProvider config,
            ILogger<RandomPizzaGenerator> logger)
        {
            this.config = config;
            this.logger = logger;
        }


        public ICollection<Pizza> GeneratePizzas(int numberOfPizzas)
        {
            logger.LogInformation("Generating random pizzas");

            var pizzaToppings = config.PizzaToppings;

            var pizzaBasesWithMultipliers = config.PizzaBasesWithMultipliers;

            var pizzas = new List<Pizza>();

            var random = new Random();

            for (var i = 0; i < numberOfPizzas; i++)
            {
                var randomTopping = pizzaToppings.ElementAt(random.Next(pizzaToppings.Count()));

                var randomBase = pizzaBasesWithMultipliers.ElementAt(random.Next(pizzaBasesWithMultipliers.Count()));

                var randomBaseName = randomBase.Key;

                var randomBaseMultiplier = randomBase.Value;

                pizzas.Add(new Pizza(randomTopping, randomBaseName, randomBaseMultiplier, config.BaseCookingTime));
            }

            return pizzas;
        }
    }
}
