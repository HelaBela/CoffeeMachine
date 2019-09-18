namespace CoffeeMachine
{
    public class LongBlackRecipe: Recipe
    {
        public LongBlackRecipe(Ingredients.Ingredients ingredients) : base(ingredients)
        {
            Steps.Add(new PourWaterStep(ingredients.Water));
            Steps.Add(new GrindCoffee(ingredients.CoffeeBeans));
        }
    }
}