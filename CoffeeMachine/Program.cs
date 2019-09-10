using System;

namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("welcome to the coffee world");

            Console.WriteLine("What do you want to do: choose '1' to get the menu and '2' to refill and '3' to exit");
            var choice = Console.ReadLine();


            while (choice == "1")
            {
                var firstCoffeeMachine = new CoffeeMachine(true, 0, 10, 10, 50);
                var menu = firstCoffeeMachine.GetMenu();
                
                var counter = 1;
                Console.WriteLine("Choose a drink from the menu:");
                
                foreach (var drink in menu)
                {
                    Console.WriteLine($"{counter}: {drink}");

                    counter++;
                }

                var answer = Console.ReadLine();

                if (Int32.TryParse(answer, out int theChoice))
                {
                    var beverageType = menu[theChoice - 1];
                    Console.WriteLine($"You selected {beverageType}. Now preparing...");
                    Console.WriteLine($"Your {beverageType} is ready. Do you like it?");
                    var likeDislikeAnswer = Console.ReadLine();
                    var beverage = firstCoffeeMachine.MakeBeverage(beverageType);

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
                    Console.WriteLine($"{answer} is not a number!");
                }

                Console.WriteLine("What do you want to do: choose '1' to get the menu and '2' to exit");
                choice = Console.ReadLine();
            }

            Console.WriteLine("Bye!");
        }

        //what if user puts 6
        //refill the coffeeMachine
    }
}