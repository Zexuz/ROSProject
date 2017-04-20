using System;
using NUnit.Framework;
using ROS.Domain.Contexts;
using ROS.Domain.Models;
using ROS.Domain.Services;

namespace ROS.Test
{
    [TestFixture]
    public class RandomEntryNrCreatorTest
    {

        [Test]
        public void RandomEntryNrCreator_ResultShouldMatch()
        {
            //Arrange
            EntryService es = new EntryService(new EntryContext());

            // ACT
            var nr = es.RandomEntryNrCreator();


            // Assert
            Assert.True(nr is int);
            Assert.Greater(nr, 99999);

            Assert.AreEqual(nr.ToString().Length, 6);

            Assert.Less(nr, 1000000);
            Assert.True(1000000 > nr && nr > 99999);

        }
    }
}
