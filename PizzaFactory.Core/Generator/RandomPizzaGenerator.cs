﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using PizzaFactory.Core.ConfigValues.Interfaces;
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
        private readonly ILogger<RandomPizzaGenerator> logger;

        public RandomPizzaGenerator(IBaseCookingTime baseCookingTime,
            IEnumerable<IPizzaBase> pizzaBases,
            IEnumerable<IPizzaTopping> pizzaToppings,
            ILogger<RandomPizzaGenerator> logger)
        {
            this.baseCookingTime = baseCookingTime;
            this.pizzaBases = pizzaBases;
            this.pizzaToppings = pizzaToppings;
            this.logger = logger;
        }

        public IEnumerable<Pizza> GeneratePizzas(int numberOfPizzas)
        {
            logger.LogInformation("Generating random pizzas");

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
