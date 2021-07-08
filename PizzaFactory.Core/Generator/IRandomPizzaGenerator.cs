using System.Collections.Generic;
using PizzaFactory.Data;

namespace PizzaFactory.Core.Generator
{
    public interface IRandomPizzaGenerator
    {
        ICollection<Pizza> GeneratePizzas(int numberOfPizzas);
    }
}