namespace CoffeeMachine
{
    public interface IDrinkMaker
    {
        Beverage Make( Recipe coffeeRecipe);
    }
}