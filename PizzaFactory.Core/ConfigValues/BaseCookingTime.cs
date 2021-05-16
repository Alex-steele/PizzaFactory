using PizzaFactory.Core.ConfigValues.Interfaces;

namespace PizzaFactory.Core.ConfigValues
{
    public class BaseCookingTime : IBaseCookingTime
    {
        public BaseCookingTime(int time)
        {
            Time = time;
        }

        public int Time { get; }
    }
}
