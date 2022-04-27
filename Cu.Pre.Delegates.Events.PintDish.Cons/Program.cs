﻿using System;
using Cu.Pre.Delegates.Events.Core;

namespace Cu.Pre.Delegates.Events.Cons
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPints = 10;
            var pintDish = new PintDish(numberOfPints);

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
    }
}
