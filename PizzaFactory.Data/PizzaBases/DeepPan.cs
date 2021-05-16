namespace PizzaFactory.Data.PizzaBases
{
    public class DeepPan : IPizzaBase
    {
        public DeepPan()
        {
            Name = "Deep Pan";
            Multiplier = 2;
        }

        public string Name { get; }

        public double Multiplier { get; }
    }
}
