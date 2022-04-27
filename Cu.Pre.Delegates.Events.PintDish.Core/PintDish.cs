using System;

namespace Cu.Pre.Delegates.Events.Core
{
    public delegate void PintStartedHandler(object sender, EventArgs e);

    public delegate void PintCompletedHandler(object sender, PintCompletedArgs e);

    public class PintDish
    {
        public event PintStartedHandler PintStarted;
        public event PintCompletedHandler PintCompleted;

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
        }
    }

    public class PintCompletedArgs : EventArgs
    {
        private static string[] Brands = { "Cara Pils", "Jupiler", "Stella Artois", "Bavik" };
        private static string[] Waiters = { "Jeff", "Carine", "Billy", "Julie" };
        public static Random random = new Random();

        public string Brand { get; }
        public string Waiter { get; }

        public PintCompletedArgs()
        {
            Brand = Brands[random.Next(0, Brands.Length)];
            Waiter = Waiters[random.Next(0, Waiters.Length)];
        }
    }
}