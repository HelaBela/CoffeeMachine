using System.Collections.Generic;

namespace CoffeeMachine
{
    
    public class CappRecipe: Recipe
    {

        public CappRecipe(Ingredients.Ingredients ingredients) : base(ingredients)
        {
            Steps.Add(new PourWaterStep(ingredients.Water));
            Steps.Add(new PourMilkStep(ingredients.Milk));
            Steps.Add(new GrindCoffee(ingredients.CoffeeBeans));
            Steps.Add(new AddChocolate(ingredients.Chocolate));
        }
    }
}