namespace CoffeeMachine
{
    public class LatteMaker : IBeverageMaker
    {
        private Recipe _recipe;
        
        public LatteMaker()
        {
            _recipe = new CappRecipe( new Ingredients(12, 0.2, 0.2, 0));
        }

        public Beverage MakeBeverage()
        {
            foreach (var step in _recipe.Steps)
            {
                step.Execute();
            }

            return new Latte();
        }
        

        public Ingredients GetIngredientsForAnUnit()
        {
            return _recipe.Ingredients;
        }
        

        public bool CanMake(Ingredients ingredients)
        {
            return ingredients.GreaterThan(GetIngredientsForAnUnit());

        }
    }
}