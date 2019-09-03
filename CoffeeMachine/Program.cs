using System;

namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("welcome to the coffee world");

            var choice = "1";

            while (choice == "1")
            {

                Console.WriteLine("What do you want to do: choose '1' to get the menu and '2' to exit");

                choice = Console.ReadLine();

                if (choice == "1")
                {
                    var firstCoffeeMachine = new CoffeeMachine(true, 20, 10, 10, 50);
                    var menu = firstCoffeeMachine.GetMenu();
                    Console.WriteLine(menu);
                    var answer = Console.ReadLine();
                    Console.WriteLine($"You selected {answer}. Now preparing...");
                }
                else
                {
                    Console.WriteLine("Bye!");
                }
            }



//
//                if (Int32.TryParse(answer, out int theChoice))
//                {
//                    Console.WriteLine(menu[theChoice - 1]);
//                }
//                else
//                {
//                    Console.WriteLine($"{answer} is not a number!");
//                    Prompt();
//                }
//                
//               
//            
//
//            void Prompt()
//            {
//                var counter = 1;
//                foreach (var drink in menu)
//                {
//                    Console.WriteLine("Choose a drink form the menu:");
//                    Console.WriteLine($"{counter}: {drink}");
//
//                    counter++;
//                }
//            }
        }
    }
}