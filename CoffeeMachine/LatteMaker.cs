namespace CoffeeMachine
{
    public class LatteMaker : IBeverageMaker
    {
        public Beverage MakeBeverage()
        {
            return new Latte();
        }

        public Ingredients GetIngredients()
        {
            return new Ingredients(12, 0.2, 0.2, 0);
        }

        public bool CanMake(Ingredients ingredients)
        {
            return ingredients.GreaterThan(GetIngredients());

        }
    }
}