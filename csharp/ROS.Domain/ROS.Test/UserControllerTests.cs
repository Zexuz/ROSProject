using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using FakeItEasy;
using NUnit.Framework;
using ROS.Domain.Contexts;
using ROS.Domain.Models;
using ROS.Domain.Services;


namespace ROS.Test
{
    [TestFixture]
    public class UserControllerTests
    {

        [Test]
        public void Get_Users_Returns_three_Users_Successfuly_Test()
        {
            var data = new List<User>
            {
                new User()
                {
                    AddressContactId = 1,
                    Email = "Test@gmail.com",
                    FirstName = "Robin",
                    LastName = "Edbom",
                    Password = "pw",
                    DateOfBirth = DateTime.Parse("1996-11-07"),
                    Id = 1
                },
                new User()
                {
                    AddressContactId = 2,
                    Email = "Test2@gmail.com",
                    FirstName = "Kalle",
                    LastName = "Edbom",
                    Password = "pw",
                    DateOfBirth = DateTime.Parse("1996-11-07"),
                    Id = 2
                },
                new User()
                {
                    AddressContactId = 3,
                    Email = "Test@gmail.com",
                    FirstName = "David",
                    LastName = "Edbom",
                    Password = "pw",
                    DateOfBirth = DateTime.Parse("1996-11-07"),
                    Id = 3
                }
            }.AsQueryable();

            // Arrange
            var fakeDbSet = A.Fake<DbSet<User>>(o => o.Implements(typeof(IQueryable<User>)).Implements(typeof(IDbAsyncEnumerable<User>)));


            A.CallTo(() => ((IQueryable<User>)fakeDbSet).Provider).Returns(data.Provider);
            A.CallTo(() => ((IQueryable<User>)fakeDbSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<User>)fakeDbSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IQueryable<User>)fakeDbSet).GetEnumerator()).Returns(data.GetEnumerator());

            var fakeContext = A.Fake<UserContext>();
            A.CallTo(() => fakeContext.Users).Returns(fakeDbSet);

            var userService = new UserService(fakeContext);

            // Act
            var users = userService.GetAll().ToList();

            // Assert
            Assert.AreEqual(3, users.Count(), "Count should be 3");
            Assert.AreEqual(1, users.First().Id, "Id Should be 1");
            Assert.AreEqual("Robin", users.First().FirstName, "FirstName Should be Robin");
            Assert.AreEqual("Edbom", users.First().LastName, "LastName Should be Edbom");
        }

        [Test]
        public void Test()
        {
            var data = new List<User>().AsQueryable();

            // Arrange
            var fakeDbSet = A.Fake<DbSet<User>>(o => o.Implements(typeof(IQueryable<User>)).Implements(typeof(IDbAsyncEnumerable<User>)));

            A.CallTo(() => ((IQueryable<User>)fakeDbSet).Provider).Returns(data.Provider);
            A.CallTo(() => ((IQueryable<User>)fakeDbSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<User>)fakeDbSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IQueryable<User>)fakeDbSet).GetEnumerator()).Returns(data.GetEnumerator());

            var fakeContext = A.Fake<UserContext>();
            A.CallTo(() => fakeContext.Users).Returns(fakeDbSet);

            var userService = new UserService(fakeContext);

            // Act
            var users = userService.GetAll().ToList();

            // Assert
            Assert.AreEqual(3, users.Count(), "Count should be 3");
            Assert.AreEqual(1, users.First().Id, "Id Should be 1");
            Assert.AreEqual("Robin", users.First().FirstName, "FirstName Should be Robin");
            Assert.AreEqual("Edbom", users.First().LastName, "LastName Should be Edbom");
        }

    }
}