using FitApp.DL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace FitApp.DL.Controller.Tests
{
    [TestClass()]
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arenge
            string userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var eatingConroller = new EatingController(userController.CurrentUser);
            var food = new Food(foodName, rnd.Next(50, 500), rnd.Next(60, 80), rnd.Next(5, 10), rnd.Next(200, 500));
            //Act
            eatingConroller.Add(food, 100);

            //Assert
            Assert.AreEqual(food.Name, eatingConroller.Eating.Foods.Last().Key.Name);
        }
    }
}