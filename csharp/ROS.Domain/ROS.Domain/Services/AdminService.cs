using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using ROS.Domain.Contexts;
using ROS.Domain.Models;

namespace ROS.Test
{
    public class AdminService
    {
        private readonly SysAdminContext _context;

        public AdminService(SysAdminContext context)
        {
            _context = context;
        }

        public bool IsUserSysAdmin(User adminUser)
        {
            var user = _context.SysAdmins.SingleOrDefault(admin => admin.UserId == adminUser.Id);
            return user != null;
        }

        public SysAdmin AddSysAdmin(User newAdminUser, User adminUser)
        {
            if (!IsUserSysAdmin(adminUser))
            {
                throw new InvalidCredentialException($"That user with id '{adminUser.Id}' does not have premission to add new admins");
            }

            var sysAdmin = new SysAdmin
            {
                UserId = newAdminUser.Id
            };

            var sys = _context.SysAdmins.Add(sysAdmin);
            return sys;
        }

        public List<SysAdmin> GetAll(User adminUser)
        {
            if (!IsUserSysAdmin(adminUser))
            {
                throw new InvalidCredentialException(
                    $"The user with id '{adminUser.Id}' does not have premission to run method {nameof(GetAll)} in service {nameof(AdminService)}");
            }

            return _context.SysAdmins.ToList();
        }
    }
}