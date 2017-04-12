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

        public void Add(AddressContact addressContact)
        {
            AddToDb(addressContact);
        }

        public void AddToDb (AddressContact addressContact)
        {
            _addressContactContext.AddressContacts.Add(addressContact);
            _addressContactContext.SaveChanges();
        }
    }
}
