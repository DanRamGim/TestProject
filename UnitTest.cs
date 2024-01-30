using Elevator.Controllers;
using Elevator.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Microsoft.Extensions.Logging;


namespace TestProject
{
    [TestFixture]
    public class ControllerTests
    {

        /// <summary>
        /// This test is when you click inside the elevator the floor 1
        /// </summary>
        [Test]
        public void TestInsideElevatorFloor1()
        {
            HomeController obj = new HomeController();
            HomeModel model = new HomeModel();
            model.SelectedFloor = 1;
            RedirectToActionResult actResult = obj.GetOut(model) as RedirectToActionResult;
            Assert.That(actResult.ActionName, Is.EqualTo("Index"));
        }
        /// <summary>
        /// This test is when you click inside the elevator the floors 2 to 4
        /// </summary>
        [Test]
        public void TestInsideElevatorFloors2To4()
        {
            HomeController obj = new HomeController();
            HomeModel model = new HomeModel();
            model.SelectedFloor = 2;
            RedirectToActionResult actResult2 = obj.GetOut(model) as RedirectToActionResult;
            Assert.That(actResult2.ActionName, Is.EqualTo("BetweenFloors"));
            model.SelectedFloor = 3;
            RedirectToActionResult actResult3 = obj.GetOut(model) as RedirectToActionResult;
            Assert.That(actResult3.ActionName, Is.EqualTo("BetweenFloors"));
            model.SelectedFloor = 4;
            RedirectToActionResult actResult4 = obj.GetOut(model) as RedirectToActionResult;
            Assert.That(actResult4.ActionName, Is.EqualTo("BetweenFloors"));
        }

        /// <summary>
        /// This test is when you click inside the elevator the floor 5
        /// </summary>
        [Test]
        public void TestInsideElevatorFloor5()
        {
            HomeController obj = new HomeController();
            HomeModel model = new HomeModel();
            model.SelectedFloor = 5;
            RedirectToActionResult actResult5 = obj.GetOut(model) as RedirectToActionResult;
            Assert.That(actResult5.ActionName, Is.EqualTo("LastFloor"));
        }
        /// <summary>
        /// This test is if the user bypasses the web page and sends a floor different from the previous ones.
        /// </summary>
        [Test]
        public void TestInsideElevatorFloorOther()
        {
            HomeController obj = new HomeController();
            HomeModel model = new HomeModel();
            model.SelectedFloor = 100;
            RedirectToActionResult actResultOther = obj.GetOut(model) as RedirectToActionResult;
            Assert.That(actResultOther.ActionName, Is.EqualTo("InsideElevator"));
        }
    }
}