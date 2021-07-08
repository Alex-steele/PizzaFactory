using System.Collections.Generic;

namespace PizzaFactory.Core.ConfigValues.Interfaces
{
    public interface IConfigValueProvider
    {
        IEnumerable<string> PizzaToppings { get; }

        Dictionary<string, string> PizzaBasesWithMultipliers { get; }

        int BaseCookingTime { get; }
    }
}