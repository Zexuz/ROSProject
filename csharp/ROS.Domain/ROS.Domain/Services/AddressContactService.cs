using AutoMapper;
using ROS.Domain.Models;
using ROS.Domain.PocoClasses.Regattas;
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

        public void Add(Regatta_AddressContact_ContactPerson_Create regattaAddressContact)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Regatta_AddressContact_ContactPerson_Create, AddressContact>();
                cfg.RecognizePrefixes("AddressContact_");
            });
            AddressContact NewAddressContact = Mapper.Map<AddressContact>(regattaAddressContact);
            AddToDb(NewAddressContact);
        }

        public void AddToDb (AddressContact addressContact)
        {
            db.AddressContacts.Add(addressContact);
            db.SaveChanges();
        }
    }
}
