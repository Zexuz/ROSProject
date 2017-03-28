using NUnit.Framework;
using ROS.Domain.Models;
using ROS.Domain.PocoClasses.Regattas;
using ROS.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS.Test
{
    [TestFixture]
    public class RegattaServiceTests
    {

        private RegattaService _regattaService = new RegattaService();

        [Test]
        public void Add_creates_Regatta()
        {
            PocoRegatta testRegatta = CreateNewRegatta();

            _regattaService.Add(testRegatta);

            Assert.IsInstanceOf(typeof(Regatta), _regattaService.NewRegatta);
        }

        [Test]
        public void Add_creates_right_Regatta()
        {
            PocoRegatta testRegatta = CreateNewRegatta();

            _regattaService.Add(testRegatta);

            Assert.IsTrue(_regattaService.NewRegatta.Name == "test");
        }

        private PocoRegatta CreateNewRegatta()
        {
            PocoRegatta testRegatta = new PocoRegatta();
            testRegatta.ContactPersonsId = 16;
            testRegatta.HostingClubId = 3;
            testRegatta.AddressContactId = 1;
            testRegatta.Name = "test";
            testRegatta.StartDateTime = DateTime.Now;
            testRegatta.EndDateTime = DateTime.Now.AddDays(5);

            return testRegatta;
        }
    }
}
