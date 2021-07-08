using System.Linq;


namespace PizzaFactory.Data
{
    public class Pizza
    {
        public Pizza(string pizzaTopping, string pizzaBase, string pizzaBaseMultiplier, int baseCookingTime)
        {
            PizzaTopping = pizzaTopping;
            PizzaBase = pizzaBase;
            PizzaBaseMultiplier = double.Parse(pizzaBaseMultiplier);
            BaseCookingTime = baseCookingTime;

            CookingTime = CalculateCookingTime();
        }

        public string PizzaTopping { get; }

        public string PizzaBase { get; }

        public double PizzaBaseMultiplier { get; }

        public int BaseCookingTime { get; }

        public int CookingTime { get; }

        private int CalculateCookingTime() =>
            (int)((BaseCookingTime * PizzaBaseMultiplier) + (string.Concat(PizzaTopping.Where(c => char.IsLetter(c))).Length * 100));
    }
}
