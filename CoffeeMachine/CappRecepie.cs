using System.Collections.Generic;

namespace CoffeeMachine
{
    public class CappRecepie: Recipe
    {

        public CappRecepie(Ingredients ingredients) : base(ingredients)
        {
            Steps.Add(new PourWaterStep(ingredients.Water));
            Steps.Add(new PourMilkStep(ingredients.Milk));
        }
    }
}