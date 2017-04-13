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
    public class SocialEventServiceTests
    {
        [Test]
        public void Create_SocialEvent_Success()
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

            
            var eventToAdd = new SocialEvent
            {
                Id = 1,
                EventId = 1,
                Name = "Korv grillning"
            };


            var data = new List<SocialEvent>().AsQueryable();

            // Arrange
            var fakeDbSet = A.Fake<DbSet<SocialEvent>>(o => o.Implements(typeof(IQueryable<SocialEvent>)).Implements(typeof(IDbAsyncEnumerable<SocialEvent>)));

            A.CallTo(() => ((IQueryable<SocialEvent>) fakeDbSet).Provider).Returns(data.Provider);
            A.CallTo(() => ((IQueryable<SocialEvent>) fakeDbSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<SocialEvent>) fakeDbSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IQueryable<SocialEvent>) fakeDbSet).GetEnumerator()).Returns(data.GetEnumerator());

            var fakeContext = A.Fake<SocialEventContext>();


            A.CallTo(() => fakeContext.SocialEvents).Returns(fakeDbSet);
            A.CallTo(() => fakeContext.SocialEvents.Add(eventToAdd)).Returns(eventToAdd);


            var fakeAdminService = A.Fake<IAdminService>();
            A.CallTo(() => fakeAdminService.IsUserSysAdmin(adminUser)).Returns(true);

            var socialEventService = new SocialEventService(fakeContext, fakeAdminService);

            var socialEvent = socialEventService.Add(eventToAdd, adminUser);
//
//            var raceEventService = new RaceEventService(fakeContext, fakeAdminSercice);
//            // Act
//
//            var raceEvent = raceEventService.Add(eventToAdd, adminUser);
//
            // Assert
            Assert.AreEqual(1,socialEvent.Id);
            Assert.AreEqual("Korv grillning",socialEvent.Name);
            Assert.AreEqual(1,socialEvent.EventId);
        }
    }
}