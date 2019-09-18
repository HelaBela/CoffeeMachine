using System;
 
 
 namespace Refiller
 {
     public class SolarRefiller: IRefiller.IRefiller
     {
         public Ingredients.Ingredients Refill(double water, double milk, int coffee, int chocolate)
         {
             Console.WriteLine("refilling machine with sun");
             
             return new Ingredients.Ingredients(coffee, water, milk, chocolate);
         }
     }
 }