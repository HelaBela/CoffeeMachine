namespace IRefiller
{
    public interface IRefiller
    {
        Ingredients.Ingredients Refill(double water, double milk, int coffee, int chocolate);
    }
}