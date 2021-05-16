using System.Collections.Generic;
using PizzaFactory.Data;

namespace PizzaFactory.Core.Generator
{
    public interface IRandomPizzaGenerator
    {
        IEnumerable<Pizza> GeneratePizzas(int numberOfPizzas);
    }
}
