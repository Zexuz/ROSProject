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
    public class ClubService
    {
        public EntityDataModel db = new EntityDataModel();
        private readonly ClubContext _ClubContext;

        public ClubService(ClubContext clubContext)
        {
            _ClubContext = clubContext;
        }
        public IEnumerable<Club> GetAll()
        {
            return _ClubContext.Clubs;
        }
        public Club Create(Club club)
        {
            var returnClub = _ClubContext.Clubs.Add(club);
            _ClubContext.Context.SaveChanges();
            
            return returnClub;
            //db.Clubs.Add(club);
            //db.SaveChanges();
        }
        public void Delete(int id)
        {
            Club club = db.Clubs.Find(id);
            db.Clubs.Remove(club);
            db.SaveChanges();
        }
    }
}
