using System;

namespace CoffeeMachine
{
    public class PourMilkStep: IStep
    {
        public PourMilkStep(double milk)
        {
            Milk = milk;
        }

        private double Milk {  get; }
      

        public void Execute()
        {
            Console.WriteLine($"pouring {Milk} liters of milk");
        }
    }
}