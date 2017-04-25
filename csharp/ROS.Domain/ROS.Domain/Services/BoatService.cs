using ROS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROS.Domain.Contexts;

namespace ROS.Domain.Services
{
    public class BoatService
    {
        private readonly BoatContext _boatContext;

        public BoatService(BoatContext boatContext)
        {
            _boatContext = boatContext;
        }

        public IEnumerable<Boat> GetAll()
        {
            return _boatContext.Boats;
        }

        public Boat Add(Boat boat)
        {   
            if (!GetAll().Any(b => b.SailNumber == boat.SailNumber
                                && b.Type == boat.Type))
            {
                var returnedBoat = _boatContext.Boats.Add(boat);
                _boatContext.Context.SaveChanges();
                return returnedBoat;
            }
            return boat;
        }

        public Boat Remove(Boat boat)
        {
            var removedBoat = _boatContext.Boats.Remove(boat);
            _boatContext.SaveChanges();
            return removedBoat;
        }
    }
}
