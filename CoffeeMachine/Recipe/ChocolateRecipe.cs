namespace CoffeeMachine
{
    public class ChocolateRecipe: Recipe
    {
        public ChocolateRecipe(Ingredients.Ingredients ingredients) : base(ingredients)
        {
            Steps.Add(new AddChocolate(ingredients.Chocolate));
            Steps.Add(new PourMilkStep(ingredients.Milk));
           
        }
    }
}