namespace CoffeeMachine
{
    public abstract class Beverage: IDrinkMaker
    {
        public virtual string Drink()
        {
            return "";
        }

        public int CoffeeBeans { get; set; }
        public double Water { get; set; }
        public double Milk { get; set; }
        public int Chocolate { get; set; }
        
        public Beverage Make()
        {
            throw new System.NotImplementedException();
        }
    }
}

