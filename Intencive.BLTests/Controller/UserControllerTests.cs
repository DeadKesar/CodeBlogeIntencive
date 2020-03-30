using Microsoft.VisualStudio.TestTools.UnitTesting;
using Intencive.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intencive.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            var userName = Guid.NewGuid().ToString();
            var genderName = Guid.NewGuid().ToString();
            var birthDate = DateTime.Now.AddYears(-18);
            var weight = 10.0;
            var height = 100.0;
            var user = new UserController(userName);
            user.SetNewUserData(genderName, birthDate, weight, height);
            var user2 = new UserController(userName);
            Assert.AreEqual(user.CurentUser.Name, user2.CurentUser.Name);
            Assert.AreEqual(user.CurentUser.Birth, user2.CurentUser.Birth);
            Assert.AreEqual(user.CurentUser.Gender.Name, user2.CurentUser.Gender.Name);
            Assert.AreEqual(user.CurentUser.Height, user2.CurentUser.Height);
            Assert.AreEqual(user.CurentUser.Weight, user2.CurentUser.Weight);
        }


        [TestMethod()]
        public void SaveTest()
        {
            // Arrange - объявление
            var userName = Guid.NewGuid().ToString();


            // Act - действи
            var controller = new UserController(userName);
            // assert результат
            Assert.AreEqual(userName, controller.CurentUser.Name);
        }
    }
}