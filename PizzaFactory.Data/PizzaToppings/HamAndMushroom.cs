namespace PizzaFactory.Data.PizzaToppings
{
    public class HamAndMushroom : AbstractPizzaTopping, IPizzaTopping
    {
        public HamAndMushroom()
        {
            Name = "Ham and Mushroom";
            CookingTime = CalculateCookingTime();
        }

        public override string Name { get; }

        public override int CookingTime { get; }
    }
}
