namespace PizzaFactory.Core
{
    public interface IGeneratePizzasCommand
    {
        void Execute(int numberOfPizzas);
    }
}