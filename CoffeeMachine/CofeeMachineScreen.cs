using System;
using System.Collections.Generic;
using CoffeeMachine.Utility;
using Refiller;

namespace CoffeeMachine
{
    public class CofeeMachineScreen
    {
        private readonly IOConsoleService _iOConsoleService;
        private readonly CoffeeMachine _coffeeMachine;


        public CofeeMachineScreen(IOConsoleService iOConsoleService, CoffeeMachine coffeeMachine)
        {
            _iOConsoleService = iOConsoleService;
            _coffeeMachine = coffeeMachine;
        }

        public void Interact()
        {
            _iOConsoleService.Write("welcome to the coffee world");


            var refill = "r";
            var exit = "e";
            var menuChoice = "m";


            var choice = GetChoice();

            while (choice != exit)
            {
                choice = HandleChoice(choice);
            }
            _iOConsoleService.Write("Nice interacting with you. Have a nice day :)");
        }

        public string HandleChoice(string choice)
        {
            var refill = "r";
            var exit = "e";
            var menu = "m";
            if (choice == menu)
            {
                _iOConsoleService.Write("Here is your menu:");
                PrintMenu();
                PrintUnavailableMenu();
            }
            else if (choice == refill)
            {
                _coffeeMachine.RefillMachine();
                _iOConsoleService.Write("Machine is refilled.");
            }

            else if (choice != refill) // choice is a number call the below
            {
                MakeTheBeverage(choice);
            } //else say invalid choice


            choice = GetChoice();
            return choice;
        }


        private string GetChoice()
        {
            _iOConsoleService.Write("Choose a drink, type 'm' to see menu or 'r' to refill or 'e' to exit.");

            return _iOConsoleService.Read();
            
        }

        private void MakeTheBeverage(String choice)
        {
            var menu = _coffeeMachine.GetMenu();
            int.TryParse(choice, out var theDrink);
            if (theDrink < menu.Count)
            {
                var beverageType = menu[theDrink - 1];
               _iOConsoleService.Write($"You selected {beverageType}. Now preparing...");
                var beverage = _coffeeMachine.MakeBeverage(beverageType);
                _iOConsoleService.Write($"Your {beverageType} is ready. Do you like it?");

                if (_iOConsoleService.Read() == "yes")
                {
                    _iOConsoleService.Write(beverage.Drink());
                }
                else
                {
                    _iOConsoleService.Write(beverage.Throw());
                }
            }
            else
            {
                _iOConsoleService.Write($"{_iOConsoleService.Read()} is not a valid answer!");
            }
        }

        void PrintMenu()
        {
            var menu = _coffeeMachine.GetMenu();
            var counter = 1;
            foreach (var drink in menu)
            {
                _iOConsoleService.Write($"{counter}: {drink}");

                counter++;
            }
        }

        void PrintUnavailableMenu()
        {
            var unavailableMenu = _coffeeMachine.GetUnavailableMenu();
            _iOConsoleService.Write("Not available at the moment: ");

            foreach (var drink in unavailableMenu)
            {
                _iOConsoleService.Write(drink.ToString());
            }
        }
    }
}

