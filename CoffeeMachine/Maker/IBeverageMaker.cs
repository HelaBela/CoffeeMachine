namespace CoffeeMachine
{
    public interface IBeverageMaker
    {
        Beverage MakeBeverage();
        Ingredients.Ingredients GetIngredientsForAnUnit();

        bool CanMake(Ingredients.Ingredients ingredients);
    }
}