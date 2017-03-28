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
        private EntityDataModel db = new EntityDataModel();
        private MapperConfiguration config = new MapperConfiguration(cfg => {cfg.CreateMap<PocoBoat, Boat>();
        });

        public void Add(PocoBoat boat)
        {
            var mapper = config.CreateMapper();
            Boat newBoat = mapper.Map<Boat>(boat);
            db.Boats.Add(newBoat);
            db.SaveChanges();
        }
    }
}
