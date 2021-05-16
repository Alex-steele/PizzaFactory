using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.Extensions.Logging;
using PizzaFactory.Core.Generator;
using PizzaFactory.Core.Mappers;
using PizzaFactory.Core.Models;
using PizzaFactory.Data;

namespace PizzaFactory.Core.Commands
{
    public class GeneratePizzasCommand : IGeneratePizzasCommand
    {
        private readonly ILogger<GeneratePizzasCommand> logger;
        private readonly IRandomPizzaGenerator randomPizzaGenerator;
        private readonly ICookingInterval cookingInterval;
        private readonly PizzaMapper mapper;

        public GeneratePizzasCommand(ILogger<GeneratePizzasCommand> logger, IRandomPizzaGenerator randomPizzaGenerator, ICookingInterval cookingInterval)
        {
            this.logger = logger;
            this.randomPizzaGenerator = randomPizzaGenerator;
            this.cookingInterval = cookingInterval;
            mapper = new PizzaMapper();
        }

        public IEnumerable<PizzaModel> Execute(int numberOfPizzas)
        {
            var result = randomPizzaGenerator.GeneratePizzas(numberOfPizzas);

            var pizzas = result.Select(x => mapper.Map(x));

            foreach (var pizza in pizzas)
            {
                yield return pizza;

                var timeToSleep = CalculateTimeToSleep(pizza.CookingTime, cookingInterval.Interval);

                Thread.Sleep(timeToSleep);

                logger.LogInformation($"{pizza.PizzaTopping.Name} pizza with a {pizza.PizzaBase.Name} base");
            }
        }

        private int CalculateTimeToSleep(int cookingTime, int interval)
        {
            if (interval <= 0)
            {
                return cookingTime;
            }

            return cookingTime < interval
                    ? interval
                    : cookingTime + interval - (cookingTime % interval);
        }
    }
}