﻿namespace PizzaFactory.Core
{
    public class CookingInterval : ICookingInterval
    {
        public CookingInterval(int interval)
        {
            Interval = interval;
        }

        public int Interval { get; set; }
    }
}