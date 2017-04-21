using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using ROS.Domain.Contexts;
using ROS.Domain.Models;

namespace ROS.Domain.Services
{
    public class ClubAdminService
    {
        private readonly ClubAdminContext _context;

        public ClubAdminService(ClubAdminContext context)
        {
            _context = context;
        }

        public bool IsUserClubAdmin(User adminUser, Club club)
        {
            var user = _context.ClubAdmins.SingleOrDefault(admin => admin.Id == adminUser.Id && admin.ClubId == club.Id);
            return user != null;
        }

        public ClubAdmin AddClubAdmin(User newAdminUser, User adminUser, Club club)
        {
            if (!IsUserClubAdmin(adminUser, club))
            {
                throw new InvalidCredentialException($"That user with id '{adminUser.Id}' does not have premission to add new admins");
            }

            var clubAdmin = new ClubAdmin
            {
                UserId = newAdminUser.Id
            };

            var cadmin = _context.ClubAdmins.Add(clubAdmin);
            _context.Context.SaveChanges();
            return cadmin;
        }

        public List<ClubAdmin> GetAll()
        {
            return _context.ClubAdmins.ToList();
        }

        public List<ClubAdmin> GetAllByClub(Club club)
        {
            return _context.ClubAdmins.Where(a => a.ClubId == club.Id).ToList();
        }
    }
}