using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitApp.DL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitApp.DL.Model;

namespace FitApp.DL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            Gender gender = new Male();
            var birthDate = DateTime.Now.AddYears(-18);
            var contoller = new UserController(userName);
            var weight = 90;
            var height = 190;


            //Act
            contoller.SetNewUserData(gender, birthDate, weight, height);
            var contoller2 = new UserController(userName);

            //Assert
            Assert.AreEqual(userName, contoller.CurrentUser.Name);
            Assert.AreEqual(birthDate, contoller.CurrentUser.BirthDate);
            Assert.AreEqual(gender, contoller.CurrentUser.Gender);
            Assert.AreEqual(weight, contoller.CurrentUser.Weight);
            Assert.AreEqual(height, contoller.CurrentUser.Height);
        }

        [TestMethod()]
        public void SaveTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();

            //Act
            var controller = new UserController(userName);

            //Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}