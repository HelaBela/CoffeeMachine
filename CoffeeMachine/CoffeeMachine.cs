using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeMachine
{
    public class CoffeeMachine
    {
        private Ingredients _ingredients;

        public bool Power { get; }
        private List<IBeverageMaker> _beverageMakers = new List<IBeverageMaker>();

        // make _beverageMakers into private Dictionary<>


        public CoffeeMachine(bool power, int coffeeBeans, double water, double milk, int chocolate)
        {
            _ingredients = new Ingredients(coffeeBeans, water, milk, chocolate);
            Power = power;
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


                if (_ingredients.GreaterThan(recipe.Ingredients)) //recepie should be internal to the maker. 
                    // this way we are breaking tell dont aks and encapsulation coz recepie is secret. 

                    //canMake (bevarageType, coffee machine's ingr) on maker. And pass ingrediets. 

                {
                    menu.Add(maker.BeverageType);
                }
            }

            return menu;
        }


        public Beverage MakeBeverage(BeverageTypes beverageType)
        {
            IBeverageMaker maker = FindBeverageMaker(beverageType);

            if (GetMenu().Contains(beverageType) && maker != null)
            {
                var beverage = maker.MakeBeverage();
                _ingredients.ReduceBy(maker.GetRecipe().Ingredients);
                return beverage;

                // make a method on maker to getingredients so that the recepie can remain private to maker. 
                //shouldnt ask recepei from the maker
            }

            return null;
        }

        private IBeverageMaker FindBeverageMaker(BeverageTypes beverageType)
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

            return maker;
        }


        //handle what happens if we dont have resources 

        //refill the coffeeMachine
        public bool? hasIngredients(Ingredients remainingIngredients)
        {
            return _ingredients.isEqual(remainingIngredients);
        }
    }
}