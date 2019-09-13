using System;

namespace CoffeeMachine
{
    public class Refiller
    {
        public void Refill(Ingredients ingredients, double water, double milk, int coffee, int chocolate)
        {
            Console.WriteLine("refilling machine");

            ingredients.Chocolate += chocolate;
            ingredients.Milk += milk;
            ingredients.Water += water;
            ingredients.CoffeeBeans += coffee;

            Console.WriteLine(
                $"Machine has now: {ingredients.Chocolate} grams of chocolate, {ingredients.Milk} liters of milk, {ingredients.Water} liters of water and {ingredients.CoffeeBeans} individual coffee beans");
        }
    }
}