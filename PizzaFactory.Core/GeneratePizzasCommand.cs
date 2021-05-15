using System;
using Microsoft.Extensions.Logging;

namespace PizzaFactory.Core
{
    public class GeneratePizzasCommand : IGeneratePizzasCommand
    {
        private readonly ILogger<GeneratePizzasCommand> logger;
        private readonly IRandomPizzaGenerator randomPizzaGenerator;

        public GeneratePizzasCommand(ILogger<GeneratePizzasCommand> logger, IRandomPizzaGenerator randomPizzaGenerator)
        {
            this.logger = logger;
            this.randomPizzaGenerator = randomPizzaGenerator;
        }

        public void Execute(int numberOfPizzas)
        {
            var result = randomPizzaGenerator.GeneratePizzas(numberOfPizzas);

            foreach (var pizza in result)
            {
                logger.LogInformation($"{pizza.PizzaTopping} pizza with a {pizza.PizzaBase} base");
            }
        }
    }
}
