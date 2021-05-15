using System.Collections.Generic;
using PizzaFactory.Data;

namespace PizzaFactory.Core
{
    public interface IRandomPizzaGenerator
    {
        IEnumerable<Pizza> GeneratePizzas(int numberOfPizzas);
    }
}
