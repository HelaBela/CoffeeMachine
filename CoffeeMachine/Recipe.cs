namespace CoffeeMachine
{
    public class Recipe
    {
        public Recipe(Ingredients ingredients)
        {
            Ingredients = ingredients;
        }

        public Ingredients Ingredients { get; }
        

    }
}