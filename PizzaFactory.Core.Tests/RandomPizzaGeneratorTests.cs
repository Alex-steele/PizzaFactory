using FakeItEasy;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using PizzaFactory.Core.Generator;
using PizzaFactory.Core.ConfigValues.Interfaces;
using System.Collections.Generic;

namespace PizzaFactory.Core.Tests
{
    public class RandomPizzaGeneratorTests
    {
        [Test]
        public void GeneratePizzas_ReturnsCorrectNumberOfPizzas()
        {
            // Arrange
            var logger = A.Fake<ILogger<RandomPizzaGenerator>>();
            var config = A.Fake<IConfigValueProvider>();

            var PizzaToppings = new List<string>
            {
                "Pepperoni",
                "HamAndMushroom",
                "Vegetable"
            };

            var PizzaBasesWithMultipliers = new Dictionary<string, string>
            {
                { "DeepPan", "2" },
                { "StuffedCrust", "1.5" },
                { "ThinAndCrispy", "1" },
            };

            var baseCookingTime = 200;

            A.CallTo(() => config.PizzaToppings)
                .Returns(PizzaToppings);

            A.CallTo(() => config.PizzaBasesWithMultipliers)
                .Returns(PizzaBasesWithMultipliers);

            A.CallTo(() => config.BaseCookingTime)
                .Returns(baseCookingTime);

            const int amountOfPizzas = 3;

            var generator = new RandomPizzaGenerator(config, logger);

            // Act
            var result = generator.GeneratePizzas(amountOfPizzas);

            // Assert
            Assert.That(result.Count, Is.EqualTo(amountOfPizzas));
        }
    }
}
