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
    public class ExerciseControllerTests
    {
        internal static Random rnd = new Random();
        [TestMethod()]
        public void AddTest()
        {
            // Activity activity, DateTime begin, DateTime stop

            var userName = Guid.NewGuid().ToString();
            User user = new User(userName);
            string name = Guid.NewGuid().ToString();
            Double cal = rnd.Next(100, 500);
            var act = new Activity(name, cal);
            DateTime start = DateTime.Now.AddHours(-1.0);
            DateTime stop = DateTime.Now;
            var temp = new ExerciseController(user);
            temp.Add(act, start, stop);

            Assert.AreEqual(temp.Activities.First<Activity>().Name, name);
        }
    }
}