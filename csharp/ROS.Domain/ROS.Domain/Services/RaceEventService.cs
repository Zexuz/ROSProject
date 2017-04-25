using System.Security.Authentication;
using ROS.Domain.Contexts;
using ROS.Domain.Models;
using ROS.Domain.Services;
using System.Collections.Generic;
using System.Linq;

namespace ROS.Domain.Services
{
    public class RaceEventService
    {
        private readonly RaceEventContext _context;
        private readonly IAdminService _adminService;

        public RaceEventService(RaceEventContext context, IAdminService adminService)
        {
            _context = context;
            _adminService = adminService;
        }

        public RaceEvent GetById(int id)
        {
            return _context.RaceEvents.SingleOrDefault(r => r.Id == id);
        }

        public RaceEvent Add(RaceEvent eventToAdd, User adminUser)
        {
            if (!_adminService.IsUserSysAdmin(adminUser))
                throw new InvalidCredentialException(
                    $"That user with id '{adminUser.Id}' does not have premission to run method {nameof(Add)} in service {nameof(RaceEventService)}");

            var e = _context.RaceEvents.Add(eventToAdd);
            _context.Context.SaveChanges();

            return e;
        }
    }
}