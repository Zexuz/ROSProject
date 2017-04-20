using ROS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROS.Domain.Contexts
{
    public class ClubAdminContext : MasterContext
    {
        public virtual DbSet<ClubAdmin> ClubAdmins { get; set; }

        public ClubAdminContext()
        {
            ClubAdmins = Context.Set<ClubAdmin>(); ;
        }
    }
}
