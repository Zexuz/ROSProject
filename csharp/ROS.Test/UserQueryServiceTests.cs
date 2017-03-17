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
        public void GetInsertQuery_Returns_Valid_Query()
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
                "INSERT INTO Users (AddressContactId, Email, Password, FirstName, LastName, DateOfBirth) VALUES (1, 'Test@test.com', 'password', 'Robin', 'Edbom', '1996-11-07')";
            Assert.AreEqual(realQuery, query);
        }

        [Test]
        public void GetSelectAllQuery_Returns_Valid_Query()
        {
            var userService = new UserQueryService();

            var query = userService.GetSelectAllQuery();

            Assert.AreEqual("SELECT * FROM Users", query);
        }

        [Test]
        public void GetDeleteByIdQuery_Returns_Valid_Query_With_Id_10()
        {
            var userService = new UserQueryService();

            var query = userService.GetDeleteByIdQuery(10);

            Assert.AreEqual("DELETE FROM Users WHERE Id = 10", query);
        }

        [Test]
        public void GetDeleteByIdQuery_Returns_Valid_Query_With_Id_150()
        {
            var userService = new UserQueryService();

            var query = userService.GetDeleteByIdQuery(150);

            Assert.AreEqual("DELETE FROM Users WHERE Id = 150", query);
        }

        [Test]
        public void GetSelectByIdQuery_Returns_Valid_Query_With_Id_10()
        {
            var userService = new UserQueryService();

            var query = userService.GetSelecByIdQuery(10);

            Assert.AreEqual("SELECT * FROM Users WHERE Id = 10", query);
        }

        [Test]
        public void GetSelectByIdQuery_Returns_Valid_Query_With_Id_150()
        {
            var userService = new UserQueryService();

            var query = userService.GetSelecByIdQuery(150);

            Assert.AreEqual("SELECT * FROM Users WHERE Id = 150", query);
        }

        [Test]
        public void GetUpdateQuery_Returns_Valid_Query()
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
                Password = "password",
                Id = 1
            };

            var userService = new UserQueryService();

            var query = userService.GetUpdateQuery(user);

            Assert.AreEqual(
                "UPDATE Users SET AddressContactId = 1, Email = 'Test@test.com', Password = 'password', FirstName = 'Robin', LastName = 'Edbom', DateOfBirth = '1996-11-07' WHERE Id = 1",
                query);
        }

        [Test]
        public void GetUpdateQuery_Throws_MissingPropertyExcpetion()
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
                Password = "password",
                Id = 1
            };

            var userService = new UserQueryService();

            var query = userService.GetUpdateQuery(user);

            Assert.AreEqual(
                "UPDATE Users SET AddressContactId = 1, Email = 'Test@test.com', Password = 'password', FirstName = 'Robin', LastName = 'Edbom', DateOfBirth = '1996-11-07' WHERE Id = 1",
                query);
        }
    }
}