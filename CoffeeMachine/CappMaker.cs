namespace CoffeeMachine
{
    public class CappMaker : IBeverageMaker
    {
        public BeverageTypes BeverageType => BeverageTypes.Capp;

        public Beverage MakeBeverage()
        {
            return new Capp();
        }

        public Recipe GetRecipe()
        {
            return new Recipe(new Ingredients(12, 0.3, 0.1, 1));
        }
    }
}