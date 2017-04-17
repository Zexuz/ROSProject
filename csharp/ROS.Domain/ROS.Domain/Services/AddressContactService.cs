using AutoMapper;
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
        public EntityDataModel db = new EntityDataModel();

        public void Add(AddressContact addressContact)
        {
            AddToDb(addressContact);
        }

        public void AddToDb (AddressContact addressContact)
        {
            db.AddressContacts.Add(addressContact);
            db.SaveChanges();
        }
    }
}
