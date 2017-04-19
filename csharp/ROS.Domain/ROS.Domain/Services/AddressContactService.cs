using AutoMapper;
using ROS.Domain.Contexts;
using ROS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS.Domain.Services
{
    public class AddressContactService
    {
        private readonly AddressContactContext _addressContactContext;

        public AddressContactService(AddressContactContext addressContactContext)
        {
            _addressContactContext = addressContactContext;
        }

        public IEnumerable<AddressContact> GetAll()
        {
            return _addressContactContext.AddressContacts;
        }

        public AddressContact Add(AddressContact addressContact)
        {
            var returnedAddressContact = _addressContactContext.AddressContacts.Add(addressContact);
            _addressContactContext.SaveChanges();
            return returnedAddressContact;
        }

        public AddressContact Remove(AddressContact addressContact)
        {
            var removedAddressContact = _addressContactContext.AddressContacts.Remove(addressContact);
            _addressContactContext.SaveChanges();
            return removedAddressContact;
        }

        public AddressContact Edit(AddressContact addressContact)
        {

            var dbAddressContact = _addressContactContext.AddressContacts.SingleOrDefault(a => a.Id == addressContact.Id);

            if (dbAddressContact == null)
            {
                throw new Exception("Can't find address contact in db!");
            }

            dbAddressContact.BoxNumber = addressContact.BoxNumber;
            dbAddressContact.StreetAddress = addressContact.StreetAddress;
            dbAddressContact.City = addressContact.City;
            dbAddressContact.ZipCode = addressContact.ZipCode;
            dbAddressContact.PhoneNumber = addressContact.PhoneNumber;
            dbAddressContact.NextOfKin = addressContact.NextOfKin;
            dbAddressContact.Country = addressContact.Country;

            _addressContactContext.SaveChanges();

            return addressContact;
        }
    }
}