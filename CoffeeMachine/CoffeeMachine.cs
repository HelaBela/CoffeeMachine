using System;
using System.Collections.Generic;

namespace CoffeeMachine
{
    public class CoffeeMachine
    {
        public int CoffeeBeans { get; set; }
        public double Water { get; set; }
        public double Milk { get; set; }
        public int Chocolate { get; set; }

        public bool Power { get; }

        //public  Drink Menu { get; }


        public CoffeeMachine(bool power, int coffeeBeans, double water, double milk, int chocolate)
        {
            CoffeeBeans = coffeeBeans;
            Water = water;
            Milk = milk;
            Power = power;
            Chocolate = chocolate;
            //  Menu = menu;
            

        }

        public List<DrinkTypes> GetMenu()
        {
            var menu = new List<DrinkTypes>();
            if (Power != true)
            {
                throw new Exception("come back later. no power");
            }
            

            if (Water >= 0.3 && CoffeeBeans >= 12 && Milk >= 0.1 && Chocolate>=1)
            {
                menu.Add(DrinkTypes.Capp);
            }
            
            if (Water >= 0.2 && CoffeeBeans >= 12 && Milk >= 0.2)
            {
                menu.Add(DrinkTypes.Latte);
            }

            
            return menu;
        }
        

        public Beverage MakeBeverage(DrinkTypes drinkTypes)
        {
            if (drinkTypes == DrinkTypes.Capp)
            {
                var cappMaker = new CapMaker();
                
                                      //  var cappMaker = new CapMaker();
                                     //  var recipe = cappMaker.getRecipe()
                                    //  check if you have enough ingredients for the recipe -
                                   //  if yes, then make, else, 
                                   

                if (GetMenu().Contains(DrinkTypes.Capp))
                {
                    var recipe = cappMaker.CappRecepie;  
                    var cap = cappMaker.Make(recipe);
                    Water -= 0.3;
                    CoffeeBeans -= 12;
                    Chocolate -= 1;
                    Milk -= 0.1;
                    

                    return cap;
                }
            }
            
            if (drinkTypes == DrinkTypes.Latte)
            {
                var latteMaker = new LatteMaker();

                if (GetMenu().Contains(DrinkTypes.Latte))
                {
                    var recipe = latteMaker.LatteRecipe;
                    var latte = latteMaker.Make(recipe);
                    Water -= 0.2;
                    CoffeeBeans -= 12;
                    Milk -= 0.2;
                    

                    return latte;
                }
            }
            

            return null;
        }

        public void DeductResourcesAfterCoffeeIsDone(Recipe recipe)
        {
            Water -= recipe.Water;
            CoffeeBeans -= recipe.CoffeeBeans;
            Milk -= recipe.Milk;
            
        }

    }
}