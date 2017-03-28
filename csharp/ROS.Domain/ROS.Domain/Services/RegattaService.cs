using AutoMapper;
using ROS.Domain.Models;
using ROS.Domain.PocoClasses.Entries;
using ROS.Domain.PocoClasses.Regattas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS.Domain.Services
{
    public class RegattaService
    {
        private MapperConfiguration regattaConfig = new MapperConfiguration(cfg => { cfg.CreateMap<PocoRegatta, Regatta>(); });
        //private MapperConfiguration contactPersonConfig = new MapperConfiguration(cfg => { cfg.CreateMap<PocoContactPerson, ContactPerson>(); });

        public EntityDataModel db = new EntityDataModel();
        public Regatta NewRegatta;
        public ContactPerson NewContactPerson;

        public void Add(PocoRegatta regatta)
        {
            //AddressContactService addressContactService = new AddressContactService();

            //ContactPersonService contactPersonService = new ContactPersonService();
            //var mapper = contactPersonConfig.CreateMapper();
            //NewContactPerson = mapper.Map<ContactPerson>(regatta);
            //contactPersonService.Add(NewContactPerson)

            var mapper = regattaConfig.CreateMapper();
            NewRegatta = mapper.Map<Regatta>(regatta);
            //NewRegatta.AddressContactId =
            //NewRegatta.ContactPersonsId = 
            //NewRegatta.HostingClubId =
            db.Regattas.Add(NewRegatta);
            db.SaveChanges();
        }
    }
}
