using System.Web.Mvc;
using NUnit.Framework;
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
            var result = controller.Details(2) as ViewResult;
            Assert.AreEqual("Details", result.ViewName);
        }

    }
}