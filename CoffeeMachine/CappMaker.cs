namespace CoffeeMachine
{
    public class CappMaker : IBeverageMaker
    {
        public Beverage MakeBeverage()
        {
            return new Capp();
        }

        public Ingredients GetIngredients()
        {
            return new Ingredients(12, 0.3, 0.1, 1);
        }

        public bool CanMake(Ingredients ingredients)
        {
            return ingredients.GreaterThan(GetIngredients());
        }
    }
}