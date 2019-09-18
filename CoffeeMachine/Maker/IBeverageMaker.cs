namespace CoffeeMachine
{
    public interface IBeverageMaker
    {
        Beverage MakeBeverage();
        Ingredients GetIngredientsForAnUnit();

        bool CanMake(Ingredients ingredients);
    }
}