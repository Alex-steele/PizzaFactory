using System.Collections.Generic;
using PizzaFactory.Core.Models;

namespace PizzaFactory.Core.Commands
{
    public interface IGeneratePizzasCommand
    {
        IEnumerable<PizzaModel> Execute(int numberOfPizzas);
    }
}