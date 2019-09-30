using System;

namespace CoffeeMachine.Utility
{
    class ConsoleOperations : IOConsoleService
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }

        public string Read()
        {
            return Console.ReadLine();
        }
    }
}