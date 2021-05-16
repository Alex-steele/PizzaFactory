using System;
using System.Threading;
using Microsoft.Extensions.Logging;
using PizzaFactory.Core.Generator;
using PizzaFactory.Data;

namespace PizzaFactory.Core.Commands
{
    public class GeneratePizzasCommand : IGeneratePizzasCommand
    {
        private readonly ILogger<GeneratePizzasCommand> logger;
        private readonly IRandomPizzaGenerator randomPizzaGenerator;
        private readonly ICookingInterval cookingInterval;

        public GeneratePizzasCommand(ILogger<GeneratePizzasCommand> logger, IRandomPizzaGenerator randomPizzaGenerator, ICookingInterval cookingInterval)
        {
            this.logger = logger;
            this.randomPizzaGenerator = randomPizzaGenerator;
            this.cookingInterval = cookingInterval;
        }

        public void Execute(int numberOfPizzas)
        {
            var result = randomPizzaGenerator.GeneratePizzas(numberOfPizzas);

            foreach (var pizza in result)
            {
                Console.WriteLine($"Cooking a {pizza.PizzaTopping.Name} pizza with a {pizza.PizzaBase.Name} base." +
                    $"\n This will take {pizza.CookingTime}ms");

                Thread.Sleep(pizza.CookingTime);

                Console.WriteLine("Done, waiting for next interval...");

                var timeTillNextInterval = cookingInterval.Interval - pizza.CookingTime > 0
                    ? cookingInterval.Interval - pizza.CookingTime
                    : 0;

                Thread.Sleep(timeTillNextInterval);

                logger.LogInformation($"{pizza.PizzaTopping.Name} pizza with a {pizza.PizzaBase.Name} base");
            }
        }
    }
}
