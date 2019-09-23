

namespace Tests.stubs
{
    public class RefillerStub: IRefiller.IRefiller
    {
        public Ingredients.Ingredients Refill(double water, double milk, int coffee, int chocolate)
        
        {
            return new Ingredients.Ingredients(coffee, water, milk, chocolate);
        }
    }
}