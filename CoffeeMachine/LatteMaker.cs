namespace CoffeeMachine
{
    public class LatteMaker : IBeverageMaker
    {
        public Beverage MakeBeverage()
        {
            return new Latte();
        }

        public Ingredients GetIngredientsForAnUnit()
        {
            return new Ingredients(12, 0.2, 0.2, 0);
        }

        public bool CanMake(Ingredients ingredients)
        {
            return ingredients.GreaterThan(GetIngredientsForAnUnit());

        }
    }
}