using System.Collections.Generic;
using System.Web.Mvc;
using NUnit.Framework;
using ROS.Models;
using ROS.MVC.Controllers;

namespace ROS.Test
{
    [TestFixture]
    public class UserControllerTests
    {

        [Test]
        public void Test()
        {

            var controller = new UserController();
            var result = controller.Index() as ViewResult;

            var models = (List<User>) result.Model;
            Assert.AreEqual(0, models.Count);
        }

    }
}