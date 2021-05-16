using Microsoft.Extensions.Logging;

namespace PizzaFactory.Data.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly ILogger<PizzaRepository> logger;

        public PizzaRepository(ILogger<PizzaRepository> logger)
        {
            this.logger = logger;
        }

        public void Add(Pizza pizza)
        {
            logger.LogInformation($"{pizza.PizzaTopping.Name} pizza with a {pizza.PizzaBase.Name} base");
        }
    }
}
