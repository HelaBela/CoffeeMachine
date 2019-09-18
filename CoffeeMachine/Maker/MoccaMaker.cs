namespace CoffeeMachine
{
    public class MoccaMaker:IBeverageMaker
    {
        private Recipe _recipe;

        public MoccaMaker()
        {
            _recipe = new MoccaRecipe(new Ingredients.Ingredients(12, 0.3, 0.1, 5));
        }

        public Beverage MakeBeverage()
        {

            foreach (var step in _recipe.Steps)
            {
              step.Execute();  
            }
            return new Mocca();
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