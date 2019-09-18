using System.Collections.Generic;

namespace CoffeeMachine
{
    public abstract class Recipe
    {
        public Recipe(Ingredients.Ingredients ingredients)
        {
            Ingredients = ingredients;
            Steps = new List<IStep>();
        }

        public Ingredients.Ingredients Ingredients { get; }
        public List<IStep> Steps { get; }
        

    }
}