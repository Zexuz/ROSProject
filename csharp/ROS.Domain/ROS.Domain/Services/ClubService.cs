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
        }
        public void Delete(int id)
        {
            Club club = db.Clubs.Find(id);
            db.Clubs.Remove(club);
            db.SaveChanges();
            //var removeClub = GetAll().SingleOrDefault(c => c.Id == club.Id);
            //removeClub.
            //var _club = _ClubContext.Clubs.Remove(club);
            //_ClubContext.SaveChanges();
            //return _club;
        }
        public Club Edit(Club club)
        {
            var _club = _ClubContext.Clubs.SingleOrDefault(c => c.Id == club.Id);
           // _club.ContactPersonsId = club.ContactPersonsId;
          //  _club.AddressContactId = club.AddressContactId;
            _club.Name = club.Name;
            _club.RegistrationDate = club.RegistrationDate;
            _club.HomePage = club.HomePage;
            _club.Logo = club.Logo;
            _club.AddressContact.City = club.AddressContact.City;
            _club.AddressContact.Country = club.AddressContact.Country;
            _club.AddressContact.BoxNumber = club.AddressContact.BoxNumber;           
            _club.AddressContact.StreetAddress = club.AddressContact.StreetAddress;
            _club.AddressContact.ZipCode = club.AddressContact.ZipCode;
            _club.AddressContact.PhoneNumber = club.AddressContact.PhoneNumber;
            _ClubContext.Context.SaveChanges();
            return club;
        }
    }
}
