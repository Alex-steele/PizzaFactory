namespace PizzaFactory.Core.ConfigValues
{
    public class DynamicCookingInterval
    {
        public DynamicCookingInterval()
        {
            Interval = 0;
            Message = "Dynamic interval";
        }

        public int Interval { get; }

        public string Message { get; }
    }
}
