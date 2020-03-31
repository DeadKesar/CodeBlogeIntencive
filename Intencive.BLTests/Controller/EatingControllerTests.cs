using Microsoft.VisualStudio.TestTools.UnitTesting;
using Intencive.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intencive.BL.Model;

namespace Intencive.BL.Controller.Tests
{
    [TestClass()]
    public class EatingControllerTests
    {
        public static Random rnd = new Random();
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var user = new UserController(userName);
            var eatingController = new EatingController(user.CurentUser);
            var food = new Food(foodName, rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500));
            //Act

            eatingController.Add(food, rnd.Next(100, 500));
            //Assert

            Assert.AreEqual(food.Name, eatingController.Eating.Foods.First().Key.Name);
        }
    }
}