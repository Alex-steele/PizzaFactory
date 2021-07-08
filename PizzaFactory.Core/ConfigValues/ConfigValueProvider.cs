using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using PizzaFactory.Core.ConfigValues.Interfaces;

namespace PizzaFactory.Core.ConfigValues
{
    public class ConfigValueProvider : IConfigValueProvider
    {
        public ConfigValueProvider(IConfiguration config)
        {
            PizzaToppings = config.GetSection("PizzaToppings").Get<List<string>>();

            PizzaBasesWithMultipliers = config.GetSection("PizzaBasesWithMultipliers").Get<Dictionary<string,string>>();

            BaseCookingTime = config.GetValue<int>("BaseCookingTime");
        }

        public IEnumerable<string> PizzaToppings { get; }

        public Dictionary<string, string> PizzaBasesWithMultipliers { get; }

        public int BaseCookingTime { get; }
    }
}
