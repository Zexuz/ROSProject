using ROS.Domain.Models;
using ROS.Domain.PocoClasses.Entries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ROS.Domain.Services
{
    public class BoatService
    {
        private MapperConfiguration config = new MapperConfiguration(cfg => {cfg.CreateMap<PocoBoat, Boat>(); });
        public EntityDataModel db = new EntityDataModel();
        public Boat newBoat;

        public void Add(PocoBoat boat)
        {
            var mapper = config.CreateMapper();
            newBoat = mapper.Map<Boat>(boat);
            db.Boats.Add(newBoat);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Boat boat = db.Boats.Find(id);
            db.Boats.Remove(boat);
            db.SaveChanges();
        }
    }
}
