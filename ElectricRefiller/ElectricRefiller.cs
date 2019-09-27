using System;


namespace ElectricRefiller
{
    public class ElectricRefiller: IRefiller.IRefiller
    {
        public Ingredients.Ingredients Refill(double water, double milk, int coffee, int chocolate)
        {
            Console.WriteLine("refilling machine electrically");
            
            return new Ingredients.Ingredients(coffee, water, milk, chocolate);
        }
    }
}