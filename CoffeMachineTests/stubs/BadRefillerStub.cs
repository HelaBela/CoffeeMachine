namespace Tests.stubs
{
    public class BadRefillerStub: IRefiller.IRefiller
    {
        public Ingredients.Ingredients Refill(double water, double milk, int coffee, int chocolate)
        {
            return new Ingredients.Ingredients(-10,-10,-10,-10);
        }
    }
}