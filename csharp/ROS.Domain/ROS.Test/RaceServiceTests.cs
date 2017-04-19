using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Authentication;
using FakeItEasy;
using NUnit.Framework;
using ROS.Domain.Contexts;
using ROS.Domain.Models;
using ROS.Domain.Services;

namespace ROS.Test
{
    [TestFixture]
    public class RaceServiceTests
    {
        [Test]
        public void Create_Race_As_Admin()
        {
            var adminUser = new User()
            {
                AddressContactId = 1,
                Email = "Test@gmail.com",
                FirstName = "Robin",
                LastName = "Edbom",
                Password = "pw",
                DateOfBirth = DateTime.Parse("1996-11-07"),
                Id = 1
            };

            var data = new List<RaceEvent>().AsQueryable();

            var eventToAdd = new RaceEvent()
            {
                Class = "Class?",
                EventId = 1,
                Id = 1,
                MaxHandicap = 2,
                MinHandicap = 1,
                Type = "Speed race"
            };

            // Arrange
            var fakeDbSet = A.Fake<DbSet<RaceEvent>>(o => o.Implements(typeof(IQueryable<RaceEvent>)).Implements(typeof(IDbAsyncEnumerable<RaceEvent>)));

            A.CallTo(() => ((IQueryable<RaceEvent>) fakeDbSet).Provider).Returns(data.Provider);
            A.CallTo(() => ((IQueryable<RaceEvent>) fakeDbSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<RaceEvent>) fakeDbSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IQueryable<RaceEvent>) fakeDbSet).GetEnumerator()).Returns(data.GetEnumerator());

            var fakeContext = A.Fake<RaceEventContext>();


            A.CallTo(() => fakeContext.RaceEvents).Returns(fakeDbSet);
            A.CallTo(() => fakeContext.RaceEvents.Add(eventToAdd)).Returns(eventToAdd);


            var fakeAdminSercice = A.Fake<IAdminService>();
            A.CallTo(() => fakeAdminSercice.IsUserSysAdmin(adminUser)).Returns(true);


            var raceEventService = new RaceEventService(fakeContext, fakeAdminSercice);
            // Act

            var raceEvent = raceEventService.Add(eventToAdd, adminUser);

            // Assert
            Assert.AreEqual(1,raceEvent.Id);
            Assert.AreEqual(1,raceEvent.MinHandicap);
            Assert.AreEqual(1,raceEvent.EventId);

        }

        [Test]
        public void Create_Race_As_Admin_InvalidCredentialException_Thrown()
        {
            var adminUser = new User()
            {
                AddressContactId = 1,
                Email = "Test@gmail.com",
                FirstName = "Robin",
                LastName = "Edbom",
                Password = "pw",
                DateOfBirth = DateTime.Parse("1996-11-07"),
                Id = 1
            };

            var data = new List<RaceEvent>().AsQueryable();

            var eventToAdd = new RaceEvent()
            {
                Class = "Class?",
                EventId = 1,
                Id = 1,
                MaxHandicap = 2,
                MinHandicap = 1,
                Type = "Speed race"
            };

            // Arrange
            var fakeDbSet = A.Fake<DbSet<RaceEvent>>(o => o.Implements(typeof(IQueryable<RaceEvent>)).Implements(typeof(IDbAsyncEnumerable<RaceEvent>)));

            A.CallTo(() => ((IQueryable<RaceEvent>) fakeDbSet).Provider).Returns(data.Provider);
            A.CallTo(() => ((IQueryable<RaceEvent>) fakeDbSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<RaceEvent>) fakeDbSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IQueryable<RaceEvent>) fakeDbSet).GetEnumerator()).Returns(data.GetEnumerator());

            var fakeContext = A.Fake<RaceEventContext>();


            A.CallTo(() => fakeContext.RaceEvents).Returns(fakeDbSet);
            A.CallTo(() => fakeContext.RaceEvents.Add(eventToAdd)).Returns(eventToAdd);


            var fakeAdminSercice = A.Fake<IAdminService>();
            A.CallTo(() => fakeAdminSercice.IsUserSysAdmin(adminUser)).Returns(false);


            var raceEventService = new RaceEventService(fakeContext, fakeAdminSercice);
            // Act

            var testCode = new TestDelegate(() => raceEventService.Add(eventToAdd, adminUser));
            Assert.Throws<InvalidCredentialException>(testCode);

        }
    }
}