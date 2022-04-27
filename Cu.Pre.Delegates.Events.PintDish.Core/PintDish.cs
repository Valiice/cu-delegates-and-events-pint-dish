using System;

namespace Cu.Pre.Delegates.Events.Core
{
    public delegate void PintStartedHandler(object sender, EventArgs e);

    public class PintDish
    {
        public event PintStartedHandler PintStarted;
        public int PintCount { get; private set; }
        public int MaxPints { get; }

        public PintDish(int maxPints)
        {
            MaxPints = maxPints;
        }

        public void AddPint()
        {
            if (PintCount >= MaxPints) throw new Exception("Dish full, no more pints for you!");
            PintStarted?.Invoke(this, EventArgs.Empty);
            PintCount++;
        }
    }
}