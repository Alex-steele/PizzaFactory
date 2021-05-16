namespace PizzaFactory.Data.PizzaToppings
{
    public class Vegetable : AbstractPizzaTopping, IPizzaTopping
    {
        public Vegetable()
        {
            Name = "Vegetable";
            CookingTime = CalculateCookingTime();
        }

        public override string Name { get; }

        public override int CookingTime { get; }
    }
}
