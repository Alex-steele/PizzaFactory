using PizzaFactory.Data.PizzaBases;
using PizzaFactory.Data.PizzaToppings;

namespace PizzaFactory.Core.Models
{
    public class PizzaModel
    {
        public PizzaModel(
            IPizzaTopping pizzaTopping,
            IPizzaBase pizzaBase,
            int baseCookingTime,
            int cookingTime)
        {
            PizzaTopping = pizzaTopping;
            PizzaBase = pizzaBase;
            BaseCookingTime = baseCookingTime;
            CookingTime = cookingTime;
        }

        public IPizzaTopping PizzaTopping { get; }

        public IPizzaBase PizzaBase { get; }

        public int BaseCookingTime { get; }

        public int CookingTime { get; }
    }
}
