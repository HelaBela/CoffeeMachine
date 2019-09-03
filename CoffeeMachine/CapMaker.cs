namespace CoffeeMachine
{
    public class CapMaker : IDrinkMaker
    {
        public Recipe CappRecepie;
        
        public Beverage Make(Recipe coffeeRecipe)
        {
            
            CappRecepie = new Recipe(12, 0.3, 0.1, 1);

            return new Capp();
        }

        



    }
}