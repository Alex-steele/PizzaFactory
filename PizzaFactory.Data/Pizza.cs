using System;
using PizzaFactory.Data.PizzaBases;
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

        //private int CalculateCookingTime()
        //{
        //    double cookingTimeDouble = BaseCookingTime;

        //    cookingTimeDouble *= PizzaBase switch
        //    {
        //        PizzaBase.DeepPan => 2,
        //        PizzaBase.StuffedCrust => 1.5,
        //        PizzaBase.ThinAndCrispy => 1,
        //        _ => throw new NotImplementedException(nameof(PizzaBase)),
        //    };

        //    var cookingTime = (int)cookingTimeDouble;

        //    foreach (var character in PizzaTopping.ToString())
        //    {
        //        cookingTime += 100;
        //    }

        //    return cookingTime;
        //}

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
