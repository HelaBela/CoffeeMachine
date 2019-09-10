using System;
using CoffeeMachine;
using NUnit.Framework;

namespace Tests
{
    public class CoffeeMachineTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanCreateCoffeeMachine()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 2, 3, 4, 5);
            Assert.IsNotNull(coffeeMachine);
        }

        [Test]
        public void CanNotGetMenuWhenThereIsNoPower()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(false, 2, 3, 4, 5);


            Assert.Throws<Exception>(() => coffeeMachine.GetMenu());
        }

        [Test]
        public void CanGetMenuWhenThereIsPower()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 2, 3, 4, 5);


            Assert.IsNotNull(coffeeMachine.GetMenu());
        }

        [Test]
        public void CanGetCappInMenuWhenIngredientsAreAvailable()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 22, 3, 4, 5);


            Assert.Contains(BeverageType.Capp, coffeeMachine.GetMenu());
        }

        [Test]
        public void CanNotGetCappInMenuWhenCoffeeNotEnaugh()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 2, 3, 4, 5);

            Assert.IsFalse(coffeeMachine.GetMenu().Contains(BeverageType.Capp));
        }

        [Test]
        public void CanNotGetCappInMenuWhenwaterNotEnaugh()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 12, 0, 4, 5);

            Assert.IsFalse(coffeeMachine.GetMenu().Contains(BeverageType.Capp));
        }

        [Test]
        public void CanNotGetCappInMenuWhenMilkNotEnaugh()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 12, 3, 0, 5);

            Assert.IsFalse(coffeeMachine.GetMenu().Contains(BeverageType.Capp));
        }

        [Test]
        public void CanNotGetCappInMenuWhenChockNotEnaugh()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 12, 3, 4, 0);

            Assert.IsFalse(coffeeMachine.GetMenu().Contains(BeverageType.Capp));
        }
        
        [Test]
        public void CanMakeCapp()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 14, 3, 4, 10);

            Assert.IsNotNull(coffeeMachine.MakeBeverage(BeverageType.Capp));
        }
        
        [Test]
        public void CanNotMakeCappWithoutWater()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 14, 0, 4, 10);

            Assert.IsNull(coffeeMachine.MakeBeverage(BeverageType.Capp));
        }
        
        [Test]
        public void CanSubstractFromCoffeeMachingWhenCapIsMAde()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 14, 20, 4, 10);

            coffeeMachine.MakeBeverage(BeverageType.Capp);
            
            Ingredients remainingIngredients = new Ingredients(2, 19.7, 3.9, 9);
            
            Assert.IsTrue(coffeeMachine.hasIngredients(remainingIngredients));
            
            //anotjher wayof testing would be to set up in a way that the inital machine can make 10 caps, and check if after making one cap it can still make 9 more 
        }
        
        [Test]
        public void CanGetLatteInMenuWhenIngredientsAreAvailable()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 22, 3, 4, 5);


            Assert.Contains(BeverageType.Latte, coffeeMachine.GetMenu());
        }
        
        [Test]
        public void CanMakeLatte()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 14, 3, 4, 10);

            Assert.IsNotNull(coffeeMachine.MakeBeverage(BeverageType.Latte));
        }
        
        [Test]
        public void CanGetLatteWhenCantMakeCap()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 24, 3, 4, 1);

            Assert.Contains(BeverageType.Latte, coffeeMachine.GetMenu());
            Assert.Contains(BeverageType.Capp, coffeeMachine.GetMenu());

            Assert.IsNotNull( coffeeMachine.MakeBeverage(BeverageType.Capp));
            
            Assert.Contains(BeverageType.Latte, coffeeMachine.GetMenu());
            Assert.IsFalse(coffeeMachine.GetMenu().Contains(BeverageType.Capp));
            Assert.IsNotNull( coffeeMachine.MakeBeverage(BeverageType.Latte));
            
        }


        
    }
}