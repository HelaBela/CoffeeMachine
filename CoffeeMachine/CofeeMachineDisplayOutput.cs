using System;
using System.Collections.Generic;
using CoffeeMachine.Utility;
using Refiller;

namespace CoffeeMachine
{
    public class CofeeMachineDisplayOutput
    {
        private readonly IOConsoleService _iOConsoleService;
        private readonly CoffeeMachine _coffeeMachine;

        public CofeeMachineDisplayOutput(IOConsoleService iOConsoleService, CoffeeMachine coffeeMachine)
        {
            _iOConsoleService = iOConsoleService;
            _coffeeMachine = coffeeMachine;
        }

        public void RunOutput()
        {
            Console.WriteLine("welcome to the coffee world");

            var menu = _coffeeMachine.GetMenu();

            var refill = "r";
            var exit = "e";

            Console.WriteLine("Here is your menu:");

            PrintMenu();
            PrintUnavailableMenu();

            var choice = Choice();
            while (choice != exit)
            {
                if (choice != refill)
                {
                    MakeTheBeverage(menu);
                }
                else
                {
                    _coffeeMachine.RefillMachine();
                    Console.WriteLine("Machine is refilled. Here is your new menu:");
                    PrintMenu();
                }

                if (choice == refill)
                {
                    _coffeeMachine.RefillMachine();
                }
            }

            Console.WriteLine("Bye!");
        }

        private static string Choice()
        {
            Console.WriteLine("Choose a drink, type 'r' to refill or 'e' to exit.");

            var choice = Console.ReadLine();
            return choice;
        }

        private void MakeTheBeverage(List<BeverageType> menu)
        {
            var drinkChoice = int.TryParse(Console.ReadLine(), out var theDrink);
            if (theDrink < menu.Count)
            {
                var beverageType = menu[theDrink - 1];
                Console.WriteLine($"You selected {beverageType}. Now preparing...");
                var beverage = _coffeeMachine.MakeBeverage(beverageType);
                Console.WriteLine($"Your {beverageType} is ready. Do you like it?");

                if (Console.ReadLine() == "yes")
                {
                    Console.WriteLine(beverage.Drink());
                }
                else
                {
                    Console.WriteLine(beverage.Throw());
                }
            }
            else
            {
                Console.WriteLine($"{Console.ReadLine()} is not a valid answer!");
            }

           
        }

        void PrintMenu()
        {
            var menu = _coffeeMachine.GetMenu();
            var counter = 1;
            foreach (var drink in menu)
            {
                Console.WriteLine($"{counter}: {drink}");

                counter++;
            }
        }

        void PrintUnavailableMenu()
        {
            var unavailableMenu = _coffeeMachine.GetUnavailableMenu();
            Console.WriteLine("Not available at the moment: ");

            foreach (var drink in unavailableMenu)
            {
                Console.WriteLine(drink);
            }
        }
    }
}