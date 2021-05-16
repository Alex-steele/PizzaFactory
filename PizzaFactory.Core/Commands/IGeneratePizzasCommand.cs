namespace PizzaFactory.Core.Commands
{
    public interface IGeneratePizzasCommand
    {
        void Execute(int numberOfPizzas);
    }
}