using Microsoft.Extensions.Logging;
using PizzaFactory.Core;

namespace PizzaFactory.ConsoleApp.Runner
{
    public class PizzaFactoryRunner : IPizzaFactoryRunner
    {
        private readonly ILogger<PizzaFactoryRunner> logger;
        private readonly IGeneratePizzasCommand generatePizzasCommand;

        public PizzaFactoryRunner(ILogger<PizzaFactoryRunner> logger, IGeneratePizzasCommand generatePizzasCommand)
        {
            this.logger = logger;
            this.generatePizzasCommand = generatePizzasCommand;
        }


        public void Run()
        {
            logger.LogInformation("Welcome to Pizza factory!");

            logger.LogInformation("Preparing your pizzas");

            generatePizzasCommand.Execute(10);
        }
    }
}
