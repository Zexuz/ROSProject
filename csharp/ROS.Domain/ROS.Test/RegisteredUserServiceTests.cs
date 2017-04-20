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
    public class RegisteredUserServiceTests
    {
        [Test]
        public void GetAllUserIdsByEntryId_Returns_two_UserIds_Successfuly_Test()
        {
            var data = new List<RegisteredUser>
                {
                    new RegisteredUser() { UserId = 1, EntryId = 1, Id = 1 },
                    new RegisteredUser() { UserId = 2, EntryId = 1, Id = 2 },
                    new RegisteredUser() { UserId = 3, EntryId = 2, Id = 3 },
                }.AsQueryable();

            // Arrange
            var fakeDbSet = A.Fake<DbSet<RegisteredUser>>(o => o.Implements(typeof(IQueryable<RegisteredUser>)).Implements(typeof(IDbAsyncEnumerable<RegisteredUser>)));


            A.CallTo(() => ((IQueryable<RegisteredUser>)fakeDbSet).Provider).Returns(data.Provider);
            A.CallTo(() => ((IQueryable<RegisteredUser>)fakeDbSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<RegisteredUser>)fakeDbSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IQueryable<RegisteredUser>)fakeDbSet).GetEnumerator()).Returns(data.GetEnumerator());

            var fakeContext = A.Fake<RegisteredUserContext>();
            var fakeEntityDataModel = A.Fake<EntityDataModel>();

            A.CallTo(() => fakeContext.Context).Returns(fakeEntityDataModel);
            A.CallTo(() => fakeContext.RegisteredUsers).Returns(fakeDbSet);

            var registeredUserService = new RegisteredUserService(fakeContext);

            // Act
            var userIds = registeredUserService.GetAllUserIdsByEntryId(1).ToList();

            // Assert
            A.CallTo(() => fakeContext.Context.SaveChanges()).MustNotHaveHappened();
            Assert.AreEqual(2, userIds.Count(), "Count should be 2");
            Assert.AreEqual(1, userIds.First(), "UserId Should be 1");

        }

        [Test]
        public void GetAllEntryIdsByUserId_Returns_two_EntryIds_Successfuly_Test()
        {
            var data = new List<RegisteredUser>
                {
                    new RegisteredUser() { UserId = 1, EntryId = 1, Id = 1 },
                    new RegisteredUser() { UserId = 1, EntryId = 2, Id = 2 },
                    new RegisteredUser() { UserId = 2, EntryId = 3, Id = 3 },
                }.AsQueryable();

            // Arrange
            var fakeDbSet = A.Fake<DbSet<RegisteredUser>>(o => o.Implements(typeof(IQueryable<RegisteredUser>)).Implements(typeof(IDbAsyncEnumerable<RegisteredUser>)));


            A.CallTo(() => ((IQueryable<RegisteredUser>)fakeDbSet).Provider).Returns(data.Provider);
            A.CallTo(() => ((IQueryable<RegisteredUser>)fakeDbSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<RegisteredUser>)fakeDbSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IQueryable<RegisteredUser>)fakeDbSet).GetEnumerator()).Returns(data.GetEnumerator());

            var fakeContext = A.Fake<RegisteredUserContext>();
            var fakeEntityDataModel = A.Fake<EntityDataModel>();

            A.CallTo(() => fakeContext.Context).Returns(fakeEntityDataModel);
            A.CallTo(() => fakeContext.RegisteredUsers).Returns(fakeDbSet);

            var registeredUserService = new RegisteredUserService(fakeContext);

            // Act
            var entryIds = registeredUserService.GetAllEntryIdsByUserId(1).ToList();

            // Assert
            A.CallTo(() => fakeContext.Context.SaveChanges()).MustNotHaveHappened();
            Assert.AreEqual(2, entryIds.Count(), "Count should be 2");
            Assert.AreEqual(1, entryIds.First(), "EntryId Should be 1");

        }

        [Test]
        public void JoinEntry_Inserts_RegisteredUser_To_Database_Success_Test()
        {
            var data = new List<RegisteredUser>
                {
                    new RegisteredUser() { UserId = 1, EntryId = 1, Id = 1 },
                    new RegisteredUser() { UserId = 2, EntryId = 2, Id = 2 },
                    new RegisteredUser() { UserId = 3, EntryId = 3, Id = 3 },
                }.AsQueryable();

            // Arrange
            var fakeDbSet = A.Fake<DbSet<RegisteredUser>>(o => o.Implements(typeof(IQueryable<RegisteredUser>)).Implements(typeof(IDbAsyncEnumerable<RegisteredUser>)));


            A.CallTo(() => ((IQueryable<RegisteredUser>)fakeDbSet).Provider).Returns(data.Provider);
            A.CallTo(() => ((IQueryable<RegisteredUser>)fakeDbSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<RegisteredUser>)fakeDbSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IQueryable<RegisteredUser>)fakeDbSet).GetEnumerator()).Returns(data.GetEnumerator());

            var fakeContext = A.Fake<RegisteredUserContext>();
            A.CallTo(() => fakeContext.RegisteredUsers).Returns(fakeDbSet);

            var fakeEntityDataModel = A.Fake<EntityDataModel>();
            A.CallTo(() => fakeContext.Context).Returns(fakeEntityDataModel); 

            var returnedRegisteredUser = new RegisteredUser();
            A.CallTo(() => fakeContext.RegisteredUsers.Add(A<RegisteredUser>._))
                .ReturnsLazily((RegisteredUser ru) => ru);

            var registeredUserService = new RegisteredUserService(fakeContext);

            // Act
            var registeredUser = registeredUserService.JoinEntry(4, 5);

            // Assert
            A.CallTo(() => fakeContext.Context.SaveChanges()).MustHaveHappened();
            Assert.AreEqual(4, registeredUser.UserId, "UserId Should be 4");
            Assert.AreEqual(5, registeredUser.EntryId, "EntryId Should be 5");
        }

        [Test]
        public void Remove_RegisteredUser_From_Database_Success_Test()
        {
            var data = new List<RegisteredUser>
                {
                    new RegisteredUser() { UserId = 1, EntryId = 1, Id = 1 },
                    new RegisteredUser() { UserId = 2, EntryId = 2, Id = 2 },
                    new RegisteredUser() { UserId = 3, EntryId = 3, Id = 3 },
                }.AsQueryable();

            // Arrange
            var fakeDbSet = A.Fake<DbSet<RegisteredUser>>(o => o.Implements(typeof(IQueryable<RegisteredUser>)).Implements(typeof(IDbAsyncEnumerable<RegisteredUser>)));


            A.CallTo(() => ((IQueryable<RegisteredUser>)fakeDbSet).Provider).Returns(data.Provider);
            A.CallTo(() => ((IQueryable<RegisteredUser>)fakeDbSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<RegisteredUser>)fakeDbSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IQueryable<RegisteredUser>)fakeDbSet).GetEnumerator()).Returns(data.GetEnumerator());

            var fakeContext = A.Fake<RegisteredUserContext>();
            var fakeEntityDataModel = A.Fake<EntityDataModel>();

            A.CallTo(() => fakeContext.Context).Returns(fakeEntityDataModel);
            A.CallTo(() => fakeContext.RegisteredUsers).Returns(fakeDbSet);

            var registeredUserService = new RegisteredUserService(fakeContext);

            var returnedRegisteredUser = new RegisteredUser();
            A.CallTo(() => fakeContext.RegisteredUsers.Remove(A<RegisteredUser>._))
                .ReturnsLazily((RegisteredUser ru) => ru);

            var registeredUserToRemove = new RegisteredUser() { UserId = 1, EntryId = 1, Id = 1 };

            // Act
            var registeredUser = registeredUserService.Remove(registeredUserToRemove);


            // Assert
            A.CallTo(() => fakeContext.Context.SaveChanges()).MustHaveHappened();
            Assert.AreEqual(1, registeredUser.UserId, "UserId Should be 1");
            Assert.AreEqual(1, registeredUser.EntryId, "EntryId Should be 1");
        }
    }
}
