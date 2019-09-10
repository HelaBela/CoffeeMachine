using System;

namespace CoffeeMachine
{
    public class PourWaterStep : IStep
    {
        private double Water { get; }

        public PourWaterStep(double water)
        {
            Water = water;
        }

        public void Execute()
        {
            Console.WriteLine($"pouring {Water} liters of water");
        }
    }
}