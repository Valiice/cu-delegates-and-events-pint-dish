using System;

namespace Cu.Pre.Delegates.Events.Core
{
    public delegate void PintStartedHandler(object sender, EventArgs e);
    public delegate void PintCompletedHandler(object sender, PintCompletedArgs e);
    public delegate void DishStartedHandler(object sender, DishStartedArgs e);
    public delegate void DishHalfwayHandler(object sender, DishHalfwayArgs e);
    public delegate void DishCompletedHandler(object sender, DishCompletedArgs e);

    public class PintDish
    {
        public event PintStartedHandler PintStarted;
        public event PintCompletedHandler PintCompleted;
        public event DishStartedHandler DishStarted;
        public event DishHalfwayHandler DishHalfway;
        public event DishCompletedHandler DishCompleted;
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
            PintCompleted?.Invoke(this, new PintCompletedArgs());
            double halfPints = Math.Ceiling(MaxPints / 2d);
            DishHalfway.Invoke(this, new DishHalfwayArgs(MaxPints, PintCount));
            if (PintCount == halfPints)
            {

            }
        }

        public void StartDish()
        {

            DishCompleted?.Invoke(this, new DishCompletedArgs());
        }
    }
}