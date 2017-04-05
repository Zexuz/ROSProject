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

namespace ROS.Test
{
    [TestFixture]
    public class AdminServiceTests
    {
        [Test]
        public void User_Is_SysAdmin()
        {
            var data = new List<SysAdmin>
            {
                new SysAdmin()
                {
                    Id = 1,
                    UserId = 1
                },
            }.AsQueryable();


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

            // Arrange
            var fakeDbSet = A.Fake<DbSet<SysAdmin>>(o => o.Implements(typeof(IQueryable<SysAdmin>)).Implements(typeof(IDbAsyncEnumerable<SysAdmin>)));

            A.CallTo(() => ((IQueryable<SysAdmin>) fakeDbSet).Provider).Returns(data.Provider);
            A.CallTo(() => ((IQueryable<SysAdmin>) fakeDbSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<SysAdmin>) fakeDbSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IQueryable<SysAdmin>) fakeDbSet).GetEnumerator()).Returns(data.GetEnumerator());

            var fakeContext = A.Fake<SysAdminContext>();


            A.CallTo(() => fakeContext.SysAdmins).Returns(fakeDbSet);

            var adminService = new AdminService(fakeContext);

            // Act
            var isUserSysAdmin = adminService.IsUserSysAdmin(adminUser);

            Assert.IsTrue(isUserSysAdmin);
        }

        [Test]
        public void User_Is_Not_SysAdmin()
        {
            var data = new List<SysAdmin>
            {
                new SysAdmin()
                {
                    Id = 1,
                    UserId = 2
                },
            }.AsQueryable();


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

            // Arrange
            var fakeDbSet = A.Fake<DbSet<SysAdmin>>(o => o.Implements(typeof(IQueryable<SysAdmin>)).Implements(typeof(IDbAsyncEnumerable<SysAdmin>)));

            A.CallTo(() => ((IQueryable<SysAdmin>) fakeDbSet).Provider).Returns(data.Provider);
            A.CallTo(() => ((IQueryable<SysAdmin>) fakeDbSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<SysAdmin>) fakeDbSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IQueryable<SysAdmin>) fakeDbSet).GetEnumerator()).Returns(data.GetEnumerator());

            var fakeContext = A.Fake<SysAdminContext>();


            A.CallTo(() => fakeContext.SysAdmins).Returns(fakeDbSet);

            var adminService = new AdminService(fakeContext);

            // Act
            var isUserSysAdmin = adminService.IsUserSysAdmin(adminUser);

            Assert.IsFalse(isUserSysAdmin);
        }

        [Test]
        public void SysAdmin_Adds_Another_SysAdmin_Sucess()
        {
            var data = new List<SysAdmin>
            {
                new SysAdmin()
                {
                    Id = 1,
                    UserId = 1
                },
            }.AsQueryable();

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

            var newAdminUser = new User()
            {
                AddressContactId = 2,
                Email = "Test@gmail.com",
                FirstName = "Kalle",
                LastName = "Anka",
                Password = "pw",
                DateOfBirth = DateTime.Parse("1996-11-07"),
                Id = 2
            };

            // Arrange
            var fakeDbSet = A.Fake<DbSet<SysAdmin>>(o => o.Implements(typeof(IQueryable<SysAdmin>)).Implements(typeof(IDbAsyncEnumerable<SysAdmin>)));

            A.CallTo(() => ((IQueryable<SysAdmin>) fakeDbSet).Provider).Returns(data.Provider);
            A.CallTo(() => ((IQueryable<SysAdmin>) fakeDbSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<SysAdmin>) fakeDbSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IQueryable<SysAdmin>) fakeDbSet).GetEnumerator()).Returns(data.GetEnumerator());

            var fakeContext = A.Fake<SysAdminContext>();


            A.CallTo(() => fakeContext.SysAdmins).Returns(fakeDbSet);

            var adminService = new AdminService(fakeContext);

            // Act
            adminService.AddSysAdmin(newAdminUser, adminUser);
            //Assert
            //Have we not thrown a error by now it was a sucess
        }

        [Test]
        public void SysAdmin_Adds_Another_SysAdmin_InvalidCredentialException_Thrown()
        {
            var data = new List<SysAdmin>
            {
                new SysAdmin()
                {
                    Id = 1,
                    UserId = 3
                },
            }.AsQueryable();

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

            var newAdminUser = new User()
            {
                AddressContactId = 2,
                Email = "Test@gmail.com",
                FirstName = "Kalle",
                LastName = "Anka",
                Password = "pw",
                DateOfBirth = DateTime.Parse("1996-11-07"),
                Id = 2
            };

            // Arrange
            var fakeDbSet = A.Fake<DbSet<SysAdmin>>(o => o.Implements(typeof(IQueryable<SysAdmin>)).Implements(typeof(IDbAsyncEnumerable<SysAdmin>)));

            A.CallTo(() => ((IQueryable<SysAdmin>) fakeDbSet).Provider).Returns(data.Provider);
            A.CallTo(() => ((IQueryable<SysAdmin>) fakeDbSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<SysAdmin>) fakeDbSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IQueryable<SysAdmin>) fakeDbSet).GetEnumerator()).Returns(data.GetEnumerator());

            var fakeContext = A.Fake<SysAdminContext>();


            A.CallTo(() => fakeContext.SysAdmins).Returns(fakeDbSet);

            var adminService = new AdminService(fakeContext);

            // Act
            var code = new TestDelegate(() => adminService.AddSysAdmin(newAdminUser, adminUser));

            //Assert
            Assert.Throws<InvalidCredentialException>(code);
        }

        [Test]
        public void No_Admins_Found()
        {
            var data = new List<SysAdmin>
            {
            }.AsQueryable();

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

            // Arrange
            var fakeDbSet = A.Fake<DbSet<SysAdmin>>(o => o.Implements(typeof(IQueryable<SysAdmin>)).Implements(typeof(IDbAsyncEnumerable<SysAdmin>)));

            A.CallTo(() => ((IQueryable<SysAdmin>) fakeDbSet).Provider).Returns(data.Provider);
            A.CallTo(() => ((IQueryable<SysAdmin>) fakeDbSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<SysAdmin>) fakeDbSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IQueryable<SysAdmin>) fakeDbSet).GetEnumerator()).Returns(data.GetEnumerator());

            var fakeContext = A.Fake<SysAdminContext>();


            A.CallTo(() => fakeContext.SysAdmins).Returns(fakeDbSet);

            var adminService = new AdminService(fakeContext);

            // Act
            var isUserSysAdmin = adminService.IsUserSysAdmin(adminUser);

            Assert.IsFalse(isUserSysAdmin);
        }

        [Test]
        public void Get_All_Admins()
        {
            var data = new List<SysAdmin>
            {
                new SysAdmin()
                {
                    Id = 1,
                    UserId = 1
                },
                new SysAdmin()
                {
                    Id = 2,
                    UserId = 2
                },
                new SysAdmin()
                {
                    Id = 10,
                    UserId = 10
                },
            }.AsQueryable();

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

            // Arrange
            var fakeDbSet = A.Fake<DbSet<SysAdmin>>(o => o.Implements(typeof(IQueryable<SysAdmin>)).Implements(typeof(IDbAsyncEnumerable<SysAdmin>)));

            A.CallTo(() => ((IQueryable<SysAdmin>) fakeDbSet).Provider).Returns(data.Provider);
            A.CallTo(() => ((IQueryable<SysAdmin>) fakeDbSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<SysAdmin>) fakeDbSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IQueryable<SysAdmin>) fakeDbSet).GetEnumerator()).Returns(data.GetEnumerator());

            var fakeContext = A.Fake<SysAdminContext>();


            A.CallTo(() => fakeContext.SysAdmins).Returns(fakeDbSet);
            var adminService = new AdminService(fakeContext);


            // Act
            var allAdmins = adminService.GetAll(adminUser);

            //Assert
            Assert.AreEqual(3, allAdmins.Count);
        }

        [Test]
        public void Get_All_Admins_InvalidCredentialException_Thrown()
        {
            var data = new List<SysAdmin>
            {
                new SysAdmin()
                {
                    Id = 1,
                    UserId = 1
                },
                new SysAdmin()
                {
                    Id = 2,
                    UserId = 2
                },
                new SysAdmin()
                {
                    Id = 10,
                    UserId = 10
                },
            }.AsQueryable();

            var adminUser = new User()
            {
                AddressContactId = 1,
                Email = "Test@gmail.com",
                FirstName = "Robin",
                LastName = "Edbom",
                Password = "pw",
                DateOfBirth = DateTime.Parse("1996-11-07"),
                Id =30
            };

            // Arrange
            var fakeDbSet = A.Fake<DbSet<SysAdmin>>(o => o.Implements(typeof(IQueryable<SysAdmin>)).Implements(typeof(IDbAsyncEnumerable<SysAdmin>)));

            A.CallTo(() => ((IQueryable<SysAdmin>) fakeDbSet).Provider).Returns(data.Provider);
            A.CallTo(() => ((IQueryable<SysAdmin>) fakeDbSet).Expression).Returns(data.Expression);
            A.CallTo(() => ((IQueryable<SysAdmin>) fakeDbSet).ElementType).Returns(data.ElementType);
            A.CallTo(() => ((IQueryable<SysAdmin>) fakeDbSet).GetEnumerator()).Returns(data.GetEnumerator());

            var fakeContext = A.Fake<SysAdminContext>();


            A.CallTo(() => fakeContext.SysAdmins).Returns(fakeDbSet);
            var adminService = new AdminService(fakeContext);


            // Act
            var code = new TestDelegate(() => adminService.GetAll(adminUser));

            //Assert
            Assert.Throws<InvalidCredentialException>(code);
        }
    }
}