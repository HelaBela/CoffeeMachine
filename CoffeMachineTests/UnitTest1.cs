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


            Assert.Contains(BeverageTypes.Capp, coffeeMachine.GetMenu());
        }

        [Test]
        public void CanNotGetCappInMenuWhenCoffeeNotEnaugh()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 2, 3, 4, 5);

            Assert.IsFalse(coffeeMachine.GetMenu().Contains(BeverageTypes.Capp));
        }

        [Test]
        public void CanNotGetCappInMenuWhenwaterNotEnaugh()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 12, 0, 4, 5);

            Assert.IsFalse(coffeeMachine.GetMenu().Contains(BeverageTypes.Capp));
        }

        [Test]
        public void CanNotGetCappInMenuWhenMilkNotEnaugh()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 12, 3, 0, 5);

            Assert.IsFalse(coffeeMachine.GetMenu().Contains(BeverageTypes.Capp));
        }

        [Test]
        public void CanNotGetCappInMenuWhenChockNotEnaugh()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 12, 3, 4, 0);

            Assert.IsFalse(coffeeMachine.GetMenu().Contains(BeverageTypes.Capp));
        }
        
        [Test]
        public void CanMakeCapp()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 14, 3, 4, 10);

            Assert.IsNotNull(coffeeMachine.MakeBeverage(BeverageTypes.Capp));
        }
        
        [Test]
        public void CanNotMakeCappWithoutWater()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 14, 0, 4, 10);

            Assert.IsNull(coffeeMachine.MakeBeverage(BeverageTypes.Capp));
        }
        
        [Test]
        public void CanSubstractFromCoffeeMachingWhenCapIsMAde()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 14, 20, 4, 10);

            coffeeMachine.MakeBeverage(BeverageTypes.Capp);

            Assert.AreEqual(2, coffeeMachine.CoffeeBeans);
            Assert.AreEqual(19.7, coffeeMachine.Water);
            Assert.AreEqual(3.9, coffeeMachine.Milk);
            Assert.AreEqual(9, coffeeMachine.Chocolate);
        }
        
        [Test]
        public void CanGetLatteInMenuWhenIngredientsAreAvailable()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 22, 3, 4, 5);


            Assert.Contains(BeverageTypes.Latte, coffeeMachine.GetMenu());
        }
        
        [Test]
        public void CanMakeLatte()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 14, 3, 4, 10);

            Assert.IsNotNull(coffeeMachine.MakeBeverage(BeverageTypes.Latte));
        }

        
    }
}