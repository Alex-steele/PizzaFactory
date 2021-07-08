namespace PizzaFactory.Core.Models
{
    public class PizzaModel
    {
        public PizzaModel(
            string pizzaTopping,
            string pizzaBase,
            int baseCookingTime,
            int cookingTime)
        {
            PizzaTopping = pizzaTopping;
            PizzaBase = pizzaBase;
            BaseCookingTime = baseCookingTime;
            CookingTime = cookingTime;
        }

        public string PizzaTopping { get; }

        public string PizzaBase { get; }

        public int BaseCookingTime { get; }

        public int CookingTime { get; }
    }
}
