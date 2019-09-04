using System;

namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("welcome to the coffee world");

            Console.WriteLine("What do you want to do: choose '1' to get the menu and '2' to exit");
            var choice = Console.ReadLine();


            while (choice == "1")
            {
                var firstCoffeeMachine = new CoffeeMachine(true, 20, 10, 10, 50);
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
                    var beverage = firstCoffeeMachine.MakeBeverage(beverageType);
                    Console.WriteLine(beverage.Throw());
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
        //give a user an option to throw away. beverage.Throw
        //refill the coffeeMachine
    }
}