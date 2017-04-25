using ROS.Domain.Contexts;
using ROS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS.Domain.Services
{
    public class RegattaService
    {
        private readonly RegattaContext _regattaContext;

        public RegattaService(RegattaContext regattaContext)
        {
            _regattaContext = regattaContext;
        }

        public IEnumerable<Regatta> GetAll()
        {
            return _regattaContext.Regattas;
        }

        public Regatta FindById(int id)
        {
            return _regattaContext.Regattas.FirstOrDefault(r => r.Id == id);
        }

        public Regatta Add(Regatta regatta)
        {
            var returnedRegatta = _regattaContext.Regattas.Add(regatta);
            _regattaContext.Context.SaveChanges();
            return returnedRegatta;
        }

        public Regatta Remove(Regatta regatta)
        {
            var removedRegatta = _regattaContext.Regattas.Remove(regatta);
            _regattaContext.SaveChanges();
            return removedRegatta;
        }

        public Regatta Edit(Regatta regatta)
        {

            var dbRegatta = _regattaContext.Regattas.SingleOrDefault(r => r.Id == regatta.Id);

            if (dbRegatta == null)
            {
                throw new Exception("Can't find regatta in db!");
            }

            dbRegatta.AddressContactId = regatta.AddressContactId;
            dbRegatta.ContactPersonsId = regatta.ContactPersonsId;
            dbRegatta.HostingClubId = regatta.HostingClubId;
            dbRegatta.Name = regatta.Name;
            dbRegatta.StartDateTime = regatta.StartDateTime;
            dbRegatta.EndDateTime = regatta.EndDateTime;
            dbRegatta.Fee = regatta.Fee;
            dbRegatta.Description = regatta.Description;

            _regattaContext.SaveChanges();

            return regatta;
        }
    }
}
