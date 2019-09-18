using System;

namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("welcome to the coffee world");

            var firstCoffeeMachine = new CoffeeMachine(true, 12, 10, 10, 0);

            var choice = Prompt();
            var menu = firstCoffeeMachine.GetMenu();

            while (choice != "3")
            {
                if (choice == "1")
                {
                    Console.WriteLine("Choose a drink from the menu:");

                    PrintMenu();
                    
                    var result2 = int.TryParse(Console.ReadLine(), out var theChoice1);

                    if (result2 && theChoice1 < menu.Count)
                    {
                        var beverageType = menu[theChoice1 - 1];
                        Console.WriteLine($"You selected {beverageType}. Now preparing...");
                        var beverage = firstCoffeeMachine.MakeBeverage(beverageType);
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
                    firstCoffeeMachine.RefillMachine();
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
                var menuOutOfOrder = firstCoffeeMachine.GetOutOfOrderMenu();
                menu = firstCoffeeMachine.GetMenu();
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
                        firstCoffeeMachine.RefillMachine();

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
    }
}