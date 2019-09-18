namespace CoffeeMachine
{
    public class LatteRecipe: Recipe
    {
        public LatteRecipe(Ingredients ingredients) : base(ingredients)
        {
            Steps.Add(new GrindCoffee(ingredients.CoffeeBeans));
            Steps.Add(new PourWaterStep(ingredients.Water));
            Steps.Add(new PourMilkStep(ingredients.Milk));
          
        }
    }
}