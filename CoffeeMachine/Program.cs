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

            while (choice != "3")
            {
                if (choice == "1")
                {
                    var menu = firstCoffeeMachine.GetMenu();

                    Console.WriteLine("Choose a drink from the menu:");

                    var counter = 1;
                    foreach (var drink in menu)
                    {
                        Console.WriteLine($"{counter}: {drink}");

                        counter++;
                    }

                    if (int.TryParse(Console.ReadLine(), out var theChoice))
                    {
                        var beverageType = menu[theChoice - 1];
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
                choice=Prompt();
            }

            Console.WriteLine("Bye!");
        }

        private static string Prompt()
        {
            Console.WriteLine(
                "What do you want to do: choose '1' to get the menu and '2' to refill and '3' to exit");
          return Console.ReadLine();
        }
    }
}