﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FakeItEasy;
using Moq;
using System.Threading.Tasks;
using NUnit.Framework;
using ROS.Domain.Contexts;
using ROS.Domain.Models;
using ROS.Domain.Services;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ROS.Domain.Interfaces.ContextInterfaces;

namespace ROS.Test
{
    [TestFixture]
    class EntryServiceTests
    {
        [Test]
        public void ENTRIES_Get_Entries_Returns_Four_Entries_Successfuly_Test()
        {
            var data = new List<Entry>
            {
                new Entry()
                {
                    Id = 1,
                    BoatId = 1231,
                    SkipperId = 2,
                    RegattaId = 1,
                    Number = 5556,
                    RegistrationDate = DateTime.Now,
                    HasPayed = true
                },
                new Entry()
                {
                    Id = 2,
                    BoatId = 1232,
                    SkipperId = 3,
                    RegattaId = 1,
                    Number = 5557,
                    RegistrationDate = DateTime.Now,
                    HasPayed = true
                },
                new Entry()
                {
                    Id = 3,
                    BoatId = 1233,
                    SkipperId = 4,
                    RegattaId = 1,
                    Number = 5558,
                    RegistrationDate = DateTime.Now,
                    HasPayed = true
                },
                new Entry()
                {
                    Id = 4,
                    BoatId = 1234,
                    SkipperId = 5,
                    RegattaId = 1,
                    Number = 5550,
                    RegistrationDate = DateTime.Now,
                    HasPayed = true
                }
            }.AsQueryable();

            // Arrange
            var fakeDbSet = A.Fake<DbSet<Entry>>(o => o.Implements(typeof(IQueryable<Entry>)).Implements(typeof(IDbAsyncEnumerable<Entry>)));


            A.CallTo(() => ((IQueryable<Entry>)fakeDbSet).Provider).Returns(data.Provider);
            A.CallTo(() => ((IQueryable<Entry>)fakeDbSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<Entry>)fakeDbSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IQueryable<Entry>)fakeDbSet).GetEnumerator()).Returns(data.GetEnumerator());

            var fakeContext = A.Fake<IRosContext<Entry>>();

            //A.CallTo(() => fakeContext.Context.Entries).Returns(fakeDbSet); TODO : Fix that you dont need Context.Set
            A.CallTo(() => fakeContext.Context.Set<Entry>()).Returns(fakeDbSet);

            var entryService = new EntryService(fakeContext);

            // Act
            var entrys = entryService.GetAll().Cast<Entry>().ToList();

            // Assert
            //A.CallTo(() => fakeContext.Context.SaveChanges()).MustNotHaveHappened();            
            Assert.AreEqual(1, entrys.First().Id, "Id Should be 1");
            Assert.AreEqual(2, entrys.First().SkipperId, "SkipperId should be 2");
            Assert.AreEqual(4, entrys.Count(), "Count should be 4");
        }

        [Test]
        public void ENTRIES_Insert_Entry_To_Database_Success_Test()
        {
            var data = new List<Entry>().AsQueryable();

            var EntryToInsert = new Entry()
            {
                Id = 1,
                BoatId = 1231,
                SkipperId = 2,
                RegattaId = 1,
                Number = 5556,
                RegistrationDate = DateTime.Now,
                HasPayed = true
            };

            // Arrange
            var fakeDbSet = A.Fake<DbSet<Entry>>(o => o.Implements(typeof(IQueryable<Entry>)).Implements(typeof(IDbAsyncEnumerable<Entry>)));

            A.CallTo(() => ((IQueryable<Entry>)fakeDbSet).Provider).Returns(data.Provider);
            A.CallTo(() => ((IQueryable<Entry>)fakeDbSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<Entry>)fakeDbSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IQueryable<Entry>)fakeDbSet).GetEnumerator()).Returns(data.GetEnumerator());

            var fakeContext = A.Fake<IRosContext<Entry>>();

            A.CallTo(() => fakeContext.Context.Set<Entry>()).Returns(fakeDbSet);
            A.CallTo(() => fakeContext.Context.Set<Entry>().Add(EntryToInsert)).Returns(EntryToInsert);

            var entryService = new EntryService(fakeContext);

            // Act
            var entry = entryService.Add(EntryToInsert);

            // Assert
            A.CallTo(() => fakeContext.Context.SaveChanges()).MustHaveHappened();
            Assert.AreEqual(1, entry.Id, "Id Should be 1");
            Assert.AreEqual(1231, entry.BoatId, "BoatId should be 1231");
            Assert.AreEqual(5556, entry.Number, "Number should be 5556");
        }

        [Test]
        public void ENTRIES_Remove_Entry_From_Database_Success()
        {
            var data = new List<Entry>
            {
                new Entry()
                {
                    Id = 1,
                    BoatId = 1231,
                    SkipperId = 2,
                    RegattaId = 1,
                    Number = 5556,
                    RegistrationDate = DateTime.Now,
                    HasPayed = true
                },
                new Entry()
                {
                    Id = 2,
                    BoatId = 1232,
                    SkipperId = 3,
                    RegattaId = 1,
                    Number = 5557,
                    RegistrationDate = DateTime.Now,
                    HasPayed = true
                },
                new Entry()
                {
                    Id = 3,
                    BoatId = 1233,
                    SkipperId = 4,
                    RegattaId = 1,
                    Number = 5558,
                    RegistrationDate = DateTime.Now,
                    HasPayed = true
                },
                new Entry()
                {
                    Id = 4,
                    BoatId = 1234,
                    SkipperId = 5,
                    RegattaId = 1,
                    Number = 5550,
                    RegistrationDate = DateTime.Now,
                    HasPayed = true
                }
            }.AsQueryable();

            var entryToDelete = new Entry()
            {
                Id = 4,
                BoatId = 1234,
                SkipperId = 5,
                RegattaId = 1,
                Number = 5550,
                RegistrationDate = DateTime.Now,
                HasPayed = true
            };

            // Arrange
            var fakeDbSet = A.Fake<DbSet<Entry>>(o => o.Implements(typeof(IQueryable<Entry>)).Implements(typeof(IDbAsyncEnumerable<Entry>)));

            A.CallTo(() => ((IQueryable<Entry>)fakeDbSet).Provider).Returns(data.Provider);
            A.CallTo(() => ((IQueryable<Entry>)fakeDbSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<Entry>)fakeDbSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IQueryable<Entry>)fakeDbSet).GetEnumerator()).Returns(data.GetEnumerator());
            

            var fakeContext = A.Fake<IRosContext<Entry>>();


            A.CallTo(() => fakeContext.Context.Set<Entry>()).Returns(fakeDbSet);
            A.CallTo(() => fakeContext.Context.Set<Entry>().Remove(entryToDelete)).Returns(entryToDelete);

            var entryService = new EntryService(fakeContext);

            // Act
            var entry = entryService.Remove(entryToDelete);

            // Assert
            A.CallTo(() => fakeContext.Context.SaveChanges()).MustHaveHappened();
            Assert.AreEqual(4, entry.Id, "Deleted entry should have Id 4");
        }

       
        [Test]
        public void ENTRIES_Get_Entries_By_EntryNumber()
        {
            var data = new List<Entry>
            {
                new Entry()
                {
                    Id = 1,
                    BoatId = 1231,
                    SkipperId = 2,
                    RegattaId = 1,
                    Number = 5556,
                    RegistrationDate = DateTime.Now,
                    HasPayed = true
                },
                new Entry()
                {
                    Id = 2,
                    BoatId = 1232,
                    SkipperId = 3,
                    RegattaId = 1,
                    Number = 5557,
                    RegistrationDate = DateTime.Now,
                    HasPayed = true
                },
                new Entry()
                {
                    Id = 3,
                    BoatId = 1233,
                    SkipperId = 4,
                    RegattaId = 1,
                    Number = 5558,
                    RegistrationDate = DateTime.Now,
                    HasPayed = true
                },
                new Entry()
                {
                    Id = 4,
                    BoatId = 1234,
                    SkipperId = 5,
                    RegattaId = 1,
                    Number = 5550,
                    RegistrationDate = DateTime.Now,
                    HasPayed = true
                }
            }.AsQueryable();

            // Arrange
            var fakeDbSet = A.Fake<DbSet<Entry>>(o => o.Implements(typeof(IQueryable<Entry>)).Implements(typeof(IDbAsyncEnumerable<Entry>)));


            A.CallTo(() => ((IQueryable<Entry>)fakeDbSet).Provider).Returns(data.Provider);
            A.CallTo(() => ((IQueryable<Entry>)fakeDbSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<Entry>)fakeDbSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IQueryable<Entry>)fakeDbSet).GetEnumerator()).Returns(data.GetEnumerator());

            var fakeContext = A.Fake<IRosContext<Entry>>();

            A.CallTo(() => fakeContext.Context.Set<Entry>()).Returns(fakeDbSet);

            var entryService = new EntryService(fakeContext);

            // Act
            var entrys = entryService.GetByEntryNumber(5550);

            // Assert
            A.CallTo(() => fakeContext.Context.SaveChanges()).MustNotHaveHappened();
            Assert.AreEqual(4, entrys.Id, "Should find entry with id 4");
        }
    }
}
