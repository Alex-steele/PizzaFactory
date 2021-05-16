using System.Collections.Generic;
using System.Linq;
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
        private readonly PizzaMapper mapper;

        public GeneratePizzasCommand(IPizzaRepository repository, IRandomPizzaGenerator randomPizzaGenerator, ICookingInterval cookingInterval)
        {
            this.repository = repository;
            this.randomPizzaGenerator = randomPizzaGenerator;
            this.cookingInterval = cookingInterval;
            mapper = new PizzaMapper();
        }

        public IEnumerable<PizzaModel> Execute(int numberOfPizzas)
        {
            var pizzas = randomPizzaGenerator.GeneratePizzas(numberOfPizzas);

            foreach (var pizza in pizzas)
            {
                repository.Add(pizza);

                var pizzaModel = mapper.Map(pizza);

                yield return pizzaModel;

                var timeToSleep = CalculateTimeToSleep(pizza.CookingTime, cookingInterval.Interval);

                Thread.Sleep(timeToSleep);

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