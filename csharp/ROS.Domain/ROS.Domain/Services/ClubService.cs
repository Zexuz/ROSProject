using AutoMapper;
using ROS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS.Domain.Services
{
    public class ClubService
    {
        public EntityDataModel db = new EntityDataModel();
        public void Create(Club club)
        {
            db.Clubs.Add(club);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            Club club = db.Clubs.Find(id);
            db.Clubs.Remove(club);
            db.SaveChanges();
        }
    }
}
