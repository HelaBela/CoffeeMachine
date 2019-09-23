using System;

namespace Tests.mocks
{
    public class RefillerMock: IRefiller.IRefiller
    {
        public Ingredients.Ingredients Refill(double water, double milk, int coffee, int chocolate)
        {
            if (water < 0 || milk < 0 || coffee < 0 || chocolate <20)
            {
                Console.WriteLine("can't accept negative inputs.");
            }
            return new Ingredients.Ingredients(coffee, water,milk, chocolate);
        }
    }
}