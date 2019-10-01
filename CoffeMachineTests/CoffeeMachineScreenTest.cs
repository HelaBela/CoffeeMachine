using NUnit.Framework;
using Tests.mocks;
using CoffeeMachine;
using CoffeeMachine.Utility;
using Moq;

namespace Tests
{
    public class CoffeeMachineScreenTest
    {
        [Test]
        public void CanShowMenu()
        {
            //Arrange
            IRefiller.IRefiller newRefiller = new RefillerMock();
            CoffeeMachine.CoffeeMachine testCoffeMachine =
                new CoffeeMachine.CoffeeMachine(true, 10, 10, 10, 10, newRefiller);

            var consoleOperationsMock = new Mock<IOConsoleService>();
            CofeeMachineScreen testScreen = new CofeeMachineScreen(consoleOperationsMock.Object, testCoffeMachine);

            //act

            testScreen.HandleChoice("m");

            //Assert

            consoleOperationsMock.Verify(
                m => m.Write(It.Is<string>(c => c == "Here is your menu:")));
            consoleOperationsMock.Verify(
                m => m.Write(It.Is<string>(c => c == "1: HotChoc")));
            consoleOperationsMock.Verify(
                m => m.Write(It.Is<string>(c => c == "2: Tea")));
            consoleOperationsMock.Verify(
                m => m.Write(It.Is<string>(c => c == "Not available at the moment: ")));
            consoleOperationsMock.Verify(
                m => m.Write(It.Is<string>(c => c == "Capp")));
            consoleOperationsMock.Verify(
                m => m.Write(It.Is<string>(c => c == "Latte")));
            consoleOperationsMock.Verify(
                m => m.Write(It.Is<string>(c => c == "LongBlack")));
            consoleOperationsMock.Verify(
                m => m.Write(It.Is<string>(c => c == "Espresso")));
            consoleOperationsMock.Verify(
                m => m.Write(It.Is<string>(c => c == "Mocca")));
            consoleOperationsMock.Verify(
                m => m.Write(It.Is<string>(c =>
                    c == "Choose a drink, type 'm' to see menu or 'r' to refill or 'e' to exit.")));
        }

        [Test]
        public void DoesntShowNotAvailableAtTheMomentWhenAllDrinksAreAvailable()
        {
            //Arrange
            
            IRefiller.IRefiller newRefiller = new RefillerMock();
            CoffeeMachine.CoffeeMachine testCoffeMachine =
                new CoffeeMachine.CoffeeMachine(true, 20, 20, 20, 20, newRefiller);

            var consoleOperationsMock = new Mock<IOConsoleService>();
            CofeeMachineScreen testScreen = new CofeeMachineScreen(consoleOperationsMock.Object, testCoffeMachine);

            //act

            testScreen.HandleChoice("m");

            //Assert
            
            consoleOperationsMock.Verify(m=>m.Write("Not available at the moment: "), Times.Never());
            

        }
        
    }
}