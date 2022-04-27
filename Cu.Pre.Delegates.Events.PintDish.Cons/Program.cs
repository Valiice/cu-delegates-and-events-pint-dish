using System;
using Cu.Pre.Delegates.Events.Core;

namespace Cu.Pre.Delegates.Events.Cons
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }

        public void Run()
        {
            int numberOfPints = 10;
            PintDish pintDish = new PintDish(numberOfPints);
            pintDish.DishStarted += PintDish_DishStarted;
            pintDish.DishCompleted += PintDish_DishCompleted;
            pintDish.PintStarted += PintDish_PintStarted;
            pintDish.PintCompleted += PintDish_PintCompleted;

            pintDish.StartDish();
            for (int i = 0; i < numberOfPints; i++)
            {
                try
                {
                    pintDish.AddPint();
                    Console.WriteLine($"Pint {pintDish.PintCount} added");
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                }
            }

            Console.ReadLine();
        }

        private void PintDish_DishCompleted(object sender, DishCompletedArgs e)
        {
            throw new NotImplementedException();
        }

        private void PintDish_DishStarted(object sender, DishStartedArgs e)
        {
            throw new NotImplementedException();
        }

        private void PintDish_PintCompleted(object sender, PintCompletedArgs e)
        {
            Console.WriteLine($"{e.Brand} brewed by {e.Waiter}, cheers!");
        }

        private void PintDish_PintStarted(object sender, EventArgs e)
        {
            Console.WriteLine($"Brewing a new pint...");
        }
    }
}
