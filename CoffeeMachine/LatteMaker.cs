namespace CoffeeMachine
{
    public class LatteMaker : IDrinkMaker
    {

        public Recipe LatteRecipe;
        
        public Beverage Make(Recipe coffeeRecipe)
        {
           LatteRecipe = new Recipe(12, 0.2 ,0.2 ,0 ); 
           return new Latte();
        }
    }
}