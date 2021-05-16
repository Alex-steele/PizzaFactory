using System;
using System.IO;
using Microsoft.Extensions.Logging;
using PizzaFactory.Data.ConfigValues;

namespace PizzaFactory.Data.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly IFilePathProvider provider;
        private readonly ILogger<PizzaRepository> logger;

        public PizzaRepository(IFilePathProvider provider, ILogger<PizzaRepository> logger)
        {
            this.provider = provider;
            this.logger = logger;
        }

        public void Add(Pizza pizza)
        {
            try
            {
                File.AppendAllText(provider.FilePath, $"{pizza.PizzaTopping.Name} pizza with a {pizza.PizzaBase.Name} base\n");
            }
            catch (Exception ex)
            {
                logger.LogError($"Saving pizza to file failed with error {ex}");

                throw new IOException($"An error occured while trying to write to the file with path name {provider.FilePath}", ex);
            }
        }
    }
}
