using System;

namespace CoffeeMachine.Utility
{
    class ConsoleOperations : IOConsoleService
    {
        public void DisplayOutput(string content)
        {
            Console.WriteLine(content);
        }

        public string ReadUserInput()
        {
            return Console.ReadLine();
        }
    }
}