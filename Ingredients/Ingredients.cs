namespace Ingredients
{
    public class Ingredients
    {
        
        
        public int CoffeeBeans { get; set; } 
        public double Water { get; set; }
        public double Milk { get; set; }
        public int Chocolate { get; set; }
        public Ingredients(int coffeeBeans, double water, double milk, int chocolate)
        {
            CoffeeBeans = coffeeBeans;
            Water = water;
            Milk = milk;
            Chocolate = chocolate;
        }

        public bool GreaterThan(Ingredients recipeIngredients)
        {
            if (Water>= recipeIngredients.Water && CoffeeBeans>= recipeIngredients.CoffeeBeans && Milk>= recipeIngredients.Milk && Chocolate>= recipeIngredients.Chocolate) return true;
            else
                return false;
        }
        
       

        public void ReduceBy(Ingredients recipeIngredients)
        {
            Water -= recipeIngredients.Water;
            CoffeeBeans -= recipeIngredients.CoffeeBeans;
            Chocolate -= recipeIngredients.Chocolate;
            Milk -= recipeIngredients.Milk;
        }

        public bool isEqual(Ingredients remainingIngredients)
        {return Water == remainingIngredients.Water && CoffeeBeans == remainingIngredients.CoffeeBeans && Milk == remainingIngredients.Milk && Chocolate == remainingIngredients.Chocolate;
        }

        public void Add(Ingredients ingredientsToRefill)
        {
            CoffeeBeans += ingredientsToRefill.CoffeeBeans;
            Water += ingredientsToRefill.Water;
            Chocolate += ingredientsToRefill.Chocolate;
            Milk += ingredientsToRefill.Milk;
        }
    }
}