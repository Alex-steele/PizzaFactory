namespace PizzaFactory.Data
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
