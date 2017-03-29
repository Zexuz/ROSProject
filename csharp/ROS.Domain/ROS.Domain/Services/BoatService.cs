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
        public EntityDataModel db = new EntityDataModel();

        public void Add(Boat boat)
        {
            db.Boats.Add(boat);
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
