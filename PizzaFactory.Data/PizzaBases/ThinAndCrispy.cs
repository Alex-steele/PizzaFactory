namespace PizzaFactory.Data.PizzaBases
{
    public class ThinAndCrispy : IPizzaBase
    {
        public ThinAndCrispy()
        {
            Name = "Thin and Crispy";
            Multiplier = 1;
        }

        public string Name { get; }

        public double Multiplier { get; }
    }
}
