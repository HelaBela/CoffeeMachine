namespace CoffeeMachine.Utility
{
    public interface IOConsoleService
    {
        void DisplayOutput(string content);
        string ReadUserInput();
    }
}