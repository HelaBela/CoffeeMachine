namespace CoffeeMachine
{
    public class LatteMaker : IBeverageMaker
    {
        public BeverageTypes BeverageType => BeverageTypes.Latte;

        public Beverage MakeBeverage()
        {
            return new Latte();
        }

        public Recipe GetRecipe()
        {
            return new Recipe(new Ingredients(12, 0.2, 0.2, 0));
        }
    }
}