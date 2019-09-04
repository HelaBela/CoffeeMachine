using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeMachine
{
    public class CoffeeMachine
    {
        public int CoffeeBeans { get; set; }
        public double Water { get; set; }
        public double Milk { get; set; }
        public int Chocolate { get; set; }

        public bool Power { get; }
        private List<IBeverageMaker> _beverageMakers = new List<IBeverageMaker>();


        public CoffeeMachine(bool power, int coffeeBeans, double water, double milk, int chocolate)
        {
            CoffeeBeans = coffeeBeans;
            Water = water;
            Milk = milk;
            Power = power;
            Chocolate = chocolate;
            _beverageMakers.Add(new CappMaker());
            _beverageMakers.Add(new LatteMaker());
        }

        public List<BeverageTypes> GetMenu()
        {
            var menu = new List<BeverageTypes>();
            if (Power != true)
            {
                throw new Exception("come back later. no power");
            }

            foreach (var maker in _beverageMakers)
            {
                var recipe = maker.GetRecipe();

                if (Water >= recipe.Water && CoffeeBeans >= recipe.CoffeeBeans && Milk >= recipe.Milk &&
                    Chocolate >= recipe.Chocolate)
                {
                    menu.Add(maker.BeverageType);
                }
            }

            return menu;
        }


        public Beverage MakeBeverage(BeverageTypes beverageType)
        {
            IBeverageMaker maker = null;
            foreach (var beverageMaker in _beverageMakers)
            {
                if (beverageMaker.BeverageType == beverageType)
                {
                    maker = beverageMaker;
                    break;
                }
            }


            if (GetMenu().Contains(beverageType) && maker != null)
            {
                var beverage = maker.MakeBeverage();
                DeductResourcesAfterCoffeeIsDone(maker.GetRecipe());
                return beverage;
            }

            return null;
        }
        
        
        //handle what happens if we dont have resources 
        
        //refill the coffeeMachine

        private void DeductResourcesAfterCoffeeIsDone(Recipe recipe)
        {
            Water -= recipe.Water;
            CoffeeBeans -= recipe.CoffeeBeans;
            Milk -= recipe.Milk;
            Chocolate -= recipe.Chocolate;
        }
    }
}