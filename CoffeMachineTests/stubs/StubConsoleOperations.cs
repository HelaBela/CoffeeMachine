using System;

namespace CoffeeMachine.Utility
{
    public class StubConsoleOperations: IOConsoleService
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }

        public string Read()
        {
            return "m";
        }
    }
}