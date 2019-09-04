namespace CoffeeMachine
{
    public interface IBeverageMaker
    {
        BeverageTypes BeverageType { get; }
        Beverage MakeBeverage();
        Recipe GetRecipe();
    }
}