﻿using PizzaFactory.Data.PizzaBases;
using PizzaFactory.Data.PizzaToppings;

namespace PizzaFactory.Data
{
    public class Pizza
    {
        public Pizza(IPizzaTopping pizzaTopping, IPizzaBase pizzaBase, int baseCookingTime)
        {
            PizzaTopping = pizzaTopping;
            PizzaBase = pizzaBase;
            BaseCookingTime = baseCookingTime;

            CookingTime = CalculateCookingTime();
        }

        public IPizzaTopping PizzaTopping { get; }

        public IPizzaBase PizzaBase { get; }

        public int BaseCookingTime { get; }

        public int CookingTime { get; }

        private int CalculateCookingTime()
        {
            double cookingTimeDouble = BaseCookingTime;

            cookingTimeDouble *= PizzaBase.Multiplier;

            var cookingTime = (int)cookingTimeDouble;

            cookingTime += PizzaTopping.CookingTime;

            return cookingTime;
        }
    }
}
