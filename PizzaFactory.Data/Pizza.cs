using System;

namespace PizzaFactory.Data
{
    public class Pizza
    {
        public Pizza(PizzaTopping pizzaTopping, PizzaBase pizzaBase, int baseCookingTime)
        {
            PizzaTopping = pizzaTopping;
            PizzaBase = pizzaBase;
            BaseCookingTime = baseCookingTime;

            CookingTime = CalculateCookingTime();
        }

        public PizzaTopping PizzaTopping { get; }

        public PizzaBase PizzaBase { get; }

        public int BaseCookingTime { get; }

        public int CookingTime { get; }

        private int CalculateCookingTime()
        {
            double cookingTimeDouble = BaseCookingTime;

            cookingTimeDouble *= PizzaBase switch
            {
                PizzaBase.DeepPan => 2,
                PizzaBase.StuffedCrust => 1.5,
                PizzaBase.ThinAndCrispy => 1,
                _ => throw new NotImplementedException(nameof(PizzaBase)),
            };

            var cookingTime = (int)cookingTimeDouble;

            foreach (var character in PizzaTopping.ToString())
            {
                cookingTime += 100;
            }

            return cookingTime;
        }
    }
}
