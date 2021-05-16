using PizzaFactory.Core.ConfigValues.Interfaces;

namespace PizzaFactory.Core.ConfigValues
{
    public class FixedCookingInterval : ICookingInterval
    {
        public FixedCookingInterval(int interval)
        {
            Interval = interval;
            Message = $"Fixed interval of {interval}ms";
        }

        public int Interval { get; }

        public string Message { get; }
    }
}
