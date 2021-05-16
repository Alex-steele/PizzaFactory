namespace PizzaFactory.Data.PizzaToppings
{
    public class Pepperoni : AbstractPizzaTopping, IPizzaTopping
    {
        public Pepperoni()
        {
            Name = "Pepperoni";
            CookingTime = CalculateCookingTime();
        }

        public override string Name { get; }

        public override int CookingTime { get; }
    }
}
