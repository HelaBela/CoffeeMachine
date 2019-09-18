namespace CoffeeMachine
{
    public class EspressoMaker: IBeverageMaker
    {
        private Recipe _recipe;

        public EspressoMaker()
        {
            _recipe= new EspressoRecipe(new Ingredients.Ingredients(12,0.2,0, 0));
        }

        public Beverage MakeBeverage()
        {
            foreach (var step in _recipe.Steps)
            {
                step.Execute();
            }

            return new Espresso();
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