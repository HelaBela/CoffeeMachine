namespace CoffeeMachine.Utility
{
    public interface IOConsoleService
    {
        void Write(string content);
        string Read();
    }
}