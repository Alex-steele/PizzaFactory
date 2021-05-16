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
        //private readonly int baseCookingTime;

        //public RandomPizzaGenerator(int baseCookingTime)
        //{
        //    this.baseCookingTime = baseCookingTime;
        //}

        //public IEnumerable<Pizza> GeneratePizzas(int numberOfPizzas)
        //{
        //    var pizzas = new List<Pizza>();

        //    var toppings = Enum.GetNames(typeof(PizzaTopping));
        //    var bases = Enum.GetNames(typeof(PizzaBase));

        //    var random = new Random();

        //    for (var i = 0; i < numberOfPizzas; i++)
        //    {
        //        var randomTopping = (PizzaTopping)Enum.Parse(typeof(PizzaTopping), toppings.GetValue(random.Next(toppings.Length)).ToString());

        //        var randomBase = (PizzaBase)Enum.Parse(typeof(PizzaBase), bases.GetValue(random.Next(bases.Length)).ToString());

        //        pizzas.Add(new Pizza(randomTopping, randomBase, baseCookingTime));
        //    }

        //    return pizzas;
        //}

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

                //var randomBase = (PizzaBase)Enum.Parse(typeof(PizzaBase), bases.GetValue(random.Next(bases.Length)).ToString());

                pizzas.Add(new Pizza(randomTopping, randomBase, baseCookingTime.Time));
            }

            return pizzas;
        }
    }
}
