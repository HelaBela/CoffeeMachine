using System;
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
            
            var choice = Prompt();
            var menu = _coffeeMachine.GetMenu();

            while (choice != "3")
            {
                if (HasUserChosenMenu(choice))
                {
                    Console.WriteLine("Choose a drink from the menu:");

                    PrintMenu();
                    
                    var result2 = int.TryParse(Console.ReadLine(), out var theChoice1);

                    if (result2 && theChoice1 < menu.Count)
                    {
                        var beverageType = menu[theChoice1 - 1];
                        Console.WriteLine($"You selected {beverageType}. Now preparing...");
                        var beverage = _coffeeMachine.MakeBeverage(beverageType);
                        Console.WriteLine($"Your {beverageType} is ready. Do you like it?");
                        var likeDislikeAnswer = Console.ReadLine();

                        if (likeDislikeAnswer == "yes")
                        {
                            Console.WriteLine(beverage.Drink());
                        }
                        else
                        {
                            Console.WriteLine(beverage.Throw());
                        }
                    
                        Console.WriteLine("choose a valid number");
                    }
                    else
                    {
                        Console.WriteLine($"{Console.ReadLine()} is not a number!");
                    }
                }
                else if (choice == "2")
                {
                    _coffeeMachine.RefillMachine();
                }
                else if (choice != "1" || choice != "2")
                {
                    Console.WriteLine("please choose a valid option.");
                }

                choice = Prompt();
            }

            Console.WriteLine("Bye!");

            void PrintMenu()
            {
                var menuOutOfOrder = _coffeeMachine.GetOutOfOrderMenu();
                menu = _coffeeMachine.GetMenu();
                var counter = 1;
                foreach (var drink in menu)
                {
                    Console.WriteLine($"{counter}: {drink}");

                    counter++;
                }

                if (menuOutOfOrder.Count != 0)
                {
                    Console.WriteLine("Not available at the moment: ");

                    foreach (var drink in menuOutOfOrder)
                    {
                        Console.WriteLine($" -> {drink}");
                    }

                    Console.WriteLine(
                        "If you like to refill the machine and have all drinks available type 'refill' else choose a drink from the menu.");

                    if (Console.ReadLine() == "refill")
                    {
                        _coffeeMachine.RefillMachine();

                        Console.WriteLine("Here is your new menu:");
                        PrintMenu();
                    }
                }
            }
        }
        
        private static string Prompt()
        {
            Console.WriteLine(
                "What do you want to do: choose '1' to get the menu and '2' to refill and '3' to exit");
            return Console.ReadLine();
        }

        private bool HasUserChosenMenu(string choice)
        {
            return choice == "1";
        }
        
    }
}