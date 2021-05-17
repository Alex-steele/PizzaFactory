using System.Linq;

namespace PizzaFactory.Data.PizzaToppings
{
    public abstract class AbstractPizzaTopping
    {
        public abstract string Name { get; }

        public abstract int CookingTime { get; }

        protected int CalculateCookingTime()
        {
            var nameWithoutWhiteSpace = string.Concat(Name.Where(c => !char.IsWhiteSpace(c)));

            return nameWithoutWhiteSpace.Length * 100;
        }
    }
}
