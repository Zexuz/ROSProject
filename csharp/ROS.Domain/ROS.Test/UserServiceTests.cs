using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using FakeItEasy;
using NUnit.Framework;
using ROS.Domain.Interfaces.ContextInterfaces;
using ROS.Domain.Models;
using ROS.Domain.Services;


namespace ROS.Test
{
    [TestFixture]
    public class UserServiceTests
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


            A.CallTo(() => ((IQueryable<User>) fakeDbSet).Provider).Returns(data.Provider);
            A.CallTo(() => ((IQueryable<User>) fakeDbSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<User>) fakeDbSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IQueryable<User>) fakeDbSet).GetEnumerator()).Returns(data.GetEnumerator());

            var fakeContext = A.Fake<IRosContext<User>>();

            A.CallTo(() => fakeContext.DbSet).Returns(fakeDbSet);

            var userService = new UserService(fakeContext);

            // Act
            var users = userService.GetAll().ToList();

            // Assert
            A.CallTo(() => fakeContext.Context.SaveChanges()).MustNotHaveHappened();
            Assert.AreEqual(3, users.Count(), "Count should be 3");
            Assert.AreEqual(1, users.First().Id, "Id Should be 1");
            Assert.AreEqual("Robin", users.First().FirstName, "FirstName Should be Robin");
            Assert.AreEqual("Edbom", users.First().LastName, "LastName Should be Edbom");
        }

        [Test]
        public void Insert_User_To_Database_Success_Test()
        {
            var data = new List<User>().AsQueryable();

            var userToInsert = new User()
            {
                AddressContactId = 1,
                Email = "Test@gmail.com",
                FirstName = "Robin",
                LastName = "Edbom",
                Password = "pw",
                DateOfBirth = DateTime.Parse("1996-11-07"),
                Id = 1
            };

            // Arrange
            var fakeDbSet = A.Fake<DbSet<User>>(o => o.Implements(typeof(IQueryable<User>)).Implements(typeof(IDbAsyncEnumerable<User>)));

            A.CallTo(() => ((IQueryable<User>) fakeDbSet).Provider).Returns(data.Provider);
            A.CallTo(() => ((IQueryable<User>) fakeDbSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<User>) fakeDbSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IQueryable<User>) fakeDbSet).GetEnumerator()).Returns(data.GetEnumerator());

            var fakeContext = A.Fake<IRosContext<User>>();

            A.CallTo(() => fakeContext.DbSet).Returns(fakeDbSet);
            A.CallTo(() => fakeContext.DbSet.Add(userToInsert)).Returns(userToInsert);

            var userService = new UserService(fakeContext);

            // Act
            var user = userService.Add(userToInsert);

            // Assert
            A.CallTo(() => fakeContext.Context.SaveChanges()).MustHaveHappened();
            Assert.AreEqual(1, user.Id, "Id Should be 1");
            Assert.AreEqual("Robin", user.FirstName, "FirstName Should be Robin");
            Assert.AreEqual("Edbom", user.LastName, "LastName Should be Edbom");
        }

        [Test]
        public void Remove_User_From_Database_Success()
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

            var userToDelete = new User()
            {
                AddressContactId = 1,
                Email = "Test@gmail.com",
                FirstName = "Robin",
                LastName = "Edbom",
                Password = "pw",
                DateOfBirth = DateTime.Parse("1996-11-07"),
                Id = 1
            };

            // Arrange
            var fakeDbSet = A.Fake<DbSet<User>>(o => o.Implements(typeof(IQueryable<User>)).Implements(typeof(IDbAsyncEnumerable<User>)));

            A.CallTo(() => ((IQueryable<User>) fakeDbSet).Provider).Returns(data.Provider);
            A.CallTo(() => ((IQueryable<User>) fakeDbSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<User>) fakeDbSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IQueryable<User>) fakeDbSet).GetEnumerator()).Returns(data.GetEnumerator());


            var fakeContext = A.Fake<IRosContext<User>>();


            A.CallTo(() => fakeContext.DbSet).Returns(fakeDbSet);
            A.CallTo(() => fakeContext.DbSet.Remove(userToDelete)).Returns(userToDelete);

            var userService = new UserService(fakeContext);

            // Act
            var user = userService.Remove(userToDelete);

            // Assert
            A.CallTo(() => fakeContext.Context.SaveChanges()).MustHaveHappened();
            Assert.AreEqual(1, user.Id, "Id Should be 1");
            Assert.AreEqual("Robin", user.FirstName, "FirstName Should be Robin");
            Assert.AreEqual("Edbom", user.LastName, "LastName Should be Edbom");
        }

        [Test]
        public void Edit_User_In_Database_Success()
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

            var userToUpdate = new User()
            {
                AddressContactId = 1,
                Email = "newEmail@gmail.com",
                FirstName = "ola",
                LastName = "Edbom",
                Password = "pw",
                DateOfBirth = DateTime.Parse("1996-11-07"),
                Id = 1
            };

            // Arrange
            var fakeDbSet = A.Fake<DbSet<User>>(o => o.Implements(typeof(IQueryable<User>)).Implements(typeof(IDbAsyncEnumerable<User>)));

            A.CallTo(() => ((IQueryable<User>) fakeDbSet).Provider).Returns(data.Provider);
            A.CallTo(() => ((IQueryable<User>) fakeDbSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<User>) fakeDbSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IQueryable<User>) fakeDbSet).GetEnumerator()).Returns(data.GetEnumerator());

            var fakeContext = A.Fake<IRosContext<User>>();


            A.CallTo(() => fakeContext.DbSet).Returns(fakeDbSet);

            var userService = new UserService(fakeContext);

            // Act
            var user = userService.Edit(userToUpdate);

            // Assert
            A.CallTo(() => fakeContext.Context.SaveChanges()).MustHaveHappened();
            Assert.AreEqual(1, user.Id, "Id Should be 1");
            Assert.AreEqual("ola", user.FirstName, "FirstName Should be ola");
            Assert.AreEqual("Edbom", user.LastName, "LastName Should be Edbom");
            Assert.AreEqual("newEmail@gmail.com", user.Email, "Email is wrong");
        }


        [Test]
        public void Edit_User_In_Database_Fails()
        {
            var data = new List<User>().AsQueryable();

            var userToUpdate = new User
            {
                AddressContactId = 1,
                Email = "newEmail@gmail.com",
                FirstName = "ola",
                LastName = "Edbom",
                Password = "pw",
                DateOfBirth = DateTime.Parse("1996-11-07"),
                Id = 1
            };

            // Arrange
            var fakeDbSet = A.Fake<DbSet<User>>(o => o.Implements(typeof(IQueryable<User>)).Implements(typeof(IDbAsyncEnumerable<User>)));

            A.CallTo(() => ((IQueryable<User>) fakeDbSet).Provider).Returns(data.Provider);
            A.CallTo(() => ((IQueryable<User>) fakeDbSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<User>) fakeDbSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IQueryable<User>) fakeDbSet).GetEnumerator()).Returns(data.GetEnumerator());

            var fakeContext = A.Fake<IRosContext<User>>();


            A.CallTo(() => fakeContext.DbSet).Returns(fakeDbSet);

            var userService = new UserService(fakeContext);

            // Act
            var x = new TestDelegate(() => userService.Edit(userToUpdate));

            // Assert
            A.CallTo(() => fakeContext.Context.SaveChanges()).MustNotHaveHappened();
            Assert.Throws(typeof(Exception), x);
        }
    }
}