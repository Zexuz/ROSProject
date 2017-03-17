using System;
using NUnit.Framework;
using ROS.Models;
using ROS.Services;

namespace ROS.Test
{
    [TestFixture]
    public class UserQueryServiceTests
    {
        [Test]
        public void UserSerivice_Create_InsertQuery()
        {
            var user = new User
            {
                AddressContactId = 1,
                DateOfBirth = new DateTime(1996, 11, 07),
                Email = "Test@test.com",
                Name = new Name
                {
                    FirstName = "Robin",
                    LastName = "Edbom"
                },
                Password = "password"
            };

            var userService = new UserQueryService();

            var query = userService.GetInsertQuery(user);

            var realQuery =
                "INSERT INTO Users (AddressContactId, Email, Password, FirstName, LastName, DateOfBirth) VALUES (1, 'Test@test.com', 'password', 'Robin', 'Edbom', '1996-11-07');";
            Assert.AreEqual(realQuery, query);
        }
    }
}