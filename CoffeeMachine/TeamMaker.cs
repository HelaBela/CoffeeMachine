namespace CoffeeMachine
{
    public class TeamMaker : IBeverageMaker

    {
        private Recipe _recipe;

        public TeamMaker()
        {
            _recipe = new TeaRecipe(new Ingredients(0, 0.4, 0, 0));
        }

        public Beverage MakeBeverage()
        {
            foreach (var step in _recipe.Steps)
            {
                step.Execute();
            }

            return new Tea();
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