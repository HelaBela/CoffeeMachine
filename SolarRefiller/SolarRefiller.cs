using System;


namespace Refiller
{
    public class SolarRefiller : IRefiller.IRefiller
    {
        public Ingredients.Ingredients Refill(double water, double milk, int coffee, int chocolate)
        {
            if (water < 0 || milk < 0 || coffee < 0 || chocolate < 0)
            {
               Console.WriteLine("can't accept negative inputs.");
            }


            return new Ingredients.Ingredients(coffee, water, milk, chocolate);
        }
    }
}