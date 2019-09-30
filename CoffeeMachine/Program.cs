using System;
using CoffeeMachine.Utility;

namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
           
            var refiller = new Refiller.SolarRefiller();

            var firstCoffeeMachine = new CoffeeMachine(true, 12, 10, 10, 0, refiller);

            var consoleServices = new ConsoleOperations();
            
            var displayOutput = new CofeeMachineDisplayOutput(consoleServices, firstCoffeeMachine);
            
            displayOutput.RunOutput();

        }




    }
}