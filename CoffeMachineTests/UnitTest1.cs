using System;
using CoffeeMachine;
using NUnit.Framework;
using Refiller;
using Tests.mocks;
using Tests.stubs;
using Ingredients = Ingredients.Ingredients;

namespace Tests
{
    public class CoffeeMachineTests
    {
        private IRefiller.IRefiller refiller;
        
        [SetUp]
        public void Setup()
        {
            refiller = new Refiller.SolarRefiller();
        }

        [Test]
        public void CanCreateCoffeeMachine()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 2, 3, 4, 5, refiller);
            Assert.IsNotNull(coffeeMachine);
        }

        [Test]
        public void CanNotGetMenuWhenThereIsNoPower()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(false, 2, 3, 4, 5, new ElectricRefiller.ElectricRefiller());


            Assert.Throws<Exception>(() => coffeeMachine.GetMenu());
        }

        [Test]
        public void CanGetMenuWhenThereIsPower()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 2, 3, 4, 5, refiller);


            Assert.IsNotNull(coffeeMachine.GetMenu());
        }

        [Test]
        public void CanGetCappInMenuWhenIngredientsAreAvailable()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 22, 3, 4, 5, refiller);


            Assert.Contains(BeverageType.Capp, coffeeMachine.GetMenu());
        }

        [Test]
        public void CanNotGetCappInMenuWhenCoffeeNotEnaugh()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 2, 3, 4, 5, refiller);

            Assert.IsFalse(coffeeMachine.GetMenu().Contains(BeverageType.Capp));
        }

        [Test]
        public void CanNotGetCappInMenuWhenwaterNotEnaugh()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 12, 0, 4, 5, refiller);

            Assert.IsFalse(coffeeMachine.GetMenu().Contains(BeverageType.Capp));
        }

        [Test]
        public void CanNotGetCappInMenuWhenMilkNotEnaugh()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 12, 3, 0, 5, refiller);

            Assert.IsFalse(coffeeMachine.GetMenu().Contains(BeverageType.Capp));
        }

        [Test]
        public void CanNotGetCappInMenuWhenChockNotEnaugh()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 12, 3, 4, 0, refiller);

            Assert.IsFalse(coffeeMachine.GetMenu().Contains(BeverageType.Capp));
        }
        
        [Test]
        public void CanMakeCapp()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 14, 3, 4, 10, refiller);

            Assert.IsNotNull(coffeeMachine.MakeBeverage(BeverageType.Capp));
        }
        
        [Test]
        public void CanNotMakeCappWithoutWater()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 14, 0, 4, 10, refiller);

            Assert.IsNull(coffeeMachine.MakeBeverage(BeverageType.Capp));
        }
        
        [Test]
        public void CanSubstractFromCoffeeMachingWhenCapIsMAde()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 14, 20, 4, 10, refiller);

            coffeeMachine.MakeBeverage(BeverageType.Capp);
            
           global::Ingredients.Ingredients remainingIngredients = new global::Ingredients.Ingredients(2, 19.7, 3.9, 9);
            
            Assert.IsTrue(coffeeMachine.hasIngredients(remainingIngredients));
            
        }
        
        [Test]
        public void CanGetLatteInMenuWhenIngredientsAreAvailable()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 22, 3, 4, 5, refiller);


            Assert.Contains(BeverageType.Latte, coffeeMachine.GetMenu());
        }
        
        [Test]
        public void CanMakeLatte()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 14, 3, 4, 1, refiller);

            Assert.IsNotNull(coffeeMachine.MakeBeverage(BeverageType.Latte));
        }
        
        [Test]
        public void CanGetLatteWhenCantMakeCap()
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 24, 3, 4, 1, refiller);

            Assert.Contains(BeverageType.Latte, coffeeMachine.GetMenu());
            Assert.Contains(BeverageType.Capp, coffeeMachine.GetMenu());

            Assert.IsNotNull( coffeeMachine.MakeBeverage(BeverageType.Capp));
            
            Assert.Contains(BeverageType.Latte, coffeeMachine.GetMenu());
            Assert.IsFalse(coffeeMachine.GetMenu().Contains(BeverageType.Capp));
            Assert.IsNotNull( coffeeMachine.MakeBeverage(BeverageType.Latte));
            
        }

        [Test]
        public void CanRefillWithRefillerThatSupportsRefilling()
        {
            
            // Arrange:
            // Create the fake Refiller:

           IRefiller.IRefiller newRefiller = new RefillerStub();

           var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 24, 3, 4, 1, newRefiller);

           Assert.Contains(BeverageType.Latte, coffeeMachine.GetMenu());
           Assert.Contains(BeverageType.Capp, coffeeMachine.GetMenu());

           Assert.IsNotNull( coffeeMachine.MakeBeverage(BeverageType.Capp));
            
           Assert.Contains(BeverageType.Latte, coffeeMachine.GetMenu());
           Assert.IsFalse(coffeeMachine.GetMenu().Contains(BeverageType.Capp));
           Assert.IsNotNull( coffeeMachine.MakeBeverage(BeverageType.Latte));
           
           coffeeMachine.RefillMachine();
           
           Assert.Contains(BeverageType.Latte, coffeeMachine.GetMenu());
           Assert.Contains(BeverageType.Capp, coffeeMachine.GetMenu());
           
        }
        
        
        [Test]
        public void CanNotRefillWhenIngredientsAreNegativeNumbers()
        {
            
            // Arrange:
            // Create the fake Refiller:

            IRefiller.IRefiller newRefiller = new RefillerMock();

            var coffeeMachine = new CoffeeMachine.CoffeeMachine(true, 10, 3, 4, 1, newRefiller);

            coffeeMachine.RefillMachine();
           
            Assert.IsFalse(coffeeMachine.GetMenu().Contains(BeverageType.Capp));
           
        }
        
        //make your machine resistant for bad refillers, when the refiller has negative numbers - write test and then improve code
    }
}