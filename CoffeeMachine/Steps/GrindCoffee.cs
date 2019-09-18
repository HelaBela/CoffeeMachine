using System;

namespace CoffeeMachine
{
    public class GrindCoffee:IStep
    {
        public int CoffeeBeans { get; }

        public GrindCoffee(int coffeeBeans)
        {
            CoffeeBeans = coffeeBeans;
        }

        public void Execute()
        {
            Console.WriteLine($"grinding {CoffeeBeans} coffee beans");
        }
    }
}