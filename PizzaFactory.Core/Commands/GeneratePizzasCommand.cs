using System.Collections.Generic;
using System.Threading;
using Microsoft.Extensions.Logging;
using PizzaFactory.Core.ConfigValues.Interfaces;
using PizzaFactory.Core.Generator;
using PizzaFactory.Core.Mappers;
using PizzaFactory.Core.Models;
using PizzaFactory.Data.Repositories;

namespace PizzaFactory.Core.Commands
{
    public class GeneratePizzasCommand : IGeneratePizzasCommand
    {
        private readonly IPizzaRepository repository;
        private readonly IRandomPizzaGenerator randomPizzaGenerator;
        private readonly ICookingInterval cookingInterval;
        private readonly ILogger<GeneratePizzasCommand> logger;
        private readonly PizzaMapper mapper;

        public GeneratePizzasCommand(
            IPizzaRepository repository,
            IRandomPizzaGenerator randomPizzaGenerator,
            ICookingInterval cookingInterval,
            ILogger<GeneratePizzasCommand> logger)
        {
            this.repository = repository;
            this.randomPizzaGenerator = randomPizzaGenerator;
            this.cookingInterval = cookingInterval;
            this.logger = logger;
            mapper = new PizzaMapper();
        }

    
    
        public IEnumerable<PizzaModel> Execute(int numberOfPizzas)
        {
            logger.LogInformation($"Calling execute in GeneratePizzasCommand with {numberOfPizzas} pizzas");

            var pizzas = randomPizzaGenerator.GeneratePizzas(numberOfPizzas);

            foreach (var pizza in pizzas)
            {
                var pizzaModel = mapper.Map(pizza);

                yield return pizzaModel;

                var timeToSleep = CalculateTimeToSleep(pizza.CookingTime, cookingInterval.Interval);

                Thread.Sleep(timeToSleep);

                repository.Add(pizza);
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