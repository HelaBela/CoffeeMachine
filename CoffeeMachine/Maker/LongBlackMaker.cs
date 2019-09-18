namespace CoffeeMachine
{
    public class LongBlackMaker : IBeverageMaker
    {
        private Recipe _recipe;

        public Beverage MakeBeverage()
        {
            foreach (var step in _recipe.Steps)
            {
                step.Execute();
            }

            return new LongBlack();
        }

        public LongBlackMaker()
        {
            _recipe = new LongBlackRecipe(new Ingredients(12, 0.4, 0, 0) );
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