using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using FakeItEasy;
using NUnit.Framework;
using ROS.Domain.Contexts;
using ROS.Domain.Models;


namespace ROS.Test
{
    [TestFixture]
    public class UserControllerTests
    {

        [Test]
        public void User_Sign_Up_Succeded_Test()
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
            Assert.AreEqual(1, users.Count(), "Count should be 1");
            Assert.AreEqual(1, users.First().Id, "Id Should be 1");
            Assert.AreEqual("Robin", users.First().FirstName, "FirstName Should be Robin");
            Assert.AreEqual("Edbom", users.First().LastName, "LastName Should be Edbom");
        }

    }

    public class UserService
    {
        private readonly UserContext _userContext;

        public UserService(UserContext userContext)
        {
            _userContext = userContext;
        }

        public IEnumerable<User> GetAll()
        {
            return _userContext.Users;
        }
    }
}