namespace CoffeeMachine
{
    public abstract class Beverage
    {
        public abstract string Drink();

        public string Throw() //shared logic, advantage of the abstract class
        {
            return "Yuck I hate it!";
        }
        
    }
}

