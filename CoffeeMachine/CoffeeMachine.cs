using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeMachine
{
    public class CoffeeMachine
    {
        private Ingredients _ingredients;

        public bool Power { get; }

        private Dictionary<BeverageType, IBeverageMaker> _beverageMakers =
            new Dictionary<BeverageType, IBeverageMaker>();

        public CoffeeMachine(bool power, int coffeeBeans, double water, double milk, int chocolate)
        {
            _ingredients = new Ingredients(coffeeBeans, water, milk, chocolate);
            Power = power;
            _beverageMakers.Add(BeverageType.Capp, new CappMaker());
            _beverageMakers.Add(BeverageType.Latte, new LatteMaker());
        }

        public List<BeverageType> GetMenu()
        {
            var menu = new List<BeverageType>();
            if (Power != true)
            {
                throw new Exception("come back later. no power");
            }

            foreach (var maker in _beverageMakers)
            {
                if (maker.Value.CanMake(_ingredients))
                {
                    menu.Add(maker.Key);
                }
            }

            return menu;
        }


        public Beverage MakeBeverage(BeverageType beverageType)
        {
            IBeverageMaker maker = _beverageMakers[beverageType];

            if (GetMenu().Contains(beverageType) && maker != null)
            {
                var beverage = maker.MakeBeverage();
                _ingredients.ReduceBy(maker.GetIngredients());
                return beverage;
            }

            return null;
        }

        //handle what happens if we dont have resources 

        //refill the coffeeMachine
        public bool? hasIngredients(Ingredients remainingIngredients)
        {
            return _ingredients.isEqual(remainingIngredients);
        }
    }
}