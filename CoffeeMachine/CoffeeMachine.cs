using System;
using System.Collections.Generic;

namespace CoffeeMachine
{
    public class CoffeeMachine
    {
        private readonly Ingredients.Ingredients _ingredients;

        private readonly IRefiller.IRefiller _refiller;

        public bool Power { get; }

        private Dictionary<BeverageType, IBeverageMaker> _beverageMakers =
            new Dictionary<BeverageType, IBeverageMaker>();

        public CoffeeMachine(bool power, int coffeeBeans, double water, double milk, int chocolate, IRefiller.IRefiller refiller)
        {
            _ingredients = new Ingredients.Ingredients(coffeeBeans, water, milk, chocolate);
            Power = power;
            _beverageMakers.Add(BeverageType.Capp, new CappMaker());
            _beverageMakers.Add(BeverageType.Latte, new LatteMaker());
            _beverageMakers.Add(BeverageType.LongBlack, new LongBlackMaker());
            _beverageMakers.Add(BeverageType.HotChoc, new ChocolteMaker());
            _beverageMakers.Add(BeverageType.Espresso, new EspressoMaker());
            _beverageMakers.Add(BeverageType.Mocca, new MoccaMaker());
            _beverageMakers.Add(BeverageType.Tea, new TeamMaker());
            _refiller = refiller;
        }

        public List<BeverageType> GetMenu()
        {
            var menu = new List<BeverageType>();
            var outOfMenu = new List<BeverageType>();
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
        
        public List<BeverageType> GetOutOfOrderMenu()
        {
            var outOfMenu = new List<BeverageType>();
            if (Power != true)
            {
                throw new Exception("come back later. no power");
            }

            foreach (var maker in _beverageMakers)
            {
                if (!maker.Value.CanMake(_ingredients))
                {
                    outOfMenu.Add(maker.Key);
                }
            }

            return outOfMenu;
        }



        public Beverage MakeBeverage(BeverageType beverageType)
        {
            IBeverageMaker maker = _beverageMakers[beverageType];

            if (GetMenu().Contains(beverageType) && maker != null)
            {
                var beverage = maker.MakeBeverage();
                _ingredients.ReduceBy(maker.GetIngredientsForAnUnit());
                return beverage;
            }

            return null;
        }

        public bool? hasIngredients(Ingredients.Ingredients remainingIngredients)
        {
            return _ingredients.isEqual(remainingIngredients);
        }

        public void RefillMachine()
        {
            
            
            _ingredients.Add(_refiller.Refill(20, 20, 20, 20));
        }
    }
}