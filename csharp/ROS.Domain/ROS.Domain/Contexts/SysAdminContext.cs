using System.Data.Entity;
using ROS.Domain.Models;

namespace ROS.Domain.Contexts
{
    public class SysAdminContext
    {
        public virtual DbSet<SysAdmin> SysAdmins { get; set; }

        public SysAdminContext()
        {
            SysAdmins = new EntityDataModel().SysAdmins;
        }
    }
}