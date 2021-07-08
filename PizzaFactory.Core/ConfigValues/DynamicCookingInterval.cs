using PizzaFactory.Core.ConfigValues.Interfaces;

namespace PizzaFactory.Core.ConfigValues
{
    public class DynamicCookingInterval : ICookingInterval
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
