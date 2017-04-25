using NUnit.Framework;
using ROS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FakeItEasy;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using ROS.Domain.Contexts;
using ROS.Domain.Services;

namespace ROS.Test
{
    [TestFixture]
    public class ClubServiceTests
    {
        [Test]
        public void GetAll_Returns_Two_Clubs_Successfuly_Test()
        {
            var clubData = new List<Club>
            {
                new Club()
                {
                    AddressContactId =1,
                    Id=1,
                    Name="Seglarna",
                    RegistrationDate= DateTime.Parse("1993-03-03"),
                    Email = "hejsan@svejsan.se",
                    Logo="http//hejsan",
                    HomePage="ollesSeglare.se",

                },
                new Club()
                {
                    AddressContactId =2,
                    Id=12,
                    Name="Degarna",
                    RegistrationDate= DateTime.Parse("1993-12-12"),
                    Email = "hejdo@dejdo.se",
                    Logo="http//hejdo",
                    HomePage="svennesSeglare.se",
                }
            }.AsQueryable();
            //Arrange
            var fakeDbSet = A.Fake<DbSet<Club>>(o => o.Implements(typeof(IQueryable<Club>)).Implements(typeof(IDbAsyncEnumerable<Club>)));

            A.CallTo(() => ((IQueryable<Club>)fakeDbSet).Provider).Returns(clubData.Provider);
            A.CallTo(() => ((IQueryable<Club>)fakeDbSet).Expression).Returns(clubData.Expression);
            A.CallTo(() => ((IQueryable<Club>)fakeDbSet).ElementType).Returns(clubData.ElementType);
            A.CallTo(() => ((IQueryable<Club>)fakeDbSet).GetEnumerator()).Returns(clubData.GetEnumerator());

            var fakeContext = A.Fake<ClubContext>();
            A.CallTo(()=>fakeContext.Clubs).Returns(fakeDbSet);

            var clubService = new ClubService(fakeContext);

            //Act
            var clubs = clubService.GetAll().ToList();

            //Assert
            A.CallTo(() => fakeContext.SaveChanges()).MustNotHaveHappened();
            Assert.AreEqual(2, clubs.Count(), "Count should be 2");
            Assert.AreEqual(1, clubs.First().Id, "Id should be 1");
            Assert.AreEqual("Seglarna", clubs.First().Name, "Name should be Seglarna");
        }
        [Test]
        public void Insert_Club_To_DataBase_Successesfuly_Test()
        {
            var clubData = new List<Club>().AsQueryable();
            
                var newClub = new Club()
                {
                    Id = 1,
                    AddressContactId = 1,                 
                    Name = "Seglarna",
                    RegistrationDate = DateTime.Parse("1993-03-03"),
                    Email = "hejsan@svejsan.se",
                    Logo = "http//hejsan",
                    HomePage = "ollesSeglare.se"

                };
            
            //Arrange
            var fakeDbSet = A.Fake<DbSet<Club>>(o => o.Implements(typeof(IQueryable<Club>)).Implements(typeof(IDbAsyncEnumerable<Club>)));

            A.CallTo(() => ((IQueryable<Club>)fakeDbSet).Provider).Returns(clubData.Provider);
            A.CallTo(() => ((IQueryable<Club>)fakeDbSet).Expression).Returns(clubData.Expression);
            A.CallTo(() => ((IQueryable<Club>)fakeDbSet).ElementType).Returns(clubData.ElementType);
            A.CallTo(() => ((IQueryable<Club>)fakeDbSet).GetEnumerator()).Returns(clubData.GetEnumerator());

            var fakeContext = A.Fake<ClubContext>();

            A.CallTo(() => fakeContext.Clubs).Returns(fakeDbSet);
            A.CallTo(() => fakeContext.Clubs.Add(newClub)).Returns(newClub);

            var clubService = new ClubService(fakeContext);

            //Act
            var club = clubService.Create(newClub);

            //Assert
            A.CallTo(() => fakeContext.SaveChanges()).MustNotHaveHappened();
            Assert.AreEqual("Seglarna", club.Name);
            Assert.AreEqual(1, club.Id);
            Assert.AreEqual(DateTime.Parse("1993-03-03") ,club.RegistrationDate,"RegistrationDate should be 1993-03-03");
        }
    }

    }

