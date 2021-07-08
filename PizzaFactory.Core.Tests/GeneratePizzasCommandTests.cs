using System.Collections.Generic;
using FakeItEasy;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using PizzaFactory.Core.Commands;
using PizzaFactory.Core.ConfigValues.Interfaces;
using PizzaFactory.Core.Generator;
using PizzaFactory.Data;
using PizzaFactory.Data.Repositories;

namespace PizzaFactory.Core.Tests
{
    public class GeneratePizzasCommandTests
    {
        private IPizzaRepository repository;
        private IRandomPizzaGenerator randomPizzaGenerator;
        private ICookingInterval cookingInterval;
        private ILogger<GeneratePizzasCommand> logger;
        private GeneratePizzasCommand sut;

        [SetUp]
        public void SetUp()
        {
            repository = A.Fake<IPizzaRepository>();
            randomPizzaGenerator = A.Fake<IRandomPizzaGenerator>();
            cookingInterval = A.Fake<ICookingInterval>();
            logger = A.Fake<ILogger<GeneratePizzasCommand>>();

            sut = new GeneratePizzasCommand(repository, randomPizzaGenerator, cookingInterval, logger);
        }

        [Test]
        public void RepositoryAdd_IsCalledWithCorrectInputs()
        {
            // Arrange
            const int numberOfPizzas = 3;

            const int baseCookingTime = 500;

            var randomPizzas = new List<Pizza>
            {
                new Pizza("Pepperoni", "DeepPan", "2", baseCookingTime),
                new Pizza("HamAndMushroom", "ThinAndCrispy", "1", baseCookingTime),
                new Pizza("Vegetable", "StuffedCrust", "1.5", baseCookingTime)
            };

            A.CallTo(() => randomPizzaGenerator.GeneratePizzas(numberOfPizzas))
                .Returns(randomPizzas);

            // Act
            var resultIterator = sut.Execute(numberOfPizzas).GetEnumerator();
            resultIterator.MoveNext();
            resultIterator.MoveNext();
            resultIterator.MoveNext();
            resultIterator.MoveNext();

            // Assert
            A.CallTo(() => repository.Add(randomPizzas[0])).MustHaveHappenedOnceExactly();
            A.CallTo(() => repository.Add(randomPizzas[1])).MustHaveHappenedOnceExactly();
            A.CallTo(() => repository.Add(randomPizzas[2])).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void CorrectModelsAreReturned()
        {
            // Arrange
            const int numberOfPizzas = 3;

            const int baseCookingTime = 100;

            var randomPizzas = new List<Pizza>
            {
                new Pizza("Pepperoni", "DeepPan", "2", baseCookingTime),
                new Pizza("HamAndMushroom", "ThinAndCrispy", "1", baseCookingTime),
                new Pizza("Vegetable", "StuffedCrust", "1.5", baseCookingTime)
            };

            A.CallTo(() => randomPizzaGenerator.GeneratePizzas(numberOfPizzas))
                .Returns(randomPizzas);

            // Act
            var resultIterator = sut.Execute(numberOfPizzas).GetEnumerator();
            resultIterator.MoveNext();
            var result1 = resultIterator.Current;
            resultIterator.MoveNext();
            var result2 = resultIterator.Current;
            resultIterator.MoveNext();
            var result3 = resultIterator.Current;

            // Assert
            Assert.That(result1.CookingTime, Is.EqualTo(1100));
            Assert.That(result1.PizzaBase, Is.EqualTo("DeepPan"));
            Assert.That(result1.PizzaTopping, Is.EqualTo("Pepperoni"));

            Assert.That(result2.CookingTime, Is.EqualTo(1500));
            Assert.That(result2.PizzaBase, Is.EqualTo("ThinAndCrispy"));
            Assert.That(result2.PizzaTopping, Is.EqualTo("HamAndMushroom"));

            Assert.That(result3.CookingTime, Is.EqualTo(1050));
            Assert.That(result3.PizzaBase, Is.EqualTo("StuffedCrust"));
            Assert.That(result3.PizzaTopping, Is.EqualTo("Vegetable"));
        }
    }
}
