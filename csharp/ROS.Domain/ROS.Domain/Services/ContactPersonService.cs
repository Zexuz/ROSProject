using ROS.Domain.Contexts;
using ROS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS.Domain.Services
{
    public class ContactPersonService
    {
        private readonly ContactPersonContext _contactPersonContext;

        public ContactPersonService(ContactPersonContext contactPersonContext)
        {
            _contactPersonContext = contactPersonContext;
        }

        public IEnumerable<ContactPerson> GetAll()
        {
            return _contactPersonContext.ContactPersons;
        }

        public ContactPerson Add(ContactPerson contactPerson)
        {
            var returnedContactPerson = _contactPersonContext.ContactPersons.Add(contactPerson);
            _contactPersonContext.SaveChanges();
            return returnedContactPerson;
        }

        public ContactPerson Remove(ContactPerson contactPerson)
        {
            var removedContactPerson = _contactPersonContext.ContactPersons.Remove(contactPerson);
            _contactPersonContext.SaveChanges();
            return removedContactPerson;
        }

        public ContactPerson Edit(ContactPerson contactPerson)
        {

            var dbContactPerson = _contactPersonContext.ContactPersons.SingleOrDefault(c => c.Id == contactPerson.Id);

            if (dbContactPerson == null)
            {
                throw new Exception("Can't find contact person in db!");
            }

            dbContactPerson.Email = contactPerson.Email;
            dbContactPerson.PhoneNumber = contactPerson.PhoneNumber;
            dbContactPerson.UserId = contactPerson.UserId;

            _contactPersonContext.SaveChanges();

            return contactPerson;
        }
    }
}
