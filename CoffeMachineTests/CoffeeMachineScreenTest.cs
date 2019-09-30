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
        }
    }
}