using PizzaFactory.Core.Models;
using PizzaFactory.Data;

namespace PizzaFactory.Core.Mappers
{
    public class PizzaMapper
    {
        public PizzaModel Map(Pizza pizza)
        {
            return new PizzaModel(
                pizza.PizzaTopping,
                pizza.PizzaBase,
                pizza.BaseCookingTime,
                pizza.CookingTime
                );
        }
    }
}
