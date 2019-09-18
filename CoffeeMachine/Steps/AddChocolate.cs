using System;

namespace CoffeeMachine
{
    public class AddChocolate: IStep
    {
        public AddChocolate(int chocolate)
        {
            Chocolate = chocolate;
        }

        public int Chocolate { get; }

        public void Execute()
        {
            Console.WriteLine($"adding {Chocolate} grams of chocolate");
        }
    }
}