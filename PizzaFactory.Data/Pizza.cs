using System;

namespace PizzaFactory.Data
{
    public class Pizza
    {
        public Pizza(PizzaTopping pizzaTopping, PizzaBase pizzaBase, double baseCookingTime)
        {
            PizzaTopping = pizzaTopping;
            PizzaBase = pizzaBase;
            BaseCookingTime = baseCookingTime;

            CookingTime = CalculateCookingTime();
        }

        public PizzaTopping PizzaTopping { get; }

        public PizzaBase PizzaBase { get; }

        public double BaseCookingTime { get; }

        public double CookingTime { get; }

        private double CalculateCookingTime()
        {
            double cookingTime = BaseCookingTime;

            cookingTime *= PizzaBase switch
            {
                PizzaBase.DeepPan => 2,
                PizzaBase.StuffedCrust => 1.5,
                PizzaBase.ThinAndCrispy => 1,
                _ => throw new NotImplementedException(nameof(PizzaBase)),
            };

            foreach (var character in PizzaTopping.ToString())
            {
                cookingTime += 100;
            }

            return cookingTime;
        }
    }
}
