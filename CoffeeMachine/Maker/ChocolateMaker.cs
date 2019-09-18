namespace CoffeeMachine
{
    public class ChocolteMaker: IBeverageMaker
    {
        Recipe _recipe;

        public ChocolteMaker()
        {
            _recipe = new ChocolateRecipe(new Ingredients.Ingredients(0,0,0.4,7));
        }

        public Beverage MakeBeverage()
        {
            foreach (var step in _recipe.Steps)
            {
                step.Execute();
            }
            
            return  new HotChocolate();
        }

        public Ingredients.Ingredients GetIngredientsForAnUnit()
        {
            return _recipe.Ingredients;
        }

        public bool CanMake(Ingredients.Ingredients ingredients)
        {
            return ingredients.GreaterThan(GetIngredientsForAnUnit());
        }
    }
}