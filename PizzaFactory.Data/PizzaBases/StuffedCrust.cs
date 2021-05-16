namespace PizzaFactory.Data.PizzaBases
{
    public class StuffedCrust : IPizzaBase
    {
        public StuffedCrust()
        {
            Name = "Stuffed Crust";
            Multiplier = 1.5;
        }

        public string Name { get; }

        public double Multiplier { get; }
    }
}
