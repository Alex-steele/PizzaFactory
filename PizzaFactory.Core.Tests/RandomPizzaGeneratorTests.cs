using System.Collections.Generic;
using FakeItEasy;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using PizzaFactory.Core.ConfigValues.Interfaces;
using PizzaFactory.Core.Generator;
using PizzaFactory.Data.PizzaBases;
using PizzaFactory.Data.PizzaToppings;

namespace PizzaFactory.Core.Tests
{
    public class RandomPizzaGeneratorTests
    {

        [Test]
        public void GeneratePizzas_ReturnsCorrectNumberOfPizzas()
        {
            // Arrange
            var baseCookingTime = A.Fake<IBaseCookingTime>();
            var logger  = A.Fake<ILogger<RandomPizzaGenerator>>();

            const int amountOfPizzas = 3;

            var pizzaBases = new List<IPizzaBase>
            {
                new DeepPan(),
                new StuffedCrust(),
                new ThinAndCrispy()
            };

            var pizzaToppings = new List<IPizzaTopping>
            {
                new Pepperoni(),
                new HamAndMushroom(),
                new Vegetable()
            };

            var generator = new RandomPizzaGenerator(baseCookingTime, pizzaBases, pizzaToppings, logger);

            // Act
            var result = generator.GeneratePizzas(amountOfPizzas);

            // Assert
            Assert.That(result.Count, Is.EqualTo(amountOfPizzas));
        }
    }
}
