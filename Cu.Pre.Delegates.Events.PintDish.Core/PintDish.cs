using System;

namespace Cu.Pre.Delegates.Events.Core
{
    public class PintDish
    {
        public int PintCount { get; private set; }
        public int MaxPints { get; }

        public PintDish(int maxPints)
        {
            MaxPints = maxPints;
        }

        public void AddPint()
        {
            if (PintCount >= MaxPints) throw new Exception("Dish full, no more pints for you!");
            PintCount++;
        }
    }
}