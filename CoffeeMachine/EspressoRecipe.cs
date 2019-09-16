namespace CoffeeMachine
{
    public class EspressoRecipe:Recipe
    
    {
        public EspressoRecipe(Ingredients ingredients) : base(ingredients)
        {
            Steps.Add(new GrindCoffee(ingredients.CoffeeBeans));
            Steps.Add(new PourWaterStep(ingredients.Water));
        }
    }
}