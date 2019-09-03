namespace CoffeeMachine
{
    public class Recipe
    {
        
        public int CoffeeBeans { get; set; }
        public double Water { get; set; }
        public double Milk { get; set; }
        public int Chocolate { get; set; }

        public Recipe(int coffeeBeans, double water, double milk, int chocolate)
        {
            CoffeeBeans = coffeeBeans;
            Water = water;
            Milk = milk;
            Chocolate = chocolate;
            
        }

    }
}