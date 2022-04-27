using System;
using Cu.Pre.Delegates.Events.Core;

namespace Cu.Pre.Delegates.Events.Cons
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.Run();
        }

        public void Run()
        {
            int numberOfPints = 10;
            var pintDish = new PintDish(numberOfPints);
            pintDish.PintStarted += PintDish_PintStarted;

            for (int i = 0; i < numberOfPints; i++)
            {
                try
                {
                    pintDish.AddPint();
                    Console.WriteLine($"Pint {pintDish.PintCount} added to dish");
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                }
            }

            Console.ReadLine();
        }

        private void PintDish_PintStarted(object sender, EventArgs e)
        {
            Console.WriteLine($"Brewing a new pint...");
        }
    }
}
