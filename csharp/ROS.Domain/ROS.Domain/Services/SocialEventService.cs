using System.Security.Authentication;
using ROS.Domain.Contexts;
using ROS.Domain.Models;
using ROS.Domain.Services;

namespace ROS.Test
{
    public class SocialEventService
    {
        private readonly SocialEventContext _context;
        private readonly IAdminService _adminService;

        public SocialEventService(SocialEventContext context, IAdminService adminService)
        {
            _context = context;
            _adminService = adminService;
        }

        public SocialEvent Add(SocialEvent eventToAdd, User adminUser)
        {

            if (!_adminService.IsUserSysAdmin(adminUser))
                throw new InvalidCredentialException(
                    $"That user with id '{adminUser.Id}' does not have premission to run method {nameof(Add)} in service {nameof(RaceEventService)}");

            var eve = _context.SocialEvents.Add(eventToAdd);
            return eve;
        }
    }
}