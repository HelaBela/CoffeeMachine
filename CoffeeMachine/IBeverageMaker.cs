namespace CoffeeMachine
{
    public interface IBeverageMaker
    {
        Beverage MakeBeverage();
        Ingredients GetIngredients();

        bool CanMake(Ingredients ingredients);
    }
}