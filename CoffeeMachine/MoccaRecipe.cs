namespace CoffeeMachine
{
    public class MoccaRecipe: Recipe 
    {
        public MoccaRecipe(Ingredients ingredients) : base(ingredients)
        {
            Steps.Add(new GrindCoffee(ingredients.CoffeeBeans));
            Steps.Add(new AddChocolate(ingredients.Chocolate));
            Steps.Add(new PourWaterStep(ingredients.Water));
            Steps.Add(new PourMilkStep(ingredients.Milk));
           
            
        }
    }
}