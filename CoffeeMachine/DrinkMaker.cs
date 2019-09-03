namespace CoffeeMachine
{
    public interface IDrinkMaker
    {
        int CoffeeBeans { get; set; }
        double Water { get; set; }
        double Milk { get; set; }
        int Chocolate { get; set; }


        Beverage Make();
    }
}