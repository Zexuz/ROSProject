using System.Collections.Generic;
using ROS.Domain.Models;

namespace ROS.Domain.Services
{
    public interface IAdminService
    {
        bool IsUserSysAdmin(User adminUser);
        SysAdmin AddSysAdmin(User newAdminUser, User adminUser);
        List<SysAdmin> GetAll(User adminUser);
    }
}