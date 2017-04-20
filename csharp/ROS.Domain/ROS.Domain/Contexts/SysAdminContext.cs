using System.Data.Entity;
using ROS.Domain.Models;

namespace ROS.Domain.Contexts
{
    public class SysAdminContext:MasterContext
    {
        public virtual DbSet<SysAdmin> SysAdmins { get; set; }

        public SysAdminContext()
        {
            SysAdmins = Context.Set<SysAdmin>();;
        }
    }
}